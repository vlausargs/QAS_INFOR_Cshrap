//PROJECT NAME: Logistics
//CLASS NAME: IRpt_InvoicePayDay.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IRpt_InvoicePayDay
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_InvoicePayDaySp(string PStartInvoice = null,
		string PEndInvoice = null,
		string PStartCustomer = null,
		string PEndCustomer = null,
		int? PDisplayHeader = 1,
		string pSite = null);
	}
}

