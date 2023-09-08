//PROJECT NAME: Finance
//CLASS NAME: ICalcBalBulk.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface ICalcBalBulk
	{
		(int? ReturnCode,
			string Infobar) CalcBalBulkSp(
			DateTime? DateStarting,
			DateTime? DateEnding,
			string StartingAccount,
			string EndingAccount,
			int? IgnoreUnit1,
			int? IgnoreUnit2,
			int? IgnoreUnit3,
			int? IgnoreUnit4,
			string UnitCode1Starting,
			string UnitCode1Ending,
			string UnitCode2Starting,
			string UnitCode2Ending,
			string UnitCode3Starting,
			string UnitCode3Ending,
			string UnitCode4Starting,
			string UnitCode4Ending,
			string ChartTypes,
			int? SeparateDrCrAmounts,
			string UseSite,
			int? SetNumber = 0,
			string Infobar = null);
	}
}

