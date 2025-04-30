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
    public partial class Dashboard_Employee : Form
    {
        public Dashboard_Employee()
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
                hash.Add("@intCompanyId", fd.CompId);

                dtReturn = ClsDefination.FillData("[Master_EmployeeDML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 101)
                    {
                        dgvSut.DataSource = dtReturn;
                        bsOriginal.DataSource = dtReturn;
                        //14 15 16 17

                        dgvSut.Columns[21].DisplayIndex = 0;

                        for (int i = 0; i < 21; i++)
                        {
                            dgvSut.Columns[i].DisplayIndex = i + 1;
                        }

                       
                        for (int i = 0; i < 22; i++)
                        {
                            dgvSut.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        
                        }

                        for (int i = 16; i < 21; i++)
                        {
                            dgvSut.Columns[i].Visible = false;
                        }
                        
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
                hash.Add("@intCreatedBy", fd.UserId);
                hash.Add("@intCompanyId", fd.CompId);
                hash.Add("@intYearId", fd.YearId);

                if (QueryNo == 3)
                {

                    hash.Add("@strUniqueCode", dgvSut.CurrentRow.Cells[21].Value.ToString());
                    hash.Add("@intCode", Convert.ToInt32(dgvSut.CurrentRow.Cells[0].Value.ToString()));
                }

                okflag = 1;
                return ClsDefination.InsertExecute(hash, "[Master_EmployeeDML]", ref strReturnMSG, ref strReturnNo, ref intReturnNo);
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

        private void Dashboard_Employee_Load(object sender, EventArgs e)
        {
            FillGrid(101);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Masters.EmployeeMaster frm = new Masters.EmployeeMaster();
            frm.newOrEdit = 0;
            frm.ShowDialog();
            FillGrid(101);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSut.SelectedRows.Count > 0)
                {
                    Masters.EmployeeMaster frm = new Masters.EmployeeMaster();
                    frm.newOrEdit = 1;
                        
           
           // ME.Emp_Code as [CODE], ME.Name as [NAME], ME.Address as [ADDRESS], ME.Mob1 as [MOBILE 1],     0 1 2 3
           // ME.Mob2 as [MOBILE 2], CV.L_ShadeName+' - '+CV.L_ShadeLocation as [LOCATION],CV1.Common_Value as [DESIGNATION],  4 5 6
           // ME.OpeningBal as [ADVANCE OPENING BAL], CV2.Common_Value as [BALANCE TYPE],ME.baki as [BAKI OPENING BAL], 7 8 9
           //CV3.Common_Value as [BALANCE TYPE], 10
           // ME.UserName as [USER NAME],  11
           // ME.bankName as [BANK], ME.branch as [BRANCH], ME.AccNo as [ACC NO], ME.IFSC as [IFSC],  12 13 14 15
           // ME.BalanceType ,ME.Location, ME.Type,ME.Password,ME.bakiBalanceType 16 17 18 19 20
                    frm.lblSrNo.Text = dgvSut.CurrentRow.Cells[0].Value.ToString();
                    frm.txtEmployeeName.Text = dgvSut.CurrentRow.Cells[1].Value.ToString();
                    frm.txtAdress.Text = dgvSut.CurrentRow.Cells[2].Value.ToString();
                    frm.txtMobileNo.Text = dgvSut.CurrentRow.Cells[3].Value.ToString();
            //                    ME.Emp_Code as [CODE], ME.Name as [NAME], ME.Address as [ADDRESS], ME.Mob1 as [MOBILE 1], 
                    frm.txtAlternetNo.Text = dgvSut.CurrentRow.Cells[4].Value.ToString();
                    frm.cmbLocation.Text = dgvSut.CurrentRow.Cells[5].Value.ToString();
                    frm.cmbType.Text = dgvSut.CurrentRow.Cells[6].Value.ToString();
            //ME.Mob2 as [MOBILE 2], CV.Common_Value as [LOCATION],CV1.Common_Value as [DESIGNATION], 
                    frm.txtOpeningBalance.Text = dgvSut.CurrentRow.Cells[7].Value.ToString();
                    frm.cmbBalanceType.Text = dgvSut.CurrentRow.Cells[8].Value.ToString();
                    frm.txtBakiBalance.Text = dgvSut.CurrentRow.Cells[9].Value.ToString();
                    frm.cmbBakiBalType.Text = dgvSut.CurrentRow.Cells[10].Value.ToString();
                    
                    frm.txtUserName.Text = dgvSut.CurrentRow.Cells[11].Value.ToString();
                    if (dgvSut.CurrentRow.Cells[11].Value.ToString() != "")
                    {
                        frm.exsitingUser = 1;
                    }
                    else
                    {
                        frm.exsitingUser = 0;
                    }
            //ME.OpeningBal as [OPENING BALANCE], CV2.Common_Value as [BALANCE TYPE],ME.UserName as [USER NAME],  
                    frm.txtBankName.Text = dgvSut.CurrentRow.Cells[12].Value.ToString();
                    frm.txtBranch.Text = dgvSut.CurrentRow.Cells[13].Value.ToString();
                    frm.txtAccNo.Text = dgvSut.CurrentRow.Cells[14].Value.ToString();
                    frm.txtIfscCode.Text = dgvSut.CurrentRow.Cells[15].Value.ToString();
            //ME.bankName as [BANK], ME.branch as [BRANCH], ME.AccNo as [ACC NO], ME.IFSC as [IFSC], 
                    frm.cmbBTV = Convert.ToInt32(dgvSut.CurrentRow.Cells[16].Value.ToString());
                    frm.cmbLV = Convert.ToInt32(dgvSut.CurrentRow.Cells[17].Value.ToString());
                    frm.cmbTV = Convert.ToInt32(dgvSut.CurrentRow.Cells[18].Value.ToString());
                    frm.txtPassword.Text=frm.txtRPassword.Text = dgvSut.CurrentRow.Cells[19].Value.ToString();
                    if (dgvSut.CurrentRow.Cells[19].Value.ToString() != "")
                    {
                        frm.exsitingUser = 1;
                    }
                    else
                    {
                        frm.exsitingUser = 0;
                    }
                    
                    
                    frm.cmbBBTV = Convert.ToInt32(dgvSut.CurrentRow.Cells[20].Value.ToString());
                    frm.lblUniqueCode.Text = dgvSut.CurrentRow.Cells[21].Value.ToString().Remove(0,2);
            //ME.BalanceType ,ME.Location, ME.Type,ME.Password
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
            catch (Exception ex)
            {
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvSut.DataSource = bsOriginal;
                bs.DataSource = dgvSut.DataSource;
                bs.Filter = string.Format("[NAME] like '%{0}%'", txtSearch.Text);
                dgvSut.DataSource = bs;
                dgvSut.Enabled = true;
                // btnClose.Enabled = true;
            }
            catch
            { }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSut.SelectedRows.Count > 0)
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
