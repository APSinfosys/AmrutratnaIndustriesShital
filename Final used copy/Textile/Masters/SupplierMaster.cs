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
    public partial class SupplierMaster : Form
    {
        public SupplierMaster()
        {
            InitializeComponent();
        }

        #region variables
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        public string UserName, yearString, companyNameStr, groupNmae, PeriodName;
        public int cmbBV,cmbPTV;
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


                dtReturn = ClsDefination.FillData("[Party_DML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];
                    if (QueryNo == 201)
                    {
                        cmbState.DataSource = dtReturn;
                        cmbState.ValueMember = "Common_Id";
                        cmbState.DisplayMember = "Common_Value";
                        cmbState.SelectedValue = 27;
                        cmbState.DisplayMember.ToUpper();
                        //cmbState.SelectedIndex = -1;
                        //cmbState.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 205)
                    {
                        cmbPartyType.DataSource = dtReturn;
                        cmbPartyType.ValueMember = "Common_Id";
                        cmbPartyType.DisplayMember = "Common_Value";
                        cmbPartyType.SelectedIndex = -1;
                        cmbPartyType.Text = "<--SELECT-->";
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
                    else if (QueryNo == 205)
                    {
                        cmbPartyType.DataSource = dtReturn;
                        cmbPartyType.SelectedIndex = -1;
                        cmbPartyType.Text = "<--NO RECORD-->";
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
                hash.Add("@intcompanyId", fd.CompId);
                hash.Add("@inryearId",fd.YearId);

                if (QueryNo == 1 || QueryNo == 2)
                {

                    if (QueryNo == 2)
                    {
                        hash.Add("@strUniqueCode", lblUniqueCode.Text);
                        hash.Add("@intP_Code", Convert.ToInt32(lblSrNo.Text));
                    }
                    hash.Add("@strP_OwnerName", txtOwnerName.Text);
                    hash.Add("@strP_CompanyName", txtPartyName.Text);
                    hash.Add("@strP_Address", txtAdress.Text);
                    hash.Add("@strP_Mobile", txtMobileNo.Text);
                    hash.Add("@strP_AlternateMob", txtAlternetNo.Text);
                    hash.Add("@strP_Email", txtEmailId.Text);
                    hash.Add("@strP_GSTNo", txtGSTNo.Text);
                    hash.Add("@strP_PANNo", txtPanNo.Text);
                    hash.Add("@intP_State", Convert.ToInt32(cmbState.SelectedValue));

                    hash.Add("@strP_BankName", txtBankName.Text);
                    hash.Add("@strP_Branch", txtBranch.Text);
                    hash.Add("@strP_AccNo", txtAccNo.Text);
                    hash.Add("@strP_IFSC", txtIfscCode.Text);
                    //,
                 //   hash.Add("@intPartyType", cmbPartyType.SelectedValue);


                }

                okflag = 1;
                return ClsDefination.InsertExecute(hash, "[Party_DML]", ref strReturnMSG, ref strReturnNo, ref intReturnNo);
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

        private void SupplierMaster_Load(object sender, EventArgs e)
        {
            FillGrid(201);
            FillGrid(202);
            FillGrid(205);

            if (newOrEdit == 1)
            {

                cmbState.SelectedValue = lblStateCode.Text;
              //  cmbPartyType.SelectedValue = cmbPTV;
            //    cmbBalanceType.SelectedValue = cmbBV;
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
                        frm.messageTxt = "Rocord Saved Successfully";// +strReturnMSG;
                    }
                    else
                    {
                        frm.messageTxt = "Rocord Updated Successfully";// +strReturnMSG;
                    }
                    frm.type = "success";
                    frm.ShowDialog();
                    this.Close();
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtGSTNo_Leave(object sender, EventArgs e)
        {
            try
            {
                txtGSTNo.Text = txtGSTNo.Text.ToUpper();
                string pan = "";
                pan = txtGSTNo.Text.Substring(2, txtGSTNo.Text.Length - 2);
                pan = pan.Remove(pan.Length - 3, 3);
                txtPanNo.Text = pan;
            }
            catch (Exception ex)
            {
                
            }
        }


    }
}
