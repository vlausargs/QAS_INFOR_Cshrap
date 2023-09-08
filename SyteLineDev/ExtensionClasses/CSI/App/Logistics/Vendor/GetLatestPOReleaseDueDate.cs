//PROJECT NAME: Logistics
//CLASS NAME: GetLatestPOReleaseDueDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GetLatestPOReleaseDueDate : IGetLatestPOReleaseDueDate
	{
		readonly IApplicationDB appDB;
		
		public GetLatestPOReleaseDueDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public DateTime? GetLatestPOReleaseDueDateFn(
			string PoNum,
			int? PoLine)
		{
			PoNumType _PoNum = PoNum;
			PoLineType _PoLine = PoLine;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetLatestPOReleaseDueDate](@PoNum, @PoLine)";
				
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoLine", _PoLine, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<DateTime?>(cmd);
				
				return Output;
			}
		}
	}
}
