using System;
using System.Collections.Generic; 
using System.ComponentModel.DataAnnotations.Schema;
using Amazon.DynamoDBv2.DocumentModel;

namespace TMSLibrary.Class
{
    public abstract class AbstractCreditor : IUser
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)] 

        public int user_id { get; set; }
        public string user_code { get; set; }
        public string user_name { get; set; }
        public string user_password { get; set; }
        public string user_group { get; set; }
        public List<Currency> cur_list { get; set; }
        public Boolean internet_access { get; set; }
        public string user_desc { get; set; }
        public List<User_Address> user_addrlist { get; set; }
        public Boolean sup_pick_up_status { get; set; }
        public Boolean sup_overwrite_policy_status { get; set; }
        public Boolean sup_cross_season_rate { get; set; } // Use First Rate, Use Average Rate, Split Service, Not Allowed
        public enum QueryType { user_id = 1, user_code = 2, user_name = 3 };
        public List<Service_Point> service_pointlist { get; set; }
        public List<Amenities> amenitieslist { get; set; }
        public List<Sup_Room_Policy> sup_room_policylist { get; set; }
        public List<Sup_Age_Policy> sup_age_policylist { get; set; }
        public List<Sup_Stay_Start_On> sup_stay_start_onlist { get; set; }
        public List<Sup_Stay_Must_Include> Sup_Stay_Must_Includelist { get; set; }
        public abstract String GetListAll();
        public abstract String GetListByQuery(ScanFilter scanfilter);
        public abstract String Insert(Creditor creditor);
        public abstract String Update(Creditor creditor);
        public abstract String Delete(Creditor creditor);
    } 

    public class Service_Point
    {
        public int sp_id { get; set; }
        public string sp_code { get; set; }
        public string sp_location { get; set; }
        public string sp_long { get; set; }
        public string sp_lat { get; set; }
    }

    public class Amenities
    {
        public int am_id { get; set; }
        public string am_code { get; set; }
        public string am_desc { get; set; }
    }

    public class Sup_Room_Policy
    {
        public int sup_rp_id { get; set; }
        public string sup_rp_cat { get; set; } // Single, Twin, Double, Triple, Quad, Other
        public int sup_rp_max_adult { get; set; }
        public int sup_rp_max_adult_child { get; set; }
    }
    public class Sup_Age_Policy
    {
        public int sup_ap_id { get; set; }
        public string sup_ap_cat { get; set; } // Infant, Child, Adult
        public int sup_ap_min_age { get; set; } // Minimum Age Limit
        public int sup_ap_max_age { get; set; } // Maximum Age Limit
    }

    public class Sup_Stay_Start_On
    {
        public int sup_stay_start_id { get; set; }
        public string sup_stay_day { get; set; } // Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
    }
    public class Sup_Stay_Must_Include
    {
        public int sup_stay_include_id { get; set; }
        public string sup_stay_include_day { get; set; } // Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
    }
}
