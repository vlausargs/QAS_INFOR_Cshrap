//PROJECT NAME: Reporting
//CLASS NAME: IRpt_JobCostVariance.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_JobCostVariance
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_JobCostVarianceSp(string StartJob = null,
		string EndJob = null,
		int? SSuffix = null,
		int? ESuffix = null,
		string Status = null,
		string VarianceType = null,
		string StartItem = null,
		string EndItem = null,
		string SCustNum = null,
		string ECustNum = null,
		string SProdMix = null,
		string EProdMix = null,
		string OrdType = null,
		string SOrdNum = null,
		string EOrdNum = null,
		DateTime? SLstTrxDate = null,
		DateTime? ELstTrxDate = null,
		DateTime? StartJobDate = null,
		DateTime? EndJobDate = null,
		int? SLstTrxDateOffset = null,
		int? ELstTrxDateOffset = null,
		int? SJobDateOffset = null,
		int? EJobDateOffset = null,
		int? DisplayHeader = null,
		string pSite = null,
		Guid? ProcessId = null);
	}
}

