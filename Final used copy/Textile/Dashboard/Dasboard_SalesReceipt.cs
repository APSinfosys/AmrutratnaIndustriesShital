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
    public partial class Dasboard_SalesReceipt : Form
    {
        public Dasboard_SalesReceipt()
        {
            InitializeComponent();
        }

        #region Variable
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        BindingSource bs = new BindingSource();
        BindingSource bsOriginal = new BindingSource();
        public string UserName, yearString, companyNameStr;
        public int userId, compId, yearId, GroupId = 0, otherPg;
        string strReturnMSG, strReturnRefNo, sp;
        int intReturnPKNo;
        int result, deletefrm;
        public int newOrEdit = 0;

        #endregion

        #region Fill Grid
        public DataTable FillGrid(int QueryNo)
        {
            try
            {
                hash = new Hashtable();

                hash.Add("@QueryNo", QueryNo);
                hash.Add("@intcompanyId", fd.CompId);
                hash.Add("@inryearId", fd.YearId);
                if (QueryNo == 101)
                {
                    hash.Add("@intShade", cmbShade.SelectedValue);
                }

                if (QueryNo == 102)
                {
                    if (Convert.ToInt32(cmbFirmName.SelectedValue) > 0)
                    {
                        hash.Add("@intFirm", cmbFirmName.SelectedValue);
                    }
                    else
                    {
                        hash.Add("@intFirm",0);
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

                DataTable dtReturn = ClsDefination.FillData("[Transaction_SalesReceipt_DML]", hash);

                if (dtReturn != null && dtReturn.Rows.Count > 0)
                {
                    DataRow dr = dtReturn.Rows[0];
                    if (QueryNo == 101 || QueryNo == 102)
                    {
                        dgvParty.DataSource = dtReturn;
                        bsOriginal.DataSource = dtReturn;

      //                  MY.yr_Short as [YEAR], FM.F_CompanyName as [FIRM NAME],MP.P_CompanyName+' - '+MP.P_OwnerName as [PARTY NAME],
      // CA.T_InvoiceNo as [INVOICE NO],TSI.grandTotal as [INVOICE AMOUNT],
      // isnull(SUM(CA.T_InAmt),0) as [PAID AMOUNT],isnull(SUM(CA.TdsAmunt),0) as [TDS AMOUNT],
      //ISNULL(isnull(sum(CA.T_OutAmt),0)-isnull(sum(CA.T_InAmt),0),0) as [BALANCE],
      // CA.firmId, CA.UniqueCode,
      // CA.T_Party as [PARTY CODE]

                        dgvParty.Columns[8].Visible = false;
                        dgvParty.Columns[9].Visible = false;
                        dgvParty.Columns[10].Visible = false;
                        dgvParty.Columns[11].Visible = false;

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
                        //, 
                        cmbParty.DataSource = dtReturn;
                        cmbParty.DisplayMember = "P_CompanyName";
                        cmbParty.ValueMember = "P_Code";
                        cmbParty.SelectedIndex = -1;
                        cmbParty.Text = "<--SELECT-->";
                    }
                }
                else
                {
                    if (QueryNo == 101 || QueryNo == 102)
                    {
                        dgvParty.DataSource = dtReturn;
                        dgvParty.Columns[8].Visible = false;
                        dgvParty.Columns[9].Visible = false;
                        dgvParty.Columns[10].Visible = false;
                        dgvParty.Columns[11].Visible = false;

                    }
                    else if (QueryNo == 201)
                    {
                        cmbShade.DataSource = dtReturn;
                        cmbShade.SelectedIndex = -1;
                        cmbShade.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 302)
                    {
                        cmbFirmName.DataSource = dtReturn;
                        cmbFirmName.SelectedIndex = -1;
                        cmbFirmName.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 303)
                    {
                        //, 
                        cmbParty.DataSource = dtReturn;
                        cmbParty.SelectedIndex = -1;
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
        #endregion

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (dgvParty.SelectedRows.Count > 0)
            {

                // MY.yr_Short as [YEAR], FM.F_CompanyName as [FIRM NAME],MP.P_CompanyName+' - '+MP.P_OwnerName as [PARTY NAME],
                // CA.T_InvoiceNo as [INVOICE NO],TSI.grandTotal as [INVOICE AMOUNT],
                // isnull(SUM(CA.T_InAmt),0) as [PAID AMOUNT],isnull(SUM(CA.TdsAmunt),0) as [TDS AMOUNT],
                //ISNULL(isnull(sum(CA.T_OutAmt),0)-isnull(sum(CA.T_InAmt),0),0) as [BALANCE],
                // CA.firmId, CA.UniqueCode,
                // CA.T_Party as [PARTY CODE]


                Finance.SalesReceipt frm = new Finance.SalesReceipt();

                frm.lblFirmName.Text = dgvParty.CurrentRow.Cells[1].Value.ToString();
                frm.lblPartyName.Text = dgvParty.CurrentRow.Cells[2].Value.ToString();
                frm.lblInvoiceNo.Text = dgvParty.CurrentRow.Cells[3].Value.ToString();
                frm.lblSalaryAmt.Text = dgvParty.CurrentRow.Cells[7].Value.ToString();

                frm.lblFirmCode.Text = dgvParty.CurrentRow.Cells[8].Value.ToString();
                frm.lblInviceUniqueCode.Text = dgvParty.CurrentRow.Cells[9].Value.ToString();
                frm.lblPartyCode.Text = dgvParty.CurrentRow.Cells[10].Value.ToString();
                frm.lblShade.Text = dgvParty.CurrentRow.Cells[11].Value.ToString(); //cmbShade.SelectedValue.ToString();
                
               // frm.lblFirmName.Text = dgvParty.CurrentRow.Cells[4].Value.ToString();
                frm.txtReceipt.Text = dgvParty.CurrentRow.Cells[3].Value.ToString();
                frm.ShowDialog();
                FillGrid(102);
            }
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please Select At Least One Record";
                frm.type = "error";
                frm.ShowDialog();
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            //if (Convert.ToInt32(cmbShade.SelectedValue) > 0)
            //{
                //if (Convert.ToInt32(cmbFirmName.SelectedValue) > 0)
                //{
                    FillGrid(102);
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

        private void Dasboard_SalesReceipt_Load(object sender, EventArgs e)
        {
            FillGrid(201);
            FillGrid(302);
            FillGrid(303);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            FillGrid(201);
            FillGrid(302);
            FillGrid(303);
            //FillGrid(102);
            dgvParty.DataSource = null;
        }
    }
}
