//PROJECT NAME: Logistics
//CLASS NAME: SSSRMXDispQty.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class SSSRMXDispQty : ISSSRMXDispQty
	{
		readonly IApplicationDB appDB;
		
		public SSSRMXDispQty(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? SSSRMXDispQtyFn(
			string RmaNum,
			int? RmaLine)
		{
			RmaNumType _RmaNum = RmaNum;
			RmaLineType _RmaLine = RmaLine;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSRMXDispQty](@RmaNum, @RmaLine)";
				
				appDB.AddCommandParameter(cmd, "RmaNum", _RmaNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RmaLine", _RmaLine, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
