//PROJECT NAME: MG.MGCore
//CLASS NAME: GetReplicationCounter.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.SQL
{
    public class GetReplicationCounter : IGetReplicationCounter
    {
        IApplicationDB appDB;


        public GetReplicationCounter(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public (int? ReturnCode, decimal? OperationCounter,
        string Infobar) GetReplicationCounterSp(string Site,
        decimal? OperationCounter,
        string Infobar)
        {
            SiteType _Site = Site;
            OperationCounterType _OperationCounter = OperationCounter;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetReplicationCounterSp";

                appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OperationCounter", _OperationCounter, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                OperationCounter = _OperationCounter;
                Infobar = _Infobar;

                return (Severity, OperationCounter, Infobar);
            }
        }
    }
}
