//PROJECT NAME: Data
//CLASS NAME: BatchUseExchRate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class BatchUseExchRate : IBatchUseExchRate
	{
		readonly IApplicationDB appDB;
		
		public BatchUseExchRate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? BatchUseExchRateFn(
			int? PBatchId)
		{
			BatchIdType _PBatchId = PBatchId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[BatchUseExchRate](@PBatchId)";
				
				appDB.AddCommandParameter(cmd, "PBatchId", _PBatchId, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
