using SyncSQLServers.model.synchronizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncSQLServers.model.service
{
    internal class Service
    {
        private Synchronizer synchronizer;
        public Service() 
        {
            this.synchronizer = new Synchronizer();
        }

        public int GetCurrentID()
        { return synchronizer.GetCurrentID(); }

        public int GetSyncLength() 
        { return synchronizer.GetSyncLength(); }

        public bool StartSynchronization() 
        { return synchronizer.Start(); }
    }
}
