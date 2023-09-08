//PROJECT NAME: MG.MGCore
//CLASS NAME: ClearSession.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.MG.MGCore
{
    public class ClearSession : IClearSession
    {
        IApplicationDB appDB;


        public ClearSession(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public (int? ReturnCode, string Infobar) ClearSessionSp(Guid? ConnectionID,
        string UserName,
        string Infobar)
        {
            RowPointerType _ConnectionID = ConnectionID;
            StringType _UserName = UserName;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ClearSessionSp";

                appDB.AddCommandParameter(cmd, "ConnectionID", _ConnectionID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UserName", _UserName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;

                return (Severity, Infobar);
            }
        }
    }
}
