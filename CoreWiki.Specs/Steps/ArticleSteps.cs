using CoreWiki.Specs.Drivers;
using TechTalk.SpecFlow;

namespace CoreWiki.Specs.Steps
{
	[Binding]
	public class ArticleSteps
	{
		private readonly ArticleDriver _articleDriver;

		public ArticleSteps(ArticleDriver articleDriver)
		{
			_articleDriver = articleDriver;
		}

		[Given(@"an article '(.*)' exists")]
		public void GivenAnArticleExists(string title)
		{
			_articleDriver.CreateArticle(title);
		}

		[Given(@"I open the article '(.*)' to edit it")]
		public void GivenIOpenTheArticle(string topic)
		{
			_articleDriver.EditArticle(topic);
		}

		[When(@"I edit the text")]
		public void WhenIEditTheText(string text)
		{
			_articleDriver.ChangeText(text);
		}

		[When(@"save it")]
		public void WhenSaveIt()
		{
			_articleDriver.Save();
		}


	}
}
