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
    public partial class VivingLoad : Form
    {
        public VivingLoad()
        {
            InitializeComponent();
        }


        #region variables
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        public int cmbShadeV, cmbLTV, cmbPV, cmbSV, cmbBV, cmbLNV, cmbQV,res;
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
                hash.Add("@intFormType", 0);

                if (QueryNo == 202 || QueryNo == 203 || QueryNo == 501 || QueryNo == 601)
                {
                    hash.Add("@intShade", cmbShade.SelectedValue);
                }
                if (QueryNo == 203 || QueryNo == 501 || QueryNo == 601)
                {
                    hash.Add("@intLoomType", cmbLoomType.SelectedValue);
                }
                if (QueryNo == 205 || QueryNo == 206 || QueryNo == 301 || QueryNo == 302 || QueryNo == 502 || QueryNo == 601 || QueryNo == 504)
                {
                    hash.Add("@intPatry", cmbPartyName.SelectedValue);
                }
                if (QueryNo == 206 || QueryNo == 302 || QueryNo == 502 || QueryNo == 601)
                {
                    hash.Add("@intSatNo", cmbSatNo.SelectedValue);
                }
                if (QueryNo == 303 || QueryNo == 601)
                {
                    hash.Add("@intBiNo", cmbBiNO.SelectedValue);
                }
                if (QueryNo == 204 || QueryNo == 205 || QueryNo == 206 || QueryNo == 502 || QueryNo == 601 || QueryNo == 503 || QueryNo == 504)
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
                    else if (QueryNo == 203 || QueryNo == 501)
                    {
                        //  L_No
                        cmbLoomNo.DataSource = dtReturn;
                        cmbLoomNo.DisplayMember = "L_No";
                        cmbLoomNo.ValueMember = "L_No";
                        cmbLoomNo.SelectedValue = -1;
                        cmbLoomNo.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 204 || QueryNo == 503)
                    {
                        //
                        cmbPartyName.DataSource = dtReturn;
                        cmbPartyName.DisplayMember = "P_CompanyName";
                        cmbPartyName.ValueMember = "P_Code";
                        cmbPartyName.SelectedValue = -1;
                        cmbPartyName.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 205 || QueryNo == 504)
                    {
                        //SatNo
                        cmbSatNo.DataSource = dtReturn;
                        cmbSatNo.DisplayMember = "SatNo";
                        cmbSatNo.ValueMember = "SatNo";
                        cmbSatNo.SelectedValue = -1;
                        cmbSatNo.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 206 || QueryNo == 502)
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
                        lblSatCount.Text = objRow["SI_COUNT"].ToString();
                    }
                    else if (QueryNo == 303)
                    {
                        lblBiCuts.Text = objRow["BiCut"].ToString();
                    }
                    else if (QueryNo == 401)
                    {
                        cmbQuality.DataSource = dtReturn;
                        cmbQuality.DisplayMember = "Q_Name";
                        cmbQuality.ValueMember = "Q_Code";
                        cmbQuality.SelectedValue = -1;
                        cmbQuality.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 601)
                    {
                       // res= objRow["res"].ToString();
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
                    else if (QueryNo == 203)
                    {
                        //  L_No
                        cmbLoomNo.DataSource = dtReturn;
                        cmbLoomNo.SelectedValue = -1;
                        cmbLoomNo.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 204)
                    {
                        //
                        cmbPartyName.DataSource = dtReturn;
                        cmbPartyName.SelectedValue = -1;
                        cmbPartyName.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 205)
                    {
                        //SatNo
                        cmbSatNo.DataSource = dtReturn;
                        cmbSatNo.SelectedValue = -1;
                        cmbSatNo.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 206)
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
                hash.Add("@intcreatedBy", Convert.ToInt32(fd.UserId));
                hash.Add("@intcompanyId", Convert.ToInt32(fd.CompId));
                hash.Add("@inryearId", Convert.ToInt32(fd.YearId));

                if (QueryNo == 1 || QueryNo == 2)
                {

                    if (QueryNo == 2)
                    {
                        hash.Add("@intCode", Convert.ToInt32(lblSrNo.Text));
                    }
                    hash.Add("@dtpDate", dtpDate.Value.ToString("MM/dd/yyyy"));
                    hash.Add("@intShade", cmbShade.SelectedValue);
                    hash.Add("@intLoomType", cmbLoomType.SelectedValue);
                    hash.Add("@intLoomNo", cmbLoomNo.SelectedValue);
                    //               ,,,,,
                    hash.Add("@intPatry", cmbPartyName.SelectedValue);
                    hash.Add("@intSatNo", cmbSatNo.SelectedValue);
                    hash.Add("@decSatCount", Convert.ToDecimal(lblSatCount.Text));
                    hash.Add("@intBiNo", cmbBiNO.SelectedValue);
                    hash.Add("@decBiCut", Convert.ToDecimal(lblBiCuts.Text));
                    hash.Add("@strBeamNo", cmbBiNO.Text);
                    hash.Add("@intQuality", Convert.ToInt32(cmbQuality.SelectedValue));
                    hash.Add("@strSatNo", cmbSatNo.Text);
                    hash.Add("@intFormType", 0);
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


        private void VivingLoad_Load(object sender, EventArgs e)
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
                cmbLoomNo.SelectedValue = cmbLNV;
                cmbQuality.SelectedValue = cmbQV;
                FillGrid(503);
                cmbPartyName.SelectedValue = cmbPV;
                FillGrid(504);
                cmbSatNo.SelectedValue = cmbSV;
                FillGrid(502);
                cmbBiNO.SelectedValue = cmbBV;
            }

        }

        private void cmbShade_Leave(object sender, EventArgs e)
        {

            if (cmbShade.Text != "<--SELECT-->" && cmbShade.Text != "<--NO RECORD-->" && Convert.ToInt32(cmbShade.SelectedValue) > 0 && cmbShade.SelectedValue != null
                && cmbShade.SelectedValue != "System.Data.DataRowView")
            {
                FillGrid(202);
            }
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please select shade";
                frm.type = "error";
                frm.ShowDialog();
                cmbShade.Focus();
            }

            if (newOrEdit == 1)
            {
                cmbLoomType.SelectedValue = cmbLTV;
            }

        }

        private void cmbLoomType_Leave(object sender, EventArgs e)
        {


            if (cmbLoomType.Text != "<--SELECT-->" && cmbLoomType.Text != "<--NO RECORD-->" && Convert.ToInt32(cmbLoomType.SelectedValue) > 0) //&& cmbLoomType.SelectedValue != null
            // && cmbLoomType.SelectedValue.ToString() != "System.Data.DataRowView")
            //cmbLoomType.SelectedValue
            {
                FillGrid(203);
                if (newOrEdit == 1)
                {
                    FillGrid(501);
                }
            }
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please select loom type";
                frm.type = "error";
                frm.ShowDialog();
                cmbLoomType.Focus();
            }
            if (newOrEdit == 1)
            {
                cmbLoomNo.SelectedValue = cmbLNV;
            }
        }

        private void cmbPartyName_Leave(object sender, EventArgs e)
        {
            
                if (cmbPartyName.Text != "<--SELECT-->" && cmbPartyName.Text != "<--NO RECORD-->" && Convert.ToInt32(cmbPartyName.SelectedValue) > 0 && cmbPartyName.SelectedValue != null
                    && cmbPartyName.SelectedValue != "System.Data.DataRowView")
                {
                    FillGrid(301);
                    FillGrid(205);
                    if (newOrEdit == 1)
                    {
                        FillGrid(504);
                    }
                }
                else
                {
                    messageBox frm = new messageBox();
                    frm.messageTxt = "Please select party";
                    frm.type = "error";
                    frm.ShowDialog();
                    cmbPartyName.Focus();
                }
                if (newOrEdit == 1)
                {
                    cmbSatNo.SelectedValue = cmbSV;
                }
        }

        private void cmbSatNo_Leave(object sender, EventArgs e)
        {
                if (cmbSatNo.Text != "<--SELECT-->" && cmbSatNo.Text != "<--NO RECORD-->" && Convert.ToInt32(cmbSatNo.SelectedIndex) > -1 &&
                    cmbSatNo.SelectedValue != null
                    && cmbSatNo.SelectedValue != "System.Data.DataRowView")
                {
                    FillGrid(302);
                    FillGrid(206);
                    if (newOrEdit == 1)
                    {
                        FillGrid(502);
                    }
                }
                else
                {
                    messageBox frm = new messageBox();
                    frm.messageTxt = "Please select sat no";
                    frm.type = "error";
                    frm.ShowDialog();
                    cmbSatNo.Focus();
                }
                if (newOrEdit == 1)
                {
                    cmbBiNO.SelectedValue = cmbBV;
                }
        }

        private void cmbBiNO_Leave(object sender, EventArgs e)
        {
            if (newOrEdit == 0)
            {
                if (cmbBiNO.Text != "<--SELECT-->" && cmbBiNO.Text != "<--NO RECORD-->" && Convert.ToInt32(cmbBiNO.SelectedValue) > 0 && cmbBiNO.SelectedValue != null
                    && cmbBiNO.SelectedValue != "System.Data.DataRowView")
                {
                    FillGrid(303);
                }
                else
                {
                    messageBox frm = new messageBox();
                    frm.messageTxt = "Please select biem no";
                    frm.type = "error";
                    frm.ShowDialog();
                    cmbBiNO.Focus();
                }
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
               // FillGrid(601);

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

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbQuality_Leave(object sender, EventArgs e)
        {

            if (cmbQuality.Text != "<--SELECT-->" && cmbQuality.Text != "<--NO RECORD-->" && Convert.ToInt32(cmbQuality.SelectedValue) > 0 && cmbQuality.SelectedValue != null
               && cmbQuality.SelectedValue != "System.Data.DataRowView")
            {
                FillGrid(204);
                if (newOrEdit == 1)
                {
                    FillGrid(503);
                }
            }
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please select quality";
                frm.type = "error";
                frm.ShowDialog();
                // cmbQuality.Focus();
            }
            if (newOrEdit == 1)
            {
                cmbPartyName.SelectedValue = cmbPV;
            }

        }

    }
}
