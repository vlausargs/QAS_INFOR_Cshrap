//PROJECT NAME: MG.MGCore
//CLASS NAME: CloseSessionContext.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.SQL
{
    public class CloseSessionContext : ICloseSessionContext
    {
        IApplicationDB appDB;


        public CloseSessionContext(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int? CloseSessionContextSp(Guid? SessionID)
        {
            RowPointerType _SessionID = SessionID;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CloseSessionContextSp";

                appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return (Severity);
            }
        }
    }
}
