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
    public partial class Dashboard_Production : Form
    {
        public Dashboard_Production()
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

                    if (QueryNo == 101)
                    {
                        dgvSut.DataSource = dtReturn;
                        bsOriginal.DataSource = dtReturn;
                        dgvSut.Columns[13].Visible=false;
                        dgvSut.Columns[14].Visible=false;
                        dgvSut.Columns[15].Visible = false;

         //     MP.P_Code as [CODE], MP.fromDate as [FROM DATE], MP.toDate as [TO DATE],
         //MLM.L_ShadeName+' - '+MLM.L_ShadeLocation as [SHADE] ,
         //CV.Common_Value as [LOOM TYPE],MP.loomNo as [LOOM NO], CD.D_Name as [QUALITY], 
         //MP.prvCut as [PREVIUS CUT], 
         //MP.noOfTage as [TAGA NO], MP.totalProduction as [PRODUCTION (Mtr.)], MP.remainCut as [REMAINING CUT], 
         //MP.totNoEmp as [TOTAL EMPLOYEE], MP.totalPayAmt as [PAYMENT],
         // MP.shade,MP.loomType,MP.Quality

                    }

                }
                else
                {
                    if (QueryNo == 101)
                    {
                        dgvSut.DataSource = dtReturn;
                        bsOriginal.DataSource = dtReturn;
                        dgvSut.Columns[15].Visible = false;
                        dgvSut.Columns[13].Visible = false;
                        dgvSut.Columns[14].Visible = false;

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
            Production.Production frm = new Production.Production();
            frm.newOrEdit = 0;
            frm.ShowDialog();
            FillGrid(101);
        }

        private void Dashboard_Production_Load(object sender, EventArgs e)
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

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }
    }
}
