namespace Textile.Masters
{
    partial class ClothDesignMaster
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
            this.btnCancle = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmbWeft = new System.Windows.Forms.ComboBox();
            this.lblWeftCount = new System.Windows.Forms.Label();
            this.txtWeftCount = new System.Windows.Forms.TextBox();
            this.lblWeft = new System.Windows.Forms.Label();
            this.lblWeftSutType = new System.Windows.Forms.Label();
            this.txtWeftSutType = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbWarf = new System.Windows.Forms.ComboBox();
            this.lblWarfCount = new System.Windows.Forms.Label();
            this.txtWarfCount = new System.Windows.Forms.TextBox();
            this.lblWarf = new System.Windows.Forms.Label();
            this.lblWarfSutType = new System.Windows.Forms.Label();
            this.txtWarfSutType = new System.Windows.Forms.TextBox();
            this.txtDesignName = new System.Windows.Forms.TextBox();
            this.lblSrNo = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.BtnCerrar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.titleBar = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.titleBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancle
            // 
            this.btnCancle.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnCancle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancle.ForeColor = System.Drawing.Color.White;
            this.btnCancle.Location = new System.Drawing.Point(322, 276);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(115, 27);
            this.btnCancle.TabIndex = 108;
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
            this.btnSave.Location = new System.Drawing.Point(167, 276);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(115, 27);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.txtDesignName);
            this.panel1.Controls.Add(this.lblSrNo);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Location = new System.Drawing.Point(8, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(558, 221);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.cmbWeft);
            this.panel3.Controls.Add(this.lblWeftCount);
            this.panel3.Controls.Add(this.txtWeftCount);
            this.panel3.Controls.Add(this.lblWeft);
            this.panel3.Controls.Add(this.lblWeftSutType);
            this.panel3.Controls.Add(this.txtWeftSutType);
            this.panel3.ForeColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(283, 66);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(251, 148);
            this.panel3.TabIndex = 2;
            // 
            // cmbWeft
            // 
            this.cmbWeft.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbWeft.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbWeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbWeft.Location = new System.Drawing.Point(12, 64);
            this.cmbWeft.Name = "cmbWeft";
            this.cmbWeft.Size = new System.Drawing.Size(199, 24);
            this.cmbWeft.TabIndex = 0;
            // 
            // lblWeftCount
            // 
            this.lblWeftCount.AutoSize = true;
            this.lblWeftCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeftCount.ForeColor = System.Drawing.Color.White;
            this.lblWeftCount.Location = new System.Drawing.Point(9, 92);
            this.lblWeftCount.Name = "lblWeftCount";
            this.lblWeftCount.Size = new System.Drawing.Size(56, 16);
            this.lblWeftCount.TabIndex = 113;
            this.lblWeftCount.Text = "COUNT";
            // 
            // txtWeftCount
            // 
            this.txtWeftCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWeftCount.Location = new System.Drawing.Point(12, 111);
            this.txtWeftCount.Name = "txtWeftCount";
            this.txtWeftCount.Size = new System.Drawing.Size(199, 22);
            this.txtWeftCount.TabIndex = 1;
            // 
            // lblWeft
            // 
            this.lblWeft.AutoSize = true;
            this.lblWeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeft.ForeColor = System.Drawing.Color.White;
            this.lblWeft.Location = new System.Drawing.Point(9, 10);
            this.lblWeft.Name = "lblWeft";
            this.lblWeft.Size = new System.Drawing.Size(55, 18);
            this.lblWeft.TabIndex = 110;
            this.lblWeft.Text = "WEFT";
            // 
            // lblWeftSutType
            // 
            this.lblWeftSutType.AutoSize = true;
            this.lblWeftSutType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeftSutType.ForeColor = System.Drawing.Color.White;
            this.lblWeftSutType.Location = new System.Drawing.Point(9, 42);
            this.lblWeftSutType.Name = "lblWeftSutType";
            this.lblWeftSutType.Size = new System.Drawing.Size(75, 16);
            this.lblWeftSutType.TabIndex = 98;
            this.lblWeftSutType.Text = "SUT TYPE";
            // 
            // txtWeftSutType
            // 
            this.txtWeftSutType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWeftSutType.Location = new System.Drawing.Point(209, 6);
            this.txtWeftSutType.Name = "txtWeftSutType";
            this.txtWeftSutType.Size = new System.Drawing.Size(12, 22);
            this.txtWeftSutType.TabIndex = 0;
            this.txtWeftSutType.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cmbWarf);
            this.panel2.Controls.Add(this.lblWarfCount);
            this.panel2.Controls.Add(this.txtWarfCount);
            this.panel2.Controls.Add(this.lblWarf);
            this.panel2.Controls.Add(this.lblWarfSutType);
            this.panel2.Controls.Add(this.txtWarfSutType);
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(26, 66);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(251, 148);
            this.panel2.TabIndex = 1;
            // 
            // cmbWarf
            // 
            this.cmbWarf.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbWarf.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbWarf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbWarf.Location = new System.Drawing.Point(15, 64);
            this.cmbWarf.Name = "cmbWarf";
            this.cmbWarf.Size = new System.Drawing.Size(199, 24);
            this.cmbWarf.TabIndex = 0;
            // 
            // lblWarfCount
            // 
            this.lblWarfCount.AutoSize = true;
            this.lblWarfCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarfCount.ForeColor = System.Drawing.Color.White;
            this.lblWarfCount.Location = new System.Drawing.Point(15, 92);
            this.lblWarfCount.Name = "lblWarfCount";
            this.lblWarfCount.Size = new System.Drawing.Size(56, 16);
            this.lblWarfCount.TabIndex = 111;
            this.lblWarfCount.Text = "COUNT";
            // 
            // txtWarfCount
            // 
            this.txtWarfCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWarfCount.Location = new System.Drawing.Point(15, 111);
            this.txtWarfCount.Name = "txtWarfCount";
            this.txtWarfCount.Size = new System.Drawing.Size(199, 22);
            this.txtWarfCount.TabIndex = 1;
            // 
            // lblWarf
            // 
            this.lblWarf.AutoSize = true;
            this.lblWarf.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarf.ForeColor = System.Drawing.Color.White;
            this.lblWarf.Location = new System.Drawing.Point(9, 10);
            this.lblWarf.Name = "lblWarf";
            this.lblWarf.Size = new System.Drawing.Size(56, 18);
            this.lblWarf.TabIndex = 110;
            this.lblWarf.Text = "WARF";
            // 
            // lblWarfSutType
            // 
            this.lblWarfSutType.AutoSize = true;
            this.lblWarfSutType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarfSutType.ForeColor = System.Drawing.Color.White;
            this.lblWarfSutType.Location = new System.Drawing.Point(15, 42);
            this.lblWarfSutType.Name = "lblWarfSutType";
            this.lblWarfSutType.Size = new System.Drawing.Size(75, 16);
            this.lblWarfSutType.TabIndex = 98;
            this.lblWarfSutType.Text = "SUT TYPE";
            // 
            // txtWarfSutType
            // 
            this.txtWarfSutType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWarfSutType.Location = new System.Drawing.Point(132, 10);
            this.txtWarfSutType.Name = "txtWarfSutType";
            this.txtWarfSutType.Size = new System.Drawing.Size(10, 22);
            this.txtWarfSutType.TabIndex = 0;
            this.txtWarfSutType.Visible = false;
            // 
            // txtDesignName
            // 
            this.txtDesignName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesignName.Location = new System.Drawing.Point(140, 27);
            this.txtDesignName.Name = "txtDesignName";
            this.txtDesignName.Size = new System.Drawing.Size(394, 22);
            this.txtDesignName.TabIndex = 0;
            // 
            // lblSrNo
            // 
            this.lblSrNo.AutoSize = true;
            this.lblSrNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSrNo.ForeColor = System.Drawing.Color.White;
            this.lblSrNo.Location = new System.Drawing.Point(480, 6);
            this.lblSrNo.Name = "lblSrNo";
            this.lblSrNo.Size = new System.Drawing.Size(39, 16);
            this.lblSrNo.TabIndex = 103;
            this.lblSrNo.Text = "SrNo";
            this.lblSrNo.Visible = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(26, 27);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(101, 16);
            this.lblName.TabIndex = 97;
            this.lblName.Text = "DESIGN NAME";
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCerrar.FlatAppearance.BorderSize = 0;
            this.BtnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.BtnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCerrar.Location = new System.Drawing.Point(601, 2);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(37, 31);
            this.BtnCerrar.TabIndex = 4;
            this.BtnCerrar.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(135, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(309, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "C L O T H   D E S I G N   M A S T E R";
            // 
            // titleBar
            // 
            this.titleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.titleBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.titleBar.Controls.Add(this.btnClose);
            this.titleBar.Controls.Add(this.BtnCerrar);
            this.titleBar.Controls.Add(this.label6);
            this.titleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleBar.Location = new System.Drawing.Point(0, 0);
            this.titleBar.Name = "titleBar";
            this.titleBar.Size = new System.Drawing.Size(578, 42);
            this.titleBar.TabIndex = 105;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackgroundImage = global::Textile.Properties.Resources.cross_24_128;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(548, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(20, 20);
            this.btnClose.TabIndex = 16;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lineShape1
            // 
            this.lineShape1.BorderColor = System.Drawing.Color.White;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 5;
            this.lineShape1.X2 = 569;
            this.lineShape1.Y1 = 271;
            this.lineShape1.Y2 = 271;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(578, 310);
            this.shapeContainer1.TabIndex = 109;
            this.shapeContainer1.TabStop = false;
            // 
            // ClothDesignMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.ClientSize = new System.Drawing.Size(578, 310);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.titleBar);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ClothDesignMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ClothDesignMaster";
            this.Load += new System.EventHandler(this.ClothDesignMaster_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.titleBar.ResumeLayout(false);
            this.titleBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblWarfSutType;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button BtnCerrar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel titleBar;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblWarf;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblWeftCount;
        private System.Windows.Forms.Label lblWeft;
        private System.Windows.Forms.Label lblWeftSutType;
        private System.Windows.Forms.Label lblWarfCount;
        public System.Windows.Forms.ComboBox cmbWeft;
        public System.Windows.Forms.ComboBox cmbWarf;
        public System.Windows.Forms.TextBox txtWarfSutType;
        public System.Windows.Forms.TextBox txtDesignName;
        public System.Windows.Forms.Label lblSrNo;
        public System.Windows.Forms.TextBox txtWeftCount;
        public System.Windows.Forms.TextBox txtWeftSutType;
        public System.Windows.Forms.TextBox txtWarfCount;
    }
}