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
    public partial class SutMaster : Form
    {
        public SutMaster()
        {
            InitializeComponent();
        }

        #region variables
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        public string UserName, yearString, companyNameStr, groupNmae, PeriodName;
        public int userId, compId, yearId, GroupId;
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
                hash.Add("@intcompanyId", fd.CompId);

                

                dtReturn = ClsDefination.FillData("[Sut_DML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 102)
                    {
                        cmbGroupName.DataSource = dtReturn;
                        cmbGroupName.DisplayMember = "YG_Name";
                        cmbGroupName.ValueMember = "YG_Code";
                        cmbGroupName.SelectedIndex = -1;
                        cmbGroupName.Text = "<--SELECT-->";
                    }
                }
                else
                {
                    if (QueryNo == 102)
                    {
                        cmbGroupName.DataSource = dtReturn;
                        cmbGroupName.SelectedIndex = -1;
                        cmbGroupName.Text = "<--NO RECORD-->";
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
                hash.Add("@intyearId", fd.YearId);

                if (QueryNo == 1 || QueryNo == 2)
                {

                    if (QueryNo == 2)
                    {
                        hash.Add("@strUniqueCode", lblUniqueCode.Text);
                        hash.Add("@intSCode", Convert.ToInt32(lblSrNo.Text));
                    }
                    hash.Add("@strSName", txtSutName.Text.ToUpper());
                    hash.Add("@decSCGST", Convert.ToDecimal(txtCGST.Text));
                    hash.Add("@decSSGST", Convert.ToDecimal( txtSGST.Text));
                    hash.Add("@decSIGST",Convert.ToDecimal( txtIGST.Text));
                    hash.Add("@intyarnGrop",Convert.ToInt32(cmbGroupName.SelectedValue));
                    hash.Add("@stryarnGropName",cmbGroupName.Text);
                    hash.Add("@strcount",txtCount.Text);
                    hash.Add("@strmillName",txtMillName.Text);
                   
                }

                okflag = 1;
                return ClsDefination.InsertExecute(hash, "[Sut_DML]", ref strReturnMSG, ref strReturnNo, ref intReturnNo);
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

        private void SutMaster_Load(object sender, EventArgs e)
        {
            FillGrid(102);

            if (newOrEdit == 1)
            {
                cmbGroupName.SelectedValue = GroupId;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCGST.Text == "")
            {
                txtCGST.Text = "0";
            }
            if (txtIGST.Text == "")
            {
                txtIGST.Text = "0";
            }
            if (txtSGST.Text == "")
            {
                txtSGST.Text = "0";
            }

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

        private void cmbGroupName_Leave(object sender, EventArgs e)
        {
            sutName();
        }

        private void txtCount_Leave(object sender, EventArgs e)
        {
            sutName();
        }

        private void txtMillName_Leave(object sender, EventArgs e)
        {
            sutName();
        }

        public void sutName()
        {
            if (cmbGroupName.SelectedIndex > -1)
            {
                txtSutName.Text = txtCount.Text + ' ' + cmbGroupName.Text + ' ' + txtMillName.Text;
            }
            else
            {
                txtSutName.Text = txtCount.Text + ' ' + txtMillName.Text;
            }
        }

    }
}
