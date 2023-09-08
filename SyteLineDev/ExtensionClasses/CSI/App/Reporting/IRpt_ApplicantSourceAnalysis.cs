//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ApplicantSourceAnalysis.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ApplicantSourceAnalysis
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ApplicantSourceAnalysisSp(string PStartingApplicant = null,
		string PEndingApplicant = null,
		DateTime? PStartingReceivedDate = null,
		DateTime? PEndingReceivedDate = null,
		string PStartingPosition = null,
		string PEndingPosition = null,
		int? PDisplayHeader = 1,
		string pSite = null);
	}
}

