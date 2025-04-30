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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Textile.EmployeePayment
{
    public partial class Employee_Payment : Form
    {
        public Employee_Payment()
        {
            InitializeComponent();
        }

        #region variables
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        public string owner;
        public int cmbSV;
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

                if (QueryNo == 202)
                {
                    hash.Add("@intShed", Convert.ToInt32(cmbShade.SelectedValue));
                }
                if (QueryNo == 102)
                {
                    hash.Add("@intCode",Convert.ToInt32(lblSrNo.Text));
                }
                dtReturn = ClsDefination.FillData("[Auto_SalaryDML]", hash);


                if ((dtReturn != null && dtReturn.Rows.Count > 0))
                {
                    DataRow objRow = dtReturn.Rows[0];

                    if (QueryNo == 201)
                    {
                        cmbShade.DataSource = dtReturn;
                        cmbShade.DisplayMember = "Shade";
                        cmbShade.ValueMember = "L_Code";
                        cmbShade.SelectedIndex = -1;
                        cmbShade.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 202)
                    {
                        cmbEmployee.DataSource = dtReturn;
                        cmbEmployee.ValueMember = "Emp_Code";
                        cmbEmployee.DisplayMember = "Name";
                        cmbEmployee.SelectedIndex = -1;
                        cmbEmployee.Text = "<--SELECT-->";
                    }
                    else if (QueryNo == 102)
                    {
                        dgvDesign.DataSource = dtReturn;
                        gridValidation();
                    }
                }
                else
                {
                    if (QueryNo == 201)
                    {
                        cmbShade.DataSource = dtReturn;
                        cmbShade.SelectedIndex = -1;
                        cmbShade.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo == 201)
                    {
                        cmbEmployee.DataSource = dtReturn;
                        cmbEmployee.SelectedIndex = -1;
                        cmbEmployee.Text = "<--NO RECORD-->";
                    }
                    else if (QueryNo==102)
                    {
                        dgvDesign.DataSource = null;
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

                if (QueryNo == 1 || QueryNo == 2)
                {

                    if (QueryNo == 2)
                    {
                        hash.Add("@strUniqueCode",lblUniqueCode.Text);
                        hash.Add("@intCode", Convert.ToInt32(lblSrNo.Text));
                    }

                    hash.Add("@dtpFromDate",dtpFromDate.Value.ToString("MM/dd/yyyy"));
                    hash.Add("@dtpToDate",dtpTodate.Value.ToString("MM/dd/yyyy"));
                    hash.Add("@strMonth", Thread.CurrentThread.CurrentCulture.DateTimeFormat.MonthNames[dtpFromDate.Value.Month-1].ToString().ToUpper());
                    hash.Add("@intShed", Convert.ToInt32(cmbShade.SelectedValue));
                    hash.Add("@decGrandTotalPayment",Convert.ToDecimal(lblGrandTotal.Text));

          //          ,,,,,,
          //@,GETDATE(),1,0,@,@


                    string strXmlDetail = "";   

                    StringBuilder xmlClassMaster = new StringBuilder();

                    for (int k = 0; k < dgvDesign.Rows.Count; k++)
                    {

                        xmlClassMaster.Append("<Row>");
                        //,,
                        xmlClassMaster.Append("<AES_Employee>" + dgvDesign.Rows[k].Cells[1].Value.ToString() + "</AES_Employee>");
                        xmlClassMaster.Append("<AES_PerDaySal>" + (Convert.ToDecimal(dgvDesign.Rows[k].Cells[3].Value)) + "</AES_PerDaySal>");
                        xmlClassMaster.Append("<AES_PerDayWrkHr>" +( Convert.ToInt32( dgvDesign.Rows[k].Cells[4].Value.ToString())) + "</AES_PerDayWrkHr>");
                        xmlClassMaster.Append("<AES_PresentDay>" + (Convert.ToInt32(dgvDesign.Rows[k].Cells[5].Value.ToString())) + "</AES_PresentDay>");
                        xmlClassMaster.Append("<AES_PresentHr>" + (Convert.ToInt32(dgvDesign.Rows[k].Cells[6].Value.ToString())) + "</AES_PresentHr>");
                        xmlClassMaster.Append("<AES_ExtraDay>" + (Convert.ToInt32(dgvDesign.Rows[k].Cells[7].Value.ToString())) + "</AES_ExtraDay>");
               //                , , , , , , 
                        xmlClassMaster.Append("<AES_4MS>" + (Convert.ToInt32(dgvDesign.Rows[k].Cells[8].Value.ToString())) + "</AES_4MS>");
                        xmlClassMaster.Append("<AES_45MS>" + (Convert.ToInt32(dgvDesign.Rows[k].Cells[9].Value.ToString())) + "</AES_45MS>");
                        xmlClassMaster.Append("<AES_4MSH>" + (Convert.ToInt32(dgvDesign.Rows[k].Cells[10].Value.ToString())) + "</AES_4MSH>");
                        xmlClassMaster.Append("<AES_45MSH>" + (Convert.ToInt32(dgvDesign.Rows[k].Cells[11].Value.ToString())) + "</AES_45MSH>");
                        
                        xmlClassMaster.Append("<AES_DoubleShift>" + (Convert.ToInt32(dgvDesign.Rows[k].Cells[12].Value.ToString())) + "</AES_DoubleShift>");
                        xmlClassMaster.Append("<AES_HelperWrk>" + (Convert.ToInt32(dgvDesign.Rows[k].Cells[13].Value.ToString())) + "</AES_HelperWrk>");
                        xmlClassMaster.Append("<AES_Payment>" + (Convert.ToDecimal(dgvDesign.Rows[k].Cells[14].Value)) + "</AES_Payment>");
                        xmlClassMaster.Append("<AES_ExtraDayPayment>" + (Convert.ToDecimal(dgvDesign.Rows[k].Cells[15].Value)) + "</AES_ExtraDayPayment>");
               //, , , , , ,
                        xmlClassMaster.Append("<AES_FridayPayment>" + (Convert.ToDecimal(dgvDesign.Rows[k].Cells[16].Value)) + "</AES_FridayPayment>");
                        xmlClassMaster.Append("<AES_4Mspayment>" + (Convert.ToDecimal(dgvDesign.Rows[k].Cells[17].Value)) + "</AES_4Mspayment>");
                        xmlClassMaster.Append("<AES_45MsPayment>" + (Convert.ToDecimal(dgvDesign.Rows[k].Cells[18].Value)) + "</AES_45MsPayment>");
                        xmlClassMaster.Append("<AES_HelperWrkPayment>" + (Convert.ToDecimal(dgvDesign.Rows[k].Cells[19].Value)) + "</AES_HelperWrkPayment>");
                        xmlClassMaster.Append("<AES_DoubleShiftPayment>" + (Convert.ToDecimal(dgvDesign.Rows[k].Cells[20].Value)) + "</AES_DoubleShiftPayment>");
               //, , , , ,
                        xmlClassMaster.Append("<AES_BeamGetter>" + (Convert.ToDecimal(dgvDesign.Rows[k].Cells[21].Value)) + "</AES_BeamGetter>");
                        xmlClassMaster.Append("<AES_BestWrk>" + (Convert.ToDecimal(dgvDesign.Rows[k].Cells[22].Value)) + "</AES_BestWrk>");
                        xmlClassMaster.Append("<AES_Deduction>" + (Convert.ToDecimal(dgvDesign.Rows[k].Cells[23].Value)) + "</AES_Deduction>");
                        xmlClassMaster.Append("<AES_TotalPayment>" + (Convert.ToDecimal(dgvDesign.Rows[k].Cells[24].Value)) + "</AES_TotalPayment>");
                        xmlClassMaster.Append("<AES_LoomNo>" + (Convert.ToDecimal(dgvDesign.Rows[k].Cells[25].Value)) + "</AES_LoomNo>");


                        //                dr2["4 M/S HR"] = Convert.ToInt32(txt4MsHr.Text);
                //dr2["4.5 M/S HR"] = Convert.ToInt32(txt45MsHr.Text);, , , 
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
                return ClsDefination.InsertExecute(hash, "[Auto_SalaryDML]", ref strReturnMSG, ref strReturnNo, ref intReturnNo);
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

        #region GridCreation & Validation
        public void GridCreation()
        {
            try
            {

                DataTable dt = new DataTable();

                dt.Columns.Add("X", typeof(string));          //0
                dt.Columns.Add("EMP CODE", typeof(int));
                //     'X' as [X],ES.AES_Employee as [EMP CODE],
                
                dt.Columns.Add("EMP NAME", typeof(string));
                dt.Columns.Add("PER DAY SAL", typeof(decimal));
                dt.Columns.Add("PERDAYWRKHR", typeof(int));
                //ME.Name as [EMP NAME],ES.AES_PerDaySal as [PER DAY SAL], ES.AES_PerDayWrkHr as [PERDAYWRKHR],
                
                dt.Columns.Add("PRESENT DAY", typeof(int));
                dt.Columns.Add("PRESENT HOUR", typeof(int));
                dt.Columns.Add("EXTRA DAY", typeof(int));
                //ES.AES_PresentDay as [PRESENT DAY], ES.AES_PresentHr as [PRESENT HOUR],ES.AES_ExtraDay as [EXTRA DAY], 

                dt.Columns.Add("4 M/S", typeof(int));
                dt.Columns.Add("4.5 M/S", typeof(int));
                dt.Columns.Add("4 M/S H", typeof(int));
                dt.Columns.Add("4.5 M/S H",typeof(int));
                //ES.AES_4MS as [4 M/S], ES.AES_45MS as [4.5 M/S],ES.AES_4MSH as [4 M/S H],ES.AES_45MSH as [4.5 M/S H],
                
                dt.Columns.Add("DOUBLE SHIFT", typeof(int));
                //ES.AES_DoubleShift as [DOUBLE SHIFT], 
                
                dt.Columns.Add("HELPER WORK", typeof(int));
                dt.Columns.Add("PAYMENT", typeof(decimal));
                //ES.AES_HelperWrk as [HELPER WORK], ES.AES_Payment as [PAYMENT], 
                
                dt.Columns.Add("EXTRA DAY PAY", typeof(decimal));
                dt.Columns.Add("FRIDAY PAY", typeof(decimal));
                //      ES.AES_ExtraDayPayment as [EXTRA DAY PAY], ES.AES_FridayPayment as [FRIDAY PAY], 

                dt.Columns.Add("4 M/S PAY", typeof(decimal));
                dt.Columns.Add("4.5 M/S PAY", typeof(decimal));
                //      ES.AES_4Mspayment as [4 M/S PAY], ES.AES_45MsPayment as [4.5 M/S PAY], 

                dt.Columns.Add("HELPER WRK PAY", typeof(decimal));
                dt.Columns.Add("DOUBLE SHIFT PAY", typeof(decimal));
                //      ES.AES_HelperWrkPayment as [HELPER WRK PAY], ES.AES_DoubleShiftPayment as [DOUBLE SHIFT PAY], 

                dt.Columns.Add("BEAM GETTER PAY", typeof(decimal));
                dt.Columns.Add("BEST WRK", typeof(decimal));
                //      ES.AES_BeamGetter as [BEAM GETTER PAY], ES.AES_BestWrk as [BEST WRK], 
           
                dt.Columns.Add("DEDUCTION", typeof(decimal));
                dt.Columns.Add("TOTAL PAY", typeof(decimal));
                //      ES.AES_Deduction as [DEDUCTION], ES.AES_TotalPayment as [TOTAL PAY],

                dt.Columns.Add("LOOM NO", typeof(decimal));
                //      ES.AES_LoomNo as [LOOM NO]

                dgvDesign.DataSource = dt;
            }
            catch (Exception ex)
            {
            }
        }

        public void gridValidation()
        {
            dgvDesign.Columns[1].Visible = false;
            dgvDesign.Columns[4].Visible = false;

        }
        #endregion



        private void Employee_Payment_Load(object sender, EventArgs e)
        {
            FillGrid(201);
            GridCreation();
            if (newOrEdit == 1)
            {
                FillGrid(102);
                 cmbShade.SelectedValue = cmbSV;
            }

            gridValidation();
        }

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

        private void cmbShade_Leave(object sender, EventArgs e)
        {
            if (cmbShade.Text != "" && cmbShade.Text != "<--SELECT-->" && cmbShade.Text != "<--NO RECORD-->" && Convert.ToInt32(cmbShade.SelectedValue) > 0)
            {
                FillGrid(202);
            }
            else
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please select shade";
                frm.type = "error";
                frm.ShowDialog();
            }
        }

        private void cmbEmployee_Leave(object sender, EventArgs e)
        {
            if (cmbEmployee.Text == "" && cmbEmployee.Text == "<--SELECT-->" && cmbEmployee.Text == "<--NO RECORD-->" && Convert.ToInt32(cmbEmployee.SelectedValue) < 0)
            {
                messageBox frm = new messageBox();
                frm.messageTxt = "Please select employee";
                frm.type = "error";
                frm.ShowDialog();
                btnSave.Focus();
            }
            else
            {
            
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = dgvDesign.DataSource as DataTable;

                DataRow dr2 = dt.NewRow();

                dr2["X"] = "X";      //0
                dr2["EMP CODE"] = Convert.ToInt32( cmbEmployee.SelectedValue);
                dr2["EMP NAME"] = cmbEmployee.Text;
                dr2["PER DAY SAL"] = Convert.ToDecimal(txtPerDayPayment.Text);
                dr2["PERDAYWRKHR"] = Convert.ToInt32(txtPerdayWrkHr.Text);
                dr2["PRESENT DAY"] = Convert.ToInt32(txtPresentDays.Text);
                dr2["PRESENT HOUR"] = Convert.ToInt32(txtHours.Text);
                dr2["EXTRA DAY"] = Convert.ToInt32(txtExtraDay.Text);
                //            AES_Employee] AES_PerDaySal] AES_PerDayWrkHr] AES_PresentDay] AES_PresentHr] AES_ExtraDay] 
                dr2["4 M/S"] = Convert.ToInt32(txt4Ms.Text);
                dr2["4.5 M/S"] = Convert.ToInt32(txt45Ms.Text);
                dr2["4 M/S H"] = Convert.ToInt32(txt4MsHr.Text);
                dr2["4.5 M/S H"] = Convert.ToInt32(txt45MsHr.Text);
                dr2["DOUBLE SHIFT"] = Convert.ToInt32(txtDoubleShift.Text);
                dr2["HELPER WORK"] = Convert.ToInt32(txtHelperWork.Text);
                dr2["PAYMENT"] = Convert.ToDecimal(txtPayment.Text);
                dr2["EXTRA DAY PAY"] = Convert.ToDecimal(txtExtraDayP.Text);
                //AES_4MS] AES_45MS] AES_DoubleShift] AES_HelperWrk] AES_Payment] AES_ExtraDayPayment] 
                dr2["FRIDAY PAY"] = Convert.ToDecimal(txtFriday.Text);
                dr2["4 M/S PAY"] = Convert.ToDecimal(txt4MsP.Text);
                dr2["4.5 M/S PAY"] = Convert.ToDecimal(txt45MsP.Text);
                dr2["HELPER WRK PAY"] = Convert.ToDecimal(txtHelperWrkP.Text);
                dr2["DOUBLE SHIFT PAY"] = Convert.ToDecimal(txtDoubleShiftP.Text);
                //AES_FridayPayment] AES_4Mspayment] AES_45MsPayment] AES_HelperWrkPayment] AES_DoubleShiftPayment] 
                dr2["BEAM GETTER PAY"] = Convert.ToDecimal(txtBeamGtrP.Text);
                dr2["BEST WRK"] = Convert.ToDecimal(txtBestWrk.Text);
                dr2["DEDUCTION"] = Convert.ToDecimal(txtDeduction.Text);
                dr2["TOTAL PAY"] = Convert.ToDecimal(txtTotalPay.Text);
                dr2["LOOM NO"]=Convert.ToDecimal(txtLoomNo.Text);

                dt.Rows.Add(dr2);

                dgvDesign.DataSource = dt;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                txtPerDayPayment.Text = "0";
                txtPerdayWrkHr.Text = "0";
                txtPresentDays.Text = "0";
                txtHours.Text = "0";
                txtExtraDay.Text = "0";
                txt4Ms.Text = "0";
                txt45Ms.Text = "0";
                txtDoubleShift.Text = "0";
                txtHelperWork.Text = "0";
                txtPayment.Text = "0";
                txtExtraDayP.Text = "0";
                txt4MsP.Text = "0";
                txt45MsP.Text = "0";
                txtDoubleShiftP.Text = "0";
                txtHelperWrkP.Text = "0";
                txtFriday.Text = "0";
                txtBeamGtrP.Text = "0";
                txtBestWrk.Text = "0";
                txtDeduction.Text = "0";
                txtTotalPay.Text = "0";
                txtLoomNo.Text = "0";
                txt45MsHr.Text=txt4MsHr.Text= "0";
                cmbEmployee.SelectedIndex = -1;
                cmbEmployee.Text = "<--SELECT-->";
                gridCalculation();
                gridValidation();
                cmbEmployee.Focus();
            }

        }

        private void txtPerdayWrkHr_Leave(object sender, EventArgs e)
        {
            if( Convert.ToInt32(txtPerdayWrkHr.Text)>0)
            {
                lblRatePerHr.Text = Math.Round(Convert.ToDecimal(txtPerDayPayment.Text) / Convert.ToDecimal(txtPerdayWrkHr.Text), 2).ToString();
            }
        }


        public void totalPay()
        {
            try
            {
                decimal mc4,mc45;

                mc4 = Math.Round(Convert.ToDecimal(txt4Ms.Text) * Convert.ToDecimal(txtPerdayWrkHr.Text), 2);
                mc45 = Math.Round(Convert.ToDecimal(txt45Ms.Text) * Convert.ToDecimal(txtPerdayWrkHr.Text), 2);
                txtExtraDayP.Text = Math.Round(Convert.ToDecimal(txtExtraDay.Text)*Convert.ToDecimal(txtPerDayPayment.Text),2 ).ToString();

                txt4MsP.Text = Math.Round((mc4+Convert.ToDecimal(txt4MsHr.Text))*Convert.ToDecimal(txt4MsRate.Text),2).ToString();

                //+Convert.ToInt32(txt4MsHr.Text) Convert.ToInt32(txt4Ms.Text)*Convert.ToInt32(txtHours.Text)
               // txt4MsP.Text = Math.Round( Convert.ToDecimal() ).ToString();
                //(Convert.ToInt32(txt45Ms.Text) * Convert.ToInt32(txtHours.Text))
                txt45MsP.Text = Math.Round((mc45 + Convert.ToInt32(txt45MsHr.Text)) * Convert.ToDecimal(txt45MsRate.Text), 2).ToString();

                txtDoubleShiftP.Text = Math.Round(Convert.ToDecimal(txtDoubleShift.Text)*Convert.ToDecimal(txtDoubleRate.Text),2).ToString();

                txtHelperWrkP.Text = Math.Round(Convert.ToDecimal(txtHelperWork.Text)*Convert.ToDecimal(txtHelperRate.Text),2).ToString();

                txtPayment.Text = Math.Round(((Convert.ToDecimal(txtPerDayPayment.Text)*Convert.ToDecimal(txtPresentDays.Text))+
                    (Convert.ToDecimal(txtHours.Text)*Convert.ToDecimal(lblRatePerHr.Text))),2).ToString();
                
                txtTotalPay.Text =
                    Math.Round(Convert.ToDecimal(txtPayment.Text) + Convert.ToDecimal(txtExtraDayP.Text) + Convert.ToDecimal(txtFriday.Text)
                    +Convert.ToDecimal(txt4MsP.Text)+Convert.ToDecimal(txt45MsP.Text)+Convert.ToDecimal(txtHelperWrkP.Text)+ Convert.ToDecimal(txtDoubleShiftP.Text)
                    +Convert.ToDecimal(txtBeamGtrP.Text)+Convert.ToDecimal(txtBestWrk.Text)+Convert.ToDecimal(txtDeduction.Text)+
                Convert.ToDecimal(txtLoomNo.Text), 2).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtPresentDays_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtPresentDays.Text == "")
                {
                    txtPresentDays.Text = "0";
                }
                if (txtPayment.Text == "")
                {
                    txtPayment.Text = "0";
                }
                txtPayment.Text = Math.Round(Convert.ToDecimal(txtPayment.Text)+(Convert.ToDecimal(txtPerDayPayment.Text) * Convert.ToDecimal(txtPresentDays.Text)), 2).ToString();
                totalPay();
            }
            catch (Exception ex)
            {
            }
        }

        private void txtHours_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtHours.Text == "")
                {
                    txtHours.Text = "0";
                }

                if (txtPayment.Text == "")
                {
                    txtPayment.Text = "0";
                }
                txtPayment.Text = Math.Round(Convert.ToDecimal(txtPayment.Text) + (Convert.ToDecimal(txtHours.Text) * Convert.ToDecimal(lblRatePerHr.Text)), 2).ToString();
                totalPay();
            }
            catch (Exception ex)
            {
            }
        }

        private void txtExtraDay_Leave(object sender, EventArgs e)
        {
            if (txtExtraDay.Text == "")
            {
                txtExtraDay.Text = "0";
            }
            totalPay();
        }

        private void txt4Ms_Leave(object sender, EventArgs e)
        {
            if (txt4Ms.Text == "")
            {
                txt4Ms.Text = "0";
            }
            totalPay();
        }

        private void txt45Ms_Leave(object sender, EventArgs e)
        {
            if (txt45Ms.Text == "")
            {
                txt45Ms.Text = "0";
            }
            totalPay();
        }

        private void txtDoubleShift_Leave(object sender, EventArgs e)
        {
            if (txtDoubleShift.Text == "")
            {
                txtDoubleShift.Text = "0";
            }
            totalPay();
        }

        private void txtHelperWork_Leave(object sender, EventArgs e)
        {
            if (txtHelperWork.Text == "")
            {
                txtHelperWork.Text = "0";
            }
            totalPay();
        }

        private void txtPayment_Leave(object sender, EventArgs e)
        {
            if (txtPayment.Text == "")
            {
                txtPayment.Text = "0";
            }

            totalPay();
        }

        private void txtExtraDayP_Leave(object sender, EventArgs e)
        {
            if (txtExtraDayP.Text == "")
            {
                txtExtraDayP.Text = "0";
            }
            totalPay();
        }

        private void txtFriday_Leave(object sender, EventArgs e)
        {
            if (txtFriday.Text == "")
            {
                txtFriday.Text = "0";
            }
            totalPay();
        }

        private void txt4MsP_Leave(object sender, EventArgs e)
        {
            if (txt4MsP.Text == "")
            {
                txt4MsP.Text = "0";
            }
            totalPay();
        }

        private void txt45MsP_Leave(object sender, EventArgs e)
        {
            if (txt45MsP.Text == "")
            {
                txt45MsP.Text = "0";
            }
            totalPay();
        }

        private void txtHelperWrkP_Leave(object sender, EventArgs e)
        {
            if (txtHelperWrkP.Text == "")
            {
                txtHelperWrkP.Text = "0";
            }
            totalPay();
        }

        private void txtDoubleShiftP_Leave(object sender, EventArgs e)
        {
            if (txtDoubleShiftP.Text == "")
            {
                txtDoubleShiftP.Text = "0";
            }
            totalPay();
        }

        private void txtBeamGtrP_Leave(object sender, EventArgs e)
        {
            if (txtBeamGtrP.Text == "")
            {
                txtBeamGtrP.Text = "0";
            }
            totalPay();
            txtLoomNo.Focus();
        }

        private void txtBestWrk_Leave(object sender, EventArgs e)
        {
            if (txtBestWrk.Text == "")
            {
                txtBestWrk.Text = "0";
            }
            totalPay();
        }

        private void txtDeduction_Leave(object sender, EventArgs e)
        {
            if (txtDeduction.Text == "")
            {
                txtDeduction.Text = "0";
            }
            totalPay();
            txtTotalPay.Focus();
        }

        public void gridCalculation()
        {
            try
            {
                lblGrandTotal.Text = "0";

                for (int i = 0; i < dgvDesign.Rows.Count; i++)
                {
                    lblGrandTotal.Text =
                        Math.Round(Convert.ToDecimal(lblGrandTotal.Text)+ Convert.ToDecimal(dgvDesign.Rows[i].Cells[22].Value.ToString()) ).ToString();
                }

            }
            catch (Exception ex)
            {
            }
        }

        private void dgvDesign_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDesign.CurrentCell.ColumnIndex == 0)
                {

                    DialogResult dialogResult = MessageBox.Show("Are you sure to delete the record?", "Delete record", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        dgvDesign.Rows.RemoveAt(dgvDesign.CurrentRow.Index);
                      
                        gridCalculation();

                    }
                }
            }
            catch
            {


            }

        }

        private void txtLoomNo_Leave(object sender, EventArgs e)
        {
            if (txtLoomNo.Text == "")
            {
                txtLoomNo.Text = "0";
            }
            totalPay();
            txtBestWrk.Focus();
        }

        private void txtBestWrk_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt4MsHr_Leave(object sender, EventArgs e)
        {
            if (txt4MsHr.Text == "")
            {
                txt4MsHr.Text = "0";
            }
            totalPay();
        }

        private void txt4MsRate_Leave(object sender, EventArgs e)
        {
            if (txt4MsRate.Text == "")
            {
                txt4MsRate.Text = "10.00";
            }
            totalPay();
        }

        private void txt45MsHr_Leave(object sender, EventArgs e)
        {
            if (txt45MsHr.Text == "")
            {
                txt45MsHr.Text = "0";
            }
            totalPay();
        }

        private void txt45MsRate_Leave(object sender, EventArgs e)
        {
            if (txt45MsRate.Text == "")
            {
                txt45MsRate.Text = "15.00";
            }
            totalPay();
        }

        private void txtDoubleRate_Leave(object sender, EventArgs e)
        {
            if (txtDoubleRate.Text == "")
            {
                txtDoubleRate.Text = "50.00";
            }
            totalPay();
        }

        private void txtHelperRate_Leave(object sender, EventArgs e)
        {
            if (txtHelperRate.Text == "")
            {
                txtHelperRate.Text = "50.00";
            }
            totalPay();
        }

    }
}
