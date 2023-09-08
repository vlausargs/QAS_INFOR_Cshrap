//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ReprintProjectInvoiceTax.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ReprintProjectInvoiceTax
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ReprintProjectInvoiceTaxSp(
			string InvNum = null,
			int? TransDomCurr = null);
	}
}

