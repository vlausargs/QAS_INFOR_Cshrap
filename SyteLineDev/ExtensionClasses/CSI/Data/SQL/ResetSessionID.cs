//PROJECT NAME: MG.MGCore
//CLASS NAME: ResetSessionID.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.SQL
{
    public class ResetSessionID : IResetSessionID
    {
        IApplicationDB appDB;


        public ResetSessionID(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int? ResetSessionIDSp(Guid? ID)
        {
            RowPointerType _ID = ID;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ResetSessionIDSp";

                appDB.AddCommandParameter(cmd, "ID", _ID, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return (Severity);
            }
        }
    }
}
