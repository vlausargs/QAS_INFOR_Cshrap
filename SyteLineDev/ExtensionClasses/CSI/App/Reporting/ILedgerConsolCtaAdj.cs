//PROJECT NAME: Reporting
//CLASS NAME: ILedgerConsolCtaAdj.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ILedgerConsolCtaAdj
	{
		(int? ReturnCode,
			string Infobar) LedgerConsolCtaAdjSp(
			DateTime? pCurrentDate,
			DateTime? pFiscalYearEnd,
			string pFromSite,
			string ParmsSite,
			string pHierarchy,
			string CurrparmsCurrCode,
			Guid? SessionID,
			string Infobar,
			string CTARef,
			int? HierarchyConnected);
	}
}

