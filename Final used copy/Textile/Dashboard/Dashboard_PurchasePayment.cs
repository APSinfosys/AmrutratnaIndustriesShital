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
    public partial class Dashboard_PurchasePayment : Form
    {
        public Dashboard_PurchasePayment()
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
                hash.Add("@intYearId", fd.YearId);
                if (QueryNo == 101 || QueryNo == 102)
                {
                    hash.Add("@intShade", cmbShade.SelectedValue);
                }
                if (QueryNo == 102)
                {
                    hash.Add("@intFirm", cmbFirmName.SelectedValue);
                }

                DataTable dtReturn = ClsDefination.FillData("[Transaction_PurchasePayment_DML]", hash);

                if (dtReturn != null && dtReturn.Rows.Count > 0)
                {
                    DataRow dr = dtReturn.Rows[0];
                    if (QueryNo == 101 || QueryNo == 102)
                    {
                        dgvParty.DataSource = dtReturn;
                        bsOriginal.DataSource = dtReturn;
                        dgvParty.Columns[3].Visible = false;
                        dgvParty.Columns[4].Visible = false;
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
                }
                else
                {
                    if (QueryNo == 101 || QueryNo == 102)
                    {
                        dgvParty.DataSource = dtReturn;
                        dgvParty.Columns[4].Visible = false;
                        dgvParty.Columns[3].Visible = false;
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


        private void Dashboard_PurchasePayment_Load(object sender, EventArgs e)
        {
            FillGrid(201);
            FillGrid(302);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbShade.SelectedValue) > 0)
            {
                if (Convert.ToInt32(cmbFirmName.SelectedValue) > 0)
                {
                    FillGrid(102);
                }
                else
                {
                    messageBox frm = new messageBox();
                    frm.messageTxt = "Please Select Firm";
                    frm.type = "error";
                    frm.ShowDialog();
                }
            }
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please Select Shade";
                frm.type = "error";
                frm.ShowDialog();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            FillGrid(201);
            FillGrid(302);
            FillGrid(101);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (dgvParty.SelectedRows.Count > 0)
            {
                Finance.SalesReceipt frm = new Finance.SalesReceipt();
                frm.lblPartyCode.Text = dgvParty.CurrentRow.Cells[0].Value.ToString();
                frm.lblPartyName.Text = dgvParty.CurrentRow.Cells[1].Value.ToString();
                frm.lblSalaryAmt.Text = dgvParty.CurrentRow.Cells[2].Value.ToString();
                frm.lblShade.Text = cmbShade.SelectedValue.ToString();
                frm.lblFirmName.Text = dgvParty.CurrentRow.Cells[4].Value.ToString();
                frm.lblFirmCode.Text = dgvParty.CurrentRow.Cells[3].Value.ToString();
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
    }
}
