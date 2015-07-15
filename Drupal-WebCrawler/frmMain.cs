using Drupal_WebCrawlerLib.Projects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drupal_WebCrawler
{
    public partial class frmMain : Form
    {
        private Project SiteProject { get; set; }

        public frmMain()
        {
            InitializeComponent();
        }

        private void mnuNewProject_Click(object sender, EventArgs e)
        {
            using (frmNewProject newProj = new frmNewProject())
            {
                if (newProj.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    this.SiteProject = newProj.SiteProject;

                }
            }
        }

        private void RefreshTitlebar()
        {
            if (this.SiteProject != null)
            {
                this.Text = "Drupal Web Crawler - " + this.SiteProject.SiteName;
            }
            else
            {
                this.Text = "Drupal Web Crawler";
            }
        }
    }
}
