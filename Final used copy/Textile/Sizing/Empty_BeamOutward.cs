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

namespace Textile.Sizing
{
    public partial class Empty_BeamOutward : Form
    {
        public Empty_BeamOutward()
        {
            InitializeComponent();
        }

        #region variables
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        public string owner;
        public int cmbPV, cmbQV, cmbSV, cmbBV, cmbCV;
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

                if (QueryNo == 301)
                {
                    hash.Add("@intShade",cmbShade.SelectedValue);
                }
                if (QueryNo == 206)
                {
                    hash.Add("@intID",cmbSatNo.SelectedValue);
                }

                dtReturn = ClsDefination.FillData("[Transaction_EmptyBeamOutward_DML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 201)
                    {
                        cmbFirmName.DataSource = dtReturn;
                        cmbFirmName.DisplayMember = "F_CompanyName";
                        cmbFirmName.ValueMember = "F_Code";
                        cmbFirmName.SelectedIndex = -1;
                        cmbFirmName.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 202)
                    {
                        cmbPartName.DataSource = dtReturn;
                        cmbPartName.DisplayMember = "P_CompanyName";
                        cmbPartName.ValueMember = "P_Code";
                        cmbPartName.SelectedIndex = -1;
                        cmbPartName.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 203)
                    {
                        cmbQuality.DataSource = dtReturn;
                        cmbQuality.DisplayMember = "Q_Name";
                        cmbQuality.ValueMember = "Q_Code";
                        cmbQuality.SelectedIndex = -1;
                        cmbQuality.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 204)
                    {
                        cmbShade.DataSource = dtReturn;
                        cmbShade.DisplayMember = "L_ShadeName";
                        cmbShade.ValueMember = "L_Code";
                        cmbShade.SelectedIndex = -1;
                        cmbShade.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 205)
                    {
                        cmbSatNo.DataSource = dtReturn;
                        cmbSatNo.DisplayMember = "SatNo";
                        cmbSatNo.ValueMember = "Id";
                        cmbSatNo.SelectedIndex = -1;
                        cmbSatNo.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 206)
                    {
                        lblQuality.Text = objRow["QualityName"].ToString();
                    }
                    else if (QueryNo == 301)
                    {
                        dgvDesign.DataSource = dtReturn;
                    }

                }
                else
                {
                    if (QueryNo == 201)
                    {
                        cmbFirmName.DataSource = dtReturn;
                        cmbFirmName.SelectedIndex = -1;
                        cmbFirmName.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 202)
                    {
                        cmbPartName.DataSource = dtReturn;
                        cmbPartName.SelectedIndex = -1;
                        cmbPartName.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 203)
                    {
                        cmbQuality.DataSource = dtReturn;
                        cmbQuality.SelectedIndex = -1;
                        cmbQuality.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 204)
                    {
                        cmbShade.DataSource = dtReturn;
                        cmbShade.SelectedIndex = -1;
                        cmbShade.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 205)
                    {
                        cmbSatNo.DataSource = dtReturn;
                        cmbSatNo.SelectedIndex = -1;
                        cmbSatNo.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 206)
                    {
                        lblQuality.Text = "NO QUALITY FOUND";
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
                        hash.Add("@intGetpassNo", Convert.ToInt32(lblSrNo.Text));
                    }

                    hash.Add("@dtpGPDate",dtpInvoiceDate.Value.ToString("MM/dd/yyyy"));
                    hash.Add("@intFromParty",Convert.ToInt32(cmbFirmName.SelectedValue));
                    hash.Add("@intToParty",Convert.ToInt32(cmbPartName.SelectedValue));
                    hash.Add("@intQuality", 0);

                    hash.Add("@strSatNo",cmbSatNo.Text);
                    if (txtSizingChallan.Text == "")
                    {
                        txtSizingChallan.Text = "N/A";
                    }
                    hash.Add("@strSizingChallan",txtSizingChallan.Text);
                    hash.Add("@dtpSizingdate",dtpSizingDate.Value.ToString("MM/dd/yyyy"));
                   
                   // hash.Add("@decTotalEnds",Convert.ToDecimal(txtTotalEnds.Text));
                    hash.Add("@strVehicalNo",txtVehicalNo.Text);
                    hash.Add("@intShade",Convert.ToInt32(cmbShade.SelectedValue));
    //                ,,,,,,,,
    //,,,@,GETDATE(),1,@,@,

                    hash.Add("@intSatNovalue",cmbSatNo.SelectedValue);
                    hash.Add("@strQualityName", lblQuality.Text);


                    string strXmlDetail = "";

                    StringBuilder xmlClassMaster = new StringBuilder();

                    for (int k = 0; k < dgvDesign.Rows.Count; k++)
                    {

                        if (Convert.ToBoolean(dgvDesign.Rows[k].Cells[1].Value) == true)
                        {
                            xmlClassMaster.Append("<Row>");
                            xmlClassMaster.Append("<Beam_No>" + dgvDesign.Rows[k].Cells[0].Value.ToString() + "</Beam_No>");
                            xmlClassMaster.Append("</Row>");
                        }
                    }

                    if (xmlClassMaster.Length > 0)
                    {
                        xmlClassMaster.Append("</ProductSupplierDetails>");
                        strXmlDetail = "<ProductSupplierDetails>" + Convert.ToString(xmlClassMaster);
                    }

                    hash.Add("@strXmlDetail", strXmlDetail);
                }

                okflag = 1;
                return ClsDefination.InsertExecute(hash, "[Transaction_EmptyBeamOutward_DML]", ref strReturnMSG, ref strReturnNo, ref intReturnNo);
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

        private void Empty_BeamOutward_Load(object sender, EventArgs e)
        {
            FillGrid(201);
            FillGrid(202);
            FillGrid(203);
            FillGrid(204);
            FillGrid(205);
        }

        private void cmbShade_Leave(object sender, EventArgs e)
        {
            if (cmbShade.SelectedIndex > -1)
            {
                FillGrid(301);
            }
        }

        private void cmbSatNo_Leave(object sender, EventArgs e)
        {
            if (cmbSatNo.SelectedIndex > -1)
            {
                FillGrid(206);
            }
        }
    }
}
