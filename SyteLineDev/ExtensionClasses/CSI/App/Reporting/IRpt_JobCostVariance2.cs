//PROJECT NAME: Reporting
//CLASS NAME: IRpt_JobCostVariance2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_JobCostVariance2
	{
		int? Rpt_JobCostVariance2Sp(
			string JobBuffer,
			string JobType,
			string JobJob,
			int? JobSuffix,
			string JobitemItem,
			decimal? JobitemQtyReleased,
			Guid? JobRowPointer,
			DateTime? AsOfDate = null);
	}
}

