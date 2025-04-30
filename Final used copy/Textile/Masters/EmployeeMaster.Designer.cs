namespace Textile.Masters
{
    partial class EmployeeMaster
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBakiBalType = new System.Windows.Forms.ComboBox();
            this.txtBakiBalance = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblBalanceType = new System.Windows.Forms.Label();
            this.cmbBalanceType = new System.Windows.Forms.ComboBox();
            this.txtOpeningBalance = new System.Windows.Forms.TextBox();
            this.lblOpeningBalance = new System.Windows.Forms.Label();
            this.txtRPassword = new System.Windows.Forms.TextBox();
            this.lblRPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.txtIfscCode = new System.Windows.Forms.TextBox();
            this.lblIFSCcode = new System.Windows.Forms.Label();
            this.txtAccNo = new System.Windows.Forms.TextBox();
            this.lblACCno = new System.Windows.Forms.Label();
            this.txtBranch = new System.Windows.Forms.TextBox();
            this.lblBranch = new System.Windows.Forms.Label();
            this.txtBankName = new System.Windows.Forms.TextBox();
            this.lblBankName = new System.Windows.Forms.Label();
            this.lblEmpType = new System.Windows.Forms.Label();
            this.txtMobileNo = new System.Windows.Forms.TextBox();
            this.txtAlternetNo = new System.Windows.Forms.TextBox();
            this.txtAdress = new System.Windows.Forms.TextBox();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.lblSrNo = new System.Windows.Forms.Label();
            this.lblLOcation = new System.Windows.Forms.Label();
            this.lblContact2 = new System.Windows.Forms.Label();
            this.lblEmpName = new System.Windows.Forms.Label();
            this.lblContact1 = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.btnCancle = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
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
            this.titleBar.Size = new System.Drawing.Size(587, 42);
            this.titleBar.TabIndex = 100;
            this.titleBar.Paint += new System.Windows.Forms.PaintEventHandler(this.titleBar_Paint);
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
            this.btnClose.Location = new System.Drawing.Point(552, 4);
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
            this.label6.Location = new System.Drawing.Point(167, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(253, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "E M P L O Y E E   M A S T E R";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblUniqueCode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbBakiBalType);
            this.panel1.Controls.Add(this.txtBakiBalance);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblBalanceType);
            this.panel1.Controls.Add(this.cmbBalanceType);
            this.panel1.Controls.Add(this.txtOpeningBalance);
            this.panel1.Controls.Add(this.lblOpeningBalance);
            this.panel1.Controls.Add(this.txtRPassword);
            this.panel1.Controls.Add(this.lblRPassword);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Controls.Add(this.lblPassword);
            this.panel1.Controls.Add(this.txtUserName);
            this.panel1.Controls.Add(this.lblUserName);
            this.panel1.Controls.Add(this.cmbType);
            this.panel1.Controls.Add(this.cmbLocation);
            this.panel1.Controls.Add(this.txtIfscCode);
            this.panel1.Controls.Add(this.lblIFSCcode);
            this.panel1.Controls.Add(this.txtAccNo);
            this.panel1.Controls.Add(this.lblACCno);
            this.panel1.Controls.Add(this.txtBranch);
            this.panel1.Controls.Add(this.lblBranch);
            this.panel1.Controls.Add(this.txtBankName);
            this.panel1.Controls.Add(this.lblBankName);
            this.panel1.Controls.Add(this.lblEmpType);
            this.panel1.Controls.Add(this.txtMobileNo);
            this.panel1.Controls.Add(this.txtAlternetNo);
            this.panel1.Controls.Add(this.txtAdress);
            this.panel1.Controls.Add(this.txtEmployeeName);
            this.panel1.Controls.Add(this.lblSrNo);
            this.panel1.Controls.Add(this.lblLOcation);
            this.panel1.Controls.Add(this.lblContact2);
            this.panel1.Controls.Add(this.lblEmpName);
            this.panel1.Controls.Add(this.lblContact1);
            this.panel1.Controls.Add(this.lblAddress);
            this.panel1.Location = new System.Drawing.Point(10, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(565, 341);
            this.panel1.TabIndex = 0;
            // 
            // lblUniqueCode
            // 
            this.lblUniqueCode.AutoSize = true;
            this.lblUniqueCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUniqueCode.ForeColor = System.Drawing.Color.White;
            this.lblUniqueCode.Location = new System.Drawing.Point(114, 48);
            this.lblUniqueCode.Name = "lblUniqueCode";
            this.lblUniqueCode.Size = new System.Drawing.Size(84, 16);
            this.lblUniqueCode.TabIndex = 138;
            this.lblUniqueCode.Text = "UniqueCode";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(314, 309);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 16);
            this.label1.TabIndex = 137;
            this.label1.Text = "BALANCE TYPE";
            // 
            // cmbBakiBalType
            // 
            this.cmbBakiBalType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbBakiBalType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBakiBalType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBakiBalType.FormattingEnabled = true;
            this.cmbBakiBalType.Location = new System.Drawing.Point(443, 305);
            this.cmbBakiBalType.Name = "cmbBakiBalType";
            this.cmbBakiBalType.Size = new System.Drawing.Size(95, 23);
            this.cmbBakiBalType.TabIndex = 135;
            this.cmbBakiBalType.Leave += new System.EventHandler(this.cmbBakiBalType_Leave);
            // 
            // txtBakiBalance
            // 
            this.txtBakiBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBakiBalance.Location = new System.Drawing.Point(166, 306);
            this.txtBakiBalance.Name = "txtBakiBalance";
            this.txtBakiBalance.Size = new System.Drawing.Size(127, 22);
            this.txtBakiBalance.TabIndex = 134;
            this.txtBakiBalance.Text = "0";
            this.txtBakiBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(19, 310);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 16);
            this.label2.TabIndex = 136;
            this.label2.Text = "BAKI BALANCE";
            // 
            // lblBalanceType
            // 
            this.lblBalanceType.AutoSize = true;
            this.lblBalanceType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalanceType.ForeColor = System.Drawing.Color.White;
            this.lblBalanceType.Location = new System.Drawing.Point(313, 274);
            this.lblBalanceType.Name = "lblBalanceType";
            this.lblBalanceType.Size = new System.Drawing.Size(109, 16);
            this.lblBalanceType.TabIndex = 133;
            this.lblBalanceType.Text = "BALANCE TYPE";
            // 
            // cmbBalanceType
            // 
            this.cmbBalanceType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbBalanceType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBalanceType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBalanceType.FormattingEnabled = true;
            this.cmbBalanceType.Location = new System.Drawing.Point(442, 270);
            this.cmbBalanceType.Name = "cmbBalanceType";
            this.cmbBalanceType.Size = new System.Drawing.Size(95, 23);
            this.cmbBalanceType.TabIndex = 14;
            this.cmbBalanceType.Leave += new System.EventHandler(this.cmbBalanceType_Leave);
            // 
            // txtOpeningBalance
            // 
            this.txtOpeningBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOpeningBalance.Location = new System.Drawing.Point(166, 271);
            this.txtOpeningBalance.Name = "txtOpeningBalance";
            this.txtOpeningBalance.Size = new System.Drawing.Size(127, 22);
            this.txtOpeningBalance.TabIndex = 13;
            this.txtOpeningBalance.Text = "0";
            this.txtOpeningBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblOpeningBalance
            // 
            this.lblOpeningBalance.AutoSize = true;
            this.lblOpeningBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpeningBalance.ForeColor = System.Drawing.Color.White;
            this.lblOpeningBalance.Location = new System.Drawing.Point(19, 275);
            this.lblOpeningBalance.Name = "lblOpeningBalance";
            this.lblOpeningBalance.Size = new System.Drawing.Size(138, 16);
            this.lblOpeningBalance.TabIndex = 131;
            this.lblOpeningBalance.Text = "ADVANCE BALANCE";
            // 
            // txtRPassword
            // 
            this.txtRPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRPassword.Location = new System.Drawing.Point(382, 232);
            this.txtRPassword.Name = "txtRPassword";
            this.txtRPassword.PasswordChar = '*';
            this.txtRPassword.Size = new System.Drawing.Size(155, 22);
            this.txtRPassword.TabIndex = 12;
            this.txtRPassword.Leave += new System.EventHandler(this.txtRPassword_Leave);
            // 
            // lblRPassword
            // 
            this.lblRPassword.AutoSize = true;
            this.lblRPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRPassword.ForeColor = System.Drawing.Color.White;
            this.lblRPassword.Location = new System.Drawing.Point(366, 210);
            this.lblRPassword.Name = "lblRPassword";
            this.lblRPassword.Size = new System.Drawing.Size(110, 16);
            this.lblRPassword.TabIndex = 130;
            this.lblRPassword.Text = "RE-PASSWORD";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(194, 232);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(155, 22);
            this.txtPassword.TabIndex = 11;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.White;
            this.lblPassword.Location = new System.Drawing.Point(194, 210);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(87, 16);
            this.lblPassword.TabIndex = 129;
            this.lblPassword.Text = "PASSWORD";
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(19, 232);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(155, 22);
            this.txtUserName.TabIndex = 10;
            this.txtUserName.Leave += new System.EventHandler(this.txtUserName_Leave);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.White;
            this.lblUserName.Location = new System.Drawing.Point(19, 210);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(88, 16);
            this.lblUserName.TabIndex = 128;
            this.lblUserName.Text = "USER NAME";
            // 
            // cmbType
            // 
            this.cmbType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(410, 120);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(127, 23);
            this.cmbType.TabIndex = 5;
            this.cmbType.Leave += new System.EventHandler(this.cmbType_Leave);
            // 
            // cmbLocation
            // 
            this.cmbLocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbLocation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(253, 120);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(127, 23);
            this.cmbLocation.TabIndex = 4;
            this.cmbLocation.Leave += new System.EventHandler(this.cmbLocation_Leave);
            // 
            // txtIfscCode
            // 
            this.txtIfscCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIfscCode.Location = new System.Drawing.Point(410, 179);
            this.txtIfscCode.Name = "txtIfscCode";
            this.txtIfscCode.Size = new System.Drawing.Size(127, 22);
            this.txtIfscCode.TabIndex = 9;
            // 
            // lblIFSCcode
            // 
            this.lblIFSCcode.AutoSize = true;
            this.lblIFSCcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIFSCcode.ForeColor = System.Drawing.Color.White;
            this.lblIFSCcode.Location = new System.Drawing.Point(410, 158);
            this.lblIFSCcode.Name = "lblIFSCcode";
            this.lblIFSCcode.Size = new System.Drawing.Size(78, 16);
            this.lblIFSCcode.TabIndex = 120;
            this.lblIFSCcode.Text = "IFSC CODE";
            // 
            // txtAccNo
            // 
            this.txtAccNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccNo.Location = new System.Drawing.Point(278, 179);
            this.txtAccNo.Name = "txtAccNo";
            this.txtAccNo.Size = new System.Drawing.Size(119, 22);
            this.txtAccNo.TabIndex = 8;
            // 
            // lblACCno
            // 
            this.lblACCno.AutoSize = true;
            this.lblACCno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblACCno.ForeColor = System.Drawing.Color.White;
            this.lblACCno.Location = new System.Drawing.Point(278, 158);
            this.lblACCno.Name = "lblACCno";
            this.lblACCno.Size = new System.Drawing.Size(97, 16);
            this.lblACCno.TabIndex = 118;
            this.lblACCno.Text = "ACCOUNT NO";
            // 
            // txtBranch
            // 
            this.txtBranch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBranch.Location = new System.Drawing.Point(148, 179);
            this.txtBranch.Name = "txtBranch";
            this.txtBranch.Size = new System.Drawing.Size(119, 22);
            this.txtBranch.TabIndex = 7;
            // 
            // lblBranch
            // 
            this.lblBranch.AutoSize = true;
            this.lblBranch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBranch.ForeColor = System.Drawing.Color.White;
            this.lblBranch.Location = new System.Drawing.Point(148, 158);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(65, 16);
            this.lblBranch.TabIndex = 116;
            this.lblBranch.Text = "BRANCH";
            // 
            // txtBankName
            // 
            this.txtBankName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBankName.Location = new System.Drawing.Point(18, 179);
            this.txtBankName.Name = "txtBankName";
            this.txtBankName.Size = new System.Drawing.Size(119, 22);
            this.txtBankName.TabIndex = 6;
            // 
            // lblBankName
            // 
            this.lblBankName.AutoSize = true;
            this.lblBankName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBankName.ForeColor = System.Drawing.Color.White;
            this.lblBankName.Location = new System.Drawing.Point(18, 158);
            this.lblBankName.Name = "lblBankName";
            this.lblBankName.Size = new System.Drawing.Size(86, 16);
            this.lblBankName.TabIndex = 112;
            this.lblBankName.Text = "BANK NAME";
            // 
            // lblEmpType
            // 
            this.lblEmpType.AutoSize = true;
            this.lblEmpType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpType.ForeColor = System.Drawing.Color.White;
            this.lblEmpType.Location = new System.Drawing.Point(410, 100);
            this.lblEmpType.Name = "lblEmpType";
            this.lblEmpType.Size = new System.Drawing.Size(76, 16);
            this.lblEmpType.TabIndex = 110;
            this.lblEmpType.Text = "EMP TYPE";
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMobileNo.Location = new System.Drawing.Point(253, 68);
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(127, 22);
            this.txtMobileNo.TabIndex = 2;
            // 
            // txtAlternetNo
            // 
            this.txtAlternetNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAlternetNo.Location = new System.Drawing.Point(410, 68);
            this.txtAlternetNo.Name = "txtAlternetNo";
            this.txtAlternetNo.Size = new System.Drawing.Size(127, 22);
            this.txtAlternetNo.TabIndex = 3;
            // 
            // txtAdress
            // 
            this.txtAdress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdress.Location = new System.Drawing.Point(18, 69);
            this.txtAdress.Multiline = true;
            this.txtAdress.Name = "txtAdress";
            this.txtAdress.Size = new System.Drawing.Size(211, 74);
            this.txtAdress.TabIndex = 1;
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployeeName.Location = new System.Drawing.Point(161, 14);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(376, 22);
            this.txtEmployeeName.TabIndex = 0;
            // 
            // lblSrNo
            // 
            this.lblSrNo.AutoSize = true;
            this.lblSrNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSrNo.ForeColor = System.Drawing.Color.White;
            this.lblSrNo.Location = new System.Drawing.Point(102, 39);
            this.lblSrNo.Name = "lblSrNo";
            this.lblSrNo.Size = new System.Drawing.Size(39, 16);
            this.lblSrNo.TabIndex = 103;
            this.lblSrNo.Text = "SrNo";
            this.lblSrNo.Visible = false;
            // 
            // lblLOcation
            // 
            this.lblLOcation.AutoSize = true;
            this.lblLOcation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLOcation.ForeColor = System.Drawing.Color.White;
            this.lblLOcation.Location = new System.Drawing.Point(253, 100);
            this.lblLOcation.Name = "lblLOcation";
            this.lblLOcation.Size = new System.Drawing.Size(75, 16);
            this.lblLOcation.TabIndex = 102;
            this.lblLOcation.Text = "LOCATION";
            // 
            // lblContact2
            // 
            this.lblContact2.AutoSize = true;
            this.lblContact2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContact2.ForeColor = System.Drawing.Color.White;
            this.lblContact2.Location = new System.Drawing.Point(410, 48);
            this.lblContact2.Name = "lblContact2";
            this.lblContact2.Size = new System.Drawing.Size(112, 16);
            this.lblContact2.TabIndex = 101;
            this.lblContact2.Text = "ALTERNATE NO";
            // 
            // lblEmpName
            // 
            this.lblEmpName.AutoSize = true;
            this.lblEmpName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpName.ForeColor = System.Drawing.Color.White;
            this.lblEmpName.Location = new System.Drawing.Point(18, 17);
            this.lblEmpName.Name = "lblEmpName";
            this.lblEmpName.Size = new System.Drawing.Size(123, 16);
            this.lblEmpName.TabIndex = 97;
            this.lblEmpName.Text = "EMPLOYEE NAME";
            // 
            // lblContact1
            // 
            this.lblContact1.AutoSize = true;
            this.lblContact1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContact1.ForeColor = System.Drawing.Color.White;
            this.lblContact1.Location = new System.Drawing.Point(253, 48);
            this.lblContact1.Name = "lblContact1";
            this.lblContact1.Size = new System.Drawing.Size(80, 16);
            this.lblContact1.TabIndex = 99;
            this.lblContact1.Text = "MOBILE NO";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.ForeColor = System.Drawing.Color.White;
            this.lblAddress.Location = new System.Drawing.Point(18, 48);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(74, 16);
            this.lblAddress.TabIndex = 98;
            this.lblAddress.Text = "ADDRESS";
            // 
            // lineShape1
            // 
            this.lineShape1.BorderColor = System.Drawing.Color.White;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 7;
            this.lineShape1.X2 = 578;
            this.lineShape1.Y1 = 392;
            this.lineShape1.Y2 = 392;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(587, 433);
            this.shapeContainer1.TabIndex = 102;
            this.shapeContainer1.TabStop = false;
            // 
            // btnCancle
            // 
            this.btnCancle.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnCancle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancle.ForeColor = System.Drawing.Color.White;
            this.btnCancle.Location = new System.Drawing.Point(316, 399);
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
            this.btnSave.Location = new System.Drawing.Point(161, 399);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(115, 27);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // EmployeeMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.ClientSize = new System.Drawing.Size(587, 433);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.titleBar);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EmployeeMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EmployeeMaster";
            this.Load += new System.EventHandler(this.EmployeeMaster_Load);
            this.titleBar.ResumeLayout(false);
            this.titleBar.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TextBox txtOpeningBalance;
        public System.Windows.Forms.TextBox txtRPassword;
        public System.Windows.Forms.TextBox txtPassword;
        public System.Windows.Forms.TextBox txtUserName;
        public System.Windows.Forms.ComboBox cmbType;
        public System.Windows.Forms.ComboBox cmbLocation;
        public System.Windows.Forms.TextBox txtIfscCode;
        public System.Windows.Forms.TextBox txtAccNo;
        public System.Windows.Forms.TextBox txtBranch;
        public System.Windows.Forms.TextBox txtBankName;
        public System.Windows.Forms.TextBox txtMobileNo;
        public System.Windows.Forms.TextBox txtAlternetNo;
        public System.Windows.Forms.TextBox txtAdress;
        public System.Windows.Forms.TextBox txtEmployeeName;
        public System.Windows.Forms.Label lblSrNo;
        public System.Windows.Forms.ComboBox cmbBalanceType;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        public System.Windows.Forms.Panel titleBar;
        public System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label lblOpeningBalance;
        public System.Windows.Forms.Label lblRPassword;
        public System.Windows.Forms.Label lblPassword;
        public System.Windows.Forms.Label lblUserName;
        public System.Windows.Forms.Label lblIFSCcode;
        public System.Windows.Forms.Label lblACCno;
        public System.Windows.Forms.Label lblBranch;
        public System.Windows.Forms.Label lblBankName;
        public System.Windows.Forms.Label lblEmpType;
        public System.Windows.Forms.Label lblLOcation;
        public System.Windows.Forms.Label lblContact2;
        public System.Windows.Forms.Label lblEmpName;
        public System.Windows.Forms.Label lblContact1;
        public System.Windows.Forms.Label lblAddress;
        public System.Windows.Forms.Label lblBalanceType;
        public System.Windows.Forms.Button btnCancle;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cmbBakiBalType;
        public System.Windows.Forms.TextBox txtBakiBalance;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lblUniqueCode;
    }
}