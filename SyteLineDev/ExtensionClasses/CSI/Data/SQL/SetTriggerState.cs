//PROJECT NAME: MG.MGCore
//CLASS NAME: SetTriggerState.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.SQL
{
    public class SetTriggerState : ISetTriggerState
    {
        IApplicationDB appDB;


        public SetTriggerState(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public (int? ReturnCode, string PreviousState,
        string Infobar) SetTriggerStateSp(int? SkipReplicating,
        int? SkipBase,
        int? ScopeProcess,
        string PreviousState,
        string Infobar,
        int? SkipAllReplicate = 1,
        int? SkipAllUpdate = 0)
        {
            ListYesNoType _SkipReplicating = SkipReplicating;
            ListYesNoType _SkipBase = SkipBase;
            ListYesNoType _ScopeProcess = ScopeProcess;
            LongListType _PreviousState = PreviousState;
            InfobarType _Infobar = Infobar;
            ListYesNoType _SkipAllReplicate = SkipAllReplicate;
            ListYesNoType _SkipAllUpdate = SkipAllUpdate;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SetTriggerStateSp";

                appDB.AddCommandParameter(cmd, "SkipReplicating", _SkipReplicating, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SkipBase", _SkipBase, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ScopeProcess", _ScopeProcess, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PreviousState", _PreviousState, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "SkipAllReplicate", _SkipAllReplicate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SkipAllUpdate", _SkipAllUpdate, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                PreviousState = _PreviousState;
                Infobar = _Infobar;

                return (Severity, PreviousState, Infobar);
            }
        }
    }
}
