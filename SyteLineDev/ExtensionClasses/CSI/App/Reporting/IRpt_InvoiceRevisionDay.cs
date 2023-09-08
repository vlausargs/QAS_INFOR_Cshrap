//PROJECT NAME: Reporting
//CLASS NAME: IRpt_InvoiceRevisionDay.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_InvoiceRevisionDay
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_InvoiceRevisionDaySp(string PStartInvoice = null,
		string PEndInvoice = null,
		DateTime? PStartInvDate = null,
		DateTime? PEndInvDate = null,
		string PStartCustomer = null,
		string PEndCustomer = null,
		int? PDisplayHeader = 1,
		string pSite = null);
	}
}

