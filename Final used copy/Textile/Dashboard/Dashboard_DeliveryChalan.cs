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
    public partial class Dashboard_DeliveryChalan : Form
    {
        public Dashboard_DeliveryChalan()
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
                hash.Add("@intCompanyId", Convert.ToInt32(fd.CompId));
                hash.Add("@intYearId", Convert.ToInt32(fd.YearId));

                if (QueryNo == 101 || QueryNo == 1001)
                {
                    if (cmbParty.SelectedIndex >= 0)
                    {
                        hash.Add("@intPartyNmae", cmbParty.SelectedValue);
                    }
                    if (txtDcNo.Text != "")
                    {
                        hash.Add("@intCode", txtDcNo.Text);
                    }
                    //*
                    hash.Add("@intPageNo", txtCurrentPg.Text);
                    hash.Add("@intNoOfRec", txtPerPgRec.Text);
                }
                dtReturn = ClsDefination.FillData("[Transaction_DelevaryChalan_DML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 101)
                    {
                        dgvSut.DataSource = dtReturn;
                        bsOriginal.DataSource = dtReturn;
                        GridValidation();
                    }
                    else if (QueryNo == 206)
                    {
                        cmbParty.DataSource = dtReturn;
                        cmbParty.DisplayMember = "Party";
                        cmbParty.ValueMember = "P_Code";
                        cmbParty.SelectedIndex = -1;
                        cmbParty.Text = "<-- SELECT PARTY -->";
                    }
                    else if (QueryNo == 1001)
                    {
                        totalRecords = Convert.ToInt32(objRow["count"].ToString());
                    }
                }
                else
                {
                    if (QueryNo == 101)
                    {
                        dgvSut.DataSource = null;
                        GridValidation();
                    }
                    else if (QueryNo == 206)
                    {
                        cmbParty.DataSource = dtReturn;
                        cmbParty.SelectedIndex = -1;
                        cmbParty.Text = "<-- NO PARTY FOUND -->";
                    }
                    else if (QueryNo == 1001)
                    {
                        totalRecords = 0;
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


        public void GridValidation()
        {//11 21

            for (int i = 13; i <= 22; i++)
            {
                dgvSut.Columns[i].Visible = false;
            }

            dgvSut.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //for (int i = 0; i < 16; i++)
            //{
            //    dgvSut.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    //dgvSut.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //}

            for (int i = 0; i < dgvSut.Rows.Count; i++)
            {
                if (dgvSut.Rows[i].Cells[17].Value.ToString() != "N/A")
                {
                    dgvSut.Rows[i].DefaultCellStyle.BackColor = Color.DarkCyan;
                }
            }

            //'# '+ DC.UniqueCode as [ UNIQUE CODE ],DC.DC_Code as [CHALAN NO],DC.DC_Date as [DATE], FM.F_CompanyName as [ FROM ],
            //MP.P_CompanyName as [TO PARTY],DC.contractName as [CONTRACT NAME], QR.Q_Name as [ QUALITY ],
            //QR.DesignName as [ DESIGN ],DC.DC_Pieces as [ PIECES ], 
            //DC.DC_Mtrs as [ METERS ],DC.sampleCutPiece as [ SAMPLE/CUT ],BM.BR_Name as [ BROKER ],

            //DC.DC_PartyName, DC.Quality,MP.P_State,DC.Shade,DC.broker,DC.invoiceNo,DC.Firm,
            //DC.contractNo as [CONTRACT NO],DC.DC_Place as [PLACE], DC.DC_Bales as [BALES]
        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            TransactionForms.DeliveryChalan frm = new TransactionForms.DeliveryChalan();
            frm.newOrEdit = 0;
            frm.ShowDialog();
            FillGrid(101);
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

        private void Dashboard_DeliveryChalan_Load(object sender, EventArgs e)
        {
            cmbPerPageRec.Text = txtPerPgRec.Text;
            FillGrid(1001);
            FillGrid(101);
            FillGrid(206);

            btnEnableDisable();

        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(dgvSut.SelectedRows.Count) > 0)
                {
                    TransactionForms.Transaction_SalesInvoice frm = new TransactionForms.Transaction_SalesInvoice();
                    frm.newOrEdit = 0;

       //             '# '+ DC.UniqueCode as [ UNIQUE CODE ],
                    frm.lblDeliveryUniqueCode.Text = dgvSut.CurrentRow.Cells[0].Value.ToString().Remove(0, 2);

//                    DC.DC_Code as [CHALAN CODE],
                    
                    //DC.CompChalanNo as [CHALAN NO] ,
                    frm.lblDCNOValue.Text = frm.txtDCNOValue.Text = dgvSut.CurrentRow.Cells[1].Value.ToString();
                    frm.txtCompNo.Text = dgvSut.CurrentRow.Cells[2].Value.ToString();
                    //DC.DC_Date as [DATE], 
                    frm.lblDCDate.Text = dgvSut.CurrentRow.Cells[3].Value.ToString();
                    frm.dtpDcDate.Text = dgvSut.CurrentRow.Cells[3].Value.ToString();
                    frm.dtpInvoicedate.Text = dgvSut.CurrentRow.Cells[3].Value.ToString();
                    //FM.F_CompanyName as [ FROM ],
                    frm.lblfromPartyName.Text = dgvSut.CurrentRow.Cells[4].Value.ToString();
       //MP.P_CompanyName as [TO PARTY], 
                    frm.lblToPartyName.Text = dgvSut.CurrentRow.Cells[5].Value.ToString();
                    //DC.contractName as [CONTRACT NAME], 
                    frm.cmbContract.Text = dgvSut.CurrentRow.Cells[6].Value.ToString();
                    //QR.Q_Name as [ QUALITY ],
                    frm.lblQualityName.Text = dgvSut.CurrentRow.Cells[7].Value.ToString();
       //QR.DesignName as [ DESIGN ],
                    frm.cmbQualityName.Text = dgvSut.CurrentRow.Cells[8].Value.ToString();
                    //DC.DC_Pieces as [ PIECES ], 
                    frm.lblPiecevalue.Text = frm.txtPiecevalue.Text = dgvSut.CurrentRow.Cells[9].Value.ToString();
       //DC.DC_Mtrs as [ METERS ],
                    frm.lblTotalMtrs.Text = frm.txtTotalMtrs.Text = dgvSut.CurrentRow.Cells[10].Value.ToString();
                    //DC.sampleCutPiece as [ SAMPLE/CUT ],
                    frm.lblSampleCutMtr.Text = frm.txtSampleCutMtr.Text = dgvSut.CurrentRow.Cells[11].Value.ToString();
                    //BM.BR_Name as [ BROKER ],
                    frm.txtBrocker.Text = dgvSut.CurrentRow.Cells[12].Value.ToString();
       //DC.DC_PartyName, 
                    frm.lblToPartyCode.Text = dgvSut.CurrentRow.Cells[13].Value.ToString();
                    //DC.Quality,
                    frm.lblQualityCode.Text = dgvSut.CurrentRow.Cells[14].Value.ToString();
                    frm.cmbQualityV = Convert.ToInt32(dgvSut.CurrentRow.Cells[14].Value.ToString());
                    //MP.P_State,
                    frm.lblStateCode.Text = dgvSut.CurrentRow.Cells[15].Value.ToString();
                    //DC.Shade,
                    frm.lblShade.Text = dgvSut.CurrentRow.Cells[16].Value.ToString();
                    //DC.broker,
                    frm.lblBrokerCode.Text = dgvSut.CurrentRow.Cells[17].Value.ToString();
                    //DC.invoiceNo,
                    
                    //DC.Firm,
                    frm.lblFromPartyCode.Text = dgvSut.CurrentRow.Cells[19].Value.ToString();
                    frm.cmbFromPartyV = Convert.ToInt32(dgvSut.CurrentRow.Cells[19].Value.ToString());
       //DC.contractNo as [CONTRACT NO],
                    frm.cmbContractValue = Convert.ToInt32(dgvSut.CurrentRow.Cells[20].Value.ToString());
                    //DC.DC_Place as [PLACE], 
                    frm.lblPlace.Text = dgvSut.CurrentRow.Cells[21].Value.ToString();
                    //DC.DC_Bales as [BALES],
                    
                    //DC.DC_ID,
                    frm.lblDcId.Text = dgvSut.CurrentRow.Cells[23].Value.ToString();
       //ROW_NUMBER() over (order by DC.DC_Code desc) as [ROWNUM]

                   

                    
                    
                    
                    

                    
                    //frm.lblFromPartyCode.Text = dgvSut.CurrentRow.Cells[14].Value.ToString();
                    
                    //frm.lblShade.Text = dgvSut.CurrentRow.Cells[16].Value.ToString();
                    
                    //frm.cmbContractValue = Convert.ToInt32(dgvSut.CurrentRow.Cells[19].Value.ToString());




                    frm.ShowDialog();
                    FillGrid(101);
                }
                else
                {
                    messageBox frm = new messageBox();

                    frm.messageTxt = "Ops ...! Something went worng. ";

                    frm.type = "error";
                    frm.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                messageBox frm = new messageBox();

                frm.messageTxt = "Please select record to sale";

                frm.type = "error";
                frm.ShowDialog();
            }
        }

        private void btnDirectSale_Click(object sender, EventArgs e)
        {
            TransactionForms.Transaction_SalesInvoice_Mannulay frm = new TransactionForms.Transaction_SalesInvoice_Mannulay();
            frm.ShowDialog();
            FillGrid(101);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvSut.SelectedRows.Count > 0)
            {
                TransactionReport.CRTransaction frmT = new TransactionReport.CRTransaction();

                ClsDefination.Readpath();

                frmT.QueryNo = 1009;
                frmT.server = ClsDefination.server;
                frmT.dbname = ClsDefination.database;
                frmT.username = ClsDefination.id;
                frmT.password = ClsDefination.password;
                frmT.reportPath = ClsDefination.CrystalPath;

                frmT.intCompanyID = fd.CompId;

                frmT.intYearID = fd.YearId;
                frmT.VoucherId = Convert.ToInt32(dgvSut.CurrentRow.Cells[0].Value.ToString());     //Convert.ToInt32(dgvSut.CurrentRow.Cells[14].Value.ToString());
                //frmT.intSupplierId = Convert.ToInt32(dgvSut.CurrentRow.Cells[39].Value.ToString());
                frmT.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please Select Delivery Chalan To Print");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FillGrid(1001);
            FillGrid(101);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbParty.SelectedIndex = -1;
            cmbParty.Text = "<-- SELECT PARTY -->";
            txtDcNo.Text = "";
            txtCurrentPg.Text = "1";
            txtPerPgRec.Text = "50";
            FillGrid(101);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtCurrentPg.Text) < (totalRecords / Convert.ToInt32(txtPerPgRec.Text)))
            {
                txtCurrentPg.Text = (Convert.ToInt32(txtCurrentPg.Text) + 1).ToString();
                FillGrid(101);
                btnPrv.Enabled = true;
            }
            else
            {
                btnNext.Enabled = false;
            }
        }

        private void btnPrv_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtCurrentPg.Text) > 1)
            {
                txtCurrentPg.Text = (Convert.ToInt32(txtCurrentPg.Text) - 1).ToString();
                FillGrid(101);
                btnNext.Enabled = true;
            }
            else
            {
                btnPrv.Enabled = false;
            }
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

        private void txtPerPgRec_TextChanged(object sender, EventArgs e)
        {
            try
            {

                int i = Convert.ToInt32(txtPerPgRec.Text);

                //  FillGrid(101);
            }
            catch (Exception ex)
            {
                txtPerPgRec.Text = "30";
            }
            finally
            {
                FillGrid(101);
                btnEnableDisable();
            }
        }

        private void cmbPerPageRec_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPerPgRec.Text = cmbPerPageRec.Text;

        }

        private void cmbPerPageRec_Leave(object sender, EventArgs e)
        {
            if (cmbPerPageRec.Text == "")
            {
                cmbPerPageRec.Text = txtPerPgRec.Text;
            }
            FillGrid(1001);
            FillGrid(101);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvSut.SelectedRows.Count > 0)
            {
                TransactionForms.DeliveryChalan frm = new TransactionForms.DeliveryChalan();
                frm.newOrEdit = 1;
      //              select
      //'# '+ DC.UniqueCode as [ UNIQUE CODE ],
              
                frm.lblUniqueCode.Text = dgvSut.CurrentRow.Cells[0].Value.ToString().Remove(0,2);
                //DC.DC_Code as [CHALAN CODE],
                frm.txtChalanNo.Text = dgvSut.CurrentRow.Cells[1].Value.ToString();
                //DC.CompChalanNo as [CHALAN NO] ,
                frm.txtComChalanNO.Text = dgvSut.CurrentRow.Cells[2].Value.ToString();
                //DC.DC_Date as [DATE], 
                frm.dtpChalanDate.Text = dgvSut.CurrentRow.Cells[3].Value.ToString();
                //FM.F_CompanyName as [ FROM ],
                frm.cmbFirmName.Text = dgvSut.CurrentRow.Cells[4].Value.ToString();
      // MP.P_CompanyName as [TO PARTY],
                frm.cmbParty.Text = dgvSut.CurrentRow.Cells[5].Value.ToString();

                //DC.contractName as [CONTRACT NAME], 
                frm.cmbContract.Text = dgvSut.CurrentRow.Cells[6].Value.ToString();
                //QR.Q_Name as [ QUALITY ],
                frm.lblQuality.Text = dgvSut.CurrentRow.Cells[7].Value.ToString();
      // QR.DesignName as [ DESIGN ],
                frm.cmbDesign.Text = dgvSut.CurrentRow.Cells[8].Value.ToString();
                //DC.DC_Pieces as [ PIECES ], 
                frm.txtPieces.Text = dgvSut.CurrentRow.Cells[9].Value.ToString();
      // DC.DC_Mtrs as [ METERS ],
                frm.txtMeters.Text = dgvSut.CurrentRow.Cells[10].Value.ToString();
                //DC.sampleCutPiece as [ SAMPLE/CUT ],
                frm.txtSampleCutPice.Text = dgvSut.CurrentRow.Cells[11].Value.ToString();
                //BM.BR_Name as [ BROKER ],
                frm.cmbBroker.Text = dgvSut.CurrentRow.Cells[12].Value.ToString();
       
      // DC.DC_PartyName,
                frm.cmbSuppliverV =Convert.ToInt32( dgvSut.CurrentRow.Cells[13].Value.ToString());
                //DC.Quality,
                frm.cmbDesignV = Convert.ToInt32(dgvSut.CurrentRow.Cells[14].Value.ToString());
                //MP.P_State,
                frm.lblStateCode.Text = dgvSut.CurrentRow.Cells[15].Value.ToString();
                //DC.Shade,
                frm.cmbShadeV = Convert.ToInt32(dgvSut.CurrentRow.Cells[16].Value.ToString());
                //DC.broker,
                frm.cmbBrokerV = Convert.ToInt32(dgvSut.CurrentRow.Cells[17].Value.ToString());
                //DC.invoiceNo,
                // Convert.ToInt32(dgvSut.CurrentRow.Cells[18].Value.ToString());
                //DC.Firm,
                frm.cmbFromPartyV = Convert.ToInt32(dgvSut.CurrentRow.Cells[19].Value.ToString());
      // DC.contractNo as [CONTRACT NO],
                frm.cmbContactV= Convert.ToInt32(dgvSut.CurrentRow.Cells[20].Value.ToString());
                //DC.DC_Place as [PLACE],
                frm.txtPlace.Text = dgvSut.CurrentRow.Cells[21].Value.ToString();
                //DC.DC_Bales as [BALES],
                frm.txtBales.Text = dgvSut.CurrentRow.Cells[22].Value.ToString();
                //DC.DC_ID,
                frm.lblSrNo.Text = dgvSut.CurrentRow.Cells[23].Value.ToString();
      // ROW_NUMBER() over (order by DC.DC_Code desc) as [ROWNUM]

                frm.ShowDialog();
                FillGrid(101);
            }
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please select record to edit";
                frm.type = "error";
                frm.ShowDialog();
                
            }
        }

        private void txtDcNo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
