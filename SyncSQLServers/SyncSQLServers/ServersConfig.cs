using System;


public class ServerConfig
{
    private string _name;
    private string _address;
    private int _port;
    private string _dataBase;
    private string _user;
    private string _password;


    public ServerConfig(string name, string address, int port, string dataBase, string user, string password)
	{
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
        set { _name = value; }
    }

    public string Address
    { 
        get { return _address; } 
        set {  _address = value; } 
    } 

    public int Port
    {
        get { return _port; }   
        set { _port = value; }  
    }

    public string DataBase
    {
        get { return _dataBase}
        set { _dataBase = value; }
    }

    public string User
    {
        get { return _user; }
        set { _user = value; }
    }

    public string Password
    { 
        get { return _password; } 
        set { _password = value; } 
    } 
          
     
    
}
