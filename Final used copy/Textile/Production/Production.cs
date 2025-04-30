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

namespace Textile.Production
{
    public partial class Production : Form
    {
        public Production()
        {
            InitializeComponent();
        }
        #region variables
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        public string owner;
        public int cmbSV, cmbLTV, cmbLNV;
        string strReturnMSG, strReturnRefNo;
        int intReturnPKNo;
        int result, okflag, count = 0;
        decimal production = 0;
        int found = 0;
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
                hash.Add("@inryearId", fd.YearId);

                if (QueryNo == 202 || QueryNo == 203 || QueryNo == 204 || QueryNo == 206 || QueryNo == 207)
                {
                    hash.Add("@intShade", Convert.ToInt32(cmbShade.SelectedValue));
                }
                if (QueryNo == 203 || QueryNo == 204 || QueryNo == 206 || QueryNo == 207)
                {
                    hash.Add("@intLoomType", Convert.ToInt32(cmbLoomType.SelectedValue));
                }
                if (QueryNo == 204 || QueryNo == 206 || QueryNo == 207)
                {
                    hash.Add("@intLoomNo", Convert.ToInt32(cmbLoomNo.SelectedValue));
                }
                if (QueryNo == 207)
                {
                    hash.Add("@intQuality",lblQuality.Text);
                }

                dtReturn = ClsDefination.FillData("[Master_ProductionDML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 103)
                    {
                        cmbShade.DataSource = dtReturn;
                        cmbShade.DisplayMember = "NAME";
                        cmbShade.ValueMember = "ShadeName";
                        cmbShade.SelectedIndex = -1;
                        cmbShade.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 202)
                    {
                        cmbLoomType.DataSource = dtReturn;
                        cmbLoomType.DisplayMember = "Common_Value";
                        cmbLoomType.ValueMember = "LoomType";
                        cmbLoomType.SelectedIndex = -1;
                        cmbLoomType.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 203)
                    {
                        cmbLoomNo.DataSource = dtReturn;
                        cmbLoomNo.DisplayMember = "LoomNo";
                        cmbLoomNo.ValueMember = "LoomNo";
                        cmbLoomNo.SelectedIndex = -1;
                        cmbLoomNo.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 204)
                    {
                        txtPrvCuts.Text = objRow["RemCount"].ToString();
                        lblQuality.Text = objRow["Quality"].ToString();
                    }
                    else if (QueryNo == 205)
                    {
                        cmbEmpName.DataSource = dtReturn;
                        cmbEmpName.DisplayMember = "Name";
                        cmbEmpName.ValueMember = "Emp_Code";
                        cmbEmpName.SelectedIndex = -1;
                        cmbEmpName.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 206)
                    {
                        //VS.PartyName,VS.SatNo,VS.BiNo,VS.BeamNo  Quality
                        lblPartyCode.Text = objRow["PartyName"].ToString();
                        lblSatNo.Text = objRow["SatNo"].ToString();
                        lblBiNo.Text = objRow["BiNo"].ToString();
                        lblBeamNo.Text = objRow["BeamNo"].ToString();
                        lblSatCount.Text = objRow["SatCount"].ToString();
                    }
                    else if (QueryNo == 207)
                    {
                        lblTotalCut.Text = "0";
                        lblTotalCut.Text = objRow["BiCut"].ToString();
                        //
                    }
                }
                else
                {
                    if (QueryNo == 103)
                    {
                        cmbShade.DataSource = dtReturn;
                        cmbShade.SelectedIndex = -1;
                        cmbShade.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 202)
                    {
                        cmbLoomType.DataSource = dtReturn;
                        cmbLoomType.SelectedIndex = -1;
                        cmbLoomType.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 203)
                    {
                        cmbLoomNo.DataSource = dtReturn;
                        cmbLoomNo.SelectedIndex = -1;
                        cmbLoomNo.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 204)
                    {
                        txtPrvCuts.Text = "0";
                    }
                    else if (QueryNo == 205)
                    {
                        cmbEmpName.DataSource = dtReturn;
                        cmbEmpName.SelectedIndex = -1;
                        cmbEmpName.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 206)
                    {
                        //VS.PartyName,VS.SatNo,VS.BiNo,VS.BeamNo
                        lblPartyCode.Text = "0";
                        lblSatNo.Text = "0";
                        lblBiNo.Text = "0";
                        lblBeamNo.Text = "0";
                        lblSatCount.Text = "0";
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

        #region GridCreation
        public void GridCreation()
        {
            try
            {

                DataTable dt = new DataTable();

                dt.Columns.Add("X", typeof(string));          //0
                dt.Columns.Add("CODE", typeof(int));
                dt.Columns.Add("NAME", typeof(string));
                dt.Columns.Add("TAGA NO", typeof(int));
                dt.Columns.Add("PRODUCTION", typeof(decimal));
                dt.Columns.Add("RATE", typeof(decimal));
                dt.Columns.Add("TOTAL", typeof(decimal));
                dgvDesign.DataSource = dt;
            }
            catch (Exception ex)
            {
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
                    hash.Add("@dtpFromDate", dtpDate.Value.ToString("MM/dd/yyyy"));
                    hash.Add("@dtpToDate", dtpToDate.Value.ToString("MM/dd/yyyy"));
                    hash.Add("@intShade", Convert.ToInt32(cmbShade.SelectedValue));
                    hash.Add("@intLoomType", Convert.ToInt32(cmbLoomType.SelectedValue));
                    hash.Add("@intLoomNo", Convert.ToInt32(cmbLoomNo.SelectedValue));
                    hash.Add("@decPrvCut", Convert.ToDecimal(txtPrvCuts.Text));
                    hash.Add("@decNoOfTage", Convert.ToDecimal(txtTotNoTage.Text));
                    hash.Add("@decRemCut", Convert.ToDecimal(txtRemCut.Text));
                    hash.Add("@intTotalEmp", Convert.ToInt32(lblTotEmpValue.Text));
                    hash.Add("@decTotalProduction", production);
                    hash.Add("@decTotalAmtPay", Convert.ToDecimal(lblTotalAmtPayVaue.Text));
                    hash.Add("@intPartyName", Convert.ToInt32(lblPartyCode.Text));
                    hash.Add("@intSatNo", Convert.ToInt32(lblSatNo.Text));
                    hash.Add("@decSatCount", Convert.ToDecimal(lblSatCount.Text));
                    hash.Add("@intBiNo", Convert.ToInt32(lblBiNo.Text));
                    hash.Add("@strBeamNo", lblBeamNo.Text);
                    hash.Add("@intQuality",Convert.ToInt32(lblQuality.Text));
                    hash.Add("@strTagaNo", txtTagaSrNo.Text);
                    hash.Add("@decTagaWeigth",Convert.ToDecimal(txtWeight.Text));
                    string strXmlDetail = "";

                    StringBuilder xmlClassMaster = new StringBuilder();

                    for (int k = 0; k < dgvDesign.Rows.Count; k++)
                    {
                        //, , , , 
                        xmlClassMaster.Append("<Row>");
                        //,,
                        xmlClassMaster.Append("<empCode>" + (Convert.ToInt32(dgvDesign.Rows[k].Cells[1].Value)) + "</empCode>");
                        xmlClassMaster.Append("<tagaNo>" + (Convert.ToInt32(dgvDesign.Rows[k].Cells[3].Value)) + "</tagaNo>");
                        xmlClassMaster.Append("<prodution>" + (Convert.ToDecimal(dgvDesign.Rows[k].Cells[4].Value)) + "</prodution>");
                        xmlClassMaster.Append("<rate>" + (Convert.ToDecimal(dgvDesign.Rows[k].Cells[5].Value)) + "</rate>");
                        xmlClassMaster.Append("<tataPay>" + (Convert.ToDecimal(dgvDesign.Rows[k].Cells[6].Value)) + "</tataPay>");

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
                return ClsDefination.InsertExecute(hash, "[Master_ProductionDML]", ref strReturnMSG, ref strReturnNo, ref intReturnNo);
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




        private void Production_Load(object sender, EventArgs e)
        {
            FillGrid(103);
            FillGrid(205);
            cmbLoomNo.Text = "<--SELECT-->";
            cmbLoomType.Text = "<--SELECT-->";
            GridCreation();
        }

        private void cmbShade_Leave(object sender, EventArgs e)
        {
            if (cmbShade.Text != "<--SELECT-->" && cmbShade.Text != "<--NO RECORD-->" && cmbShade.SelectedValue != null && Convert.ToInt32(cmbShade.SelectedValue) > 0)
            {
                FillGrid(202);
            }
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please select shade";
                frm.type = "error";
                frm.ShowDialog();
                FillGrid(201);
                cmbShade.Focus();
            }
        }

        private void cmbLoomType_Leave(object sender, EventArgs e)
        {
            if (cmbLoomType.Text != "<--SELECT-->" && cmbLoomType.Text != "<--NO RECORD-->" && cmbLoomType.SelectedValue != null && Convert.ToInt32(cmbLoomType.SelectedValue) > 0)
            {
                FillGrid(203);
            }
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please select loom type";
                frm.type = "error";
                frm.ShowDialog();
                FillGrid(202);
                cmbLoomType.Focus();
            }
        }

        private void cmbLoomNo_Leave(object sender, EventArgs e)
        {
            if (cmbLoomNo.Text != "<--SELECT-->" && cmbLoomNo.Text != "<--NO RECORD-->" && cmbLoomNo.SelectedValue != null && Convert.ToInt32(cmbLoomNo.SelectedValue) > 0)
            {
                FillGrid(204);
                FillGrid(206);
                FillGrid(207);
            }
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please select loom no";
                frm.type = "error";
                frm.ShowDialog();
                FillGrid(203);
                cmbLoomNo.Focus();
            }
        }

        private void txtTotNoTage_Leave(object sender, EventArgs e)
        {
            if (txtTotNoTage.Text == "" || txtTotNoTage.Text == "0")
            {
                txtTotNoTage.Text = "0";
                messageBox frm = new messageBox();
                frm.messageTxt = "Please enter total no of tage";
                frm.type = "error";
                frm.ShowDialog();
                txtTotNoTage.Focus();
            }
            else
            {
                txtRemCut.Text = (Convert.ToDecimal(txtPrvCuts.Text) - Convert.ToDecimal(1)).ToString();
            }
        }

        public void empTagaWiseAmt()
        {
            lblTotalAmt.Text =
                Math.Round(Convert.ToDecimal(txtProduction.Text) * Convert.ToDecimal(txtRate.Text), 2).ToString();
        }

        private void txtProduction_Leave(object sender, EventArgs e)
        {
            if (txtProduction.Text == "" || txtProduction.Text == "0")
            {
                txtProduction.Text = "0";

                messageBox frm = new messageBox();
                frm.messageTxt = "Please enter total production meter";
                frm.type = "error";
                frm.ShowDialog();
                txtProduction.Focus();
            }
            else
            {
                empTagaWiseAmt();
            }
        }

        private void txtRate_Leave(object sender, EventArgs e)
        {
            if (txtRate.Text == "" || txtRate.Text == "0")
            {
                txtRate.Text = "0";

                messageBox frm = new messageBox();
                frm.messageTxt = "Please enter rate";
                frm.type = "error";
                frm.ShowDialog();
                txtRate.Focus();
            }
            else
            {
                empTagaWiseAmt();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtTagaNo.Text != "")
                {
                    DataTable dt = dgvDesign.DataSource as DataTable;

                    DataRow dr2 = dt.NewRow();

                    dr2["X"] = "X";
                    dr2["CODE"] = Convert.ToInt32(cmbEmpName.SelectedValue);
                    dr2["NAME"] = cmbEmpName.Text;
                    dr2["TAGA NO"] = txtTagaSrNo.Text; //Convert.ToInt32(txtTagaNo.Text);
                    dr2["PRODUCTION"] = Convert.ToDecimal(txtProduction.Text);
                    dr2["RATE"] = Convert.ToDecimal(txtRate.Text);
                    dr2["TOTAL"] = Convert.ToDecimal(lblTotalAmt.Text);


                    for (int i = 0; i < dgvDesign.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(cmbEmpName.SelectedValue) == Convert.ToInt32(dgvDesign.Rows[i].Cells[1].Value))
                        {
                            found = 1;
                            break;
                        }
                        else
                        {
                            found = 0;
                        }
                    }

                    if (found == 0)
                    {
                        count++;
                        lblTotEmpValue.Text = count.ToString();
                    }

                    dt.Rows.Add(dr2);

                    dgvDesign.DataSource = dt;

                }
                else
                {
                    messageBox frm = new messageBox();
                    frm.messageTxt = "Please enter taga no";
                    frm.type = "error";
                    frm.ShowDialog();
                    txtTagaNo.Focus();
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                cmbEmpName.Text = "<--SELECT-->";
                txtTagaNo.Text = "0";
                txtProduction.Text = "0";
                txtRate.Text = "0";
                lblTotalAmt.Text = "0";
                FillGrid(205);
                gridCalculation();
                cmbEmpName.Focus();
            }

        }

        public void gridCalculation()
        {
            try
            {
                lblTotProductionValue.Text = "0";
                lblTotalAmtPayVaue.Text = "0";
                production = 0;
                for (int i = 0; i < dgvDesign.Rows.Count; i++)
                {
                    lblTotProductionValue.Text =
                        Math.Round(Convert.ToDecimal(lblTotProductionValue.Text) + Convert.ToDecimal(dgvDesign.Rows[i].Cells[4].Value.ToString()), 3).ToString();

                    lblTotalAmtPayVaue.Text =
                        Math.Round(Convert.ToDecimal(lblTotalAmtPayVaue.Text) + Convert.ToDecimal(dgvDesign.Rows[i].Cells[6].Value.ToString()), 2).ToString();
                }

                production = Convert.ToDecimal(lblTotProductionValue.Text);
                lblTotProductionValue.Text = lblTotProductionValue.Text + " Mtr.";

            }
            catch (Exception ex)
            {
            }
        }

        private void cmbEmpName_Leave(object sender, EventArgs e)
        {
            if (cmbEmpName.Text != "<--SELECT-->" && cmbEmpName.Text != "<--NO RECORD-->" && cmbEmpName.SelectedValue != null && Convert.ToInt32(cmbEmpName.SelectedValue) > 0)
            {

            }
            else
            {
                btnSave.Focus();
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

        private void txtTagaNo_Leave(object sender, EventArgs e)
        {
            //if (txtTagaNo.Text == "" || Convert.ToInt32(txtTagaNo.Text) <= 0 )//|| Convert.ToInt32(txtTagaNo.Text) > Convert.ToInt32(txtTotNoTage.Text))
            //{
            //    messageBox frm = new messageBox();
            //    frm.messageTxt = "Please enter valid taga no";
            //    frm.type = "error";
            //    frm.ShowDialog();
            //    txtTagaNo.Focus();
            //}
        }

        private void dgvDesign_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDesign.CurrentCell.ColumnIndex == 0)
                {
                    //"confirm"
                    DialogResult dialogResult = MessageBox.Show("Are you sure to delete the record?", "Delete record", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        dgvDesign.Rows.RemoveAt(dgvDesign.CurrentRow.Index);
                        gridCalculation();
                    }
                }
            }
            catch
            { }
        }

        private void lblTotalCut_TextChanged(object sender, EventArgs e)
        {
          //  txtTotNoTage.Text = Math.Round((Convert.ToDecimal(lblTotalCut.Text) - Convert.ToDecimal(txtPrvCuts.Text)) + 1, 2).ToString();
        }

    }
}
