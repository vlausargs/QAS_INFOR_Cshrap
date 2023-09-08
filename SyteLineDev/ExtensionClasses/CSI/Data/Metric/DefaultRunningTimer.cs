using Infor.IPF.Metrics.Metric;
using Infor.IPF.Metrics.Record;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.Metric
{
    class DefaultRunningTimer : IRunningTimer
    {
        public DateTime Start => DateTime.MinValue;

        public TimeSpan Elapsed => new TimeSpan();

        public IRecordingId RecordingId => null;

        public IMetric Metric => null;

        public IRecordingId ParentRecordingId => null;
    }
}
