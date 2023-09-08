//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ScrapAnalysis.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ScrapAnalysis
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ScrapAnalysisSp(string PStartingItem = null,
		string PEndingItem = null,
		string PStartingProdCode = null,
		string PEndingProdCode = null,
		DateTime? PStartingJobDate = null,
		DateTime? PEndingJobDate = null,
		string PJobStatus = "RSCH",
		int? PPageBetweenItem = 1,
		int? PShowDetail = 1,
		string PSortBy = "I",
		int? PStartingJobDateOffset = null,
		int? PEndingJobDateOffset = null,
		int? PDisplayHeader = 1,
		string PStartingJob = null,
		string PEndingJob = null,
		int? PStartingJobSuffix = null,
		int? PEndingJobSuffix = null,
		string PStartingWorkCenter = null,
		string PEndingWorkCenter = null,
		string PStartingReason = null,
		string PEndingReason = null,
		DateTime? PStartingTransDate = null,
		DateTime? PEndingTransDate = null,
		int? PStartingTransDateOffset = null,
		int? PEndingTransDateOffset = null,
		string BGSessionId = null,
		string pSite = null,
		string BGUser = null);
	}
}

