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

namespace Textile.Sizing
{
    public partial class Sizing_Tippan : Form
    {
        public Sizing_Tippan()
        {
            InitializeComponent();
        }


        #region variables
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        public string owner;
        public int cmbPV, cmbQV, cmbSV, cmbBV, cmbFV, cmbCV, cmbYG;
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

                if (QueryNo == 202)
                {
                    hash.Add("@intSiCode", lblSrNo.Text);
                }
                if (QueryNo == 401 || QueryNo == 504 || QueryNo == 510)
                {
                    hash.Add("@intFromParty", cmbPartyName.SelectedValue);
                }
                if (QueryNo == 510)
                {
                    hash.Add("@intShade", cmbShade.SelectedValue);
                }
                if (QueryNo == 505 || QueryNo == 506 || QueryNo == 508 || QueryNo == 509)
                {
                    //wr_sutId,wr_count,Tara
                    hash.Add("@intQuality", Convert.ToInt32(cmbQuality.SelectedValue));
                }
                if (QueryNo == 508 || QueryNo == 509)
                {
                    hash.Add("@intSutType", cmbYarnGroup.SelectedValue);
                    hash.Add("@intFromParty", cmbPartyName.SelectedValue);
                    hash.Add("@intShade", cmbShade.SelectedValue);
                }
                if (QueryNo == 509)
                {
                    hash.Add("@decCount", cmbCount.Text);
                }




                dtReturn = ClsDefination.FillData("[Transaction_SizingInwardDML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 202)
                    {
                        dgvDesign.DataSource = dtReturn;
                    }
                    if (QueryNo == 301)
                    {
                        cmbPartyName.DataSource = dtReturn;
                        cmbPartyName.ValueMember = "P_Code";
                        cmbPartyName.DisplayMember = "P_CompanyName";
                        cmbPartyName.SelectedIndex = -1;
                        cmbPartyName.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 302)
                    {
                        cmbQuality.DataSource = dtReturn;
                        cmbQuality.ValueMember = "D_Code";
                        cmbQuality.DisplayMember = "D_Name";
                        cmbQuality.SelectedIndex = -1;
                        cmbQuality.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 401)
                    {
                        lblOwner.Text = objRow["P_OwnerName"].ToString();//dtReturn.Rows[0][0].ToString();
                        lblStateCode.Text = objRow["P_State"].ToString();//dtReturn.Rows[0][1].ToString();

                        if (Convert.ToInt32(lblStateCode.Text) == fd.StateId)
                        {
                            txtCGSTPer.Enabled = true;
                            txtCGSTPer.BackColor = System.Drawing.Color.White;
                            txtSGSTPer.Enabled = true;
                            txtSGSTPer.BackColor = System.Drawing.Color.White;
                            txtIGSTPer.Enabled = false;
                            txtIGSTPer.BackColor = System.Drawing.Color.LightGray;

                        }
                        else
                        {
                            txtCGSTPer.Enabled = false;
                            txtCGSTPer.BackColor = System.Drawing.Color.LightGray;
                            txtSGSTPer.Enabled = false;
                            txtSGSTPer.BackColor = System.Drawing.Color.LightGray;
                            txtIGSTPer.Enabled = true;
                            txtIGSTPer.BackColor = System.Drawing.Color.White;

                        }
                    }
                    else if (QueryNo == 501)
                    {
                        cmbShade.DataSource = dtReturn;
                        cmbShade.DisplayMember = "Shade";
                        cmbShade.ValueMember = "ShadeCode";
                        cmbShade.SelectedIndex = -1;
                        cmbShade.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 502)
                    {
                        cmbBroker.DataSource = dtReturn;
                        cmbBroker.DisplayMember = "BR_Name";
                        cmbBroker.ValueMember = "BR_Code";
                        cmbBroker.SelectedIndex = -1;
                        cmbBroker.Text = "<--SELECT-->";
                    }

                    else if (QueryNo == 503)
                    {
                        //F_Code,F_CompanyName
                        cmbFirm.DataSource = dtReturn;
                        cmbFirm.DisplayMember = "F_CompanyName";
                        cmbFirm.ValueMember = "F_Code";
                        cmbFirm.SelectedIndex = -1;
                        cmbFirm.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 504)
                    {
                        //[],'N/A' as []

                        cmbContract.DataSource = dtReturn;
                        cmbContract.DisplayMember = "contractNoV";
                        cmbContract.ValueMember = "contractNo";
                        cmbContract.SelectedIndex = -1;
                        cmbContract.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 505)
                    {
                        lblSutId.Text = objRow["wr_sutId"].ToString();
                        cmbYarnGroup.SelectedValue = Convert.ToInt32(objRow["wr_sutId"].ToString());
                        lblYarnCount.Text = objRow["wr_count"].ToString();
                        lblTara.Text = objRow["Tara"].ToString();
                        //,,
                    }
                    else if (QueryNo == 506)
                    {
                        txtPart.Text = lblPart1.Text = objRow["Q_Part"].ToString();
                        lblWarfConst.Text = objRow["Q_WarfConst"].ToString();
                        // ,
                    }
                    else if (QueryNo == 507)
                    {
                        cmbYarnGroup.DataSource = dtReturn;
                        cmbYarnGroup.DisplayMember = "YG_Name";
                        cmbYarnGroup.ValueMember = "YG_Code";
                        cmbYarnGroup.SelectedIndex = -1;
                        cmbYarnGroup.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 508)
                    {
                        cmbCount.DataSource = dtReturn;
                        cmbCount.DisplayMember = "Count";
                        cmbCount.SelectedIndex = -1;
                        cmbCount.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 509)
                    {
                        cmbMill.DataSource = dtReturn;
                        cmbMill.DisplayMember = "mill";
                        cmbMill.SelectedIndex = -1;
                        cmbMill.Text = "<--SELECT-->";
                    }

                    //else if (QueryNo == 510)
                    //{
                    //    cmbBNo.DataSource = dtReturn;
                    //    cmbBNo.DisplayMember = "Beam_No";
                    //    cmbBNo.SelectedIndex = -1;
                    //    cmbBNo.Text = "<--SELECT-->";
                    //}
                }
                else
                {
                    if (QueryNo == 301)
                    {
                        cmbPartyName.DataSource = dtReturn;
                        cmbPartyName.SelectedIndex = -1;
                        cmbPartyName.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 401)
                    {
                        lblOwner.Text = "ERROR";
                        lblStateCode.Text = "ERROR";
                    }
                    else if (QueryNo == 302)
                    {
                        cmbQuality.DataSource = dtReturn;
                        cmbQuality.SelectedIndex = -1;
                        cmbQuality.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 501)
                    {
                        cmbShade.DataSource = dtReturn;
                        cmbShade.SelectedIndex = -1;
                        cmbShade.Text = "<--NO RECORD-->";
                    }

                    else if (QueryNo == 502)
                    {
                        cmbBroker.DataSource = dtReturn;
                        cmbBroker.SelectedIndex = -1;
                        cmbBroker.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 503)
                    {
                        cmbFirm.DataSource = dtReturn;
                        cmbFirm.SelectedIndex = -1;
                        cmbFirm.Text = "<--NO RECORD-->";

                    }
                    else if (QueryNo == 504)
                    {
                        cmbContract.DataSource = dtReturn;
                        cmbContract.SelectedIndex = -1;
                        cmbContract.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 505)
                    {
                        lblSutId.Text = "0";
                        cmbYarnGroup.SelectedValue = Convert.ToInt32("0");
                        lblYarnCount.Text = "0";
                        lblTara.Text = "0";
                        //,,
                    }
                    else if (QueryNo == 506)
                    {
                        lblPart1.Text = "0";
                        lblWarfConst.Text = "0";
                        // ,
                    }
                    else if (QueryNo == 507)
                    {
                        cmbYarnGroup.DataSource = dtReturn;
                        cmbYarnGroup.SelectedIndex = -1;
                        cmbYarnGroup.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 508)
                    {
                        cmbCount.DataSource = dtReturn;
                        cmbCount.SelectedIndex = -1;
                        cmbCount.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 509)
                    {
                        cmbMill.DataSource = dtReturn;
                        cmbMill.SelectedIndex = -1;
                        cmbMill.Text = "<--NO RECORD-->";
                    }
                    //else if (QueryNo == 510)
                    //{
                    //    cmbBNo.DataSource = dtReturn;
                    //    cmbBNo.SelectedIndex = -1;
                    //    cmbBNo.Text = "<--NO RECORD-->";
                    //}
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
                hash.Add("@intYearId", Convert.ToInt32(fd.YearId));

                if (QueryNo == 1 || QueryNo == 2)
                {

                    if (QueryNo == 2)
                    {
                        hash.Add("@strUniqueCode", lblUniqueCode.Text);
                        hash.Add("@intSiCode", Convert.ToInt32(lblSrNo.Text));
                    }

                    hash.Add("@strSiInvoiceNo", txtInvoiceNo.Text);
                    hash.Add("@dtInvoiceDate", dtpInvoiceDate.Value.ToString("MM/dd/yyyy"));
                    hash.Add("@intFromParty", cmbPartyName.SelectedValue);
                    hash.Add("@strFromParty", cmbPartyName.Text);
                    hash.Add("@intState", lblStateCode.Text);
                    hash.Add("@strOwnerName", lblOwner.Text.ToUpper());
                    //           ,,,,,
                    hash.Add("@decCount", txtCount.Text);
                    hash.Add("@strMill", txtMill.Text.ToUpper());
                    hash.Add("@strHSN", txtHSN.Text);
                    hash.Add("@decEndPerSection", txtEndsPerSection.Text);
                    hash.Add("@decPart", txtPart.Text);
                    hash.Add("@decMeasureYards", txtMeasureYards.Text);
                    //,,,,,,
                    hash.Add("@decCutMark", txtCutMark.Text);
                    hash.Add("@decTotalCuts", txtTotalCuts.Text);
                    hash.Add("@decTotalMeasure", txtTotalMeasure.Text);
                    hash.Add("@intQuality", cmbQuality.SelectedValue);
                    hash.Add("@decSzKg", txtSizingKg.Text);
                    hash.Add("@decSzRate", txtRate.Text);
                    //,,,,,,
                    hash.Add("@decSzAmt", lblSizingAmt.Text);
                    hash.Add("@decWrMtr", txtWarpingMtr.Text);
                    hash.Add("@decWrRate", txtWarpingRate.Text);
                    hash.Add("@decWrAmt", lblWarpingAmt.Text);
                    hash.Add("@decSubTotal", lblSubtotalAmt.Text);
                    hash.Add("@decDis", txtDiscount.Text);
                    //,,,,,,
                    hash.Add("@decAddLess", txtAddLess.Text);
                    hash.Add("@decTaxableAmt", lblTaxableAmt.Text);
                    hash.Add("@decCGPer", txtCGSTPer.Text);
                    hash.Add("@decCGAmt", lblCGSTAmt.Text);
                    hash.Add("@decSGPer", txtSGSTPer.Text);
                    //,,,,,
                    hash.Add("@decSGAmt", lblSGSTAmt.Text);
                    hash.Add("@decIGPer", txtIGSTPer.Text);
                    hash.Add("@decIGAmt", lblIGSTAmt.Text);
                    hash.Add("@decROFF", txtRoff.Text);
                    hash.Add("@decGrandTotal", lblGrandTotalAmt.Text);

                    hash.Add("@intShade", Convert.ToInt32(cmbShade.SelectedValue));
                    hash.Add("@decRatePerPick", Convert.ToDecimal(txtRatePerPick.Text));

                    hash.Add("@intBroker", Convert.ToInt32(cmbBroker.SelectedValue));

                    hash.Add("@intFirm", Convert.ToInt32(cmbFirm.SelectedValue));

                    hash.Add("@intContract", Convert.ToInt32(cmbContract.SelectedValue));
                    hash.Add("@strContractValue", cmbContract.Text);
                    //,,
                    hash.Add("@strchallnNo", txtChallanNo.Text);

                    hash.Add("@inttotalBeams", Convert.ToInt32(txtTotalBeams.Text));
                    hash.Add("@dectotalMtrs", Convert.ToDecimal(txtTotalMtrs.Text));
                    hash.Add("@strsatNo", txtSatNo1.Text);

                    hash.Add("@intwr_sutId", Convert.ToInt32(lblSutId.Text));
                    hash.Add("@decwr_count", Convert.ToDecimal(lblYarnCount.Text));
                    hash.Add("@decTara", Convert.ToDecimal(lblTara.Text));
                    hash.Add("@decQ_Part", Convert.ToDecimal(lblPart1.Text));
                    hash.Add("@decQ_WarfConst", Convert.ToDecimal(lblWarfConst.Text));

                    hash.Add("@intSutType", cmbYarnGroup.SelectedValue);


                    decimal consumption = 0, u = 0, b = 0;

                    u = Math.Round(Convert.ToDecimal(lblTara.Text) * Convert.ToDecimal(lblPart1.Text), 3);
                    //   b = Math.Round(Convert.ToDecimal(lblWarfConst.Text) / Convert.ToDecimal(lblYarnCount.Text), 3);

                    b = u / Convert.ToDecimal(lblWarfConst.Text);
                    b = b / Convert.ToDecimal(lblYarnCount.Text);
                    consumption = Math.Round(b * Convert.ToDecimal(txtTotalMtrs.Text), 3);

                    hash.Add("@decConsumption", consumption);

                    hash.Add("@intFormType", 1);
                    //                     as int=0,
                    // as decimal(18,2)=0.00,
                    // as decimal(18,2)=0.00,
                    // as decimal(18,2)=0.00,
                    // as decimal(18,2)=0.00,

                    //string strXmlDetail = "";

                    //StringBuilder xmlClassMaster = new StringBuilder();

                    //for (int k = 0; k < dgvDesign.Rows.Count; k++)
                    //{

                    //    xmlClassMaster.Append("<Row>");
                    //    //,,
                    //    xmlClassMaster.Append("<SI_BNo>" + dgvDesign.Rows[k].Cells[1].Value.ToString() + "</SI_BNo>");
                    //    xmlClassMaster.Append("<SI_Cuts>" + (Convert.ToDecimal(dgvDesign.Rows[k].Cells[2].Value)) + "</SI_Cuts>");
                    //    xmlClassMaster.Append("<SI_Border>" + dgvDesign.Rows[k].Cells[3].Value.ToString() + "</SI_Border>");
                    //    xmlClassMaster.Append("<SI_SatNo>" + dgvDesign.Rows[k].Cells[4].Value.ToString() + "</SI_SatNo>");
                    //    xmlClassMaster.Append("<BiCode>" + dgvDesign.Rows[k].Cells[5].Value.ToString() + "</BiCode>");
                    //    xmlClassMaster.Append("<meter>" + (Convert.ToDecimal(dgvDesign.Rows[k].Cells[6].Value.ToString())) + "</meter>");
                    //    xmlClassMaster.Append("</Row>");
                    //}

                    //if (xmlClassMaster.Length > 0)
                    //{
                    //    xmlClassMaster.Append("</ProductSupplierDetails>");
                    //    strXmlDetail = "<ProductSupplierDetails>" + Convert.ToString(xmlClassMaster);
                    //}

                    //hash.Add("@strXmlDetail", strXmlDetail);




                }

                okflag = 1;
                return ClsDefination.InsertExecute(hash, "[Transaction_SizingInwardDML]", ref strReturnMSG, ref strReturnNo, ref intReturnNo);
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

        private void Sizing_Tippan_Load(object sender, EventArgs e)
        {
            FillGrid(301);
            FillGrid(302);
            FillGrid(507);
            FillGrid(501);
            FillGrid(502);
            FillGrid(503);
            FillGrid(504);

            //GridCreation();
            if (newOrEdit == 1)
            {
                cmbPartyName.SelectedValue = cmbPV;
                cmbQuality.SelectedValue = cmbQV;
                cmbShade.SelectedValue = cmbSV;
                cmbBroker.SelectedValue = cmbBV;
                cmbFirm.SelectedValue = cmbFV;
                FillGrid(504);
                cmbContract.SelectedValue = cmbCV;
                FillGrid(202);
                FillGrid(505);
                FillGrid(506);
                FillGrid(507);
                cmbYarnGroup.SelectedValue = cmbYG;
            }
        }

        private void cmbShade_Leave(object sender, EventArgs e)
        {
            if (cmbShade.SelectedValue == null || Convert.ToInt32(cmbShade.SelectedValue) < 0)
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please select shade";
                frm.type = "error";
                frm.ShowDialog();
                //cmbPartyName.Focus();
            }
        }

        private void cmbPartyName_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbPartyName.SelectedValue) > 0 && cmbPartyName.Text != "<--SELECT-->" && cmbPartyName.Text != "<--NO RECORD-->")
            {
                FillGrid(401);
                FillGrid(504);

                if (newOrEdit == 1)
                {
                    cmbContract.SelectedValue = cmbCV;
                }

              //  FillGrid(510);
            }
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please select party name";
                frm.type = "error";
                frm.ShowDialog();
                cmbPartyName.Focus();
            }
        }

        private void cmbBroker_Leave(object sender, EventArgs e)
        {
            if (cmbBroker.SelectedValue == null || Convert.ToInt32(cmbBroker.SelectedValue) < 0)
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please select Broker";
                frm.type = "error";
                frm.ShowDialog();
                //cmbPartyName.Focus();
            }
        }

        private void cmbQuality_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbQuality.SelectedValue) < 0)
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please select quality";
                frm.type = "error";
                frm.ShowDialog();


                //                cmbPartyName.Focus();            
            }
            else
            {
                FillGrid(505);
                FillGrid(506);
            }
        }

        private void txtSizingKg_Leave(object sender, EventArgs e)
        {
            if (txtSizingKg.Text == "")
            {
                txtSizingKg.Text = "0";
            }
            financeClac();
        }

        private void txtRate_Leave(object sender, EventArgs e)
        {
            if (txtRate.Text == "")
            {
                txtRate.Text = "0";
            }


            financeClac();
        }

        private void txtWarpingMtr_Leave(object sender, EventArgs e)
        {
            if (txtWarpingMtr.Text == "")
            {
                txtWarpingMtr.Text = "0";
            }
            financeClac();
        }

        private void txtWarpingRate_Leave(object sender, EventArgs e)
        {
            if (txtWarpingRate.Text == "")
            {
                txtWarpingRate.Text = "0";
            }
            financeClac();
        }

        private void txtDiscount_Leave(object sender, EventArgs e)
        {
            if (txtDiscount.Text == "")
            {
                txtDiscount.Text = "0";
            }
            financeClac();
        }

        private void txtAddLess_Leave(object sender, EventArgs e)
        {
            if (txtAddLess.Text == "")
            {
                txtAddLess.Text = "0";
            }
            financeClac();
        }

        private void txtCGSTPer_Leave(object sender, EventArgs e)
        {
            if (txtCGSTPer.Text == "")
            {
                txtCGSTPer.Text = "0";
            }
            financeClac();
        }

        private void txtSGSTPer_Leave(object sender, EventArgs e)
        {
            if (txtSGSTPer.Text == "")
            {
                txtSGSTPer.Text = "0";
            }
            financeClac();
        }

        private void txtIGSTPer_Leave(object sender, EventArgs e)
        {
            if (txtIGSTPer.Text == "")
            {
                txtIGSTPer.Text = "0";
            }
            financeClac();
        }

        public void financeClac()
        {
            try
            {

                lblSizingAmt.Text =
                    Math.Round((Convert.ToDecimal(txtSizingKg.Text) * Convert.ToDecimal(txtRate.Text)), 2, MidpointRounding.AwayFromZero).ToString();
                lblWarpingAmt.Text =
                    Math.Round((Convert.ToDecimal(txtWarpingMtr.Text) * Convert.ToDecimal(txtWarpingRate.Text)), 2, MidpointRounding.AwayFromZero).ToString();

                lblSubtotalAmt.Text =
                    Math.Round((Convert.ToDecimal(lblSizingAmt.Text) + Convert.ToDecimal(lblWarpingAmt.Text)), 2, MidpointRounding.AwayFromZero).ToString();


                lblTaxableAmt.Text =
                    Math.Round((Convert.ToDecimal(lblSubtotalAmt.Text) - Convert.ToDecimal(txtDiscount.Text) + Convert.ToDecimal(txtAddLess.Text)), 2, MidpointRounding.AwayFromZero).ToString();


                if (Convert.ToInt32(lblStateCode.Text) == fd.StateId)
                {
                    lblIGSTPer.Text = "0";
                    lblIGSTAmt.Text = "0";
                    txtIGSTPer.Text = "0";

                    lblCGSTAmt.Text =
                        Math.Round(((Convert.ToDecimal(lblTaxableAmt.Text) / 100) * Convert.ToDecimal(txtCGSTPer.Text)), 2, MidpointRounding.AwayFromZero).ToString();

                    lblSGSTAmt.Text =
                        Math.Round(((Convert.ToDecimal(lblTaxableAmt.Text) / 100) * Convert.ToDecimal(txtSGSTPer.Text)), 2, MidpointRounding.AwayFromZero).ToString();

                }
                else
                {
                    lblCGSTPer.Text = "0";
                    lblCGSTAmt.Text = "0";
                    txtCGSTPer.Text = "0";

                    lblSGSTPer.Text = "0";
                    lblSGSTAmt.Text = "0";
                    txtSGSTPer.Text = "0";

                    lblCGSTAmt.Text =
                        Math.Round(((Convert.ToDecimal(lblTaxableAmt.Text) / 100) * Convert.ToDecimal(txtIGSTPer.Text)), 2, MidpointRounding.AwayFromZero).ToString();

                }



                // Round off amount
                decimal decGrandTotal;
                int intGrandTotal;

                decGrandTotal = Math.Round((Convert.ToDecimal(lblTaxableAmt.Text) + Convert.ToDecimal(lblCGSTAmt.Text)
                                + Convert.ToDecimal(lblSGSTAmt.Text) + Convert.ToDecimal(lblIGSTAmt.Text)), 2, MidpointRounding.AwayFromZero);

                intGrandTotal = Convert.ToInt32(Math.Round(decGrandTotal));

                txtRoff.Text = (decGrandTotal - intGrandTotal).ToString();

                lblGrandTotalAmt.Text = intGrandTotal.ToString();

            }
            catch (Exception ex)
            {
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

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbYarnGroup_Leave(object sender, EventArgs e)
        {
            if (cmbYarnGroup.SelectedIndex > -1)
            {
                string count = cmbCount.Text;
                FillGrid(508);

                if (newOrEdit == 1)
                {
                    cmbCount.Text = count;
                }
                cmbCount.Focus();
                //txtCount.Text = cmbCount.Text;
            }
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please select YARN GROUP";
                frm.type = "error";
                frm.ShowDialog();
            }
        }

        private void cmbCount_Leave(object sender, EventArgs e)
        {
            if (cmbCount.SelectedIndex > -1)
            {
                string mill = cmbMill.Text;
                FillGrid(509);
                if (newOrEdit == 1)
                {
                    cmbMill.Text = mill;
                }
                txtCount.Text = cmbCount.Text;
                cmbMill.Focus();
            }
            else
            {
                txtCount.Text = "0";
            }
        }

        private void cmbMill_Leave(object sender, EventArgs e)
        {
            if (cmbMill.SelectedIndex > -1)
            {
                txtMill.Text = cmbMill.Text;
            }
            else
            {
                txtMill.Text = "";
            }
        }
    }
}
