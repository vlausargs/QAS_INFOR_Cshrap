//PROJECT NAME: Data
//CLASS NAME: ICoBlnChangedItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICoBlnChangedItem
	{
		(int? ReturnCode,
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
			string Infobar);
	}
}

