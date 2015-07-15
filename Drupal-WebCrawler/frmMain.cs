using Drupal_WebCrawlerLib.Projects;
using System;
using System.Windows.Forms;

namespace Drupal_WebCrawler
{
    public partial class frmMain : Form
    {
        private string filename;
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
                    this.RefreshTitlebar();
                }
            }
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            this.RefreshTitlebar();
        }

        private void mnuSaveProject_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.filename))
            {
                if (sfdSaveProject.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Project.Save(this.SiteProject, sfdSaveProject.FileName);
                    this.filename = sfdSaveProject.FileName;
                }
            }
            else
            {
                Project.Save(this.SiteProject, this.filename);
            }
        }

        

        private void mnuOpenProject_Click(object sender, EventArgs e)
        {
            if (ofdOpenProject.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.SiteProject = Project.Load(ofdOpenProject.FileName);
                this.filename = ofdOpenProject.FileName;
                this.RefreshTitlebar();
                this.DisplayWebsiteLinks();
            }
        }

        private void DisplayWebsiteLinks()
        {

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
