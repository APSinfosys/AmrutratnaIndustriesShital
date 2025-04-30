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
    public partial class Dashboard_YarnSales : Form
    {
        public Dashboard_YarnSales()
        {
            InitializeComponent();
        }


        #region variables
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        BindingSource bs = new BindingSource();
        BindingSource bsOriginal = new BindingSource();
        BindingSource bs1 = new BindingSource();
        BindingSource bsOriginal1 = new BindingSource();
        public string UserName, yearString, companyNameStr, groupNmae, PeriodName;
        public int userId, compId, yearId, GroupId, otherPg, cmbValue, cmbTT, formType;
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
                hash.Add("@intCompanyId", Convert.ToInt32(fd.CompId));
                hash.Add("@intYearId", Convert.ToInt32(fd.YearId));



                dtReturn = ClsDefination.FillData("[Transaction_YarnSales_DML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 101)
                    {
                        dgvDesign.DataSource = dtReturn;
                        bsOriginal.DataSource = dtReturn;
                        bsOriginal1.DataSource = dtReturn;
                        dgvDesign.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        for (int i = 12; i < 20; i++)
                        {
                            dgvDesign.Columns[i].Visible = false;
                        }
                    }

                }
                else
                {
                    if (QueryNo == 101)
                    {
                        dgvDesign.DataSource = dtReturn;

                        for (int i = 12; i < 20; i++)
                        {
                            dgvDesign.Columns[i].Visible = false;
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


        #region savedata()
        //--------------- Savedata() -------------------------------------------------

        public DataSet SaveData(int QueryNo, ref string strReturnMSG, ref string strReturnNo, ref Int32 intReturnNo)//string strReturn    DataSet
        {
            try
            {
                strReturnMSG = "0";
                strReturnNo = "0";
                intReturnNo = 0;

                okflag = 0;
                hash = new Hashtable();


                hash.Add("@QueryNo", QueryNo);
                hash.Add("@intcreatedBy", fd.UserId);
                hash.Add("@intCompanyId", fd.CompId);
                hash.Add("@intYearId", fd.YearId);

                if (QueryNo == 3)
                {
                    hash.Add("@strUniqueCode", dgvDesign.CurrentRow.Cells[0].Value.ToString());
                    hash.Add("@intInvoiceNo", Convert.ToInt32(dgvDesign.CurrentRow.Cells[1].Value.ToString()));
                }

                okflag = 1;
                return ClsDefination.InsertExecute(hash, "[Transaction_YarnSales_DML]", ref strReturnMSG, ref strReturnNo, ref intReturnNo);
            }
            catch (Exception Ex)
            {
                if (okflag == 0)
                {
                    MessageBox.Show("Enter proper data " + Ex);
                }
                return null;
                throw;
            }
        }

        //----------------------------------------------------------------------------

        #endregion

        private void Dashboard_YarnSales_Load(object sender, EventArgs e)
        {  
            FillGrid(101);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Yarn.Transaction_YarnSales frm = new Yarn.Transaction_YarnSales();
            frm.newOrEdit = 0;
            frm.ShowDialog();
            FillGrid(101);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvDesign.SelectedRows.Count > 0)
            {
                Yarn.Transaction_YarnSales frm = new Yarn.Transaction_YarnSales();
                frm.newOrEdit = 1;

                frm.lblUniqueCode.Text = dgvDesign.CurrentRow.Cells[0].Value.ToString();
                frm.txtInvoiceNo.Text = dgvDesign.CurrentRow.Cells[1].Value.ToString();
                frm.dtpInvoicedate.Text = dgvDesign.CurrentRow.Cells[2].Value.ToString();

                //                  TYS.UniqueCode as [UNIQUE CODE],TYS.InvoiceNo as [INVOICE NO], TYS.date as [DATE],  2

                frm.cmbSupplier.Text = dgvDesign.CurrentRow.Cells[3].Value.ToString();
                frm.cmbTaxable.Text = dgvDesign.CurrentRow.Cells[4].Value.ToString();
                frm.cmbFirmName.Text = dgvDesign.CurrentRow.Cells[5].Value.ToString();
                //MP.P_CompanyName as [TO PARTY],CV.Common_Value as [IS TAXABLE],FM.F_CompanyName as [FIRM NAME], 5

                frm.cmbShadeName.Text = dgvDesign.CurrentRow.Cells[6].Value.ToString();
                frm.lblTaxableValue.Text = dgvDesign.CurrentRow.Cells[7].Value.ToString();
                //LM.L_ShadeName as [SHADE],TYS.totalTaxable as [TAXABLE AMOUNT], 7

                frm.lblGSTAmt.Text = dgvDesign.CurrentRow.Cells[8].Value.ToString();
                frm.txtAdd.Text = dgvDesign.CurrentRow.Cells[9].Value.ToString();
                frm.txtROFF.Text = dgvDesign.CurrentRow.Cells[10].Value.ToString();
                //TYS.totalGST as [TOTAL GST], TYS.other as [OTHER], TYS.roff as [R / OFF],  10

                frm.lblGrandTotalAmt.Text = dgvDesign.CurrentRow.Cells[11].Value.ToString();
                //TYS.GrandTotal as [INVOICE AMOUNT], 11

                frm.cmbSuppliverV = Convert.ToInt32(dgvDesign.CurrentRow.Cells[12].Value.ToString());
                frm.cmbTaxableV = Convert.ToInt32(dgvDesign.CurrentRow.Cells[13].Value.ToString());
                frm.cmbFirmV = Convert.ToInt32( dgvDesign.CurrentRow.Cells[14].Value.ToString());
                frm.cmbShadeV=Convert.ToInt32(dgvDesign.CurrentRow.Cells[15].Value.ToString());
                frm.lblCGSTAmount.Text = dgvDesign.CurrentRow.Cells[16].Value.ToString();
                //TYS.party, TYS.isTaxable, TYS.fromFirm, TYS.shade,  TYS.totalCgst,  16

                frm.lblSGSTAmount.Text = dgvDesign.CurrentRow.Cells[17].Value.ToString();
                frm.lblIGSTAmount.Text = dgvDesign.CurrentRow.Cells[18].Value.ToString();
                frm.lblSrNo.Text = dgvDesign.CurrentRow.Cells[19].Value.ToString();
                //TYS.totalSgst, TYS.totalIgst, TYS.InvoiceCode 19
                frm.ShowDialog();
                FillGrid(101);
            }
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please select record for update";

                frm.type = "error";
                frm.ShowDialog();

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDesign.SelectedRows.Count > 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the record?", "Delete record", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        SaveData(3, ref strReturnMSG, ref strReturnRefNo, ref intReturnPKNo);

                        if (okflag == 1)
                        {
                            if (intReturnPKNo == 0)
                            {
                                messageBox frm = new messageBox();
                                frm.messageTxt = strReturnMSG;
                                frm.type = "error";
                                frm.ShowDialog();
                            }
                            else
                            {
                                messageBox frm = new messageBox();
                                frm.messageTxt = "Rocord Deleted Successfully: ";// +strReturnMSG;
                                frm.type = "success";
                                frm.ShowDialog();
                                FillGrid(101);
                            }
                        }
                    }
                }
                else
                {
                    messageBox frm = new messageBox();
                    frm.messageTxt = "Please select record to delete";
                    frm.type = "error";
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Something went wrong please try again or call Administrator";
                frm.type = "error";
                frm.ShowDialog();
            }
        }
    }
}
