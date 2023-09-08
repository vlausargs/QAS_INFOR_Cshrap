//PROJECT NAME: Finance
//CLASS NAME: IMXValidateCMToInvoice.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Mexican
{
	public interface IMXValidateCMToInvoice
	{
		(int? ReturnCode,
			string Infobar) MXValidateCMToInvoiceSp(
			string InvNum,
			string CustNum,
			decimal? CMAmt,
			string Infobar);
	}
}

