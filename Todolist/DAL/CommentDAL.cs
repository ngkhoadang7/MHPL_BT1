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
    public class CommentDAL
    {
        public static List<Comment> getAllCommentOfJob(int jobID)
        {
            SqlConnection cnn;
            SqlCommand cmd;
            string sql;
            SqlDataReader reader;
            List<Comment> data = new List<Comment>();

            cnn = DAL.connectDB();
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }

            sql = "SELECT * FROM comments WHERE job_id = "+ jobID;


            cnn.Open();
            cmd = new SqlCommand(sql, cnn);
            reader = cmd.ExecuteReader();
            while (reader.HasRows)
            {
                while (reader.Read())
                {
                    Comment cmt = new Comment();
                    cmt.id = reader.GetInt32(0);
                    cmt.user_id = reader.GetInt32(1);
                    cmt.job_id = reader.GetInt32(2);
                    cmt.content = reader.GetString(3);
                    cmt.postTime = reader.GetDateTime(4);
                    data.Add(cmt);
                }
                reader.NextResult();
            }
            reader.Close();
            cmd.Dispose();
            cnn.Close();
            return data;
        }

        public static bool canEditComment(int cmtID, int userID)
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

            sql = "SELECT * FROM comments WHERE id = " + cmtID + " AND user_id = " + userID;

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

        public static Comment getComment(int id)
        {
            SqlConnection cnn;
            SqlCommand cmd;
            string sql;
            SqlDataReader reader;
            Comment data = new Comment();

            cnn = DAL.connectDB();
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }

            sql = "SELECT * FROM comments WHERE id = " + id;


            cnn.Open();
            cmd = new SqlCommand(sql, cnn);
            reader = cmd.ExecuteReader();
            while (reader.HasRows)
            {
                while (reader.Read())
                {
                    data.id = reader.GetInt32(0);
                    data.user_id = reader.GetInt32(1);
                    data.job_id = reader.GetInt32(2);
                    data.content = reader.GetString(3);
                    data.postTime = reader.GetDateTime(4);
                }
                reader.NextResult();
            }
            reader.Close();
            cmd.Dispose();
            cnn.Close();
            return data;
        }

        public static bool addComment(Comment cmt)
        {
            SqlConnection cnn;
            SqlCommand cmd;
            string sql;

            cnn = DAL.connectDB();
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }

            sql = "INSERT INTO comments( user_id, job_id, content, postTime)" +
                "VALUES (@user_id, @job_id, @content, @postTime)";

            try
            {
                cnn.Open();
                cmd = new SqlCommand(sql, cnn);

                cmd.Parameters.AddWithValue("@user_id", cmt.user_id);
                cmd.Parameters.AddWithValue("@job_id", cmt.job_id);
                cmd.Parameters.AddWithValue("@content", cmt.content);
                cmd.Parameters.AddWithValue("@postTime", cmt.postTime);

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
        public static bool deleteComment(int id)
        {
            SqlConnection cnn;
            SqlCommand cmd;
            string sql;

            cnn = DAL.connectDB();
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }

            sql = "DELETE FROM comments WHERE id = " + id;

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

        public static bool editComment(Comment cmt)
        {
            SqlConnection cnn;
            SqlCommand cmd;
            string sql;

            cnn = DAL.connectDB();
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }

            sql = "UPDATE comments SET " +
                "content ='" + cmt.content + "' " +
                "WHERE id = " + cmt.id;

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
    }
}
