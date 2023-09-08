//PROJECT NAME: Data
//CLASS NAME: IVacCal1I.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IVacCal1I
	{
		(int? ReturnCode,
			DateTime? pDate,
			DateTime? pStart,
			DateTime? pEnd,
			DateTime? pServDate,
			int? pServYears,
			int? pJobDays,
			int? pServDays,
			int? pVacDays,
			decimal? pVac) VacCal1ISp(
			int? pEmpStatVacBnft,
			DateTime? pJobDate,
			string pPosClass,
			DateTime? pHighDate,
			DateTime? pLowDate,
			DateTime? pNextYearDate,
			DateTime? pDate,
			DateTime? pStart,
			DateTime? pEnd,
			DateTime? pServDate,
			int? pServYears,
			int? pJobDays,
			int? pServDays,
			int? pVacDays,
			decimal? pVac);
	}
}

