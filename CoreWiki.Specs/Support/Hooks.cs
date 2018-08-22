using CoreWiki.Specs.Drivers;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.UnitTestProvider;

namespace CoreWiki.Specs.Support
{
	[Binding]
	public class Hooks
	{
		private readonly WebDriver _webDriver;

		public Hooks(WebDriver webDriver)
		{
			_webDriver = webDriver;
		}

		[BeforeScenario()]
		public void BeforeScenario()
		{

		}


		[AfterScenario()]
		public void AfterScenario()
		{
			_webDriver?.Quit();
		}

		[BeforeTestRun]
		public static void BeforeTestRun()
		{

		}
	}
}
