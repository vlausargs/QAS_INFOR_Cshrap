//PROJECT NAME: MG.MGCore
//CLASS NAME: IAddProcessErrorLog.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MG.MGCore
{
    public interface IAddProcessErrorLog
    {
        int? AddProcessErrorLogSp(int? ProcessID,
        string InfobarText,
        int? MessageSeverity = null);
    }
}

