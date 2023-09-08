//PROJECT NAME: Logistics
//CLASS NAME: IHomepage_QCRejectionPercentageByItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
    public interface IHomepage_QCRejectionPercentageByItem
    {
        (ICollectionLoadResponse Data,
        int? ReturnCode) Homepage_QCRejectionPercentageByItemSp(
            DateTime? DateEnd,
            DateTime? DateStart,
            string RefType);
    }
}

