using CSI.MG;
using Mongoose.Core.Common;
using Mongoose.IDO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.Logger
{
    public class MGLogger : ILogger
    {
        public void Debug(string source, string message)
        {
            MGLog.LogMessage(IDORuntime.ConfigurationName, source, LogMessageTypes.General, message);
        }

        public void Error(string source, string message)
        {
            MGLog.LogMessage(IDORuntime.ConfigurationName, source,  LogMessageTypes.Error, message);
        }

        public void Fatal(string source, string message)
        {
            MGLog.LogMessage(IDORuntime.ConfigurationName, source, LogMessageTypes.Error, message);
        }

        public void Info(string source, string message)
        {
            MGLog.LogMessage(IDORuntime.ConfigurationName, source, LogMessageTypes.General, message);
        }

        public void Performance(string source, string message)
        {
            MGLog.LogMessage(IDORuntime.ConfigurationName, source, LogMessageTypes.Performance, message);
        }

        public void Trace(string source, string message)
        {
            MGLog.LogMessage(IDORuntime.ConfigurationName, source, LogMessageTypes.Trace, message);
        }

        public void Warn(string source, string message)
        {
            MGLog.LogMessage(IDORuntime.ConfigurationName, source, LogMessageTypes.Error, message);
        }
        public void SQL(string source, string message)
        {
            MGLog.LogMessage(IDORuntime.ConfigurationName, source, LogMessageTypes.SQL, message);
        }
    }
}
