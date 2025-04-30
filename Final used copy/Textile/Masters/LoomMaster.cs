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
    public partial class LoomMaster : Form
    {
        public LoomMaster()
        {
            InitializeComponent();
        }

        #region variables
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        string strReturnMSG, strReturnRefNo;
        int intReturnPKNo;
        int result, okflag;
        public int cmbLTV;
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


                dtReturn = ClsDefination.FillData("[Master_LoomDML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 201)
                    {
                        cmbLoomType.DataSource = dtReturn;
                        cmbLoomType.DisplayMember = "Common_Value";
                        cmbLoomType.ValueMember = "Common_Id";
                        cmbLoomType.SelectedValue = -1;
                        cmbLoomType.Text = "<--SELECT-->";
                    }
                    

                }
                else
                {
                    if (QueryNo == 201)
                    {
                        cmbLoomType.DataSource = dtReturn;
                        cmbLoomType.SelectedValue = -1;
                        cmbLoomType.Text = "<--NO RECORD-->";
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
                       // hash.Add("@strUniqueCode",lblUniqueCode.Text);
                        hash.Add("@intLCode", Convert.ToInt32(lblSrNo.Text));
                    }
                    hash.Add("@strLSName", txtShadeName.Text);
                    hash.Add("@strLSLocation", txtShadeLocetion.Text);
                    hash.Add("@strLType", cmbLoomType.Text);
                    hash.Add("@intNoLooms", txtNoOfLoom.Text);
                    hash.Add("@intLType",cmbLoomType.SelectedValue);

                    string strXmlDetail = "";

                    StringBuilder xmlClassMaster = new StringBuilder();
                    //int i = 0;
                    for (int k = 1; k <= Convert.ToInt32(txtNoOfLoom.Text); k++)
                    {
                        
                        xmlClassMaster.Append("<Row>");
                        //,,
                        xmlClassMaster.Append("<L_No>" + k + "</L_No>");

                        xmlClassMaster.Append("</Row>");
                    }

                    if (xmlClassMaster.Length > 0)
                    {
                        xmlClassMaster.Append("</ProductSupplierDetails>");
                        strXmlDetail = "<ProductSupplierDetails>" + Convert.ToString(xmlClassMaster);
                    }

                    hash.Add("@strXmlDetail", strXmlDetail);

                }

                okflag = 1;
                return ClsDefination.InsertExecute(hash, "[Master_LoomDML]", ref strReturnMSG, ref strReturnNo, ref intReturnNo);
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

        private void LoomMaster_Load(object sender, EventArgs e)
        {
            FillGrid(201);
            if (newOrEdit == 1)
            {
                cmbLoomType.SelectedValue = cmbLTV;
            }
        }
    }
}
