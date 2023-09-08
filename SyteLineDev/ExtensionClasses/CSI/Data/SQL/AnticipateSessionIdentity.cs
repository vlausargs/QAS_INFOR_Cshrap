//PROJECT NAME: MG.MGCore
//CLASS NAME: AnticipateSessionIdentity.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.SQL
{
    public class AnticipateSessionIdentity : IAnticipateSessionIdentity
    {
        IApplicationDB appDB;


        public AnticipateSessionIdentity(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int? AnticipateSessionIdentitySp(string TableName)
        {
            StringType _TableName = TableName;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AnticipateSessionIdentitySp";

                appDB.AddCommandParameter(cmd, "TableName", _TableName, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return (Severity);
            }
        }
    }
}
