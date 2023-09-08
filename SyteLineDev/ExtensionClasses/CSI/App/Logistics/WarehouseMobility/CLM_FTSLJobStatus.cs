//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLJobStatus.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLJobStatus : ICLM_FTSLJobStatus
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_FTSLJobStatus(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_FTSLJobStatusSp(string JobStart,
		string JobEnd,
		int? SuffixStart,
		int? SuffixEnd,
		string WorkCenterStart,
		string WorkCenterEnd,
		DateTime? StartDate,
		DateTime? EndDate,
		int? SortBy,
		int? Clear)
		{
			JobType _JobStart = JobStart;
			JobType _JobEnd = JobEnd;
			SuffixType _SuffixStart = SuffixStart;
			SuffixType _SuffixEnd = SuffixEnd;
			WcType _WorkCenterStart = WorkCenterStart;
			WcType _WorkCenterEnd = WorkCenterEnd;
			DateType _StartDate = StartDate;
			DateType _EndDate = EndDate;
			CustSeqType _SortBy = SortBy;
			CustSeqType _Clear = Clear;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_FTSLJobStatusSp";
				
				appDB.AddCommandParameter(cmd, "JobStart", _JobStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobEnd", _JobEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SuffixStart", _SuffixStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SuffixEnd", _SuffixEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WorkCenterStart", _WorkCenterStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WorkCenterEnd", _WorkCenterEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SortBy", _SortBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Clear", _Clear, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
