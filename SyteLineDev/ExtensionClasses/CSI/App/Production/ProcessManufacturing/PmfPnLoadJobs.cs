//PROJECT NAME: CSIProduct
//CLASS NAME: PmfPnLoadJobs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;

namespace CSI.Production
{
    public interface IPmfPnLoadJobs
    {
        (ICollectionLoadResponse Data, int? ReturnCode, string InfoBar) PmfPnLoadJobsSp(string InfoBar = null,
                                                                                        Guid? PnRp = null);
    }

    public class PmfPnLoadJobs : IPmfPnLoadJobs
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;

        public PmfPnLoadJobs(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
            this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
        }

        public (ICollectionLoadResponse Data, int? ReturnCode, string InfoBar) PmfPnLoadJobsSp(string InfoBar = null,
                                                                                               Guid? PnRp = null)
        {
            InfobarType _InfoBar = InfoBar;
            RowPointerType _PnRp = PnRp;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PmfPnLoadJobsSp";

                appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PnRp", _PnRp, ParameterDirection.Input);

                IntType returnVal = 0;
                IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
                dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                InfoBar = _InfoBar;

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, InfoBar);
            }
        }
    }
}
