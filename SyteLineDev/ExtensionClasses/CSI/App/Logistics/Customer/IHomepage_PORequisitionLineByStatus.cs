//PROJECT NAME: Logistics
//CLASS NAME: IHomepage_PORequisitionLineByStatus.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
    public interface IHomepage_PORequisitionLineByStatus
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Homepage_PORequisitionLineByStatusSp(int? DaysBefore = 0, string Item = null);
    }
}

