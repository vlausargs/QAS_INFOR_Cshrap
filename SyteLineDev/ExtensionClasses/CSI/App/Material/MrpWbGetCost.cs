//PROJECT NAME: Material
//CLASS NAME: MrpWbGetCost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class MrpWbGetCost : IMrpWbGetCost
	{
		readonly IApplicationDB appDB;
		
		
		public MrpWbGetCost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? LeadTime,
		decimal? UnitCost,
		string Infobar) MrpWbGetCostSp(string Item,
		decimal? ReqdQty,
		string VendNum,
		string ToWhse,
		int? LeadTime,
		decimal? UnitCost,
		string Infobar = null)
		{
			ItemType _Item = Item;
			QtyTotlType _ReqdQty = ReqdQty;
			VendNumType _VendNum = VendNum;
			WhseType _ToWhse = ToWhse;
			LeadTimeType _LeadTime = LeadTime;
			CostPrcType _UnitCost = UnitCost;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MrpWbGetCostSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReqdQty", _ReqdQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToWhse", _ToWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LeadTime", _LeadTime, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitCost", _UnitCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				LeadTime = _LeadTime;
				UnitCost = _UnitCost;
				Infobar = _Infobar;
				
				return (Severity, LeadTime, UnitCost, Infobar);
			}
		}
	}
}
