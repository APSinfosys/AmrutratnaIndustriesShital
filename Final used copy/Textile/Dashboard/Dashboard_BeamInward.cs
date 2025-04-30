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
    public partial class Dashboard_BeamInward : Form
    {
        public Dashboard_BeamInward()
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

                dtReturn = ClsDefination.FillData("[Transaction_BeamInward_DML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 101)
                    {
                        dgvDesign.DataSource = dtReturn;
                        bsOriginal.DataSource = dtReturn;

                        gridValidations(); 

                    }

                }
                else 
                {
                    if (QueryNo == 101)
                    {
                        dgvDesign.DataSource = dtReturn;
                        gridValidations();
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


        public void gridValidations()
        {
            for (int i = 0; i <= 30; i++)
            {
                dgvDesign.Columns[i].Visible = false;
            }

            //27 0 3 1 20 21 22


            dgvDesign.Columns[27].Visible = dgvDesign.Columns[0].Visible = dgvDesign.Columns[3].Visible = dgvDesign.Columns[1].Visible = dgvDesign.Columns[20].Visible =
            dgvDesign.Columns[21].Visible = dgvDesign.Columns[22].Visible = true;

            dgvDesign.Columns[27].DisplayIndex = 0; dgvDesign.Columns[0].DisplayIndex = 1;
            dgvDesign.Columns[3].DisplayIndex = 2; dgvDesign.Columns[1].DisplayIndex = 3; dgvDesign.Columns[20].DisplayIndex = 4;
            dgvDesign.Columns[21].DisplayIndex = 5; dgvDesign.Columns[22].DisplayIndex = 6;

        }


        private void Dashboard_BeamInward_Load(object sender, EventArgs e)
        {
            FillGrid(101);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Sizing.BeamInward frm = new Sizing.BeamInward();
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
                bs.Filter = string.Format("[ QUALITY ] like '%{0}%'", txtSearch.Text);
                dgvDesign.DataSource = bs;
                dgvDesign.Enabled = true;
                // btnClose.Enabled = true;
            }
            catch
            { }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDesign.SelectedRows.Count > 0)
                {

                    Sizing.BeamInward frm = new Sizing.BeamInward();
                    frm.newOrEdit = 1;

                    frm.lblSrNo.Text = dgvDesign.CurrentRow.Cells[0].Value.ToString();
                    frm.txtSatNo.Text = dgvDesign.CurrentRow.Cells[1].Value.ToString();
                    frm.txtInvoiceNo.Text = dgvDesign.CurrentRow.Cells[2].Value.ToString();
                    frm.dtpInvoiceDate.Text = dgvDesign.CurrentRow.Cells[3].Value.ToString();

                    //         BI.B_Code as [ CODE ], BI.B_SatNo as [ SAT NO ], BI.B_InvoiceNo as [ INVOICE NO ], BI.B_Date as [ DATE ], 


                    frm.cmbPartyName.Text = dgvDesign.CurrentRow.Cells[4].Value.ToString();
                    frm.cmbSizingName.Text = dgvDesign.CurrentRow.Cells[5].Value.ToString();
                    frm.txtSizingName.Text = dgvDesign.CurrentRow.Cells[5].Value.ToString();
                    //MP.P_CompanyName+' - '+MP.P_OwnerName as [ PARTY NAME ], BI.B_SizingName as [ SIZING ], 

                    frm.txtCount.Text = dgvDesign.CurrentRow.Cells[6].Value.ToString();
                    frm.txtYarnSource.Text = dgvDesign.CurrentRow.Cells[7].Value.ToString();
                    frm.txtWarp.Text = dgvDesign.CurrentRow.Cells[8].Value.ToString();
                    frm.txtWeft.Text = dgvDesign.CurrentRow.Cells[9].Value.ToString();
                    //BI.B_Count as [ COUNT ], BI.B_YarnSource as [ YARN SOURCE ], BI.B_Warf as [ WARF ], BI.B_Weft as [ WEFT ], 

                    frm.txtReed.Text = dgvDesign.CurrentRow.Cells[10].Value.ToString();
                    frm.txtPick.Text = dgvDesign.CurrentRow.Cells[11].Value.ToString();
                    //BI.B_Reed as [ REED ], BI.B_Pick as [ PICK ], 

                    frm.txtWeave.Text = dgvDesign.CurrentRow.Cells[12].Value.ToString();
                    frm.txtCreelEnds.Text = dgvDesign.CurrentRow.Cells[13].Value.ToString();
                    frm.txtFunctionPart.Text = dgvDesign.CurrentRow.Cells[14].Value.ToString();
                    //BI.B_Weave as [ WEAVE ], BI.B_CreelEnds as [ CREEL END ], BI.B_FunctionPart as [ FUNCTION / PART],

                    frm.txtTotalEnds.Text = dgvDesign.CurrentRow.Cells[15].Value.ToString();
                    frm.txtLength.Text = dgvDesign.CurrentRow.Cells[16].Value.ToString();
                    frm.txtCutMark.Text = dgvDesign.CurrentRow.Cells[17].Value.ToString();
                    //BI.B_TotalEnds as [ TOTAL ENDS ],BI.B_Length as [ LENGTH ], BI.B_CutMark as [ CUT MARK ], 

                    frm.txtDBF.Text = dgvDesign.CurrentRow.Cells[18].Value.ToString();
                    frm.txtRatePerPick.Text = dgvDesign.CurrentRow.Cells[19].Value.ToString();
                    frm.lblQuality.Text = dgvDesign.CurrentRow.Cells[20].Value.ToString();
                    //BI.B_Dbf as [ DBF ], BI.B_RatePerPick as [ RATE ],QR.Q_Name as [ QUALITY ], 

                    frm.cmbShade.Text = dgvDesign.CurrentRow.Cells[21].Value.ToString();
                    frm.cmbBroker.Text = dgvDesign.CurrentRow.Cells[22].Value.ToString();

                    frm.cmbSV = Convert.ToInt32(dgvDesign.CurrentRow.Cells[23].Value.ToString());
                    frm.cmbBV = Convert.ToInt32(dgvDesign.CurrentRow.Cells[24].Value.ToString());
                    frm.cmbPV = Convert.ToInt32(dgvDesign.CurrentRow.Cells[25].Value.ToString());
                    frm.cmbQV = Convert.ToInt32(dgvDesign.CurrentRow.Cells[26].Value.ToString());
                    frm.lblUniqueCode.Text = dgvDesign.CurrentRow.Cells[27].Value.ToString();
                    //LM.L_ShadeName+' - '+LM.L_ShadeLocation as [ SHADE ],BM.BR_Name as [ BROKER ],BI.Shade, BI.brocker,BI.B_Party,BI.Quality

                    frm.cmbContract.Text = dgvDesign.CurrentRow.Cells[28].Value.ToString();
                    frm.cmbCV = Convert.ToInt32(dgvDesign.CurrentRow.Cells[29].Value.ToString());
                    frm.cmbSN = Convert.ToInt32(dgvDesign.CurrentRow.Cells[30].Value.ToString());
                    frm.ShowDialog();
                    FillGrid(101);
                }
                else
                {
                    messageBox frm = new messageBox();
                    frm.messageTxt = "Please Select Record To Edit";
                    frm.type = "error";
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Error while editing record";
                frm.type = "error";
                frm.ShowDialog();
            }
        }
    }
}
