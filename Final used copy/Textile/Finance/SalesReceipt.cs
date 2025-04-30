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

namespace Textile.Finance
{
    public partial class SalesReceipt : Form
    {
        public SalesReceipt()
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
                hash.Add("@intcompanyId", fd.CompId);
                hash.Add("@inryearId", fd.YearId);

                if (QueryNo == 204)
                {
                    hash.Add("@intPartyCode", lblPartyCode.Text);
                    hash.Add("@intFirm",lblFirmCode.Text);
                    hash.Add("@intCode",txtReceipt.Text);
                }

                DataTable dtReturn = ClsDefination.FillData("[Transaction_SalesReceipt_DML]", hash);

                if (dtReturn != null && dtReturn.Rows.Count > 0)
                {
                    DataRow dr = dtReturn.Rows[0];
                    if (QueryNo == 202)
                    {
                        cmbFrmAcc.DataSource = dtReturn;
                        cmbFrmAcc.DisplayMember = "BankName";
                        cmbFrmAcc.ValueMember = "Acc_Code";
                        cmbFrmAcc.SelectedIndex = -1;
                        cmbFrmAcc.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 203)
                    {
                        cmbPaidBy.DataSource = dtReturn;
                        cmbPaidBy.DisplayMember = "Common_Value";
                        cmbPaidBy.ValueMember = "Common_Id";
                        cmbPaidBy.SelectedIndex = -1;
                        cmbPaidBy.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 204)
                    {
                        lblTaxableAmt.Text = dr["taxableAmt"].ToString();
                    }

                }
                else
                {
                    if (QueryNo == 202)
                    {
                        cmbFrmAcc.DataSource = dtReturn;
                        cmbFrmAcc.SelectedIndex = -1;
                        cmbFrmAcc.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 203)
                    {
                        cmbPaidBy.DataSource = dtReturn;
                        cmbPaidBy.SelectedIndex = -1;
                        cmbPaidBy.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 204)
                    {
                        lblTaxableAmt.Text = "0";
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
                hash.Add("@intcreatedBy", fd.UserId);
                hash.Add("@intcompanyId", fd.CompId);
                hash.Add("@inryearId", fd.YearId);

                if (QueryNo == 1 || QueryNo == 2)
                {

                    if (QueryNo == 2)
                    {
                        //hash.Add("@intCode", Convert.ToInt32(lblSrNo.Text));
                    }

                    hash.Add("@dtpTransactionDate",dtpTransactionDate.Value.ToString("MM/dd/yyyy"));
                    hash.Add("@intPartyCode",Convert.ToInt32(lblPartyCode.Text));
                    hash.Add("@strPArty",lblPartyName.Text);
                    hash.Add("@decAmount",Convert.ToDecimal(lblSalaryAmt.Text));
                    hash.Add("@decPayingAmount",Convert.ToDecimal(txtAmountPay.Text));
                    hash.Add("@decBalAmt",Convert.ToDecimal(lblRemAmt.Text));
    
                    hash.Add("@intPaidBy",Convert.ToInt32(cmbPaidBy.SelectedValue));
                    hash.Add("@strChkNo",txtChkNo.Text);
                    hash.Add("@dtpDate",dtpChkDate.Value.ToString("MM/dd/yyyy"));
                    hash.Add("@intAmtToAcc",Convert.ToInt32(cmbFrmAcc.SelectedValue));
                    hash.Add("@intShade",Convert.ToDecimal(lblShade.Text));
                    hash.Add("@strReceiptNo",txtReceipt.Text);
                    hash.Add("@intFirm", Convert.ToInt32(lblFirmCode.Text));
                    hash.Add("@decTDSAmount", Convert.ToDecimal(txtTdsAmt.Text));
                    hash.Add("@decTDSPer", Convert.ToDecimal(txtTdsPer.Text));

                    hash.Add("@strSIUniqueCode", lblInviceUniqueCode.Text);
                }

                okflag = 1;
                return ClsDefination.InsertExecute(hash, "[Transaction_SalesReceipt_DML]", ref strReturnMSG, ref strReturnNo, ref intReturnNo);
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

        private void btnCancle_Click(object sender, EventArgs e)
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
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = strReturnMSG;
                frm.type = "error";
                frm.ShowDialog();
            }
        }

        private void SalesReceipt_Load(object sender, EventArgs e)
        {
            FillGrid(202);
            FillGrid(203);
            lblRemAmt.Text = lblSalaryAmt.Text;
            txtChkNo.Enabled = false;
            dtpChkDate.Enabled = false;
            FillGrid(204);
        }

        private void cmbPaidBy_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbPaidBy.SelectedValue) == 56)
            {
                txtChkNo.Enabled = false;
                dtpChkDate.Enabled = false;
            }
            else
            {
                txtChkNo.Enabled = true;
                dtpChkDate.Enabled = true;
                txtChkNo.Focus();
            }
        }

        private void txtAmountPay_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtAmountPay.Text == "")
                {
                    txtAmountPay.Text = "0";
                }

                calculation();

            }
            catch (Exception ex)
            {
            }
        }

        private void txtTdsPer_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtTdsPer.Text == "")
                {
                    txtTdsPer.Text = "0";
                }

                if (Convert.ToDecimal(txtTdsPer.Text) > 0)
                {
                    txtTdsAmt.Text = Math.Round( (Convert.ToDecimal(lblTaxableAmt.Text)/100)*Convert.ToDecimal(txtTdsPer.Text),0).ToString();
                }
                calculation();
            }
            catch (Exception ex)
            {
            }
        }

        public void calculation()
        {
            lblRemAmt.Text = Math.Round(
                Convert.ToDecimal(lblSalaryAmt.Text) - Convert.ToDecimal(txtAmountPay.Text) - Convert.ToDecimal(txtTdsAmt.Text), 2
                ).ToString();
        }

    }
}
