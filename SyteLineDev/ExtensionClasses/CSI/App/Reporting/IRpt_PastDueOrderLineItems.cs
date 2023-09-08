//PROJECT NAME: Reporting
//CLASS NAME: IRpt_PastDueOrderLineItems.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_PastDueOrderLineItems
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_PastDueOrderLineItemsSp(DateTime? pAsOfDate = null,
		string pCoType = null,
		string pCoStat = null,
		string pCoitemStat = null,
		string pcredit_hold = null,
		string pBegItem = null,
		string pEndItem = null,
		string pBegCI = null,
		string pEndCI = null,
		DateTime? pBegDueDate = null,
		DateTime? pEndDueDate = null,
		DateTime? pBegLastShipDate = null,
		DateTime? pEndLastShipDate = null,
		string pBegOrder = null,
		string pEndOrder = null,
		string pBegCustomer = null,
		string pEndCustomer = null,
		DateTime? pBegOrderDate = null,
		DateTime? pEndOrderDate = null,
		int? StartDateOffset = null,
		int? EndDateOffset = null,
		int? StartDateDueDateOffset = null,
		int? EndDateDueDateOffset = null,
		int? StartDateShipDateOffset = null,
		int? EndDateShipDateOffset = null,
		int? DateOffset = null,
		int? pDisplayHeader = null,
		string pSite = null);
	}
}

