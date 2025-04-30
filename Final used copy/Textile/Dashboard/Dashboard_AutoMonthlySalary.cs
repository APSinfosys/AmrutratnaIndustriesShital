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
    public partial class Dashboard_AutoMonthlySalary : Form
    {
        public Dashboard_AutoMonthlySalary()
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
                hash.Add("@intcompanyId", fd.CompId);
                hash.Add("@inryearId", fd.YearId);
                //hash.Add("@dtpFromDate", dtpFrom.Value.ToString("MM/dd/yyyy"));
                //hash.Add("@dtpToDate", dtpTo.Value.ToString("MM/dd/yyyy"));

                dtReturn = ClsDefination.FillData("[Auto_SalaryDML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 101)
                    {
                        dgvSut.DataSource = dtReturn;
                        bsOriginal.DataSource = dtReturn;
                        dgvSut.Columns[6].Visible= false;
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            EmployeePayment.Employee_Payment frm = new EmployeePayment.Employee_Payment();
            frm.newOrEdit = 0;
            frm.ShowDialog();
            FillGrid(101);
        }

        private void Dashboard_AutoMonthlySalary_Load(object sender, EventArgs e)
        {
            FillGrid(101);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvSut.SelectedRows.Count > 0)
            {
                EmployeePayment.Employee_Payment frm = new EmployeePayment.Employee_Payment();
                frm.newOrEdit = 1;

               //         select SM.AES_Code as [CODE], SM.AES_FromDate as [FROM DATE], SM.AES_ToDate as [TO DATE], SM.AES_Month as [MONTH], 
               //LM.L_ShadeName+' - '+LM.L_ShadeLocation as [SHADE], SM.AES_TotalPayment as [TOTAL PAYMENT],SM.AES_Shade,
               //SM.UniqueCode as [UNIQUE CODE] 

                frm.lblSrNo.Text = dgvSut.CurrentRow.Cells[0].Value.ToString();
                frm.dtpFromDate.Text = dgvSut.CurrentRow.Cells[1].Value.ToString();
                frm.dtpTodate.Text = dgvSut.CurrentRow.Cells[2].Value.ToString();
                frm.lblGrandTotal.Text= dgvSut.CurrentRow.Cells[5].Value.ToString();
                frm.cmbSV = Convert.ToInt32(dgvSut.CurrentRow.Cells[6].Value.ToString());
                frm.lblUniqueCode.Text = dgvSut.CurrentRow.Cells[7].Value.ToString();
                frm.ShowDialog();
                FillGrid(101);
            }
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please select row to edit";
                frm.type = "error";
                frm.ShowDialog();
            }
        }
    }
}
