//PROJECT NAME: Reporting
//CLASS NAME: WBCanInvCostGetRecs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting.CriticalNumber
{
	public class WBCanInvCostGetRecs : IWBCanInvCostGetRecs
	{
		readonly IApplicationDB appDB;
		
		public WBCanInvCostGetRecs(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? WBCanInvCostGetRecsSp(
			string Item,
			string Whse,
			string Loc,
			string ProductCode,
			string FamilyCode,
			string PlannerCodeList,
			string ABCCodeList,
			string ItemTypeList,
			string ItemSourceList,
			string ItemStatusList,
			int? ConsumableItem,
			int? KitItem,
			string ProductCodeList,
			string FamilyCodeList,
			string WhseList,
			string ItemList)
		{
			ItemType _Item = Item;
			WhseType _Whse = Whse;
			LocType _Loc = Loc;
			ProductCodeType _ProductCode = ProductCode;
			FamilyCodeType _FamilyCode = FamilyCode;
			LongListType _PlannerCodeList = PlannerCodeList;
			LongListType _ABCCodeList = ABCCodeList;
			LongListType _ItemTypeList = ItemTypeList;
			LongListType _ItemSourceList = ItemSourceList;
			LongListType _ItemStatusList = ItemStatusList;
			ListYesNoType _ConsumableItem = ConsumableItem;
			ListYesNoType _KitItem = KitItem;
			LongListType _ProductCodeList = ProductCodeList;
			LongListType _FamilyCodeList = FamilyCodeList;
			LongListType _WhseList = WhseList;
			LongListType _ItemList = ItemList;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "WBCanInvCostGetRecsSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCode", _ProductCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FamilyCode", _FamilyCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PlannerCodeList", _PlannerCodeList, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ABCCodeList", _ABCCodeList, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemTypeList", _ItemTypeList, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemSourceList", _ItemSourceList, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemStatusList", _ItemStatusList, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ConsumableItem", _ConsumableItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "KitItem", _KitItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCodeList", _ProductCodeList, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FamilyCodeList", _FamilyCodeList, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WhseList", _WhseList, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemList", _ItemList, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
