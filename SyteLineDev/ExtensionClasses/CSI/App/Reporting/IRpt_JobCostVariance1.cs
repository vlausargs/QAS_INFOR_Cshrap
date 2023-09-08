//PROJECT NAME: Reporting
//CLASS NAME: IRpt_JobCostVariance1.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_JobCostVariance1
	{
		int? Rpt_JobCostVariance1Sp(
			string JobType,
			string Job,
			int? Suffix,
			DateTime? AsOfDate = null);
	}
}

