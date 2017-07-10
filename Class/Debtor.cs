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
    [System.ComponentModel.DataAnnotations.Schema.Table("Debtor")]
    public class Debtor : AbstractDebtor
    { 
        public override String GetListByQuery(ScanFilter scanfilter)
        { 
            IAmazonDynamoDB DynamoDBclient = DynamoDatabaseFactory.GetDBConnection();
            DynamoDBContext DynamoDBContext = new DynamoDBContext(DynamoDBclient);
            List<Debtor> Debtorlist = DynamoDBContext.Scan<Debtor>().ToList();
            return "";
        }

        public override String GetListAll()
        {
            IAmazonDynamoDB DynamoDBclient = DynamoDatabaseFactory.GetDBConnection();
            DynamoDBContext DynamoDBContext = new DynamoDBContext(DynamoDBclient);

            //--------------- Search 1 ----------------
            List<Debtor> Debtorlist = DynamoDBContext.Scan<Debtor>().ToList(); 
            String Deb_DebtorList = Newtonsoft.Json.JsonConvert.SerializeObject(Debtorlist);
            return Deb_DebtorList;
        }




        public override String Insert(Debtor debtor)
        {
            IAmazonDynamoDB DynamoDBclient = DynamoDatabaseFactory.GetDBConnection();
            DynamoDBContext DynamoDBContext = new DynamoDBContext(DynamoDBclient);  
            DynamoDBContext.Save<Debtor>(debtor);
            String Sup_DebtorList = Newtonsoft.Json.JsonConvert.SerializeObject(debtor);
            return Sup_DebtorList;
        } 

        public override String Update(Debtor debtor) {
            return "";
        }
        public override String Delete(Debtor debtor)
        {
            return "";
        }
    } 
}
