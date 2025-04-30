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

namespace Accounting.Dashbord_Forms
{
    public partial class Dashboard_AccountMaster : Form
    {
        public Dashboard_AccountMaster()
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
        int result, deletefrm, okflag;
        public int newOrEdit = 0;

        #endregion

        public DataTable FillGrid(int QueryNo)
        {
            try
            {
                hash = new Hashtable();

                hash.Add("@QueryNo", QueryNo);
                hash.Add("@intCompanyId", fd.CompId);
                hash.Add("@intYearId", fd.YearId);


                DataTable dtReturn = ClsDefination.FillData("[Master_AccMasterDML]", hash);

                if (dtReturn != null && dtReturn.Rows.Count > 0)
                {
                    DataRow dr = dtReturn.Rows[0];
                    if (QueryNo == 101)
                    {
                        dgvAcc.DataSource = dtReturn;
                        bsOriginal.DataSource = dtReturn;

                        dgvAcc.Columns[10].DisplayIndex = 0;

                        for (int i = 0; i < 10; i++)
                        {
                            dgvAcc.Columns[i].DisplayIndex = i+1;
                        }

                        dgvAcc.Columns[8].Visible = false;
                        dgvAcc.Columns[9].Visible=false;

                    }

                }
                else
                {
                    if (QueryNo == 101)
                    {
                        dgvAcc.DataSource =  null;

                        dgvAcc.Columns[10].DisplayIndex = 0;

                        for (int i = 0; i < 10; i++)
                        {
                            dgvAcc.Columns[i].DisplayIndex = i + 1;
                        }

                        dgvAcc.Columns[8].Visible = false;
                        dgvAcc.Columns[9].Visible = false;

                        //   dgvAcc.Columns[9].Visible = false;
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


                hash.Add("@QueryNo", QueryNo);
                hash.Add("@intcreatedBy", fd.UserId);
                hash.Add("@intcompanyId", fd.CompId);
                hash.Add("@intYearId", fd.YearId);

                if (QueryNo == 3)
                {

                    hash.Add("@strUniqueCode", dgvAcc.CurrentRow.Cells[10].Value.ToString());
                    hash.Add("@intCode", Convert.ToInt32( dgvAcc.CurrentRow.Cells[0].Value.ToString()));
                }

                okflag = 1;
                return ClsDefination.InsertExecute(hash, "[Master_AccMasterDML]", ref strReturnMSG, ref strReturnNo, ref intReturnNo);
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


        private void Dashboard_AccountMaster_Load(object sender, EventArgs e)
        {
            FillGrid(101);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            FillGrid(301);
            FillGrid(302);
            lblBalance.Visible = false;
            lblBalLabel.Visible = false;
            btnDelete.Enabled = true;
            btnEdit.Enabled = true;
            btnNew.Enabled = true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FillGrid(301);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Master.Master_AccountMaster frm = new Master.Master_AccountMaster();
            frm.newOrEdit = 0;
            frm.ShowDialog();
            FillGrid(101);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvAcc.SelectedRows.Count > 0)
            {
                Master.Master_AccountMaster frm = new Master.Master_AccountMaster();
                frm.newOrEdit = 1;
                frm.lblSrNo.Text= dgvAcc.CurrentRow.Cells[0].Value.ToString();
                frm.txtName.Text = dgvAcc.CurrentRow.Cells[1].Value.ToString();
                frm.txtAccNo.Text = dgvAcc.CurrentRow.Cells[2].Value.ToString();
                frm.txtAddress.Text = dgvAcc.CurrentRow.Cells[3].Value.ToString();
        //select AM.Acc_Code as [CODE], AM.BankName as [BANK NAME], AM.AccNo as [ACC NO], AM.Address as [ADDRESS], 
                frm.txtBranch.Text = dgvAcc.CurrentRow.Cells[4].Value.ToString();
                frm.txtIfsc.Text = dgvAcc.CurrentRow.Cells[5].Value.ToString();
                frm.txtHolderName.Text = dgvAcc.CurrentRow.Cells[6].Value.ToString();
        //AM.Branch as [BRANCH], AM.IFSCCode as [IFSC CODE], AM.HolderName as [HOLDER NAME], 
                frm.txtOpBal.Text = dgvAcc.CurrentRow.Cells[7].Value.ToString();
                frm.cmbTT = Convert.ToInt32(dgvAcc.CurrentRow.Cells[9].Value.ToString());
                frm.lblUniqueCode.Text = dgvAcc.CurrentRow.Cells[10].Value.ToString().Remove(0,2);
        //AM.OpeningBalance as [OPENING BALANCE],CV.Common_Value as [BALANCE TYPE] ,AM.BalanceType 
                frm.ShowDialog();
                FillGrid(101);

        //                select AM.Acc_Code as [CODE], AM.BankName as [BANK NAME], AM.AccNo as [ACC NO], AM.Address as [ADDRESS], 
        //AM.Branch as [BRANCH], AM.IFSCCode as [IFSC CODE], AM.HolderName as [HOLDER NAME], 
        //AM.OpeningBalance as [OPENING BALANCE],CV.Common_Value as [BALANCE TYPE] ,AM.BalanceType
                //FillGrid(302);
            }
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please Select At Least One Record";
                frm.type = "error";
                frm.ShowDialog();
            }
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {

            if (cmbAcc.Text != "<--select-->")
            {
                FillGrid(304);/// get individual acc details
                // FillGrid(305); /// getmclosing balance 
                FillGrid(308);
                FillGrid(309);
                lblBalance.Visible = true;
                lblBalLabel.Visible = true;
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
                btnEdit.ForeColor = Color.White;
                btnNew.ForeColor = Color.White;
                btnNew.Enabled = false;
            }
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please Select Record";
                frm.type = "error";
                frm.ShowDialog();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvAcc.DataSource = bsOriginal;
                bs.DataSource = dgvAcc.DataSource;
                bs.Filter = string.Format("[BANK NAME] like '%{0}%'", txtSearch.Text);
                dgvAcc.DataSource = bs;
                dgvAcc.Enabled = true;
                // btnClose.Enabled = true;
            }
            catch
            { }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAcc.SelectedRows.Count > 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the record?", "Delete record", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        SaveData(3, ref strReturnMSG, ref strReturnRefNo, ref intReturnPKNo);

                        if (okflag == 1)
                        {
                            if (intReturnPKNo == 0)
                            {
                                messageBox frm = new messageBox();
                                frm.messageTxt = strReturnMSG;
                                frm.type = "error";
                                frm.ShowDialog();
                            }
                            else
                            {
                                messageBox frm = new messageBox();
                                frm.messageTxt = "Rocord Deleted Successfully: ";// +strReturnMSG;
                                frm.type = "success";
                                frm.ShowDialog();
                                FillGrid(101);
                            }
                        }
                    }
                }
                else
                {
                    messageBox frm = new messageBox();
                    frm.messageTxt = "Please select record to delete";
                    frm.type = "error";
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Something went wrong please try again or call Administrator";
                frm.type = "error";
                frm.ShowDialog();
            }
        }
    }
}
