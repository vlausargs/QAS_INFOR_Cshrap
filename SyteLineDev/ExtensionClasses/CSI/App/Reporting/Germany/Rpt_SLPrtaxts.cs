//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SLPrtaxts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting.Germany
{
    public class Rpt_SLPrtaxts : IRpt_SLPrtaxts
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;

        public Rpt_SLPrtaxts(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
            this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
        }
        public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_GetBDTransferData(string ProgramName, DateTime? TransDateBeg, DateTime? TransDateEnd, string SiteID)
        {
            return Rpt_SLPrtaxtsSp(TransDateBeg, TransDateEnd, SiteID);
        }
        public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SLPrtaxtsSp(
            DateTime? TransDateBeg,
            DateTime? TransDateEnd,
            string SiteID)
        {
            DateType _TransDateBeg = TransDateBeg;
            DateType _TransDateEnd = TransDateEnd;
            StringType _SiteID = SiteID;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Rpt_SLPrtaxtsSp";

                appDB.AddCommandParameter(cmd, "TransDateBeg", _TransDateBeg, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TransDateEnd", _TransDateEnd, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SiteID", _SiteID, ParameterDirection.Input);

                IntType returnVal = 0;
                IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
                dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
            }
        }
    }
}
