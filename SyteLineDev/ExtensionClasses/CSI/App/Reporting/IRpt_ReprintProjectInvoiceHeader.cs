//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ReprintProjectInvoiceHeader.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ReprintProjectInvoiceHeader
	{
		int? Rpt_ReprintProjectInvoiceHeaderSp(
			string InvNum,
			int? TransDomCurr,
			int? PrintCustomerNotes,
			int? ShowInternal = 1,
			int? ShowExternal = 1,
			int? PrintDiscountAmt = 0);
	}
}

