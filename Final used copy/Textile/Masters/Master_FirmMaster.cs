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
    public partial class Master_FirmMaster : Form
    {
        public Master_FirmMaster()
        {
            InitializeComponent();
        }


        #region variables
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        public string UserName, yearString, companyNameStr, groupNmae, PeriodName;
        public int cmbBV;
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
                        //cmbState.SelectedIndex = -1;
                        //cmbState.Text = "<--SELECT-->";
                        cmbState.SelectedValue = 27;
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
                hash.Add("@intcreatedBy", fd.UserId);
                hash.Add("@intcompanyId", fd.CompId);
                hash.Add("@inryearId", fd.YearId);

                if (QueryNo == 1 || QueryNo == 2)
                {

                    if (QueryNo == 2)
                    {
                        hash.Add("@intCode", Convert.ToInt32(lblSrNo.Text));
                    }
     //   @,@,@,@,@,@,@,
     //@,@,@,@,GETDATE(),1,@,@
                    hash.Add("@strOwnerName", txtOwnerName.Text.ToUpper());
                    hash.Add("@strCompanyName", txtPartyName.Text.ToUpper());
                    hash.Add("@strAddress", txtAdress.Text.ToUpper());
                    hash.Add("@strContact", txtMobileNo.Text);
                    hash.Add("@strAlternet", txtAlternetNo.Text);
                    hash.Add("@strEmail", txtEmailId.Text.ToUpper());
                    hash.Add("@strGSt", txtGSTNo.Text.ToUpper());
                    hash.Add("@strPan", txtPanNo.Text.ToUpper());
                    hash.Add("@intState", Convert.ToInt32(cmbState.SelectedValue));
                    hash.Add("@strBank",txtBankName.Text.ToUpper());
                    hash.Add("@strAccNo",txtAccountNo.Text.ToUpper());
                    hash.Add("@strIfsc",txtIfscCode.Text.ToUpper());
                    
                }

                okflag = 1;
                return ClsDefination.InsertExecute(hash, "[Master_FirmMaster_DML]", ref strReturnMSG, ref strReturnNo, ref intReturnNo);
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
            if (Convert.ToInt32(cmbState.SelectedValue) > 0)
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
                        if (newOrEdit == 0)
                        {
                            frm.messageTxt = "Rocord Saved Successfully: ";// +strReturnMSG;
                        }
                        else
                        {
                            frm.messageTxt = "Rocord Updated Successfully: ";// +strReturnMSG;
                        }
                        frm.type = "success";
                        frm.ShowDialog();
                        this.Close();
                    }
                }
            }
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please Select State";
                frm.type = "error";
                frm.ShowDialog();
            }
        }

        private void Master_FirmMaster_Load(object sender, EventArgs e)
        {
            FillGrid(201);
            //FillGrid(202);
            if (newOrEdit == 1)
            {
                cmbState.SelectedValue = lblStateCode.Text;
            }
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
                messageBox frm = new messageBox();
                frm.messageTxt = "Please enter valid GSTN No";
                frm.type = "error";
                frm.ShowDialog();
                txtGSTNo.Focus();
            }
        }
    }
}
