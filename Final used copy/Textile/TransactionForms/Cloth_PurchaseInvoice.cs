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
    public partial class Cloth_PurchaseInvoice : Form
    {
        public Cloth_PurchaseInvoice()
        {
            InitializeComponent();
        }

        #region variables
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        BindingSource bs = new BindingSource();
        BindingSource bsOriginal = new BindingSource();
        string strReturnMSG, strReturnRefNo;
        int intReturnPKNo;
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
                hash.Add("@intCompanyId", Convert.ToInt32(fd.CompId));
                hash.Add("@intYearId", Convert.ToInt32(fd.YearId));

                if (QueryNo == 301)
                {
                    hash.Add("@intSupplier", Convert.ToInt32(lblFromPartyCode.Text));
                }

                dtReturn = ClsDefination.FillData("[Transaction_PurchaseInvoiceDml]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 301)
                    {
                        lblStateCode.Text = objRow["P_State"].ToString();

                        if (Convert.ToInt32(lblStateCode.Text) == fd.StateId)
                        {
                            txtCGSTPer.Enabled = txtSGSTPer.Enabled = true;
                            txtCGSTPer.ReadOnly = txtSGSTPer.ReadOnly = false;
                            
                            txtGSTPer.Enabled = false;
                        }
                        else
                        {
                            txtCGSTPer.Enabled = txtSGSTPer.Enabled = txtGSTPer.ReadOnly = false;
                            txtGSTPer.Enabled =  true;
                        }
                    }

                }
                else
                {
                    if (QueryNo == 301)
                    {
                        lblStateCode.Text = "0";
                        txtCGSTPer.Enabled = false;
                        txtSGSTPer.Enabled = false;
                        txtGSTPer.Enabled = false;
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

                if (QueryNo == 501 || QueryNo == 502)
                {

                    if (QueryNo == 502)
                    {
                        hash.Add("@strUniqueCode", lblUniqueCode.Text);
                        hash.Add("@intCode", lblSrNo.Text);
                 
                    }

                    hash.Add("@strInvoiceNo", txtInvoiceNo.Text);

                    hash.Add("@strDC_Code", txtDCNOValue.Text);
                    hash.Add("@intOnFirmCode", Convert.ToInt32( lblOnFirmCode.Text));
                    hash.Add("@dtpPI_Date", dtpInvoicedate.Value.ToString("MM/dd/yyyy"));
                    hash.Add("@intstateCode", lblStateCode.Text);
                    hash.Add("@strloomNo", txtLoomNo.Text);

                    //             @,@intCode,,,,,,
                    hash.Add("@strhsnCode", txtHSNNo.Text);
                    hash.Add("@strbrocker", lblBrokerName.Text);
                    hash.Add("@dtpDC_Date", dtpDcDate.Value.ToString("MM/dd/yyyy"));
                    hash.Add("@intQuality", Convert.ToInt32(lblQualityCode.Text));
                    hash.Add("@intNoOfPiece", Convert.ToInt32(txtPiecevalue.Text));
                    hash.Add("@decMtrs", Convert.ToDecimal(txtTotalMtrs.Text));
                    hash.Add("@decrate", Convert.ToDecimal(txtRate.Text));
                    hash.Add("@dectotalAmt", Convert.ToDecimal(lbltotalAmt.Text));
                    //,,,,,,,,
                   
                    hash.Add("@dectaxableAmt", Convert.ToDecimal(lblTaxableValue.Text));
                    hash.Add("@deccgstPer", Convert.ToDecimal(txtCGSTPer.Text));
                    hash.Add("@deccgstAmt", Convert.ToDecimal(txtCGSTAmt.Text));
                    hash.Add("@decsgstPer", Convert.ToDecimal(txtSGSTPer.Text));
                    hash.Add("@decsgstAmt", Convert.ToDecimal(txtSGSTAmt.Text));
                    hash.Add("@decigstPer", Convert.ToDecimal(txtGSTPer.Text));
                    hash.Add("@decigstAmt", Convert.ToDecimal(txtGSTAmt.Text));
                    hash.Add("@decTotalGst", Convert.ToDecimal(lblGSTAmt.Text));
                    //,,,,,,,,
                    hash.Add("@decROff", Convert.ToDecimal(txtROFF.Text));
                    hash.Add("@decGrandTotal", Convert.ToDecimal(lblGrandTotalAmt.Text));
                    

                    hash.Add("@decpacking", Convert.ToDecimal(txtPacking.Text));
                    hash.Add("@decchecking", Convert.ToDecimal(txtChecking.Text));
                    hash.Add("@decother", Convert.ToDecimal(txtAddOther.Text));
                    hash.Add("@dectotalAdd", Convert.ToDecimal(lblTotalAdd.Text));
                    hash.Add("@decsecand", Convert.ToDecimal(txtSecond.Text));
                    hash.Add("@dectp", Convert.ToDecimal(txtTP.Text));
                    hash.Add("@decsl", Convert.ToDecimal(txtSL.Text));
                    hash.Add("@decfold", Convert.ToDecimal(txtFold.Text));
                    hash.Add("@decotherLess", Convert.ToDecimal(txtOtherLess.Text));
                    hash.Add("@dectotalLess", Convert.ToDecimal(lblTotalLess.Text));
                    
                    hash.Add("@intfromParty", Convert.ToInt32(lblFromPartyCode.Text));
                    hash.Add("@intbrokerCode", Convert.ToInt32(lblBrokerCode.Text));
                    hash.Add("@decsampleCuts", Convert.ToDecimal(txtSampleCutMtr.Text));
                    hash.Add("@intShade", Convert.ToInt32(lblShadeCode.Text));

                    //hash.Add("@strPlace", lblp);
                    hash.Add("@intcontractCode", Convert.ToInt32(lblContractCode.Text));
                    hash.Add("@strContractName", lblContractName.Text);
                }

                okflag = 1;
                return ClsDefination.InsertExecute(hash, "[Transaction_PurchaseInvoiceDml]", ref strReturnMSG, ref strReturnNo, ref intReturnNo);
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






        #region Calculations

        public void calculation()
        {
            try
            {
                lbltotalAmt.Text = Math.Round(Convert.ToDecimal(txtTotalMtrs.Text) * Convert.ToDecimal(txtRate.Text), 2).ToString();


    // 99                if (FOLD > 0) {
    // 1  const per = 100 - FOLD;
    // 99  mtr = this.Total_Meters.value - ((this.Total_Meters.value / 100) * per);
    //  console.log("FOLD IS "+ FOLD + " Mtr is "+mtr);
    // 99 * rate   FOLD= mtr * this.Rate.value;
    // 100*rate - 99 * rate  FOLD = (this.Total_Meters.value * this.Rate.value)-FOLD;
    //  console.log("Fold Amount is "+FOLD);
    //}
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


                lblTotalAdd.Text = Math.Round(Convert.ToDecimal(txtPacking.Text)+Convert.ToDecimal(txtChecking.Text)+Convert.ToDecimal(txtAddOther.Text),2).ToString();
                lblTotalLess.Text = Math.Round(Convert.ToDecimal(txtSecond.Text) + Convert.ToDecimal(txtTP.Text) + Convert.ToDecimal(txtSL.Text) + fold +
                    Convert.ToDecimal(txtOtherLess.Text), 2).ToString();

                lblTaxableValue.Text = Math.Round(Convert.ToDecimal(lbltotalAmt.Text) + Convert.ToDecimal(lblTotalAdd.Text) - Convert.ToDecimal(lblTotalLess.Text),2).ToString();


                if (Convert.ToInt32(lblStateCode.Text) == fd.StateId)
                {
                    txtCGSTAmt.Text = Math.Round((Convert.ToDecimal(lblTaxableValue.Text) / 100) * Convert.ToDecimal(txtCGSTPer.Text), 2).ToString();
                    txtSGSTAmt.Text = Math.Round((Convert.ToDecimal(lblTaxableValue.Text) / 100) * Convert.ToDecimal(txtSGSTPer.Text), 2).ToString();

                    lblGSTAmt.Text = Math.Round(Convert.ToDecimal(txtCGSTAmt.Text) + Convert.ToDecimal(txtSGSTAmt.Text),2).ToString();
                }
                else
                {
                    txtGSTAmt.Text = Math.Round((Convert.ToDecimal(lblTaxableValue.Text) / 100) * Convert.ToDecimal(txtGSTPer.Text), 2).ToString();
                    lblGSTAmt.Text = txtGSTAmt.Text;
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
                messageBox frm = new messageBox();
                frm.messageTxt = "Something went wrong in calculation";
                frm.type = "error";
                frm.ShowDialog();
            }
        }



        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Cloth_PurchaseInvoice_Load(object sender, EventArgs e)
        {
            FillGrid(301);
        }


        #region Text box leave
        private void txtRate_Leave(object sender, EventArgs e)
        {
            try
            {
                if(txtRate.Text =="")
                {
                    txtRate.Text="0";
                }
                if (Convert.ToDecimal(txtRate.Text) <= 0)
                {
                    //calculation();
                    messageBox frm = new messageBox();
                    frm.messageTxt = "Please enter rate";
                    frm.type = "error";
                    frm.ShowDialog();
                    txtRate.Focus();
                }
                else
                {
                    calculation();
                }
            }
            catch(Exception ex)
            {
            }
        }

        private void txtPacking_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtPacking.Text == "")
                {
                    txtPacking.Text = "0";
                }
                if (Convert.ToDecimal(txtPacking.Text) < -9856230)
                {

                }
                else
                {
                    calculation();
                }
            }
            catch (Exception ex)
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please enter valid value in Packing";
                frm.type = "error";
                frm.ShowDialog();
                txtPacking.Text = "0";
                txtPacking.Focus();
            }
        }

        private void txtChecking_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtChecking.Text == "")
                {
                    txtChecking.Text = "0";
                }
                if (Convert.ToDecimal(txtChecking.Text) < -9856230)
                {

                }
                else
                {
                    calculation();
                }
            }
            catch (Exception ex)
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please enter valid value fro Checking";
                frm.type = "error";
                frm.ShowDialog();
                txtChecking.Text = "0";
                txtChecking.Focus();
            }
        }

        private void txtAddOther_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtAddOther.Text == "")
                {
                    txtAddOther.Text = "0";
                }
                if (Convert.ToDecimal(txtAddOther.Text) < -9856230)
                {

                }
                else
                {
                    calculation();
                }
            }
            catch (Exception ex)
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please enter valid value in Other";
                frm.type = "error";
                frm.ShowDialog();
                txtAddOther.Text = "0";
                txtAddOther.Focus();
            }
        }

        private void txtSecond_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtSecond.Text == "")
                {
                    txtSecond.Text = "0";
                }
                if (Convert.ToDecimal(txtSecond.Text) < -9856230)
                {

                }
                else
                {
                    calculation();
                }
            }
            catch (Exception ex)
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please enter valid value in Second";
                frm.type = "error";
                frm.ShowDialog();
                txtSecond.Text = "0";
                txtSecond.Focus();
            }
        }

        private void txtTP_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtTP.Text == "")
                {
                    txtTP.Text = "0";
                }
                if (Convert.ToDecimal(txtTP.Text) < -9856230)
                {

                }
                else
                {
                    calculation();
                }
            }
            catch (Exception ex)
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please enter valid value in TP";
                frm.type = "error";
                frm.ShowDialog();
                txtTP.Text = "0";
                txtTP.Focus();
            }
        }

        private void txtSL_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtSL.Text == "")
                {
                    txtSL.Text = "0";
                }
                if (Convert.ToDecimal(txtSL.Text) < -9856230)
                {

                }
                else
                {
                    calculation();
                }
            }
            catch (Exception ex)
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please enter valid value in SL";
                frm.type = "error";
                frm.ShowDialog();
                txtSL.Text = "0";
                txtSL.Focus();
            }
        }

        private void txtFold_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtFold.Text == "")
                {
                    txtFold.Text = "0";
                }
                if (Convert.ToDecimal(txtFold.Text) < -9856230)
                {

                }
                else
                {
                    calculation();
                }
            }
            catch (Exception ex)
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please enter valid value in Fold";
                frm.type = "error";
                frm.ShowDialog();
                txtFold.Text = "0";
                txtFold.Focus();
            }
        }

        private void txtOtherLess_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtOtherLess.Text == "")
                {
                    txtOtherLess.Text = "0";
                }
                if (Convert.ToDecimal(txtOtherLess.Text) < -9856230)
                {

                }
                else
                {
                    calculation();
                }
            }
            catch (Exception ex)
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please enter valid value in Other";
                frm.type = "error";
                frm.ShowDialog();
                txtOtherLess.Text = "0";
                txtOtherLess.Focus();
            }
        }

        private void txtCGSTPer_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtGSTPer.Text == "")
                {
                    txtCGSTPer.Text = "0";
                }
                if (Convert.ToDecimal(txtCGSTPer.Text) < -9856230)
                {

                }
                else
                {
                    calculation();
                }
            }
            catch (Exception ex)
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please enter valid value for CGST%";
                frm.type = "error";
                frm.ShowDialog();
                txtCGSTPer.Text = "0";
                txtCGSTPer.Focus();
            }
        }

        private void txtSGSTPer_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtSGSTPer.Text == "")
                {
                    txtSGSTPer.Text = "0";
                }
                if (Convert.ToDecimal(txtSGSTPer.Text) < -9856230)
                {

                }
                else
                {
                    calculation();
                }
            }
            catch (Exception ex)
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please enter valid value SGST %";
                frm.type = "error";
                frm.ShowDialog();
                txtSGSTPer.Text = "0";
                txtSGSTPer.Focus();
            }
        }

        private void txtGSTPer_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtGSTPer.Text == "")
                {
                    txtGSTPer.Text = "0";
                }
                if (Convert.ToDecimal(txtGSTPer.Text) < -9856230)
                {

                }
                else
                {
                    calculation();
                }
            }
            catch (Exception ex)
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please enter valid value IGST %";
                frm.type = "error";
                frm.ShowDialog();
                txtGSTPer.Text = "0";
                txtGSTPer.Focus();
            }
        }

        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
        
            if (newOrEdit == 0)
            {
                SaveData(501, ref strReturnMSG, ref strReturnRefNo, ref intReturnPKNo);
            }
            else
            {
                SaveData(502, ref strReturnMSG, ref strReturnRefNo, ref intReturnPKNo);
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

                    this.Close();
                }
            }

        }



    }
}
