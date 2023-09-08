//PROJECT NAME: MG.MGCore
//CLASS NAME: ExecuteDynamicSQL.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.SQL
{
    public class ExecuteDynamicSQL : IExecuteDynamicSQL
    {
        IApplicationDB appDB;
        IBunchedLoadCollection bunchedLoadCollection;
        IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;

        public ExecuteDynamicSQL(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
            this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
        }

        public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar,
        int? ImpactedRowCount) ExecuteDynamicSQLSp(int? NeedGetMoreRows = 0,
        string Infobar = null,
        int? ImpactedRowCount = 0)
        {
            ListYesNoType _NeedGetMoreRows = NeedGetMoreRows;
            InfobarType _Infobar = Infobar;
            IntType _ImpactedRowCount = ImpactedRowCount;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ExecuteDynamicSQLSp";

                appDB.AddCommandParameter(cmd, "NeedGetMoreRows", _NeedGetMoreRows, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ImpactedRowCount", _ImpactedRowCount, ParameterDirection.InputOutput);

                IntType returnVal = 0;
                IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
                dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                Infobar = _Infobar;
                ImpactedRowCount = _ImpactedRowCount;

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, Infobar, ImpactedRowCount);
            }
        }
    }
}
