using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections;
using Accounting.Classes;
namespace Accounting
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("user32.Dll",EntryPoint="ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.Dll",EntryPoint="SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam,int lparam);


        #region Variable
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        public string UserName, yearString, companyNameStr;
        //int AccType;
        public int userId, compId, yearId;
        #endregion

        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (menuBar.Width == 250)
            {
                menuBar.Width = 70;
                btnLeft.BackgroundImage = Textile.Properties.Resources.arrow_right_128;
                lblUserName.Visible = false;
            }
            else
            {
                menuBar.Width = 250;
                btnLeft.BackgroundImage = Textile.Properties.Resources.arrow_left_128;
                lblUserName.Visible = true;
            }

            panelContainer.Dock = DockStyle.Fill;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnLeft.BackgroundImage = Textile.Properties.Resources.arrow_left_128;
            btnResore.Visible = true;
            btnMaximize.Visible = false;

            lblCompanyName.Text = fd.CompanyNameStr;
            FillGrid(701);
           //newForm(new Dashbord_Forms.Dashboard_HomeScreen());
            userId = fd.UserId;
            lblUserName.Text = fd.UserName;
            lblUserType.Text = fd.LoginType;
        
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximize.Visible = false;
            btnResore.Visible = true;
        }

        private void btnResore_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnResore.Visible = false;
            btnMaximize.Visible = true;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void titleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            product.Active = true;
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            product.Active = false;
        }

        private void btnProduct_MouseHover(object sender, EventArgs e)
        {
          //  productPan.BackColor = System.Drawing.Color.White;
            //btnProduct.BackColor = System.Drawing.Color.FromArgb(45, 45, 49);
        }

        private void btnProduct_MouseLeave(object sender, EventArgs e)
        {
         //   productPan.BackColor = System.Drawing.Color.Transparent;
            //btnProduct.BackColor = System.Drawing.Color.Transparent;
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

        private void btnProduct_Click(object sender, EventArgs e)
        {
          //  newForm(new Form2());
            //newForm(new Master.Master_CustomerMaster());
        }

        private void titleBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
           // newForm(new Dashbord_Forms.Dashboard_GroupSubgroupMaster());
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_ClothDesigh());
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_SutMaster());
        }

        private void menuBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            
            
        }

        private void panel1_Click_1(object sender, EventArgs e)
        {
           // newForm(new Dashbord_CustomerMaster());
            panel12.Visible = false;    
        }

        private void panel2_Click(object sender, EventArgs e)
        {
           // newForm(new Dashbord_Forms.Dashbord_EmployeeMaster());
            panel12.Visible = false;
        }

        private void panel3_Click(object sender, EventArgs e)
        {
           // newForm(new Dashbord_Forms.Dashboard_GroupSubgroupMaster());
            panel12.Visible = false;
        }

        public DataTable FillGrid(int QueryNo)
        {
            try
            {
                hash = new Hashtable();

                hash.Add("@QueryNo",QueryNo);
                hash.Add("@intCompanyId", compId);
                DataTable dtReturn = ClsDefination.FillData("[Login_DML]", hash);

                if (dtReturn != null && dtReturn.Rows.Count > 0)
                {
                    DataRow dr = dtReturn.Rows[0];

                    if (QueryNo == 701)
                    {
                        lblNoCustomer.Text = dtReturn.Rows[0][0].ToString();
                        lblNoOfEmp.Text = dtReturn.Rows[0][1].ToString();
                        lblNoOfGroups.Text = dtReturn.Rows[0][2].ToString();
                        lblLastDayCollection.Text = dtReturn.Rows[0][3].ToString();
                    }

                }
                else
                {
                    if (QueryNo == 701)
                    {
                        lblNoCustomer.Text = "0";
                        lblNoOfEmp.Text = "0";
                        lblNoOfGroups.Text = "0";
                        lblLastDayCollection.Text = "0";
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

        private void lblNoOfEmp_Click(object sender, EventArgs e)
        {
           // newForm(new Dashbord_Forms.Dashbord_EmployeeMaster());
            panel12.Visible = false;
        }

        private void lblNoCustomer_Click(object sender, EventArgs e)
        {
           // newForm(new Dashbord_CustomerMaster());
            panel12.Visible = false;  
        }

        private void lblNoOfGroups_Click(object sender, EventArgs e)
        {
           // newForm(new Dashbord_Forms.Dashboard_GroupSubgroupMaster());
            panel12.Visible = false;
        }

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSales_Click(object sender, EventArgs e)
        {
           // newForm(new Dashbord_Forms.GroupWiseCustomerDetails());
            panel12.Visible = false;
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_YarnInward());
           // Textile.Yarn.YarnInward frm = new Textile.Yarn.YarnInward();
           // frm.Show();
            panel12.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_YarnOutward());
           // Textile.Yarn.YarnOutword frm = new Textile.Yarn.YarnOutword();
            //frm.Show();
            panel12.Visible = false;
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
          //  newForm(new Dashbord_Forms.Dashboard_FinantialTransaction());
            panel12.Visible = false;
        }

        private void btnAccountMaster_Click(object sender, EventArgs e)
        {
            newForm(new Dashbord_Forms.Dashboard_AccountMaster());
            panel12.Visible = false;
        }

        private void btnFinanceHeads_Click(object sender, EventArgs e)
        {
            //newForm(new Dashbord_Forms.Dashboard_FinanceHeads());
            panel12.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_PartyMaster());
            panel12.Visible = false;
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            //button4.BackColor = System.Drawing.Color.FromArgb(0, 100, 182);//Color.rgb(0, 100, 182);
            //button5.BackColor = System.Drawing.Color.FromArgb(0, 100, 182);
            //button6.BackColor = System.Drawing.Color.FromArgb(0, 100, 182);

            //button2.Visible = true;
            //btnEmployee.Visible = true;
            //btnCustomer.Visible = true;
            ////btnAccountMaster.Visible = true;
            
            ////btnProducts.Visible = true;
            ////btnSales.Visible = true;
           

            //btnPurchase.Visible = false;
            //button1.Visible = false;
            //btn_AuctionPayments.Visible = false;

            //btnFinanceHeads.Visible = false;
            //btnPayment.Visible = false;
            
            //btnReport.Visible = false;
            //btnEmpRpt.Visible = false;
            //btnBalanceSheet.Visible = false;
            //btnPL.Visible = false;
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
           // button3.BackColor = System.Drawing.Color.FromArgb(0, 100, 182);//Color.rgb(0, 100, 182);
           // button5.BackColor = System.Drawing.Color.FromArgb(0, 100, 182);
           // button6.BackColor = System.Drawing.Color.FromArgb(0, 100, 182);
            
            
           // button2.Visible = false;
           // btnAccountMaster.Visible = false;
           // btnCustomer.Visible =  false;
           // //btnProducts.Visible = false;
           // //btnSales.Visible = false;
           // //btnEmployee.Visible = false;

           // btnPurchase.Visible = true;
           // button1.Visible = true;
           //// btn_AuctionPayments.Visible = true;

           // btnFinanceHeads.Visible = false;
           // btnPayment.Visible = false;

           // btnReport.Visible = false;
           // btnEmpRpt.Visible = false;
           // btnBalanceSheet.Visible = false;
           // btnPL.Visible = false;
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {

            //button4.BackColor = System.Drawing.Color.FromArgb(0, 100, 182);//Color.rgb(0, 100, 182);
            //button3.BackColor = System.Drawing.Color.FromArgb(0, 100, 182);
            //button6.BackColor = System.Drawing.Color.FromArgb(0, 100, 182);

            //button2.Visible = false;
            //btnAccountMaster.Visible = false;
            //btnCustomer.Visible = false;
            ////btnProducts.Visible = false;
            ////btnSales.Visible = false;
            ////btnEmployee.Visible = false;

            //btnPurchase.Visible = false;
            //button1.Visible = false;
            ////btn_AuctionPayments.Visible = false;

            //btnSizingInward.Visible =true;
            //btnPayment.Visible = true;

            //btnReport.Visible = false;
            //btnEmpRpt.Visible = false;
            //btnBalanceSheet.Visible = false;
            //btnPL.Visible = false;
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            button4.BackColor = System.Drawing.Color.FromArgb(0, 100, 182);//Color.rgb(0, 100, 182);
            btnSizing.BackColor = System.Drawing.Color.FromArgb(0, 100, 182);
            button3.BackColor = System.Drawing.Color.FromArgb(0, 100, 182);

            //button2.Visible = false;
            //btnAccountMaster.Visible = false;
            //btnCustomer.Visible = false;
            ////btnProducts.Visible = false;
            ////btnSales.Visible = false;
            ////btnEmployee.Visible = false;

            //btnPurchase.Visible = false;
            //button1.Visible = false;
            ////btn_AuctionPayments.Visible = false;

            //btnSizingInward.Visible = false;
            //btnPayment.Visible = false;

            //btnSalaryReport.Visible = true;
           
            //btnBalanceSheet.Visible = true;
            
            //btnPL.Visible = true;
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
           // newForm(new Dashbord_Forms.Dashboard_Report());
            panel12.Visible = false;
        }

        private void btnEmpRpt_Click(object sender, EventArgs e)
        {
           // newForm(new Dashbord_Forms.Dashboard_EmpReports());
            panel12.Visible = false;
        }

        private void btnBalanceSheet_Click(object sender, EventArgs e)
        {
           // newForm(new Dashbord_Forms.Dashboard_Balancesheet());
            panel12.Visible = false;
        }

        private void btnPL_Click(object sender, EventArgs e)
        {
           // newForm(new Dashbord_Forms.Dashboard_ProfitLoss());
            panel12.Visible = false;
        }

        private void btn_AuctionPayments_Click(object sender, EventArgs e)
        {
           // newForm(new Dashbord_Forms.Dashboard_AuctionPayment());
            panel12.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button2.Visible == false)
            {
                //button4.BackColor = System.Drawing.Color.FromArgb(0, 100, 182);//Color.rgb(0, 100, 182);
                //btnSizing.BackColor = System.Drawing.Color.FromArgb(0, 100, 182);
                //btnReports.BackColor = System.Drawing.Color.FromArgb(0, 100, 182);

                MasterMax();
                //YarnMin();
                //WindingMin();
                //sizingMin();
              
            }
            else
            {
                MasterMin();
            }
        }

        public void MasterMax()
        {
            sizingMin();
            YarnMin();
            WindingMin();
            rptMin();
            productionMin();
            monthlyPayMin();
            transactionMin();
            button2.Visible = true;
            btnEmployee.Visible = true;
            btnCustomer.Visible = true;
            btnLoomMaster.Visible = true;
            btnEmployeeMaster.Visible = true;
            btnAccountMaster.Visible = true;
        }
        public void MasterMin()
        {
            button2.Visible = false;
            btnEmployee.Visible = false;
            btnCustomer.Visible = false;
            btnLoomMaster.Visible = false;
            btnEmployeeMaster.Visible = false;
            btnAccountMaster.Visible = false;
        }

        public void YarnMax()
        {
            MasterMin();
            sizingMin();
            WindingMin();
            rptMin();
            productionMin();
            monthlyPayMin();
            transactionMin();
            btnPurchase.Visible = true;
            button1.Visible = true;
        }
        public void YarnMin()
        {
            btnPurchase.Visible = false;
            button1.Visible = false;
        }

        public void WindingMax()
        {
            MasterMin();
            YarnMin();
            sizingMin();
            rptMin();
            productionMin();
            monthlyPayMin();
            transactionMin();
            btnWindingInward.Visible = true;
            btnWindingOutward.Visible = true;

        }

        public void WindingMin()
        {
            btnWindingInward.Visible = false;
            btnWindingOutward.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (btnPurchase.Visible == false)
            {
                YarnMax();
            }
            else
            {
                YarnMin();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_WindingInward());
            panel12.Visible = false;
        }

        private void btnWinding_Click(object sender, EventArgs e)
        {
            if (btnWindingInward.Visible == false)
            {
                WindingMax();
            }
            else
            {
                WindingMin();
            }
        }

        private void btnWindingOutward_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_WindingOutward());
            panel12.Visible = false;
        }

        public void sizingMax()
        {
            MasterMin();
            YarnMin();
            WindingMin();
            rptMin();
            productionMin();
            monthlyPayMin();
            transactionMin();
            btnSizingInward.Visible = true;
        }
        public void sizingMin()
        {
            btnSizingInward.Visible = false;
        }

        private void btnSizing_Click(object sender, EventArgs e)
        {
            if (btnSizingInward.Visible == true)
            {
                sizingMin();
            }
            else
            {
                sizingMax();
            }
        }

        private void btnSizingInward_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_SizingInward());
            panel12.Visible = false;
        }

        private void btnLoomMaster_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_LoomMaster());
            panel12.Visible = false;
        }

        private void btnViving_Click(object sender, EventArgs e)
        {
            MasterMin();
            YarnMin();
            WindingMin();
            sizingMin();
            rptMin();
            productionMin();
            monthlyPayMin();
            transactionMin();
            newForm(new Textile.Dashboard.Dashboard_Viving());
            panel12.Visible = false;
        }

        private void btnEmployeeMaster_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_Employee());
            panel12.Visible = false;
        }

        public void productionMax()
        {
            btnMagProduction.Visible = true;
            btnAutoRapierProduction.Visible = true;
            MasterMin();
            YarnMin();
            WindingMin();
            sizingMin();
            rptMin();
            monthlyPayMin();
            transactionMin();
        }
        public void productionMin()
        {
            btnMagProduction.Visible = false;
            btnAutoRapierProduction.Visible = false;
        }
        private void btnProduction_Click(object sender, EventArgs e)
        {
            if (btnMagProduction.Visible == true)
            {
                productionMin();
            }
            else
            {
                productionMax();
            }
            //MasterMin();
            //YarnMin();
            //WindingMin();
            //sizingMin();
            //rptMin();
            //newForm(new Textile.Dashboard.Dashboard_Production());
            //panel12.Visible = false;
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            if (btnGSTReport.Visible == false)
            {
                rptMax();
            }
            else
            {
                rptMin();
            }
        }

        public void rptMax()
        {
            MasterMin();
            YarnMin();
            WindingMin();
            sizingMin();
            productionMin();
            monthlyPayMin();
            transactionMin();
            //btnSalaryReport.Visible = true;
            btnGSTReport.Visible = true;
            btnClothReport.Visible = true;
            btnStockReport.Visible = true;
         //   btnPayment.Visible = true;
        }

        public void rptMin()
        {
           // btnSalaryReport.Visible = false;
            btnGSTReport.Visible = false;
            btnClothReport.Visible = false;
            btnStockReport.Visible = false;
            btnPayment.Visible = false;
        }

        private void btnSalaryReport_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_EmployeeSalaryReport());
            panel12.Visible = false;
        }

        private void btnGSTReport_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_GSTReport());
            panel12.Visible = false;
        }

        private void btnClothReport_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_ClothReport());
            panel12.Visible = false;
        }

        private void btnMagProduction_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_Production());
            panel12.Visible = false;
        }

        private void btnAutoRapierProduction_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_AutoProduction());
            panel12.Visible = false;
        }

        public void monthlyPayMax()
        {
            MasterMin();
            YarnMin();
            WindingMin();
            sizingMin();
            rptMin();
            productionMin();
            transactionMin();
            btnAutoLoomSalary.Visible = true;
            btnSalaryReport.Visible = true;
            btnSalRtpAuto.Visible = true;
        }
        public void monthlyPayMin()
        {
            btnAutoLoomSalary.Visible = false;
            btnSalaryReport.Visible = false;
            btnSalRtpAuto.Visible = false;
        }

        private void btnMonthlyPayment_Click(object sender, EventArgs e)
        {
            if (btnAutoLoomSalary.Visible == true)
            {
                monthlyPayMin();
            }
            else
            {
                monthlyPayMax();
            }
        }

        private void btnAutoLoomSalary_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_AutoMonthlySalary());
            panel12.Visible = false;
        }

        private void btnSalRtpAuto_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_EmpSalReportAuto());
            panel12.Visible = false;
        }

        private void btnStockReport_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_StockReport());
            panel12.Visible = false;
        }

        public void transactionMax()
        {
            MasterMin();
            YarnMin();
            WindingMin();
            sizingMin();
            productionMin();
            monthlyPayMin();
            rptMin();
            btnPurchaseInvoice.Visible = true;
            btnDeliveryCahalan.Visible = true;
           // btnSalesInvoice.Visible = true;
            
        }

        public void transactionMin()
        {
            btnDeliveryCahalan.Visible = false;
            btnSalesInvoice.Visible = false;
            btnPurchaseInvoice.Visible = false;
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            if (btnPurchaseInvoice.Visible == true)
            {
                transactionMin();
            }
            else
            {
                transactionMax();
            }
        }

        private void btnPurchaseInvoice_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_PurchaseInvoice());
            panel12.Visible = false;
        }

        private void btnDeliveryCahalan_Click(object sender, EventArgs e)
        {
            newForm(new Textile.Dashboard.Dashboard_DeliveryChalan());
            panel12.Visible = false;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSalesInvoice_Click(object sender, EventArgs e)
        {

        }

    }
}
