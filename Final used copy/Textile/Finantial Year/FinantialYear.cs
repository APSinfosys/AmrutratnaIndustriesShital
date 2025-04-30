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

namespace Textile.Finantial_Year
{
    public partial class FinantialYear : Form
    {
        public int userId, compId;
        public string UserName;

        public FinantialYear()
        {
            InitializeComponent();
        }

        #region Variable Declaration
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        string User, Passward, userType;
        //int userId, AccType, compId;
        #endregion

        #region FILLGRID
        public DataTable FillGrid(int QueryNo)
        {
            try
            {
                hash = new Hashtable();


                hash.Add("@QueryNo", QueryNo);
                if (QueryNo == 502)
                {
                    hash.Add("@intCompId", fd.CompId);
                    //hash.Add("@strPassword", txtPassword.Text);
                }
                if (QueryNo == 503)
                {
                    hash.Add("@intYearId",cmbYear.SelectedValue);
                }

                DataTable dtReturn = ClsDefination.FillData("[Login_DML]", hash);

                if (dtReturn != null && dtReturn.Rows.Count > 0)
                {
                    //LD.id,LD.compId,LD.username,LD.password,LD.loginType,LD.name,LD.userCode,MCM.commonName
                    DataRow dr = dtReturn.Rows[0];
                    if (QueryNo == 502)
                    {
                        cmbYear.DataSource = dtReturn;
                        cmbYear.ValueMember="Yr_Id";
                        cmbYear.DisplayMember = "Yr_Name";
                       // cmbYear.SelectedIndex = -1;
                      //  cmbYear.Text = "<--SELECT-->";
                    }

                    else if (QueryNo == 503)
                    {
                        fd.StartDate = Convert.ToDateTime(dr["Date_From"]);
                        fd.EndDate =  Convert.ToDateTime(dr["Date_To"]);
                        fd.ShortYear = dr["yr_Short"].ToString();
                    }
                }
                else
                {
                    if (QueryNo == 502)
                    {
                        cmbYear.DataSource = dtReturn;
                        cmbYear.SelectedIndex = -1;
                        cmbYear.Text = "<--NO RECORD-->";
                    }

                    //messageBox frm = new messageBox();
                    //frm.type = "error";
                    //frm.messageTxt = "You have enterd wrong user name or password";//"No user named " + txtUserName.Text + " available. " + Environment.NewLine + "Please check user name and try again.";
                    //frm.ShowDialog();
                }
                return null;
            }


            catch (Exception ex)
            {
                messageBox frm = new messageBox();
                frm.type = "error";
                frm.messageTxt = "Database Connection Issue " + Environment.NewLine + "Please Contact Support On +91 73 85 993 551";
                frm.ShowDialog();

                return null;
                throw;
            }
        }
        #endregion
        private void button1_Click(object sender, EventArgs e)
        {
            //Main frm = new Main();
            //Form1 frm = new Form1();
            if (cmbYear.Text == "<--SELECT-->" || cmbYear.Text == "<--NO RECORD-->" || cmbYear.SelectedIndex < 0 || cmbYear.Text == "")
            {

                messageBox frm = new messageBox();
                frm.type = "error";
                frm.messageTxt = "Please select finantial year";
                frm.ShowDialog();
            }
            else
            {
                FillGrid(503);
                Main frm = new Main();
                frm.Show();
                this.Hide();
            }
        }

        private void FinantialYear_Load(object sender, EventArgs e)
        {
            FillGrid(502);
        }

        private void cmbYear_Leave(object sender, EventArgs e)
        {
            if (cmbYear.Text != "<--SELECT-->")
            {
                fd.YearId = Convert.ToInt32(cmbYear.SelectedValue);
                fd.YearString = cmbYear.Text;
            }
            else
            {
                cmbYear.Focus();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
