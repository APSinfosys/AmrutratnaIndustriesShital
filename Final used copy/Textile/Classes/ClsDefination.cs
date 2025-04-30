

using System;
using System.Data;
using System.Configuration;
//using System.Linq;
using System.Web;
using System.IO;
//using System.Xml.Linq;
using System.Data.SqlClient;
using System.Collections;
using System.Net.NetworkInformation;
using System.Data.OleDb;
using System.Windows.Forms;
using Accounting.Classes;

public class ClsDefination : IDisposable
{

    public static int UserID = 1135;

    public static int CompanyId;
    public static int YearId;

    private static SqlConnection con = new SqlConnection();
    private static DataSet ds = null;
    private static DataTable dt = null;
    private static SqlDataReader dr = null;
    private static SqlDataAdapter da = null;
    private static SqlCommand cmd = null;
    public string ServerNM
    {
        get;
        set;
    }

    public string DatabaseNM
    {
        get;
        set;
    }

    public string UserNM
    {
        get;
        set;
    }

    public string PasswordStr
    {
        get;
        set;
    }

    public string PrinterName
    {
        get;
        set;
    }
    public string PrinterName1
    {
        get;
        set;
    }
    public string PrinterName2
    {
        get;
        set;
    }
    public static int CrystalReportNo
    {
        get;
        set;
    }
    public static int CrystalReportCriteria
    {
        get;
        set;
    }

    public ClsDefination()
    {


        //
        // TODO: Add constructor logic here
        //
    }

    ~ClsDefination()
    {
        //
        // TODO: Add destructor logic here
        //
        Dispose();
    }

    public void Dispose()
    {
        System.GC.SuppressFinalize(this);// 100 line no
    }

    public static string Str, Frm, PCM;
    //public string ServerNM
    //{
    //    get;
    //    set;
    //}

    //public string DatabaseNM
    //{
    //    get;
    //    set;
    //}

    //public string UserNM
    //{
    //    get;
    //    set;
    //}

    //public string PasswordStr
    //{
    //    get;
    //    set;
    //}
    public string MACADD
    {
        get;
        set;
    }
    public string ReportNm
    {
        get;
        set;
    }
    public string crystalpath
    {
        get;
        set;
    }

    /// <summary>
    /// Project Title:- Hotel Preeti 
    /// Project Start Date:- 02-03-2015 Time:-4:00 PM
    /// 
    /// </summary>
    public void ReportConnectionServer()
    {
        Readpath();
        ReadPrinter();

        PrinterName1 = printer1;
        PrinterName2 = printer2;

        ServerNM = server;
        //ServerNM = "JACKFRUIT-PC/JACKFRUIT2";
        DatabaseNM = database;
        UserNM = id; //"sa";
        //PasswordStr = "RNdimensionclient15";
        PasswordStr = password;
        //PasswordStr = "RNmahadevclient15";
        //PasswordStr = "";
        // PasswordStr = "RNganeshagenciesclient15";
        //  Readpath();


        //PasswordStr = "rnBALAJICLIENT11"; "RNpragatiengineeringclient15";"rns11"; 
        //"RNruchiracaterersclient15"; RNruchiraclient15 RNruchiraclient15



    }
    public static string printer1, printer2;
    public static void ReadPrinter()
    {
        try
        {
            int counter = 0;
            string line;
            int i = 0;
            string[] arr = new string[2];
            StreamReader file = new StreamReader(Application.StartupPath + "\\PrinterSetting.txt");
            while ((line = file.ReadLine()) != null)
            {
                arr[i] = line;
                Console.WriteLine(line);
                counter++;
                i++;
            }
            printer1 = arr[0].ToString();
            printer2 = arr[1].ToString();
            file.Close();
        }
        catch
        { }
    }
    static string adapterName;
    public static void adapter()
    {                              // Line no 200


        IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();

        NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
        Console.WriteLine("Interface information for {0}.{1} ",
        computerProperties.HostName, computerProperties.NodeType);


        foreach (NetworkInterface adapter in nics)
        {
            if (adapter.Id != null && adapter.Id != "")
            {
                IPInterfaceProperties properties = adapter.GetIPProperties();
                adapterName = adapter.Name.ToString();
                PCM = adapter.Id.ToString();

                return;
            }
            else
            {

            }

        }

    }

    public static string server, database, id, password;
    public static int AccessDataQueryNo;
    public static void Readpath()
    {
        try
        {
            int counter = 0;
            string line;
            int i = 0;
            string[] arr = new string[7];

            //StreamReader file = new StreamReader(@"C:\Program Files\Windows Media Player\Textile360New.txt");
            StreamReader file = new StreamReader(@"C:\Program Files\Windows Media Player\Textile360NewS.txt");
            while ((line = file.ReadLine()) != null)
            {
                arr[i] = line;
                Console.WriteLine(line);
                counter++;
                i++;
            }
            server = arr[0].ToString();
            database = arr[1].ToString();
            id = arr[2].ToString();
            password = arr[3].ToString();
            CrystalPath = arr[4].ToString();
            MAC = arr[5].ToString();
            file.Close();
        }
        catch (Exception ex)
        {

        }

    }
    //public static void Printersetting()
    //{
    //    int counter = 0;
    //    string line;
    //    int i = 0;
    //    string[] arr = new string[7];

    //    StreamReader file = new StreamReader(@"C:\Program Files\Windows Media Player\PrinterSetting.txt");
    //    while ((line = file.ReadLine()) != null)
    //    {
    //        arr[i] = line;
    //        Console.WriteLine(line);
    //        counter++;
    //        i++;
    //    }
    //  string  printername = arr[0].ToString();
    //    database = arr[1].ToString();
    //    id = arr[2].ToString();
    //    password = arr[3].ToString();
    //    CrystalPath = arr[4].ToString();
    //    MAC = arr[5].ToString();
    //    file.Close();
    //}
    public static DataTable GetM()
    {
        Readpath();

        SqlConnection con = new SqlConnection(@"Data Source=" + server + ";Initial Catalog=Login;User ID=" + id + ";Password=" + password + "");
        con.Open();
        SqlDataAdapter daM = new SqlDataAdapter("Select Address from Path where ID=1", con);
        DataTable dtM = new DataTable();
        daM.Fill(dtM);
        return dtM;

        con.Close();
    }
    //public void ConnectionServer()
    //{
    // line  no 300

    //    ServerNM =server;
    //    DatabaseNM = database;
    //    UserNM =id;
    //    PasswordStr = password;
    //    MACADD = MAC;
    //    crystalpath = CrystalPath;
    //}


    public static int i;
    public static string CrystalPath, MAC, com;

    /// <summary>
    /// ////////////////////////////////////////////////////////////
    /// </summary>
    public static string CoBackString;
    public static string strconnection;
    /////////////////////////////////////////////////////////


    public static bool openconnection()
    {
        try
        {
            if (con.State != ConnectionState.Open)
            {
                functionalDetails.superUser = "S@m@rt#";
                functionalDetails.superPassword = "$@m@rt#";
                Readpath();
                //  Printersetting();
                strconnection = string.Empty;

                //strconnection = @"Data Source=" + server + "  ;Initial Catalog=InventorySystem;User ID=sa;Password=RNganeshagenciesclient15";//RNdimensionclient15
                //strconnection = @"Data Source=" + server + "  ;Initial Catalog=InventorySystem;User ID=sa;Password=RNdimensionclient15";

                //strconnection = @"Data Source=" + server + ";Initial Catalog=InventorySystem;User ID=sa;Password=rns11";
                strconnection = @"Data Source=.;Initial Catalog=InventorySystem;Integrated Security=True";
                // strconnection = @"Data Source=" + server + ";Initial Catalog=InventorySystem;User ID=sa;Password=RNmahadevclient15";

                if (id.ToLower() == "sa")
                {
                    strconnection = @"Data Source=" + server + ";Initial Catalog=" + database + ";User ID=" + id + ";Password=" + password + "";
                }
                else
                {
                    strconnection = @"Data Source=" + server + ";Initial Catalog=" + database + ";Integrated Security=True";
                }

                //string path1= Path.GetFullPath(Environment.CurrentDirectory);
                //string db = "TextileManagement.mdf";
                // strconnection = @"Data Source=(localdb)\v11.0;AttachDbFilename="+path1+@"\"+db+";Integrated Security=True";



                con.ConnectionString = strconnection;
                con.Open();


                CoBackString = strconnection;
            }
            return true;
        }
        catch (Exception ex)
        {
            string strException = ex.Message;
            return false;
        }
    }

    public static void CloseConnection()
    {
        try
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
                con.Dispose();
            }
        }
        catch (Exception e)
        {
            String str;
            str = e.Message;
            // clsException.Publish(e);
        }
    }




    public static DataTable FillData(string ProcedureName, Hashtable hashdata)
    {
        try
        {
            //                           line no 400

            if (openconnection())
            {

                cmd = new SqlCommand(ProcedureName, con);

                cmd.CommandType = CommandType.StoredProcedure;
                IDictionaryEnumerator enumerator = hashdata.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    cmd.Parameters.AddWithValue(enumerator.Key.ToString(), enumerator.Value);
                }
                SqlParameter outputpara = new SqlParameter("@strOutputMsg", SqlDbType.VarChar, 200); //New Update
                outputpara.Direction = ParameterDirection.Output;
                //outParameter.Value = "";
                cmd.Parameters.Add(outputpara);
                cmd.ExecuteNonQuery();
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                //_transaction.Commit();
            }
        }
        catch (Exception e)
        {

            dt = new DataTable();

            dt.Columns.Clear();
            //DataTable dt = new DataTable();
            dt.Columns.Add("Error Message", typeof(string));

            DataRow dr = dt.NewRow();

            dr["Error Message"] = e.Message.ToString();


            dt.Rows.Add(dr);
        }
        finally
        {
            cmd.Dispose();
            da.Dispose();
            CloseConnection();
        }
        return dt;
    }

    //public static DataTable FillDataFromAccess(int a, string EmpCode, DateTime FromDate, DateTime ToDate)
    public static DataTable FillDataFromAccess(int a, string EmpCode, string FromDate, string ToDate)
    {
        try
        {
            DataSet ds = new DataSet();
            DataTable dtReturn2 = new DataTable();
            // string str = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\RealtimeSystemDatabase\AccessDatabase\ARMS.mdb ";
            // Jet OLEDB : Database password= arms2721954";
            string str = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Program Files\RS Solutions\Realsoft 9.2\ARMS.mdb";
            string Query = "";
            //string Query = "select ea.ECode, ea.EDate, wd.Arrtim as [InTime], wd.Deptim as [OutTime], wd.LateHrs, wd.OvTim as [Overtime], dd.Hrs as [WorkingHours], wd.LateHrs, wd.OvTim from EmpAttendance ea inner join DlyData dd on ea.ECode = dd.EmpCode  inner join weeklydetail wd on ea.ECode = wd.Empcode where wd.Empcode ='" + EmpCode + "' and wd.Present =1 and ea.EDate >'" + FromDate + "' and ea.EDate< '" + ToDate + "'";
            //string Query = "select wd.Empcode, wd.Date_trn as [Date], wd.Arrtim as [InTime], wd.Deptim as [OutTime], wd.WrkHrs as [WorkingHours], wd.LateHrs, wd.OvTim as [Overtime] from weeklydetail wd where wd.Empcode ='" + EmpCode + "' and wd.Present =1";// and wd.Date_trn >'" + FromDate + "' and wd.Date_trn< '" + ToDate + "'";


            //string Query = "SELECT wd.Empcode, wd.Date_trn AS [Date], wd.ArrTim AS InTime, wd.DepTim AS OutTime, wd.WrkHrs AS WorkingHours, wd.LateHrs, wd.OvTim AS Overtime, 0 as [EarlyHrs], sm.ShfIn, sm.ShfOut, sm.ShiftCode, wd.Present FROM ((weeklydetail wd INNER JOIN EmpMst em ON wd.Empcode = em.EmpCode) INNER JOIN ShiftMst sm ON em.FShift = sm.ShiftCode) where wd.Empcode ='" + EmpCode + "' and wd.Present =1 ";// and wd.Date_trn >'" + FromDate + "' and wd.Date_trn< '" + ToDate + "'";
            //--------------------------------------------------------------------------------------------
            //string Query = "SELECT myt.EmpCode, myt.DateTrn AS [Date], myt.ArrTim AS InTime, myt.DepTim AS OutTime, myt.WrkHrs AS WorkingHrs, myt.LateHrs, myt.OvTim AS OvertimeHrs, 0 as [EarlyHrs], sm.ShfIn AS ShiftIn, sm.ShfOut AS ShiftOut, myt.Shift AS ShiftCode, myt.PresAbs as [Present], myt.ActBreak as [LunchBrk] FROM (MmmYyyyTrn myt INNER JOIN ShiftMst sm  ON sm.ShiftCode = myt.Shift) where myt.Empcode ='" + EmpCode + "'  and (myt.DateTrn >#" + FromDate + "#) and (myt.DateTrn< #" + ToDate + "#) order by myt.DateTrn "; // and myt.Present =1 ";

            if (AccessDataQueryNo == 1)
            {
                Query = "SELECT myt.EmpCode,format( myt.DateTrn,\"MM/dd/yyyy\") AS [Date], myt.PresAbs as [Present], myt.Shift AS ShiftCode, sm.ShfIn AS ShiftIn, sm.ShfOut AS ShiftOut, myt.ArrTim AS InTime, myt.Actrt_O as LunchBrkOutTime, myt.ActBreak as[LunchBrkDuration], myt.Actrt_I as [LunchBrkInTime], myt.DepTim AS OutTime, myt.LateHrs as [LateHrs],1.1 as ExtraLunchTime, 1.1 as TotalLateHrs, myt.OvTim AS OvertimeHrs, myt.WrkHrs AS WorkingHrs FROM (MmmYyyyTrn myt INNER JOIN ShiftMst sm ON sm.ShiftCode = myt.Shift) where myt.Empcode ='" + EmpCode + "'  and (format(myt.DateTrn,\"MM/dd/yyyy\") >=#" + FromDate + "#) and (format(myt.DateTrn,\"MM/dd/yyyy\")<= #" + ToDate + "#) order by myt.DateTrn "; // and myt.Present =1 ";
            }
            else if (AccessDataQueryNo == 2)
            {
                Query = "select EmpCode, Name, 1.1 as [Basic Salary], 1.1 as [LateMark Cutting]  from EmpMst order by EmpCode";
            }
            //-------------------------------------------------------------------------------------------
            OleDbConnection con2 = new OleDbConnection(str);
            //con2.Open();
            //OleDbCommand cmd2 = new OleDbCommand(Query, con2);
            OleDbDataAdapter da = new OleDbDataAdapter(Query, con2);
            //da.Fill(dtReturn2);
            da.Fill(ds);
            //con2.Close();
            //con2.Open();
            // dtReturn2 = cmd.ExecuteNonQuery();
            dtReturn2 = ds.Tables[0];
            return dtReturn2;
        }
        catch
        {
            return null;
            //con2.Close();
        }
        finally
        {

        }
    }
    // line no 500


    public static DataSet InsertExecute(Hashtable hashdata, string ProcedureName, ref string OutputMessage, ref string OutputNo, ref Int32 OutputPKNo)
    {
        try
        {
            if (openconnection())
            {

                cmd = new SqlCommand(ProcedureName, con);

                cmd.CommandType = CommandType.StoredProcedure;
                IDictionaryEnumerator enumerator = hashdata.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    cmd.Parameters.AddWithValue(enumerator.Key.ToString(), enumerator.Value);
                }
                SqlParameter outputparaMSG = new SqlParameter("@strOutputMsg", SqlDbType.VarChar, 255);
                outputparaMSG.Direction = ParameterDirection.InputOutput;

                cmd.Parameters.Add(outputparaMSG);

                SqlParameter outputparaNO = new SqlParameter("@strOutputNo", SqlDbType.VarChar, 255);
                outputparaNO.Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add(outputparaNO);

                SqlParameter outputparaID = new SqlParameter("@intOutputPKNo", SqlDbType.Int, 32);
                outputparaID.Direction = ParameterDirection.InputOutput;

                cmd.Parameters.Add(outputparaID);

                cmd.ExecuteNonQuery();

                OutputMessage = cmd.Parameters["@strOutputMsg"].Value.ToString();
                OutputNo = cmd.Parameters["@strOutputNo"].Value.ToString();
                OutputPKNo = Convert.ToInt32(cmd.Parameters["@intOutputPKNo"].Value);
            }
        }
        catch (SqlException ex) //Exception
        {

            OutputMessage = cmd.Parameters["@strOutputMsg"].Value.ToString();
            OutputNo = cmd.Parameters["@strOutputNo"].Value.ToString();
            OutputPKNo = Convert.ToInt32(cmd.Parameters["@intOutputPKNo"].Value);
            return null;
        }
        catch (Exception ex) //Exception
        {

            OutputMessage = cmd.Parameters["@strOutputMsg"].Value.ToString();
            OutputNo = cmd.Parameters["@strOutputNo"].Value.ToString();
            OutputPKNo = Convert.ToInt32(cmd.Parameters["@intOutputPKNo"].Value);
            return null;
        }
        finally
        {
            cmd.Dispose();
            CloseConnection();
        }
        return ds;
    }
}

