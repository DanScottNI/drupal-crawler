using Drupal_WebCrawlerLib.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System.Collections.ObjectModel;
using System.Linq;

namespace Drupal_WebCrawlerLib.Tests
{
    [TestClass]
    public class WebsiteTests
    {
        [TestMethod]
        public void GetAllWebsiteLinks()
        {
            string uri = "http://www.attorneygeneralni.gov.uk";
            Website web = new Website(uri);

            Collection<string> links = web.GetAllLinksOnSite();
            links.Any().ShouldBe(true);
            links.Count.ShouldBe(102);
        }

        

        
        
    }
}
