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

namespace Textile.Masters
{
    public partial class EmployeeMaster : Form
    {
        public EmployeeMaster()
        {
            InitializeComponent();
        }

        #region variables
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        public string UserName, yearString, companyNameStr, groupNmae, PeriodName;
        public int cmbLV,cmbTV,cmbBTV,cmbBBTV,exsitingUser;
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
                hash.Add("@intCompanyId", fd.CompId);
                hash.Add("@strUserName", txtUserName.Text);

                dtReturn = ClsDefination.FillData("[Master_EmployeeDML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];
                    if (QueryNo == 201)
                    {
                        cmbLocation.DataSource = dtReturn;
                        cmbLocation.ValueMember = "CODE";
                        cmbLocation.DisplayMember = "NAME";
                        cmbLocation.SelectedIndex = -1;
                        cmbLocation.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 202)
                    {
                        cmbType.DataSource = dtReturn;
                        cmbType.ValueMember = "Common_Id";
                        cmbType.DisplayMember = "Common_Value";
                        cmbType.SelectedIndex = -1;
                        cmbType.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 203)
                    {
                        cmbBalanceType.DataSource = dtReturn;
                        cmbBalanceType.ValueMember = "Common_Id";
                        cmbBalanceType.DisplayMember = "Common_Value";
                        cmbBalanceType.SelectedIndex = -1;
                        cmbBalanceType.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 204)
                    {
                        cmbBakiBalType.DataSource = dtReturn;
                        cmbBakiBalType.ValueMember = "Common_Id";
                        cmbBakiBalType.DisplayMember = "Common_Value";
                        cmbBakiBalType.SelectedIndex = -1;
                        cmbBakiBalType.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 301)
                    {
                        if (dtReturn.Rows[0][0].ToString() == "0")
                        {
                        }
                        else
                        {
                            messageBox frm = new messageBox();
                            frm.type = "error";
                            frm.messageTxt = txtUserName.Text + " is not available. ";// + Environment.NewLine + "Please check user name and try again.";
                            frm.ShowDialog();
                            txtUserName.Focus();
                        }
                    }
                }
                else
                {
                    if (QueryNo == 201)
                    {
                        cmbLocation.DataSource = dtReturn;
                        cmbLocation.SelectedIndex = -1;
                        cmbLocation.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 202)
                    {
                        cmbType.DataSource = dtReturn;
                        cmbType.SelectedIndex = -1;
                        cmbType.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 203)
                    {
                        cmbBalanceType.DataSource = dtReturn;
                        cmbBalanceType.SelectedIndex = -1;
                        cmbBalanceType.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 204)
                    {
                        cmbBakiBalType.DataSource = dtReturn;
                        cmbBakiBalType.SelectedIndex = -1;
                        cmbBakiBalType.Text = "<--NO RECORD-->";
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

                //,getdate(),1,,
                hash.Add("@QueryNo", QueryNo);
                hash.Add("@intCreatedBy", fd.UserId);
                hash.Add("@intCompanyId", fd.CompId);
                hash.Add("@intYearId", fd.YearId);

                if (QueryNo == 1 || QueryNo == 2)
                {

                    if (QueryNo == 2)
                    {
                        hash.Add("@strUniqueCode", lblUniqueCode.Text);
                        hash.Add("@intCode", Convert.ToInt32(lblSrNo.Text));
                    }

                    hash.Add("@strName", txtEmployeeName.Text.ToUpper());
                    hash.Add("@strAddress", txtAdress.Text.ToUpper());
                    hash.Add("@strMob1", txtMobileNo.Text.ToUpper());
                    hash.Add("@strMob2", txtAlternetNo.Text.ToUpper());
                    hash.Add("@intLocation", Convert.ToInt32( cmbLocation.SelectedValue));
                    hash.Add("@intEmpType", Convert.ToInt32(cmbType.SelectedValue));
                    hash.Add("@strBank", txtBankName.Text.ToUpper());
                    hash.Add("@strBranch", txtBranch.Text.ToUpper());
                    hash.Add("@strAccNo", txtAccNo.Text.ToUpper());
                    hash.Add("@strIFSC", txtIfscCode.Text.ToUpper());
                    hash.Add("@strUserName", txtUserName.Text.ToLower());
                    hash.Add("@strPassword", txtPassword.Text);
                    hash.Add("@decOpeningBal",Convert.ToDecimal(txtOpeningBalance.Text));
                    hash.Add("@intBalanceType",Convert.ToInt32(cmbBalanceType.SelectedValue));
                    hash.Add("@decBakiAmt",Convert.ToDecimal(txtBakiBalance.Text));
                    hash.Add("@intBakiBalanceType",Convert.ToInt32(cmbBakiBalType.SelectedValue));
                   // hash.Add("@intExistingUser", exsitingUser);
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
        
        private void EmployeeMaster_Load(object sender, EventArgs e)
        {
            FillGrid(201);
            FillGrid(202);
            FillGrid(203);
            FillGrid(204);

            if (newOrEdit == 1)
            {
                cmbLocation.SelectedValue = cmbLV;
                cmbType.SelectedValue = cmbTV;
                cmbBalanceType.SelectedValue = cmbBTV;
                cmbBakiBalType.SelectedValue = cmbBBTV;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (newOrEdit == 0)
            {
                SaveData(1, ref strReturnMSG, ref strReturnRefNo, ref intReturnPKNo);
            }
            else
            {
                SaveData(2, ref strReturnMSG, ref strReturnRefNo, ref intReturnPKNo);
            }
            if (okflag == 1)
            {
                messageBox frm = new messageBox();

                if (intReturnPKNo == 0)
                {
                    frm.messageTxt = strReturnMSG;
                    frm.type = "error";
                    frm.ShowDialog();
                }
                else
                {

                    if (newOrEdit == 0)
                    {
                        frm.messageTxt = "Rocord Saved Successfully: " + strReturnMSG;
                    }
                    else
                    {
                        frm.messageTxt = "Rocord Updated Successfully: " + strReturnMSG;
                    }
                    frm.type = "success";
                    frm.ShowDialog();
                    this.Close();
                }
            }

        }

        private void cmbLocation_Leave(object sender, EventArgs e)
        {
            if (cmbLocation.Text != "<--SELECT-->" && cmbLocation.Text != "<--NO RECORD-->" && cmbLocation.SelectedValue != null && Convert.ToInt32(cmbLocation.SelectedValue) > 0)
            {

            }
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please select location";
                frm.type = "error";
                frm.ShowDialog();
                cmbLocation.Focus();
                FillGrid(201);
            }
        }

        private void cmbType_Leave(object sender, EventArgs e)
        {
            if (cmbType.Text != "<--SELECT-->" && cmbType.Text != "<--NO RECORD-->" && cmbType.SelectedValue != null && Convert.ToInt32(cmbType.SelectedValue) > 0)
            {

            }
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please select employee type";
                frm.type = "error";
                frm.ShowDialog();
                cmbType.Focus();
                FillGrid(202);
            }
        }

        private void cmbBalanceType_Leave(object sender, EventArgs e)
        {
            if (cmbBalanceType.Text != "<--SELECT-->" && cmbBalanceType.Text != "<--NO RECORD-->" && cmbBalanceType.SelectedValue != null && Convert.ToInt32(cmbBalanceType.SelectedValue) > 0)
            {

            }
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please select balance type";
                frm.type = "error";
                frm.ShowDialog();
                cmbBalanceType.Focus();
                FillGrid(203);
            }
        }

        private void txtRPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtRPassword.Text)
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please check password";
                frm.type = "error";
                frm.ShowDialog();
                txtRPassword.Text = "";
                txtRPassword.Focus();
            }
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            if (txtUserName.Text != "")
            {
                FillGrid(301);
                txtPassword.Enabled = txtRPassword.Enabled = true;
            }
            else
            {
                txtPassword.Enabled = txtRPassword.Enabled = false;
                txtOpeningBalance.Focus();
            }
        }

        private void cmbBakiBalType_Leave(object sender, EventArgs e)
        {
            if (cmbBakiBalType.Text != "<--SELECT-->" && cmbBakiBalType.Text != "<--NO RECORD-->" && cmbBakiBalType.SelectedValue != null && Convert.ToInt32(cmbBakiBalType.SelectedValue) > 0)
            {

            }
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please select balance type";
                frm.type = "error";
                frm.ShowDialog();
                cmbBakiBalType.Focus();
                FillGrid(204);
            }
        }

        private void titleBar_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
