//PROJECT NAME: MG.MGCore
//CLASS NAME: UndefineVariableBySessionId.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.SQL
{
    public class UndefineVariableBySessionId : IUndefineVariableBySessionId
    {
        IApplicationDB appDB;


        public UndefineVariableBySessionId(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public (int? ReturnCode, string Infobar) UndefineVariableBySessionIdSp(Guid? SessionID,
        string VariableName,
        string Infobar)
        {
            RowPointerType _SessionID = SessionID;
            StringType _VariableName = VariableName;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UndefineVariableBySessionIdSp";

                appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "VariableName", _VariableName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;

                return (Severity, Infobar);
            }
        }
    }
}
