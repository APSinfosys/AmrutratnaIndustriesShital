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
    public partial class BeamOutward : Form
    {
        public BeamOutward()
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

                if (QueryNo == 202)
                {
                    hash.Add("@intParty", cmbPartyName.SelectedValue);
                    //SI_FromParty
                }
                if (QueryNo == 303)
                {
                    hash.Add("@intParty", Convert.ToInt32(lblSizingCode.Text));
                    //
                }

                if (QueryNo == 301 || QueryNo == 303)
                {
                    hash.Add("@strSatNo", cmbSatNo.Text);
                }
                if (QueryNo == 302 || QueryNo == 303 || QueryNo == 205)
                {
                    hash.Add("@intContractNo", Convert.ToInt32(cmbContract.SelectedValue));
                }
                if (QueryNo == 303)
                {
                    hash.Add("@intShade", cmbShade.SelectedValue);
                    hash.Add("@intQulity", cmbQuality.SelectedValue);
                }

                dtReturn = ClsDefination.FillData("[Transaction_BeamOutward_DML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 102)
                    {
                        //  GridValidation();
                    }
                    else if (QueryNo == 201)
                    {
                        cmbPartyName.DataSource = dtReturn;
                        cmbPartyName.ValueMember = "P_Code";
                        cmbPartyName.DisplayMember = "P_CompanyName";
                        cmbPartyName.SelectedIndex = -1;
                        cmbPartyName.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 202)
                    {
                        cmbContract.DataSource = dtReturn;
                        cmbContract.DisplayMember = "contractNo";
                        cmbContract.ValueMember = "contractNo";
                        cmbContract.SelectedIndex = -1;
                        cmbContract.Text = "<--SELECT-->";
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
                        cmbBroker.DataSource = dtReturn;
                        cmbBroker.DisplayMember = "BR_Name";
                        cmbBroker.ValueMember = "BR_Code";
                        cmbBroker.SelectedIndex = -1;
                        cmbBroker.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 205)
                    {
                        cmbSatNo.DataSource = dtReturn;
                        cmbSatNo.DisplayMember = "SI_SatNo";
                        cmbSatNo.SelectedIndex = -1;
                        cmbSatNo.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 206)
                    {
                        //,
                        cmbShade.DataSource = dtReturn;
                        cmbShade.DisplayMember = "L_ShadeName";
                        cmbShade.ValueMember = "L_Code";
                        cmbShade.SelectedIndex = -1;
                        cmbShade.Text = "<--SELECT-->";

                    }
                    else if (QueryNo == 301)
                    {
                        lblSizingCode.Text = objRow["SI_FromParty"].ToString();
                        txtSizingName.Text = objRow["P_CompanyName"].ToString();
                    }
                    else if (QueryNo == 302)
                    {
                        cmbBroker.SelectedValue = Convert.ToInt32(objRow["brokerCode"].ToString());
                        cmbQuality.SelectedValue = Convert.ToInt32(objRow["qualityCode"].ToString());
                    }
                    else if (QueryNo == 303)
                    {
                        dgvDesign.DataSource = dtReturn;

                        dgvDesign.Columns[0].Visible = false;
                        dgvDesign.Columns[2].Visible = false;
                        dgvDesign.Columns[4].Visible = false;
                        //SI.SI_Code as [SI CODE],SID.SI_BNo as [BEAM NO],SID.SI_Cuts as [CUTS],SID.SI_Border as [BORDER],   3
                        //SID.BiCode as [BEAM CODE],SID.meter as [METER],(cast (0 as bit))as [SELECT]--,SI.UniqueCode     6

                    }

                }
                else
                {
                    if (QueryNo == 102)
                    {
                        //  GridValidation();
                    }
                    else if (QueryNo == 201)
                    {
                        cmbPartyName.DataSource = dtReturn;
                        cmbPartyName.SelectedIndex = -1;
                        cmbPartyName.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 202)
                    {
                        cmbContract.DataSource = dtReturn;
                        cmbContract.SelectedIndex = -1;
                        cmbContract.Text = "<--NO RECORD-->";

                        cmbQuality.SelectedIndex = -1;
                        cmbQuality.Text = "<--NO RECORD-->";

                        cmbBroker.SelectedIndex = -1;
                        cmbBroker.Text = "<--NO RECORD-->";

                        cmbSatNo.DataSource = null;
                        cmbSatNo.SelectedIndex = -1;
                        cmbSatNo.Text = "<--NO RECORD-->";

                        txtSizingName.Text = "";
                        lblSizingCode.Text = "0";
                    }
                    else if (QueryNo == 203)
                    {
                        cmbQuality.DataSource = dtReturn;
                        cmbQuality.SelectedIndex = -1;
                        cmbQuality.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 204)
                    {
                        cmbBroker.DataSource = dtReturn;
                        cmbBroker.SelectedIndex = -1;
                        cmbBroker.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 205)
                    {
                        cmbSatNo.DataSource = dtReturn;
                        cmbSatNo.SelectedIndex = -1;
                        cmbSatNo.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 206)
                    {
                        //,
                        cmbShade.DataSource = dtReturn;
                        cmbShade.SelectedIndex = -1;
                        cmbShade.Text = "<--NO RECORD-->";

                    }
                    else if (QueryNo == 301)
                    {
                        lblSizingCode.Text = "0";
                        txtSizingName.Text = "";
                    }
                    else if (QueryNo == 302)
                    {
                        cmbBroker.SelectedValue = -1;
                        cmbBroker.Text = "<--NO RECORD-->";
                        cmbQuality.SelectedValue = -1;
                        cmbQuality.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 303)
                    {
                        dgvDesign.DataSource = dtReturn;
                        dgvDesign.Columns[0].Visible = false;
                        dgvDesign.Columns[2].Visible = false;
                        dgvDesign.Columns[4].Visible = false;
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
                hash.Add("@intCreatedby", fd.UserId);
                hash.Add("@intCompanyId", fd.CompId);
                hash.Add("@intYearId", fd.YearId);

                if (QueryNo == 1 || QueryNo == 2)
                {

                    if (QueryNo == 2)
                    {
                        hash.Add("@strUniqueCode", lblUniqueCode.Text);
                        hash.Add("@intCode", Convert.ToInt32(lblSrNo.Text));
                    }

                    hash.Add("@dtpDate", dtpInvoiceDate.Value.ToString("MM/dd/yyyy"));
                    hash.Add("@intParty", cmbPartyName.SelectedValue);
                    hash.Add("@intContractNo", cmbContract.Text);
                    hash.Add("@intQulity", cmbQuality.SelectedValue);
                    hash.Add("@strSatNo", cmbSatNo.Text);
                    hash.Add("@strSizingName", txtSizingName.Text);
                    hash.Add("@strFromParty", txtSizingName.Text);
                    hash.Add("@intFromParty", lblSizingCode.Text);
                    hash.Add("@intShade", cmbShade.SelectedValue);
                    hash.Add("@intBroker", cmbBroker.SelectedValue);
                    //   @intGetpassNo,,,,,,,
                    //,,@,GETDATE(),@,@,1,
                    //@
                    string strXmlDetail = "";

                    StringBuilder xmlClassMaster = new StringBuilder();

                    for (int k = 0; k < dgvDesign.Rows.Count; k++)
                    {
                        //                        select SI.SI_Code as [SI CODE],SID.SI_BNo as [BEAM NO],SID.SI_Cuts as [CUTS],SID.SI_Border as [BORDER],
                        //SID.BiCode as [BEAM CODE],SID.meter as [METER],(cast (0 as bit))as [SELECT]

                        if (Convert.ToBoolean(dgvDesign.Rows[k].Cells[6].Value) == true)
                        {
                            xmlClassMaster.Append("<Row>");
                            //,,,,,,,
                            xmlClassMaster.Append("<BO_BNO>" + dgvDesign.Rows[k].Cells[1].Value.ToString() + "</BO_BNO>");
                            //  xmlClassMaster.Append("<B_SatNo>" + dgvDesign.Rows[k].Cells[4].Value.ToString() + "</B_SatNo>");
                            xmlClassMaster.Append("<B_Border>" + dgvDesign.Rows[k].Cells[3].Value.ToString() + "</B_Border>");
                            xmlClassMaster.Append("<B_BOCode>" + dgvDesign.Rows[k].Cells[4].Value.ToString() + "</B_BOCode>");
                            xmlClassMaster.Append("<meter>" + (Convert.ToDecimal(dgvDesign.Rows[k].Cells[5].Value)) + "</meter>");
                            // xmlClassMaster.Append("<weaver>" + dgvDesign.Rows[k].Cells[3].Value.ToString() + "</weaver>");

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
                return ClsDefination.InsertExecute(hash, "[Transaction_BeamOutward_DML]", ref strReturnMSG, ref strReturnNo, ref intReturnNo);
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

        private void BeamOutward_Load(object sender, EventArgs e)
        {
            FillGrid(201);
            FillGrid(203);
            FillGrid(204);
            FillGrid(206);
            FillGrid(207);
        }

        private void cmbPartyName_Leave(object sender, EventArgs e)
        {
            if (cmbPartyName.SelectedIndex > -1)
            {
                FillGrid(202);
            }
        }

        private void cmbContract_Leave(object sender, EventArgs e)
        {
            if (cmbContract.SelectedIndex > -1)
            {
                FillGrid(205);
                FillGrid(302);
            }
        }

        private void cmbSatNo_Leave(object sender, EventArgs e)
        {
            if (cmbSatNo.SelectedIndex > -1)
            {
                FillGrid(301);
            }
        }

        private void cmbShade_Leave(object sender, EventArgs e)
        {
            if (cmbShade.SelectedIndex > -1)
            {
                FillGrid(303);
            }
        }
    }
}
