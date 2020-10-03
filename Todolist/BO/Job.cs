using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Job
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public string title { get; set; }
        public DateTime startDate { get; set; }
        public DateTime finishDate { get; set; }
        public int status { get; set; }
        public string coworker { get; set; }
        public int privacy { get; set; }
        public string attach { get; set; }

        public Job() { }

        public Job(int user_id, string title, DateTime startDate, DateTime finishDate, int status, string coworker, int privacy , string attach)
        {
            this.user_id = user_id;
            this.title = title;
            this.startDate = startDate;
            this.finishDate = finishDate;
            this.status = status;
            this.coworker = coworker;
            this.privacy = privacy;
            this.attach = attach;
        }

    }
}
