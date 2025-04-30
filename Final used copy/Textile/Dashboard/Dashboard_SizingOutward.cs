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

namespace Textile.Dashboard
{
    public partial class Dashboard_SizingOutward : Form
    {
        public Dashboard_SizingOutward()
        {
            InitializeComponent();
        }

        #region variables
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        BindingSource bs = new BindingSource();
        BindingSource bsOriginal = new BindingSource();
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
                if(QueryNo==101)
                {
                    hash.Add("@intOutwardTo", 1);
                }
                dtReturn = ClsDefination.FillData("[YarnOutward_DML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 101)
                    {
                        dgvDesign.DataSource = dtReturn;
                        bsOriginal.DataSource = dtReturn;

                        dgvDesign.Columns[10].Visible = false;

                        for (int i = 14; i < 46; i++)
                        {
                            dgvDesign.Columns[i].Visible = false;
                        }


                    }

                }
                else
                {
                    if (QueryNo == 101)
                    {
                        dgvDesign.DataSource = dtReturn;
                        
                        for (int i = 14; i < 46; i++)
                        {
                            dgvDesign.Columns[i].Visible = false;
                        }
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

                if (QueryNo == 3)
                {
                    hash.Add("@strUniqueCode",dgvDesign.CurrentRow.Cells[0].Value.ToString());
                    hash.Add("@intCode", Convert.ToInt32(dgvDesign.CurrentRow.Cells[1].Value.ToString()));
                }

                okflag = 1;
                return ClsDefination.InsertExecute(hash, "[YarnOutward_DML]", ref strReturnMSG, ref strReturnNo, ref intReturnNo);
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


        private void Dashboard_SizingOutward_Load(object sender, EventArgs e)
        {
            FillGrid(101);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDesign.SelectedRows.Count > 0)
                {
                   // Sizing.SizingInward frm = new Sizing.SizingInward();
                    Yarn.YarnOutward_ToSizing frm = new Yarn.YarnOutward_ToSizing();
                    frm.newOrEdit = 1;

                    frm.lblUniqueCode.Text = dgvDesign.CurrentRow.Cells[0].Value.ToString();
                    frm.lblSrNo.Text = dgvDesign.CurrentRow.Cells[1].Value.ToString();
                    frm.txtInvoiceNo.Text = dgvDesign.CurrentRow.Cells[2].Value.ToString();
                    frm.dtpInvoiceDate.Text = dgvDesign.CurrentRow.Cells[3].Value.ToString();
                    frm.cmbShade.Text = dgvDesign.CurrentRow.Cells[4].Value.ToString();

                    //MP.P_CompanyName as [COMPANY NAME], 5
                    frm.cmbPartyName.Text = dgvDesign.CurrentRow.Cells[5].Value.ToString();
                    //YON.contractNoValue as [CONTRACT NO], 6
                    frm.cmbContract.Text = dgvDesign.CurrentRow.Cells[6].Value.ToString();
                    //MS.S_Name as [SUT NAME], 7
                    frm.cmbSutType.Text = dgvDesign.CurrentRow.Cells[7].Value.ToString();
                    //CVN.Common_Value as [SUT USE],YOD.YO_Count as [COUNT], YOD.YO_Color as [COLOR], 10

                    frm.cmbWarfWeft.Text = dgvDesign.CurrentRow.Cells[8].Value.ToString();
                    frm.cmbCount.Text = dgvDesign.CurrentRow.Cells[9].Value.ToString();
                    frm.count = dgvDesign.CurrentRow.Cells[9].Value.ToString();
                    frm.cmbColor.Text = dgvDesign.CurrentRow.Cells[10].Value.ToString();
                    frm.color = dgvDesign.CurrentRow.Cells[10].Value.ToString();
                    //YOD.YO_TotMixBag as [TOTAL BAG],YOD.YO_TotMixKon as [TOTAL KON],YOD.YO_TotMixWeight as [TOTAL WEIGHT], 13

                    frm.lblMixBag.Text = dgvDesign.CurrentRow.Cells[11].Value.ToString();
                    frm.lblMixKon.Text = dgvDesign.CurrentRow.Cells[12].Value.ToString();
                    frm.lblMixWeight.Text = dgvDesign.CurrentRow.Cells[13].Value.ToString();
                    //YON.YO_OwnerName as [OWNER], 14
                    frm.lblOwner.Text = dgvDesign.CurrentRow.Cells[14].Value.ToString();
                    //YOD.YO_TotalBag as [FRESH BAG],YOD.YO_TotalKon as [FRESH KON],YOD.YO_TotalWeight as [FRESH WEIGHT], 17
                    frm.lblTotalBagQty.Text = dgvDesign.CurrentRow.Cells[15].Value.ToString();
                    frm.lblTotalKOn.Text = dgvDesign.CurrentRow.Cells[16].Value.ToString();
                    frm.lblTotalWeight.Text = dgvDesign.CurrentRow.Cells[17].Value.ToString();

                    //YOD.YO_WindingTotBag as [WINDING BAG],YOD.YO_WindingTotKon as [WINDING KON],YOD.YO_WindingTotWeight as [WINDING WEIGHT], 20
                    frm.lblTotBagW.Text = dgvDesign.CurrentRow.Cells[18].Value.ToString();
                    frm.lblTotKonW.Text = dgvDesign.CurrentRow.Cells[19].Value.ToString();
                    frm.lblTotWeightW.Text = dgvDesign.CurrentRow.Cells[20].Value.ToString();
                    //YON.YO_ToParty,YON.YO_State,YOD.YO_SutType, 23
                    frm.cmbPartyV = Convert.ToInt32(dgvDesign.CurrentRow.Cells[21].Value.ToString());
                    frm.lblStateCode.Text = dgvDesign.CurrentRow.Cells[22].Value.ToString();
                    frm.cmbSutTypeV = Convert.ToInt32(dgvDesign.CurrentRow.Cells[23].Value.ToString());
                    frm.lblSutTypeV.Text = dgvDesign.CurrentRow.Cells[23].Value.ToString();
                    //YOD.YO_SutUse,YOD.YO_GodawonBag, YOD.YO_KarkahanBag, 26
                    frm.lblWarfWeftV.Text = dgvDesign.CurrentRow.Cells[24].Value.ToString();
                    frm.txtGodBagF.Text = dgvDesign.CurrentRow.Cells[25].Value.ToString();
                    frm.txtKarBagF.Text = dgvDesign.CurrentRow.Cells[26].Value.ToString();

                    //YOD.YO_GodawonKon, YOD.YO_KarkhanaKon,YOD.YO_GodawonWeight,29

                    frm.txtGodawonKonF.Text = dgvDesign.CurrentRow.Cells[27].Value.ToString();
                    frm.txtKarkhanaKonF.Text = dgvDesign.CurrentRow.Cells[28].Value.ToString();
                    frm.txtGodawonWeightF.Text = dgvDesign.CurrentRow.Cells[29].Value.ToString();
                    // YOD.YO_KarkahanWeight,YOD.YO_WidingBag,YOD.YO_WindingBagK,  32

                    frm.txtKarkahanWeightF.Text = dgvDesign.CurrentRow.Cells[30].Value.ToString();
                    frm.txtWindingBagGod.Text = dgvDesign.CurrentRow.Cells[31].Value.ToString();
                    frm.txtWindingBagK.Text = dgvDesign.CurrentRow.Cells[32].Value.ToString();
                    //YOD.YO_WidingKon,YOD.YO_WindingKonK,YOD.YO_WindingWeight, 35

                    frm.txtWindingKonGod.Text = dgvDesign.CurrentRow.Cells[33].Value.ToString();
                    frm.txtWindingKonK.Text = dgvDesign.CurrentRow.Cells[34].Value.ToString();
                    frm.txtWindingWeightGod.Text = dgvDesign.CurrentRow.Cells[35].Value.ToString();
                    //YOD.YO_WindingWeightK,YON.Shade,YOD.YO_PkgType,YON.contractNo,YON.Quality 40

                    frm.txtWindingWeightK.Text = dgvDesign.CurrentRow.Cells[36].Value.ToString();
                    frm.cmbSV = Convert.ToInt32(dgvDesign.CurrentRow.Cells[37].Value.ToString());
                    frm.cmbPkgV = Convert.ToInt32(dgvDesign.CurrentRow.Cells[38].Value.ToString());
                    frm.cmbContractV = Convert.ToInt32(dgvDesign.CurrentRow.Cells[39].Value.ToString());
                    frm.cmbQualityV = Convert.ToInt32(dgvDesign.CurrentRow.Cells[40].Value.ToString());
                    frm.txtTara.Text = dgvDesign.CurrentRow.Cells[41].Value.ToString();
                    frm.txtPart.Text = dgvDesign.CurrentRow.Cells[42].Value.ToString();
                    frm.txtMeasure.Text = dgvDesign.CurrentRow.Cells[43].Value.ToString();
                    frm.txtMillName.Text = dgvDesign.CurrentRow.Cells[44].Value.ToString();
                    frm.txtLotNo.Text = dgvDesign.CurrentRow.Cells[45].Value.ToString();
                    // frm.lblQuality.Text = dgvDesign.CurrentRow.Cells[46].Value.ToString();

                    frm.cmbMIllName.Text= dgvDesign.CurrentRow.Cells[44].Value.ToString();
                    //YON.UniqueCode as [UNIQUE CODE],YON.YO_Code as [CODE], YON.YO_GetpassNo as [GETPASS], YON.YO_Date as [DATE],LM.L_ShadeName+' - '+LM.L_ShadeLocation as [SHADE], 
                    //MP.P_CompanyName as [COMPANY NAME],
                    //YON.contractNoValue as [CONTRACT NO],
                    //MS.S_Name as [YARN NAME],
                    //CVN.Common_Value as [SUT USE],YOD.YO_Count as [COUNT], YOD.YO_Color as [COLOR],
                    //YOD.YO_TotMixBag as [TOTAL BAG],YOD.YO_TotMixKon as [TOTAL KON],YOD.YO_TotMixWeight as [TOTAL WEIGHT],
                    //YON.YO_OwnerName as [OWNER],
                    //YOD.YO_TotalBag as [FRESH BAG],YOD.YO_TotalKon as [FRESH KON],YOD.YO_TotalWeight as [FRESH WEIGHT],
                    //YOD.YO_WindingTotBag as [WINDING BAG],YOD.YO_WindingTotKon as [WINDING KON],YOD.YO_WindingTotWeight as [WINDING WEIGHT], 20
                    //YON.YO_ToParty,YON.YO_State,YOD.YO_SutType,
                    //YOD.YO_SutUse,YOD.YO_GodawonBag, YOD.YO_KarkahanBag,
                    //YOD.YO_GodawonKon, YOD.YO_KarkhanaKon,YOD.YO_GodawonWeight,
                    // YOD.YO_KarkahanWeight,YOD.YO_WidingBag,YOD.YO_WindingBagK,  
                    //YOD.YO_WidingKon,YOD.YO_WindingKonK,YOD.YO_WindingWeight,
                    //YOD.YO_WindingWeightK,YON.Shade,YOD.YO_PkgType,YON.contractNo,YON.Quality,YON.tara,
                    //YON.part,YON.measure,YON.MillName,YON.LotNo
                    
                    frm.ShowDialog();
                    FillGrid(101);
                }
                else
                {
                    messageBox frm = new messageBox();
                    frm.messageTxt = "Please select row first";
                    frm.type = "error";
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
            }

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Yarn.YarnOutward_ToSizing frm = new Yarn.YarnOutward_ToSizing();
            frm.newOrEdit = 0;
            frm.ShowDialog();
            FillGrid(101);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvDesign.DataSource = bsOriginal;
                bs.DataSource = dgvDesign.DataSource;
                bs.Filter = string.Format("[NAME] like '%{0}%'", txtSearch.Text);
                dgvDesign.DataSource = bs;
                dgvDesign.Enabled = true;
                // btnClose.Enabled = true;
            }
            catch
            { }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDesign.SelectedRows.Count > 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the record?", "Delete record", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        SaveData(3, ref strReturnMSG, ref strReturnRefNo, ref intReturnPKNo);

                        if (okflag == 1)
                        {
                            if (intReturnPKNo == 0)
                            {
                                messageBox frm = new messageBox();
                                frm.messageTxt = strReturnMSG;
                                frm.type = "error";
                                frm.ShowDialog();
                            }
                            else
                            {
                                messageBox frm = new messageBox();
                                frm.messageTxt = "Rocord Deleted Successfully: ";// +strReturnMSG;
                                frm.type = "success";
                                frm.ShowDialog();
                                FillGrid(101);
                            }
                        }
                    }
                }
                else
                {
                    messageBox frm = new messageBox();
                    frm.messageTxt = "Please select record to delete";
                    frm.type = "error";
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Something went wrong please try again or call Administrator";
                frm.type = "error";
                frm.ShowDialog();
            }
        }
    }
}
