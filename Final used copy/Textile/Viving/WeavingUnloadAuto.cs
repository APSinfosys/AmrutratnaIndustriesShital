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

namespace Textile.Viving
{
    public partial class WeavingUnloadAuto : Form
    {
        public WeavingUnloadAuto()
        {
            InitializeComponent();
        }

        #region variables
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        public int cmbShadeV, cmbLTV, cmbPV, cmbQV, cmbLV;
        public string cmbSV, cmbBV;
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
                hash.Add("@intFormType", 1);

                if (QueryNo == 202 || QueryNo == 203 || QueryNo == 2031 || QueryNo == 501)
                {
                    hash.Add("@intShade", cmbShade.SelectedValue);
                }
                if (QueryNo == 203 || QueryNo == 2031 || QueryNo == 501)
                {
                    hash.Add("@intLoomType", cmbLoomType.SelectedValue);
                }
                if (QueryNo == 205 || QueryNo == 2051 || QueryNo == 206 || QueryNo == 2061 || QueryNo == 301 || QueryNo == 302
                    || QueryNo == 502 || QueryNo == 504)
                {
                    hash.Add("@intPatry", cmbPartyName.SelectedValue);
                }
                if (QueryNo == 206 || QueryNo == 2061 || QueryNo == 302 || QueryNo == 502)
                {
                    hash.Add("@strSatNo", cmbSatNo.SelectedValue);
                }
                if (QueryNo == 303)
                {
                    hash.Add("@intBiNo", cmbBiNO.SelectedValue);
                }
                if (QueryNo == 204 || QueryNo == 2041 || QueryNo == 205 || QueryNo == 2051 || QueryNo == 206 || QueryNo == 2061
                    || QueryNo == 502 || QueryNo == 503 || QueryNo == 504)
                {
                    hash.Add("@intQuality", cmbQuality.SelectedValue);
                }

                dtReturn = ClsDefination.FillData("[VivingMaster_DML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];
                    if (QueryNo == 201)
                    {
                        //L_Code as [],L_ShadeName+' - '+L_ShadeLocation as []
                        cmbShade.DataSource = dtReturn;
                        cmbShade.DisplayMember = "NAME";
                        cmbShade.ValueMember = "CODE";
                        cmbShade.SelectedValue = -1;
                        cmbShade.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 202)
                    {
                        //,
                        cmbLoomType.DataSource = dtReturn;
                        cmbLoomType.DisplayMember = "L_TYpe";
                        cmbLoomType.ValueMember = "L_TypeCode";
                        cmbLoomType.SelectedValue = -1;
                        cmbLoomType.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 203 || QueryNo == 501 || QueryNo == 2031)
                    {
                        //  L_No
                        cmbLoomNo.DataSource = dtReturn;
                        cmbLoomNo.DisplayMember = "L_No";
                        cmbLoomNo.ValueMember = "L_No";
                        cmbLoomNo.SelectedValue = -1;
                        cmbLoomNo.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 204 || QueryNo == 503 || QueryNo == 2041)
                    {
                        //
                        cmbPartyName.DataSource = dtReturn;
                        cmbPartyName.DisplayMember = "P_CompanyName";
                        cmbPartyName.ValueMember = "P_Code";
                        cmbPartyName.SelectedValue = -1;
                        cmbPartyName.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 205 || QueryNo == 504 || QueryNo == 2051)
                    {
                        //SatNo
                        cmbSatNo.DataSource = dtReturn;
                        cmbSatNo.DisplayMember = "SatNo";
                        cmbSatNo.ValueMember = "SatNo";
                        cmbSatNo.SelectedValue = -1;
                        cmbSatNo.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 206 || QueryNo == 502 || QueryNo == 2061)
                    {
                        //SatNo
                        cmbBiNO.DataSource = dtReturn;
                        cmbBiNO.DisplayMember = "BiNo";
                        cmbBiNO.ValueMember = "BiCode";
                        cmbBiNO.SelectedValue = -1;
                        cmbBiNO.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 301)
                    {
                        lblOwner.Text = objRow["P_OwnerName"].ToString();
                    }
                    else if (QueryNo == 302)
                    {
                        lblSatCount.Text = objRow["B_Count"].ToString();
                    }
                    else if (QueryNo == 303)
                    {
                        lblBiCuts.Text = objRow["meter"].ToString();
                    }
                    else if (QueryNo == 401)
                    {
                        cmbQuality.DataSource = dtReturn;
                        cmbQuality.DisplayMember = "Q_Name";
                        cmbQuality.ValueMember = "Q_Code";
                        cmbQuality.SelectedValue = -1;
                        cmbQuality.Text = "<--SELECT-->";
                    }
                }
                else
                {
                    if (QueryNo == 201)
                    {
                        //L_Code as [],L_ShadeName+' - '+L_ShadeLocation as []
                        cmbShade.DataSource = dtReturn;
                        cmbShade.SelectedValue = -1;
                        cmbShade.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 202)
                    {
                        //,
                        cmbLoomType.DataSource = dtReturn;
                        cmbLoomType.SelectedValue = -1;
                        cmbLoomType.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 203 || QueryNo == 2031)
                    {
                        //  L_No
                        cmbLoomNo.DataSource = dtReturn;
                        cmbLoomNo.SelectedValue = -1;
                        cmbLoomNo.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 204 || QueryNo == 503 || QueryNo == 2041)
                    {
                        //
                        cmbPartyName.DataSource = dtReturn;
                        cmbPartyName.SelectedValue = -1;
                        cmbPartyName.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 205 || QueryNo == 2051)
                    {
                        //SatNo
                        cmbSatNo.DataSource = dtReturn;
                        cmbSatNo.SelectedValue = -1;
                        cmbSatNo.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 206 || QueryNo == 2061)
                    {
                        //SatNo
                        cmbBiNO.DataSource = dtReturn;
                        cmbBiNO.SelectedValue = -1;
                        cmbBiNO.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 301)
                    {
                        lblOwner.Text = "NO RECORD";
                    }
                    else if (QueryNo == 302)
                    {
                        lblSatCount.Text = "NO RECORD";
                    }
                    else if (QueryNo == 303)
                    {
                        lblBiCuts.Text = "NO RECORD";
                    }
                    else if (QueryNo == 401)
                    {
                        cmbQuality.DataSource = dtReturn;
                        cmbQuality.SelectedValue = -1;
                        cmbQuality.Text = "<--NO RECORD-->";
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

                if (QueryNo == 5 )
                {


                        hash.Add("@strUniqueCode", lblUniqueCode.Text);
                        hash.Add("@intCode", Convert.ToInt32(lblSrNo.Text));
                    

                }

                okflag = 1;
                return ClsDefination.InsertExecute(hash, "[VivingMaster_DML]", ref strReturnMSG, ref strReturnNo, ref intReturnNo);
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

        private void WeavingUnloadAuto_Load(object sender, EventArgs e)
        {
            FillGrid(201);
            //FillGrid(204);
            FillGrid(401);
            if (newOrEdit == 0)
            {
                cmbBiNO.Text = "<--SELECT-->";
                cmbLoomNo.Text = "<--SELECT-->";
                cmbLoomType.Text = "<--SELECT-->";
                cmbSatNo.Text = "<--SELECT-->";
            }

            if (newOrEdit == 1)
            {
                cmbShade.SelectedValue = cmbShadeV;
                FillGrid(202);
                cmbLoomType.SelectedValue = cmbLTV;
                FillGrid(501);
                FillGrid(2031);
                cmbLoomNo.SelectedValue = cmbLV;
                cmbQuality.SelectedValue = cmbQV;
                FillGrid(503);
                FillGrid(2041);
                cmbPartyName.SelectedValue = cmbPV;
                FillGrid(504);
                FillGrid(2051);
                cmbSatNo.SelectedValue = cmbSV;
                FillGrid(502);
                FillGrid(2061);
                cmbBiNO.SelectedValue = cmbBV;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (newOrEdit == 0)
            {
             //   SaveData(1, ref strReturnMSG, ref strReturnRefNo, ref intReturnPKNo);
            }
            else
            {
                SaveData(5, ref strReturnMSG, ref strReturnRefNo, ref intReturnPKNo);
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
                    frm.messageTxt = "Beam Unloaded Successfully";// +strReturnMSG;
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
