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

namespace Textile.Dashboard
{
    public partial class Dashboard_StockReport : Form
    {
        public Dashboard_StockReport()
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
                hash.Add("@intYearId", Convert.ToInt32(fd.YearId));


                if (QueryNo == 1007 || QueryNo == 1014 || QueryNo == 1015 || QueryNo == 1016)
                {
                    hash.Add("@intShade", Convert.ToInt32(cmbShade.SelectedValue));
                }

                dtReturn = ClsDefination.FillData("[Report_AllReport]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 105)
                    {
                        cmbShade.DataSource = dtReturn;
                        cmbShade.DisplayMember = "Shade";
                        cmbShade.ValueMember = "L_Code";
                        cmbShade.SelectedIndex = -1;
                        cmbShade.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 1007 || QueryNo == 1014 || QueryNo == 1015 || QueryNo == 1016)
                    {
                        dgvSut.DataSource = dtReturn;

                        if (QueryNo == 1014)
                        {
                            dgvSut.Columns[0].Visible = false;
                            dgvSut.Columns[2].Visible = false;
                        }
                        if (QueryNo == 1016)
                        {
                            dgvSut.Columns[4].Visible = false;
                            
                        }
                    }
                }
                else
                {
                    if (QueryNo == 105)
                    {
                        cmbShade.DataSource = dtReturn;
                        cmbShade.SelectedIndex = -1;
                        cmbShade.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 1005 || QueryNo == 1014 || QueryNo == 1015 || QueryNo == 1016)
                    {
                        dgvSut.DataSource = dtReturn;
                        if (QueryNo == 1014)
                        {
                            dgvSut.Columns[0].Visible = false;
                            dgvSut.Columns[2].Visible = false;
                        }
                        if (QueryNo == 1016)
                        {
                            dgvSut.Columns[4].Visible = false;
                        }
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



        private void Dashboard_StockReport_Load(object sender, EventArgs e)
        {
            FillGrid(105);
            printerlist();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
           // FillGrid(1007);
//            YARN REPORT
//BEAM REPORT
//TAGE REPORT

            if (cmbReportToView.Text == "YARN REPORT")
            {
                FillGrid(1014);
            }
            else if (cmbReportToView.Text == "BEAM REPORT")
            {
                FillGrid(1015);
            }
            else if (cmbReportToView.Text == "TAGE REPORT")
            {
                FillGrid(1016);
            }
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please Select Which Report To View";
                frm.type = "error";
                frm.ShowDialog();
            }
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


        private void btnPayment_Click(object sender, EventArgs e)
        {
            
            ClsDefination.Readpath();//@intShade
            common.server = ClsDefination.server;
            common.dbname = ClsDefination.database;
            common.username = ClsDefination.id;
            common.password = ClsDefination.password;
            common.reportPath = ClsDefination.CrystalPath;
            common.BillNo = Convert.ToInt32(strReturnMSG);
            common.companyId = fd.CompId;
            common.yearID = fd.YearId;
            common.shade = Convert.ToInt32(cmbShade.SelectedValue);
            common.PrinterName = cmbPrinter.Text;
           // common.PrintDirect(1007);
            if (cmbReportToView.Text == "YARN REPORT")
            {
               // FillGrid(1014);
                common.PrintDirect(1014);
            }
            else if (cmbReportToView.Text == "BEAM REPORT")
            {
      //  BeamStock        FillGrid(1015);
                common.PrintDirect(1015);
            }
            else if (cmbReportToView.Text == "TAGE REPORT")
            {

             //  TagaStock FillGrid(1016);
                common.PrintDirect(1016);
            }
        }
    }
}
