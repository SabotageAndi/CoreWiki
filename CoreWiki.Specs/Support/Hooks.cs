using CoreWiki.Specs.Drivers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server.Features;
using System;
using System.IO;
using System.Threading;
using CoreWiki.Data;
using CoreWiki.Data.Security;
using Microsoft.Extensions.DependencyInjection;
using TechTalk.SpecFlow;

namespace CoreWiki.Specs.Support
{
	[Binding]
	public class Hooks
	{
		private static IWebHost _buildWebHost;
		private readonly WebDriver _webDriver;
		private readonly ScenarioContext _scenarioContext;
		private IServiceScope _serviceScope;

		public Hooks(WebDriver webDriver, ScenarioContext scenarioContext)
		{
			_webDriver = webDriver;
			_scenarioContext = scenarioContext;
		}

		[BeforeScenario()]
		public void BeforeScenario()
		{
			var appDataPath = Path.Combine(Environment.CurrentDirectory, "app_data");
			if (Directory.Exists(appDataPath))
			{
				Directory.Delete(appDataPath, true);
			}

			if (!Directory.Exists(appDataPath))
			{
				Directory.CreateDirectory(appDataPath);
			}


			_buildWebHost = Program.CreateWebHost(null)
				.UseContentRoot(Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "..", "CoreWiki"))
				.Build();

			var serverAddressesFeature = _buildWebHost.ServerFeatures.Get<IServerAddressesFeature>();
			serverAddressesFeature.Addresses.Add(_webDriver.BaseUrl);


			_buildWebHost.Start();


			_serviceScope = _buildWebHost.Services.CreateScope();

			_scenarioContext.ScenarioContainer.RegisterInstanceAs(_serviceScope);

			_scenarioContext.ScenarioContainer.RegisterInstanceAs(_serviceScope.ServiceProvider.GetRequiredService<CoreWikiIdentityContext>());
			_scenarioContext.ScenarioContainer.RegisterInstanceAs(_serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>());
		}


		[AfterScenario()]
		public void AfterScenario()
		{
			_serviceScope.Dispose();
			_webDriver?.Quit();

			_buildWebHost.StopAsync().Wait();
		}
	}
}
