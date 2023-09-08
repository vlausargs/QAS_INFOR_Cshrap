//PROJECT NAME: MG.MGCore
//CLASS NAME: DefineVariableBySessionId.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.SQL
{
    public class DefineVariableBySessionId : IDefineVariableBySessionId
    {
        IApplicationDB appDB;


        public DefineVariableBySessionId(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public (int? ReturnCode, string VariableValue,
        string Infobar) DefineVariableBySessionIdSp(Guid? SessionID,
        string VariableName,
        string VariableValue,
        string Infobar)
        {
            RowPointerType _SessionID = SessionID;
            StringType _VariableName = VariableName;
            VeryLongListType _VariableValue = VariableValue;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DefineVariableBySessionIdSp";

                appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "VariableName", _VariableName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "VariableValue", _VariableValue, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                VariableValue = _VariableValue;
                Infobar = _Infobar;

                return (Severity, VariableValue, Infobar);
            }
        }
    }
}
