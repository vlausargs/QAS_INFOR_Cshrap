//PROJECT NAME: Data
//CLASS NAME: GetLastExpDateOfCoShip.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetLastExpDateOfCoShip : IGetLastExpDateOfCoShip
	{
		readonly IApplicationDB appDB;
		
		public GetLastExpDateOfCoShip(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public DateTime? GetLastExpDateOfCoShipFn(
			string CoNum,
			int? CoLine)
		{
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetLastExpDateOfCoShip](@CoNum, @CoLine)";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<DateTime?>(cmd);
				
				return Output;
			}
		}
	}
}
