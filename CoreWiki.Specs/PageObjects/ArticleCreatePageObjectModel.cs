using System.Linq;
using CoreWiki.Specs.Drivers;
using OpenQA.Selenium;

namespace CoreWiki.Specs.PageObjects
{
	public class ArticleCreatePageObjectModel : PageObjectModel
	{
		internal override void Init(WebDriver webDriver)
		{
			base.Init(webDriver);
			Content = webDriver.Current.FindElement(By.ClassName("CodeMirror"));
			Topic = webDriver.Current.FindElement(By.Id("Article_Topic"));
			CreateButton = webDriver.Current.FindElements(By.TagName("button")).SingleOrDefault(we => we.Text == "Create");
		}

		public IWebElement Content { get; private set; }
		public IWebElement Topic { get; private set; }
		public IWebElement CreateButton { get; private set; }
	}
}
