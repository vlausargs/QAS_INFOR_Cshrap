//PROJECT NAME: Logistics
//CLASS NAME: ICLM_ItemContentRefs.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
    public interface ICLM_ItemContentRefs
    {
        (ICollectionLoadResponse Data, int? ReturnCode) CLM_ItemContentRefsSp(string Item = null,
            string RefType = null,
            string RefNum = null,
            int? RefLine = 0,
            int? RefRelease = 0,
            DateTime? EffectDate = null,
            string FilterString = null);
    }
}

