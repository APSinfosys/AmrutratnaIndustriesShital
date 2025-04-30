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
    public partial class Dashboard_DeliveryChalan_Register : Form
    {
        public Dashboard_DeliveryChalan_Register()
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
                //@intPageNo*@intNoOfRec
                if ( QueryNo == 1002 || QueryNo==1003)
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

                    if (QueryNo == 1002)
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
                    else if (QueryNo == 1003)
                    {
                        totalRecords = Convert.ToInt32(objRow["count"].ToString());
                    }

                }
                else
                {
                    if (QueryNo == 1002)
                    {
                        dgvSut.DataSource = null;
                        GridValidation();
                    }
                    else if (QueryNo == 206)
                    {
                        cmbParty.DataSource = dtReturn;
                        cmbParty.SelectedIndex = -1;
                        cmbParty.Text = "<-- NO PARTY AVAILABLE -->";
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

            for (int i = 13; i <= 24; i++)
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

        private void Dashboard_DeliveryChalan_Register_Load(object sender, EventArgs e)
        {
            cmbPerPageRec.Text = txtPerPgRec.Text;
            FillGrid(1002);
            FillGrid(1003);
            FillGrid(206);

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

        private void btnEditSales_Click(object sender, EventArgs e)
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
                frmT.VoucherId = Convert.ToInt32(dgvSut.CurrentRow.Cells[1].Value.ToString());     //Convert.ToInt32(dgvSut.CurrentRow.Cells[14].Value.ToString());
                //frmT.intSupplierId = Convert.ToInt32(dgvSut.CurrentRow.Cells[39].Value.ToString());
                frmT.ShowDialog();
              //  this.Close();
            }
            else
            {
                MessageBox.Show("PLease select delivery chalan to print");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FillGrid(1003);
            FillGrid(1002);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbParty.SelectedIndex = -1;
            cmbParty.Text = "<-- SELECT PARTY -->";
            txtDcNo.Text = "";
            txtCurrentPg.Text = "1";
            txtPerPgRec.Text = "50";
            FillGrid(1002);
        }

        private void cmbPerPageRec_Leave(object sender, EventArgs e)
        {
            if (cmbPerPageRec.Text == "")
            {
                cmbPerPageRec.Text = txtPerPgRec.Text;
            }
            FillGrid(1002);
            FillGrid(1003);
            btnEnableDisable();
        }

        private void cmbPerPageRec_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPerPgRec.Text = cmbPerPageRec.Text;
        }

        private void btnPrv_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtCurrentPg.Text) > 1)
            {
                txtCurrentPg.Text = (Convert.ToInt32(txtCurrentPg.Text) - 1).ToString();
                FillGrid(1002);
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
                FillGrid(1002);
                btnPrv.Enabled = true;
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //TransactionReport.CRTransaction frmT = new TransactionReport.CRTransaction();

            //ClsDefination.Readpath();

            //frmT.QueryNo = 1009;
            //frmT.server = ClsDefination.server;
            //frmT.dbname = ClsDefination.database;
            //frmT.username = ClsDefination.id;
            //frmT.password = ClsDefination.password;
            //frmT.reportPath = ClsDefination.CrystalPath;

            //frmT.intCompanyID = fd.CompId;

            //frmT.intYearID = fd.YearId;
            //frmT.VoucherId = Convert.ToInt32(strReturnMSG);     //Convert.ToInt32(dgvSut.CurrentRow.Cells[14].Value.ToString());
            ////frmT.intSupplierId = Convert.ToInt32(dgvSut.CurrentRow.Cells[39].Value.ToString());
            //frmT.ShowDialog();
            //this.Close();

        }
    }
}
