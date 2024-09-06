using SyncSQLServers.model.service;
using SyncSQLServers.model.synchronizer;
using SyncSQLServers.ui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SyncSQLServers.presenter
{
    internal class Presenter
    {
        private Service service;
        private IUi ui;

        public Presenter(IUi ui)
        {
            this.service = new Service();
            this.ui = ui;
        }

        public bool StartSync() 
        {
            if (service.StartSynchronization()) 
            { PrintAnswere("Synchronization is complete!"); }
            return true;
        }

        private void PrintAnswere(String answere) 
        { ui.PrintAnswere(answere); }

        public int GetCurrentID() 
        { return service.GetCurrentID(); }

        public int GetSyncLength()
        { return service.GetSyncLength(); }
    }
}
