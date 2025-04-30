using Accounting;
using Accounting.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Textile
{
    public partial class SalaryPayments : Form
    {
        public SalaryPayments()
        {
            InitializeComponent();
        }

        #region variables
        ClassFiles.CommonFunction common = new ClassFiles.CommonFunction();
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        BindingSource bs = new BindingSource();
        BindingSource bsOriginal = new BindingSource();
        string strReturnMSG, strReturnRefNo;
        int intReturnPKNo;
        int result, okflag;
        public int newOrEdit = 0;
        public int frmCode = 0;
        #endregion

        #region FillGrid()
        public DataTable FillGrid(int QueryNo)
        {
            try
            {
                hash = new Hashtable();
                DataTable dtReturn = new DataTable();

                hash.Add("@QueryNo", QueryNo);
                hash.Add("@intCompanyId", Convert.ToInt32(fd.CompId));
                hash.Add("@intYearId", Convert.ToInt32(fd.YearId));

                if (QueryNo == 101)
                {
                    hash.Add("@intEmpCode",Convert.ToInt32(lblEmpCode.Text));
                    hash.Add("@intShadeCode",Convert.ToInt32(lblLocationCode.Text));
                }
                if (QueryNo == 104)
                {
                    hash.Add("@intEmpCode", Convert.ToInt32(lblEmpCode.Text));
                }
                if (QueryNo == 105)
                {
                    hash.Add("@intSalaryMonth",Convert.ToInt32(lblMonthCode.Text));
                }
                if (QueryNo == 106)
                {
                    hash.Add("@intShadeCode",Convert.ToInt32(lblLocationCode.Text));
                }

                dtReturn = ClsDefination.FillData("[SalaryPayment_DML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 101)
                    {
                        lblAdvanceBalAmt.Text = objRow["ADVANCE"].ToString();
                        lblBakiBalanceAmt.Text = objRow["BAKI"].ToString();
                    }
                    else if (QueryNo == 102)
                    {
                        cmbFrmAcc.DataSource = dtReturn;
                        cmbFrmAcc.DisplayMember = "BankName";
                        cmbFrmAcc.ValueMember = "Acc_Code";
                        cmbFrmAcc.SelectedIndex = -1;
                        cmbFrmAcc.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 103)
                    {
                        //Common_Id,Common_Value
                        cmbPaidBy.DataSource = dtReturn;
                        cmbPaidBy.DisplayMember = "Common_Value";
                        cmbPaidBy.ValueMember = "Common_Id";
                        cmbPaidBy.SelectedIndex = -1;
                        cmbPaidBy.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 104)
                    {
                        lblEmpTypeCode.Text = objRow["Type"].ToString();
                        if (frmCode == 1)
                        {
                            lblEmpTypeName.Text = objRow["Common_Value"].ToString();
                        }
                    }
                    else if (QueryNo == 105)
                    {
                        dtpFromDate.Text= objRow["AES_FromDate"].ToString();
                        dtpToDate.Text = objRow["AES_ToDate"].ToString();
                    }
                    else if (QueryNo == 106)
                    {
                        lblLoomType.Text = objRow["L_TypeCode"].ToString();
                    }
                }
                else
                {
                    if (QueryNo == 101)
                    {
                        lblAdvanceBalAmt.Text = "0.00";
                        lblBakiBalanceAmt.Text = "0.00";
                    }
                    else if (QueryNo == 102)
                    {
                        cmbFrmAcc.DataSource = dtReturn;
                        cmbFrmAcc.SelectedIndex = -1;
                        cmbFrmAcc.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 103)
                    {
                        //Common_Id,Common_Value
                        cmbPaidBy.DataSource = dtReturn;
                        cmbPaidBy.SelectedIndex = -1;
                        cmbPaidBy.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 104)
                    {
                        lblEmpTypeCode.Text = "0";
                    }
                    else if (QueryNo == 106)
                    {
                        lblLoomType.Text = "0";
                    }
                }
                return null;
            }

            catch (Exception)
            {
                return null;
                throw;
            }
        }

        #endregion

        #region savedata()
        //--------------- Savedata() -------------------------------------------------

        public DataSet SaveData(int QueryNo, ref string strReturnMSG, ref string strReturnNo, ref Int32 intReturnNo)//string strReturn    DataSet
        {
            try
            {
                strReturnMSG = "0";
                strReturnNo = "0";
                intReturnNo = 0;

                okflag = 0;
                hash = new Hashtable();

                //,getdate(),1,,
                hash.Add("@QueryNo", QueryNo);
                hash.Add("@intCreatedBy", Convert.ToInt32(fd.UserId));
                hash.Add("@intCompanyId", Convert.ToInt32(fd.CompId));
                hash.Add("@intYearId", Convert.ToInt32(fd.YearId));

                if (QueryNo == 1 || QueryNo == 2 || QueryNo == 4)
                {

                    if (QueryNo == 2)
                    {
                        hash.Add("@intCode", Convert.ToInt32(lblSrNo.Text));
                    }

                    hash.Add("@dtpDate",dtpTransactionDate.Value.ToString("MM/dd/yyyy"));
                    hash.Add("@intEmpCode", Convert.ToInt32(lblEmpCode.Text));
                    hash.Add("@intShadeCode",Convert.ToInt32(lblLocationCode.Text));
                    hash.Add("@intEmpTpe", Convert.ToInt32(lblEmpTypeCode.Text));
                    if (QueryNo == 4)
                    {
                        hash.Add("@intSalaryMonth", Convert.ToInt32(0));
                    }
                    else
                    {
                        hash.Add("@intSalaryMonth", Convert.ToInt32(lblMonthCode.Text));
                    }
        //,,,,,,,
                    hash.Add("@decSalaryAmt",Convert.ToDecimal(lblSalaryAmt.Text));
                    hash.Add("@decPrvAdv",Convert.ToDecimal(lblAdvanceBalAmt.Text));
                    hash.Add("@decPrevBaki",Convert.ToDecimal(lblBakiBalanceAmt.Text));
                    hash.Add("@decSalPay",Convert.ToDecimal(txtSalaryPay.Text));
                    hash.Add("@decAdvPay",Convert.ToDecimal(txtAdvance.Text));
                    hash.Add("@decBakiPay",Convert.ToDecimal(txtBaki.Text));
                    hash.Add("@decRemAdv",Convert.ToDecimal(lblRemAdvBal.Text));
                    hash.Add("@decRemBaki",Convert.ToDecimal(lblRemBakiBal.Text));
                    hash.Add("@intPayfrmAcc",Convert.ToInt32(cmbFrmAcc.SelectedValue));
                    hash.Add("@intPaidBy",Convert.ToInt32(cmbPaidBy.SelectedValue));
                    hash.Add("@strChkNo",txtChkNo.Text);
                    hash.Add("@dtpChkDate",dtpChkDate.Value.ToString("MM/dd/yyyy"));
                    hash.Add("@dtpFromDate",dtpFromDate.Value.ToString("MM/dd/yyyy"));
                    hash.Add("@dtpToDate", dtpToDate.Value.ToString("MM/dd/yyyy"));
                    hash.Add("@intLoomType", Convert.ToInt32(lblLoomType.Text));
                     
                }

                okflag = 1;
                return ClsDefination.InsertExecute(hash, "[SalaryPayment_DML]", ref strReturnMSG, ref strReturnNo, ref intReturnNo);
            }
            catch (Exception Ex)
            {
                if (okflag == 0)
                {
                    MessageBox.Show("Enter proper data " + Ex);
                }
                return null;
                throw;
            }
        }

        //----------------------------------------------------------------------------

        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (newOrEdit == 0)
            {
                if (frmCode == 1)
                {
                    SaveData(4, ref strReturnMSG, ref strReturnRefNo, ref intReturnPKNo);
                }
                else
                {
                    SaveData(1, ref strReturnMSG, ref strReturnRefNo, ref intReturnPKNo);
                }
            }
            else
            {
                SaveData(2, ref strReturnMSG, ref strReturnRefNo, ref intReturnPKNo);
            }
            if (okflag == 1)
            {
                messageBox frm = new messageBox();
                if (newOrEdit == 0)
                {
                    frm.messageTxt = "Rocord Saved Successfully: " + strReturnMSG;
                }
                else
                {
                    frm.messageTxt = "Rocord Updated Successfully: " + strReturnMSG;
                }
                frm.type = "success";
                frm.ShowDialog();

                if (Convert.ToInt32(strReturnMSG) > 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to print this ?", "Print", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                       // ClassFiles.CommonFunction common = new ClassFiles.CommonFunction();
                        ClsDefination.Readpath();
                        common.server = ClsDefination.server;
                        common.dbname = ClsDefination.database;
                        common.username = ClsDefination.id;
                        common.password = ClsDefination.password;
                        common.reportPath = ClsDefination.CrystalPath;
                        common.BillNo = Convert.ToInt32(strReturnMSG);
                        common.companyId = fd.CompId;
                        common.yearID = fd.YearId;
                        common.sdtFromDate = dtpFromDate.Value.ToString("MM/dd/yyyy");
                        common.sdtToDate = dtpToDate.Value.ToString("MM/dd/yyyy");
                        common.PrinterName = cmbPrinter.Text;
                        if (frmCode == 1)
                        {
                            common.PrintDirect(1006);
                        }
                        else
                        {
                            //common.PrintDirect(6011);
                        }
                    }

                }
                this.Close();
            }
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = strReturnMSG;
                frm.type = "error";
                frm.ShowDialog();
            }
        }

        public void printerlist()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Name", typeof(string));

            //comboBox1.DataSource = dt; 
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                //       MessageBox.Show(printer);

                dt.Rows.Add(printer);
            }
            cmbPrinter.DataSource = dt;
            cmbPrinter.DisplayMember = "Name";
        }


        private void SalaryPayments_Load(object sender, EventArgs e)
        {
            if (frmCode != 1)
            {
                FillGrid(101);
                FillGrid(102); //
                FillGrid(103); //
                FillGrid(104); //
                FillGrid(105);
                FillGrid(106);
            }
            else
            {
                FillGrid(101);
                FillGrid(102); //
                FillGrid(103); //
                FillGrid(104); //
                FillGrid(106);
                lblTo.Visible = true;
                dtpFromDate.Visible = true;
                dtpToDate.Visible = true;
            }
            lblRemAdvBal.Text = "0.00";
            lblRemBakiBal.Text = "0.00";
            printerlist();
        }

        private void txtAdvance_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtAdvance.Text == "")
                {
                    txtAdvance.Text = "0";
                }
                lblRemAdvBal.Text = Math.Round(
                    Convert.ToDecimal(lblAdvanceBalAmt.Text) - Convert.ToDecimal(txtAdvance.Text),2
                    ).ToString();
            }
            catch (Exception ex)
            {
            }
        }

        private void txtBaki_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtBaki.Text == "")
                {
                    txtBaki.Text = "0";
                }
                lblRemBakiBal.Text = Math.Round(
                    Convert.ToDecimal(lblBakiBalanceAmt.Text) - Convert.ToDecimal(txtBaki.Text), 2
                    ).ToString();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
