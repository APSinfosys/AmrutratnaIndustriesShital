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
    public partial class YarnInward : Form
    {
        public YarnInward()
        {
            InitializeComponent();
        }

        #region variables
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        public string owner;
        public int cmbSTV, cmbPNV,cmbFV,cmbSV,cmbQV,cmbCV;
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

                if (QueryNo == 202)
                {
                    hash.Add("@intFromParty", cmbPartyName.SelectedValue);
                }
                if (QueryNo == 204)
                {
                    hash.Add("@intSutType", cmbSutType.SelectedValue);
                }
                if (QueryNo == 210)
                {
                    hash.Add("@intFromParty",cmbPartyName.SelectedValue);
                }
                if (QueryNo == 211)
                {
                    hash.Add("@intContractNo",cmbContract.SelectedValue);
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
                        if (lblStateCode.Text == fd.StateId.ToString())
                        {
                            txtCgPer.Text = objRow["S_CGST"].ToString();//dtReturn.Rows[0][0].ToString();
                            txtSgPer.Text = objRow["S_SGST"].ToString();//dtReturn.Rows[0][1].ToString();
                            txtIgPer.Text = "0.00";
                            //  ,,
                        }
                        else
                        {
                            txtCgPer.Text = "0.00";
                            txtSgPer.Text = "0.00";
                            txtIgPer.Text = objRow["S_IGST"].ToString();//dtReturn.Rows[0][2].ToString();
                        }

                        lblGST.Text = objRow["S_IGST"].ToString();
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
                        cmbQuality.DisplayMember = "Q_Name";// 
                        cmbQuality.ValueMember = "Q_Code";
                        cmbQuality.SelectedIndex = -1;
                        cmbQuality.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 209)
                    {
                        cmbFirmName.DataSource = dtReturn;
                        cmbFirmName.DisplayMember = "F_CompanyName";
                        cmbFirmName.ValueMember = "F_Code";
                        cmbFirmName.SelectedIndex = -1;
                        cmbFirmName.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 210)
                    {
                        //Common_Id as [],Common_Value as []
                        cmbContract.DataSource = dtReturn;
                        cmbContract.DisplayMember = "ContractNoV";
                        cmbContract.ValueMember = "ContractNo";
                        cmbContract.SelectedIndex = -1;
                        cmbContract.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 211)
                    {
                        //,
                        txtRate.Text = objRow["netrate"].ToString();
                        txtExcluding.Text = objRow["netRateExcluding"].ToString();
                        //,
                        txtCount.Text = objRow["count"].ToString();
                        cmbSutType.SelectedValue = Convert.ToInt32(objRow["yarnCode"].ToString());
                        txtMillName.Text = objRow["mill"].ToString();
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
                    else if (QueryNo == 209)
                    {
                        cmbFirmName.DataSource = dtReturn;
                        cmbFirmName.SelectedIndex = -1;
                        cmbFirmName.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 210)
                    {
                        cmbContract.DataSource = dtReturn;
                        cmbContract.SelectedIndex = -1;
                        cmbContract.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 211)
                    {
                        //,
                        txtRate.Text = "0";
                        txtExcluding.Text = "0";
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
                    hash.Add("@decGrandTaxable", Convert.ToDecimal(txtAmt.Text));
                    decimal gst;
                    if (lblStateCode.Text == fd.StateId.ToString())
                    {
                        gst = Convert.ToDecimal(txtCGST.Text) + Convert.ToDecimal(txtSGST.Text);
                    }
                    else
                    {
                        gst = Convert.ToDecimal(txtIGST.Text);
                    }
                    hash.Add("@decGST", gst);
                    hash.Add("@decGrandTotal", Convert.ToDecimal(lblGrandAMT.Text));
                    hash.Add("@decROFF", Convert.ToDecimal(txtROff.Text));

           //         @intCode,@strInvoiceNo,@strGetpassNo,@intSutType,@intSutUse,@decCount,
           
                    hash.Add("@intSutType", Convert.ToInt32(cmbSutType.SelectedValue));
                    hash.Add("@intSutUse", Convert.ToInt32(cmbWarfWeft.SelectedValue));
                    hash.Add("@decCount", Convert.ToDecimal(txtCount.Text));
                    //@strColor,@decGodawonQty,@decKarkhanaQty,@decTotBagQty,
                    hash.Add("@strColor", txtColor.Text.ToUpper());
                    hash.Add("@decGodawonQty",txtGodawonBag.Text);
                    hash.Add("@decKarkhanaQty",txtKarkhanaBag.Text);
                    hash.Add("@decTotBagQty", Convert.ToDecimal(lblTotalBag.Text));
                    //@decGodawonKon,@decKarkhanaKon,@decTotalKon,
                    hash.Add("@decGodawonKon",txtGodawonKon.Text);
                    hash.Add("@decKarkhanaKon",txtKarkhanaKon.Text);
                    hash.Add("@decTotalKon",lblTotalKon.Text);
                    //@decGodawonNWeight,@decKarkahanNWeight,@decTotalNWeight,@decGWeight,

                    hash.Add("@decGodawonNWeight",txtGodawonNWeight.Text);
                    hash.Add("@decKarkahanNWeight",txtKarkhanaNWeight.Text);
                    hash.Add("@decTotalNWeight",lblTotalWeight.Text);
                    hash.Add("@decGWeight",txtGrossWeight.Text);
                    //@intPacking,@decRatePerKg,@decTaxableTotal,@decCGSTPer,@decCGSTAmt,@decSGSTPer,

                    hash.Add("@intPacking",cmbPkgType.SelectedValue);
                    hash.Add("@decRatePerKg",txtRate.Text);
                    hash.Add("@decTaxableTotal", txtAmt.Text);
                    hash.Add("@decCGSTPer", Convert.ToDecimal(txtCgPer.Text));
                    hash.Add("@decCGSTAmt", Convert.ToDecimal(txtCGST.Text));
                    hash.Add("@decSGSTPer", Convert.ToDecimal(txtSgPer.Text));
                    hash.Add("@decSGSTAmt", Convert.ToDecimal(txtSGST.Text));
                    hash.Add("@decIGSTPer", Convert.ToDecimal(txtIgPer.Text));
                    hash.Add("@decIGSTAmt", Convert.ToDecimal(txtIGST.Text));

                    decimal st = Convert.ToDecimal(txtAmt.Text) + Convert.ToDecimal(txtCGST.Text) + Convert.ToDecimal(txtSGST.Text) +
                        Convert.ToDecimal(txtIGST.Text);
                    hash.Add("@decSubTotal", st);

                    hash.Add("@intShade",Convert.ToInt32(cmbShade.SelectedValue));
                   // hash.Add("@intInwardOnly",0);
                    hash.Add("@intIsTaxable", 1);
                    hash.Add("@intFirm", Convert.ToInt32(cmbFirmName.SelectedValue));

                    hash.Add("@intQuality",Convert.ToInt32(cmbQuality.SelectedValue));
                    hash.Add("@intContractNo",Convert.ToInt32(cmbContract.SelectedValue));
                    hash.Add("@decRateExcluding",Convert.ToDecimal(txtExcluding.Text));
                    hash.Add("@strContract", cmbContract.Text);

                    hash.Add("@strMill", txtMillName.Text);

                    //,,
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

        private void YarnInward_Load(object sender, EventArgs e)
        {
            FillGrid(206);// fill packing
            FillGrid(205);// sut use
            FillGrid(203);// sut typr
            FillGrid(201);// fill party
            FillGrid(207);// shade
            FillGrid(208); // QUALITY
            FillGrid(209); // firm
            if (newOrEdit == 1)
            {
                cmbPartyName.SelectedValue = cmbPNV;
                cmbSutType.SelectedValue = cmbSTV;
                cmbWarfWeft.SelectedValue = lblWarfWeft.Text;
                cmbPkgType.SelectedValue = lblPAkgType.Text;
                cmbFirmName.SelectedValue = cmbFV;
                cmbShade.SelectedValue = cmbSV;
                cmbQuality.SelectedValue = cmbQV;
                cmbContract.SelectedValue = cmbCV;
                //cmbQuality.SelectedValue= 
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

        private void cmbPartyName_Leave(object sender, EventArgs e)
        {
            if (cmbPartyName.Text != "<--SELECT-->" || cmbPartyName.SelectedIndex > 0 || cmbPartyName.SelectedValue != "System.Data.DataRow")
            {
                FillGrid(202);// get owner and state
                FillGrid(210);// get contracts
                if (newOrEdit == 1)
                {
                    cmbContract.SelectedValue = cmbCV;
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
                financeCalc();
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

        private void txtSizing_Leave(object sender, EventArgs e)
        {
            // stockCalc();
        }

        private void txtGodawon_Leave(object sender, EventArgs e)
        {
            stockCalc();
        }

        private void txtKarkhana_Leave(object sender, EventArgs e)
        {
            stockCalc();

        }

        public void reverceCalc()
        {
            txtExcluding.Text =
                Math.Round(Convert.ToDecimal(txtRate.Text) - (Convert.ToDecimal(txtRate.Text) - (Convert.ToDecimal(txtRate.Text) *
                 (100 / (100 + Convert.ToDecimal(lblGST.Text))))), 2).ToString();
        }

        private void txtRate_Leave(object sender, EventArgs e)
        {
            reverceCalc();
            financeCalc();
        }

        public void financeCalc()
        {
            txtAmt.Text = Math.Round((Convert.ToDecimal(lblTotalWeight.Text) * Convert.ToDecimal(txtExcluding.Text)), 2).ToString();

            txtCGST.Text = Math.Round(((Convert.ToDecimal(txtAmt.Text) / 100) * Convert.ToDecimal(txtCgPer.Text)), 2).ToString();

            txtSGST.Text = Math.Round(((Convert.ToDecimal(txtAmt.Text) / 100) * Convert.ToDecimal(txtSgPer.Text)), 2).ToString();

            txtIGST.Text = Math.Round(((Convert.ToDecimal(txtAmt.Text) / 100) * Convert.ToDecimal(txtIgPer.Text)), 2).ToString();

            decimal tot = Convert.ToDecimal(txtAmt.Text) + Convert.ToDecimal(txtCGST.Text) + Convert.ToDecimal(txtSGST.Text) + Convert.ToDecimal(txtIGST.Text);

            lblGrandAMT.Text = tot.ToString();
            // decimal tot1 = Math.Round(tot);
            decimal decGrandTotal = Convert.ToDecimal(lblGrandAMT.Text);
            Int32 intGrandTotal;

            // decGrandTotal = Math.Round((Convert.ToDecimal(txtValueOfGoods.Text) - Convert.ToDecimal(txtDiscountAmt.Text) + Convert.ToDecimal(txtGst.Text) + Convert.ToDecimal(txtFright.Text)), 2, MidpointRounding.AwayFromZero);
            intGrandTotal = Convert.ToInt32(Math.Round(decGrandTotal));

            decimal r = intGrandTotal - decGrandTotal;
            txtROff.Text = r.ToString();


            lblGrandAMT.Text = intGrandTotal.ToString();
        }

        private void cmbPartyName_TextChanged(object sender, EventArgs e)
        {
            if (cmbPartyName.Text != "<--SELECT-->" || cmbPartyName.SelectedIndex > 0)
            {
                FillGrid(202);// get owner and state
            }
        }

        private void cmbSutType_TextChanged(object sender, EventArgs e)
        {
            if (cmbSutType.Text != "<--SELECT-->" || cmbSutType.SelectedIndex > 0)
            {
                FillGrid(204);// get owner and state
            }
        }

        private void cmbWarfWeft_TextChanged(object sender, EventArgs e)
        {
            //lblWarfWeft.Text = cmbWarfWeft.SelectedValue.ToString();
        }

        private void cmbPkgType_TextChanged(object sender, EventArgs e)
        {
            //lblPAkgType.Text = cmbPkgType.SelectedValue.ToString();
        }

        private void txtNoOfKonPerBag_Leave(object sender, EventArgs e)
        {
            //if (Convert.ToDecimal(txtNoOfKonPerBag.Text) <= 0)
            //{
            //    messageBox frm = new messageBox();
            //    frm.messageTxt = "Please enter kon in bag";
            //    frm.type = "error";
            //    frm.ShowDialog();
            //}
            //else
            //{
            //    txtTotalKon.Text = Math.Round(((Convert.ToDecimal(txtQty.Text)) * Convert.ToDecimal(txtNoOfKonPerBag.Text)), 2).ToString();
            //}
        }

        private void cmbWarfWeft_Leave(object sender, EventArgs e)
        {
            if (cmbWarfWeft.Text == "<--SELECT-->" || cmbWarfWeft.SelectedIndex < 0 || cmbWarfWeft.SelectedValue == "System.Data.DataRow")
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please select WARF / WEFT";
                frm.type = "error";
                frm.ShowDialog();
                cmbWarfWeft.Focus();
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

        private void txtQty_Leave(object sender, EventArgs e)
        {

        }

        private void txtNetWeight_Leave(object sender, EventArgs e)
        {
            //if (Convert.ToDecimal(txtNetWeight.Text) > 0)
            //{
            //    financeCalc();
            //}
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblGrossWeight_Click(object sender, EventArgs e)
        {

        }

        private void lblWeight_Click(object sender, EventArgs e)
        {

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

        private void txtExcluding_Leave(object sender, EventArgs e)
        {
            txtRate.Text = Math.Round(
                Convert.ToDecimal(txtExcluding.Text)+((Convert.ToDecimal(txtExcluding.Text)/100)*Convert.ToDecimal(lblGST.Text)),2
                ).ToString();
            financeCalc();
        }

        private void cmbContract_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbContract_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbContract.SelectedValue) > 0)// != "System.Data.DataRowView")
            {
                FillGrid(211);

            }
            else
            {

            }
        }

    }
}
