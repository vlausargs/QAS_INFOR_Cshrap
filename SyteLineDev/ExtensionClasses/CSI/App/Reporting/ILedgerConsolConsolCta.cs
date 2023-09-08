//PROJECT NAME: Reporting
//CLASS NAME: ILedgerConsolConsolCta.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ILedgerConsolConsolCta
	{
		(int? ReturnCode,
			string Infobar) LedgerConsolConsolCtaSp(
			DateTime? pCurrentDate,
			DateTime? pFiscalYearStart,
			DateTime? pFiscalYearEnd,
			decimal? pAmount,
			string pFromSite,
			string pSiteName,
			string pHierarchy,
			string Infobar,
			DateTime? pYearStart);
	}
}

