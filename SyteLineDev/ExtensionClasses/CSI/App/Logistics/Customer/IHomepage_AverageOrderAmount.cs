//PROJECT NAME: Logistics
//CLASS NAME: IHomepage_AverageOrderAmount.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
    public interface IHomepage_AverageOrderAmount
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Homepage_AverageOrderAmountSp(string Range = "T", string CustNum = null);
    }
}

