//PROJECT NAME: Logistics
//CLASS NAME: AU_GetPoItemReleaseCost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class AU_GetPoItemReleaseCost : IAU_GetPoItemReleaseCost
	{
		readonly IApplicationDB appDB;
		
		public AU_GetPoItemReleaseCost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? UnitMatCostConv,
			string Infobar) AU_GetPoItemReleaseCostSp(
			string PoNum,
			int? PoLine,
			int? PoRelease,
			decimal? UnitMatCostConv,
			string Infobar)
		{
			PoNumType _PoNum = PoNum;
			PoLineType _PoLine = PoLine;
			PoReleaseType _PoRelease = PoRelease;
			CostPrcType _UnitMatCostConv = UnitMatCostConv;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AU_GetPoItemReleaseCostSp";
				
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoLine", _PoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoRelease", _PoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitMatCostConv", _UnitMatCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				UnitMatCostConv = _UnitMatCostConv;
				Infobar = _Infobar;
				
				return (Severity, UnitMatCostConv, Infobar);
			}
		}
	}
}
