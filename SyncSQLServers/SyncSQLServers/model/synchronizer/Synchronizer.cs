using MySqlConnector;
using SyncSQLServers.configReader;
using SyncSQLServers.model.mDBDataCollector;
using SyncSQLServers.model.mDBDataCollector.personData;
using SyncSQLServers.model.sqlConnectionBuilder;
using System;
using System.Collections.Generic;

namespace SyncSQLServers.model.synchronizer
{
    internal class Synchronizer
    {
        private List<MySqlConnection> slaveConnections;
        private MDBDataCollector mDBDataCollector;
        private int current_id;
        private List<string> syncPersons;

        public Synchronizer()
        {
            ConfigReader configReader = new ConfigReader();
            SQLConnectionBuilder sQLConnectionBuilder = new SQLConnectionBuilder();
            this.slaveConnections = sQLConnectionBuilder.BuildSlaves(configReader);
            this.mDBDataCollector = new MDBDataCollector(configReader, sQLConnectionBuilder);
            this.current_id = 1;
            syncPersons = new List<string>();
        }

        public bool Start() 
        {
            foreach (PersonData personData in mDBDataCollector.GetPersonDatas()) 
            {
                foreach (MySqlConnection slaveConnection in slaveConnections)
                { 
                    SyncSlave(personData, slaveConnection);
                }
                current_id++;
            }
            current_id = -1;
            return true;
        }

        private void SyncSlave(PersonData personData, MySqlConnection slaveConnection) 
        {
            int syncId = CheckEqualsExptime(personData, slaveConnection);
            if (!syncId.Equals(-1))
            {
                SyncExptime(syncId, personData, slaveConnection);
            }
        }

        private int CheckEqualsExptime(PersonData personData, MySqlConnection slaveConnection) 
        {
            int id = -1;
            slaveConnection.Open();
            string commandString = $@"SELECT id, exptime FROM personal  
                                    WHERE type = 'EMP' and status = 'available'
                                    and CODEKEY = unhex('{personData.HexCodeKey}') 
                                    and name = '{personData.Name}'";
            
            MySqlCommand mySqlCommand = new MySqlCommand(commandString, slaveConnection);
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            if (mySqlDataReader.Read()) 
            {
                if (!mySqlDataReader["exptime"].Equals(personData.Exptime))
                {
                    id = Convert.ToInt32(mySqlDataReader["id"]);
                    syncPersons.Add(personData.Name);
                }
            }
            slaveConnection.Close();
            return id;
        }

        private void SyncExptime(int id, PersonData personData, MySqlConnection slaveConnection) 
        {
            DateTime exptime;
            string commandString = "";
            if (!personData.Exptime.Equals(DBNull.Value))
            {
                exptime = Convert.ToDateTime(personData.Exptime);
                commandString = $@"UPDATE personal
                                        SET exptime = '{exptime.ToString("yyyy-MM-dd HH:mm:ss")}'
                                        WHERE id = '{id}'";
            }
            else
            {
                commandString = $@"UPDATE personal
                                        SET exptime = null
                                        WHERE id = '{id}'";
            }
            
            slaveConnection.Open();
            MySqlCommand command = new MySqlCommand(commandString, slaveConnection);   
            slaveConnection.Close();
        }

        public int GetCurrentID() 
        { return current_id; }

        public int GetSyncLength() 
        { return mDBDataCollector.GetPersonDatas().Count; }

        public List<string> GetSyncedPersons() 
        {
            return syncPersons;
        }

    }
}
