using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Logic
{
    using System.IO;
    using System.Diagnostics;

    public class Logger
    {
        private readonly string LogFileName;
        private readonly EventLog EventLog;

        public Logger(string logFileName, string eventLogName)
        {
            this.EventLog = new EventLog();
            this.EventLog.Source = eventLogName;
            this.LogFileName = logFileName;
        }

        public void WriteLog(string log, LogTypes type = LogTypes.INFO)
        {
            try
            {
                StringBuilder fullLog = new StringBuilder();
                fullLog.AppendFormat("{0}: {1} {2}.\n", DateTime.Now, type, log);
                File.AppendAllText(this.LogFileName, fullLog.ToString());
            }
            catch (UnauthorizedAccessException ex)
            {
                this.EventLog.WriteEntry(string.Format("{0}: {1}. Access denied.", ex.StackTrace, ex.Message));
            }
            catch (IOException ex)
            {
                this.EventLog.WriteEntry(string.Format("{0}: {1}. Error writing log to file.", ex.StackTrace, ex.Message));
            }
            catch(Exception ex)
            {
                this.EventLog.WriteEntry(this.LogFileName);
                this.EventLog.WriteEntry(string.Format("{0}: {1}. Unknown error.", ex.StackTrace, ex.Message));
            }
        }

        public void WriteSystemLog(string log, LogTypes type = LogTypes.INFO)
        {
            this.EventLog.WriteEntry(log);
        }
    }
}
