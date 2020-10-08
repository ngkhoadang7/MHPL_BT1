using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;

namespace DAL
{
    public class UserDAL
    {
        public static List<User> getAllUserExceptMe(int id)
        {
            SqlConnection cnn;
            SqlCommand cmd;
            string sql;
            SqlDataReader reader;
            List<User> data = new List<User>();

            cnn = DAL.connectDB();
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }

            sql = "SELECT * FROM users WHERE id <> " + id + " AND type <> 1";


            cnn.Open();
            cmd = new SqlCommand(sql, cnn);
            reader = cmd.ExecuteReader();
            while (reader.HasRows)
            {
                while (reader.Read())
                {
                    User user = new User();
                    user.id = reader.GetInt32(0);
                    user.name = reader.GetString(3);
                    data.Add(user);
                }
                reader.NextResult();
            }
            reader.Close();
            cmd.Dispose();
            cnn.Close();
            return data;
        }

        public static User login(string email, string password)
        {
            SqlConnection cnn;
            SqlCommand cmd;
            string sql;
            SqlDataReader reader;
            User data = new User();

            cnn = DAL.connectDB();
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }

            sql = "SELECT id, type, name FROM users WHERE email='" +email+ "' AND password='"+ password +"'";

            cnn.Open();
            cmd = new SqlCommand(sql, cnn);
            reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {
                return null;
            } 
            else
                while (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        data.id = reader.GetInt32(0);
                        data.type = reader.GetInt32(1);
                        data.name = reader.GetString(2);
                    }
                    reader.NextResult();
                }
            reader.Close();
            cmd.Dispose();
            cnn.Close();
            return data;
        }
    }
}
