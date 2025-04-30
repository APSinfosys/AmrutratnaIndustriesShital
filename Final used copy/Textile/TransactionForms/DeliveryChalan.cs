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
    public partial class DeliveryChalan : Form
    {
        public DeliveryChalan()
        {
            InitializeComponent();
        }


        #region variables
        ClassFiles.CommonFunction common = new ClassFiles.CommonFunction();
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        public string UserName, yearString, companyNameStr, groupNmae, PeriodName;
        public int cmbSuppliverV, cmbTaxableV, cmbFromPartyV, cmbDesignV, cmbContactV, cmbBrokerV, cmbShadeV;
        string strReturnMSG, strReturnRefNo;
        int intReturnPKNo, repete;
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
                //QueryNo == 202 ||
                if (QueryNo == 203 || QueryNo == 204 || QueryNo == 205 || QueryNo == 209 || QueryNo == 210 || QueryNo == 102)
                {
                    hash.Add("@intQuality", cmbDesign.SelectedValue);
                }
                if (QueryNo == 203 || QueryNo == 204 || QueryNo == 205 || QueryNo == 102)
                {
                    hash.Add("@intShade", cmbShade.SelectedValue);
                }
                if (QueryNo == 204 || QueryNo == 205)
                {
                    hash.Add("@intLoom", cmbLoomNo.SelectedValue);
                }
                if (QueryNo == 205)
                {
                    hash.Add("@intTaga", cmbPiceNo.SelectedValue);
                }
                if (QueryNo == 211)
                {
                    hash.Add("@intPartyNmae", cmbParty.SelectedValue);
                }
                if (QueryNo == 213 || QueryNo == 201)
                {
                    hash.Add("@intContract", cmbContract.SelectedValue);
                }
                if (QueryNo == 3001)
                {
                    hash.Add("@intCode", Convert.ToInt32(txtChalanNo.Text));
                }

                dtReturn = ClsDefination.FillData("[Transaction_DelevaryChalan_DML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];
                    if (QueryNo == 102)
                    {
                        dgvPurchaseDetail.DataSource = dtReturn;
                        dgvPurchaseDetail.Columns[6].ReadOnly = false;

                        dgvPurchaseDetail.Columns[0].Visible = false;
                        dgvPurchaseDetail.Columns[1].Visible = false;
                        dgvPurchaseDetail.Columns[2].Visible = false;
                        dgvPurchaseDetail.Columns[3].Visible = false;

                        dgvPurchaseDetail.Columns[4].Visible = false;
                        dgvPurchaseDetail.Columns[6].Visible = false;


                        //                        GridValidation();
                    }
                    else if (QueryNo == 201)
                    {
                        cmbDesign.DataSource = dtReturn;
                        cmbDesign.ValueMember = "Q_Code";
                        cmbDesign.DisplayMember = "Q_Name";
                        cmbDesign.SelectedIndex = -1;
                        cmbDesign.Text = "<--SELECT-->";
                    }

                    else if (QueryNo == 202)
                    {
                        cmbShade.DataSource = dtReturn;
                        cmbShade.DisplayMember = "ShadeName";
                        cmbShade.ValueMember = "L_ID";
                        //cmbShade.SelectedIndex = -1;
                        //cmbShade.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 203)
                    {
                        cmbLoomNo.DataSource = dtReturn;
                        cmbLoomNo.DisplayMember = "loomNo";
                        cmbLoomNo.ValueMember = "loomNo";
                        cmbLoomNo.SelectedIndex = -1;
                        cmbLoomNo.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 204)
                    {
                        cmbPiceNo.DataSource = dtReturn;
                        cmbPiceNo.DisplayMember = "tagaNo";
                        cmbPiceNo.ValueMember = "TG_Code";
                        cmbPiceNo.SelectedIndex = -1;
                        cmbPiceNo.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 205)
                    {
                        txtMeter.Text = objRow["Taga_Mtr"].ToString();
                        txtWeight.Text = objRow["tagaWeight"].ToString();
                    }
                    else if (QueryNo == 206)
                    {
                        cmbParty.DataSource = dtReturn;
                        cmbParty.DisplayMember = "Party";
                        cmbParty.ValueMember = "P_Code";
                        cmbParty.SelectedIndex = -1;
                        cmbParty.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 207)
                    {

                        cmbBroker.DataSource = dtReturn;
                        cmbBroker.DisplayMember = "BR_Name";
                        cmbBroker.ValueMember = "BR_Code";
                        cmbBroker.SelectedIndex = -1;
                        cmbBroker.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 208)
                    {

                        cmbFirmName.DataSource = dtReturn;
                        cmbFirmName.DisplayMember = "F_CompanyName";
                        cmbFirmName.ValueMember = "F_Code";
                        cmbFirmName.SelectedIndex = -1;
                        cmbFirmName.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 209)
                    {
                        dgvWarf.DataSource = dtReturn;

                        //                wd.Q_Code,QR.Q_Name, wd.wr_sutId, MS.S_Name as [SUT],wd.wr_count as [COUNT], wd.wr_color as [COLOR],
                        //((((((wd.Tara * QR.Q_Part)* QR.Q_Lasa)) / QR.Q_WarfConst)/ wd.wr_count)) as [PER METER],'' as [TOTAL CONSUPTION]
                    }
                    else if (QueryNo == 210)
                    {
                        dgvWeft.DataSource = dtReturn;

                        WeftValidation();

                    }
                    else if (QueryNo == 211)
                    {
                        //cmbContract.SelectedValue = Convert.ToInt32(objRow["Contractcode"].ToString());
                        cmbContract.DataSource = dtReturn;
                        cmbContract.DisplayMember = "Contract";
                        cmbContract.ValueMember = "Contractcode";
                        cmbContract.SelectedIndex = -1;
                        cmbContract.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 212)
                    {
                        //cmbContract.DataSource = dtReturn;
                        //cmbContract.DisplayMember = "Contract";
                        //cmbContract.ValueMember = "Contractcode";
                        //cmbContract.SelectedIndex = -1;
                        //cmbContract.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 213)
                    {
                        //cmbDesign.SelectedValue = objRow["qualityCode"].ToString();
                        //qualityCode,brokerCode,QualityName
                        lblQuality.Text = objRow["QualityName"].ToString();
                        cmbBroker.SelectedValue = Convert.ToInt32(objRow["brokerCode"].ToString());

                    }
                    else if (QueryNo == 3001)
                    {
                        dgvPurchaseDetail.DataSource = dtReturn;
                    }
                    else if (QueryNo == 3002)
                    {
                        txtComChalanNO.Text = objRow["CompChalanNo"].ToString();
                    }
                }
                else
                {
                    if (QueryNo == 201)
                    {
                        cmbDesign.DataSource = dtReturn;
                        cmbDesign.SelectedIndex = -1;
                        cmbDesign.Text = "<--NO RECORD-->";
                    }

                    else if (QueryNo == 202)
                    {
                        cmbShade.DataSource = dtReturn;
                        cmbShade.SelectedIndex = -1;
                        cmbShade.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 203)
                    {
                        cmbLoomNo.DataSource = dtReturn;
                        cmbLoomNo.SelectedIndex = -1;
                        cmbLoomNo.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 204)
                    {
                        cmbPiceNo.DataSource = dtReturn;
                        cmbPiceNo.SelectedIndex = -1;
                        cmbPiceNo.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 205)
                    {
                        txtMeter.Text = "0";
                    }
                    else if (QueryNo == 206)
                    {
                        cmbParty.DataSource = dtReturn; ;
                        cmbParty.SelectedIndex = -1;
                        cmbParty.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 207)
                    {

                        cmbBroker.DataSource = dtReturn;
                        cmbBroker.SelectedIndex = -1;
                        cmbBroker.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 208)
                    {

                        cmbFirmName.DataSource = dtReturn;
                        cmbFirmName.SelectedIndex = -1;
                        cmbFirmName.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 209)
                    {
                        dgvWarf.DataSource = dtReturn;
                        dgvWarf.Columns[0].Visible = false;
                        dgvWarf.Columns[1].Visible = false;
                        dgvWarf.Columns[2].Visible = false;

                        //                wd.Q_Code,QR.Q_Name, wd.wr_sutId, MS.S_Name as [SUT],wd.wr_count as [COUNT], wd.wr_color as [COLOR],
                        //((((((wd.Tara * QR.Q_Part)* QR.Q_Lasa)) / QR.Q_WarfConst)/ wd.wr_count)) as [PER METER],'' as [TOTAL CONSUPTION]
                    }
                    else if (QueryNo == 210)
                    {
                        dgvWeft.DataSource = dtReturn;
                        WeftValidation();
                    }
                    else if (QueryNo == 3001)
                    {
                        dgvPurchaseDetail.DataSource = null;
                    }
                    else if (QueryNo == 3002)
                    {
                        txtComChalanNO.Text = "";
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
                hash.Add("@intYearId", fd.YearId);

                if (QueryNo == 1 || QueryNo == 2)
                {

                    if (QueryNo == 2)
                    {
                        hash.Add("@intCode", lblSrNo.Text);
                        hash.Add("@strUniqueCode", lblUniqueCode.Text);
                    }

                    hash.Add("@dtpChalanDate", dtpChalanDate.Value.ToString("MM/dd/yyyy"));
                    hash.Add("@intPartyNmae", cmbParty.SelectedValue);
                    hash.Add("@strPlace", txtPlace.Text.ToUpper());
                    hash.Add("@strBales", txtBales.Text);
                    hash.Add("@intPices", txtPieces.Text);
                    hash.Add("@decMeters", Convert.ToDecimal(txtMeters.Text));
                    hash.Add("@intQuality", cmbDesign.SelectedValue);

                    hash.Add("@intShade1", Convert.ToInt32(cmbFirmName.SelectedValue));
                    hash.Add("@intBroker", Convert.ToInt32(cmbBroker.SelectedValue));
                    hash.Add("@decSampleCutPiece", Convert.ToDecimal(txtSampleCutPice.Text));
                    hash.Add("@intShade", cmbShade.SelectedValue);

                    hash.Add("@intContract", cmbContract.SelectedValue);

                    hash.Add("@strContractName", cmbContract.Text);
                    //@intContract,

                    hash.Add("@strCompChalanNo", txtComChalanNO.Text);

                    string strXmlDetail = "";

                    StringBuilder xmlClassMaster = new StringBuilder();

                    for (int k = 0; k < dgvPurchaseDetail.Rows.Count; k++)
                    {

                        //if (Convert.ToBoolean(dgvPurchaseDetail.Rows[k].Cells[11].Value) == true)
                        //{
                        xmlClassMaster.Append("<Row>");
                        // xmlClassMaster.Append("<Quality>" + (Convert.ToInt32(dgvPurchaseDetail.Rows[k].Cells[0].Value)) + "</Quality>");
                        //  xmlClassMaster.Append("<shade>" + (Convert.ToInt32(dgvPurchaseDetail.Rows[k].Cells[2].Value)) + "</shade>");
                        xmlClassMaster.Append("<loomNo>" + (Convert.ToInt32(dgvPurchaseDetail.Rows[k].Cells[1].Value)) + "</loomNo>");
                        //  xmlClassMaster.Append("<P_Exp>" + ConvertedDate + "</P_Exp>");
                        //xmlClassMaster.Append("<pieceNo>" + (Convert.ToInt32(dgvPurchaseDetail.Rows[k].Cells[7].Value)) + "</pieceNo>");
                        xmlClassMaster.Append("<pieceNo>" + dgvPurchaseDetail.Rows[k].Cells[2].Value.ToString() + "</pieceNo>");
                        xmlClassMaster.Append("<Mtr>" + (Convert.ToDecimal(dgvPurchaseDetail.Rows[k].Cells[3].Value)) + "</Mtr>");

                        xmlClassMaster.Append("<Weight>" + (Convert.ToDecimal(dgvPurchaseDetail.Rows[k].Cells[4].Value)) + "</Weight>");
                        //GRAMEZ
                        //xmlClassMaster.Append("<GRAMEZ>" + (Convert.ToDecimal(dgvPurchaseDetail.Rows[k].Cells[10].Value)) + "</GRAMEZ>");
                        xmlClassMaster.Append("<NoOfPices>" + (Convert.ToInt32(dgvPurchaseDetail.Rows[k].Cells[2].Value)) + "</NoOfPices>");
                       //
                        xmlClassMaster.Append("<QualityCode>" + (Convert.ToInt32(dgvPurchaseDetail.Rows[k].Cells[6].Value)) + "</QualityCode>");
                        xmlClassMaster.Append("<DesignNameG>" + dgvPurchaseDetail.Rows[k].Cells[7].Value.ToString() + "</DesignNameG>");
                        xmlClassMaster.Append("</Row>");
                        // }
                    }

                    if (xmlClassMaster.Length > 0)
                    {
                        xmlClassMaster.Append("</ProductSupplierDetails>");
                        strXmlDetail = "<ProductSupplierDetails>" + Convert.ToString(xmlClassMaster);
                    }

                    hash.Add("@strXmlDetail", strXmlDetail);



                    ////////////////////////////////////////////////////////////////// WARF ///////////////////////////////
                    string strXmlDetail1 = "";

                    StringBuilder xmlClassMaster1 = new StringBuilder();

                    for (int k = 0; k < dgvWarf.Rows.Count; k++)
                    {

                        xmlClassMaster1.Append("<Row>");
                        xmlClassMaster1.Append("<SutType>" + (Convert.ToInt32(dgvWarf.Rows[k].Cells[2].Value)) + "</SutType>");
                        xmlClassMaster1.Append("<SutUse>" + (Convert.ToInt32(42)) + "</SutUse>");
                        xmlClassMaster1.Append("<Count>" + (Convert.ToDecimal(dgvWarf.Rows[k].Cells[4].Value)) + "</Count>");
                        //  xmlClassMaster.Append("<P_Exp>" + ConvertedDate + "</P_Exp>");
                        xmlClassMaster1.Append("<Color>" + (dgvWarf.Rows[k].Cells[5].Value.ToString()) + "</Color>");
                        xmlClassMaster1.Append("<WeightOut>" + (Convert.ToDecimal(dgvWarf.Rows[k].Cells[7].Value)) + "</WeightOut>");

                        // xmlClassMaster1.Append("<shade>" + (Convert.ToInt32(dgvWarf.Rows[k].Cells[8].Value)) + "</shade>");
                        //GRAMEZ

                        xmlClassMaster1.Append("</Row>");
                    }

                    if (xmlClassMaster1.Length > 0)
                    {
                        xmlClassMaster1.Append("</ProductSupplierDetails>");
                        strXmlDetail1 = "<ProductSupplierDetails>" + Convert.ToString(xmlClassMaster1);
                    }

                    hash.Add("@strXmlDetail1", strXmlDetail1);


                    ////////////////////////////////////////////////////////////////// WEFT ///////////////////////////////
                    string strXmlDetail2 = "";

                    StringBuilder xmlClassMaster2 = new StringBuilder();

                    for (int k = 0; k < dgvWeft.Rows.Count; k++)
                    {
                        xmlClassMaster2.Append("<Row>");
                        xmlClassMaster2.Append("<SutType>" + (Convert.ToInt32(dgvWeft.Rows[k].Cells[2].Value)) + "</SutType>");
                        xmlClassMaster2.Append("<SutUse>" + (Convert.ToInt32(43)) + "</SutUse>");
                        xmlClassMaster2.Append("<Count>" + (Convert.ToDecimal(dgvWeft.Rows[k].Cells[4].Value)) + "</Count>");
                        //  xmlClassMaster.Append("<P_Exp>" + ConvertedDate + "</P_Exp>");
                        xmlClassMaster2.Append("<Color>" + (dgvWeft.Rows[k].Cells[5].Value.ToString()) + "</Color>");
                        xmlClassMaster2.Append("<WeightOut>" + (Convert.ToDecimal(dgvWeft.Rows[k].Cells[7].Value)) + "</WeightOut>");
                        xmlClassMaster2.Append("<Pick>" + (Convert.ToDecimal(dgvWeft.Rows[k].Cells[9].Value)) + "</Pick>");
                        //xmlClassMaster2.Append("<shade>" + (Convert.ToInt32(dgvWeft.Rows[k].Cells[8].Value)) + "</shade>");
                        //GRAMEZ

                        xmlClassMaster2.Append("</Row>");
                    }

                    if (xmlClassMaster2.Length > 0)
                    {
                        xmlClassMaster2.Append("</ProductSupplierDetails>");
                        strXmlDetail2 = "<ProductSupplierDetails>" + Convert.ToString(xmlClassMaster2);
                    }

                    hash.Add("@strXmlDetail2", strXmlDetail2);
                }

                okflag = 1;
                return ClsDefination.InsertExecute(hash, "[Transaction_DelevaryChalan_DML]", ref strReturnMSG, ref strReturnNo, ref intReturnNo);
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

        #region GRID CREATION & validation
        public void WeftValidation()
        {
            dgvWeft.Columns[0].Visible = dgvWeft.Columns[1].Visible = dgvWeft.Columns[2].Visible = dgvWeft.Columns[5].Visible = dgvWeft.Columns[8].Visible =
                       dgvWeft.Columns[10].Visible = dgvWeft.Columns[11].Visible = dgvWeft.Columns[12].Visible = false;

            for (int i = 0; i < dgvWeft.Columns.Count; i++)
            {
                dgvWeft.Columns[i].ReadOnly = true;
            }
            dgvWeft.Columns[9].ReadOnly = false;

            //3 4 8 5 6

            dgvWeft.Columns[3].DisplayIndex = 0;
            dgvWeft.Columns[4].DisplayIndex = 1;
            dgvWeft.Columns[9].DisplayIndex = 2;
            dgvWeft.Columns[6].DisplayIndex = 3;
            dgvWeft.Columns[7].DisplayIndex = 4;

        }

        #endregion

        public void printerlist()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Name", typeof(string));

            //comboBox1.DataSource = dt; 
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                //       MessageBox.Show(printer);

                dt.Rows.Add(printer);
            }
            cmbPrinter.DataSource = dt;
            cmbPrinter.DisplayMember = "Name";
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
                if (Convert.ToInt32(strReturnMSG) > 0)
                {
                    //TransactionReport.CRTransaction frmT = new TransactionReport.CRTransaction();

                    //ClsDefination.Readpath();

                    //frmT.QueryNo = 1009;
                    //frmT.server = ClsDefination.server;
                    //frmT.dbname = ClsDefination.database;
                    //frmT.username = ClsDefination.id;
                    //frmT.password = ClsDefination.password;
                    //frmT.reportPath = ClsDefination.CrystalPath;

                    //frmT.intCompanyID = fd.CompId;

                    //frmT.intYearID = fd.YearId;
                    //frmT.VoucherId = Convert.ToInt32(strReturnMSG);     //Convert.ToInt32(dgvSut.CurrentRow.Cells[14].Value.ToString());
                    ////frmT.intSupplierId = Convert.ToInt32(dgvSut.CurrentRow.Cells[39].Value.ToString());
                    //frmT.ShowDialog();
                    //this.Close();

                }



            }
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = strReturnMSG;
                frm.type = "error";
                frm.ShowDialog();
            }
        }

        private void DeliveryChalan_Load(object sender, EventArgs e)
        {
            printerlist();
            // FillGrid(201);
            FillGrid(202); // shade
            FillGrid(206); // party
            FillGrid(207); // broker
            FillGrid(208); // firm

            GridCreationDelivery();

            if (newOrEdit == 1)
            {
                cmbShade.SelectedValue = cmbShadeV;
                cmbParty.SelectedValue = cmbSuppliverV;
                cmbBroker.SelectedValue = cmbBrokerV;
                cmbFirmName.SelectedValue = cmbFromPartyV;

                FillGrid(3001); // Delivery details
                FillGrid(211);// for contract
                cmbContract.SelectedValue = cmbContactV;
                FillGrid(201);//for design
                cmbDesign.SelectedValue = cmbDesignV;
                // FillGrid(213);
                FillGrid(209);// warf
                FillGrid(210); // weft
            }
            else
            {
                FillGrid(3002); // get chalan no
            }



        }

        public void ConsumptionCalculation()
        {
            try
            {
                //decimal warf=0;
                lblWarfConsuption.Text = "0";
                lblWeftConsuption.Text = "0";

                if (txtSampleCutPice.Text == "")
                {
                    txtSampleCutPice.Text = "0";
                }

                for (int i = 0; i < dgvWarf.Rows.Count; i++)
                {
                    //7
                    // warf= warf+ Convert.ToDecimal(dgvWarf.Rows[
                    dgvWarf.Rows[i].Cells[7].Value = Math.Round((Convert.ToDecimal(txtMeters.Text) + Convert.ToDecimal(txtSampleCutPice.Text)) * Convert.ToDecimal(dgvWarf.Rows[i].Cells[6].Value), 5);
                    lblWarfConsuption.Text = Math.Round(Convert.ToDecimal(lblWarfConsuption.Text) + Convert.ToDecimal(dgvWarf.Rows[i].Cells[7].Value), 5).ToString();
                    // dgvWarf.Rows[i].Cells[8].Value = "";
                    // dgvWarf.Rows[i].Cells[8].Value = cmbShade.SelectedValue;

                }
                for (int i = 0; i < dgvWeft.Rows.Count; i++)
                {
                    //7
                    // warf= warf+ Convert.ToDecimal(dgvWarf.Rows[
                    dgvWeft.Rows[i].Cells[7].Value = Math.Round((Convert.ToDecimal(txtMeters.Text) + Convert.ToDecimal(txtSampleCutPice.Text)) * Convert.ToDecimal(dgvWeft.Rows[i].Cells[6].Value), 5);
                    lblWeftConsuption.Text = Math.Round(Convert.ToDecimal(lblWeftConsuption.Text) + Convert.ToDecimal(dgvWeft.Rows[i].Cells[7].Value), 5).ToString();
                    //  dgvWeft.Rows[i].Cells[8].Value = "";
                    //  dgvWeft.Rows[i].Cells[8].Value = cmbShade.SelectedValue;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                FillGrid(102);
                //repete = 0;
                //if (Convert.ToInt32(cmbLoomNo.SelectedValue) > 0)
                //{
                //    for (int i = 0; i < dgvPurchaseDetail.Rows.Count; i++)
                //    {
                //        if (Convert.ToInt32(dgvPurchaseDetail.Rows[i].Cells[5].Value.ToString()) == Convert.ToInt32(cmbLoomNo.SelectedValue)
                //            && Convert.ToInt32(dgvPurchaseDetail.Rows[i].Cells[7].Value.ToString()) == Convert.ToInt32(cmbPiceNo.SelectedValue))
                //        {
                //            repete = 1;
                //        }
                //    }


                //    if (repete == 0)
                //    {

                //        DataTable dt = dgvPurchaseDetail.DataSource as DataTable;
                //        DataRow dr2 = dt.NewRow();


                //        dr2["X"] = "X";
                //        dr2["QUALITY CODE"] = cmbDesign.SelectedValue;

                //        //dt.Columns.Add("", typeof(int)); //1
                //        dr2["QUALITY NAME"] = cmbDesign.Text;
                //        //dt.Columns.Add("QUALITY NAME", typeof(string));//2
                //        dr2["SHADE CODE"] = cmbShade.SelectedValue;
                //        //dt.Columns.Add("SHADE CODE", typeof(int));//3
                //        dr2["SHADE NAME"] = cmbShade.Text;
                //        //dt.Columns.Add("SHADE NAME", typeof(string));//4
                //        dr2["LOOM CODE"] = cmbLoomNo.SelectedValue;
                //        //dt.Columns.Add("LOOM CODE", typeof(int));//5
                //        dr2["LOOM NO"] = cmbLoomNo.Text;
                //        //dt.Columns.Add("LOOM NO", typeof(string));//6
                //        dr2["PIECE CODE"] = cmbPiceNo.SelectedValue;
                //        //dt.Columns.Add("PIECE CODE", typeof(int));//7
                //        dr2["PIECE NO"] = cmbPiceNo.Text;
                //        //dt.Columns.Add("PIECE NO", typeof(string)); // 8
                //        dr2["METER"] = txtMeter.Text;
                //        //dt.Columns.Add("METER", typeof(decimal)); // 9
                //        dr2["WEIGHT"] = txtWeight.Text;
                //        //dt.Columns.Add("", typeof(decimal)); // 10
                //        dr2["GRAMEZ"] = txtGramz.Text;

                //        dt.Rows.Add(dr2);
                //        dgvPurchaseDetail.DataSource = dt;
                //    }
                //    else
                //    {
                //        messageBox frm = new messageBox();
                //        frm.messageTxt = "Piece is allready added";
                //        frm.type = "error";
                //        frm.ShowDialog();
                //    }
                //}
            }
            catch (Exception ex)
            {
            }
            finally
            {
                FillGrid(203);
                cmbLoomNo.Focus();
                //cmbLoomNo.Text = "<--SELECT-->";
                txtWeight.Text = "0";
                txtGramz.Text = "0";
                txtMeter.Text = "0";
                gridCalculation();

                ConsumptionCalculation();
            }
        }

        private void cmbDesign_Leave(object sender, EventArgs e)
        {

            if (Convert.ToInt32(cmbDesign.SelectedValue) > 0 && cmbDesign.SelectedValue != null)
            {
                //FillGrid(202);
                FillGrid(209);
                FillGrid(210);
                //QR.Q_Panna,WD.Pick,QR.Q_WeftConst,WD.we_count,QR.Westage
                dgvWarf.Columns[0].Visible = dgvWarf.Columns[1].Visible = dgvWarf.Columns[2].Visible = dgvWarf.Columns[5].Visible = false;
            }

        }

        private void cmbShade_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbShade.SelectedValue) > 0)
            {
                //FillGrid(203);
                // FillGrid(102);
                //lblWeftConsuption.Text = lblWarfConsuption.Text = "0.00";
                if (txtPieces.Text == "0")
                {
                    txtBiNo.Focus();
                }
                else
                {
                    button1.Focus();
                }
            }
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please select Shade";
                frm.type = "error";
                frm.ShowDialog();
                cmbShade.Focus();
            }
        }

        private void cmbLoomNo_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbLoomNo.SelectedValue) > 0 && cmbLoomNo.SelectedValue != null)
            {
                FillGrid(204);
            }
        }

        private void cmbPiceNo_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbPiceNo.SelectedValue) > 0 && cmbPiceNo.SelectedValue != null)
            {
                FillGrid(205);
            }
        }

        public void gridCalculation()
        {
            try
            {
                txtMeters.Text = "0";
                txtPieces.Text = "0";

                for (int i = 0; i < dgvPurchaseDetail.Rows.Count; i++)
                {
                    txtMeters.Text = Math.Round(
                        Convert.ToDecimal(txtMeters.Text) + Convert.ToDecimal(dgvPurchaseDetail.Rows[i].Cells[9].Value), 2
                        ).ToString();
                }

                txtPieces.Text = dgvPurchaseDetail.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
            }

        }

        private void txtWeight_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtGramz.Text = Math.Round(Convert.ToDecimal(txtWeight.Text) / Convert.ToDecimal(txtMeter.Text), 3).ToString();
            }
            catch (Exception ex)
            {
            }
        }

        private void cmbShade1_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbFirmName.SelectedIndex) < 0)
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please select Shade";
                frm.type = "error";
                frm.ShowDialog();
                //cmbPartyName.Focus();
            }
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

        private void txtSampleCutPice_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtSampleCutPice.Text == "")
                {
                    txtSampleCutPice.Text = "0";
                }
                if (Convert.ToDecimal(txtSampleCutPice.Text) > 0)
                {
                    //txtSampleCutPice.Text = "0";
                    ConsumptionCalculation();
                }

            }
            catch (Exception ex)
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please Enter Valid Sample & Cut Piece Meters";
                frm.type = "error";
                frm.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //if (txtMeters.Text == "")
            //{
            //    txtMeters.Text = "0";
            //}
            //if (txtPieces.Text == "")
            //{
            //    txtPieces.Text = "0";
            //}


            //for (int i = 0; i < dgvPurchaseDetail.Rows.Count; i++)
            //{
            //    if (Convert.ToBoolean(dgvPurchaseDetail.Rows[i].Cells[11].Value) == true)
            //    {
            //        txtMeters.Text = Math.Round(
            //            Convert.ToDecimal(txtMeters.Text) + Convert.ToDecimal(dgvPurchaseDetail.Rows[i].Cells[8].Value), 3
            //            ).ToString();

            //        txtPieces.Text = (Convert.ToInt32(txtPieces.Text) + 1).ToString();
            //    }
            //}



            lblWarfConsuption.Text = "0";
            lblWeftConsuption.Text = "0";

            if (txtSampleCutPice.Text == "")
            {
                txtSampleCutPice.Text = "0";
            }

            for (int i = 0; i < dgvWarf.Rows.Count; i++)
            {
                dgvWarf.Rows[i].Cells[7].Value = Math.Round((Convert.ToDecimal(txtMeters.Text) + Convert.ToDecimal(txtSampleCutPice.Text)) *
                    Convert.ToDecimal(dgvWarf.Rows[i].Cells[6].Value), 3);
                lblWarfConsuption.Text = Math.Round(Convert.ToDecimal(lblWarfConsuption.Text) + Convert.ToDecimal(dgvWarf.Rows[i].Cells[7].Value), 3).ToString();
            }


            weftCalculation();

        }


        public void weftCalculation()
        {
            for (int i = 0; i < dgvWeft.Rows.Count; i++)
            {
                decimal p = Convert.ToDecimal(dgvWeft.Rows[i].Cells[8].Value);
                decimal pik = Convert.ToDecimal(dgvWeft.Rows[i].Cells[9].Value);
                decimal wconst = Convert.ToDecimal(dgvWeft.Rows[i].Cells[10].Value);
                decimal weCount = Convert.ToDecimal(dgvWeft.Rows[i].Cells[11].Value);
                decimal westage = Convert.ToDecimal(dgvWeft.Rows[i].Cells[12].Value);

                decimal mtr = Math.Round(((((p * pik) * 1) / wconst) / weCount) + (((((p * pik * 1) / wconst) / weCount) / 100) * westage), 3);
                dgvWeft.Rows[i].Cells[6].Value = mtr;
                dgvWeft.Rows[i].Cells[7].Value = Math.Round((Convert.ToDecimal(txtMeters.Text) + Convert.ToDecimal(txtSampleCutPice.Text)) * mtr, 3);
                lblWeftConsuption.Text = Math.Round(Convert.ToDecimal(lblWeftConsuption.Text) + Convert.ToDecimal(dgvWeft.Rows[i].Cells[7].Value), 3).ToString();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbParty_Leave(object sender, EventArgs e)
        {
            if (cmbParty.SelectedIndex > -1)
            {
                FillGrid(211);
                if (newOrEdit == 1)
                {
                    cmbContract.SelectedValue = cmbContactV;
                }
            }
        }

        private void cmbContract_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbContract.SelectedIndex) > -1)
            {
                FillGrid(201);
                FillGrid(213);

                if (newOrEdit == 1)
                {
                    cmbDesign.SelectedValue = cmbDesignV;
                    cmbBroker.Enabled = false;
                }
            }
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please select Contract";
                frm.type = "error";
                frm.ShowDialog();
                cmbContract.Focus();
            }
        }

        private void dgvWeft_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            weftCalculation();
        }


        #region GridCreationDelivery
        public void GridCreationDelivery()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("X", typeof(string));          //0
                dt.Columns.Add("LOOM NO", typeof(int));
                dt.Columns.Add("PICES", typeof(int));
                dt.Columns.Add("MTR", typeof(decimal));
                dt.Columns.Add("WEIGHT", typeof(decimal));
                dt.Columns.Add("DESIGN", typeof(string));
                dt.Columns.Add("QualityCode", typeof(int));
                dt.Columns.Add("DesignNameG", typeof(string));
                dgvPurchaseDetail.DataSource = dt;
                //dgvPurchaseDetail.Columns[5].Visible = dgvPurchaseDetail.Columns[6].Visible = false;
            }
            catch (Exception ex)
            {
            }
        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            txtPieces.Enabled = txtMeters.Enabled = false;
            int repeat = 0;
            //int pcount = 0;
            //decimal totMtr = 0.00M;
            if (txtBiNo.Text != "")
            {
                if (Convert.ToInt32(txtPices.Text) > 0)
                {
                    if (Convert.ToDecimal(txtGrifMtr.Text) > 0)
                    {
                        for (int i = 0; i < dgvPurchaseDetail.Rows.Count; i++)
                        {
                            if (Convert.ToInt32(dgvPurchaseDetail.Rows[i].Cells[2].Value) == Convert.ToInt32(txtPices.Text))
                            {
                                repeat = 1;
                                break;
                            }
                        }


                        if (repeat == 0)
                        {
                            DataTable dt = dgvPurchaseDetail.DataSource as DataTable;

                            DataRow dr2 = dt.NewRow();
                            dr2["X"] = "X";
                            dr2["LOOM NO"] = Convert.ToInt32(txtBiNo.Text);
                            dr2["PICES"] = txtPices.Text;
                            dr2["MTR"] = txtGrifMtr.Text;
                            dr2["WEIGHT"] = Convert.ToDecimal(txtGridWeight.Text);
                            dr2["DESIGN"] = cmbDesign.Text;
                            dr2["QualityCode"]=cmbDesign.SelectedValue;
                            dr2["DesignNameG"] = txtDesignNameG.Text;
                            
                            dt.Rows.Add(dr2);

                            dgvPurchaseDetail.DataSource = dt;
                            upperCalc();
                            txtBiNo.Text = "";
                            txtGrifMtr.Text = txtGridWeight.Text = txtPices.Text = "0";

                            txtBiNo.Focus();
                        }
                        else
                        {
                            messageBox frm = new messageBox();
                            frm.messageTxt = "Record for this loom no is already added";
                            frm.type = "error";
                            frm.ShowDialog();
                        }
                    }
                    else
                    {
                        messageBox frm = new messageBox();
                        frm.messageTxt = "Please Enter Mtr's";
                        frm.type = "error";
                        frm.ShowDialog();
                    }
                }
                else
                {
                    messageBox frm = new messageBox();
                    frm.messageTxt = "Please Enter Pices";
                    frm.type = "error";
                    frm.ShowDialog();
                }
            }
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please Enter Bieam No";
                frm.type = "error";
                frm.ShowDialog();
            }
        }

        public void upperCalc() // pice and meter
        {
            int pice = 0;
            decimal mtr = 0.00M;

            if (dgvPurchaseDetail.Rows.Count >= 0)
            {
                for (int i = 0; i < dgvPurchaseDetail.Rows.Count; i++)
                {
                    //pice = pice + Convert.ToInt32(dgvPurchaseDetail.Rows[i].Cells[2].Value);
                    mtr = mtr + Convert.ToDecimal(dgvPurchaseDetail.Rows[i].Cells[3].Value);
                }

                txtPieces.Text = dgvPurchaseDetail.Rows.Count.ToString();
                txtMeters.Text = mtr.ToString();
            }
        }

        private void txtBiNo_Leave(object sender, EventArgs e)
        {
            if (txtBiNo.Text == "")
            {
                txtBiNo.Text = "0";
            }
        }

        private void txtPices_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtPices.Text) < 0)
                {
                    txtPices.Text = "0";
                }
            }
            catch (Exception ex)
            {
                txtPices.Text = "0";
            }

        }

        private void txtGrifMtr_Leave(object sender, EventArgs e)
        {
            try
            {
                //if (Convert.ToInt32(txtGrifMtr.Text) < 0)
                //{
                //    txtGrifMtr.Text = "0";
                //}
            }
            catch (Exception ex)
            {
                txtGrifMtr.Text = "0";
            }
        }

        private void txtGridWeight_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(txtGridWeight.Text) < 0)
                {
                    txtGridWeight.Text = "0";
                }
            }
            catch (Exception ex)
            {
                txtGridWeight.Text = "0";
            }
        }

        private void dgvPurchaseDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvPurchaseDetail.CurrentCell.ColumnIndex == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure to delete the record?", "Delete record", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        dgvPurchaseDetail.Rows.RemoveAt(dgvPurchaseDetail.CurrentRow.Index);
                        upperCalc();
                    }
                }
            }
            catch
            { }
        }

    }
}
