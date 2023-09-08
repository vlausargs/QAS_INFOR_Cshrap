using CSI.Data.Utilities;
using Infor.IPF.Metrics.Metric;
using Infor.IPF.Metrics.Record;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace CSI.Data.Metric
{
    public class CSIMetricRecorderFactory
    {
        IMetricConfiguration metricConfiguration;
        bool isEntryPointMethod;
        public CSIMetricRecorderFactory(IMetricConfiguration metricConfiguration, bool isEntryPointMethod)
        {
            this.metricConfiguration = metricConfiguration;
            this.isEntryPointMethod = isEntryPointMethod;
        }
        public ICSIMetricRecorder Create(IMetricFactory metricFactory, 
            ITimingRecorder metricRecorder, IEventRecorder eventRecorder)
        {
            if (RecordEnabled(this.metricConfiguration,this.isEntryPointMethod))
                return new CSIMetricRecorder(metricFactory, metricRecorder, eventRecorder);
            return new DefaultCSIMetricRecorder();
        }
        
        private bool RecordEnabled(IMetricConfiguration metricConfiguration, bool isEntryPointMethod)
        {
            //if config to let nested log reorded
            if (metricConfiguration.NestedEnabled(""))  return true;
            else
            {//in this branch, entry point method is allowed to record log.
                if (isEntryPointMethod) return true;
            }
            return false;
        }        
    }
}
