//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ToBeInvoiced.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ToBeInvoiced
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ToBeInvoicedSp(string OrderStarting = null,
		string OrderEnding = null,
		DateTime? OrderDateStarting = null,
		DateTime? OrderDateEnding = null,
		string CustomerStarting = null,
		string CustomerEnding = null,
		string SlsmanStarting = null,
		string SlsmanEnding = null,
		string CustPOStarting = null,
		string CustPOEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		string CustItemStarting = null,
		string CustItemEnding = null,
		DateTime? ShipDateStarting = null,
		DateTime? ShipDateEnding = null,
		DateTime? DueDateStarting = null,
		DateTime? DueDateEnding = null,
		string InvoiceType = null,
		string COStatus = null,
		string COItemStatus = null,
		string SortBy = null,
		int? ShowDetail = null,
		int? OrderDateStartingOffSET = null,
		int? OrderDateEndingOffSET = null,
		int? ShipDateStartingOffSET = null,
		int? ShipDateEndingOffSET = null,
		int? DueDateStartingOffSET = null,
		int? DueDateEndingOffSET = null,
		int? ShowPrice = null,
		int? DisplayHeader = null,
		int? IncludeInvoiceHold = null,
		string pSite = null,
        DateTime? InvDate = null,
        Guid? ProcessId = null);
	}
}

