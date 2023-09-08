//PROJECT NAME: Reporting
//CLASS NAME: IRpt_MXDIOT.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_MXDIOT
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_MXDIOTSp(DateTime? ReconDateStarting = null,
		DateTime? ReconDateEnding = null,
		int? EndPeriod = null,
		int? FiscalYear = null,
		int? Reprint = 0,
		int? Close = 0,
		string PrintOrCommit = "P",
		string ReportType = "D",
		string pSite = null);
	}
}

