//PROJECT NAME: Logistics
//CLASS NAME: IHomepage_POLinesReceivedCount.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
    public interface IHomepage_POLinesReceivedCount
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Homepage_POLinesReceivedCountSp(int? DaysBefore = 0, string VendNum = null);
    }
}

