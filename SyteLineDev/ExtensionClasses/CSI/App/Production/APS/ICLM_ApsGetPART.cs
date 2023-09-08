//PROJECT NAME: Production
//CLASS NAME: ICLM_ApsGetPART.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
    public interface ICLM_ApsGetPART
    {
        (ICollectionLoadResponse Data,
        int? ReturnCode) CLM_ApsGetPARTSp(
            int? AltNo,
            string Filter = null);
    }
}

