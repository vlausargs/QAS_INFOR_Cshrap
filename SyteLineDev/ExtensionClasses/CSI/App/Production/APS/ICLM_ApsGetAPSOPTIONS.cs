//PROJECT NAME: Production
//CLASS NAME: ICLM_ApsGetAPSOPTIONS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
    public interface ICLM_ApsGetAPSOPTIONS
    {
        (ICollectionLoadResponse Data,
        int? ReturnCode) CLM_ApsGetAPSOPTIONSSp(
            int? AltNo);
    }
}

