using System;
using System.Configuration;
using Amazon.DynamoDBv2; 

namespace TMSLibrary.Common
{
    public sealed class DynamoDatabaseFactory
    {
        public static bool IsSSL { get; set; }
        public static DynamoDatabaseFactorySectionHandler sectionHandler = (DynamoDatabaseFactorySectionHandler)ConfigurationManager.GetSection("DBFactoryConfig");
        private DynamoDatabaseFactory() { } 
        public static AmazonDynamoDBClient GetDBConnection() {
            if ((sectionHandler.Name.Length == 0)){

                throw new Exception("Database name not defined in DatabaseFactoryConfiguration section of web.config.");
            }

            try {

                var ddbConfig = new AmazonDynamoDBConfig
                {
                    ServiceURL = sectionHandler.ConnectionString
                };

                var dynamoDBClient = new AmazonDynamoDBClient("AKIAJ6C6YMZFKWPZ5N2A", "laxECzE0W8Ay1+IxnC8BLv/0uoW+FVQ7FbApoT14", ddbConfig);
               
                return dynamoDBClient;
            }
            catch (Exception excep)
            {
                throw new Exception("Error instantiating database " + sectionHandler.Name + ". " + excep.Message);
            }
        }
    }
}