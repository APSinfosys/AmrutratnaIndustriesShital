namespace Textile.Finance
{
    partial class SalesReceipt
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
            this.lblShade = new System.Windows.Forms.Label();
            this.lblPartyCode = new System.Windows.Forms.Label();
            this.lblPartyName = new System.Windows.Forms.Label();
            this.dtpChkDate = new System.Windows.Forms.DateTimePicker();
            this.lblChkDate = new System.Windows.Forms.Label();
            this.txtChkNo = new System.Windows.Forms.TextBox();
            this.lblChkNo = new System.Windows.Forms.Label();
            this.lblPaidBY = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTaxableAmt = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTdsAmt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTdsPer = new System.Windows.Forms.TextBox();
            this.lblFirmCode = new System.Windows.Forms.Label();
            this.lblFirmName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtReceipt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPaidBy = new System.Windows.Forms.ComboBox();
            this.lblRemAmt = new System.Windows.Forms.Label();
            this.lblAdvance = new System.Windows.Forms.Label();
            this.lblSalaryAmt = new System.Windows.Forms.Label();
            this.dtpTransactionDate = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblPayFrmAcc = new System.Windows.Forms.Label();
            this.cmbFrmAcc = new System.Windows.Forms.ComboBox();
            this.lblSalaryPay = new System.Windows.Forms.Label();
            this.txtAmountPay = new System.Windows.Forms.TextBox();
            this.lblSalary = new System.Windows.Forms.Label();
            this.lblEmpName = new System.Windows.Forms.Label();
            this.titleBar = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.BtnCerrar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.label5 = new System.Windows.Forms.Label();
            this.lblInvoiceNo = new System.Windows.Forms.Label();
            this.lblInviceUniqueCode = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
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
            this.btnCancle.Location = new System.Drawing.Point(314, 405);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(115, 30);
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
            this.btnSave.Location = new System.Drawing.Point(159, 405);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(115, 30);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblShade
            // 
            this.lblShade.AutoSize = true;
            this.lblShade.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShade.ForeColor = System.Drawing.Color.White;
            this.lblShade.Location = new System.Drawing.Point(502, 18);
            this.lblShade.Name = "lblShade";
            this.lblShade.Size = new System.Drawing.Size(55, 18);
            this.lblShade.TabIndex = 162;
            this.lblShade.Text = "Shade";
            this.lblShade.Visible = false;
            // 
            // lblPartyCode
            // 
            this.lblPartyCode.AutoSize = true;
            this.lblPartyCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartyCode.ForeColor = System.Drawing.Color.White;
            this.lblPartyCode.Location = new System.Drawing.Point(331, 16);
            this.lblPartyCode.Name = "lblPartyCode";
            this.lblPartyCode.Size = new System.Drawing.Size(0, 18);
            this.lblPartyCode.TabIndex = 161;
            this.lblPartyCode.Visible = false;
            // 
            // lblPartyName
            // 
            this.lblPartyName.AutoSize = true;
            this.lblPartyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartyName.ForeColor = System.Drawing.Color.White;
            this.lblPartyName.Location = new System.Drawing.Point(153, 106);
            this.lblPartyName.Name = "lblPartyName";
            this.lblPartyName.Size = new System.Drawing.Size(31, 18);
            this.lblPartyName.TabIndex = 158;
            this.lblPartyName.Text = "PN";
            // 
            // dtpChkDate
            // 
            this.dtpChkDate.CustomFormat = "dd/MM/yyyy";
            this.dtpChkDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpChkDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpChkDate.Location = new System.Drawing.Point(334, 256);
            this.dtpChkDate.Name = "dtpChkDate";
            this.dtpChkDate.Size = new System.Drawing.Size(128, 22);
            this.dtpChkDate.TabIndex = 7;
            // 
            // lblChkDate
            // 
            this.lblChkDate.AutoSize = true;
            this.lblChkDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChkDate.ForeColor = System.Drawing.Color.White;
            this.lblChkDate.Location = new System.Drawing.Point(331, 232);
            this.lblChkDate.Name = "lblChkDate";
            this.lblChkDate.Size = new System.Drawing.Size(105, 16);
            this.lblChkDate.TabIndex = 157;
            this.lblChkDate.Text = "CHEQUE DATE";
            // 
            // txtChkNo
            // 
            this.txtChkNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChkNo.Location = new System.Drawing.Point(177, 256);
            this.txtChkNo.Name = "txtChkNo";
            this.txtChkNo.Size = new System.Drawing.Size(119, 22);
            this.txtChkNo.TabIndex = 6;
            // 
            // lblChkNo
            // 
            this.lblChkNo.AutoSize = true;
            this.lblChkNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChkNo.ForeColor = System.Drawing.Color.White;
            this.lblChkNo.Location = new System.Drawing.Point(174, 232);
            this.lblChkNo.Name = "lblChkNo";
            this.lblChkNo.Size = new System.Drawing.Size(88, 16);
            this.lblChkNo.TabIndex = 155;
            this.lblChkNo.Text = "CHEQUE NO";
            // 
            // lblPaidBY
            // 
            this.lblPaidBY.AutoSize = true;
            this.lblPaidBY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaidBY.ForeColor = System.Drawing.Color.White;
            this.lblPaidBY.Location = new System.Drawing.Point(18, 232);
            this.lblPaidBY.Name = "lblPaidBY";
            this.lblPaidBY.Size = new System.Drawing.Size(60, 16);
            this.lblPaidBY.TabIndex = 154;
            this.lblPaidBY.Text = "PAID BY";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblInviceUniqueCode);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.lblInvoiceNo);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lblTaxableAmt);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtTdsAmt);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtTdsPer);
            this.panel1.Controls.Add(this.lblFirmCode);
            this.panel1.Controls.Add(this.lblFirmName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtReceipt);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblShade);
            this.panel1.Controls.Add(this.lblPartyCode);
            this.panel1.Controls.Add(this.lblPartyName);
            this.panel1.Controls.Add(this.dtpChkDate);
            this.panel1.Controls.Add(this.lblChkDate);
            this.panel1.Controls.Add(this.txtChkNo);
            this.panel1.Controls.Add(this.lblChkNo);
            this.panel1.Controls.Add(this.lblPaidBY);
            this.panel1.Controls.Add(this.cmbPaidBy);
            this.panel1.Controls.Add(this.lblRemAmt);
            this.panel1.Controls.Add(this.lblAdvance);
            this.panel1.Controls.Add(this.lblSalaryAmt);
            this.panel1.Controls.Add(this.dtpTransactionDate);
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Controls.Add(this.lblPayFrmAcc);
            this.panel1.Controls.Add(this.cmbFrmAcc);
            this.panel1.Controls.Add(this.lblSalaryPay);
            this.panel1.Controls.Add(this.txtAmountPay);
            this.panel1.Controls.Add(this.lblSalary);
            this.panel1.Controls.Add(this.lblEmpName);
            this.panel1.Location = new System.Drawing.Point(9, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(572, 326);
            this.panel1.TabIndex = 0;
            // 
            // lblTaxableAmt
            // 
            this.lblTaxableAmt.AutoSize = true;
            this.lblTaxableAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaxableAmt.ForeColor = System.Drawing.Color.White;
            this.lblTaxableAmt.Location = new System.Drawing.Point(485, 200);
            this.lblTaxableAmt.Name = "lblTaxableAmt";
            this.lblTaxableAmt.Size = new System.Drawing.Size(17, 18);
            this.lblTaxableAmt.TabIndex = 172;
            this.lblTaxableAmt.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(216, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 16);
            this.label4.TabIndex = 171;
            this.label4.Text = "TDS AMOUNT";
            // 
            // txtTdsAmt
            // 
            this.txtTdsAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTdsAmt.Location = new System.Drawing.Point(356, 164);
            this.txtTdsAmt.Name = "txtTdsAmt";
            this.txtTdsAmt.ReadOnly = true;
            this.txtTdsAmt.Size = new System.Drawing.Size(119, 22);
            this.txtTdsAmt.TabIndex = 4;
            this.txtTdsAmt.Text = "0";
            this.txtTdsAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(18, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 169;
            this.label2.Text = "TDS (%)";
            // 
            // txtTdsPer
            // 
            this.txtTdsPer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTdsPer.Location = new System.Drawing.Point(111, 164);
            this.txtTdsPer.Name = "txtTdsPer";
            this.txtTdsPer.Size = new System.Drawing.Size(75, 22);
            this.txtTdsPer.TabIndex = 3;
            this.txtTdsPer.Text = "0";
            this.txtTdsPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTdsPer.Leave += new System.EventHandler(this.txtTdsPer_Leave);
            // 
            // lblFirmCode
            // 
            this.lblFirmCode.AutoSize = true;
            this.lblFirmCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirmCode.ForeColor = System.Drawing.Color.White;
            this.lblFirmCode.Location = new System.Drawing.Point(502, 43);
            this.lblFirmCode.Name = "lblFirmCode";
            this.lblFirmCode.Size = new System.Drawing.Size(82, 18);
            this.lblFirmCode.TabIndex = 167;
            this.lblFirmCode.Text = "FirmCode";
            this.lblFirmCode.Visible = false;
            // 
            // lblFirmName
            // 
            this.lblFirmName.AutoSize = true;
            this.lblFirmName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirmName.ForeColor = System.Drawing.Color.White;
            this.lblFirmName.Location = new System.Drawing.Point(153, 75);
            this.lblFirmName.Name = "lblFirmName";
            this.lblFirmName.Size = new System.Drawing.Size(30, 18);
            this.lblFirmName.TabIndex = 166;
            this.lblFirmName.Text = "FN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(18, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 16);
            this.label3.TabIndex = 165;
            this.label3.Text = "FIRM NAME";
            // 
            // txtReceipt
            // 
            this.txtReceipt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceipt.Location = new System.Drawing.Point(125, 14);
            this.txtReceipt.Name = "txtReceipt";
            this.txtReceipt.ReadOnly = true;
            this.txtReceipt.Size = new System.Drawing.Size(119, 22);
            this.txtReceipt.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(18, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 16);
            this.label1.TabIndex = 164;
            this.label1.Text = "RECEIPT NO";
            // 
            // cmbPaidBy
            // 
            this.cmbPaidBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbPaidBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPaidBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPaidBy.FormattingEnabled = true;
            this.cmbPaidBy.Location = new System.Drawing.Point(18, 256);
            this.cmbPaidBy.Name = "cmbPaidBy";
            this.cmbPaidBy.Size = new System.Drawing.Size(118, 23);
            this.cmbPaidBy.TabIndex = 5;
            this.cmbPaidBy.Leave += new System.EventHandler(this.cmbPaidBy_Leave);
            // 
            // lblRemAmt
            // 
            this.lblRemAmt.AutoSize = true;
            this.lblRemAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemAmt.ForeColor = System.Drawing.Color.White;
            this.lblRemAmt.Location = new System.Drawing.Point(176, 201);
            this.lblRemAmt.Name = "lblRemAmt";
            this.lblRemAmt.Size = new System.Drawing.Size(17, 18);
            this.lblRemAmt.TabIndex = 151;
            this.lblRemAmt.Text = "0";
            // 
            // lblAdvance
            // 
            this.lblAdvance.AutoSize = true;
            this.lblAdvance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdvance.ForeColor = System.Drawing.Color.White;
            this.lblAdvance.Location = new System.Drawing.Point(18, 202);
            this.lblAdvance.Name = "lblAdvance";
            this.lblAdvance.Size = new System.Drawing.Size(145, 16);
            this.lblAdvance.TabIndex = 144;
            this.lblAdvance.Text = "REMAINING AMOUNT";
            // 
            // lblSalaryAmt
            // 
            this.lblSalaryAmt.AutoSize = true;
            this.lblSalaryAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalaryAmt.ForeColor = System.Drawing.Color.White;
            this.lblSalaryAmt.Location = new System.Drawing.Point(107, 135);
            this.lblSalaryAmt.Name = "lblSalaryAmt";
            this.lblSalaryAmt.Size = new System.Drawing.Size(85, 18);
            this.lblSalaryAmt.TabIndex = 140;
            this.lblSalaryAmt.Text = "100000.00";
            // 
            // dtpTransactionDate
            // 
            this.dtpTransactionDate.CustomFormat = "dd/MM/yyyy";
            this.dtpTransactionDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTransactionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTransactionDate.Location = new System.Drawing.Point(347, 14);
            this.dtpTransactionDate.Name = "dtpTransactionDate";
            this.dtpTransactionDate.Size = new System.Drawing.Size(128, 22);
            this.dtpTransactionDate.TabIndex = 1;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(286, 17);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(45, 16);
            this.lblDate.TabIndex = 138;
            this.lblDate.Text = "DATE";
            // 
            // lblPayFrmAcc
            // 
            this.lblPayFrmAcc.AutoSize = true;
            this.lblPayFrmAcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayFrmAcc.ForeColor = System.Drawing.Color.White;
            this.lblPayFrmAcc.Location = new System.Drawing.Point(18, 300);
            this.lblPayFrmAcc.Name = "lblPayFrmAcc";
            this.lblPayFrmAcc.Size = new System.Drawing.Size(152, 16);
            this.lblPayFrmAcc.TabIndex = 133;
            this.lblPayFrmAcc.Text = "AMOUNT IN ACCOUNT";
            // 
            // cmbFrmAcc
            // 
            this.cmbFrmAcc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbFrmAcc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFrmAcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFrmAcc.FormattingEnabled = true;
            this.cmbFrmAcc.Location = new System.Drawing.Point(178, 297);
            this.cmbFrmAcc.Name = "cmbFrmAcc";
            this.cmbFrmAcc.Size = new System.Drawing.Size(166, 23);
            this.cmbFrmAcc.TabIndex = 8;
            // 
            // lblSalaryPay
            // 
            this.lblSalaryPay.AutoSize = true;
            this.lblSalaryPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalaryPay.ForeColor = System.Drawing.Color.White;
            this.lblSalaryPay.Location = new System.Drawing.Point(216, 136);
            this.lblSalaryPay.Name = "lblSalaryPay";
            this.lblSalaryPay.Size = new System.Drawing.Size(120, 16);
            this.lblSalaryPay.TabIndex = 118;
            this.lblSalaryPay.Text = "PAYING AMOUNT";
            // 
            // txtAmountPay
            // 
            this.txtAmountPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmountPay.Location = new System.Drawing.Point(356, 133);
            this.txtAmountPay.Name = "txtAmountPay";
            this.txtAmountPay.Size = new System.Drawing.Size(119, 22);
            this.txtAmountPay.TabIndex = 2;
            this.txtAmountPay.Text = "0";
            this.txtAmountPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmountPay.Leave += new System.EventHandler(this.txtAmountPay_Leave);
            // 
            // lblSalary
            // 
            this.lblSalary.AutoSize = true;
            this.lblSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalary.ForeColor = System.Drawing.Color.White;
            this.lblSalary.Location = new System.Drawing.Point(18, 136);
            this.lblSalary.Name = "lblSalary";
            this.lblSalary.Size = new System.Drawing.Size(70, 16);
            this.lblSalary.TabIndex = 112;
            this.lblSalary.Text = "AMOUNT ";
            // 
            // lblEmpName
            // 
            this.lblEmpName.AutoSize = true;
            this.lblEmpName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpName.ForeColor = System.Drawing.Color.White;
            this.lblEmpName.Location = new System.Drawing.Point(18, 107);
            this.lblEmpName.Name = "lblEmpName";
            this.lblEmpName.Size = new System.Drawing.Size(96, 16);
            this.lblEmpName.TabIndex = 97;
            this.lblEmpName.Text = "PARTY NAME";
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
            this.titleBar.Size = new System.Drawing.Size(594, 42);
            this.titleBar.TabIndex = 101;
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
            this.btnClose.Location = new System.Drawing.Point(560, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(25, 23);
            this.btnClose.TabIndex = 16;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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
            this.label6.Location = new System.Drawing.Point(182, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(208, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "S A L E S   R E C E I P T";
            // 
            // lineShape1
            // 
            this.lineShape1.BorderColor = System.Drawing.Color.White;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 4;
            this.lineShape1.X2 = 584;
            this.lineShape1.Y1 = 389;
            this.lineShape1.Y2 = 389;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(594, 447);
            this.shapeContainer1.TabIndex = 102;
            this.shapeContainer1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(18, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 16);
            this.label5.TabIndex = 173;
            this.label5.Text = "INVOICE NO";
            // 
            // lblInvoiceNo
            // 
            this.lblInvoiceNo.AutoSize = true;
            this.lblInvoiceNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceNo.ForeColor = System.Drawing.Color.White;
            this.lblInvoiceNo.Location = new System.Drawing.Point(122, 47);
            this.lblInvoiceNo.Name = "lblInvoiceNo";
            this.lblInvoiceNo.Size = new System.Drawing.Size(24, 18);
            this.lblInvoiceNo.TabIndex = 174;
            this.lblInvoiceNo.Text = "IN";
            // 
            // lblInviceUniqueCode
            // 
            this.lblInviceUniqueCode.AutoSize = true;
            this.lblInviceUniqueCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInviceUniqueCode.ForeColor = System.Drawing.Color.White;
            this.lblInviceUniqueCode.Location = new System.Drawing.Point(320, 47);
            this.lblInviceUniqueCode.Name = "lblInviceUniqueCode";
            this.lblInviceUniqueCode.Size = new System.Drawing.Size(24, 18);
            this.lblInviceUniqueCode.TabIndex = 176;
            this.lblInviceUniqueCode.Text = "IC";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(216, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 16);
            this.label8.TabIndex = 175;
            this.label8.Text = "INVOICE CODE";
            // 
            // SalesReceipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.ClientSize = new System.Drawing.Size(594, 447);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.titleBar);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SalesReceipt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SalesReceipt";
            this.Load += new System.EventHandler(this.SalesReceipt_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.titleBar.ResumeLayout(false);
            this.titleBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Label lblShade;
        public System.Windows.Forms.Label lblPartyCode;
        public System.Windows.Forms.Label lblPartyName;
        public System.Windows.Forms.DateTimePicker dtpChkDate;
        public System.Windows.Forms.Label lblChkDate;
        public System.Windows.Forms.TextBox txtChkNo;
        public System.Windows.Forms.Label lblChkNo;
        public System.Windows.Forms.Label lblPaidBY;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.ComboBox cmbPaidBy;
        public System.Windows.Forms.Label lblRemAmt;
        public System.Windows.Forms.Label lblAdvance;
        public System.Windows.Forms.Label lblSalaryAmt;
        private System.Windows.Forms.DateTimePicker dtpTransactionDate;
        public System.Windows.Forms.Label lblDate;
        public System.Windows.Forms.Label lblPayFrmAcc;
        public System.Windows.Forms.ComboBox cmbFrmAcc;
        public System.Windows.Forms.Label lblSalaryPay;
        public System.Windows.Forms.TextBox txtAmountPay;
        public System.Windows.Forms.Label lblSalary;
        public System.Windows.Forms.Label lblEmpName;
        private System.Windows.Forms.Panel titleBar;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button BtnCerrar;
        private System.Windows.Forms.Label label6;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        public System.Windows.Forms.TextBox txtReceipt;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblFirmCode;
        public System.Windows.Forms.Label lblFirmName;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtTdsAmt;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtTdsPer;
        public System.Windows.Forms.Label lblTaxableAmt;
        public System.Windows.Forms.Label lblInviceUniqueCode;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label lblInvoiceNo;
        public System.Windows.Forms.Label label5;
    }
}