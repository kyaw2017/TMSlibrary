using System;
using System.Configuration; 

namespace TMSLibrary.Common
{
    public sealed class DynamoDatabaseFactorySectionHandler : ConfigurationSection
    {
        [ConfigurationProperty("Name")]
        public string Name
        {
            get { return (string)base["Name"]; }
        } 

        [ConfigurationProperty("ConnectionStringName")]
        public string ConnectionStringName
        {
            get { return (string)base["ConnectionStringName"]; }
        }

        [ConfigurationProperty("DBName")]
        public string DBName
        {
            get { return (string)base["DBName"]; }
        }

        [ConfigurationProperty("TableName")]
        public string TableName
        {
            get { return (string)base["TableName"]; }
        }

        public string ConnectionString
        {
            get {
                try
                {
                    return ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString;
                }
                catch (Exception exp) {
                    throw new Exception("Connection string " + ConnectionStringName + " was not found in web.config. " + exp.Message);
                }

            }
        }
        public string DBNameString
        {
            get
            {
                try
                {
                    return ConfigurationManager.ConnectionStrings[DBName].ConnectionString;
                }
                catch (Exception exp)
                {
                    throw new Exception("Data Base Name " + DBName + " was not found in web.config. " + exp.Message);
                }

            }
        }


        public string TableNameString
        {
            get
            {
                try
                {
                    return ConfigurationManager.ConnectionStrings[TableNameString].ConnectionString;
                }
                catch (Exception exp)
                {
                    throw new Exception("Table Name " + TableNameString + " was not found in web.config. " + exp.Message);
                }

            }

            set {

            }
        }
    }
}