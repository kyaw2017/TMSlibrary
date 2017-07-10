using Amazon.DynamoDBv2;

namespace TMSLibrary.Common
{
    public abstract class DynamoDatabase
    {
        public string connectionString;
        #region Abstract Functions
        public abstract AmazonDynamoDBClient GetDBConnection();  
        #endregion
    }
}