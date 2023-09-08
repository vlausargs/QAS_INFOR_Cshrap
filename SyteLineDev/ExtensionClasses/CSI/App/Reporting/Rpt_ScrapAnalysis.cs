//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ScrapAnalysis.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ScrapAnalysis : IRpt_ScrapAnalysis
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ScrapAnalysis(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ScrapAnalysisSp(string PStartingItem = null,
		string PEndingItem = null,
		string PStartingProdCode = null,
		string PEndingProdCode = null,
		DateTime? PStartingJobDate = null,
		DateTime? PEndingJobDate = null,
		string PJobStatus = "RSCH",
		int? PPageBetweenItem = 1,
		int? PShowDetail = 1,
		string PSortBy = "I",
		int? PStartingJobDateOffset = null,
		int? PEndingJobDateOffset = null,
		int? PDisplayHeader = 1,
		string PStartingJob = null,
		string PEndingJob = null,
		int? PStartingJobSuffix = null,
		int? PEndingJobSuffix = null,
		string PStartingWorkCenter = null,
		string PEndingWorkCenter = null,
		string PStartingReason = null,
		string PEndingReason = null,
		DateTime? PStartingTransDate = null,
		DateTime? PEndingTransDate = null,
		int? PStartingTransDateOffset = null,
		int? PEndingTransDateOffset = null,
		string BGSessionId = null,
		string pSite = null,
		string BGUser = null)
		{
			ItemType _PStartingItem = PStartingItem;
			ItemType _PEndingItem = PEndingItem;
			ProductCodeType _PStartingProdCode = PStartingProdCode;
			ProductCodeType _PEndingProdCode = PEndingProdCode;
			DateType _PStartingJobDate = PStartingJobDate;
			DateType _PEndingJobDate = PEndingJobDate;
			InfobarType _PJobStatus = PJobStatus;
			ListYesNoType _PPageBetweenItem = PPageBetweenItem;
			ListYesNoType _PShowDetail = PShowDetail;
			InfobarType _PSortBy = PSortBy;
			DateOffsetType _PStartingJobDateOffset = PStartingJobDateOffset;
			DateOffsetType _PEndingJobDateOffset = PEndingJobDateOffset;
			ListYesNoType _PDisplayHeader = PDisplayHeader;
			JobType _PStartingJob = PStartingJob;
			JobType _PEndingJob = PEndingJob;
			SuffixType _PStartingJobSuffix = PStartingJobSuffix;
			SuffixType _PEndingJobSuffix = PEndingJobSuffix;
			WcType _PStartingWorkCenter = PStartingWorkCenter;
			WcType _PEndingWorkCenter = PEndingWorkCenter;
			ReasonCodeType _PStartingReason = PStartingReason;
			ReasonCodeType _PEndingReason = PEndingReason;
			DateType _PStartingTransDate = PStartingTransDate;
			DateType _PEndingTransDate = PEndingTransDate;
			DateOffsetType _PStartingTransDateOffset = PStartingTransDateOffset;
			DateOffsetType _PEndingTransDateOffset = PEndingTransDateOffset;
			StringType _BGSessionId = BGSessionId;
			SiteType _pSite = pSite;
			UsernameType _BGUser = BGUser;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ScrapAnalysisSp";
				
				appDB.AddCommandParameter(cmd, "PStartingItem", _PStartingItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingItem", _PEndingItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingProdCode", _PStartingProdCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingProdCode", _PEndingProdCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingJobDate", _PStartingJobDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingJobDate", _PEndingJobDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJobStatus", _PJobStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPageBetweenItem", _PPageBetweenItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PShowDetail", _PShowDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSortBy", _PSortBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingJobDateOffset", _PStartingJobDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingJobDateOffset", _PEndingJobDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDisplayHeader", _PDisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingJob", _PStartingJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingJob", _PEndingJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingJobSuffix", _PStartingJobSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingJobSuffix", _PEndingJobSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingWorkCenter", _PStartingWorkCenter, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingWorkCenter", _PEndingWorkCenter, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingReason", _PStartingReason, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingReason", _PEndingReason, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingTransDate", _PStartingTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingTransDate", _PEndingTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingTransDateOffset", _PStartingTransDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingTransDateOffset", _PEndingTransDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGUser", _BGUser, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
