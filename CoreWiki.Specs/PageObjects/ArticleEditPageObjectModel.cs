using System.Linq;
using CoreWiki.Specs.Drivers;
using OpenQA.Selenium;

namespace CoreWiki.Specs.PageObjects
{
	public class ArticleEditPageObjectModel : PageObjectModel
	{
		internal override void Init(WebDriver webDriver)
		{
			base.Init(webDriver);
			Content = webDriver.Current.FindElement(By.ClassName("CodeMirror-lines"));
			Topic = webDriver.Current.FindElement(By.Id("Article_Topic"));
			SaveButton = webDriver.Current.FindElements(By.TagName("button")).SingleOrDefault(we => we.Text == "Save");
		}

		public IWebElement Content { get; private set; }
		public IWebElement Topic { get; private set; }
		public IWebElement SaveButton { get; private set; }
	}
}
