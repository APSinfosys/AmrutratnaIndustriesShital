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
    public partial class Dashboard_SinglePage : Form
    {
        public Dashboard_SinglePage()
        {
            InitializeComponent();
        }

        #region variables
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        BindingSource bs = new BindingSource();
        BindingSource bsOriginal = new BindingSource();
        BindingSource bs1 = new BindingSource();
        BindingSource bsOriginal1 = new BindingSource();
        public string UserName, yearString, companyNameStr, groupNmae, PeriodName;
        public int userId, compId, yearId, GroupId, otherPg, cmbValue, cmbTT, formType;
        string strReturnMSG, strReturnRefNo;
        int intReturnPKNo;
        int result, okflag;
        //  public int groupId;
        public int newOrEdit = 0;
        #endregion


        #region FillGrid() for All in one
        public DataTable FillGrid(int QueryNo)
        {
            try
            {
                hash = new Hashtable();
                DataTable dtReturn = new DataTable();

                hash.Add("@QueryNo", QueryNo);
                hash.Add("@intCompanyId", Convert.ToInt32(fd.CompId));
                hash.Add("@intYearId", Convert.ToInt32(fd.YearId));

                if (QueryNo == 102 || QueryNo == 103)
                {
                    hash.Add("@intParty", cmbPartyName.SelectedValue);
                }
                if (QueryNo == 103)
                {
                    hash.Add("@intSatNo", cmbSatNo.SelectedValue);
                }


                dtReturn = ClsDefination.FillData("[All_In_One_DML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 101)
                    {
                        cmbPartyName.DataSource = dtReturn;
                        cmbPartyName.ValueMember = "P_Code";
                        cmbPartyName.DisplayMember = "P_CompanyName";
                        cmbPartyName.SelectedIndex = -1;
                        cmbPartyName.Text = "<--SELECT PARTY-->";
                    }
                    else if (QueryNo == 102)
                    {
                        cmbSatNo.DataSource = dtReturn;
                        cmbSatNo.ValueMember = "Id";
                        cmbSatNo.DisplayMember = "contractNo";
                        cmbSatNo.SelectedIndex = -1;
                        cmbSatNo.Text = "<--SELECT SAT NO-->";
                    }
                    else if (QueryNo == 103)
                    {
                        lblQuality.Text = objRow["Q_Name"].ToString();
                    }

                }
                else
                {
                    if (QueryNo == 101)
                    {
                        cmbPartyName.DataSource = dtReturn;
                        cmbPartyName.SelectedIndex = -1;
                        cmbPartyName.Text = "<--NO PARTY AVAILABLE-->";
                    }
                    else if (QueryNo == 102)
                    {
                        cmbSatNo.DataSource = dtReturn;
                        cmbSatNo.SelectedIndex = -1;
                        cmbSatNo.Text = "<--NO SAT AVAILABLE-->";
                    }
                    else if (QueryNo == 103)
                    {
                        lblQuality.Text = "NO QUALITY FOUND";
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

        #region FillGrid() for Yarn Inward only
        public DataTable FillGridYarn(int QueryNo)
        {
            try
            {
                hash = new Hashtable();
                DataTable dtReturn = new DataTable();

                hash.Add("@QueryNo", QueryNo);
                hash.Add("@intcompanyId", fd.CompId);
                hash.Add("@inryearId", fd.YearId);

                dtReturn = ClsDefination.FillData("[YarnInward_DML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 102)
                    {
                        dgvYarnInward.DataSource = dtReturn;
                        bsOriginal.DataSource = dtReturn;
                        bsOriginal1.DataSource = dtReturn;
                        dgvYarnInward.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        for (int i = 9; i < 32; i++)
                        {
                            dgvYarnInward.Columns[i].Visible = false;
                        }
                        dgvYarnInward.Columns[1].Visible = false;

                        dgvYarnInward.Columns[0].DisplayIndex = 0;
                        dgvYarnInward.Columns[2].DisplayIndex = 1;
                        dgvYarnInward.Columns[3].DisplayIndex = 2;
                        dgvYarnInward.Columns[4].DisplayIndex = 3;
                        dgvYarnInward.Columns[5].DisplayIndex = 4;
                        dgvYarnInward.Columns[6].DisplayIndex = 5;
                        dgvYarnInward.Columns[32].DisplayIndex = 6;
                        dgvYarnInward.Columns[7].DisplayIndex = 7;
                        dgvYarnInward.Columns[8].DisplayIndex = 8;
                        //              YIN.UniqueCode as [UNIQUE CODE],YIN.YI_InvoiceNo as [INVOICE NO], YIN.YI_Getpass as [GETPASS],
                        //YIN.YI_Date as [DATE],MP.P_CompanyName as [FROM PARTY],
                        //YC.SatNo as [SAT NO],YC.QualityName as [QUALITY],
                        //CAST(YIN.Count as varchar(10)) +' '+ MS.YG_Name+ ' '+YIN.mill as [YARN],
                        //YIN.TotalNWeight as [NET WEIGHT],


                        //                YIN.UniqueCode as [UNIQUE CODE],YIN.YI_InvoiceNo as [INVOICE NO], YIN.YI_Getpass as [GETPASS],
                        // YIN.YI_Date as [DATE],
                        // MP.P_CompanyName as [FROM PARTY],
                        // YIN.contractValue as [CONATRACT NO],QR.Q_Name as [QUALITY],MS.S_Name as [YARN],
                        // YIN.TotalNWeight as [NET WEIGHT],   8

                        // YIN.YI_Code, YIN.YI_FromParty, YIN.YI_StateCode, 
                        // YIN.YI_OwnerName, YIN.shade, 
                        // YIN.GetpassNo, YIN.SutType, YIN.SutUse, YIN.Count, YIN.Color, 
                        // YIN.GodawnBag, YIN.KarkhanaBag, YIN.TotalBag, 
                        // YIN.GodawnKon, YIN.KarkhanaKon, YIN.TotalKon, 
                        // YIN.GodawnNWeight, YIN.KarkhanaNWeight,  YIN.GrossWeight, YIN.PkgType, 
                        // YIN.Quality,YIN.contractNo 30


                    }

                }
                else
                {
                    if (QueryNo == 102)
                    {
                        dgvYarnInward.DataSource = dtReturn;

                        for (int i = 9; i < 31; i++)
                        {
                            dgvYarnInward.Columns[i].Visible = false;
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

        #region FillGrid() For Beam Inward
        public DataTable FillGridBeamInward(int QueryNo)
        {
            try
            {
                hash = new Hashtable();
                DataTable dtReturn = new DataTable();

                hash.Add("@QueryNo", QueryNo);
                hash.Add("@intCompanyId", fd.CompId);
                hash.Add("@intYearId", fd.YearId);

                dtReturn = ClsDefination.FillData("[Transaction_BeamInward_DML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 101)
                    {
                        dgvBeamInward.DataSource = dtReturn;
                        dgvBeamInward.DataSource = dtReturn;
                        bsOriginal.DataSource = dtReturn;

                        gridValidationsBeam();

                    }

                }
                else
                {
                    if (QueryNo == 101)
                    {
                        dgvBeamInward.DataSource = dtReturn;
                        gridValidationsBeam();
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

        public void gridValidationsBeam()
        {
            for (int i = 0; i <= 30; i++)
            {
                dgvBeamInward.Columns[i].Visible = false;
            }

            //27 0 3 1 20 21 22


            dgvBeamInward.Columns[27].Visible = dgvBeamInward.Columns[0].Visible = dgvBeamInward.Columns[3].Visible = dgvBeamInward.Columns[1].Visible = dgvBeamInward.Columns[20].Visible =
            dgvBeamInward.Columns[21].Visible = dgvBeamInward.Columns[22].Visible = true;

            dgvBeamInward.Columns[27].DisplayIndex = 0; dgvBeamInward.Columns[0].DisplayIndex = 1;
            dgvBeamInward.Columns[3].DisplayIndex = 2; dgvBeamInward.Columns[1].DisplayIndex = 3; dgvBeamInward.Columns[20].DisplayIndex = 4;
            dgvBeamInward.Columns[21].DisplayIndex = 5; dgvBeamInward.Columns[22].DisplayIndex = 6;

        }

        #endregion

        #region FillGrid() For Delivery Chalan
        public DataTable FillGridDC(int QueryNo)
        {
            try
            {
                hash = new Hashtable();
                DataTable dtReturn = new DataTable();

                hash.Add("@QueryNo", QueryNo);
                hash.Add("@intCompanyId", Convert.ToInt32(fd.CompId));
                hash.Add("@intYearId", Convert.ToInt32(fd.YearId));

                if (QueryNo == 2001)
                {
                    hash.Add("@intPartyNmae", cmbPartyName.SelectedValue);
                    hash.Add("@intCode", cmbSatNo.SelectedValue);
                }
                dtReturn = ClsDefination.FillData("[Transaction_DelevaryChalan_DML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 2001)
                    {
                        dgvDeliveryChalan.DataSource = dtReturn;
                        bsOriginal.DataSource = dtReturn;
                        GridValidation();
                    }
                }
                else
                {
                    if (QueryNo == 101)
                    {
                        dgvDeliveryChalan.DataSource = null;
                        GridValidation();
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

        public void GridValidation()
        {//11 21

            for (int i = 12; i <= 21; i++)
            {
                dgvDeliveryChalan.Columns[i].Visible = false;
            }

            dgvDeliveryChalan.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            for (int i = 0; i < dgvDeliveryChalan.Rows.Count; i++)
            {
                if (dgvDeliveryChalan.Rows[i].Cells[17].Value.ToString() != "N/A")
                {
                    dgvDeliveryChalan.Rows[i].DefaultCellStyle.BackColor = Color.DarkCyan;
                }
            }

        }


        #endregion

        #region FillGrid() for Sales Invoice
        public DataTable FillGridSalesInvoice(int QueryNo)
        {
            try
            {
                hash = new Hashtable();
                DataTable dtReturn = new DataTable();

                hash.Add("@QueryNo", QueryNo);
                hash.Add("@intCompanyId", fd.CompId);
                hash.Add("@intYearId", fd.YearId);

                if (QueryNo == 2001)
                {
                    hash.Add("@intFromParty", cmbPartyName.SelectedValue);
                    hash.Add("@intContractCode",cmbSatNo.SelectedValue);
                }

                dtReturn = ClsDefination.FillData("[Transaction_SalesInvoice_DML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 2001)
                    {
                        dgvSalesInvoice.DataSource = dtReturn;
                        bsOriginal.DataSource = dtReturn;


                        for (int i = 13; i <=45; i++)
                        {
                            dgvSalesInvoice.Columns[i].Visible = false;
                        }

                    }
                }
                else
                {
                    if (QueryNo == 1001)
                    {
                        dgvSalesInvoice.DataSource = null;
                        for (int i = 13; i < 45; i++)
                        {
                            dgvSalesInvoice.Columns[i].Visible = false;
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



        private void Dashboard_SinglePage_Load(object sender, EventArgs e)
        {
            FillGrid(101); // fill party
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Text == "YARN INWARD")
            {
                Yarn.YarnInwardOnly frm = new Yarn.YarnInwardOnly();
                frm.newOrEdit = 0;
                frm.singlePage = 1;
                frm.cmbPNV = Convert.ToInt32(cmbPartyName.SelectedValue);
                frm.cmbCV = Convert.ToInt32(cmbSatNo.SelectedValue);

                frm.ShowDialog();


                // FillGrid(101);
            }
            else if (tabControl1.SelectedTab.Text == "BEAM INWARD")
            {
                Sizing.BeamInward frm = new Sizing.BeamInward();
                frm.newOrEdit = 0;
                frm.ShowDialog();
                //    FillGrid(101);

            }
            else if (tabControl1.SelectedTab.Text == "DELIVERY CHALAN")
            {
                TransactionForms.DeliveryChalan frm = new TransactionForms.DeliveryChalan();
                frm.newOrEdit = 0;
                frm.ShowDialog();
            }
            else if (tabControl1.SelectedTab.Text == "SALES INVOICES")
            {
                TransactionForms.Transaction_SalesInvoice frm = new TransactionForms.Transaction_SalesInvoice();
                frm.newOrEdit = 0;
                frm.ShowDialog();
            }
        }

        private void btnGetRecord_Click(object sender, EventArgs e)
        {
            if (cmbPartyName.SelectedIndex > -1)
            {
                if (cmbSatNo.SelectedIndex > -1)
                {
                    FillGrid(103); // get quality details
                    FillGridYarn(102);
                }
                else
                {
                    messageBox frm = new messageBox();
                    frm.messageTxt = "Please select SAT No";
                    frm.type = "error";
                    frm.ShowDialog();

                }
            }
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please select Party";
                frm.type = "error";
                frm.ShowDialog();

            }
        }

        private void cmbPartyName_Leave(object sender, EventArgs e)
        {
            if (cmbPartyName.SelectedIndex > -1)
            {
                FillGrid(102);// fill sat no
                cmbSatNo.Focus();
            }
        }

        private void tabYarnInward_Enter(object sender, EventArgs e)
        {
            FillGridYarn(102);
        }

        private void tabBeamInward_Enter(object sender, EventArgs e)
        {
            FillGridBeamInward(101);
        }

        private void tabDeliveryCHalan_Enter(object sender, EventArgs e)
        {
            FillGridDC(2001);
        }

        private void tabInvoices_Enter(object sender, EventArgs e)
        {
            FillGridSalesInvoice(2001);
        }

    }
}
