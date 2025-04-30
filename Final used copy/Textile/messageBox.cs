using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Accounting
{
    public partial class messageBox : Form
    {
        public messageBox()
        {
            InitializeComponent();
        }

        public string type;
        public string messageTxt;
        public int result;
        private void messageBox_Load(object sender, EventArgs e)
        {
            if (type.ToLower() == "success")
            {
                msgType.BackgroundImage = Textile.Properties.Resources.sucessIcon;
                btnNo.Visible = false;
                btnYes.Visible = false;
                button1.Visible = true;
            }
            else if (type.ToLower() == "confirm")
            {
                msgType.BackgroundImage = Textile.Properties.Resources.Blue_question_mark_icon_svg;
                btnNo.Visible = true;
                btnYes.Visible = true;
                button1.Visible = false;
                
            }
            else if (type.ToLower() == "error")
            {
                msgType.BackgroundImage = Textile.Properties.Resources.errorIcon;
                btnNo.Visible = false;
                btnYes.Visible = false;
                button1.Visible = true;
            }
            lblMessage.Text = messageTxt;

            //MessageBox.Show
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            this.Close();
            result = 1;
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
            result = 0;
        }

       
    }
}
