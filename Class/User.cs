using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSLibrary.Class
{
    public abstract class User
    {
        public int user_id { get; set; }
        public string user_code { get; set; }
        public string user_name { get; set; }
        public string user_password { get; set; }
        public string user_group { get; set; }
        public List<Currency> cur_list { get; set; } 
        public bool internet_access { get; set; }
        public string user_desc { get; set; }
        List<User_Address> user_addrlist { get; set; }

    } 

}
