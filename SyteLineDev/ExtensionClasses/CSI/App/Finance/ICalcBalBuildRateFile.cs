//PROJECT NAME: Finance
//CLASS NAME: ICalcBalBuildRateFile.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface ICalcBalBuildRateFile
	{
		(int? ReturnCode,
			string Infobar) CalcBalBuildRateFileSp(
			string TMethod,
			DateTime? SDate,
			DateTime? EDate,
			string PCurrCode,
			string PDomCurrCode,
			int? TUse,
			string Infobar,
			string pSite = null);
	}
}

