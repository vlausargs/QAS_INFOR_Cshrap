//PROJECT NAME: Logistics
//CLASS NAME: AU_RepricePoitemorBlanketLines.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class AU_RepricePoitemorBlanketLines : IAU_RepricePoitemorBlanketLines
	{
		readonly IApplicationDB appDB;
		
		
		public AU_RepricePoitemorBlanketLines(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? AU_RepricePoitemorBlanketLinesSp(int? LineorBlanketLine,
		string PoNum,
		int? PoLine,
		int? PoRelease,
		decimal? NewPrice)
		{
			ListYesNoType _LineorBlanketLine = LineorBlanketLine;
			PoNumType _PoNum = PoNum;
			PoLineType _PoLine = PoLine;
			PoReleaseType _PoRelease = PoRelease;
			CostPrcType _NewPrice = NewPrice;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AU_RepricePoitemorBlanketLinesSp";
				
				appDB.AddCommandParameter(cmd, "LineorBlanketLine", _LineorBlanketLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoLine", _PoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoRelease", _PoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewPrice", _NewPrice, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
