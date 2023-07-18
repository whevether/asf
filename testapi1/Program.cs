using System;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Server.Kestrel.Https;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace testapi1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    int port = 0;
                    webBuilder.ConfigureAppConfiguration((context, config) =>
                    {
                        config.SetBasePath(Directory.GetCurrentDirectory());
                        IConfigurationRoot build = config.Build();
                        port = int.Parse(build.GetSection("Port").Value);
                    });
                    webBuilder.ConfigureKestrel(options =>
                    {
                        //添加连接超时为两分钟
                        options.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(2);
                        // 最大并发连接数为100个
                        options.Limits.MaxConcurrentConnections = 100;
                        // 最大并发升级连接数
                        options.Limits.MaxConcurrentUpgradedConnections = 100;
                        options.ConfigureHttpsDefaults(httpsOption => {
                            httpsOption.ClientCertificateMode = ClientCertificateMode.AllowCertificate; 
                        });
                        // Setup a HTTP/2 endpoint without TLS.
                        options.ListenAnyIP(port, o =>{
                            o.Protocols = HttpProtocols.Http1AndHttp2;
                            // var cert = new X509Certificate2(Path.Combine("/Users/mowenfeng/Desktop/https/localhost.pfx"), "123456");
                            // o.UseHttps(cert);
                        });
                    });
                    webBuilder.UseStartup<Startup>();
                });
        
        // public static void Main(string[] args)
        // {
        //     CreateWebHostBuilder(args).Build().Run();
        // }
        //
        // public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        //     WebHost.CreateDefaultBuilder(args)
        //         .UseStartup<Startup>();
        
    }
}
