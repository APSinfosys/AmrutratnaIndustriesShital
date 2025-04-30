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
    public partial class Dashboard_YarnOnlyInward : Form
    {
        public Dashboard_YarnOnlyInward()
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


        #region FillGrid()
        public DataTable FillGrid(int QueryNo)
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
                        dgvDesign.DataSource = dtReturn;
                        bsOriginal.DataSource = dtReturn;
                        bsOriginal1.DataSource = dtReturn;
                        dgvDesign.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        for (int i = 9; i < 32; i++)
                        {
                            dgvDesign.Columns[i].Visible = false;
                        }
                        dgvDesign.Columns[1].Visible = false;

                        dgvDesign.Columns[0].DisplayIndex=0;
                        dgvDesign.Columns[2].DisplayIndex = 1;
                        dgvDesign.Columns[3].DisplayIndex = 2;
                        dgvDesign.Columns[4].DisplayIndex = 3;
                        dgvDesign.Columns[5].DisplayIndex = 4;
                        dgvDesign.Columns[6].DisplayIndex = 5;
                        dgvDesign.Columns[32].DisplayIndex = 6;
                        dgvDesign.Columns[7].DisplayIndex = 7;
                        dgvDesign.Columns[8].DisplayIndex = 8;
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
                        dgvDesign.DataSource = dtReturn;

                        for (int i = 9; i < 31; i++)
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


        #region savedata()
        //--------------- Savedata() -------------------------------------------------

        public DataSet SaveData(int QueryNo, ref string strReturnMSG, ref string strReturnNo, ref Int32 intReturnNo)//string strReturn    DataSet
        {
            try
            {
                strReturnMSG = "0";
                strReturnNo = "0";
                intReturnNo = 0;

                okflag = 0;
                hash = new Hashtable();


                hash.Add("@QueryNo", QueryNo);
                hash.Add("@intcreatedBy", fd.UserId);
                hash.Add("@intcompanyId", fd.CompId);
                hash.Add("@inryearId", fd.YearId);

                if (QueryNo == 3)
                {

                    hash.Add("@strUniqueCode",dgvDesign.CurrentRow.Cells[0].Value.ToString());
                    hash.Add("@intCode", Convert.ToInt32(dgvDesign.CurrentRow.Cells[9].Value.ToString()));
                }

                okflag = 1;
                return ClsDefination.InsertExecute(hash, "[YarnInward_DML]", ref strReturnMSG, ref strReturnNo, ref intReturnNo);
            }
            catch (Exception Ex)
            {
                if (okflag == 0)
                {
                    MessageBox.Show("Enter proper data " + Ex);
                }
                return null;
                throw;
            }
        }

        //----------------------------------------------------------------------------

        #endregion

        private void Dashboard_YarnOnlyInward_Load(object sender, EventArgs e)
        {
            FillGrid(102);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Yarn.YarnInwardOnly frm = new Yarn.YarnInwardOnly();
            frm.newOrEdit = 0;
            frm.ShowDialog();
            FillGrid(102);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvDesign.DataSource = bsOriginal;
                bs.DataSource = dgvDesign.DataSource;
                bs.Filter = string.Format("[FROM PARTY] like '%{0}%'", txtSearch.Text);
                dgvDesign.DataSource = bs;
                dgvDesign.Enabled = true;
                // btnClose.Enabled = true;
            }
            catch
            { }
        }

        private void txtSutSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvDesign.DataSource = bsOriginal1;
                bs1.DataSource = dgvDesign.DataSource;
                bs1.Filter = string.Format("[YARN] like '%{0}%'", txtSutSearch.Text);
                dgvDesign.DataSource = bs1;
                dgvDesign.Enabled = true;
                // btnClose.Enabled = true;
            }
            catch
            { }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDesign.SelectedRows.Count > 0)
                {
                    Yarn.YarnInwardOnly frm = new Yarn.YarnInwardOnly();
                    frm.newOrEdit = 1;
                    
                    
         //                     YIN.UniqueCode as [UNIQUE CODE],YIN.YI_InvoiceNo as [INVOICE NO], YIN.YI_Getpass as [GETPASS],
                    frm.lblUniqueCode.Text = dgvDesign.CurrentRow.Cells[0].Value.ToString();
                    frm.txtInvoiceNo.Text = dgvDesign.CurrentRow.Cells[1].Value.ToString();
                    frm.txtGetpass.Text = dgvDesign.CurrentRow.Cells[2].Value.ToString();
         // YIN.YI_Date as [DATE],--FM.F_CompanyName as [FIRM NAME],
                    frm.dtpInvoiceDate.Text = dgvDesign.CurrentRow.Cells[3].Value.ToString();
         // MP.P_CompanyName as [FROM PARTY],
                    frm.cmbPartyName.Text = dgvDesign.CurrentRow.Cells[4].Value.ToString();
         // YIN.contractValue as [CONATRACT NO],QR.Q_Name as [QUALITY],MS.S_Name as [YARN],
                    frm.cmbContract.Text = dgvDesign.CurrentRow.Cells[5].Value.ToString();
                    frm.lblQuality.Text = dgvDesign.CurrentRow.Cells[6].Value.ToString();
                    frm.cmbSutType.Text = dgvDesign.CurrentRow.Cells[7].Value.ToString();
         // YIN.TotalNWeight as [NET WEIGHT],--YIN.rateExcluding as [RATE],
                    frm.lblTotalWeight.Text = dgvDesign.CurrentRow.Cells[8].Value.ToString();
                    //-- YIN.YI_TaxableSubTotal as [TAXABLE AMOUNT],YIN.YI_TotalGst as [GST AMOUNT], 
         // --YIN.YI_ROFF as [R / OFF], YIN.YI_GrandTotal as [INVOICE AMOUNT],
		  
         // YIN.YI_Code, YIN.YI_FromParty, YIN.YI_StateCode, 
                    frm.lblSrNo.Text = dgvDesign.CurrentRow.Cells[9].Value.ToString();
                    frm.cmbPNV=Convert.ToInt32( dgvDesign.CurrentRow.Cells[10].Value.ToString());
                    frm.lblStateCode.Text = dgvDesign.CurrentRow.Cells[11].Value.ToString();
         // YIN.YI_OwnerName, YIN.shade, --YIN.Rate, 
                    frm.lblOwner.Text = dgvDesign.CurrentRow.Cells[12].Value.ToString();
                    frm.cmbSV= Convert.ToInt32( dgvDesign.CurrentRow.Cells[13].Value.ToString());
         //-- YIN.CgstPer, YIN.Cgst, YIN.SgstPer, YIN.Sgst, YIN.IgstPer, YIN.Igst, 
         //-- YIN.Firm, 
         // YIN.GetpassNo, YIN.SutType, YIN.SutUse, YIN.Count, YIN.Color, 
                    frm.cmbSTV = Convert.ToInt32( dgvDesign.CurrentRow.Cells[15].Value.ToString());
                    frm.lblWarfWeft.Text = dgvDesign.CurrentRow.Cells[16].Value.ToString();
                    frm.txtCount.Text= frm.cmbCount.Text = dgvDesign.CurrentRow.Cells[17].Value.ToString();
                    frm.txtColor.Text = dgvDesign.CurrentRow.Cells[18].Value.ToString();
         // YIN.GodawnBag, YIN.KarkhanaBag, YIN.TotalBag, 
                    frm.txtGodawonBag.Text = dgvDesign.CurrentRow.Cells[19].Value.ToString();
                    frm.txtKarkhanaBag.Text = dgvDesign.CurrentRow.Cells[20].Value.ToString();
                    frm.lblTotalBag.Text = dgvDesign.CurrentRow.Cells[21].Value.ToString();
         // YIN.GodawnKon, YIN.KarkhanaKon, YIN.TotalKon, 
                    frm.txtGodawonKon.Text = dgvDesign.CurrentRow.Cells[22].Value.ToString();
                    frm.txtKarkhanaKon.Text = dgvDesign.CurrentRow.Cells[23].Value.ToString();
                    frm.lblTotalKon.Text = dgvDesign.CurrentRow.Cells[24].Value.ToString();
         // YIN.GodawnNWeight, YIN.KarkhanaNWeight,  YIN.GrossWeight, YIN.PkgType,
                    frm.txtGodawonNWeight.Text = dgvDesign.CurrentRow.Cells[25].Value.ToString();
                    frm.txtKarkhanaNWeight.Text = dgvDesign.CurrentRow.Cells[26].Value.ToString();
                    frm.txtGrossWeight.Text = dgvDesign.CurrentRow.Cells[27].Value.ToString();
                    frm.lblPAkgType.Text = dgvDesign.CurrentRow.Cells[28].Value.ToString();
         // YIN.Quality,YIN.contractNo
                    frm.cmbQV = Convert.ToInt32( dgvDesign.CurrentRow.Cells[29].Value.ToString());
                    frm.cmbCV = Convert.ToInt32(dgvDesign.CurrentRow.Cells[30].Value.ToString());
                    frm.txtMillName.Text = dgvDesign.CurrentRow.Cells[31].Value.ToString();
                    frm.cmbQuality.Text = dgvDesign.CurrentRow.Cells[32].Value.ToString();

                    frm.ShowDialog();
                    FillGrid(102);
                }
                else
                {
                    messageBox frm = new messageBox();
                    frm.messageTxt = "Please Select Record To Edit";
                    frm.type = "error";
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void btnPrintPanelClose_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void btnPrintValue_Click(object sender, EventArgs e)
        {
            TransactionReport.CRTransaction frm = new TransactionReport.CRTransaction();

            ClsDefination.Readpath();

            frm.QueryNo = 6002;
            frm.server = ClsDefination.server;
            frm.dbname = ClsDefination.database;
            frm.username = ClsDefination.id;
            frm.password = ClsDefination.password;
            frm.reportPath = ClsDefination.CrystalPath;

            frm.intCompanyID = fd.CompId;

            frm.intYearID = fd.YearId;
         //   frm.VoucherId = Convert.ToInt32(dgvSut.CurrentRow.Cells[14].Value.ToString());
            if (cmbFromParty.SelectedIndex > -1)
            {
                frm.intSupplierId = Convert.ToInt32(cmbFromParty.SelectedValue);
            }
            else
            {
                frm.intSupplierId = 0;
            }

            if (cmbYarnName.SelectedIndex > -1)
            {
                frm.VoucherId = Convert.ToInt32(cmbYarnName.SelectedValue);
            }
            else
            {
                frm.VoucherId = 0;
            }
            if (dtpFromDate.Value.ToString("MM/dd/yyyy") != dtpToDate.Value.ToString("MM/dd/yyyy"))
            {
                frm.sdtFromDate = dtpFromDate.Value.ToString("MM/dd/yyyy");
                frm.sdtToDate = dtpToDate.Value.ToString("MM/dd/yyyy");
            }
            frm.ShowDialog();


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDesign.SelectedRows.Count > 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the record?", "Delete record", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        SaveData(3, ref strReturnMSG, ref strReturnRefNo, ref intReturnPKNo);

                        if (okflag == 1)
                        {
                            if (intReturnPKNo == 0)
                            {
                                messageBox frm = new messageBox();
                                frm.messageTxt = strReturnMSG;
                                frm.type = "error";
                                frm.ShowDialog();
                            }
                            else
                            {
                                messageBox frm = new messageBox();
                                frm.messageTxt = "Rocord Deleted Successfully: ";// +strReturnMSG;
                                frm.type = "success";
                                frm.ShowDialog();
                                FillGrid(102);
                            }
                        }
                    }
                }
                else
                {
                    messageBox frm = new messageBox();
                    frm.messageTxt = "Please select record to delete";
                    frm.type = "error";
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Something went wrong please try again or call Administrator";
                frm.type = "error";
                frm.ShowDialog();
            }
        }
    }
}
