//PROJECT NAME: Data
//CLASS NAME: BatchCustNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class BatchCustNum : IBatchCustNum
	{
		readonly IApplicationDB appDB;
		
		public BatchCustNum(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string BatchCustNumFn(
			int? PBatchId)
		{
			BatchIdType _PBatchId = PBatchId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[BatchCustNum](@PBatchId)";
				
				appDB.AddCommandParameter(cmd, "PBatchId", _PBatchId, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
