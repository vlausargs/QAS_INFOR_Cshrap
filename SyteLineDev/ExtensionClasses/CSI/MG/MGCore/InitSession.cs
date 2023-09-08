//PROJECT NAME: MG.MGCore
//CLASS NAME: InitSession.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.MG.MGCore
{
    public class InitSession : IInitSession
    {
        IApplicationDB appDB;


        public InitSession(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int? InitSessionSp(Guid? ID,
        string UserName,
        string Site = null)
        {
            GuidType _ID = ID;
            StringType _UserName = UserName;
            SiteType _Site = Site;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InitSessionSp";

                appDB.AddCommandParameter(cmd, "ID", _ID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UserName", _UserName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return (Severity);
            }
        }
    }
}
