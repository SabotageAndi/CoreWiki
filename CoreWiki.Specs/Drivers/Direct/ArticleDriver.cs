using System;
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
		
		public ArticleDriver(ApplicationDbContext applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
			
		}

		public void CreateArticle(string topic, string content)
		{
			var article = new Article()
			{
				Topic = topic,
				Slug = UrlHelpers.URLFriendly(topic),
				Published = Instant.FromDateTimeUtc(DateTime.UtcNow),
				Content = content
			};

			var articleHistory = ArticleHistory.FromArticle(article);

			_applicationDbContext.Articles.Add(article);
			_applicationDbContext.ArticleHistories.Add(articleHistory);

			_applicationDbContext.SaveChanges();
		}

		public void AssertArticleText(string articleTopic, string lastEnteredContent)
		{
			var article = _applicationDbContext.Articles.SingleOrDefault(a => a.Topic == articleTopic);
			_applicationDbContext.Entry(article).Reload();

			article.Content.Should().Be(lastEnteredContent);
		}
	}
}
