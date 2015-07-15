using Drupal_WebCrawlerLib.Projects;
using Drupal_WebCrawlerLib.Web;
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
    public partial class frmNewProject : Form
    {
        public frmNewProject()
        {
            InitializeComponent();
        }

        private void txtUri_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSitename.Text))
            {
                WebPage web = new WebPage(this.txtUri.Text);
                this.txtSitename.Text = web.Title;
            }
        }

        internal Project SiteProject
        {
            get
            {
                return new Project(this.txtUri.Text, this.txtSitename.Text);
            }
        }
    }
}
