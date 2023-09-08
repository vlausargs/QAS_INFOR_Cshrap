//PROJECT NAME: MG.MGCore
//CLASS NAME: InitSessionContextWithUser.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.SQL
{
    public class InitSessionContextWithUser : IInitSessionContextWithUser
    {
        IApplicationDB appDB;


        public InitSessionContextWithUser(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public (int? ReturnCode, Guid? SessionID) InitSessionContextWithUserSp(string ContextName,
        string UserName,
        Guid? SessionID,
        string Site = null)
        {
            FormNameType _ContextName = ContextName;
            UsernameType _UserName = UserName;
            RowPointerType _SessionID = SessionID;
            SiteType _Site = Site;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InitSessionContextWithUserSp";

                appDB.AddCommandParameter(cmd, "ContextName", _ContextName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UserName", _UserName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                SessionID = _SessionID;

                return (Severity, SessionID);
            }
        }
    }
}
