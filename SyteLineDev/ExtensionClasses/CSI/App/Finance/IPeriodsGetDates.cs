//PROJECT NAME: Finance
//CLASS NAME: IPeriodsGetDates.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IPeriodsGetDates
	{
		(int? ReturnCode, DateTime? PerStart,
		DateTime? PerEnd,
		string Infobar) PeriodsGetDatesSp(int? FiscalYear,
		int? Period,
		string Site = null,
		DateTime? PerStart = null,
		DateTime? PerEnd = null,
		string Infobar = null);
	}
}

