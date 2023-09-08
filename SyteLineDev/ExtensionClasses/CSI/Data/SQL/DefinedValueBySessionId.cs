//PROJECT NAME: MG.MGCore
//CLASS NAME: DefinedValueBySessionId.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.SQL
{
    public class DefinedValueBySessionId : IDefinedValueBySessionId
    {
        readonly IApplicationDB appDB;

        public DefinedValueBySessionId(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public string DefinedValueBySessionIdFn(
            Guid? SessionID,
            string VariableName)
        {
            RowPointerType _SessionID = SessionID;
            StringType _VariableName = VariableName;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  dbo.[DefinedValueBySessionId](@SessionID, @VariableName)";

                appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "VariableName", _VariableName, ParameterDirection.Input);

                var Output = appDB.ExecuteScalar<string>(cmd);

                return Output;
            }
        }
    }
}