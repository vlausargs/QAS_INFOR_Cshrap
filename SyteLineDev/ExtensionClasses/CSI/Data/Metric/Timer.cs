using Infor.IPF.Metrics.Metric;
using Infor.IPF.Metrics.Record;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace CSI.Data.Metric
{
    public class Timer<T> : DispatchProxy
    {
        T decorated;
        string className;
        IMetricFactory metricFactory;
        ITimingRecorder timingRecorder;
        IEventRecorder eventRecorder;
        IMetricConfiguration metricConfiguration;
        bool isEntryPointMethod;
        /// <summary>
        /// This is the internal construction method called by the factory method Create()
        /// </summary>
        private void Constructor(T decorated, IMetricFactory metricFactory, ITimingRecorder metricRecorder, IEventRecorder eventRecorder,
            IMetricConfiguration metricConfiguration, bool isEntryPointMethod)
        {
            // The parameters of this method are what would be passed to a constructor

            if (decorated == null)
                throw new ArgumentNullException($"Internal error: An instance of {typeof(T).Name} was not supplied");

            this.decorated = decorated;
            this.className = typeof(T).ToString();
            this.metricFactory = metricFactory;
            this.timingRecorder = metricRecorder;
            this.eventRecorder = eventRecorder;
            this.metricConfiguration = metricConfiguration;
            this.isEntryPointMethod = isEntryPointMethod;
        }
        
        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            if (!metricConfiguration.Time(targetMethod.Name))
                return targetMethod.Invoke(decorated, args);
            //start timer
            ICSIMetricRecorder metricRecorder = new CSIMetricRecorderFactory(this.metricConfiguration, this.isEntryPointMethod).Create(metricFactory, timingRecorder, eventRecorder);
            IMetricBuilder metricBuilder = new MetricBuilderFactory(this.metricConfiguration, this.isEntryPointMethod).Create(metricFactory, metricConfiguration);
            var timing = metricBuilder.CreateMetric(this.className, targetMethod);
            var timer = metricRecorder.StartTimer(timing);
            IMetric debuggingMetric = null;
            try
            {
                var result = targetMethod.Invoke(decorated, args);
                //call debuggingRecord to build debugging Metric
                debuggingMetric = metricBuilder.CreateMetric(this.className, targetMethod, args, result);
                return result;
            }
            catch (TargetInvocationException ex)
            {
                var e = ex.InnerException ?? ex;

                //capture the exception
                var eventAttributes = new Dictionary<string, string>()
                {
                    { "Class", className },
                    { "Exception", e.Message }
                };
                
                var errEvent = metricBuilder.CreateMetricWithAttributes(targetMethod.Name, eventAttributes);
                //once using default metric recorder, the timer could be null which migh cause another exception.
                metricRecorder.ResilientEventPost(errEvent, timer.RecordingId);

                throw e;
            }
            finally
            {
                //post the timing
                metricRecorder.ResilientTimerPost(timer);
                metricRecorder.EventPost(debuggingMetric);
            }
        }

        /// <summary>
        /// Create a proxy that times the methods on the decorated instance
        /// </summary>
        public static T Create(T decorated, IMetricFactory metricFactory, ITimingRecorder timingRecorder, IEventRecorder eventRecorder, IMetricConfiguration metricConfiguration, bool isEntryPointMethod)
        {
            // The design of DispatchProxy requires this static factory method
            // The parameters of this method are what would be passed to a constructor

            object proxy = Create<T, Timer<T>>();
            ((Timer<T>)proxy).Constructor(decorated, metricFactory, timingRecorder, eventRecorder, metricConfiguration, isEntryPointMethod);

            return (T)proxy;
        }

        public static T Create(T decorated, IMetricFactory metricFactory, ITimingRecorder timingRecorder, IEventRecorder eventRecorder, IMetricConfiguration metricConfiguration)
        {
            return Create(decorated, metricFactory, timingRecorder, eventRecorder, metricConfiguration,false);
        }
    }
}
