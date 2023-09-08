//PROJECT NAME: Logistics
//CLASS NAME: IHomepage_LeadsCount.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
    public interface IHomepage_LeadsCount
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Homepage_LeadsCountSp(int? DaysBefore = 30,
            string CustNumProspectId = null,
            string Type = "Customer");
    }
}

