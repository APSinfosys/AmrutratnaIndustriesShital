using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Classes
{
    class functionalDetails
    {
        public static int userId;
        public static int yearId;
        public static int compId;
        public static int stateId;
        public static string userName;
        public static string yearString;
        public static string companyNameStr;
        public static string loginType;
        public static string superUser;
        public static string superPassword;
        public static DateTime endDate;
        public static DateTime startDate;
        public static string shortYear;
       
        
        

        public string ShortYear
        {
            get { return shortYear; }
            set { shortYear = value; }

        }

        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }

        }

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }

        }

        public int StateId
        {
            get { return stateId; }
            set { stateId = value; }

        }

        public string SuperUser
        {
            get { return superUser; }
            set { superUser = value; }
                
        }

        public string SuperPassword
        {
            get { return SuperPassword; }
            set { superPassword = value; }
        }

        public string LoginType
        {
            get { return loginType; }
            set { loginType = value; }
        }
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public string YearString
        {
            get { return yearString; }
            set { yearString = value; }
        }
        public string CompanyNameStr 
        {
            get { return companyNameStr; }
            set { companyNameStr = value; }
        }
        public int UserId 
        {
            get { return userId; }
            set{ userId = value; }
        } 
        public int CompId 
        {
            get { return compId; }
            set { compId = value; }
        } 
        public int YearId 
        {
            get{return yearId;}
            set{yearId = value;}
        
        }

        public string supDetailsU()
        {
            superUser = "s@m@rt#";
            return superUser;
        }
        public string supDetailsP()
        {
            
            superPassword = "S@m@rt#143";
            return superPassword;
        }
    }
}
