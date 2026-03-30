using System;
using System.Collections.Generic;
using System.Globalization;
using ASF.Domain.Services;
using ASF.Internal;
using ASF.Internal.Security;
using ASF.Internal.Utils;
using Coravel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace ASF.DependencyInjection;

/// <summary>
///   asf 服务
/// </summary>
public class ASFBuilder
{
	/// <summary>
	///   asf 服务
	/// </summary>
	/// <param name="services"></param>
	public ASFBuilder(IServiceCollection services)
  {
    Services = services;
  }

	/// <summary>
	///   服务集合
	/// </summary>
	public IServiceCollection Services { get; }

	/// <summary>
	///   编译服务
	/// </summary>
	public void Build()
  {
    Services.AddMemoryCache();
    Services.AddSingleton<IIdGenerator, DefaultIdGenerator>();
    // httpclient 
    Services.AddHttpClient();
    Services.AddSingleton<IHttpHelper, HttpHelper>();
    // Add framework services.
    Services.AddLocalization();
    Services.Configure<RequestLocalizationOptions>(
      options =>
      {
        var supportedCultures = new List<CultureInfo>
        {
          new("en-US"),
          new("zh-HK"),
          new("zh-CN")
        };

        options.DefaultRequestCulture = new RequestCulture("zh-CN", "zh-CN");
        options.SupportedCultures = supportedCultures;
        options.SupportedUICultures = supportedCultures;
        options.AddInitialRequestCultureProvider(new AcceptLanguageHeaderRequestCultureProvider());
      });

    Services.AddScheduler();
    AddDomainServices();
    AddAuthorization();
  }

	/// <summary>
	///   添加授权
	/// </summary>
	private void AddAuthorization()
  {
    Services.AddAuthorization(opt =>
      {
        opt.AddPolicy(JwtBearerDefaults.AuthenticationScheme, new AuthorizationPolicyBuilder()
          .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
          .RequireAuthenticatedUser()
          .Build());
        // opt.DefaultPolicy = new AuthorizationPolicyBuilder().AddRequirements(new OperationAuthorizationRequirement()).Build();
      }).AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
      .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, jwtBearerOptions =>
      {
        // jwtBearerOptions.SaveToken = true;
        jwtBearerOptions.RequireHttpsMetadata = false;
        jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = RSA.RSAPublicKey,
          ValidateIssuer = true,
          ValidIssuer = "asf",
          ValidateAudience = true,
          ValidAudience = "asf",
          ValidateLifetime = true,
          ClockSkew = TimeSpan.Zero,
          RequireExpirationTime = true
        };
      });
    ;
  }

	/// <summary>
	///   添加领域服务
	/// </summary>
	private void AddDomainServices()
  {
    Services.AddTransient<AccountAuthorizationService>();
    Services.AddTransient<LoggerService>();
    Services.AddTransient<IAccountLoginService, AccountLoginService>();
    Services.AddTransient<AccountService>();
    Services.AddTransient<PermissionService>();
    Services.AddTransient<ApiService>();
    Services.AddTransient<MenuService>();
    Services.AddTransient<TranslateService>();
    Services.AddTransient<TenancyService>();
    Services.AddTransient<DepartmentService>();
    Services.AddTransient<RoleService>();
    Services.AddTransient<PostService>();
    Services.AddTransient<DictionaryService>();
    Services.AddTransient<RunSendPhoneTasks>();
    Services.AddTransient<UploadService>();
    Services.AddTransient<CountryService>();
  }
}