//PROJECT NAME: MG.MGCore
//CLASS NAME: RetrieveSessionIdentity.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.SQL
{
    public class RetrieveSessionIdentity : IRetrieveSessionIdentity
    {
        IApplicationDB appDB;


        public RetrieveSessionIdentity(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public (int? ReturnCode, long? Identity) RetrieveSessionIdentitySp(string TableName,
        long? Identity)
        {
            StringType _TableName = TableName;
            LongType _Identity = Identity;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "RetrieveSessionIdentitySp";

                appDB.AddCommandParameter(cmd, "TableName", _TableName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Identity", _Identity, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Identity = _Identity;

                return (Severity, Identity);
            }
        }
    }
}
