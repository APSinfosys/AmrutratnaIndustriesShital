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

namespace Textile.Dashboard
{
    public partial class Dashboard_PartyPayments : Form
    {
        public Dashboard_PartyPayments()
        {
            InitializeComponent();
        }



        #region Variable
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        BindingSource bs = new BindingSource();
        BindingSource bsOriginal = new BindingSource();
        BindingSource bs1 = new BindingSource();
        BindingSource bsOriginal1 = new BindingSource();
        BindingSource bs2 = new BindingSource();
        BindingSource bsOriginal2 = new BindingSource();
        BindingSource bs3 = new BindingSource();
        BindingSource bsOriginal3 = new BindingSource();
        public string UserName, yearString, companyNameStr;
        public int userId, compId, yearId, GroupId = 0, otherPg;
        string strReturnMSG, strReturnRefNo, sp;
        int intReturnPKNo;
        int result, deletefrm;
        public int newOrEdit = 0;

        #endregion

        public DataTable FillGrid(int QueryNo)
        {
            try
            {
                hash = new Hashtable();

                hash.Add("@QueryNo", QueryNo);
                hash.Add("@intcompanyId", fd.CompId);
                hash.Add("@inryearId", fd.YearId);
                if ( QueryNo == 102)
                {
                  //  hash.Add("@intShade", cmbShade.SelectedValue);
                }
                if (QueryNo == 101)
                {
                    if (Convert.ToInt32(cmbFirmName.SelectedValue) > 0)
                    {
                        hash.Add("@intFirm", cmbFirmName.SelectedValue);
                    }
                    else
                    {
                        hash.Add("@intFirm", 0);
                    }

                    if (Convert.ToInt32(cmbParty.SelectedValue) > 0)
                    {
                        hash.Add("@intPartyCode", cmbParty.SelectedValue);
                    }
                    else
                    {
                        hash.Add("@intPartyCode", 0);
                    }

                    if (dtpFrom.Value.ToString("MM/dd/yyyy") == dtpTo.Value.ToString("MM/dd/yyyy") && chkDate.Checked != true)
                    {
                        hash.Add("@dtpFrom", fd.StartDate.ToString("MM/dd/yyyy"));
                        hash.Add("@dtpTo", fd.EndDate.ToString("MM/dd/yyyy"));
                    }
                    else
                    {
                        hash.Add("@dtpFrom", dtpFrom.Value.ToString("MM/dd/yyyy"));
                        hash.Add("@dtpTo", dtpTo.Value.ToString("MM/dd/yyyy"));
                    }
                }

                DataTable dtReturn = ClsDefination.FillData("[Transaction_PartyPayments_DML]", hash);

                if (dtReturn != null && dtReturn.Rows.Count > 0)
                {
                    DataRow dr = dtReturn.Rows[0];
                    if (QueryNo == 101 ) //|| QueryNo == 102
                    {
                        dgvParty.DataSource = dtReturn; 
                        bsOriginal.DataSource = dtReturn;
                        bsOriginal1.DataSource = dtReturn;
                        bsOriginal2.DataSource = dtReturn;
                        bsOriginal3.DataSource = dtReturn;
                        gridValidation();
                    }
                    else if (QueryNo == 201)
                    {
                        cmbShade.DataSource = dtReturn;
                        cmbShade.DisplayMember = "Shade";
                        cmbShade.ValueMember = "ShadeCode";
                        cmbShade.SelectedIndex = -1;
                        cmbShade.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 302)
                    {
                        cmbFirmName.DataSource = dtReturn;
                        cmbFirmName.DisplayMember = "F_CompanyName";
                        cmbFirmName.ValueMember = "F_Code";
                        cmbFirmName.SelectedIndex = -1;
                        cmbFirmName.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 303)
                    {
                        cmbParty.DataSource = dtReturn;
                        cmbParty.DisplayMember = "P_CompanyName";
                        cmbParty.ValueMember = "P_Code";
                        cmbParty.SelectedIndex = -1;
                        cmbParty.Text = "<--SELECT-->";
                    }
                }
                else
                {
                    if (QueryNo == 101)//|| QueryNo == 102
                    {
                        dgvParty.DataSource = dtReturn;
                        gridValidation();
                    }
                    else if (QueryNo == 201)
                    {
                        cmbShade.DataSource = dtReturn;
                        cmbShade.SelectedIndex = -1;
                        cmbShade.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 302)
                    {
                        cmbFirmName1.DataSource = dtReturn;
                        cmbFirmName1.SelectedIndex = -1;
                        cmbFirmName1.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 303)
                    {
                        cmbParty.DataSource = dtReturn;
                        cmbParty.Text = "<--NO RECORD-->";
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

        public void gridValidation()
        {
      //MY.yr_Short [YEAR],FM.F_CompanyName as [FIRM NAME],MP.P_CompanyName+' - '+MP.P_OwnerName as [PARTY NAME],
      //CA.T_InvoiceNo as [INVOICE NO],TPI.P_GrandTotal as [INVOICE AMOUNT],isnull(SUM(CA.T_OutAmt),0) as [PAID AMOUNT],
      //isnull(SUM(CA.TdsAmunt),0) as [TDS AMOUNT],ISNULL( isnull(SUM(CA.T_InAmt),0)- isnull(SUM(CA.T_OutAmt),0)- isnull(SUM(CA.TdsAmunt),0),0) as [BALANCE],
      //CA.T_Party as [PARTY CODE], CA.firmId,CA.UniqueCode,CA.shade

            dgvParty.Columns[8].Visible = false;// Firm Cde
            dgvParty.Columns[9].Visible = false;// Party Code
            dgvParty.Columns[10].Visible = false; // Purchase Unique cde
            dgvParty.Columns[11].Visible = false; // shade
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (dgvParty.SelectedRows.Count > 0)
            {
                PartyPayment frm = new PartyPayment();
                frm.lblPartyCode.Text = dgvParty.CurrentRow.Cells[8].Value.ToString();
                frm.lblPartyName.Text = dgvParty.CurrentRow.Cells[2].Value.ToString();
                frm.lblSalaryAmt.Text = dgvParty.CurrentRow.Cells[7].Value.ToString();
               // frm.lblShade.Text = cmbShade.SelectedValue.ToString();
                frm.lblFirmName.Text = dgvParty.CurrentRow.Cells[1].Value.ToString();
                frm.lblFirmCode.Text = dgvParty.CurrentRow.Cells[9].Value.ToString();
                frm.lblInvoiceNo.Text = dgvParty.CurrentRow.Cells[3].Value.ToString();
                frm.lblPInvoiceUniqeCode.Text = dgvParty.CurrentRow.Cells[10].Value.ToString();
                frm.lblShade.Text = dgvParty.CurrentRow.Cells[11].Value.ToString();
                frm.ShowDialog();
                FillGrid(101);
            }
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please Select At Least One Record";
                frm.type = "error";
                frm.ShowDialog();
            }
        }

        private void Dashboard_PartyPayments_Load(object sender, EventArgs e)
        {
            //FillGrid(201);
            FillGrid(302);
            FillGrid(303);

           // FillGrid(101);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            //if (Convert.ToInt32(cmbShade.SelectedValue) > 0)
            //{
                //if (Convert.ToInt32(cmbFirmName.SelectedValue) > 0)
                //{
                    FillGrid(101);
                //}
                //else
                //{
                //    messageBox frm = new messageBox();
                //    frm.messageTxt = "Please Select Firm";
                //    frm.type = "error";
                //    frm.ShowDialog();
                //}
            //}
            //else
            //{
            //    messageBox frm = new messageBox();
            //    frm.messageTxt = "Please Select Shade";
            //    frm.type = "error";
            //    frm.ShowDialog();
            //}
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Now;
            dtpTo.Value = DateTime.Now;
            FillGrid(201);
            FillGrid(302);
            FillGrid(303);
            // FillGrid(101);
            dgvParty.DataSource = null;
        }

        private void txtSearchFirm_TextChanged(object sender, EventArgs e)
       {
            try
            {
                dgvParty.DataSource = bsOriginal;
                bs.DataSource = dgvParty.DataSource;
                bs.Filter = string.Format("[FIRM NAME] like '%{0}%'", txtSearchFirm.Text);
                dgvParty.DataSource = bs;
                dgvParty.Enabled = true;
                gridValidation();
                // btnClose.Enabled = true;
            }
            catch
            { }
        }

        private void txtSearchParty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvParty.DataSource = bsOriginal1;
                bs1.DataSource = dgvParty.DataSource;
                bs1.Filter = string.Format("[PARTY NAME] like '%{0}%'", txtSearchParty.Text);
                dgvParty.DataSource = bs1;
                dgvParty.Enabled = true;
                gridValidation();
                // btnClose.Enabled = true;
            }
            catch
            { }
        }

        private void txtSearchYr_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvParty.DataSource = bsOriginal2;
                bs2.DataSource = dgvParty.DataSource;
                bs2.Filter = string.Format("[YEAR] like '%{0}%'", txtSearchYr.Text);
                dgvParty.DataSource = bs2;
                dgvParty.Enabled = true;
                gridValidation();
                // btnClose.Enabled = true;
            }
            catch
            { }
        }

        private void txtSearchInvocie_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvParty.DataSource = bsOriginal3;
                bs3.DataSource = dgvParty.DataSource;
                bs3.Filter = string.Format("[INVOICE NO] like '%{0}%'", txtSearchInvocie.Text);
                dgvParty.DataSource = bs3;
                dgvParty.Enabled = true;
                gridValidation();
                // btnClose.Enabled = true;
            }
            catch
            { }
        }
    }
}
