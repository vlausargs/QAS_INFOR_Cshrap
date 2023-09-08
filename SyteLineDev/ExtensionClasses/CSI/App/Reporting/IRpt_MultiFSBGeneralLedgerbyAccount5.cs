//PROJECT NAME: Reporting
//CLASS NAME: IRpt_MultiFSBGeneralLedgerbyAccount5.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_MultiFSBGeneralLedgerbyAccount5
	{
		(int? ReturnCode,
			int? PReportSet3RowPointer,
			int? PTtUnitRowPointer,
			string PTtUnitAcctUnit1,
			string PTtUnitAcctUnit2,
			string PTtUnitAcctUnit3,
			string PTtUnitAcctUnit4,
			string PTOldUc,
			decimal? PTcTotUcDr,
			decimal? PTcTotUcCr,
			decimal? PTcTotUcEnd,
			decimal? PTcTotUcBeg) Rpt_MultiFSBGeneralLedgerbyAccount5Sp(
			Guid? PGLRowPointer,
			int? PReportSet3RowPointer,
			string PSite,
			int? PTtUnitRowPointer,
			string PTtUnitAcctUnit1,
			string PTtUnitAcctUnit2,
			string PTtUnitAcctUnit3,
			string PTtUnitAcctUnit4,
			string PSortByTrx,
			int? PIsSortByUc,
			int? PIsSubUc,
			string PTOldUc,
			decimal? PTcTotUcDr,
			decimal? PTcTotUcCr,
			decimal? PTcTotUcEnd,
			decimal? PTcTotUcBeg,
			int? PNumHier,
			string PEntList,
			DateTime? PSDate,
			DateTime? PEDate,
			string PChartAcct,
			string PChartType,
			string PSort,
			int? PSortMethod,
			string PCurrCode,
			string PAcctUnit1,
			string PAcctUnit2,
			string PAcctUnit3,
			string PAcctUnit4,
			decimal? PTcTotAcctBeg,
			string FSBName = null);
	}
}

