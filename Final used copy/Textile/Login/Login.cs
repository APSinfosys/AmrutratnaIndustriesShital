using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accounting.Classes;
using System.Collections;
using Accounting;

namespace Textile.Login
{
    public partial class Login : Form
    {

        //  functionalDetails fd = new functionalDetails();

        #region Variable Declaration
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        string User, Passward, userType, companyName;
        int userId, AccType, compId;
        #endregion

        public Login()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (txtUserName.Text.ToLower() == "samarth" && txtPassword.Text == "$@m@rt#")
            {
                CompanyRegistration.Comapny_Registraiton frm = new CompanyRegistration.Comapny_Registraiton();
                this.Hide();
                frm.Show();
            }
            else if (txtUserName.Text.ToLower() == "user name" || txtPassword.Text == "PASSWORD" || txtUserName.Text.ToLower() == "" || txtPassword.Text == "")
            {
                messageBox frm = new messageBox();
                frm.type = "error";
                frm.messageTxt = "Please check user name or password and try again.";
                //"No user named " + txtUserName.Text + " available. " + Environment.NewLine + "Please check user name and try again.";
                frm.ShowDialog();

                txtUserName.Text = "USER NAME";
                txtPassword.Text = "PASSWORD";
                txtUserName.Focus();
                // Finantial_Year.FinantialYear frm = new Finantial_Year.FinantialYear();
                //frm.Show();
            }
            else
            {
                FillGrid(501);

                //messageBox frm = new messageBox();
                //frm.type = "error";
                //frm.messageTxt = "No user named " + txtUserName.Text + " available. " + Environment.NewLine + "Please check user name and try again.";
                //frm.ShowDialog();
            }
        }

        public DataTable FillGrid(int QueryNo)
        {
            try
            {
                hash = new Hashtable();


                hash.Add("@QueryNo", QueryNo);
                if (QueryNo == 501)
                {
                    hash.Add("@strUserName", txtUserName.Text.ToLower());
                    hash.Add("@strPassword", txtPassword.Text);
                }

                DataTable dtReturn = ClsDefination.FillData("[Login_DML]", hash);

                if (dtReturn != null && dtReturn.Rows.Count > 0)
                {
                    //LD.id,LD.compId,LD.username,LD.password,LD.loginType,LD.name,LD.userCode,MCM.commonName
                    DataRow dr = dtReturn.Rows[0];
                    User = dr["User_Name"].ToString();
                    Passward = dr["User_Password"].ToString();// +Convert.ToString(System.DateTime.Now.Day);
                    userId = Convert.ToInt32(dr["User_Code"].ToString());
                    compId = Convert.ToInt32(dr["User_Company"].ToString());
                    userType = dr["User_Type_S"].ToString();
                    fd.StateId = Convert.ToInt32(dr["Comp_State"].ToString());
                    companyName = dr["Comp_Name"].ToString();
                    fd.EndDate = Convert.ToDateTime(dr["endDate"].ToString());

                    DateTime endDate = new DateTime();
                    endDate = Convert.ToDateTime(dr["endDate"].ToString());


                    int regType = Convert.ToInt32(dr["reg_Type"].ToString());

                    if (regType == 1)
                    {
                        finance();
                    }
                    else
                    {

                        int end = (Convert.ToInt32(endDate.Year) * 12*30) + ( Convert.ToInt32( endDate.Month) * 30) + Convert.ToInt32(endDate.Day);


                        DateTime current = new DateTime();

                        current = DateTime.Today;

                      

                        int currentDate = (Convert.ToInt32( current.Year) * 12*30) + (Convert.ToInt32( current.Month) * 30) + Convert.ToInt32(current.Day);

                        int diff = end - currentDate;

                        if (diff >= 1 && diff <= 15)
                        {
                            messageBox frm = new messageBox();
                            frm.type = "error";
                            frm.messageTxt = "Your licence period going to expire within " + diff + " days";//"No user named " + txtUserName.Text + " available. " + Environment.NewLine + "Please check user name and try again.";
                            frm.ShowDialog();
                            finance();
                        }
                        else if (diff <= 0)
                        {
                            messageBox frm = new messageBox();
                            frm.type = "error";
                            frm.messageTxt = "Your licence period is expird please contact +91 7507482288";//"No user named " + txtUserName.Text + " available. " + Environment.NewLine + "Please check user name and try again.";
                            frm.ShowDialog();
                        }
                        else
                        {
                            finance();
                        }

                    }
                }
                else
                {

                    messageBox frm = new messageBox();
                    frm.type = "error";
                    frm.messageTxt = "You have enterd wrong user name or password";//"No user named " + txtUserName.Text + " available. " + Environment.NewLine + "Please check user name and try again.";
                    frm.ShowDialog();
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

        public void finance()
        {
            if (User.ToLower() == txtUserName.Text.ToLower() && Passward == txtPassword.Text)
            {
                Finantial_Year.FinantialYear frm = new Finantial_Year.FinantialYear();
                fd.UserId = userId;//Convert.ToInt32(dr["userCode"].ToString());
                fd.CompId = compId;
                fd.UserName = User;//dr["name"].ToString();
                fd.LoginType = userType;//dr["commonName"].ToString();
                fd.CompanyNameStr = companyName;
                frm.userId = fd.UserId;
                frm.compId = compId;
                frm.UserName = fd.LoginType;


                frm.Show();

                this.Hide();
            }
            else
            {

                messageBox frm = new messageBox();
                frm.type = "error";
                frm.messageTxt = "You have enterd wrong user name or password";//"No user named " + txtUserName.Text + " available. " + Environment.NewLine + "Please check user name and try again.";
                frm.ShowDialog();
            }
        }

        public void licence()
        {

        }

        private void btnLogin_Enter(object sender, EventArgs e)
        {
            btnLogin.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
        }

        private void btnLogin_Leave(object sender, EventArgs e)
        {
            btnLogin.BackColor = System.Drawing.Color.LightGray;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtUserName.Focus();
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            txtPassword.Focus();
        }


    }
}
