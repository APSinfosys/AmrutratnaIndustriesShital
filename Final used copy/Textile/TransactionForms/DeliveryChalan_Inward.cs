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

namespace Textile.TransactionForms
{
    public partial class DeliveryChalan_Inward : Form
    {
        public DeliveryChalan_Inward()
        {
            InitializeComponent();
        }

        #region variables
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        public int cmbSuppliverV, cmbTaxableV, cmbInvoiceV, cmbFirmV, cmbShadeV, cmbAccV, cmbPaidByV;
        string strReturnMSG, strReturnRefNo;
        int intReturnPKNo, repete, pageLoad = 0;
        int result, okflag;
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


                if (QueryNo == 203)
                {
                    hash.Add("@intParty", cmbParty.SelectedValue);
                }
                if (QueryNo == 204)
                {
                    hash.Add("@intCode",cmbContract.SelectedValue);
                }

                dtReturn = ClsDefination.FillData("[Transaction_DelevaryChalan_Inward_DML]", hash);


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
                        cmbParty.DataSource = dtReturn;
                        cmbParty.DisplayMember = "P_CompanyName";
                        cmbParty.ValueMember = "P_Code";
                        cmbParty.SelectedIndex = -1;
                        cmbParty.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 203)
                    {
                        cmbContract.DataSource = dtReturn;
                        cmbContract.DisplayMember = "CONTRACT";
                        cmbContract.ValueMember = "contractNo";
                        cmbContract.SelectedIndex = -1;
                        cmbContract.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 204)
                    {
                        lblBrokerName.Text=objRow["BR_Name"].ToString();
                        lblBrokerCode.Text=objRow["brokerCode"].ToString();
                        lblDesignName.Text = objRow["Q_Name"].ToString();
                        lblDesignCode.Text=objRow["qualityCode"].ToString();
                    }
                    else if (QueryNo == 205)
                    {
                        cmbShade.DataSource = dtReturn;
                        cmbShade.DisplayMember = "L_ShadeName";
                        cmbShade.ValueMember = "L_Code";
                        cmbShade.SelectedIndex = -1;
                        cmbShade.Text = "<--SELECT-->";
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
                        cmbParty.DataSource = dtReturn;
                        cmbParty.SelectedIndex = -1;
                        cmbParty.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 203)
                    {
                        cmbContract.DataSource = dtReturn;
                        cmbContract.SelectedIndex = -1;
                        cmbContract.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 204)
                    {
                        lblBrokerName.Text = "NOT FOUND";
                        lblBrokerCode.Text = "0";
                        lblDesignName.Text = "NOT FOUND";
                        lblDesignCode.Text = "0";
                    }
                    else if (QueryNo == 205)
                    {
                        cmbShade.DataSource = dtReturn;
                        cmbShade.SelectedIndex = -1;
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
                hash.Add("@intCreatedBy", Convert.ToInt32(fd.UserId));
                hash.Add("@intCompanyId", Convert.ToInt32(fd.CompId));
                hash.Add("@intYearId", Convert.ToInt32(fd.YearId));

                if (QueryNo == 1 || QueryNo == 2)
                {

                    if (QueryNo == 2)
                    {
                        hash.Add("@strUniqueCode", lblUniqueCode.Text);
                        hash.Add("@intCode", lblSrNo.Text);
                    }

                    hash.Add("@strDCINo",txtChalanNo.Text);
                    hash.Add("@dtpDCIDate",dtpChalanDate.Value.ToString("dd/MM/yyyy"));
                    hash.Add("@intFirm",cmbFirmName.SelectedValue);
                    hash.Add("@intBroker",Convert.ToInt32(lblBrokerCode.Text));
                    hash.Add("@intParty",Convert.ToInt32(cmbParty.SelectedValue));
                    hash.Add("@decBales",Convert.ToDecimal(txtBales.Text));
                    hash.Add("@intPices",Convert.ToInt32(txtPieces.Text));
                    hash.Add("@decMeter",Convert.ToDecimal(txtMeters.Text));
                    hash.Add("@decSample",Convert.ToDecimal(txtSampleCutPice.Text));
        //            ,,@,,,,,,,
                    hash.Add("@intContract",Convert.ToInt32(cmbContract.SelectedValue));
                    hash.Add("@intDesing",Convert.ToInt32(lblDesignCode.Text));
                    hash.Add("@intShade",Convert.ToInt32(cmbShade.SelectedValue));
        //,,,@,getdate(),@,@,@,@

                    string strXmlDetail = "";

                    StringBuilder xmlClassMaster = new StringBuilder();

                    for (int k = 0; k < dgvPurchaseDetail.Rows.Count; k++)
                    {

                        //dt.Columns.Add("LOOM NO", typeof(string)); //1
                        //dt.Columns.Add("TAGA NO", typeof(string));//2
                        //dt.Columns.Add("MTR", typeof(decimal));//3
                        //dt.Columns.Add("WEIGHT", typeof(decimal));//4
                        //dt.Columns.Add("GRAMEZ", typeof(decimal));//5

                            //        loomNo int 'loomNo', 
                            //pieceNo int 'pieceNo', 
                            //Mtr decimal(18,3) 'Mtr', 
                            //Weight decimal(18,3) 'Weight',
                            //GRAMEZ decimal(18,3) 'GRAMEZ'
               

                        xmlClassMaster.Append("<Row>");
                        xmlClassMaster.Append("<loomNo>" + dgvPurchaseDetail.Rows[k].Cells[1].Value.ToString() + "</loomNo>");
                        xmlClassMaster.Append("<pieceNo>" + dgvPurchaseDetail.Rows[k].Cells[2].Value.ToString() + "</pieceNo>");
                        xmlClassMaster.Append("<Mtr>" + (Convert.ToDecimal(dgvPurchaseDetail.Rows[k].Cells[3].Value)) + "</Mtr>");
                        //  xmlClassMaster.Append("<P_Exp>" + ConvertedDate + "</P_Exp>");
                        xmlClassMaster.Append("<Weight>" + (Convert.ToDecimal(dgvPurchaseDetail.Rows[k].Cells[4].Value)) + "</Weight>");
                        xmlClassMaster.Append("<GRAMEZ>" + (Convert.ToDecimal(dgvPurchaseDetail.Rows[k].Cells[5].Value)) + "</GRAMEZ>");

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
                return ClsDefination.InsertExecute(hash, "[Transaction_DelevaryChalan_Inward_DML]", ref strReturnMSG, ref strReturnNo, ref intReturnNo);
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

        #region GRID CREATION & validation
        public void GridCreation()
        {
            try
            {

                DataTable dt = new DataTable();

                dt.Columns.Add("X", typeof(string));          //0
                dt.Columns.Add("LOOM NO", typeof(string)); //1
                dt.Columns.Add("TAGA NO", typeof(string));//2
                dt.Columns.Add("MTR", typeof(decimal));//3
                dt.Columns.Add("WEIGHT",typeof(decimal));//4
                dt.Columns.Add("GRAMEZ", typeof(decimal));//5
                
                dgvPurchaseDetail.DataSource = dt;
                GridValidation();
                defoultValue();
            }
            catch (Exception ex)
            {
            }
        }

        public void GridValidation()
        {
            //1,3,20 
            //dgvPurchaseDetail.Columns[15].Visible = false;
            //dgvPurchaseDetail.Columns[16].Visible = false;

        }

        public void defoultValue()
        {

            txtLoomNo.Text = "";
            txtTagaNo.Text = "0";
            txtTagaWeight.Text = "0";
            txtMtr.Text="0.00";
            txtGramez.Text = "0.00";

            claculation();
        
        }

        public void claculation()
        {
            txtPieces.Text = dgvPurchaseDetail.Rows.Count.ToString();
            txtMeters.Text = "0";
            decimal totalMtr = 0;
            
            for (int i = 0; i < dgvPurchaseDetail.Rows.Count; i++)
            {
                totalMtr = totalMtr + Convert.ToDecimal(dgvPurchaseDetail.Rows[i].Cells[3].Value.ToString());
            }

            txtMeters.Text = totalMtr.ToString();
        }

        #endregion

        private void DeliveryChalan_Inward_Load(object sender, EventArgs e)
        {
            GridCreation();
            FillGrid(201);
            FillGrid(202);
            FillGrid(205);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                repete = 0;
                if (Convert.ToDecimal(txtMtr.Text) > 0 && Convert.ToDecimal(txtTagaWeight.Text)>0)
                {
                    for (int i = 0; i < dgvPurchaseDetail.Rows.Count; i++)
                    {
                        if (dgvPurchaseDetail.Rows[i].Cells[2].Value.ToString() == txtTagaNo.Text+txtChalanNo.Text+cmbParty.SelectedValue.ToString())
                        {
                            repete = 1;
                        }
                    }


                    if (repete == 0)
                    {
                        DataTable dt = dgvPurchaseDetail.DataSource as DataTable;

                        DataRow dr2 = dt.NewRow();


                        dr2["X"] = "X";

                        dr2["LOOM NO"] = txtLoomNo.Text;
                        dr2["TAGA NO"] = txtTagaNo.Text+txtChalanNo.Text+cmbParty.SelectedValue.ToString();
                        dr2["MTR"]=Convert.ToDecimal(txtMtr.Text);
                        dr2["WEIGHT"] = Convert.ToDecimal(txtTagaWeight.Text);
                        dr2["GRAMEZ"] = Convert.ToDecimal(txtGramez.Text);

               
                        dt.Rows.Add(dr2);
                        dgvPurchaseDetail.DataSource = dt;
                        txtLoomNo.Focus();
                    }
                    else
                    {
                        messageBox frm = new messageBox();
                        frm.messageTxt = "Taga with Taga No Is Already Added";
                        frm.type = "error";
                        frm.ShowDialog();
                        txtLoomNo.Focus();
                    }
                }
                else
                {
                    messageBox frm = new messageBox();
                    frm.messageTxt = "Please enter taga mtr && weight";
                    frm.type = "error";
                    frm.ShowDialog();
                    txtLoomNo.Focus();
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                GridValidation();
                defoultValue();
                txtLoomNo.Focus();
            }
        }

        private void btnAdd_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtMtr.Text) <= 0)
            {
                btnSave.Focus();
            }
        }

        private void dgvPurchaseDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvPurchaseDetail.CurrentCell.ColumnIndex == 0)
                {
                    //"confirm"
                    DialogResult dialogResult = MessageBox.Show("Are you sure to delete the record?", "Delete record", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        dgvPurchaseDetail.Rows.RemoveAt(dgvPurchaseDetail.CurrentRow.Index);
                       // gridCalculation();
                    }
                }
            }
            catch
            { }
        }

        private void cmbParty_Leave(object sender, EventArgs e)
        {
            if (cmbParty.SelectedIndex > -1)
            {
                FillGrid(203);
            }
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please select party";
                frm.type = "error";
                frm.ShowDialog();
            }
        }

        private void cmbContract_Leave(object sender, EventArgs e)
        {
            if (cmbParty.SelectedIndex > -1)
            {
                FillGrid(204);
            }
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please select party";
                frm.type = "error";
                frm.ShowDialog();
            }
        }

        private void txtBales_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtBales.Text =="")
                {
                    txtBales.Text = "0";
                }
                else if(Convert.ToInt32(txtBales.Text) >= 0)
                {
                }
            }
            catch (Exception ex)
            {
                txtBales.Text = "0";
            }
        }

        private void txtSampleCutPice_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtSampleCutPice.Text == "")
                {
                    txtSampleCutPice.Text = "0";
                }
                else if (Convert.ToInt32(txtSampleCutPice.Text) >= 0)
                {
                }
            }
            catch (Exception ex)
            {
                txtSampleCutPice.Text = "0";
            }

        }
    }
}
