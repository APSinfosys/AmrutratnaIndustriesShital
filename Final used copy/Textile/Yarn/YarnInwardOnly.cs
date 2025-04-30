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
    public partial class YarnInwardOnly : Form
    {
        public YarnInwardOnly()
        {
            InitializeComponent();
        }


        #region variables
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        public string owner;
        public int cmbSTV, cmbPNV,cmbSV,cmbQV,cmbCV,singlePage;
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
                hash.Add("@intcompanyId", fd.CompId);

                if (QueryNo == 202 || QueryNo == 212)
                {
                    hash.Add("@intFromParty", cmbPartyName.SelectedValue);
                }
                if (QueryNo == 204)
                {
                    hash.Add("@intSutType", cmbSutType.SelectedValue);
                }
                if (QueryNo == 211 )//|| QueryNo == 213)
                {
                    hash.Add("@strContract", cmbContract.SelectedValue);
                }
                if (QueryNo == 213 || QueryNo == 215)
                {
                    hash.Add("@intContractNo",cmbContract.SelectedValue);
                }
                if (QueryNo == 214 || QueryNo == 301 || QueryNo == 302)
                {
                    hash.Add("@intQuality",cmbQuality.SelectedValue);
                }

                if (QueryNo == 301 || QueryNo == 302)
                {
                    hash.Add("@intYarnGroup", cmbSutType.SelectedValue);
                }

                dtReturn = ClsDefination.FillData("[YarnInward_DML]", hash);


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
                        //if (lblStateCode.Text == fd.StateId.ToString())
                        //{
                        //    txtCgPer.Text = objRow["S_CGST"].ToString();//dtReturn.Rows[0][0].ToString();
                        //    txtSgPer.Text = objRow["S_SGST"].ToString();//dtReturn.Rows[0][1].ToString();
                        //    txtIgPer.Text = "0.00";
                        //    //  ,,
                        //}
                        //else
                        //{
                        //    txtCgPer.Text = "0.00";
                        //    txtSgPer.Text = "0.00";
                        //    txtIgPer.Text = objRow["S_IGST"].ToString();//dtReturn.Rows[0][2].ToString();
                        //}
                    }
                    else if (QueryNo == 205)
                    {
                        cmbWarfWeft.DataSource = dtReturn;
                        cmbWarfWeft.ValueMember = "Common_Id";
                        cmbWarfWeft.DisplayMember = "Common_Value";
                        cmbWarfWeft.SelectedIndex = -1;
                        cmbWarfWeft.Text = "<--SELECT-->";
                        //,
                    }
                    else if (QueryNo == 206)
                    {
                        cmbPkgType.DataSource = dtReturn;
                        cmbPkgType.ValueMember = "Common_Id";
                        cmbPkgType.DisplayMember = "Common_Value";
                        cmbPkgType.SelectedIndex = -1;
                        cmbPkgType.Text = "<--SELECT-->";
                        //,
                    }
                    else if (QueryNo == 207)
                    {
                        cmbShade.DataSource = dtReturn;
                        cmbShade.DisplayMember = "Shade";
                        cmbShade.ValueMember = "ShadeCode";
                        cmbShade.SelectedIndex = -1;
                        cmbShade.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 208)
                    {
                        
                        cmbQuality.DataSource = dtReturn;
                        cmbQuality.DisplayMember = "Q_Name";
                        cmbQuality.ValueMember = "Q_Code";
                        cmbQuality.SelectedIndex = -1;
                        cmbQuality.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 215)
                    {

                        cmbQuality.DataSource = dtReturn;
                        cmbQuality.DisplayMember = "DesignName";
                        cmbQuality.ValueMember = "Q_Code";
                        cmbQuality.SelectedIndex = -1;
                        cmbQuality.Text = "<--SELECT-->";

                    }
                    else if (QueryNo == 212)
                    {
                        //Common_Id as [ContractNo],Common_Value as [ContractNoV]
                     
                        cmbContract.DataSource = dtReturn;
                        cmbContract.DisplayMember = "ContractNoV";
                        cmbContract.ValueMember = "ContractNo";
                        cmbContract.SelectedIndex = -1;
                        cmbContract.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 211)
                    {
                        //,
                        txtCount.Text = objRow["count"].ToString();
                        cmbSutType.SelectedValue = Convert.ToInt32(objRow["yarnCode"].ToString());
                    }
                    else if (QueryNo == 213)
                    {
                        //cmbQuality.SelectedValue = Convert.ToInt32(objRow["qualityCode"].ToString());
                        //cmbQuality.Enabled = false;
                        //if (Convert.ToInt32(cmbQuality.SelectedValue) == 0)
                        //{
                        //    cmbQuality.Enabled = true;

                        //}

                        lblQuality.Text = objRow["QualityName"].ToString();

                        //FillGrid(214);
                        //cmbSutType.Focus();
                    }
                    else if (QueryNo == 214)
                    {
                        cmbSutType.DataSource = dtReturn;
                        cmbSutType.DisplayMember = "NAME";
                        cmbSutType.ValueMember = "code";
                        cmbSutType.SelectedIndex = -1;
                        cmbSutType.Text = "<--SELECT-->";
                    }

                    else if (QueryNo == 301 || QueryNo == 302)
                    {
                        cmbCount.DataSource = dtReturn;
                        cmbCount.DisplayMember = "COUNT";
                        cmbCount.SelectedIndex = -1;
                        cmbCount.Text = "<SELECT>";
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
                    else if (QueryNo == 205)
                    {
                        cmbWarfWeft.DataSource = dtReturn;
                        cmbWarfWeft.SelectedIndex = -1;
                        cmbWarfWeft.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 206)
                    {
                        cmbPkgType.DataSource = dtReturn;
                        cmbPkgType.SelectedIndex = -1;
                        cmbPkgType.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 207)
                    {
                        cmbShade.DataSource = dtReturn;
                        cmbShade.SelectedIndex = -1;
                        cmbShade.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 208)
                    {
                        cmbQuality.DataSource = dtReturn;
                        cmbQuality.SelectedIndex = -1;
                        cmbQuality.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 210 || QueryNo == 212)
                    {
                        cmbContract.DataSource = dtReturn;
                        cmbContract.SelectedIndex = -1;
                        cmbContract.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 213)
                    {
                        cmbQuality.Enabled = true;
                        cmbQuality.SelectedIndex = -1;
                        cmbQuality.Text = "<--SELECT-->";
                        FillGrid(203);
                        cmbQuality.Focus();
                    }
                    else if (QueryNo == 215)
                    {

                        cmbQuality.DataSource = dtReturn;
                        cmbQuality.SelectedIndex = -1;
                        cmbQuality.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 301 || QueryNo == 302)
                    {
                        cmbCount.DataSource = dtReturn;
                        cmbCount.SelectedIndex = -1;
                        cmbCount.Text = "<NO RECORD>";
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
                hash.Add("@intcreatedBy", Convert.ToInt32(fd.UserId));
                hash.Add("@intcompanyId", Convert.ToInt32(fd.CompId));
                hash.Add("@inryearId", Convert.ToInt32(fd.YearId));

                if (QueryNo == 1 || QueryNo == 2)
                {

                    if (QueryNo == 2)
                    {
                        hash.Add("@strUniqueCode",lblUniqueCode.Text);
                        hash.Add("@intCode", Convert.ToInt32(lblSrNo.Text));
                    }
                    
                    hash.Add("@strInvoiceNo", txtInvoiceNo.Text);
                    hash.Add("@strGetpassNo", txtGetpass.Text);
                    hash.Add("@dtInvoiceDate", dtpInvoiceDate.Value.ToString("MM/dd/yyyy"));
                    hash.Add("@intFromParty", Convert.ToInt32(cmbPartyName.SelectedValue));
                    hash.Add("@intPartyState", lblStateCode.Text);
                    hash.Add("@strOwner", lblOwner.Text);

                    hash.Add("@intSutType", Convert.ToInt32(cmbSutType.SelectedValue));
                    hash.Add("@intSutUse", Convert.ToInt32(cmbWarfWeft.SelectedValue));
                    hash.Add("@decCount", Convert.ToDecimal(txtCount.Text));

                    hash.Add("@strColor", txtColor.Text.ToUpper());
                    hash.Add("@decGodawonQty", txtGodawonBag.Text);
                    hash.Add("@decKarkhanaQty", txtKarkhanaBag.Text);
                    hash.Add("@decTotBagQty", Convert.ToDecimal(lblTotalBag.Text));

                    hash.Add("@decGodawonKon", txtGodawonKon.Text);
                    hash.Add("@decKarkhanaKon", txtKarkhanaKon.Text);
                    hash.Add("@decTotalKon", lblTotalKon.Text);


                    hash.Add("@decGodawonNWeight", txtGodawonNWeight.Text);
                    hash.Add("@decKarkahanNWeight", txtKarkhanaNWeight.Text);
                    hash.Add("@decTotalNWeight", lblTotalWeight.Text);
                    hash.Add("@decGWeight", txtGrossWeight.Text);


                    hash.Add("@intPacking", cmbPkgType.SelectedValue);

                    hash.Add("@intShade", Convert.ToInt32(cmbShade.SelectedValue));
                    hash.Add("@intQuality", Convert.ToInt32(cmbQuality.SelectedValue));
                    hash.Add("@intIsTaxable", 0);
                  //  hash.Add("@intInwardOnly", 1);
                   // hash.Add("@intQuality", Convert.ToInt32(cmbQuality.SelectedValue));
                    hash.Add("@intContractNo",Convert.ToInt32(cmbContract.SelectedValue));
                    hash.Add("@strContract", cmbContract.Text);

                    hash.Add("@strMill",txtMillName.Text);

                }

                okflag = 1;
                return ClsDefination.InsertExecute(hash, "[YarnInward_DML]", ref strReturnMSG, ref strReturnNo, ref intReturnNo);
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

        private void YarnInwardOnly_Load(object sender, EventArgs e)
        {
            FillGrid(206);// fill packing
            FillGrid(205);// sut use
            FillGrid(203);// sut typr
            FillGrid(201);// fill party
            FillGrid(207);// shade
            FillGrid(208); // quality

            if (singlePage == 1)
            {
                cmbPartyName.SelectedValue = cmbPNV;
                cmbPartyName.Enabled = false;
                FillGrid(202);// get owner and state
                FillGrid(212);// contract
                cmbContract.SelectedValue = cmbCV;
                cmbContract.Enabled = false;
               // FillGrid(213);// get quality  
                FillGrid(215); // get design
               cmbQuality.SelectedValue = cmbQV;

            }

            if (newOrEdit == 1)
            {
                cmbPartyName.SelectedValue = cmbPNV;
                cmbSutType.SelectedValue = cmbSTV;
                cmbWarfWeft.SelectedValue = lblWarfWeft.Text;
                cmbPkgType.SelectedValue = lblPAkgType.Text;
                cmbShade.SelectedValue = cmbSV;
                FillGrid(212);
                cmbContract.SelectedValue = cmbCV;
                FillGrid(215);
                cmbQuality.SelectedValue = cmbQV;
                
            }
        }

        private void cmbPartyName_Leave(object sender, EventArgs e)
        {
            if (cmbPartyName.Text != "<--SELECT-->" || cmbPartyName.SelectedIndex > 0 || cmbPartyName.SelectedValue != "System.Data.DataRow")
            {
                if (singlePage != 1)
                {
                    FillGrid(202);// get owner and state
                    FillGrid(212);// contract
                    if (newOrEdit == 1)
                    {
                        cmbContract.SelectedValue = cmbCV;
                    }
                }
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

        private void cmbSutType_Leave(object sender, EventArgs e)
        {
            if (cmbSutType.Text != "<--SELECT-->" || cmbSutType.SelectedIndex > 0 || cmbSutType.SelectedValue != "System.Data.DataRow")
            {
                FillGrid(204);// get gst per
                // financeCalc();
            }
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please select SUT Type";
                frm.type = "error";
                frm.ShowDialog();
                cmbSutType.Focus();
            }
        }

        public void stockCalc()
        {
            lblTotalBag.Text =
                Math.Round((Convert.ToDecimal(txtGodawonBag.Text) + Convert.ToDecimal(txtKarkhanaBag.Text)), 2).ToString();
        }

        private void txtGodawonBag_Leave(object sender, EventArgs e)
        {
            stockCalc();
        }

        private void txtKarkhanaBag_Leave(object sender, EventArgs e)
        {
            stockCalc();
        }

        private void cmbWarfWeft_Leave(object sender, EventArgs e)
        {
            // 42 WARF 43 WEFT
            if (cmbWarfWeft.SelectedIndex < 0)
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please select WARF / WEFT";
                frm.type = "error";
                frm.ShowDialog();
                cmbWarfWeft.Focus();
            }
            else
            {
                if (Convert.ToInt32(cmbWarfWeft.SelectedValue) == 42)
                {
                    FillGrid(301);
                }
                else
                {
                    FillGrid(302);
                }

            }

        }

        private void cmbPkgType_Leave(object sender, EventArgs e)
        {
            if (cmbPkgType.Text == "<--SELECT-->" || cmbPkgType.SelectedIndex < 0 || cmbPkgType.SelectedValue == "System.Data.DataRow")
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please select Packing";
                frm.type = "error";
                frm.ShowDialog();
                cmbPkgType.Focus();
            }
        }

        private void txtGodawonKon_Leave(object sender, EventArgs e)
        {
            lblTotalKon.Text =
               Math.Round(Convert.ToDecimal(txtGodawonKon.Text) + Convert.ToDecimal(txtKarkhanaKon.Text), 2).ToString();
        }

        private void txtKarkhanaKon_Leave(object sender, EventArgs e)
        {
            lblTotalKon.Text =
               Math.Round(Convert.ToDecimal(txtGodawonKon.Text) + Convert.ToDecimal(txtKarkhanaKon.Text), 2).ToString();
        }

        private void txtGodawonNWeight_Leave(object sender, EventArgs e)
        {
            lblTotalWeight.Text =
               Math.Round(Convert.ToDecimal(txtGodawonNWeight.Text) + Convert.ToDecimal(txtKarkhanaNWeight.Text), 2).ToString();
        }

        private void txtKarkhanaNWeight_Leave(object sender, EventArgs e)
        {
            lblTotalWeight.Text =
               Math.Round(Convert.ToDecimal(txtGodawonNWeight.Text) + Convert.ToDecimal(txtKarkhanaNWeight.Text), 2).ToString();
        }

        private void cmbContract_Leave(object sender, EventArgs e)
        {
            if (cmbContract.SelectedIndex > -1)
            {
                if (singlePage != 1)
                {
                    //FillGrid(211);
                    if (Convert.ToInt32(cmbContract.SelectedValue) != 0)
                    {
                        FillGrid(213);// get quality
                        FillGrid(215); // fill design
                    }


                    if (newOrEdit == 1)
                    {
                        cmbQuality.SelectedValue = cmbQV;
                    }
                }
            }
        }

        private void cmbQuality_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbCount_Leave(object sender, EventArgs e)
        {
            if (cmbCount.SelectedIndex > -1)
            {
                txtCount.Text = cmbCount.Text;
            }
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please select count";
                frm.type = "error";
                frm.ShowDialog();
                cmbCount.Focus();
            }
        }

        private void cmbQuality_Leave(object sender, EventArgs e)
        {
            //FillGrid(214);
            //cmbSutType.Focus();

            if (cmbQuality.SelectedIndex > -1)
            {
                FillGrid(214);

                if (newOrEdit == 1)
                {
                    cmbSutType.SelectedValue = cmbSTV;
                }
            }
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please select design";
                frm.type = "error";
                frm.ShowDialog();
                cmbCount.Focus();
            }

        }

        private void txtInvoiceNo_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
