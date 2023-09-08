//PROJECT NAME: Data
//CLASS NAME: GetShipmentApprovedQty.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetShipmentApprovedQty : IGetShipmentApprovedQty
	{
		readonly IApplicationDB appDB;
		
		public GetShipmentApprovedQty(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? GetShipmentApprovedQtyFn(
			string CoNum,
			int? CoLine,
			int? CoRelease)
		{
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			CoReleaseType _CoRelease = CoRelease;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetShipmentApprovedQty](@CoNum, @CoLine, @CoRelease)";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoRelease", _CoRelease, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
