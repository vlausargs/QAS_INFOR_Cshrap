//PROJECT NAME: Finance
//CLASS NAME: ISSSCCIPOSPayInvoices.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.CreditCard
{
	public interface ISSSCCIPOSPayInvoices
	{
		(int? ReturnCode,
			string Infobar) SSSCCIPOSPayInvoicesSp(
			string POSNum,
			string InvNum,
			string OrderNum,
			string CustNum,
			string InvCred,
			string Infobar);
	}
}

