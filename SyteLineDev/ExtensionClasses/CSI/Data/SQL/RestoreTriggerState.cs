//PROJECT NAME: MG.MGCore
//CLASS NAME: RestoreTriggerState.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.SQL
{
    public class RestoreTriggerState : IRestoreTriggerState
    {
        IApplicationDB appDB;


        public RestoreTriggerState(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public (int? ReturnCode, string Infobar) RestoreTriggerStateSp(int? ScopeProcess,
        string SavedState,
        string Infobar)
        {
            ListYesNoType _ScopeProcess = ScopeProcess;
            LongListType _SavedState = SavedState;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "RestoreTriggerStateSp";

                appDB.AddCommandParameter(cmd, "ScopeProcess", _ScopeProcess, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SavedState", _SavedState, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;

                return (Severity, Infobar);
            }
        }
    }
}
