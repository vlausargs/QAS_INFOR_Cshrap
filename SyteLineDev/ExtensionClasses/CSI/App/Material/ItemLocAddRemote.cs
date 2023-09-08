//PROJECT NAME: Material
//CLASS NAME: ItemLocAddRemote.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class ItemLocAddRemote : IItemLocAddRemote
	{
		readonly IApplicationDB appDB;
		
		
		public ItemLocAddRemote(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, Guid? RowPointer,
		string Infobar) ItemLocAddRemoteSp(string Whse,
		string Item,
		string Loc,
		int? UcFlag,
		decimal? UnitCost,
		decimal? MatlCost,
		decimal? LbrCost,
		decimal? FovhdCost,
		decimal? VovhdCost,
		decimal? OutCost,
		int? SetPermFlag,
		string Site = null,
		Guid? RowPointer = null,
		string Infobar = null)
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
			SiteType _Site = Site;
			RowPointerType _RowPointer = RowPointer;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemLocAddRemoteSp";
				
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
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RowPointer = _RowPointer;
				Infobar = _Infobar;
				
				return (Severity, RowPointer, Infobar);
			}
		}
	}
}
