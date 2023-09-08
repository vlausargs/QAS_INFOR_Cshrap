//PROJECT NAME: Data
//CLASS NAME: IFRRpt_ProjectInvoiceTaxFooter.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFRRpt_ProjectInvoiceTaxFooter
	{
		(ICollectionLoadResponse Data, int? ReturnCode) FRRpt_ProjectInvoiceTaxFooterSp(
			string InvNum = null,
			int? TransDomCurr = null,
			string Site = null);
	}
}

