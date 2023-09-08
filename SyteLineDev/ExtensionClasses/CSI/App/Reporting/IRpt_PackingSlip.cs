//PROJECT NAME: Reporting
//CLASS NAME: IRpt_PackingSlip.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_PackingSlip
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_PackingSlipSp(string PckCall = null,
		int? MinPackNum = null,
		int? MaxPackNum = null,
		int? PrintOrderText = null,
		int? PrintLineText = null,
		int? PrintDescription = null,
		int? PrintPlanningItemMaterials = null,
		int? IncludeSerialNumbers = null,
		int? ShowInternal = null,
		int? ShowExternal = null,
		int? PrintItemOverview = null,
		int? DisplayHeader = null,
		int? CoTypeRegular = null,
		int? CoTypeBlanket = null,
		string CoStat = null,
		string CoItemStat = null,
		string OrderStarting = null,
		string OrderEnding = null,
		int? OrderLineStarting = null,
		int? OrderReleaseStarting = null,
		int? OrderLineEnding = null,
		int? OrderReleaseEnding = null,
		string CustomerStarting = null,
		string CustomerEnding = null,
		DateTime? OrderDateStarting = null,
		DateTime? OrderDateEnding = null,
		DateTime? DueDateStarting = null,
		DateTime? DueDateEnding = null,
		string pSite = null);
	}
}

