//PROJECT NAME: Data
//CLASS NAME: ICalcRate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICalcRate
	{
		(int? ReturnCode,
			decimal? TPayRate) CalcRateSp(
			Guid? TEmpRecid,
			string THrType,
			int? TPaySalary,
			string TShift,
			DateTime? TEffDate,
			int? TSumAtt,
			decimal? TPayRate);
	}
}

