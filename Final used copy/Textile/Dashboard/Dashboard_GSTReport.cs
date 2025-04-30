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

namespace Textile.Dashboard
{
    public partial class Dashboard_GSTReport : Form
    {
        public Dashboard_GSTReport()
        {
            InitializeComponent();
        }


        #region variables
        ClassFiles.CommonFunction common = new ClassFiles.CommonFunction();
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
                hash.Add("@intYearId",Convert.ToInt32(fd.YearId));


                if (QueryNo == 1002 || QueryNo == 3001 || QueryNo == 30011 || QueryNo == 3002)
                {
                    //,
                    hash.Add("@dtpFromDate",dtpFrom.Value.ToString("MM/dd/yyyy"));
                    hash.Add("@dtpToDate",dtpTo.Value.ToString("MM/dd/yyyy"));
                    if (QueryNo == 3001 || QueryNo == 3002)
                    {
                        hash.Add("@intShade", cmbShade.SelectedValue);
                    }
                    else
                    {
                        hash.Add("@intFrom", cmbFirm.SelectedValue);
                    }
                }

                dtReturn = ClsDefination.FillData("[Report_AllReport]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 1002 || QueryNo == 3001 || QueryNo == 30011 || QueryNo == 3002)
                    {
                        dgvSut.DataSource = null;
                        dgvSut.DataSource = dtReturn;
                        //dgvSut.Columns[11].Visible=false;
                    }
                    else if (QueryNo == 3003)
                    {
                        // L_Code ,L_ShadeName+' - '+L_ShacdeLocation as [Shade]
                        cmbShade.DataSource = dtReturn;
                        cmbShade.DisplayMember = "Shade";
                        cmbShade.ValueMember = "L_Code";
                        cmbShade.SelectedIndex = -1;
                        cmbShade.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 106)
                    {
                        cmbFirm.DataSource = dtReturn;
                        cmbFirm.DisplayMember = "F_CompanyName";
                        cmbFirm.ValueMember = "F_Code";
                        cmbFirm.SelectedIndex = -1;
                        cmbFirm.Text = "<--SELECT-->";

                    }
                }
                else
                {
                    if (QueryNo == 1002 || QueryNo == 3001 || QueryNo == 3002)
                    {
                        dgvSut.DataSource = dtReturn;

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

        public void printerlist()
        {
            //DataTable dt = new DataTable();

            //dt.Columns.Add("Name", typeof(string));

            ////comboBox1.DataSource = dt; 
            //foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            //{
            //    //       MessageBox.Show(printer);

            //    dt.Rows.Add(printer);
            //}
            //cmbPrinter.DataSource = dt;
            //cmbPrinter.DisplayMember = "Name";
        }

        private void Dashboard_GSTReport_Load(object sender, EventArgs e)
        {
            
            printerlist();
            FillGrid(3003);
            FillGrid(106);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                ClsDefination.Readpath();

                TransactionReport.CRTransaction frmT = new TransactionReport.CRTransaction();

                ClsDefination.Readpath();

                if (comboBox1.Text == "SALES")
                {
                    frmT.QueryNo = 3001;
                }
                else if (comboBox1.Text == "PURCHASE")
                {
                    frmT.QueryNo = 3002;
                }
                frmT.server = ClsDefination.server;
                frmT.dbname = ClsDefination.database;
                frmT.username = ClsDefination.id;
                frmT.password = ClsDefination.password;
                frmT.reportPath = ClsDefination.CrystalPath;

                frmT.intCompanyID = fd.CompId;

                frmT.intYearID = fd.YearId;
                frmT.VoucherId = Convert.ToInt32(cmbShade.SelectedValue);     //Convert.ToInt32(dgvSut.CurrentRow.Cells[14].Value.ToString());
               // frmT.intSupplierId = cmbSuppliverV;//Convert.ToInt32(dgvSut.CurrentRow.Cells[39].Value.ToString());

                frmT.sdtFromDate = dtpFrom.Value.ToString("dd/MM/yyyy");
                frmT.sdtToDate = dtpTo.Value.ToString("dd/MM/yyyy");
                frmT.ShowDialog();




              //  common.server = ClsDefination.server;
              //  common.dbname = ClsDefination.database;
              //  common.username = ClsDefination.id;
              //  common.password = ClsDefination.password;
              //  common.reportPath = ClsDefination.CrystalPath;
              ////  common.PrinterName = cmbPrinter.Text;
              //  common.companyId = fd.CompId;
              //  common.yearID = fd.YearId;
              //  common.sdtFromDate = dtpFrom.Value.ToString("MM/dd/yyyy");
              //  common.sdtToDate = dtpTo.Value.ToString("MM/dd/yyyy");
              //  //common.PrintDirect(1002);
            }
            catch (Exception ex)
            {
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            //FillGrid(1002);

            if (chkGSTR1.Checked == false)
            {
                if (cmbShade.SelectedIndex > -1)
                {
                    if (comboBox1.Text == "SALES")
                    {
                        FillGrid(3001);
                    }
                    else if (comboBox1.Text == "PURCHASE")
                    {
                        FillGrid(3002);
                    }
                }
                else
                {
                    MessageBox.Show("Please select shade");
                }

            }
            else
            {
                if (cmbFirm.SelectedIndex > -1)
                {
                    if (comboBox1.Text == "SALES")
                    {
                        FillGrid(30011);
                        if (dgvSut.Rows.Count > 0)
                        {
                            Excel();
                        }
                    }
                    else if (comboBox1.Text == "PURCHASE")
                    {
                        FillGrid(3002);
                    }
                }
                else
                {
                    MessageBox.Show("Please select firm");
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }


        public void Excel()
        {
            //// creating Excel Application
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();

            // creating new WorkBook within Excel application
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);

            // creating new Excelsheet in workbook
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            // see the excel sheet behind the program
            app.Visible = true;

            // get the reference of first sheet. By default its name is Sheet1.
            // store its reference to worksheet
            worksheet = (Microsoft.Office.Interop.Excel._Worksheet)workbook.Sheets["Sheet1"];
            worksheet = (Microsoft.Office.Interop.Excel._Worksheet)workbook.ActiveSheet;


            // changing the name of active sheet
            worksheet.Name = "GSTR1 - " + cmbFirm.Text;


            //worksheet.Cells["A1"].FillColor = Color.LightBlue;
            //worksheet.Cells[1, 1].Font.Color = Color.White;

            

            worksheet.Cells[1, 1] = "Summary For B2B(4) - "+cmbFirm.Text ;//fd.CompanyNameStr;  //"AMRUT - RATNA INDUSTRIES";

           // worksheet.Cells[1, 1] = System.Drawing.Color.Brown;
            

            //CellRange range = worksheet.Range["C3:D4"];
            //Formatting rangeFormatting = range.BeginUpdateFormatting();
            //rangeFormatting.Font.Color = Color.Blue;
            //rangeFormatting.Fill.BackgroundColor = Color.LightBlue;
            //rangeFormatting.Fill.PatternType = PatternType.LightHorizontal;
            //rangeFormatting.Fill.PatternColor = Color.Violet;
            //range.EndUpdateFormatting(rangeFormatting);

            worksheet.Cells[2, 1] = "No. of Recipients";
            worksheet.Cells[2, 2] = "No. of Invoices";
            worksheet.Cells[2, 4] = "Total Invoice Value";
            worksheet.Cells[2, 10] = "Total Taxable Value";
            worksheet.Cells[2, 11] = "Total Cess";

            int noInvoice = 0;
            decimal invoiceValue=0, taxableValue=0, cess=0;
            for (int i = 0; i < dgvSut.Rows.Count; i++)
            {
                invoiceValue = invoiceValue + Convert.ToDecimal(dgvSut.Rows[i].Cells[3].Value.ToString());
                taxableValue = taxableValue + Convert.ToDecimal(dgvSut.Rows[i].Cells[9].Value.ToString());
                cess = cess + Convert.ToDecimal(dgvSut.Rows[i].Cells[10].Value.ToString());
            }

            worksheet.Cells[3, 1] = dgvSut.Rows.Count.ToString();
            worksheet.Cells[3, 2] = dgvSut.Rows.Count.ToString();
            worksheet.Cells[3, 4] = invoiceValue.ToString();
            worksheet.Cells[3, 10] = taxableValue.ToString();
            worksheet.Cells[3, 11] = cess.ToString();

            //************************************************************************* GSTR1 ********************************************************
            List<DataGridViewColumn> listVisible = new List<DataGridViewColumn>();
            foreach (DataGridViewColumn col in dgvSut.Columns)
            {
                if (col.Visible)
                    listVisible.Add(col);
            }
            for (int i = 0; i < listVisible.Count; i++)
            {
                worksheet.Cells[4, i + 1] = listVisible[i].HeaderText;   // Display HEader on cell[5A,1A]
            }

            for (int i = 0; i < dgvSut.Rows.Count; i++)
            {
                for (int j = 0; j < listVisible.Count; j++)
                {
                    worksheet.Cells[i+5, j + 1] = dgvSut.Rows[i].Cells[listVisible[j].Name].Value.ToString();  // display data from cell[6A,1A]
                }
            }

            ////    storing header part in Excel
            //for (int i = 1; i < dgvBeamDetails.Columns.Count + 1; i++
            //{
            //    worksheet.Cells[6, i] = dgvBeamDetails.Columns[i - 1].HeaderText;
            //}
            ////     storing Each row and column value to excel sheet
            //for (int i = 0; i < dgvBeamDetails.Rows.Count - 1; i++)
            //{
            //    for (int j = 0; j < dgvBeamDetails.Columns.Count; j++)
            //    {
            //        worksheet.Cells[i + 7, j + 1] = dgvBeamDetails.Rows[i].Cells[j].Value.ToString();
            //    }
            //}


            //****************************************************************************** BEAM END *******************************************************

            //****************************************************************************** YARN INWARD ****************************************************

            //worksheet.Cells[8 + dgvBeamDetails.Rows.Count, 2] = "YARN INWARD DETAILS";
            //List<DataGridViewColumn> listVisible1 = new List<DataGridViewColumn>();
            //foreach (DataGridViewColumn col in dgvYarnInwardDetails.Columns)
            //{
            //    if (col.Visible)
            //        listVisible1.Add(col);
            //}
            //for (int i = 0; i < listVisible1.Count; i++)
            //{
            //    worksheet.Cells[9 + dgvBeamDetails.Rows.Count, i + 1] = listVisible1[i].HeaderText;
            //}

            //for (int i = 0; i < dgvYarnInwardDetails.Rows.Count; i++)
            //{
            //    for (int j = 0; j < listVisible1.Count; j++)
            //    {
            //        worksheet.Cells[i + 10 + dgvBeamDetails.Rows.Count, j + 1] = dgvYarnInwardDetails.Rows[i].Cells[listVisible1[j].Name].Value.ToString();
            //    }
            //}

            ////    storing header part in Excel
            //for (int i = 1; i < dgvYarnInwardDetails.Columns.Count + 1; i++)
            //{
            //    worksheet.Cells[9 + dgvBeamDetails.Rows.Count, i] = dgvYarnInwardDetails.Columns[i - 1].HeaderText;
            //}
            ////     storing Each row and column value to excel sheet
            //for (int i = 0; i < dgvYarnInwardDetails.Rows.Count - 1; i++)
            //{
            //    for (int j = 0; j < dgvYarnInwardDetails.Columns.Count; j++)
            //    {
            //        worksheet.Cells[i + 10 + dgvBeamDetails.Rows.Count, j + 1] = dgvYarnInwardDetails.Rows[i].Cells[j].Value.ToString();
            //    }
            //}
            ////************************************************************************************* YARN INWARD END *****************************************

            ////****************************************************************************** Delivery Details ****************************************************

            //worksheet.Cells[12 + dgvYarnInwardDetails.Rows.Count + dgvBeamDetails.Rows.Count, 2] = "DELIVERY DETAILS";
            //List<DataGridViewColumn> listVisible2 = new List<DataGridViewColumn>();
            //foreach (DataGridViewColumn col in dgvDelivery.Columns)
            //{
            //    if (col.Visible)
            //        listVisible2.Add(col);
            //}
            //for (int i = 0; i < listVisible2.Count; i++)
            //{
            //    worksheet.Cells[13 + dgvYarnInwardDetails.Rows.Count + dgvBeamDetails.Rows.Count, i + 1] = listVisible2[i].HeaderText;
            //}

            //for (int i = 0; i < dgvDelivery.Rows.Count; i++)
            //{
            //    for (int j = 0; j < listVisible2.Count; j++)
            //    {
            //        worksheet.Cells[i + 14 + dgvYarnInwardDetails.Rows.Count + dgvBeamDetails.Rows.Count, j + 1] = dgvDelivery.Rows[i].Cells[listVisible2[j].Name].Value.ToString();
            //    }
            //}

            ////    storing header part in Excel
            //for (int i = 1; i < dgvDelivery.Columns.Count + 1; i++)
            //{
            //    worksheet.Cells[13 + dgvYarnInwardDetails.Rows.Count + dgvBeamDetails.Rows.Count, i] = dgvDelivery.Columns[i - 1].HeaderText;
            //}
            ////     storing Each row and column value to excel sheet
            //for (int i = 0; i < dgvDelivery.Rows.Count - 1; i++)
            //{
            //    for (int j = 0; j < dgvDelivery.Columns.Count; j++)
            //    {
            //        worksheet.Cells[i + 14 + dgvYarnInwardDetails.Rows.Count + dgvBeamDetails.Rows.Count, j + 1] = dgvDelivery.Rows[i].Cells[j].Value.ToString();
            //    }
            //}
            ////************************************************************************************* DELEVERY DETAILS END *****************************************

            ////****************************************************************************** Yarn consumption Details ****************************************************

            //worksheet.Cells[15 + dgvYarnInwardDetails.Rows.Count + dgvBeamDetails.Rows.Count + dgvDelivery.Rows.Count, 2] = "TOTAL YARN WEIGHT";
            //List<DataGridViewColumn> listVisible3 = new List<DataGridViewColumn>();
            //foreach (DataGridViewColumn col in dgvWeightDetials.Columns)
            //{
            //    if (col.Visible)
            //        listVisible3.Add(col);
            //}
            //for (int i = 0; i < listVisible3.Count - 2; i++)
            //{
            //    worksheet.Cells[16 + dgvYarnInwardDetails.Rows.Count + dgvBeamDetails.Rows.Count + dgvDelivery.Rows.Count, i + 1] = listVisible3[i].HeaderText;
            //}

            //for (int i = 0; i < dgvWeightDetials.Rows.Count; i++)
            //{
            //    for (int j = 0; j < listVisible3.Count - 2; j++)
            //    {
            //        worksheet.Cells[i + 17 + dgvYarnInwardDetails.Rows.Count + dgvBeamDetails.Rows.Count + dgvDelivery.Rows.Count, j + 1] = dgvWeightDetials.Rows[i].Cells[listVisible3[j].Name].Value.ToString();
            //    }
            //}

            ////    storing header part in Excel
            //for (int i = 1; i < dgvWeightDetials.Columns.Count - 1; i++)
            //{
            //    worksheet.Cells[16 + dgvYarnInwardDetails.Rows.Count + dgvBeamDetails.Rows.Count + dgvDelivery.Rows.Count, i] = dgvWeightDetials.Columns[i - 1].HeaderText;
            //}
            ////     storing Each row and column value to excel sheet
            //for (int i = 0; i < dgvWeightDetials.Rows.Count - 1; i++)
            //{
            //    for (int j = 0; j < dgvWeightDetials.Columns.Count - 2; j++)
            //    {
            //        worksheet.Cells[i + 17 + dgvYarnInwardDetails.Rows.Count + dgvBeamDetails.Rows.Count + dgvDelivery.Rows.Count, j + 1] = dgvWeightDetials.Rows[i].Cells[j].Value.ToString();
            //    }
            //}
            ////************************************************************************************* total yarn DETAILS END *****************************************



            ////****************************************************************************** weft consumption Details ****************************************************

            //worksheet.Cells[19 + dgvYarnInwardDetails.Rows.Count + dgvBeamDetails.Rows.Count + dgvDelivery.Rows.Count + dgvWeightDetials.Rows.Count, 2] =
            //    "TOTAL WEFT CONSUMPTION";
            //List<DataGridViewColumn> listVisible4 = new List<DataGridViewColumn>();
            //foreach (DataGridViewColumn col in dgvWeft.Columns)
            //{
            //    if (col.Visible)
            //        listVisible4.Add(col);
            //}
            //for (int i = 0; i < listVisible4.Count; i++)
            //{
            //    worksheet.Cells[20 + dgvYarnInwardDetails.Rows.Count + dgvBeamDetails.Rows.Count + dgvDelivery.Rows.Count + dgvWeightDetials.Rows.Count, i + 1] =
            //        listVisible4[i].HeaderText;
            //}

            //for (int i = 0; i < dgvWeft.Rows.Count; i++)
            //{
            //    for (int j = 0; j < listVisible4.Count; j++)
            //    {
            //        worksheet.Cells[i + 21 + dgvYarnInwardDetails.Rows.Count + dgvBeamDetails.Rows.Count + dgvDelivery.Rows.Count + dgvWeightDetials.Rows.Count, j + 1] = dgvWeft.Rows[i].Cells[listVisible4[j].Name].Value.ToString();
            //    }
            //}

            ////    storing header part in Excel
            //for (int i = 1; i < dgvWeft.Columns.Count + 1; i++)
            //{
            //    worksheet.Cells[20 + dgvYarnInwardDetails.Rows.Count + dgvBeamDetails.Rows.Count + dgvDelivery.Rows.Count + dgvWeightDetials.Rows.Count, i] = dgvWeft.Columns[i - 1].HeaderText;
            //}
            ////     storing Each row and column value to excel sheet
            //for (int i = 0; i < dgvWeft.Rows.Count - 1; i++)
            //{
            //    for (int j = 0; j < dgvWeft.Columns.Count; j++)
            //    {
            //        worksheet.Cells[i + 21 + dgvYarnInwardDetails.Rows.Count + dgvBeamDetails.Rows.Count + dgvDelivery.Rows.Count + dgvWeightDetials.Rows.Count, j + 1] = dgvWeft.Rows[i].Cells[j].Value.ToString();
            //    }
            //}
            ////************************************************************************************* yarn consumtion DETAILS END *****************************************



        }
    }
}
