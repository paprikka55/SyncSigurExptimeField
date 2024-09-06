using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SyncSQLServers.serverConfigs
{
    internal class ServerConfig
    {
        private bool _mainServer;
        private string _name;
        private string _address;
        private int _port;
        private string _dataBase;
        private string _user;
        private string _password;


        public ServerConfig(bool mainServer, string name, string address, int port, string dataBase, string user, string password)
        {
            this._mainServer = mainServer;
            this._name = name;
            this._address = address;
            this._port = port;
            this._dataBase = dataBase;
            this._user = user;
            this._password = password;
        }

        public string Name
        {
            get { return _name; }
        }

        public string Address
        {
            get { return _address; }
        }

        public int Port
        {
            get { return _port; }
        }

        public string DataBase
        {
            get { return _dataBase; }
        }

        public string User
        {
            get { return _user; }
        }

        public string Password
        {
            get { return _password; }
        }

        public bool MainServer
        { 
            get { return _mainServer; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Main?: ");
            sb.Append(_mainServer);
            sb.Append("\n");
            sb.Append("Name: ");
            sb.Append(_name);
            sb.Append("\n");
            sb.Append("Address: ");
            sb.Append(_address);
            sb.Append("\n");
            sb.Append("Port: ");
            sb.Append(_port);
            sb.Append("\n");
            sb.Append("DB_Name: ");
            sb.Append(_dataBase);
            sb.Append("\n");
            sb.Append("User: ");
            sb.Append(_user);
            sb.Append("\n");
            sb.Append("Password: ");
            sb.Append(_password);
            sb.Append("\n");
            return sb.ToString();
        }
    }
}
