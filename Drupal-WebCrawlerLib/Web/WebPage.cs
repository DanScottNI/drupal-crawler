using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drupal_WebCrawlerLib.Extensions;
using System.Net;

namespace Drupal_WebCrawlerLib.Web
{
    public class WebPage
    {
        private HtmlDocument doc;
        public string Uri { get; set; }
        public string BaseUri { get; set; }

        public WebPage(string uri)
        {
            this.BaseUri = uri;
            this.Uri = uri;
        }

        public WebPage(string baseUri, string uri)
        {
            this.BaseUri = baseUri;
            this.Uri = uri;
        }

        /// <summary>
        /// Gets the 
        /// </summary>
        protected HtmlDocument Document
        {
            get
            {
                if (this.doc == null)
                {
                    this.doc = this.GetWebPage(this.Uri);
                }

                return this.doc;
            }

            private set
            {
                this.doc = value;
            }
        }

        /// <summary>
        /// Gets the text of the HTML document as a string.
        /// </summary>
        public string DocumentText
        {
            get
            {
                if (this.Document != null)
                {
                    return this.Document.DocumentNode.OuterHtml;
                }

                return string.Empty;
            }
        }

        public string Title
        {
            get
            {
                string websiteTitle = string.Empty;
                HtmlNodeCollection nodes = this.Document.DocumentNode.SelectNodes("//title");

                if (nodes != null && nodes.Any())
                {
                    foreach (var title in nodes)
                    {
                        websiteTitle = title.InnerText;
                    }
                }

                return websiteTitle.Trim();
            }
        }

        public HtmlNodeCollection SearchElements(string xpath)
        {
            HtmlNodeCollection nodes = this.Document.DocumentNode.SelectNodes(xpath);
            return nodes;
        }

        public Collection<string> GetAllLinkDestinations(bool excludeAnchors = true)
        {
            HtmlNodeCollection nodes = this.Document.DocumentNode.SelectNodes("//a");
            Collection<string> newLinks = new Collection<string>();

            if (nodes != null && nodes.Any())
            {
                foreach (var link in nodes)
                {
                    var href = link.GetAttributeValue("href", string.Empty);

                    // avoid anchors
                    if (!string.IsNullOrWhiteSpace(href))
                    {
                        // build absolute uri
                        var absoluteUri = href.GetAbsoluteUrl(this.BaseUri);

                        if (absoluteUri.IndexOf('#') > -1)
                        {
                            absoluteUri = absoluteUri.Substring(0, absoluteUri.LastIndexOf('#'));
                        }

                        // only crawl links from the base URL
                        if (absoluteUri.Contains(this.BaseUri))
                        {
                            newLinks.Add(absoluteUri);
                        }
                    }

                }
            }

            return newLinks;
        }

        protected HtmlDocument GetWebPage(string uri)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = null;

            doc = web.Load(uri, "GET");

            return doc;
        }

        public bool PageExists()
        {
            var request = HttpWebRequest.Create(this.Uri) as HttpWebRequest;
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
    }
}
