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
    public partial class Dashboard_BeamOutward : Form
    {
        public Dashboard_BeamOutward()
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

                dtReturn = ClsDefination.FillData("[Transaction_BeamOutward_DML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 101)
                    {
                        dgvDesign.DataSource = dtReturn;
                        bsOriginal.DataSource = dtReturn;
                        //23 26

                        //             BI.B_Code as [ CODE ], BI.B_SatNo as [ SAT NO ], BI.B_InvoiceNo as [ INVOICE NO ], BI.B_Date as [ DATE ], 0 1 2 3 
                        //MP.P_CompanyName+' - '+MP.P_OwnerName as [ PARTY NAME ], BI.B_SizingName as [ SIZING ],  4 5
                        //BI.B_Count as [ COUNT ], BI.B_YarnSource as [ YARN SOURCE ], BI.B_Warf as [ WARF ], BI.B_Weft as [ WEFT ], 6 7 8 9
                        //BI.B_Reed as [ REED ], BI.B_Pick as [ PICK ], 10 11 
                        //BI.B_Weave as [ WEAVE ], BI.B_CreelEnds as [ CREEL END ], BI.B_FunctionPart as [ FUNCTION / PART],  12 13 14
                        //BI.B_TotalEnds as [ TOTAL ENDS ],BI.B_Length as [ LENGTH ], BI.B_CutMark as [ CUT MARK ],  15 16 17
                        //BI.B_Dbf as [ DBF ], BI.B_RatePerPick as [ RATE ],QR.Q_Name as [ QUALITY ],  18 19 20
                        //LM.L_ShadeName+' - '+LM.L_ShadeLocation as [ SHADE ],BM.BR_Name as [ BROKER ],BI.Shade, 21 22 23 
                        //BI.brocker,BI.B_Party,BI.Quality, 24 25 26
                        //BI.UniqueCode 27

                        dgvDesign.Columns[27].DisplayIndex = 0;

                        for (int i = 0; i < 27; i++)
                        {
                            dgvDesign.Columns[i].DisplayIndex = i + 1;
                        }

                        dgvDesign.Columns[23].Visible = false;
                        dgvDesign.Columns[24].Visible = false;
                        dgvDesign.Columns[25].Visible = false;
                        dgvDesign.Columns[26].Visible = false;

                    }

                }
                else
                {
                    if (QueryNo == 101)
                    {
                        dgvDesign.DataSource = dtReturn;
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
            Sizing.BeamOutward frm = new Sizing.BeamOutward();
            frm.newOrEdit = 0;
            frm.ShowDialog();
            FillGrid(101);

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

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

        private void Dashboard_BeamOutward_Load(object sender, EventArgs e)
        {
            FillGrid(101);
        }
    }
}
