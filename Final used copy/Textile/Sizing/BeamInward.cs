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
    public partial class BeamInward : Form
    {
        public BeamInward()
        {
            InitializeComponent();
        }

        #region variables
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        public string owner;
        public int cmbPV, cmbQV, cmbSV,cmbBV,cmbCV,cmbSN;
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

                if (QueryNo == 202 || QueryNo == 102)
                {
                    hash.Add("@intCode", lblSrNo.Text);
                    hash.Add("@strSatNo", txtSatNo.Text);
                }
                if (QueryNo == 401 || QueryNo == 503)
                {
                    hash.Add("@intParty", cmbPartyName.SelectedValue);
                }

                if (QueryNo == 601 || QueryNo == 602 || QueryNo == 701 || QueryNo == 702)
                {
                    hash.Add("@intContractCode", cmbContract.SelectedValue);
                }

                if (QueryNo == 603)
                {
                    hash.Add("@intShade",cmbShade.SelectedValue);
                    hash.Add("@intSizingName",cmbSizingName.SelectedValue);
                }

                dtReturn = ClsDefination.FillData("[Transaction_BeamInward_DML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 102)
                    {
                        dgvDesign.DataSource = dtReturn;
                        GridValidation();
                    }
                    if (QueryNo == 301)
                    {
                        cmbPartyName.DataSource = dtReturn;
                        cmbPartyName.ValueMember = "P_Code";
                        cmbPartyName.DisplayMember = "P_CompanyName";
                        cmbPartyName.SelectedIndex = -1;
                        cmbPartyName.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 302)
                    {
                        cmbQuality.DataSource = dtReturn;
                        cmbQuality.ValueMember = "D_Code";
                        cmbQuality.DisplayMember = "D_Name";
                        cmbQuality.SelectedIndex = -1;
                        cmbQuality.Text = "<--SELECT-->";
                    }

                    else if (QueryNo == 501)
                    {
                        cmbShade.DataSource = dtReturn;
                        cmbShade.DisplayMember = "Shade";
                        cmbShade.ValueMember = "ShadeCode";
                        cmbShade.SelectedIndex = -1;
                        cmbShade.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 502)
                    {
                        cmbBroker.DataSource = dtReturn;
                        cmbBroker.DisplayMember = "BR_Name";
                        cmbBroker.ValueMember = "BR_Code";
                        cmbBroker.SelectedIndex = -1;
                        cmbBroker.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 503)
                    {
                        //[],'N/A' as []
                        cmbContract.DataSource = dtReturn;
                        cmbContract.DisplayMember = "contractNoV";
                        cmbContract.ValueMember = "contractNo";
                        cmbContract.SelectedIndex = -1;
                        cmbContract.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 601)
                    {
                        cmbBroker.SelectedValue = Convert.ToInt32(objRow["brokerCode"].ToString());
                        lblQuality.Text = objRow["QualityName"].ToString();
                        cmbBroker.Enabled = false;
                       // cmbQuality.SelectedValue = Convert.ToInt32(objRow["qualityCode"].ToString());
                    }
                    else if (QueryNo == 602)
                    {
                        cmbSizingName.DataSource = dtReturn;
                        cmbSizingName.DisplayMember = "NAME";
                        cmbSizingName.ValueMember = "CODE";
                        cmbSizingName.SelectedIndex = -1;
                        cmbSizingName.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 603)
                    {
                        cmbBINo.DataSource = dtReturn;
                        cmbBINo.DisplayMember = "Beam_No";
                        cmbBINo.SelectedIndex = -1;
                        cmbBINo.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 701)
                    {
                        cmbSizingName.DataSource = dtReturn;
                        cmbSizingName.DisplayMember = "P_CompanyName";
                        cmbSizingName.ValueMember = "To_Party";
                        cmbSizingName.SelectedIndex = -1;
                        cmbSizingName.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 702)
                    {
                        cmbQuality.DataSource = dtReturn;
                        cmbQuality.DisplayMember = "DesignName";
                        cmbQuality.ValueMember = "Q_Code";
                        cmbQuality.SelectedIndex = -1;
                        cmbQuality.Text = "<--SELECT-->";
                    }
                }
                else
                {
                    if (QueryNo == 301)
                    {
                        cmbPartyName.DataSource = dtReturn;
                        cmbPartyName.SelectedIndex = -1;
                        cmbPartyName.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 401)
                    {
                        lblOwner.Text = "ERROR";
                        lblStateCode.Text = "ERROR";
                    }
                    else if (QueryNo == 302)
                    {
                        cmbQuality.DataSource = dtReturn;
                        cmbQuality.SelectedIndex = -1;
                        cmbQuality.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 501)
                    {
                        cmbShade.DataSource = dtReturn;
                        cmbShade.SelectedIndex = -1;
                        cmbShade.Text = "<--NO RECORD-->";
                    }

                    else if (QueryNo == 502)
                    {
                        cmbBroker.DataSource = dtReturn;
                        cmbBroker.SelectedIndex = -1;
                        cmbBroker.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 503)
                    {
                        //[],'N/A' as []
                        cmbContract.DataSource = dtReturn;
                        cmbContract.SelectedIndex = -1;
                        cmbContract.Text = "<--NO RECORD-->";
                    }
                    if (QueryNo == 102)
                    {
                        dgvDesign.DataSource = dtReturn;
                        GridValidation();
                    }
                    else if (QueryNo == 601)
                    {
                        cmbBroker.SelectedValue = 0;
                        lblQuality.Text = "NO RECORD FOUND";
                        // cmbQuality.SelectedValue = Convert.ToInt32(objRow["qualityCode"].ToString());
                    }
                    else if (QueryNo == 602)
                    {
                        cmbSizingName.DataSource = dtReturn;
                        cmbSizingName.SelectedIndex = -1;
                        cmbSizingName.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 603)
                    {
                        cmbBINo.DataSource = dtReturn;
                        cmbBINo.SelectedIndex = -1;
                        cmbBINo.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 701)
                    {
                        cmbSizingName.DataSource = dtReturn;
                        cmbSizingName.SelectedIndex = -1;
                        cmbSizingName.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 702)
                    {
                        cmbQuality.DataSource = dtReturn;
                        cmbQuality.SelectedIndex = -1;
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
                hash.Add("@intCreatedBy", fd.UserId);
                hash.Add("@intCompanyId", fd.CompId);
                hash.Add("@intYearId",fd.YearId);

                if (QueryNo == 1 || QueryNo == 2)
                {

                    if (QueryNo == 2)
                    {
                        hash.Add("@strUniqueCode", lblUniqueCode.Text);
                        hash.Add("@intCode", Convert.ToInt32(lblSrNo.Text));
                    }

                    hash.Add("@strSatNo",txtSatNo.Text);
                    hash.Add("@strInvoiceNo",txtInvoiceNo.Text);
                    hash.Add("@dtpDate",dtpInvoiceDate.Value.ToString("MM/dd/yyyy"));
                    hash.Add("@intParty",Convert.ToInt32(cmbPartyName.SelectedValue));
                    hash.Add("@intSizingName",Convert.ToInt32(cmbSizingName.SelectedValue));
                    hash.Add("@strSizing",txtSizingName.Text);
                    hash.Add("@intCount",Convert.ToDecimal(txtCount.Text));
         //           @,,,,,,,
                    hash.Add("@strYarnSource",txtYarnSource.Text);
                    hash.Add("@decWarf",Convert.ToDecimal(txtWarp.Text));
                    hash.Add("@decWeft",Convert.ToDecimal(txtWeft.Text));
                    hash.Add("@decReed",Convert.ToDecimal(txtReed.Text));
                    hash.Add("@decPick",Convert.ToDecimal(txtPick.Text));
                    hash.Add("@strWeave",txtWeave.Text);
                    hash.Add("@decCreelEnds",Convert.ToDecimal(txtCreelEnds.Text));
         //,,,,,,,
                    hash.Add("@decFunctionPart",Convert.ToDecimal(txtFunctionPart.Text));
                    hash.Add("@decTotalEnds",Convert.ToDecimal(txtTotalEnds.Text));
                    hash.Add("@decLength",Convert.ToDecimal(txtLength.Text));
                    hash.Add("@decCutMark",Convert.ToDecimal(txtCutMark.Text));
                    hash.Add("@strDBF",txtDBF.Text);
                    hash.Add("@decRate",Convert.ToDecimal(txtRatePerPick.Text));
         //,,,,,,
                    hash.Add("@intQuality",Convert.ToInt32(cmbQuality.SelectedValue));
                    hash.Add("@intShade",Convert.ToInt32(cmbShade.SelectedValue));
                   // cmbBroker.SelectedValue = 0;
                    hash.Add("@intBrocker",Convert.ToInt32(cmbBroker.SelectedValue));
         //,,,@,GETDATE(),1,@,@
                    hash.Add("@strFromParty", cmbPartyName.Text);

                    //,
                    hash.Add("@strContractNo",cmbContract.Text);
                    hash.Add("@intContractCode",Convert.ToInt32(cmbContract.SelectedValue));

                    string strXmlDetail = "";

                    StringBuilder xmlClassMaster = new StringBuilder();

                    for (int k = 0; k < dgvDesign.Rows.Count; k++)
                    {

                        xmlClassMaster.Append("<Row>");
                        //,, SI_BNo,,,,,,,,
                        xmlClassMaster.Append("<SI_BNo>" + dgvDesign.Rows[k].Cells[1].Value.ToString() + "</SI_BNo>");
                        xmlClassMaster.Append("<SI_SatNo>" + dgvDesign.Rows[k].Cells[4].Value.ToString() + "</SI_SatNo>");
                        xmlClassMaster.Append("<BiCode>" + dgvDesign.Rows[k].Cells[5].Value.ToString() + "</BiCode>");
                        xmlClassMaster.Append("<shade>" + (Convert.ToInt32(dgvDesign.Rows[k].Cells[6].Value)) + "</shade>");
                        xmlClassMaster.Append("<meter>" + (Convert.ToDecimal(dgvDesign.Rows[k].Cells[2].Value)) + "</meter>");
                        xmlClassMaster.Append("<weaver>" + dgvDesign.Rows[k].Cells[3].Value.ToString() + "</weaver>");
                        xmlClassMaster.Append("<Quality>" + dgvDesign.Rows[k].Cells[7].Value.ToString() + "</Quality>");
                        xmlClassMaster.Append("<QualityCode>" + (Convert.ToInt32(dgvDesign.Rows[k].Cells[8].Value)) + "</QualityCode>");
                        xmlClassMaster.Append("<Design>" + dgvDesign.Rows[k].Cells[9].Value.ToString() + "</Design>");
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
                return ClsDefination.InsertExecute(hash, "[Transaction_BeamInward_DML]", ref strReturnMSG, ref strReturnNo, ref intReturnNo);
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

        #region GridCreation
        public void GridCreation()
        {
            try
            {

                DataTable dt = new DataTable();

                dt.Columns.Add("X", typeof(string));          //0
                dt.Columns.Add("F NO", typeof(string));   //1
                dt.Columns.Add("METERS", typeof(decimal)); //2
                dt.Columns.Add("WEAVER", typeof(string)); // 3
                dt.Columns.Add("SAT NO", typeof(string)); // 4
                dt.Columns.Add("BI CODE", typeof(string)); // 5
                dt.Columns.Add("shade", typeof(int)); //6
                dt.Columns.Add("QUALITY", typeof(string));//7
                dt.Columns.Add("qualityCode", typeof(int));//8
                dt.Columns.Add("DESIGN",typeof(string));//9
               // SI_BNo,SI_SatNo,BiCode,shade,meter,weaver
                dgvDesign.DataSource = dt;
                GridValidation();

            }
            catch (Exception ex)
            {
            }
        }


        public void GridValidation()
        {
            //dgvDesign.Columns[4].Visible = false;
            dgvDesign.Columns[5].Visible = false;
            //dgvDesign.Columns[6].Visible = false;
            dgvDesign.Columns[6].Visible = false;
            dgvDesign.Columns[8].Visible = false;

        }
        #endregion


        private void BeamInward_Load(object sender, EventArgs e)
        {
            txtWeaver.Text = fd.CompanyNameStr;
            FillGrid(301);
            FillGrid(302);
            FillGrid(501);
            FillGrid(502);
            FillGrid(503);
          //  FillGrid(602);
            GridCreation();
            if (newOrEdit == 1)
            {
                cmbPartyName.SelectedValue = cmbPV;
                cmbQuality.SelectedValue = cmbQV;
                cmbShade.SelectedValue = cmbSV;
                cmbBroker.SelectedValue = cmbBV;

                FillGrid(503);
                cmbContract.SelectedValue = cmbCV;
                FillGrid(601);
                cmbContract.SelectedValue = cmbCV;
                
                FillGrid(701);
                cmbSizingName.SelectedValue = cmbSN;
                FillGrid(702);
                cmbQuality.SelectedValue = cmbQV;
                FillGrid(102);

            }
        }

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

                if (intReturnPKNo == 0)
                {
                    frm.messageTxt = strReturnMSG;
                    frm.type = "error";
                    frm.ShowDialog();
                }
                else
                {
                    if (newOrEdit == 0)
                    {
                        frm.messageTxt = "Rocord Saved Successfully";// +strReturnMSG;
                    }
                    else
                    {
                        frm.messageTxt = "Rocord Updated Successfully";// +strReturnMSG;
                    }
                    frm.type = "success";
                    frm.ShowDialog();
                    this.Close();
                }

                FillGrid(101);
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDesign.Rows.Count <= 0)
                {
                    GridCreation();
                    GridValidation();
                }

                int repete = 0;

                for (int i = 0; i < dgvDesign.Rows.Count; i++)
                {
                    if (cmbBINo.Text == dgvDesign.Rows[i].Cells[1].Value.ToString())
                    {
                        repete = 1;
                        break;
                    }
                }

                if (repete == 0)
                {
                    if (cmbBINo.SelectedIndex != -1)
                    {
                        if (txtMeters.Text != "")
                        {

                            DataTable dt = dgvDesign.DataSource as DataTable;

                            DataRow dr2 = dt.NewRow();

                            dr2["X"] = "X";
                            dr2["F NO"] = cmbBINo.Text;  //txtFNo.Text;
                            dr2["METERS"] = Convert.ToDecimal(txtMeters.Text);
                            dr2["WEAVER"] = txtWeaver.Text;
                            dr2["SAT NO"] = cmbContract.Text;
                            dr2["BI CODE"] = txtInvoiceNo.Text + cmbContract.Text + cmbBINo.Text;//txtFNo.Text;
                            dr2["shade"] = Convert.ToInt32(cmbShade.SelectedValue);
                            dr2["QUALITY"] = lblQuality.Text;
                            dr2["qualityCode"] = Convert.ToInt32(cmbQuality.SelectedValue);
                            dr2["DESIGN"] = cmbQuality.Text;

                            dt.Rows.Add(dr2);

                            dgvDesign.DataSource = dt;

                        }
                        else
                        {
                            messageBox frm = new messageBox();
                            frm.messageTxt = "Please enter meters";
                            frm.type = "error";
                            frm.ShowDialog();
                            txtMeters.Focus();
                        }
                    }
                    else
                    {
                        messageBox frm = new messageBox();
                        frm.messageTxt = "Please select beam no";
                        frm.type = "error";
                        frm.ShowDialog();
                        cmbBINo.Focus();
                    }
                }
                else
                {
                    messageBox frm = new messageBox();
                    frm.messageTxt = "Beam No is already added";
                    frm.type = "error";
                    frm.ShowDialog();
                    cmbBINo.Focus();
                 
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                txtFNo.Text = "";
                cmbBINo.SelectedIndex = -1;
                cmbBINo.Text = "<--SELECT-->";
                txtMeters.Text = "0";
                //txtWeaver.Text = "";
                cmbBINo.Focus();
            }

        }

        private void cmbPartyName_Leave(object sender, EventArgs e)
        {
            if (cmbPartyName.SelectedIndex >-1 )//Convert.ToInt32(cmbPartyName.SelectedValue) > 0 && cmbPartyName.Text != "<--SELECT-->" && cmbPartyName.Text != "<--NO RECORD-->"
            {
                FillGrid(401);
                FillGrid(503);

                if (newOrEdit == 1)
                {
                    cmbContract.SelectedValue = cmbCV;
                   
                }
            }
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please select party name";
                frm.type = "error";
                frm.ShowDialog();
                cmbPartyName.Focus();
            }

        }

        private void cmbQuality_Leave(object sender, EventArgs e)
        {
            if (cmbQuality.SelectedValue == null || Convert.ToInt32(cmbQuality.SelectedValue) < 0)
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please select quality";
                frm.type = "error";
                frm.ShowDialog();
                //                cmbPartyName.Focus();            
            }
        }

        private void cmbShade_Leave(object sender, EventArgs e)
        {
            if (cmbShade.SelectedValue == null || Convert.ToInt32(cmbShade.SelectedValue) < 0)
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please select shade";
                frm.type = "error";
                frm.ShowDialog();
                //cmbPartyName.Focus();
            }
            else
            {
                FillGrid(603);
            }
        }

        private void dgvDesign_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDesign.CurrentCell.ColumnIndex == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure to delete the record?", "Delete record", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        dgvDesign.Rows.RemoveAt(dgvDesign.CurrentRow.Index);
                    }
                }
            }
            catch
            { }
        }

        private void cmbBroker_Leave(object sender, EventArgs e)
        {
            if (cmbBroker.SelectedValue == null || Convert.ToInt32(cmbBroker.SelectedValue) < 0)
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please select Broker";
                frm.type = "error";
                frm.ShowDialog();
                //cmbPartyName.Focus();
            }
        }

        private void cmbContract_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbContract_Leave(object sender, EventArgs e)
        {
            if (cmbContract.SelectedIndex > -1)
            {
                FillGrid(601);
                FillGrid(602);
                FillGrid(701);
                FillGrid(702);
                if (newOrEdit == 1)
                {
                    cmbSizingName.SelectedValue = cmbSN;
                    cmbQuality.SelectedValue = cmbQV;
                }

                txtSatNo.Text = cmbContract.Text;
            }
        }

        private void cmbSizingName_Leave(object sender, EventArgs e)
        {
            if (cmbSizingName.SelectedIndex > -1)
            {
                txtSizingName.Text = cmbSizingName.Text;
            }
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please select sizing name";
                frm.type = "error";
                frm.ShowDialog();
            }
        }
    }
}
