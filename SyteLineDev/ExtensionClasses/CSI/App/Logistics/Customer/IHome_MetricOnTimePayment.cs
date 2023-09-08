//PROJECT NAME: Logistics
//CLASS NAME: IHome_MetricOnTimePayment.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
    public interface IHome_MetricOnTimePayment
    {
        (ICollectionLoadResponse Data,
        int? ReturnCode) Home_MetricOnTimePaymentSp(
            int? Count = 4);
    }
}