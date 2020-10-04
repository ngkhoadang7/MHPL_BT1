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

        public Job getJob(int id)
        {
            Job data = JobDAL.getJob(id);
            return data;
        }

    }
}
