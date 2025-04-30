using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Collections;
using System.Drawing;
//using CrystalDecisions.CrystalReports.Engine;
//using CrystalDecisions.Shared;
using System.Drawing.Printing;
//using MultiColumnComboBoxDemo;
using Accounting.Classes;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace ClassFiles
{
    class CommonFunction
    {

        ~CommonFunction()
        {
            GC.Collect();
        }



        public Int32 intLoginUserID;
        public static Int32 LoginYearID = 1;
        string CommonPath = Application.StartupPath + "\\RPTs";
        public int InvoiceNo, QueryNo, PlanningId; //DCNo, vchno, TaxInvice, InvoiceID, PurchaseReturnNo;
        public int RowId; // To specify report with same query no.
        public string PrintCopy, Txtinv, PrinterName, companyName;
        public int BillNo, installmentNo, companyId, yearID, subgroupId,shade,supplierId;
        public string sdtFromDate, sdtToDate, StrBatchNo, strQuotDetailID, reportPath, server, dbname, username, password, PRINTER;
        //public string serverName, Databse, userName, Password, Printer, reporPath;
        //-------------------- Variables for Form theming --------------------------------------
        public string TextBoxFont = "Arial", LableFont = "Arial", TitleFont, ButtonFont = "Arial", GridViewFont = "Arial"; // Trebuchet MS
        public int TextBoxSize = 9, LableSize = 10, TitleSize = 14, ButtonFontSize = 9, GridFontSize = 9;
        public int PanelTitleSizeX = 1086, PanelTitleSizeY = 50, PanelButtonSizeX = 1086, PanelButtonSizeY = 50, PanelMasterMiddleSizeX, PanelMasterMiddleSizeY, PanelTransactionMiddleSizeX, PanelTransactionMiddleSizeY;
        // public string LableForeColor, PanelBackColor, ButtonBackColor;
        public System.Drawing.Color LableForeColor = Color.Black, PanelBackColor = Color.GhostWhite, ButtonBackColor = Color.LightSalmon;
        //--------------------------------------------------------------------------------------

        public void RoundValue(decimal FieldStartValue, ref decimal FieldOutValue)
        {
            FieldOutValue = Math.Round(FieldStartValue, 2, MidpointRounding.AwayFromZero);
        }
        #region ClearTextBox

        public void clearTextBox(Control.ControlCollection cc)
        {


            foreach (Control item in cc)
            {
                if (item.GetType().ToString() == "System.Windows.Forms.Panel")
                {
                    clearTextBox(item.Controls);

                }
                if (item.GetType().ToString() == "System.Windows.Forms.GroupBox")
                {
                    clearTextBox(item.Controls);
                }

                if (item.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    item.Text = "";
                }
                if (item.GetType().ToString() == "System.Windows.Forms.ComboBox")
                {
                    item.Text = "";
                }
                if (item.GetType().ToString() == "System.Windows.Forms.DateTimePicker")
                {
                    item.Text = System.DateTime.Now.ToString();
                }
                if (item.GetType().ToString() == "System.Windows.Forms.DataGridView")
                {
                    item.Text = "";
                }
                if (item.GetType().ToString() == "System.Windows.Forms.RichTextBox")
                {
                    item.Text = "";
                }
                if (item.GetType().ToString() == "MultiColumnComboBoxDemo.MultiColumnComboBox")
                {
                    item.Text = "";
                }
            }
        }

        #endregion

        #region Grid Row No

        public void GridRowNo(DataGridView Dgv)
        {
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                row.HeaderCell.Value = String.Format("{0}", row.Index + 1);
            }
        }

        #endregion

        #region Validation Number
        public void NumberValidation(KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        public void NumberValidationDecimal(KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 46 || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        #endregion
        #region ClearTextBox

        public static void clearTextBox2(Control.ControlCollection cc)
        {


            foreach (Control item in cc)
            {
                if (item.GetType().ToString() == "System.Windows.Forms.Panel")
                {
                    clearTextBox2(item.Controls);

                }
                if (item.GetType().ToString() == "System.Windows.Forms.GroupBox")
                {
                    clearTextBox2(item.Controls);
                }

                if (item.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    if (item.Tag != null)
                    {
                        item.Text = "0";
                    }
                    else
                    {
                        item.Text = "";
                    }
                }
                if (item.GetType().ToString() == "System.Windows.Forms.RichTextBox")
                {
                    item.Text = "";

                }
                if (item.GetType().ToString() == "System.Windows.Forms.ComboBox")
                {
                    item.Text = "";
                }
                if (item.GetType().ToString() == "System.Windows.Forms.DateTimePicker")
                {
                    item.Text = System.DateTime.Now.ToString();
                }
                if (item.GetType().ToString() == "System.Windows.Forms.DataGridView")
                {
                    item.Text = "";
                }
                if (item.GetType().ToString() == "System.Windows.Forms.TabControl")
                {
                    clearTextBox2(item.Controls);

                }




            }
        }

        #endregion
        #region LockCotrol

        public void DisableControl(Control.ControlCollection cc)
        {


            foreach (Control item in cc)
            {


                if (item.GetType().ToString() == "System.Windows.Forms.Panel")
                {
                    DisableControl(item.Controls);

                }
                if (item.GetType().ToString() == "System.Windows.Forms.GroupBox")
                {
                    DisableControl(item.Controls);
                }
                if (item.GetType().ToString() == "System.Windows.Forms.TextBox")
                {

                    item.Enabled = false;
                }
                if (item.GetType().ToString() == "System.Windows.Forms.ComboBox")
                {
                    item.Enabled = false;
                }
                if (item.GetType().ToString() == "System.Windows.Forms.DateTimePicker")
                {
                    item.Enabled = false;
                }
                if (item.GetType().ToString() == "System.Windows.Forms.DataGridView")
                {
                    item.Enabled = false;
                }

                if (item.GetType().ToString() == "System.Windows.Forms.RichTextBox")
                {

                    item.Enabled = false;
                }
                if (item.GetType().ToString() == "System.Windows.Forms.CheckBox")
                {

                    item.Enabled = false;
                }
                if (item.GetType().ToString() == "System.Windows.Forms.ListBox")
                {

                    item.Enabled = false;
                }
                if (item.GetType().ToString() == "System.Windows.Forms.Button")
                {
                    item.Enabled = false;
                }
                if (item.GetType().ToString() == "MultiColumnComboBoxDemo.MultiColumnComboBox")
                {
                    item.Enabled = false;
                }
            }
        }


        public void EnableControl(Control.ControlCollection cc)
        {


            foreach (Control item in cc)
            {


                if (item.GetType().ToString() == "System.Windows.Forms.Panel")
                {
                    EnableControl(item.Controls);

                }
                if (item.GetType().ToString() == "System.Windows.Forms.GroupBox")
                {
                    EnableControl(item.Controls);
                }
                if (item.GetType().ToString() == "System.Windows.Forms.TextBox")
                {

                    item.Enabled = true;
                }
                if (item.GetType().ToString() == "System.Windows.Forms.ComboBox")
                {
                    item.Enabled = true;
                }
                if (item.GetType().ToString() == "System.Windows.Forms.DateTimePicker")
                {
                    item.Enabled = true;
                }
                if (item.GetType().ToString() == "System.Windows.Forms.DataGridView")
                {
                    item.Enabled = true;
                }
                if (item.GetType().ToString() == "System.Windows.Forms.RichTextBox")
                {

                    item.Enabled = true;
                }
                if (item.GetType().ToString() == "System.Windows.Forms.CheckBox")
                {

                    item.Enabled = true;
                }
                if (item.GetType().ToString() == "System.Windows.Forms.ListBox")
                {

                    item.Enabled = true;
                }
                if (item.GetType().ToString() == "System.Windows.Forms.Button")
                {
                    item.Enabled = true;
                }
                if (item.GetType().ToString() == "MultiColumnComboBoxDemo.MultiColumnComboBox")
                {
                    item.Enabled = true;
                }
            }
        }

        #endregion

        #region AutoFillEditeble

        public void AutoFillEditeble(ComboBox cb, System.Windows.Forms.KeyPressEventArgs e, bool blnLimitToList)
        {
            string strFindStr = "";

            if (e.KeyChar == (char)8)
            {
                if (cb.SelectionStart <= 1)
                {
                    cb.Text = "";
                    return;
                }

                if (cb.SelectionLength == 0)
                    strFindStr = cb.Text.Substring(0, cb.Text.Length - 1);
                else
                    strFindStr = cb.Text.Substring(0, cb.SelectionStart - 1);
            }
            else
            {
                if (cb.SelectionLength == 0)
                    strFindStr = cb.Text + e.KeyChar;
                else
                    strFindStr = cb.Text.Substring(0, cb.SelectionStart) + e.KeyChar;
            }

            int intIdx = -1;

            // Search the string in the ComboBox list.

            intIdx = cb.FindString(strFindStr);

            if (intIdx != -1)
            {
                cb.SelectedText = "";
                cb.SelectedIndex = intIdx;
                cb.SelectionStart = strFindStr.Length;
                cb.SelectionLength = cb.Text.Length;
                e.Handled = true;
            }
            else
            {
                // e.Handled = blnLimitToList;
            }


        }
        #endregion
        #region AutoCompleteComboBox

        public void AutoComplete(ComboBox cb, System.Windows.Forms.KeyPressEventArgs e, bool blnLimitToList)
        {
            string strFindStr = "";

            if (e.KeyChar == (char)8)
            {
                if (cb.SelectionStart <= 1)
                {
                    cb.Text = "";
                    return;
                }

                if (cb.SelectionLength == 0)
                    strFindStr = cb.Text.Substring(0, cb.Text.Length - 1);
                else
                    strFindStr = cb.Text.Substring(0, cb.SelectionStart - 1);
            }
            else
            {
                if (cb.SelectionLength == 0)
                    strFindStr = cb.Text + e.KeyChar;
                else
                    strFindStr = cb.Text.Substring(0, cb.SelectionStart) + e.KeyChar;
            }

            int intIdx = -1;

            // Search the string in the ComboBox list.

            intIdx = cb.FindString(strFindStr);

            if (intIdx != -1)
            {
                cb.SelectedText = "";
                cb.SelectedIndex = intIdx;
                cb.SelectionStart = strFindStr.Length;
                cb.SelectionLength = cb.Text.Length;
                e.Handled = true;
            }
            else
            {
                e.Handled = blnLimitToList;
            }


        }
        #endregion

        #region AutoComplete Multi column ComboBox

        //public void AutoComplete(MultiColumnComboBox cb, System.Windows.Forms.KeyPressEventArgs e, bool blnLimitToList)
        //{
        //    string strFindStr = "";

        //    if (e.KeyChar == (char)8)
        //    {
        //        if (cb.SelectionStart <= 1)
        //        {
        //            cb.Text = "";
        //            return;
        //        }

        //        if (cb.SelectionLength == 0)
        //            strFindStr = cb.Text.Substring(0, cb.Text.Length - 1);
        //        else
        //            strFindStr = cb.Text.Substring(0, cb.SelectionStart - 1);
        //    }
        //    else
        //    {
        //        if (cb.SelectionLength == 0)
        //            strFindStr = cb.Text + e.KeyChar;
        //        else
        //            strFindStr = cb.Text.Substring(0, cb.SelectionStart) + e.KeyChar;
        //    }

        //    int intIdx = -1;

        //    // Search the string in the ComboBox list.

        //    intIdx = cb.FindString(strFindStr);

        //    if (intIdx != -1)
        //    {
        //        cb.SelectedText = "";
        //        cb.SelectedIndex = intIdx;
        //        cb.SelectionStart = strFindStr.Length;
        //        cb.SelectionLength = cb.Text.Length;
        //        e.Handled = true;
        //    }
        //    else
        //    {
        //        e.Handled = blnLimitToList;
        //    }


        //}
        #endregion



        #region Button Enable Disable
        public Boolean[] EnableVisible(int cc)
        {


            switch (cc)
            {

                case 0: //Form Load
                    Boolean[] z = { true, false, false, false, false, true, false, true };//true-Add,Search
                    return z;
                    break;
                case 1: //add
                    Boolean[] b = { false, true, true, false, false, false, false, true };//true-insert
                    return b;
                    break;
                case 2: //save
                    Boolean[] c = { true, false, false, false, false, true, false, true };
                    return c;
                    break;
                case 3: // a=cancle
                    Boolean[] d = { true, false, false, false, false, true, false, true };
                    return d;
                    break;
                case 4: // a=modify
                    Boolean[] e = { false, true, true, false, false, true, false, true };//true-Update
                    return e;
                    break;
                case 5: //delete
                    Boolean[] f = { true, false, false, false, false, true, false, true };
                    return f;
                    break;
                case 6: //Search
                    Boolean[] g = { true, false, true, true, true, false, true, true };
                    return g;
                    break;
                case 7: //Print
                    Boolean[] h = { true, false, false, false, false, true, false, true };
                    return h;
                    break;
                default:
                    return null;
            }
        }
        #endregion
        Hashtable hash = new Hashtable();
        int RAdd, RSave, RCancel, RModify, RSearch, RDelete, RPrint;
        #region Button Rights
        public Boolean[] ButtonRights(int cc)
        {

            Boolean[] z;
            hash = new Hashtable();
            hash.Add("@QueryNo", 101);
            hash.Add("@intUserID", intLoginUserID);

            DataTable dtReturn = ClsDefination.FillData("", hash);
            if (true)
            {
                Boolean[] z2 = { };
            }
            else
            {

            }
            Boolean[] z1 = { true, false, false, false, true, false, false, true };//true-Add,Search
            return z1;


        }
        #endregion

        # region Print Direct
        public void PrintDirect(int QueryNo)
         {

            try
            {
                //cammented because crystal report is Not installed



                ReportDocument ObjReportDocument = new ReportDocument();


                if (QueryNo == 1002) //KOT Print
                {
                    //ObjReportDocument.Load(CommonPath + "\\rptKOTBill.rpt"E:\Abhi\Textile\Textile\Rpt\GSTReport.rpt);
                    //ObjReportDocument.Load(CommonPath + "\\GSTReport.rpt");
                    ObjReportDocument.Load(reportPath + "\\GSTReport.rpt");
                }

                if (QueryNo == 1006)
                {
                    //ObjReportDocument.Load(CommonPath + "\\MagSalaryReport.rpt");
                    ObjReportDocument.Load(reportPath + "\\MagSalaryReport.rpt");
                }
                if (QueryNo == 1007)
                {
                    //ObjReportDocument.Load(CommonPath + "\\Stock.rpt");
                    ObjReportDocument.Load(reportPath + "\\StockNew.rpt");
                }
                //
                if (QueryNo == 1008)
                {
                    //ObjReportDocument.Load(CommonPath + "\\SalesInvoice.rpt");
                    ObjReportDocument.Load(reportPath + "\\CommonSalesInvoice.rpt");
                }

                if (QueryNo == 1009)
                {
                    //ObjReportDocument.Load(CommonPath + "\\DChalan.rpt");
                    ObjReportDocument.Load(reportPath + "\\DChalan3.rpt");
                }

                if (QueryNo == 1014)
                {
                    // YarnStock  BeamStock
                    ObjReportDocument.Load(reportPath + "\\YarnStock.rpt");
                }
                if (QueryNo == 1015)
                {
                    // YarnStock  BeamStock TagaStock
                    ObjReportDocument.Load(reportPath + "\\BeamStock.rpt");
                }
                if (QueryNo == 1016)
                {
                    // YarnStock  BeamStock TagaStock
                    ObjReportDocument.Load(reportPath + "\\TagaStock.rpt");
                }
                ParameterFieldDefinition crParameterFieldDefinition;
                ParameterFieldDefinitions crParameterFieldDefinitions;
                ParameterValues crParameterValues = new ParameterValues();
                ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

                ConnectionInfo crConnectionInfo = new ConnectionInfo();
                TableLogOnInfo crTableLogOnInfo = new TableLogOnInfo();

                if (QueryNo == 1002)
                {
                    ObjReportDocument.SetParameterValue("@QueryNo", QueryNo);
                    ObjReportDocument.SetParameterValue("@dtpFromDate", sdtFromDate);
                    ObjReportDocument.SetParameterValue("@dtpToDate", sdtToDate);
                    ObjReportDocument.SetParameterValue("@intCompanyId", Convert.ToInt32(companyId));
                    ObjReportDocument.SetParameterValue("@intYearId", Convert.ToInt32(yearID));
                }
                if (QueryNo == 1006)
                {
                    ObjReportDocument.SetParameterValue("@QueryNo", QueryNo);
                    //ObjReportDocument.SetParameterValue("@dtpFromDate", sdtFromDate);
                    //ObjReportDocument.SetParameterValue("@dtpToDate", sdtToDate);
                    ObjReportDocument.SetParameterValue("@intCompanyId", Convert.ToInt32(companyId));
                    ObjReportDocument.SetParameterValue("@intYearId", Convert.ToInt32(yearID));
                    ObjReportDocument.SetParameterValue("@intCode", Convert.ToInt32(BillNo));
                }
                if (QueryNo == 1007 || QueryNo == 1014 || QueryNo == 1015 || QueryNo == 1016)
                {
                    ObjReportDocument.SetParameterValue("@QueryNo", QueryNo);
                    ObjReportDocument.SetParameterValue("@intCompanyId", Convert.ToInt32(companyId));
                   // ObjReportDocument.SetParameterValue("@intYearId", Convert.ToInt32(yearID));
                    ObjReportDocument.SetParameterValue("@intShade", Convert.ToInt32(shade));
                }
                if (QueryNo == 1008)
                {
                    ObjReportDocument.SetParameterValue("@QueryNo", QueryNo);
                    ObjReportDocument.SetParameterValue("@intCompanyId", Convert.ToInt32(companyId));
                    ObjReportDocument.SetParameterValue("@intYearId", Convert.ToInt32(yearID));
                    ObjReportDocument.SetParameterValue("@intCode", Convert.ToInt32(BillNo));
                    ObjReportDocument.SetParameterValue("@intFromParty",Convert.ToInt32(supplierId));

                }

                Tables crTables;

                using (ClsDefination objMaster = new ClsDefination())
                {
                    objMaster.ReportConnectionServer();

                    crConnectionInfo.ServerName = server;

                    crConnectionInfo.DatabaseName = dbname;

                    if (username.ToLower() == "sa")
                    {
                        crConnectionInfo.UserID = username;

                        crConnectionInfo.Password = password;
                    }
                    else
                    {
                        crConnectionInfo.IntegratedSecurity = true;
                    }

                }



                crTables = ObjReportDocument.Database.Tables;

                foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in crTables)
                {

                    crTableLogOnInfo = CrTable.LogOnInfo;

                    crTableLogOnInfo.ConnectionInfo = crConnectionInfo;

                    CrTable.ApplyLogOnInfo(crTableLogOnInfo);

                }
                ObjReportDocument.PrintOptions.PrinterName = PrinterName;
                ObjReportDocument.PrintToPrinter(1, false, 0, 0);
            }
            catch (Exception ex)
            {

            }

        }


        #endregion

        //        # region Print Direct
        //        public void PrintDirect()
        //        {
        //            ReportDocument ObjReportDocument = new ReportDocument();
        //            CommonPath = reporPath;

        //            if(QueryNo==101)
        //            {
        //            //E:\NEW BEGNING\Chit Fund\ChitFund\ChitFund\bin\Debug\RPT\
        //                ObjReportDocument.Load(CommonPath+"\\DefoultrtList.rpt");
        //            }
        //            //if (QueryNo == 1017)  //Bill Print
        //            //{
        //            //    ObjReportDocument.Load(CommonPath + "\\PRSales.rpt");
        //            //}
        //            //else if (QueryNo == 1002) //KOT Print
        //            //{
        //            //    ObjReportDocument.Load(CommonPath + "\\rptKOTBill.rpt");
        //            //}
        //            //else if (QueryNo == 105) //KOT Print
        //            //{
        //            //    ObjReportDocument.Load(CommonPath + "\\SalesbillPrint.rpt");

        //            //}
        //            ParameterFieldDefinition crParameterFieldDefinition;
        //            ParameterFieldDefinitions crParameterFieldDefinitions;
        //            ParameterValues crParameterValues = new ParameterValues();
        //            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

        //            ConnectionInfo crConnectionInfo = new ConnectionInfo();
        //            TableLogOnInfo crTableLogOnInfo = new TableLogOnInfo();

        //            if (QueryNo == 101)
        //            {

        ////                  as int=0,
        ////  as int=0,
        ////  as int=0 ,

        ////  as int=0,
        ////  as int=0,
        ////  as int=0,
        ////  as int=0,
        ////  as int=0,
        ////  as int =0,
        ////  as int=0,

        //// as smalldatetime= '01/01/1900',
        ////  as smalldatetime= '01/01/1900'

        //                ObjReportDocument.SetParameterValue("@QueryNo", QueryNo);
        //                ObjReportDocument.SetParameterValue("@QueryNoDed", 0);
        //                ObjReportDocument.SetParameterValue("@QueryNoALL", 0);
        //                ObjReportDocument.SetParameterValue("@intCustId", 0);
        //                ObjReportDocument.SetParameterValue("@intEmpId", 0);
        //                ObjReportDocument.SetParameterValue("@intCode", 0);
        //                ObjReportDocument.SetParameterValue("@intCompanyId", 1001);
        //                ObjReportDocument.SetParameterValue("@intYearId", 1);
        //                ObjReportDocument.SetParameterValue("@intSubgroupId", 1001);
        //                ObjReportDocument.SetParameterValue("@intInstallmentNo", 2);
        //                ObjReportDocument.SetParameterValue("@sdtFromDate", "01/01/1900");
        //                ObjReportDocument.SetParameterValue("@sdtToDate", "01/01/1900");

        //            }
        //            else if (QueryNo == 105)
        //            {
        //                ObjReportDocument.SetParameterValue("@QueryNo", QueryNo);
        //                //ObjReportDocument.SetParameterValue("@intProcessNo", VoucherNo);
        //                ObjReportDocument.SetParameterValue("@intPartyNo", 0);
        //                //ObjReportDocument.SetParameterValue("@intComponentNo", 0);
        //                ObjReportDocument.SetParameterValue("@sdtFromDate", "01/01/1900");
        //                ObjReportDocument.SetParameterValue("@sdtToDate", "01/01/1900");
        //                ObjReportDocument.SetParameterValue("@intProductID", 0);

        //                //ObjReportDocument.SetParameterValue("@intProductID", 0);
        //                ObjReportDocument.SetParameterValue("@intCategoryID", 0);
        //                ObjReportDocument.SetParameterValue("@intSubcategoryID", 0);
        //                ObjReportDocument.SetParameterValue("@intCompanyID", 0);
        //                ObjReportDocument.SetParameterValue("@intSupplierId", 0);
        //                ObjReportDocument.SetParameterValue("@intBatchNo", 0);
        //                ObjReportDocument.SetParameterValue("@intYearID", 0);
        //                // ObjReportDocument.SetParameterValue("@intAccontid", 0);
        //                ObjReportDocument.SetParameterValue("@intCustid", 0);
        //                ObjReportDocument.SetParameterValue("@salesid", BillNo);


        //            }
        //            Tables crTables;

        //            using (ClsDefination objMaster = new ClsDefination())
        //            {
        //                objMaster.ReportConnectionServer();


        //                crConnectionInfo.ServerName = objMaster.ServerNM;

        //                crConnectionInfo.DatabaseName = objMaster.DatabaseNM;

        //                crConnectionInfo.UserID = objMaster.UserNM;

        //                userName= objMaster.UserNM;
        //                crConnectionInfo.Password = objMaster.PasswordStr;
        //                Password = objMaster.PasswordStr;
        //                if (userName == "sa")
        //                {
        //                    crConnectionInfo.UserID = userName;
        //                    crConnectionInfo.Password = Password;
        //                }
        //                else
        //                {
        //                    crConnectionInfo.IntegratedSecurity = true;
        //                }

        //                PrinterSettings settings = new PrinterSettings();
        //                foreach (string printer in PrinterSettings.InstalledPrinters)
        //                {
        //                    settings.PrinterName = printer;
        //                    if (settings.IsDefaultPrinter)
        //                        PrinterName= printer;
        //                }
        //               // return string.Empty;
        //                //PrinterName = objMaster.PrinterName1;

        //               // PrinterName = "Send To OneNote 2007";
        //            }



        //            crTables = ObjReportDocument.Database.Tables;

        //            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in crTables)
        //            {

        //                crTableLogOnInfo = CrTable.LogOnInfo;

        //                crTableLogOnInfo.ConnectionInfo = crConnectionInfo;

        //                CrTable.ApplyLogOnInfo(crTableLogOnInfo);

        //            }
        //            ObjReportDocument.PrintOptions.PrinterName = PrinterName;
        //            ObjReportDocument.PrintToPrinter(1, false, 0, 0);

        //        }

        //        #endregion 

        #region Form theme

        #region Font & size for TextBox, combobox, checkbox
        public void SetFontAndSize(Control.ControlCollection cc)
        {
            foreach (Control item in cc)
            {
                if (item.GetType().ToString() == "System.Windows.Forms.Panel")
                {
                    //if (item.Name.ToString() == "PanelTitle")
                    //{
                    //    item.Size = new Size(PanelTitleSizeX, PanelTitleSizeY);
                    //}
                    //else if (item.Name.ToString() == "PanelButton")
                    //{
                    //    item.Size = new Size(PanelButtonSizeX, PanelButtonSizeY);
                    //}
                    //else 
                    if (item.Name.ToString() == "PanelMasterMiddle")
                    {
                        item.Size = new Size(PanelMasterMiddleSizeX, PanelMasterMiddleSizeY);
                    }
                    else if (item.Name.ToString() == "PanelTransactionMiddle")
                    {
                        item.Size = new Size(PanelTransactionMiddleSizeX, PanelTransactionMiddleSizeY);
                    }

                    SetFontAndSize(item.Controls);

                }
                if (item.GetType().ToString() == "System.Windows.Forms.GroupBox")
                {
                    SetFontAndSize(item.Controls);
                }


                if (item.GetType().ToString() == "System.Windows.Forms.TextBox" || item.GetType().ToString() == "System.Windows.Forms.ComboBox" || item.GetType().ToString() == "System.Windows.Forms.DateTimePicker" || item.GetType().ToString() == "System.Windows.Forms.CheckBox")
                {

                    item.Font = new Font(TextBoxFont, TextBoxSize);
                }

                if (item.GetType().ToString() == "System.Windows.Forms.Label")
                {
                    if (item.Name.ToString() == "lblTitle")
                    {
                        item.Font = new Font(TitleFont, TitleSize);
                        item.ForeColor = LableForeColor;
                    }
                    else
                    {
                        item.Font = new Font(LableFont, LableSize);
                        //item.ForeColor = LableForeColor;
                    }

                }
                if (item.GetType().ToString() == "System.Windows.Forms.Button")
                {
                    item.Font = new Font(ButtonFont, ButtonFontSize);
                    item.BackColor = ButtonBackColor;
                }
                if (item.GetType().ToString() == "System.Windows.Forms.DataGridView")
                {
                    item.Font = new Font(GridViewFont, GridFontSize);
                    //item.BackColor = ButtonBackColor;
                }

            }
        }

        #endregion

        #endregion


        #region GridColumnsVisible

        public void GridColumnsVisible(DataGridView Dgv, ArrayList arr1)
        {
            try
            {
                foreach (int item in arr1)
                {
                    Dgv.Columns[item].Visible = false;
                }
            }
            catch { }
        }

        #endregion

        #region GridColumnsReadOnly

        public void GridColumnsReadOnly(DataGridView Dgv, ArrayList arr1)
        {
            foreach (int item in arr1)
            {
                Dgv.Columns[item].ReadOnly = true;
                Dgv.Columns[item].DefaultCellStyle.BackColor = Color.Gainsboro;
            }
        }

        #endregion

        #region GridWrapMode

        public void GridWrapMode(DataGridView Dgv, ArrayList arr1)
        {
            foreach (int item in arr1)
            {
                Dgv.Columns[item].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
        }

        #endregion

        #region Grid Alternate Color

        public void GridAlternateColor(DataGridView Dgv)
        {
            Dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkCyan;
        }

        #endregion


        //#region Number validation

        //public void NumberValidation(KeyPressEventArgs e)
        //{
        //    if (e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 46)
        //    {
        //        e.Handled = false;
        //    }
        //    else
        //    {
        //        e.Handled = true;
        //    }
        //}

        //#endregion

        #region Character validation (Numerical values not allowed)

        public void CharacterValidation(KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 46)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        #endregion

        //#region Combo box property

        //public void SetComboProperty(ComboBox cmb, EventArgs e)
        //{
        //    cmb.DroppedDown = true;    
        //}

        ////public void SetComboProperty(Control cmb, EventArgs e)
        ////{
        ////    if (cmb.GetType ().ToString() =="System.Windows.Forms.ComboBox" )
        ////    {
        ////        cmb.DroppedDown = true;                
        ////    }
        ////}

        //#endregion







        internal void AutoFillEditeble(ComboBox cmbProductName, EventArgs e, bool p)
        {
            //throw new NotImplementedException();
        }

        internal void GridRowNo()
        {
            throw new NotImplementedException();
        }

        internal void AutoFillEditeble()
        {
            throw new NotImplementedException();
        }

        //internal void clearTextBox(ChitFund.Masters.AccountMaster accountMaster)
        //{
        //    throw new NotImplementedException();
        //}

        internal void AutoComplete(ComboBox cmbMenuName, KeyEventArgs e, bool p)
        {
            throw new NotImplementedException();
        }

        internal void SetFontAndSize()
        {
            throw new NotImplementedException();
        }
    }

}

