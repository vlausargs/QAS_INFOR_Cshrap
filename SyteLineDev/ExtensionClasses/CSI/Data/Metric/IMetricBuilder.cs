using System.Collections.Generic;
using System.Reflection;
using Infor.IPF.Metrics.Metric;
using Infor.IPF.Metrics.Record;

namespace CSI.Data.Metric
{
    public interface IMetricBuilder
    {
        IMetric CreateMetric(string className, MethodInfo targetMethod, object[] requestParms, object responseParm);
        IMetric CreateMetric(string className, MethodInfo targetMethod);
        IMetric CreateMetricWithAttributes(string name, IDictionary<string, string> eventAttributes);
    }
}
