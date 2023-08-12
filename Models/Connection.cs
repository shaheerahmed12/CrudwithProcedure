using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace crud2.Models
{
    public class Connection
    {
        private static string s = ConfigurationManager.ConnectionStrings["Connect"].ConnectionString;
        public SqlConnection con = new SqlConnection(s);
    }
}
