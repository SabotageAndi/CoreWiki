using System;
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
		private readonly ArticleWebDriver _articleWebDriver;

		public ArticleSteps(ArticleDriver articleDriver, CurrentArticleContext currentArticleContext, ArticleWebDriver articleWebDriver)
		{
			_articleDriver = articleDriver;
			_currentArticleContext = currentArticleContext;
			_articleWebDriver = articleWebDriver;
		}

		[Given(@"an article '(.*)' exists")]
		public void GivenAnArticleExists(string topic)
		{
			_articleDriver.CreateArticle(topic, String.Empty);
			_currentArticleContext.ArticleTopic = topic;

		}

		[When(@"I create a new article without content")]
		[When(@"I create a new article")]
		public void WhenICreateANewArticle()
		{
			var topic = Guid.NewGuid().ToString("N");
			GivenAnArticleWithTheTopicWasCreated(topic);
		}

		[Given(@"an article with the topic '(.*)' was created")]
		public void GivenAnArticleWithTheTopicWasCreated(string topic)
		{
			_articleWebDriver.CreateArticleViaWeb(topic);
			_currentArticleContext.ArticleTopic = topic;
		}

		[Given(@"I open this article to edit it")]
		public void GivenIOpenThisArticleToEditIt()
		{
			GivenIOpenTheArticle(_currentArticleContext.ArticleTopic);
		}


		[Given(@"I open the article '(.*)' to edit it")]
		public void GivenIOpenTheArticle(string topic)
		{
			_articleWebDriver.EditArticle(topic);
			_currentArticleContext.ArticleTopic = topic;
		}

		[When(@"enter the content")]
		[When(@"I change the content to")]
		public void WhenIChangeTheContentTo(string content)
		{
			_articleWebDriver.ChangeText(content);
			_currentArticleContext.LastEnteredContent = content;
		}

		[Given(@"save it")]
		[When(@"save it")]
		public void WhenSaveIt()
		{
			_articleWebDriver.Save();
		}

		[Then(@"the new article has the content:")]
		public void ThenTheNewArticleHasTheContent(string expectedContent)
		{
			_articleDriver.AssertArticleText(_currentArticleContext.ArticleTopic, expectedContent);
		}

		[Given(@"an article exists with the content:")]
		public void GivenAnArticleExistsWithTheContent(string content)
		{
			var topic = Guid.NewGuid().ToString("N");
			_articleDriver.CreateArticle(topic, content);
			_currentArticleContext.ArticleTopic = topic;
		}

		[Then(@"the new article is available")]
		public void ThenTheNewArticleIsAvailable()
		{
			_articleWebDriver.AssertIfArticleIfAvailable(_currentArticleContext.ArticleTopic);

		}

		[When(@"I look at the list of available topics")]
		public void WhenILookAtTheListOfAvailableTopics()
		{
			
		}

		[Then(@"the article with the topic '(.*)' is available")]
		public void ThenTheArticleWithTheTopicIsAvailable(string topic)
		{
			_articleWebDriver.AssertIfArticleIfAvailable(topic);
		}


	}
}
