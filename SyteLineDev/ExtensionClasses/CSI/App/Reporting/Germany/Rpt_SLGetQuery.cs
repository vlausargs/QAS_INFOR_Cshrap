//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SLGetQuery.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting.Germany
{
    public class Rpt_SLGetQuery : IRpt_SLGetQuery
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;

        public Rpt_SLGetQuery(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
            this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
        }

        public (ICollectionLoadResponse Data, int? ReturnCode,
            string SqlQuery) Rpt_SLGetQuerySp(
            string IDOName,
            string SqlQuery)
        {
            StringType _IDOName = IDOName;
            StringType _SqlQuery = SqlQuery;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Rpt_SLGetQuerySp";

                appDB.AddCommandParameter(cmd, "IDOName", _IDOName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SqlQuery", _SqlQuery, ParameterDirection.InputOutput);

                IntType returnVal = 0;
                IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
                dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                SqlQuery = _SqlQuery;

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, SqlQuery);
            }
        }
    }
}
