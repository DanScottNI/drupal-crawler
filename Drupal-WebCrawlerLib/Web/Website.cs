using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Drupal_WebCrawlerLib.Web
{
    public class Website
    {
        public Website(string baseUri)
        {
            this.BaseUri = baseUri;
        }

        public string BaseUri { get; set; }

        public bool IsWebUri()
        {
            return this.IsWebUri(this.BaseUri);
        }

        public bool IsWebUri(string uri)
        {
            Uri uriResult;
            return System.Uri.TryCreate(uri, UriKind.Absolute, out uriResult) && uriResult.Scheme == System.Uri.UriSchemeHttp;
        }

        public string GetWebsiteTitle()
        {
            string websiteTitle = string.Empty;

            HtmlDocument doc = this.GetWebPage(this.BaseUri);

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

            links = GetLinksOnPage(this.BaseUri, links);
            List<string> newLinks = new List<string>();

            foreach (var l in links)
            {
                newLinks.AddRange(GetLinksOnPage(l, links));
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

        public Collection<string> GetLinksOnPage(string uri, IList<string> links)
        {
            HtmlDocument doc = this.GetWebPage(uri);
            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//a");
            Collection<string> newLinks = new Collection<string>();

            if (nodes != null)
            {
                foreach (var link in nodes)
                {
                    var href = link.GetAttributeValue("href", string.Empty);

                    // avoid anchors
                    if (!string.IsNullOrWhiteSpace(href) && !href.StartsWith("#"))
                    {
                        // build absolute uri
                        var absoluteUri = GetAbsoluteUrl(href);

                        if (absoluteUri.IndexOf('#') > -1)
                        {
                            absoluteUri = absoluteUri.Substring(0, absoluteUri.LastIndexOf('#'));
                        }

                        // only crawl links from the base URL
                        if (absoluteUri.Contains(this.BaseUri) && !links.Contains(absoluteUri))
                        {
                            newLinks.Add(absoluteUri);
                        }
                    }
                }
            }

            return newLinks;
        }

        public Collection<string> GetLinksOnPage(string uri)
        {
            Collection<string> links = new Collection<string>();

            return GetLinksOnPage(uri, links);
        }

        public bool PageExists(string uri)
        {
            var request = HttpWebRequest.Create(uri) as HttpWebRequest;
            if (request != null)
            {
                try
                {
                    var response = request.GetResponse() as HttpWebResponse;
                }
                catch (WebException)
                {
                    return false;
                }
            }

            return true;
        }

        public string GetAbsoluteUrl(string href)
        {
            var uri = new Uri(href, UriKind.RelativeOrAbsolute);

            if (!uri.IsAbsoluteUri)
            {
                uri = new Uri(new Uri(this.BaseUri), uri);
            }

            return uri.ToString();
        }
    }
}
