using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Textile.TransactionReport;
using Accounting;
//using InventorySystem.TransactionReport;

namespace Textile.TranscationReport
{
    public partial class InwardRegisterSorting : Form
    {
        public

            InwardRegisterSorting()
        {
            InitializeComponent();
        }
        #region ------------------------Variable Declaration------------------
        ClassFiles.CommonFunction common = new ClassFiles.CommonFunction();
        Accounting.Classes.functionalDetails fd = new Accounting.Classes.functionalDetails();
        DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();

        public Int32 intReturnPKNo, visibilityBtndateMonthCriteria,
            count, QuerySearch, btnVisibleCriteria,
            labelVisibleCriteria, SearchState, ComboQuery, TotalVisibleCriteria
            , GroupIndex, GroupSumColumn1, GroupSumColumn2, GroupSumColumn3, GroupSumColumn4, GroupSumColumn5;
        Hashtable hash = new Hashtable();
        #endregion
       
        private void InwardRegister_Load(object sender, EventArgs e)
        {

            //Textile.TranscationReport.InwardRegisterSorting frm = new Textile.TranscationReport.InwardRegisterSorting();
            //frm.SearchRecord(2124);
            QuerySearch = 1019;
            GroupIndex = 1;GroupSumColumn1 = 5; GroupSumColumn2 = 6;
            //frm.QueryMonthGraph = 2124;
           lblTitle.Text = "Ledger";
           // frm.MdiParent = this;
            labelVisibleCriteria = 3;
            labelVisibleCriteria = 4;
            //frm.CmbRoute.Visible = false;
            //frm.Route.Visible = false;



            dgvDetails.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            ComboLoad(1020); // partyfill
            ComboLoad(106);//cmbFirm fill

            //if (lblTitle.Text == "Bank Statement")
            //{
            //    ComboLoad(21);
            //}
            //else
            //{
            //    ComboLoad(19);//load customer n supplier
            //}
            //if (ComboQuery == 10)//For Supplier Search
            //{
            //    ComboLoad(10);
            //}
            //if (ComboQuery == 9)//For Customer Load
            //{
            //    ComboLoad(9);
            //}
            //if (lblTitle.Text == "Delivery Challan Register" || lblTitle.Text == "Details Delivery Challan Register" ||
            //    lblTitle.Text == "Sales Return Register" || lblTitle.Text == "Sales Invoice Register"
            //    || lblTitle.Text == "Sundry Debtors Ledger" || lblTitle.Text == "Sales Receipt Register"
            //   )
            //{
            //    ComboLoad(32);//customer combo
            //}
            //if (lblTitle.Text == "GRN Register" || lblTitle.Text == "Purchase Invoice Register" ||
            //    lblTitle.Text == "Detail Purchase Invoice Register" || lblTitle.Text == "Purchase Return Register"
            //   || lblTitle.Text == "Purchase Payment Register" || lblTitle.Text == "Inward Register")
            //{
            //    ComboLoad(31);//supplier combo
            //}
            //ComboLoad(11);//category combo
            //ComboLoad(12);//subcategory combo
            //ComboLoad(13);//Load Batch No
            //ComboLoad(14);//Load Product Name
            //ComboLoad(15);//load route

            common.GridRowNo(dgvDetails);
            //if (lblTitle.Text == "Sundry Creditors" || lblTitle.Text == "Payment Withdrow")
            //{
            //    //ComboLoad(10);//supplier combo
            //    CBPartyName.Visible = true;
            //    lblPartyName.Visible = true;
            //    CmbRoute.Visible = false;
            //    Route.Visible = false;
            //    lblProductName.Visible = false;
            //    cmbProductName.Visible = false;

            //    btnPrint.Visible = true;



            //    label2.Visible = false;
            //}
            //else if (lblTitle.Text == "Godown Transfer Register")
            //{
            //    //CmbRoute.Visible = true;
            //    //Route.Visible = true;
            //}
            //else if (lblTitle.Text == "Daily Stock Register" || lblTitle.Text == "Godown Transfer LOOSE Register")
            //{

            //    lblPartyName.Visible = false;
            //    CBPartyName.Visible = false;
            //    Route.Visible = false;
            //    CmbRoute.Visible = false;
            //    if (lblTitle.Text == "Godown Transfer LOOSE Register")
            //    {

            //        lblProductName.Visible = false;
            //        cmbProductName.Visible = false;

            //    }

            //}
            //else if (lblTitle.Text == "Sundry Debtors")
            //{


            //    lblProductName.Visible = false;
            //    cmbProductName.Visible = false;
            //    CBPartyName.Visible = true;
            //    lblPartyName.Visible = true;
            //}
            //else if (lblTitle.Text == "Sales Receipt Register")
            //{

            //    lblProductName.Visible = false;
            //    cmbProductName.Visible = false;

            //    label2.Visible = false;

            //}
            //else if (lblTitle.Text == "Sales Receipt Register")
            //{
            //    lblProductName.Visible = false;
            //    cmbProductName.Visible = false;

            //}
            //else if (lblTitle.Text == "Purchase Payment Register")
            //{


            //    Route.Visible = false;
            //    CmbRoute.Visible = false;

            //}
            //else if (lblTitle.Text == "Account Balance Register")
            //{
            //    CmbRoute.Visible = false;
            //    Route.Visible = false;
            //    lblPartyName.Visible = false;
            //    CBPartyName.Visible = false;

            //    //btnPrint.Visible = false;
            //    label2.Visible = false;
            //    CmbRoute.Visible = false;
            //    Route.Visible = false;
            //    cmbProductName.Visible = false;
            //    lblProductName.Visible = false;
            //}

            //else if (labelVisibleCriteria == 3)
            //{

            //    Route.Visible = false;
            //}
            //else if (labelVisibleCriteria == 4)
            //{

            //    lblProductName.Visible = false;
            //    cmbProductName.Visible = false;

            //}



            //if (labelVisibleCriteria == 2)
            //{
            //    CmbRoute.Visible = false;
            //    Route.Visible = false;



            //}
            //else if (labelVisibleCriteria == 7)
            //{
            //    label2.Visible = false;
            //    label3.Visible = false;
            //    dtpFromDt.Visible = false;
            //    dtpToDt.Visible = false;
            //    chkDt.Visible = false;



            //}

            btnsearch.Focus();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (lblTitle.Text == "Bank Statement")
            {
                if (CBPartyName.Text == "<Select>" || CBPartyName.Text == "<select>")
                {
                    MessageBox.Show("Select Account No");

                }
                else
                {
                    SearchRecord(QuerySearch, GroupIndex, GroupSumColumn1, GroupSumColumn2, GroupSumColumn3, GroupSumColumn4, GroupSumColumn5);
                }
            }
            else
            {
                if (cmbLedeger.Text == "<Select Party>")
                {
                    MessageBox.Show("Please Select Ledeger Type");
                }
                else
                {
                    SearchRecord(QuerySearch, GroupIndex, GroupSumColumn1, GroupSumColumn2, GroupSumColumn3, GroupSumColumn4, GroupSumColumn5);
                }
            }
        }



        private void btnRefresh_Click(object sender, EventArgs e)
        {

            //CBPartyName.Text = "<Select>";

            //cmbProductName.Text = "<Select>";
            chkDt.Checked = false;

           // CmbRoute.Text = "<Select>";

            ComboLoad(1020); // partyfill
            ComboLoad(106);//cmbFirm fill
            dtpFromDt.Text = System.DateTime.Now.ToString();
            dtpToDt.Text = System.DateTime.Now.ToString();
            dgvDetails.Columns.Clear();

        }


        int ComponentNo, ProcessNo, PONo, PartyNo, ProductID, CustID, route,FirmNo;

        string StartDate, EndDate, BatchNo;
        public void Criteria()
        {

            //if (CmbRoute.SelectedValue == null || CmbRoute.Text == "<Select>")
            //{
            //    route = 0;
            //}
            //else
            //{
            //    route = Convert.ToInt16(CmbRoute.SelectedValue.ToString());
            //}



            if (CBPartyName.Text == "<Select>" || CBPartyName.Text == "<Select>" || CBPartyName.SelectedValue == null)
            {
                PartyNo = 0;
            }
            else
            {
                PartyNo = Convert.ToInt16(CBPartyName.SelectedValue.ToString());
            }

            if (cmbFirm.Text == "<Select>" || cmbFirm.Text == "<Select>" || cmbFirm.SelectedValue == null)
            {
                FirmNo = 0;
            }
            else
            {
                FirmNo = Convert.ToInt16(cmbFirm.SelectedValue.ToString());
            }

            //if (cmbProductName.Text == "<Select>" || cmbProductName.SelectedValue == null)
            //{
            //    ProductID = 0;
            //}
            //else
            //{
            //    ProductID = Convert.ToInt16(cmbProductName.SelectedValue.ToString());
            //}



            if (dtpFromDt.Value.ToString("MM/dd/yyyy") == dtpToDt.Value.ToString("MM/dd/yyyy") && chkDt.Checked != true)
            {
                StartDate = fd.StartDate.ToString("MM/dd/yyyy"); //"01/01/1900";
                EndDate = fd.EndDate.ToString("MM/dd/yyyy");// //"01/01/1900";
            }
            else
            {
                if (chkDt.Checked == true)
                {
                    StartDate = dtpFromDt.Value.ToString("MM/dd/yyyy");
                    EndDate = dtpFromDt.Value.ToString("MM/dd/yyyy");
                }
                else
                {
                    if (QuerySearch == 204)
                    {
                        StartDate = dtpFromDt.Value.ToString("MM/dd/yyyy");
                    }
                    else
                    {
                        StartDate = dtpFromDt.Value.ToString("MM/dd/yyyy");
                    }

                    EndDate = dtpToDt.Value.ToString("MM/dd/yyyy");

                }
            }

        }

        #region LoadCombobox
        void ComboLoad(int Query)
        {

            hash = new Hashtable();
            Criteria();
            hash.Add("@QueryNo", Query);

            hash.Add("@intCompanyId", fd.CompId);


            DataTable dtReturn = ClsDefination.FillData("[Report_AllReport]", hash);

            if (dtReturn.Rows.Count > 0 || dtReturn == null)
            {

                if (Query == 1020)
                {
                    CBPartyName.DataSource = dtReturn;
                    CBPartyName.DisplayMember = "P_CompanyName";
                    CBPartyName.ValueMember = "P_Code";
                    CBPartyName.SelectedIndex = -1;
                    CBPartyName.Text = "<Select>";
                }
                else if (Query == 106)
                {
                    cmbFirm.DataSource = dtReturn;
                    cmbFirm.DisplayMember = "F_CompanyName";
                    cmbFirm.ValueMember="F_Code";
                    cmbFirm.SelectedIndex=-1;
                    cmbFirm.Text="<--Select-->";
                }
                else if (Query == 21)//-- Supplier Master--Developer-Ranjeet--Date-13/12/2014 10:45 PM
                {
                    CBPartyName.DataSource = dtReturn;
                    CBPartyName.ValueMember = "ID";
                    CBPartyName.DisplayMember = "AccountName";
                    CBPartyName.Text = "<Select>";

                }
                else if (Query == 9)//customer id
                {
                    CBPartyName.DataSource = dtReturn;
                    CBPartyName.ValueMember = "CustID";
                    CBPartyName.DisplayMember = "Customer Name";
                    CBPartyName.Text = "<Select>";



                }
                else if (Query == 19) //customer n suplier common combo
                {
                    CBPartyName.DataSource = dtReturn;
                    CBPartyName.ValueMember = "ID";
                    CBPartyName.DisplayMember = "Name";
                    CBPartyName.Text = "<Select>";



                }
                else if (Query == 31) // suplier combo
                {
                    CBPartyName.DataSource = dtReturn;
                    CBPartyName.ValueMember = "ID";
                    CBPartyName.DisplayMember = "Name";
                    CBPartyName.Text = "<Select>";



                }
                else if (Query == 32) //customer combo
                {
                    CBPartyName.DataSource = dtReturn;
                    CBPartyName.ValueMember = "ID";
                    CBPartyName.DisplayMember = "Name";
                    CBPartyName.Text = "<Select>";



                }
                else

                    if (Query == 10)//-- Supplier Master--Developer-Ranjeet--Date-13/12/2014 10:45 PM
                    {
                        CBPartyName.DataSource = dtReturn;
                        CBPartyName.ValueMember = "SupID";
                        CBPartyName.DisplayMember = "SupplierName";
                        CBPartyName.Text = "<Select>";

                    }


                    //else if (Query == 14)//Load Product Name
                    //{
                    //    cmbProductName.DataSource = dtReturn;
                    //    cmbProductName.DisplayMember = "Product Name";
                    //    cmbProductName.ValueMember = "ProductId";
                    //    cmbProductName.Text = "<Select>";
                    //}
                    //else if (Query == 15)//-- Supplier Master--Developer-Ranjeet--Date-13/12/2014 10:45 PM
                    //{
                    //    CmbRoute.DataSource = dtReturn;
                    //    CmbRoute.ValueMember = "ID";
                    //    CmbRoute.DisplayMember = "CommonName";
                    //    CmbRoute.Text = "<Select>";

                    //}



            }
            else
            {
                if (Query == 9)
                {
                    CBPartyName.DataSource = null;
                    CBPartyName.Text = "<Select>";
                    CBPartyName.ValueMember = "0";
                }
                else
                    if (Query == 10)//Party Name
                    {
                        CBPartyName.DataSource = null;
                        CBPartyName.Text = "<Select>";
                        CBPartyName.ValueMember = "0";

                    }

                    else if (Query == 14)//Product Name
                    {
                        //cmbProductName.DataSource = null;
                        //cmbProductName.Text = "<Select>";
                        //cmbProductName.ValueMember = "0";

                    }
                    else if (Query == 106)
                    {
                        cmbFirm.DataSource = dtReturn;
                        cmbFirm.SelectedIndex = -1;
                        cmbFirm.Text = "<--No Record-->";
                    }

            }
        }
        #endregion

        #region-------------- Start--Grid Load-------------------
        public DataTable SearchRecord(int QueryNo, int intGroupIndex, int intGroupSumColumn1, int intGroupSumColumn2, int intGroupSumColumn3, int intGroupSumColumn4, int intGroupSumColumn5)
        {
            try
            {
                hash = new Hashtable();

                Criteria();
                hash.Add("@QueryNo", QueryNo);
                hash.Add("@intCompanyID", fd.CompId);
                hash.Add("@intYearID", fd.YearId);

                //if (chkDt.Checked == true)
                //{
                //    hash.Add("@sdtFromDate", StartDate);
                //    hash.Add("@sdtToDate", StartDate);
                //}

                //else
                //{
                    hash.Add("@dtpFromDate", StartDate);
                    hash.Add("@dtpToDate", EndDate);
                //}


                //hash.Add("@salesid", route);
                //hash.Add("@intCategoryID", ComponentNo);
               // hash.Add("@intSubcategoryID", ProcessNo);
                if (QueryNo == 110 || QueryNo == 601)
                {
                   // hash.Add("@intBatchNo", route);
                }
                else
                {
                 //   hash.Add("@intBatchNo", BatchNo);
                }
              //  hash.Add("@intProductID", ProductID);

                hash.Add("@intFromParty", PartyNo);
                hash.Add("@intTo",FirmNo);
               // hash.Add("@intSupplierId", PartyNo);
             //   hash.Add("@intCustid", PartyNo);

                if (QueryNo == 1019)
                {
                    hash.Add("@strTypeOfLedger", cmbLedeger.Text);
                }

                DataTable dtReturn = ClsDefination.FillData("[Report_AllReport]", hash);

                if (dtReturn != null && dtReturn.Rows.Count > 0)
                {

                    decimal sum1 = 0;
                    decimal GrandTotal1 = 0;
                    decimal sum2 = 0;
                    decimal GrandTotal2 = 0;
                    decimal sum3 = 0;
                    decimal GrandTotal3 = 0;
                    decimal sum4 = 0;
                    decimal GrandTotal4 = 0;
                    decimal sum5 = 0;
                    decimal GrandTotal5 = 0;
                    DataRow row;
                    if (intGroupIndex != 0)
                    {



                        string iKey = (string)dtReturn.Rows[0][intGroupIndex];

                        for (int i = 0; i < dtReturn.Rows.Count; i++)
                        {

                            string id = (string)dtReturn.Rows[i][intGroupIndex];

                            if (id != iKey)
                            {
                                iKey = id;
                                row = dtReturn.NewRow();
                                if (intGroupSumColumn1 != 0)//1st Group Total Not Use 
                                {
                                    row[intGroupSumColumn1] = sum1;
                                }
                                if (intGroupSumColumn2 != 0)//2nd Group Total Not Use 
                                {
                                    row[intGroupSumColumn2] = sum2;
                                }
                                if (intGroupSumColumn3 != 0)//2nd Group Total Not Use 
                                {
                                    row[intGroupSumColumn3] = sum3;
                                }
                                if (intGroupSumColumn4 != 0)//2nd Group Total Not Use 
                                {
                                    row[intGroupSumColumn4] = sum4;
                                }
                                if (intGroupSumColumn5 != 0)//2nd Group Total Not Use 
                                {
                                    row[intGroupSumColumn5] = sum5;
                                }
                                dtReturn.Rows.InsertAt(row, i);
                                dtReturn.AcceptChanges();
                                sum1 = 0;
                                sum2 = 0;
                                i++;
                            }

                            if (i == (dtReturn.Rows.Count - 1))
                            {
                                row = dtReturn.NewRow();
                                if (intGroupSumColumn1 != 0)//1st Group Total Not Use 
                                {
                                    row[intGroupSumColumn1] = sum1 + (decimal)dtReturn.Rows[i][intGroupSumColumn1];
                                }
                                if (intGroupSumColumn2 != 0)//2nd Group Total Not Use 
                                {
                                    row[intGroupSumColumn2] = sum2 + (decimal)dtReturn.Rows[i][intGroupSumColumn2];
                                }
                                if (intGroupSumColumn3 != 0)//2nd Group Total Not Use 
                                {
                                    row[intGroupSumColumn3] = sum3 + (decimal)dtReturn.Rows[i][intGroupSumColumn3];
                                }
                                if (intGroupSumColumn4 != 0)//2nd Group Total Not Use 
                                {
                                    row[intGroupSumColumn4] = sum4 + (decimal)dtReturn.Rows[i][intGroupSumColumn4];
                                }
                                if (intGroupSumColumn5 != 0)//2nd Group Total Not Use 
                                {
                                    row[intGroupSumColumn5] = sum5 + (decimal)dtReturn.Rows[i][intGroupSumColumn5];
                                }
                                dtReturn.Rows.Add(row);
                                dtReturn.AcceptChanges();

                                if (intGroupSumColumn1 != 0)//1st Group Total Not Use 
                                {
                                    GrandTotal1 += (decimal)dtReturn.Rows[i][intGroupSumColumn1];
                                }
                                if (intGroupSumColumn2 != 0)//2nd Group Total Not Use 
                                {
                                    GrandTotal2 += (decimal)dtReturn.Rows[i][intGroupSumColumn2];
                                }
                                if (intGroupSumColumn3 != 0)//2nd Group Total Not Use 
                                {
                                    GrandTotal3 += (decimal)dtReturn.Rows[i][intGroupSumColumn3];
                                }
                                if (intGroupSumColumn4 != 0)//2nd Group Total Not Use 
                                {
                                    GrandTotal4 += (decimal)dtReturn.Rows[i][intGroupSumColumn4];
                                }
                                if (intGroupSumColumn5 != 0)//2nd Group Total Not Use 
                                {
                                    GrandTotal5 += (decimal)dtReturn.Rows[i][intGroupSumColumn5];
                                }
                                i++;
                            }
                            else
                            {

                                if (intGroupSumColumn1 != 0)//1st Group Total Not Use 
                                {
                                    GrandTotal1 += (decimal)dtReturn.Rows[i][intGroupSumColumn1];
                                    sum1 += (decimal)dtReturn.Rows[i][intGroupSumColumn1];
                                }
                                if (intGroupSumColumn2 != 0)//2nd Group Total Not Use 
                                {
                                    GrandTotal2 += (decimal)dtReturn.Rows[i][intGroupSumColumn2];
                                    sum2 += (decimal)dtReturn.Rows[i][intGroupSumColumn2];
                                }
                                if (intGroupSumColumn3 != 0)//2nd Group Total Not Use 
                                {
                                    GrandTotal3 += (decimal)dtReturn.Rows[i][intGroupSumColumn3];
                                    sum3 += (decimal)dtReturn.Rows[i][intGroupSumColumn3];
                                }
                                if (intGroupSumColumn4 != 0)//2nd Group Total Not Use 
                                {
                                    GrandTotal4 += (decimal)dtReturn.Rows[i][intGroupSumColumn4];
                                    sum4 += (decimal)dtReturn.Rows[i][intGroupSumColumn4];
                                }
                                if (intGroupSumColumn5 != 0)//2nd Group Total Not Use 
                                {
                                    GrandTotal5 += (decimal)dtReturn.Rows[i][intGroupSumColumn5];
                                    sum5 += (decimal)dtReturn.Rows[i][intGroupSumColumn5];
                                }
                            }
                        }

                        row = dtReturn.NewRow();
                        if (intGroupSumColumn1 != 0)//1st Group Total Not Use 
                        {
                            row[intGroupSumColumn1] = GrandTotal1;
                        }
                        if (intGroupSumColumn2 != 0)//2nd Group Total Not Use 
                        {
                            row[intGroupSumColumn2] = GrandTotal2;
                        }
                        if (intGroupSumColumn3 != 0)//2nd Group Total Not Use 
                        {
                            row[intGroupSumColumn3] = GrandTotal3;
                        }
                        if (intGroupSumColumn4 != 0)//2nd Group Total Not Use 
                        {
                            row[intGroupSumColumn4] = GrandTotal4;
                        }
                        if (intGroupSumColumn5 != 0)//2nd Group Total Not Use 
                        {
                            row[intGroupSumColumn5] = GrandTotal5;
                        }
                        dtReturn.Rows.Add(row);
                    }


                    dgvDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                    dgvDetails.ColumnHeadersVisible = false;
                    dgvDetails.RowHeadersVisible = false;// set it to false if not needed
                    dgvDetails.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing; //or even better .DisableResizing. Most time consumption enum is DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders


                    dgvDetails.DataSource = dtReturn;

                    dgvDetails.ColumnHeadersVisible = true;
                    dgvDetails.RowHeadersVisible = true;
                    //   dgvDetails.Columns[0].Visible = false;
                    DataGridViewValidation();
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Message", typeof(string));
                    DataRow dr = dt.NewRow();
                    dr["Message"] = "Record Not Available";
                    dt.Rows.Add(dr);

                    dgvDetails.DataSource = dt;
                    dgvDetails.Columns[0].Width = 250;



                }
                return null;
            }


            catch (Exception)
            {
                return null;
                throw;
            }
        }

        void DataGridViewValidation()
        {

            dgvDetails.Columns[0].Visible = false;


            //For Allignment of Column
            for (int i = 0; i < dgvDetails.Columns.Count; i++)
            {
                this.dgvDetails.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvDetails.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable; ;
                if (dgvDetails.Columns[i].ValueType == typeof(decimal))
                {
                    dgvDetails.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvDetails.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    // dgvDetails.Columns[i].Width = 20;
                }
                else if (dgvDetails.Columns[i].ValueType == typeof(int) || dgvDetails.Columns[i].ValueType == typeof(Int16) || dgvDetails.Columns[i].ValueType == typeof(Int32) || dgvDetails.Columns[i].ValueType == typeof(Int64))
                {
                    dgvDetails.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvDetails.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    // dgvDetails.Columns[i].Width = 20;
                }
                else
                {
                    dgvDetails.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dgvDetails.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
            }

            //Change Back Colour & Font of Column
            dgvDetails.EnableHeadersVisualStyles = false;
            dgvDetails.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#968650");
            dgvDetails.ColumnHeadersDefaultCellStyle.Font = new Font("White", 11F, FontStyle.Regular);
            dgvDetails.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#FFFFFF");

            //Change Back Colour of Rows
            dgvDetails.DefaultCellStyle.Font = new Font("White", 10F, FontStyle.Regular);

            for (int k = 0; k < dgvDetails.RowCount; k++)
            {
                //dgvDetails.DataSource  

                if (dgvDetails.Rows[k].Cells[0].Value.ToString() == "")
                {
                    dgvDetails.Rows[k].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#BFAB65");

                    dgvDetails.Rows[k].DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#FFFFFF");
                    //dgvDetails.Rows[k].DefaultCellStyle.ForeColor = Color.Yellow;
                }
                else
                {
                    dgvDetails.Rows[k].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFFFFF");//#E5E4E2

                }
            }





        }
        #endregion------------------END --Grid Load--------
        public int ID;

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void btnToExcel_Click(object sender, EventArgs e)
        {
            //// creating Excel Application
            //Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();

            //// creating new WorkBook within Excel application
            //Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);

            //// creating new Excelsheet in workbook
            //Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            //// see the excel sheet behind the program
            //app.Visible = true;

            //// get the reference of first sheet. By default its name is Sheet1.
            //// store its reference to worksheet
            //worksheet = (Microsoft.Office.Interop.Excel._Worksheet)workbook.Sheets["Sheet1"];
            //worksheet = (Microsoft.Office.Interop.Excel._Worksheet)workbook.ActiveSheet;


            //// changing the name of active sheet
            //worksheet.Name = "PIN korisnici";


            //List<DataGridViewColumn> listVisible = new List<DataGridViewColumn>();
            //foreach (DataGridViewColumn col in dgvDetails.Columns)
            //{
            //    if (col.Visible)
            //        listVisible.Add(col);
            //}
            //for (int i = 0; i < listVisible.Count; i++)
            //{
            //    worksheet.Cells[1, i + 1] = listVisible[i].HeaderText;
            //}

            //for (int i = 0; i < dgvDetails.Rows.Count; i++)
            //{
            //    for (int j = 0; j < listVisible.Count; j++)
            //    {
            //        worksheet.Cells[i + 2, j + 1] = dgvDetails.Rows[i].Cells[listVisible[j].Name].Value.ToString();
            //    }
            //}

            // storing header part in Excel
            //for (int i = 1; i < dgvDetails.Columns.Count + 1; i++)
            //{
            //    worksheet.Cells[1, i] = dgvDetails.Columns[i - 1].HeaderText;
            //}
            // storing Each row and column value to excel sheet
            //for (int i = 0; i < dgvDetails.Rows.Count - 1; i++)
            //{
            //    for (int j = 0; j < dgvDetails.Columns.Count; j++)
            //    {
            //        worksheet.Cells[i + 2, j + 1] = dgvDetails.Rows[i].Cells[j].Value.ToString();
            //    }
            //}
        }

        private void cmbProductName_KeyPress(object sender, KeyPressEventArgs e)
        {
          //  common.AutoFillEditeble(cmbProductName, e, true);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Criteria();
            if (QuerySearch == null || QuerySearch == 0)
            {

            }
            else
            {
                Textile.TransactionReport.CRTransaction frm = new CRTransaction();

                ClsDefination.Readpath();

                ClsDefination.Readpath();
                common.server = ClsDefination.server;
                common.dbname = ClsDefination.database;
                common.username = ClsDefination.id;
                common.password = ClsDefination.password;
                common.reportPath = ClsDefination.CrystalPath;


                if (cmbLedeger.Text == "PURCHASE")
                {
                    if (rbAgainstFirm.Checked == true)
                    {
                        if (cmbFirm.SelectedIndex > -1)
                        {
                            frm.QueryNo = 7001;
                            frm.intPartyNo = 0;
                            frm.intFirm = Convert.ToInt32( cmbFirm.SelectedValue);
                        }
                        else
                        {
                            messageBox mfrm = new messageBox();

                            mfrm.messageTxt = "Please select firm";

                            mfrm.type = "error";
                            mfrm.ShowDialog();

                            cmbFirm.Focus();
                            //this.Close();
                        }
                    }
                    if (rbAgainstParty.Checked == true)
                    {
                        if (CBPartyName.SelectedIndex > -1)
                        {
                            frm.QueryNo = 7001;
                            frm.intFirm = 0;
                            frm.intPartyNo = Convert.ToInt32(CBPartyName.SelectedValue);
                        }
                        else
                        {
                            messageBox mfrm = new messageBox();

                            mfrm.messageTxt = "Please select party";

                            mfrm.type = "error";
                            mfrm.ShowDialog();
                            CBPartyName.Focus();
                            //this.Close();
                        }
                    }
                }

                if (cmbLedeger.Text == "SALES")
                {
                    if (rbAgainstFirm.Checked == true)
                    {
                        if (cmbFirm.SelectedIndex > -1)
                        {
                            frm.QueryNo = 7002; //5003
                            frm.intPartyNo = 0;
                            frm.intFirm = Convert.ToInt32(cmbFirm.SelectedValue);
                        }
                        else
                        {
                            messageBox mfrm = new messageBox();

                            mfrm.messageTxt = "Please select firm";

                            mfrm.type = "error";
                            mfrm.ShowDialog();
                            cmbFirm.Focus();
                            //this.Close();
                        }
                    }
                    if (rbAgainstParty.Checked == true)
                    {
                        if (CBPartyName.SelectedIndex > -1)
                        {
                            frm.QueryNo = 7002;//5004
                            frm.intFirm = 0;
                            frm.intPartyNo = Convert.ToInt32(CBPartyName.SelectedValue);
                        }
                        else
                        {
                            messageBox mfrm = new messageBox();

                            mfrm.messageTxt = "Please select party";

                            mfrm.type = "error";
                            mfrm.ShowDialog();
                            CBPartyName.Focus();
                            //this.Close();
                        }

                    }
                }
                
                



                frm.sdtFromDate = StartDate;
                frm.sdtToDate = EndDate;
                frm.reportPath = common.reportPath;
                //frm.intPartyNo = PartyNo;
                //frm.TypeId = TypeId;
                //frm.intCategoryID = CategoryId;
                frm.intCompanyID = fd.CompId;
                frm.intYearID = fd.YearId;
                //frm.intProductID = ProductID;
   
                frm.ShowDialog();
            }
        }






        private void CmbRoute_KeyPress(object sender, KeyPressEventArgs e)
        {
           // common.AutoFillEditeble(CmbRoute, e, true);
        }






        private void CBPartyName_KeyPress(object sender, KeyPressEventArgs e)
        {
            common.AutoFillEditeble(CBPartyName, e, true);

        }


        #region----Cell Merging
        private void dgvDetails_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {


                if (IsRepeatedCellValue(e.RowIndex, e.ColumnIndex))
                {

                    e.Value = string.Empty;
                    e.FormattingApplied = true;
                }
            }
        }

        private bool IsRepeatedCellValue(int rowIndex, int colIndex)
        {
            try
            {

                if (dgvDetails.Rows[rowIndex].Cells[colIndex].Value.ToString() == dgvDetails.Rows[rowIndex - 1].Cells[colIndex].Value.ToString())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;

            }

        }

        private bool IsEmptyCellValue(int rowIndex, int colIndex)
        {

            if (dgvDetails.Rows[rowIndex].Cells[colIndex].Value.ToString() == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void dgvDetails_CellPainting(object sender, DataGridViewCellPaintingEventArgs args)
        {
            if (args.RowIndex == -1 || args.ColumnIndex == -1)
                return;

            if (args.ColumnIndex == 1)
            {





                if (IsEmptyCellValue(args.RowIndex, args.ColumnIndex))
                {
                    //   args.AdvancedBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None;
                    //   args.AdvancedBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;
                }


                if (IsRepeatedCellValue(args.RowIndex, args.ColumnIndex))
                {


                    //  dgvDetails_CellFormatting(null, null);
                    //    args.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
                    //  args.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;

                }
                else
                {
                    //   args.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.Single;
                    //  args.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
                }
            }
        }


        #endregion--Cell Merging

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chkDt_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbAgainstFirm_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAgainstFirm.Checked == true)
            {
                rbAgainstParty.Checked = false;
            }
            else
            {
                rbAgainstParty.Checked = true;
            }
        }

        private void rbAgainstParty_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAgainstParty.Checked == true)
            {
                rbAgainstFirm.Checked = false;
            }
            else
            {
                rbAgainstFirm.Checked = true;
            }
        }

    }
}
