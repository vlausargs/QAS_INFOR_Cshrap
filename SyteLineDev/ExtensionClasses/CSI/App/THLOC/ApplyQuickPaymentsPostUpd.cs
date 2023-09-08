//PROJECT NAME: THLOC
//CLASS NAME: ApplyQuickPaymentsPostUpd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.THLOC
{
    public interface IApplyQuickPaymentsPostUpd
    {
        (ICollectionLoadResponse Data, int? ReturnCode) ApplyQuickPaymentsPostUpdSp(Guid? SessionId);
    }

    public class ApplyQuickPaymentsPostUpd : IApplyQuickPaymentsPostUpd
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;

        public ApplyQuickPaymentsPostUpd(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
            this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
        }

        public (ICollectionLoadResponse Data, int? ReturnCode) ApplyQuickPaymentsPostUpdSp(Guid? SessionId)
        {
            RowPointerType _SessionId = SessionId;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable(); 

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ApplyQuickPaymentsPostUpdSp";

                appDB.AddCommandParameter(cmd, "SessionId", _SessionId, ParameterDirection.Input);

                IntType returnVal = 0;
                IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
                dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
            }
        }
    }
}
