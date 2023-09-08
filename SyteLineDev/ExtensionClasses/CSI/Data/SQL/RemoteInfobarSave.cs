//PROJECT NAME: MG.MGCore
//CLASS NAME: RemoteInfobarSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.SQL
{
    public class RemoteInfobarSave : IRemoteInfobarSave
    {
        IApplicationDB appDB;


        public RemoteInfobarSave(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int? RemoteInfobarSaveSp(string Infobar)
        {
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "RemoteInfobarSaveSp";

                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return (Severity);
            }
        }
    }
}
