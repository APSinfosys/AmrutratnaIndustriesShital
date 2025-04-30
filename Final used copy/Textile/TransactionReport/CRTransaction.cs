using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
//using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
//using CrystalDecisions.Shared;


namespace Textile.TransactionReport
{
    public partial class CRTransaction : Form
    {
        public CRTransaction()
        {
            InitializeComponent();
        }
        public Int32 QueryNo, intProductID, intPartyNo, intCategoryID, intSubcategoryID,
       intCompanyID, intSupplierId, intYearID, VoucherId, intGodownid, intNewFormType, intSaleType, intFirm;
        public string sdtFromDate, sdtToDate, StrBatchNo, strQuotDetailID, reportPath, server, dbname, username, password;
        // string CommonPath = @"D:\ProcSoMate\Angel";
        string CommonPath = Application.StartupPath + "\\RPTs";

        private void CRTransaction_Load(object sender, EventArgs e)
        {
            try
            {

                CRVReport1.Refresh();
                CommonPath = reportPath;


                if (CommonPath == null)
                {
                    CommonPath = "E:\\testrpt\\RPTs";
                }

                ReportDocument ObjReportDocument = new ReportDocument();

                //   ReportDocument sub = new ReportDocument();

                //    ObjReportDocument.subrpt sub = new ObjReportDocument.subrpt();

                if (QueryNo == 1107)
                {
                    ObjReportDocument.Load(CommonPath + "\\DailyBillRegister.rpt");

                }
                else if (QueryNo == 4001)
                {
                    ObjReportDocument.Load(CommonPath + "\\SalaryReportAuto.rpt");
                }
                else if (QueryNo == 3001)
                {
                    ObjReportDocument.Load(CommonPath + "\\SalesDetailsGST.rpt");
                }
                else if (QueryNo == 3002)
                {
                    ObjReportDocument.Load(CommonPath + "\\PurchaseDetialsGST.rpt");
                }
                else if (QueryNo == 1009)
                {
                    ObjReportDocument.Load(CommonPath + "\\DChalan3.rpt");
                }
                else
                    if (QueryNo == 3)
                    {
                        ObjReportDocument.Load(CommonPath + "\\DailySalesPurchase.rpt");

                    }
                    else
                        if (QueryNo == 1)
                        {
                            ObjReportDocument.Load(CommonPath + "\\DailyStockOfShop.rpt");

                        }
                        else
                            if (QueryNo == 2)
                            {
                                ObjReportDocument.Load(CommonPath + "\\DailyStockOfGodown.rpt");

                            }
                            else
                                if (QueryNo == 117)
                                {
                                    ObjReportDocument.Load(CommonPath + "\\BarcodePrintssold.rpt");

                                }
                                else
                                    if (QueryNo == 1172)
                                    {
                                        ObjReportDocument.Load(CommonPath + "\\CompanyBarcodePrint.rpt");

                                    }
                                    else
                                        if (QueryNo == 104)//----Detail purchase invoice register
                                        {

                                            ObjReportDocument.Load(CommonPath + "\\PurchaseDetailRegister.rpt");
                                        }

                                        else if (QueryNo == 121)
                                        {

                                            ObjReportDocument.Load(CommonPath + "\\SalesInvoiceRegisterNew.rpt");
                                        }
                                        else if (QueryNo == 1120)//Sales Receipt
                                        {

                                            ObjReportDocument.Load(CommonPath + "\\Print_SalesReceipt.rpt");
                                        }
                                        //else if (QueryNo == 1121)//Purchase Receipt
                                        //{

                                        //    ObjReportDocument.Load(CommonPath + "\\Print_PurchaseReceipt.rpt");
                                        //}

                                        else if (QueryNo == 105)//sales print
                                        {
                                            //ObjReportDocument.Load(CommonPath + "\\SalesbillPrint1.rpt");//"\\SalesbillPrint2.rpt");
                                            ObjReportDocument.Load(CommonPath + "\\Medical.rpt");

                                        }
                                        else if (QueryNo == 6002)//sales print
                                        {
                                            //ObjReportDocument.Load(CommonPath + "\\SalesbillPrint1.rpt");//"\\SalesbillPrint2.rpt");
                                            //ObjReportDocument.Load(CommonPath + "\\MedicalNew6002.rpt");
                                            //if (intNewFormType == 1)
                                            //{
                                            //    ObjReportDocument.Load(CommonPath + "\\Avtar.rpt");
                                            //}
                                            //else
                                            //{
                                            //    ObjReportDocument.Load(CommonPath + "\\AvtarCR.rpt");
                                            //}

                                            ObjReportDocument.Load(CommonPath + "\\YarnInwardOnlyReport.rpt");
                                        }
                                        else if (QueryNo == 6003)//sales print
                                        {
                                            //ObjReportDocument.Load(CommonPath + "\\SalesbillPrint1.rpt");//"\\SalesbillPrint2.rpt");
                                            //ObjReportDocument.Load(CommonPath + "\\MedicalNew6002.rpt");
                                            if (intNewFormType == 1)
                                            {
                                                ObjReportDocument.Load(CommonPath + "\\AvtarSGCG.rpt");
                                            }
                                            else
                                            {
                                                ObjReportDocument.Load(CommonPath + "\\AvtarSGCGCR.rpt");
                                            }


                                        }

                                        else if (QueryNo == 6011)
                                        {//E:\NEW BEGNING\RAHUL DEMO\InventorySystem\bin\Debug\RPTs\subRptForCGST.rpt
                                            ObjReportDocument.Load(CommonPath + "\\ShreyaEnterprises.rpt");
                                            //sub.Load(CommonPath + "\\subRptForCGST.rpt");
                                        }
                                        else if (QueryNo == 6014)
                                        {
                                            ObjReportDocument.Load(CommonPath + "\\QuotationShreyaEnterprises.rpt");
                                        }
                                        else if (QueryNo == 6025)
                                        {//E:\NEW BEGNING\RAHUL DEMO\InventorySystem\bin\Debug\RPTs\BuyBackForShreyaEnterprises.rpt
                                            ObjReportDocument.Load(CommonPath + "\\BuyBackForShreyaEnterprises.rpt");
                                        }
                                        else if (QueryNo == 6024)
                                        {//E:\NEW BEGNING\RAHUL DEMO\InventorySystem\bin\Debug\RPTs\GSTReturnForShreyaEnterprises.rpt
                                            ObjReportDocument.Load(CommonPath + "\\GSTReturnForShreyaEnterprises.rpt");
                                        }
                                        else if (QueryNo == 6026)
                                        {//E:\Final Copies\Shreya Enterprises\InventorySystem\bin\Debug\RPTs\GSTReturnCA.rpt
                                            ObjReportDocument.Load(CommonPath + "\\GSTReturnCA.rpt");
                                        }

                                        else if (QueryNo == 300)//Bank Statement print
                                        {
                                            ObjReportDocument.Load(CommonPath + "\\BankStatementPrint.rpt");


                                        }
                                        else if (QueryNo == 601)//DepositRegister
                                        {
                                            ObjReportDocument.Load(CommonPath + "\\DepositRegisterPrint.rpt");


                                        }
                                        else if (QueryNo == 113)//DepositRegister
                                        {
                                            ObjReportDocument.Load(CommonPath + "\\PaymentWithdrowRegister.rpt");


                                        }
                                        else if (QueryNo == 2122)//sales receipt
                                        {
                                            ObjReportDocument.Load(CommonPath + "\\SalesbillPrint2.rpt");


                                        }
                                        else if (QueryNo == 2123)//debitor ledger entry 
                                        {
                                            ObjReportDocument.Load(CommonPath + "\\LedgerRPT.rpt");


                                        }
                                        else if (QueryNo == 2124)//creditors ledger entry 
                                        {
                                            ObjReportDocument.Load(CommonPath + "\\PurchaseLedgerRPT.rpt");


                                        }
                                        else if (QueryNo == 1115)//a/c BALANCE REPORT
                                        {
                                            ObjReportDocument.Load(CommonPath + "\\AccountBalance.rpt");


                                        }
                                        else if (QueryNo == 103)//Supplier GRN
                                        {
                                            ObjReportDocument.Load(CommonPath + "\\GRN_Register.rpt");


                                        }
                                        else if (QueryNo == 503)//BillReport.rpt   
                                        {
                                            ObjReportDocument.Load(CommonPath + "\\BillReport.rpt");


                                        }
                                        else if (QueryNo == 101)// Payment Deposit Print
                                        {
                                            ObjReportDocument.Load(CommonPath + "\\PrintPaymentDeposit.rpt");


                                        }
                                        else if (QueryNo == 111)// journal voucher Print
                                        {
                                            ObjReportDocument.Load(CommonPath + "\\VoucherPrint.rpt");


                                        }
                                        else if (QueryNo == 1131)// journal voucher Register Print
                                        {
                                            ObjReportDocument.Load(CommonPath + "\\VoucherRegisterPrint.rpt");


                                        }
                                        else if (QueryNo == 200)//withdrow Print
                                        {
                                            ObjReportDocument.Load(CommonPath + "\\Print_PurchaseReceipt.rpt");


                                        }
                                        else if (QueryNo == 1207)//withdrow Print
                                        {
                                            ObjReportDocument.Load(CommonPath + "\\PrintNormalSalseRegister.rpt");


                                        }
                                        else if (QueryNo == 1208)//withdrow Print
                                        {
                                            ObjReportDocument.Load(CommonPath + "\\PrintDetailSalesRegister.rpt");


                                        }
                                        else
                                            if (QueryNo == 204)//----Normal purchase invoice register
                                            {

                                                //ObjReportDocument.Load(@"E:\ABHI\Shreya Enterprises\InventorySystem\bin\Debug\RPTs\PurchaseRegisterNew.rpt");
                                                ObjReportDocument.Load(CommonPath + "\\PurchaseRegisterNew.rpt");
                                                //ObjReportDocument.Load(@"E:\MY SOFTWARES\Abhi\InventoryUpdates07-08-2015\InventorySystem07-08-2015\InventorySystem\bin\Debug\RPTs\PurchaseRegister1.rpt ");
                                            }
                                            else if (QueryNo == 5001)
                                            {
                                                ObjReportDocument.Load(CommonPath + "\\PurchaseLedegerAgainstFrim.rpt");
                                            }
                                            else if (QueryNo == 7001)
                                            {
                                                if (intFirm == 0)
                                                {
                                                    ObjReportDocument.Load(CommonPath + "\\PurchaseLedgerAgainstPartyN.rpt");
                                                }
                                                else
                                                {
                                                    ObjReportDocument.Load(CommonPath + "\\PurchaseLedgerAgainstFirmNew.rpt");
                                                }
                                            }
                                            else if (QueryNo == 7002)
                                            {
                                                if (intFirm == 0)
                                                {
                                                    ObjReportDocument.Load(CommonPath + "\\SalesLedgerAgainstParty.rpt");
                                                }
                                                else
                                                {
                                                    ObjReportDocument.Load(CommonPath + "\\SalesLedgerAgainstFirmNew.rpt");
                                                }
                                            }
                                            else if (QueryNo == 5002)
                                            {
                                                ObjReportDocument.Load(CommonPath + "\\PurchaseLeadgerAgainstParty.rpt");
                                            }
                                            else if (QueryNo == 5003)
                                            {
                                                ObjReportDocument.Load(CommonPath + "\\SalesLedegerAgainstFirmP.rpt");
                                            }
                                            else if (QueryNo == 5004)
                                            {
                                                ObjReportDocument.Load(CommonPath + "\\SalesLedegerAgainstPartyP.rpt");
                                            }
                                            else
                                                if (QueryNo == 110)//----stock register report
                                                {

                                                    ObjReportDocument.Load(CommonPath + "\\SendroyDebtorsReport.rpt");
                                                }
                                                else
                                                    if (QueryNo == 116)//----Account balance transfer report
                                                    {

                                                        //ObjReportDocument.Load(CommonPath + "\\PrintAccountBalanceTrans.rpt");
                                                        ObjReportDocument.Load(CommonPath + "\\Account_BalTransfer.rpt");
                                                    }
                                                    else
                                                        if (QueryNo == 109)//----stock register report
                                                        {

                                                            ObjReportDocument.Load(CommonPath + "\\SendroyCreditorsReport.rpt");
                                                        }
                                                        else
                                                            if (QueryNo == 131)//----stock register report
                                                            {

                                                                ObjReportDocument.Load(CommonPath + "\\DailyStockRegister.rpt");
                                                            }
                //else
                //if (QueryNo == 420)//----SALES RETURN register report
                //{

                //    ObjReportDocument.Load(CommonPath + "\\SalesReturnsRegister.rpt");
                //}
                if (QueryNo == 255)//----Purchase RETURN print
                {

                    ObjReportDocument.Load(CommonPath + "\\Print_PurchaseReturns.rpt");
                }
                else
                    if (QueryNo == 420)//----SALES RETURN register report
                    {

                        ObjReportDocument.Load(CommonPath + "\\SalesReturnsRegister.rpt");
                    }
                    else
                        if (QueryNo == 106)//----SALES RETURN register report
                        {

                            ObjReportDocument.Load(CommonPath + "\\PurchasrReturn_Reg.rpt");
                        }
                        else
                            if (QueryNo == 114)//----SALES Receipt register report
                            {

                                ObjReportDocument.Load(CommonPath + "\\salesReceipt_Reg.rpt");
                            }
                            else
                                if (QueryNo == 1001)//----SALES Receipt register report
                                {

                                    ObjReportDocument.Load(CommonPath + "\\Inward_Reg.rpt");
                                }
                                else if (QueryNo == 1003)//sales print
                                {
                                    ObjReportDocument.Load(CommonPath + "\\DeliveryChallan_Reg.rpt");


                                }

                                else
                                    if (QueryNo == 230)//----SALES RETURN Print
                                    {

                                        ObjReportDocument.Load(CommonPath + "\\Print_SalesReturns.rpt");
                                    }
                                    else
                                        if (QueryNo == 2020)//----Delivery challan  Print
                                        {

                                            ObjReportDocument.Load(CommonPath + "\\Print_DChallan.rpt");
                                        }
                                        else
                                            if (QueryNo == 107)//----GodawonTranferReg  Print
                                            {

                                                ObjReportDocument.Load(CommonPath + "\\GodawonTranferReg.rpt");
                                            }
                                            else
                                                if (QueryNo == 400)//----InwardTreansportReport reg
                                                {

                                                    ObjReportDocument.Load(CommonPath + "\\InwardTreansportReport.rpt");
                                                }
                                                else
                                                    if (QueryNo == 118)//----GodawonTransferLoose reg
                                                    {

                                                        ObjReportDocument.Load(CommonPath + "\\GodawonTransferLoose.rpt");
                                                    }
                                                    else if (QueryNo == 450)//----InwardTreansportReport reg
                                                    {

                                                        ObjReportDocument.Load(CommonPath + "\\OutwordTransportReport.rpt");
                                                    }
                                                    else if (QueryNo == 119)//----InwardTreansportReport reg
                                                    {

                                                        ObjReportDocument.Load(CommonPath + "\\Consumption.rpt");
                                                    }

                                                    else if (QueryNo == 1008)
                                                    {
                                                        //ObjReportDocument.Load(CommonPath + "\\CommonSalesInvoice.rpt");
                                                        //ShelkeSalesInvoice.rpt 
                                                        //ObjReportDocument.Load(CommonPath + "\\ShelkeSalesInvoice.rpt");
                                                        ObjReportDocument.Load(CommonPath + "\\SampleSalesInvoice1.rpt");
                                                    }

                                                    else if (QueryNo == 10002)
                                                    {
                                                        ObjReportDocument.Load(CommonPath + "\\ChequeTdsDetails.rpt");
                                                    }
                                                    else if (QueryNo == 10003)
                                                    {
                                                        if (intNewFormType == 1)
                                                        {
                                                            ObjReportDocument.Load(CommonPath + "\\BillDetails.rpt");
                                                        }
                                                        else if (intNewFormType == 2)
                                                        {
                                                            ObjReportDocument.Load(CommonPath + "\\Outstanding.rpt");
                                                        }

                                                    }

                ParameterFieldDefinition crParameterFieldDefinition;
                ParameterFieldDefinitions crParameterFieldDefinitions;
                ParameterValues crParameterValues = new ParameterValues();
                ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

                ConnectionInfo crConnectionInfo = new ConnectionInfo();
                TableLogOnInfo crTableLogOnInfo = new TableLogOnInfo();
                // ReportDocument obj = new ReportDocument();



                if (QueryNo == 1009)
                {
                    ObjReportDocument.SetParameterValue("@QueryNo", QueryNo);
                    ObjReportDocument.SetParameterValue("@intCompanyId", intCompanyID);
                    ObjReportDocument.SetParameterValue("@intYearId", intYearID);
                    ObjReportDocument.SetParameterValue("@intCode", VoucherId);

                }

                if (QueryNo == 4001)
                {

                    ObjReportDocument.SetParameterValue("@QueryNo", QueryNo);
                    ObjReportDocument.SetParameterValue("@intShade", intPartyNo);
                    ObjReportDocument.SetParameterValue("@intCompanyId", intCompanyID);
                    ObjReportDocument.SetParameterValue("@intYearId", intYearID);
                    ObjReportDocument.SetParameterValue("@intCode", intGodownid);
                }

                if (QueryNo == 3001 || QueryNo == 3002)
                {
                    ObjReportDocument.SetParameterValue("@QueryNo", QueryNo);
                    ObjReportDocument.SetParameterValue("@intShade", VoucherId);
                    ObjReportDocument.SetParameterValue("@intCompanyId", intCompanyID);
                    ObjReportDocument.SetParameterValue("@dtpFromDate", sdtFromDate);
                    ObjReportDocument.SetParameterValue("@dtpToDate", sdtToDate);
                    ObjReportDocument.SetParameterValue("@intYearId", intYearID);

                }
                if (QueryNo == 1008)
                {
                    //ObjReportDocument.SetParameterValue("@QueryNo", QueryNo);
                    ObjReportDocument.SetParameterValue("@intFromParty",0);
                    //ObjReportDocument.SetParameterValue("@intCode",VoucherId);
                    ObjReportDocument.SetParameterValue("@intYearId",0);
                    ObjReportDocument.SetParameterValue("@intCompanyId",0);

                    ObjReportDocument.SetParameterValue("@QueryNo", QueryNo);
                    ObjReportDocument.SetParameterValue("@strUniqueCode", "");
                    ObjReportDocument.SetParameterValue("@intShade", Convert.ToInt32(0));
                     ObjReportDocument.SetParameterValue("@decMtr", Convert.ToDecimal(0));
                    ObjReportDocument.SetParameterValue("@intCode", Convert.ToInt32(VoucherId));
                    ObjReportDocument.SetParameterValue("@intEmployeeId", 0);

                    ObjReportDocument.SetParameterValue("@dtpFromDate", "01/01/2000");
                    ObjReportDocument.SetParameterValue("@dtpToDate", "01/01/2000");
                    ObjReportDocument.SetParameterValue("@intQuality", 0);
                    ObjReportDocument.SetParameterValue("@intTo", 0);
                    ObjReportDocument.SetParameterValue("@intFrom", 0);

              


                }

                if (QueryNo == 10002 || QueryNo == 10003)
                {
                    ObjReportDocument.SetParameterValue("@QueryNo", QueryNo);
                    ObjReportDocument.SetParameterValue("@intFromParty", intFirm);
                    ObjReportDocument.SetParameterValue("@dtpFromDate", sdtFromDate);
                    ObjReportDocument.SetParameterValue("@dtpToDate", sdtToDate);
                }

                // || QueryNo == 1207
                if (QueryNo == 1107 || QueryNo == 3 || QueryNo == 1 || QueryNo == 2 || QueryNo == 114
                    || QueryNo == 1001 || QueryNo == 1003 || QueryNo == 107 || QueryNo == 400 || QueryNo == 450
                    || QueryNo == 118 || QueryNo == 119)
                {
                    ObjReportDocument.SetParameterValue("@QueryNo", QueryNo);
                    ObjReportDocument.SetParameterValue("@intProductID", intProductID);

                    ObjReportDocument.SetParameterValue("@intPartyNo", intPartyNo);
                    ObjReportDocument.SetParameterValue("@intCategoryID", intCategoryID);
                    ObjReportDocument.SetParameterValue("@intSubcategoryID", intSubcategoryID);
                    ObjReportDocument.SetParameterValue("@intCompanyID", ClsDefination.CompanyId);
                    if (QueryNo == 1003 || QueryNo == 1207)
                    {
                        ObjReportDocument.SetParameterValue("@intBatchNo", 0);

                    }
                    else
                    {
                        ObjReportDocument.SetParameterValue("@intBatchNo", StrBatchNo);
                        ObjReportDocument.SetParameterValue("@intFormType", 1);
                    }
                    ObjReportDocument.SetParameterValue("@intYearID", ClsDefination.YearId);
                    ObjReportDocument.SetParameterValue("@sdtFromDate", sdtFromDate);
                    ObjReportDocument.SetParameterValue("@sdtToDate", sdtToDate);
                    if (QueryNo == 1 || QueryNo == 1001 || QueryNo == 107 ||
                        QueryNo == 400 || QueryNo == 118 || QueryNo == 450 || QueryNo == 119)
                    {
                        ObjReportDocument.SetParameterValue("@intCustid", 0);
                        ObjReportDocument.SetParameterValue("@salesid", 0);
                    }
                    else if (QueryNo == 114 || QueryNo == 1207 || QueryNo == 1003 || QueryNo == 1002 || QueryNo == 107)
                    {
                        ObjReportDocument.SetParameterValue("@salesid", intSubcategoryID);
                        ObjReportDocument.SetParameterValue("@intCustid", 0);
                    }
                    ObjReportDocument.SetParameterValue("@intSupplierId", intPartyNo);



                }
                if (QueryNo == 1207)
                {
                    ObjReportDocument.SetParameterValue("@QueryNo", QueryNo);

                    ObjReportDocument.SetParameterValue("@intPartyNo", intPartyNo);
                    ObjReportDocument.SetParameterValue("@intCategoryID", intCategoryID);
                    ObjReportDocument.SetParameterValue("@intSubcategoryID", intSubcategoryID);
                    ObjReportDocument.SetParameterValue("@intCompanyID", ClsDefination.CompanyId);
                    ObjReportDocument.SetParameterValue("@salesid", intSubcategoryID);
                    ObjReportDocument.SetParameterValue("@intCustid", 0);
                    ObjReportDocument.SetParameterValue("@intBatchNo", StrBatchNo);
                    // ObjReportDocument.SetParameterValue("@intFormType", intNewFormType);
                    ObjReportDocument.SetParameterValue("@sdtFromDate", sdtFromDate);
                    ObjReportDocument.SetParameterValue("@sdtToDate", sdtToDate);
                    ObjReportDocument.SetParameterValue("@intProductID", intProductID);
                    ObjReportDocument.SetParameterValue("@intSupplierId", intPartyNo);
                    // ObjReportDocument.SetParameterValue("@intYearID", ClsDefination.YearId);


                }

                if (QueryNo == 2020)
                {
                    ObjReportDocument.SetParameterValue("@QueryNo", QueryNo);
                    ObjReportDocument.SetParameterValue("@intProductID", 0);

                    ObjReportDocument.SetParameterValue("@intCustomerID", 0);
                    ObjReportDocument.SetParameterValue("@intCustomerMobNo", "");
                    ObjReportDocument.SetParameterValue("@strBatchNo", "");
                    ObjReportDocument.SetParameterValue("@intCompanyID", intCompanyID);
                    ObjReportDocument.SetParameterValue("@strBarcode", "");
                    ObjReportDocument.SetParameterValue("@intYearID", intYearID);
                    //ObjReportDocument.SetParameterValue("@sdtFromDate", sdtFromDate);
                    //ObjReportDocument.SetParameterValue("@sdtToDate", sdtToDate);

                    ObjReportDocument.SetParameterValue("@intGodownId", 0);
                    ObjReportDocument.SetParameterValue("@intDCId", VoucherId);
                    ObjReportDocument.SetParameterValue("@intRute", 0);


                    ObjReportDocument.SetParameterValue("@strCustType", "");
                    ObjReportDocument.SetParameterValue("@strProductId", "");

                    ObjReportDocument.SetParameterValue("@strTransportName", "");
                    ObjReportDocument.SetParameterValue("@intVehicalNo", "");


                }
                else if (QueryNo == 103 || QueryNo == 255)
                {

                    // ObjReportDocument.SetParameterValue("@strQuotDetailID", strQuotDetailID);
                    ObjReportDocument.SetParameterValue("@QueryNo", QueryNo);
                    ObjReportDocument.SetParameterValue("@intProductID", intProductID);
                    ObjReportDocument.SetParameterValue("@intPartyNo", 0);

                    ObjReportDocument.SetParameterValue("@intCategoryID", 0);
                    ObjReportDocument.SetParameterValue("@intSubcategoryID", 0);

                    ObjReportDocument.SetParameterValue("@intSupplierId", intPartyNo);
                    ObjReportDocument.SetParameterValue("@intCustid", 0);
                    ObjReportDocument.SetParameterValue("@intBatchNo", 0);
                    ObjReportDocument.SetParameterValue("@intYearID", ClsDefination.YearId);
                    ObjReportDocument.SetParameterValue("@intCompanyId", ClsDefination.CompanyId);
                    ObjReportDocument.SetParameterValue("@intFormType", 0);
                    if (QueryNo == 255)
                    {
                        ObjReportDocument.SetParameterValue("@salesid", VoucherId);
                        ObjReportDocument.SetParameterValue("@sdtFromDate", "01/01/1900");
                        ObjReportDocument.SetParameterValue("@sdtToDate", "01/01/1900");

                    }
                    else
                    {
                        ObjReportDocument.SetParameterValue("@salesid", 0);
                        ObjReportDocument.SetParameterValue("@sdtFromDate", sdtFromDate);
                        ObjReportDocument.SetParameterValue("@sdtToDate", sdtToDate);

                    }


                }
                else if (QueryNo == 503)//BillReport.rpt 503  
                {
                    ObjReportDocument.SetParameterValue("@QueryNo", QueryNo);
                    ObjReportDocument.SetParameterValue("@strProductId", "");

                    ObjReportDocument.SetParameterValue("@intCustomerID", 0);
                    ObjReportDocument.SetParameterValue("@intCustomerMobNo", "");
                    ObjReportDocument.SetParameterValue("@strQuotDetailID", strQuotDetailID);
                    ObjReportDocument.SetParameterValue("@intCompanyID", ClsDefination.CompanyId);
                    ObjReportDocument.SetParameterValue("@intSalesID", 0);
                    ObjReportDocument.SetParameterValue("@intFormType", 0);
                    ObjReportDocument.SetParameterValue("@intYearID", ClsDefination.YearId);
                    ObjReportDocument.SetParameterValue("@intGodownId", 0);
                    ObjReportDocument.SetParameterValue("@strBatchNo", "");

                    ObjReportDocument.SetParameterValue("@strCustType", "");

                    ObjReportDocument.SetParameterValue("@intRute", 0);
                    ObjReportDocument.SetParameterValue("@sdtFromDate", sdtFromDate);
                    ObjReportDocument.SetParameterValue("@sdtToDate", sdtToDate);



                }
                else if (QueryNo == 117 || QueryNo == 1172)
                {

                    ObjReportDocument.SetParameterValue("@QueryNo", QueryNo);
                    //ObjReportDocument.SetParameterValue("@intID", 0);

                    ObjReportDocument.SetParameterValue("@intYearID", 0);
                    ObjReportDocument.SetParameterValue("@intCompanyID", 0);
                    ObjReportDocument.SetParameterValue("@intProductId", 0);
                    //ObjReportDocument.SetParameterValue("@intVoucherId", VoucherId);
                    //ObjReportDocument.SetParameterValue("@intgodownid", 0);
                    //ObjReportDocument.SetParameterValue("@intFromGodownID", 0);
                    ObjReportDocument.SetParameterValue("@intBatchNo", 0);
                    ObjReportDocument.SetParameterValue("@intCustid", 0);
                    ObjReportDocument.SetParameterValue("@salesid", 0);
                    ObjReportDocument.SetParameterValue("@intFormType", 0);

                }
                else
                    if (QueryNo == 104 || QueryNo == 204 || QueryNo == 106 || QueryNo == 420)
                    {
                        ObjReportDocument.SetParameterValue("@QueryNo", QueryNo);
                        ObjReportDocument.SetParameterValue("@intProductID", intProductID);

                        //ObjReportDocument.SetParameterValue("@intProcessNo", VoucherNo);
                        ObjReportDocument.SetParameterValue("@intPartyNo", intPartyNo);
                        //ObjReportDocument.SetParameterValue("@intComponentNo", 0);

                        //ObjReportDocument.SetParameterValue("@intProductID", 0);
                        ObjReportDocument.SetParameterValue("@intCategoryID", 0);
                        ObjReportDocument.SetParameterValue("@intSubcategoryID", 0);


                        ObjReportDocument.SetParameterValue("@intSupplierId", intSupplierId);
                        if (QueryNo == 106)
                        {
                            ObjReportDocument.SetParameterValue("@intCustid", 0);
                        }
                        else
                        {
                            ObjReportDocument.SetParameterValue("@intCustid", 0);
                        }

                        ObjReportDocument.SetParameterValue("@intYearID", 0);

                        ObjReportDocument.SetParameterValue("@salesid", 0);
                        ObjReportDocument.SetParameterValue("@intBatchNo", 0);
                        ObjReportDocument.SetParameterValue("@sdtFromDate", sdtFromDate);
                        ObjReportDocument.SetParameterValue("@sdtToDate", sdtToDate);
                        ObjReportDocument.SetParameterValue("@intCompanyID", intCompanyID);



                    }
                    //    else if(QueryNo==105)
                    //{
                    //    ObjReportDocument.SetParameterValue("@QueryNo", QueryNo);
                    //    ObjReportDocument.SetParameterValue("@salesid", VoucherId);
                    //   // ObjReportDocument.SetParameterValue("@salesid1", intNewFormType);
                    // //   ObjReportDocument.SetParameterValue("@salesid1", intNewFormType);
                    //}
                    else
                        if (QueryNo == 121 || QueryNo == 105)
                        {
                            ObjReportDocument.SetParameterValue("@QueryNo", QueryNo);
                            //ObjReportDocument.SetParameterValue("@intProcessNo", VoucherNo);
                            ObjReportDocument.SetParameterValue("@intPartyNo", 0);
                            //ObjReportDocument.SetParameterValue("@intComponentNo", 0);
                            ObjReportDocument.SetParameterValue("@sdtFromDate", "01/01/1900");
                            ObjReportDocument.SetParameterValue("@sdtToDate", "01/01/1900");

                            //ObjReportDocument.SetParameterValue("@intProductID", 0);
                            ObjReportDocument.SetParameterValue("@intCategoryID", 0);
                            ObjReportDocument.SetParameterValue("@intSubcategoryID", 0);
                            ObjReportDocument.SetParameterValue("@intCompanyID", 0);

                            ObjReportDocument.SetParameterValue("@intProductID", 0);

                            ObjReportDocument.SetParameterValue("@intSupplierId", 0);


                            ObjReportDocument.SetParameterValue("@intBatchNo", 0);
                            ObjReportDocument.SetParameterValue("@intYearID", 0);
                            // ObjReportDocument.SetParameterValue("@intAccontid", 0);
                            ObjReportDocument.SetParameterValue("@intCustid", 0);
                            if (QueryNo == 121)
                            {
                                ObjReportDocument.SetParameterValue("@salesid", 0);
                            }
                            else
                            {
                                ObjReportDocument.SetParameterValue("@salesid", VoucherId);
                                //ObjReportDocument.SetParameterValue("@intFormType", Convert.ToInt32(intFormType));
                                ////ObjReportDocument.SetParameterValue("@salesid", VoucherId);
                                // ObjReportDocument.SetParameterValue("@intFormType", intFormType);
                            }

                        }
                        else if (QueryNo == 7001 || QueryNo==7002)
                        {
                            ObjReportDocument.SetParameterValue("@QueryNo", QueryNo);
                            ObjReportDocument.SetParameterValue("@intFromParty", intPartyNo);
                            ObjReportDocument.SetParameterValue("@intCompanyId", intCompanyID);
                            ObjReportDocument.SetParameterValue("@dtpFromDate", sdtFromDate);
                            ObjReportDocument.SetParameterValue("@dtpToDate", sdtToDate);
                            ObjReportDocument.SetParameterValue("@intTo", intFirm);
                        }
                        else if (QueryNo == 5001 || QueryNo == 5002 || QueryNo == 5003 || QueryNo == 5004)
                        {
                            //ObjReportDocument.SetParameterValue("@QueryNo", QueryNo);
                            ObjReportDocument.SetParameterValue("@QueryNo", QueryNo);
                            //ObjReportDocument.SetParameterValue("@intFromParty", intPartyNo);
                            if (QueryNo != 5003)
                            {
                                ObjReportDocument.SetParameterValue("@intFromParty", intPartyNo);
                            }
                            ObjReportDocument.SetParameterValue("@intCompanyId", intCompanyID);

                            if (QueryNo == 5001 || QueryNo == 5003)
                            {
                                //ObjReportDocument.SetParameterValue("@intCode", intFirm);
                                ObjReportDocument.SetParameterValue("@intCode", intFirm);
                            }
                            //ObjReportDocument.SetParameterValue("@dtpFromDate", sdtFromDate);
                            ObjReportDocument.SetParameterValue("@dtpFromDate", sdtFromDate);
                            //ObjReportDocument.SetParameterValue("@dtpToDate", sdtToDate);
                            ObjReportDocument.SetParameterValue("@dtpToDate", sdtToDate);

                        }

                        else
                            if (QueryNo == 6002)
                            {
                                ObjReportDocument.SetParameterValue("@QueryNo", QueryNo);
                                // ObjReportDocument.SetParameterValue("@intProcessNo", VoucherNo);
                                ObjReportDocument.SetParameterValue("@intFromParty", intSupplierId);
                                ObjReportDocument.SetParameterValue("@intYarnCode", VoucherId);
                                ObjReportDocument.SetParameterValue("@dtpFromDate", sdtFromDate);
                                ObjReportDocument.SetParameterValue("@dtpToDate", sdtToDate);
                                ObjReportDocument.SetParameterValue("@intCompanyId", intCompanyID);
                                ObjReportDocument.SetParameterValue("@intYearId", intYearID);
                            }

                            else if (QueryNo == 6024 || QueryNo == 6026)
                            {
                                ObjReportDocument.SetParameterValue("@QueryNo", QueryNo);
                                ObjReportDocument.SetParameterValue("@sdtFromDate", sdtFromDate);
                                ObjReportDocument.SetParameterValue("@sdtToDate", sdtToDate);
                                ObjReportDocument.SetParameterValue("@intProductID", null);
                                //ObjReportDocument.SetParameterValue("@intGodownId", null);
                                ObjReportDocument.SetParameterValue("@intPartyNo", null);
                                ObjReportDocument.SetParameterValue("@intCategoryID", null);
                                ObjReportDocument.SetParameterValue("@intSubcategoryID", null);
                                ObjReportDocument.SetParameterValue("@intSupplierId", null);
                                ObjReportDocument.SetParameterValue("@intCustid", null);
                                ObjReportDocument.SetParameterValue("@intBatchNo", null);
                                ObjReportDocument.SetParameterValue("@salesid", null);
                                ObjReportDocument.SetParameterValue("@intFormType", null);
                                ObjReportDocument.SetParameterValue("@intProductID", null);

                                ObjReportDocument.SetParameterValue("@intCompanyId", null);


                                ObjReportDocument.SetParameterValue("@intYearId", null);



                            }
                            else if (QueryNo == 6011 || QueryNo == 6014 || QueryNo == 6025)
                            {
                                ObjReportDocument.SetParameterValue("@QueryNo", QueryNo);
                                ObjReportDocument.SetParameterValue("@salesid", VoucherId);
                                // sub.SetParameterValue("@QueryNo", 6012);
                                // sub.SetParameterValue("@salesid", VoucherId);
                                //// sub.SetParameterValue();
                                // sub.SetParameterValue("@intPartyNo", 0);

                                // //ObjReportDocument.SetParameterValue("@intComponentNo", 0);
                                // sub.SetParameterValue("@sdtFromDate", "01/01/1900");

                                // sub.SetParameterValue("@sdtToDate", "01/01/1900");

                                // //sub.SetParameterValue("@intProductID(subRpt)", 0);
                                // sub.SetParameterValue("@intCategoryID", 0);

                                // sub.SetParameterValue("@intSubcategoryID", 0);

                                // sub.SetParameterValue("@intCompanyID", 0);


                                // sub.SetParameterValue("@intProductID", 0);


                                // sub.SetParameterValue("@intSupplierId", 0);



                                // sub.SetParameterValue("@intBatchNo", 0);
                                // sub.SetParameterValue("@intYearID", 0);
                            }
                            //else

                                //if (QueryNo == 105)
                            //    {
                            //        ObjReportDocument.SetParameterValue("@salesid", VoucherId);
                            //        ObjReportDocument.SetParameterValue("@intFormType", intFormType);
                            //    }

                            else
                                if (QueryNo == 230)
                                {
                                    ObjReportDocument.SetParameterValue("@QueryNo", QueryNo);
                                    //ObjReportDocument.SetParameterValue("@intProcessNo", VoucherNo);
                                    ObjReportDocument.SetParameterValue("@intProductID", 0);
                                    ObjReportDocument.SetParameterValue("@intGodownId", 0);

                                    //ObjReportDocument.SetParameterValue("@intProductID", 0);
                                    ObjReportDocument.SetParameterValue("@intCustomerID", 0);
                                    ObjReportDocument.SetParameterValue("@intCustomerMobNo", 0);
                                    ObjReportDocument.SetParameterValue("@strBatchNo", 0);

                                    ObjReportDocument.SetParameterValue("@strCustomerType", 0);

                                    ObjReportDocument.SetParameterValue("@intRute", 0);

                                    ObjReportDocument.SetParameterValue("@intCompanyId", 0);


                                    ObjReportDocument.SetParameterValue("@intYearId", 0);

                                    ObjReportDocument.SetParameterValue("@intSalesReturnID", VoucherId);

                                }


                                else if (QueryNo == 200)//print of withdrow
                                {
                                    ObjReportDocument.SetParameterValue("@QueryNo", QueryNo);
                                    //ObjReportDocument.SetParameterValue("@strPartyReceiptNo ", 0);
                                    ObjReportDocument.SetParameterValue("@intPartyNo", 0);
                                    ObjReportDocument.SetParameterValue("@intReceiptNo", 0);

                                    ObjReportDocument.SetParameterValue("@intReceiptID", VoucherId);
                                    ObjReportDocument.SetParameterValue("@intReceiptType", 0);

                                    ObjReportDocument.SetParameterValue("@intCompanyId", ClsDefination.CompanyId);
                                    ObjReportDocument.SetParameterValue("@intYearID", ClsDefination.YearId);

                                }
                                else if (QueryNo == 101)//print of dposit
                                {
                                    ObjReportDocument.SetParameterValue("@QueryNo", QueryNo);
                                    //ObjReportDocument.SetParameterValue("@intProcessNo", VoucherNo);
                                    ObjReportDocument.SetParameterValue("@intPartyNo", 0);
                                    ObjReportDocument.SetParameterValue("@intReceiptNo", 0);

                                    ObjReportDocument.SetParameterValue("@intReceiptID", VoucherId);
                                    ObjReportDocument.SetParameterValue("@intReceiptType", 0);

                                    ObjReportDocument.SetParameterValue("@intCompanyId", ClsDefination.CompanyId);
                                    ObjReportDocument.SetParameterValue("@intYearID", intYearID);

                                }
                                else if (QueryNo == 1131 || QueryNo == 131 || QueryNo == 601 || QueryNo == 113)//JOUNERAL vOUCHER REGISTER
                                {
                                    ObjReportDocument.SetParameterValue("@QueryNo", QueryNo);
                                    ObjReportDocument.SetParameterValue("@intCategoryID", 0);
                                    ObjReportDocument.SetParameterValue("@intSubcategoryID", 0);
                                    ObjReportDocument.SetParameterValue("@intSupplierId", 0);
                                    ObjReportDocument.SetParameterValue("@intCustid", 0);
                                    ObjReportDocument.SetParameterValue("@intBatchNo", 0);

                                    ObjReportDocument.SetParameterValue("@intPartyNo", intPartyNo);
                                    if (QueryNo == 601)
                                    {
                                        ObjReportDocument.SetParameterValue("@salesid", intSubcategoryID);

                                    }
                                    else
                                    {
                                        ObjReportDocument.SetParameterValue("@salesid", 0);

                                    }
                                    ObjReportDocument.SetParameterValue("@intProductID", 0);

                                    ObjReportDocument.SetParameterValue("@intCompanyId", intCompanyID);
                                    ObjReportDocument.SetParameterValue("@intYearID", intYearID);
                                    ObjReportDocument.SetParameterValue("@sdtFromDate", sdtFromDate);
                                    ObjReportDocument.SetParameterValue("@sdtToDate", sdtToDate);

                                }
                                else if (QueryNo == 1120 || QueryNo == 1121)//Sales n Purchase Receipt print
                                {
                                    ObjReportDocument.SetParameterValue("@QueryNo", QueryNo);
                                    ObjReportDocument.SetParameterValue("@intPartyNo", 0);
                                    ObjReportDocument.SetParameterValue("@IntCompanyId", ClsDefination.CompanyId);
                                    ObjReportDocument.SetParameterValue("@intVoucherId", VoucherId);
                                    ObjReportDocument.SetParameterValue("@IntYearId", ClsDefination.YearId);


                                }
                                else if (QueryNo == 116)//ACCOUNT BAL TRANSFER print
                                {
                                    //ObjReportDocument.SetParameterValue("@QueryNo", QueryNo);
                                    //ObjReportDocument.SetParameterValue("@voucherNo", VoucherId);
                                    //ObjReportDocument.SetParameterValue("@inmsg", "0");
                                    //ObjReportDocument.SetParameterValue("@intAccountRecordNo", 0);
                                    //ObjReportDocument.SetParameterValue("@intCompanyId",ClsDefination.CompanyId );
                                    ObjReportDocument.SetParameterValue("@QueryNo", QueryNo);
                                    ObjReportDocument.SetParameterValue("@intProductID", 0);

                                    ObjReportDocument.SetParameterValue("@intPartyNo", 0);
                                    ObjReportDocument.SetParameterValue("@intCategoryID", 0);
                                    ObjReportDocument.SetParameterValue("@intSubcategoryID", 0);
                                    ObjReportDocument.SetParameterValue("@intCompanyID", ClsDefination.CompanyId);
                                    if (QueryNo == 1003)
                                    {
                                        ObjReportDocument.SetParameterValue("@intBatchNo", 0);
                                    }
                                    else
                                    {
                                        ObjReportDocument.SetParameterValue("@intBatchNo", 0);
                                    }
                                    ObjReportDocument.SetParameterValue("@intYearID", ClsDefination.YearId);
                                    ObjReportDocument.SetParameterValue("@sdtFromDate", sdtFromDate);
                                    ObjReportDocument.SetParameterValue("@sdtToDate", sdtToDate);

                                    ObjReportDocument.SetParameterValue("@intCustid", 0);
                                    ObjReportDocument.SetParameterValue("@salesid", 0);
                                    ObjReportDocument.SetParameterValue("@intSupplierId", 0);

                                }
                                else if (QueryNo == 111)//journal voucher print
                                {
                                    ObjReportDocument.SetParameterValue("@QueryNo", QueryNo);
                                    ObjReportDocument.SetParameterValue("@intVoucherID", VoucherId);
                                    ObjReportDocument.SetParameterValue("@strVoucherNo", 0);
                                    ObjReportDocument.SetParameterValue("@strVoucherRef", 0);

                                    ObjReportDocument.SetParameterValue("@sdtVoucherDate", "01/01/1900");
                                    ObjReportDocument.SetParameterValue("@strVoucherDescription", 0);
                                    ObjReportDocument.SetParameterValue("@decVoucherAmount", 0);
                                    ObjReportDocument.SetParameterValue("@intPersonID", 0);
                                    ObjReportDocument.SetParameterValue("@sdtFromVoucherDate", "01/01/1900");
                                    ObjReportDocument.SetParameterValue("@sdtTOVoucherDate", "01/01/1900");

                                    ObjReportDocument.SetParameterValue("@intAccountID", 0);
                                    ObjReportDocument.SetParameterValue("@intAccountType", 0);
                                    ObjReportDocument.SetParameterValue("@strAccountType", 0);
                                    ObjReportDocument.SetParameterValue("@intUserId", 0);
                                    ObjReportDocument.SetParameterValue("@isPaid", 0);

                                    ObjReportDocument.SetParameterValue("@strPaymentMode", 0);
                                    ObjReportDocument.SetParameterValue("@strChequeNo", 0);
                                    ObjReportDocument.SetParameterValue("@sdtChequeDate", "01/01/1900");
                                    ObjReportDocument.SetParameterValue("@strAmendNote", 0);
                                    ObjReportDocument.SetParameterValue("@intCompanyId", ClsDefination.CompanyId);
                                    ObjReportDocument.SetParameterValue("@intYearId", ClsDefination.YearId);

                                    ObjReportDocument.SetParameterValue("@intPersonID", 0);
                                }
                                else if (QueryNo == 410 || QueryNo == 110)//JOUNERAL vOUCHER REGISTER
                                {
                                    ObjReportDocument.SetParameterValue("@QueryNo", QueryNo);
                                    ObjReportDocument.SetParameterValue("@intCategoryID", intCategoryID);
                                    ObjReportDocument.SetParameterValue("@intSubcategoryID", intSubcategoryID);
                                    ObjReportDocument.SetParameterValue("@intSupplierId", 0);
                                    ObjReportDocument.SetParameterValue("@intCustid", intPartyNo);

                                    if (QueryNo == 110)
                                    {
                                        ObjReportDocument.SetParameterValue("@intBatchNo", intSubcategoryID);
                                        ObjReportDocument.SetParameterValue("@salesid", 0);
                                    }
                                    else
                                    {
                                        ObjReportDocument.SetParameterValue("@intBatchNo", 0);
                                        ObjReportDocument.SetParameterValue("@salesid", intGodownid);//GODOWN ID 
                                    }
                                    ObjReportDocument.SetParameterValue("@intPartyNo", intPartyNo);


                                    ObjReportDocument.SetParameterValue("@intProductID", intProductID);
                                    ObjReportDocument.SetParameterValue("@intCompanyId", intCompanyID);
                                    ObjReportDocument.SetParameterValue("@intYearID", intYearID);
                                    ObjReportDocument.SetParameterValue("@sdtFromDate", "01/01/1900");
                                    ObjReportDocument.SetParameterValue("@sdtToDate", "01/01/1900");

                                }

                                else if (QueryNo == 1208 || QueryNo == 2122 || QueryNo == 2123 || QueryNo == 2124
                                    || QueryNo == 1115 || QueryNo == 109 || QueryNo == 300)
                                {
                                    ObjReportDocument.SetParameterValue("@QueryNo", QueryNo);
                                    //ObjReportDocument.SetParameterValue("@intProcessNo", VoucherNo);
                                    ObjReportDocument.SetParameterValue("@intPartyNo", intPartyNo);
                                    //ObjReportDocument.SetParameterValue("@intComponentNo", 0);



                                    ObjReportDocument.SetParameterValue("@sdtFromDate", sdtFromDate);
                                    ObjReportDocument.SetParameterValue("@sdtToDate", sdtToDate);
                                    ObjReportDocument.SetParameterValue("@intCustid", intPartyNo);
                                    ObjReportDocument.SetParameterValue("@intCompanyID", intCompanyID);
                                    ObjReportDocument.SetParameterValue("@intYearID", intYearID);

                                    ObjReportDocument.SetParameterValue("@intProductID", 0);

                                    //ObjReportDocument.SetParameterValue("@intProductID", 0);
                                    ObjReportDocument.SetParameterValue("@intCategoryID", 0);
                                    ObjReportDocument.SetParameterValue("@intSubcategoryID", 0);

                                    ObjReportDocument.SetParameterValue("@intSupplierId", intPartyNo);
                                    ObjReportDocument.SetParameterValue("@intBatchNo", 0);

                                    // ObjReportDocument.SetParameterValue("@intAccontid", 0);




                                    if (QueryNo == 105)
                                    {
                                        ObjReportDocument.SetParameterValue("@salesid", VoucherId);
                                        ObjReportDocument.SetParameterValue("@intFormType", intNewFormType);
                                    }
                                    else if (QueryNo == 2123)
                                    {
                                        ObjReportDocument.SetParameterValue("@salesid", intSubcategoryID);

                                    }
                                    else
                                    {
                                        ObjReportDocument.SetParameterValue("@salesid", 0);
                                    }






                                }




                Tables crTables;

                using (ClsDefination objMaster = new ClsDefination())
                {
                    //objMaster.ReportConnectionServer();

                    ClsDefination.Readpath();
                    //// crConnectionInfo.ServerName =objMaster.ServerNM ;
                    //crConnectionInfo.ServerName = "ADMIN-PC";
                    ////crConnectionInfo.DatabaseName = objMaster.DatabaseNM;
                    //crConnectionInfo.DatabaseName = "Medical";
                    //// crConnectionInfo.UserID = objMaster.UserNM;
                    ////crConnectionInfo.UserID = "admin-PC/admin";
                    //// crConnectionInfo.Password = objMaster.PasswordStr;
                    ////crConnectionInfo.Password = "";
                    //crConnectionInfo.IntegratedSecurity = true;

                    crConnectionInfo.ServerName = ClsDefination.server;// server;
                    crConnectionInfo.DatabaseName = ClsDefination.database;// dbname;
                    username = ClsDefination.id;
                    if (username == "sa")
                    {
                        crConnectionInfo.IntegratedSecurity = false;
                        crConnectionInfo.UserID = ClsDefination.id;// username;
                        crConnectionInfo.Password = ClsDefination.password;// password;
                    }
                    else
                    {
                        crConnectionInfo.IntegratedSecurity = true;
                    }


                }

                try
                {

                    crTables = ObjReportDocument.Database.Tables;
                    //crTables1 = sub.Database.Tables;
                    foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in crTables)
                    {

                        crTableLogOnInfo = CrTable.LogOnInfo;

                        crTableLogOnInfo.ConnectionInfo = crConnectionInfo;

                        CrTable.ApplyLogOnInfo(crTableLogOnInfo);

                    }


                    CRVReport1.ReportSource = ObjReportDocument;



                    CRVReport1.Refresh();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Print not available");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("");
            }
        }

        private void CRVReport1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PanelTitle_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
