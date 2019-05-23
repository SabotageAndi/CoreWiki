using System;
using System.IO;
using CoreWiki.Specs.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecRun;

namespace CoreWiki.Specs.Drivers
{
	public class WebDriver
	{
		private readonly TestRunContext _testRunContext;
		private IWebDriver _currentWebDriver;

		public WebDriver(TestRunContext testRunContext)
		{
			_testRunContext = testRunContext;
		}

		public IWebDriver Current
		{
			get
			{
				if (_currentWebDriver != null)
					return _currentWebDriver;

				var chromeOptions = new ChromeOptions()
				{

				};

				var chromeDriverService = ChromeDriverService.CreateDefaultService(Path.Combine(_testRunContext.TestDirectory, "..", ".."), "chromedriver.exe");

				_currentWebDriver = new ChromeDriver(chromeDriverService, chromeOptions) { Url = BaseUrl };

				return _currentWebDriver;
			}
		}

		public string BaseUrl => "https://localhost:8081";

		private WebDriverWait _wait;
		public WebDriverWait Wait
		{
			get
			{
				if (_wait == null)
				{
					this._wait = new WebDriverWait(Current, TimeSpan.FromSeconds(10));
				}
				return _wait;
			}
		}

		public void Quit()
		{
			_currentWebDriver?.Quit();
		}

		public T GetPageModelFromCurrentPage<T>() where T : PageObjectModel, new()
		{
			var pageModelFromCurrentPage = new T();
			pageModelFromCurrentPage.Init(this);
			return pageModelFromCurrentPage;
		}
	}
}
