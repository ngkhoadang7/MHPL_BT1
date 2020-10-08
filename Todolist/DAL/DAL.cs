using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class DAL
    {
        public static SqlConnection cnn;
        public static SqlConnection connectDB()
        {
            string cnnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            cnn = new SqlConnection(cnnString);
            //cnn = new SqlConnection("Data Source=VINNE-LAP\\SQLEXPRESS;Initial Catalog=DB_Todolist;Integrated Security=True");
            return cnn;
        }
    }
}
