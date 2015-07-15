using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

        public static Project Load(string filename)
        {
            string body = File.ReadAllText(filename);
            return JsonConvert.DeserializeObject<Project>(body);
        }

        public static void Save(Project project, string filename)
        {
            string projectText = JsonConvert.SerializeObject(project);
            File.WriteAllText(filename, projectText);
        }
    }
}
