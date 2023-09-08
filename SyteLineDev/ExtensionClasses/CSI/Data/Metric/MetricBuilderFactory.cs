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
    public class MetricBuilderFactory
    {
        IMetricConfiguration metricConfiguration;
        bool isEntryPointMethod;
        public MetricBuilderFactory(IMetricConfiguration metricConfiguration, bool isEntryPointMethod)
        {
            this.metricConfiguration = metricConfiguration;
            this.isEntryPointMethod = isEntryPointMethod;
        }
        public IMetricBuilder Create(IMetricFactory metricFactory, IMetricConfiguration metricConfiguration)
        {
            var tupleUtil = new TupleUtilFactory().Create();
            if (RecordEnabled(this.metricConfiguration, this.isEntryPointMethod))
                return new MetricBuilder(metricFactory, metricConfiguration, tupleUtil, new RunningSQLCatcher());
            return new DefaultMetricBuilder();
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
