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
    public partial class Dashboard_BrokerMaster : Form
    {
        public Dashboard_BrokerMaster()
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


                DataTable dtReturn = ClsDefination.FillData("[Master_BrokerMaster_DML]", hash);

                if (dtReturn != null && dtReturn.Rows.Count > 0)
                {
                    DataRow dr = dtReturn.Rows[0];
                    if (QueryNo == 101)
                    {
                        dgvAcc.DataSource = dtReturn;
                        bsOriginal.DataSource = dtReturn;


      //                  BM.BR_Code as [ CODE ], BM.BR_Name as [ BROKER NAME ], BM.BR_Address as [ ADDRESS ], 
      //BM.BR_Contact as [ CONTACT NO ], BM.BR_Alternate as [ ALTERNET CONTACT NO],BM.UniqueCode as [UNIQUE CODE],
      //BM.OpeningBalance as [OPENING BALANCE],CV.Common_Value as [BALANCE TYPE] ,BM.BalanceType

                        dgvAcc.Columns[5].DisplayIndex = 0;

                        dgvAcc.Columns[0].DisplayIndex = 1;
                        dgvAcc.Columns[1].DisplayIndex = 2;
                        dgvAcc.Columns[2].DisplayIndex = 3;
                        dgvAcc.Columns[3].DisplayIndex = 4;
                        dgvAcc.Columns[4].DisplayIndex = 5;
                        dgvAcc.Columns[6].DisplayIndex = 6;
                        dgvAcc.Columns[7].DisplayIndex = 7;
                        dgvAcc.Columns[8].DisplayIndex = 8;
                        
                        dgvAcc.Columns[8].Visible = false;

                    }

                }
                else
                {
                    if (QueryNo == 101)
                    {
                        dgvAcc.DataSource = dtReturn;
                        bsOriginal.DataSource = dtReturn;
                        dgvAcc.Columns[5].DisplayIndex = 0;

                        for (int i = 0; i < 5; i++)
                        {
                            dgvAcc.Columns[i].DisplayIndex = i + 1;
                        }

                        dgvAcc.Columns[8].Visible = false;
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
                hash.Add("@intCreatedBy", fd.UserId);
                hash.Add("@intCompanyId", fd.CompId);
                hash.Add("@intYearId", fd.YearId);

                if (QueryNo == 3)
                {
                    hash.Add("@strUniqueCode",dgvAcc.CurrentRow.Cells[5].Value.ToString());
                    hash.Add("@intCode", Convert.ToInt32(dgvAcc.CurrentRow.Cells[0].Value.ToString()));
                }

                okflag = 1;
                return ClsDefination.InsertExecute(hash, "[Master_BrokerMaster_DML]", ref strReturnMSG, ref strReturnNo, ref intReturnNo);
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



        private void Dashboard_BrokerMaster_Load(object sender, EventArgs e)
        {
            FillGrid(101);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvAcc.DataSource = bsOriginal;
                bs.DataSource = dgvAcc.DataSource;
                bs.Filter = string.Format("[ BROKER NAME ] like '%{0}%'", txtSearch.Text);
                dgvAcc.DataSource = bs;
                dgvAcc.Enabled = true;
                // btnClose.Enabled = true;
            }
            catch
            { }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Masters.Master_BrockerMaster frm = new Masters.Master_BrockerMaster();
            frm.newOrEdit = 0;
            frm.ShowDialog();
            FillGrid(101);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAcc.SelectedRows.Count > 0)
                {
                    Masters.Master_BrockerMaster frm = new Masters.Master_BrockerMaster();
                    frm.newOrEdit = 1;
      //                    BR_Code as [ CODE ], BR_Name as [ BROKER NAME ], BR_Address as [ ADDRESS ], 
      //BR_Contact as [ CONTACT NO ], BR_Alternate as [ ALTERNET CONTACT NO],UniqueCode as [UNIQUE CODE]
                    frm.lblSrNo.Text = dgvAcc.CurrentRow.Cells[0].Value.ToString();
                    frm.txtName.Text = dgvAcc.CurrentRow.Cells[1].Value.ToString();
                    frm.txtAddress.Text = dgvAcc.CurrentRow.Cells[2].Value.ToString();
                    frm.txtContact.Text = dgvAcc.CurrentRow.Cells[3].Value.ToString();
                    frm.txtAlternet.Text = dgvAcc.CurrentRow.Cells[4].Value.ToString();
                    frm.lblUniqueCode.Text = dgvAcc.CurrentRow.Cells[5].Value.ToString();
                    frm.txtOpeningBalance.Text = dgvAcc.CurrentRow.Cells[6].Value.ToString();
                    frm.cmbBalanceType.Text = dgvAcc.CurrentRow.Cells[7].Value.ToString();
                    frm.cmbBT = Convert.ToInt32(dgvAcc.CurrentRow.Cells[8].Value.ToString());
      //              BM.BR_Code as [ CODE ], BM.BR_Name as [ BROKER NAME ], BM.BR_Address as [ ADDRESS ], 
      //BM.BR_Contact as [ CONTACT NO ], BM.BR_Alternate as [ ALTERNET CONTACT NO],BM.UniqueCode as [UNIQUE CODE],
      //BM.OpeningBalance as [OPENING BALANCE],CV.Common_Value as [BALANCE TYPE] ,BM.BalanceType
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
            catch (Exception ex)
            {
            }
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
