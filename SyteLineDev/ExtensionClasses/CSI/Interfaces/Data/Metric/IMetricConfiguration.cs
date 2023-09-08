using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.Metric
{
    public interface IMetricConfiguration
    {
        bool Time(string methodName);

        bool Enable { get; }

        bool NestedEnabled(string tenantID);

        bool StatisticEnabled(string tenantID);
    }
}
