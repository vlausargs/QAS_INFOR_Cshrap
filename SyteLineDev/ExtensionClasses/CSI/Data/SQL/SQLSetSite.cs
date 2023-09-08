//PROJECT NAME: MG.MGCore
//CLASS NAME: SetSite.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using System.Data.SqlClient;
using CSI.MG.MGCore;

namespace CSI.Data.SQL
{
    public class SQLSetSite : ISetSite
    {
        //IApplicationDB appDB;
        IDbConnection connection;
        IDbTransaction transaction;

        //public MGSetSite(IApplicationDB appDB)
        //{
        //    this.appDB = appDB;
        //}
        public SQLSetSite(IDbConnection connection, IDbTransaction transaction)
        {
            this.connection = connection;
            this.transaction = transaction;
        }

        //public (int? ReturnCode, string Infobar) SetSiteSp(string Site,
        //string Infobar)
        //{
        //    SiteType _Site = Site;
        //    InfobarType _Infobar = Infobar;

        //    using (IDbCommand cmd = appDB.CreateCommand())
        //    {

        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "SetSiteSp";

        //        appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
        //        appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

        //        var Severity = appDB.ExecuteNonQuery(cmd);

        //        Infobar = _Infobar;

        //        return (Severity, Infobar);
        //    }
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="site">SyteType</param>
        /// <param name="infobar">InfobarType</param>
        public (int? ReturnCode, string Infobar) SetSite(string Site, string Infobar)
        {
            using (IDbCommand cmd = new SqlCommand())
            {
                cmd.Connection = connection;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SetSiteSp";
                cmd.Parameters.Add(new SqlParameter("Site", Site));
                var p = new SqlParameter("@Infobar", SqlDbType.NVarChar);
                p.Direction = ParameterDirection.Output;
                p.Size = 1024;
                cmd.Parameters.Add(p);

                var Severity = cmd.ExecuteNonQuery();

                Infobar = p.Value as string;

                return (Severity, Infobar);
            }
        }
    }
}
