//PROJECT NAME: Reporting
//CLASS NAME: IRpt_WipValuation.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_WipValuation
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_WipValuationSp(string PStartingProdCode = null,
		string PEndingProdCode = null,
		string PStartingItem = null,
		string PEndingItem = null,
		string PStartingJob = null,
		string PEndingJob = null,
		int? PStartingSubJob = null,
		int? PEndingSubJob = null,
		string PJobStatus = "RSC",
		int? PShowDetail = 0,
		int? PDisplayHeader = 1,
		string pSite = null);
	}
}

