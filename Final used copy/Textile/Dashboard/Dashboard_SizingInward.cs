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
    public partial class Dashboard_SizingInward : Form
    {
        public Dashboard_SizingInward()
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
        //  public int groupId;
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
                hash.Add("@intFormType", 0);

                dtReturn = ClsDefination.FillData("[Transaction_SizingInwardDML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 101)
                    {
                        dgvDesign.DataSource = dtReturn;
                        bsOriginal.DataSource = dtReturn;

                        for (int i = 15; i < 45; i++)
                        {
                            dgvDesign.Columns[i].Visible = false;
                        }

                    }

                }
                else
                {
                    if (QueryNo == 101)
                    {
                        dgvDesign.DataSource = dtReturn;
                        for (int i = 15; i < 45; i++)
                        {
                            dgvDesign.Columns[i].Visible = false;
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


        private void btnNew_Click(object sender, EventArgs e)
        {
            Sizing.SizingInward frm = new Sizing.SizingInward();
            frm.newOrEdit = 0;
            frm.ShowDialog();
            FillGrid(101);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            try
            {
                if (dgvDesign.SelectedRows.Count > 0)
                {
                    Sizing.SizingInward frm = new Sizing.SizingInward();
                    frm.newOrEdit = 1;

                    frm.lblUniqueCode.Text = dgvDesign.CurrentRow.Cells[0].Value.ToString();
                    frm.txtInvoiceNo.Text = dgvDesign.CurrentRow.Cells[1].Value.ToString();
                    frm.dtpInvoiceDate.Text = dgvDesign.CurrentRow.Cells[2].Value.ToString();
                    //TSI.UniqueCode as [UNIQUE CODE],TSI.SI_INvoiceNo as [INVICE NO], TSI.SI_Date as [DATE],                          2

                    frm.cmbPartyName.Text = dgvDesign.CurrentRow.Cells[3].Value.ToString();
                    frm.cmbContract.Text = dgvDesign.CurrentRow.Cells[4].Value.ToString();
                    frm.cmbFirm.Text = dgvDesign.CurrentRow.Cells[5].Value.ToString();
                    //          MP.P_CompanyName as [NAME],TSI.contractValue as [CONTRACT VALUE],FM.F_CompanyName as [FIRM NAME],       5

                    frm.cmbCount.Text=frm.txtCount.Text = dgvDesign.CurrentRow.Cells[6].Value.ToString();
                    frm.cmbMill.Text= frm.txtMill.Text = dgvDesign.CurrentRow.Cells[7].Value.ToString();
                    frm.cmbQuality.Text = dgvDesign.CurrentRow.Cells[8].Value.ToString();
                    //          TSI.SI_COUNT as [MILL COUNT], TSI.SI_Mill as [MILL],CD.Q_Name as [QUALITY],                                8

                    frm.lblTaxableAmt.Text = dgvDesign.CurrentRow.Cells[9].Value.ToString();
                    frm.lblCGSTAmt.Text = dgvDesign.CurrentRow.Cells[10].Value.ToString();
                    frm.lblSGSTAmt.Text = dgvDesign.CurrentRow.Cells[11].Value.ToString();
                    //          TSI.SI_TaxableAmt as [TAXABLE AMT],TSI.SI_CGSTAmt as [CGST AMT],TSI.SI_SGSTAmt as [SGST AMT],         11

                    frm.lblIGSTAmt.Text = dgvDesign.CurrentRow.Cells[12].Value.ToString();
                    frm.txtRoff.Text = dgvDesign.CurrentRow.Cells[13].Value.ToString();
                    frm.lblGrandTotalAmt.Text = dgvDesign.CurrentRow.Cells[14].Value.ToString();
                    //          TSI.SI_IGSTAmt as [IGST AMT],TSI.SI_ROFF as [R / OFF], TSI.SI_GrandTotal as [GRAND TOTAL],    14

                    frm.lblSrNo.Text = dgvDesign.CurrentRow.Cells[15].Value.ToString();
                    //          TSI.SI_Code as [CODE],                                                                                  15

                    frm.txtEndsPerSection.Text = dgvDesign.CurrentRow.Cells[16].Value.ToString();
                    frm.txtPart.Text = dgvDesign.CurrentRow.Cells[17].Value.ToString();
                    frm.txtMeasureYards.Text = dgvDesign.CurrentRow.Cells[18].Value.ToString();
                    //          TSI.SI_EndsPerSection as [ENDS/SECTION], TSI.SI_Part as [PART], TSI.SI_MeasureYards as [MEASURE YARDS], 18

                    frm.txtCutMark.Text = dgvDesign.CurrentRow.Cells[19].Value.ToString();
                    frm.txtTotalCuts.Text = dgvDesign.CurrentRow.Cells[20].Value.ToString();
                    frm.txtTotalMeasure.Text = dgvDesign.CurrentRow.Cells[21].Value.ToString();
                    //          TSI.SI_CutMark as [CUT MARK], TSI.SI_TotalCuts as [TOTAL CUTS], TSI.SI_TotalMeasure as [TOTAL MEASURE], 21

                    frm.txtSizingKg.Text = dgvDesign.CurrentRow.Cells[22].Value.ToString();
                    frm.txtRate.Text = dgvDesign.CurrentRow.Cells[23].Value.ToString();
                    frm.lblSizingAmt.Text = dgvDesign.CurrentRow.Cells[24].Value.ToString();
                    //          TSI.SI_SzKg as [SIZING KG], TSI.SI_SzRate as [SIZING RATE],TSI.SI_SzAmt as [SIZING AMT],                   24

                    frm.txtWarpingMtr.Text = dgvDesign.CurrentRow.Cells[25].Value.ToString();
                    frm.txtWarpingRate.Text = dgvDesign.CurrentRow.Cells[26].Value.ToString();
                    frm.lblWarpingAmt.Text = dgvDesign.CurrentRow.Cells[27].Value.ToString();
                    //          TSI.SI_WarpingMtr as [WARPING MTR], TSI.SI_WrRate as [WARPING RATE], TSI.SI_WrAmt as [WARPING AMT], 27

                    frm.lblSubtotalAmt.Text = dgvDesign.CurrentRow.Cells[28].Value.ToString();
                    frm.txtDiscount.Text = dgvDesign.CurrentRow.Cells[29].Value.ToString();
                    frm.txtAddLess.Text = dgvDesign.CurrentRow.Cells[30].Value.ToString();
                    //          TSI.SI_SubTotal as [SUBTOTAL], TSI.SI_Disc as [DISCOUNT], TSI.SI_AddLess as [ADD/LESS],              30

                    frm.cmbQV = Convert.ToInt32(dgvDesign.CurrentRow.Cells[31].Value.ToString());
                    frm.cmbPV = Convert.ToInt32(dgvDesign.CurrentRow.Cells[32].Value.ToString());
                    frm.lblStateCode.Text = dgvDesign.CurrentRow.Cells[33].Value.ToString();
                    frm.lblOwner.Text = dgvDesign.CurrentRow.Cells[34].Value.ToString();
                    frm.txtHSN.Text = dgvDesign.CurrentRow.Cells[35].Value.ToString();
                    //          TSI.SI_Quality,TSI.SI_FromParty,TSI.SI_State, TSI.SI_OwnerName,TSI.SI_HSN,                      35

                    frm.txtCGSTPer.Text = dgvDesign.CurrentRow.Cells[36].Value.ToString();
                    frm.txtSGSTPer.Text = dgvDesign.CurrentRow.Cells[37].Value.ToString();
                    frm.txtIGSTPer.Text = dgvDesign.CurrentRow.Cells[38].Value.ToString();
                    frm.cmbSV = Convert.ToInt32( dgvDesign.CurrentRow.Cells[39].Value.ToString());
                    frm.txtRatePerPick.Text = dgvDesign.CurrentRow.Cells[40].Value.ToString();
                    frm.cmbBV= Convert.ToInt32(dgvDesign.CurrentRow.Cells[41].Value.ToString());
                    //          TSI.SI_CGSTPer,  TSI.SI_SGSTPer,  TSI.SI_IGSTPer,TSI.shade,TSI.RatePerPick as [RATE PER PICK],TSI.broker, 41
                    frm.cmbBroker.Text = dgvDesign.CurrentRow.Cells[42].Value.ToString();
                    frm.cmbFV=Convert.ToInt32(dgvDesign.CurrentRow.Cells[43].Value.ToString());
                    //          BM.BR_Name as [BROKER],TSI.firm,   43
                    frm.cmbCV= Convert.ToInt32(dgvDesign.CurrentRow.Cells[44].Value.ToString());
                    //          TSI.contractNo  44
             
                    //TSI.challnNo,TSI.totalBeams,TSI.totalMtrs,TSI.satNo

                    frm.txtChallanNo.Text = dgvDesign.CurrentRow.Cells[45].Value.ToString();
                    frm.txtTotalMtrs.Text = dgvDesign.CurrentRow.Cells[47].Value.ToString();
                    frm.txtSatNo1.Text = dgvDesign.CurrentRow.Cells[48].Value.ToString();
                    frm.cmbYG = Convert.ToInt32(dgvDesign.CurrentRow.Cells[49].Value.ToString());

                    frm.ShowDialog();
                    FillGrid(101);
                }
                else
                {
                    messageBox frm = new messageBox();
                    frm.messageTxt = "Please select row first";
                    frm.type = "error";
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Something went wrong";
                frm.type = "error";
                frm.ShowDialog();
            }

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvDesign.DataSource = bsOriginal;
                bs.DataSource = dgvDesign.DataSource;
                bs.Filter = string.Format("[NAME] like '%{0}%'", txtSearch.Text);
                dgvDesign.DataSource = bs;
                dgvDesign.Enabled = true;
                // btnClose.Enabled = true;
            }
            catch
            { }
        }

        private void Dashboard_SizingInward_Load(object sender, EventArgs e)
        {
            FillGrid(101);
        }
    }
}
