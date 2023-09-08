//PROJECT NAME: Data
//CLASS NAME: IVacCalcI.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IVacCalcI
	{
		(int? ReturnCode,
			int? pNoHrJob,
			int? pNoVacParms,
			decimal? pTVac,
			int? pActive,
			string Infobar) VacCalcISp(
			string pEmpNum,
			DateTime? pHighDate,
			DateTime? pLowDate,
			DateTime? pNextYearDate,
			int? pNoHrJobContinue = 1,
			int? pNoVacParmsContinue = 1,
			int? pNoHrJob = null,
			int? pNoVacParms = null,
			decimal? pTVac = null,
			int? pActive = null,
			string Infobar = null);
	}
}

