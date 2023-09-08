//PROJECT NAME: Data
//CLASS NAME: GetCashSummary.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetCashSummary : IGetCashSummary
	{
		readonly IApplicationDB appDB;
		
		public GetCashSummary(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? GetCashSummarySp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetCashSummarySp]()";
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
