//PROJECT NAME: Logistics
//CLASS NAME: IPurgeEDIVendorInvoices.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IPurgeEDIVendorInvoices
	{
		(int? ReturnCode, string Message) PurgeEDIVendorInvoicesSp(string VendorStarting = null,
		string VendorEnding = null,
		string PoStarting = null,
		string PoEnding = null,
		DateTime? CDateStarting = null,
		DateTime? CDateEnding = null,
		string ExOptprPostedEmp = null,
		int? CDateStartingOffset = null,
		int? CDateEndingOffset = null,
		string Message = null);
	}
}

