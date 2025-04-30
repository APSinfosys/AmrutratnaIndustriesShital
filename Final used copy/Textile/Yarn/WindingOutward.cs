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
    public partial class WindingOutward : Form
    {
        public WindingOutward()
        {
            InitializeComponent();
        }


        #region variables
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        public string owner,kharadGetpass,color;
        public int cmbSTV, cmbPNV,cmbSUV,cmbSV,isFromKharad,cmbFV,cmbQV,cmbContractValue,cmbWindingParty;
        public decimal countV;
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

                if (QueryNo == 202 )
                {
                    hash.Add("@intToParty", cmbToParty.SelectedValue);
                }
                if (QueryNo == 204 || QueryNo == 301 || QueryNo == 302 || QueryNo == 303)
                {
                    hash.Add("@intSutType", cmbSutType.SelectedValue);
                }
                if (QueryNo == 301 || QueryNo == 302 || QueryNo == 303)
                {
                    hash.Add("@intShade",cmbShade.SelectedValue);
                }
                if (QueryNo == 302 || QueryNo == 303)
                {
                    hash.Add("@intSutUse", cmbWarfWeft.SelectedValue);
                }
                if (QueryNo == 303)
                {
                    hash.Add("@decCount",cmbCount.Text);
                }
                if (QueryNo == 209)
                {
        //            hash.Add("@intFirm",cmbFirm.SelectedValue);
                    hash.Add("@intToParty", cmbPartyName.SelectedValue);
                }

                dtReturn = ClsDefination.FillData("[WindingOutward_DML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 201)
                    {
                        cmbPartyName.DataSource = dtReturn;
                        cmbPartyName.ValueMember = "P_Code";
                        cmbPartyName.DisplayMember = "P_CompanyName";
                        cmbPartyName.SelectedIndex = -1;
                        cmbPartyName.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 202)
                    {
                        lblOwner.Text = objRow["P_OwnerName"].ToString();//dtReturn.Rows[0][0].ToString();
                        lblStateCode.Text = objRow["P_State"].ToString();//dtReturn.Rows[0][1].ToString();
                    }
                    else if (QueryNo == 203)
                    {
                        cmbSutType.DataSource = dtReturn;
                        cmbSutType.ValueMember = "S_Code";
                        cmbSutType.DisplayMember = "S_Name";
                        cmbSutType.SelectedIndex = -1;
                        cmbSutType.Text = "<--SELECT-->";
                    }

                    else if (QueryNo == 204)
                    {
                        cmbWarfWeft.DataSource = dtReturn;
                        cmbWarfWeft.ValueMember = "Common_Id";
                        cmbWarfWeft.DisplayMember = "Common_Value";
                        cmbWarfWeft.SelectedIndex = -1;
                        cmbWarfWeft.Text = "<--SELECT-->";
                        //,
                    }
                    else if (QueryNo == 205)
                    {
                        //ShadeCode
                        cmbShade.DataSource = dtReturn;
                        cmbShade.DisplayMember = "Shade";
                        cmbShade.ValueMember = "ShadeCode";
                        cmbShade.SelectedIndex = -1;
                        cmbShade.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 206)
                    {
                        // ,Q_Code,Q_Name
                        cmbQuality.DataSource = dtReturn;
                        cmbQuality.DisplayMember = "Q_Name";
                        cmbQuality.ValueMember = "Q_Code";
                        cmbQuality.SelectedIndex = -1;
                        cmbQuality.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 207)
                    {
                        // ,
                        cmbFirm.DataSource = dtReturn;
                        cmbFirm.DisplayMember = "F_CompanyName";
                        cmbFirm.ValueMember = "F_Code";
                        cmbFirm.SelectedIndex = -1;
                        cmbFirm.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 208)
                    {
                        cmbToParty.DataSource = dtReturn;
                        cmbToParty.DisplayMember = "P_CompanyName";
                        cmbToParty.ValueMember = "P_Code";
                        cmbToParty.SelectedIndex = -1;
                        cmbToParty.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 209)
                    {
                        cmbContract.DataSource = dtReturn;
                        cmbContract.DisplayMember = "NAME";
                        cmbContract.ValueMember = "CONTRACT NO";
                        cmbContract.SelectedIndex = -1;
                        cmbContract.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 301)
                    {
                        cmbWarfWeft.DataSource = dtReturn;
                        cmbWarfWeft.DisplayMember = "Common_Value";
                        cmbWarfWeft.ValueMember = "SutUse";
                        cmbWarfWeft.SelectedIndex = -1;
                        cmbWarfWeft.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 302)
                    {
                        cmbCount.DataSource = dtReturn;
                        cmbCount.DisplayMember = "Count";
                        cmbCount.ValueMember = "Count";
                        cmbCount.SelectedIndex = -1;
                        cmbCount.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 303)
                    {
                        cmbColor.DataSource = dtReturn;
                        cmbColor.DisplayMember = "Color";
                        cmbColor.ValueMember = "Color";
                        cmbColor.SelectedIndex = -1;
                        cmbColor.Text = "<--SELECT-->";
                    }
                }
                else
                {
                    if (QueryNo == 201)
                    {
                        cmbPartyName.DataSource = dtReturn;
                        cmbPartyName.SelectedIndex = -1;
                        cmbPartyName.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 202)
                    {
                        lblOwner.Text = "ERROR";
                        lblStateCode.Text = "ERROR";
                    }
                    else if (QueryNo == 203)
                    {
                        cmbSutType.DataSource = dtReturn;
                        cmbSutType.SelectedIndex = -1;
                        cmbSutType.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 204)
                    {
                        cmbWarfWeft.DataSource = dtReturn;
                        cmbWarfWeft.SelectedIndex = -1;
                        cmbWarfWeft.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 205)
                    {
                        //ShadeCode
                        cmbShade.DataSource = dtReturn;
                        cmbShade.SelectedIndex = -1;
                        cmbShade.Text = "<--NO REOCRD-->";
                    }
                    else if (QueryNo == 206)
                    {
                        // ,
                        cmbQuality.DataSource = dtReturn;
                        cmbQuality.SelectedIndex = -1;
                        cmbQuality.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 207)
                    {
                        // ,
                        cmbFirm.DataSource = dtReturn;
                        cmbFirm.SelectedIndex = -1;
                        cmbFirm.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 208)
                    {
                        cmbToParty.DataSource = dtReturn;
                        cmbToParty.SelectedIndex = -1;
                        cmbToParty.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 209)
                    {
                        cmbContract.DataSource = dtReturn;
                        cmbContract.SelectedIndex = -1;
                        cmbContract.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 301)
                    {
                        cmbWarfWeft.DataSource = dtReturn;
                        cmbWarfWeft.SelectedIndex = -1;
                        cmbWarfWeft.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 302)
                    {
                        cmbCount.DataSource = dtReturn;
                        cmbCount.SelectedIndex = -1;
                        cmbCount.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 303)
                    {
                        cmbColor.DataSource = dtReturn;
                        cmbColor.SelectedIndex = -1;
                        cmbColor.Text = "<--SELECT-->";
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
                        hash.Add("@intCode", Convert.ToInt32(lblSrNo.Text));
                    }

                    hash.Add("@strGetpass",txtGetpass.Text);
                    hash.Add("@dtpdate",dtpInvoiceDate.Value.ToString("MM/dd/yyyy"));
                    hash.Add("@intToParty",cmbPartyName.SelectedValue);
                    hash.Add("@strOwner",lblOwner.Text);
                    hash.Add("@intState",lblStateCode.Text);
                    hash.Add("@intSutType",cmbSutType.SelectedValue);
                    hash.Add("@intSutUse",cmbWarfWeft.SelectedValue);
                    hash.Add("@decCount",cmbCount.Text);
                    hash.Add("@decColor",cmbColor.Text);
                    hash.Add("@decGBag",txtGodawonBag.Text);
                    hash.Add("@decKBag",txtKarkhanaBag.Text);
                    hash.Add("@decTotalBag",lblTotalBag.Text);

                    hash.Add("@decGKon",txtGodawonKon.Text);
                    hash.Add("@decKKon",txtKarkhanaKon.Text);
                    hash.Add("@decTotalKon",lblTotalKon.Text);

                    hash.Add("@decGWeight",txtGodawonNWeight.Text);
                    hash.Add("@decKWeight",txtKarkhanaNWeight.Text);
                    hash.Add("@decTotalWeight",lblTotalWeight.Text);

                    hash.Add("@intShade", Convert.ToInt32(cmbShade.SelectedValue));

                    hash.Add("@decGrossWeight",Convert.ToDecimal(txtGrossWeight.Text));
                    hash.Add("@intFirm",cmbFirm.SelectedValue);
                    hash.Add("@strContractValue",cmbContract.Text);
                    hash.Add("@intContractNo",cmbContractValue);
                    hash.Add("@intQuality",cmbQuality.SelectedValue);
                    hash.Add("@strKharadGetpass",kharadGetpass);

                    hash.Add("@strLotNo", txtLotNo.Text);

                    hash.Add("@intWindingParty",Convert.ToInt32(cmbToParty.SelectedValue));
                    hash.Add("@strMillName",cmbMillName.Text);

  //                     as int=0,
  // as varchar(50)='',
  
            //        ,,@,,,,
            //@strUniqueCode)

                }

                okflag = 1;
                return ClsDefination.InsertExecute(hash, "[WindingOutward_DML]", ref strReturnMSG, ref strReturnNo, ref intReturnNo);
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


        private void WindingOutward_Load(object sender, EventArgs e)
        {
            FillGrid(201); // party
            FillGrid(203);// Sut
            FillGrid(204);// warf weft
            FillGrid(205);//shade
            FillGrid(206);// quality
            FillGrid(207); // firm
            FillGrid(208); // to party


            if (newOrEdit == 1 || isFromKharad==1)
            {
                cmbPartyName.SelectedValue = cmbPNV;
                cmbSutType.SelectedValue = cmbSTV;
                cmbWarfWeft.SelectedValue = cmbSUV; 
              //  cmbShade.Text
                cmbShade.SelectedValue = cmbSV;
                cmbQuality.SelectedValue = cmbQV;
                cmbWarfWeft.SelectedValue = cmbSUV;
                cmbFirm.SelectedValue = cmbFV;
                FillGrid(209);
                cmbContract.SelectedValue = cmbContractValue;
                cmbToParty.SelectedValue = cmbWindingParty;
            }


        }

        private void cmbPartyName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cmbPartyName.Text != "<--SELECT-->" || cmbPartyName.SelectedIndex > 0 || cmbPartyName.SelectedValue != "System.Data.DataRow")
                {
                    FillGrid(202);// get owner and state
                }
                else
                {
                    messageBox frm = new messageBox();
                    frm.messageTxt = "Please select PARTY";
                    frm.type = "error";
                    frm.ShowDialog();
                    cmbPartyName.Focus();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void cmbSutType_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cmbSutType.Text == "<--SELECT-->" || Convert.ToInt32(cmbSutType.SelectedValue) < 0 || cmbSutType.SelectedValue == "System.Data.DataRow")
                {
                    messageBox frm = new messageBox();
                    frm.messageTxt = "Please select SUT Type";
                    frm.type = "error";
                    frm.ShowDialog();
                    cmbSutType.Focus();
                }
                else
                {
                    FillGrid(301);

                    if (newOrEdit == 1 || isFromKharad == 1)
                    {
                        cmbWarfWeft.SelectedValue = cmbSUV;
                    }
                }

            }
            catch (Exception ex)
            {
            }

        }

        private void cmbWarfWeft_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cmbWarfWeft.Text == "<--SELECT-->" || cmbWarfWeft.SelectedIndex < 0 || cmbWarfWeft.SelectedValue == "System.Data.DataRow")
                {
                    messageBox frm = new messageBox();
                    frm.messageTxt = "Please select WARF / WEFT";
                    frm.type = "error";
                    frm.ShowDialog();
                    //        cmbWarfWeft.Focus();
                }
                else
                {
                    FillGrid(302);
                    
                    if (newOrEdit == 1 || isFromKharad == 1)
                    {
                        cmbCount.SelectedValue = countV;
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }


        public void totalBag()
        {
            if (txtGodawonBag.Text == "")
            {
                txtGodawonBag.Text = "0";
            }
            if (txtKarkhanaBag.Text == "")
            {
                txtKarkhanaBag.Text = "0";
            }

            lblTotalBag.Text = Math.Round(Convert.ToDecimal(txtGodawonBag.Text)+Convert.ToDecimal(txtKarkhanaBag.Text)).ToString();
        }

        private void txtGodawonBag_Leave(object sender, EventArgs e)
        {
            totalBag();
        }

        private void txtKarkhanaBag_Leave(object sender, EventArgs e)
        {
            totalBag();
        }


        public void totalKon()
        {
            if (txtGodawonKon.Text == "")
            {
                txtGodawonKon.Text = "0";
            }
            if (txtKarkhanaKon.Text == "")
            {
                txtKarkhanaKon.Text = "0";
            }

            lblTotalKon.Text = Math.Round(Convert.ToDecimal(txtGodawonKon.Text) + Convert.ToDecimal(txtKarkhanaKon.Text)).ToString();
        }
        private void txtGodawonKon_Leave(object sender, EventArgs e)
        {
            totalKon();
        }

        private void txtKarkhanaKon_Leave(object sender, EventArgs e)
        {
            totalKon();
        }

        public void totalWeight()
        {
            if (txtGodawonNWeight.Text == "")
            {
                txtGodawonNWeight.Text = "0";
            }
            if (txtKarkhanaNWeight.Text == "")
            {
                txtKarkhanaNWeight.Text = "0";
            }

            txtGrossWeight.Text= lblTotalWeight.Text = Math.Round(Convert.ToDecimal(txtGodawonNWeight.Text) + Convert.ToDecimal(txtKarkhanaNWeight.Text),2).ToString();
        }

        private void txtGodawonNWeight_Leave(object sender, EventArgs e)
        {
            totalWeight();
        }

        private void txtKarkhanaNWeight_Leave(object sender, EventArgs e)
        {
            totalWeight();
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
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbCount_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbCount.SelectedValue) > 0)
            {
                FillGrid(303);
                if (newOrEdit == 1 || isFromKharad == 1)
                {
                    cmbColor.Text = color;
                }
            }
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please Select Count";
                frm.type = "error";
                frm.ShowDialog();
            }
        }

        private void cmbColor_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbColor.SelectedIndex)<=-1)
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please Select Color";
                frm.type = "error";
                frm.ShowDialog();
            
            }
        }

        private void cmbToParty_Leave(object sender, EventArgs e)
        {
            try
            {
                if ( cmbPartyName.SelectedIndex > -1 )
                {
                    FillGrid(202);// get owner and state
                }
                else
                {
                    messageBox frm = new messageBox();
                    frm.messageTxt = "Please select party";
                    frm.type = "error";
                    frm.ShowDialog();
                    cmbToParty.Focus();
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
