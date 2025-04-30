namespace Textile.TransactionReport
{
    partial class CRTransaction
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
            this.CRVReport1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.PanelTitle = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.PanelTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // CRVReport1
            // 
            this.CRVReport1.ActiveViewIndex = -1;
            this.CRVReport1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRVReport1.Cursor = System.Windows.Forms.Cursors.Default;
            this.CRVReport1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CRVReport1.Location = new System.Drawing.Point(0, 39);
            this.CRVReport1.Name = "CRVReport1";
            this.CRVReport1.SelectionFormula = "";
            this.CRVReport1.ShowCloseButton = false;
            this.CRVReport1.ShowCopyButton = false;
            this.CRVReport1.ShowParameterPanelButton = false;
            this.CRVReport1.ShowRefreshButton = false;
            this.CRVReport1.Size = new System.Drawing.Size(997, 621);
            this.CRVReport1.TabIndex = 1;
            this.CRVReport1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.CRVReport1.ViewTimeSelectionFormula = "";
            this.CRVReport1.Load += new System.EventHandler(this.CRVReport1_Load);
            // 
            // PanelTitle
            // 
            this.PanelTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.PanelTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PanelTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelTitle.Controls.Add(this.button1);
            this.PanelTitle.Controls.Add(this.lblTitle);
            this.PanelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTitle.Location = new System.Drawing.Point(0, 0);
            this.PanelTitle.Name = "PanelTitle";
            this.PanelTitle.Size = new System.Drawing.Size(997, 37);
            this.PanelTitle.TabIndex = 0;
            this.PanelTitle.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelTitle_Paint);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackgroundImage = global::Textile.Properties.Resources.errorIcon;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(960, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 27);
            this.button1.TabIndex = 578;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(5, 4);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(132, 24);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Print Preview";
            // 
            // CRTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 660);
            this.Controls.Add(this.PanelTitle);
            this.Controls.Add(this.CRVReport1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CRTransaction";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CRTransaction";
            this.Load += new System.EventHandler(this.CRTransaction_Load);
            this.PanelTitle.ResumeLayout(false);
            this.PanelTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRVReport;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRVReport1;
        private System.Windows.Forms.Panel PanelTitle;
        public System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button button1;
    }
}