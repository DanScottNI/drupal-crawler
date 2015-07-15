using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Drupal_WebCrawlerLib.Web
{
    public class Website
    {
        public Website(string uri)
        {
            this.Uri = uri;
        }

        public string Uri { get; set; }

        public bool IsWebUri()
        {
            return this.IsWebUri(this.Uri);
        }

        public bool IsWebUri(string uri)
        {
            Uri uriResult;
            return System.Uri.TryCreate(uri, UriKind.Absolute, out uriResult) && uriResult.Scheme == System.Uri.UriSchemeHttp;
        }

        public string GetWebsiteTitle()
        {
            string websiteTitle = string.Empty;

            HtmlDocument doc = this.GetWebPage(this.Uri);

            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//title");

            if (nodes != null && nodes.Any())
            {
                foreach(var title in nodes)
                {
                    websiteTitle = title.InnerText;
                }
            }
            
            return websiteTitle;
        }

        protected HtmlDocument GetWebPage(string uri)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = null;

            doc = web.Load(uri, "GET");
            
            return doc;
        }
    }
}
