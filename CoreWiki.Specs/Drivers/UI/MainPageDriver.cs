using CoreWiki.Specs.PageObjects;
using FluentAssertions;

namespace CoreWiki.Specs.Drivers
{
	public class MainPageDriver
	{
		private readonly WebDriver _webDriver;
		private readonly LoginDriver _loginDriver;

		public MainPageDriver(WebDriver webDriver, LoginDriver loginDriver)
		{
			_webDriver = webDriver;
			_loginDriver = loginDriver;
		}

		public void AssertWelcomeMessage()
		{
			var masterPageModel = _webDriver.GetPageModelFromCurrentPage<MasterPageModel>();

			masterPageModel.WelcomeMessage.Text.Should().Be($"Hello {_loginDriver.CurrentLoginData.EMail}");
		}
	}
}
