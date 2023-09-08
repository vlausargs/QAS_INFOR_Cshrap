//PROJECT NAME: Codes
//CLASS NAME: ICLM_PerTot.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
    public interface ICLM_PerTot
    {
        (ICollectionLoadResponse Data,
        int? ReturnCode) CLM_PerTotSp();
    }
}

