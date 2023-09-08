//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ProjectedJobCostToComplete.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ProjectedJobCostToComplete : IRpt_ProjectedJobCostToComplete
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ProjectedJobCostToComplete(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ProjectedJobCostToCompleteSp(string PStartingJob = null,
		string PEndingJob = null,
		int? PStartingSubJob = null,
		int? PEndingSubJob = null,
		string PJobStatus = "RS",
		decimal? PUnderPlanVar = null,
		decimal? POverPlanVar = null,
		string PStartingItem = null,
		string PEndingItem = null,
		int? PShowDetail = 0,
		int? PDisplayHeader = 1,
		string pSite = null)
		{
			JobType _PStartingJob = PStartingJob;
			JobType _PEndingJob = PEndingJob;
			IntType _PStartingSubJob = PStartingSubJob;
			IntType _PEndingSubJob = PEndingSubJob;
			Infobar _PJobStatus = PJobStatus;
			AmtTotType _PUnderPlanVar = PUnderPlanVar;
			AmtTotType _POverPlanVar = POverPlanVar;
			ItemType _PStartingItem = PStartingItem;
			ItemType _PEndingItem = PEndingItem;
			ListYesNoType _PShowDetail = PShowDetail;
			ListYesNoType _PDisplayHeader = PDisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ProjectedJobCostToCompleteSp";
				
				appDB.AddCommandParameter(cmd, "PStartingJob", _PStartingJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingJob", _PEndingJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingSubJob", _PStartingSubJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingSubJob", _PEndingSubJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJobStatus", _PJobStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUnderPlanVar", _PUnderPlanVar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POverPlanVar", _POverPlanVar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingItem", _PStartingItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingItem", _PEndingItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PShowDetail", _PShowDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDisplayHeader", _PDisplayHeader, ParameterDirection.Input);
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
