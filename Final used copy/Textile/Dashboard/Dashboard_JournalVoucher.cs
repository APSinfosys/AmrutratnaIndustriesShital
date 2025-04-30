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
    public partial class Dashboard_JournalVoucher : Form
    {
        public Dashboard_JournalVoucher()
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

        public DataTable FillGrid(int QueryNo)
        {
            try
            {
                hash = new Hashtable();

                hash.Add("@QueryNo", QueryNo);
                hash.Add("@intCompanyId", fd.CompId);
                hash.Add("@intYearId", fd.YearId);

                DataTable dtReturn = ClsDefination.FillData("[Transaction_JournalVoucher_DML]", hash);

                if (dtReturn != null && dtReturn.Rows.Count > 0)
                {
                    DataRow dr = dtReturn.Rows[0];
                    if (QueryNo == 101)
                    {
                        dgvDesign.DataSource = dtReturn;
                        bsOriginal.DataSource = dtReturn; 

                        dgvDesign.Columns[12].Visible = false;
                        dgvDesign.Columns[13].Visible = false;
                        dgvDesign.Columns[14].Visible = false;
                        dgvDesign.Columns[15].Visible = false;
                        dgvDesign.Columns[16].Visible = false;
     //                   JV.UniqueCode as [UNIQUE CODE], 
     //JV.Jv_Code as [CODE], JV.Date as [DATE], CV1.Common_Value as [TYPE OF PAYMENT] ,
     //LM.L_ShadeName+'-'+LM.L_ShadeLocation as [SHADE],EM.Name as [NAME],
     //JV.amount as [AMOUNT],CV2.Common_Value as [PAID BY],
     //JV.chequeNo as [CHEQUE NO], JV.chequeDate as [CHEQUE DATE],AM.BankName as [ACCOUNT NAME] ,JV.note as [NOTE], 11
     //JV.TypeOfPayment,  JV.shade, JV.name,
     //JV.paidBy,  JV.bankId
                    }

                }
                else
                {
                    if (QueryNo == 101)
                    {
                        dgvDesign.DataSource = dtReturn;
                        bsOriginal.DataSource = dtReturn;
                        dgvDesign.Columns[12].Visible = false;
                        dgvDesign.Columns[13].Visible = false;
                        dgvDesign.Columns[14].Visible = false;
                        dgvDesign.Columns[15].Visible = false;
                        dgvDesign.Columns[16].Visible = false;
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


        private void btnNew_Click(object sender, EventArgs e)
        {
            TransactionForms.Transaction_JournalVoucher frm = new TransactionForms.Transaction_JournalVoucher();
            frm.newOrEdit = 0;
            frm.ShowDialog();
            FillGrid(101);
        }

        private void Dashboard_JournalVoucher_Load(object sender, EventArgs e)
        {
            FillGrid(101);
        }
    }
}
