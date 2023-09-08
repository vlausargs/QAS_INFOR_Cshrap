//PROJECT NAME: DataCollection
//CLASS NAME: ItemLocAdd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class ItemLocAdd : IItemLocAdd
	{
		readonly IApplicationDB appDB;
		
		
		public ItemLocAdd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, Guid? RowPointer,
		string Infobar) ItemLocAddSp(string Whse,
		string Item,
		string Loc,
		int? UcFlag,
		decimal? UnitCost,
		decimal? MatlCost,
		decimal? LbrCost,
		decimal? FovhdCost,
		decimal? VovhdCost,
		decimal? OutCost,
		int? SetPermFlag = 0,
		Guid? RowPointer = null,
		string Infobar = null,
		int? PermFlagValue = null,
		int? MrbFlagValue = null,
		int? locMrbFlag = null,
		string locLocType = null,
		string locWC = null)
		{
			WhseType _Whse = Whse;
			ItemType _Item = Item;
			LocType _Loc = Loc;
			ListYesNoType _UcFlag = UcFlag;
			CostPrcType _UnitCost = UnitCost;
			CostPrcType _MatlCost = MatlCost;
			CostPrcType _LbrCost = LbrCost;
			CostPrcType _FovhdCost = FovhdCost;
			CostPrcType _VovhdCost = VovhdCost;
			CostPrcType _OutCost = OutCost;
			ListYesNoType _SetPermFlag = SetPermFlag;
			RowPointerType _RowPointer = RowPointer;
			InfobarType _Infobar = Infobar;
			ListYesNoType _PermFlagValue = PermFlagValue;
			ListYesNoType _MrbFlagValue = MrbFlagValue;
			ListYesNoType _locMrbFlag = locMrbFlag;
			LocTypeType _locLocType = locLocType;
			WcType _locWC = locWC;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemLocAddSp";
				
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UcFlag", _UcFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitCost", _UnitCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlCost", _MatlCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LbrCost", _LbrCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FovhdCost", _FovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VovhdCost", _VovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OutCost", _OutCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SetPermFlag", _SetPermFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PermFlagValue", _PermFlagValue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MrbFlagValue", _MrbFlagValue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "locMrbFlag", _locMrbFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "locLocType", _locLocType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "locWC", _locWC, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RowPointer = _RowPointer;
				Infobar = _Infobar;
				
				return (Severity, RowPointer, Infobar);
			}
		}
	}
}
