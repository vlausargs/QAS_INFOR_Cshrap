//PROJECT NAME: MG.MGCore
//CLASS NAME: CloseSession.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.SQL
{
    public class CloseSession : ICloseSession
    {
        IApplicationDB appDB;


        public CloseSession(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int? CloseSessionSp(Guid? ID)
        {
            GuidType _ID = ID;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CloseSessionSp";

                appDB.AddCommandParameter(cmd, "ID", _ID, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return (Severity);
            }
        }
    }
}
