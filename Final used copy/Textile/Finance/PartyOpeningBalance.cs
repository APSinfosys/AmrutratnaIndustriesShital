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
    public partial class PartyOpeningBalance : Form
    {
        public PartyOpeningBalance()
        {
            InitializeComponent();
        }


        #region variables
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        public string owner;
        public int cmbPV, cmbQV;
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
                hash.Add("@intcompanyId", fd.CompId);
                hash.Add("@inryearId", fd.YearId);

                if (QueryNo == 102)
                {
                    hash.Add("@intP_Code", Convert.ToInt32(lblSrNo.Text));
                    hash.Add("@strUniqueCode", lblUniqueCode.Text);
                }

                dtReturn = ClsDefination.FillData("[Party_DML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 202)
                    {
                        cmbBalanceType.DataSource = dtReturn;
                        cmbBalanceType.DisplayMember = "Common_Value";
                        cmbBalanceType.ValueMember = "Common_Id";
                        cmbBalanceType.SelectedIndex = -1;
                        cmbBalanceType.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 203)
                    {
                        cmbShade.DataSource = dtReturn;
                        cmbShade.DisplayMember = "Shade";
                        cmbShade.ValueMember = "ShadeCode";
                        cmbShade.SelectedIndex = -1;
                        cmbShade.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 102)
                    {
                        dgvWarf.DataSource = dtReturn;
                        if (dgvWarf.Rows.Count > 0)
                        {
                            newOrEdit = 1;
                        }
                        else
                        {
                            newOrEdit = 0;
                        }
                    }
                    else if (QueryNo == 204)
                    {
                        // ,
                        cmbFirmName.DataSource = dtReturn;
                        cmbFirmName.DisplayMember = "F_CompanyName";
                        cmbFirmName.ValueMember = "F_Code";
                        cmbFirmName.SelectedIndex = -1;
                        cmbFirmName.Text = "<--SELECT-->";
                    }
                }
                else
                {

                    if (QueryNo == 202)
                    {
                        cmbBalanceType.DataSource = dtReturn;
                        cmbBalanceType.SelectedIndex = -1;
                        cmbBalanceType.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 203)
                    {
                        cmbShade.DataSource = dtReturn;
                        cmbShade.SelectedIndex = -1;
                        cmbShade.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 102)
                    {
                        newOrEdit = 0;
                    }
                    else if (QueryNo == 204)
                    {
                        // ,
                        cmbFirmName.DataSource = dtReturn;
                        cmbFirmName.SelectedIndex = -1;
                        cmbFirmName.Text = "<--NO RECORD-->";
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


                hash.Add("@QueryNo", QueryNo);
                hash.Add("@intcreatedBy", fd.UserId);
                hash.Add("@intcompanyId", fd.CompId);
                hash.Add("@inryearId", fd.YearId);

                if (QueryNo == 3 || QueryNo == 4)
                {

                    hash.Add("@strP_CompanyName", lblCompanyNameValue.Text);
                    hash.Add("@intP_Code", Convert.ToInt32(lblSrNo.Text));
                    hash.Add("@strUniqueCode", lblUniqueCode.Text);
                    string strXmlDetail = "";

                    StringBuilder xmlClassMaster = new StringBuilder();
                    //dt.Columns.Add("X", typeof(string));          //0
                    //dt.Columns.Add("PARTY ID", typeof(int));   //1
                    //dt.Columns.Add("PARTY NAME", typeof(string));  //2
                    //dt.Columns.Add("FIRM ID", typeof(int)); //3
                    //dt.Columns.Add("FIRM NAME", typeof(string));//4
                    //dt.Columns.Add("SHADE ID", typeof(int));   //5
                    //dt.Columns.Add("SHADE NAME", typeof(string));   //6 
                    //dt.Columns.Add("OPENING BALANCE", typeof(decimal));//7
                    //dt.Columns.Add("BALANCE TYPE ID", typeof(int));//8
                    //dt.Columns.Add("BALANCE TYPE", typeof(string));//9
                    //dt.Columns.Add("InAmt", typeof(decimal));//10
                    //dt.Columns.Add("OutAmt", typeof(decimal));//11
                    //dt.Columns.Add("firmId", typeof(int));//12
                    //dt.Columns.Add("UniqueCode", typeof(string));
               

                    for (int k = 0; k < dgvWarf.Rows.Count; k++)
                    {
                        xmlClassMaster.Append("<Row>");
                        xmlClassMaster.Append("<T_Code>" + (Convert.ToInt32(dgvWarf.Rows[k].Cells[1].Value)) + "</T_Code>");
                        xmlClassMaster.Append("<T_Party>" + (Convert.ToInt32(dgvWarf.Rows[k].Cells[1].Value)) + "</T_Party>");
                        //xmlClassMaster.Append("<firmId>" + (Convert.ToInt32(dgvWarf.Rows[k].Cells[3].Value)) + "</firmId>");
                        xmlClassMaster.Append("<firmId>" + (Convert.ToInt32(dgvWarf.Rows[k].Cells[3].Value)) + "</firmId>");
                        xmlClassMaster.Append("<shade>" + (Convert.ToInt32(dgvWarf.Rows[k].Cells[5].Value)) + "</shade>");

                        xmlClassMaster.Append("<amount>" + (Convert.ToDecimal(dgvWarf.Rows[k].Cells[7].Value)) + "</amount>");
                        xmlClassMaster.Append("<balanceType>" + (Convert.ToInt32(dgvWarf.Rows[k].Cells[8].Value)) + "</balanceType>");
                        xmlClassMaster.Append("<T_InAmt>" + (Convert.ToDecimal(dgvWarf.Rows[k].Cells[10].Value)) + "</T_InAmt>");
                        xmlClassMaster.Append("<T_OutAmt>" + (Convert.ToDecimal(dgvWarf.Rows[k].Cells[11].Value)) + "</T_OutAmt>");

                        //xmlClassMaster.Append("<UniqueCode>" + dgvWarf.Rows[k].Cells[13].Value.ToString() + "</UniqueCode>");
                        

                        //,,

                        xmlClassMaster.Append("</Row>");
                    }

                    if (xmlClassMaster.Length > 0)
                    {
                        xmlClassMaster.Append("</ProductSupplierDetails>");
                        strXmlDetail = "<ProductSupplierDetails>" + Convert.ToString(xmlClassMaster);
                    }
                    hash.Add("@strXmlDetail", strXmlDetail);
                }

                okflag = 1;
                return ClsDefination.InsertExecute(hash, "[Party_DML]", ref strReturnMSG, ref strReturnNo, ref intReturnNo);
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


        #region GridCreation
        public void GridCreation()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("X", typeof(string));          //0
                dt.Columns.Add("PARTY ID", typeof(int));   //1
                dt.Columns.Add("PARTY NAME", typeof(string));  //2
                dt.Columns.Add("FIRM ID", typeof(int)); //3
                dt.Columns.Add("FIRM NAME", typeof(string));//4
                dt.Columns.Add("SHADE ID", typeof(int));   //5
                dt.Columns.Add("SHADE NAME", typeof(string));   //6 
                dt.Columns.Add("OPENING BALANCE", typeof(decimal));//7
                dt.Columns.Add("BALANCE TYPE ID", typeof(int));//8
                dt.Columns.Add("BALANCE TYPE", typeof(string));//9
                dt.Columns.Add("InAmt", typeof(decimal));//10
                dt.Columns.Add("OutAmt", typeof(decimal));//11
                dt.Columns.Add("firmId", typeof(int));//12
           //     dt.Columns.Add("UniqueCode",typeof(string));
                   
                //,
                dgvWarf.DataSource = dt;
                gridValidation();
            }
            catch (Exception ex)
            {
            }
        }

        public void gridValidation()
        {
            dgvWarf.Columns[1].Visible = false;
            dgvWarf.Columns[3].Visible = false;
            dgvWarf.Columns[5].Visible = false;
            dgvWarf.Columns[8].Visible = false;
            dgvWarf.Columns[10].Visible = false;
            dgvWarf.Columns[11].Visible = false;
        }
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
                SaveData(3, ref strReturnMSG, ref strReturnRefNo, ref intReturnPKNo);
            }
            else
            {
                SaveData(4, ref strReturnMSG, ref strReturnRefNo, ref intReturnPKNo);
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
                        frm.messageTxt = "Rocord Saved Successfully";// +strReturnMSG;
                    }
                    else
                    {
                        frm.messageTxt = "Rocord Updated Successfully";// +strReturnMSG;
                    }
                    frm.type = "success";
                    frm.ShowDialog();
                    this.Close();
                }
            }
        }

        private void PartyOpeningBalance_Load(object sender, EventArgs e)
        {
            GridCreation();
            FillGrid(202);
            FillGrid(203);
            FillGrid(204);
            FillGrid(102);


        }

        private void btnWeftAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int repeat = 0;
                if (Convert.ToDecimal(txtOpeningBal.Text) > 0)
                {

                    for (int i = 0; i < dgvWarf.Rows.Count; i++)
                    {
                        if (Convert.ToInt32( cmbFirmName.SelectedValue) == Convert.ToInt32( dgvWarf.Rows[i].Cells[3].Value) && 
                            Convert.ToInt32( cmbShade.SelectedValue) == Convert.ToInt32( dgvWarf.Rows[i].Cells[5].Value))
                        {
                            repeat = 1;
                        }
                    }

                    if (repeat == 0)
                    {

                        DataTable dt = dgvWarf.DataSource as DataTable;

                        DataRow dr2 = dt.NewRow();
                        dr2["X"] = "X";
                        dr2["PARTY ID"] = Convert.ToInt32(lblSrNo.Text);   //1
                        dr2["PARTY NAME"] = lblCompanyNameValue.Text;  //2
                        dr2["FIRM ID"] = Convert.ToInt32(cmbFirmName.SelectedValue);
                        dr2["FIRM NAME"] = cmbFirmName.Text;
                        dr2["SHADE ID"] = Convert.ToInt32(cmbShade.SelectedValue);   //3
                        dr2["SHADE NAME"] = cmbShade.Text;   //4 
                        dr2["OPENING BALANCE"] = Convert.ToDecimal(txtOpeningBal.Text);//5
                        dr2["BALANCE TYPE ID"] = Convert.ToInt32(cmbBalanceType.SelectedValue);//6
                        dr2["BALANCE TYPE"] = cmbBalanceType.Text;//7

                        if (Convert.ToInt32(cmbBalanceType.SelectedValue) == 52) // yene
                        {
                            dr2["InAmt"] = Convert.ToDecimal(0.00);
                            dr2["OutAmt"] = Convert.ToDecimal(txtOpeningBal.Text);
                        }
                        else if (Convert.ToInt32(cmbBalanceType.SelectedValue) == 53) // dene
                        {
                            dr2["InAmt"] = Convert.ToDecimal(txtOpeningBal.Text);
                            dr2["OutAmt"] = Convert.ToDecimal(0.00);
                        }

                        //dr2["UniqueCode"] = lblUniqueCode.Text;
                        dr2["firmId"] = Convert.ToInt32(cmbFirmName.SelectedValue);
                       
                       // ,

                        dt.Rows.Add(dr2);

                        dgvWarf.DataSource = dt;
                    }
                    else
                    {
                        messageBox frm = new messageBox();
                        frm.messageTxt = "Record Is Allready Added...";
                        frm.type = "error";
                        frm.ShowDialog();
                    }
                }
                else
                {
                    messageBox frm = new messageBox();
                    frm.messageTxt = "Please Enter Opening Balance";
                    frm.type = "error";
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                
                cmbBalanceType.SelectedIndex = cmbShade.SelectedIndex = cmbFirmName.SelectedIndex = -1;
                cmbBalanceType.Text = cmbShade.Text = cmbFirmName.Text = "<--SELECT-->";
                txtOpeningBal.Text = "0";
                cmbFirmName.Focus();
            }
        }

        private void dgvWarf_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvWarf.CurrentCell.ColumnIndex == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure to delete the record?", "Delete record", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        dgvWarf.Rows.RemoveAt(dgvWarf.CurrentRow.Index);
                    }
                }
            }
            catch
            { }
        }
    }
}
