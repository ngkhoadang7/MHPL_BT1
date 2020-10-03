using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Comment
    {
        public string id { get; set; }
        public string user_id { get; set; }
        public string job_id { get; set; }
        public string content { get; set; }
        public DateTime postTime { get; set; }
    }
}
