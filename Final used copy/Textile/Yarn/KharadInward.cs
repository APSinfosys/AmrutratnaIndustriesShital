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

namespace Textile.Yarn
{
    public partial class KharadInward : Form
    {
        public KharadInward()
        {
            InitializeComponent();
        }

        #region variables
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        public string UserName, yearString, companyNameStr, groupNmae, PeriodName, count, color;
        public int cmbPartyV, cmbSutTypeV, cmbSutUseV, cmbFirmV, cmbShadeV, cmbGetpassV, cmbQualityV;
        string strReturnMSG, strReturnRefNo;
        int intReturnPKNo;
        int okflag;

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

                if(QueryNo==204)
                {
                    hash.Add("@intParty", cmbPartyName.SelectedValue);    
                 }
                if (QueryNo == 205)
                {
                    hash.Add("@intGetpassToParty", cmbGetpassNo.SelectedValue);
                }


                dtReturn = ClsDefination.FillData("[Sizing_KharadInward_DML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 201)
                    {
                        cmbFirm.DataSource = dtReturn;
                        cmbFirm.DisplayMember = "F_CompanyName";
                        cmbFirm.ValueMember = "F_Code";
                        cmbFirm.SelectedIndex = -1;
                        cmbFirm.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 202)
                    {
                        cmbShade.DataSource = dtReturn;
                        cmbShade.DisplayMember = "L_ShadeName";
                        cmbShade.ValueMember = "L_Code";
                        cmbShade.SelectedIndex = -1;
                        cmbShade.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 203)
                    {
                        cmbPartyName.DataSource = dtReturn;
                        cmbPartyName.DisplayMember = "P_CompanyName";
                        cmbPartyName.ValueMember = "P_Code";
                        cmbPartyName.SelectedIndex = -1;
                        cmbPartyName.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 204)
                    {
                        cmbGetpassNo.DataSource = dtReturn;
                        cmbGetpassNo.DisplayMember = "YO_GetpassNo";
                        cmbGetpassNo.ValueMember = "YO_Code";
                        cmbGetpassNo.SelectedIndex = -1;
                        cmbGetpassNo.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 205)
                    {
                        lblYarnCode.Text = objRow["YO_SutType"].ToString();
                        lblWarfWeftCode.Text = objRow["YO_SutUse"].ToString();
                        lblCount.Text = objRow["YO_Count"].ToString();
                        lblColor.Text = objRow["YO_Color"].ToString();
              //          YOD.,YOD.,YOD.,YOD.,
                        lblYarnDetails.Text = objRow["YARN DETAILS"].ToString();
              //MS.S_Name+' '+CV.Common_Value+' '+YOD.YO_Count+' '+YOD.YO_Color as [],
                        txtBag.Text = objRow["YO_TotMixBag"].ToString();
                        txtKon.Text = objRow["YO_TotMixKon"].ToString();
                        txtGrossWeight.Text = objRow["YO_TotMixWeight"].ToString();
              //YOD.,YOD.,YOD.

                        txtPart.Text = objRow["part"].ToString();
                        txtTara.Text = objRow["tara"].ToString();
                        txtMeasure.Text = objRow["measure"].ToString();
                        txtMillName.Text = objRow["MillName"].ToString();
                        txtLotNo.Text = objRow["LotNo"].ToString();
                        //YON.,yon.part,YON.,YON.,YON.

                        cmbQuality.SelectedValue = Convert.ToInt32(objRow["Quality"].ToString());

                        lblContract.Text = objRow["contractNo"].ToString();
                        lblContractCode.Text = objRow["contractNoValue"].ToString();
                        //YON.,YON.
                    }
                    else if (QueryNo == 206)
                    {
                        cmbQuality.DataSource = dtReturn;
                        cmbQuality.DisplayMember = "Q_Name";
                        cmbQuality.ValueMember = "Q_Code";
                        cmbQuality.SelectedIndex = -1;
                        cmbQuality.Text = "<--SELECT-->";
                    }
                }
                else
                {
                    if (QueryNo == 201)
                    {
                        cmbFirm.DataSource = dtReturn;
                        cmbFirm.SelectedIndex = -1;
                        cmbFirm.Text = "<--NO SELECT-->";
                    }
                    else if (QueryNo == 202)
                    {
                        cmbShade.DataSource = dtReturn;
                        cmbShade.SelectedIndex = -1;
                        cmbShade.Text = "<--NO SELECT-->";
                    }
                    else if (QueryNo == 203)
                    {
                        cmbPartyName.DataSource = dtReturn;
                        cmbPartyName.SelectedIndex = -1;
                        cmbPartyName.Text = "<--NO SELECT-->";
                    }
                    else if (QueryNo == 204)
                    {
                        cmbGetpassNo.DataSource = dtReturn;
                        cmbGetpassNo.SelectedIndex = -1;
                        cmbGetpassNo.Text = "<--NO SELECT-->";
                    }
                    else if (QueryNo == 205)
                    {
                        lblYarnCode.Text = "0";
                        lblWarfWeftCode.Text = "0";
                        lblCount.Text = "0";
                        lblColor.Text = "0";
                        //          YOD.,YOD.,YOD.,YOD.,
                        lblYarnDetails.Text = "NO DETAILS AVAILABLE";
                        //MS.S_Name+' '+CV.Common_Value+' '+YOD.YO_Count+' '+YOD.YO_Color as [],
                        txtBag.Text = "0";
                        txtKon.Text = "0";
                        txtGrossWeight.Text = "0";
                        //YOD.,YOD.,YOD.
                        txtPart.Text = "0";
                        txtTara.Text = "0";
                        txtMeasure.Text = "0";
                        txtMillName.Text = "0";
                        txtLotNo.Text = "0";
                        cmbQuality.SelectedValue = 0;
                        lblContract.Text = "0";
                        lblContractCode.Text = "0";
                    }
                    else if (QueryNo == 206)
                    {
                        cmbQuality.DataSource = dtReturn;
                        cmbQuality.SelectedIndex = -1;
                        cmbQuality.Text = "<--NO SELECT-->";
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

                    hash.Add("@strGetpassNo",txtGetpass.Text);
                    hash.Add("@dtpDate",dtpInvoiceDate.Value.ToString("MM/dd/yyyy"));
                    hash.Add("@intFirm", cmbFirm.SelectedValue);
                    hash.Add("@intShade",cmbShade.SelectedValue);
                    hash.Add("@intParty",cmbPartyName.SelectedValue);
                    hash.Add("@strGetpassToParty",cmbGetpassNo.Text);
 //@ as int=0,
 //@ as varchar(50)='',
 // as smalldatetime='01/01/1900',// as int=0,// as int=0,// as int=0,// as varchar(50)='',
                    hash.Add("@intGetpassToParty",cmbGetpassNo.SelectedValue);
                    hash.Add("@intQuality", cmbQuality.SelectedValue);
                    hash.Add("@decTotEmptyBag",Convert.ToDecimal(txtTotBag.Text));
                    hash.Add("@decEmptyBagWeight",Convert.ToDecimal(txtBagWeight.Text));
 // as int=0,// as int=0,// as decimal(18,2)=0.00,// as decimal(18,3)=0.000,

                    hash.Add("@decTotEmptyKon",Convert.ToDecimal(txtTotKon.Text));
                    hash.Add("@decEmptyKonWeight",Convert.ToDecimal(txtKonWeight.Text));
                    hash.Add("@decTotEmpatyBagWeight",Convert.ToDecimal(lblEmptyBagWeight.Text));
 // as decimal(18,2)=0.00,// as decimal(18,3)=0.000,// as decimal(18,3)=0.000,
                    hash.Add("@decTotEmptyKonWeight",Convert.ToDecimal(lblEmptyKonWeight.Text));
                    hash.Add("@decTotNetWeight",Convert.ToDecimal(lblNetWeight.Text));
                    hash.Add("@decTotUsedWeight",Convert.ToDecimal(lblUsedWeight.Text));
 // as decimal(18,3)=0.000,// as decimal(18,3)=0.000,// as decimal(18,3)=0.000,
                  
                    hash.Add("@intSut",Convert.ToInt32(lblYarnCode.Text));
                    hash.Add("@intWarfWeft",Convert.ToInt32(lblWarfWeftCode.Text));
                    hash.Add("@decCount",Convert.ToDecimal(lblCount.Text));
 // as varchar(50)='',// as int=0,// as int=0,// as int=0,// as decimal(18,2)=0.00,
                    hash.Add("@strColor",lblColor.Text);
                    hash.Add("@strSutType","");
                    hash.Add("@intBag", Convert.ToDecimal(txtKharadBag.Text));
                    hash.Add("@intKon",Convert.ToDecimal(txtKharadKon.Text));
                    hash.Add("@decWeight",Convert.ToDecimal(txtKharadWeight.Text));
 // as varchar(50)='',// as varchar(50)='',// as decimal(18,2)=0.00,// as decimal(18,2)=0.00,// as decimal(18,3)=0.000,

                    hash.Add("@intBagF",Convert.ToDecimal(txtFreshBag.Text));
                    hash.Add("@intKonF",Convert.ToDecimal(txtFreshKon.Text));
                    hash.Add("@decWeightF",Convert.ToDecimal(txtFreshWeight.Text));
 // as decimal(18,2)=0.00,// as decimal(18,2)=0.00,// as decimal(18,3)=0.000,//@ as int=0, //@ as int=0,//@ as int=0,

                    hash.Add("@intContractCode",Convert.ToInt32(lblContract.Text));
                    hash.Add("@strContractName", lblContractCode.Text);
             //@,ContractName=
                    hash.Add("@strLotNo", txtLotNo.Text);

                }

                okflag = 1;
                return ClsDefination.InsertExecute(hash, "[Sizing_KharadInward_DML]", ref strReturnMSG, ref strReturnNo, ref intReturnNo);
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

        #region   //------------------ CALCULATION

        public void calculations()
        {
            try
            {
                txtTotBag.Text = lblMixBag.Text = Math.Round(Convert.ToDecimal(txtKharadBag.Text) + Convert.ToDecimal(txtFreshBag.Text), 2).ToString();
                txtTotKon.Text = lblMixKon.Text = Math.Round(Convert.ToDecimal(txtKharadKon.Text) + Convert.ToDecimal(txtFreshKon.Text), 2).ToString();
                lblMixWeight.Text = Math.Round(Convert.ToDecimal(txtKharadWeight.Text) + Convert.ToDecimal(txtFreshWeight.Text), 3).ToString();

                lblEmptyBagWeight.Text = Math.Round(Convert.ToDecimal(txtTotBag.Text)*Convert.ToDecimal(txtBagWeight.Text),3 ).ToString();
                lblEmptyKonWeight.Text = Math.Round(Convert.ToDecimal(txtTotKon.Text) * Convert.ToDecimal(txtKonWeight.Text), 3).ToString();


                lblNetWeight.Text = Math.Round( Convert.ToDecimal(lblMixWeight.Text)-Convert.ToDecimal(lblEmptyBagWeight.Text)-Convert.ToDecimal(lblEmptyKonWeight.Text),3 ).ToString();

                lblUsedWeight.Text = Math.Round(Convert.ToDecimal(txtGrossWeight.Text)-Convert.ToDecimal(lblNetWeight.Text),3).ToString();


            }
            catch (Exception ex)
            {
            }
        }


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

        private void txtGrossWeight_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(txtGrossWeight.Text) <= 0 || txtGrossWeight.Text == "")
                {

                }
                else
                {
                    calculations();
                }

            }
            catch (Exception ex)
            {
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtKharadBag_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(txtKharadBag.Text) <= 0 || txtKharadBag.Text == "")
                {
                    messageBox frm = new messageBox();
                    frm.messageTxt = "Please enter bag's";
                    frm.type = "error";
                    frm.ShowDialog();
                }
                else
                {
                    calculations();
                }

            }
            catch (Exception ex)
            {
            }
        }

        private void txtKharadKon_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(txtKharadKon.Text) <= 0 || txtKharadKon.Text == "")
                {
                    messageBox frm = new messageBox();
                    frm.messageTxt = "Please enter kon's";
                    frm.type = "error";
                    frm.ShowDialog();
                }
                else
                {
                    calculations();
                }

            }
            catch (Exception ex)
            {
            }
        }

        private void txtKharadWeight_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(txtKharadWeight.Text) <= 0 || txtKharadWeight.Text == "")
                {
                    messageBox frm = new messageBox();
                    frm.messageTxt = "Please enter weight";
                    frm.type = "error";
                    frm.ShowDialog();
                }
                else
                {
                    calculations();
                }

            }
            catch (Exception ex)
            {
            }
        }

        private void txtFreshBag_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(txtFreshBag.Text) <= 0 || txtFreshBag.Text == "")
                {
                    messageBox frm = new messageBox();
                    frm.messageTxt = "Please enter bag's";
                    frm.type = "error";
                    frm.ShowDialog();
                }
                else
                {
                    calculations();
                }

            }
            catch (Exception ex)
            {
            }
        }

        private void txtFreshKon_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(txtFreshKon.Text) <= 0 || txtFreshKon.Text == "")
                {
                    messageBox frm = new messageBox();
                    frm.messageTxt = "Please enter kon's";
                    frm.type = "error";
                    frm.ShowDialog();
                }
                else
                {
                    calculations();
                }

            }
            catch (Exception ex)
            {
            }
        }

        private void txtFreshWeight_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(txtFreshWeight.Text) <= 0 || txtFreshWeight.Text == "")
                {
                    messageBox frm = new messageBox();
                    frm.messageTxt = "Please enter kon weight";
                    frm.type = "error";
                    frm.ShowDialog();
                }
                else
                {
                    calculations();
                }

            }
            catch (Exception ex)
            {
            }
        }

        private void txtBagWeight_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(txtBagWeight.Text) <= 0 || txtBagWeight.Text == "")
                {
                    messageBox frm = new messageBox();
                    frm.messageTxt = "Please enter bag weight";
                    frm.type = "error";
                    frm.ShowDialog();
                }
                else
                {
                    calculations();
                }

            }
            catch (Exception ex)
            {
            }
        }

        private void txtKonWeight_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(txtKonWeight.Text) <= 0 || txtKonWeight.Text == "")
                {
                    messageBox frm = new messageBox();
                    frm.messageTxt = "Please enter kon weight";
                    frm.type = "error";
                    frm.ShowDialog();
                }
                else
                {
                    calculations();
                }

            }
            catch (Exception ex)
            {
            }
        }

        private void KharadInward_Load(object sender, EventArgs e)
        {
            FillGrid(201);
            FillGrid(202);
            FillGrid(203);

            if (newOrEdit == 1)
            {
                cmbFirm.SelectedValue = cmbFirmV;
                cmbShade.SelectedValue = cmbShadeV;
                cmbPartyName.SelectedValue = cmbPartyV;
                FillGrid(204);
                cmbGetpassNo.SelectedValue = cmbGetpassV;
                FillGrid(206);
                FillGrid(205);
                cmbQuality.SelectedValue = cmbQualityV;
            }
        }

        private void cmbPartyName_Leave(object sender, EventArgs e)
        {
            if (cmbPartyName.SelectedIndex > -1)
            {
                FillGrid(204);

                if (newOrEdit == 1)
                {
                    cmbGetpassNo.SelectedValue = cmbGetpassV;
                }
            }
        }

        private void cmbGetpassNo_Leave(object sender, EventArgs e)
        {
            if (cmbGetpassNo.SelectedIndex > -1)
            {
                FillGrid(206);
                FillGrid(205);

                if (newOrEdit == 1)
                {
                    cmbQuality.SelectedValue = cmbQualityV;
                }
            }
        }
    }
}
