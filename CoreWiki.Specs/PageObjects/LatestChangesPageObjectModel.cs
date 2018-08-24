using System.Collections.Generic;
using System.Linq;
using CoreWiki.Specs.Drivers;
using OpenQA.Selenium;

namespace CoreWiki.Specs.PageObjects
{
	public class LatestChangesPageObjectModel : PageObjectModel
	{
		internal override void Init(WebDriver webDriver)
		{
			base.Init(webDriver);

			Cards = WebDriver.Current.FindElements(By.ClassName("card"))
				.Select(cwe =>
				{
					var cardPageObjectModel = new CardPageObjectModel();
					cardPageObjectModel.Init(webDriver, cwe);
					return cardPageObjectModel;
				}).ToList();
		}

		public IReadOnlyList<CardPageObjectModel> Cards { get; private set; }
	}
}
