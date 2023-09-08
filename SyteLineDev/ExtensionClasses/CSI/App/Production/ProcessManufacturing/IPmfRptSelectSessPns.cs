//PROJECT NAME: Production
//CLASS NAME: IPmfRptSelectSessPns.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
    public interface IPmfRptSelectSessPns
    {
        (ICollectionLoadResponse Data,
        int? ReturnCode) PmfRptSelectSessPnsSp(
            Guid? SessionId,
            int? Seq,
            int? ClearSess = 0);
    }
}

