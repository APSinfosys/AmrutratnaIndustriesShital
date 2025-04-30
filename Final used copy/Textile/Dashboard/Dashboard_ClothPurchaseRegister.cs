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
    public partial class Dashboard_ClothPurchaseRegister : Form
    {
        public Dashboard_ClothPurchaseRegister()
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
                hash.Add("@intCompanyId", fd.CompId);
                hash.Add("@intYearId", fd.YearId);

                dtReturn = ClsDefination.FillData("[Transaction_PurchaseInvoiceDml]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 5001)
                    {
                        dgvSut.DataSource = dtReturn;
                        bsOriginal.DataSource = dtReturn;
                  
       //select FM.[F_CompanyName] as [FIRM], CPI.PI_Code as [INVOICE NO],CPI.PI_Date as [INVOICE DATE],MP.P_CompanyName as [PARTY NAME],     3
       //        CPI.DC_Code as [DC NO],                                                                                                      4
       //        QR.Q_Name as [QUALITY],CPI.NoOfPiece as [PIECES], CPI.Mtrs as [MTR], CPI.rate as [RATE],CPI.taxableAmt as [TAXABLE AMOUNT],   9
       //       CPI.totalGst as [GST], CPI.roff as [R/OFF], CPI.grandTotal as [INVOCIE AMOUNT],                                               12
       //        CPI.OnFirmCode,  CPI.stateCode, CPI.loomNo, CPI.hsnCode, CPI.brocker, CPI.DC_Date,                                           18
       //       CPI.Quality,  CPI.totalAmt,  CPI.cgstPer, CPI.cgstAmt, CPI.sgstPer,                                                            23
       //       CPI.sgstAmt, CPI.igstPer, CPI.igstAmt,  CPI.packing,                                                                             27
       //       CPI.checking, CPI.other, CPI.totalAdd, CPI.secand, CPI.tp, CPI.sl, CPI.fold, CPI.otherLess, CPI.totalLess, CPI.fromParty,   37
       //       CPI.brokerCode, CPI.sampleCuts, CPI.Place, CPI.Shade, CPI.UniqueCode, CPI.contractCode, CPI.ContractName                      44

                        //dgvSut.Columns[42].DisplayIndex = 0;


                        for (int i = 13; i < 46; i++)
                        {
                            dgvSut.Columns[i].Visible = false;
                        }
                        dgvSut.Columns[42].Visible = true;
                    }

                }
                else
                {
                    if (QueryNo == 5001)
                    {
                        dgvSut.DataSource = null;
                        for (int i = 13; i < 45; i++)
                        {
                            dgvSut.Columns[i].Visible = false;
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


        private void Dashboard_ClothPurchaseRegister_Load(object sender, EventArgs e)
        {
            FillGrid(5001);
        }

        private void btnEditSales_Click(object sender, EventArgs e)
        {
            if (dgvSut.SelectedRows.Count > 0)
            {

                TransactionForms.Cloth_PurchaseInvoice frm = new TransactionForms.Cloth_PurchaseInvoice();
                frm.newOrEdit = 1;

                // FM.[F_CompanyName] as [FIRM], CPI.PI_Code as [INVOICE NO],CPI.PI_Date as [INVOICE DATE],MP.P_CompanyName as [PARTY NAME],

                frm.lblOnFirmName.Text = dgvSut.CurrentRow.Cells[0].Value.ToString();
                frm.txtInvoiceNo.Text = dgvSut.CurrentRow.Cells[1].Value.ToString();
                frm.dtpInvoicedate.Text = dgvSut.CurrentRow.Cells[2].Value.ToString();
                frm.lblFromPartyName.Text = dgvSut.CurrentRow.Cells[3].Value.ToString();
                // CPI.DC_Code as [DC NO], 
                frm.txtDCNOValue.Text = dgvSut.CurrentRow.Cells[4].Value.ToString();
                // QR.Q_Name as [QUALITY],CPI.NoOfPiece as [PIECES], CPI.Mtrs as [MTR], CPI.rate as [RATE],CPI.taxableAmt as [TAXABLE AMOUNT], 
                frm.lblQualityName.Text = dgvSut.CurrentRow.Cells[5].Value.ToString();
                frm.txtPiecevalue.Text = dgvSut.CurrentRow.Cells[6].Value.ToString();
                frm.txtTotalMtrs.Text = dgvSut.CurrentRow.Cells[7].Value.ToString();
                frm.txtRate.Text = dgvSut.CurrentRow.Cells[8].Value.ToString();
                frm.lblTaxableValue.Text = dgvSut.CurrentRow.Cells[9].Value.ToString();

                //CPI.totalGst as [GST], CPI.roff as [R/OFF], CPI.grandTotal as [INVOCIE AMOUNT],
                frm.lblGSTAmt.Text = dgvSut.CurrentRow.Cells[10].Value.ToString();
                frm.txtROFF.Text = dgvSut.CurrentRow.Cells[11].Value.ToString();
                frm.lblGrandTotalAmt.Text = dgvSut.CurrentRow.Cells[12].Value.ToString();

                // CPI.OnFirmCode,  CPI.stateCode, CPI.loomNo, CPI.hsnCode, CPI.brocker, CPI.DC_Date, 

                frm.lblOnFirmCode.Text = dgvSut.CurrentRow.Cells[13].Value.ToString();
                frm.lblStateCode.Text = dgvSut.CurrentRow.Cells[14].Value.ToString();
                frm.txtLoomNo.Text = dgvSut.CurrentRow.Cells[15].Value.ToString();
                frm.txtHSNNo.Text = dgvSut.CurrentRow.Cells[16].Value.ToString();
                frm.lblBrokerName.Text = dgvSut.CurrentRow.Cells[17].Value.ToString();
                frm.dtpDcDate.Text = dgvSut.CurrentRow.Cells[18].Value.ToString();

                //CPI.Quality,  CPI.totalAmt,  CPI.cgstPer, CPI.cgstAmt, CPI.sgstPer, 
                frm.lblQualityCode.Text = dgvSut.CurrentRow.Cells[19].Value.ToString();
                frm.lbltotalAmt.Text = dgvSut.CurrentRow.Cells[20].Value.ToString();
                frm.txtCGSTPer.Text = dgvSut.CurrentRow.Cells[21].Value.ToString();
                frm.txtCGSTAmt.Text = dgvSut.CurrentRow.Cells[22].Value.ToString();
                frm.txtSGSTPer.Text = dgvSut.CurrentRow.Cells[23].Value.ToString();

                //CPI.sgstAmt, CPI.igstPer, CPI.igstAmt,  CPI.packing,
                frm.txtSGSTAmt.Text = dgvSut.CurrentRow.Cells[24].Value.ToString();
                frm.txtGSTPer.Text = dgvSut.CurrentRow.Cells[25].Value.ToString();
                frm.txtGSTAmt.Text = dgvSut.CurrentRow.Cells[26].Value.ToString();
                frm.txtPacking.Text = dgvSut.CurrentRow.Cells[27].Value.ToString();

                //CPI.checking, CPI.other, CPI.totalAdd, CPI.secand, CPI.tp, CPI.sl, CPI.fold, CPI.otherLess, CPI.totalLess, CPI.fromParty, 
                frm.txtChecking.Text = dgvSut.CurrentRow.Cells[28].Value.ToString();
                frm.txtAddOther.Text = dgvSut.CurrentRow.Cells[29].Value.ToString();
                frm.lblTotalAdd.Text = dgvSut.CurrentRow.Cells[30].Value.ToString();
                frm.txtSecond.Text = dgvSut.CurrentRow.Cells[31].Value.ToString();
                frm.txtTP.Text = dgvSut.CurrentRow.Cells[32].Value.ToString();
                frm.txtSL.Text = dgvSut.CurrentRow.Cells[33].Value.ToString();
                frm.txtFold.Text = dgvSut.CurrentRow.Cells[34].Value.ToString();
                frm.txtOtherLess.Text = dgvSut.CurrentRow.Cells[35].Value.ToString();
                frm.lblTotalLess.Text = dgvSut.CurrentRow.Cells[36].Value.ToString();
                frm.lblFromPartyCode.Text = dgvSut.CurrentRow.Cells[37].Value.ToString();

                //CPI.brokerCode, CPI.sampleCuts, CPI.Place, CPI.Shade, CPI.UniqueCode, CPI.contractCode, CPI.ContractName

                frm.lblBrokerCode.Text = dgvSut.CurrentRow.Cells[38].Value.ToString();
                frm.txtSampleCutMtr.Text = dgvSut.CurrentRow.Cells[39].Value.ToString();
                frm.lblShadeCode.Text = dgvSut.CurrentRow.Cells[41].Value.ToString();
                frm.lblUniqueCode.Text = dgvSut.CurrentRow.Cells[42].Value.ToString();
                frm.lblContractCode.Text = dgvSut.CurrentRow.Cells[43].Value.ToString();
                frm.lblContractName.Text = dgvSut.CurrentRow.Cells[44].Value.ToString();

                frm.lblSrNo.Text = dgvSut.CurrentRow.Cells[45].Value.ToString();

                frm.ShowDialog();
                FillGrid(5001);
            }
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please select record to edit";
                frm.type = "error";
                frm.ShowDialog();
            }
        }
    }
}
