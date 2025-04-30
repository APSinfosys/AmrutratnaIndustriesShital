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

namespace Textile.TransactionForms
{
    public partial class Transaction_JournalVoucher : Form
    {
        public Transaction_JournalVoucher()
        {
            InitializeComponent();
        }

        #region variables
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        public string UserName, yearString, companyNameStr, groupNmae, PeriodName;
        public int cmbLV, cmbTV, cmbBTV, cmbBBTV;
        string strReturnMSG, strReturnRefNo;
        int intReturnPKNo;
        int result, okflag;
        //  public int groupId;
        public int newOrEdit = 0;
        #endregion

        #region Fillgrid
        public DataTable FillGrid(int QueryNo)
        {
            try
            {
                hash = new Hashtable();

                hash.Add("@QueryNo", QueryNo);
                hash.Add("@intCompanyId", fd.CompId);
                hash.Add("@intYearId", fd.YearId);


                DataTable dtReturn = ClsDefination.FillData("[Transaction_JournalVoucher_DML]", hash);

                if (dtReturn != null && dtReturn.Rows.Count > 0)
                {
                    DataRow dr = dtReturn.Rows[0];

                    if (QueryNo == 201)
                    {
                        cmbTypeOfPayment.DataSource = dtReturn;
                        cmbTypeOfPayment.DisplayMember = "Common_Value";
                        cmbTypeOfPayment.ValueMember = "Common_Id";
                        cmbTypeOfPayment.SelectedIndex = -1;
                        cmbTypeOfPayment.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 202)
                    {
                        cmbShadeName.DataSource = dtReturn;
                        cmbShadeName.DisplayMember = "Shade";
                        cmbShadeName.ValueMember = "L_Code";
                        cmbShadeName.SelectedIndex = -1;
                        cmbShadeName.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 203)
                    {
                        cmbName.DataSource = dtReturn;
                        cmbName.DisplayMember = "NAME";
                        cmbName.ValueMember = "CODE";
                        cmbName.SelectedIndex = -1;
                        cmbName.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 204)
                    {
                        cmbPaidBy.DataSource = dtReturn;
                        cmbPaidBy.DisplayMember = "Common_Value";
                        cmbPaidBy.ValueMember = "Common_Id";
                        cmbPaidBy.SelectedIndex = -1;
                        cmbPaidBy.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 205)
                    {
                        cmbAccount.DataSource = dtReturn;
                        cmbAccount.DisplayMember = "BankName";
                        cmbAccount.ValueMember = "Acc_Code";
                        cmbAccount.SelectedIndex = -1;
                        cmbAccount.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 206)
                    {
                        cmbFirm.DataSource = dtReturn;
                        cmbFirm.DisplayMember = "F_CompanyName";
                        cmbFirm.ValueMember = "F_Code";
                        cmbFirm.SelectedIndex = -1;
                        cmbFirm.Text = "<--SELECT-->";
                    }


                }
                else
                {
                    if (QueryNo == 201)
                    {
                        cmbTypeOfPayment.DataSource = dtReturn;
                        cmbTypeOfPayment.SelectedIndex = -1;
                        cmbTypeOfPayment.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 202)
                    {
                        cmbShadeName.DataSource = dtReturn;
                        cmbShadeName.SelectedIndex = -1;
                        cmbShadeName.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 203)
                    {
                        cmbName.DataSource = dtReturn;
                        cmbName.SelectedIndex = -1;
                        cmbName.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 204)
                    {
                        cmbPaidBy.DataSource = dtReturn;
                        cmbPaidBy.SelectedIndex = -1;
                        cmbPaidBy.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 205)
                    {
                        cmbAccount.DataSource = dtReturn;
                        cmbAccount.SelectedIndex = -1;
                        cmbAccount.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 206)
                    {
                        cmbFirm.DataSource = dtReturn;
                        cmbFirm.SelectedIndex = -1;
                        cmbFirm.Text = "<--NO RECORD-->";
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

                //,getdate(),1,,
                hash.Add("@QueryNo", QueryNo);
                hash.Add("@intCreatedBy", fd.UserId);
                hash.Add("@intCompanyId", fd.CompId);
                hash.Add("@intYearId", fd.YearId);

                if (QueryNo == 1 || QueryNo == 2)
                {

                    if (QueryNo == 2)
                    {
                        hash.Add("@strUniqueCode", lblUniqueCode.Text);
                        hash.Add("@intCode", Convert.ToInt32(lblSrNo.Text));
                    }

                    hash.Add("@dtDate", dtpJVDate.Value.ToString("MM/dd/yyyy"));
                    hash.Add("@intPaymentType", cmbTypeOfPayment.SelectedValue);
                    hash.Add("@strPaymentType", cmbTypeOfPayment.Text);
                    hash.Add("@intShade", cmbShadeName.SelectedValue);
                    hash.Add("@intName", cmbName.SelectedValue);
                    hash.Add("@decAmount", txtAmount.Text);
                    hash.Add("@intPaidBy", cmbPaidBy.SelectedValue);
                    hash.Add("@strPaidBy", cmbPaidBy.Text);
                    hash.Add("@strChqueNo", txtChqueNo.Text);
                    hash.Add("@dtChqueDate", dtpChqueDate.Value.ToString("MM/dd/yyyy"));
                    hash.Add("@intBankId", cmbAccount.SelectedValue);
                    hash.Add("@strNote", txtNote.Text);
                    hash.Add("@intFirm", cmbFirm.SelectedValue);
                    //               ,@,@,@,@,@,
                    //@,@,@,@,@,GETDATE(),
                    //@,@,1,@

                }

                okflag = 1;
                return ClsDefination.InsertExecute(hash, "[Transaction_JournalVoucher_DML]", ref strReturnMSG, ref strReturnNo, ref intReturnNo);
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


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (newOrEdit == 0)
            {
                SaveData(1, ref strReturnMSG, ref strReturnRefNo, ref intReturnPKNo);
            }
            else
            {
                SaveData(2, ref strReturnMSG, ref strReturnRefNo, ref intReturnPKNo);
            }
            if (okflag == 1)
            {
                messageBox frm = new messageBox();

                if (intReturnPKNo == 0)
                {
                    frm.messageTxt = strReturnMSG;
                    frm.type = "error";
                    frm.ShowDialog();

                }
                else
                {
                    if (newOrEdit == 0)
                    {
                        frm.messageTxt = "Rocord Saved Successfully: " + strReturnMSG;
                    }
                    else
                    {
                        frm.messageTxt = "Rocord Updated Successfully: " + strReturnMSG;
                    }
                    frm.type = "success";
                    frm.ShowDialog();
                    this.Close();
                }
            }

        }

        private void Transaction_JournalVoucher_Load(object sender, EventArgs e)
        {
            FillGrid(201);
            FillGrid(202);
            FillGrid(203);
            FillGrid(204);
            FillGrid(205);
            FillGrid(206);
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbName_SelectedIndexChanged(object sender, EventArgs e)
        {
            label11.Text = cmbName.SelectedValue.ToString();
        }

        private void txtTDSPer_Leave(object sender, EventArgs e)
        {
            try
            {
                lblActualAmount.Text = Math.Round(
                    Convert.ToDecimal(txtAmount.Text) / (1 - (Convert.ToDecimal(txtTDSPer.Text) / 100)),2
                    ).ToString();

                txtTDSAMOUNT.Text = Math.Round(
                   (Convert.ToDecimal(lblActualAmount.Text) / Convert.ToDecimal(100)) * Convert.ToDecimal(txtTDSPer.Text),2
                    ).ToString();

            }
            catch (Exception ex)
            {
            }
        }

        private void txtTDSAMOUNT_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtTDSPer.Text == "0" || txtTDSPer.Text == "")
                {
                    lblActualAmount.Text = Math.Round(Convert.ToDecimal(txtAmount.Text)+Convert.ToDecimal(txtTDSAMOUNT.Text),2).ToString();

                    txtTDSPer.Text = Math.Round( (Convert.ToDecimal(txtTDSAMOUNT.Text)/Convert.ToDecimal(lblActualAmount.Text))*100,2  ).ToString();
                }
            }
            catch (Exception ex)
            {
            }
        }


    }
}
