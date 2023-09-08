//PROJECT NAME: CSIProduct
//CLASS NAME: JobStatusChangeMass.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public interface IJobStatusChangeMass
	{
		(ICollectionLoadResponse Data, int? ReturnCode) JobStatusChangeMassSp(string Process,
		string FromJobStatus,
		string FromJobStatusLabel,
		string ToJobStatus,
		string ToJobStatusLabel,
		byte? SelectFinish,
		string StartingJob,
		int? StartingSuffix,
		string EndingJob,
		int? EndingSuffix,
		DateTime? EarliestJobEndDate,
		DateTime? LatestJobEndDate,
		DateTime? EarliestStartDate,
		DateTime? LatestStartDate,
		byte? DeleteHistoryJobs,
		byte? CopyRouting,
		short? EStartDateOffset = null,
		short? LStartDateOffset = null,
		short? EEndDateOffset = null,
		short? LEndDateOffset = null);
	}
	
	public class JobStatusChangeMass : IJobStatusChangeMass
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public JobStatusChangeMass(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) JobStatusChangeMassSp(string Process,
		string FromJobStatus,
		string FromJobStatusLabel,
		string ToJobStatus,
		string ToJobStatusLabel,
		byte? SelectFinish,
		string StartingJob,
		int? StartingSuffix,
		string EndingJob,
		int? EndingSuffix,
		DateTime? EarliestJobEndDate,
		DateTime? LatestJobEndDate,
		DateTime? EarliestStartDate,
		DateTime? LatestStartDate,
		byte? DeleteHistoryJobs,
		byte? CopyRouting,
		short? EStartDateOffset = null,
		short? LStartDateOffset = null,
		short? EEndDateOffset = null,
		short? LEndDateOffset = null)
		{
			StringType _Process = Process;
			JobStatusType _FromJobStatus = FromJobStatus;
			InfobarType _FromJobStatusLabel = FromJobStatusLabel;
			JobStatusType _ToJobStatus = ToJobStatus;
			InfobarType _ToJobStatusLabel = ToJobStatusLabel;
			ListYesNoType _SelectFinish = SelectFinish;
			JobType _StartingJob = StartingJob;
			GenericIntType _StartingSuffix = StartingSuffix;
			JobType _EndingJob = EndingJob;
			GenericIntType _EndingSuffix = EndingSuffix;
			DateType _EarliestJobEndDate = EarliestJobEndDate;
			DateType _LatestJobEndDate = LatestJobEndDate;
			DateType _EarliestStartDate = EarliestStartDate;
			DateType _LatestStartDate = LatestStartDate;
			ListYesNoType _DeleteHistoryJobs = DeleteHistoryJobs;
			ListYesNoType _CopyRouting = CopyRouting;
			DateOffsetType _EStartDateOffset = EStartDateOffset;
			DateOffsetType _LStartDateOffset = LStartDateOffset;
			DateOffsetType _EEndDateOffset = EEndDateOffset;
			DateOffsetType _LEndDateOffset = LEndDateOffset;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobStatusChangeMassSp";
				
				appDB.AddCommandParameter(cmd, "Process", _Process, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromJobStatus", _FromJobStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromJobStatusLabel", _FromJobStatusLabel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToJobStatus", _ToJobStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToJobStatusLabel", _ToJobStatusLabel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SelectFinish", _SelectFinish, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingJob", _StartingJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingSuffix", _StartingSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingJob", _EndingJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingSuffix", _EndingSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EarliestJobEndDate", _EarliestJobEndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LatestJobEndDate", _LatestJobEndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EarliestStartDate", _EarliestStartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LatestStartDate", _LatestStartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DeleteHistoryJobs", _DeleteHistoryJobs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CopyRouting", _CopyRouting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EStartDateOffset", _EStartDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LStartDateOffset", _LStartDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EEndDateOffset", _EEndDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LEndDateOffset", _LEndDateOffset, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
