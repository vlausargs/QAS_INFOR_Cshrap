//PROJECT NAME: Material
//CLASS NAME: ItemLifo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class ItemLifo : IItemLifo
	{
		readonly IApplicationDB appDB;
		
		
		public ItemLifo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ItemLifoSp(int? Delete,
		string ItemlifoItem,
		DateTime? ItemlifoTransDate,
		decimal? ItemlifoQty,
		decimal? ItemlifoUnitCost,
		decimal? ItemlifoMatlCost,
		decimal? ItemlifoLbrCost,
		decimal? ItemlifoFovhdCost,
		decimal? ItemlifoVovhdCost,
		decimal? ItemlifoOutCost,
		string ItemlifoInvAcct,
		string ItemlifoLbrAcct,
		string ItemlifoFovhdAcct,
		string ItemlifoVovhdAcct,
		string ItemlifoOutAcct,
		Guid? ItemlifoRowPointer,
		string ItemlifoRecordDate,
		string ItemlifoWhse,
		string Infobar)
		{
			ListYesNoType _Delete = Delete;
			ItemType _ItemlifoItem = ItemlifoItem;
			DateTimeType _ItemlifoTransDate = ItemlifoTransDate;
			QtyUnitType _ItemlifoQty = ItemlifoQty;
			CostPrcType _ItemlifoUnitCost = ItemlifoUnitCost;
			CostPrcType _ItemlifoMatlCost = ItemlifoMatlCost;
			CostPrcType _ItemlifoLbrCost = ItemlifoLbrCost;
			CostPrcType _ItemlifoFovhdCost = ItemlifoFovhdCost;
			CostPrcType _ItemlifoVovhdCost = ItemlifoVovhdCost;
			CostPrcType _ItemlifoOutCost = ItemlifoOutCost;
			AcctType _ItemlifoInvAcct = ItemlifoInvAcct;
			AcctType _ItemlifoLbrAcct = ItemlifoLbrAcct;
			AcctType _ItemlifoFovhdAcct = ItemlifoFovhdAcct;
			AcctType _ItemlifoVovhdAcct = ItemlifoVovhdAcct;
			AcctType _ItemlifoOutAcct = ItemlifoOutAcct;
			RowPointerType _ItemlifoRowPointer = ItemlifoRowPointer;
			StringType _ItemlifoRecordDate = ItemlifoRecordDate;
			WhseType _ItemlifoWhse = ItemlifoWhse;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemLifoSp";
				
				appDB.AddCommandParameter(cmd, "Delete", _Delete, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemlifoItem", _ItemlifoItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemlifoTransDate", _ItemlifoTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemlifoQty", _ItemlifoQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemlifoUnitCost", _ItemlifoUnitCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemlifoMatlCost", _ItemlifoMatlCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemlifoLbrCost", _ItemlifoLbrCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemlifoFovhdCost", _ItemlifoFovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemlifoVovhdCost", _ItemlifoVovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemlifoOutCost", _ItemlifoOutCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemlifoInvAcct", _ItemlifoInvAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemlifoLbrAcct", _ItemlifoLbrAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemlifoFovhdAcct", _ItemlifoFovhdAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemlifoVovhdAcct", _ItemlifoVovhdAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemlifoOutAcct", _ItemlifoOutAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemlifoRowPointer", _ItemlifoRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemlifoRecordDate", _ItemlifoRecordDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemlifoWhse", _ItemlifoWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
