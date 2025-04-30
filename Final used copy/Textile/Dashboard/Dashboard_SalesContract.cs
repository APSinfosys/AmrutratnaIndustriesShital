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
    public partial class Dashboard_SalesContract : Form
    {
        public Dashboard_SalesContract()
        {
            InitializeComponent();
        }

        #region variables
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        public string UserName, yearString, companyNameStr, groupNmae, PeriodName;
        public int cmbBT;
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



                dtReturn = ClsDefination.FillData("[Master_SalesContract_DML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 101)
                    {
                        dgvAcc.DataSource = dtReturn;

                        for (int i = 20; i < 24; i++)
                        {
                            dgvAcc.Columns[i].Visible = false;
                        }
                    }

                }
                else
                {
                    if (QueryNo == 101)
                    {
                        dgvAcc.DataSource = dtReturn;

                        for (int i = 20; i < 24; i++)
                        {
                            dgvAcc.Columns[i].Visible = false;
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



        private void btnNew_Click(object sender, EventArgs e)
        {
            ContractForm.Transaction_SalesContract frm = new ContractForm.Transaction_SalesContract();
            frm.newOrEdit = 0;
            frm.ShowDialog();
            FillGrid(101);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvAcc.SelectedRows.Count > 0)
            {

                ContractForm.Transaction_SalesContract frm = new ContractForm.Transaction_SalesContract();
                frm.newOrEdit = 1;

                frm.lblUniqueCode.Text = dgvAcc.CurrentRow.Cells[0].Value.ToString();
                frm.txtContractNo.Text = dgvAcc.CurrentRow.Cells[1].Value.ToString();
                frm.dtpDate.Text = dgvAcc.CurrentRow.Cells[2].Value.ToString();
                //                      MSC.uniqueCode as [UNIQUE CODE], MSC.contractNo as [CONTRACT NO], MSC.date as [DATE], 
                //  --FM.F_CompanyName as [FIRM NAME],

                frm.cmbParty.Text = dgvAcc.CurrentRow.Cells[3].Value.ToString();
                frm.cmbBroker.Text = dgvAcc.CurrentRow.Cells[4].Value.ToString();
                //  MP.P_CompanyName as [PARTY NAME],BM.BR_Name as [BROKER NAME],

                frm.cmbQuality.Text = dgvAcc.CurrentRow.Cells[5].Value.ToString();
                frm.txtPhani.Text = dgvAcc.CurrentRow.Cells[6].Value.ToString();
                //  QR.Q_Name as [QUALITY NAME],MSC.phani as [PHANI],


                frm.txtPick.Text = dgvAcc.CurrentRow.Cells[7].Value.ToString();
                frm.txtPannha.Text = dgvAcc.CurrentRow.Cells[8].Value.ToString();
                //  MSC.pick as [PICK], MSC.pannha as [PANNHA],

                frm.txtTage.Text = dgvAcc.CurrentRow.Cells[9].Value.ToString();
                frm.txtWeight.Text = dgvAcc.CurrentRow.Cells[10].Value.ToString();
                frm.txtCuts.Text = dgvAcc.CurrentRow.Cells[11].Value.ToString();
                //  MSC.tage as [TAGE], MSC.weight as [WEIGHT],MSC.cuts as [CUTS],
                //--  MJC.meter as [METER],MJC.beam as [BEAMS],MJC.totalLoom as [LOOM],

                frm.txtRate.Text = dgvAcc.CurrentRow.Cells[12].Value.ToString();
                frm.txtGST.Text = dgvAcc.CurrentRow.Cells[13].Value.ToString();
                frm.txtRateWithGST.Text = dgvAcc.CurrentRow.Cells[14].Value.ToString();

                //  MSC.rate as [RATE], MSC.gst as [GST %],MSC.rateWithGst as [RATE WITH GST],
                frm.dtpDeliveryPeriod.Text = dgvAcc.CurrentRow.Cells[15].Value.ToString();
                //  MSC.deliveryPeriod as [DELIVERY PERIOD], 

                frm.txtPaymentDate.Text = dgvAcc.CurrentRow.Cells[16].Value.ToString();
               //  MSC.paymentDay as [PAYMENT DAYS],

                frm.txtWarf.Text = dgvAcc.CurrentRow.Cells[17].Value.ToString();
                frm.txtWeft.Text = dgvAcc.CurrentRow.Cells[18].Value.ToString();
                frm.txtBrokrage.Text = dgvAcc.CurrentRow.Cells[19].Value.ToString();

                //  MSC.warf as [WARF], MSC.weft as [WEFT], MSC.brokrage as [BROKRAGE],
                frm.cmbPartyC = Convert.ToInt32( dgvAcc.CurrentRow.Cells[20].Value.ToString());
                frm.cmbBrokerC = Convert.ToInt32(dgvAcc.CurrentRow.Cells[21].Value.ToString());
                frm.cmbQualityC = Convert.ToInt32(dgvAcc.CurrentRow.Cells[22].Value.ToString());


                //  MSC.partyCode, MSC.brokerCode, MSC.qualityCode

                frm.txtMeters.Text = dgvAcc.CurrentRow.Cells[23].Value.ToString();
                frm.ShowDialog();
                FillGrid(101);
            }
        }

        private void Dashboard_SalesContract_Load(object sender, EventArgs e)
        {
            FillGrid(101);
        }
    }
}
