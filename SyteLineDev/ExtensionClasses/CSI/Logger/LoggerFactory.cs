using System;

namespace CSI.Logger
{
    public class LoggerFactory
    {
        public CSI.MG.ILogger Create() { return this.Create(LoggerType.Mongoose); }
        public CSI.MG.ILogger Create(LoggerType loggerType)
        {
            _logLoggerInstanceCreatingMessage(loggerType);
            if (loggerType == LoggerType.Mongoose)
                return new MGLogger();
            else return new NullLogger();
        }
        private void _logLoggerInstanceCreatingMessage(LoggerType loggerType)
        {
            try
            {
                string loggerCreatingMessag = string.Format("The logger type is {0}. The {0} logger will be created!", loggerType.ToString());
                Mongoose.Core.Common.MGLog.LogMessage(Mongoose.IDO.IDORuntime.ConfigurationName, "Metric", Mongoose.Core.Common.LogMessageTypes.General, loggerCreatingMessag);
            }
            catch { }
        }
    }
}
