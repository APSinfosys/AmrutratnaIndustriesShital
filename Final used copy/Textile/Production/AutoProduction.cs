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
    public partial class AutoProduction : Form
    {
        public AutoProduction()
        {
            InitializeComponent();
        }

        #region variables
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        public string owner, cmbLNV;
        public int cmbSV, cmbLTV;
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

                if (QueryNo == 202 || QueryNo == 203 || QueryNo == 204 || QueryNo == 206 || QueryNo == 207 || QueryNo == 208 || QueryNo == 301)
                {
                    hash.Add("@intShade", Convert.ToInt32(cmbShade.SelectedValue));
                }
                if (QueryNo == 203 || QueryNo == 204 || QueryNo == 206 || QueryNo == 207 || QueryNo == 208)
                {
                    hash.Add("@intLoomType", Convert.ToInt32(cmbLoomType.SelectedValue));
                }
                if (QueryNo == 204 || QueryNo == 206 || QueryNo == 207)
                {
                    hash.Add("@intLoomNo", Convert.ToInt32(cmbLoomNo.SelectedValue));
                }
                if (QueryNo == 207)
                {
                    hash.Add("@intQuality",Convert.ToInt32(lblQuality.Text));
                }
                if (QueryNo == 2061)
                {
                    //@ @  @strBeamNo
                    hash.Add("@intPartyName", Convert.ToInt32(lblPartyCode.Text));
                    hash.Add("@intSatNo", lblSatNo.Text);
                    hash.Add("@strBeamNo", lblBiNo.Text);
                }
                if (QueryNo == 301)
                {
                    hash.Add("@strTagaNo",txtTagaSrNo.Text);
                }

                dtReturn = ClsDefination.FillData("[Master_ProductionDML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 201)
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
                    else if (QueryNo == 203 || QueryNo == 208)
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
                    else if (QueryNo == 206)
                    {
                        //VS.PartyName,VS.SatNo,VS.BiNo,VS.BeamNo
                        lblPartyCode.Text = objRow["PartyName"].ToString();
                        lblSatNo.Text = objRow["SatNo"].ToString();
                        lblBiNo.Text = objRow["BiNo"].ToString();
                        lblBeamNo.Text = objRow["BeamNo"].ToString();
                        lblSatCount.Text = objRow["SatCount"].ToString();
                        lblQuality.Text = objRow["Quality"].ToString();
                        lblQualityName.Text = objRow["Q_Name"].ToString();
                        lblPartyName.Text = objRow["P_CompanyName"].ToString();
                        lblContract.Text = objRow["ContractNo"].ToString(); //objRow["Q_Name"].ToString();
                        lblTotalMtr.Text = objRow["meter"].ToString();
                        lblContractCode.Text = objRow["ContractCode"].ToString();

       //                 VM.PartyName,VM.SatNo,VM.BiNo,VM.BeamNo,VM.SatCount,VM.Quality,
                        //MP.P_CompanyName,QR.Q_Name ,meter ,ContractNo
                    }
                    else if (QueryNo==2061)
                    {
                        lblAvailableMtr.Text = objRow["Available Mtr"].ToString();

                    }
                    else if (QueryNo == 207)
                    {
                        lblTotalCuts.Text = "0";
                        lblTotalCuts.Text = objRow["BiCut"].ToString();
                    }
                    else if (QueryNo == 102)
                    {
                        Dashboard.Dashboard_AutoProduction frm = new Dashboard.Dashboard_AutoProduction();
                        frm.dgvSut.DataSource = dtReturn;
                    }
                    else if (QueryNo == 301)
                    {
                        int i =Convert.ToInt32(objRow["Count"].ToString());
                        if (i == 1)
                        {
                            MessageBox.Show("Taga No allready exist");
                            txtTagaSrNo.Focus();
                        }
                    }
                }
                else
                {
                    if (QueryNo == 201)
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

                if (QueryNo == 501 || QueryNo == 502)
                {

                    if (QueryNo == 502)
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
                  //  hash.Add("@intTotalEmp", Convert.ToInt32(lblTotEmpValue.Text));
                    hash.Add("@decTotalProduction", Convert.ToDecimal(txtProductionMtr.Text));
                   // hash.Add("@decTotalAmtPay", Convert.ToDecimal(lblTotalAmtPayVaue.Text));
                    hash.Add("@intPartyName", Convert.ToInt32(lblPartyCode.Text));
                    hash.Add("@intSatNo", lblSatNo.Text);
                    hash.Add("@decSatCount", Convert.ToDecimal(lblSatCount.Text));
                    hash.Add("@intBiNo", lblBiNo.Text);
                    hash.Add("@strBeamNo", lblBeamNo.Text);
                    hash.Add("@intQuality", Convert.ToInt32(lblQuality.Text));
                    hash.Add("@intRPM",txtRPM.Text);

        //            @strBeamNo,@intSatNo,
        //,)

                    hash.Add("@intContractNo",lblContractCode.Text);
                    hash.Add("@strContractName", lblContract.Text);
                    if (chkUnload.Checked == true)
                    {
                        hash.Add("@intUnload", 1);
                    }
                    else
                    {
                        hash.Add("@intUnload", 0);
                    }

                    hash.Add("@strTagaNo",txtTagaSrNo.Text);
                    hash.Add("@decTagaWeigth",Convert.ToDecimal(txtWeight.Text));

                    hash.Add("@strPartyName", lblPartyName.Text);
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

        private void AutoProduction_Load(object sender, EventArgs e)
        {
            FillGrid(201);
            cmbLoomNo.Text = "<--SELECT-->";
            cmbLoomType.Text = "<--SELECT-->";

            if (newOrEdit == 1)
            {
                cmbShade.SelectedValue = cmbSV;
                FillGrid(202);
                cmbLoomType.SelectedValue = cmbLTV;
                FillGrid(208);
                cmbLoomNo.SelectedValue = cmbLNV;
                FillGrid(206);
                FillGrid(207);
                
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
                SaveData(501, ref strReturnMSG, ref strReturnRefNo, ref intReturnPKNo);
            }
            else
            {
                SaveData(502, ref strReturnMSG, ref strReturnRefNo, ref intReturnPKNo);
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

                FillGrid(203);
                txtTagaSrNo.Text = "0";
                txtWeight.Text = "0";
                txtProductionMtr.Text = "0";
                txtRPM.Text = "0";
                cmbLoomNo.Focus();        
               // this.Close();
            }
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = strReturnMSG;
                frm.type = "error";
                frm.ShowDialog();
            }
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
                //cmbShade.Focus();
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
               // cmbLoomType.Focus();
            }
        }

        private void cmbLoomNo_Leave(object sender, EventArgs e)
        {
            if (cmbLoomNo.Text != "<--SELECT-->" && cmbLoomNo.Text != "<--NO RECORD-->" && cmbLoomNo.SelectedValue != null && Convert.ToInt32(cmbLoomNo.SelectedValue) > 0)
            {
               FillGrid(204);
                FillGrid(206);
                FillGrid(2061);
                FillGrid(207);


                decimal d = 0;

                d = (Convert.ToDecimal(lblTotalMtr.Text) / 100) * 90;

                d = Convert.ToDecimal(lblTotalMtr.Text) - d;

                if (Convert.ToDecimal(lblAvailableMtr.Text) <= d)
                {
                //messageBox frm = new messageBox();
                //frm.messageTxt = "Please check for beam unload";
                //frm.type = "error";
               // frm.ShowDialog();
                //FillGrid(202);
               ///    
                }
            }
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please select loom no";
                frm.type = "error";
                frm.ShowDialog();
                FillGrid(203);
              //  cmbLoomNo.Focus();
            }
        }

        private void txtTotNoTage_Leave(object sender, EventArgs e)
        {
            if (txtTotNoTage.Text == "" || txtTotNoTage.Text == "0")
            {
                txtTotNoTage.Text = "1";
             
                txtRemCut.Text = (Convert.ToDecimal(txtPrvCuts.Text) - 1).ToString();
            }
        }

        private void txtProductionMtr_Leave(object sender, EventArgs e)
        {
            if (txtProductionMtr.Text == "" || txtProductionMtr.Text == "0")
            {
                txtProductionMtr.Text = "0";

                messageBox frm = new messageBox();
                frm.messageTxt = "Please enter total production meter";
                frm.type = "error";
                frm.ShowDialog();
                txtProductionMtr.Focus();
            }
        }

        private void lblTotalCuts_TextChanged(object sender, EventArgs e)
        {
          //  txtTotNoTage.Text = Math.Round((Convert.ToDecimal(lblTotalCuts.Text) - Convert.ToDecimal(txtPrvCuts.Text)) + 1, 2).ToString();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtTagaSrNo_Leave(object sender, EventArgs e)
        {
            FillGrid(301);
        }
    }
}
