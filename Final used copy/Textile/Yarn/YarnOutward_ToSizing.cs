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
    public partial class YarnOutward_ToSizing : Form
    {
        public YarnOutward_ToSizing()
        {
            InitializeComponent();
        }

        #region variables
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        public string UserName, yearString, companyNameStr, groupNmae, PeriodName, count, color;
        public int cmbPartyV, cmbSutTypeV, cmbSutUseV, cmbPkgV, cmbSV, cmbContractV, cmbQualityV;
        string strReturnMSG, strReturnRefNo;
        int intReturnPKNo;
        int okflag;

        public int newOrEdit = 0;
        #endregion

        #region Printer List
        public void printerlist()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Name", typeof(string));

            //comboBox1.DataSource = dt; 
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                //       MessageBox.Show(printer);

                dt.Rows.Add(printer);
            }
            cmbPrinter.DataSource = dt;
            cmbPrinter.DisplayMember = "Name";
        }
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
                hash.Add("@intyearId", fd.YearId);
                if (QueryNo == 203 || QueryNo == 301 || QueryNo == 204 || QueryNo == 302 || QueryNo == 205 || QueryNo == 2005 || QueryNo == 303 || QueryNo == 304)
                {
                    hash.Add("@intSutType", lblSutTypeV.Text);//cmbSutType.SelectedValue
                }
                if (QueryNo == 204 || QueryNo == 302 || QueryNo == 205 || QueryNo == 2005 || QueryNo == 303 || QueryNo == 304)
                {
                    hash.Add("@intSutUse", lblWarfWeftV.Text);//cmbWarfWeft.SelectedValue
                }
                if (QueryNo == 205 || QueryNo == 2005 || QueryNo == 303 || QueryNo == 304)
                {
                    hash.Add("@decCount", cmbCount.Text);
                    //
                }
                if (QueryNo == 304)
                {
                    //hash.Add("@strColor", cmbColor.Text);
                    hash.Add("@strMillName", cmbMIllName.Text);
                }
                if (QueryNo == 207 || QueryNo == 209)
                {
                    hash.Add("@intToParty", cmbPartyName.SelectedValue);
                }
                if (QueryNo == 203 || QueryNo == 204 || QueryNo == 205 || QueryNo == 2005 || QueryNo == 301 || QueryNo == 302 || QueryNo == 303 || QueryNo == 304)
                {
                    hash.Add("@intShade", Convert.ToInt32(cmbShade.SelectedValue));
                }

                if (QueryNo == 210)
                {
                    hash.Add("@intContractNo",cmbContract.SelectedValue);
                }
                if (QueryNo == 2010)
                {
                    hash.Add("@intQuality", Convert.ToInt32(lblQualityCode.Text));
                }

                dtReturn = ClsDefination.FillData("[YarnOutward_DML]", hash);


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
                        cmbSutType.DataSource = dtReturn;
                        cmbSutType.ValueMember = "S_Code";
                        cmbSutType.DisplayMember = "S_Name";
                        cmbSutType.SelectedIndex = -1;
                        cmbSutType.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 203)
                    {
                        cmbWarfWeft.Enabled = true;
                        cmbWarfWeft.DataSource = dtReturn;
                        cmbWarfWeft.ValueMember = "Common_Id";
                        cmbWarfWeft.DisplayMember = "Common_Value";
                        cmbWarfWeft.SelectedIndex = -1;
                        cmbWarfWeft.Text = "<--SELECT-->";

                        //,
                    }
                    else if (QueryNo == 204)
                    {
                        cmbCount.Enabled = true;
                        cmbCount.DataSource = dtReturn;
                        // cmbCount.ValueMember = "Common_Id";
                        cmbCount.DisplayMember = "Count";
                        cmbCount.SelectedIndex = -1;
                        cmbCount.Text = "<--SELECT-->";
                        //,
                    }
                    else if (QueryNo == 205)
                    {
                        cmbColor.Enabled = true;
                        cmbColor.DataSource = dtReturn;
                        //   cmbWarfWeft.ValueMember = "Common_Id";
                        cmbColor.DisplayMember = "Color";
                        cmbColor.SelectedIndex = -1;
                        cmbColor.Text = "<--SELECT-->";
                        //,
                    }
                    else if (QueryNo == 2005)
                    {
                        cmbMIllName.Enabled = true;
                        cmbMIllName.DataSource = dtReturn;
                        cmbMIllName.DisplayMember = "mill";
                        cmbMIllName.SelectedIndex = -1;
                        cmbMIllName.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 301 || QueryNo == 302 || QueryNo == 303 || QueryNo == 304)
                    {
                        lblGodawonBag.Text = objRow["GODAWON FRESH"].ToString();
                        lblKarkahanBag.Text = objRow["KARKHANA FRESH"].ToString();
                        lblWindingBagKarkhana.Text = objRow["KARKHANA WINDING"].ToString();
                        lblWidingBagGodawon.Text = objRow["GODAWON WINDING"].ToString();
                        lblGodawonKon.Text = objRow["GODAWON FRESH KON"].ToString();
                        lblKarkahanaKon.Text = objRow["KARKHANA FRESH KON"].ToString();
                        lblWindingKonKarkhana.Text = objRow["KARKHANA WINDING KON"].ToString();
                        lblWidingKonGodawon.Text = objRow["GODAWON WINDING KON"].ToString();
                        lblGodWeight.Text = objRow["GODAWON FRESH WEIGHT"].ToString();
                        lblKarWeight.Text = objRow["KARKHANA FRESH WEIGHT"].ToString();
                        lblKarWinWeight.Text = objRow["KARKHANA WINDING WEIGHT"].ToString();
                        lblWinGodWeight.Text = objRow["GODAWON WINDING WEIGHT"].ToString();

                        lblTotalBagFresh.Text = (Convert.ToDecimal(lblGodawonBag.Text) + Convert.ToDecimal(lblKarkahanBag.Text)).ToString();
                        lblTotalKonFresh.Text = (Convert.ToDecimal(lblGodawonKon.Text) + Convert.ToDecimal(lblKarkahanaKon.Text)).ToString();
                        lblTotFreshWeight.Text = (Convert.ToDecimal(lblGodWeight.Text) + Convert.ToDecimal(lblKarWeight.Text)).ToString();

                        lbltotalWidingBag.Text = (Convert.ToDecimal(lblWidingBagGodawon.Text) + Convert.ToDecimal(lblWindingBagKarkhana.Text)).ToString();
                        lblTotalWidingKon.Text = (Convert.ToDecimal(lblWidingKonGodawon.Text) + Convert.ToDecimal(lblWindingKonKarkhana.Text)).ToString();
                        lblTotWindingWeight.Text = (Convert.ToDecimal(lblWinGodWeight.Text) + Convert.ToDecimal(lblKarWinWeight.Text)).ToString();
                        //lblGodawonBag.Text = objRow["BAG QTY"].ToString();
                        //lblGodawonKon.Text = objRow["Godawon"].ToString();
                        //lblWidingBagGodawon.Text = objRow["Karkhana"].ToString();
                        //lblGodWeight.Text = objRow["NWeight"].ToString();
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
                        lblOwner.Text = objRow["P_OwnerName"].ToString();
                        lblStateCode.Text = objRow["P_State"].ToString();
                    }
                    else if (QueryNo == 208)
                    {
                        cmbShade.DataSource = dtReturn;
                        cmbShade.DisplayMember = "Shade";
                        cmbShade.ValueMember = "ShadeCode";
                        cmbShade.SelectedIndex = -1;
                        cmbShade.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 401)
                    {
                        cmbContract.DataSource = dtReturn;
                        cmbContract.DisplayMember = "contractNoV";
                        cmbContract.ValueMember = "contractNo";
                        cmbContract.SelectedIndex = -1;
                        cmbContract.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 210)
                    {
                        //MJC.qualityCode,QR.Q_Name

                        lblQuality.Text = objRow["Q_Name"].ToString();
                        lblQualityCode.Text = objRow["qualityCode"].ToString();

                        FillGrid(2010);

                        //cmbQuality.DataSource = dtReturn;
                        //cmbQuality.DisplayMember = "Q_Name";
                        //cmbQuality.ValueMember = "qualityCode";
                        //cmbQuality.SelectedIndex = -1;
                        //cmbQuality.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 2010)
                    {
                        txtTara.Text = objRow["Q_Part"].ToString();
                        txtPart.Text = objRow["TARA"].ToString();
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
                        cmbSutType.DataSource = dtReturn;
                        cmbSutType.SelectedIndex = -1;
                        cmbSutType.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 203)
                    {
                        cmbWarfWeft.Enabled = false;
                        cmbWarfWeft.DataSource = dtReturn;
                        cmbWarfWeft.SelectedIndex = -1;
                        cmbWarfWeft.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 204)
                    {
                        cmbCount.Enabled = false;
                        cmbCount.DataSource = dtReturn;
                        // cmbCount.ValueMember = "Common_Id";
                        //   cmbCount.DisplayMember = "YI_Count";
                        cmbCount.SelectedIndex = -1;
                        cmbCount.Text = "<--NO RECORD-->";
                        //,
                    }

                    else if (QueryNo == 205)
                    {
                        cmbColor.Enabled = false;
                        cmbColor.DataSource = dtReturn;
                        //   cmbWarfWeft.ValueMember = "Common_Id";
                        //cmbColor.DisplayMember = "YI_Color";
                        cmbColor.SelectedIndex = -1;
                        cmbColor.Text = "<--NO RECORD-->";
                        //,
                    }
                    else if (QueryNo == 2005)
                    {
                        cmbMIllName.Enabled = true;
                        cmbMIllName.DataSource = dtReturn;
                     //   cmbMIllName.DisplayMember = "mill";
                        cmbMIllName.SelectedIndex = -1;
                        cmbMIllName.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 206)
                    {
                        cmbPkgType.DataSource = dtReturn;
                        cmbPkgType.SelectedIndex = -1;
                        cmbPkgType.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 301 || QueryNo == 302 || QueryNo == 303 || QueryNo == 304)
                    {
                        lblGodawonBag.Text = "0";
                        lblKarkahanBag.Text = "0";
                        lblWindingBagKarkhana.Text = "0";
                        lblWidingBagGodawon.Text = "0";
                        lblGodawonKon.Text = "0";
                        lblKarkahanaKon.Text = "0";
                        lblWindingKonKarkhana.Text = "0";
                        lblWidingKonGodawon.Text = "0";
                        lblGodWeight.Text = "0";
                        lblKarWeight.Text = "0";
                        lblKarWinWeight.Text = "0";
                        lblWinGodWeight.Text = "0";

                        lblTotalBagFresh.Text = (Convert.ToDecimal(lblGodawonBag.Text) + Convert.ToDecimal(lblKarkahanBag.Text)).ToString();
                        lblTotalKonFresh.Text = (Convert.ToDecimal(lblGodawonKon.Text) + Convert.ToDecimal(lblKarkahanaKon.Text)).ToString();
                        lblTotFreshWeight.Text = (Convert.ToDecimal(lblGodWeight.Text) + Convert.ToDecimal(lblKarWeight.Text)).ToString();

                        lbltotalWidingBag.Text = (Convert.ToDecimal(lblWidingBagGodawon.Text) + Convert.ToDecimal(lblWindingBagKarkhana.Text)).ToString();
                        lblTotalWidingKon.Text = (Convert.ToDecimal(lblWidingKonGodawon.Text) + Convert.ToDecimal(lblWindingKonKarkhana.Text)).ToString();
                        lblTotWindingWeight.Text = (Convert.ToDecimal(lblWinGodWeight.Text) + Convert.ToDecimal(lblKarWinWeight.Text)).ToString();
                    }
                    else if (QueryNo == 208)
                    {
                        cmbShade.DataSource = dtReturn;
                        cmbShade.SelectedIndex = -1;
                        cmbShade.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 209)
                    {
                        cmbContract.DataSource = dtReturn;
                        cmbContract.SelectedIndex = -1;
                        cmbContract.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 210)
                    {
                        //MJC.qualityCode,QR.Q_Name
                        lblQuality.Text = "N/A";
                        lblQualityCode.Text = 0.ToString();

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
                hash.Add("@intyearId", Convert.ToInt32(fd.YearId));

                if (QueryNo == 1 || QueryNo == 2)
                {

                    if (QueryNo == 2)
                    {
                        hash.Add("@strUniqueCode", lblUniqueCode.Text);
                        hash.Add("@intCode", Convert.ToInt32(lblSrNo.Text));
                    }

                    hash.Add("@intGetpass", txtInvoiceNo.Text);
                    hash.Add("@dtpDate", dtpInvoiceDate.Value.ToString("MM/dd/yyyy"));
                    hash.Add("@intToParty", cmbPartyName.SelectedValue);

                    hash.Add("@intState", Convert.ToInt32(lblStateCode.Text));
                    hash.Add("@strOwner", lblOwner.Text);
                    hash.Add("@intSutType", Convert.ToInt32(cmbSutType.SelectedValue));
                    hash.Add("@intSutUse", Convert.ToInt32(cmbWarfWeft.SelectedValue));

                    hash.Add("@decCount", Convert.ToDecimal(cmbCount.Text));
                    hash.Add("@strColor", cmbColor.Text);
                    hash.Add("@decTotBagQty", Convert.ToDecimal(lblTotalBagQty.Text));

                    hash.Add("@decGodawonBag", Convert.ToDecimal(txtGodBagF.Text));
                    hash.Add("@decKarkhanaBag", Convert.ToDecimal(txtKarBagF.Text));
                    hash.Add("@decWindingBag", Convert.ToDecimal(txtWindingBagGod.Text));

                    hash.Add("@decTotalKon", Convert.ToDecimal(lblTotalKOn.Text));
                    hash.Add("@decGodawonKon", Convert.ToDecimal(txtGodawonKonF.Text));
                    hash.Add("@decKarkhanaKon", Convert.ToDecimal(txtKarkhanaKonF.Text));

                    hash.Add("@decWindingKon", Convert.ToDecimal(txtWindingKonGod.Text));
                    hash.Add("@decTotalWeight", Convert.ToDecimal(lblTotalWeight.Text));
                    hash.Add("@decGodawonWeight", Convert.ToDecimal(txtGodawonWeightF.Text));

                    hash.Add("@decKarkhanaWeight", Convert.ToDecimal(txtKarkahanWeightF.Text));
                    hash.Add("@decWindingWeight", Convert.ToDecimal(txtWindingWeightGod.Text));
                    hash.Add("@decWindingBagK", Convert.ToDecimal(txtWindingBagK.Text));

                    hash.Add("@decWindingKonK", Convert.ToDecimal(txtWindingKonK.Text));
                    hash.Add("@decWindingWeightK", Convert.ToDecimal(txtWindingWeightK.Text));
                    hash.Add("@decWindingTotBag", Convert.ToDecimal(lblTotBagW.Text));

                    hash.Add("@decWindingTotKon", Convert.ToDecimal(lblTotKonW.Text));
                    hash.Add("@decWindingTotWeight", Convert.ToDecimal(lblTotWeightW.Text));

                    hash.Add("@intPacking", Convert.ToInt32(cmbPkgType.SelectedValue));

                    hash.Add("@decYO_TotMixBag", Convert.ToDecimal(lblMixBag.Text));
                    hash.Add("@decYO_TotMixKon", Convert.ToDecimal(lblMixKon.Text));
                    hash.Add("@decYO_TotMixWeight", Convert.ToDecimal(lblMixWeight.Text));

                    hash.Add("@intShade", Convert.ToInt32(cmbShade.SelectedValue));
                    // ,
                    hash.Add("@intContractNo", cmbContract.SelectedValue);
                    hash.Add("@strContractValue", cmbContract.Text);

                    hash.Add("@intQuality", Convert.ToInt32(lblQualityCode.Text));
                    hash.Add("@intOutwardTo", 1);

                     //@,@,@)
                    hash.Add("@intTara",Convert.ToInt32(txtTara.Text));
                    hash.Add("@decPart",Convert.ToDecimal(txtPart.Text));
                    hash.Add("@decMeasure",Convert.ToDecimal(txtMeasure.Text));
                    //@
                    hash.Add("@strMillName",txtMillName.Text);
                    hash.Add("@strLotNo",txtLotNo.Text);

                }

                okflag = 1;
                return ClsDefination.InsertExecute(hash, "[YarnOutward_DML]", ref strReturnMSG, ref strReturnNo, ref intReturnNo);
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

        private void YarnOutward_ToSizing_Load(object sender, EventArgs e)
        {
            printerlist();

            FillGrid(201); // fill party
            FillGrid(202); // fill sut type
            FillGrid(206); // fill packing
            FillGrid(208);// shade
           // FillGrid(209); // contract
            if (newOrEdit == 1)
            {
                cmbPartyName.SelectedValue = cmbPartyV;
                cmbShade.SelectedValue = cmbSV;
                //cmbSutType.SelectedValue = Convert.ToInt32( lblSutTypeV.Text);

                lblQualityCode.Text = cmbQualityV.ToString();
                FillGrid(209);
                cmbSutType.SelectedValue = cmbSutTypeV;
                FillGrid(203);
                FillGrid(301);
                cmbWarfWeft.SelectedValue = Convert.ToInt32(lblWarfWeftV.Text);
                FillGrid(204);
                FillGrid(302);
                cmbCount.Text = count;

                FillGrid(205);
                FillGrid(303);

                cmbColor.Text = color;
                FillGrid(304);


                cmbPkgType.SelectedValue = cmbPkgV;
                //  lblSutTypeV.Text = cmbSutTypeV.ToString();
                FillGrid(401);
                cmbContract.SelectedValue = cmbContractV;
                FillGrid(210);
            }
        }

        private void cmbCount_Leave(object sender, EventArgs e)
        {
            if (cmbCount.Text != "<--SELECT-->" && cmbCount.Text != "<--NO RECORD-->" && cmbCount.SelectedValue != null)
            {
                FillGrid(205);// fill color
                FillGrid(2005);
                //FillGrid(303);// stock by count
                //if (cmbColor.Enabled == true)
                //{
                //    cmbColor.Focus();
                //}
                //else
                //{
                //    txtGodBagF.Focus();
                //}
                if (newOrEdit == 1)
                {
                    cmbColor.Text = color;
                }

                cmbMIllName.Focus();
            }
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please select Count";
                frm.type = "error";
                frm.ShowDialog();
            }
        }

        private void cmbColor_Leave(object sender, EventArgs e)
        {
            if (cmbColor.Text != "<--SELECT-->" && cmbColor.Text != "<--NO RECORD-->")
            {

                FillGrid(304);// stock by count
            }
        }

        public void MixBag()
        {
            lblMixBag.Text =
                Math.Round((Convert.ToDecimal(txtGodBagF.Text) + Convert.ToDecimal(txtKarBagF.Text) + Convert.ToDecimal(txtWindingBagGod.Text) + Convert.ToDecimal(txtWindingBagK.Text)), 2).ToString();
        }

        public void MixKon()
        {
            lblMixKon.Text =
             Math.Round((Convert.ToDecimal(txtGodawonKonF.Text) + Convert.ToDecimal(txtKarkhanaKonF.Text) +
                          Convert.ToDecimal(txtWindingKonGod.Text) + Convert.ToDecimal(txtWindingKonK.Text)), 2).ToString();
        }

        public void MixWeight()
        {
            lblMixWeight.Text =
             Math.Round((Convert.ToDecimal(txtGodawonWeightF.Text) + Convert.ToDecimal(txtKarkahanWeightF.Text) +
                         Convert.ToDecimal(txtWindingWeightGod.Text) + Convert.ToDecimal(txtWindingWeightK.Text)), 2).ToString();
        }

        private void txtGodBagF_Leave(object sender, EventArgs e)
        {
            lblTotalBagQty.Text = Math.Round((Convert.ToDecimal(txtGodBagF.Text) + Convert.ToDecimal(txtKarBagF.Text)), 2).ToString();
            //txtKarBagF.Text = Math.Round((Convert.ToDecimal(txtQty.Text) - Convert.ToDecimal(txtGodBagF.Text)), 2).ToString();           
            MixBag();
        }

        private void txtKarBagF_Leave(object sender, EventArgs e)
        {
            lblTotalBagQty.Text = Math.Round((Convert.ToDecimal(txtGodBagF.Text) + Convert.ToDecimal(txtKarBagF.Text)), 2).ToString();
            //txtKarBagF.Text = Math.Round((Convert.ToDecimal(txtQty.Text) - Convert.ToDecimal(txtGodBagF.Text)), 2).ToString();           
            MixBag();
        }

        private void txtGodawonKonF_Leave(object sender, EventArgs e)
        {
            lblTotalKOn.Text = Math.Round((Convert.ToDecimal(txtGodawonKonF.Text) + Convert.ToDecimal(txtKarkhanaKonF.Text)), 2).ToString();
            MixKon();
        }

        private void txtKarkhanaKonF_Leave(object sender, EventArgs e)
        {
            lblTotalKOn.Text = Math.Round((Convert.ToDecimal(txtGodawonKonF.Text) + Convert.ToDecimal(txtKarkhanaKonF.Text)), 2).ToString();
            MixKon();
        }

        private void txtGodawonWeightF_Leave(object sender, EventArgs e)
        {
            lblTotalWeight.Text = Math.Round((Convert.ToDecimal(txtGodawonWeightF.Text) + Convert.ToDecimal(txtKarkahanWeightF.Text)), 2).ToString();
            MixWeight();
        }

        private void txtKarkahanWeightF_Leave(object sender, EventArgs e)
        {
            lblTotalWeight.Text = Math.Round((Convert.ToDecimal(txtGodawonWeightF.Text) + Convert.ToDecimal(txtKarkahanWeightF.Text)), 2).ToString();
            MixWeight();
        }

        private void txtWindingBagGod_Leave(object sender, EventArgs e)
        {
            lblTotBagW.Text = Math.Round((Convert.ToDecimal(txtWindingBagGod.Text) + Convert.ToDecimal(txtWindingBagK.Text)), 2).ToString();
            MixBag();
        }

        private void txtWindingBagK_Leave(object sender, EventArgs e)
        {
            lblTotBagW.Text = Math.Round((Convert.ToDecimal(txtWindingBagGod.Text) + Convert.ToDecimal(txtWindingBagK.Text)), 2).ToString();
            MixBag();
        }

        private void txtWindingKonGod_Leave(object sender, EventArgs e)
        {
            lblTotKonW.Text = Math.Round((Convert.ToDecimal(txtWindingKonGod.Text) + Convert.ToDecimal(txtWindingKonK.Text)), 2).ToString();
            MixKon();
        }

        private void txtWindingKonK_Leave(object sender, EventArgs e)
        {
            lblTotKonW.Text = Math.Round((Convert.ToDecimal(txtWindingKonGod.Text) + Convert.ToDecimal(txtWindingKonK.Text)), 2).ToString();
            MixKon();
        }

        private void txtWindingWeightGod_Leave(object sender, EventArgs e)
        {
            lblTotWeightW.Text = Math.Round((Convert.ToDecimal(txtWindingWeightGod.Text) + Convert.ToDecimal(txtWindingWeightK.Text)), 2).ToString();
            MixWeight();
        }

        private void txtWindingWeightK_Leave(object sender, EventArgs e)
        {
            lblTotWeightW.Text = Math.Round((Convert.ToDecimal(txtWindingWeightGod.Text) + Convert.ToDecimal(txtWindingWeightK.Text)), 2).ToString();
            MixWeight();
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

        private void cmbWarfWeft_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbWarfWeft.SelectedValue) > 0)
            {
                lblWarfWeftV.Text = cmbWarfWeft.SelectedValue.ToString();
                FillGrid(204);// fill count
              //  FillGrid(302);// stock by type
                if (cmbCount.Enabled == true)
                {
                    cmbCount.Focus();
                }
                else
                {
                    txtGodBagF.Focus();
                }
                if (newOrEdit == 1)
                {
                    cmbCount.Text = count;
                }
            }
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please select Warf / Weft";
                frm.type = "error";
                frm.ShowDialog();
            }

        }

        private void cmbPartyName_Leave(object sender, EventArgs e)
        {
            if (cmbPartyName.Text != "System.Data.DataRowView")
            {
                FillGrid(207);
                FillGrid(401);
               // FillGrid(209);
                ////if (newOrEdit == 1)
                ////{
                ////    cmbContract.SelectedValue = cmbContractV;
                ////}
            }
        }

        private void cmbSutType_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbSutType.SelectedValue) > 0)
            {
                lblSutTypeV.Text = cmbSutType.SelectedValue.ToString();
                FillGrid(203);// fill sut use
              //  FillGrid(301);// stock by type
                cmbSutTypeV = Convert.ToInt32(cmbSutType.SelectedValue);
                lblSutTypeV.Text = cmbSutTypeV.ToString();
                if (cmbWarfWeft.Enabled == true)
                {
                    cmbWarfWeft.Focus();
                }
                else
                {
                    txtGodBagF.Focus();
                }
                if (newOrEdit == 1)
                {
                    //        cmbWarfWeft.SelectedValue = cmbSutUseV;
                    cmbWarfWeft.SelectedValue = Convert.ToInt32(lblWarfWeftV.Text);
                }
            }
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please select Yarn Type";
                frm.type = "error";
                frm.ShowDialog();
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
            }
        }

        private void cmbContract_Leave(object sender, EventArgs e)
        {

            if (cmbContract.SelectedValue != "System.Data.DataRowView" && cmbContract.SelectedIndex >= 0)
            {
                //if (Convert.ToInt32( cmbContract.SelectedValue) > 0)
                //{
                FillGrid(210);
                
                //}
            }
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please select contract";
                frm.type = "error";
                frm.ShowDialog();
                cmbContract.Focus();
            }
        }

        private void cmbMIllName_Leave(object sender, EventArgs e)
        {
            if (cmbMIllName.SelectedIndex > -1)
            {
                FillGrid(304);
                txtMillName.Text = cmbMIllName.Text;
            }
        }



    }
}
