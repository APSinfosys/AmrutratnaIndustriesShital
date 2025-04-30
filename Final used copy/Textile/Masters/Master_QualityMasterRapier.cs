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
    public partial class Master_QualityMasterRapier : Form
    {
        public Master_QualityMasterRapier()
        {
            InitializeComponent();
        }

        #region variables
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        public string owner;
        public int cmbPV, cmbQV,cmbSN   ;
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
                hash.Add("@inryearId", fd.YearId);

                if (QueryNo == 301 || QueryNo == 302)
                {
                    hash.Add("@intCode", Convert.ToInt32(lblSrNo.Text));
                    // hash.Add("@strUniqueCode", lblUniqueCode.Text);
                }
                if (QueryNo == 402)
                {
                    hash.Add("@intCode",cmbSatNo.SelectedValue);
                }

                dtReturn = ClsDefination.FillData("[Master_QualityMasterDML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 201)
                    {
                        cmbWarf.DataSource = dtReturn;
                        cmbWarf.DisplayMember = "S_Name";
                        cmbWarf.ValueMember = "S_Code";
                        cmbWarf.SelectedValue = -1;
                        cmbWarf.Text = "<-SELECT-->";
                    }
                    else if (QueryNo == 202)
                    {
                        cmbWeft.DataSource = dtReturn;
                        cmbWeft.DisplayMember = "S_Name";
                        cmbWeft.ValueMember = "S_Code";
                        cmbWeft.SelectedValue = -1;
                        cmbWeft.Text = "<-SELECT-->";
                    }
                    else if (QueryNo == 301)
                    {
                        dgvWarf.DataSource = dtReturn;
                        dgvWarf.Columns[1].Visible = false;
                    }
                    else if (QueryNo == 302)
                    {
                        dgvWeft.DataSource = dtReturn;
                        dgvWeft.Columns[1].Visible = false;
                    }
                    else if (QueryNo == 401)
                    {
                        cmbSatNo.DataSource = dtReturn;
                        cmbSatNo.ValueMember = "Id";
                        cmbSatNo.DisplayMember = "SatNo";
                        cmbSatNo.SelectedIndex = -1;
                        cmbSatNo.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 402)
                    {
                        lblQualityName.Text = objRow["QualityName"].ToString();
                        lblMajuri.Text = objRow["rate"].ToString();
                        DesignName();
                    }
                }
                else
                {
                    if (QueryNo == 201)
                    {
                        cmbWarf.DataSource = dtReturn;
                        cmbWarf.SelectedValue = -1;
                        cmbWarf.Text = "<-NO RECORD-->";
                    }
                    else if (QueryNo == 202)
                    {
                        cmbWeft.DataSource = dtReturn;
                        cmbWeft.SelectedValue = -1;
                        cmbWeft.Text = "<-NO RECORD-->";
                    }
                    else if (QueryNo == 401)
                    {
                        cmbSatNo.DataSource = dtReturn;
                        cmbSatNo.SelectedIndex = -1;
                        cmbSatNo.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 402)
                    {
                        lblQualityName.Text = "NO QUALITY FOUND";
                        lblMajuri.Text = "0.00";
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

                if (QueryNo == 1 || QueryNo == 2)
                {

                    if (QueryNo == 2)
                    {
                        hash.Add("@intCode", Convert.ToInt32(lblSrNo.Text));
                        hash.Add("@strUniqueCode", lblUniqueCode.Text);
                    }

                    hash.Add("@strName", lblQualityName.Text.ToUpper());
                    //  decimal warf = ((Convert.ToDecimal(txtTara.Text) + Convert.ToDecimal(txtPart.Text)) * Convert.ToDecimal(txtLasa.Text)) / Convert.ToDecimal(txtWarfConst.Text);
                    // decimal weft = ((Convert.ToDecimal(txtPanna.Text) + Convert.ToDecimal(txtGala.Text)) * Convert.ToDecimal(txtPick.Text)) / Convert.ToDecimal(txtWeftConst.Text);
                    hash.Add("@decWeft", Convert.ToDecimal(0.00));
                    hash.Add("@decWarf", Convert.ToDecimal(0.00));
                    hash.Add("@decTara", Convert.ToDecimal(0.00));
                    if (txtPart.Text == "PART")
                    {
                        txtPart.Text = "0";

                    }
                    hash.Add("@decPart", Convert.ToDecimal(txtPart.Text));
                    if (txtLasa.Text == "LASA")
                    {
                        txtLasa.Text = "1";
                    }
                    hash.Add("@decLasa", Convert.ToDecimal(txtLasa.Text));
                    hash.Add("@decWarfConst", Convert.ToDecimal(txtWarfConst.Text));
                    hash.Add("@decPanna", Convert.ToDecimal(txtPanna.Text));
                    //       ,,,,,,,,,
                    //hash.Add("@decGala", Convert.ToDecimal(txtMeter.Text));

                    decimal pick = 0;
                    for (int i = 0; i < dgvWeft.Rows.Count; i++)
                    {
                        pick = pick + Convert.ToDecimal(dgvWeft.Rows[i].Cells[5].Value.ToString());
                    }
                        hash.Add("@decPick", pick);
                    hash.Add("@decWeftConst", Convert.ToDecimal(txtWeftConst.Text));
                    hash.Add("@decMeasure", Convert.ToDecimal(txtMeasure.Text)); //
                    hash.Add("@decMeter", Convert.ToDecimal(txtMeter.Text));
                    hash.Add("@decWestage", Convert.ToDecimal(txtWestage.Text));

                    hash.Add("@decNPannha",Convert.ToDecimal(txtPannha.Text));

                    hash.Add("@strReed",txtReed.Text);

                    hash.Add("@intSatNo",cmbSatNo.SelectedValue);
                    hash.Add("@strDesignName",txtDesignName.Text);

                   // ,,

                    hash.Add("@decMajuri",lblMajuri.Text);
                    hash.Add("@decPickC",lblPickC.Text);
                    hash.Add("@decRate",lblRate.Text);
    //                     as int=0,
    // as varchar(100)='',
                    //,,
                    //,,,,GETDATE(),1,,   

                    string strXmlDetail = "";

                    StringBuilder xmlClassMaster = new StringBuilder();

                    for (int k = 0; k < dgvWarf.Rows.Count; k++)
                    {

                        xmlClassMaster.Append("<Row>");
                        //,,

                        xmlClassMaster.Append("<wr_sutId>" + (Convert.ToInt32(dgvWarf.Rows[k].Cells[1].Value)) + "</wr_sutId>");
                        xmlClassMaster.Append("<wr_count>" + (Convert.ToDecimal(dgvWarf.Rows[k].Cells[3].Value)) + "</wr_count>");
                        xmlClassMaster.Append("<wr_color>" + dgvWarf.Rows[k].Cells[4].Value.ToString().ToUpper() + "</wr_color>");
                        xmlClassMaster.Append("<Tara>" + (Convert.ToDecimal(dgvWarf.Rows[k].Cells[5].Value)) + "</Tara>");

                        xmlClassMaster.Append("</Row>");
                    }

                    if (xmlClassMaster.Length > 0)
                    {
                        xmlClassMaster.Append("</ProductSupplierDetails>");
                        strXmlDetail = "<ProductSupplierDetails>" + Convert.ToString(xmlClassMaster);
                    }

                    hash.Add("@strXmlDetail", strXmlDetail);



                    string strXmlDetail1 = "";

                    StringBuilder xmlClassMaster1 = new StringBuilder();

                    for (int k = 0; k < dgvWeft.Rows.Count; k++)
                    {

                        xmlClassMaster1.Append("<Row>");

                        xmlClassMaster1.Append("<wr_sutId>" + (Convert.ToInt32(dgvWeft.Rows[k].Cells[1].Value)) + "</wr_sutId>");
                        xmlClassMaster1.Append("<wr_count>" + (Convert.ToDecimal(dgvWeft.Rows[k].Cells[3].Value)) + "</wr_count>");
                        xmlClassMaster1.Append("<wr_color>" + dgvWeft.Rows[k].Cells[4].Value.ToString().ToUpper() + "</wr_color>");
                        xmlClassMaster1.Append("<Pick>" + (Convert.ToDecimal(dgvWeft.Rows[k].Cells[5].Value)) + "</Pick>");
                        xmlClassMaster1.Append("</Row>");
                    }

                    if (xmlClassMaster1.Length > 0)
                    {
                        xmlClassMaster1.Append("</ProductSupplierDetails1>");
                        strXmlDetail1 = "<ProductSupplierDetails1>" + Convert.ToString(xmlClassMaster1);
                    }

                    hash.Add("@strXmlDetail1", strXmlDetail1);



                }

                okflag = 1;
                return ClsDefination.InsertExecute(hash, "[Master_QualityMasterDML]", ref strReturnMSG, ref strReturnNo, ref intReturnNo);
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


        #region GridCreationWarf
        public void GridCreationWarf()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("X", typeof(string));          //0
                dt.Columns.Add("SUT ID", typeof(int));
                dt.Columns.Add("SUT", typeof(string));
                dt.Columns.Add("COUNT", typeof(decimal));
                dt.Columns.Add("COLOR", typeof(string));
                dt.Columns.Add("TARA", typeof(decimal));
                dgvWarf.DataSource = dt;
            }
            catch (Exception ex)
            {
            }
        }
        #endregion

        #region GridCreationWeft
        public void GridCreationWeft()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("X", typeof(string));          //0
                dt.Columns.Add("SUT ID", typeof(int));
                dt.Columns.Add("SUT", typeof(string));
                dt.Columns.Add("COUNT", typeof(decimal));
                dt.Columns.Add("COLOR", typeof(string));
                dt.Columns.Add("PICK", typeof(decimal));
                dgvWeft.DataSource = dt;
            }
            catch (Exception ex)
            {
            }
        }
        #endregion

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnWarfAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbWarf.SelectedIndex > -1)
                {

                    DataTable dt = dgvWarf.DataSource as DataTable;

                    DataRow dr2 = dt.NewRow();
                    dr2["X"] = "X";
                    dr2["SUT ID"] = Convert.ToInt32(cmbWarf.SelectedValue);
                    dr2["SUT"] = cmbWarf.Text;
                    dr2["COUNT"] = txtWarfCount.Text;
                    dr2["COLOR"] = txtWarfColor.Text;
                    dr2["TARA"] = Convert.ToDecimal(txtTara1.Text);

                    dt.Rows.Add(dr2);

                    dgvWarf.DataSource = dt;
                    DesignName();
                }
                else
                {
                    messageBox frm = new messageBox();
                    frm.messageTxt = "Please select yarn group";
                    frm.type = "error";
                    frm.ShowDialog();

                    //txtPart.Focus();
                }

            }
            catch (Exception ex)
            {
            }
            finally
            {
                txtWarfColor.Text = "";
                txtWarfCount.Text = "";
                txtTara1.Text = "";
                cmbWarf.Text = "<--SELECT-->";
                dgvWarf.Columns[1].Visible = false;
                cmbWarf.Focus();

            }
        }

        private void btnWeftAdd_Click(object sender, EventArgs e)
        {
            try
            {

                if (cmbWeft.SelectedIndex > -1)
                {
                    DataTable dt = dgvWeft.DataSource as DataTable;

                    DataRow dr2 = dt.NewRow();
                    dr2["X"] = "X";
                    dr2["SUT ID"] = Convert.ToInt32(cmbWeft.SelectedValue);
                    dr2["SUT"] = cmbWeft.Text;
                    dr2["COUNT"] = txtWeftCount.Text;
                    dr2["COLOR"] = txtWeftColor.Text;
                    dr2["PICK"] = Convert.ToDecimal(txtPick1.Text);
                    dt.Rows.Add(dr2);

                    dgvWeft.DataSource = dt;
                    DesignName();
                }
                else
                {
                    messageBox frm = new messageBox();
                    frm.messageTxt = "Please select yarn group";
                    frm.type = "error";
                    frm.ShowDialog();

                    //txtPanna.Focus();
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                txtWeftColor.Text = "";
                txtWeftCount.Text = "";
                txtPick1.Text = "";
                cmbWeft.Text = "<--SELECT-->";
                dgvWeft.Columns[1].Visible = false;
                cmbWeft.Focus();
            }
        }

        private void Master_QualityMasterRapier_Load(object sender, EventArgs e)
        {
            GridCreationWarf();
            GridCreationWeft();

            FillGrid(201);
            FillGrid(202);
            FillGrid(401);
            if (newOrEdit == 1)
            {
                cmbSatNo.SelectedValue = cmbSN;
                FillGrid(301);
                FillGrid(302);
                if (dgvWeft.Rows.Count > 0)
                {
                    DesignName();
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
            }

        }

        private void txtPart_Leave(object sender, EventArgs e)
        {
            //   txtTara1.Text = Convert.ToDecimal(txtPart.Text).ToString();
        }

        private void txtLasa_Leave(object sender, EventArgs e)
        {
            //   txtLasa.Text = Convert.ToDecimal(txtLasa.Text).ToString();
        }

        private void txtPanna_Leave(object sender, EventArgs e)
        {
            if (newOrEdit == 0)
            {
                try
                {
                    txtPanna.Text = Convert.ToDecimal(txtPanna.Text).ToString();

                   // DesignName();
                }
                catch (Exception ex)
                {
                    messageBox frm = new messageBox();
                    frm.messageTxt = "Please enter valid reed space";
                    frm.type = "error";
                    frm.ShowDialog();
                    txtPanna.Focus();
                }
            }
            //if(txtPanna.Text=="" || txtPanna.Text=="Reed Space")
        }

        private void txtGala_Leave(object sender, EventArgs e)
        {
            //    txtGala.Text = Convert.ToDecimal(txtGala.Text).ToString();
        }

        private void txtWarfConst_Leave(object sender, EventArgs e)
        {
            //  txtWarfConst.Text = Convert.ToDecimal(txtWarfConst.Text).ToString();
        }

        private void txtWeftConst_Leave(object sender, EventArgs e)
        {
            //txtWeftConst.Text = Convert.ToDecimal(txtWeftConst.Text).ToString();
        }

        private void dgvWarf_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvWarf.CurrentCell.ColumnIndex == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure to delete the record?", "Delete record", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        dgvWarf.Rows.RemoveAt(dgvWarf.CurrentRow.Index);
                    }
                }
            }
            catch
            { }
        }

        private void dgvWeft_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvWeft.CurrentCell.ColumnIndex == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure to delete the record?", "Delete record", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        dgvWeft.Rows.RemoveAt(dgvWeft.CurrentRow.Index);
                        DesignName();
                    }
                }
            }
            catch
            { }
        }

        private void cmbWarf_Leave(object sender, EventArgs e)
        {
            if (cmbWarf.Text == "<--SELECT-->" && Convert.ToInt32(cmbWarf.SelectedValue) <= 0)
            {
                txtPart.Focus();
            }

            //if (cmbWarf.Text == "<--SELECT-->" || cmbWarf.SelectedIndex <= 0)
            //{
            //    cmbWeft.Focus();
            //}
        }

        private void cmbWeft_Leave(object sender, EventArgs e)
        {
            if (cmbWeft.Text == "<--SELECT-->" && Convert.ToInt32(cmbWeft.SelectedValue) <= 0)
            {
                txtPanna.Focus();
            }
        }


        public void DesignName()
        {
            try
            {

                decimal p = 0;

                for (int i = 0; i < dgvWeft.Rows.Count; i++)
                {
                    p = p + Convert.ToDecimal(dgvWeft.Rows[i].Cells[5].Value.ToString());
                }

                lblPickC.Text = p.ToString();

                lblRate.Text = Math.Round( Convert.ToDecimal(lblMajuri.Text)*Convert.ToDecimal(lblPickC.Text),2).ToString();

                //string pick = "", warfCount = "", weftCount = "", warf = "", weft = "";
                //for (int i = 0; i < dgvWeft.Rows.Count; i++)
                //{
                //    if (dgvWeft.Rows.Count == 1)
                //    {
                //        pick = dgvWeft.Rows[i].Cells[5].Value.ToString();
                //        weftCount = dgvWeft.Rows[i].Cells[3].Value.ToString();
                //        weft = dgvWeft.Rows[i].Cells[2].Value.ToString();
                //    }
                //    else
                //    {

                //        if (i == 0)
                //        {
                //            pick = dgvWeft.Rows[i].Cells[5].Value.ToString();
                //            weftCount = dgvWeft.Rows[i].Cells[3].Value.ToString();
                //            weft = dgvWeft.Rows[i].Cells[2].Value.ToString();
                //        }
                //        else
                //        {
                //            pick = pick + " + " + dgvWeft.Rows[i].Cells[5].Value.ToString();
                //            weftCount = weftCount + " + " + dgvWeft.Rows[i].Cells[3].Value.ToString();
                //            weft = weft + " + " + dgvWeft.Rows[i].Cells[2].Value.ToString();

                //        }

                //        if (i == dgvWeft.Rows.Count - 1)
                //        {
                //            pick = " ( " + pick + " ) ";
                //            weftCount = " ( " + weftCount + " ) ";
                //            weft = " ( " + weft + " ) ";
                //        }
                //    }
                //}

                //for (int i = 0; i < dgvWarf.Rows.Count; i++)
                //{
                //    if (dgvWarf.Rows.Count == 1)
                //    {
                //        warfCount = dgvWarf.Rows[i].Cells[3].Value.ToString();
                //        warf = dgvWarf.Rows[i].Cells[2].Value.ToString();
                //    }
                //    else
                //    {
                //        if (i == 0)
                //        {
                //            warfCount = dgvWarf.Rows[i].Cells[3].Value.ToString();
                //            warf = dgvWarf.Rows[i].Cells[2].Value.ToString();
                //        }
                //        else
                //        {
                //            warf = warf + " + " + dgvWarf.Rows[i].Cells[2].Value.ToString();
                //            warfCount = warfCount + " + " + dgvWarf.Rows[i].Cells[3].Value.ToString();
                //        }
                //        if (i == dgvWarf.Rows.Count - 1)
                //        {
                //            warfCount = "( " + warfCount + " )";
                //            warf = " ( " + warf + " ) ";
                //        }
                //    }
                //}

                //txtDesignName.Text = txtPannha.Text + "'' " + txtReed.Text + " X " + pick + "/ " + warfCount + warf + " X " + weftCount + weft;
            }
            catch (Exception ex)
            {
            }
        }

        private void txtPannha_Leave(object sender, EventArgs e)
        {
            if (newOrEdit == 0)
            {
                if (txtPannha.Text != "")
                {
                    DesignName();
                }
            }
        }

        private void txtReed_Leave(object sender, EventArgs e)
        {
            if (newOrEdit == 0)
            {
                if (txtPannha.Text != "")
                {
                    DesignName();
                }
            }
        }

        private void cmbSatNo_Leave(object sender, EventArgs e)
        {
            FillGrid(402);
        }


    }
}
