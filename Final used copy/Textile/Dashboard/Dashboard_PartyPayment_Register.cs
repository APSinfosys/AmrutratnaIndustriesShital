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
    public partial class Dashboard_PartyPayment_Register : Form
    {
        public Dashboard_PartyPayment_Register()
        {
            InitializeComponent();
        }


        #region Variable
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        BindingSource bs = new BindingSource();
        BindingSource bsOriginal = new BindingSource();
        BindingSource bs1 = new BindingSource();
        BindingSource bsOriginal1 = new BindingSource();
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
                    if (QueryNo == 1012)
                    {
                        dgvParty.DataSource = dtReturn;
                        bsOriginal.DataSource = dtReturn;
                        bsOriginal1.DataSource = dtReturn;

                        dgvParty.Columns[17].DisplayIndex = 0;

                        for (int i = 0; i < 17; i++)
                        {
                            dgvParty.Columns[i].DisplayIndex = i+1;
                        }
                        dgvParty.Columns[11].Visible = false;
                        dgvParty.Columns[12].Visible = false;
                        dgvParty.Columns[13].Visible = false;
                        dgvParty.Columns[14].Visible = false;
                        dgvParty.Columns[15].Visible = false;
                        dgvParty.Columns[16].Visible = false;
                    
                    }
                    
                }
                else
                {
                    if (QueryNo == 1012)
                    {
                        dgvParty.DataSource = dtReturn;
                        dgvParty.Columns[18].DisplayIndex = 0;

                        for (int i = 0; i < 18; i++)
                        {
                            dgvParty.Columns[i].DisplayIndex = i + 1;
                        }

                        dgvParty.Columns[12].Visible = false;
                        dgvParty.Columns[13].Visible = false;
                        dgvParty.Columns[14].Visible = false;
                        dgvParty.Columns[15].Visible = false;
                        dgvParty.Columns[16].Visible = false;
                        //   dgvAcc.Columns[9].Visible = false;
                    }
                    //else if (QueryNo == 201)
                    //{
                    //    cmbShade.DataSource = dtReturn;
                    //    cmbShade.SelectedIndex = -1;
                    //    cmbShade.Text = "<--NO RECORD-->";
                    //}

                }

                return null;
            }


            catch (Exception)
            {
                return null;
                throw;
            }
        }



        private void Dashboard_PartyPayment_Register_Load(object sender, EventArgs e)
        {
            FillGrid(1012);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvParty.DataSource = bsOriginal;
                bs.DataSource = dgvParty.DataSource;
                bs.Filter = string.Format("[ FIRM NAME ] like '%{0}%'", textBox1.Text);
                dgvParty.DataSource = bs;
                dgvParty.Enabled = true;
                // btnClose.Enabled = true;
            }
            catch
            { }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvParty.DataSource = bsOriginal1;
                bs1.DataSource = dgvParty.DataSource;
                bs1.Filter = string.Format("[ PARTY NAME ] like '%{0}%'", textBox2.Text);
                dgvParty.DataSource = bs1;
                dgvParty.Enabled = true;
                // btnClose.Enabled = true;
            }
            catch
            { }
        }
    }
}
