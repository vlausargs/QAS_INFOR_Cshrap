//PROJECT NAME: Data
//CLASS NAME: CoBlnChangedItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CoBlnChangedItem : ICoBlnChangedItem
	{
		readonly IApplicationDB appDB;
		
		public CoBlnChangedItem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string ShipSite,
			string CustItem,
			string FeatStr,
			string ItemUM,
			string ItemDesc,
			int? ItemPlanFlag,
			int? Kit,
			int? PrintKitComponents,
			int? ItemSerialTracked,
			int? AllowOnPickList,
			string Infobar) CoBlnChangedItemSp(
			string CoNum,
			string Item,
			string CustNum,
			string CustCurrCode,
			string ShipSite,
			string CustItem,
			string FeatStr,
			string ItemUM,
			string ItemDesc,
			int? ItemPlanFlag,
			int? Kit,
			int? PrintKitComponents,
			int? ItemSerialTracked,
			int? AllowOnPickList,
			string Infobar)
		{
			CoNumType _CoNum = CoNum;
			ItemType _Item = Item;
			CustNumType _CustNum = CustNum;
			CurrCodeType _CustCurrCode = CustCurrCode;
			SiteType _ShipSite = ShipSite;
			CustItemType _CustItem = CustItem;
			FeatStrType _FeatStr = FeatStr;
			UMType _ItemUM = ItemUM;
			DescriptionType _ItemDesc = ItemDesc;
			FlagNyType _ItemPlanFlag = ItemPlanFlag;
			ListYesNoType _Kit = Kit;
			ListYesNoType _PrintKitComponents = PrintKitComponents;
			ListYesNoType _ItemSerialTracked = ItemSerialTracked;
			ListYesNoType _AllowOnPickList = AllowOnPickList;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CoBlnChangedItemSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustCurrCode", _CustCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipSite", _ShipSite, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustItem", _CustItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FeatStr", _FeatStr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemUM", _ItemUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemDesc", _ItemDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemPlanFlag", _ItemPlanFlag, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Kit", _Kit, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrintKitComponents", _PrintKitComponents, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemSerialTracked", _ItemSerialTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AllowOnPickList", _AllowOnPickList, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ShipSite = _ShipSite;
				CustItem = _CustItem;
				FeatStr = _FeatStr;
				ItemUM = _ItemUM;
				ItemDesc = _ItemDesc;
				ItemPlanFlag = _ItemPlanFlag;
				Kit = _Kit;
				PrintKitComponents = _PrintKitComponents;
				ItemSerialTracked = _ItemSerialTracked;
				AllowOnPickList = _AllowOnPickList;
				Infobar = _Infobar;
				
				return (Severity, ShipSite, CustItem, FeatStr, ItemUM, ItemDesc, ItemPlanFlag, Kit, PrintKitComponents, ItemSerialTracked, AllowOnPickList, Infobar);
			}
		}
	}
}
