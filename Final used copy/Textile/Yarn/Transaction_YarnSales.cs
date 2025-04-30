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
    public partial class Transaction_YarnSales : Form
    {
        public Transaction_YarnSales()
        {
            InitializeComponent();
        }

        #region variables
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        public int cmbSuppliverV, cmbTaxableV, cmbInvoiceV, cmbFirmV, cmbShadeV, cmbAccV, cmbPaidByV;
        string strReturnMSG, strReturnRefNo;
        int intReturnPKNo, repete, pageLoad = 0;
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

                if (QueryNo == 102)
                {
                    // hash.Add("@intCode", Convert.ToInt32(lblSrNo.Text));
                    hash.Add("@strUniqueCode", lblUniqueCode.Text);
                    hash.Add("@intInvoiceCode",lblSrNo.Text);
                }
                if (QueryNo == 301)
                {
                    hash.Add("@intFromParty", cmbSupplier.SelectedValue);
                }
                if (QueryNo == 209)
                {
                    hash.Add("@intShade", cmbShadeName.SelectedValue);
                }



                if (QueryNo == 210 || QueryNo == 211 || QueryNo == 212 || QueryNo == 213)
                {
                    if (QueryNo == 210 || QueryNo == 211 || QueryNo == 212 || QueryNo == 213)
                    {
                        hash.Add("@intShade", cmbShadeName.SelectedValue);
                      
                    }
                    if (QueryNo == 210 || QueryNo == 211 || QueryNo == 212 || QueryNo == 213)
                    {
                        hash.Add("@intYarn", cmbProduct.SelectedValue);
                    }
                    if (QueryNo == 210 || QueryNo == 212 || QueryNo == 213)
                    {
                        hash.Add("@intSutUse", cmbWarfWeft.SelectedValue);
                    }
                    if (QueryNo == 210 || QueryNo == 213)
                    {
                        hash.Add("@decCount", cmbCount.SelectedValue);
                    }
                    if (QueryNo == 210)
                    {
                        hash.Add("@strColor", cmbColor.Text);
                    }

                }

                //        SY.companyId=@intCompanyId and SY.shade= and SY.SutType=
                //and SY.SutUse= and SY.Count= and SY.Color=

                dtReturn = ClsDefination.FillData("[Transaction_YarnSales_DML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];
                    if (QueryNo == 102)
                    {
                        dgvPurchaseDetail.DataSource = dtReturn;
                        GridValidation();
                    }
                    else if (QueryNo == 201)
                    {
                        cmbSupplier.DataSource = dtReturn;
                        cmbSupplier.ValueMember = "P_Code";
                        cmbSupplier.DisplayMember = "part";
                        cmbSupplier.SelectedIndex = -1;
                        cmbSupplier.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 301)
                    {
                        lblStateCode.Text = objRow["P_State"].ToString();

                    }
                    else if (QueryNo == 202)
                    {
                        cmbTaxable.DataSource = dtReturn;
                        cmbTaxable.DisplayMember = "Common_Value";
                        cmbTaxable.ValueMember = "Common_Id";
                        cmbTaxable.SelectedIndex = -1;
                        cmbTaxable.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 206)
                    {
                        cmbLocation.DataSource = dtReturn;
                        cmbLocation.DisplayMember = "LOCATION";
                        cmbLocation.ValueMember = "L_Code";
                        cmbLocation.SelectedIndex = -1;
                        cmbLocation.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 207)
                    {
                        cmbShadeName.DataSource = dtReturn;
                        cmbShadeName.DisplayMember = "LOCATION";
                        cmbShadeName.ValueMember = "L_Code";
                        cmbShadeName.SelectedIndex = -1;
                        cmbShadeName.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 208)
                    {
                        cmbFirmName.DataSource = dtReturn;
                        cmbFirmName.DisplayMember = "F_CompanyName";
                        cmbFirmName.ValueMember = "F_Code";
                        cmbFirmName.SelectedIndex = -1;
                        cmbFirmName.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 209)
                    {
                        cmbProduct.DataSource = dtReturn;
                        cmbProduct.DisplayMember = "S_Name";
                        cmbProduct.ValueMember = "SutType";
                        cmbProduct.SelectedIndex = -1;
                        cmbProduct.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 210)
                    {
                        lblAvailableYarn.Text = objRow["Available"].ToString();
                        //txtCGSTPer.Text = objRow["S_CGST"].ToString();
                        //txtSGSTPer.Text = objRow["S_SGST"].ToString();
                        //txtGSTPer.Text = objRow["S_IGST"].ToString();

                        
                    }
                    else if (QueryNo == 211)
                    {
                        //SY.SutUse,CV.Common_Value
                        cmbWarfWeft.DataSource = dtReturn;
                        cmbWarfWeft.DisplayMember = "Common_Value";
                        cmbWarfWeft.ValueMember = "SutUse";
                        cmbWarfWeft.SelectedIndex = -1;
                        cmbWarfWeft.Text = "<--SELECT-->";
                    }

                    else if (QueryNo == 212)
                    {
                        cmbCount.DataSource = dtReturn;
                        cmbCount.DisplayMember = "Count";
                        cmbCount.ValueMember = "Count";
                        cmbCount.SelectedIndex = -1;
                        cmbCount.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 213)
                    {
                        cmbColor.DataSource = dtReturn;
                        cmbColor.DisplayMember = "Color";
                        cmbColor.SelectedIndex = -1;
                        cmbColor.Text = "<--SELECT-->";
                    }
                }
                else
                {
                    if (QueryNo == 201)
                    {
                        cmbSupplier.DataSource = dtReturn;
                        cmbSupplier.SelectedIndex = -1;
                        cmbSupplier.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 202)
                    {
                        cmbTaxable.DataSource = dtReturn;
                        cmbTaxable.SelectedIndex = -1;
                        cmbTaxable.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 206)
                    {
                        cmbLocation.DataSource = dtReturn;
                        cmbLocation.SelectedIndex = -1;
                        cmbLocation.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 207)
                    {
                        cmbShadeName.DataSource = dtReturn;
                        cmbShadeName.SelectedIndex = -1;
                        cmbShadeName.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 208)
                    {
                        cmbFirmName.DataSource = dtReturn;
                        cmbFirmName.SelectedIndex = -1;
                        cmbFirmName.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 209)
                    {
                        cmbProduct.DataSource = dtReturn;
                        cmbProduct.SelectedIndex = -1;
                        cmbProduct.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 210)
                    {
                        lblAvailableYarn.Text = "0";

                        txtCGSTPer.Text = "0";
                        txtSGSTPer.Text = "0";
                        txtGSTPer.Text = "0";
                    }
                    else if (QueryNo == 211)
                    {
                        //SY.SutUse,CV.Common_Value
                        cmbWarfWeft.DataSource = dtReturn;
                        cmbWarfWeft.SelectedIndex = -1;
                        cmbWarfWeft.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 212)
                    {
                        cmbCount.DataSource = dtReturn;
                        cmbCount.SelectedIndex = -1;
                        cmbCount.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 213)
                    {
                        cmbColor.DataSource = dtReturn;
                         cmbColor.SelectedIndex = -1;
                         cmbColor.Text = "<--NO RECORD-->";
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
                        hash.Add("@intInvoiceCode", lblSrNo.Text);
                        hash.Add("@intInvoiceNo",txtInvoiceNo.Text);
                    }
         
         //@,@,@,@decROFF,@,,GETDATE(),
         //,,1,,
                   
                    hash.Add("@dtpDate", dtpInvoicedate.Value.ToString("MM/dd/yyyy"));
                    hash.Add("@intParty", Convert.ToInt32(cmbSupplier.SelectedValue));
                    hash.Add("@intIsTaxable", Convert.ToInt32(cmbTaxable.SelectedValue));

                    hash.Add("@intFromParty", Convert.ToInt32(cmbFirmName.SelectedValue));
                    hash.Add("@intShade", Convert.ToInt32(cmbShadeName.SelectedValue));
                    hash.Add("@decTotalTaxable", Convert.ToDecimal(lblTaxableValue.Text));
                    hash.Add("@decTotalCgst", Convert.ToDecimal(lblCGSTAmount.Text));
                    hash.Add("@decTotalSgst", Convert.ToDecimal(lblSGSTAmount.Text));
                    hash.Add("@decTotalIgst", Convert.ToDecimal(lblIGSTAmount.Text));
                    hash.Add("@decGst", Convert.ToDecimal(lblGSTAmt.Text));
                    hash.Add("@decOther",Convert.ToDecimal(txtAdd.Text));
                    hash.Add("@decROFF",Convert.ToDecimal(txtROFF.Text));
                    hash.Add("@decGrandTotal",Convert.ToDecimal(lblGrandTotalAmt.Text));

                    string strXmlDetail = "";

                    StringBuilder xmlClassMaster = new StringBuilder();

                    for (int k = 0; k < dgvPurchaseDetail.Rows.Count; k++)
                    {
                        xmlClassMaster.Append("<Row>");
                        xmlClassMaster.Append("<yarnCode>" + ( Convert.ToInt32(dgvPurchaseDetail.Rows[k].Cells[2].Value)) + "</yarnCode>");
                        xmlClassMaster.Append("<mtr>" + (Convert.ToDecimal(dgvPurchaseDetail.Rows[k].Cells[3].Value)) + "</mtr>");
                        xmlClassMaster.Append("<rate>" + (Convert.ToDecimal(dgvPurchaseDetail.Rows[k].Cells[4].Value)) + "</rate>");
                        //  xmlClassMaster.Append("<P_Exp>" + ConvertedDate + "</P_Exp>");
                        xmlClassMaster.Append("<cgst>" + (Convert.ToDecimal(dgvPurchaseDetail.Rows[k].Cells[5].Value)) + "</cgst>");
                        xmlClassMaster.Append("<chstAmt>" + (Convert.ToDecimal(dgvPurchaseDetail.Rows[k].Cells[6].Value)) + "</chstAmt>");

                        xmlClassMaster.Append("<sgst>" + (Convert.ToDecimal(dgvPurchaseDetail.Rows[k].Cells[7].Value)) + "</sgst>");
                        xmlClassMaster.Append("<sgstAmt>" + (Convert.ToDecimal(dgvPurchaseDetail.Rows[k].Cells[8].Value)) + "</sgstAmt>");
                        xmlClassMaster.Append("<igst>" + (Convert.ToDecimal(dgvPurchaseDetail.Rows[k].Cells[9].Value)) + "</igst>");
                        xmlClassMaster.Append("<igstAmt>" + (Convert.ToDecimal(dgvPurchaseDetail.Rows[k].Cells[10].Value)) + "</igstAmt>");
                        xmlClassMaster.Append("<taxableAmount>" + (Convert.ToDecimal(dgvPurchaseDetail.Rows[k].Cells[11].Value)) + "</taxableAmount>");
                        xmlClassMaster.Append("<GstAmt>" + (Convert.ToDecimal(dgvPurchaseDetail.Rows[k].Cells[12].Value)) + "</GstAmt>");
                        xmlClassMaster.Append("<TotalAmount>" + (Convert.ToDecimal(dgvPurchaseDetail.Rows[k].Cells[13].Value)) + "</TotalAmount>");

                        xmlClassMaster.Append("<sutUse>" + (Convert.ToInt32(dgvPurchaseDetail.Rows[k].Cells[14].Value)) + "</sutUse>");
                        xmlClassMaster.Append("<count>" + (Convert.ToDecimal(dgvPurchaseDetail.Rows[k].Cells[15].Value)) + "</count>");
                        //,
                        xmlClassMaster.Append("<color>" + dgvPurchaseDetail.Rows[k].Cells[16].Value.ToString() + "</color>");


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
                return ClsDefination.InsertExecute(hash, "[Transaction_YarnSales_DML]", ref strReturnMSG, ref strReturnNo, ref intReturnNo);
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

        #region GRID CREATION & validation
        public void GridCreation()
        {
            try
            {

                DataTable dt = new DataTable();
                dt.Columns.Add("X", typeof(string));          //0
                dt.Columns.Add("YARN", typeof(string)); //1
                dt.Columns.Add("yarnCode", typeof(int)); //2
                dt.Columns.Add("METER's", typeof(string));//3
                dt.Columns.Add("RATE", typeof(decimal));//4
                dt.Columns.Add("CGST PER", typeof(decimal));//5
                dt.Columns.Add("CGST AMT", typeof(decimal));//6
                dt.Columns.Add("SGST PER", typeof(decimal));//7
                dt.Columns.Add("SGST AMT", typeof(decimal));//8
                dt.Columns.Add("IGST PER", typeof(decimal)); // 9
                dt.Columns.Add("IGST AMT", typeof(decimal)); // 10
                dt.Columns.Add("TAXABLE AMT", typeof(decimal)); // 11
                dt.Columns.Add("GST AMT", typeof(decimal));//12
                dt.Columns.Add("TOTAL AMT", typeof(decimal)); // 13
                dt.Columns.Add("sutUse", typeof(int));//14
                dt.Columns.Add("count", typeof(decimal));//15
                dt.Columns.Add("color", typeof(string));//16
                //dt.Columns.Add("Location", typeof(int));//14
                //dt.Columns.Add("LOCATION", typeof(string));//15
                //dt.Columns.Add("HSN", typeof(string)); //16
                dgvPurchaseDetail.DataSource = dt;

                GridValidation();
            }
            catch (Exception ex)
            {
            }
        }

        public void GridValidation()
        {
            //1,3,20 
            dgvPurchaseDetail.Columns[2].Visible = false;
            dgvPurchaseDetail.Columns[14].Visible = false;
            dgvPurchaseDetail.Columns[15].Visible = false;
            dgvPurchaseDetail.Columns[16].Visible = false;

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

        private void Transaction_YarnSales_Load(object sender, EventArgs e)
        {
            FillGrid(201); // party 
            FillGrid(202);// is Taxable
            FillGrid(206);// shade
            FillGrid(207);// location
            FillGrid(208);// firm
            // FillGrid(209);// Yarn Name
            GridCreation();

            if (newOrEdit == 1)
            {
                cmbSupplier.SelectedValue = cmbSuppliverV;
                cmbTaxable.SelectedValue = cmbTaxableV;
                cmbFirmName.SelectedValue = cmbFirmV;
                cmbShadeName.SelectedValue = cmbShadeV;

                FillGrid(102);
            }
        }

        private void cmbShadeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if ( Convert.ToInt32(cmbShadeName.SelectedValue) > 0)
            //{
            //    FillGrid(209);
            //}

            //if (cmbShadeName.SelectedValue == "System.Data.DataRowView" || Convert.ToInt32(cmbShadeName.SelectedValue) > 0)
            //{
            //    if (cmbShadeName.SelectedIndex > -1)
            //    {
            //        FillGrid(209);
            //    }
            //}
        }

        private void cmbShadeName_Leave(object sender, EventArgs e)
        {
            if (cmbShadeName.SelectedIndex > -1)
            {
                FillGrid(209);
            }
        }

        private void cmbProduct_Leave(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedIndex > -1)
            {
                FillGrid(211);
                //   FillGrid(210);
            }
        }

        private void cmbSupplier_Leave(object sender, EventArgs e)
        {
            if (cmbSupplier.SelectedIndex > -1)
            {
                FillGrid(301);
            }
        }

        private void txtPQty_Leave(object sender, EventArgs e)
        {
            if (txtPQty.Text == "")
            {
                txtPQty.Text = "1";
                upperCalculation();
            }
            else if (Convert.ToDecimal(txtPQty.Text) > Convert.ToDecimal(lblAvailableYarn.Text))
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Sales quantity is less than or equals to" + Environment.NewLine + "available yarn";
                frm.type = "error";
                frm.ShowDialog();
                //txtPQty.Text = "";
                txtPQty.Focus();
            }

        }


        #region //******************* Calculation

        public void upperCalculation()
        {
            try
            {
                decimal amt = Math.Round(Convert.ToDecimal(txtPRate.Text) * Convert.ToDecimal(txtPQty.Text), 2);
                txtCGSTAmt.Text = Math.Round((amt / 100) * Convert.ToDecimal(txtCGSTPer.Text), 2).ToString();
                txtSGSTAmt.Text = Math.Round((amt / 100) * Convert.ToDecimal(txtSGSTPer.Text), 2).ToString();
                txtGSTAmt.Text = Math.Round((amt / 100) * Convert.ToDecimal(txtGSTPer.Text), 2).ToString();
                lblTotalAmt.Text = Math.Round(amt + Convert.ToDecimal(txtCGSTAmt.Text) + Convert.ToDecimal(txtSGSTAmt.Text) + Convert.ToDecimal(txtGSTAmt.Text), 2).ToString();
            }
            catch (Exception ex)
            {
            }
        }

        public void lowerCalculation()
        {
            try
            {
                lblTaxableValue.Text = lblCGSTAmount.Text = lblSGSTAmount.Text = lblIGSTAmount.Text = lblGSTAmt.Text = "0";
                for (int i = 0; i < dgvPurchaseDetail.Rows.Count; i++)
                {
                    lblTaxableValue.Text = Math.Round(Convert.ToDecimal(lblTaxableValue.Text)+Convert.ToDecimal(dgvPurchaseDetail.Rows[i].Cells[11].Value.ToString()),2 ).ToString();
                    lblCGSTAmount.Text = Math.Round(Convert.ToDecimal(lblCGSTAmount.Text) + Convert.ToDecimal(dgvPurchaseDetail.Rows[i].Cells[6].Value.ToString()), 2).ToString();
                    lblSGSTAmount.Text = Math.Round(Convert.ToDecimal(lblSGSTAmount.Text) + Convert.ToDecimal(dgvPurchaseDetail.Rows[i].Cells[8].Value.ToString()), 2).ToString();
                    lblIGSTAmount.Text = Math.Round(Convert.ToDecimal(lblIGSTAmount.Text) + Convert.ToDecimal(dgvPurchaseDetail.Rows[i].Cells[10].Value.ToString()), 2).ToString();
                    lblGSTAmt.Text = Math.Round(Convert.ToDecimal(lblGSTAmt.Text) + Convert.ToDecimal(dgvPurchaseDetail.Rows[i].Cells[12].Value.ToString()), 2).ToString();
                }

                roffCalculation();
            }
            catch (Exception ex)
            {
            }
        }

        public void roffCalculation()
        {
            try
            {
                decimal d = Convert.ToDecimal(txtAdd.Text) + Convert.ToDecimal(lblTaxableValue.Text) + Convert.ToDecimal(lblGSTAmt.Text);

                int j = Convert.ToInt32(d);

                txtROFF.Text = Math.Round(j - d, 2).ToString();

                lblGrandTotalAmt.Text = j.ToString();
            }
            catch (Exception ex)
            {
            }
        }


        #endregion

        private void txtPRate_Leave(object sender, EventArgs e)
        {
            if (txtPRate.Text == "")
            {
                txtPRate.Text = "1";
            }


            upperCalculation();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                repete = 0;
                if (cmbProduct.SelectedIndex > -1)
                {
                    for (int i = 0; i < dgvPurchaseDetail.Rows.Count; i++)  //14 15 16
                    {
                        if (Convert.ToInt32(dgvPurchaseDetail.Rows[i].Cells[2].Value) == Convert.ToInt32( cmbProduct.SelectedValue)
                            && Convert.ToInt32(dgvPurchaseDetail.Rows[i].Cells[14].Value)== Convert.ToInt32(cmbWarfWeft.SelectedValue)
                            && Convert.ToDecimal(dgvPurchaseDetail.Rows[i].Cells[15].Value)== Convert.ToDecimal(cmbCount.Text)
                            && dgvPurchaseDetail.Rows[i].Cells[16].Value.ToString() == cmbColor.Text
                            )
                        {
                            repete = 1;
                        }
                    }


                    if (repete == 0)
                    {
                        DataTable dt = dgvPurchaseDetail.DataSource as DataTable;

                        DataRow dr2 = dt.NewRow();


                        dr2["X"] = "X";
                        //dt.Columns.Add("X", typeof(string));          //0
                        //dt.Columns.Add("YARN", typeof(string)); //1
                        dr2["YARN"] = cmbCount.Text.ToUpper()+' '+ cmbProduct.Text.ToUpper()+' '+cmbColor.Text.ToUpper();
                        //dt.Columns.Add("yarnCode", typeof(int)); //2
                        dr2["yarnCode"] = Convert.ToInt32(cmbProduct.SelectedValue);
                        //dt.Columns.Add("METER's", typeof(string));//3
                        dr2["METER's"] = Convert.ToDecimal(txtPQty.Text);
                        //dt.Columns.Add("RATE", typeof(decimal));//4
                        dr2["RATE"] = Convert.ToDecimal(txtPRate.Text);
                        //dt.Columns.Add("CGST PER", typeof(decimal));//5
                        dr2["CGST PER"] = Convert.ToDecimal(txtCGSTPer.Text);
                        //dt.Columns.Add("CGST AMT", typeof(decimal));//6
                        dr2["CGST AMT"] = Convert.ToDecimal(txtCGSTAmt.Text);
                        //dt.Columns.Add("SGST PER", typeof(decimal));//7
                        dr2["SGST PER"] = Convert.ToDecimal(txtSGSTPer.Text);
                        //dt.Columns.Add("SGST AMT", typeof(decimal));//8
                        dr2["SGST AMT"] = Convert.ToDecimal(txtSGSTAmt.Text);
                        //dt.Columns.Add("IGST PER", typeof(decimal)); // 9
                        dr2["IGST PER"] = Convert.ToDecimal(txtGSTPer.Text);
                        //dt.Columns.Add("IGST AMT", typeof(decimal)); // 10
                        dr2["IGST AMT"] = Convert.ToDecimal(txtGSTAmt.Text);
                        //dt.Columns.Add("TAXABLE AMT", typeof(decimal)); // 11
                        dr2["TAXABLE AMT"] = Convert.ToDecimal(txtPRate.Text) * Convert.ToDecimal(txtPQty.Text);
                        //dt.Columns.Add("GST AMT", typeof(decimal));//12
                        dr2["GST AMT"] = Convert.ToDecimal(txtCGSTAmt.Text) + Convert.ToDecimal(txtSGSTAmt.Text) + Convert.ToDecimal(txtGSTAmt.Text);
                        //dt.Columns.Add("TOTAL AMT", typeof(decimal)); // 13
                        dr2["TOTAL AMT"] = Convert.ToDecimal(lblTotalAmt.Text);

                        dr2["sutUse"] = Convert.ToInt32(cmbWarfWeft.SelectedValue);

                        dr2["count"] = Convert.ToDecimal(cmbCount.Text);

                        dr2["color"] = cmbColor.Text;

                        //dt.Columns.Add("sutUse", typeof(int));//14
                        //dt.Columns.Add("count", typeof(decimal));//15
                        //dt.Columns.Add("color", typeof(string));//16
                        
                        
                        //dt.Columns.Add("Location", typeof(int));//14
                        //dr2["Location"] = Convert.ToDecimal(txtPRate.Text);
                        //dt.Columns.Add("LOCATION", typeof(string));//15
                        //dt.Columns.Add("HSN", typeof(string)); //16

                        dt.Rows.Add(dr2);
                        dgvPurchaseDetail.DataSource = dt;
                    }
                    else
                    {
                        messageBox frm = new messageBox();
                        frm.messageTxt = "Product allready added";
                        frm.type = "error";
                        frm.ShowDialog();
                    }
                }
                else
                {
                    txtAdd.Focus();
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                GridValidation();
                lowerCalculation();
                //   gridCalculation();
                  defaultValue();
            }
        }

        public void defaultValue()
        {
            cmbProduct.SelectedIndex = -1;
            cmbProduct.Text = "<--SELECT-->";
            cmbWarfWeft.SelectedIndex = -1;
            cmbWarfWeft.Text = "<--SELECT-->";
            cmbCount.SelectedIndex = -1;
            cmbCount.Text = "<--SELECT-->";
            cmbColor.SelectedIndex = -1;
            cmbColor.Text = "<--SELECT-->";
            
            lblAvailableYarn.Text = "0";
            txtPQty.Text = "1";
            txtPRate.Text = "0";
            txtCGSTAmt.Text = txtCGSTPer.Text = txtSGSTAmt.Text = txtSGSTPer.Text = txtGSTAmt.Text = txtGSTPer.Text = lblTotalAmt.Text = "0";

            cmbProduct.Focus();
        }

        private void cmbWarfWeft_Leave(object sender, EventArgs e)
        {
            if (cmbWarfWeft.SelectedIndex > -1)
            {
                //FillGrid(211);
                FillGrid(212);
            }
        }

        private void cmbCount_Leave(object sender, EventArgs e)
        {
            if (cmbCount.SelectedIndex > -1)
            {
                //FillGrid(211);
                FillGrid(213);
            }
        }

        private void cmbColor_Leave(object sender, EventArgs e)
        {
            if (cmbColor.Text != "<--SELECT-->" && cmbColor.Text != "<--NO RECORD-->")
            {
                //FillGrid(211);
                FillGrid(210);
            }
        }

        private void txtAdd_Leave(object sender, EventArgs e)
        {
            if (txtAdd.Text == "")
            {
                txtAdd.Text = "0";
            }
            roffCalculation();
        }

        private void dgvPurchaseDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvPurchaseDetail.CurrentCell.ColumnIndex == 0)
                {
                    //"confirm"
                    DialogResult dialogResult = MessageBox.Show("Are you sure to delete the record?", "Delete record", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        dgvPurchaseDetail.Rows.RemoveAt(dgvPurchaseDetail.CurrentRow.Index);
                        upperCalculation();
                        lowerCalculation();
                    }
                }
            }
            catch
            { }
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

        private void txtCGSTPer_Leave(object sender, EventArgs e)
        {
            try
            {
                upperCalculation();
            }
            catch (Exception ex)
            {
            }
        }

        private void txtSGSTPer_Leave(object sender, EventArgs e)
        {
            try
            {
                upperCalculation();
            }
            catch (Exception ex)
            {
            }
        }

        private void txtGSTPer_Leave(object sender, EventArgs e)
        {
            try
            {
                upperCalculation();
            }
            catch (Exception ex)
            {
            }
        }

        private void cmbFirmName_Leave(object sender, EventArgs e)
        {

        }

        private void cmbTaxable_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbTaxable.SelectedValue) == 60)
            {
                if (Convert.ToInt32(fd.StateId) == Convert.ToInt32(lblStateCode.Text))
                {
                    txtCGSTPer.Enabled = true;
                    txtSGSTPer.Enabled = true;
                    txtGSTPer.Enabled = false;
                }
                else
                {
                    txtCGSTPer.Enabled = false;
                    txtSGSTPer.Enabled = false;
                    txtGSTPer.Enabled = true;
                }
            }
            else
            {
                txtCGSTPer.Enabled = false;
                txtSGSTPer.Enabled = false;
                txtGSTPer.Enabled = false;
                txtCGSTPer.Text = "0";
                txtSGSTPer.Text = "0";
                txtGSTPer.Text = "0";

            }
        }


    }
}
