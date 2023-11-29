using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenseRepositoryDB
{
    public class Secret
    {
        public static string GetConnectionString
        {
            get
            {
                return "Data Source=mssql9.unoeuro.com;User ID=lntech_dk;Password=trEG49cf2A3FBRxp5ygz;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            }
        }
    }
}
