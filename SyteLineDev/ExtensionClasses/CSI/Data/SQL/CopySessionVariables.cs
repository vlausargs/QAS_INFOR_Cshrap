//PROJECT NAME: MG.MGCore
//CLASS NAME: CopySessionVariables.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.SQL
{
    public class CopySessionVariables : ICopySessionVariables
    {
        IApplicationDB appDB;


        public CopySessionVariables(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int? CopySessionVariablesSp(string SessionId)
        {
            StringType _SessionId = SessionId;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CopySessionVariablesSp";

                appDB.AddCommandParameter(cmd, "SessionId", _SessionId, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return (Severity);
            }
        }
    }
}
