//PROJECT NAME: Reporting
//CLASS NAME: IRpt_APBalanceReport.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_APBalanceReport
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) Rpt_APBalanceReportSp(string FromVendNum,
		string ToVendNum,
		int? FromPeriod,
		int? ToPeriod,
		int? FromYear,
		int? ToYear,
		int? DisplayHeader = null,
		string Infobar = null,
		string pSite = null,
        string ProcessId = null
            );
	}
}

