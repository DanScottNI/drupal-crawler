﻿using Drupal_WebCrawlerLib.Projects;
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
            
        }
    }
}
