using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public int type { get; set; }
        public string phone { get; set; }


        public User() { }

        public User(int id, string name, string password, string email, int type, string phone)
        {
            this.id = id;
            this.name = name;
            this.password = password;
            this.email = email;
            this.type = type;
            this.phone = phone;
        }
    }
}
