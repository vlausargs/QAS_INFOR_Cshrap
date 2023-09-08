//PROJECT NAME: Production
//CLASS NAME: IGetVariableDateBuckets.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IGetVariableDateBuckets
	{
		(int? ReturnCode, DateTime? PerStart,
		DateTime? PerEnd,
		DateTime? PeriodStart1,
		DateTime? PeriodStart2,
		DateTime? PeriodStart3,
		DateTime? PeriodStart4,
		DateTime? PeriodStart5,
		DateTime? PeriodStart6,
		DateTime? PeriodStart7,
		DateTime? PeriodStart8,
		DateTime? PeriodStart9,
		DateTime? PeriodStart10,
		DateTime? PeriodStart11,
		DateTime? PeriodStart12,
		DateTime? PeriodEnd1,
		DateTime? PeriodEnd2,
		DateTime? PeriodEnd3,
		DateTime? PeriodEnd4,
		DateTime? PeriodEnd5,
		DateTime? PeriodEnd6,
		DateTime? PeriodEnd7,
		DateTime? PeriodEnd8,
		DateTime? PeriodEnd9,
		DateTime? PeriodEnd10,
		DateTime? PeriodEnd11,
		DateTime? PeriodEnd12) GetVariableDateBucketsSp(string PeriodType,
		DateTime? PerStart,
		DateTime? PerEnd,
		DateTime? PeriodStart1,
		DateTime? PeriodStart2,
		DateTime? PeriodStart3,
		DateTime? PeriodStart4,
		DateTime? PeriodStart5,
		DateTime? PeriodStart6,
		DateTime? PeriodStart7,
		DateTime? PeriodStart8,
		DateTime? PeriodStart9,
		DateTime? PeriodStart10,
		DateTime? PeriodStart11,
		DateTime? PeriodStart12,
		DateTime? PeriodEnd1,
		DateTime? PeriodEnd2,
		DateTime? PeriodEnd3,
		DateTime? PeriodEnd4,
		DateTime? PeriodEnd5,
		DateTime? PeriodEnd6,
		DateTime? PeriodEnd7,
		DateTime? PeriodEnd8,
		DateTime? PeriodEnd9,
		DateTime? PeriodEnd10,
		DateTime? PeriodEnd11,
		DateTime? PeriodEnd12);
	}
}

