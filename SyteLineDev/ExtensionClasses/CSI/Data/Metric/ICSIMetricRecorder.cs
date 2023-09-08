using System.Collections.Generic;
using System.Reflection;
using Infor.IPF.Metrics.Metric;
using Infor.IPF.Metrics.Record;

namespace CSI.Data.Metric
{
    public interface ICSIMetricRecorder
    {
        void ResilientEventPost(IMetric metric, IRecordingId parentRecording);
        void ResilientTimerPost(IRunningTimer runningTimer);
        IRunningTimer StartTimer(IMetric timing);
        void EventPost(IMetric metric);
    }
}