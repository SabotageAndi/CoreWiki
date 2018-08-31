using System.Linq;
using CoreWiki.Specs.Drivers;
using OpenQA.Selenium;

namespace CoreWiki.Specs.PageObjects
{
	public class LoginPageObjectModel : PageObjectModel
	{
		internal override void Init(WebDriver webDriver)
		{
			base.Init(webDriver);
			Password = webDriver.Current.FindElement(By.Id("Input_Email"));
			EMail = webDriver.Current.FindElement(By.Id("Input_Password"));
			LogInButton = webDriver.Current.FindElements(By.TagName("button")).SingleOrDefault(we => we.Text == "Log in");
			ValidationErrors = webDriver.Current.FindElements(By.ClassName("validation-summary-errors")).SingleOrDefault();
		}

		public IWebElement LogInButton { get; set; }
		public IWebElement EMail { get; set; }
		public IWebElement Password { get; set; }

		public IWebElement ValidationErrors { get; set; }
	}
}
