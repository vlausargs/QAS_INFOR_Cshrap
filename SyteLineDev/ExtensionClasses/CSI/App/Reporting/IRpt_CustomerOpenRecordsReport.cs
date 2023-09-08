//PROJECT NAME: Reporting
//CLASS NAME: IRpt_CustomerOpenRecordsReport.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_CustomerOpenRecordsReport
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_CustomerOpenRecordsReportSp(string CustNumStarting = null,
		string CustNumEnding = null,
		string StatStarting = null,
		string StatEnding = null,
		string pSite = null);
	}
}

