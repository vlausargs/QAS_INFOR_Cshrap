//PROJECT NAME: Reporting
//CLASS NAME: IRpt_GeneralLedgerbyAccount1.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_GeneralLedgerbyAccount1
	{
		int? Rpt_GeneralLedgerbyAccount1Sp(
			int? PAnalyticalLedger,
			string PCurSiteGroup,
			string PCurSite,
			DateTime? PSPerDate,
			DateTime? PEPerDate,
			int? PShowAllTrx,
			int? PShowDetail,
			string PChartType,
			string PSAcct,
			string PEAcct,
			string PSAcctUnit1,
			string PEAcctUnit1,
			string PSAcctUnit2,
			string PEAcctUnit2,
			string PSAcctUnit3,
			string PEAcctUnit3,
			string PSAcctUnit4,
			string PEAcctUnit4,
			int? PShowInternal = null,
			int? PShowExternal = null,
			string FirstUnitSort = null,
			string SecondUnitSort = null,
			string ThirdUnitSort = null,
			string FourthUnitSort = null,
			int? SeparateDrCrAmounts = 0);
	}
}

