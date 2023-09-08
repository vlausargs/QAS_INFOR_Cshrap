//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ProjectedJobCostToComplete.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ProjectedJobCostToComplete
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ProjectedJobCostToCompleteSp(string PStartingJob = null,
		string PEndingJob = null,
		int? PStartingSubJob = null,
		int? PEndingSubJob = null,
		string PJobStatus = "RS",
		decimal? PUnderPlanVar = null,
		decimal? POverPlanVar = null,
		string PStartingItem = null,
		string PEndingItem = null,
		int? PShowDetail = 0,
		int? PDisplayHeader = 1,
		string pSite = null);
	}
}

