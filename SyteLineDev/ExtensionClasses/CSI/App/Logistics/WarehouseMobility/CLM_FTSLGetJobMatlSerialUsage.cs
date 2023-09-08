//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLGetJobMatlSerialUsage.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLGetJobMatlSerialUsage : ICLM_FTSLGetJobMatlSerialUsage
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_FTSLGetJobMatlSerialUsage(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_FTSLGetJobMatlSerialUsageSp(string Job = null,
		int? Suffix = null,
		int? OperNum = null,
		string EndItem = null,
		string EndItemSerial = null,
		string JobMatlItem = null,
		string JobMatlSerial = null)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			OperNumType _OperNum = OperNum;
			ItemType _EndItem = EndItem;
			SerNumType _EndItemSerial = EndItemSerial;
			ItemType _JobMatlItem = JobMatlItem;
			SerNumType _JobMatlSerial = JobMatlSerial;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_FTSLGetJobMatlSerialUsageSp";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndItem", _EndItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndItemSerial", _EndItemSerial, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobMatlItem", _JobMatlItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobMatlSerial", _JobMatlSerial, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
