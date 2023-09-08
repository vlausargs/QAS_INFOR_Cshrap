//PROJECT NAME: Production
//CLASS NAME: ICLM_ApsGetMATLRULE.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
    public interface ICLM_ApsGetMATLRULE
    {
        (ICollectionLoadResponse Data,
        int? ReturnCode) CLM_ApsGetMATLRULESp(
            int? AltNo,
            string Filter = null);
    }
}

