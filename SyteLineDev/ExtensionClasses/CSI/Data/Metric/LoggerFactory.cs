using System;
using System.Collections.Generic;
using System.Text;
using NLog;
using NLog.Config;
using NLog.Targets;
using System.Linq;

namespace CSI.ServiceClasses.CSIServiceClasses
{
    public class LoggerFactory
    {
        //use one global threadsafe logger
        static NLog.ILogger logger;

        static LoggerFactory()
        {
            Data.Metric.IMetricConfiguration metricConfiguration = new Data.Metric.MetricConfiguration();
            CSI.Logger.LoggerType loggerType = metricConfiguration.Enable ? CSI.Logger.LoggerType.Mongoose : CSI.Logger.LoggerType.Null;
            MG.ILogger metriclogger = (new CSI.Logger.LoggerFactory()).Create(loggerType);
            logger = new Metric.Logger.Logger(metriclogger);
        }

        public NLog.ILogger Create()
        {
            return logger;
        }
    }
}
