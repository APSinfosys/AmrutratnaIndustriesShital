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
    public partial class Dashboard_YarnContract : Form
    {
        public Dashboard_YarnContract()
        {
            InitializeComponent();
        }
        #region variables
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        public string UserName, yearString, companyNameStr, groupNmae, PeriodName;
        public int cmbFirmC, cmbPartyC, cmbBrokerC, cmbYarnC;
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
                hash.Add("@intCompanyId", fd.CompId);
                hash.Add("@intYearId", fd.YearId);

                dtReturn = ClsDefination.FillData("[Master_YarnContract_DML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 101)
                    {
                        dgvAcc.DataSource = dtReturn;

                        for (int i = 12; i < 18; i++)
                        {
                            dgvAcc.Columns[i].Visible = false;
                        }

                    }
                }
                else
                {

                    if (QueryNo == 101)
                    {
                        dgvAcc.DataSource = dtReturn;

                        for (int i = 13; i < 18; i++)
                        {
                            dgvAcc.Columns[i].Visible = false;
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
                    hash.Add("@intContractNo", Convert.ToInt32(dgvAcc.CurrentRow.Cells[1].Value.ToString()));
                    hash.Add("@strUniqueCode", dgvAcc.CurrentRow.Cells[0].Value.ToString());
                }

                okflag = 1;
                return ClsDefination.InsertExecute(hash, "[Master_YarnContract_DML]", ref strReturnMSG, ref strReturnNo, ref intReturnNo);
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
            ContractForm.Transaction_YarnContract frm = new ContractForm.Transaction_YarnContract();
            frm.newOrEdit = 0;
            frm.ShowDialog();
            FillGrid(101);

        }

        private void Dashboard_YarnContract_Load(object sender, EventArgs e)
        {
            FillGrid(101);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvAcc.SelectedRows.Count > 0)
            {
                ContractForm.Transaction_YarnContract frm = new ContractForm.Transaction_YarnContract();
                frm.newOrEdit = 1;


      //          MYC.uniqueCode as [UNIQUE CODE],MYC.ContractNo as [CONTRACT NO], MYC.date as [DATE], 
      //MP.P_CompanyName as [PARTY NAME],BR.BR_Name as [BROKER],
      //MS.S_Name as [YARN NAME],
      //--FM.F_CompanyName as [FIRM NAME],
      //MYC.count as [COUNT], MYC.mill as [MILL], 
      //MYC.bag as [BAG], MYC.weight as [WEIGHT], MYC.netrate as [NET RATE], MYC.ratePKg as [RATE / Kg], 
      //MYC.brokrage as [BROKRAGE],
      //MYC.firmCode, MYC.partyCode, MYC.brokerCode, MYC.yarnCode,MYC.netRateExcluding 



                frm.lblUniqueCode.Text = dgvAcc.CurrentRow.Cells[0].Value.ToString();
                frm.txtContractNo.Text = dgvAcc.CurrentRow.Cells[1].Value.ToString();
                frm.dtpDate.Text = dgvAcc.CurrentRow.Cells[2].Value.ToString();

                //                     MYC.uniqueCode as [UNIQUE CODE],MYC.ContractNo as [CONTRACT NO], MYC.date as [DATE],  2

                frm.cmbParty.Text = dgvAcc.CurrentRow.Cells[3].Value.ToString();
                frm.cmbBroker.Text = dgvAcc.CurrentRow.Cells[4].Value.ToString();
                  
                
                //BR.BR_Name as [BROKER],FM.F_CompanyName as [FIRM NAME],MP.P_CompanyName as [PARTY NAME],
                frm.cmbYarn.Text = dgvAcc.CurrentRow.Cells[5].Value.ToString();
                //MS.S_Name as [YARN NAME],                 
                frm.txtCount.Text = dgvAcc.CurrentRow.Cells[6].Value.ToString();
                frm.txtMill.Text = dgvAcc.CurrentRow.Cells[7].Value.ToString();
                //MYC.count as [COUNT], MYC.mill as [MILL], 
                frm.txtBags.Text = dgvAcc.CurrentRow.Cells[8].Value.ToString();
                frm.txtWeight.Text = dgvAcc.CurrentRow.Cells[9].Value.ToString();
                frm.txtNetRateIncluding.Text = dgvAcc.CurrentRow.Cells[10].Value.ToString();
                frm.txtRatePKg.Text = dgvAcc.CurrentRow.Cells[11].Value.ToString();
                //MYC.bag as [BAG], MYC.weight as [WEIGHT], MYC.netrate as [NET RATE], MYC.ratePKg as [RATE / Kg],           12
                frm.txtBrokrage.Text = dgvAcc.CurrentRow.Cells[12].Value.ToString();
                //MYC.brokrage as [BROKRAGE],                                                                                13   
                
                frm.cmbFirmC = Convert.ToInt32(dgvAcc.CurrentRow.Cells[13].Value.ToString());
                frm.cmbPartyC = Convert.ToInt32(dgvAcc.CurrentRow.Cells[14].Value.ToString());
                frm.cmbBrokerC = Convert.ToInt32(dgvAcc.CurrentRow.Cells[15].Value.ToString());
                frm.cmbYarnC = Convert.ToInt32(dgvAcc.CurrentRow.Cells[16].Value.ToString());
                frm.txtNetRateExcluding.Text = dgvAcc.CurrentRow.Cells[17].Value.ToString();
                //MYC.firmCode, MYC.partyCode, MYC.brokerCode, MYC.yarnCode
                //17
                frm.ShowDialog();
                FillGrid(101);
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
