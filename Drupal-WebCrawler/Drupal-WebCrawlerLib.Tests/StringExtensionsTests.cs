using Drupal_WebCrawlerLib.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace Drupal_WebCrawlerLib.Tests
{
    [TestClass]
    class StringExtensionsTests
    {
        [TestMethod]
        public void GetBadlyFormedWebPageUri()
        {
            "blah.hferfw.wefewqf".IsWebUri().ShouldBe(false);
        }

        [TestMethod]
        public void GetWellFormedWebPageUri()
        {
            "http://www.bbc.co.uk".IsWebUri().ShouldBe(true);
        }

    }
}
