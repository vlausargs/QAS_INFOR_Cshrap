//PROJECT NAME: MG.MGCore
//CLASS NAME: DefineProcessVariable.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.SQL
{
    public class DefineProcessVariable : IDefineProcessVariable
    {
        IApplicationDB appDB;


        public DefineProcessVariable(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public (int? ReturnCode, string Infobar) DefineProcessVariableSp(string VariableName,
        string VariableValue,
        string Infobar)
        {
            StringType _VariableName = VariableName;
            VeryLongListType _VariableValue = VariableValue;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DefineProcessVariableSp";

                appDB.AddCommandParameter(cmd, "VariableName", _VariableName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "VariableValue", _VariableValue, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;

                return (Severity, Infobar);
            }
        }
    }
}
