namespace Drupal_WebCrawler
{
    partial class frmNewProject
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblUri = new System.Windows.Forms.Label();
            this.txtUri = new System.Windows.Forms.TextBox();
            this.lblSitename = new System.Windows.Forms.Label();
            this.txtSitename = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblUri
            // 
            this.lblUri.AutoSize = true;
            this.lblUri.Location = new System.Drawing.Point(12, 9);
            this.lblUri.Name = "lblUri";
            this.lblUri.Size = new System.Drawing.Size(31, 17);
            this.lblUri.TabIndex = 0;
            this.lblUri.Text = "URI:";
            // 
            // txtUri
            // 
            this.txtUri.Location = new System.Drawing.Point(70, 9);
            this.txtUri.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUri.Name = "txtUri";
            this.txtUri.Size = new System.Drawing.Size(696, 25);
            this.txtUri.TabIndex = 1;
            this.txtUri.Leave += new System.EventHandler(this.txtUri_Leave);
            // 
            // lblSitename
            // 
            this.lblSitename.AutoSize = true;
            this.lblSitename.Location = new System.Drawing.Point(12, 51);
            this.lblSitename.Name = "lblSitename";
            this.lblSitename.Size = new System.Drawing.Size(46, 17);
            this.lblSitename.TabIndex = 2;
            this.lblSitename.Text = "Name:";
            // 
            // txtSitename
            // 
            this.txtSitename.Location = new System.Drawing.Point(70, 51);
            this.txtSitename.Name = "txtSitename";
            this.txtSitename.Size = new System.Drawing.Size(696, 25);
            this.txtSitename.TabIndex = 4;
            // 
            // frmNewProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 367);
            this.Controls.Add(this.txtSitename);
            this.Controls.Add(this.lblSitename);
            this.Controls.Add(this.txtUri);
            this.Controls.Add(this.lblUri);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmNewProject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Project";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUri;
        private System.Windows.Forms.TextBox txtUri;
        private System.Windows.Forms.Label lblSitename;
        private System.Windows.Forms.TextBox txtSitename;
    }
}