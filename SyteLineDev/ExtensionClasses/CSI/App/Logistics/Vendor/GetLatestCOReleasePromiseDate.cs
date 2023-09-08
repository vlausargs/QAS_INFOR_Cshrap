//PROJECT NAME: Logistics
//CLASS NAME: GetLatestCOReleasePromiseDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GetLatestCOReleasePromiseDate : IGetLatestCOReleasePromiseDate
	{
		readonly IApplicationDB appDB;
		
		public GetLatestCOReleasePromiseDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public DateTime? GetLatestCOReleasePromiseDateFn(
			string CoNum,
			int? CoLine)
		{
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetLatestCOReleasePromiseDate](@CoNum, @CoLine)";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<DateTime?>(cmd);
				
				return Output;
			}
		}
	}
}
