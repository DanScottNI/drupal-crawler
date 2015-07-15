using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Drupal_WebCrawlerLib.Extensions;

namespace Drupal_WebCrawlerLib.Web
{
    public class Website
    {
        public Website(string baseUri)
        {
            this.BaseUri = baseUri;
        }

        public string BaseUri { get; set; }

        public string GetWebsiteTitle(string uri)
        {
            string websiteTitle = string.Empty;

            HtmlDocument doc = this.GetWebPage(uri);

            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//title");

            if (nodes != null && nodes.Any())
            {
                foreach (var title in nodes)
                {
                    websiteTitle = title.InnerText;
                }
            }

            return websiteTitle.Trim();
        }

        protected HtmlDocument GetWebPage(string uri)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = null;

            doc = web.Load(uri, "GET");

            return doc;
        }

        public Collection<string> GetAllLinksOnSite()
        {
            Collection<string> links = new Collection<string>();

            WebPage page = new WebPage(this.BaseUri);

            links = page.GetAllLinkDestinations();
            List<string> newLinks = new List<string>();

            foreach (var l in links)
            {
                page = new WebPage(this.BaseUri, l);
                newLinks.AddRange(page.GetAllLinkDestinations());
            }

            newLinks = newLinks.Distinct().ToList();

            foreach (var l in newLinks)
            {
                if (!links.Contains(l))
                {
                    links.Add(l);
                }
            }

            return links;
        }




    }
}
