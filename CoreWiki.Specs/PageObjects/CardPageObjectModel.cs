using CoreWiki.Specs.Drivers;
using OpenQA.Selenium;

namespace CoreWiki.Specs.PageObjects
{
	public class CardPageObjectModel : PageObjectModel
	{
		public IWebElement Topic { get; private set; }
		public IWebElement Header { get; private set; }

		public void Init(WebDriver webDriver, IWebElement cwe)
		{
			base.Init(webDriver);
			Header = cwe.FindElement(By.ClassName("card-header"));
			Topic = Header.FindElement(By.TagName("a"));
		}

		
	}
}
