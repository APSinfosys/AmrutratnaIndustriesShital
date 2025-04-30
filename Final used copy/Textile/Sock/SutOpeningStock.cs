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

namespace Textile.Sock
{
    public partial class SutOpeningStock : Form
    {
        public SutOpeningStock()
        {
            InitializeComponent();
        }


        #region variables
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        public string owner;
        public int cmbPV, cmbQV;
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
        //        hash.Add("@inryearId", fd.YearId);


                dtReturn = ClsDefination.FillData("[Sut_DML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 201)
                    {
                        cmbShade.DataSource = dtReturn;
                        cmbShade.DisplayMember = "Shade";
                        cmbShade.ValueMember = "ShadeCode";
                        cmbShade.SelectedIndex = -1;
                        cmbShade.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 202)
                    {
                        cmbSutUse.DataSource = dtReturn;
                        cmbSutUse.DisplayMember = "Common_Value";
                        cmbSutUse.ValueMember = "Common_Id";
                        cmbSutUse.SelectedIndex = -1;
                        cmbSutUse.Text = "<--SELECT-->";
                    }
                }
                else
                {

                    if (QueryNo == 201)
                    {
                        cmbShade.DataSource = dtReturn;
                        cmbShade.SelectedIndex = -1;
                        cmbShade.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 202)
                    {
                        cmbSutUse.DataSource = dtReturn;
                        cmbSutUse.SelectedIndex = -1;
                        cmbSutUse.Text = "<--NO RECORD-->";
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
                hash.Add("@intcreatedBy", Convert.ToInt32(fd.UserId));
                hash.Add("@intcompanyId", Convert.ToInt32(fd.CompId));
                hash.Add("@intyearId", Convert.ToInt32(fd.YearId));

                if (QueryNo == 3 || QueryNo == 4)
                {
                    hash.Add("@strUniqueCode", lblUniqueCode.Text);
                    hash.Add("@intSCode",Convert.ToInt32( lblSrNo.Text));
                    hash.Add("@strSName",lblSutNameValue.Text);

                    hash.Add("@intSutUse",Convert.ToInt32(cmbSutUse.SelectedValue));
                    hash.Add("@decSutCount",Convert.ToDecimal(txtSutCount.Text));
                    hash.Add("@strSutColor",txtSutColor.Text);
                    hash.Add("@intShade",Convert.ToInt32(cmbShade.SelectedValue));

                    hash.Add("@decFGBag",Convert.ToDecimal(txtFGBag.Text));
                    hash.Add("@intFGKon", Convert.ToInt32(txtFGKon.Text));
                    hash.Add("@decFGWeight", Convert.ToDecimal(txtFGWeight.Text));

                    hash.Add("@decFKBag",Convert.ToDecimal(txtFKBag.Text));
                    hash.Add("@intFKKon", Convert.ToInt32(txtFKKon.Text));
                    hash.Add("@decFKWeight", Convert.ToDecimal(txtFKWeight.Text));

                    hash.Add("@decWGBag", Convert.ToDecimal(txtWGBag.Text));
                    hash.Add("@intWGKon", Convert.ToInt32(txtWGKon.Text));
                    hash.Add("@decWGWeight", Convert.ToDecimal(txtWGWeight.Text));

                    hash.Add("@decWKBag", Convert.ToDecimal(txtWKBag.Text));
                    hash.Add("@intWKKon", Convert.ToInt32(txtWKKon.Text));
                    hash.Add("@decWKWeight", Convert.ToDecimal(txtWKWeight.Text));
                   


                   
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (newOrEdit == 0)
            {
                SaveData(3, ref strReturnMSG, ref strReturnRefNo, ref intReturnPKNo);
            }
            else
            {
                //  SaveData(2, ref strReturnMSG, ref strReturnRefNo, ref intReturnPKNo);
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

        private void SutOpeningStock_Load(object sender, EventArgs e)
        {
            FillGrid(201);
            FillGrid(202);
        }
  
    }
}
