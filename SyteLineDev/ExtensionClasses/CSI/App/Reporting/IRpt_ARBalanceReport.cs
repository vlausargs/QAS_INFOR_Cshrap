//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ARBalanceReport.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ARBalanceReport
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) Rpt_ARBalanceReportSp(string FromCustNum,
		string ToCustNum,
		int? FromPeriod,
		int? ToPeriod,
		int? FromYear,
		int? ToYear,
		int? DisplayHeader = null,
		string Infobar = null,
		string pSite = null);
	}
}

