//PROJECT NAME: Data
//CLASS NAME: GetJobMatlSerialUsage.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.Data;

namespace CSI.Functions
{
	public class GetJobMatlSerialUsage : IGetJobMatlSerialUsage
	{
		readonly IApplicationDB appDB;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		readonly IDataTableUtil dataTableUtil;
		
		public GetJobMatlSerialUsage(IApplicationDB appDB, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse, IDataTableUtil dataTableUtil)
		{
			this.appDB = appDB;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
			this.dataTableUtil = dataTableUtil;
		}
		
		public ICollectionLoadResponse GetJobMatlSerialUsageFn(
			string Job,
			int? Suffix,
			int? OperNum,
			string EndItem,
			string EndItemSerial,
			string JobMatlItem,
			string JobMatlSerial)
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
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT * FROM dbo.[GetJobMatlSerialUsage](@Job, @Suffix, @OperNum, @EndItem, @EndItemSerial, @JobMatlItem, @JobMatlSerial)";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndItem", _EndItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndItemSerial", _EndItemSerial, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobMatlItem", _JobMatlItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobMatlSerial", _JobMatlSerial, ParameterDirection.Input);
				
				dtReturn = appDB.ExecuteQuery(cmd);
				dtReturn.TableName = "#fnt_GetJobMatlSerialUsage";
				dataTableUtil.CloneDataTableIntoDB(dtReturn);
				
				return dataTableToCollectionLoadResponse.Process(dtReturn);
			}
		}
	}
}
