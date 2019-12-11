using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSBD.Database
{
    class Database
    {
        public static SqlConnection getConnection()
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = cnn.ConnectionString = "Server=ADMIN\\SQLEXPRESS02;Database=QuanLySanBong;User Id=admin;Password=123456;";
            return cnn;
        }  
    }
}
