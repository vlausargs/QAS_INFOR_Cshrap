using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Infor.IPF.Metrics.Metric;
using Infor.IPF.Metrics.Record;

namespace CSI.Data.Metric
{
    /// <summary>
    /// this default metric recorder will do nothing. keep silent.
    /// </summary>
    class DefaultCSIMetricRecorder : ICSIMetricRecorder
    {        
        public void EventPost(IMetric metric)
        {
            
        }

        public void ResilientEventPost(IMetric metric, IRecordingId parentRecording)
        {

        }

        public void ResilientTimerPost(IRunningTimer runningTimer)
        {
        }

        public IRunningTimer StartTimer(IMetric timing)
        {
            return new DefaultRunningTimer();
        }
    }
}
