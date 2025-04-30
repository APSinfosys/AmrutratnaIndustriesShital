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

namespace Textile.ContractForm
{
    public partial class Transaction_YarnContract : Form
    {
        public Transaction_YarnContract()
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

                hash.Add("@intYarnCode", cmbYarn.SelectedValue);

                dtReturn = ClsDefination.FillData("[Master_YarnContract_DML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 204)
                    {
                        cmbBroker.DataSource = dtReturn;
                        cmbBroker.DisplayMember = "BR_Name";
                        cmbBroker.ValueMember = "BR_Code";
                        cmbBroker.SelectedIndex = -1;
                        cmbBroker.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 203)
                    {
                        cmbFirmName.DataSource = dtReturn;
                        cmbFirmName.DisplayMember = "F_CompanyName";
                        cmbFirmName.ValueMember = "F_Code";
                        cmbFirmName.SelectedIndex = -1;
                        cmbFirmName.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 202)
                    {
                        cmbParty.DataSource = dtReturn;
                        cmbParty.DisplayMember = "P_CompanyName";
                        cmbParty.ValueMember = "P_Code";
                        cmbParty.SelectedIndex = -1;
                        cmbParty.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 201)
                    {
                        cmbYarn.DataSource = dtReturn;
                        cmbYarn.DisplayMember = "S_Name";
                        cmbYarn.ValueMember = "S_Code";
                        cmbYarn.SelectedIndex = -1;
                        cmbYarn.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 301)
                    {
                        lblGST.Text = objRow["S_IGST"].ToString();
                    }

                }
                else
                {
                    if (QueryNo == 204)
                    {
                        cmbBroker.DataSource = dtReturn;
                        cmbBroker.SelectedIndex = -1;
                        cmbBroker.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 203)
                    {
                        cmbFirmName.DataSource = dtReturn;
                        cmbFirmName.SelectedIndex = -1;
                        cmbFirmName.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 202)
                    {
                        cmbParty.DataSource = dtReturn;
                        cmbParty.SelectedIndex = -1;
                        cmbParty.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 201)
                    {
                        cmbYarn.DataSource = dtReturn;
                        cmbYarn.SelectedIndex = -1;
                        cmbYarn.Text = "<--NO RECORD-->";
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
                hash.Add("@intCompanyId", fd.CompId);
                hash.Add("@intYearId", fd.YearId);
                hash.Add("@intCreatedBy", fd.UserId);
                if (QueryNo == 1 || QueryNo == 2)
                {

                    if (QueryNo == 2)
                    {
                        hash.Add("@strUniqueCode", lblUniqueCode.Text);
                        hash.Add("@intContractNo", txtContractNo.Text);
                    }

                    hash.Add("@dtpDate", dtpDate.Value.ToString("MM/dd/yyyy"));
                    //hash.Add("@intFirmCode", cmbFirmName.SelectedValue);
                    hash.Add("@intPartyCode", cmbParty.SelectedValue);
                    hash.Add("@intBrokerCode", cmbBroker.SelectedValue);
                    hash.Add("@intYarnCode", cmbYarn.SelectedValue);
                    hash.Add("@decCount", Convert.ToDecimal(txtCount.Text));
                    hash.Add("@strMill", txtMill.Text);
                    hash.Add("@intBag", Convert.ToInt32(txtBags.Text));
                    hash.Add("@decWeight", Convert.ToDecimal(txtWeight.Text));

                    //               @intContractNo,,,,,,,,,,

                    hash.Add("@decNetRate", Convert.ToDecimal(txtNetRateIncluding.Text));
                    hash.Add("@decRatePKg", Convert.ToDecimal(txtRatePKg.Text));
                    hash.Add("@decBrokrage", Convert.ToDecimal(txtBrokrage.Text));
                    //,,,@,@,getdate(),1,@,@
                    hash.Add("@decNetRateExcluding", Convert.ToDecimal(txtNetRateExcluding.Text));
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



        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Transaction_YarnContract_Load(object sender, EventArgs e)
        {
            FillGrid(201);
            FillGrid(202);
            FillGrid(203);
            FillGrid(204);

            if (newOrEdit == 1)
            {
                cmbBroker.SelectedValue = cmbBrokerC;
               // cmbFirmName.SelectedValue = cmbFirmC;
                cmbParty.SelectedValue = cmbPartyC;
                cmbYarn.SelectedValue = cmbYarnC;

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (newOrEdit == 0)
            {
                SaveData(1, ref strReturnMSG, ref strReturnRefNo, ref intReturnPKNo);
            }
            else
            {
                SaveData(2, ref strReturnMSG, ref strReturnRefNo, ref intReturnPKNo);
            }
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
                    if (newOrEdit == 0)
                    {
                        frm.messageTxt = "Rocord Saved Successfully: ";// +strReturnMSG;
                    }
                    else
                    {
                        frm.messageTxt = "Rocord Updated Successfully: ";// +strReturnMSG;
                    }
                    frm.type = "success";
                    frm.ShowDialog();
                    this.Close();
                }
            }

            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Something went wrong please check";
                frm.type = "error";
                frm.ShowDialog();
            }
        }

        private void cmbYarn_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbYarn.SelectedValue != "System.Data.DataRowView")
            {
                FillGrid(301);
            }
        }

        private void txtNetRateIncluding_Leave(object sender, EventArgs e)
        {
            //            excluding = including - (including * (100 / (100 + gst)));

            try
            {

                txtNetRateExcluding.Text =
                    Math.Round(Convert.ToDecimal(txtNetRateIncluding.Text) - (Convert.ToDecimal(txtNetRateIncluding.Text) - (Convert.ToDecimal(txtNetRateIncluding.Text) * (100 / (100 + Convert.ToDecimal(lblGST.Text))))), 2).ToString();
            }
            catch (Exception ex)
            {
                txtNetRateExcluding.Text = "1";
                
            }
        }

        private void txtNetRateExcluding_Leave(object sender, EventArgs e)
        {
            try
            {
                txtNetRateIncluding.Text =
                    Math.Round(Convert.ToDecimal(txtNetRateExcluding.Text) + (Convert.ToDecimal(txtNetRateExcluding.Text) / 100) * Convert.ToDecimal(lblGST.Text), 2).ToString();
            }
            catch (Exception ex)
            {

            }
        }


    }
}
