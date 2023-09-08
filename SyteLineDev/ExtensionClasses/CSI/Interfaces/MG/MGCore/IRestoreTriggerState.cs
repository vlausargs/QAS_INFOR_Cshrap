//PROJECT NAME: MG.MGCore
//CLASS NAME: IRestoreTriggerState.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MG.MGCore
{
    public interface IRestoreTriggerState
    {
        (int? ReturnCode, string Infobar) RestoreTriggerStateSp(int? ScopeProcess,
        string SavedState,
        string Infobar);
    }
}

