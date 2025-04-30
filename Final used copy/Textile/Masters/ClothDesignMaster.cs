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
    public partial class ClothDesignMaster : Form
    {
        public ClothDesignMaster()
        {
            InitializeComponent();
        }

        #region variables
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        public string UserName, yearString, companyNameStr, groupNmae, PeriodName;
        public int userId, compId, yearId,cmbWarfV,cmbWeftV;
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


                dtReturn = ClsDefination.FillData("[ClothDesign_DML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];
                    if (QueryNo == 201)
                    {
                        cmbWarf.DataSource = dtReturn;
                        cmbWarf.ValueMember = "S_Code";
                        cmbWarf.DisplayMember = "S_Name";
                        cmbWarf.SelectedIndex = -1;
                        cmbWarf.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 202)
                    {
                        cmbWeft.DataSource = dtReturn;
                        cmbWeft.ValueMember = "S_Code";
                        cmbWeft.DisplayMember = "S_Name";
                        cmbWeft.SelectedIndex = -1;
                        cmbWeft.Text = "<--SELECT-->";
                    }
                   
                }
                else
                {
                    if (QueryNo == 201)
                    {
                        cmbWarf.DataSource = dtReturn;
                        cmbWarf.SelectedIndex = -1;
                        cmbWarf.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 202)
                    {
                        cmbWeft.DataSource = dtReturn;
                        cmbWeft.SelectedIndex = -1;
                        cmbWeft.Text = "<--NO RECORD-->";
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
                hash.Add("@intCreatedBy", Convert.ToInt32(fd.UserId));
                hash.Add("@intcompanyId", Convert.ToInt32(fd.CompId));
                hash.Add("@intyearId", Convert.ToInt32(fd.YearId));

                if (QueryNo == 1 || QueryNo == 2)
                {

                    if (QueryNo == 2)
                    {
                        hash.Add("@intDCode", Convert.ToInt32(lblSrNo.Text));
                    }
                    hash.Add("@strDName", txtDesignName.Text);
                    hash.Add("@strDWrSut", cmbWarf.Text);
                    hash.Add("@decDWrCount",Convert.ToDecimal( txtWarfCount.Text));
                    hash.Add("@strDWeSut", cmbWeft.Text);
                    hash.Add("@decDWeCount",Convert.ToDecimal( txtWeftCount.Text));
                    hash.Add("@intDWrSutInt", Convert.ToInt32(cmbWarf.SelectedValue));
                    hash.Add("@intDWeSutInt", Convert.ToInt32(cmbWeft.SelectedValue));
                  
                }

                okflag = 1;
                return ClsDefination.InsertExecute(hash, "[ClothDesign_DML]", ref strReturnMSG, ref strReturnNo, ref intReturnNo);
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

        private void ClothDesignMaster_Load(object sender, EventArgs e)
        {
            FillGrid(201);//warf
            FillGrid(202);//weft

            if (newOrEdit == 1)
            {
                cmbWarf.SelectedValue = cmbWarfV;
                cmbWeft.SelectedValue = cmbWeftV;
            }
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
    }
}
