//PROJECT NAME: Production
//CLASS NAME: ApsSiteIn.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
    public interface IApsSiteIn
    {
        (int? ReturnCode, string PSQLServerName, string PSQLDbName) ApsSiteInfo(string PSQLServerName,
                                                                                string PSQLDbName);
    }

    public class ApsSiteIn : IApsSiteIn
    {
        readonly IApplicationDB appDB;

        public ApsSiteIn(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public (int? ReturnCode, string PSQLServerName, string PSQLDbName) ApsSiteInfo(string PSQLServerName,
                                                                                       string PSQLDbName)
        {
            StringType _PSQLServerName = PSQLServerName;
            StringType _PSQLDbName = PSQLDbName;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ApsSiteInfoSp";

                appDB.AddCommandParameter(cmd, "PSQLServerName", _PSQLServerName, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PSQLDbName", _PSQLDbName, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                PSQLServerName = _PSQLServerName;
                PSQLDbName = _PSQLDbName;

                return (Severity, PSQLServerName, PSQLDbName);
            }
        }
    }
}
