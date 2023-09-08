//PROJECT NAME: Reporting
//CLASS NAME: IRpt_JobCostDetailStatus.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_JobCostDetailStatus
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_JobCostDetailStatusSp(string PStartingJob = null,
		string PEndingJob = null,
		int? PStartingSubJob = null,
		int? PEndingSubJob = null,
		string PJobStatus = null,
		string PCostComponent = null,
		string PStartingCustomer = null,
		string PEndingCustomer = null,
		string PStartingItem = null,
		string PEndingItem = null,
		string PStartingProdMix = null,
		string PEndingProdMix = null,
		string POrderType = null,
		string PStartingOrderNum = null,
		string PEndingOrderNum = null,
		DateTime? PStartingTrxDate = null,
		DateTime? PEndingTrxDate = null,
		DateTime? PStartingJobDate = null,
		DateTime? PEndingJobDate = null,
		int? PStartingTrxDateOffset = null,
		int? PEndingTrxDateOffset = null,
		int? PStartingJobDateOffset = null,
		int? PEndingJobDateOffset = null,
		int? PDisplayHeader = 1,
		string pSite = null);
	}
}

