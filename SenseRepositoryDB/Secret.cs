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
                return "Data Source=mssql15.unoeuro.com;Initial Catalog=lntech_dk_db_sensemax;User ID=lntech_dk;Password=trEG49cf2A3FBRxp5ygz;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
            }
        }
    }
}
