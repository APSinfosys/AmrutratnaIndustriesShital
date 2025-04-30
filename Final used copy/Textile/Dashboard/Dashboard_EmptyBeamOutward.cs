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
    public partial class Dashboard_EmptyBeamOutward : Form
    {
        public Dashboard_EmptyBeamOutward()
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
                hash.Add("@intCompanyId", fd.CompId);
                hash.Add("@intYearId", fd.YearId);

                dtReturn = ClsDefination.FillData("[Transaction_EmptyBeamOutward_DML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 101)
                    {
                        dgvDesign.DataSource = dtReturn;
                        bsOriginal.DataSource = dtReturn;
                        Gridvalidations();
                    }

                }
                else
                {
                    if (QueryNo == 101)
                    {
                        dgvDesign.DataSource = dtReturn;
                        Gridvalidations();
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


        public void Gridvalidations()
        {
            dgvDesign.Columns[0].DisplayIndex = 0;
            dgvDesign.Columns[1].DisplayIndex = 1;
            dgvDesign.Columns[2].DisplayIndex = 2;
            dgvDesign.Columns[3].DisplayIndex = 3;
            dgvDesign.Columns[4].DisplayIndex = 4;
            dgvDesign.Columns[11].DisplayIndex = 5;
            dgvDesign.Columns[15].DisplayIndex = 6;
            dgvDesign.Columns[5].DisplayIndex = 7;


            dgvDesign.Columns[6].Visible = dgvDesign.Columns[7].Visible = dgvDesign.Columns[8].Visible =
                dgvDesign.Columns[9].Visible = dgvDesign.Columns[10].Visible = dgvDesign.Columns[12].Visible = dgvDesign.Columns[13].Visible =
                dgvDesign.Columns[14].Visible = dgvDesign.Columns[16].Visible = false;

        }

        private void Dashboard_EmptyBeamOutward_Load(object sender, EventArgs e)
        {
            FillGrid(101);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Sizing.Empty_BeamOutward frm = new Sizing.Empty_BeamOutward();
            frm.newOrEdit = 0;
            frm.ShowDialog();
            FillGrid(101);

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvDesign.DataSource = bsOriginal;
                bs.DataSource = dgvDesign.DataSource;
                bs.Filter = string.Format("[ QUALITY ] like '%{0}%'", txtSearch.Text);
                dgvDesign.DataSource = bs;
                dgvDesign.Enabled = true;
                // btnClose.Enabled = true;
            }
            catch
            { }
        }
    }
}
