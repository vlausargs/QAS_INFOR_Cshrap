//PROJECT NAME: Logistics
//CLASS NAME: GetLatestCOReleaseShipDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GetLatestCOReleaseShipDate : IGetLatestCOReleaseShipDate
	{
		readonly IApplicationDB appDB;
		
		public GetLatestCOReleaseShipDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public DateTime? GetLatestCOReleaseShipDateFn(
			string CoNum,
			int? CoLine)
		{
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetLatestCOReleaseShipDate](@CoNum, @CoLine)";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<DateTime?>(cmd);
				
				return Output;
			}
		}
	}
}
