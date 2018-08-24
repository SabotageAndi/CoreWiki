using CoreWiki.Specs.Context;
using CoreWiki.Specs.Drivers;
using TechTalk.SpecFlow;

namespace CoreWiki.Specs.Steps
{
	[Binding]
	public class ArticleSteps
	{
		private readonly ArticleDriver _articleDriver;
		private readonly CurrentArticleContext _currentArticleContext;

		public ArticleSteps(ArticleDriver articleDriver, CurrentArticleContext currentArticleContext)
		{
			_articleDriver = articleDriver;
			_currentArticleContext = currentArticleContext;
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
			_currentArticleContext.ArticleTopic = topic;
		}

		[When(@"I edit the text")]
		public void WhenIEditTheText(string text)
		{
			_articleDriver.ChangeText(text);
			_currentArticleContext.LastEnteredContent = text;
		}

		[When(@"save it")]
		public void WhenSaveIt()
		{
			_articleDriver.Save();
		}

		[Then(@"the new text is saved to the database")]
		public void ThenTheNewTextIsSavedToTheDatabase()
		{
			_articleDriver.AssertArticleText(_currentArticleContext.ArticleTopic,
				_currentArticleContext.LastEnteredContent);
		}

	}
}
