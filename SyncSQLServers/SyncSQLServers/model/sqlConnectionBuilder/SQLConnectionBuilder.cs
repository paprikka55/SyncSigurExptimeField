using MySqlConnector;
using SyncSQLServers.configReader;
using SyncSQLServers.serverConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncSQLServers.model.sqlConnectionBuilder
{
    internal class SQLConnectionBuilder
    {
        public MySqlConnection BuildMain(ServerConfig serverConfig)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(BuildConnectionString(serverConfig));
            return mySqlConnection;
        }

        private static string BuildConnectionString(ServerConfig serverConfig)
        {
            StringBuilder connectionString = new StringBuilder();
            connectionString.Append("Server =");
            connectionString.Append(serverConfig.Address);
            connectionString.Append(";Port=");
            connectionString.Append(serverConfig.Port);
            connectionString.Append(";Database=");
            connectionString.Append(serverConfig.DataBase);
            connectionString.Append(";User=");
            connectionString.Append(serverConfig.User);
            connectionString.Append("; Password =");
            connectionString.Append(serverConfig.Password);
            return connectionString.ToString();
        }

        public List<MySqlConnection> BuildSlaves(ConfigReader configReader) 
        { 
            List<MySqlConnection> mySqlConnections = new List<MySqlConnection>();
            List<ServerConfig> slaves = configReader.GetSlaves();
            foreach (ServerConfig slave in slaves) 
            {
                mySqlConnections.Add(new MySqlConnection(BuildConnectionString(slave)));
            }

            return mySqlConnections; 
        }

        
    }
}
