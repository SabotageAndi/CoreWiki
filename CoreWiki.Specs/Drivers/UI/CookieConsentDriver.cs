using CoreWiki.Specs.PageObjects;
using FluentAssertions;

namespace CoreWiki.Specs.Drivers
{
	public class CookieConsentDriver
	{
		private readonly WebDriver _webDriver;

		public CookieConsentDriver(WebDriver webDriver)
		{
			_webDriver = webDriver;
		}

		protected MasterPageModel CurrentPage => _webDriver.GetPageModelFromCurrentPage<MasterPageModel>();


		public void AssertThatTheMessageIsShown()
		{
			CurrentPage.CookieConsent.IsShown.Should().BeTrue();
		}

		public void AgreeToCookieConsentMessage()
		{
			CurrentPage.CookieConsent.AgreeButton.Should().NotBeNull("the button is not shown");
			CurrentPage.CookieConsent.AgreeButton.Click();
		}

		public void AssertThatTheMessageIsNotShown()
		{
			CurrentPage.CookieConsent.IsShown.Should().BeFalse();
		}
	}
}
