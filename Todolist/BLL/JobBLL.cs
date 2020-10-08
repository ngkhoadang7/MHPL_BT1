using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using DAL;

namespace BLL
{
    public class JobBLL
    {
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

        public Job getJob(int id)
        {
            Job data = JobDAL.getJob(id);
            return data;
        }
        
        public static void addJob(Job job)
        {
            JobDAL.addJob(job);
        }
        public static void editJob(Job job)
        {
            JobDAL.editJob(job);
        }
    }
}
