using System; 
using System.Configuration;
using MongoDB.Driver;

namespace TMSLibrary.Common
{
    public sealed class MongoDatabaseFactory
    {
        public static bool IsSSL { get; set; }
        public static MongoDatabaseFactorySectionHandler sectionHandler = (MongoDatabaseFactorySectionHandler)ConfigurationManager.GetSection("DBFactoryConfig");
        private MongoDatabaseFactory() { }
        private IMongoDatabase _database { get; }
        public static IMongoDatabase GetDBConnection() {
            if ((sectionHandler.Name.Length == 0)  || (sectionHandler.DBName.Length == 0)){

                throw new Exception("Database name not defined in DatabaseFactoryConfiguration section of web.config.");
            }

            try { 

                MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(sectionHandler.ConnectionString));

                if (IsSSL)
                {
                    settings.SslSettings = new SslSettings { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };
                }
                var mongoClient = new MongoClient(settings);
                var _database = mongoClient.GetDatabase(sectionHandler.DBName); 
                return _database;
            }
            catch (Exception excep)
            {
                throw new Exception("Error instantiating database " + sectionHandler.Name + ". " + excep.Message);
            }
        }
    }
}