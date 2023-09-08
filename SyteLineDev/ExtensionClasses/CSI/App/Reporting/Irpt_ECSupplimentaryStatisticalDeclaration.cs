//PROJECT NAME: Reporting
//CLASS NAME: Irpt_ECSupplimentaryStatisticalDeclaration.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface Irpt_ECSupplimentaryStatisticalDeclaration
	{
		(ICollectionLoadResponse Data, int? ReturnCode) rpt_ECSupplimentaryStatisticalDeclarationSp(DateTime? PeriodStarting = null,
		DateTime? PeriodEnding = null,
		string ExOptdfEcSsdOpt = null,
		int? ExOptszSummaryOrDetail = null,
		int? ExOptdfEcSsdTrade = null,
		int? ExOptdfEcSsdNotc = null,
		int? ExOptdfElOutput = null,
		string TElOut = null,
		string CommCodeStarting = null,
		string CommCodeEnding = null,
		string ECCodeStarting = null,
		string ECCodeEnding = null,
		int? PeriodStartingOffset = null,
		int? PeriodEndingOffset = null,
		int? ExOptszPreviewOrPrint = null,
		int? PrintFlag = 0,
		string ExPrintPeriod = null,
		int? ReportingLevel = 1,
		string BGSessionId = null,
		string pSite = null);
	}
}

