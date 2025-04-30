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
    public partial class Dashboard_ClothReport : Form
    {
        public Dashboard_ClothReport()
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
                hash.Add("@intYearId", Convert.ToInt32(fd.YearId));
                if (QueryNo == 1003 || QueryNo == 1004)
                {
                    hash.Add("@decMtr", Convert.ToDecimal(txtPMtr.Text));
                    hash.Add("@intCode", Convert.ToInt32(cmbDesign.SelectedValue));
                }
                if (QueryNo == 108)
                {
                    hash.Add("@intQuality",cmbQuality.SelectedValue);
                }

                dtReturn = ClsDefination.FillData("[Report_AllReport]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 109)
                    {
                        cmbQuality.DataSource = dtReturn;
                        cmbQuality.DisplayMember = "Quality";
                        cmbQuality.ValueMember = "id";
                        cmbQuality.SelectedIndex = -1;
                        cmbQuality.Text = "<-- SELECT QUALITY -->";
                    }
                    else if (QueryNo == 108)
                    {
                        cmbDesign.DataSource = dtReturn;
                        cmbDesign.DisplayMember = "DesignName";
                        cmbDesign.ValueMember = "Q_Code";
                        cmbDesign.SelectedIndex = -1;
                        cmbDesign.Text = "<-- SELECT DESIGN -->";
                    }
                    else if (QueryNo == 1003)
                    {
                        dgvWarf.DataSource = dtReturn;
                        bsOriginal.DataSource = dtReturn;
                        // dgvSut.Columns[4].Visible= false;

                        for (int i = 0; i < 3; i++)
                        {
                            dgvWarf.Columns[i].Visible = false;
                        }
                    }
                    else if (QueryNo == 1004)
                    {
                        dgvWeft.DataSource = dtReturn;
                        bsOriginal.DataSource = dtReturn;
                        // dgvSut.Columns[4].Visible= false;
                        for (int i = 0; i < 3; i++)
                        {
                            dgvWeft.Columns[i].Visible = false;
                        }
                    }

                }
                else
                {
                    if (QueryNo == 109)
                    {
                        cmbQuality.DataSource = dtReturn;
                        cmbQuality.SelectedIndex = -1;
                        cmbQuality.Text = "<-- NO QUALITY AVAILABLE -->";
                    }
                    else if (QueryNo == 108)
                    {
                        cmbDesign.DataSource = dtReturn;
                        cmbDesign.SelectedIndex = -1;
                        cmbDesign.Text = "<-- NO DESIGN AVAILABLE -->";
                    }

                    else if (QueryNo == 1003)
                    {
                        dgvWarf.DataSource = null;
                     
                    }
                    else if (QueryNo == 1004)
                    {
                        dgvWeft.DataSource = null;
                     
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

        private void Dashboard_ClothReport_Load(object sender, EventArgs e)
        {
            FillGrid(109);
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            if (cmbDesign.SelectedIndex > -1)
            {
                FillGrid(1003);
                FillGrid(1004);
                calculate();
            }
            else
            {
                MessageBox.Show("Please select design");
            }
        }
        public void calculate()
        {
            lblWarfKG.Text = "0";
            lblWeftKg.Text="0";

            for (int i = 0; i < dgvWarf.Rows.Count; i++)
            {
                lblWarfKG.Text= (Convert.ToDecimal(lblWarfKG.Text)+ Convert.ToDecimal(dgvWarf.Rows[i].Cells[6].Value.ToString())).ToString();
            }

            for(int i=0; i< dgvWeft.Rows.Count; i++)
            {
                lblWeftKg.Text= (Convert.ToDecimal(lblWeftKg.Text)+ Convert.ToDecimal(dgvWeft.Rows[i].Cells[6].Value.ToString())).ToString();
            }

        }

        private void cmbQuality_Leave(object sender, EventArgs e)
        {
            if (cmbQuality.SelectedIndex > -1)
            {
                FillGrid(108);
            }
            else
            {
                MessageBox.Show("Please Select Quality");
            }
        }

        private void cmbDesign_Leave(object sender, EventArgs e)
        {

        }
    }
}
