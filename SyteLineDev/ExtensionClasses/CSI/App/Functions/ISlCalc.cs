//PROJECT NAME: Data
//CLASS NAME: ISlCalc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISlCalc
	{
		(int? ReturnCode,
			decimal? TotalYtd,
			string Infobar) SlCalcSp(
			DateTime? LowDate,
			DateTime? HighDate,
			DateTime? NextYearDate,
			string EmpNum,
			decimal? DaysCf,
			decimal? DaysUsed,
			decimal? TotalYtd,
			string Infobar);
	}
}

