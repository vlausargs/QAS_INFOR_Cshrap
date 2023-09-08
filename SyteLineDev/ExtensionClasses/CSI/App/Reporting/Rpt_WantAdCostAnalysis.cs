//PROJECT NAME: Reporting
//CLASS NAME: Rpt_WantAdCostAnalysis.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_WantAdCostAnalysis : IRpt_WantAdCostAnalysis
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_WantAdCostAnalysis(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_WantAdCostAnalysisSp(int? PWaNumStarting = null,
		int? PWaNumEnding = null,
		DateTime? PDateStarting = null,
		DateTime? PDateEnding = null,
		string PSortBy = null,
		int? PPrintCost = 0,
		string PSite = null)
		{
			WaNumType _PWaNumStarting = PWaNumStarting;
			WaNumType _PWaNumEnding = PWaNumEnding;
			DateType _PDateStarting = PDateStarting;
			DateType _PDateEnding = PDateEnding;
			InfobarType _PSortBy = PSortBy;
			IntType _PPrintCost = PPrintCost;
			SiteType _PSite = PSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_WantAdCostAnalysisSp";
				
				appDB.AddCommandParameter(cmd, "PWaNumStarting", _PWaNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PWaNumEnding", _PWaNumEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDateStarting", _PDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDateEnding", _PDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSortBy", _PSortBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPrintCost", _PPrintCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
