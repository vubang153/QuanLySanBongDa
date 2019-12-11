using QLSBD.Class;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLSBD.Commons;

namespace QLSBD.Database
{
    class tblUser
    {

        public int checkLoginAdmin(clAdmin admin)
        {
            String sqlQuery = "select * from dbo.admin where admin.username='" + admin.Username + "' and admin.password='" + admin.Password + "'";
            SqlConnection cnn = Database.getConnection();
            cnn.Open();
            SqlCommand cmd = new SqlCommand(sqlQuery, cnn);
            SqlDataReader data = cmd.ExecuteReader();
            if (data.Read() == true)
            {
                return DB_QUERY.OK;
            }
            else
            {
                return DB_QUERY.NO_RESULTS;
            }
        }
    }
}
