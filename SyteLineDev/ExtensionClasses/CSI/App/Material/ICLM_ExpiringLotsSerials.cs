//PROJECT NAME: Material
//CLASS NAME: ICLM_ExpiringLotsSerials.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
    public interface ICLM_ExpiringLotsSerials
    {
        (ICollectionLoadResponse Data,
        int? ReturnCode) CLM_ExpiringLotsSerialsSp(
            DateTime? CutoffDate,
            string PMTCodes,
            string FilterString = null,
            string PSiteGroup = null);
    }
}

