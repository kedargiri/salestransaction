using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SalesTransaction.Application.DataAccessLayer
{
    public class ConnectionClass
    {
        public static string ConnectionString
        {
            get { return System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; }
        }


    }
}
