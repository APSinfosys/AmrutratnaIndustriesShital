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
    public partial class Dashboard_PartyMaster : Form
    {
        public Dashboard_PartyMaster()
        {
            InitializeComponent();
        }

        #region variables
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        BindingSource bs = new BindingSource();
        BindingSource bsOriginal = new BindingSource();
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
                hash.Add("@intcompanyId", Convert.ToInt32(fd.CompId));

                dtReturn = ClsDefination.FillData("[Party_DML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 101)
                    {
                        dgvParty.DataSource = dtReturn;
                        bsOriginal.DataSource = dtReturn;
                        dgvParty.Columns[8].Visible = false;
                        dgvParty.Columns[15].DisplayIndex = 0;
                        for (int i = 0; i < 15; i++)
                        {
                            dgvParty.Columns[i].DisplayIndex = i + 1;
                        }
                        //           MP.P_Code as [CODE], MP.P_OwnerName as [OWNER], MP.P_CompanyName as [COMPANY], MP.P_Address as [ADDRESS],
                        //MP.P_Mobile as [MOBILE 1], MP.P_AlternateMob as [MOBILE 2],
                        //MP.P_GSTNo as [GST NO], MP.P_PANNo as [PAN NO], MP.P_State,CVN.Common_Value as [STATE], MP.P_Email as [EMAIL], 
                        //MP.P_BankName as [BANK], MP.P_Branch as [BRANCH], MP.P_AccNo as [ACC NO], MP.P_IFSC as [IFSC],
                        //MP.UniqueCode as [UNIQUE CODE]
                    }

                }
                else
                {
                    if (QueryNo == 101)
                    {
                        dgvParty.DataSource = null;

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


                hash.Add("@QueryNo", QueryNo);
                hash.Add("@intcreatedBy", fd.UserId);
                hash.Add("@intcompanyId", fd.CompId);
                hash.Add("@inryearId", fd.YearId);

                if (QueryNo == 20)
                {

                    hash.Add("@strUniqueCode", dgvParty.CurrentRow.Cells[15].Value.ToString());
                    hash.Add("@intP_Code",Convert.ToInt32(dgvParty.CurrentRow.Cells[0].Value.ToString()));
                }

                okflag = 1;
                return ClsDefination.InsertExecute(hash, "[Party_DML]", ref strReturnMSG, ref strReturnNo, ref intReturnNo);
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


        private void Dashboard_PartyMaster_Load(object sender, EventArgs e)
        {
            FillGrid(101);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvParty.DataSource = bsOriginal;
                bs.DataSource = dgvParty.DataSource;
                bs.Filter = string.Format("[COMPANY] like '%{0}%'", txtSearch.Text);
                dgvParty.DataSource = bs;
                dgvParty.Enabled = true;
                // btnClose.Enabled = true;
            }
            catch
            { }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Masters.SupplierMaster frm = new Masters.SupplierMaster();
            frm.ShowDialog();
            FillGrid(101);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvParty.SelectedRows.Count > 0)
                {
                    Masters.SupplierMaster frm = new Masters.SupplierMaster();
                    frm.newOrEdit = 1;


                    frm.lblSrNo.Text = dgvParty.CurrentRow.Cells[0].Value.ToString();
                    frm.txtOwnerName.Text = dgvParty.CurrentRow.Cells[1].Value.ToString();
                    frm.txtPartyName.Text = dgvParty.CurrentRow.Cells[2].Value.ToString();
                    frm.txtAdress.Text = dgvParty.CurrentRow.Cells[3].Value.ToString();
                    //       MP.P_Code as [CODE], MP.P_OwnerName as [OWNER], MP.P_CompanyName as [COMPANY], MP.P_Address as [ADDRESS],

                    frm.txtMobileNo.Text = dgvParty.CurrentRow.Cells[4].Value.ToString();
                    frm.txtAlternetNo.Text = dgvParty.CurrentRow.Cells[5].Value.ToString();
                    //MP.P_Mobile as [MOBILE 1], MP.P_AlternateMob as [MOBILE 2],

                    frm.txtGSTNo.Text = dgvParty.CurrentRow.Cells[6].Value.ToString();
                    frm.txtPanNo.Text = dgvParty.CurrentRow.Cells[7].Value.ToString();
                    frm.lblStateCode.Text = dgvParty.CurrentRow.Cells[8].Value.ToString();
                    frm.cmbState.Text = dgvParty.CurrentRow.Cells[9].Value.ToString();
                    frm.txtEmailId.Text = dgvParty.CurrentRow.Cells[10].Value.ToString();
                    //MP.P_GSTNo as [GST NO], MP.P_PANNo as [PAN NO], MP.P_State,CVN.Common_Value as [STATE], MP.P_Email as [EMAIL], 

                    frm.txtBankName.Text = dgvParty.CurrentRow.Cells[11].Value.ToString();
                    frm.txtBranch.Text = dgvParty.CurrentRow.Cells[12].Value.ToString();
                    frm.txtAccNo.Text = dgvParty.CurrentRow.Cells[13].Value.ToString();
                    frm.txtIfscCode.Text = dgvParty.CurrentRow.Cells[14].Value.ToString();
                    frm.lblUniqueCode.Text = dgvParty.CurrentRow.Cells[15].Value.ToString().Remove(0,2);

                    frm.ShowDialog();
                    FillGrid(101);
                }
                else
                {
                    messageBox frm = new messageBox();
                    frm.messageTxt = "Please Select Row To Edit";
                    frm.type = "error";
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void btnPayPayment_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvParty.SelectedRows.Count > 0)
                {
                    Finance.PartyOpeningBalance frm = new Finance.PartyOpeningBalance();
                    frm.newOrEdit = 0;
                    frm.lblUniqueCode.Text = dgvParty.CurrentRow.Cells[15].Value.ToString();
                    frm.lblSrNo.Text = dgvParty.CurrentRow.Cells[0].Value.ToString();
                    frm.lblCompanyNameValue.Text = dgvParty.CurrentRow.Cells[2].Value.ToString() + " - " + dgvParty.CurrentRow.Cells[1].Value.ToString();

                    frm.ShowDialog();
                }
                else
                {
                    messageBox frm = new messageBox();
                    frm.messageTxt = "Please Select Party For Opening Balance";
                    frm.type = "error";
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvParty.SelectedRows.Count > 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the record?", "Delete record", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        SaveData(20, ref strReturnMSG, ref strReturnRefNo, ref intReturnPKNo);

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

