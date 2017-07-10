using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using TMSLibrary.Common;

namespace TMSLibrary.Class
{
    [System.ComponentModel.DataAnnotations.Schema.Table("Creditor")]
    public class Creditor : AbstractCreditor
    {
        public override String GetListByQuery(ScanFilter scanfilter) {
            string result = "";
            try
            {
                IAmazonDynamoDB DynamoDBclient = DynamoDatabaseFactory.GetDBConnection();
                DynamoDBContext DynamoDBContext = new DynamoDBContext(DynamoDBclient);

                string tableName = this.GetType().Name;
                Table CreditorTable = Table.LoadTable(DynamoDBclient, tableName); 
                //scanFilter.AddCondition("user_name", ScanOperator.Contains, "sortkey");

                Search search = CreditorTable.Scan(scanfilter);
                List<Document> documentList = new List<Document>();
                do
                {
                    documentList = search.GetNextSet();  
                } while (!search.IsDone);

                var docList = documentList as List<Document>;
                    result = Newtonsoft.Json.JsonConvert.SerializeObject(documentList);
            }
            catch (AmazonDynamoDBException e)
            {
                result = "{'ErrorCode :'" + e.ErrorCode + ",'ErrorMessage': '" + string.Concat("Exception while deleting a record in DynamoDb table: {0}", e.Message) + "'}";
            }
            return result;
        } 

        public override String GetListAll()
        {
            string result = "";
            try
            {
                IAmazonDynamoDB DynamoDBclient = DynamoDatabaseFactory.GetDBConnection();
                DynamoDBContext DynamoDBContext = new DynamoDBContext(DynamoDBclient); 
            //--------------- Search 1 ----------------
                List<Creditor> CreditorList = DynamoDBContext.Scan<Creditor>().ToList();
                result = Newtonsoft.Json.JsonConvert.SerializeObject(CreditorList); 
            }
            catch (AmazonDynamoDBException e)
            {
                result = "{'ErrorCode :'" + e.ErrorCode + ",'ErrorMessage': '" + string.Concat("Exception while deleting a record in DynamoDb table: {0}", e.Message) + "'}";
            }
            return result;
            //List<Creditor> Sup_Supplierlist2 = DynamoDBContext.Query<Creditor>(user_name, QueryOperator.BeginsWith, new object[] { user_name }, operationConfig).OrderByDescending(o => o.OrderIssueDate).ToList();




            //while (!queryFilterSearch.IsDone)
            //{
            //   List<Creditor> Sup_Supplierlist2 = queryFilterSearch.GetNextSet().ToList();
            //}

            //List<Creditor> Sup_Supplierlist2 = DynamoDBContext.Query<Creditor>(queryConfig).OrderByDescending(o => o.user_id).ToList();
            //--------------- Search 1 ---------------- 

            //        var request = new QueryRequest
            //        {
            //            TableName = "Creditor",
            //            KeyConditionExpression = "user_id = :v_user_id",
            //            ExpressionAttributeValues = new Dictionary<string, AttributeValue> {
            //    {":v_user_id", new AttributeValue { N =  "817" }} //,
            //    //{":v_user_code", new AttributeValue {  S =  "RBTBKK" }}
            //},
            //            ProjectionExpression = "user_id, user_code"

            //        };

            //var response = DynamoDBclient.Query(request);

            //foreach (Dictionary<string, AttributeValue> item in response.Items)
            //{ 
            //    PrintItem(item);
            //}

            //Dictionary<string, AttributeValue> lastKeyEvaluated = null;
            //do
            //{
            //    var request = new ScanRequest
            //    {
            //        TableName = "Creditor",
            //        //Limit = 2,
            //        ExclusiveStartKey = lastKeyEvaluated,
            //        ExpressionAttributeValues = new Dictionary<string, AttributeValue> {
            //        {":val", new AttributeValue {
            //             S = "ZENBKK"
            //         }}
            //    },
            //        FilterExpression = "user_code = :val",

            //        ProjectionExpression = "user_id, user_code, user_name, user_password, curlist, internet_access, user_desc"
            //    };

            //    var response = DynamoDBclient.Scan(request);
            //    var var1 = response.Items[0];
            //    lastKeyEvaluated = response.LastEvaluatedKey;
            //} while (lastKeyEvaluated != null && lastKeyEvaluated.Count != 0);

            //List<Creditor> Sup_Supplierlist2 = lastKeyEvaluated.ToList(); 
        }

        public override String Insert(Creditor creditor)
        {
            string result = "";
            try
            { 
                IAmazonDynamoDB DynamoDBclient = DynamoDatabaseFactory.GetDBConnection();
                DynamoDBContext DynamoDBContext = new DynamoDBContext(DynamoDBclient);  
                DynamoDBContext.Save<Creditor>(creditor);
                result = Newtonsoft.Json.JsonConvert.SerializeObject(creditor);
            }
            catch (AmazonDynamoDBException e)
            {
                result = "{'ErrorCode :'" + e.ErrorCode + ",'ErrorMessage': '" + string.Concat("Exception while deleting a record in DynamoDb table: {0}", e.Message) + "'}";
            }
            return result;
        }

        public override String Update(Creditor creditor)
        {
            string result = "";
            try
            {
                IAmazonDynamoDB DynamoDBclient = DynamoDatabaseFactory.GetDBConnection();
                DynamoDBContext DynamoDBContext = new DynamoDBContext(DynamoDBclient); 
                DynamoDBContext.Save<Creditor>(creditor);
                result = Newtonsoft.Json.JsonConvert.SerializeObject(creditor);
            }
            catch (AmazonDynamoDBException e)
            {
                result = "{'ErrorCode :'" + e.ErrorCode + ",'ErrorMessage': '" + string.Concat("Exception while deleting a record in DynamoDb table: {0}", e.Message) + "'}";
            }
            return result;
        }
        public override String Delete(Creditor creditor)
        {
            string result = "";
            try
            {
                IAmazonDynamoDB DynamoDBclient = DynamoDatabaseFactory.GetDBConnection();
                DynamoDBContext DynamoDBContext = new DynamoDBContext(DynamoDBclient); 
                DynamoDBContext.Delete<Creditor>(creditor);
                result = Newtonsoft.Json.JsonConvert.SerializeObject(creditor); 
            }
            catch (AmazonDynamoDBException e)
            {
                result = "{'ErrorCode :'" + e.ErrorCode + ",'ErrorMessage': '" + string.Concat("Exception while deleting a record in DynamoDb table: {0}", e.Message) + "'}" ;
            }
            return result;
        } 

    } 
}
