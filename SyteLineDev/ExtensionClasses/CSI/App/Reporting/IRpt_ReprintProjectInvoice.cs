//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ReprintProjectInvoice.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ReprintProjectInvoice
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ReprintProjectInvoiceSp(string InvoiceStarting = null,
		string InvoiceEnding = null,
		DateTime? InvoiceDateStarting = null,
		DateTime? InvoiceDateEnding = null,
		string ProjectStarting = null,
		string ProjectEnding = null,
		string CustomerStarting = null,
		string CustomerEnding = null,
		int? PrintEuroTotal = null,
		int? TransDomCurr = null,
		int? InvoiceDateStartingOffset = null,
		int? InvoiceDateEndingOffset = null,
		int? PrintMilestoneNotes = null,
		int? PrintCustomerNotes = null,
		int? PrintProjectNotes = null,
		int? PrintStandardNotes = null,
		int? ShowInternal = null,
		int? ShowExternal = null,
		int? DisplayHeader = null,
		int? PrintDiscountAmt = 0,
		int? TaskId = null,
		string pSite = null,
		int? CallFromReport = 0);
	}
}

