using System;
using System.Linq;
using CoreWiki.Helpers;
using CoreWiki.Specs.PageObjects;
using FluentAssertions;
using OpenQA.Selenium.Support.Extensions;

namespace CoreWiki.Specs.Drivers.UI
{
    public class ArticleWebDriver
	{
		private readonly WebDriver _webDriver;

		public ArticleWebDriver(WebDriver webDriver)
		{
			_webDriver = webDriver;
		}

		public void GoToArticle(string topic)
		{
			var slug = UrlHelpers.URLFriendly(topic);
			_webDriver.Current.Navigate().GoToUrl(_webDriver.BaseUrl + "/wiki/" + slug);
		}

		public void EditArticle(string topic)
		{
			var slug = UrlHelpers.URLFriendly(topic);
			_webDriver.Current.Navigate().GoToUrl(_webDriver.BaseUrl + "/" + slug + "/edit");
		}

		public void ChangeText(string text)
		{
			var articleEditPageObjectModel = _webDriver.GetPageModelFromCurrentPage<ArticleEditPageObjectModel>();

			text = text.Replace(Environment.NewLine, "\\n");

			var script = "arguments[0].CodeMirror.setValue(\"" + text + "\");";
			_webDriver.Current.ExecuteJavaScript(script, articleEditPageObjectModel.Content);
		}

		public void Save()
		{
			if (_webDriver.Current.Url.EndsWith("/Create"))
			{
				var articleCreatePageObjectModel = _webDriver.GetPageModelFromCurrentPage<ArticleCreatePageObjectModel>();
				articleCreatePageObjectModel.CreateButton.Click();
			}
			else
			{
				var articleEditPageObjectModel = _webDriver.GetPageModelFromCurrentPage<ArticleEditPageObjectModel>();
				articleEditPageObjectModel.SaveButton.Click();
			}
		}

		public void CreateArticleViaWeb(string topic)
		{
			_webDriver.Current.Navigate().GoToUrl(_webDriver.BaseUrl + "/Create");
			var articleEditPageObjectModel = _webDriver.GetPageModelFromCurrentPage<ArticleEditPageObjectModel>();

			articleEditPageObjectModel.Topic.Clear();
			articleEditPageObjectModel.Topic.SendKeys(topic);

		}

		public void AssertIfArticleIfAvailable(string topic)
		{
			_webDriver.Current.Navigate().GoToUrl(_webDriver.BaseUrl + "/Search/LatestChanges");
			var latestChangesPageObjectModel = _webDriver.GetPageModelFromCurrentPage<LatestChangesPageObjectModel>();

			latestChangesPageObjectModel.Cards.Any(c => c.Header.Text == topic).Should().BeTrue();
		}
	}
}