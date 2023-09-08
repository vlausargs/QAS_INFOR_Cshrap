//PROJECT NAME: Logistics
//CLASS NAME: IHomepage_TotalSales.cs

using System;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
    [RuntimeIntercept(ERuntimeIntercept.HomepageTotalSales)]
    public interface IHomepage_TotalSales
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Homepage_TotalSalesSp(string CustNum = null);
    }
}

