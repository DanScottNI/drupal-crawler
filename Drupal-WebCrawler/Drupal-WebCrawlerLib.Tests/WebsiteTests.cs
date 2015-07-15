using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Drupal_WebCrawlerLib.Web;
using Shouldly;
namespace Drupal_WebCrawlerLib.Tests
{
    [TestClass]
    public class WebsiteTests
    {
        [TestMethod]
        public void GetWebPage()
        {
            Website web = new Website("http://www.bbc.co.uk");

            web.GetWebsiteTitle().ShouldBe("BBC - Homepage");
        }
    }
}
