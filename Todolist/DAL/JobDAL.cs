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
    public class JobDAL
    {
        public static List<Job> getAllJob()
        {
            SqlConnection cnn;
            SqlCommand cmd;
            string sql = null;
            SqlDataReader reader;
            List<Job> data = new List<Job>();

            cnn = DAL.connectDB();
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }

            sql = "SELECT * FROM jobs";

            try
            {
                cnn.Open();
                cmd = new SqlCommand(sql, cnn);
                reader = cmd.ExecuteReader();
                while (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Job job = new Job();
                        job.id = reader.GetInt32(0);
                        job.user_id = reader.GetInt32(1);
                        job.title = reader.GetString(2);
                        job.startDate = reader.GetDateTime(3);
                        job.finishDate = reader.GetDateTime(4);
                        job.status = reader.GetInt32(5);
                        job.coworker = reader.IsDBNull(reader.GetOrdinal("coworker")) ? null : reader.GetString(6);
                        job.privacy = reader.GetInt32(7);
                        job.attach = reader.IsDBNull(reader.GetOrdinal("attach")) ? null : reader.GetString(8);
                        data.Add(job);
                    }
                    reader.NextResult();
                }
                reader.Close();
                cmd.Dispose();
                cnn.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Can not open connection!");
            }
            return data;
        }

        public static Job getJob(int id)
        {
            SqlConnection cnn;
            SqlCommand cmd;
            string sql = null;
            SqlDataReader reader;
            Job data = new Job();

            cnn = DAL.connectDB();
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }

            sql = "SELECT * FROM jobs WHERE id = "+ id.ToString();

            try
            {
                cnn.Open();
                cmd = new SqlCommand(sql, cnn);
                reader = cmd.ExecuteReader();
                while (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        data.id = reader.GetInt32(0);
                        data.user_id = reader.GetInt32(1);
                        data.title = reader.GetString(2);
                        data.startDate = reader.GetDateTime(3);
                        data.finishDate = reader.GetDateTime(4);
                        data.status = reader.GetInt32(5);
                        data.coworker = reader.IsDBNull(reader.GetOrdinal("coworker")) ? null : reader.GetString(6);
                        data.privacy = reader.GetInt32(7);
                        data.attach = reader.IsDBNull(reader.GetOrdinal("attach")) ? null : reader.GetString(8);
                    }
                    reader.NextResult();
                }
                reader.Close();
                cmd.Dispose();
                cnn.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Can not open connection!");
            }
            return data;
        }

        public void addJob(Job job)
        {
            SqlConnection cnn;
            SqlCommand cmd;
            string sql = null;

            cnn = DAL.connectDB();
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }

            sql = "INSERT INTO jobs(user_id, title, startDate, finishDate, status, coworker, privacy, attach)" +
                "VALUES (@user_id, @title, @startDate, @finishDate, @status, @coworker, @privacy, @attach)";

            try
            {
                cnn.Open();
                cmd = new SqlCommand(sql, cnn);

                cmd.Parameters.AddWithValue("@user_id", job.user_id);
                cmd.Parameters.AddWithValue("@title", job.title);
                cmd.Parameters.AddWithValue("@startDate", job.startDate);
                cmd.Parameters.AddWithValue("@finishDate", job.finishDate);
                cmd.Parameters.AddWithValue("@status", job.status);
                cmd.Parameters.AddWithValue("@coworker", job.coworker);
                cmd.Parameters.AddWithValue("@privacy", job.privacy);
                cmd.Parameters.AddWithValue("@attach", job.attach);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cnn.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Can not open connection!");
            }
        }
    }
}
