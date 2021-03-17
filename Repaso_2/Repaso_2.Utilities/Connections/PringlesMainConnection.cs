using Repaso_2.Utilities.Const;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso_2.Utilities.Connections
{
    public static class PringlesMainConnection
    {
        public static IDbConnection GetDbConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings[Connection.PRINGLES_DB].ConnectionString;
            return new SqlConnection(connectionString);
        }
    }
}
