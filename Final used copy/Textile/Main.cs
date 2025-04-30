using Accounting.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Textile.Masters;

namespace Textile
{
    public partial class Main : Form
    {
        private int childFormNumber = 0;

        public Main()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        public void FillGrid1(int q)
        {
            string con1 = ClsDefination.strconnection;
            SqlConnection con = new SqlConnection(con1);

            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("[p_db_BackUp]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@QueryNo", q);
                cmd.Parameters.AddWithValue("@file", "");

                cmd.ExecuteNonQuery();

                MessageBox.Show("Data Backuped Successfully.");

            }


            catch (Exception)
            {
                MessageBox.Show("Error In Tacking Backup.");
                //return null;
                //throw;
            }
            finally
            {
                con.Close();
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        #region Variable Declaration
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        string User, Passward, userType;
        //int userId, AccType, compId;
        #endregion
        private void Main_Load(object sender, EventArgs e)
        {
            //label1.Text = fd.UserId.ToString();

            //label1.Text = fd.UserName.ToString();
            //label1.Text = fd.YearId.ToString();
            //label1.Text = fd.CompId.ToString();
            //label1.Text = fd.CompanyNameStr.ToString();
            //label1.Text = fd.LoginType;
            //label1.Text = fd.YearString;
            lblShortName.Text = "( "+fd.ShortYear+" )";
            lblCompanyName.Text = fd.CompanyNameStr;
            lblYear.Text = "( "+fd.YearString+" )";

           // lblBrand.Text = "Designed && Developed By: Bit's && Byte's Technology PVT. LTD";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard.Dashboard_PartyMaster frm = new Dashboard.Dashboard_PartyMaster();
            frm.Show();
        //    SupplierMaster SM = new SupplierMaster();
        //    SM.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dashboard.Dashboard_SutMaster frm = new Dashboard.Dashboard_SutMaster();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dashboard.Dashboard_ClothDesigh frm = new Dashboard.Dashboard_ClothDesigh();
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Yarn.YarnInward frm = new Yarn.YarnInward();
            frm.Show();
        }

        public void newForm(object form)
        {
            if (this.panelContainer.Controls.Count > 0)
                this.panelContainer.Controls.RemoveAt(0);

            Form frm = form as Form;
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            
            this.panelContainer.Controls.Add(frm);
            this.panelContainer.Tag = frm;
            frm.Show();
        }
        private void pARTYMASTERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
           // panel12.Visible = false;
        }

        private void pARTYMASTERToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_PartyMaster());
            //Textile.Dashboard.Dashboard_PartyMaster frm = new Dashboard.Dashboard_PartyMaster();
            //frm.Show();
        }

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void sUTMASTERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_SutMaster());
        }

        private void qUALITYMASTERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_ClothDesigh());
        }

        private void lOOMMASTERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_LoomMaster());
        }

        private void aCCOUNTMASTErToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Accounting.Dashbord_Forms.Dashboard_AccountMaster());
        }

        private void eMPLOYEEMASTERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_Employee());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            FillGrid1(101);
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnResore_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnResore.Visible = false;
            btnMaximize.Visible = true;
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximize.Visible = false;
            btnResore.Visible = true;
        }

        private void yARNINWARDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //newForm(new Textile.Dashboard.Dashboard_YarnInward());
        }

        private void yARNOUTWARDToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void wINDINGINWARDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_WindingInward());
        }

        private void wINDINGOUTWARDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_WindingOutward());
        }

        private void sIZINGINWARDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_SizingInward());
        }

        private void vIVINGLOADToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_Viving());
        }

        private void mAGPRODUCTIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_Production());
        }

        private void aUTOPRODUCTIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_AutoProduction());
        }

        private void sALARYDETAILSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_AutoMonthlySalary());
        }

        private void sALARYREPORTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_EmpSalReportAuto());
        }

        private void sALARYREPORTMAGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_EmployeeSalaryReport());
        }

        private void pURCHASEINVOICEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_PurchaseInvoice());
        }

        private void dELIVERYCHALANToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_DeliveryChalan());
        }

        private void cLOTHREPORTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_ClothReport());
        }

        private void gSTREPORTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_GSTReport());
        }

        private void sTOCKREPORTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_StockReport());
        }

        private void pARTYPAYMENTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_PartyPayments());
        }

        private void sALESRECEIPTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dasboard_SalesReceipt());
        }

        private void pARTYPAYMENTREGISTERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_PartyPayment_Register());
        }

        private void sALESRECEIPTREGISTERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_SalesReceipt_Register());
        }

        private void bROKERMASTERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_BrokerMaster());
        }

        private void fIRMMASTERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_FirmMaster());
        }

        private void oNLYINWARDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_YarnOnlyInward());
        }

        private void iNWARDWITHINVOICEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_YarnInward());
        }

        private void sIZINGToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // newForm(new Textile.Dashboard.Dashboard_SizingInward());
        }

        private void bEAMINWARDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_BeamInward());
        }

        private void wEAVINGLOADAUTOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_WeavingLoadAuto());
        }

        private void sALESINVOICEREGISTERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_SalesInvoice_Register());
        }

        private void yENEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_Outstanding_Yene());
        }

        private void dENEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_Outstanding_Dene());
        }

        private void bAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_BankBalance());
        }

        private void bANKTRANSACTIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_Bank_Transaction());
        }

        private void jOURNALVOUCHERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_JournalVoucher());
        }

        private void pURCHASEPAYMENTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_PartyPayments());
        }

        private void dELIVERYCHALANREGISTERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_DeliveryChalan_Register());
        }

        private void pAIDRECEIPTToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lEDGERToolStripMenuItem_Click(object sender, EventArgs e)
        {


            newForm(new Textile.TranscationReport.InwardRegisterSorting());

           
        }

        private void pARTYREPORTToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pARTYHISHOBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Dashboard.Dashboard_PartyHishob());
        }

        private void pURCHASECONTRACTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Dashboard.Dashboard_YarnContract());
        }

        private void sALESCONTRACTToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void oUTWARDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Dashboard.Dashboard_JobContract());
        }

        private void iNWARDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Dashboard.Dashboard_JobContract_Inward());
        }

        private void sALESCONTRACTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            newForm(new Dashboard.Dashboard_SalesContract());
        }

        private void tOPARTYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_YarnOutward());

        }

        private void tOSIZINGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_SizingOutward());

        }

        private void yARNSALEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_YarnSales());

        }

        private void kHARADINWARDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_KharadInward());
        }

        private void bEAMOUTWARDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_BeamOutward());
        }

        private void bARCODEPRINTToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mULTIPALINVOICEPRINTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Textile.TransactionReport.MultipalInvoicePrint());
        }

        private void cOSTINGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_Costing());
        }

        private void dELIVERYCHALANINWARDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_DeliveryChalanInward());
        }

        private void cLOTHPURCHASEREGISTERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_ClothPurchaseRegister());
        }

        private void yARNGROUPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_YarnGroupMaster());
        }

        private void bEAMMASTERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_EmptyBeams());
        }

        private void eMPTYBEAMOUTWARDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_EmptyBeamOutward());
        }

        private void sIZINGTIPPANINWARDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_SizingInward_Tippan());
        }

        private void hELPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_ContactUs());
        }

        private void aLLINONEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_SinglePage());
        }

        private void sALESBILLDETAILSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_SalesBillDetails());
        }

        private void lOGOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FillGrid1(101);
            Application.Exit();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
