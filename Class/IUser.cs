using Amazon.DynamoDBv2.DocumentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSLibrary.Class
{
    public interface IUser
    {
        // interface members 
        int user_id { get; set; }
        string user_code { get; set; }
        string user_name { get; set; }
        string user_password { get; set; }
        string user_group { get; set; }
        List<Currency> cur_list { get; set; }
        bool internet_access { get; set; }
        string user_desc { get; set; } 
        List<User_Address> user_addrlist { get; set; }
    } 


    public class User_Address
    {
        public int user_addr_id { get; set; }
        public string user_addr_type { get; set; } // Single, Twin, Double, Triple, Quad, Other
        public string user_addr_1 { get; set; }
        public string user_addr_2 { get; set; }
        public string user_addr_3 { get; set; }
        public string user_airport_code { get; set; }
        public string user_post_code { get; set; }
        public string user_lon { get; set; }
        public string user_lat { get; set; }
    } 

    public class Currency
    {
        public int cur_id { get; set; }
        public string cur_code { get; set; }
        public string cur_name { get; set; }

    }

}
