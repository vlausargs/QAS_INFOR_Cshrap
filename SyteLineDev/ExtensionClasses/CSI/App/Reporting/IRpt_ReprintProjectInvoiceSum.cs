//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ReprintProjectInvoiceSum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ReprintProjectInvoiceSum
	{
		int? Rpt_ReprintProjectInvoiceSumSp(
			string InvNum,
			string BeginInvNum,
			int? TransDomCurr);
	}
}

