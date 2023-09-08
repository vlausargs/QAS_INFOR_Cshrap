//PROJECT NAME: Reporting
//CLASS NAME: IWBCanArAgingBucketParms.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting.CriticalNumber
{
	public interface IWBCanArAgingBucketParms
	{
		(int? ReturnCode,
			int? Days,
			decimal? TotGoal,
			decimal? TotAlert,
			decimal? PctGoal,
			decimal? PctAlert,
			int? ShowIndTot,
			int? ShowIndPct) WBCanArAgingBucketParmsSp(
			int? KPINum,
			int? Index,
			int? Days,
			decimal? TotGoal,
			decimal? TotAlert,
			decimal? PctGoal,
			decimal? PctAlert,
			int? ShowIndTot,
			int? ShowIndPct);
	}
}

