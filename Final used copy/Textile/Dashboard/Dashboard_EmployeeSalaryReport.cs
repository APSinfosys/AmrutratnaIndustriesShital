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
    public partial class Dashboard_EmployeeSalaryReport : Form
    {
        public Dashboard_EmployeeSalaryReport()
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
                hash.Add("@intYearId",Convert.ToInt32(fd.YearId));
                if (QueryNo == 1001)
                {
                    hash.Add("@dtpFromDate", dtpFrom.Value.ToString("MM/dd/yyyy"));
                    hash.Add("@dtpToDate", dtpTo.Value.ToString("MM/dd/yyyy"));
                    hash.Add("@intShade", Convert.ToInt32(cmbShade.SelectedValue));
                }
                dtReturn = ClsDefination.FillData("[Report_AllReport]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 1001)
                    {
                        dgvSut.DataSource = dtReturn;
                        bsOriginal.DataSource = dtReturn;
                        
                       // dgvSut.Columns[4].Visible= false;
                        //for (int i = 0; i < dgvSut.Rows.Count; i++)
                        //{
                        //    if (Convert.ToDecimal(dgvSut.Rows[i].Cells[6].Value) <= 0)
                        //    {
                        //        dgvSut.Rows[i].Visible = false;
                        //    }
                        //}
                    }
                    else if (QueryNo == 104)
                    {
                        cmbShade.DataSource = dtReturn;
                        cmbShade.DisplayMember = "Shade";
                        cmbShade.ValueMember = "L_Code";
                        cmbShade.SelectedIndex = -1;
                        cmbShade.Text = "<--SELECT-->";
                        btnCalc.Enabled = true;
                    }

                }
                else
                {
                    if (QueryNo == 101)
                    {
                        dgvSut.DataSource = null;

                    }
                    else if (QueryNo == 104)
                    {
                        cmbShade.DataSource = dtReturn;
                        cmbShade.SelectedIndex = -1;
                        cmbShade.Text = "<--NO RECORD-->";
                        btnCalc.Enabled = false;
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



        private void Dashboard_EmployeeSalaryReport_Load(object sender, EventArgs e)
        {
            FillGrid(104);
            //FillGrid(1001);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbShade.SelectedValue) < 0)
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please select shade";
                frm.type = "error";
                frm.ShowDialog();
            }
            else
            {
                FillGrid(1001);
            }
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSut.SelectedRows.Count > 0)
                {
                    SalaryPayments frm = new SalaryPayments();
                    frm.newOrEdit = 0;
                    frm.frmCode = 1;
                    frm.lblEmpCode.Text = dgvSut.CurrentRow.Cells[0].Value.ToString();
                    frm.txtEmployeeName.Text = dgvSut.CurrentRow.Cells[1].Value.ToString();
                    frm.lblLocationName.Text = cmbShade.Text;
                    frm.lblLocationCode.Text = cmbShade.SelectedValue.ToString();
                    frm.dtpFromDate.Text = dtpFrom.Value.ToString("MM/dd/yyyy");
                    frm.dtpToDate.Text = dtpTo.Value.ToString("MM/dd/yyyy");
                    frm.lblSalaryAmt.Text = dgvSut.CurrentRow.Cells[2].Value.ToString();
                    //frm.lblAdvanceBalAmt.Text= dgvSut.CurrentRow.Cells[4].Value.ToString();
                   // frm.lblBakiBalanceAmt.Text = dgvSut.CurrentRow.Cells[5].Value.ToString();
                    frm.lblSalaryMonth.Text = "SALARY FROM";
                    frm.ShowDialog();
                    FillGrid(1001);
                }
                else
                {
                    messageBox frm = new messageBox();
                    frm.messageTxt = "Please select employee to pay";
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
    }
}
