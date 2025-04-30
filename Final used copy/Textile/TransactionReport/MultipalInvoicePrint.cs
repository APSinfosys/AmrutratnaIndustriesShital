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

namespace Textile.TransactionReport
{
    public partial class MultipalInvoicePrint : Form
    {
        public MultipalInvoicePrint()
        {
            InitializeComponent();
        }

        #region ------------------------Variable Declaration------------------
        ClassFiles.CommonFunction common = new ClassFiles.CommonFunction();
        Accounting.Classes.functionalDetails fd = new Accounting.Classes.functionalDetails();
        DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();

        public Int32 intReturnPKNo, visibilityBtndateMonthCriteria,
            count, QuerySearch, btnVisibleCriteria,
            labelVisibleCriteria, SearchState, ComboQuery, TotalVisibleCriteria
            , GroupIndex, GroupSumColumn1, GroupSumColumn2, GroupSumColumn3, GroupSumColumn4, GroupSumColumn5;
        Hashtable hash = new Hashtable();
        #endregion

        #region LoadCombobox
        void ComboLoad(int Query)
        {

            hash = new Hashtable();
            // Criteria();
            hash.Add("@QueryNo", Query);

            hash.Add("@intCompanyId", fd.CompId);
            hash.Add("@intYearId", fd.YearId);

            if (Query == 10001)
            {
                hash.Add("@intFrom", Convert.ToInt32(txtFrom.Text));
                hash.Add("@intTo", Convert.ToInt32(txtTo.Text));
                hash.Add("@intFromParty", cmbFirm.SelectedValue);

            }

            DataTable dtReturn = ClsDefination.FillData("[Report_AllReport]", hash);

            if (dtReturn.Rows.Count > 0 || dtReturn == null)
            {

                if (Query == 1020)
                {
                    CBPartyName.DataSource = dtReturn;
                    CBPartyName.DisplayMember = "P_CompanyName";
                    CBPartyName.ValueMember = "P_Code";
                    CBPartyName.SelectedIndex = -1;
                    CBPartyName.Text = "<Select>";
                }
                else if (Query == 10001)
                {
                    dgvDetails.DataSource = dtReturn;
                }
                else if (Query == 106)
                {
                    cmbFirm.DataSource = dtReturn;
                    cmbFirm.DisplayMember = "F_CompanyName";
                    cmbFirm.ValueMember = "F_Code";
                    cmbFirm.SelectedIndex = -1;
                    cmbFirm.Text = "<--Select-->";
                }
                else if (Query == 21)//-- Supplier Master--Developer-Ranjeet--Date-13/12/2014 10:45 PM
                {
                    CBPartyName.DataSource = dtReturn;
                    CBPartyName.ValueMember = "ID";
                    CBPartyName.DisplayMember = "AccountName";
                    CBPartyName.Text = "<Select>";

                }
                else if (Query == 9)//customer id
                {
                    CBPartyName.DataSource = dtReturn;
                    CBPartyName.ValueMember = "CustID";
                    CBPartyName.DisplayMember = "Customer Name";
                    CBPartyName.Text = "<Select>";



                }
                else if (Query == 19) //customer n suplier common combo
                {
                    CBPartyName.DataSource = dtReturn;
                    CBPartyName.ValueMember = "ID";
                    CBPartyName.DisplayMember = "Name";
                    CBPartyName.Text = "<Select>";



                }
                else if (Query == 31) // suplier combo
                {
                    CBPartyName.DataSource = dtReturn;
                    CBPartyName.ValueMember = "ID";
                    CBPartyName.DisplayMember = "Name";
                    CBPartyName.Text = "<Select>";



                }
                else if (Query == 32) //customer combo
                {
                    CBPartyName.DataSource = dtReturn;
                    CBPartyName.ValueMember = "ID";
                    CBPartyName.DisplayMember = "Name";
                    CBPartyName.Text = "<Select>";



                }
                else

                    if (Query == 10)//-- Supplier Master--Developer-Ranjeet--Date-13/12/2014 10:45 PM
                    {
                        CBPartyName.DataSource = dtReturn;
                        CBPartyName.ValueMember = "SupID";
                        CBPartyName.DisplayMember = "SupplierName";
                        CBPartyName.Text = "<Select>";

                    }


                //else if (Query == 14)//Load Product Name
                //{
                //    cmbProductName.DataSource = dtReturn;
                //    cmbProductName.DisplayMember = "Product Name";
                //    cmbProductName.ValueMember = "ProductId";
                //    cmbProductName.Text = "<Select>";
                //}
                //else if (Query == 15)//-- Supplier Master--Developer-Ranjeet--Date-13/12/2014 10:45 PM
                //{
                //    CmbRoute.DataSource = dtReturn;
                //    CmbRoute.ValueMember = "ID";
                //    CmbRoute.DisplayMember = "CommonName";
                //    CmbRoute.Text = "<Select>";

                //}



            }
            else
            {
                if (Query == 9)
                {
                    CBPartyName.DataSource = null;
                    CBPartyName.Text = "<Select>";
                    CBPartyName.ValueMember = "0";
                }
                else
                    if (Query == 10)//Party Name
                    {
                        CBPartyName.DataSource = null;
                        CBPartyName.Text = "<Select>";
                        CBPartyName.ValueMember = "0";

                    }

                    else if (Query == 14)//Product Name
                    {
                        //cmbProductName.DataSource = null;
                        //cmbProductName.Text = "<Select>";
                        //cmbProductName.ValueMember = "0";

                    }
                    else if (Query == 106)
                    {
                        cmbFirm.DataSource = dtReturn;
                        cmbFirm.SelectedIndex = -1;
                        cmbFirm.Text = "<--No Record-->";
                    }

            }
        }
        #endregion
        private void MultipalInvoicePrint_Load(object sender, EventArgs e)
        {
            ComboLoad(106);
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            ComboLoad(10001);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtFrom.Text = txtTo.Text = "";
            cmbFirm.SelectedIndex = -1;
            cmbFirm.Text = "<--SELECT-->";
            dgvDetails.DataSource = null;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

                for (int i = 0; i < dgvDetails.Rows.Count; i++)
                {

                    if (Convert.ToBoolean(dgvDetails.Rows[i].Cells[0].Value) == true)
                    {

                        ClsDefination.Readpath();

                        common.BillNo = Convert.ToInt32(dgvDetails.Rows[i].Cells[1].Value.ToString());
                        common.supplierId = Convert.ToInt32(cmbFirm.SelectedValue);
                        common.yearID = fd.YearId;
                        common.companyId = fd.CompId;
                        common.server = ClsDefination.server;
                        common.dbname = ClsDefination.database;
                        common.username = ClsDefination.id;
                        common.password = ClsDefination.password;
                        common.reportPath = ClsDefination.CrystalPath;

                        common.PrintDirect(1008);
                    }
             
                //TransactionReport.CRTransaction frm = new TransactionReport.CRTransaction();


                //frm.QueryNo = 1008;
                //frm.server = ClsDefination.server;
                //frm.dbname = ClsDefination.database;
                //frm.username = ClsDefination.id;
                //frm.password = ClsDefination.password;
                //frm.reportPath = ClsDefination.CrystalPath;

                //frm.intCompanyID = fd.CompId;

                //frm.intYearID = fd.YearId;
                //frm.VoucherId = Convert.ToInt32(dgvDetails.Rows[i].Cells[1].Value.ToString());
                //frm.intSupplierId = Convert.ToInt32(cmbFirm.SelectedValue);
                //frm.ShowDialog();


            }

 
        }
    }
}
