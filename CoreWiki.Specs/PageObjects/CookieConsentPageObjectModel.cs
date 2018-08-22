using System.Linq;
using CoreWiki.Specs.Drivers;
using OpenQA.Selenium;

namespace CoreWiki.Specs.PageObjects
{
	public class CookieConsentPageObjectModel : PageObjectModel
	{
		private IWebElement _navigationCookieConsent;

		internal override void Init(WebDriver webDriver)
		{
			base.Init(webDriver);

			_navigationCookieConsent = WebDriver.Current.FindElements(By.Id("cookieConsent")).SingleOrDefault();

			if (_navigationCookieConsent == null)
			{
				IsShown = false;
			}
			else
			{
				IsShown = _navigationCookieConsent.Displayed;

				AgreeButton = _navigationCookieConsent.FindElements(By.ClassName("btn-secondary")).SingleOrDefault();
			}
		}

		public bool IsShown { get; private set; }
		public IWebElement AgreeButton { get; private set; }
	}
}
