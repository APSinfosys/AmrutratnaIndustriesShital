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
    public partial class Dashboard_JobContract : Form
    {
        public Dashboard_JobContract()
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

              

                dtReturn = ClsDefination.FillData("[Master_JobContract_DML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 101)
                    {
                        dgvAcc.DataSource = dtReturn;

                        for (int i = 20; i < 28; i++)
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

                        for (int i = 20; i < 28; i++)
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
                hash.Add("@intCompanyID", fd.CompId);
                hash.Add("@intYearId", fd.YearId);

                if (QueryNo == 6)
                {
                    hash.Add("@UniqueCode",dgvAcc.CurrentRow.Cells[0].Value.ToString());
                    hash.Add("@intContractNo", Convert.ToInt32(dgvAcc.CurrentRow.Cells[1].Value.ToString()));
                }

                okflag = 1;
                return ClsDefination.InsertExecute(hash, "[Master_JobContract_DML]", ref strReturnMSG, ref strReturnNo, ref intReturnNo);
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



        private void btnNew_Click(object sender, EventArgs e)
        {
            ContractForm.Transaction_JobContract frm = new ContractForm.Transaction_JobContract();
            frm.newOrEdit = 0;
            frm.isInward = 0;
            frm.ShowDialog();
            FillGrid(101);
        }

        private void Dashboard_JobContract_Load(object sender, EventArgs e)
        {
            FillGrid(101);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvAcc.SelectedRows.Count > 0)
            {
                ContractForm.Transaction_JobContract frm = new ContractForm.Transaction_JobContract();
                frm.newOrEdit = 1;
                frm.isInward = 0;

                //   MJC.UniqueCode as [UNIQUE CODE], MJC.contractNo as [CONTRACT NO], MJC.date as [DATE],     2
                frm.lblUniqueCode.Text = dgvAcc.CurrentRow.Cells[0].Value.ToString();
                frm.txtContractNo.Text = dgvAcc.CurrentRow.Cells[1].Value.ToString();
                frm.dtpDate.Text = dgvAcc.CurrentRow.Cells[2].Value.ToString();

                //FM.F_CompanyName as [FIRM NAME],MP.P_CompanyName as [PARTY NAME],BM.BR_Name as [BROKER NAME], 5
                //frm.cmbFirmName.Text = dgvAcc.CurrentRow.Cells[3].Value.ToString();
                frm.cmbParty.Text = dgvAcc.CurrentRow.Cells[3].Value.ToString();
                frm.cmbBroker.Text = dgvAcc.CurrentRow.Cells[4].Value.ToString();

                //QR.Q_Name as [QUALITY NAME],MJC.phani as [PHANI],  7
                frm.cmbQuality.Text = dgvAcc.CurrentRow.Cells[5].Value.ToString();
                frm.txtPhani.Text = dgvAcc.CurrentRow.Cells[6].Value.ToString();

                //MJC.pick as [PICK], MJC.pannha as [PANNHA], MJC.tage as [TAGE], MJC.cuts as [CUTS],  8 9 10 11

                //MJC.pick as [PICK], MJC.pannha as [PANNHA],    9
                frm.txtPick.Text = dgvAcc.CurrentRow.Cells[7].Value.ToString();
                frm.txtPannha.Text = dgvAcc.CurrentRow.Cells[8].Value.ToString();


                //MJC.meter as [METER],MJC.beam as [BEAMS],MJC.totalLoom as [LOOM],    12
                frm.txtMtr.Text = dgvAcc.CurrentRow.Cells[9].Value.ToString();
                frm.txtBeams.Text = dgvAcc.CurrentRow.Cells[10].Value.ToString();
                frm.txtLooms.Text = dgvAcc.CurrentRow.Cells[11].Value.ToString();

                //MJC.rate as [RATE], MJC.gst as [GST %],MJC.rateWithGst as [RATE WITH GST],  15
                frm.txtRate.Text = dgvAcc.CurrentRow.Cells[12].Value.ToString();
                frm.txtGST.Text = dgvAcc.CurrentRow.Cells[13].Value.ToString();
                frm.txtRateWithGST.Text = dgvAcc.CurrentRow.Cells[14].Value.ToString();

                //MJC.deliveryPeriod as [DELIVERY PERIOD],  16
                frm.dtpDeliveryPeriod.Text = dgvAcc.CurrentRow.Cells[15].Value.ToString();

                //MJC.paymentDays as [PAYMENT DAYS],  17
                frm.txtPaymentDate.Text = dgvAcc.CurrentRow.Cells[16].Value.ToString();

                //MJC.warf as [WARF], MJC.weft as [WEFT], MJC.brokrage as [BROKRAGE], 20
                frm.txtWarf.Text = dgvAcc.CurrentRow.Cells[17].Value.ToString();
                frm.txtWeft.Text = dgvAcc.CurrentRow.Cells[18].Value.ToString();
                frm.txtBrokrage.Text = dgvAcc.CurrentRow.Cells[19].Value.ToString();

                //MJC.firmCode, MJC.partyCode, MJC.brokerCode, MJC.qualityCode,  24
                frm.cmbFirmC = Convert.ToInt32(dgvAcc.CurrentRow.Cells[20].Value.ToString());
                frm.cmbPartyC = Convert.ToInt32(dgvAcc.CurrentRow.Cells[21].Value.ToString());
                frm.cmbBrokerC = Convert.ToInt32(dgvAcc.CurrentRow.Cells[22].Value.ToString());
                frm.cmbQualityC = Convert.ToInt32(dgvAcc.CurrentRow.Cells[23].Value.ToString());

                //MJC.tage as [TAGE], MJC.weight as [WEIGHT],MJC.cuts as [CUTS]  27

                frm.ShowDialog();
                FillGrid(101);

            }
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please Select Record to Edit";
                frm.type = "error";
                frm.ShowDialog();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAcc.SelectedRows.Count > 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the record?", "Delete record", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        SaveData(6, ref strReturnMSG, ref strReturnRefNo, ref intReturnPKNo);

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
