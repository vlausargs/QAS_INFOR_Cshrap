//PROJECT NAME: Reporting
//CLASS NAME: IRpt_VendorOpenRecordsReport.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_VendorOpenRecordsReport
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_VendorOpenRecordsReportSp(string VendNumStarting = null,
		string VendNumEnding = null,
		string StatStarting = null,
		string StatEnding = null,
		string pSite = null);
	}
}

