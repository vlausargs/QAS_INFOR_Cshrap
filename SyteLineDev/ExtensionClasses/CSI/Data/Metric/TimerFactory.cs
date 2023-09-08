using System;
using System.Collections.Generic;
using System.Text;
using CSI.ServiceClasses.CSIServiceClasses;
using Infor.IPF.Metrics.Metric;
using Infor.IPF.Metrics.NLogFlatXMLWriter;
using Infor.IPF.Metrics.Record;
using Infor.IPF.TimeProvider;

namespace CSI.Data.Metric
{
    public class TimerFactory : ITimerFactory
    {
        //use one global set of threadsafe metric infrastructure
        static IMetricFactory metricFactory;
        static MetricRecorder metricRecorder;

        static TimerFactory()
        {
            var NLogger = new LoggerFactory().Create();
            var flushCountInterval = new TimeSpan(0, 0, 0, 0, 10000); //10 seconds
            var runningTimerInterval = new TimeSpan(0, 0, 0, 0, 1000 * 60 * 1); //1 minute
            var stopWatchProvider = new StopwatchProvider();
            var dateTimeProvider = new DateTimeProvider();
            var nLogFlatXMLWriter = new NLogFlatXMLWriter(NLogger, flushCountInterval, dateTimeProvider);
            metricFactory = new MetricFactory();
            metricRecorder = new MetricRecorder(runningTimerInterval, stopWatchProvider, dateTimeProvider, nLogFlatXMLWriter, nLogFlatXMLWriter, nLogFlatXMLWriter);
        }

        public T Create<T>(T decorated)
        {
            var metricConfiguration = new MetricConfiguration();
            return Timer<T>.Create(decorated, metricFactory, metricRecorder, metricRecorder, metricConfiguration);
        }
        public T CreateForEntryPointMethod<T>(T decorated)
        {
            var metricConfiguration = new MetricConfiguration();
            return Timer<T>.Create(decorated, metricFactory, metricRecorder, metricRecorder, metricConfiguration, true);
        }
    }
}
