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
    public partial class Master_BrockerMaster : Form
    {
        public Master_BrockerMaster()
        {
            InitializeComponent();
        }

        #region variables
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        public string UserName, yearString, companyNameStr, groupNmae, PeriodName;
        public int cmbBT;
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
                hash.Add("@intYearId", fd.YearId);


                dtReturn = ClsDefination.FillData("[Master_BrokerMaster_DML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 201)
                    {
                        //id,
                        cmbBalanceType.DataSource = dtReturn;
                        cmbBalanceType.DisplayMember = "Common_Value";
                        cmbBalanceType.ValueMember = "Common_Id";
                        cmbBalanceType.SelectedValue = -1;
                        cmbBalanceType.Text = "<--SELECT-->";
                    }

                }
                else
                {
                    if (QueryNo == 201)
                    {
                        cmbBalanceType.DataSource = dtReturn;
                        cmbBalanceType.SelectedValue = -1;
                        cmbBalanceType.Text = "<--NO RECORD-->";
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
                        hash.Add("@strUniqueCode",lblUniqueCode.Text);
                        hash.Add("@intCode", Convert.ToInt32(lblSrNo.Text));
                    }

                    hash.Add("@strName",txtName.Text.ToUpper());
                    hash.Add("@strAddress",txtAddress.Text.ToUpper());
                    hash.Add("@strContact",txtContact.Text);
                    hash.Add("@strAlternate",txtAlternet.Text);
                    hash.Add("@decOpeningBalance",Convert.ToDecimal(txtOpeningBalance.Text));
                    hash.Add("@decBalanceType", Convert.ToInt32(cmbBalanceType.SelectedValue));
                   // ,,@intShade,@intFirm

                }

                okflag = 1;



                return ClsDefination.InsertExecute(hash, "[Master_BrokerMaster_DML]", ref strReturnMSG, ref strReturnNo, ref intReturnNo);


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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Master_BrockerMaster_Load(object sender, EventArgs e)
        {
            FillGrid(201);
            if (newOrEdit == 1)
            {
                cmbBalanceType.SelectedValue = cmbBT;
            }
            txtName.Focus();
        }
    }
}
