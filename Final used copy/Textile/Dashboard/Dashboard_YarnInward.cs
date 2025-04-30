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
    public partial class Dashboard_YarnInward : Form
    {
        public Dashboard_YarnInward()
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
        public int userId, compId, yearId, GroupId, otherPg, cmbValue, cmbTT,formType;
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
                hash.Add("@intcompanyId", Convert.ToInt32(fd.CompId));
                hash.Add("@inryearId", Convert.ToInt32(fd.YearId));

                if (QueryNo == 101)
                {
                    hash.Add("@intIsTaxable", 1); 

                }

                dtReturn = ClsDefination.FillData("[YarnInward_DML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 101)
                    {
                        dgvDesign.DataSource = dtReturn;
                        bsOriginal.DataSource = dtReturn;
                        bsOriginal1.DataSource = dtReturn;
                        dgvDesign.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


                        for (int i = 15; i < 45; i++)
                        {
                            dgvDesign.Columns[i].Visible = false;
                        }


          //                        YIN.UniqueCode as [UNIQUE CODE],YIN.YI_InvoiceNo as [INVOICE NO], YIN.YI_Getpass as [GETPASS],
          //YIN.YI_Date as [DATE],FM.F_CompanyName as [FIRM NAME],
          //MP.P_CompanyName as [FROM PARTY],
          //YIN.contractValue as [CONATRACT NO],QR.Q_Name as [QUALITY],MS.S_Name as [YARN],
          //YIN.TotalNWeight as [NET WEIGHT],YIN.rateExcluding as [RATE],
          //YIN.YI_TaxableSubTotal as [TAXABLE AMOUNT],YIN.YI_TotalGst as [GST AMOUNT], 
          //YIN.YI_ROFF as [R / OFF], YIN.YI_GrandTotal as [INVOICE AMOUNT], 14
		  
          //YIN.YI_Code, YIN.YI_FromParty, YIN.YI_StateCode, 
          //YIN.YI_OwnerName, YIN.shade, YIN.Rate, 
          //YIN.CgstPer, YIN.Cgst, YIN.SgstPer, YIN.Sgst, YIN.IgstPer, YIN.Igst, 
          //YIN.Firm, YIN.GetpassNo, YIN.SutType, YIN.SutUse, YIN.Count, YIN.Color, 
          //YIN.GodawnBag, YIN.KarkhanaBag, YIN.TotalBag, 
          //YIN.GodawnKon, YIN.KarkhanaKon, YIN.TotalKon, 
          //YIN.GodawnNWeight, YIN.KarkhanaNWeight,  YIN.GrossWeight, YIN.PkgType, 
          //YIN.Quality,YIN.contractNo  44


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

                    hash.Add("@strUniqueCode", dgvDesign.CurrentRow.Cells[0].Value.ToString());
                    hash.Add("@intCode", Convert.ToInt32(dgvDesign.CurrentRow.Cells[15].Value.ToString()));
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

        private void Dashboard_YarnInward_Load(object sender, EventArgs e)
        {


            FillGrid(101);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Yarn.YarnInward frm = new Yarn.YarnInward();
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

                    Yarn.YarnInward frm = new Yarn.YarnInward();
                    frm.newOrEdit = 1;

          //           YIN.UniqueCode as [UNIQUE CODE],YIN.YI_InvoiceNo as [INVOICE NO], YIN.YI_Getpass as [GETPASS],
                    frm.lblUniqueCode.Text = dgvDesign.CurrentRow.Cells[0].Value.ToString();
                    frm.txtInvoiceNo.Text = dgvDesign.CurrentRow.Cells[1].Value.ToString();
                    frm.txtGetpass.Text = dgvDesign.CurrentRow.Cells[2].Value.ToString();


          //YIN.YI_Date as [DATE],FM.F_CompanyName as [FIRM NAME],
                    frm.dtpInvoiceDate.Text = dgvDesign.CurrentRow.Cells[3].Value.ToString();
                    frm.cmbFirmName.Text = dgvDesign.CurrentRow.Cells[4].Value.ToString();
          //MP.P_CompanyName as [FROM PARTY],
                    frm.cmbPartyName.Text = dgvDesign.CurrentRow.Cells[5].Value.ToString();
          //YC.ContractNo as [CONATRACT NO],QR.Q_Name as [QUALITY],MS.S_Name as [YARN],
                    frm.cmbContract.Text = dgvDesign.CurrentRow.Cells[6].Value.ToString();
                    frm.cmbQuality.Text = dgvDesign.CurrentRow.Cells[7].Value.ToString();
                    frm.cmbSutType.Text = dgvDesign.CurrentRow.Cells[8].Value.ToString();
          //YIN.TotalNWeight as [NET WEIGHT],YIN.rateExcluding as [RATE],
                    frm.lblTotalWeight.Text = dgvDesign.CurrentRow.Cells[9].Value.ToString();
                    frm.txtExcluding.Text = dgvDesign.CurrentRow.Cells[10].Value.ToString();
          //YIN.YI_TaxableSubTotal as [TAXABLE AMOUNT],YIN.YI_TotalGst as [GST AMOUNT], 
                    frm.txtAmt.Text = dgvDesign.CurrentRow.Cells[11].Value.ToString();
                    frm.lblGST.Text = dgvDesign.CurrentRow.Cells[12].Value.ToString();
          //YIN.YI_ROFF as [R / OFF], YIN.YI_GrandTotal as [INVOICE AMOUNT],
                    frm.txtROff.Text = dgvDesign.CurrentRow.Cells[13].Value.ToString();
                    frm.lblGrandAMT.Text = dgvDesign.CurrentRow.Cells[14].Value.ToString();
		  
          //YIN.YI_Code, YIN.YI_FromParty, YIN.YI_StateCode, 
                    frm.lblSrNo.Text = dgvDesign.CurrentRow.Cells[15].Value.ToString();
                    frm.cmbPNV = Convert.ToInt32( dgvDesign.CurrentRow.Cells[16].Value.ToString());
                    frm.lblStateCode.Text = dgvDesign.CurrentRow.Cells[17].Value.ToString();
          
                    //YIN.YI_OwnerName, YIN.shade, YIN.Rate, 
                    frm.lblOwner.Text = dgvDesign.CurrentRow.Cells[18].Value.ToString();
                    frm.cmbSV = Convert.ToInt32( dgvDesign.CurrentRow.Cells[19].Value.ToString());
                    frm.txtRate.Text = dgvDesign.CurrentRow.Cells[20].Value.ToString();

          //YIN.CgstPer, YIN.Cgst, YIN.SgstPer, YIN.Sgst, YIN.IgstPer, YIN.Igst,
                    frm.txtCgPer.Text = dgvDesign.CurrentRow.Cells[21].Value.ToString();
                    frm.txtCGST.Text = dgvDesign.CurrentRow.Cells[22].Value.ToString();
                    frm.txtSgPer.Text = dgvDesign.CurrentRow.Cells[23].Value.ToString();
                    frm.txtSGST.Text = dgvDesign.CurrentRow.Cells[24].Value.ToString();
                    frm.txtIgPer.Text = dgvDesign.CurrentRow.Cells[25].Value.ToString();
                    frm.txtIGST.Text = dgvDesign.CurrentRow.Cells[26].Value.ToString();

          //YIN.Firm, YIN.GetpassNo, YIN.SutType, YIN.SutUse, YIN.Count, YIN.Color, 
                    frm.cmbFV= Convert.ToInt32(dgvDesign.CurrentRow.Cells[27].Value.ToString());
                    frm.cmbSTV=Convert.ToInt32(dgvDesign.CurrentRow.Cells[29].Value.ToString());
                    frm.lblWarfWeft.Text = dgvDesign.CurrentRow.Cells[30].Value.ToString();
                    frm.txtCount.Text = dgvDesign.CurrentRow.Cells[31].Value.ToString();
                    frm.txtColor.Text = dgvDesign.CurrentRow.Cells[32].Value.ToString();
          //YIN.GodawnBag, YIN.KarkhanaBag, YIN.TotalBag, 
                    frm.txtGodawonBag.Text = dgvDesign.CurrentRow.Cells[33].Value.ToString();
                    frm.txtKarkhanaBag.Text = dgvDesign.CurrentRow.Cells[34].Value.ToString();
                    frm.lblTotalBag.Text = dgvDesign.CurrentRow.Cells[35].Value.ToString();
          //YIN.GodawnKon, YIN.KarkhanaKon, YIN.TotalKon, 
                    frm.txtGodawonKon.Text = dgvDesign.CurrentRow.Cells[36].Value.ToString();
                    frm.txtKarkhanaKon.Text = dgvDesign.CurrentRow.Cells[37].Value.ToString();
                    frm.lblTotalKon.Text = dgvDesign.CurrentRow.Cells[38].Value.ToString();
          //YIN.GodawnNWeight, YIN.KarkhanaNWeight,  YIN.GrossWeight, YIN.PkgType,
                    frm.txtGodawonNWeight.Text = dgvDesign.CurrentRow.Cells[39].Value.ToString();
                    frm.txtKarkhanaNWeight.Text = dgvDesign.CurrentRow.Cells[40].Value.ToString();
                    frm.txtGrossWeight.Text = dgvDesign.CurrentRow.Cells[41].Value.ToString();
                    frm.lblPAkgType.Text = dgvDesign.CurrentRow.Cells[42].Value.ToString();
          //YIN.Quality
                    frm.cmbQV = Convert.ToInt32( dgvDesign.CurrentRow.Cells[43].Value.ToString());
                    frm.cmbCV = Convert.ToInt32(dgvDesign.CurrentRow.Cells[44].Value.ToString());

                    frm.ShowDialog();
                    FillGrid(101);
                }
                else
                {
                    messageBox frm = new messageBox();
                    frm.messageTxt = "Please Select Row To Edit";
                    frm.type = "error";
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
            }
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
                                FillGrid(101);
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
