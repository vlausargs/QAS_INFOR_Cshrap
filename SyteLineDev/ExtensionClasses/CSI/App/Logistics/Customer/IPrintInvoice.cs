//PROJECT NAME: Logistics
//CLASS NAME: IPrintInvoice.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IPrintInvoice
	{
		(int? ReturnCode,
			int? Error,
			string Infobar) PrintInvoiceSp(
			string CustomerNum,
			string InvoiceNum,
			int? InvoiceSeq,
			int? EPlaces,
			int? EuroExists,
			string DocType,
			int? PrintDocTxt,
			int? PrintStdOrderTxt,
			int? PrintCustMstrTxt,
			int? TransDomCurr,
			int? PrintEuroTotal,
			int? ShowInternal,
			int? ShowExternal,
			DateTime? DocDate,
			int? Error,
			string Infobar = null,
			int? PrePrint = null);
	}
}

