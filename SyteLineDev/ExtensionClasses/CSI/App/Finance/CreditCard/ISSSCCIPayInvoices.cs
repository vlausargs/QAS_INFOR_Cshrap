//PROJECT NAME: Finance
//CLASS NAME: ISSSCCIPayInvoices.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.CreditCard
{
	public interface ISSSCCIPayInvoices
	{
		(int? ReturnCode, string Infobar) SSSCCIPayInvoicesSp(string BegInvNum,
		string EndInvNum,
		string Infobar);
	}
}

