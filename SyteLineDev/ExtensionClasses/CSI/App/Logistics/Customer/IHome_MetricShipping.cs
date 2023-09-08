//PROJECT NAME: Logistics
//CLASS NAME: IHome_MetricShipping.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
    public interface IHome_MetricShipping
    {
        (ICollectionLoadResponse Data,
        int? ReturnCode) Home_MetricShippingSp(
            int? NumberOfRows = 6);
    }
}