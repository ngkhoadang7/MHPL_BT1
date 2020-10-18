using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using DAL;

namespace BLL
{
    public class JobBLL
    {
        public static bool CheckFileType(string fileName)
        {

            string ext = Path.GetExtension(fileName);
            switch (ext.ToLower())
            {
                case ".doc":
                case ".docm":
                case ".docx":
                case ".pdf":
                case ".txt":
                case ".ppt":
                case ".pptx":
                case ".xlsx":
                case ".xls":
                    return true;
                default:
                    return false;
            }
        }

        public static string GenerateNameFile(string fileName)
        {
            int lastDotIndex = fileName.LastIndexOf(".");
            string ext = fileName.Substring(lastDotIndex + 1);
            string name = fileName.Substring(0,lastDotIndex);
            return name + "_" + DateTime.Now.ToString("ddMMyyyy-hhmmss-tt.")+ext;
        }

        public static void deleteFile(string fileName)
        {
            string rootFolder = @"C:\Users\vinni\source\repos\MHPL_BT1\Todolist\Todolist\File\";
            try
            {
                // Check if file exists with its full path    
                if (File.Exists(Path.Combine(rootFolder, fileName)))
                {
                    // If file found, delete it    
                    File.Delete(Path.Combine(rootFolder, fileName));
                    Console.WriteLine("File deleted.");
                }
                else Console.WriteLine("File not found");
            }
            catch (IOException ioExp)
            {
                Console.WriteLine(ioExp.Message);
            }
        }

        public List<Job> getAllJob()
        {
            List<Job> data = JobDAL.getAllJob();
            return data;
        }

        public List<Job> getAllJobForStaff(int id)
        {
            List<Job> data = JobDAL.getAllJobForStaff(id);
            return data;
        }

        public static Job getJob(int id)
        {
            Job data = JobDAL.getJob(id);
            return data;
        }
        
        public static bool addJob(Job job)
        {
            return JobDAL.addJob(job);
        }
        public static bool editJob(Job job)
        {
            return JobDAL.editJob(job);
        }
        public static bool deleteJob(int id)
        {
            string fileName = JobDAL.getFileName(id);
            if (JobDAL.deleteJob(id)){
                
                if(fileName != null)
                    deleteFile(fileName);

                return true;
            } 
            else
            {
                return false;
            }
        }

        public static bool canAccess(int userID, int jobID)
        {
            return JobDAL.canAccess(userID, jobID);
        }

        public static bool isPublic(int id)
        {
            return JobDAL.isPublic(id);
        }
    }
}
