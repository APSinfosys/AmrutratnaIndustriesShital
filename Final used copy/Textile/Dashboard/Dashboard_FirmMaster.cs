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
    public partial class Dashboard_FirmMaster : Form
    {
        public Dashboard_FirmMaster()
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

                dtReturn = ClsDefination.FillData("[Master_FirmMaster_DML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 101)
                    {


                        dgvParty.DataSource = dtReturn;
                        bsOriginal.DataSource = dtReturn;
                        dgvParty.Columns[14].Visible = false;

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

                if (QueryNo == 3)
                {

                    hash.Add("@intCode", Convert.ToInt32(dgvParty.CurrentRow.Cells[0].Value.ToString()));
                }

                okflag = 1;
                return ClsDefination.InsertExecute(hash, "[Master_FirmMaster_DML]", ref strReturnMSG, ref strReturnNo, ref intReturnNo);
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


        private void btnNew_Click(object sender, EventArgs e)
        {
            Masters.Master_FirmMaster frm = new Masters.Master_FirmMaster();
            frm.ShowDialog();
            FillGrid(101);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvParty.DataSource = bsOriginal;
                bs.DataSource = dgvParty.DataSource;
                bs.Filter = string.Format("[COMPANY NAME] like '%{0}%'", txtSearch.Text);
                dgvParty.DataSource = bs;
                dgvParty.Enabled = true;
                // btnClose.Enabled = true;
            }
            catch
            { }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvParty.SelectedRows.Count > 0)
                {


                    Masters.Master_FirmMaster frm = new Masters.Master_FirmMaster();
                    frm.newOrEdit = 1;

                    frm.lblSrNo.Text = dgvParty.CurrentRow.Cells[1].Value.ToString();
                    frm.txtPartyName.Text = dgvParty.CurrentRow.Cells[2].Value.ToString();
                    frm.txtOwnerName.Text = dgvParty.CurrentRow.Cells[3].Value.ToString();
                    
                    frm.txtAdress.Text = dgvParty.CurrentRow.Cells[4].Value.ToString();

                    frm.txtMobileNo.Text = dgvParty.CurrentRow.Cells[5].Value.ToString();
                    frm.txtAlternetNo.Text = dgvParty.CurrentRow.Cells[6].Value.ToString();
                    frm.txtGSTNo.Text = dgvParty.CurrentRow.Cells[7].Value.ToString();


                    frm.txtPanNo.Text = dgvParty.CurrentRow.Cells[8].Value.ToString();
                    frm.lblStateCode.Text = dgvParty.CurrentRow.Cells[14].Value.ToString();
                    frm.cmbState.Text = dgvParty.CurrentRow.Cells[9].Value.ToString();
                    frm.txtEmailId.Text = dgvParty.CurrentRow.Cells[10].Value.ToString();
                    frm.txtBankName.Text = dgvParty.CurrentRow.Cells[11].Value.ToString();
                    frm.txtAccountNo.Text = dgvParty.CurrentRow.Cells[12].Value.ToString();
                    frm.txtIfscCode.Text = dgvParty.CurrentRow.Cells[13].Value.ToString();

                    frm.ShowDialog();
                    FillGrid(101);
                }
                else
                {
                    messageBox frm = new messageBox();
                    frm.messageTxt = "Please select record to edit";
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

        private void Dashboard_FirmMaster_Load(object sender, EventArgs e)
        {
            FillGrid(101);
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
