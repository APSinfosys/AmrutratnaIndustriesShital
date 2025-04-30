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
    public partial class Dashboard_LoomMaster : Form
    {
        public Dashboard_LoomMaster()
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
                hash.Add("@intcompanyId", fd.CompId);

                dtReturn = ClsDefination.FillData("[Master_LoomDML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 101)
                    {
                        dgvSut.DataSource = dtReturn;
                        bsOriginal.DataSource = dtReturn;
                        dgvSut.Columns[5].Visible = false;

                        dgvSut.Columns[6].DisplayIndex = 0;

                        for(int i=0;i<6;i ++)
                        {
                            dgvSut.Columns[i].DisplayIndex = i+1;
                        }

                    }

                }
                else
                {
                    if (QueryNo == 101)
                    {
                        dgvSut.DataSource = null;

                        dgvSut.Columns[5].Visible = false;

                        dgvSut.Columns[6].DisplayIndex = 0;

                        for (int i = 0; i < 6; i++)
                        {
                            dgvSut.Columns[i].DisplayIndex = i + 1;
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

        private void Dashboard_LoomMaster_Load(object sender, EventArgs e)
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
            Masters.LoomMaster frm = new Masters.LoomMaster();
            frm.newOrEdit = 0;
            frm.ShowDialog();
            FillGrid(101);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSut.SelectedRows.Count > 0)
                {
                    Masters.LoomMaster frm = new Masters.LoomMaster();
                    frm.newOrEdit = 1;
                    frm.lblSrNo.Text = dgvSut.CurrentRow.Cells[0].Value.ToString();
                    frm.txtShadeName.Text = dgvSut.CurrentRow.Cells[1].Value.ToString();
                    frm.txtShadeLocetion.Text = dgvSut.CurrentRow.Cells[2].Value.ToString();
                    frm.cmbLoomType.Text = dgvSut.CurrentRow.Cells[3].Value.ToString();
                    frm.txtNoOfLoom.Text = dgvSut.CurrentRow.Cells[4].Value.ToString();
                    frm.cmbLTV = Convert.ToInt32(dgvSut.CurrentRow.Cells[5].Value.ToString());
                    frm.lblUniqueCode.Text = dgvSut.CurrentRow.Cells[6].Value.ToString();
                    frm.ShowDialog();
         //                    LM.L_Code as [CODE], LM.L_ShadeName as [SHADE], LM.L_ShadeLocation as [LOCATION], 
         //LM.L_TYpe as [LOOM TYPE], LM.L_NoOfLooms as [NO OF LOOMS],LM.L_TypeCode
         //                    L_Code as [CODE], L_ShadeName as [SHADE], L_ShadeLocation as [LOCATION], 
         //L_TYpe as [LOOM TYPE], L_NoOfLooms as [NO OF LOOMS]
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
    }
}
