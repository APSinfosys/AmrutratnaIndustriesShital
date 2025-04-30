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
    public partial class Dashboard_PartyHishob : Form
    {
        public Dashboard_PartyHishob()
        {
            InitializeComponent();
        }

        #region Variable
        Hashtable hash = new Hashtable();
        functionalDetails fd = new functionalDetails();
        BindingSource bs = new BindingSource();
        BindingSource bsOriginal = new BindingSource();
        public string UserName, yearString, companyNameStr;
        public int userId, compId, yearId, GroupId = 0, otherPg;
        string strReturnMSG, strReturnRefNo, sp;
        int intReturnPKNo;
        int result, deletefrm;
        public int newOrEdit = 0;

        #endregion

        public DataTable FillGrid(int QueryNo)
        {
            try
            {
                hash = new Hashtable();

                hash.Add("@QueryNo", QueryNo);
                hash.Add("@intCompanyId", fd.CompId);
                hash.Add("@intYearId", fd.YearId);

                if (QueryNo == 2001 || QueryNo == 2002 || QueryNo == 2003 || QueryNo == 2004 || QueryNo == 1021)
                {
                    hash.Add("@intFromParty", cmbPartyName.SelectedValue);
                }
                if (QueryNo == 2001 || QueryNo == 2002 || QueryNo == 2003 || QueryNo == 2006 || QueryNo == 1022 || QueryNo == 1023 || QueryNo == 2004 || QueryNo == 2005)
                {
                    hash.Add("@intQuality", cmbQuality.SelectedValue); // Sat no
                }
                //if ( )
                //{
                //    hash.Add("@intQuality", lblQualityCode.Text);
                //}

                DataTable dtReturn = ClsDefination.FillData("[Report_AllReport]", hash);

                if (dtReturn != null && dtReturn.Rows.Count > 0)
                {
                    DataRow dr = dtReturn.Rows[0];

                    if (QueryNo == 1021)
                    {
                        //,
                        cmbQuality.DataSource = dtReturn;
                        cmbQuality.DisplayMember = "SatNo";
                        cmbQuality.ValueMember = "Id";
                        cmbQuality.SelectedIndex = -1;
                        cmbQuality.Text = "<-- Select SAT NO -->";
                    }
                    else if (QueryNo == 1022)
                    {
                        lblQualityCode.Text = dr["Q_Code"].ToString();//count
                        lblTotalDesigns.Text = dr["count"].ToString();

                    }
                    else if (QueryNo == 1023)
                    {
                        lblQualityName.Text = dr["QualityName"].ToString();
                    }
                    else if (QueryNo == 1020)
                    {
                        //,
                        cmbPartyName.DataSource = dtReturn;
                        cmbPartyName.DisplayMember = "P_CompanyName";
                        cmbPartyName.ValueMember = "P_Code";
                        cmbPartyName.SelectedIndex = -1;
                        cmbPartyName.Text = "<-- Select Party -->";
                    }
                    else if (QueryNo == 2001)
                    {
                        dgvYarnInwardDetails.DataSource = dtReturn;
                    }
                    else if (QueryNo == 2002)
                    {
                        dgvBeamDetails.DataSource = dtReturn;
                    }
                    else if (QueryNo == 2003)
                    {
                        dgvDelivery.DataSource = dtReturn;
                    }
                    else if (QueryNo == 2004)
                    {
                        dgvWeightDetials.DataSource = dtReturn;
                    }
                    else if (QueryNo == 2005)
                    {
                        dgvWarf.DataSource = dtReturn;
                    }
                    else if (QueryNo == 2006)
                    {
                        dgvWeft.DataSource = dtReturn;
                    }


                }
                else
                {

                    if (QueryNo == 101)
                    {
                        //,
                        cmbQuality.DataSource = dtReturn;
                        cmbQuality.SelectedIndex = -1;
                        cmbQuality.Text = "<-- NO SAT NO FOUND -->";
                    }
                    else if (QueryNo == 1020)
                    {
                        //,
                        cmbPartyName.DataSource = dtReturn;
                        cmbPartyName.SelectedIndex = -1;
                        cmbPartyName.Text = "<-- NO PARTY FOUND -->";
                    }
                    else if (QueryNo == 2001)
                    {
                        dgvYarnInwardDetails.DataSource = dtReturn;
                    }
                    else if (QueryNo == 2002)
                    {
                        dgvBeamDetails.DataSource = dtReturn;
                    }
                    else if (QueryNo == 2003)
                    {
                        dgvDelivery.DataSource = dtReturn;
                    }
                    else if (QueryNo == 2004)
                    {
                        dgvWeightDetials.DataSource = dtReturn;
                    }
                    else if (QueryNo == 2005)
                    {
                        dgvWarf.DataSource = dtReturn;
                    }
                    else if (QueryNo == 2006)
                    {
                        dgvWeft.DataSource = dtReturn;
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

        private void Dashboard_PartyHishob_Load(object sender, EventArgs e)
        {
            FillGrid(101);
            FillGrid(1020);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {

            if (cmbPartyName.SelectedIndex > -1)
            {
                if (cmbQuality.SelectedIndex > -1)
                {
                    FillGrid(2001); // yarn inward
                    FillGrid(2002); // beam inward
                    FillGrid(2003);
                    FillGrid(2004);
                    FillGrid(2005);
                    FillGrid(2006);
                   // dgvWeft.Columns[6].Visible = dgvWeft.Columns[7].Visible = false;
                    calculations();
                    Excel();
                }
                else
                {
                    MessageBox.Show("Please Select Sat No");
                }
            }
            else
            {
                MessageBox.Show("Please Select Party");
            }
        }

        public void calculations()
        {
            try
            {
                lblTotalMtr.Text = "0";
                decimal Qmtr = 0.00M;
                int Desings = Convert.ToInt32(lblTotalDesigns.Text);
                string temp = "", temp1 = "";
                //dgvWarf = 42;
                //dgvWeft = 43;

                //if (dgvDelivery.Rows.Count > 0)
                //{

                //    for (int i = 0; i < dgvDelivery.Rows.Count; i++)
                //    {

                //        lblTotalMtr.Text = Math.Round(Convert.ToDecimal(lblTotalMtr.Text) + Convert.ToDecimal(dgvDelivery.Rows[i].Cells[3].Value.ToString()), 2).ToString();
                //    }
                //}

                //for (int i = 0; i < dgvWarf.Rows.Count; i++)
                //{
                //    dgvWarf.Rows[i].Cells[4].Value = Math.Round(Convert.ToDecimal(lblTotalMtr.Text) * Convert.ToDecimal(dgvWarf.Rows[i].Cells[3].Value), 2);


                //}



                //while (Desings > 0)
                //{

                for (int i = 0; i < dgvDelivery.Rows.Count; i++)
                {
                    temp = dgvDelivery.Rows[i].Cells[5].Value.ToString(); // getting Design name
                    Qmtr = 0;
                    if (temp != temp1) // checking design name against temp1 variable 
                    {

                        temp1 = temp; // assigning temp vale to temp1 so upside condition will be false untill we get new design
                        for (int j = 0; j < dgvDelivery.Rows.Count; j++)
                        {
                            if (temp == dgvDelivery.Rows[j].Cells[5].Value.ToString()) // check grid value against temp value if match then calculate mtr else skip
                            {
                                Qmtr = Qmtr + Convert.ToDecimal(dgvDelivery.Rows[j].Cells[3].Value) + Convert.ToDecimal(dgvDelivery.Rows[j].Cells[4].Value);
                            }
                            else
                            {
                                continue;
                            }
                        }
                        for (int k = 0; k < dgvWeft.Rows.Count; k++) // adding calculated mtr against weft for consupmtion
                        {
                            if (temp == dgvWeft.Rows[k].Cells[0].Value.ToString())
                            {
                                string d;

                                d = Math.Round(Convert.ToDecimal(Qmtr) * Convert.ToDecimal(dgvWeft.Rows[k].Cells[4].Value), 2, MidpointRounding.AwayFromZero).ToString();
                                dgvWeft.Rows[k].Cells[5].Value = d;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                    else
                    {
                        continue;
                    }
                }

                //for (int j = 0; j < dgvDelivery.Rows.Count; j++)  /// for getting mtr according to design
                //{
                //    for (int i = 0; i < dgvWeft.Rows.Count; i++)
                //    {
                //        string d;
                //        d = Math.Round(Convert.ToDecimal(lblTotalMtr.Text) * Convert.ToDecimal(dgvWeft.Rows[i].Cells[3].Value), 2, MidpointRounding.AwayFromZero).ToString();
                //        dgvWeft.Rows[i].Cells[4].Value = d;
                //    }
                //}

                //}



                for (int i = 0; i < dgvWeightDetials.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dgvWeightDetials.Rows[i].Cells[5].Value) == 42)
                    {
                        //for (int j = 0; j < dgvWarf.Rows.Count; j++)
                        //{
                        //    if (dgvWarf.Rows[j].Cells[0].Value.ToString() == dgvWeightDetials.Rows[i].Cells[0].Value.ToString())
                        //    {
                        //        dgvWarf.Rows[j].Cells[5].Value = dgvWeightDetials.Rows[i].Cells[2].Value.ToString();
                        //    }
                        //}
                    }
                    else if (Convert.ToInt32(dgvWeightDetials.Rows[i].Cells[5].Value) == 43)
                    {
                        for (int j = 0; j < dgvWeft.Rows.Count; j++)
                        {
                            if (dgvWeft.Rows[j].Cells[1].Value.ToString() == dgvWeightDetials.Rows[i].Cells[0].Value.ToString() &&
                                dgvWeft.Rows[j].Cells[2].Value.ToString() == dgvWeightDetials.Rows[i].Cells[2].Value.ToString())
                            {
                                dgvWeft.Rows[j].Cells[6].Value = dgvWeightDetials.Rows[i].Cells[3].Value.ToString();
                                dgvWeft.Rows[j].Cells[7].Value = Convert.ToDecimal(dgvWeft.Rows[j].Cells[5].Value) - Convert.ToDecimal(dgvWeft.Rows[j].Cells[6].Value);
                            }
                        }

                    }
                }


                //for (int i = 0; i < dgvWarf.Rows.Count; i++)
                //{
                //    dgvWarf.Rows[i].Cells[6].Value = Math.Round(
                //        Convert.ToDecimal(dgvWarf.Rows[i].Cells[4].Value) - Convert.ToDecimal(dgvWarf.Rows[i].Cells[5].Value), 3
                //        ).ToString();
                //}

                //for (int i = 0; i < dgvWeft.Rows.Count; i++)
                //{
                //    dgvWeft.Rows[i].Cells[6].Value = Math.Round(
                //        Convert.ToDecimal(dgvWeft.Rows[i].Cells[4].Value) - Convert.ToDecimal(dgvWeft.Rows[i].Cells[5].Value), 3
                //        ).ToString();
                //}



                for (int i = 0; i < dgvWeightDetials.Rows.Count; i++)
                {
                    temp = dgvWeightDetials.Rows[i].Cells[0].Value.ToString(); // getting Design name
                    Qmtr = 0;
                    for (int j = 0; j < dgvWeft.Rows.Count; j++)
                    {
                        temp1 = dgvWeft.Rows[j].Cells[1].Value.ToString();
                        if (temp == temp1) // checking design name against temp1 variable 
                        {
                            Qmtr = Qmtr + Convert.ToDecimal(dgvWeft.Rows[j].Cells[5].Value);
                        }
                    }

                    dgvWeightDetials.Rows[i].Cells[4].Value= Qmtr;

                    dgvWeightDetials.Rows[i].Cells[5].Value = Math.Round(Convert.ToDecimal( dgvWeightDetials.Rows[i].Cells[3].Value) - Convert.ToDecimal( dgvWeightDetials.Rows[i].Cells[4].Value),3);
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void Excel()
        {
            //// creating Excel Application
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();

            // creating new WorkBook within Excel application
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);

            // creating new Excelsheet in workbook
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            // see the excel sheet behind the program
            app.Visible = true;

            // get the reference of first sheet. By default its name is Sheet1.
            // store its reference to worksheet
            worksheet = (Microsoft.Office.Interop.Excel._Worksheet)workbook.Sheets["Sheet1"];
            worksheet = (Microsoft.Office.Interop.Excel._Worksheet)workbook.ActiveSheet;


            // changing the name of active sheet
            worksheet.Name = "PIN korisnici";



            worksheet.Cells[1, 2] = fd.CompanyNameStr;  //"AMRUT - RATNA INDUSTRIES";
            //    worksheet.Cells[1, 2] = Font.Bold;
            // worksheet.Cells[1, 10] = 



            worksheet.Cells[2, 3] = cmbPartyName.Text;
            worksheet.Cells[3, 3] = cmbQuality.Text + " - " + lblQualityName.Text;

            worksheet.Cells[5, 1] = "BEAM INWARD DETAILS";




            //************************************************************************* BEAM ********************************************************
            List<DataGridViewColumn> listVisible = new List<DataGridViewColumn>();
            foreach (DataGridViewColumn col in dgvBeamDetails.Columns)
            {
                if (col.Visible)
                    listVisible.Add(col);
            }
            for (int i = 0; i < listVisible.Count; i++)
            {
                worksheet.Cells[6, i + 1] = listVisible[i].HeaderText;   // Display HEader on cell[5A,1A]
            }

            for (int i = 0; i < dgvBeamDetails.Rows.Count; i++)
            {
                for (int j = 0; j < listVisible.Count; j++)
                {
                    worksheet.Cells[i + 7, j + 1] = dgvBeamDetails.Rows[i].Cells[listVisible[j].Name].Value.ToString();  // display data from cell[6A,1A]
                }
            }

            //    storing header part in Excel
            for (int i = 1; i < dgvBeamDetails.Columns.Count + 1; i++)
            {
                worksheet.Cells[6, i] = dgvBeamDetails.Columns[i - 1].HeaderText;
            }
            //     storing Each row and column value to excel sheet
            for (int i = 0; i < dgvBeamDetails.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dgvBeamDetails.Columns.Count; j++)
                {
                    worksheet.Cells[i + 7, j + 1] = dgvBeamDetails.Rows[i].Cells[j].Value.ToString();
                }
            }


            //****************************************************************************** BEAM END *******************************************************

            //****************************************************************************** YARN INWARD ****************************************************

            worksheet.Cells[8 + dgvBeamDetails.Rows.Count, 2] = "YARN INWARD DETAILS";
            List<DataGridViewColumn> listVisible1 = new List<DataGridViewColumn>();
            foreach (DataGridViewColumn col in dgvYarnInwardDetails.Columns)
            {
                if (col.Visible)
                    listVisible1.Add(col);
            }
            for (int i = 0; i < listVisible1.Count; i++)
            {
                worksheet.Cells[9 + dgvBeamDetails.Rows.Count, i + 1] = listVisible1[i].HeaderText;
            }

            for (int i = 0; i < dgvYarnInwardDetails.Rows.Count; i++)
            {
                for (int j = 0; j < listVisible1.Count; j++)
                {
                    worksheet.Cells[i + 10 + dgvBeamDetails.Rows.Count, j + 1] = dgvYarnInwardDetails.Rows[i].Cells[listVisible1[j].Name].Value.ToString();
                }
            }

            //    storing header part in Excel
            for (int i = 1; i < dgvYarnInwardDetails.Columns.Count + 1; i++)
            {
                worksheet.Cells[9 + dgvBeamDetails.Rows.Count, i] = dgvYarnInwardDetails.Columns[i - 1].HeaderText;
            }
            //     storing Each row and column value to excel sheet
            for (int i = 0; i < dgvYarnInwardDetails.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dgvYarnInwardDetails.Columns.Count; j++)
                {
                    worksheet.Cells[i + 10 + dgvBeamDetails.Rows.Count, j + 1] = dgvYarnInwardDetails.Rows[i].Cells[j].Value.ToString();
                }
            }
            //************************************************************************************* YARN INWARD END *****************************************

            //****************************************************************************** Delivery Details ****************************************************

            worksheet.Cells[12 + dgvYarnInwardDetails.Rows.Count + dgvBeamDetails.Rows.Count, 2] = "DELIVERY DETAILS";
            List<DataGridViewColumn> listVisible2 = new List<DataGridViewColumn>();
            foreach (DataGridViewColumn col in dgvDelivery.Columns)
            {
                if (col.Visible)
                    listVisible2.Add(col);
            }
            for (int i = 0; i < listVisible2.Count; i++)
            {
                worksheet.Cells[13 + dgvYarnInwardDetails.Rows.Count + dgvBeamDetails.Rows.Count, i + 1] = listVisible2[i].HeaderText;
            }

            for (int i = 0; i < dgvDelivery.Rows.Count; i++)
            {
                for (int j = 0; j < listVisible2.Count; j++)
                {
                    worksheet.Cells[i + 14 + dgvYarnInwardDetails.Rows.Count + dgvBeamDetails.Rows.Count, j + 1] = dgvDelivery.Rows[i].Cells[listVisible2[j].Name].Value.ToString();
                }
            }

            //    storing header part in Excel
            for (int i = 1; i < dgvDelivery.Columns.Count + 1; i++)
            {
                worksheet.Cells[13 + dgvYarnInwardDetails.Rows.Count + dgvBeamDetails.Rows.Count, i] = dgvDelivery.Columns[i - 1].HeaderText;
            }
            //     storing Each row and column value to excel sheet
            for (int i = 0; i < dgvDelivery.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dgvDelivery.Columns.Count; j++)
                {
                    worksheet.Cells[i + 14 + dgvYarnInwardDetails.Rows.Count + dgvBeamDetails.Rows.Count, j + 1] = dgvDelivery.Rows[i].Cells[j].Value.ToString();
                }
            }
            //************************************************************************************* DELEVERY DETAILS END *****************************************




            //****************************************************************************** weft consumption Details ****************************************************

            worksheet.Cells[19 + dgvYarnInwardDetails.Rows.Count + dgvBeamDetails.Rows.Count + dgvDelivery.Rows.Count + dgvWeightDetials.Rows.Count, 2] =
                "TOTAL WEFT CONSUMPTION";
            List<DataGridViewColumn> listVisible4 = new List<DataGridViewColumn>();
            foreach (DataGridViewColumn col in dgvWeft.Columns)
            {
                if (col.Visible)
                    listVisible4.Add(col);
            }
            for (int i = 0; i < listVisible4.Count; i++)
            {
                worksheet.Cells[20 + dgvYarnInwardDetails.Rows.Count + dgvBeamDetails.Rows.Count + dgvDelivery.Rows.Count + dgvWeightDetials.Rows.Count, i + 1] =
                    listVisible4[i].HeaderText;
            }

            for (int i = 0; i < dgvWeft.Rows.Count; i++)
            {
                for (int j = 0; j < listVisible4.Count; j++)
                {
                    worksheet.Cells[i + 21 + dgvYarnInwardDetails.Rows.Count + dgvBeamDetails.Rows.Count + dgvDelivery.Rows.Count + dgvWeightDetials.Rows.Count, j + 1] = dgvWeft.Rows[i].Cells[listVisible4[j].Name].Value.ToString();
                }
            }

            //    storing header part in Excel
            for (int i = 1; i < dgvWeft.Columns.Count + 1; i++)
            {
                worksheet.Cells[20 + dgvYarnInwardDetails.Rows.Count + dgvBeamDetails.Rows.Count + dgvDelivery.Rows.Count + dgvWeightDetials.Rows.Count, i] = dgvWeft.Columns[i - 1].HeaderText;
            }
            //     storing Each row and column value to excel sheet
            for (int i = 0; i < dgvWeft.Rows.Count - 1; i++)
            {
                //for (int j = 0; j < dgvWeft.Columns.Count; j++)
                //{
                for (int k = 0; k < listVisible4.Count; k++)
                {
                    worksheet.Cells[i + 21 + dgvYarnInwardDetails.Rows.Count + dgvBeamDetails.Rows.Count + dgvDelivery.Rows.Count + dgvWeightDetials.Rows.Count, k + 1]
                        = dgvWeft.Rows[i].Cells[k].Value.ToString();
                }
                //worksheet.Cells[i + 21 + dgvYarnInwardDetails.Rows.Count + dgvBeamDetails.Rows.Count + dgvDelivery.Rows.Count + dgvWeightDetials.Rows.Count, j + 1] 
                //= dgvWeft.Rows[i].Cells[j].Value.ToString();
                //}
            }
            //************************************************************************************* yarn consumtion DETAILS END *****************************************

            //****************************************************************************** Yarn consumption Details ****************************************************

            worksheet.Cells[15 + dgvYarnInwardDetails.Rows.Count + dgvBeamDetails.Rows.Count + dgvDelivery.Rows.Count, 2] = "TOTAL YARN WEIGHT";
            List<DataGridViewColumn> listVisible3 = new List<DataGridViewColumn>();
            foreach (DataGridViewColumn col in dgvWeightDetials.Columns)
            {
                if (col.Visible)
                    listVisible3.Add(col);
            }
            for (int i = 0; i < listVisible3.Count - 2; i++)
            {
                worksheet.Cells[16 + dgvYarnInwardDetails.Rows.Count + dgvBeamDetails.Rows.Count + dgvDelivery.Rows.Count, i + 1] = listVisible3[i].HeaderText;
            }

            for (int i = 0; i < dgvWeightDetials.Rows.Count; i++)
            {
                for (int j = 0; j < listVisible3.Count - 2; j++)
                {
                    worksheet.Cells[i + 17 + dgvYarnInwardDetails.Rows.Count + dgvBeamDetails.Rows.Count + dgvDelivery.Rows.Count, j + 1] = dgvWeightDetials.Rows[i].Cells[listVisible3[j].Name].Value.ToString();
                }
            }

            //    storing header part in Excel
            for (int i = 1; i < dgvWeightDetials.Columns.Count - 1; i++)
            {
                worksheet.Cells[16 + dgvYarnInwardDetails.Rows.Count + dgvBeamDetails.Rows.Count + dgvDelivery.Rows.Count, i] = dgvWeightDetials.Columns[i - 1].HeaderText;
            }
            //     storing Each row and column value to excel sheet
            for (int i = 0; i < dgvWeightDetials.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dgvWeightDetials.Columns.Count - 2; j++)
                {
                    worksheet.Cells[i + 17 + dgvYarnInwardDetails.Rows.Count + dgvBeamDetails.Rows.Count + dgvDelivery.Rows.Count, j + 1] = dgvWeightDetials.Rows[i].Cells[j].Value.ToString();
                }
            }
            //************************************************************************************* total yarn DETAILS END *****************************************


        }

        private void cmbPartyName_Leave(object sender, EventArgs e)
        {
            if (cmbPartyName.SelectedIndex > -1)
            {
                FillGrid(1021);
            }
            else
            {
                MessageBox.Show("Please Select Party");
            }
        }

        private void cmbQuality_Leave(object sender, EventArgs e)
        {
            if (cmbQuality.SelectedIndex > -1)
            {
                FillGrid(1022);
                FillGrid(1023);
            }
            else
            {
                MessageBox.Show("Please Select ");
            }
        }

    }
}
