//PROJECT NAME: Data
//CLASS NAME: IFRRpt_ReportTaxFooter.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFRRpt_ReportTaxFooter
	{
		(ICollectionLoadResponse Data, int? ReturnCode) FRRpt_ReportTaxFooterSp(
			string InvNum = null,
			int? TransDomCurr = null,
			string pSite = null,
			int? ReportType = null);
	}
}

