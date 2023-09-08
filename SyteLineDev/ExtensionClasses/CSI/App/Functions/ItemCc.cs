//PROJECT NAME: Data
//CLASS NAME: ItemCc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ItemCc : IItemCc
	{
		readonly IApplicationDB appDB;
		
		public ItemCc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? NewUnitCost,
			decimal? NewMatlCost,
			decimal? NewLbrCost,
			decimal? NewFovhdCost,
			decimal? NewVovhdCost,
			decimal? NewOutCost,
			decimal? NewAvgUCost,
			decimal? NewAvgMatlCost,
			decimal? NewAvgLbrCost,
			decimal? NewAvgFovhdCost,
			decimal? NewAvgVovhdCost,
			decimal? NewAvgOutCost,
			string Infobar) ItemCcSp(
			int? LotTracked,
			int? AddMode,
			Guid? ItemRowPointer,
			string OldCostMethod,
			string OldCostType,
			decimal? OldUnitCost,
			decimal? OldMatlCost,
			decimal? OldLbrCost,
			decimal? OldFovhdCost,
			decimal? OldVovhdCost,
			decimal? OldOutCost,
			string NewCostMethod,
			string NewCostType,
			decimal? NewUnitCost,
			decimal? NewMatlCost,
			decimal? NewLbrCost,
			decimal? NewFovhdCost,
			decimal? NewVovhdCost,
			decimal? NewOutCost,
			decimal? NewAvgUCost,
			decimal? NewAvgMatlCost,
			decimal? NewAvgLbrCost,
			decimal? NewAvgFovhdCost,
			decimal? NewAvgVovhdCost,
			decimal? NewAvgOutCost,
			string Infobar,
			string Whse)
		{
			ListYesNoType _LotTracked = LotTracked;
			ListYesNoType _AddMode = AddMode;
			RowPointer _ItemRowPointer = ItemRowPointer;
			CostMethodType _OldCostMethod = OldCostMethod;
			CostTypeType _OldCostType = OldCostType;
			CostPrcType _OldUnitCost = OldUnitCost;
			CostPrcType _OldMatlCost = OldMatlCost;
			CostPrcType _OldLbrCost = OldLbrCost;
			CostPrcType _OldFovhdCost = OldFovhdCost;
			CostPrcType _OldVovhdCost = OldVovhdCost;
			CostPrcType _OldOutCost = OldOutCost;
			CostMethodType _NewCostMethod = NewCostMethod;
			CostTypeType _NewCostType = NewCostType;
			CostPrcType _NewUnitCost = NewUnitCost;
			CostPrcType _NewMatlCost = NewMatlCost;
			CostPrcType _NewLbrCost = NewLbrCost;
			CostPrcType _NewFovhdCost = NewFovhdCost;
			CostPrcType _NewVovhdCost = NewVovhdCost;
			CostPrcType _NewOutCost = NewOutCost;
			CostPrcType _NewAvgUCost = NewAvgUCost;
			CostPrcType _NewAvgMatlCost = NewAvgMatlCost;
			CostPrcType _NewAvgLbrCost = NewAvgLbrCost;
			CostPrcType _NewAvgFovhdCost = NewAvgFovhdCost;
			CostPrcType _NewAvgVovhdCost = NewAvgVovhdCost;
			CostPrcType _NewAvgOutCost = NewAvgOutCost;
			InfobarType _Infobar = Infobar;
			WhseType _Whse = Whse;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemCcSp";
				
				appDB.AddCommandParameter(cmd, "LotTracked", _LotTracked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AddMode", _AddMode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemRowPointer", _ItemRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldCostMethod", _OldCostMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldCostType", _OldCostType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldUnitCost", _OldUnitCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldMatlCost", _OldMatlCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldLbrCost", _OldLbrCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldFovhdCost", _OldFovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldVovhdCost", _OldVovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldOutCost", _OldOutCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewCostMethod", _NewCostMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewCostType", _NewCostType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewUnitCost", _NewUnitCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NewMatlCost", _NewMatlCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NewLbrCost", _NewLbrCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NewFovhdCost", _NewFovhdCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NewVovhdCost", _NewVovhdCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NewOutCost", _NewOutCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NewAvgUCost", _NewAvgUCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NewAvgMatlCost", _NewAvgMatlCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NewAvgLbrCost", _NewAvgLbrCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NewAvgFovhdCost", _NewAvgFovhdCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NewAvgVovhdCost", _NewAvgVovhdCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NewAvgOutCost", _NewAvgOutCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				NewUnitCost = _NewUnitCost;
				NewMatlCost = _NewMatlCost;
				NewLbrCost = _NewLbrCost;
				NewFovhdCost = _NewFovhdCost;
				NewVovhdCost = _NewVovhdCost;
				NewOutCost = _NewOutCost;
				NewAvgUCost = _NewAvgUCost;
				NewAvgMatlCost = _NewAvgMatlCost;
				NewAvgLbrCost = _NewAvgLbrCost;
				NewAvgFovhdCost = _NewAvgFovhdCost;
				NewAvgVovhdCost = _NewAvgVovhdCost;
				NewAvgOutCost = _NewAvgOutCost;
				Infobar = _Infobar;
				
				return (Severity, NewUnitCost, NewMatlCost, NewLbrCost, NewFovhdCost, NewVovhdCost, NewOutCost, NewAvgUCost, NewAvgMatlCost, NewAvgLbrCost, NewAvgFovhdCost, NewAvgVovhdCost, NewAvgOutCost, Infobar);
			}
		}
	}
}
