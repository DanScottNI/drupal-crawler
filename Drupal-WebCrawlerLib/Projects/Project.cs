using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drupal_WebCrawlerLib.Projects
{
    public class Project
    {
        public string BaseUri { get; set; }
        public string SiteName { get; set; }

        public Project(string baseUri, string sitename)
        {
            this.BaseUri = baseUri;
            this.SiteName = sitename;
        }
    }
}
