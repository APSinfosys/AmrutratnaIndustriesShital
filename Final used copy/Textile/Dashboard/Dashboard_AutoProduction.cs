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
    public partial class Dashboard_AutoProduction : Form
    {
        public Dashboard_AutoProduction()
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
                hash.Add("@inryearId", Convert.ToDecimal(fd.YearId));

                

                dtReturn = ClsDefination.FillData("[Master_ProductionDML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 102)
                    {
                        dgvSut.DataSource = dtReturn;
                        bsOriginal.DataSource = dtReturn;

                        dgvSut.Columns[8].Visible = false;
                        dgvSut.Columns[9].Visible = false;
                        dgvSut.Columns[10].Visible = false;
                        dgvSut.Columns[11].Visible = false;
                        dgvSut.Columns[12].Visible = false;
                        dgvSut.Columns[13].Visible = false;
                        dgvSut.Columns[14].Visible = false;
                        dgvSut.Columns[15].Visible = false;
                        dgvSut.Columns[16].Visible = false;
                        //dgvSut.Columns[17].Visible = false;
         //     MP.P_Code as [CODE], MP.fromDate as [DATE],-- MP.toDate as [TO DATE],              1
         //MLM.L_ShadeName+' - '+MLM.L_ShadeLocation as [SHADE] ,                                 1
         //CV.Common_Value as [LOOM TYPE],MP.loomNo as [LOOM NO],CD.Q_Name as [QUALITY],  5
         //MP.TagaNo as [TAGA NO], MP.totalProduction as [PRODUCTION (Mtr.)],      7
         // MP.shade,MP.loomType,MP.Quality,MP.prvCut as [PREVIUS CUT], MP.remainCut as [REMAINING CUT] , 12 
         //MP.totNoEmp as [TOTAL EMPLOYEE], MP.totalPayAmt as [PAYMENT], MP.Quality,MP.noOfTage,MP.tagaWeight 17


                    }

                }
                else
                {
                    if (QueryNo == 101)
                    {
                        dgvSut.DataSource = dtReturn;
                        bsOriginal.DataSource = dtReturn;

                        dgvSut.Columns[8].Visible = false;
                        dgvSut.Columns[9].Visible = false;
                        dgvSut.Columns[10].Visible = false;
                        dgvSut.Columns[11].Visible = false;
                        dgvSut.Columns[12].Visible = false;
                        dgvSut.Columns[13].Visible = false;
                        dgvSut.Columns[14].Visible = false;
                        dgvSut.Columns[15].Visible = false;
                        dgvSut.Columns[16].Visible = false;
                        dgvSut.Columns[17].Visible = false;
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
            Production.AutoProduction frm = new Production.AutoProduction();
            frm.newOrEdit = 0;
            frm.ShowDialog();
            FillGrid(102);
        }

        private void Dashboard_AutoProduction_Load(object sender, EventArgs e)
        {
            FillGrid(102);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSut.SelectedRows.Count > 0)
                {
                    Production.AutoProduction frm = new Production.AutoProduction();
                    frm.newOrEdit = 1;

                    frm.lblSrNo.Text = dgvSut.CurrentRow.Cells[0].Value.ToString();
                    frm.dtpDate.Text = dgvSut.CurrentRow.Cells[1].Value.ToString();
                    frm.cmbShade.Text = dgvSut.CurrentRow.Cells[2].Value.ToString();
                    frm.cmbLoomType.Text = dgvSut.CurrentRow.Cells[3].Value.ToString();
                    frm.cmbLoomNo.Text = dgvSut.CurrentRow.Cells[4].Value.ToString();
                    frm.cmbLNV = dgvSut.CurrentRow.Cells[4].Value.ToString();
                    frm.lblQuality.Text = dgvSut.CurrentRow.Cells[5].Value.ToString();
                    frm.txtTagaSrNo.Text = dgvSut.CurrentRow.Cells[6].Value.ToString();
                    frm.txtProductionMtr.Text = dgvSut.CurrentRow.Cells[7].Value.ToString();
                    frm.cmbSV = Convert.ToInt32(dgvSut.CurrentRow.Cells[8].Value.ToString());
                    frm.cmbLTV = Convert.ToInt32(dgvSut.CurrentRow.Cells[9].Value.ToString());
                    frm.lblQuality.Text = dgvSut.CurrentRow.Cells[10].Value.ToString();
                    frm.txtPrvCuts.Text = dgvSut.CurrentRow.Cells[11].Value.ToString();
                    frm.txtRemCut.Text = dgvSut.CurrentRow.Cells[12].Value.ToString();
                 //   13,14,15,
                    frm.txtTotNoTage.Text = dgvSut.CurrentRow.Cells[16].Value.ToString();
                    frm.txtWeight.Text = dgvSut.CurrentRow.Cells[17].Value.ToString();
                    frm.txtRPM.Text = dgvSut.CurrentRow.Cells[18].Value.ToString();
                    frm.ShowDialog();
                    FillGrid(102);

         //           MP.P_Code as [CODE], MP.fromDate as [DATE],-- MP.toDate as [TO DATE],
         //MLM.L_ShadeName+' - '+MLM.L_ShadeLocation as [SHADE] ,
         //CV.Common_Value as [LOOM TYPE],MP.loomNo as [LOOM NO],CD.Q_Name as [QUALITY],  
         //MP.TagaNo as [TAGA NO], MP.totalProduction as [PRODUCTION (Mtr.)],
         // MP.shade,MP.loomType,MP.Quality,MP.prvCut as [PREVIUS CUT], MP.remainCut as [REMAINING CUT], 
         //MP.totNoEmp as [TOTAL EMPLOYEE], MP.totalPayAmt as [PAYMENT], MP.Quality,MP.noOfTage,MP.tagaWeight as [TAGA WEIGHT]
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
