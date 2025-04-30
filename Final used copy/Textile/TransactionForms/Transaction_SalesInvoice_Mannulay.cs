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
    public partial class Transaction_SalesInvoice_Mannulay : Form
    {
        public Transaction_SalesInvoice_Mannulay()
        {
            InitializeComponent();
        }


        #region variables
        ClassFiles.CommonFunction common = new ClassFiles.CommonFunction();
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        public string UserName, yearString, companyNameStr, groupNmae, PeriodName;
        public int cmbSuppliverV, cmbTaxableV, cmbContractV, cmbFromPartyV, cmbToPartyV;
        string strReturnMSG, strReturnRefNo;
        int intReturnPKNo, repete;
        int result, okflag, pageLoad = 0;
        public int newOrEdit = 0;
        #endregion

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


        #region GridCreationWarf
        public void GridCreation()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("X", typeof(string));          //0
                dt.Columns.Add("DC ID", typeof(int));
                dt.Columns.Add("DC NO", typeof(int));
                dt.Columns.Add("DATE", typeof(DateTime));
                dt.Columns.Add("QUALITY", typeof(string));
                dt.Columns.Add("DESIGN", typeof(string));
                dt.Columns.Add("TOTAL PICES", typeof(int));
                dt.Columns.Add("TOTAL MTR's", typeof(decimal));
                dt.Columns.Add("SAMPLE MTR's", typeof(decimal));
                dt.Columns.Add("DESIGN ID", typeof(int));
                dt.Columns.Add("DeliveryChalanUniqueCode", typeof(string));
                dt.Columns.Add("rate", typeof(decimal));
                dt.Columns.Add("amount", typeof(decimal));
                dt.Columns.Add("CompChalanNo", typeof(string));

                dgvSut.DataSource = dt;


                dgvSut.Columns[1].Visible = dgvSut.Columns[9].Visible = dgvSut.Columns[10].Visible = false;
                dgvSut.Columns[0].AutoSizeMode = dgvSut.Columns[2].AutoSizeMode = dgvSut.Columns[3].AutoSizeMode =
                    dgvSut.Columns[4].AutoSizeMode = dgvSut.Columns[5].AutoSizeMode = dgvSut.Columns[6].AutoSizeMode =
                    dgvSut.Columns[7].AutoSizeMode = dgvSut.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


            }
            catch (Exception ex)
            {
            }
        }
        #endregion


        private void Transaction_SalesInvoice_Mannulay_Load(object sender, EventArgs e)
        {
            pageLoad = 0;
            printerlist();
            GridCreation();
            //lblDCDate.Text = dtpDcDate.Value.ToString("dd/MM/yyyy");
            FillGrid(201); // Quality
            FillGrid(202);// Shade
            // FillGrid(203);// Party // filling it from Firm leave
            FillGrid(204);// broker
            FillGrid(205);// firm master
            cmbBroker.Enabled = true;
            pageLoad = 1;

            if (newOrEdit == 1)
            {
                // dtpInvoicedate.Text = Convert.ToDateTime(lblDtpDate.Text).ToString("MM/dd/yyyy");
                cmbFromParty.SelectedValue = cmbFromPartyV;
                cmbBroker.SelectedValue = lblBrokerCode.Text;
                cmbBroker.Enabled = false;
                FillGrid(2003);
                cmbToParty.SelectedValue = lblToPartyCode.Text;
                int i = cmbToPartyV;
                FillGrid(301);
                FillGrid(207);
                if (cmbContractV == 0)
                {
                    cmbContract.Text = "NO RECORD AVAILABLE";
                    cmbContract.SelectedIndex = -1;
                }
                else
                {
                    cmbContract.SelectedValue = cmbContractV;
                }
                //FillGrid(401); // getting broker code
                FillGrid(402);// getting delivery details
                FillGrid(405);
                cmbShade.SelectedValue = Convert.ToInt32(lblShade.Text);
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

                if (QueryNo == 1 || QueryNo == 2)
                {

                    if (QueryNo == 2)
                    {
                        hash.Add("@strUniqueCode", lblUniqueCode.Text);
                        hash.Add("@intID", lblSrNo.Text);
                        hash.Add("@intCode", txtInvoiceNo.Text);
                    }

                    hash.Add("@intDcCode", txtDCNOValue.Text);
                    hash.Add("@intPArtyCode", cmbToParty.SelectedValue);//lblToPartyCode.Text);
                    hash.Add("@dtSiDate", dtpInvoicedate.Value.ToString("MM/dd/yyyy"));
                    hash.Add("@intStateCode", lblStateCode.Text);
                    hash.Add("@strLoomNo", txtLoomNo.Text);

                    //             @,@intCode,,,,,,
                    hash.Add("@strHSNCode", txtHSNNo.Text);
                    hash.Add("@strBrocker", cmbBroker.Text);

                    //***************************** Pass this values from xml below ********************
                    //hash.Add("@dtDcDate", dtpDcDate.Value.ToString("MM/dd/yyyy"));
                    //hash.Add("@intQuality", Convert.ToInt32(cmbQualityName.SelectedValue));
                    int noOfTage = 0;
                    for (int i = 0; i < dgvSut.Rows.Count; i++)
                    {
                        noOfTage = noOfTage + Convert.ToInt32(dgvSut.Rows[i].Cells[6].Value.ToString());
                    }

                    hash.Add("@intNoOfPiece", noOfTage);
                    hash.Add("@decMtrs", Convert.ToDecimal(lblTotalGridMtr.Text));
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

                    cmbSuppliverV = Convert.ToInt32(cmbFromParty.SelectedValue);
                    hash.Add("@intFromParty", cmbFromParty.SelectedValue);//Convert.ToInt32(lblFromPartyCode.Text));
                    hash.Add("@intBroker", cmbBroker.SelectedValue);//Convert.ToInt32(lblBrokerCode.Text));
                    hash.Add("@decSampleCut", 0);//Convert.ToDecimal(lblSampleCutMtr.Text));
                    hash.Add("@intShade", cmbShade.SelectedValue);//Convert.ToInt32(lblShade.Text));
                    hash.Add("@strPlace", txtPlace.Text);
                    hash.Add("@intContractCode", cmbContract.SelectedValue);
                    hash.Add("@strContractName", cmbContract.Text);

                    hash.Add("@decVatavPer", txtVatavPer.Text);
                    hash.Add("@decVatavAmt", txtVatavAmt.Text);
                    hash.Add("@intPaymentDays", txtPaymentDays.Text);
                    //,
                    hash.Add("@inttotalNoOfTage", Convert.ToInt32(txtTotalTage.Text));
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

                    for (int k = 0; k < dgvSut.Rows.Count; k++)
                    {

                        DateTime Date;
                        Date = Convert.ToDateTime(dgvSut.Rows[k].Cells[3].Value.ToString());

                        string ConvertedDate = Date.ToString("MM/dd/yyyy");


                        xmlClassMaster.Append("<Row>");
                        xmlClassMaster.Append("<DC_ID>" + (Convert.ToInt32(dgvSut.Rows[k].Cells[1].Value)) + "</DC_ID>");
                        xmlClassMaster.Append("<DC_CODE>" + (Convert.ToInt32(dgvSut.Rows[k].Cells[2].Value)) + "</DC_CODE>");
                        xmlClassMaster.Append("<DC_Date>" + ConvertedDate + "</DC_Date>");

                        xmlClassMaster.Append("<Design_Id>" + (Convert.ToInt32(dgvSut.Rows[k].Cells[9].Value)) + "</Design_Id>");

                        xmlClassMaster.Append("<TotalNoTage>" + (Convert.ToInt32(dgvSut.Rows[k].Cells[6].Value)) + "</TotalNoTage>");
                        xmlClassMaster.Append("<TotalMtr>" + (Convert.ToDecimal(dgvSut.Rows[k].Cells[7].Value)) + "</TotalMtr>");
                        xmlClassMaster.Append("<SampleMtr>" + (Convert.ToDecimal(dgvSut.Rows[k].Cells[8].Value)) + "</SampleMtr>");
                        xmlClassMaster.Append("<DeliveryChalanUniqueCode>" + (dgvSut.Rows[k].Cells[10].Value.ToString()) + "</DeliveryChalanUniqueCode>");
                        xmlClassMaster.Append("<rate>" + (Convert.ToDecimal(dgvSut.Rows[k].Cells[11].Value)) + "</rate>");
                        xmlClassMaster.Append("<amount>" + (Convert.ToDecimal(dgvSut.Rows[k].Cells[12].Value)) + "</amount>");
                        xmlClassMaster.Append("<CompChalanNo>" + dgvSut.Rows[k].Cells[13].Value.ToString() + "</CompChalanNo>");
                        xmlClassMaster.Append("</Row>");
                    }

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvSut.Rows.Count > 0)
            {
            }
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please add delivery chaln no";
                frm.type = "error";
                frm.ShowDialog();
            }

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

                if (Convert.ToInt32(strReturnMSG) > 0)
                {

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

                    //ClsDefination.Readpath();
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
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = strReturnMSG;
                frm.type = "error";
                frm.ShowDialog();
            }

        }


        public void LowerCalculation()
        {
            try
            {

                //lblTotalAdd.Text = Math.Round(
                //    Convert.ToDecimal(txtPacking.Text) + Convert.ToDecimal(txtChecking.Text) + Convert.ToDecimal(txtAddOther.Text), 2
                //    ).ToString();

                //lblTotalLess.Text = Math.Round(
                //    Convert.ToDecimal(txtSecond.Text) + Convert.ToDecimal(txtTP.Text) + Convert.ToDecimal(txtSL.Text)
                //    + Convert.ToDecimal(txtFold.Text) + Convert.ToDecimal(txtOtherLess.Text), 2
                //    ).ToString();

                //lblTaxableValue.Text = Math.Round(Convert.ToDecimal(lbltotalAmt.Text) + Convert.ToDecimal(lblTotalAdd.Text)
                //    - Convert.ToDecimal(lblTotalLess.Text), 2).ToString();

                lblTotalGridMtr.Text = "0";

                for (int i = 0; i < dgvSut.Rows.Count; i++)
                {
                    lblTotalGridMtr.Text = Math.Round(Convert.ToDecimal(lblTotalGridMtr.Text) + Convert.ToDecimal(dgvSut.Rows[i].Cells[7].Value.ToString())
                        + Convert.ToDecimal(dgvSut.Rows[i].Cells[8].Value.ToString()), 2).ToString();
                    //txtRate.Text = dgvSut.Rows[i].Cells[11].Value.ToString();
                }

                if (chkBoxCalculation.Checked == true)
                {
                    lbltotalAmt.Text = Math.Round(Convert.ToDecimal(lblTotalGridMtr.Text) * Convert.ToDecimal(txtRate.Text), 2).ToString();
                }
                else
                {
                    lbltotalAmt.Text = Math.Round(Convert.ToDecimal(txtNoOfPices.Text) * Convert.ToDecimal(txtRate.Text), 2).ToString();
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


                //                lblTaxableValue.Text = Math.Round(Convert.ToDecimal(lblTaxableValue.Text) - Convert.ToDecimal(txtVatavAmt.Text), 2).ToString();





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

        private void txtPacking_Leave(object sender, EventArgs e)
        {
            if (txtPacking.Text == "")
            {
                txtPacking.Text = "0";
            }
            LowerCalculation();
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

                if (chkBoxCalculation.Checked == true)
                {
                    lbltotalAmt.Text = Math.Round(Convert.ToDecimal(lblTotalGridMtr.Text) * Convert.ToDecimal(txtRate.Text), 2).ToString();
                }
                else
                {
                    lbltotalAmt.Text = Math.Round(Convert.ToDecimal(txtNoOfPices.Text) * Convert.ToDecimal(txtRate.Text), 2).ToString();
                }

                lblTaxableValue.Text = lbltotalAmt.Text;

                LowerCalculation();
                txtPacking.Focus();
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

                if (QueryNo == 301 || QueryNo == 207)
                {
                    hash.Add("@intPArtyCode", cmbToParty.SelectedValue);
                }

                if (QueryNo == 2003 || QueryNo == 402)
                {
                    hash.Add("@intFromParty", cmbFromParty.SelectedValue);
                }
                if (QueryNo == 401 || QueryNo == 402 || QueryNo == 404)
                {
                    hash.Add("@intContractCode", cmbContract.SelectedValue);
                }
                if (QueryNo == 403)
                {
                    hash.Add("@intCode", cmbDcDetails.SelectedValue);
                }
                if (QueryNo == 405)
                {
                    hash.Add("@intCode", lblSrNo.Text);
                }
                if (QueryNo == 402)
                {
                    hash.Add("@intNewOrEdit", newOrEdit);
                }

                dtReturn = ClsDefination.FillData("[Transaction_SalesInvoice_DML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 201)
                    {
                        cmbQuality.DataSource = dtReturn;
                        cmbQuality.DisplayMember = "Q_Name";
                        cmbQuality.ValueMember = "Q_Code";
                        cmbQuality.SelectedValue = -1;
                        cmbQuality.Text = "<Select>";
                    }
                    else if (QueryNo == 202)
                    {
                        //,L_ShadeName+ ' - '+L_ShadeLocation as [Shade]
                        cmbShade.DataSource = dtReturn;
                        cmbShade.DisplayMember = "Shade";
                        cmbShade.ValueMember = "L_Code";

                    }
                    else if (QueryNo == 203 || QueryNo == 2003)
                    {
                        //P_Code,P_CompanyName+' - '+P_OwnerName as [Party]
                        cmbToParty.DataSource = dtReturn;
                        cmbToParty.DisplayMember = "Party";
                        cmbToParty.ValueMember = "P_Code";
                        cmbToParty.SelectedIndex = -1;
                        cmbToParty.Text = "<Select>";
                    }
                    else if (QueryNo == 204)
                    {
                        //,
                        cmbBroker.DataSource = dtReturn;
                        cmbBroker.DisplayMember = "BR_Name";
                        cmbBroker.ValueMember = "BR_Code";
                        cmbBroker.SelectedIndex = -1;
                        cmbBroker.Text = "<Select>";
                    }
                    else if (QueryNo == 205)
                    {
                        //,
                        cmbFromParty.DataSource = dtReturn;
                        cmbFromParty.DisplayMember = "F_CompanyName";
                        cmbFromParty.ValueMember = "F_Code";
                        cmbFromParty.SelectedIndex = -1;
                        cmbFromParty.Text = "<Select>";
                    }
                    else if (QueryNo == 207)
                    {
                        cmbContract.DataSource = dtReturn;
                        cmbContract.DisplayMember = "Contract";
                        cmbContract.ValueMember = "Contractcode";
                        cmbContract.SelectedIndex = -1;
                        cmbContract.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 301)
                    {
                        lblStateCode.Text = objRow["P_State"].ToString();
                        lblState.Text = objRow["Common_Value"].ToString();
                    }
                    else if (QueryNo == 401)
                    {
                        cmbBroker.SelectedValue = Convert.ToInt32(objRow["brokerCode"].ToString());
                        cmbBroker.Enabled = false;
                    }
                    else if (QueryNo == 402)
                    {
                        cmbDcDetails.DataSource = dtReturn;
                        cmbDcDetails.DisplayMember = "NAME";
                        cmbDcDetails.ValueMember = "ID";
                        cmbDcDetails.SelectedIndex = -1;
                        cmbDcDetails.Text = "<-- SELECT DC NO -->";
                    }
                    else if (QueryNo == 403)
                    {
                        txtDCNOValue.Text = objRow["DC NO"].ToString();
                        dtpInvoicedate.Text = dtpDcDate.Text = objRow["DATE"].ToString();
                        lblQualityName.Text = objRow["QUALITY"].ToString();
                        cmbQuality.Text = objRow["DESIGN"].ToString();
                        txtNoOfPices.Text = objRow["TOTAL PICES"].ToString();
                        txtTotalMtrs.Text = objRow["TOTAL MTR's"].ToString();
                        txtSampleCutMtr.Text = objRow["SAMPLE MTR's"].ToString();
                        lblQualityCode.Text = objRow["DESIGN ID"].ToString();
                        lblDeliveryUniqueCode.Text = objRow["UniqueCode"].ToString();
                        if (Convert.ToDecimal(objRow["Dar"].ToString()) > 0)
                        {
                            txtRate.Text = objRow["Dar"].ToString();
                        }
                        else
                        {
                            txtRate.Text = Math.Round(Convert.ToDecimal(objRow["PICK"].ToString()) * Convert.ToDecimal(objRow["rate"].ToString()), 2).ToString();
                        }
                        //   txtRate.Text = objRow["Dar"].ToString();
                        lblCompChalanNo.Text = objRow["CompChalanNo"].ToString();
                    }
                    else if (QueryNo == 404)
                    {
                        txtRate.Text = Math.Round(Convert.ToDecimal(objRow["Rate"].ToString()), 2).ToString();
                    }
                    else if (QueryNo == 405)
                    {
                        dgvSut.DataSource = dtReturn;

                    }

                }
                else
                {
                    if (QueryNo == 201)
                    {
                        cmbQuality.DataSource = dtReturn;
                        cmbQuality.SelectedValue = -1;
                        cmbQuality.Text = "<No Record>";
                    }
                    else if (QueryNo == 202)
                    {
                        //,L_ShadeName+ ' - '+L_ShadeLocation as [Shade]
                        cmbShade.DataSource = dtReturn;
                        cmbShade.SelectedIndex = -1;
                        cmbShade.Text = "<No Record>";
                    }
                    else if (QueryNo == 203)
                    {
                        //P_Code,P_CompanyName+' - '+P_OwnerName as [Party]
                        cmbToParty.DataSource = dtReturn;
                        cmbToParty.SelectedIndex = -1;
                        cmbToParty.Text = "<No Record>";
                    }
                    else if (QueryNo == 204)
                    {
                        //,
                        cmbBroker.DataSource = dtReturn;
                        cmbBroker.SelectedIndex = -1;
                        cmbBroker.Text = "<No Record>";
                    }
                    else if (QueryNo == 205)
                    {
                        //,
                        cmbFromParty.DataSource = dtReturn;
                        cmbFromParty.SelectedIndex = -1;
                        cmbFromParty.Text = "<No Record>";
                    }
                    else if (QueryNo == 207)
                    {
                        cmbContract.DataSource = dtReturn;
                        cmbContract.SelectedIndex = -1;
                        cmbContract.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 301)
                    {
                        lblStateCode.Text = "";
                        lblState.Text = "Error";
                    }
                    else if (QueryNo == 401)
                    {
                        //   cmbBroker.SelectedValue = Convert.ToInt32(objRow["brokerCode"].ToString());
                        cmbBroker.Enabled = true;
                    }
                    else if (QueryNo == 402)
                    {
                        cmbDcDetails.DataSource = dtReturn;
                        cmbDcDetails.SelectedIndex = -1;
                        cmbDcDetails.Text = "<-- NO DC NO AVAILABLE -->";
                    }
                    else if (QueryNo == 403)
                    {
                        txtDCNOValue.Text = "0";
                    }
                    else if (QueryNo == 404)
                    {
                        txtRate.Text = "0.00";
                    }
                    else if (QueryNo == 405)
                    {
                        dgvSut.DataSource = null;
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

        private void cmbToParty_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (pageLoad != 0)
            //{
            //    if (cmbToParty.SelectedIndex > -1)
            //    {
            //        FillGrid(301);
            //        FillGrid(207);

            //        if (Convert.ToInt32(lblStateCode.Text) == fd.StateId)
            //        {
            //            txtCGSTPer.Enabled = txtSGSTPer.Enabled =  true;
            //            txtGSTPer.Enabled = txtGSTAmt.Enabled = txtCGSTAmt.Enabled = txtSGSTAmt.Enabled = false;
            //        }
            //        else
            //        {
            //            txtCGSTPer.Enabled = txtGSTAmt.Enabled = txtCGSTAmt.Enabled = txtSGSTPer.Enabled = txtSGSTAmt.Enabled = false;
            //            txtGSTPer.Enabled =  true;
            //        }
            //    }
            //}
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
            if (chkBoxCalculation.Checked == true)
            {
                txtNoOfPices.Text = "0";
            }
            else
            {
                txtTotalMtrs.Text = "0";
            }
        }

        private void cmbFromParty_Leave(object sender, EventArgs e)
        {
            if (cmbFromParty.SelectedIndex > -1)
            {
                if (newOrEdit == 0)
                {
                    FillGrid(2003); // fill party from dc 
                }
                else
                {
                    cmbToParty.SelectedValue = cmbToPartyV;
                }
            }
        }

        private void cmbToParty_Leave(object sender, EventArgs e)
        {
            if (pageLoad != 0)
            {
                if (cmbToParty.SelectedIndex > -1)
                {
                    FillGrid(301);
                    if (newOrEdit == 0)
                    {
                        FillGrid(207);
                    }
                    else
                    {
                        cmbContract.SelectedValue = cmbContractV;
                    }
                    if (Convert.ToInt32(lblStateCode.Text) == fd.StateId)
                    {
                        txtCGSTPer.Enabled = txtSGSTPer.Enabled = true;
                        txtGSTPer.Enabled = txtGSTAmt.Enabled = txtCGSTAmt.Enabled = txtSGSTAmt.Enabled = false;
                    }
                    else
                    {
                        txtCGSTPer.Enabled = txtGSTAmt.Enabled = txtCGSTAmt.Enabled = txtSGSTPer.Enabled = txtSGSTAmt.Enabled = false;
                        txtGSTPer.Enabled = true;
                    }
                }
            }
        }

        private void cmbContract_Leave(object sender, EventArgs e)
        {
            if (cmbContract.SelectedIndex > -1)
            {
                if (newOrEdit == 0)
                {
                    FillGrid(401); // getting broker code

                    FillGrid(404);// getting rate from contract Pick * Rate
                }
                FillGrid(402);// getting delivery details
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbDcDetails.SelectedIndex > -1)
            {
                FillGrid(403);
                GridCreation();
                gridFill();
                LowerCalculation();
                // FillGrid(404);
            }
        }


        public void gridFill()
        {
            try
            {

                if (cmbDcDetails.SelectedIndex > -1)
                {
                    int repeat = 0;

                    if (dgvSut.Rows.Count > 0)
                    {
                        for (int i = 0; i < dgvSut.Rows.Count; i++)
                        {
                            if (Convert.ToInt32(dgvSut.Rows[i].Cells[1].Value) == Convert.ToInt32(cmbDcDetails.SelectedValue))
                            {
                                repeat = 1;
                                break;
                            }

                            if (Convert.ToDecimal(dgvSut.Rows[i].Cells[11].Value) != Convert.ToDecimal(txtRate.Text))
                            {
                                repeat = 2;
                                break;
                            }

                        }
                    }
                    if (repeat == 0)
                    {
                        DataTable dt = dgvSut.DataSource as DataTable;

                        DataRow dr2 = dt.NewRow();
                        dr2["X"] = "X";
                        dr2["DC ID"] = Convert.ToInt32(cmbDcDetails.SelectedValue);
                        dr2["DC NO"] = txtDCNOValue.Text;
                        dr2["DATE"] = dtpDcDate.Value.ToString("MM/dd/yyyy");
                        dr2["QUALITY"] = lblQualityName.Text;
                        dr2["DESIGN"] = cmbQuality.Text;
                        dr2["TOTAL PICES"] = Convert.ToInt32(txtNoOfPices.Text);
                        dr2["TOTAL MTR's"] = Convert.ToDecimal(txtTotalMtrs.Text);
                        dr2["SAMPLE MTR's"] = Convert.ToDecimal(txtSampleCutMtr.Text);
                        dr2["DESIGN ID"] = Convert.ToInt32(lblQualityCode.Text);
                        dr2["DeliveryChalanUniqueCode"] = lblDeliveryUniqueCode.Text;
                        dr2["rate"] = Convert.ToDecimal(txtRate.Text);
                        dr2["amount"] = Convert.ToDecimal(txtRate.Text) * (Convert.ToDecimal(txtTotalMtrs.Text) + Convert.ToDecimal(txtSampleCutMtr.Text));
                        dr2["CompChalanNo"] = lblCompChalanNo.Text;
                        dt.Rows.Add(dr2);

                        dgvSut.DataSource = dt;
                    }
                    else
                    {
                        messageBox frm = new messageBox();
                        if (repeat == 1)
                        {
                            frm.messageTxt = "Selected DC is already added to the list";
                        }
                        else
                        {
                            frm.messageTxt = "Ohh...!Rate must be same";
                        }
                        frm.type = "error";
                        frm.ShowDialog();
                    }
                }
                else
                {
                    messageBox frm = new messageBox();
                    frm.messageTxt = "Please select DC No";
                    frm.type = "error";
                    frm.ShowDialog();
                    //txtPanna.Focus();
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                cmbDcDetails.SelectedIndex = -1;
                cmbDcDetails.Text = "<-- SELECT DC NO -->";
                txtDCNOValue.Text = "0";
                lblQualityName.Text = "";
                cmbQuality.Text = "";
                txtNoOfPices.Text = "0";
                txtTotalMtrs.Text = "0";
                txtSampleCutMtr.Text = "0";
                lblQualityCode.Text = "0";
                lblCompChalanNo.Text = "";
                cmbDcDetails.Focus();
            }
        }

        private void dgvSut_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvSut.CurrentCell.ColumnIndex == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure to delete the record?", "Delete record", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        dgvSut.Rows.RemoveAt(dgvSut.CurrentRow.Index);
                        LowerCalculation();
                    }
                }
            }
            catch
            { }
        }


    }
}
