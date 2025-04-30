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
    public partial class Dashboard_WindingInward : Form
    {
        public Dashboard_WindingInward()
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
        public int userId, compId, yearId, GroupId, otherPg, cmbValue, cmbTT;
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
                hash.Add("@intCompanyId", Convert.ToInt32(fd.CompId));
                hash.Add("@intYearId", Convert.ToInt32(fd.YearId));

                dtReturn = ClsDefination.FillData("[WindingInward_DML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 101)
                    {
                        dgvDesign.DataSource = dtReturn;
                        bsOriginal.DataSource = dtReturn;
                        bsOriginal1.DataSource = dtReturn;
                        dgvDesign.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        for (int i = 0; i < 36; i++)
                        {
                            dgvDesign.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        }
                        for (int i = 20; i < 36; i++)
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

                        for (int i = 20; i < 36; i++)
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

        private void Dashboard_WindingInward_Load(object sender, EventArgs e)
        {
            FillGrid(101);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Yarn.WindingInward frm = new Yarn.WindingInward();
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
                    Yarn.WindingInward frm = new Yarn.WindingInward();
                    frm.newOrEdit = 1;

                    frm.lblUniqueCode.Text = dgvDesign.CurrentRow.Cells[0].Value.ToString();
                    frm.txtGetpass.Text = dgvDesign.CurrentRow.Cells[1].Value.ToString();
                    frm.dtpInvoiceDate.Text = dgvDesign.CurrentRow.Cells[2].Value.ToString();
           //                    WI.UniqueCode as [UNIQUE CODE],WI.WI_GetpassNo as [GETPASS NO], WI.WI_Date as [INWARD DATE],
                    frm.cmbPartyName.Text = dgvDesign.CurrentRow.Cells[3].Value.ToString();
                    frm.cmbFirm.Text = dgvDesign.CurrentRow.Cells[4].Value.ToString();
           //WI.WI_FromPartyName as [PARTY NAME], FM.F_CompanyName as [FIRM NAME],
                    frm.lblSutNameWarfWeft.Text = dgvDesign.CurrentRow.Cells[5].Value.ToString() + ' ' + dgvDesign.CurrentRow.Cells[6].Value.ToString();
                    frm.lblCountValue.Text = dgvDesign.CurrentRow.Cells[7].Value.ToString();
                    frm.lblColorValue.Text = dgvDesign.CurrentRow.Cells[8].Value.ToString();
           //MS.S_Name as [YARN NAME],CV.Common_Value as [WARF / WEFT],WI.WI_Count as [COUNT], WI.WI_Color as [COLOR],
                    frm.lblSrNo.Text = dgvDesign.CurrentRow.Cells[9].Value.ToString();
                    frm.cmbOGNV = Convert.ToInt32(dgvDesign.CurrentRow.Cells[10].Value.ToString());
                    frm.cmbOutWardGetpass.Text = dgvDesign.CurrentRow.Cells[11].Value.ToString();
                    frm.dtpOutWardDate.Text = dgvDesign.CurrentRow.Cells[12].Value.ToString();
                    frm.cmbPNV = Convert.ToInt32(dgvDesign.CurrentRow.Cells[13].Value.ToString());
           //WI.WI_Code,  WI.WO_Getpass, WI.WO_GetpassNo, WI.WO_Date, WI.WI_FromParty,
                    frm.lblOwner.Text = dgvDesign.CurrentRow.Cells[14].Value.ToString();
                    frm.lblStateCode.Text = dgvDesign.CurrentRow.Cells[15].Value.ToString();
                    frm.lblSutCode.Text = dgvDesign.CurrentRow.Cells[16].Value.ToString();
                    frm.lblWarfWeftCode.Text = dgvDesign.CurrentRow.Cells[17].Value.ToString();
                    frm.lblOutwardTotalKon.Text = dgvDesign.CurrentRow.Cells[18].Value.ToString();
                    frm.lblTotalOutwardWeight.Text = dgvDesign.CurrentRow.Cells[19].Value.ToString();
           //WI.WI_OwnerName, WI.WI_State, WI.WI_SutType, WI.WI_SutUse,  WI.WO_TotalKon, WI.WO_Weight, 
                    frm.txtGodawonBag.Text = dgvDesign.CurrentRow.Cells[20].Value.ToString();
                    frm.txtKarkhanaBag.Text = dgvDesign.CurrentRow.Cells[21].Value.ToString();
                    frm.txtGodawonKon.Text = dgvDesign.CurrentRow.Cells[22].Value.ToString();
                    frm.txtKarkhanaKon.Text = dgvDesign.CurrentRow.Cells[23].Value.ToString();
                    frm.lblTotalBag.Text = dgvDesign.CurrentRow.Cells[24].Value.ToString();
                    frm.lblTotalKon.Text = dgvDesign.CurrentRow.Cells[25].Value.ToString();
                    frm.txtGodawonNWeight.Text = dgvDesign.CurrentRow.Cells[26].Value.ToString();
                    frm.txtKarkhanaNWeight.Text = dgvDesign.CurrentRow.Cells[27].Value.ToString();
           //WI.WI_GBag, WI.WI_KBag, WI.WI_GKon, WI.WI_KKon, WI.WI_TotalBag, WI.WI_TotalKon, WI.WI_GNWeight, WI.WI_KNWeight, 
                    frm.lblTotalWeight.Text = dgvDesign.CurrentRow.Cells[28].Value.ToString();
                    frm.txtGodawonEmptyKon.Text = dgvDesign.CurrentRow.Cells[29].Value.ToString();
                    frm.txtKarkahanEmptyKon.Text = dgvDesign.CurrentRow.Cells[30].Value.ToString();
                    frm.lblTotalEmptyKon.Text = dgvDesign.CurrentRow.Cells[31].Value.ToString();
                    frm.txtGodawonEmptyWeight.Text = dgvDesign.CurrentRow.Cells[32].Value.ToString();
                    frm.txtEmptyKonKarkhanaWeight.Text = dgvDesign.CurrentRow.Cells[33].Value.ToString();
                    //WI.WI_TotlaWeight, WI.WI_EmptyGKon, WI.WI_EmptyKKon, WI.WI_TotalEmptyKon, WI.WI_EmptyGWeight, WI.WI_EmptyKWeight, 
                    frm.lblTotalEmptyWeight.Text = dgvDesign.CurrentRow.Cells[34].Value.ToString();
                    frm.lblTotalMixKon.Text = dgvDesign.CurrentRow.Cells[35].Value.ToString();
                    frm.txtWestage.Text = dgvDesign.CurrentRow.Cells[36].Value.ToString();
                    frm.lblReduedWeight.Text = dgvDesign.CurrentRow.Cells[37].Value.ToString();
           //WI.WI_TotalEmptyWeight, WI.WI_TotalMIxKon, WI.WI_Westage, WI.WI_RedusedWeight,
                    frm.cmbSV = Convert.ToInt32(dgvDesign.CurrentRow.Cells[38].Value.ToString());
                    frm.cmbFV=Convert.ToInt32(dgvDesign.CurrentRow.Cells[39].Value.ToString());
                    frm.cmbQV=Convert.ToInt32(dgvDesign.CurrentRow.Cells[40].Value.ToString());
                    frm.cmbCV= Convert.ToInt32(dgvDesign.CurrentRow.Cells[41].Value.ToString());
           // WI.Shade,  WI.Firm, WI.Quality, WI.ContractCode, WI.ContractValue



                    //frm.lblSrNo.Text = dgvDesign.CurrentRow.Cells[0].Value.ToString();
                    //frm.txtGetpass.Text = dgvDesign.CurrentRow.Cells[1].Value.ToString();
                    //frm.dtpInvoiceDate.Text = dgvDesign.CurrentRow.Cells[2].Value.ToString();
                    ////            WI.WI_Code as [CODE], WI.WI_GetpassNo as [GETPASS No], WI.WI_Date AS [DATE],  2
                    //frm.cmbOutWardGetpass.Text = dgvDesign.CurrentRow.Cells[3].Value.ToString();
                    //frm.dtpOutWardDate.Text = dgvDesign.CurrentRow.Cells[4].Value.ToString();
                    //frm.cmbPartyName.Text = dgvDesign.CurrentRow.Cells[5].Value.ToString();
                    ////WI.WO_GetpassNo as [OUTWARD GETPASS] , WI.WO_Date as [WOUTWARD DATE],  WI.WI_FromPartyName  as [COMPANY NAME],  5
                    //frm.lblOwner.Text = dgvDesign.CurrentRow.Cells[6].Value.ToString();
                    //frm.lblSutNameWarfWeft.Text = dgvDesign.CurrentRow.Cells[7].Value.ToString() + " - " + dgvDesign.CurrentRow.Cells[8].Value.ToString();
                    ////WI.WI_OwnerName as [OWNER],MS.S_Name as [SUT NAME],CV.Common_Value as [WARF / WEFT] , 8
                    //frm.lblCountValue.Text = dgvDesign.CurrentRow.Cells[9].Value.ToString();
                    //frm.lblColorValue.Text = dgvDesign.CurrentRow.Cells[10].Value.ToString();
                    //frm.lblOutwardTotalKon.Text = dgvDesign.CurrentRow.Cells[11].Value.ToString();
                    ////WI.WI_Count as [COUNT], WI.WI_Color as [COLOR], WI.WO_TotalKon as [WO TOTAL KON], 11

                    //frm.lblTotalOutwardWeight.Text = dgvDesign.CurrentRow.Cells[12].Value.ToString();
                    //frm.lblTotalWeight.Text = dgvDesign.CurrentRow.Cells[14].Value.ToString();
                    //frm.lblTotalKon.Text = dgvDesign.CurrentRow.Cells[13].Value.ToString();
                    ////WI.WO_Weight as [WO TOTAL WEIGHT],WI.WI_TotalKon as [TOTAL WINDING KON],WI.WI_TotlaWeight as [TOTAL WINDING WEIGHT], 14

                    //frm.lblTotalEmptyKon.Text = dgvDesign.CurrentRow.Cells[15].Value.ToString();
                    //frm.lblTotalEmptyWeight.Text = dgvDesign.CurrentRow.Cells[16].Value.ToString();
                    //frm.txtWestage.Text = dgvDesign.CurrentRow.Cells[17].Value.ToString();
                    ////WI.WI_TotalEmptyKon as [TOTAL EMPTY KON],WI.WI_TotalEmptyWeight as [TOTAL EMPTY WEIGHT],WI.WI_Westage as [WESTAGE], 17

                    //frm.lblReduedWeight.Text = dgvDesign.CurrentRow.Cells[18].Value.ToString();
                    //frm.lblTotalMixKon.Text = dgvDesign.CurrentRow.Cells[19].Value.ToString();
                    ////WI.WI_RedusedWeight as [REDUSED WEIGHT],WI.WI_TotalMIxKon as [TOTAL INWARD KON], 19

                    //frm.cmbOGNV= Convert.ToInt32(dgvDesign.CurrentRow.Cells[20].Value.ToString());
                    //frm.cmbPNV= Convert.ToInt32(dgvDesign.CurrentRow.Cells[21].Value.ToString());
                    //frm.lblStateCode.Text = dgvDesign.CurrentRow.Cells[22].Value.ToString();
                    //frm.lblSutCode.Text = dgvDesign.CurrentRow.Cells[23].Value.ToString();
                    //frm.lblWarfWeftCode.Text = dgvDesign.CurrentRow.Cells[24].Value.ToString();
                    ////WI.WO_Getpass,WI.WI_FromParty, WI.WI_State, WI.WI_SutType,WI.WI_SutUse, 24

                    //frm.txtGodawonBag.Text = dgvDesign.CurrentRow.Cells[25].Value.ToString();
                    //frm.txtKarkhanaBag.Text = dgvDesign.CurrentRow.Cells[26].Value.ToString();
                    //frm.txtGodawonKon.Text = dgvDesign.CurrentRow.Cells[27].Value.ToString();
                    //frm.txtKarkhanaKon.Text = dgvDesign.CurrentRow.Cells[28].Value.ToString();
                    //frm.lblTotalBag.Text = dgvDesign.CurrentRow.Cells[29].Value.ToString();
                    ////WI.WI_GBag,WI.WI_KBag, WI.WI_GKon, WI.WI_KKon, WI.WI_TotalBag,  29

                    //frm.txtGodawonNWeight.Text = dgvDesign.CurrentRow.Cells[30].Value.ToString();
                    //frm.txtKarkhanaNWeight.Text = dgvDesign.CurrentRow.Cells[31].Value.ToString();
                    //frm.txtGodawonEmptyKon.Text = dgvDesign.CurrentRow.Cells[32].Value.ToString();
                    //frm.txtGodawonEmptyWeight.Text = dgvDesign.CurrentRow.Cells[33].Value.ToString();
                    ////WI.WI_GNWeight, WI.WI_KNWeight,  WI.WI_EmptyGKon,WI.WI_EmptyGWeight, 33 
                    //frm.txtKarkahanEmptyKon.Text = dgvDesign.CurrentRow.Cells[34].Value.ToString();
                    //frm.txtEmptyKonKarkhanaWeight.Text = dgvDesign.CurrentRow.Cells[35].Value.ToString();
            
                    ////WI.WI_EmptyKKon,WI.WI_EmptyKWeight 35
                    //frm.cmbSV = Convert.ToInt32(dgvDesign.CurrentRow.Cells[37].Value.ToString());
                    //frm.lblUniqueCode.Text = dgvDesign.CurrentRow.Cells[38].Value.ToString();
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
                bs.Filter = string.Format("[PARTY NAME] like '%{0}%'", txtSearch.Text);
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
                bs1.Filter = string.Format("[YARN NAME] like '%{0}%'", txtSutSearch.Text);
                dgvDesign.DataSource = bs1;
                dgvDesign.Enabled = true;
                // btnClose.Enabled = true;
            }
            catch
            { }
        }
    }
}
