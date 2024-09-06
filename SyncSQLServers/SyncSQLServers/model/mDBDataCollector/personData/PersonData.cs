using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SyncSQLServers.model.mDBDataCollector.personData
{
    internal class PersonData
    {
        private int _id;
        private string _name;
        private string _hexCodekey;
        private Object _exptime;

        public PersonData(int id, string name, string hexCodekey, Object exptime)
        {
            _id = id;
            _name = name;
            _hexCodekey = hexCodekey;
            _exptime = exptime;
        }

        public String Name 
        {
            get { return _name; }
        }
        public int Id
        { get { return _id; } }

        public String HexCodeKey 
        {
            get { return _hexCodekey; }
        }

        public Object Exptime
        { get { return _exptime; } }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(_id);
            stringBuilder.Append("\n");
            stringBuilder.Append(_name);
            stringBuilder.Append("\n");
            stringBuilder.Append(_hexCodekey);
            stringBuilder.Append("\n");
            stringBuilder.Append(_exptime);
            stringBuilder.Append("\n------------------------");
            return stringBuilder.ToString();
        }
    }
}
