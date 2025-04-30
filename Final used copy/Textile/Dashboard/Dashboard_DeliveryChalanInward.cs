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
    public partial class Dashboard_DeliveryChalanInward : Form
    {
        public Dashboard_DeliveryChalanInward()
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

                dtReturn = ClsDefination.FillData("[Transaction_DelevaryChalan_Inward_DML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 101)
                    {
                        dgvSut.DataSource = dtReturn;
                        bsOriginal.DataSource = dtReturn;
                        //14 15 16 17

                        // dgvSut.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        for (int i = 0; i < 12; i++)
                        {
                            dgvSut.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        }

                        //                  DCI.UniqueCode as [UNIQUE CODE],DCI.DCI_No as [CHALN NO], DCI.DCI_Date as [DATE],     3
                        //FM.F_CompanyName as [FIRM],LM.L_ShadeName as [SHADE],BM.BR_Name as [BROKER],MP.P_CompanyName as [PARTY], 7
                        //JC.contractName as [CONTRACT],QR.Q_Name as [QUALITY],                                                     9
                        //DCI.Pices as [PICES], DCI.Meter as [METERS],DCI.SamplePice as [SAMPLE/CUT],DCI.Bales as [BALES],        13
                        //DCI.FIrmName, DCI.BrokerName, DCI.PartyName,                                                             16
                        //DCI.Contract, DCI.Design, DCI.Shade,DCI.code                                                             20 

                        //for (int i = 0; i < dgvSut.Rows.Count; i++)
                        //{
                        //    if (dgvSut.Rows[i].Cells[16].Value.ToString() != "N/A")
                        //    {
                        //        dgvSut.Rows[i].DefaultCellStyle.BackColor = Color.DarkCyan;
                        //    }
                        //}


                        for (int i = 12; i < 20; i++)
                        {

                            dgvSut.Columns[i].Visible = false;
                        }
                        //dgvSut.Columns[12].Visible = false;
                        //dgvSut.Columns[13].Visible = false;
                        //dgvSut.Columns[14].Visible = false;
                        //dgvSut.Columns[15].Visible = false;
                        //dgvSut.Columns[16].Visible = false;
                    }

                }
                else
                {
                    if (QueryNo == 101)
                    {
                        dgvSut.DataSource = null;

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
            TransactionForms.DeliveryChalan_Inward frm = new TransactionForms.DeliveryChalan_Inward();
            frm.newOrEdit = 0;
            frm.ShowDialog();
        }

        private void Dashboard_DeliveryChalanInward_Load(object sender, EventArgs e)
        {
            FillGrid(101);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvSut.DataSource = bsOriginal;
                bs.DataSource = dgvSut.DataSource;
                bs.Filter = string.Format("[PARTY] like '%{0}%'", txtSearch.Text);
                dgvSut.DataSource = bs;
                dgvSut.Enabled = true;
                // btnClose.Enabled = true;
            }
            catch
            { }
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSut.SelectedRows.Count > 0)
                {
                    Textile.TransactionForms.Cloth_PurchaseInvoice frm = new TransactionForms.Cloth_PurchaseInvoice();
                    frm.newOrEdit = 0;
      //              DCI.UniqueCode as [UNIQUE CODE],DCI.DCI_No as [CHALN NO], DCI.DCI_Date as [DATE],
                    frm.lblUniqueCode.Text = dgvSut.CurrentRow.Cells[0].Value.ToString();
                    frm.txtDCNOValue.Text = dgvSut.CurrentRow.Cells[1].Value.ToString();
                    frm.lblDCDate.Text = dgvSut.CurrentRow.Cells[2].Value.ToString();
                    frm.dtpDcDate.Text = dgvSut.CurrentRow.Cells[2].Value.ToString();

      //FM.F_CompanyName as [FIRM],LM.L_ShadeName as [SHADE],BM.BR_Name as [BROKER],MP.P_CompanyName as [PARTY],
                    frm.lblOnFirmName.Text = dgvSut.CurrentRow.Cells[3].Value.ToString();
                    frm.lblShadeName.Text = dgvSut.CurrentRow.Cells[4].Value.ToString();
                    frm.lblBrokerName.Text = dgvSut.CurrentRow.Cells[5].Value.ToString();
                    frm.lblFromPartyName.Text = dgvSut.CurrentRow.Cells[6].Value.ToString();
      //cast( JC.contractNo as varchar(10)) +' - '+ QR.Q_Name as [CONTRACT],
                    frm.lblContractName.Text = dgvSut.CurrentRow.Cells[7].Value.ToString();
      //DCI.Pices as [PICES], DCI.Meter as [METERS],DCI.SamplePice as [SAMPLE/CUT],DCI.Bales as [BALES],
                    frm.txtPiecevalue.Text = dgvSut.CurrentRow.Cells[8].Value.ToString();
                    frm.txtTotalMtrs.Text = dgvSut.CurrentRow.Cells[9].Value.ToString();
                    frm.txtSampleCutMtr.Text = dgvSut.CurrentRow.Cells[10].Value.ToString();

      //DCI.FIrmName, DCI.BrokerName, DCI.PartyName,QR.Q_Name as [QUALITY],  
                    frm.lblOnFirmCode.Text = dgvSut.CurrentRow.Cells[12].Value.ToString();
                    frm.lblBrokerCode.Text = dgvSut.CurrentRow.Cells[13].Value.ToString();
                    frm.lblFromPartyCode.Text = dgvSut.CurrentRow.Cells[14].Value.ToString();
                    frm.lblQualityName.Text = dgvSut.CurrentRow.Cells[15].Value.ToString();
      //DCI.Contract, DCI.Design, DCI.Shade,DCI.code
                 //   frm.cmbContract.SelectedValue = Convert.ToInt32(dgvSut.CurrentRow.Cells[16].Value.ToString());
                    frm.lblContractCode.Text = dgvSut.CurrentRow.Cells[16].Value.ToString();
                    frm.lblQualityCode.Text = dgvSut.CurrentRow.Cells[17].Value.ToString();
                    frm.lblShadeCode.Text = dgvSut.CurrentRow.Cells[18].Value.ToString();
                    frm.ShowDialog();

                    FillGrid(101);
                }
                else
                {
                    messageBox frm = new messageBox();
                    frm.messageTxt = "Please select atleast one record";
                    frm.type = "error";
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
