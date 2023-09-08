//PROJECT NAME: Reporting
//CLASS NAME: IRpt_PurchaseRequisition.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_PurchaseRequisition
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_PurchaseRequisitionSp(string PreqStat = null,
		string PPreqItemStat = null,
		int? PrintReqNotes = null,
		int? PrintLineNotes = null,
		int? ShowExternal = null,
		int? ShowInternal = null,
		string PreqNumStarting = null,
		string PreqNumEnding = null,
		int? PreqItemStarting = null,
		int? PreqItemEnding = null,
		DateTime? PreqItemDueDateStarting = null,
		DateTime? PreqItemDueDateEnding = null,
		int? PreqItemDueDateStartingOffset = null,
		int? PreqItemDueDateEndingOffset = null,
		string PreqItemVendNumStarting = null,
		string PreqItemVendNumEnding = null,
		int? PrintCost = 0,
		int? DisplayHeader = null,
		string pSite = null);
	}
}

