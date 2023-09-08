//PROJECT NAME: Reporting
//CLASS NAME: IRpt_IndentedProjectedJobCosttoComplete.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_IndentedProjectedJobCosttoComplete
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_IndentedProjectedJobCosttoCompleteSp(string PStartingJob = null,
		string PEndingJob = null,
		int? PStartingSubJob = null,
		int? PEndingSubJob = null,
		string PJobStatus = null,
		decimal? PUnderPlanVar = null,
		decimal? POverPlanVar = null,
		string PStartingItem = null,
		string PEndingItem = null,
		int? PDisplayHeader = 1,
		string pSite = null);
	}
}

