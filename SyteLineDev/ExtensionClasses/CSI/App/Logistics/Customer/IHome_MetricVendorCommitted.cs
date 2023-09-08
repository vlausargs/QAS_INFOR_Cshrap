//PROJECT NAME: Logistics
//CLASS NAME: IHome_MetricVendorCommitted.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
    public interface IHome_MetricVendorCommitted
    {
        (ICollectionLoadResponse Data,
        int? ReturnCode) Home_MetricVendorCommittedSp(
            int? Count = 10);
    }
}