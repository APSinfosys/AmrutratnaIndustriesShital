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
    public partial class Master_EmptyBeam : Form
    {
        public Master_EmptyBeam()
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


                dtReturn = ClsDefination.FillData("[Master_EmptyBeam_DML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 201)
                    {
                        cmbShade.DataSource = dtReturn;
                        cmbShade.DisplayMember = "L_ShadeName";
                        cmbShade.ValueMember = "L_Code";
                        cmbShade.SelectedValue = -1;
                        cmbShade.Text = "<--SELECT-->";
                    }


                }
                else
                {
                    if (QueryNo == 201)
                    {
                        cmbShade.DataSource = dtReturn;
                        cmbShade.SelectedValue = -1;
                        cmbShade.Text = "<--NO RECORD-->";
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
                      //  hash.Add("@intLCode", Convert.ToInt32(lblSrNo.Text));
                    }
                    //@intBeamCode,,
                    hash.Add("@intShade", Convert.ToInt32(cmbShade.SelectedValue));
                    hash.Add("@intNoOfBeams", txtNoOfBeams.Text);
                    
                    string strXmlDetail = "";

                    StringBuilder xmlClassMaster = new StringBuilder();
                    //int i = 0;
                    for (int k = 1; k <= Convert.ToInt32(txtNoOfBeams.Text); k++)
                    {

                        xmlClassMaster.Append("<Row>");
                        //,,
                        xmlClassMaster.Append("<Beam_No>" + k + "</Beam_No>");

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
                return ClsDefination.InsertExecute(hash, "[Master_EmptyBeam_DML]", ref strReturnMSG, ref strReturnNo, ref intReturnNo);
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

        private void Master_EmptyBeam_Load(object sender, EventArgs e)
        {
            FillGrid(201);
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
