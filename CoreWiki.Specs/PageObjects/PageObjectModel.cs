using System;
using CoreWiki.Specs.Drivers;

namespace CoreWiki.Specs.PageObjects
{
	public class PageObjectModel
	{
		protected WebDriver WebDriver;

		internal virtual void Init(WebDriver webDriver)
		{
			WebDriver = webDriver;
		}
	}
}
