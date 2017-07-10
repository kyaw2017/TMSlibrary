using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel; 
using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using TMSLibrary.Common; 

namespace TMSLibrary.Class
{
    [System.ComponentModel.DataAnnotations.Schema.Table("Location")]
    public class Location : AbstractLocation
    {
        public override IEnumerable<LocationDataSet> GetListByQuery(int scanLimit)
        { 
            IAmazonDynamoDB DynamoDBclient = DynamoDatabaseFactory.GetDBConnection();
            List<LocationDataSet> LocationDataSetList = new List<LocationDataSet>();
            Dictionary<string, AttributeValue> lastKeyEvaluated = null;
            int PgNumber = 0;
            do
            { 
                var request = new ScanRequest
                {
                    TableName = "Location",
                    Limit = scanLimit,
                    ExclusiveStartKey = lastKeyEvaluated
                };

                var response = DynamoDBclient.Scan(request);
                lastKeyEvaluated = response.LastEvaluatedKey;
                LocationDataSet objLocationDataSet = new LocationDataSet();  
                PgNumber += 1;
                objLocationDataSet.pageNumber = PgNumber;
                objLocationDataSet.lst = LocationItems(response.Items);
                LocationDataSetList.Add(objLocationDataSet); 

            } while (lastKeyEvaluated != null && lastKeyEvaluated.Count != 0);

            IEnumerable<LocationDataSet> results = LocationDataSetList;

            return results; 
        }
        private static List<Location> LocationItems(
           List<Dictionary<string, AttributeValue>> items)
        {
            List<Location> LocationList = new List<Location>();

            foreach (Dictionary<string, AttributeValue> item
      in items)
            { 
                string localityCode = "";
                string locationCode = "";
                string destCode = "";
                string countryCode = "";
                string locationName = "";
                string localityDesc = "";
                string destDesc = "";
                string countryDesc = ""; 
                foreach (KeyValuePair<string, AttributeValue> kvp in item)
                {
                    string attributeName = kvp.Key;
                    AttributeValue value = kvp.Value;

                    switch (attributeName)
                    {
                        case "locality_code": { localityCode = value.S; break; }
                        case "location_code": { locationCode = value.S; break; }
                        case "dest_code": { destCode = value.S; break; }
                        case "country_code": { countryCode = value.S; break; }
                        case "location_name": { locationName = value.S; break; }
                        case "locality_desc": { localityDesc = value.S; break; }
                        case "dest_desc": { destDesc = value.S; break; }
                        case "country_desc": { countryDesc = value.S; break; }
                    }

                }

                Location objLocation = new Location(); 
                objLocation.locality_code = localityCode;
                objLocation.location_code = locationCode;
                objLocation.dest_code = destCode;
                objLocation.country_code = countryCode;
                objLocation.location_name = locationName;
                objLocation.locality_desc = localityDesc;
                objLocation.dest_desc = destDesc;
                objLocation.country_desc = countryDesc;  
                LocationList.Add(objLocation);
            } 
            return LocationList;
        }
         
        public override IEnumerable<Location> GetListAll()
        {
            IEnumerable<Location> result = null; 
                IAmazonDynamoDB DynamoDBclient = DynamoDatabaseFactory.GetDBConnection();
                DynamoDBContext DynamoDBContext = new DynamoDBContext(DynamoDBclient); 
                result = DynamoDBContext.Scan<Location>().ToList(); 
            return result;
        }

        public override String Insert(Location loc)
        {
            string result = "";
            try
            { 
                IAmazonDynamoDB DynamoDBclient = DynamoDatabaseFactory.GetDBConnection();
                DynamoDBContext DynamoDBContext = new DynamoDBContext(DynamoDBclient);  
                DynamoDBContext.Save<Location>(loc);
                result = Newtonsoft.Json.JsonConvert.SerializeObject(loc);
            }
            catch (AmazonDynamoDBException e)
            {
                result = "{'ErrorCode :'" + e.ErrorCode + ",'ErrorMessage': '" + string.Concat("Exception while deleting a record in DynamoDb table: {0}", e.Message) + "'}";
            }
            return result;
        }

        public override String Update(Location loc)
        {
            string result = "";
            try
            {
                IAmazonDynamoDB DynamoDBclient = DynamoDatabaseFactory.GetDBConnection();
                DynamoDBContext DynamoDBContext = new DynamoDBContext(DynamoDBclient); 
                DynamoDBContext.Save<Location>(loc);
                result = Newtonsoft.Json.JsonConvert.SerializeObject(loc);
            }
            catch (AmazonDynamoDBException e)
            {
                result = "{'ErrorCode :'" + e.ErrorCode + ",'ErrorMessage': '" + string.Concat("Exception while deleting a record in DynamoDb table: {0}", e.Message) + "'}";
            }
            return result;
        }
        public override String Delete(Location loc)
        {
            string result = "";
            try
            {
                IAmazonDynamoDB DynamoDBclient = DynamoDatabaseFactory.GetDBConnection();
                DynamoDBContext DynamoDBContext = new DynamoDBContext(DynamoDBclient); 
                DynamoDBContext.Delete<Location>(loc);
                result = Newtonsoft.Json.JsonConvert.SerializeObject(loc); 
            }
            catch (AmazonDynamoDBException e)
            {
                result = "{'ErrorCode :'" + e.ErrorCode + ",'ErrorMessage': '" + string.Concat("Exception while deleting a record in DynamoDb table: {0}", e.Message) + "'}" ;
            }
            return result;
        } 

    } 

}
