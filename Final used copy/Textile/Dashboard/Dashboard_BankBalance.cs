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
    public partial class Dashboard_BankBalance : Form
    {
        public Dashboard_BankBalance()
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
                //if (QueryNo == 101)
                //{
                //    hash.Add("@intShade", cmbShade.SelectedValue);
                //}

                DataTable dtReturn = ClsDefination.FillData("[Report_AllReport]", hash);

                if (dtReturn != null && dtReturn.Rows.Count > 0)
                {
                    DataRow dr = dtReturn.Rows[0];
                    if (QueryNo == 1018)
                    {
                        dgvParty.DataSource = dtReturn;
                        bsOriginal.DataSource = dtReturn;
                    }

                }
                else
                {
                    if (QueryNo == 1018)
                    {
                        dgvParty.DataSource = dtReturn;
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


        private void Dashboard_BankBalance_Load(object sender, EventArgs e)
        {

            FillGrid(1018);
        }
    }
}
