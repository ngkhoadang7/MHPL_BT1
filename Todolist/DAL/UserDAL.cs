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
        public static List<User> getAllUser()
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

            sql = "SELECT * FROM users";


            cnn.Open();
            cmd = new SqlCommand(sql, cnn);
            reader = cmd.ExecuteReader();
            while (reader.HasRows)
            {
                while (reader.Read())
                {
                    User user = new User();
                    user.id = reader.GetInt32(0);
                    user.type = reader.GetInt32(1);
                    user.password = reader.GetString(2);
                    user.name = reader.GetString(3);
                    user.email = reader.GetString(4);
                    user.phone = reader.GetString(5);
                    data.Add(user);
                }
                reader.NextResult();
            }
            reader.Close();
            cmd.Dispose();
            cnn.Close();
            return data;
        }

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

        public static List<User> getAllUserExceptAdmin()
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

            sql = "SELECT * FROM users WHERE type <> 1";


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

        public static User getUser(int id)
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

            sql = "SELECT * FROM users WHERE id = " + id;


            cnn.Open();
            cmd = new SqlCommand(sql, cnn);
            reader = cmd.ExecuteReader();
            while (reader.HasRows)
            {
                while (reader.Read())
                {
                    data.id = reader.GetInt32(0);
                    data.type = reader.GetInt32(1);
                    data.password = reader.GetString(2);
                    data.name = reader.GetString(3);
                    data.email = reader.GetString(4);
                    data.phone = reader.GetString(5);
                }
                reader.NextResult();
            }
            reader.Close();
            cmd.Dispose();
            cnn.Close();
            return data;
        }
        public static bool deleteUser(int id)
        {
            SqlConnection cnn;
            SqlCommand cmd;
            string sql;

            cnn = DAL.connectDB();
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }

            sql = "DELETE FROM users WHERE id = " + id;

            try
            {
                cnn.Open();
                cmd = new SqlCommand(sql, cnn);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cnn.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool addUser(User user)
        {
            SqlConnection cnn;
            SqlCommand cmd;
            string sql;

            cnn = DAL.connectDB();
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }

            sql = "INSERT INTO users(type, password, name, email, phone)" +
                "VALUES (@type, @password, @name, @email, @phone)";

            try
            {
                cnn.Open();
                cmd = new SqlCommand(sql, cnn);

                cmd.Parameters.AddWithValue("@type", user.type);
                cmd.Parameters.AddWithValue("@password", user.password);
                cmd.Parameters.AddWithValue("@name", user.name);
                cmd.Parameters.AddWithValue("@email", user.email);
                cmd.Parameters.AddWithValue("@phone", user.phone);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cnn.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool editUser(User user)
        {
            SqlConnection cnn;
            SqlCommand cmd;
            string sql;

            cnn = DAL.connectDB();
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }

            sql = "UPDATE users SET " +
                "type = " + user.type + ", " +
                "password ='" + user.password + "', " +
                "name ='" + user.name + "', " +
                "email ='" + user.email + "', " +
                "phone ='" + user.phone + "' "+
                "WHERE id = " + user.id;

            try
            {
                cnn.Open();
                cmd = new SqlCommand(sql, cnn);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cnn.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
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

        public static bool isManager(int id)
        {
            SqlConnection cnn;
            SqlCommand cmd;
            string sql;
            SqlDataReader reader;

            cnn = DAL.connectDB();
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }

            sql = "SELECT * FROM users WHERE id=" + id + " AND type = 2 ";

            cnn.Open();
            cmd = new SqlCommand(sql, cnn);
            reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {
                reader.Close();
                cmd.Dispose();
                cnn.Close();
                return false;
            }
            else
            {
                reader.Close();
                cmd.Dispose();
                cnn.Close();
                return true;
            }
        }
    }
}
