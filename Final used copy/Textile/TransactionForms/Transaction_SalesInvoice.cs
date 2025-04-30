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

namespace Textile.TransactionForms
{
    public partial class Transaction_SalesInvoice : Form
    {
        public Transaction_SalesInvoice()
        {
            InitializeComponent();
        }

        #region variables
        ClassFiles.CommonFunction common = new ClassFiles.CommonFunction();
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        public string UserName, yearString, companyNameStr, groupNmae, PeriodName;
        public int cmbSuppliverV, cmbTaxableV, cmbContractValue,cmbFromPartyV,cmbQualityV;
        string strReturnMSG, strReturnRefNo;
        int intReturnPKNo, repete;
        int result, okflag;
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

                if (QueryNo == 206)
                {
                    hash.Add("@intFromParty", cmbToParty.SelectedValue);
                }
                if (QueryNo == 201 || QueryNo == 404)
                {
                    hash.Add("@intContractCode",cmbContract.SelectedValue);
                }
                if (QueryNo == 404)
                {
                    hash.Add("@intQuality", cmbQualityName.SelectedValue);
                }
                dtReturn = ClsDefination.FillData("[Transaction_SalesInvoice_DML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 203)
                    {
                        cmbToParty.DataSource = dtReturn;
                        cmbToParty.DisplayMember = "Party";
                        cmbToParty.ValueMember = "P_Code";
                        cmbToParty.SelectedIndex = -1;
                        cmbToParty.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 204)
                    {
                        cmbBroker.DataSource = dtReturn;
                        cmbBroker.DisplayMember = "BR_Name";
                        cmbBroker.ValueMember = "BR_Code";
                        cmbBroker.SelectedIndex = -1;
                        cmbBroker.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 201)
                    {
                        cmbQualityName.DataSource = dtReturn;
                        cmbQualityName.DisplayMember = "Q_Name";
                        cmbQualityName.ValueMember = "Q_Code";
                        cmbQualityName.SelectedIndex = -1;
                        cmbQualityName.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 205)
                    {
                        cmbPartyName.DataSource = dtReturn;
                        cmbPartyName.DisplayMember = "F_CompanyName";
                        cmbPartyName.ValueMember = "F_Code";
                        cmbPartyName.SelectedIndex = -1;
                        cmbPartyName.Text = "<--SELECT-->";


                    }
                    else if (QueryNo == 206)
                    {
                        cmbContract.DataSource = dtReturn;
                        cmbContract.DisplayMember = "contractNo";
                        cmbContract.ValueMember = "Id";
                        cmbContract.SelectedIndex = -1;
                        cmbContract.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 404)
                    {
                        txtRate.Text = Math.Round(Convert.ToDecimal(objRow["Rate"].ToString()) * Convert.ToDecimal(objRow["Pick"].ToString()), 2).ToString(); ;
                    }

                }
                else
                {
                    if (QueryNo == 203)
                    {
                        cmbToParty.DataSource = dtReturn;
                        cmbToParty.SelectedIndex = -1;
                        cmbToParty.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 204)
                    {
                        cmbBroker.DataSource = dtReturn;
                        cmbBroker.SelectedIndex = -1;
                        cmbBroker.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 201)
                    {
                        cmbQualityName.DataSource = dtReturn;
                        cmbQualityName.SelectedIndex = -1;
                        cmbQualityName.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 205)
                    {
                        cmbPartyName.DataSource = dtReturn;
                        cmbPartyName.SelectedIndex = -1;
                        cmbPartyName.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 206)
                    {
                        cmbContract.DataSource = dtReturn;
                        cmbContract.SelectedIndex = -1;
                        cmbContract.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 404)
                    {
                        txtRate.Text = "0.00";
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
                        hash.Add("@intID", lblSrNo.Text);
                        hash.Add("@intCode", txtInvoiceNo.Text);
                    }

                    hash.Add("@intDcCode", txtDCNOValue.Text);
                    hash.Add("@intPArtyCode", lblToPartyCode.Text);
                    hash.Add("@dtSiDate", dtpInvoicedate.Value.ToString("MM/dd/yyyy"));
                    hash.Add("@intStateCode", lblStateCode.Text);
                    hash.Add("@strLoomNo", txtLoomNo.Text);

                    //             @,@intCode,,,,,,
                    hash.Add("@strHSNCode", txtHSNNo.Text);
                    hash.Add("@strBrocker", txtBrocker.Text);
                    //***************************** Pass this values from xml below ********************
                    //hash.Add("@dtDcDate", dtpDcDate.Value.ToString("MM/dd/yyyy"));
                    //hash.Add("@intQuality", Convert.ToInt32(cmbQualityName.SelectedValue));
                    hash.Add("@intNoOfPiece", Convert.ToDecimal(txtPiecevalue.Text));
                    hash.Add("@decMtrs", Convert.ToDecimal(txtTotalMtrs.Text));
                    //***************************** Pass this values from xml below ********************
                    hash.Add("@decRate", Convert.ToDecimal(txtRate.Text));
                    hash.Add("@decTotalAmt", Convert.ToDecimal(lbltotalAmt.Text));
                    //,,,,,,,,
                    hash.Add("@decTaxableAmt", Convert.ToDecimal(lblTaxableValue.Text));
                    hash.Add("@decCgstPer", Convert.ToDecimal(txtCGSTPer.Text));
                    hash.Add("@decCgstAmt", Convert.ToDecimal(txtCGSTAmt.Text));
                    hash.Add("@decSgstPer", Convert.ToDecimal(txtSGSTPer.Text));
                    hash.Add("@decSgstAmt", Convert.ToDecimal(txtSGSTAmt.Text));
                    hash.Add("@decIgstPer", Convert.ToDecimal(txtGSTPer.Text));
                    hash.Add("@decIgstAmt", Convert.ToDecimal(txtGSTAmt.Text));
                    hash.Add("@decGst", Convert.ToDecimal(lblGSTAmt.Text));
                    //,,,,,,,,
                    hash.Add("@decROff", Convert.ToDecimal(txtROFF.Text));
                    hash.Add("@decGrandtotal", Convert.ToDecimal(lblGrandTotalAmt.Text));
                    //,,@,GETDATE(),1,@,@

                    hash.Add("@decPacking", Convert.ToDecimal(txtPacking.Text));
                    hash.Add("@decChecking", Convert.ToDecimal(txtChecking.Text));
                    hash.Add("@decOther", Convert.ToDecimal(txtAddOther.Text));
                    hash.Add("@decTotalAdd", Convert.ToDecimal(lblTotalAdd.Text));
                    hash.Add("@decSecand", Convert.ToDecimal(txtSecond.Text));
                    hash.Add("@decTP", Convert.ToDecimal(txtTP.Text));
                    hash.Add("@decSL", Convert.ToDecimal(txtSL.Text));
                    hash.Add("@decFold", Convert.ToDecimal(txtFold.Text));
                    hash.Add("@decOtherLess", Convert.ToDecimal(txtOtherLess.Text));
                    hash.Add("@decTotalLess", Convert.ToDecimal(lblTotalLess.Text));
                    //,,,,,,,,,
                    //@,@,
                    cmbSuppliverV = Convert.ToInt32(lblFromPartyCode.Text);
                    hash.Add("@intFromParty", Convert.ToInt32(lblFromPartyCode.Text));
                    hash.Add("@intBroker", Convert.ToInt32(lblBrokerCode.Text));
                    hash.Add("@decSampleCut", Convert.ToDecimal(0));
                    hash.Add("@intShade", Convert.ToInt32(lblShade.Text));

                    hash.Add("@strPlace", lblPlace.Text);
                    hash.Add("@intContractCode", cmbContract.SelectedValue);
                    hash.Add("@strContractName", cmbContract.Text);

                    hash.Add("@decVatavPer", txtVatavPer.Text);
                    hash.Add("@decVatavAmt", txtVatavAmt.Text);

                    hash.Add("@intPaymentDays", txtPaymentDays.Text);

                    hash.Add("@inttotalNoOfTage", txtTotalTage.Text);
                    if (chkBoxCalculation.Checked == true)
                    {
                        hash.Add("@intchkCalculation", 1);
                    }
                    else
                    {
                        hash.Add("@intchkCalculation", 0);
                    }



                    string strXmlDetail = "";

                    StringBuilder xmlClassMaster = new StringBuilder();

                        //DateTime Date;
                        //Date = Convert.ToDateTime(dgvSut.Rows[k].Cells[3].Value.ToString());

                        //string ConvertedDate = Date.ToString("MM/dd/yyyy");


                        xmlClassMaster.Append("<Row>");
                        xmlClassMaster.Append("<DC_ID>" + (Convert.ToInt32(lblDcId.Text)) + "</DC_ID>");
                        xmlClassMaster.Append("<DC_CODE>" + (Convert.ToInt32(txtDCNOValue.Text)) + "</DC_CODE>");
                        xmlClassMaster.Append("<DC_Date>" + dtpDcDate.Value.ToString("MM/dd/yyyy") + "</DC_Date>");

                        xmlClassMaster.Append("<Design_Id>" + (Convert.ToInt32(cmbQualityName.SelectedValue)) + "</Design_Id>");

                        xmlClassMaster.Append("<TotalNoTage>" + (Convert.ToInt32(txtPiecevalue.Text)) + "</TotalNoTage>");
                        xmlClassMaster.Append("<TotalMtr>" + (Convert.ToDecimal(txtTotalMtrs.Text)) + "</TotalMtr>");
                        xmlClassMaster.Append("<SampleMtr>" + (Convert.ToDecimal(txtSampleCutMtr.Text)) + "</SampleMtr>");
                        xmlClassMaster.Append("<DeliveryChalanUniqueCode>" + lblDeliveryUniqueCode.Text + "</DeliveryChalanUniqueCode>");
                        xmlClassMaster.Append("<rate>" + (Convert.ToDecimal(txtRate.Text)) + "</rate>");
                        xmlClassMaster.Append("<amount>" + (Convert.ToDecimal(lbltotalAmt.Text)) + "</amount>");
                        xmlClassMaster.Append("<CompChalanNo>" + txtCompNo.Text + "</CompChalanNo>");


                        xmlClassMaster.Append("</Row>");

                    if (xmlClassMaster.Length > 0)
                    {
                        xmlClassMaster.Append("</ProductSupplierDetails>");
                        strXmlDetail = "<ProductSupplierDetails>" + Convert.ToString(xmlClassMaster);
                    }

                    hash.Add("@strXmlDetail", strXmlDetail);



                }

                okflag = 1;
                return ClsDefination.InsertExecute(hash, "[Transaction_SalesInvoice_DML]", ref strReturnMSG, ref strReturnNo, ref intReturnNo);
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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }


        public void LowerCalculation()
        {
            try
            {

                if (chkBoxCalculation.Checked == true)
                {
                    lbltotalAmt.Text = Math.Round(Convert.ToDecimal(lblTotalMtrs.Text) * Convert.ToDecimal(txtRate.Text), 2).ToString();

                }
                else
                {
                    lbltotalAmt.Text = Math.Round(Convert.ToDecimal(txtPiecevalue.Text) * Convert.ToDecimal(txtRate.Text), 2).ToString();
                }

                lblTaxableValue.Text = lbltotalAmt.Text;


                lblTotalAdd.Text = Math.Round(
                    Convert.ToDecimal(txtPacking.Text) + Convert.ToDecimal(txtChecking.Text) + Convert.ToDecimal(txtAddOther.Text), 2
                    ).ToString();

                decimal fold = 0;
                decimal per = 0;
                decimal mtr = 0;
                if (Convert.ToDecimal(txtFold.Text) > 0)
                {
                    per = 100 - Convert.ToDecimal(txtFold.Text);
                    mtr = Convert.ToDecimal(txtTotalMtrs.Text) - ((Convert.ToDecimal(txtTotalMtrs.Text) / 100) * per);
                    fold = mtr * Convert.ToDecimal(txtRate.Text);

                    fold = (Convert.ToDecimal(txtRate.Text) * Convert.ToDecimal(txtTotalMtrs.Text)) - fold;

                }
                txtVatavAmt.Text = "0.00";
                if (Convert.ToDecimal(txtVatavPer.Text) > 0)
                {
                    txtVatavAmt.Text = Math.Round((Convert.ToDecimal(lblTaxableValue.Text) / 100) * Convert.ToDecimal(txtVatavPer.Text), 2).ToString();
                }


                lblTotalLess.Text = Math.Round(
                    Convert.ToDecimal(txtSecond.Text) + Convert.ToDecimal(txtTP.Text) + Convert.ToDecimal(txtSL.Text)
                    + fold + Convert.ToDecimal(txtOtherLess.Text) + Convert.ToDecimal(txtVatavAmt.Text), 2
                    ).ToString();

                lblTaxableValue.Text = Math.Round(Convert.ToDecimal(lbltotalAmt.Text) + Convert.ToDecimal(lblTotalAdd.Text)
                    - Convert.ToDecimal(lblTotalLess.Text), 2).ToString();


                //lblTaxableValue.Text = Math.Round( Convert.ToDecimal(lblTaxableValue.Text) - Convert.ToDecimal(txtVatavAmt.Text),2).ToString();


                if (Convert.ToInt32(lblStateCode.Text) == fd.StateId)
                {
                    txtCGSTAmt.Text =
                        Math.Round((Convert.ToDecimal(lblTaxableValue.Text) / 100) * Convert.ToDecimal(txtCGSTPer.Text), 2).ToString();

                    txtSGSTAmt.Text =
                        Math.Round((Convert.ToDecimal(lblTaxableValue.Text) / 100) * Convert.ToDecimal(txtSGSTPer.Text), 2).ToString();
                    txtGSTPer.Text = "0";
                    txtGSTAmt.Text = "0";

                    lblGSTAmt.Text = Math.Round(
                        Convert.ToDecimal(txtCGSTAmt.Text) + Convert.ToDecimal(txtSGSTAmt.Text), 2
                        ).ToString();
                }
                else
                {
                    txtGSTAmt.Text =
                        Math.Round((Convert.ToDecimal(lblTaxableValue.Text) / 100) * Convert.ToDecimal(txtGSTPer.Text), 2).ToString();
                    txtCGSTPer.Text = "0";
                    txtCGSTAmt.Text = "0";
                    txtSGSTPer.Text = "0";
                    lblGSTAmt.Text = txtGSTAmt.Text;
                    txtSGSTAmt.Text = "0";
                }



                decimal decGrandTotal;
                int intGrandTotal;

                decGrandTotal = Math.Round((Convert.ToDecimal(lblTaxableValue.Text) + Convert.ToDecimal(lblGSTAmt.Text)
                                ), 2, MidpointRounding.AwayFromZero);

                intGrandTotal = Convert.ToInt32(Math.Round(decGrandTotal));

                txtROFF.Text = (intGrandTotal - decGrandTotal).ToString();

                lblGrandTotalAmt.Text = intGrandTotal.ToString();


            }
            catch (Exception ex)
            {
            }
        }

        private void txtCGSTPer_Leave(object sender, EventArgs e)
        {
            if (txtCGSTPer.Text == "")
            {
                txtCGSTPer.Text = "0";
            }
            LowerCalculation();
        }

        private void txtRate_Leave(object sender, EventArgs e)
        {
            try
            {

                LowerCalculation();
            }
            catch (Exception ex)
            {
            }
        }

        private void txtSGSTPer_Leave(object sender, EventArgs e)
        {
            if (txtSGSTPer.Text == "")
            {
                txtSGSTPer.Text = "0";
            }
            LowerCalculation();
        }

        private void txtGSTPer_Leave(object sender, EventArgs e)
        {
            if (txtGSTPer.Text == "")
            {
                txtGSTPer.Text = "0";
            }
            LowerCalculation();
        }

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

        private void Transaction_SalesInvoice_Load(object sender, EventArgs e)
        {
           // printerlist();
            lblDCDate.Text = dtpDcDate.Value.ToString("dd/MM/yyyy");
            if (Convert.ToInt32(lblStateCode.Text) == fd.StateId)
            {
                txtCGSTPer.Enabled = txtSGSTPer.Enabled = true;
                txtGSTPer.Enabled = false;
            }
            else
            {
                txtCGSTPer.Enabled = txtSGSTPer.Enabled = false;
                txtGSTPer.Enabled = true;
            }

            FillGrid(203);// fill party
            FillGrid(204); // fill brocker
            cmbToParty.SelectedValue = Convert.ToInt32(lblToPartyCode.Text);
            FillGrid(206); // fill contract related to party
            FillGrid(205); // fill firm
            cmbContract.SelectedValue = cmbContractValue;
            FillGrid(201); // fill design related to contract
           
            cmbQualityName.SelectedValue = cmbQualityV;
            FillGrid(404);// get rate from contract no
            //comboBox1.SelectedValue = cmbFromPartyV;
            cmbPartyName.SelectedValue = cmbFromPartyV;
           
            
            cmbBroker.SelectedValue = Convert.ToInt32(lblBrokerCode.Text);

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

                if (intReturnPKNo == 0)
                {
                    frm.messageTxt = strReturnMSG;
                    frm.type = "error";
                    frm.ShowDialog();
                }

                else
                {
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

                    if (Convert.ToInt32(strReturnMSG) > 0)
                    {
                        //                        ClsDefination.Readpath();

                        TransactionReport.CRTransaction frmT = new TransactionReport.CRTransaction();

                        ClsDefination.Readpath();

                        frmT.QueryNo = 1008;
                        frmT.server = ClsDefination.server;
                        frmT.dbname = ClsDefination.database;
                        frmT.username = ClsDefination.id;
                        frmT.password = ClsDefination.password;
                        frmT.reportPath = ClsDefination.CrystalPath;

                        frmT.intCompanyID = fd.CompId;

                        frmT.intYearID = fd.YearId;
                        frmT.VoucherId = Convert.ToInt32(intReturnPKNo);     //Convert.ToInt32(dgvSut.CurrentRow.Cells[14].Value.ToString());
                        frmT.intSupplierId = cmbSuppliverV;//Convert.ToInt32(dgvSut.CurrentRow.Cells[39].Value.ToString());
                        frmT.ShowDialog();


                        //common.server = ClsDefination.server;
                        //common.dbname = ClsDefination.database;
                        //common.username = ClsDefination.id;
                        //common.password = ClsDefination.password;
                        //common.reportPath = ClsDefination.CrystalPath;
                        //common.PrinterName = cmbPrinter.Text;
                        //common.companyId = fd.CompId;
                        //common.yearID = fd.YearId;
                        //common.BillNo = Convert.ToInt32(strReturnMSG);
                        //common.PrintDirect(1008);
                    }

                    this.Close();
                }
            }

        }

        private void txtPacking_Leave(object sender, EventArgs e)
        {
            if (txtPacking.Text == "")
            {
                txtPacking.Text = "0";
            }
            LowerCalculation();
        }

        private void txtChecking_Leave(object sender, EventArgs e)
        {
            if (txtChecking.Text == "")
            {
                txtChecking.Text = "0";
            }
            LowerCalculation();
        }

        private void txtAddOther_Leave(object sender, EventArgs e)
        {
            if (txtAddOther.Text == "")
            {
                txtAddOther.Text = "0";
            }
            LowerCalculation();
        }

        private void txtSecond_Leave(object sender, EventArgs e)
        {
            if (txtSecond.Text == "")
            {
                txtSecond.Text = "0";
            }
            LowerCalculation();
        }

        private void txtTP_Leave(object sender, EventArgs e)
        {
            if (txtTP.Text == "")
            {
                txtTP.Text = "0";

            }
            LowerCalculation();
        }

        private void txtSL_Leave(object sender, EventArgs e)
        {
            if (txtSL.Text == "")
            {
                txtSL.Text = "0";
            }
            LowerCalculation();
        }

        private void txtFold_Leave(object sender, EventArgs e)
        {
            if (txtFold.Text == "")
            {
                txtFold.Text = "0";
            }
            LowerCalculation();
        }

        private void txtOtherLess_Leave(object sender, EventArgs e)
        {
            if (txtOtherLess.Text == "")
            {
                txtOtherLess.Text = "0";
            }
            LowerCalculation();
        }

        private void txtTotalMtrs_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtTotalMtrs.Text == "" || Convert.ToDecimal(txtTotalMtrs.Text) <= 0)
                {
                    txtTotalMtrs.Text = "0";
                }
                lblTotalMtrs.Text = txtTotalMtrs.Text;
                LowerCalculation();
            }
            catch (Exception ex)
            {
            }
        }

        private void txtSampleCutMtr_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtSampleCutMtr.Text == "" || Convert.ToDecimal(txtSampleCutMtr.Text) <= 0)
                {
                    txtSampleCutMtr.Text = "0";
                }
                lblSampleCutMtr.Text = txtSampleCutMtr.Text;
                LowerCalculation();
            }
            catch (Exception ex)
            {
            }
        }

        private void cmbToParty_Leave(object sender, EventArgs e)
        {
            if (cmbToParty.SelectedIndex > -1)
            {
                lblToPartyCode.Text = cmbToParty.SelectedValue.ToString();
                lblToPartyName.Text = cmbToParty.Text;
            }
        }

        private void cmbBroker_Leave(object sender, EventArgs e)
        {
            if (cmbBroker.SelectedIndex > -1)
            {
                lblBrokerCode.Text = cmbBroker.SelectedValue.ToString();
                txtBrocker.Text = cmbBroker.Text;

            }
        }

        private void txtVatavPer_Leave(object sender, EventArgs e)
        {
            if (txtVatavPer.Text == "")
            {
                txtVatavPer.Text = "0";
            }
            LowerCalculation();
        }

        private void chkBoxCalculation_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkBoxCalculation.Checked == true)
            //{
            //    txtPiecevalue.Text = "0";
            //}
            //else
            //{
            //    txtTotalMtrs.Text = "0";
            //}
        }

        private void cmbPartyName_Leave(object sender, EventArgs e)
        {
            if (cmbPartyName.SelectedIndex > -1)
            {
                lblFromPartyCode.Text = cmbPartyName.SelectedValue.ToString();
                lblfromPartyName.Text = cmbPartyName.Text;

            }
        }

        private void cmbQualityName_Leave(object sender, EventArgs e)
        {
            if (cmbQualityName.SelectedIndex > -1)
            {
                lblQualityCode.Text = cmbQualityName.SelectedValue.ToString();
                lblQualityName.Text = cmbQualityName.Text;

            }
        }
    }
}
