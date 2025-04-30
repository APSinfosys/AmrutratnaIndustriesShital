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
    public partial class Dashboard_ClothDesigh : Form
    {
        public Dashboard_ClothDesigh()
        {
            InitializeComponent();
        }

        #region variables
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        BindingSource bs = new BindingSource();
        BindingSource bsOriginal = new BindingSource();
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
                hash.Add("@intcompanyId", Convert.ToInt32(fd.CompId));

                dtReturn = ClsDefination.FillData("[Master_QualityMasterDML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 101)
                    {
                        dgvDesign.DataSource = dtReturn;
                        bsOriginal.DataSource = dtReturn; //2 8
                        gridValidation();
                     
                    }

                }
                else
                {
                    if (QueryNo == 101)
                    {
                        dgvDesign.DataSource = null;


                        gridValidation();
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
                    hash.Add("@intCode", Convert.ToInt32(dgvDesign.CurrentRow.Cells[0].Value.ToString()));
                    hash.Add("@strUniqueCode", dgvDesign.CurrentRow.Cells[15].Value.ToString());
                }

                okflag = 1;
                return ClsDefination.InsertExecute(hash, "[Master_QualityMasterDML]", ref strReturnMSG, ref strReturnNo, ref intReturnNo);
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

        public void gridValidation()
        {
            dgvDesign.Columns[15].DisplayIndex = 0;
            dgvDesign.Columns[20].DisplayIndex = 1;
            dgvDesign.Columns[1].DisplayIndex = 2;
            dgvDesign.Columns[19].DisplayIndex = 3;
            dgvDesign.Columns[2].DisplayIndex = 4;
            dgvDesign.Columns[5].DisplayIndex = 4;


            dgvDesign.Columns[0].Visible =
                 dgvDesign.Columns[3].Visible = dgvDesign.Columns[4].Visible =
                dgvDesign.Columns[6].Visible = dgvDesign.Columns[7].Visible = dgvDesign.Columns[8].Visible =
                dgvDesign.Columns[9].Visible = dgvDesign.Columns[10].Visible = dgvDesign.Columns[11].Visible = dgvDesign.Columns[12].Visible =
                dgvDesign.Columns[13].Visible = dgvDesign.Columns[14].Visible =
                dgvDesign.Columns[16].Visible = dgvDesign.Columns[17].Visible =
                dgvDesign.Columns[18].Visible = false;
        }

        private void Dashboard_ClothDesigh_Load(object sender, EventArgs e)
        {
            FillGrid(101);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvDesign.DataSource = bsOriginal;
                bs.DataSource = dgvDesign.DataSource;
                bs.Filter = string.Format("[QUALITY NAME] like '%{0}%'", txtSearch.Text);
                dgvDesign.DataSource = bs;
                dgvDesign.Enabled = true;
                gridValidation();
                // btnClose.Enabled = true;
            }
            catch
            { }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            // Sizing.SizingInward frm = new Sizing.SizingInward();
            // Masters.ClothDesignMaster frm = new Masters.ClothDesignMaster();
            Masters.Master_QualityMasterRapier frm = new Masters.Master_QualityMasterRapier();
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
                    Masters.Master_QualityMasterRapier frm = new Masters.Master_QualityMasterRapier();
                    frm.newOrEdit = 1;
                    frm.lblSrNo.Text = dgvDesign.CurrentRow.Cells[0].Value.ToString();
                    frm.lblQualityName.Text = dgvDesign.CurrentRow.Cells[1].Value.ToString();

                    frm.txtPart.Text = dgvDesign.CurrentRow.Cells[2].Value.ToString();
                    frm.txtLasa.Text = dgvDesign.CurrentRow.Cells[3].Value.ToString();
                    frm.txtWarfConst.Text = dgvDesign.CurrentRow.Cells[4].Value.ToString();

                    frm.txtPanna.Text = dgvDesign.CurrentRow.Cells[5].Value.ToString();
                    //                  Q_Code as [CODE], Q_Name as [NAME], Q_Tara as [TARA], 
                    //Q_Part as [PART], Q_Lasa as [LASA], Q_WarfConst as [WARF CONST], Q_Panna as [PANNA], 
                    frm.txtMeter.Text = dgvDesign.CurrentRow.Cells[6].Value.ToString();
                    frm.txtWeftConst.Text = dgvDesign.CurrentRow.Cells[7].Value.ToString();
                    frm.txtWestage.Text = dgvDesign.CurrentRow.Cells[8].Value.ToString();
                    frm.txtMeasure.Text = dgvDesign.CurrentRow.Cells[9].Value.ToString();

                    frm.lblUniqueCode.Text = dgvDesign.CurrentRow.Cells[15].Value.ToString().Remove(0,2);
                    frm.txtPannha.Text = dgvDesign.CurrentRow.Cells[16].Value.ToString();
                    frm.txtReed.Text = dgvDesign.CurrentRow.Cells[17].Value.ToString();
                    //QR.satNo,QR.DesignName as [DESING NAME],JCI.SatNo as [SAT NO]
                    frm.cmbSN = Convert.ToInt32(dgvDesign.CurrentRow.Cells[18].Value.ToString());
                    frm.txtDesignName.Text = dgvDesign.CurrentRow.Cells[19].Value.ToString();
                    frm.cmbSatNo.Text = dgvDesign.CurrentRow.Cells[20].Value.ToString();
                    frm.lblMajuri.Text = dgvDesign.CurrentRow.Cells[21].Value.ToString();
                    frm.lblPickC.Text = dgvDesign.CurrentRow.Cells[22].Value.ToString();
                    frm.lblRate.Text = dgvDesign.CurrentRow.Cells[23].Value.ToString();
                    
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the record?", "Delete record", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SaveData(3, ref strReturnMSG, ref strReturnRefNo, ref intReturnPKNo);

                if (okflag == 1)
                {
                    messageBox frm = new messageBox();

                    if (intReturnPKNo == 0)
                    {
                        frm.messageTxt = strReturnMSG;
                        frm.type = "error";
                        frm.ShowDialog();
                    }
                    else
                    {
                        frm.messageTxt = "Rocord Deleted Successfully";// +strReturnMSG;
                        frm.type = "success";
                        frm.ShowDialog();
                        FillGrid(101);
                    }
                }
            }
        }
    }
}
