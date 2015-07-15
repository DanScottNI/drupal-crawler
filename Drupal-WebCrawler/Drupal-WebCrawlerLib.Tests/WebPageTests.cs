using Drupal_WebCrawlerLib.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System.Collections.ObjectModel;
using System.Linq;

namespace Drupal_WebCrawlerLib.Tests
{
    [TestClass]
    public class WebPageTests
    {
        [TestMethod]
        public void GetWebPage()
        {
            WebPage web = new WebPage("http://www.bbc.co.uk");

            web.Title.ShouldBe("BBC - Homepage");
        }

        [TestMethod]
        public void GetWebPageLinks()
        {
            string uri = "http://www.attorneygeneralni.gov.uk";
            WebPage web = new WebPage(uri);

            Collection<string> links = web.GetAllLinkDestinations();
            links.Any().ShouldBe(true);
            links.Count.ShouldBe(15);
        }

        [TestMethod]
        public void PageDoesNotExist()
        {
            WebPage web = new WebPage("http://www.attorneygeneralni.gov.uk/dan.html");
            web.PageExists().ShouldBe(false);
        }

        [TestMethod]
        public void PageExists()
        {
            WebPage web = new WebPage("http://www.attorneygeneralni.gov.uk");
            
            web.PageExists().ShouldBe(true);
        }
    }
}
