//PROJECT NAME: Data
//CLASS NAME: GetJobPlanCost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.Data;

namespace CSI.Functions
{
	public class GetJobPlanCost : IGetJobPlanCost
	{
		readonly IApplicationDB appDB;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		readonly IDataTableUtil dataTableUtil;
		
		public GetJobPlanCost(IApplicationDB appDB, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse, IDataTableUtil dataTableUtil)
		{
			this.appDB = appDB;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
			this.dataTableUtil = dataTableUtil;
		}
		
		public ICollectionLoadResponse GetJobPlanCostFn(
			string Job,
			int? Suffix)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT * FROM dbo.[GetJobPlanCost](@Job, @Suffix)";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				
				dtReturn = appDB.ExecuteQuery(cmd);
				dtReturn.TableName = "#fnt_GetJobPlanCost";
				dataTableUtil.CloneDataTableIntoDB(dtReturn);
				
				return dataTableToCollectionLoadResponse.Process(dtReturn);
			}
		}
	}
}
