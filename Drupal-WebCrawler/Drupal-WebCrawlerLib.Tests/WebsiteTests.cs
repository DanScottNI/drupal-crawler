using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Drupal_WebCrawlerLib.Web;
using Shouldly;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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

        [TestMethod]
        public void GetAllWebsiteLinks()
        {
            string uri = "http://www.attorneygeneralni.gov.uk";
            Website web = new Website(uri);

            Collection<string> links = web.GetAllLinksOnSite();
            links.Any().ShouldBe(true);
            links.Count.ShouldBe(102);
        }

        [TestMethod]
        public void GetWebPageLinks()
        {
            string uri = "http://www.attorneygeneralni.gov.uk";
            Website web = new Website(uri);

            Collection<string> links = web.GetLinksOnPage(uri);
            links.Any().ShouldBe(true);
            links.Count.ShouldBe(15);
        }

        [TestMethod]
        public void GetBadlyFormedWebPageUri()
        {
            Website web = new Website("blah.hferfw.wefewqf");
            web.IsWebUri().ShouldBe(false);
        }

        [TestMethod]
        public void GetWellFormedWebPageUri()
        {
            Website web = new Website("http://www.bbc.co.uk");
            web.IsWebUri().ShouldBe(true);
        }

        [TestMethod]
        public void PageDoesNotExist()
        {
            Website web = new Website("http://www.attorneygeneralni.gov.uk");
            web.PageExists("http://www.attorneygeneralni.gov.uk/dan.html").ShouldBe(false);
        }

        [TestMethod]
        public void PageExists()
        {
            Website web = new Website("http://www.attorneygeneralni.gov.uk");
            web.PageExists("http://www.attorneygeneralni.gov.uk/index/about-us.htm").ShouldBe(true);
        }
    }
}
