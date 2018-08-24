﻿using System;
using System.Linq;
using CoreWiki.Data;
using CoreWiki.Data.Models;
using CoreWiki.Helpers;
using CoreWiki.Specs.PageObjects;
using FluentAssertions;
using Microsoft.AspNetCore.Identity.UI.Pages.Internal.Account;
using NodaTime;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace CoreWiki.Specs.Drivers
{
	public class ArticleDriver
	{
		private readonly ApplicationDbContext _applicationDbContext;
		private readonly WebDriver _webDriver;

		public ArticleDriver(ApplicationDbContext applicationDbContext, WebDriver webDriver)
		{
			_applicationDbContext = applicationDbContext;
			_webDriver = webDriver;
		}

		public void CreateArticle(string topic, string content)
		{
			var article = new Article()
			{
				Topic = topic,
				Slug = ConvertTopicIntoSlug(topic),
				Published = Instant.FromDateTimeUtc(DateTime.UtcNow),
				Content = content
			};

			var articleHistory = ArticleHistory.FromArticle(article);

			_applicationDbContext.Articles.Add(article);
			_applicationDbContext.ArticleHistories.Add(articleHistory);

			_applicationDbContext.SaveChanges();
		}

		private static string ConvertTopicIntoSlug(string topic)
		{
			return UrlHelpers.URLFriendly(topic);
		}

		public void GoToArticle(string topic)
		{
			var slug = ConvertTopicIntoSlug(topic);
			_webDriver.Current.Navigate().GoToUrl(_webDriver.BaseUrl + "/wiki/" + slug);
		}

		public void EditArticle(string topic)
		{
			var slug = ConvertTopicIntoSlug(topic);
			_webDriver.Current.Navigate().GoToUrl(_webDriver.BaseUrl + "/"+ slug + "/edit");
		}

		public void ChangeText(string text)
		{
			var articleEditPageObjectModel = _webDriver.GetPageModelFromCurrentPage<ArticleEditPageObjectModel>();

			text = text.Replace(Environment.NewLine, "\\n");

			var script = "arguments[0].CodeMirror.setValue(\"" + text+ "\");";
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

		public void AssertArticleText(string articleTopic, string lastEnteredContent)
		{
			var article = _applicationDbContext.Articles.SingleOrDefault(a => a.Topic == articleTopic);
			_applicationDbContext.Entry(article).Reload();

			article.Content.Should().Be(lastEnteredContent);
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