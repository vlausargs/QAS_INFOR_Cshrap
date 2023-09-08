//PROJECT NAME: Production
//CLASS NAME: ICLM_ApsGetBOM.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
    public interface ICLM_ApsGetBOM
    {
        (ICollectionLoadResponse Data,
        int? ReturnCode) CLM_ApsGetBOMSp(
            int? AltNo,
            string Filter = null);
    }
}

