//PROJECT NAME: MG.MGCore
//CLASS NAME: InitSessionContext.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.SQL
{
    public class InitSessionContext : IInitSessionContext
    {
        IApplicationDB appDB;


        public InitSessionContext(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public (int? ReturnCode, Guid? SessionID) InitSessionContextSp(string ContextName,
        Guid? SessionID,
        string Site = null)
        {
            FormNameType _ContextName = ContextName;
            RowPointerType _SessionID = SessionID;
            SiteType _Site = Site;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InitSessionContextSp";

                appDB.AddCommandParameter(cmd, "ContextName", _ContextName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                SessionID = _SessionID;

                return (Severity, SessionID);
            }
        }
    }
}
