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
    public partial class Dashboard_WindingOutward : Form
    {
        public Dashboard_WindingOutward()
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

                dtReturn = ClsDefination.FillData("[WindingOutward_DML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 101)
                    {
                        dgvDesign.DataSource = dtReturn;
                        bsOriginal.DataSource = dtReturn;
                        bsOriginal1.DataSource = dtReturn;
                        dgvDesign.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        for (int i = 0; i < 32; i++)
                        {
                            dgvDesign.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        }

                        for (int i = 14; i < 33; i++)
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

                        for (int i = 14; i < 33; i++)
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

        private void Dashboard_WindingOutward_Load(object sender, EventArgs e)
        {
            FillGrid(101);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvDesign.DataSource = bsOriginal;
                bs.DataSource = dgvDesign.DataSource;
                bs.Filter = string.Format("[COMPANY NAME] like '%{0}%'", txtSearch.Text);
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
                bs1.Filter = string.Format("[SUT NAME] like '%{0}%'", txtSutSearch.Text);
                dgvDesign.DataSource = bs1;
                dgvDesign.Enabled = true;
                // btnClose.Enabled = true;
            }
            catch
            { }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Yarn.WindingOutward frm = new Yarn.WindingOutward();
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
                    Yarn.WindingOutward frm = new Yarn.WindingOutward();
                    frm.newOrEdit = 1;

                    frm.lblUniqueCode.Text = dgvDesign.CurrentRow.Cells[0].Value.ToString();
                    frm.txtGetpass.Text = dgvDesign.CurrentRow.Cells[1].Value.ToString();
                    frm.dtpInvoiceDate.Text = dgvDesign.CurrentRow.Cells[2].Value.ToString();

                    //           TWO.UniqueCode as [UNIQUE CODE], TWO.WO_GetpassNo as [GETPASS NO], TWO.WO_Date as [DATE], 

                    frm.cmbPartyName.Text = dgvDesign.CurrentRow.Cells[3].Value.ToString();
                    frm.cmbFirm.Text = dgvDesign.CurrentRow.Cells[4].Value.ToString();
                    frm.cmbShade.Text = dgvDesign.CurrentRow.Cells[5].Value.ToString();
                    //MP.P_CompanyName as [PARTY NAME],FM.F_CompanyName as [FIRM NAME],LM.L_ShadeName as [SHADE NAME],

                    frm.cmbSutType.Text = dgvDesign.CurrentRow.Cells[6].Value.ToString();
                    frm.cmbWarfWeft.Text = dgvDesign.CurrentRow.Cells[7].Value.ToString();
                    frm.cmbCount.Text = dgvDesign.CurrentRow.Cells[8].Value.ToString();
                    frm.countV = Convert.ToDecimal(dgvDesign.CurrentRow.Cells[8].Value.ToString());
                    frm.color= frm.cmbColor.Text = dgvDesign.CurrentRow.Cells[9].Value.ToString();
                   
                    //MS.S_Name as [YARN NAME],CV.Common_Value as [WARF / WEFT],TWO.WO_Count as [COUNT], TWO.WO_Color as [COLOR],

                    frm.lblTotalBag.Text = dgvDesign.CurrentRow.Cells[10].Value.ToString();
                    frm.lblTotalKon.Text = dgvDesign.CurrentRow.Cells[11].Value.ToString();
                    frm.lblTotalWeight.Text = dgvDesign.CurrentRow.Cells[12].Value.ToString();
                    //TWO.WO_TotalBag as [TOTAL BAG], TWO.WO_TotalKon as [TOTAL KON], TWO.WO_TotalWeight as [TOTAL WEIGHT],
                    frm.txtGrossWeight.Text = dgvDesign.CurrentRow.Cells[13].Value.ToString();
                    //TWO.grossWeight as [GROSS WEIGHT],
                    frm.cmbPNV = Convert.ToInt32(dgvDesign.CurrentRow.Cells[14].Value.ToString());
                    frm.lblOwner.Text = dgvDesign.CurrentRow.Cells[15].Value.ToString();
                    frm.lblStateCode.Text = dgvDesign.CurrentRow.Cells[16].Value.ToString();
                    frm.cmbSTV = Convert.ToInt32(dgvDesign.CurrentRow.Cells[17].Value.ToString());
                    //TWO.WO_ToParty, TWO.WO_Owner, TWO.WO_State, TWO.WO_SutType, 

                    frm.cmbSUV = Convert.ToInt32(dgvDesign.CurrentRow.Cells[18].Value.ToString());
                    frm.txtGodawonBag.Text = dgvDesign.CurrentRow.Cells[19].Value.ToString();
                    frm.txtKarkhanaBag.Text = dgvDesign.CurrentRow.Cells[20].Value.ToString();
                    frm.txtGodawonKon.Text = dgvDesign.CurrentRow.Cells[21].Value.ToString();
                    frm.txtKarkhanaKon.Text = dgvDesign.CurrentRow.Cells[22].Value.ToString();
                    frm.txtGodawonNWeight.Text = dgvDesign.CurrentRow.Cells[23].Value.ToString();
                    //TWO.WO_SutUse,  TWO.WO_GBag, TWO.WO_KBag, TWO.WO_GKon, TWO.WO_KKon, TWO.WO_GWeight, 
                    frm.txtKarkhanaNWeight.Text = dgvDesign.CurrentRow.Cells[24].Value.ToString();
                    //TWO.WO_KWeight, 
                    frm.cmbSV = Convert.ToInt32(dgvDesign.CurrentRow.Cells[25].Value.ToString());
                    frm.cmbFV = Convert.ToInt32(dgvDesign.CurrentRow.Cells[26].Value.ToString());
                    frm.cmbContract.Text = dgvDesign.CurrentRow.Cells[27].Value.ToString();
                    frm.cmbContractValue = Convert.ToInt32(dgvDesign.CurrentRow.Cells[28].Value.ToString());
                    //TWO.shade,  TWO.firm, TWO.contractValue, TWO.contractCode, 
                    frm.lblSrNo.Text = dgvDesign.CurrentRow.Cells[29].Value.ToString();
                    frm.cmbQV = Convert.ToInt32(dgvDesign.CurrentRow.Cells[30].Value.ToString());
                    frm.lblKharadValue.Text = dgvDesign.CurrentRow.Cells[31].Value.ToString();
                    //TWO.WO_Code,TWO.quality, TWO.kharadGetpass

                    frm.txtLotNo.Text = dgvDesign.CurrentRow.Cells[32].Value.ToString();

                    frm.cmbMillName.Text = dgvDesign.CurrentRow.Cells[33].Value.ToString();
                    frm.cmbWindingParty = Convert.ToInt32(dgvDesign.CurrentRow.Cells[34].Value.ToString());

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

        private void btnKharad_Click(object sender, EventArgs e)
        {

        }
    }
}