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

namespace Textile.Dashboard
{
    public partial class Dashboard_PurchaseInvoice : Form
    {
        public Dashboard_PurchaseInvoice()
        {
            InitializeComponent();
        }

        #region variables
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        BindingSource bs = new BindingSource();
        BindingSource bsOriginal = new BindingSource();
        BindingSource bs1 = new BindingSource();
        BindingSource bsOriginal1 = new BindingSource();
        public string UserName, yearString, companyNameStr, groupNmae, PeriodName;
        public int userId, compId, yearId, GroupId, otherPg, cmbValue, cmbTT;
        string strReturnMSG, strReturnRefNo;
        int intReturnPKNo;
        int result, okflag;
        //  public int groupId;
        public int newOrEdit = 0;
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
                hash.Add("@intYearId",Convert.ToInt32(fd.YearId));

                dtReturn = ClsDefination.FillData("[Transaction_PurchaseInvoiceDml]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 101)
                    {
                        dgvDesign.DataSource = dtReturn;
                        bsOriginal.DataSource = dtReturn; //2 8
                        bsOriginal1.DataSource = dtReturn; //2 8

                        for (int i = 17; i < 25; i++)
                        {
                            dgvDesign.Columns[i].Visible = false;
                        }

     //                   TPI.UniqueCode as [UNIQUE CODE],
     //TPI.P_Code as [CODE], TPI.P_InvoiceNo as [INVOICE NO], TPI.P_Date as [INVOICE DATE],
     //MP.P_CompanyName+' - '+MP.P_OwnerName as [PARTY NAME],FM.F_CompanyName as [FIRM NAME], 
     //CV.Common_Value as [TAXABLE INVOICE],CV1.Common_Value as [INVOICE TYPE],
     //TPI.P_TaxableAmt as [TAXABLE AMT], TPI.P_GstAmt as [GST AMT],
     //TPI.P_Add as [ADD], TPI.P_Less as [LESS], TPI.P_ROff as [R/OFF], TPI.P_GrandTotal as [INVOICE AMT],
     //AM.BankName as [PAY FROM],CV2.Common_Value as [PAID BY],TPI.chkNo as [CHEQUE NO],  16
                        //TPI.chkDate as [CHEQUE DATE],
     //TPI.P_SuplierCode,TPI.P_Taxable,TPI.P_Payment,TPI.PayfromAcc,TPI.PaidBy,TPI.Shade,TPI.Firm 24
                    }

                }
                else
                {
                    if (QueryNo == 101)
                    {
                        dgvDesign.DataSource = dtReturn;
                        //bsOriginal.DataSource = dtReturn; //2 8

                        for (int i = 17; i < 25; i++)
                        {
                            dgvDesign.Columns[i].Visible = false;
                        }
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




        private void btnNew_Click(object sender, EventArgs e)
        {
            Textile.Transaction.PurchaseInvoice frm = new Textile.Transaction.PurchaseInvoice();
            frm.newOrEdit = 0;
            frm.ShowDialog();
            FillGrid(101);
            
        }

        private void Dashboard_PurchaseInvoice_Load(object sender, EventArgs e)
        {
            FillGrid(101);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvDesign.SelectedRows.Count > 0)
            {
                Textile.Transaction.PurchaseInvoice frm = new Transaction.PurchaseInvoice();
                frm.newOrEdit = 1;



                frm.lblUniqueCode.Text = dgvDesign.CurrentRow.Cells[0].Value.ToString();
     //           TPI.UniqueCode as [UNIQUE CODE],
                frm.lblSrNo.Text = dgvDesign.CurrentRow.Cells[1].Value.ToString();
                frm.txtInvoiceNo.Text = dgvDesign.CurrentRow.Cells[2].Value.ToString();
                frm.dtpInvoicedate.Text = dgvDesign.CurrentRow.Cells[3].Value.ToString();
     //TPI.P_Code as [CODE], TPI.P_InvoiceNo as [INVOICE NO], TPI.P_Date as [INVOICE DATE],
                frm.cmbFirmName.Text = dgvDesign.CurrentRow.Cells[5].Value.ToString();
     //MP.P_CompanyName+' - '+MP.P_OwnerName as [PARTY NAME],FM.F_CompanyName as [FIRM NAME],
                frm.cmbTaxable.Text = dgvDesign.CurrentRow.Cells[6].Value.ToString();
                frm.cmbPaymentType.Text = dgvDesign.CurrentRow.Cells[7].Value.ToString();
     //CV.Common_Value as [TAXABLE INVOICE],CV1.Common_Value as [INVOICE TYPE],
                frm.lblTaxableValue.Text = dgvDesign.CurrentRow.Cells[8].Value.ToString();
                frm.lblGSTAmt.Text = dgvDesign.CurrentRow.Cells[9].Value.ToString();
     //TPI.P_TaxableAmt as [TAXABLE AMT], TPI.P_GstAmt as [GST AMT],
                frm.txtAdd.Text = dgvDesign.CurrentRow.Cells[10].Value.ToString();
                frm.txtLess.Text = dgvDesign.CurrentRow.Cells[11].Value.ToString();
                frm.txtROFF.Text = dgvDesign.CurrentRow.Cells[12].Value.ToString();
                frm.lblGrandTotalAmt.Text = dgvDesign.CurrentRow.Cells[13].Value.ToString();
     //TPI.P_Add as [ADD], TPI.P_Less as [LESS], TPI.P_ROff as [R/OFF], TPI.P_GrandTotal as [INVOICE AMT],
                frm.cmbAcc.Text = dgvDesign.CurrentRow.Cells[14].Value.ToString();
                frm.cmbPaidBy.Text = dgvDesign.CurrentRow.Cells[15].Value.ToString();
                frm.txtChkNo.Text = dgvDesign.CurrentRow.Cells[16].Value.ToString();
                frm.dtpChkDate.Text = dgvDesign.CurrentRow.Cells[17].Value.ToString();
     //AM.BankName as [PAY FROM],CV2.Common_Value as [PAID BY],TPI.chkNo as [CHEQUE NO], TPI.chkDate as [CHEQUE DATE],

                frm.cmbSuppliverV = Convert.ToInt32(dgvDesign.CurrentRow.Cells[18].Value.ToString());
                frm.cmbTaxableV = Convert.ToInt32(dgvDesign.CurrentRow.Cells[19].Value.ToString());
                frm.cmbInvoiceV = Convert.ToInt32(dgvDesign.CurrentRow.Cells[20].Value.ToString());
                frm.cmbAccV = Convert.ToInt32(dgvDesign.CurrentRow.Cells[21].Value.ToString());
                frm.cmbPaidByV = Convert.ToInt32(dgvDesign.CurrentRow.Cells[22].Value.ToString());
                frm.cmbShadeV = Convert.ToInt32(dgvDesign.CurrentRow.Cells[23].Value.ToString());
                frm.cmbFirmV = Convert.ToInt32(dgvDesign.CurrentRow.Cells[24].Value.ToString());
                frm.lblStateCode.Text = dgvDesign.CurrentRow.Cells[25].Value.ToString();
     //TPI.P_SuplierCode,TPI.P_Taxable,TPI.P_Payment,TPI.PayfromAcc,TPI.PaidBy,TPI.Shade,TPI.Firm,state

                frm.ShowDialog();
                FillGrid(101);
            }
            else
            {
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvDesign.DataSource = bsOriginal;
                bs.DataSource = dgvDesign.DataSource;
                bs.Filter = string.Format("[PARTY NAME] like '%{0}%'", txtSearch.Text);
                dgvDesign.DataSource = bs;
                dgvDesign.Enabled = true;
                // btnClose.Enabled = true;
            }
            catch
            { }
        }

        private void txtSearchInvocie_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvDesign.DataSource = bsOriginal1;
                bs1.DataSource = dgvDesign.DataSource;
                bs1.Filter = string.Format("[INVOICE NO] like '%{0}%'", txtSearchInvocie.Text);
                dgvDesign.DataSource = bs1;
                dgvDesign.Enabled = true;
                // btnClose.Enabled = true;
            }
            catch
            { }
        }
    }
}
