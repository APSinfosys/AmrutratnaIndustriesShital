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

namespace Accounting.Master
{
    public partial class Master_AccountMaster : Form
    {
        public Master_AccountMaster()
        {
            InitializeComponent();
        }

        #region variables
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        public string UserName, yearString, companyNameStr, groupNmae, PeriodName;
        public int userId, compId, yearId, GroupId, otherPg, cmbValue,cmbTT;
        string strReturnMSG, strReturnRefNo;
        int intReturnPKNo;
        int result, okflag;
        //  public int groupId;
        public int newOrEdit = 0;
        #endregion

        private void Master_AccountMaster_Load(object sender, EventArgs e)
        {
            FillGrid(102);
            if (newOrEdit == 1)
            {
                cmbCrDr.SelectedValue = cmbTT;
            }
        }

        #region Click Events
        private void BtnCerrar_Click(object sender, EventArgs e)
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
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = strReturnMSG;
                frm.type = "error";
                frm.ShowDialog();
            }
        }
        #endregion

        #region Button Hover and leave events
        private void btnSave_MouseHover(object sender, EventArgs e)
        {
            btnSave.FlatAppearance.BorderSize = 1;
            btnSave.FlatAppearance.BorderColor = Color.DarkGreen;
            btnSave.BackColor = Color.DarkGreen;
            btnSave.ForeColor = Color.White;
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatAppearance.BorderColor = Color.FromArgb(0, 112, 204);
            btnSave.BackColor = Color.FromArgb(0, 112, 204);
            btnSave.ForeColor = Color.White;
        }

        private void btnCancle_MouseHover(object sender, EventArgs e)
        {
            btnCancle.FlatAppearance.BorderSize = 1;
            btnCancle.FlatAppearance.BorderColor = Color.Brown;
            btnCancle.BackColor = Color.Brown;
            btnCancle.ForeColor = Color.White;
        }

        private void btnCancle_MouseLeave(object sender, EventArgs e)
        {
            btnCancle.FlatAppearance.BorderSize = 0;
            btnCancle.FlatAppearance.BorderColor = Color.FromArgb(0, 112, 204);
            btnCancle.BackColor = Color.FromArgb(0, 112, 204);
            btnCancle.ForeColor = Color.White;
        }
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
                hash.Add("@intYearId",fd.YearId);


                dtReturn = ClsDefination.FillData("[Master_AccMasterDML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 102)
                    {
                        //id,
                        cmbCrDr.DataSource = dtReturn;
                        cmbCrDr.DisplayMember = "Common_Value";
                        cmbCrDr.ValueMember = "Common_Id";
                        cmbCrDr.SelectedValue = -1;
                        cmbCrDr.Text = "<--SELECT-->";
                    }

                }
                else
                {
                    if (QueryNo == 102)
                    {
                        cmbCrDr.DataSource = dtReturn;
                        cmbCrDr.SelectedValue = -1;
                        cmbCrDr.Text = "<--NO RECORD-->";
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
                hash.Add("@intCompanyId", fd.CompId);
                hash.Add("@intYearId", fd.YearId);
                hash.Add("@intCreatedBy", fd.UserId);
                if (QueryNo == 1 || QueryNo == 2)
                {

                    if (QueryNo == 2)
                    {
                        hash.Add("@strUniqueCode", lblUniqueCode.Text);
                        hash.Add("@intCode", Convert.ToInt32(lblSrNo.Text));
                    }

                    hash.Add("@strBankName",txtName.Text.ToUpper());
                    hash.Add("@strAccNo", txtAccNo.Text.ToUpper());
                    hash.Add("@strAddress",txtAddress.Text.ToUpper());
                    hash.Add("@strBranch",txtBranch.Text.ToUpper());
                    hash.Add("@strIFSC",txtIfsc.Text.ToUpper());
                    hash.Add("@strHolder",txtHolderName.Text.ToUpper());
                    hash.Add("@decOpeningBal",Convert.ToDecimal( txtOpBal.Text));
                    hash.Add("@intBalanceType",Convert.ToInt32( 53));
                }
                
                okflag = 1;

                return ClsDefination.InsertExecute(hash, "[Master_AccMasterDML]", ref strReturnMSG, ref strReturnNo, ref intReturnNo);


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
   
    }
}
