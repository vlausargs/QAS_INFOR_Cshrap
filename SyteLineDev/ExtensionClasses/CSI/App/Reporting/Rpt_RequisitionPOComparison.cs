//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RequisitionPOComparison.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_RequisitionPOComparison : IRpt_RequisitionPOComparison
	{
		IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_RequisitionPOComparison(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_RequisitionPOComparisonSP(string ReqNumStarting,
		string ReqNumEnding,
		int? ReqLineStarting,
		int? ReqLineEnding,
		int? ShowCost,
		int? DisplayHeader,
		string BGSessionId = null,
		string pSite = null)
		{
			HighLowCharType _ReqNumStarting = ReqNumStarting;
			HighLowCharType _ReqNumEnding = ReqNumEnding;
			GenericIntType _ReqLineStarting = ReqLineStarting;
			GenericIntType _ReqLineEnding = ReqLineEnding;
			FlagNyType _ShowCost = ShowCost;
			FlagNyType _DisplayHeader = DisplayHeader;
			StringType _BGSessionId = BGSessionId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_RequisitionPOComparisonSP";
				
				appDB.AddCommandParameter(cmd, "ReqNumStarting", _ReqNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReqNumEnding", _ReqNumEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReqLineStarting", _ReqLineStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReqLineEnding", _ReqLineEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowCost", _ShowCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
