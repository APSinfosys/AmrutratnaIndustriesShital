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
    public partial class Transaction_JobContract : Form
    {
        public Transaction_JobContract()
        {
            InitializeComponent();
        }



        #region variables
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        public string UserName, yearString, companyNameStr, groupNmae, PeriodName;
        public int cmbFirmC, cmbPartyC, cmbBrokerC, cmbQualityC;
        string strReturnMSG, strReturnRefNo;
        int intReturnPKNo;
        int result, okflag;
        //  public int groupId;
        public int newOrEdit = 0,isInward=0;
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

                if (QueryNo == 301)
                {
                    hash.Add("@intQuality", cmbQuality.SelectedValue);
                }


                dtReturn = ClsDefination.FillData("[Master_JobContract_DML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 201)
                    {
                        cmbBroker.DataSource = dtReturn;
                        cmbBroker.DisplayMember = "BR_Name";
                        cmbBroker.ValueMember = "BR_Code";
                        cmbBroker.SelectedIndex = -1;
                        cmbBroker.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 202)
                    {
                        cmbFirmName.DataSource = dtReturn;
                        cmbFirmName.DisplayMember = "F_CompanyName";
                        cmbFirmName.ValueMember = "F_Code";
                        cmbFirmName.SelectedIndex = -1;
                        cmbFirmName.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 203)
                    {
                        cmbParty.DataSource = dtReturn;
                        cmbParty.DisplayMember = "P_CompanyName";
                        cmbParty.ValueMember = "P_Code";
                        cmbParty.SelectedIndex = -1;
                        cmbParty.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 204)
                    {
                        cmbQuality.DataSource = dtReturn;
                        cmbQuality.DisplayMember = "Q_Name";
                        cmbQuality.ValueMember = "Q_Code";
                        cmbQuality.SelectedIndex = -1;
                        cmbQuality.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 301)
                    {
                       txtPick.Text= lblPick.Text = objRow["PICK"].ToString();
                       txtPannha.Text= lblPannha.Text = objRow["PANNHA"].ToString();
                    }

                }
                else
                {
                    if (QueryNo == 201)
                    {
                        cmbBroker.DataSource = dtReturn;
                        cmbBroker.SelectedIndex = -1;
                        cmbBroker.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 202)
                    {
                        cmbFirmName.DataSource = dtReturn;
                        cmbFirmName.SelectedIndex = -1;
                        cmbFirmName.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 203)
                    {
                        cmbParty.DataSource = dtReturn;
                        cmbParty.SelectedIndex = -1;
                        cmbParty.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 204)
                    {
                        cmbQuality.DataSource = dtReturn;
                        cmbQuality.SelectedIndex = -1;
                        cmbQuality.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 301)
                    {
                        lblPick.Text = "0";
                        lblPannha.Text = "0";
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
                if (QueryNo == 1 || QueryNo == 2 || QueryNo == 3 || QueryNo == 4)
                {

                    if (QueryNo == 2)
                    {
                        hash.Add("@UniqueCode", lblUniqueCode.Text);
                        hash.Add("@intContractNo", Convert.ToInt32(txtContractNo.Text));
                    }
                    else if (QueryNo == 3 || QueryNo == 4)
                    {
                        if (QueryNo == 4)
                        {
                            hash.Add("@UniqueCode", lblUniqueCode.Text);
                            hash.Add("@intContractNo", lblSrNo.Text);
                        }
                        hash.Add("@strContractNo",txtContractNo.Text);
                       
                    }

                    

                    hash.Add("@dtpDate", dtpDate.Value.ToString("MM/dd/yyyy"));
                 //   hash.Add("@intFirm", cmbFirmName.SelectedValue);
                    hash.Add("@intParty", cmbParty.SelectedValue);
                    hash.Add("@intBroker", cmbBroker.SelectedValue);
                    hash.Add("@intQuality", cmbQuality.SelectedValue);
                    hash.Add("@decPhani",Convert.ToDecimal(txtPhani.Text));
                    hash.Add("@decPick", Convert.ToDecimal( txtPick.Text));
                    hash.Add("@decPannha", Convert.ToDecimal( txtPannha.Text));
                    hash.Add("@decTaga", Convert.ToDecimal(txtMtr.Text));
                    hash.Add("@decWeight",Convert.ToDecimal(  txtWeight.Text));
                    //hash.Add("@decCuts",  txtBeams.Text);
                    hash.Add("@decRate", Convert.ToDecimal( txtRate.Text));
                    hash.Add("@decGst", Convert.ToDecimal( txtGST.Text));
                    hash.Add("@dtpDeliveryPeriod", dtpDeliveryPeriod.Value.ToString("MM/dd/yyyy"));
                    hash.Add("@intPaymentDays", Convert.ToInt32( txtPaymentDate.Text));
                    hash.Add("@decWarf", Convert.ToDecimal( txtWarf.Text));
                    hash.Add("@decWeft", Convert.ToDecimal( txtWeft.Text));
                    hash.Add("@decBrokrage", Convert.ToDecimal( txtBrokrage.Text));

                    hash.Add("@decMeter",Convert.ToDecimal( txtMtr.Text));
                    hash.Add("@intBeam",Convert.ToInt32( txtBeams.Text));
                    hash.Add("@intTotalLoom",Convert.ToInt32( txtLooms.Text));
                    hash.Add("@decRateWithGst",Convert.ToDecimal( txtRateWithGST.Text));

                    //QualityName=,SatNo=
                    hash.Add("@strQualityName",txtQualityName.Text);
                    hash.Add("@strSatNo", txtShortYear.Text+txtSatNo.Text);
                }

                okflag = 1;



                return ClsDefination.InsertExecute(hash, "[Master_JobContract_DML]", ref strReturnMSG, ref strReturnNo, ref intReturnNo);


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


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (newOrEdit == 0)
            {
                if (isInward == 0)
                {
                    SaveData(1, ref strReturnMSG, ref strReturnRefNo, ref intReturnPKNo);
                }
                else
                {
                    SaveData(3, ref strReturnMSG, ref strReturnRefNo, ref intReturnPKNo);
                }
            }
            else
            {
                if (isInward == 0)
                {
                    SaveData(2, ref strReturnMSG, ref strReturnRefNo, ref intReturnPKNo);
                }
                else
                {
                    SaveData(4, ref strReturnMSG, ref strReturnRefNo, ref intReturnPKNo);
                }
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
                frm.messageTxt = "Please Select State";
                frm.type = "error";
                frm.ShowDialog();
            }
        }

        private void Transaction_JobContract_Load(object sender, EventArgs e)
        {
            FillGrid(201);
            FillGrid(202);
            FillGrid(203);
            FillGrid(204);

            if (isInward == 0)
            {
                txtContractNo.Enabled = false;
                txtContractNo.ReadOnly = true;
                txtBrokrage.Visible = false;
                lblOpeningBalance.Visible = false;
                dtpDate.Focus();
            }
            else
            {
                txtContractNo.Enabled = true;
                txtContractNo.ReadOnly = false;
                txtBrokrage.Visible = true;
                lblOpeningBalance.Visible = true;
                txtContractNo.Focus();
            }

            if (newOrEdit == 1)
            {
                cmbParty.SelectedValue = cmbPartyC;
                // cmbFirmName.SelectedValue = cmbFirmC;
                cmbBroker.SelectedValue = cmbBrokerC;
                cmbQuality.SelectedValue = cmbQualityC;
            }
            else
            {
                txtShortYear.Text = fd.ShortYear+"/";
            }
        }

        private void cmbQuality_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbQuality.SelectedIndex > -1)
            //{
            //   // FillGrid(301);
            //}
        }

        private void txtRate_Leave(object sender, EventArgs e)
        {
            gstClac();
        }

        public void gstClac()
        {
            try
            {
                txtRateWithGST.Text =
                    Math.Round((Convert.ToDecimal(txtRate.Text)+ ((Convert.ToDecimal(txtRate.Text)/100)*Convert.ToDecimal(txtGST.Text))),2 ).ToString();
            }
            catch (Exception ex)
            {
            }
        }

        private void txtGST_Leave(object sender, EventArgs e)
        {
            gstClac();
        }

        private void cmbQuality_Leave(object sender, EventArgs e)
        {
            if (cmbQuality.SelectedIndex > -1)
            {
                FillGrid(301);
            }
        }
    }
}
