//PROJECT NAME: Logistics
//CLASS NAME: AU_RecalculatePOBlanketReleaseCost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class AU_RecalculatePOBlanketReleaseCost : IAU_RecalculatePOBlanketReleaseCost
	{
		readonly IApplicationDB appDB;
		
		public AU_RecalculatePOBlanketReleaseCost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) AU_RecalculatePOBlanketReleaseCostSp(
			string PoNum,
			int? PoLine,
			decimal? UnitCost,
			string Infobar,
			string Site = null)
		{
			PoNumType _PoNum = PoNum;
			PoLineType _PoLine = PoLine;
			CostPrcType _UnitCost = UnitCost;
			Infobar _Infobar = Infobar;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AU_RecalculatePOBlanketReleaseCostSp";
				
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoLine", _PoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitCost", _UnitCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
