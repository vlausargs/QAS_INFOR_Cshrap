using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Infor.IPF.Metrics.Metric;

namespace CSI.Data.Metric
{
    class DefaultMetricBuilder : IMetricBuilder
    {
        public IMetric CreateMetric(string className, MethodInfo targetMethod, object[] requestParms, object responseParm)
        {
            return null;
        }

        public IMetric CreateMetric(string className, MethodInfo targetMethod)
        {
            return null;
        }

        public IMetric CreateMetricWithAttributes(string name, IDictionary<string, string> eventAttributes)
        {
            return null;
        }
    }
}
