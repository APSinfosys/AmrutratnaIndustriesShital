namespace Textile.TransactionForms
{
    partial class Transaction_JournalVoucher
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
            this.label11 = new System.Windows.Forms.Label();
            this.cmbName = new System.Windows.Forms.ComboBox();
            this.cmbFirm = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblUniqueCode = new System.Windows.Forms.Label();
            this.dtpChqueDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtChqueNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTypeOfPayment = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPaidBy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbAccount = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbShadeName = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblSrNo = new System.Windows.Forms.Label();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.dtpJVDate = new System.Windows.Forms.DateTimePicker();
            this.lblInvoiceDate = new System.Windows.Forms.Label();
            this.txtJVNo = new System.Windows.Forms.TextBox();
            this.lblInvoiceNo = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.btnCancle = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTDSPer = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTDSAMOUNT = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lblActualAmount = new System.Windows.Forms.Label();
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
            this.titleBar.Size = new System.Drawing.Size(569, 42);
            this.titleBar.TabIndex = 99;
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
            this.btnClose.Location = new System.Drawing.Point(531, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(32, 26);
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
            this.label6.Location = new System.Drawing.Point(160, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(254, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "J O U R N A L   V O U C H E R";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblActualAmount);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.txtTDSAMOUNT);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.txtTDSPer);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.cmbName);
            this.panel1.Controls.Add(this.cmbFirm);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.lblUniqueCode);
            this.panel1.Controls.Add(this.dtpChqueDate);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtChqueNo);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cmbTypeOfPayment);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtNote);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtAmount);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbPaidBy);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbAccount);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cmbShadeName);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.lblSrNo);
            this.panel1.Controls.Add(this.lblSupplier);
            this.panel1.Controls.Add(this.dtpJVDate);
            this.panel1.Controls.Add(this.lblInvoiceDate);
            this.panel1.Controls.Add(this.txtJVNo);
            this.panel1.Controls.Add(this.lblInvoiceNo);
            this.panel1.Location = new System.Drawing.Point(10, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(549, 389);
            this.panel1.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(292, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 16);
            this.label11.TabIndex = 180;
            this.label11.Text = "partyCode";
            this.label11.Visible = false;
            // 
            // cmbName
            // 
            this.cmbName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbName.FormattingEnabled = true;
            this.cmbName.Location = new System.Drawing.Point(127, 150);
            this.cmbName.Name = "cmbName";
            this.cmbName.Size = new System.Drawing.Size(375, 23);
            this.cmbName.TabIndex = 5;
            this.cmbName.SelectedIndexChanged += new System.EventHandler(this.cmbName_SelectedIndexChanged);
            // 
            // cmbFirm
            // 
            this.cmbFirm.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbFirm.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFirm.FormattingEnabled = true;
            this.cmbFirm.Location = new System.Drawing.Point(127, 120);
            this.cmbFirm.Name = "cmbFirm";
            this.cmbFirm.Size = new System.Drawing.Size(375, 23);
            this.cmbFirm.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(12, 123);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 16);
            this.label10.TabIndex = 178;
            this.label10.Text = "FIRM NAME";
            // 
            // lblUniqueCode
            // 
            this.lblUniqueCode.AutoSize = true;
            this.lblUniqueCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUniqueCode.ForeColor = System.Drawing.Color.White;
            this.lblUniqueCode.Location = new System.Drawing.Point(470, 14);
            this.lblUniqueCode.Name = "lblUniqueCode";
            this.lblUniqueCode.Size = new System.Drawing.Size(84, 16);
            this.lblUniqueCode.TabIndex = 176;
            this.lblUniqueCode.Text = "UniqueCode";
            this.lblUniqueCode.Visible = false;
            // 
            // dtpChqueDate
            // 
            this.dtpChqueDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpChqueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpChqueDate.Location = new System.Drawing.Point(386, 270);
            this.dtpChqueDate.Name = "dtpChqueDate";
            this.dtpChqueDate.Size = new System.Drawing.Size(116, 22);
            this.dtpChqueDate.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(273, 273);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 16);
            this.label5.TabIndex = 175;
            this.label5.Text = "CHEQUE DATE";
            // 
            // txtChqueNo
            // 
            this.txtChqueNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChqueNo.Location = new System.Drawing.Point(127, 270);
            this.txtChqueNo.Name = "txtChqueNo";
            this.txtChqueNo.Size = new System.Drawing.Size(138, 22);
            this.txtChqueNo.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 273);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 173;
            this.label4.Text = "CHEQUE NO";
            // 
            // cmbTypeOfPayment
            // 
            this.cmbTypeOfPayment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbTypeOfPayment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTypeOfPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTypeOfPayment.FormattingEnabled = true;
            this.cmbTypeOfPayment.Location = new System.Drawing.Point(127, 52);
            this.cmbTypeOfPayment.Name = "cmbTypeOfPayment";
            this.cmbTypeOfPayment.Size = new System.Drawing.Size(272, 23);
            this.cmbTypeOfPayment.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 32);
            this.label3.TabIndex = 170;
            this.label3.Text = "TYPE OF \r\n PAYMENT";
            // 
            // txtNote
            // 
            this.txtNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNote.Location = new System.Drawing.Point(127, 333);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(375, 51);
            this.txtNote.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(12, 333);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 16);
            this.label9.TabIndex = 169;
            this.label9.Text = "NOTE";
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(127, 180);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(138, 22);
            this.txtAmount.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 169;
            this.label1.Text = "AMOUNT";
            // 
            // cmbPaidBy
            // 
            this.cmbPaidBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbPaidBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPaidBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPaidBy.FormattingEnabled = true;
            this.cmbPaidBy.Location = new System.Drawing.Point(127, 240);
            this.cmbPaidBy.Name = "cmbPaidBy";
            this.cmbPaidBy.Size = new System.Drawing.Size(137, 23);
            this.cmbPaidBy.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 243);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 166;
            this.label2.Text = "PAID BY";
            // 
            // cmbAccount
            // 
            this.cmbAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAccount.FormattingEnabled = true;
            this.cmbAccount.Location = new System.Drawing.Point(127, 300);
            this.cmbAccount.Name = "cmbAccount";
            this.cmbAccount.Size = new System.Drawing.Size(375, 23);
            this.cmbAccount.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(12, 303);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 16);
            this.label8.TabIndex = 166;
            this.label8.Text = "BANK NAME";
            // 
            // cmbShadeName
            // 
            this.cmbShadeName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbShadeName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbShadeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbShadeName.FormattingEnabled = true;
            this.cmbShadeName.Location = new System.Drawing.Point(127, 90);
            this.cmbShadeName.Name = "cmbShadeName";
            this.cmbShadeName.Size = new System.Drawing.Size(375, 23);
            this.cmbShadeName.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(12, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 16);
            this.label7.TabIndex = 166;
            this.label7.Text = "SHADE NAME";
            // 
            // lblSrNo
            // 
            this.lblSrNo.AutoSize = true;
            this.lblSrNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSrNo.ForeColor = System.Drawing.Color.White;
            this.lblSrNo.Location = new System.Drawing.Point(414, 17);
            this.lblSrNo.Name = "lblSrNo";
            this.lblSrNo.Size = new System.Drawing.Size(39, 16);
            this.lblSrNo.TabIndex = 161;
            this.lblSrNo.Text = "SrNo";
            this.lblSrNo.Visible = false;
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplier.ForeColor = System.Drawing.Color.White;
            this.lblSupplier.Location = new System.Drawing.Point(12, 153);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(47, 16);
            this.lblSupplier.TabIndex = 128;
            this.lblSupplier.Text = "NAME";
            // 
            // dtpJVDate
            // 
            this.dtpJVDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpJVDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpJVDate.Location = new System.Drawing.Point(283, 14);
            this.dtpJVDate.Name = "dtpJVDate";
            this.dtpJVDate.Size = new System.Drawing.Size(116, 22);
            this.dtpJVDate.TabIndex = 1;
            // 
            // lblInvoiceDate
            // 
            this.lblInvoiceDate.AutoSize = true;
            this.lblInvoiceDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceDate.ForeColor = System.Drawing.Color.White;
            this.lblInvoiceDate.Location = new System.Drawing.Point(218, 17);
            this.lblInvoiceDate.Name = "lblInvoiceDate";
            this.lblInvoiceDate.Size = new System.Drawing.Size(45, 16);
            this.lblInvoiceDate.TabIndex = 126;
            this.lblInvoiceDate.Text = "DATE";
            // 
            // txtJVNo
            // 
            this.txtJVNo.Enabled = false;
            this.txtJVNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJVNo.Location = new System.Drawing.Point(127, 14);
            this.txtJVNo.Name = "txtJVNo";
            this.txtJVNo.ReadOnly = true;
            this.txtJVNo.Size = new System.Drawing.Size(80, 22);
            this.txtJVNo.TabIndex = 0;
            // 
            // lblInvoiceNo
            // 
            this.lblInvoiceNo.AutoSize = true;
            this.lblInvoiceNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceNo.ForeColor = System.Drawing.Color.White;
            this.lblInvoiceNo.Location = new System.Drawing.Point(12, 17);
            this.lblInvoiceNo.Name = "lblInvoiceNo";
            this.lblInvoiceNo.Size = new System.Drawing.Size(101, 16);
            this.lblInvoiceNo.TabIndex = 125;
            this.lblInvoiceNo.Text = "VOUCHER  NO";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(569, 483);
            this.shapeContainer1.TabIndex = 101;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.BorderColor = System.Drawing.Color.White;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 5;
            this.lineShape1.X2 = 561;
            this.lineShape1.Y1 = 443;
            this.lineShape1.Y2 = 443;
            // 
            // btnCancle
            // 
            this.btnCancle.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnCancle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancle.ForeColor = System.Drawing.Color.White;
            this.btnCancle.Location = new System.Drawing.Point(306, 448);
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
            this.btnSave.Location = new System.Drawing.Point(151, 448);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(115, 27);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(12, 213);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 16);
            this.label12.TabIndex = 181;
            this.label12.Text = "TDS(%)";
            // 
            // txtTDSPer
            // 
            this.txtTDSPer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTDSPer.Location = new System.Drawing.Point(127, 210);
            this.txtTDSPer.Name = "txtTDSPer";
            this.txtTDSPer.Size = new System.Drawing.Size(138, 22);
            this.txtTDSPer.TabIndex = 7;
            this.txtTDSPer.Leave += new System.EventHandler(this.txtTDSPer_Leave);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(273, 213);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(98, 16);
            this.label13.TabIndex = 183;
            this.label13.Text = "TDS AMOUNT";
            // 
            // txtTDSAMOUNT
            // 
            this.txtTDSAMOUNT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTDSAMOUNT.Location = new System.Drawing.Point(386, 210);
            this.txtTDSAMOUNT.Name = "txtTDSAMOUNT";
            this.txtTDSAMOUNT.Size = new System.Drawing.Size(116, 22);
            this.txtTDSAMOUNT.TabIndex = 8;
            this.txtTDSAMOUNT.Leave += new System.EventHandler(this.txtTDSAMOUNT_Leave);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(273, 183);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(123, 16);
            this.label14.TabIndex = 184;
            this.label14.Text = "ACTUAL AMOUNT";
            // 
            // lblActualAmount
            // 
            this.lblActualAmount.AutoSize = true;
            this.lblActualAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActualAmount.ForeColor = System.Drawing.Color.White;
            this.lblActualAmount.Location = new System.Drawing.Point(409, 183);
            this.lblActualAmount.Name = "lblActualAmount";
            this.lblActualAmount.Size = new System.Drawing.Size(32, 16);
            this.lblActualAmount.TabIndex = 185;
            this.lblActualAmount.Text = "0.00";
            // 
            // Transaction_JournalVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.ClientSize = new System.Drawing.Size(569, 483);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.titleBar);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Transaction_JournalVoucher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transaction_JournalVoucher";
            this.Load += new System.EventHandler(this.Transaction_JournalVoucher_Load);
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
        public System.Windows.Forms.DateTimePicker dtpChqueDate;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtChqueNo;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox cmbTypeOfPayment;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtNote;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox txtAmount;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cmbPaidBy;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cmbAccount;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.ComboBox cmbShadeName;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label lblSrNo;
        public System.Windows.Forms.Label lblSupplier;
        public System.Windows.Forms.DateTimePicker dtpJVDate;
        public System.Windows.Forms.Label lblInvoiceDate;
        public System.Windows.Forms.TextBox txtJVNo;
        public System.Windows.Forms.Label lblInvoiceNo;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Label lblUniqueCode;
        public System.Windows.Forms.ComboBox cmbFirm;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.ComboBox cmbName;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.TextBox txtTDSAMOUNT;
        public System.Windows.Forms.Label label13;
        public System.Windows.Forms.TextBox txtTDSPer;
        public System.Windows.Forms.Label label12;
        public System.Windows.Forms.Label lblActualAmount;
        public System.Windows.Forms.Label label14;
    }
}