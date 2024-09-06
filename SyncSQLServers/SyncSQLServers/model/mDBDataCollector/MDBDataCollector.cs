using MySqlConnector;
using SyncSQLServers.configReader;
using SyncSQLServers.model.mDBDataCollector.personData;
using SyncSQLServers.model.sqlConnectionBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SyncSQLServers.model.mDBDataCollector
{
    internal class MDBDataCollector
    {
        private List<PersonData> personDatas;
        private MySqlConnection mainSqlConnection;

        public MDBDataCollector(ConfigReader configReader, SQLConnectionBuilder sQLConnectionBuilder)
        {
            personDatas = new List<PersonData>();
            this.mainSqlConnection = sQLConnectionBuilder.BuildMain(configReader.GetMain());
            FillpersonDatas();
        }



        private void FillpersonDatas() 
        {
            string commandString = "select id, name, exptime, hex(CODEKEY) from personal where  type = \"EMP\" and status = \"available\" and hex(CODEKEY) <> \"NULL\" and hex(CODEKEY) <> \"0000000000000000\" ORDER BY name";
            MySqlCommand fillCommand = new MySqlCommand(commandString, mainSqlConnection);
            mainSqlConnection.Open();
            MySqlDataReader mySqlDataReader = fillCommand.ExecuteReader();
            int id = 1;
            while (mySqlDataReader.Read())
            {
                
                if (!mySqlDataReader["hex(codekey)"].Equals(DBNull.Value) || !Convert.ToString(mySqlDataReader["hex(codekey)"]).Equals("0000000000000000"))
                {
                    string name = Convert.ToString(mySqlDataReader["name"]);
                    string hexCodeKey = Convert.ToString(mySqlDataReader["hex(codekey)"]);
                    Object exptime = mySqlDataReader["exptime"];
                    AddPersonData(id, name, hexCodeKey, exptime);
                    id++;
                }
                else { Console.WriteLine("Ignore"); }
            }
            mainSqlConnection.Close();
        }

        private void AddPersonData(int id, string name, string hexCodeKey, Object exptime) 
        {
            personDatas.Add(new PersonData(id, name , hexCodeKey, exptime));
        }

        public List<PersonData> GetPersonDatas() { return  personDatas; }

    }
}
