using System.Linq;
using CoreWiki.Specs.Drivers;
using OpenQA.Selenium;

namespace CoreWiki.Specs.PageObjects
{
	public class MasterPageModel : PageObjectModel
	{
		internal override void Init(WebDriver webDriver)
		{
			base.Init(webDriver);
			CookieConsent = new CookieConsentPageObjectModel();
			CookieConsent.Init(webDriver);

			LoginButton = webDriver.Current.FindElements(By.LinkText("Login")).SingleOrDefault();
			WelcomeMessage = webDriver.Current.FindElements(By.TagName("a"))
				.SingleOrDefault(we => we.GetAttribute("title") == "Manage");
		}

		public CookieConsentPageObjectModel CookieConsent { get; private set; }

		public IWebElement LoginButton { get; set; }

		public IWebElement WelcomeMessage { get; private set; }
	}
}
