using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.Metric
{
    public class MetricConfiguration : IMetricConfiguration
    {
        public bool Enable
        {
            get
            {
                try
                {
                    return bool.Parse(Environment.GetEnvironmentVariable("CSIMetricsEnabled"));
                }
                catch { return false; }
            }
        }

        public bool Time(string methodName)
        {
            return true;
        }
        //this switch is to write log for entry point which is the first method that IDO method calls.
        //to-do: nested metrics be logged for a particular tenant
        public bool NestedEnabled(string tenantID)
        {
            try
            {
                return bool.Parse(Environment.GetEnvironmentVariable("CSIMetricsNestedEnabled"));
            }
            catch { return true; } //default value is true which make it is the same with previous behavior
        }
        //this switch is to count CRUD action count and associated record count.
        public bool StatisticEnabled(string tenantID)
        {
            try
            {
                return bool.Parse(Environment.GetEnvironmentVariable("CSIMetricsStatisticEnabled"));
            }
            catch { return false; }
        }
    }
}
