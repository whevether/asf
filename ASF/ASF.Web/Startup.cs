using System.IdentityModel.Tokens.Jwt;
using System.IO;
using ASF.Application.DtoMapper;
using ASF.DependencyInjection;
using ASF.Internal.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Minio;
using Minio.AspNetCore;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Discovery.Consul;

namespace ASF.Web;

public class Startup
{
  public Startup(IConfiguration configuration, IWebHostEnvironment env)
  {
    Configuration = configuration;
    Env = env;
  }

  public IConfiguration Configuration { get; }
  public IWebHostEnvironment Env { get; }

  // This method gets called by the runtime. Use this method to add services to the container.
  public void ConfigureServices(IServiceCollection services)
  {
    JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
    var jwtKeyPath = Configuration["ASF:JwtKeyPath"];
    if (string.IsNullOrWhiteSpace(jwtKeyPath))
      jwtKeyPath = Path.Combine(Env.ContentRootPath, "Data", "jwt-rsa.pem");
    RSA.Initialize(jwtKeyPath);
    //添加日志
    services.AddLogging();
    //automapper
    services.AddAutoMapper(cfg =>
    {
      cfg.LicenseKey =
        "eyJhbGciOiJSUzI1NiIsImtpZCI6Ikx1Y2t5UGVubnlTb2Z0d2FyZUxpY2Vuc2VLZXkvYmJiMTNhY2I1OTkwNGQ4OWI0Y2IxYzg1ZjA4OGNjZjkiLCJ0eXAiOiJKV1QifQ.eyJpc3MiOiJodHRwczovL2x1Y2t5cGVubnlzb2Z0d2FyZS5jb20iLCJhdWQiOiJMdWNreVBlbm55U29mdHdhcmUiLCJleHAiOiIxODA2NTM3NjAwIiwiaWF0IjoiMTc3NTAwODg2MCIsImFjY291bnRfaWQiOiIwMTlkNDZjMzUyNjI3YjNlOWYzMjhjNDkwY2Y3OGU2NyIsImN1c3RvbWVyX2lkIjoiY3RtXzAxa24zY2JqcnRxdjU5OW43cHQwc3YxeGJ6Iiwic3ViX2lkIjoiLSIsImVkaXRpb24iOiIwIiwidHlwZSI6IjIifQ.tdHcBUPDYppylawO-wWZjiX3iSxolTjozMUBwQwzZMqfhEAnS1zQMlaLM6He1c9VpVS18sNpY6RyxjwwOw9xhUNgaZtkewTTTSdHYdTAQoGhOaGuJb7l-Y5OKmHJ3J07z7QNdLLOfuRI2YS9Ady_xDLmeHvy5z_FgeTqO1B8WzBE99mRJm4diGhNsKGlCXd97xzsjSuhyEiR_f_KjuWJUodCCRoBbOvFETLY6JdT_Fatc8YdXdAvidjxh3JU6x-SlQXmyZWE63AVYYl1F3M7XrIs-s1_Tc3wo5ZtlUVx9bhLqfAKjP1tW4R7wvx8DgaTtzulqWW9plEea595T-sy1w";
      cfg.AddMaps(typeof(AudioMapper).Assembly);
    });
    // 跨域处理中间件
    services.AddCors(options => options.AddPolicy("CorsPolicy", builder =>
    {
      // string[] urls = Configuration.GetSection("AllowedCores").Value.Split(',');
      builder
        .WithOrigins()
        .SetIsOriginAllowed(orig => true)
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    }));
    services.AddOptions().Configure<MinioOp>(Configuration.GetSection("Minio"));
    services.AddOptions().Configure<ASFOptions>(Configuration.GetSection("ASF"));
    services.AddOptions().Configure<AesEncryptionOptions>(Configuration.GetSection("AesEncryption"));
    services.AddMinio(opt =>
    {
      opt.Endpoint = Configuration["Minio:MinioUrl"] ?? "";
      opt.AccessKey = Configuration["Minio:AccessKey"] ?? "";
      opt.SecretKey = Configuration["Minio:SecretKey"] ?? "";
      var endpoint = Configuration["Minio:Endpoint"] ?? "";
      //如果是http 就注释掉。如果是https 就开启
      if (endpoint.Contains("https"))
        opt.ConfigureClient(client => { client.WithSSL(); });
    });
    // 添加asf 服务
    services.AddASF(build =>
    {
      var asfOptions = Configuration.GetSection("ASF").Get<ASFOptions>();
      build.AddDbContext(b =>
      {
        //处理各种db
        switch (asfOptions.DBType.ToLower())
        {
          case "sqlite":
            b.UseSqlite(asfOptions.DBConnectionString, opt => { opt.MigrationsAssembly("ASF.Web"); });
            break;
          case "sqlserver":
            b.UseSqlServer(asfOptions.DBConnectionString, opt => { opt.MigrationsAssembly("ASF.Web"); });
            break;
          case "postgre":
            b.UseNpgsql(asfOptions.DBConnectionString, opt => { opt.MigrationsAssembly("ASF.Web"); });
            break;
        }
      });
    });
    // 网关仍用 Ocelot，但不要 AddNewtonsoftJson。
    // 默认 AddOcelot() 会把 Newtonsoft 格式化器插到最前，DateTime 会被写成 ISO，盖住 UnixSecondsDateTimeConverter。
    services.AddOcelotUsingBuilder(Configuration, (builder, assembly) =>
    {
      builder.Services.AddMiddlewareAnalysis().AddWebEncoders();
      return builder
        .AddApplicationPart(assembly)
        .AddControllersAsServices()
        .AddAuthorization()
        .AddJsonOptions(_ => { });
    }).AddConsul();
  }

  // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
  public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
  {
    if (env.IsDevelopment())
    {
      // app.UseDeveloperExceptionPage();
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "asf API");
        //c.RoutePrefix = "";
      });
    }
    
    app.UseStaticFiles();
    app.UseCors("CorsPolicy");

    // var provider = app.ApplicationServices;
    // provider.UseScheduler(scheduler =>
    // {
    //   scheduler.Schedule<RunSendPhoneTasks>()
    //       .EverySeconds(35);
    //   // scheduler.Schedule<RunFetchData>()
    //   //     .EveryFiveMinutes();
    // });
    app.UseASF();

    app.UseOcelot().Wait();
  }
}