//PROJECT NAME: Production
//CLASS NAME: GetBatchedProd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class GetBatchedProd : IGetBatchedProd
	{
		readonly IApplicationDB appDB;
		
		
		public GetBatchedProd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? BatchedProdId) GetBatchedProdSp(int? BatchedProdId)
		{
			ApsBatchNumberType _BatchedProdId = BatchedProdId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetBatchedProdSp";
				
				appDB.AddCommandParameter(cmd, "BatchedProdId", _BatchedProdId, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				BatchedProdId = _BatchedProdId;
				
				return (Severity, BatchedProdId);
			}
		}
	}
}
