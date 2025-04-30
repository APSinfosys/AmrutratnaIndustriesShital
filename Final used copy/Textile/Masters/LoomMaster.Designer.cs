namespace Textile.Masters
{
    partial class LoomMaster
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
            this.titleBar = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblUniqueCode = new System.Windows.Forms.Label();
            this.cmbLoomType = new System.Windows.Forms.ComboBox();
            this.lblSrNo = new System.Windows.Forms.Label();
            this.txtNoOfLoom = new System.Windows.Forms.TextBox();
            this.lblNoOfLoom = new System.Windows.Forms.Label();
            this.lblLoomType = new System.Windows.Forms.Label();
            this.txtShadeLocetion = new System.Windows.Forms.TextBox();
            this.lblShedLocation = new System.Windows.Forms.Label();
            this.txtShadeName = new System.Windows.Forms.TextBox();
            this.lblShadeName = new System.Windows.Forms.Label();
            this.btnCancle = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.titleBar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleBar
            // 
            this.titleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.titleBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.titleBar.Controls.Add(this.btnClose);
            this.titleBar.Controls.Add(this.label6);
            this.titleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleBar.Location = new System.Drawing.Point(0, 0);
            this.titleBar.Name = "titleBar";
            this.titleBar.Size = new System.Drawing.Size(475, 42);
            this.titleBar.TabIndex = 98;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackgroundImage = global::Textile.Properties.Resources.errorIcon;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(440, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 27);
            this.btnClose.TabIndex = 16;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(144, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(187, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "L O O M   M A S T E R";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblUniqueCode);
            this.panel1.Controls.Add(this.cmbLoomType);
            this.panel1.Controls.Add(this.lblSrNo);
            this.panel1.Controls.Add(this.txtNoOfLoom);
            this.panel1.Controls.Add(this.lblNoOfLoom);
            this.panel1.Controls.Add(this.lblLoomType);
            this.panel1.Controls.Add(this.txtShadeLocetion);
            this.panel1.Controls.Add(this.lblShedLocation);
            this.panel1.Controls.Add(this.txtShadeName);
            this.panel1.Controls.Add(this.lblShadeName);
            this.panel1.Location = new System.Drawing.Point(12, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(451, 107);
            this.panel1.TabIndex = 0;
            // 
            // lblUniqueCode
            // 
            this.lblUniqueCode.AutoSize = true;
            this.lblUniqueCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUniqueCode.ForeColor = System.Drawing.Color.White;
            this.lblUniqueCode.Location = new System.Drawing.Point(237, 36);
            this.lblUniqueCode.Name = "lblUniqueCode";
            this.lblUniqueCode.Size = new System.Drawing.Size(84, 16);
            this.lblUniqueCode.TabIndex = 109;
            this.lblUniqueCode.Text = "UniqueCode";
            // 
            // cmbLoomType
            // 
            this.cmbLoomType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cmbLoomType.FormattingEnabled = true;
            this.cmbLoomType.Location = new System.Drawing.Point(168, 72);
            this.cmbLoomType.Name = "cmbLoomType";
            this.cmbLoomType.Size = new System.Drawing.Size(121, 24);
            this.cmbLoomType.TabIndex = 2;
            // 
            // lblSrNo
            // 
            this.lblSrNo.AutoSize = true;
            this.lblSrNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSrNo.ForeColor = System.Drawing.Color.White;
            this.lblSrNo.Location = new System.Drawing.Point(398, 36);
            this.lblSrNo.Name = "lblSrNo";
            this.lblSrNo.Size = new System.Drawing.Size(39, 16);
            this.lblSrNo.TabIndex = 108;
            this.lblSrNo.Text = "SrNo";
            this.lblSrNo.Visible = false;
            // 
            // txtNoOfLoom
            // 
            this.txtNoOfLoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoOfLoom.Location = new System.Drawing.Point(310, 72);
            this.txtNoOfLoom.Name = "txtNoOfLoom";
            this.txtNoOfLoom.Size = new System.Drawing.Size(127, 22);
            this.txtNoOfLoom.TabIndex = 3;
            // 
            // lblNoOfLoom
            // 
            this.lblNoOfLoom.AutoSize = true;
            this.lblNoOfLoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoOfLoom.ForeColor = System.Drawing.Color.White;
            this.lblNoOfLoom.Location = new System.Drawing.Point(310, 47);
            this.lblNoOfLoom.Name = "lblNoOfLoom";
            this.lblNoOfLoom.Size = new System.Drawing.Size(90, 16);
            this.lblNoOfLoom.TabIndex = 107;
            this.lblNoOfLoom.Text = "NO OF LOOM";
            // 
            // lblLoomType
            // 
            this.lblLoomType.AutoSize = true;
            this.lblLoomType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoomType.ForeColor = System.Drawing.Color.White;
            this.lblLoomType.Location = new System.Drawing.Point(165, 47);
            this.lblLoomType.Name = "lblLoomType";
            this.lblLoomType.Size = new System.Drawing.Size(85, 16);
            this.lblLoomType.TabIndex = 105;
            this.lblLoomType.Text = "LOOM TYPE";
            // 
            // txtShadeLocetion
            // 
            this.txtShadeLocetion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShadeLocetion.Location = new System.Drawing.Point(20, 72);
            this.txtShadeLocetion.Name = "txtShadeLocetion";
            this.txtShadeLocetion.Size = new System.Drawing.Size(127, 22);
            this.txtShadeLocetion.TabIndex = 1;
            // 
            // lblShedLocation
            // 
            this.lblShedLocation.AutoSize = true;
            this.lblShedLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShedLocation.ForeColor = System.Drawing.Color.White;
            this.lblShedLocation.Location = new System.Drawing.Point(20, 47);
            this.lblShedLocation.Name = "lblShedLocation";
            this.lblShedLocation.Size = new System.Drawing.Size(75, 16);
            this.lblShedLocation.TabIndex = 103;
            this.lblShedLocation.Text = "LOCETION";
            // 
            // txtShadeName
            // 
            this.txtShadeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShadeName.Location = new System.Drawing.Point(110, 11);
            this.txtShadeName.Name = "txtShadeName";
            this.txtShadeName.Size = new System.Drawing.Size(328, 22);
            this.txtShadeName.TabIndex = 0;
            // 
            // lblShadeName
            // 
            this.lblShadeName.AutoSize = true;
            this.lblShadeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShadeName.ForeColor = System.Drawing.Color.White;
            this.lblShadeName.Location = new System.Drawing.Point(20, 14);
            this.lblShadeName.Name = "lblShadeName";
            this.lblShadeName.Size = new System.Drawing.Size(88, 16);
            this.lblShadeName.TabIndex = 101;
            this.lblShadeName.Text = "SHED NAME";
            // 
            // btnCancle
            // 
            this.btnCancle.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnCancle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancle.ForeColor = System.Drawing.Color.White;
            this.btnCancle.Location = new System.Drawing.Point(253, 164);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(115, 27);
            this.btnCancle.TabIndex = 2;
            this.btnCancle.Text = "CANCLE";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(98, 164);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(115, 27);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lineShape1
            // 
            this.lineShape1.BorderColor = System.Drawing.Color.White;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 8;
            this.lineShape1.X2 = 467;
            this.lineShape1.Y1 = 157;
            this.lineShape1.Y2 = 157;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(475, 198);
            this.shapeContainer1.TabIndex = 102;
            this.shapeContainer1.TabStop = false;
            // 
            // LoomMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.ClientSize = new System.Drawing.Size(475, 198);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.titleBar);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoomMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoomMaster";
            this.Load += new System.EventHandler(this.LoomMaster_Load);
            this.titleBar.ResumeLayout(false);
            this.titleBar.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel titleBar;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label lblSrNo;
        public System.Windows.Forms.TextBox txtNoOfLoom;
        private System.Windows.Forms.Label lblNoOfLoom;
        private System.Windows.Forms.Label lblLoomType;
        public System.Windows.Forms.TextBox txtShadeLocetion;
        private System.Windows.Forms.Label lblShedLocation;
        public System.Windows.Forms.TextBox txtShadeName;
        private System.Windows.Forms.Label lblShadeName;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Button btnSave;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        public System.Windows.Forms.ComboBox cmbLoomType;
        public System.Windows.Forms.Label lblUniqueCode;
    }
}