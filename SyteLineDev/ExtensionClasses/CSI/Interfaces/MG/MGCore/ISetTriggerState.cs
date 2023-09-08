//PROJECT NAME: MG.MGCore
//CLASS NAME: ISetTriggerState.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MG.MGCore
{
    public interface ISetTriggerState
    {
        (int? ReturnCode, string PreviousState,
        string Infobar) SetTriggerStateSp(int? SkipReplicating,
        int? SkipBase,
        int? ScopeProcess,
        string PreviousState,
        string Infobar,
        int? SkipAllReplicate = 1,
        int? SkipAllUpdate = 0);
    }
}

