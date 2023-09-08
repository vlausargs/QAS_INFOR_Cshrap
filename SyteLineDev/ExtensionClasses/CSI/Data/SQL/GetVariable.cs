//PROJECT NAME: MG.MGCore
//CLASS NAME: GetVariable.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.SQL
{
    public class GetVariable : IGetVariable
    {
        IApplicationDB appDB;


        public GetVariable(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public (int? ReturnCode, string VariableValue,
        string Infobar) GetVariableSp(string VariableName,
        string DefaultValue,
        int? DeleteVariable,
        string VariableValue,
        string Infobar)
        {
            StringType _VariableName = VariableName;
            VeryLongListType _DefaultValue = DefaultValue;
            ListYesNoType _DeleteVariable = DeleteVariable;
            VeryLongListType _VariableValue = VariableValue;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetVariableSp";

                appDB.AddCommandParameter(cmd, "VariableName", _VariableName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DefaultValue", _DefaultValue, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DeleteVariable", _DeleteVariable, ParameterDirection.Input);
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
