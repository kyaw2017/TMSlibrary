using MongoDB.Driver; 

namespace TMSLibrary.Common
{
    public abstract class MongoDatabase
    {
        public string connectionString;
        #region Abstract Functions
        public abstract IMongoDatabase GetDBConnection();  
        #endregion
    }
}