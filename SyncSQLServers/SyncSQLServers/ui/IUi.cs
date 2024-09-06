using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SyncSQLServers.ui
{
    internal interface IUi
    {
        void PrintAnswere(string answere);
        IUi GetUi();

        void StartSync();
    }
}
