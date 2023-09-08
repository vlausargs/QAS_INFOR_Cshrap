//PROJECT NAME: Production
//CLASS NAME: ICLM_ApsGetEFFECT.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
    public interface ICLM_ApsGetEFFECT
    {
        (ICollectionLoadResponse Data,
        int? ReturnCode) CLM_ApsGetEFFECTSp(
            int? AltNo,
            string Filter = null);
    }
}

