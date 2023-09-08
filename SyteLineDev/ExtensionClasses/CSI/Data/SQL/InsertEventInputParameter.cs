//PROJECT NAME: MG.MGCore
//CLASS NAME: InsertEventInputParameter.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.SQL
{
    public class InsertEventInputParameter : IInsertEventInputParameter
    {
        IApplicationDB appDB;


        public InsertEventInputParameter(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int? InsertEventInputParameterSp(Guid? EventParmId,
        string Name,
        string Value,
        int? IsOutput = 0)
        {
            EventParmIdType _EventParmId = EventParmId;
            EventVariableNameType _Name = Name;
            EventVariableValueType _Value = Value;
            ListYesNoType _IsOutput = IsOutput;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertEventInputParameterSp";

                appDB.AddCommandParameter(cmd, "EventParmId", _EventParmId, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Name", _Name, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Value", _Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "IsOutput", _IsOutput, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return (Severity);
            }
        }
    }
}
