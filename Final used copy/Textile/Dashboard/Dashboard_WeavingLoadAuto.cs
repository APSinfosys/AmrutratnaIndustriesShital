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
    public partial class Dashboard_WeavingLoadAuto : Form
    {
        public Dashboard_WeavingLoadAuto()
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
                hash.Add("@intcompanyId", fd.CompId);
                hash.Add("@inryearId", fd.YearId);
                hash.Add("@intFormType", 1);

                dtReturn = ClsDefination.FillData("[VivingMaster_DML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 101)
                    {
                        dgvSut.DataSource = dtReturn;
                        bsOriginal.DataSource = dtReturn;
                        bsOriginal1.DataSource = dtReturn;
                        //12 13 1415

           //VM.VI_Code as [CODE], VM.VI_Date as [DATE],MLM.L_ShadeName+' - '+MLM.L_ShadeLocation as [SHADE],CV.Common_Value as [LOOM TYPE],  0 1 2 3
           //VM.LoomNo as [LOOM NO],QR.Q_Name as [QUALITY],MP.P_CompanyName as [PARTY NAME],MP.P_OwnerName as [OWNER NAME],  4 5 6 7
           //VM.SatNo as [SAT NO], VM.SatCount as [COUNT], VM.BeamNo as [BI NO], VM.BiMeter as [BI METER], 8 9 10 11
           //VM.ShadeName, VM.LoomType,VM.PartyName,VM.BiNo,VM.Quality,VM.UniqueCode 12 13 14 15 16 17

                        dgvSut.Columns[17].DisplayIndex = 0;

                        for (int i = 0; i < 17; i++)
                        {
                            dgvSut.Columns[i].DisplayIndex = i+1;
                        }


                        dgvSut.Columns[12].Visible = false;
                        dgvSut.Columns[13].Visible = false;
                        dgvSut.Columns[14].Visible = false;
                        dgvSut.Columns[15].Visible = false;
                    }

                }
                else
                {
                    if (QueryNo == 101)
                    {
                        dgvSut.DataSource = dtReturn;

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

        private void Dashboard_WeavingLoadAuto_Load(object sender, EventArgs e)
        {
            FillGrid(101);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvSut.DataSource = bsOriginal;
                bs.DataSource = dgvSut.DataSource;
                bs.Filter = string.Format("[SHADE] like '%{0}%'", txtSearch.Text);
                dgvSut.DataSource = bs;
                dgvSut.Enabled = true;
                // btnClose.Enabled = true;
            }
            catch
            { }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Viving.WeavingLoadAuto frm = new Viving.WeavingLoadAuto();
            frm.newOrEdit = 0;
            frm.ShowDialog();
            FillGrid(101);

        }

        private void txtPartyName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvSut.DataSource = bsOriginal1;
                bs1.DataSource = dgvSut.DataSource;
                bs1.Filter = string.Format("[PARTY NAME] like '%{0}%'", txtPartyName.Text);
                dgvSut.DataSource = bs1;
                dgvSut.Enabled = true;
                // btnClose.Enabled = true;
            }
            catch
            { }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSut.SelectedRows.Count > 0)
                {
           //                    VM.VI_Code as [CODE], VM.VI_Date as [DATE],MLM.L_ShadeName+' - '+MLM.L_ShadeLocation as [SHADE],CV.Common_Value as [LOOM TYPE], 
           //VM.LoomNo as [LOOM NO],QR.Q_Name as [QUALITY],MP.P_CompanyName as [PARTY NAME],MP.P_OwnerName as [OWNER NAME], 
           //VM.SatNo as [SAT NO], VM.SatCount as [COUNT], VM.BeamNo as [BI NO], VM.BiMeter as [BI METER], 
           //VM.ShadeName, VM.LoomType,VM.PartyName,VM.BiNo,VM.Quality


                    Viving.WeavingLoadAuto frm = new Viving.WeavingLoadAuto();
                    frm.newOrEdit = 1;


                    frm.lblSrNo.Text = dgvSut.CurrentRow.Cells[0].Value.ToString();
                    frm.dtpDate.Text = dgvSut.CurrentRow.Cells[1].Value.ToString();
                    frm.cmbShade.Text = dgvSut.CurrentRow.Cells[2].Value.ToString(); 
                    frm.cmbLoomType.Text = dgvSut.CurrentRow.Cells[3].Value.ToString();
                    frm.cmbLoomNo.Text = dgvSut.CurrentRow.Cells[4].Value.ToString();
                    frm.cmbLV = Convert.ToInt32(dgvSut.CurrentRow.Cells[4].Value.ToString());
                    frm.cmbQuality.Text = dgvSut.CurrentRow.Cells[5].Value.ToString();
                    frm.cmbPartyName.Text = dgvSut.CurrentRow.Cells[6].Value.ToString();
                    frm.lblOwner.Text = dgvSut.CurrentRow.Cells[7].Value.ToString();
                    frm.cmbSatNo.Text = dgvSut.CurrentRow.Cells[8].Value.ToString();
                    frm.cmbSV = dgvSut.CurrentRow.Cells[8].Value.ToString();
                    frm.lblSatCount.Text = dgvSut.CurrentRow.Cells[9].Value.ToString();
                    frm.cmbBiNO.Text = dgvSut.CurrentRow.Cells[10].Value.ToString();
                    frm.lblBiCuts.Text = dgvSut.CurrentRow.Cells[11].Value.ToString();
                    frm.cmbShadeV = Convert.ToInt32(dgvSut.CurrentRow.Cells[12].Value.ToString());
                    frm.cmbLTV = Convert.ToInt32(dgvSut.CurrentRow.Cells[13].Value.ToString());
                    frm.cmbPV = Convert.ToInt32(dgvSut.CurrentRow.Cells[14].Value.ToString());
                    frm.cmbBV = dgvSut.CurrentRow.Cells[15].Value.ToString();
                    frm.cmbQV = Convert.ToInt32(dgvSut.CurrentRow.Cells[16].Value.ToString());
                    frm.lblUniqueCode.Text = dgvSut.CurrentRow.Cells[17].Value.ToString();

                    frm.ShowDialog();
                    FillGrid(101);
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void btnUnloadBeam_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSut.SelectedRows.Count > 0)
                {
                    //                    VM.VI_Code as [CODE], VM.VI_Date as [DATE],MLM.L_ShadeName+' - '+MLM.L_ShadeLocation as [SHADE],CV.Common_Value as [LOOM TYPE], 
                    //VM.LoomNo as [LOOM NO],QR.Q_Name as [QUALITY],MP.P_CompanyName as [PARTY NAME],MP.P_OwnerName as [OWNER NAME], 
                    //VM.SatNo as [SAT NO], VM.SatCount as [COUNT], VM.BeamNo as [BI NO], VM.BiMeter as [BI METER], 
                    //VM.ShadeName, VM.LoomType,VM.PartyName,VM.BiNo,VM.Quality


                    Viving.WeavingUnloadAuto frm = new Viving.WeavingUnloadAuto();
                    frm.newOrEdit = 1;


                    frm.lblSrNo.Text = dgvSut.CurrentRow.Cells[0].Value.ToString();
                    frm.dtpDate.Text = dgvSut.CurrentRow.Cells[1].Value.ToString();
                    frm.cmbShade.Text = dgvSut.CurrentRow.Cells[2].Value.ToString();
                    frm.cmbLoomType.Text = dgvSut.CurrentRow.Cells[3].Value.ToString();
                    frm.cmbLoomNo.Text = dgvSut.CurrentRow.Cells[4].Value.ToString();
                    frm.cmbLV = Convert.ToInt32(dgvSut.CurrentRow.Cells[4].Value.ToString());
                    frm.cmbQuality.Text = dgvSut.CurrentRow.Cells[5].Value.ToString();
                    frm.cmbPartyName.Text = dgvSut.CurrentRow.Cells[6].Value.ToString();
                    frm.lblOwner.Text = dgvSut.CurrentRow.Cells[7].Value.ToString();
                    frm.cmbSatNo.Text = dgvSut.CurrentRow.Cells[8].Value.ToString();
                    frm.cmbSV = dgvSut.CurrentRow.Cells[8].Value.ToString();
                    frm.lblSatCount.Text = dgvSut.CurrentRow.Cells[9].Value.ToString();
                    frm.cmbBiNO.Text = dgvSut.CurrentRow.Cells[10].Value.ToString();
                    frm.lblBiCuts.Text = dgvSut.CurrentRow.Cells[11].Value.ToString();
                    frm.cmbShadeV = Convert.ToInt32(dgvSut.CurrentRow.Cells[12].Value.ToString());
                    frm.cmbLTV = Convert.ToInt32(dgvSut.CurrentRow.Cells[13].Value.ToString());
                    frm.cmbPV = Convert.ToInt32(dgvSut.CurrentRow.Cells[14].Value.ToString());
                    frm.cmbBV = dgvSut.CurrentRow.Cells[15].Value.ToString();
                    frm.cmbQV = Convert.ToInt32(dgvSut.CurrentRow.Cells[16].Value.ToString());
                    frm.lblUniqueCode.Text = dgvSut.CurrentRow.Cells[17].Value.ToString();

                    frm.ShowDialog();
                    FillGrid(101);
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
