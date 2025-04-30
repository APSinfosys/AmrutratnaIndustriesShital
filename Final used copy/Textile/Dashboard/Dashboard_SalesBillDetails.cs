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
    public partial class Dashboard_SalesBillDetails : Form
    {
        public Dashboard_SalesBillDetails()
        {
            InitializeComponent();
        }

        #region Variable
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        BindingSource bs = new BindingSource();
        BindingSource bsOriginal = new BindingSource();
        public string UserName, yearString, companyNameStr;
        public int userId, compId, yearId, GroupId = 0, otherPg;
        string strReturnMSG, strReturnRefNo, sp;
        int intReturnPKNo;
        int result, deletefrm;
        public int newOrEdit = 0;

        #endregion

        #region Fill Grid
        public DataTable FillGrid(int QueryNo)
        {
            try
            {
                hash = new Hashtable();

                hash.Add("@QueryNo", QueryNo);
                hash.Add("@intCompanyId", fd.CompId);
                hash.Add("@intYearId", fd.YearId);

                if (QueryNo == 10002 || QueryNo == 10003)
                {
                    hash.Add("@intFromParty",cmbParty.SelectedValue);
                    hash.Add("@dtpFromDate",dtpFromDate.Value.ToString("MM/dd/yyyy"));
                    hash.Add("@dtpToDate",dtpToDate.Value.ToString("MM/dd/yyyy"));
                }

                DataTable dtReturn = ClsDefination.FillData("[Report_AllReport]", hash);

                if (dtReturn != null && dtReturn.Rows.Count > 0)
                {
                    DataRow dr = dtReturn.Rows[0];
                    if (QueryNo == 10002 || QueryNo == 10003)
                    {
                        dgvSut.DataSource = dtReturn;
                    }
                    else if (QueryNo == 106)
                    {
                        cmbParty.DataSource = dtReturn;
                        cmbParty.DisplayMember = "F_CompanyName";
                        cmbParty.ValueMember = "F_Code";
                        cmbParty.SelectedIndex = -1;
                        cmbParty.Text = "<--SELECT-->";
                    }
                }
                else
                {
                    if (QueryNo == 101 || QueryNo == 10002 || QueryNo == 10003)
                    {
                        dgvSut.DataSource = dtReturn;
                    }
                    else if (QueryNo == 106)
                    {
                        cmbParty.DataSource = dtReturn;
                        cmbParty.SelectedIndex = -1;
                        cmbParty.Text = "<--NO RECORD-->";
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

        private void Dashboard_SalesBillDetails_Load(object sender, EventArgs e)
        {
            FillGrid(106);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cmbParty.SelectedIndex > -1)
            {
                if (rbSalesDetailsTDS.Checked == true)
                {
                    FillGrid(10002);
                    dgvSut.Columns[0].Visible = false;
                    dgvSut.Columns[9].Visible = false;
                    dgvSut.Columns[10].Visible = false;
                    dgvSut.Columns[11].Visible = false;
                }
                else if (rbBillDetails.Checked == true)
                {
                    FillGrid(10003);
                    dgvSut.Columns[3].Visible = false;
                    dgvSut.Columns[11].Visible = false;
                    dgvSut.Columns[12].Visible = false;
                    dgvSut.Columns[13].Visible = false;
                    dgvSut.Columns[14].Visible = false;
                    dgvSut.Columns[15].Visible = false;
                }
                else if (rbOutstanding.Checked == true)
                {
                    FillGrid(10003);
                    dgvSut.Columns[3].Visible = true;
                    dgvSut.Columns[11].Visible = true;
                    dgvSut.Columns[12].Visible = true;
                    dgvSut.Columns[13].Visible = false;
                    dgvSut.Columns[14].Visible = false;
                    dgvSut.Columns[15].Visible = false;
                }
            }
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please Select Firm";
                frm.type = "error";
                frm.ShowDialog();
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dtpFromDate.Text=dtpToDate.Text = System.DateTime.Now.ToString();
            FillGrid(106);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (cmbParty.SelectedIndex > -1)
            {

                TransactionReport.CRTransaction frm = new TransactionReport.CRTransaction();

                ClsDefination.Readpath();


                frm.server = ClsDefination.server;
                frm.dbname = ClsDefination.database;
                frm.username = ClsDefination.id;
                frm.password = ClsDefination.password;
                frm.reportPath = ClsDefination.CrystalPath;
                frm.sdtFromDate = dtpFromDate.Value.ToString("MM/dd/yyyy");
                frm.sdtToDate = dtpToDate.Value.ToString("MM/dd/yyyy");
                frm.intFirm = Convert.ToInt32(cmbParty.SelectedValue);
                              
                //frm.intCompanyID = fd.CompId;

                //frm.intYearID = fd.YearId;
                //frm.VoucherId = Convert.ToInt32(dgvSut.CurrentRow.Cells[13].Value.ToString());
                //frm.intSupplierId = Convert.ToInt32(dgvSut.CurrentRow.Cells[39].Value.ToString());
                

                if (rbSalesDetailsTDS.Checked == true)
                {
                    //FillGrid(10002);
                    frm.QueryNo = 10002;
                    //ChequeTdsDetails
                }
                else if (rbBillDetails.Checked == true)
                {
                    frm.QueryNo = 10003;
                    frm.intNewFormType = 1;
                    //FillGrid(10003);
                    //BillDetails
                }
                else if (rbOutstanding.Checked == true)
                {
                    frm.QueryNo = 10003;
                    frm.intNewFormType = 2;
                    //FillGrid(10003);
                    //Outstanding
                }

                frm.ShowDialog();

            }
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please Select Firm";
                frm.type = "error";
                frm.ShowDialog();
            }

        }


    }
}
