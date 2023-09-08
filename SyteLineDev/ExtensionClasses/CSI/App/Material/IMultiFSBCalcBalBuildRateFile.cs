//PROJECT NAME: Finance
//CLASS NAME: IMultiFSBCalcBalBuildRateFile.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IMultiFSBCalcBalBuildRateFile
	{
		(int? ReturnCode,
			string Infobar) MultiFSBCalcBalBuildRateFileSp(
			string TMethod,
			DateTime? SDate,
			DateTime? EDate,
			string PCurrCode,
			string PDomCurrCode,
			int? TUse,
			string Infobar,
			string pSite = null,
			string PeriodName = null);
	}
}

