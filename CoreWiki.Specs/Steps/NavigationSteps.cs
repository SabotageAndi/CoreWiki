using CoreWiki.Specs.Drivers;
using TechTalk.SpecFlow;

namespace CoreWiki.Specs.Steps
{
	[Binding]
	public class NavigationSteps
	{
		private readonly WebDriver _webDriver;

		public NavigationSteps(WebDriver webDriver)
		{
			_webDriver = webDriver;
		}

		[When(@"I visit the main page")]
		public void WhenIVisitTheMainPage()
		{
			_webDriver.Current.Navigate().GoToUrl(_webDriver.BaseUrl);
		}

	}
}
