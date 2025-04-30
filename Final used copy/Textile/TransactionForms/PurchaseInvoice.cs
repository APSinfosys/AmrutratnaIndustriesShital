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

namespace Textile.Transaction
{
    public partial class PurchaseInvoice : Form
    {
        public PurchaseInvoice()
        {
            InitializeComponent();
        }

        #region variables
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        public int cmbSuppliverV, cmbTaxableV,cmbInvoiceV,cmbFirmV,cmbShadeV,cmbAccV,cmbPaidByV;
        string strReturnMSG, strReturnRefNo;
        int intReturnPKNo, repete,pageLoad=0;
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
                }
                if (QueryNo == 301)
                {
                    hash.Add("@intSupplier", cmbSupplier.SelectedValue);
                }
                //if (QueryNo == 302)
                //{
                //    hash.Add("@intPCode", cmbProductName.SelectedValue);
                //}
                dtReturn = ClsDefination.FillData("[Transaction_PurchaseInvoiceDml]", hash);


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
                    else if (QueryNo == 202)
                    {
                        cmbTaxable.DataSource = dtReturn;
                        cmbTaxable.DisplayMember = "Common_Value";
                        cmbTaxable.ValueMember = "Common_Id";
                        cmbTaxable.SelectedIndex = 0;
                        //cmbTaxable.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 203)
                    {
                        cmbPaymentType.DataSource = dtReturn;
                        cmbPaymentType.DisplayMember = "Common_Value";
                        cmbPaymentType.ValueMember = "Common_Id";
                        cmbPaymentType.SelectedIndex = 0;
                        //cmbPaymentType.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 204)
                    {
                        cmbAcc.DataSource = dtReturn;
                        cmbAcc.DisplayMember = "BankName";
                        cmbAcc.ValueMember = "Acc_Code";
                        cmbAcc.SelectedIndex = 0;
                        //cmbAcc.Text = "<--SELECT-->";
                        //cmbAcc.Text;
                    }
                    else if (QueryNo == 205)
                    {
                        cmbPaidBy.DataSource = dtReturn;
                        cmbPaidBy.DisplayMember = "Common_Value";
                        cmbPaidBy.ValueMember = "Common_Id";
                        cmbPaidBy.SelectedIndex = 0;
                        //cmbPaidBy.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 206)
                    {
                        cmbLocation.DataSource = dtReturn;
                        cmbLocation.DisplayMember = "LOCATION";
                        cmbLocation.ValueMember = "L_Code";
                        cmbLocation.SelectedIndex = 0;
                        //cmbLocation.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 207)
                    {
                        cmbShadeName.DataSource = dtReturn;
                        cmbShadeName.DisplayMember = "LOCATION";
                        cmbShadeName.ValueMember = "L_Code";
                        cmbShadeName.SelectedIndex = 0;
                        //cmbShadeName.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 208)
                    {
                        cmbFirmName.DataSource = dtReturn;
                        cmbFirmName.DisplayMember = "F_CompanyName";
                        cmbFirmName.ValueMember = "F_Code";
                        cmbFirmName.SelectedIndex = -1;
                        cmbFirmName.Text = "<--SELECT-->";
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
                    else if (QueryNo == 203)
                    {
                        cmbPaymentType.DataSource = dtReturn;
                        cmbPaymentType.SelectedIndex = -1;
                        cmbPaymentType.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 204)
                    {
                        cmbAcc.DataSource = dtReturn;
                        cmbAcc.SelectedIndex = -1;
                        cmbAcc.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 205)
                    {
                        cmbPaidBy.DataSource = dtReturn;
                        cmbPaidBy.SelectedIndex = -1;
                        cmbPaidBy.Text = "<--NO RECORD-->";
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
                    hash.Add("@strInvoiceNo", txtInvoiceNo.Text);
                    hash.Add("@dtpInvoiceDate", dtpInvoicedate.Value.ToString("MM/dd/yyyy"));
                    hash.Add("@intSupplier", Convert.ToInt32(cmbSupplier.SelectedValue));
                    hash.Add("@intTaxable", Convert.ToInt32(cmbTaxable.SelectedValue));
                    hash.Add("@intPaymentType", Convert.ToInt32(cmbPaymentType.SelectedValue));
                    hash.Add("@decTaxable", Convert.ToDecimal(lblTaxableValue.Text));
                    hash.Add("@decTotalGst", Convert.ToDecimal(lblGSTAmt.Text));
                    hash.Add("@decAdd", Convert.ToDecimal(txtAdd.Text));
                    hash.Add("@decLess", Convert.ToDecimal(txtLess.Text));
                    hash.Add("@decROff", Convert.ToDecimal(txtROFF.Text));
                    hash.Add("@decGrandTotal", Convert.ToDecimal(lblGrandTotalAmt.Text));

                    hash.Add("@intPayFrmAcca", Convert.ToInt32(cmbAcc.SelectedValue));

                    if (Convert.ToInt32(cmbPaidBy.SelectedValue) == 0)
                    {
                        hash.Add("@intPaidBy", Convert.ToInt32(41));
                    }
                    else
                    {
                        hash.Add("@intPaidBy", Convert.ToInt32(cmbPaidBy.SelectedValue));
                    }
                    hash.Add("@strChkNo", txtChkNo.Text);
                    hash.Add("@dtpChkDate", dtpChkDate.Value.ToString("MM/dd/yyyy"));

                    hash.Add("@intShade1", cmbShadeName.SelectedValue);
                    hash.Add("@intFirm", cmbFirmName.SelectedValue);

                    //    ,
                    //           @,,,,,,,
                    //,,,,,@,GETDATE(),1,@,@,
                    //,,,


                    string strXmlDetail = "";

                    StringBuilder xmlClassMaster = new StringBuilder();

                    for (int k = 0; k < dgvPurchaseDetail.Rows.Count; k++)
                    {

                        //dt.Columns.Add("X", typeof(string));          //0
                        // //dt.Columns.Add("PRODUCT NAME", typeof(string)); //1
                        //  //dt.Columns.Add("P QTY", typeof(decimal));//2
                        //  //dt.Columns.Add("FREE QTY", typeof(decimal));//3
                        //  //dt.Columns.Add("P RATE", typeof(decimal));//4
                        //  //dt.Columns.Add("DISC AMT", typeof(decimal));//5
                        //dt.Columns.Add("SUB TOTAL", typeof(decimal));//6
                        //dt.Columns.Add("TAXABLE AMT", typeof(decimal));//7
                        //  //dt.Columns.Add("CGST PER", typeof(decimal)); // 8
                        ///   //dt.Columns.Add("CGST AMT", typeof(decimal)); // 9
                        //   //dt.Columns.Add("SGST PER", typeof(decimal)); // 10
                        //   //dt.Columns.Add("SGST AMT", typeof(decimal));//11
                        //   //dt.Columns.Add("IGST PER", typeof(decimal)); // 12
                        //    //dt.Columns.Add("IGST AMT", typeof(decimal));//13
                        //    //dt.Columns.Add("TOTAL AMT", typeof(decimal));//14
                        //dt.Columns.Add("TOTALPQTY", typeof(decimal)); //15
                        //    //dt.Columns.Add("LOACTION ID", typeof(int));//16
                        //dt.Columns.Add("LOCATION", typeof(string));//17

                        xmlClassMaster.Append("<Row>");
                        xmlClassMaster.Append("<ProductName>" + dgvPurchaseDetail.Rows[k].Cells[1].Value.ToString() + "</ProductName>");
                        xmlClassMaster.Append("<PQty>" + (Convert.ToDecimal(dgvPurchaseDetail.Rows[k].Cells[2].Value)) + "</PQty>");
                        xmlClassMaster.Append("<PRate>" + (Convert.ToDecimal(dgvPurchaseDetail.Rows[k].Cells[4].Value)) + "</PRate>");
                        //  xmlClassMaster.Append("<P_Exp>" + ConvertedDate + "</P_Exp>");
                        xmlClassMaster.Append("<PFreeQty>" + (Convert.ToDecimal(dgvPurchaseDetail.Rows[k].Cells[3].Value)) + "</PFreeQty>");
                        xmlClassMaster.Append("<PDisc>" + (Convert.ToDecimal(dgvPurchaseDetail.Rows[k].Cells[5].Value)) + "</PDisc>");

                        xmlClassMaster.Append("<CGSTPer>" + (Convert.ToDecimal(dgvPurchaseDetail.Rows[k].Cells[8].Value)) + "</CGSTPer>");
                        xmlClassMaster.Append("<CGSTAmt>" + (Convert.ToDecimal(dgvPurchaseDetail.Rows[k].Cells[9].Value)) + "</CGSTAmt>");
                        xmlClassMaster.Append("<SGSTPer>" + (Convert.ToDecimal(dgvPurchaseDetail.Rows[k].Cells[10].Value)) + "</SGSTPer>");
                        xmlClassMaster.Append("<SGSTAmt>" + (Convert.ToDecimal(dgvPurchaseDetail.Rows[k].Cells[11].Value)) + "</SGSTAmt>");
                        xmlClassMaster.Append("<IGSTPer>" + (Convert.ToDecimal(dgvPurchaseDetail.Rows[k].Cells[12].Value)) + "</IGSTPer>");
                        xmlClassMaster.Append("<IGSTAmt>" + (Convert.ToDecimal(dgvPurchaseDetail.Rows[k].Cells[13].Value)) + "</IGSTAmt>");
                        xmlClassMaster.Append("<NetAmt>" + (Convert.ToDecimal(dgvPurchaseDetail.Rows[k].Cells[14].Value)) + "</NetAmt>");

                        xmlClassMaster.Append("<taxableAmt>" + (Convert.ToDecimal(dgvPurchaseDetail.Rows[k].Cells[7].Value)) + "</taxableAmt>");
                        xmlClassMaster.Append("<GSTAmt>" + (Convert.ToDecimal(dgvPurchaseDetail.Rows[k].Cells[18].Value)) + "</GSTAmt>");
                        //,
                        xmlClassMaster.Append("<locationId>" + (Convert.ToDecimal(dgvPurchaseDetail.Rows[k].Cells[16].Value)) + "</locationId>");


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

        #region GRID CREATION & validation
        public void GridCreation()
        {
            try
            {

                DataTable dt = new DataTable();

                dt.Columns.Add("X", typeof(string));          //0
                dt.Columns.Add("PRODUCT NAME", typeof(string)); //1
                dt.Columns.Add("P QTY", typeof(decimal));//2
                dt.Columns.Add("FREE QTY", typeof(decimal));//3
                dt.Columns.Add("P RATE", typeof(decimal));//4
                dt.Columns.Add("DISC AMT", typeof(decimal));//5
                dt.Columns.Add("SUB TOTAL", typeof(decimal));//6
                dt.Columns.Add("TAXABLE AMT", typeof(decimal));//7
                dt.Columns.Add("CGST PER", typeof(decimal)); // 8
                dt.Columns.Add("CGST AMT", typeof(decimal)); // 9
                dt.Columns.Add("SGST PER", typeof(decimal)); // 10
                dt.Columns.Add("SGST AMT", typeof(decimal));//11
                dt.Columns.Add("IGST PER", typeof(decimal)); // 12
                dt.Columns.Add("IGST AMT", typeof(decimal));//13
                dt.Columns.Add("TOTAL AMT", typeof(decimal));//14
                dt.Columns.Add("TOTALPQTY", typeof(decimal)); //15
                dt.Columns.Add("LOACTION ID", typeof(int));//16
                dt.Columns.Add("LOCATION", typeof(string));//17
                dt.Columns.Add("GST AMT", typeof(string));//18
                // dt.Columns.Add("TAXABLE AMT", typeof(string));//19

                dgvPurchaseDetail.DataSource = dt;
            }
            catch (Exception ex)
            {
            }
        }

        public void GridValidation()
        {
            //1,3,20 
            dgvPurchaseDetail.Columns[15].Visible = false;
            dgvPurchaseDetail.Columns[16].Visible = false;

        }

        #endregion

        private void PurchaseInvoice_Load(object sender, EventArgs e)
        {
            GridCreation();
            GridValidation();
            FillGrid(201);
            FillGrid(202);
            FillGrid(203);
            FillGrid(204);
            FillGrid(205);
            FillGrid(206);
            FillGrid(207);
            FillGrid(208);

            if (newOrEdit == 1)
            {
                cmbSupplier.SelectedValue = cmbSuppliverV;
                cmbTaxable.SelectedValue = cmbTaxableV;
                cmbPaymentType.SelectedValue = cmbInvoiceV;
                cmbFirmName.SelectedValue = cmbFirmV;
                cmbShadeName.SelectedValue = cmbShadeV;
                cmbAcc.SelectedValue = cmbAccV;
                cmbPaidBy.SelectedValue = cmbPaidByV;

                FillGrid(102);
            }


            

            pageLoad = 1;
            //if (newOrEdit == 1)
            //{
            //    cmbSupplier.SelectedValue = cmbSuppliverV;
            //    cmbTaxable.SelectedValue = cmbTaxableV;
            //    FillGrid(102);
            //}


        }

        public void defoultValue()
        {
            txtProductName.Text = "";
            txtPQty.Text = "0";
            txtPRate.Text = "0";
            txtFreeQty.Text = "0";
            txtDiscAmt.Text = "0";
            txtCGSTPer.Text = "0";
            txtCGSTAmt.Text = "0";
            txtSGSTPer.Text = "0";
            txtSGSTAmt.Text = "0";
            txtGSTPer.Text = "0";
            txtGSTAmt.Text = "0";
            lblTotalPurcaseAmt.Text = "0";
            cmbLocation.Text = "<--SELECT-->";
            cmbLocation.SelectedIndex = -1;

        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                repete = 0;
                if (txtProductName.Text != "")
                {
                    for (int i = 0; i < dgvPurchaseDetail.Rows.Count; i++)
                    {
                        if (dgvPurchaseDetail.Rows[i].Cells[1].Value.ToString().ToLower() == txtProductName.Text.ToLower())
                        {
                            repete = 1;
                        }
                    }


                    if (repete == 0)
                    {
                        DataTable dt = dgvPurchaseDetail.DataSource as DataTable;

                        DataRow dr2 = dt.NewRow();


                        dr2["X"] = "X";
                        dr2["PRODUCT NAME"] = txtProductName.Text;
                        dr2["P QTY"] = txtPQty.Text;
                        dr2["FREE QTY"] = txtFreeQty.Text;
                        dr2["P RATE"] = txtPRate.Text;
                        dr2["DISC AMT"] = txtDiscAmt.Text;
                        dr2["SUB TOTAL"] = Math.Round((Convert.ToDecimal(txtPQty.Text) * Convert.ToDecimal(txtPRate.Text)), 2);
                        dr2["TAXABLE AMT"] = Math.Round(((Convert.ToDecimal(txtPQty.Text) * Convert.ToDecimal(txtPRate.Text)) - Convert.ToDecimal(txtDiscAmt.Text)), 2);
                        dr2["CGST PER"] = txtCGSTPer.Text;
                        dr2["CGST AMT"] = txtCGSTAmt.Text;
                        dr2["SGST PER"] = txtSGSTPer.Text;
                        dr2["SGST AMT"] = txtSGSTAmt.Text;
                        dr2["IGST PER"] = txtGSTPer.Text;
                        dr2["IGST AMT"] = txtGSTAmt.Text;
                        dr2["TOTAL AMT"] = lblTotalPurcaseAmt.Text;
                        dr2["TOTALPQTY"] = txtFreeQty.Text;
                        dr2["LOACTION ID"] = cmbLocation.SelectedValue;
                        dr2["LOCATION"] = cmbLocation.Text;

                        if (Convert.ToInt32(lblStateCode.Text) == fd.StateId)
                        {
                            dr2["GST AMT"] = Convert.ToDecimal(txtCGSTAmt.Text) + Convert.ToDecimal(txtSGSTAmt.Text);
                        }
                        else
                        {
                            dr2["GST AMT"] = Convert.ToDecimal(txtGSTAmt.Text);
                        }
                        dt.Rows.Add(dr2);
                        dgvPurchaseDetail.DataSource = dt;
                    }
                    else
                    {
                        messageBox frm = new messageBox();
                        frm.messageTxt = "Product with this batch allready added";
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
                gridCalculation();
                defoultValue();
            }
        }

        #region UpperCalc

        public void UpperCalc()
        {


            decimal subTotal = Math.Round(((Convert.ToDecimal(txtPQty.Text)) * Convert.ToDecimal(txtPRate.Text)), 2, MidpointRounding.AwayFromZero);
            decimal taxable = subTotal - Convert.ToDecimal(txtDiscAmt.Text);

            if (Convert.ToInt32(cmbTaxable.SelectedValue) == 60)
            {
                if (Convert.ToInt32(fd.StateId) == Convert.ToInt32(lblStateCode.Text))
                {
                    txtCGSTAmt.Text =
                        Math.Round(((taxable / 100) * Convert.ToDecimal(txtCGSTPer.Text)), 2).ToString();
                    txtSGSTAmt.Text =
                        Math.Round(((taxable / 100) * Convert.ToDecimal(txtSGSTPer.Text)), 2).ToString();
                    txtGSTPer.Text = "0";
                    txtGSTAmt.Text = "0";
                    lblTotalPurcaseAmt.Text = Math.Round((taxable + Convert.ToDecimal(txtCGSTAmt.Text) + Convert.ToDecimal(txtSGSTAmt.Text)), 2).ToString();
                }
                else
                {
                    txtCGSTPer.Text = "0";
                    txtCGSTAmt.Text = "0";
                    txtSGSTPer.Text = "0";
                    txtSGSTAmt.Text = "0";
                    txtGSTAmt.Text = Math.Round(((taxable / 100) * Convert.ToDecimal(txtGSTPer.Text)), 2).ToString();
                    lblTotalPurcaseAmt.Text = Math.Round((taxable + Convert.ToDecimal(txtGSTAmt.Text)), 2).ToString();
                }
            }
            else
            {
                txtCGSTPer.Text = "0";
                txtCGSTAmt.Text = "0";
                txtSGSTPer.Text = "0";
                txtSGSTAmt.Text = "0";
                txtGSTAmt.Text = "0";
                txtGSTPer.Text = "0";
                lblTotalPurcaseAmt.Text = Math.Round((taxable), 2).ToString();
            }


        }
        #endregion

        private void txtPQty_Leave(object sender, EventArgs e)
        {
            UpperCalc();
        }

        private void txtCF_Leave(object sender, EventArgs e)
        {
            UpperCalc();
        }

        private void txtFreeQty_Leave(object sender, EventArgs e)
        {
            UpperCalc();
        }

        private void txtPRate_Leave(object sender, EventArgs e)
        {
            UpperCalc();
        }

        private void txtDiscAmt_Leave(object sender, EventArgs e)
        {
            UpperCalc();
        }

        private void txtGSTPer_Leave(object sender, EventArgs e)
        {
            UpperCalc();
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
                        gridCalculation();
                    }
                }
            }
            catch
            { }
        }


        #region GridCalculation
        public void gridCalculation()
        {
            lblTaxableValue.Text = "0";
            lblGSTAmt.Text = "0";

            for (int i = 0; i < dgvPurchaseDetail.Rows.Count; i++)
            {
                lblTaxableValue.Text =
                    Math.Round((Convert.ToDecimal(lblTaxableValue.Text) + Convert.ToDecimal(dgvPurchaseDetail.Rows[i].Cells[7].Value.ToString())), 2, MidpointRounding.AwayFromZero).ToString();

                if (Convert.ToInt32(cmbTaxable.SelectedValue) == 60)
                {

                    lblGSTAmt.Text =
                        Math.Round((Convert.ToDecimal(lblGSTAmt.Text) + Convert.ToDecimal(dgvPurchaseDetail.Rows[i].Cells[18].Value.ToString())), 2, MidpointRounding.AwayFromZero).ToString();
                }
                else
                {
                    lblGSTAmt.Text = "0";
                }
            }

            // Round off amount
            decimal decGrandTotal;
            int intGrandTotal;

            decGrandTotal = Math.Round((Convert.ToDecimal(lblTaxableValue.Text) + Convert.ToDecimal(lblGSTAmt.Text)
                            + Convert.ToDecimal(txtAdd.Text) - Convert.ToDecimal(txtLess.Text)), 2, MidpointRounding.AwayFromZero);
            intGrandTotal = Convert.ToInt32(Math.Round(decGrandTotal));

            txtROFF.Text = (intGrandTotal - decGrandTotal).ToString();

            lblGrandTotalAmt.Text = intGrandTotal.ToString();
        }
        #endregion

        private void cmbSupplier_Leave(object sender, EventArgs e)
        {
            if (cmbSupplier.Text != "<--SELECT-->" && cmbSupplier.Text != "<--NO RECORD-->" && cmbSupplier.SelectedValue != "System.Data.DataRowView" && cmbSupplier.SelectedValue != null)
            {
                FillGrid(301);
            }
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please select supplier";
                frm.type = "error";
                frm.ShowDialog();
                cmbSupplier.Focus();
            }
        }

        private void cmbProductName_Leave(object sender, EventArgs e)
        {
            //if (cmbProductName.Text != "<--SELECT-->" && cmbProductName.Text != "<--NO RECORD-->"
            //    && cmbProductName.SelectedValue != "System.Data.DataRowView" && cmbProductName.SelectedValue != null)
            //{
            //    FillGrid(302);
            //}
            //else
            //{
            //    txtAdd.Focus();
            //}
        }

        private void txtAdd_Leave(object sender, EventArgs e)
        {
            gridCalculation();
        }

        private void txtLess_Leave(object sender, EventArgs e)
        {
            gridCalculation();
        }

        private void txtCGSTPer_Leave(object sender, EventArgs e)
        {
            UpperCalc();
        }

        private void txtSGSTPer_Leave(object sender, EventArgs e)
        {
            UpperCalc();
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
            }
        }

        private void cmbPaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pageLoad != 0)
            {
                if (Convert.ToInt32(cmbPaymentType.SelectedValue) == 59)
                {
                    cmbAcc.SelectedValue = 1;
                    cmbPaidBy.SelectedValue = 41;
                    cmbAcc.Enabled = cmbPaidBy.Enabled = txtChkNo.Enabled = dtpChkDate.Enabled = false;
                }
                else
                {
                    FillGrid(204);
                    FillGrid(205);
                    cmbAcc.Enabled = cmbPaidBy.Enabled = txtChkNo.Enabled = dtpChkDate.Enabled = true;
                }
            }
        }


    }
}
