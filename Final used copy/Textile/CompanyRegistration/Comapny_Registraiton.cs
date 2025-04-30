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

namespace Textile.CompanyRegistration
{
    public partial class Comapny_Registraiton : Form
    {
        public Comapny_Registraiton()
        {
            InitializeComponent();
        }

        #region variables
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        public string UserName, yearString, companyNameStr, groupNmae, PeriodName;
        public int userId, compId, yearId, GroupId, otherPg, cmbValue, cmbTT;
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

                if (QueryNo == 202)
                {
                    hash.Add("@strUserName",txtUserName.Text);
                }
      
                dtReturn = ClsDefination.FillData("[CompanyRegistration_DML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];
                    if (QueryNo == 201)
                    {
                        cmbState.DataSource = dtReturn;
                        cmbState.ValueMember = "Common_Id";
                        cmbState.DisplayMember = "Common_Value";
                        cmbState.SelectedIndex = -1;
                        cmbState.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 202)
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
                        cmbState.DataSource = dtReturn;
                        cmbState.SelectedIndex = -1;
                        cmbState.Text = "<--NO RECORD-->";
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

                if (QueryNo == 1 || QueryNo == 2)
                {

                    hash.Add("@strCompName", txtCompanyName.Text);
                    hash.Add("@strAddress", txtAdress.Text);
                    hash.Add("@intState", Convert.ToInt32(cmbState.SelectedValue));
                    hash.Add("@strOwner", txtOwner.Text);
                    hash.Add("@strEmail", txtEmailId.Text);
                    hash.Add("@strGST", txtGSTNo.Text);
                    hash.Add("@strPan", txtPanNo.Text);
                    hash.Add("@strContact", txtMobileNo.Text);
                    hash.Add("@strContact1", txtAlternetNo.Text);
                    hash.Add("@strUserName", txtUserName.Text);
                    hash.Add("@strPassword", txtPassword.Text);
                    hash.Add("@intType", 38); // ADMIN USER TYPE
                }

                okflag = 1;
                return ClsDefination.InsertExecute(hash, "[CompanyRegistration_DML]", ref strReturnMSG, ref strReturnNo, ref intReturnNo);
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

        private void cmbAccHead_Leave(object sender, EventArgs e)
        {
            FillGrid(307);
        }

        //----------------------------------------------------------------------------

        #endregion

       

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData(1, ref strReturnMSG, ref strReturnRefNo, ref intReturnPKNo);
            if (okflag == 1)
            {
            
                messageBox frm = new messageBox();
                frm.messageTxt = "Rocord Saved Successfully: " + strReturnMSG;
                frm.type = "success";
                frm.ShowDialog();
                this.Close();
                Login.Login lg = new Login.Login();
                lg.Show();
            }
            else
            {
                //MessageBox.Show(strReturnMSG);
                messageBox frm = new messageBox();
                frm.messageTxt = strReturnMSG;
                frm.type = "error";
                frm.ShowDialog();
            }
        }

        private void Comapny_Registraiton_Load(object sender, EventArgs e)
        {
            FillGrid(201);
            txtUserName.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login.Login frm = new Login.Login();
            frm.Show();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login.Login frm = new Login.Login();
            frm.Show();
        }

        private void cmbState_Leave(object sender, EventArgs e)
        {

            if (cmbState.SelectedValue != null)
            {
                lblStateCode.Text = cmbState.SelectedValue.ToString();
            }
            if (lblStateCode.Text == "StateCode")
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "PLEASE SELECT STATE";
                frm.type = "error";
                frm.ShowDialog();
                cmbState.Focus();
            }
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            FillGrid(202);// check weather user name is available or not
        }

        private void txtRePassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtRePassword.Text)
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "PLEASE CHECK PASSWORD";
                frm.type = "error";
                frm.ShowDialog();
                txtRePassword.Focus();
            }
        }


    }
}
