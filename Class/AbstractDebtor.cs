using System;
using System.Collections.Generic; 
using System.ComponentModel.DataAnnotations.Schema;
using Amazon.DynamoDBv2.DocumentModel;

namespace TMSLibrary.Class
{
    public abstract class AbstractDebtor : IUser
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int user_id { get; set; }
        public string user_code { get; set; }
        public string user_name { get; set; }
        public string user_password { get; set; }
        public string user_group { get; set; }
        public List<Currency> cur_list { get; set; }
        public bool internet_access { get; set; }
        public string user_desc { get; set; }
        public List<User_Address> user_addrlist { get; set; }
        public enum QueryType { user_id = 1, user_code = 2, user_name = 3 };
        public abstract String GetListAll();
        public abstract String GetListByQuery(ScanFilter scanfilter);
        public abstract String Insert(Debtor debtor);
        public abstract String Update(Debtor debtor);
        public abstract String Delete(Debtor debtor);
    }
      
}
