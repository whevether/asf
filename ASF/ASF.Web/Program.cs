using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace ASF.Web;

public class Program
{
  public static void Main(string[] args)
  {
    CreateHostBuilder(args).Build().Run();
  }

  public static IHostBuilder CreateHostBuilder(string[] args)
  {
    return Host.CreateDefaultBuilder(args)
      .ConfigureWebHostDefaults(webBuilder =>
      {
        var port = "5900";
        var realPath = Directory.GetParent(Assembly.GetExecutingAssembly().Location)
          ?.FullName;
        webBuilder.ConfigureAppConfiguration((hostingContext, config) =>
        {
          config
            .SetBasePath(realPath)
            // .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
            .AddJsonFile("appsettings.json", true, true)
            .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true,
              true)
            .AddJsonFile("ocelot.json", false, true)
            .AddEnvironmentVariables();
        }).ConfigureLogging((hostingContext, logging) =>
        {
          logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
          logging.AddConsole();
          logging.AddDebug();
        });
        webBuilder.UseUrls($"http://*:{port}").UseStartup<Startup>();
      }).UseNLog();
  }
}