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
    public partial class Dashboard_EmpSalReportAuto : Form
    {
        public Dashboard_EmpSalReportAuto()
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
                hash.Add("@intCompanyId", Convert.ToInt32(fd.CompId));
                hash.Add("@intYearId", Convert.ToInt32(fd.YearId));

                if (QueryNo == 103)
                {
                    hash.Add("@intShade", Convert.ToInt32(cmbShade.SelectedValue));
                }
                if (QueryNo == 1005)
                {
                    hash.Add("@intCode",Convert.ToInt32(cmbMonth.SelectedValue));
                }
                dtReturn = ClsDefination.FillData("[Report_AllReport]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 102)
                    {
                        cmbShade.DataSource = dtReturn;
                        cmbShade.DisplayMember = "Shade";
                        cmbShade.ValueMember = "L_Code";
                        cmbShade.SelectedIndex = -1;
                        cmbShade.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 103)
                    {
                        cmbMonth.DataSource = dtReturn;
                        cmbMonth.DisplayMember = "AES_Month";
                        cmbMonth.ValueMember = "AES_Code";
                        cmbMonth.SelectedIndex = -1;
                        cmbMonth.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 1005)
                    {
                        dgvSut.DataSource = dtReturn;

                        for (int i = 0; i < dgvSut.Rows.Count; i++)
                        {
                            if (Convert.ToInt32( dgvSut.Rows[i].Cells[22].Value) == 1)
                            {
                                dgvSut.Rows[i].DefaultCellStyle.BackColor = Color.DarkCyan;
                            }
                        }
                    }
                }
                else
                {
                    if (QueryNo == 102)
                    {
                        cmbShade.DataSource = dtReturn;
                        cmbShade.SelectedIndex = -1;
                        cmbShade.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 103)
                    {
                        cmbMonth.DataSource = dtReturn;
                        cmbMonth.SelectedIndex = -1;
                        cmbMonth.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 1005)
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




        private void Dashboard_EmpSalReportAuto_Load(object sender, EventArgs e)
        {
            FillGrid(102);
            cmbMonth.Text = "<--SELECT-->";
        }

        private void cmbShade_Leave(object sender, EventArgs e)
        {
            FillGrid(103);
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32( cmbShade.SelectedValue)<0 || cmbShade.SelectedValue==null)
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please select shade";
                frm.type = "error";
                frm.ShowDialog();
                cmbShade.Focus();
            }
            else if (Convert.ToInt32( cmbMonth.SelectedValue)<0 || cmbMonth.SelectedValue==null)
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please select month";
                frm.type = "error";
                frm.ShowDialog();
                cmbMonth.Focus();
            }
            else
            {
                FillGrid(1005);
            }
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSut.SelectedRows.Count > 0)
                {
                    if (Convert.ToInt32(dgvSut.CurrentRow.Cells[22].Value) == 0)
                    {
                        SalaryPayments frm = new SalaryPayments();
                        frm.lblEmpCode.Text = dgvSut.CurrentRow.Cells[0].Value.ToString();
                        frm.txtEmployeeName.Text = dgvSut.CurrentRow.Cells[1].Value.ToString();
                        frm.lblLocationName.Text = cmbShade.Text;
                        frm.lblLocationCode.Text = cmbShade.SelectedValue.ToString();
                        frm.lblSalaryAmt.Text = dgvSut.CurrentRow.Cells[3].Value.ToString();
                        frm.lblMonth.Text = cmbMonth.Text;
                        frm.lblMonthCode.Text = cmbMonth.SelectedValue.ToString();
                        frm.ShowDialog();
                        FillGrid(1005);
                    }
                    else
                    {
                        messageBox frm = new messageBox();
                        frm.messageTxt = "Salary allready paid to this employee";
                        frm.type = "error";
                        frm.ShowDialog();
                    }
                }
                else
                {
                    messageBox frm = new messageBox();
                    frm.messageTxt = "Please select employee";
                    frm.type = "error";
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            if (cmbShade.SelectedIndex != -1 && cmbMonth.SelectedIndex != -1)
            {

                TransactionReport.CRTransaction frmT = new TransactionReport.CRTransaction();

                ClsDefination.Readpath();

                frmT.intCompanyID = 0;

                frmT.intYearID = 0;
                frmT.intPartyNo = 0;     //Convert.ToInt32(dgvSut.CurrentRow.Cells[14].Value.ToString());
                frmT.intGodownid = 0;//Convert.ToInt32(dgvSut.CurrentRow.Cells[39].Value.ToString());
                
                frmT.QueryNo = 4001;
                frmT.server = ClsDefination.server;
                frmT.dbname = ClsDefination.database;
                frmT.username = ClsDefination.id;
                frmT.password = ClsDefination.password;
                frmT.reportPath = ClsDefination.CrystalPath;

                frmT.intCompanyID = fd.CompId;

                frmT.intYearID = fd.YearId;
                frmT.intPartyNo = Convert.ToInt32(cmbShade.SelectedValue);     //Convert.ToInt32(dgvSut.CurrentRow.Cells[14].Value.ToString());
                frmT.intGodownid = Convert.ToInt32(cmbMonth.SelectedValue);//Convert.ToInt32(dgvSut.CurrentRow.Cells[39].Value.ToString());
                frmT.ShowDialog();
            }
        }
    }
}
