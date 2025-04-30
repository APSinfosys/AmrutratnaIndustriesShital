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
    public partial class Dashboard_KharadInward : Form
    {
        public Dashboard_KharadInward()
        {
            InitializeComponent();
        }

        #region variables
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        BindingSource bs = new BindingSource();
        BindingSource bsOriginal = new BindingSource();
        BindingSource bs1 = new BindingSource();
        BindingSource bsOriginal1 = new BindingSource();
        public string UserName, yearString, companyNameStr, groupNmae, PeriodName;
        public int userId, compId, yearId, GroupId, otherPg, cmbValue, cmbTT;
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
                hash.Add("@intCompanyId", Convert.ToInt32(fd.CompId));
                hash.Add("@intYearId", Convert.ToInt32(fd.YearId));

                dtReturn = ClsDefination.FillData("[Sizing_KharadInward_DML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 101)
                    {
                        dgvDesign.DataSource = dtReturn;
                        bsOriginal.DataSource = dtReturn;
                        bsOriginal1.DataSource = dtReturn;
                        dgvDesign.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        for (int i = 0; i < 39; i++)
                        {
                            dgvDesign.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        }
                        for (int i = 8; i < 39; i++)
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

                        for (int i = 8; i < 39; i++)
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


        private void Dashboard_KharadInward_Load(object sender, EventArgs e)
        {
            FillGrid(101);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvDesign.SelectedRows.Count > 0)
            {
                Yarn.KharadInward frm = new Yarn.KharadInward();
                frm.newOrEdit = 1;

                frm.txtGetpass.Text = dgvDesign.CurrentRow.Cells[0].Value.ToString();
                frm.dtpInvoiceDate.Text = dgvDesign.CurrentRow.Cells[1].Value.ToString();
                frm.cmbFirm.Text = dgvDesign.CurrentRow.Cells[2].Value.ToString();

                //          SKI.GetpassNo as [GETPASS NO], SKI.date as [DATE] ,FM.F_CompanyName as [FIRM NAME], 2

                frm.cmbShade.Text = dgvDesign.CurrentRow.Cells[3].Value.ToString();
                frm.cmbPartyName.Text = dgvDesign.CurrentRow.Cells[4].Value.ToString();
                //LM.L_ShadeName as [SHADE NAME],MP.P_CompanyName as [PARTY NAME],  4
                
                frm.cmbGetpassNo.Text = dgvDesign.CurrentRow.Cells[5].Value.ToString();
                frm.lblNetWeight.Text = dgvDesign.CurrentRow.Cells[6].Value.ToString();
                frm.lblUsedWeight.Text = dgvDesign.CurrentRow.Cells[7].Value.ToString();
                //SKI.getPassToParty as [CONTRACT NO],SKI.totNetWeight as [NET WEIGHT], SKI.totUsedWeight as [USED WEIGHT],  7
                
                frm.cmbFirmV = Convert.ToInt32(dgvDesign.CurrentRow.Cells[8].Value.ToString());
                frm.cmbShadeV = Convert.ToInt32(dgvDesign.CurrentRow.Cells[9].Value.ToString());
                //SKI.firmCode, SKI.shadeCode, 9

                frm.cmbGetpassV = Convert.ToInt32(dgvDesign.CurrentRow.Cells[10].Value.ToString());
                frm.cmbQualityV = Convert.ToInt32(dgvDesign.CurrentRow.Cells[11].Value.ToString());
                //SKI.getPassCode, SKI.qualityCode, 11 

                frm.txtTotBag.Text = dgvDesign.CurrentRow.Cells[12].Value.ToString();
                frm.txtBagWeight.Text = dgvDesign.CurrentRow.Cells[13].Value.ToString();
                frm.txtTotKon.Text = dgvDesign.CurrentRow.Cells[14].Value.ToString();
                frm.txtKonWeight.Text = dgvDesign.CurrentRow.Cells[15].Value.ToString();
                frm.lblEmptyBagWeight.Text = dgvDesign.CurrentRow.Cells[16].Value.ToString();
                //SKI.totEmptyBag, SKI.EmptyBagWeight, SKI.totEmptyKon, SKI.EmptyKonWeight, SKI.totEmptyBagWeight,  16

                frm.lblEmptyKonWeight.Text = dgvDesign.CurrentRow.Cells[17].Value.ToString();
                frm.lblUniqueCode.Text = dgvDesign.CurrentRow.Cells[18].Value.ToString();
                frm.lblSrNo.Text = dgvDesign.CurrentRow.Cells[19].Value.ToString();
                frm.cmbPartyV = Convert.ToInt32(dgvDesign.CurrentRow.Cells[20].Value.ToString());
                //SKI.totEmptyKonWeight,  SKI.uniqueCode, SKI.Code, SKI.party, 20

                frm.lblYarnCode.Text = dgvDesign.CurrentRow.Cells[21].Value.ToString();
                frm.lblWarfWeftCode.Text = dgvDesign.CurrentRow.Cells[22].Value.ToString();
                frm.lblCount.Text = dgvDesign.CurrentRow.Cells[23].Value.ToString();
                frm.lblColor.Text = dgvDesign.CurrentRow.Cells[24].Value.ToString();
                frm.txtKharadBag.Text = dgvDesign.CurrentRow.Cells[25].Value.ToString();
                frm.txtKharadKon.Text = dgvDesign.CurrentRow.Cells[26].Value.ToString();
                frm.txtKharadWeight.Text = dgvDesign.CurrentRow.Cells[27].Value.ToString();
                //SKID.sutCode,SKID.sutUse,SKID.count,SKID.color,SKID.bag,SKID.kon,SKID.weight, 27

                frm.txtFreshBag.Text = dgvDesign.CurrentRow.Cells[28].Value.ToString();
                frm.txtFreshKon.Text = dgvDesign.CurrentRow.Cells[29].Value.ToString();
                frm.txtFreshWeight.Text = dgvDesign.CurrentRow.Cells[30].Value.ToString();
                //SKID.bagF,SKID.konF,SKID.decimalF, 30

                frm.txtLotNo.Text = dgvDesign.CurrentRow.Cells[31].Value.ToString();
              
                frm.txtMillName.Text = dgvDesign.CurrentRow.Cells[32].Value.ToString();
                frm.txtMeasure.Text = dgvDesign.CurrentRow.Cells[33].Value.ToString();
                frm.txtPart.Text = dgvDesign.CurrentRow.Cells[34].Value.ToString();
                frm.txtTara.Text = dgvDesign.CurrentRow.Cells[35].Value.ToString();
                //YON.LotNo,YON.MillName,YON.measure,YON.part,YON.tara, 35

                frm.lblMixBag.Text= frm.txtBag.Text = dgvDesign.CurrentRow.Cells[36].Value.ToString();
                frm.lblMixKon.Text= frm.txtKon.Text = dgvDesign.CurrentRow.Cells[37].Value.ToString();
                frm.lblMixWeight.Text= frm.txtGrossWeight.Text = dgvDesign.CurrentRow.Cells[38].Value.ToString();
                //YOD.YO_TotMixBag,YOD.YO_TotMixKon,YOD.YO_TotMixWeight 38

                frm.ShowDialog();
                FillGrid(101);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Yarn.KharadInward frm = new Yarn.KharadInward();
            frm.newOrEdit = 0;
            frm.ShowDialog();
            FillGrid(101);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvDesign.SelectedRows.Count > 0)
            {
                Yarn.WindingOutward frm = new Yarn.WindingOutward();
                frm.newOrEdit = 0;
                frm.isFromKharad = 1;

                frm.kharadGetpass = dgvDesign.CurrentRow.Cells[18].Value.ToString();
                frm.cmbFirm.Text = dgvDesign.CurrentRow.Cells[2].Value.ToString();
                frm.cmbShade.Text = dgvDesign.CurrentRow.Cells[3].Value.ToString();
                frm.cmbPartyName.Text = dgvDesign.CurrentRow.Cells[4].Value.ToString();
                frm.cmbContract.Text = dgvDesign.CurrentRow.Cells[39].Value.ToString();
              //  SKI.GetpassNo as [GETPASS NO], SKI.date as [DATE] ,FM.F_CompanyName as [FIRM NAME], 2
              //LM.L_ShadeName as [SHADE NAME],MP.P_CompanyName as [PARTY NAME], 4

              //SKI.getPassToParty as [CONTRACT NO],SKI.totNetWeight as [NET WEIGHT], SKI.totUsedWeight as [USED WEIGHT],  7
                frm.cmbFV = Convert.ToInt32(dgvDesign.CurrentRow.Cells[8].Value.ToString());
                frm.cmbSV=Convert.ToInt32(dgvDesign.CurrentRow.Cells[9].Value.ToString());
              //SKI.firmCode, SKI.shadeCode,  9
                
                frm.cmbQV = Convert.ToInt32(dgvDesign.CurrentRow.Cells[11].Value.ToString());
              //SKI.getPassCode, SKI.qualityCode, 11 

              //SKI.totEmptyBag, SKI.EmptyBagWeight, SKI.totEmptyKon, SKI.EmptyKonWeight, SKI.totEmptyBagWeight,  16

                frm.cmbPNV = Convert.ToInt32(dgvDesign.CurrentRow.Cells[20].Value.ToString());
              //SKI.totEmptyKonWeight,  SKI.uniqueCode, SKI.Code, SKI.party, 20
                frm.cmbSTV = Convert.ToInt32(dgvDesign.CurrentRow.Cells[21].Value.ToString());
                frm.cmbSUV = Convert.ToInt32(dgvDesign.CurrentRow.Cells[22].Value.ToString());
                frm.cmbCount.Text = dgvDesign.CurrentRow.Cells[23].Value.ToString();
                frm.countV = Convert.ToDecimal(dgvDesign.CurrentRow.Cells[23].Value.ToString());
              frm.color= frm.cmbColor.Text = dgvDesign.CurrentRow.Cells[24].Value.ToString();
              

              frm.lblTotalBag.Text=  frm.txtKarkhanaBag.Text = dgvDesign.CurrentRow.Cells[25].Value.ToString();
               frm.lblTotalKon.Text=  frm.txtKarkhanaKon.Text = dgvDesign.CurrentRow.Cells[26].Value.ToString();
               frm.lblTotalWeight.Text= frm.txtKarkhanaNWeight.Text = dgvDesign.CurrentRow.Cells[27].Value.ToString();
              //SKID.sutCode,SKID.sutUse,SKID.count,SKID.color,SKID.bag,SKID.kon,SKID.weight, 27
              //SKID.bagF,SKID.konF,SKID.decimalF, 30
                frm.txtLotNo.Text = dgvDesign.CurrentRow.Cells[31].Value.ToString();
                frm.cmbMillName.Text = dgvDesign.CurrentRow.Cells[32].Value.ToString();
              //YON.LotNo,YON.MillName,YON.measure,YON.part,YON.tara, 35
              //YOD.YO_TotMixBag,YOD.YO_TotMixKon,YOD.YO_TotMixWeight 38
                frm.cmbContractValue = Convert.ToInt32(dgvDesign.CurrentRow.Cells[40].Value.ToString());
               // SKI.ContractName,SKI.ContractCode 40

                frm.ShowDialog();
                FillGrid(101);
            }
        }
    }
}
