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
    public partial class Dashboard_Bank_Transaction : Form
    {
        public Dashboard_Bank_Transaction()
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
                if (QueryNo == 1017)
                {
                    hash.Add("@intCode", cmbAccount.SelectedValue);
                }

                DataTable dtReturn = ClsDefination.FillData("[Report_AllReport]", hash);

                if (dtReturn != null && dtReturn.Rows.Count > 0)
                {
                    DataRow dr = dtReturn.Rows[0];
                    if (QueryNo == 1017)
                    {
                        dgvParty.DataSource = dtReturn;
                        bsOriginal.DataSource = dtReturn;

                        dgvParty.Columns[9].Visible = false;
                        dgvParty.Columns[10].Visible = false;
                        dgvParty.Columns[11].Visible = false;
                        
                    }
                    else if (QueryNo == 107)
                    {
                        //, 

                        cmbAccount.DataSource = dtReturn;
                        cmbAccount.DisplayMember = "BankName";
                        cmbAccount.ValueMember = "Acc_Code";
                        cmbAccount.SelectedIndex = -1;
                        cmbAccount.Text = "<--SELECT-->";
                    }

                }
                else
                {
                    if (QueryNo == 1017)
                    {
                        dgvParty.DataSource = dtReturn;
                        
                        dgvParty.Columns[9].Visible = false;
                        dgvParty.Columns[10].Visible = false;
                        dgvParty.Columns[11].Visible = false;
                        
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



        private void Dashboard_Bank_Transaction_Load(object sender, EventArgs e)
        {
            FillGrid(107);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (cmbAccount.SelectedIndex > -1)
            {
                FillGrid(1017);
            }
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please Select Account";
                frm.type = "error";
                frm.ShowDialog();
            }
        }
    }
}
