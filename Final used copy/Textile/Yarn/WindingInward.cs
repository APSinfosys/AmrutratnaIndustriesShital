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

namespace Textile.Yarn
{
    public partial class WindingInward : Form
    {
        public WindingInward()
        {
            InitializeComponent();
        }

        #region variables
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        public string owner;
        public int cmbOGNV, cmbPNV,cmbSV,cmbFV,cmbCV,cmbQV;
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
                hash.Add("@intYearId",fd.YearId);


                if (QueryNo == 202 || QueryNo == 301 || QueryNo == 601 || QueryNo == 602)
                {
                    hash.Add("@intFromParty", cmbPartyName.SelectedValue);
                }
                if (QueryNo == 302)
                {
                    hash.Add("@intCode", cmbOutWardGetpass.SelectedValue);
                }
                if (QueryNo == 301 || QueryNo == 302 || QueryNo == 401 || QueryNo == 601 || QueryNo == 602)
                {
                    hash.Add("@intShade",Convert.ToInt32(cmbShade.SelectedValue));
                }
                if (QueryNo == 601 || QueryNo == 301 || QueryNo == 602 || QueryNo == 201)
                {
                    hash.Add("@intFirm",Convert.ToInt32(cmbFirm.SelectedValue));
                }


                dtReturn = ClsDefination.FillData("[WindingInward_DML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 201)
                    {
                        cmbPartyName.DataSource = dtReturn;
                        cmbPartyName.DisplayMember = "P_CompanyName";
                        cmbPartyName.ValueMember = "P_Code";
                        cmbPartyName.SelectedIndex = -1;
                        cmbPartyName.Text = "<--SELECT-->";

                    }
                    else if (QueryNo == 202)
                    {
                        lblOwner.Text = objRow["P_OwnerName"].ToString();
                        lblStateCode.Text = objRow["P_State"].ToString();
                    }
                    else if (QueryNo == 301 || QueryNo == 401 ||  QueryNo == 602)
                    {
                        cmbOutWardGetpass.DataSource = dtReturn;
                        cmbOutWardGetpass.DisplayMember = "WO_GetpassNo";
                        cmbOutWardGetpass.ValueMember = "WO_Code";
                        cmbOutWardGetpass.SelectedIndex = -1;
                        cmbOutWardGetpass.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 302)
                    {
            //select WO.WO_SutType as [Sut Type],MS.S_Name as [Sut Name],WO.WO_SutUse as [Sut Use],
            //CV.Common_Value as [Sut Use Name],WO.WO_Count as [Count],
            //       WO.WO_Color as [COLOR],WO.WO_TotalKon as [Tot KOn],WO.WO_TotalWeight as [Tot Weight]

                        lblSutNameWarfWeft.Text = objRow["Sut Name"].ToString() + " - " + objRow["Sut Use Name"].ToString();
                        lblSutCode.Text = objRow["Sut Type"].ToString();
                        lblWarfWeftCode.Text = objRow["Sut Use"].ToString();
                        lblCountValue.Text = objRow["Count"].ToString();
                        lblColorValue.Text = objRow["COLOR"].ToString();
                        lblOutwardTotalKon.Text = objRow["Tot KOn"].ToString();
                        lblTotalOutwardWeight.Text = objRow["Tot Weight"].ToString();
                        dtpOutWardDate.Text = objRow["DATE"].ToString();
                        lblMillName.Text = objRow["MillName"].ToString();
                    }
                    else if (QueryNo == 203)
                    {
                        cmbShade.DataSource = dtReturn;
                        cmbShade.DisplayMember = "Shade";
                        cmbShade.ValueMember = "ShadeCode";
                        cmbShade.SelectedIndex = -1;
                        cmbShade.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 501)
                    {
                        cmbFirm.DataSource = dtReturn;
                        cmbFirm.DisplayMember = "F_CompanyName";
                        cmbFirm.ValueMember = "F_Code";
                        cmbFirm.SelectedIndex = -1;
                        cmbFirm.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 502)
                    {
                        cmbQuality.DataSource = dtReturn;
                        cmbQuality.DisplayMember = "Q_Name";
                        cmbQuality.ValueMember = "Q_Code";
                        cmbQuality.SelectedIndex = -1;
                        cmbQuality.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 503)
                    {
                        cmbContract.DataSource = dtReturn;
                        cmbContract.DisplayMember = "contractNoV";
                        cmbContract.ValueMember = "contractNo";
                        cmbContract.SelectedIndex = -1;
                        cmbContract.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 601)
                    {
                       
                        //contractCode,quality,WO_Code
                        cmbContract.SelectedValue = Convert.ToInt32(objRow["contractCode"].ToString());
                        cmbQuality.SelectedValue= Convert.ToInt32(objRow["quality"].ToString());
                       // cmbOutWardGetpass.SelectedValue = Convert.ToInt32(objRow["WO_Code"].ToString());
                    }
                }
                else
                {
                    if (QueryNo == 201)
                    {
                        cmbPartyName.DataSource = null;
                        cmbPartyName.SelectedIndex = -1;
                        cmbPartyName.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 202)
                    {
                        lblOwner.Text = "NO NAME FOUND";
                        lblStateCode.Text = "0";
                    }
                    else if (QueryNo == 301 || QueryNo == 602)
                    {
                        cmbOutWardGetpass.DataSource = null;
                        cmbOutWardGetpass.SelectedIndex = -1;
                        cmbOutWardGetpass.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 302)
                    {

                        lblSutNameWarfWeft.Text = "NO RECORD FOUND " + " NO RECORD FOUND";
                        lblSutCode.Text = "0";
                        lblWarfWeftCode.Text = "0";
                        lblCountValue.Text = "0";
                        lblColorValue.Text = "N/A";
                        lblOutwardTotalKon.Text = "0";
                        lblTotalOutwardWeight.Text = "0";
                    }
                    else if (QueryNo == 203)
                    {
                        cmbShade.DataSource = dtReturn;
                        cmbShade.SelectedIndex = -1;
                        cmbShade.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 501)
                    {
                        cmbFirm.DataSource = dtReturn;
                        cmbFirm.SelectedIndex = -1;
                        cmbFirm.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 502)
                    {
                        cmbQuality.DataSource = dtReturn;
                        cmbQuality.SelectedIndex = -1;
                        cmbQuality.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 503)
                    {
                        cmbContract.DataSource = dtReturn;
                        cmbContract.SelectedIndex = -1;
                        cmbContract.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 601)
                    {
                        //contractCode,quality,WO_Code
                    
                        cmbContract.SelectedIndex = -1;
                        cmbContract.Text = "<--NO RECORD-->";

                        cmbQuality.SelectedIndex = -1;
                        cmbQuality.Text = "<--NO RECORD-->";

                        //cmbOutWardGetpass.SelectedIndex = -1;
                        //cmbOutWardGetpass.Text = "<--NO RECORD-->";

                        //cmbContract.SelectedValue = Convert.ToInt32(objRow["contractCode"].ToString());
                        //cmbQuality.SelectedValue= Convert.ToInt32(objRow["quality"].ToString());
                        //cmbOutWardGetpass.SelectedValue = Convert.ToInt32(objRow["WO_Code"].ToString());
                    
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
                hash.Add("@intCreatedBy", Convert.ToInt32(fd.UserId));
                hash.Add("@intCompanyId", Convert.ToInt32(fd.CompId));
                hash.Add("@intYearId", Convert.ToInt32(fd.YearId));

                if (QueryNo == 1 || QueryNo == 2)
                {

                    if (QueryNo == 2)
                    {
                        hash.Add("@strUniqueCode", lblUniqueCode.Text);
                        hash.Add("@intCode", lblSrNo.Text);
                    }

                    hash.Add("@strGetpas",txtGetpass.Text);
                    hash.Add("@dtpInwardDate",dtpInvoiceDate.Value.ToString("MM/dd/yyyy"));
                    hash.Add("@intWOGetpass",cmbOutWardGetpass.SelectedValue);
                    hash.Add("@strWOGetpassValue",cmbOutWardGetpass.Text);
                    hash.Add("@dtWODate",dtpOutWardDate.Value.ToString("MM/dd/yyyy"));
                    hash.Add("@intFromParty",cmbPartyName.SelectedValue);
                    hash.Add("@strFromParty",cmbPartyName.Text);
                    hash.Add("@strOwner",lblOwner.Text);
                    hash.Add("@intState",lblStateCode.Text);
                    hash.Add("@intSutType",lblSutCode.Text);
                    hash.Add("@intSutUse",lblWarfWeftCode.Text);
                    hash.Add("@decCount",lblCountValue.Text);
                    hash.Add("@strColor",lblColorValue.Text);
                    hash.Add("@decWOTotalKon",lblOutwardTotalKon.Text);
                    hash.Add("@decWOWeight",lblTotalOutwardWeight.Text);

                    hash.Add("@decGBag",txtGodawonBag.Text);
                    hash.Add("@decKBag",txtKarkhanaBag.Text);
                    hash.Add("@decTotalBag",lblTotalBag.Text);

                    hash.Add("@decGKon",txtGodawonKon.Text);
                    hash.Add("@decKKon",txtKarkhanaKon.Text);
                    hash.Add("@decTotalKon",lblTotalKon.Text);

                    hash.Add("@decGWeight",txtGodawonNWeight.Text);
                    hash.Add("@decKWeight",txtKarkhanaNWeight.Text);
                    hash.Add("@decTotalWeight",lblTotalWeight.Text);

                    hash.Add("@decEGKon",txtGodawonEmptyKon.Text);
                    hash.Add("@decEKKon",txtKarkahanEmptyKon.Text);
                    hash.Add("@decEtotalKon",lblTotalEmptyKon.Text);

                    hash.Add("@decEGWeight",txtGodawonEmptyWeight.Text);
                    hash.Add("@decEKWeight",txtEmptyKonKarkhanaWeight.Text);
                    hash.Add("@decETotalWeight",lblTotalEmptyWeight.Text);

                    hash.Add("@decTotalMixKon",lblTotalMixKon.Text);

                    hash.Add("@decWestage",txtWestage.Text);
                    hash.Add("@decRedusedWeight",lblReduedWeight.Text);

                    hash.Add("@intShade", Convert.ToInt32(cmbShade.SelectedValue));

                    hash.Add("@intFirm",Convert.ToInt32(cmbFirm.SelectedValue));
                    hash.Add("@intQuality",Convert.ToInt32(cmbQuality.SelectedValue));
                    hash.Add("@intContraact",Convert.ToInt32(cmbContract.SelectedValue));
                    hash.Add("@strContractValue",cmbContract.Text);

                    hash.Add("@strMill", lblMillName.Text);

                }

                okflag = 1;
                return ClsDefination.InsertExecute(hash, "[WindingInward_DML]", ref strReturnMSG, ref strReturnNo, ref intReturnNo);
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
            try
            {
                //if (Convert.ToDecimal(lblOutwardTotalKon.Text) == Convert.ToDecimal( lblTotalMixKon.Text))
                //{

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
                        messageBox frm = new messageBox();
                        if (newOrEdit == 0)
                        {
                            frm.messageTxt = "Rocord Saved Successfully: " + strReturnMSG;
                        }
                        else
                        {
                            frm.messageTxt = "Rocord Updated Successfully: " + strReturnMSG;
                        }
                        frm.type = "success";
                        frm.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        messageBox frm = new messageBox();
                        frm.messageTxt = strReturnMSG;
                        frm.type = "error";
                        frm.ShowDialog();
                    }


                //}
                //else
                //{
                //    messageBox frm = new messageBox();
                //    frm.messageTxt = "Please kon value you have enterd";
                //    frm.type = "error";
                //    frm.ShowDialog();
                //}
            }
            catch (Exception ex)
            {
            }
        }

        private void WindingInward_Load(object sender, EventArgs e)
        {
           // FillGrid(201);
            FillGrid(203);
            FillGrid(401);

            FillGrid(501);
           // FillGrid(502);
           // FillGrid(503);
            if (newOrEdit == 1)
            {
                cmbShade.SelectedValue = cmbSV;
                cmbFirm.SelectedValue = cmbFV;

                cmbPartyName.SelectedValue = cmbPNV;
               // FillGrid(601);
                FillGrid(602);
                cmbOutWardGetpass.SelectedValue = cmbOGNV;
                
                cmbContract.SelectedValue = cmbCV;
                cmbQuality.SelectedValue = cmbQV;

            }
        }


        public void bagTotal()
        {
            if (txtGodawonBag.Text == "")
            {
                txtGodawonBag.Text = "0";
            }
            if (txtKarkhanaBag.Text == "")
            {
                txtKarkhanaBag.Text = "0";
            }
            lblTotalBag.Text =
                Math.Round(Convert.ToDecimal(txtGodawonBag.Text) + Convert.ToDecimal(txtKarkhanaBag.Text)).ToString();

        }

        private void txtGodawonBag_Leave(object sender, EventArgs e)
        {
            bagTotal();
        }

        private void txtKarkhanaBag_Leave(object sender, EventArgs e)
        {
            bagTotal();
        }

        public void konTotal()
        {
            if (txtGodawonKon.Text == "")
            {
                txtGodawonKon.Text = "0";
            }
            if (txtKarkhanaKon.Text == "")
            {
                txtKarkhanaKon.Text = "0";
            }
            if (txtGodawonEmptyKon.Text == "")
            {
                txtGodawonEmptyKon.Text = "0";
            }
            if (txtKarkahanEmptyKon.Text == "")
            {
                txtKarkahanEmptyKon.Text = "0";
            }

            lblTotalKon.Text = Math.Round(Convert.ToDecimal(txtGodawonKon.Text) + Convert.ToDecimal(txtKarkhanaKon.Text)).ToString();

            lblTotalEmptyKon.Text = Math.Round(Convert.ToDecimal(txtGodawonEmptyKon.Text) + Convert.ToDecimal(txtKarkahanEmptyKon.Text)).ToString();

            lblTotalMixKon.Text = Math.Round(Convert.ToDecimal(lblTotalKon.Text) + Convert.ToDecimal(lblTotalEmptyKon.Text)).ToString();
        }

        private void txtGodawonKon_Leave(object sender, EventArgs e)
        {
            konTotal();
        }

        private void txtKarkhanaKon_Leave(object sender, EventArgs e)
        {
            konTotal();
        }

        private void txtGodawonEmptyKon_Leave(object sender, EventArgs e)
        {
            konTotal();
        }

        private void txtKarkahanEmptyKon_Leave(object sender, EventArgs e)
        {
            konTotal();
        }

        public void weight()
        {
            if (txtGodawonNWeight.Text == "")
            {
                txtGodawonNWeight.Text = "0";
            }
            if (txtKarkhanaNWeight.Text == "")
            {
                txtKarkhanaNWeight.Text = "0";
            }
            if (txtGodawonEmptyWeight.Text == "")
            {
                txtGodawonEmptyWeight.Text = "0";
            }
            if (txtEmptyKonKarkhanaWeight.Text == "")
            {
                txtEmptyKonKarkhanaWeight.Text = "0";
            }
            if (txtWestage.Text == "")
            {
                txtWestage.Text = "0";
            }

            lblTotalWeight.Text =
                Math.Round(Convert.ToDecimal(txtGodawonNWeight.Text) + Convert.ToDecimal(txtKarkhanaNWeight.Text), 2).ToString();

            lblTotalEmptyWeight.Text =
                Math.Round(Convert.ToDecimal(txtGodawonEmptyWeight.Text) + Convert.ToDecimal(txtEmptyKonKarkhanaWeight.Text), 2).ToString();

            lblReduedWeight.Text =
                Math.Round(Convert.ToDecimal(lblTotalOutwardWeight.Text) - (Convert.ToDecimal(lblTotalWeight.Text) + Convert.ToDecimal(lblTotalEmptyWeight.Text)
                           + Convert.ToDecimal(txtWestage.Text)), 2).ToString();
        }

        private void txtGodawonNWeight_Leave(object sender, EventArgs e)
        {
            weight();
        }

        private void txtKarkhanaNWeight_Leave(object sender, EventArgs e)
        {
            weight();
        }
     
        private void txtGodawonEmptyWeight_Leave(object sender, EventArgs e)
        {
            weight();
        }

        private void txtEmptyKonKarkhanaWeight_Leave(object sender, EventArgs e)
        {
            weight();
        }

        private void txtWestage_Leave(object sender, EventArgs e)
        {
            weight();
        }

        private void cmbPartyName_Leave(object sender, EventArgs e)
        {
            try
            {
                //if (cmbPartyName.Text != "<--SELECT-->" || cmbPartyName.SelectedIndex > 0 || cmbPartyName.SelectedValue != "System.Data.DataRow")
                //{
                //    FillGrid(202);// get owner and state
                //    if (newOrEdit == 0)
                //    {
                //        FillGrid(301);
                //    }
                //    else
                //    {
                //        FillGrid(401);
                //        cmbOutWardGetpass.SelectedValue = cmbOGNV;
                //    }
                //}
                //else
                //{
                //    messageBox frm = new messageBox();
                //    frm.messageTxt = "Please select PARTY";
                //    frm.type = "error";
                //    frm.ShowDialog();
                //    cmbPartyName.Focus();
                //}

                if (cmbPartyName.SelectedIndex > -1)
                {
                    FillGrid(503);
                    FillGrid(502);

                    FillGrid(202);// get owner and state
                    FillGrid(601); // get qualit contract 
                    FillGrid(301); //getpass

                    if (newOrEdit == 1)
                    {
                        FillGrid(602);
                        cmbContract.SelectedValue = cmbCV;
                        cmbQuality.SelectedValue = cmbQV;
                        cmbOutWardGetpass.SelectedValue = cmbOGNV;
                    }
                }
                else
                {
                    messageBox frm = new messageBox();
                    frm.messageTxt = "Please select party";
                    frm.type = "error";
                    frm.ShowDialog();
                   // cmbPartyName.Focus();
                }

            }
            catch (Exception ex)
            {
            }
        }

        private void cmbOutWardGetpass_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cmbOutWardGetpass.Text != "<--SELECT-->" || cmbOutWardGetpass.Text != "" || cmbOutWardGetpass.SelectedIndex > -1 || cmbOutWardGetpass.SelectedValue != "System.Data.DataRow")
                {
                   
                    FillGrid(302);
                }
                else
                {
                    messageBox frm = new messageBox();
                    frm.messageTxt = "Please select GETPASS";
                    frm.type = "error";
                    frm.ShowDialog();
                    cmbOutWardGetpass.Focus();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void cmbShade_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbShade.SelectedValue) < 0 || cmbShade.SelectedValue == null || cmbShade.Text == "<--NO RECORD-->")
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please select shade";
                frm.type = "error";
                frm.ShowDialog();
               // cmbPartyName.Focus();
             
            }
        }

        private void cmbShade_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbFirm_Leave(object sender, EventArgs e)
        {
            if (cmbFirm.SelectedIndex > -1)
            {
                FillGrid(201);
            }
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please select firm";
                frm.type = "error";
                frm.ShowDialog();
                cmbFirm.Focus();
             
            }
        }

    }
}
