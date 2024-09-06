using SyncSQLServers.presenter;
using SyncSQLServers.ui.consoleUi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SyncSQLServers.ui
{
    internal class ConsoleUi : IUi
    {
        private Presenter presenter;
        private ConsoleProgressBar progressBar;

        public ConsoleUi()
        {
            this.presenter = new Presenter(this);
            this.progressBar = new ConsoleProgressBar(50, presenter.GetSyncLength());
        }

        public void StartSync() 
        {
            bool stopFlag = false;
            Parallel.Invoke(
                () =>
                {
                    stopFlag = presenter.StartSync();
                },
                () =>
                {
                    while (!stopFlag)
                    {
                        Thread.Sleep(3000);
                        Console.Clear();
                        Console.WriteLine(progressBar.GetProgressBar(presenter.GetCurrentID()));
                    }
                }
                );
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }

        public IUi GetUi()
        {
            return this;
        }

        public void PrintAnswere(string answere)
        {
            Console.WriteLine(answere);
        }
    }
}
