//PROJECT NAME: Production
//CLASS NAME: IPmfRptSelectSessFm.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
    public interface IPmfRptSelectSessFm
    {
        (ICollectionLoadResponse Data,
        int? ReturnCode) PmfRptSelectSessFmSp(
            Guid? SessionID,
            int? Seq,
            int? ClearSession = 0);
    }
}

