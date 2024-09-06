using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Xml;
using SyncSQLServers.serverConfigs;

namespace SyncSQLServers.configReader
{
    internal class ConfigReader
    {
        private List<ServerConfig> servers;
        private XmlTextReader reader;

        public ConfigReader()
        {
            servers = new List<ServerConfig>();
            reader = new XmlTextReader("servers.xml");
            AddServers();
        }

        public ServerConfig GetMain()
        {
            ServerConfig mainCfg = null;
            foreach (ServerConfig server in servers)
            {
                if (server.MainServer.Equals(true)) { mainCfg = server; }
            }
            return mainCfg;
        }

        public List<ServerConfig> GetSlaves()
        { 
            List<ServerConfig> slaves = new List<ServerConfig>();
            foreach (ServerConfig server in servers) 
            {
                if (server.MainServer.Equals(false)) { slaves.Add(server); }
            }
            return slaves; 
        }
        private void AddServers() 
        {
            while (reader.Read())
            {
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "SRV"))
                {
                    if (reader.HasAttributes) 
                    {
                        AddServer(
                            reader.GetAttribute("main"),
                            reader.GetAttribute("name"), 
                            reader.GetAttribute("address"), 
                            reader.GetAttribute("port"), 
                            reader.GetAttribute("database"), 
                            reader.GetAttribute("user"),
                            reader.GetAttribute("password")
                            );
                    }    
                }          
            }
        }

        private void AddServer(string mainSrv, string name, string address, string port, string database, string user, string password) 
        {
            bool _mainSrv = Convert.ToBoolean(mainSrv);
            int _port = Convert.ToInt32(port);
            ServerConfig srvCfg = new ServerConfig(_mainSrv, name, address, _port, database, user, password);
            servers.Add(srvCfg);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (ServerConfig srvCfg in servers) 
            {
                sb.Append(srvCfg.ToString());
            }
            return sb.ToString();
        }
        
    }
}
