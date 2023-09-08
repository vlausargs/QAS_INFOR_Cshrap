//PROJECT NAME: Finance
//CLASS NAME: ISSSCCIParmsDebug.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.CreditCard
{
    public interface ISSSCCIParmsDebug
    {
        (int? ReturnCode,
        int? Debug) SSSCCIParmsDebugSp(
            int? Debug);
    }
}

