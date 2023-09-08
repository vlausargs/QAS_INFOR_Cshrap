//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ReprintProjectInvoiceBottom.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ReprintProjectInvoiceBottom
	{
		int? Rpt_ReprintProjectInvoiceBottomSp(
			string InvNum,
			int? TransDomCurr,
			int? PrintProjectNotes,
			int? PrintStandardNotes,
			int? ShowInternal = 1,
			int? ShowExternal = 1);
	}
}

