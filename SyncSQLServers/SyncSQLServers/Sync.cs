using SyncSQLServers.configReader;
using SyncSQLServers.model.mDBDataCollector;
using SyncSQLServers.model.mDBDataCollector.personData;
using SyncSQLServers.model.sqlConnectionBuilder;
using SyncSQLServers.model.synchronizer;
using SyncSQLServers.serverConfigs;
using SyncSQLServers.ui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SyncSQLServers
{
    internal class Sync
    {
        static void Main(string[] args)
        {
            IUi consoleUi = new ConsoleUi();
            consoleUi.StartSync();
        }
    }
}
