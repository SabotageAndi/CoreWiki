using System.Linq;
using CoreWiki.Specs.PageObjects;
using FluentAssertions;
using OpenQA.Selenium;

namespace CoreWiki.Specs.Drivers
{
	public class LoginDriver
	{
		private readonly WebDriver _webDriver;

		public LoginDriver(WebDriver webDriver)
		{
			_webDriver = webDriver;
		}

		protected LoginPageObjectModel LoginPOM => _webDriver.GetPageModelFromCurrentPage<LoginPageObjectModel>();

		public LoginData CurrentLoginData { get; private set; }

		public void LoginWithCredentials(LoginData loginData)
		{
			_webDriver.Current.Navigate().GoToUrl(_webDriver.BaseUrl + "/identity/account/login");

			var loginPOM = LoginPOM;
			loginPOM.EMail.SendKeys(loginData.EMail);
			loginPOM.Password.SendKeys(loginData.Password);
			loginPOM.LogInButton.Click();

			CurrentLoginData = loginData;
		}

		public void AssertThatAnInvalidLoginAttemptMessage()
		{
			var loginPOM = LoginPOM;
			var validationErrors = loginPOM.ValidationErrors.FindElements(By.TagName("li"));

			validationErrors.Any(we => we.Text == "Invalid login attempt.").Should().BeTrue();
		}
	}
}
