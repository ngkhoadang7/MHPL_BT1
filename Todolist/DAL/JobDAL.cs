﻿using System;
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
    }
}