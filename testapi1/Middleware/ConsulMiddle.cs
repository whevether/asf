using System;
using System.Linq;
using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Web.Middleware
{
	public static class ConsulMiddle
	{
		public static IApplicationBuilder RegisterWithConsul(this IApplicationBuilder app,
			IHostApplicationLifetime lifetime,IConfiguration configuration)
		{
			// Retrieve Consul client from DI
			var consulClient = app.ApplicationServices
				.GetRequiredService<IConsulClient>();
			// Setup logger
			var loggingFactory = app.ApplicationServices
				.GetRequiredService<ILoggerFactory>();
			var logger = loggingFactory.CreateLogger<IApplicationBuilder>();
			
			var features = app.Properties["server.Features"] as FeatureCollection;
			var serverFeatures = features.Get<IServerAddressesFeature>();
			var address = serverFeatures.Addresses.FirstOrDefault();
			if (serverFeatures.Addresses.Count==0)
			{
				address = $"{configuration["Ip"]}:{configuration["Port"]}";
			}
			// Register service with consul
			var uri = new Uri(address);
			var httpCheck = new Consul.AgentServiceCheck()
			{
				// DeregisterCriticalServiceAfter = TimeSpan.FromMinutes(1),
				// Interval = TimeSpan.FromSeconds(30),
				Timeout = TimeSpan.FromSeconds(3) ,
				Interval = TimeSpan.FromSeconds(10),
				Notes = "Checks /health/status on localhost",
				HTTP = $"{uri.Scheme}://{uri.Host}:{uri.Port}/health"
			};
			var registration = new AgentServiceRegistration()
			{
				Checks = new[] { httpCheck },
				Address = uri.Host,
				ID = $"Api1Service_{uri.Port}",
				Name = "Api1Service",
				Port = uri.Port
			};

			logger.LogInformation("Registering with Consul");
			consulClient.Agent.ServiceDeregister(registration.ID).Wait();
			consulClient.Agent.ServiceRegister(registration).Wait();

			lifetime.ApplicationStopping.Register(() => {
				logger.LogInformation("Deregistering from Consul");
				consulClient.Agent.ServiceDeregister(registration.ID).Wait(); 
			});
			return app;
		}
	}
}