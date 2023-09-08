//PROJECT NAME: Reporting
//CLASS NAME: IWBCanInvCostGetRecs.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting.CriticalNumber
{
	public interface IWBCanInvCostGetRecs
	{
		int? WBCanInvCostGetRecsSp(
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
			string ItemList);
	}
}

