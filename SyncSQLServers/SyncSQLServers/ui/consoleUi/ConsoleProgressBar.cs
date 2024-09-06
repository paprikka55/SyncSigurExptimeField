using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncSQLServers.ui.consoleUi
{
    internal class ConsoleProgressBar
    {
        private int maxValue;
        private int sectors;

        public ConsoleProgressBar(int sectors, int maxValue)
        {
            this.maxValue = maxValue;
            this.sectors = sectors;
        }

        public string GetProgressBar(int currentValue)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Synchronization progress:[");
            sb.Append(GetProgressBarChars(currentValue));
            sb.Append("] ");
            sb.Append(GetProgress(currentValue));
            sb.Append("% complete");
            sb.Append("\n");
            return sb.ToString();
        }

        private string GetProgressBarChars(int currentValue) 
        {
            string pBChars = "";
            int currentSectorValue = maxValue / sectors;
            for (int i = 0; i < sectors; i++)
            {
                if (currentValue > currentSectorValue)
                {
                    pBChars += "#";
                }
                else
                {
                    pBChars += ".";
                }
                currentSectorValue += maxValue / sectors;
            }
            return pBChars;
        }

        private int GetProgress(int currentValue) 
        {
            return currentValue * 100 / maxValue;
        }
    }
}
