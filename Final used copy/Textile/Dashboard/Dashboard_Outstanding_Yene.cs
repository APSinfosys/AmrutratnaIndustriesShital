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
    public partial class Dashboard_Outstanding_Yene : Form
    {
        public Dashboard_Outstanding_Yene()
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
                hash.Add("@intcompanyId", fd.CompId);
                hash.Add("@inryearId", fd.YearId);

                DataTable dtReturn = ClsDefination.FillData("[Transaction_SalesReceipt_DML]", hash);

                if (dtReturn != null && dtReturn.Rows.Count > 0)
                {
                    DataRow dr = dtReturn.Rows[0];
                    if (QueryNo == 101)
                    {
                        dgvParty.DataSource = dtReturn;
                        bsOriginal.DataSource = dtReturn;

                    }

                }
                else
                {
                    if (QueryNo == 101)
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




        private void Dashboard_Outstanding_Yene_Load(object sender, EventArgs e)
        {
            FillGrid(101);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvParty.DataSource = bsOriginal;
                bs.DataSource = dgvParty.DataSource;
                bs.Filter = string.Format("[PARTY NAME] like '%{0}%'", textBox1.Text);
                dgvParty.DataSource = bs;
                dgvParty.Enabled = true;
                // btnClose.Enabled = true;
            }
            catch
            { }
        }
    }
}
