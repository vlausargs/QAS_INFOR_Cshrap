using Infor.IPF.Metrics.Metric;
using Infor.IPF.Metrics.Record;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace CSI.Data.Metric
{
    class CSIMetricRecorder : ICSIMetricRecorder
    {
        IMetricFactory metricFactory;
        ITimingRecorder metricRecorder; 
        IEventRecorder eventRecorder;
        public CSIMetricRecorder(IMetricFactory metricFactory, ITimingRecorder metricRecorder, IEventRecorder eventRecorder)
        {
            this.metricFactory = metricFactory?? throw new ArgumentNullException($"{typeof(IMetricFactory).Name} "); 
            this.metricRecorder = metricRecorder ?? throw new ArgumentNullException($"{typeof(ITimingRecorder).Name} ");
            this.eventRecorder = eventRecorder ?? throw new ArgumentNullException($"{typeof(IEventRecorder).Name} ");
        }    
        
        public IRunningTimer StartTimer(IMetric timing)
        {
            return metricRecorder.StartTimer(timing);
        }
        //if timer posting is down for some reason, mainline functionality continues
        public void ResilientTimerPost(IRunningTimer runningTimer)
        {
            try
            {
                metricRecorder.PostTimer(runningTimer);
            }
            catch { }
        }
        //if event posting is down for some reason, mainline functionality continues       
        public void ResilientEventPost(IMetric metric, IRecordingId parentRecording)
        {
            try
            {
                eventRecorder.Post(metric, parentRecording);
            }
            catch { }
        }

        public void EventPost(IMetric metric)
        {
            try
            {
                if (metric != null) eventRecorder.Post(metric);
            }
            catch { }
        }
    }
}
