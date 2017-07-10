using System;
using System.Collections.Generic; 
using System.ComponentModel.DataAnnotations.Schema;
using Amazon.DynamoDBv2.DocumentModel;
using TMSLibrary.Common;
using Amazon.DynamoDBv2.Model;

namespace TMSLibrary.Class
{
    public abstract class AbstractLocation
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)] 
        public string locality_code { get; set; }
        public string location_code { get; set; }
        public string dest_code { get; set; }
        public string country_code { get; set; }
        public string location_name { get; set; }
        public string locality_desc { get; set; } 
        public string dest_desc { get; set; }
        public string country_desc { get; set; }
        public abstract IEnumerable<Location> GetListAll();
        public abstract IEnumerable<LocationDataSet> GetListByQuery(int scanLimit);
        public abstract String Insert(Location loc);
        public abstract String Update(Location loc);
        public abstract String Delete(Location loc);
    }  
}
