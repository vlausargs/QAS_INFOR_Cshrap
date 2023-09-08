//PROJECT NAME: Material
//CLASS NAME: MrpVendorRankingInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class MrpVendorRankingInfo : IMrpVendorRankingInfo
	{
		readonly IApplicationDB appDB;
		
		public MrpVendorRankingInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string VendNum,
			int? LeadTime,
			decimal? UnitCost,
			string Infobar) MrpVendorRankingInfoSp(
			string Item,
			decimal? ReqdQty,
			int? Rank,
			string SourceRuleVendNum,
			string VendNum,
			int? LeadTime,
			decimal? UnitCost,
			string Infobar)
		{
			ItemType _Item = Item;
			QtyUnitType _ReqdQty = ReqdQty;
			GenericIntType _Rank = Rank;
			VendNumType _SourceRuleVendNum = SourceRuleVendNum;
			VendNumType _VendNum = VendNum;
			LeadTimeType _LeadTime = LeadTime;
			CostPrcType _UnitCost = UnitCost;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MrpVendorRankingInfoSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReqdQty", _ReqdQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Rank", _Rank, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SourceRuleVendNum", _SourceRuleVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LeadTime", _LeadTime, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitCost", _UnitCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				VendNum = _VendNum;
				LeadTime = _LeadTime;
				UnitCost = _UnitCost;
				Infobar = _Infobar;
				
				return (Severity, VendNum, LeadTime, UnitCost, Infobar);
			}
		}
	}
}
