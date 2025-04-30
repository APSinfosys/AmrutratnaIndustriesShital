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
    public partial class Dashboard_SutMaster : Form
    {
        public Dashboard_SutMaster()
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

                dtReturn = ClsDefination.FillData("[Sut_DML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 101)
                    {
                        dgvSut.DataSource = dtReturn;
                        bsOriginal.DataSource = dtReturn;
                        dgvSut.Columns[5].DisplayIndex = 0;

                        for (int i = 0; i < 5; i++)
                        {
                            dgvSut.Columns[i].DisplayIndex = i+1;

                        }

                        dgvSut.Columns[6].Visible = dgvSut.Columns[7].Visible = dgvSut.Columns[8].Visible = dgvSut.Columns[9].Visible = false;
                    }

                }
                else
                {
                    if (QueryNo == 101)
                    {
                        dgvSut.DataSource = null;

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

        private void Dashboard_SutMaster_Load(object sender, EventArgs e)
        {
            FillGrid(101);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Masters.SutMaster frm = new Masters.SutMaster();
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
                    Masters.SutMaster frm = new Masters.SutMaster();
                    frm.newOrEdit = 1;
                    frm.lblSrNo.Text = dgvSut.CurrentRow.Cells[0].Value.ToString();
                    frm.txtSutName.Text = dgvSut.CurrentRow.Cells[1].Value.ToString();
                    frm.txtCGST.Text = dgvSut.CurrentRow.Cells[2].Value.ToString();
                    frm.txtSGST.Text = dgvSut.CurrentRow.Cells[3].Value.ToString();
                    frm.txtIGST.Text = dgvSut.CurrentRow.Cells[4].Value.ToString();
                    frm.lblUniqueCode.Text = dgvSut.CurrentRow.Cells[5].Value.ToString();
                    frm.cmbGroupName.SelectedValue = frm.GroupId= Convert.ToInt32( dgvSut.CurrentRow.Cells[6].Value.ToString());
                    frm.cmbGroupName.Text = dgvSut.CurrentRow.Cells[7].Value.ToString();
                    frm.txtCount.Text = dgvSut.CurrentRow.Cells[8].Value.ToString();
                    frm.txtMillName.Text = dgvSut.CurrentRow.Cells[9].Value.ToString();
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
                dgvSut.DataSource = bsOriginal;
                bs.DataSource = dgvSut.DataSource;
                bs.Filter = string.Format("[SUT NAME] like '%{0}%'", txtSearch.Text);
                dgvSut.DataSource = bs;
                dgvSut.Enabled = true;
                // btnClose.Enabled = true;
            }
            catch
            { }
        }

        private void btnOpeningStock_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSut.SelectedRows.Count > 0)
                {
                    Textile.Sock.SutOpeningStock frm = new Sock.SutOpeningStock();
                    frm.newOrEdit = 0;
                    frm.lblSrNo.Text = dgvSut.CurrentRow.Cells[0].Value.ToString();
                    frm.lblSutNameValue.Text = dgvSut.CurrentRow.Cells[1].Value.ToString();
                    frm.lblUniqueCode.Text = dgvSut.CurrentRow.Cells[5].Value.ToString();
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
