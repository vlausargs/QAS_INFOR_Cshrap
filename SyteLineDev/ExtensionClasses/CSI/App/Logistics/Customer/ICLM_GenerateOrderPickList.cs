//PROJECT NAME: Logistics
//CLASS NAME: ICLM_GenerateOrderPickList.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
    public interface ICLM_GenerateOrderPickList
    {
        (ICollectionLoadResponse Data, int? ReturnCode) CLM_GenerateOrderPickListSp(string PStartCoNum,
            string PEndCoNum,
            DateTime? PStartDueDate,
            DateTime? PEndDueDate,
            string PStartWhse,
            string PEndWhse,
            string PStartCustNum,
            string PEndCustNum,
            int? PStartCustSeq,
            int? PEndCustSeq,
            string PParmsSite);
    }
}

