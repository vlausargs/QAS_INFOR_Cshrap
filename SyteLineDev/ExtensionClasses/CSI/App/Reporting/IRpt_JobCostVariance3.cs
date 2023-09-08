//PROJECT NAME: Reporting
//CLASS NAME: IRpt_JobCostVariance3.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_JobCostVariance3
	{
		int? Rpt_JobCostVariance3Sp(
			string JobBuffer,
			string JobType,
			string JobJob,
			int? JobSuffix,
			string JobitemItem,
			decimal? JobitemQtyReleased,
			DateTime? AsOfDate = null);
	}
}

