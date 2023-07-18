using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Web.Middleware;
using Consul;
using System;
namespace testapi1
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      //注册consul
      services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(consulConfig =>
      {
        consulConfig.Address = new Uri("http://localhost:8500");
      }
      //   , client =>
      // {
      //   client.Timeout = TimeSpan.FromSeconds(100000);
      //   client.DefaultRequestVersion = new Version(2, 0);
      //   client.DefaultVersionPolicy = HttpVersionPolicy.RequestVersionExact;
      // }
        ));
      services.AddControllers();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "testapi2", Version = "v1" });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime lifetime)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "testapi2 v1"));
      }

      app.UseHttpsRedirection();

      app.UseRouting();
      app.Map("/health", HealthMap);
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
      app.RegisterWithConsul(lifetime, Configuration);
    }

    private static void HealthMap(IApplicationBuilder app)
    {
      app.Run(async context =>
      {
        // var result = JsonConvert.SerializeObject(new { code = 200, data = "", msg = "ok" });
        // context.Response.ContentType = "application/json;charset=utf-8";
        await context.Response.WriteAsync("OK");
      });
    }
  }
}
