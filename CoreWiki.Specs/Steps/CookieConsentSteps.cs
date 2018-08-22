using CoreWiki.Specs.Drivers;
using TechTalk.SpecFlow;

namespace CoreWiki.Specs.Steps
{
	[Binding]
	public class CookieConsentSteps
	{
		private readonly CookieConsentDriver _cookieConsentDriver;

		public CookieConsentSteps(CookieConsentDriver cookieConsentDriver)
		{
			_cookieConsentDriver = cookieConsentDriver;
		}

		[Then(@"I see the cookie message at the top of the page")]
		public void ThenISeeTheCookieMessageAtTheTopOfThePage()
		{
			_cookieConsentDriver.AssertThatTheMessageIsShown();
		}

		[When(@"agree to the cookie message")]
		public void WhenAgreeToTheCookieMessage()
		{
			_cookieConsentDriver.AgreeToCookieConsentMessage();
		}

		[Then(@"I the cookie message at the top of the page is gone")]
		public void ThenITheCookieMessageAtTheTopOfThePageIsGone()
		{
			_cookieConsentDriver.AssertThatTheMessageIsNotShown();
		}


	}
}
