//PROJECT NAME: Reporting
//CLASS NAME: LedgerConsol.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class LedgerConsol : ILedgerConsol
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public LedgerConsol(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) LedgerConsolSp(string pConsolidated = null,
		DateTime? pCutoffDate = null,
		DateTime? pCTADate = null,
		int? pPostTrx = null,
		string pMode = null,
		int? pSummaryOrDetail = null,
		int? pYearEnd = null,
		int? pUseCTADate = null,
		int? FASB52Override = null,
		decimal? UserID = null,
		string BGSessionId = null,
		string pSite = null)
		{
			StringType _pConsolidated = pConsolidated;
			DateType _pCutoffDate = pCutoffDate;
			DateType _pCTADate = pCTADate;
			Flag _pPostTrx = pPostTrx;
			StringType _pMode = pMode;
			Flag _pSummaryOrDetail = pSummaryOrDetail;
			Flag _pYearEnd = pYearEnd;
			Flag _pUseCTADate = pUseCTADate;
			ListYesNoType _FASB52Override = FASB52Override;
			TokenType _UserID = UserID;
			StringType _BGSessionId = BGSessionId;
			SiteType _pSite = pSite;

            if (bunchedLoadCollection != null)
                bunchedLoadCollection.StartBunching();

            using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LedgerConsolSp";
				
				appDB.AddCommandParameter(cmd, "pConsolidated", _pConsolidated, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCutoffDate", _pCutoffDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCTADate", _pCTADate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPostTrx", _pPostTrx, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pMode", _pMode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSummaryOrDetail", _pSummaryOrDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pYearEnd", _pYearEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pUseCTADate", _pUseCTADate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FASB52Override", _FASB52Override, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserID", _UserID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);

                if (bunchedLoadCollection != null)
                    bunchedLoadCollection.EndBunching();

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
