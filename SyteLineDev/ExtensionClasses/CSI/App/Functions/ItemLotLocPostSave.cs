//PROJECT NAME: Data
//CLASS NAME: ItemLotLocPostSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ItemLotLocPostSave : IItemLotLocPostSave
	{
		readonly IApplicationDB appDB;
		
		public ItemLotLocPostSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ItemLotLocPostSaveSp(
			string Item,
			string Whse,
			string Lot,
			string Loc,
			decimal? OldUnitCost,
			decimal? OldMatlCost,
			decimal? OldLbrCost,
			decimal? OldFovhdCost,
			decimal? OldVovhdCost,
			decimal? OldOutCost,
			decimal? UnitCost,
			decimal? MatlCost,
			decimal? LbrCost,
			decimal? FovhdCost,
			decimal? VovhdCost,
			decimal? OutCost,
			decimal? QtyOnHand,
			string Infobar)
		{
			ItemType _Item = Item;
			WhseType _Whse = Whse;
			LotType _Lot = Lot;
			LocType _Loc = Loc;
			CostPrcType _OldUnitCost = OldUnitCost;
			CostPrcType _OldMatlCost = OldMatlCost;
			CostPrcType _OldLbrCost = OldLbrCost;
			CostPrcType _OldFovhdCost = OldFovhdCost;
			CostPrcType _OldVovhdCost = OldVovhdCost;
			CostPrcType _OldOutCost = OldOutCost;
			CostPrcType _UnitCost = UnitCost;
			CostPrcType _MatlCost = MatlCost;
			CostPrcType _LbrCost = LbrCost;
			CostPrcType _FovhdCost = FovhdCost;
			CostPrcType _VovhdCost = VovhdCost;
			CostPrcType _OutCost = OutCost;
			QtyUnitType _QtyOnHand = QtyOnHand;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemLotLocPostSaveSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldUnitCost", _OldUnitCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldMatlCost", _OldMatlCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldLbrCost", _OldLbrCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldFovhdCost", _OldFovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldVovhdCost", _OldVovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldOutCost", _OldOutCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitCost", _UnitCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlCost", _MatlCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LbrCost", _LbrCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FovhdCost", _FovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VovhdCost", _VovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OutCost", _OutCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyOnHand", _QtyOnHand, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
