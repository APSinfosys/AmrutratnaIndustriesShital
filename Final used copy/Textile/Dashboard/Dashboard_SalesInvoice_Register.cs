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
    public partial class Dashboard_SalesInvoice_Register : Form
    {
        public Dashboard_SalesInvoice_Register()
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
        public int newOrEdit = 0, totalRecords = 0;
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

                if (QueryNo == 1001 || QueryNo == 1002)
                {
                    if (cmbParty.SelectedIndex >= 0)
                    {
                        hash.Add("@intFromParty", cmbParty.SelectedValue);
                    }
                    if (txtDcNo.Text != "")
                    {
                        hash.Add("@intCode", txtDcNo.Text);
                    }
                    //*
                    hash.Add("@intPageNo", txtCurrentPg.Text);
                    hash.Add("@intNoOfRec", txtPerPgRec.Text);
                }

                dtReturn = ClsDefination.FillData("[Transaction_SalesInvoice_DML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 1001)
                    {
                        dgvSut.DataSource = dtReturn;
                        bsOriginal.DataSource = dtReturn;


                        for (int i = 13; i < 45; i++)
                        {
                            dgvSut.Columns[i].Visible = false;
                        }

                    }
                    else if (QueryNo == 1002)
                    {
                        totalRecords = Convert.ToInt32(objRow["count"].ToString());
                    }
                    else if (QueryNo == 205)
                    {
                        cmbParty.DataSource = dtReturn;
                        cmbParty.DisplayMember = "F_CompanyName";
                        cmbParty.ValueMember = "F_Code";
                        cmbParty.SelectedIndex = -1;
                        cmbParty.Text = "<-- SELECT FIRM -->";
                    }

                }
                else
                {
                    if (QueryNo == 1001)
                    {
                        dgvSut.DataSource = null;
                        for (int i = 13; i < 45; i++)
                        {
                            dgvSut.Columns[i].Visible = false;
                        }
                    }
                    else if (QueryNo == 1002)
                    {
                        totalRecords = 0;
                    }
                    else if (QueryNo == 205)
                    {
                        cmbParty.DataSource = dtReturn;
                        cmbParty.SelectedIndex = -1;
                        cmbParty.Text = "<-- NO FIRM AVAILABLE -->";
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


        private void Dashboard_SalesInvoice_Register_Load(object sender, EventArgs e)
        {
            cmbPerPageRec.Text = txtPerPgRec.Text;
            FillGrid(1001);
            FillGrid(1002);
            FillGrid(205);
            btnEnableDisable();
        }

        public void btnEnableDisable()
        {
            if ((totalRecords / Convert.ToInt32(txtPerPgRec.Text)) > 1)
            {
                btnNext.Enabled = true;
            }
            else
            {
                btnNext.Enabled = false;
            }
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            try
            {
                dgvSut.DataSource = bsOriginal;
                bs.DataSource = dgvSut.DataSource;
                bs.Filter = string.Format("[PARTY NAME] like '%{0}%'", txtSearch.Text);
                dgvSut.DataSource = bs;
                dgvSut.Enabled = true;
                // btnClose.Enabled = true;
            }
            catch
            { }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            if (dgvSut.SelectedRows.Count > 0)
            {
                TransactionReport.CRTransaction frm = new TransactionReport.CRTransaction();

                ClsDefination.Readpath();

                frm.QueryNo = 1008;
                frm.server = ClsDefination.server;
                frm.dbname = ClsDefination.database;
                frm.username = ClsDefination.id;
                frm.password = ClsDefination.password;
                frm.reportPath = ClsDefination.CrystalPath;

                frm.intCompanyID = fd.CompId;

                frm.intYearID = fd.YearId;
                frm.VoucherId = Convert.ToInt32(dgvSut.CurrentRow.Cells[13].Value.ToString());
                //frm.intSupplierId = Convert.ToInt32(dgvSut.CurrentRow.Cells[39].Value.ToString());
                frm.ShowDialog();
            }
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please select record to print";
                frm.type = "error";
                frm.ShowDialog();
            }
        }

        private void btnEditSales_Click(object sender, EventArgs e)
        {
            if (dgvSut.SelectedRows.Count > 0)
            {

                TransactionForms.Transaction_SalesInvoice_Mannulay frm = new TransactionForms.Transaction_SalesInvoice_Mannulay();
                frm.newOrEdit = 1;


                //                             select 
                // '# '+SI.UniqueCode as [UNIQUE CODE], SI.SI_Code as [INVOICE NO], CONVERT(varchar(12), SI.SI_Date,103) as [INVOICE DATE], 2
                frm.lblUniqueCode.Text = dgvSut.CurrentRow.Cells[0].Value.ToString().Remove(0, 2);
                frm.txtInvoiceNo.Text = dgvSut.CurrentRow.Cells[1].Value.ToString();
                frm.lblDtpDate.Text = dgvSut.CurrentRow.Cells[2].Value.ToString();
                frm.dtpInvoicedate.Text = dgvSut.CurrentRow.Cells[2].Value.ToString();

                //FM.F_CompanyName as [FIRM NAME], MP.P_CompanyName as [PARTY NAME],  4
                frm.lblfromPartyName.Text = frm.cmbFromParty.Text = dgvSut.CurrentRow.Cells[3].Value.ToString();
                frm.lblToPartyName.Text = frm.cmbToParty.Text = dgvSut.CurrentRow.Cells[4].Value.ToString();

                //SI.ContractName as [CONTRACT],QR.QualityName as [QUALITY], 6
                frm.cmbContract.Text = dgvSut.CurrentRow.Cells[5].Value.ToString();
                frm.lblQualityName.Text = dgvSut.CurrentRow.Cells[6].Value.ToString();

                // SI.NoOfPiece as [PIECES], 7
                frm.lblPiecevalue.Text = dgvSut.CurrentRow.Cells[7].Value.ToString();

                // SI.Mtrs as [TOTAL MTRS],SI.rate as [RATE],SI.taxableAmt as [TAXABLE AMOUNT], SI.totalGst as [TOTAL GST], 11
                frm.lblTotalGridMtr.Text = dgvSut.CurrentRow.Cells[8].Value.ToString();
                frm.txtRate.Text = dgvSut.CurrentRow.Cells[9].Value.ToString();
                frm.lblTaxableValue.Text = dgvSut.CurrentRow.Cells[10].Value.ToString();
                frm.lblGSTAmt.Text = dgvSut.CurrentRow.Cells[11].Value.ToString();

                // SI.grandTotal as [INVOICE AMOUNT], 12
                frm.lblGrandTotalAmt.Text = dgvSut.CurrentRow.Cells[12].Value.ToString();

                // SI.SI_Id,  SI.PartyCode, SI.stateCode, 15  
                frm.lblSrNo.Text = dgvSut.CurrentRow.Cells[13].Value.ToString();
                frm.lblToPartyCode.Text = dgvSut.CurrentRow.Cells[14].Value.ToString();
                frm.cmbToPartyV = Convert.ToInt32(dgvSut.CurrentRow.Cells[14].Value.ToString());
                frm.lblStateCode.Text = dgvSut.CurrentRow.Cells[15].Value.ToString();

                // SI.loomNo, SI.hsnCode,      17
                frm.txtLoomNo.Text = dgvSut.CurrentRow.Cells[16].Value.ToString();
                frm.txtHSNNo.Text = dgvSut.CurrentRow.Cells[17].Value.ToString();

                //   SI.totalAmt,  SI.cgstPer, SI.cgstAmt, 20 
                frm.lbltotalAmt.Text = dgvSut.CurrentRow.Cells[18].Value.ToString();
                frm.txtCGSTPer.Text = dgvSut.CurrentRow.Cells[19].Value.ToString();
                frm.txtCGSTAmt.Text = dgvSut.CurrentRow.Cells[20].Value.ToString();


                // SI.sgstPer, SI.sgstAmt, SI.igstPer, SI.igstAmt,  SI.roff, 25 
                frm.txtSGSTPer.Text = dgvSut.CurrentRow.Cells[21].Value.ToString();
                frm.txtSGSTAmt.Text = dgvSut.CurrentRow.Cells[22].Value.ToString();
                frm.txtGSTPer.Text = dgvSut.CurrentRow.Cells[23].Value.ToString();
                frm.txtGSTAmt.Text = dgvSut.CurrentRow.Cells[24].Value.ToString();
                frm.txtROFF.Text = dgvSut.CurrentRow.Cells[25].Value.ToString();

                //  SI.packing, SI.checking, SI.other, SI.totalAdd, SI.secand,  30
                frm.txtPacking.Text = dgvSut.CurrentRow.Cells[26].Value.ToString();
                frm.txtChecking.Text = dgvSut.CurrentRow.Cells[27].Value.ToString();
                frm.txtAddOther.Text = dgvSut.CurrentRow.Cells[28].Value.ToString();
                frm.lblTotalAdd.Text = dgvSut.CurrentRow.Cells[29].Value.ToString();
                frm.txtSecond.Text = dgvSut.CurrentRow.Cells[30].Value.ToString();


                // SI.tp, SI.sl, SI.fold, SI.otherLess, SI.totalLess, SI.fromParty,SI.brokerCode, 37 
                frm.txtTP.Text = dgvSut.CurrentRow.Cells[31].Value.ToString();
                frm.txtSL.Text = dgvSut.CurrentRow.Cells[32].Value.ToString();
                frm.txtFold.Text = dgvSut.CurrentRow.Cells[33].Value.ToString();
                frm.txtOtherLess.Text = dgvSut.CurrentRow.Cells[34].Value.ToString();
                frm.lblTotalLess.Text = dgvSut.CurrentRow.Cells[35].Value.ToString();
                frm.lblFromPartyCode.Text = dgvSut.CurrentRow.Cells[36].Value.ToString();
                frm.cmbFromPartyV = Convert.ToInt32(dgvSut.CurrentRow.Cells[36].Value.ToString());
                frm.lblBrokerCode.Text = dgvSut.CurrentRow.Cells[37].Value.ToString();


                //  SI.Place, SI.Shade,SI.contractCode, 40
                frm.txtPlace.Text = dgvSut.CurrentRow.Cells[38].Value.ToString();
                frm.lblShade.Text = dgvSut.CurrentRow.Cells[39].Value.ToString();
                if (dgvSut.CurrentRow.Cells[40].Value.ToString() != "")
                {
                    frm.cmbContractV = Convert.ToInt32(dgvSut.CurrentRow.Cells[40].Value.ToString());
                }

                // SI.vatavPer,SI.vatavAmt, 42
                frm.txtVatavPer.Text = dgvSut.CurrentRow.Cells[41].Value.ToString();
                frm.txtVatavAmt.Text = dgvSut.CurrentRow.Cells[42].Value.ToString();


                // SI.paymentDays,SI.chkCalculation 44
                frm.txtPaymentDays.Text = dgvSut.CurrentRow.Cells[43].Value.ToString();
                if (Convert.ToInt32(dgvSut.CurrentRow.Cells[44].Value) == 1)
                {
                    frm.chkBoxCalculation.Checked = true;
                }
                else
                {
                    frm.chkBoxCalculation.Checked = false;
                }

                frm.ShowDialog();
                FillGrid(1001);
            }
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please select record to edit";
                frm.type = "error";
                frm.ShowDialog();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FillGrid(1001);
            FillGrid(1002);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbParty.SelectedIndex = -1;
            cmbParty.Text = "<-- SELECT PARTY -->";
            txtDcNo.Text = "";
            txtCurrentPg.Text = "1";
            txtPerPgRec.Text = "50";
            FillGrid(1001);
        }

        private void btnPrv_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtCurrentPg.Text) > 1)
            {
                txtCurrentPg.Text = (Convert.ToInt32(txtCurrentPg.Text) - 1).ToString();
                FillGrid(1001);
                btnNext.Enabled = true;
            }
            else
            {
                btnPrv.Enabled = false;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtCurrentPg.Text) < (totalRecords / Convert.ToInt32(txtPerPgRec.Text)))
            {
                txtCurrentPg.Text = (Convert.ToInt32(txtCurrentPg.Text) + 1).ToString();
                FillGrid(1001);
                btnPrv.Enabled = true;
            }
            else
            {
                btnNext.Enabled = false;
            }
        }

        private void cmbPerPageRec_Leave(object sender, EventArgs e)
        {
            if (cmbPerPageRec.Text == "")
            {
                cmbPerPageRec.Text = txtPerPgRec.Text;

            }
            FillGrid(1001);
            FillGrid(1002);
            btnEnableDisable();
        }

        private void cmbPerPageRec_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPerPgRec.Text = cmbPerPageRec.Text;
        }
    }
}
