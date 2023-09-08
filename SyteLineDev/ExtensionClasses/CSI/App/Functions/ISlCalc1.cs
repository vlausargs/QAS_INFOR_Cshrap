//PROJECT NAME: Data
//CLASS NAME: ISlCalc1.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISlCalc1
	{
		(int? ReturnCode,
			decimal? TYtd,
			string Infobar) SlCalc1Sp(
			DateTime? LowDate,
			DateTime? HighDate,
			DateTime? NextYearDate,
			DateTime? TADate,
			DateTime? TSlEnd,
			string EmpNum,
			DateTime? JobDate,
			string PositionClass,
			decimal? TYtd,
			string Infobar);
	}
}

