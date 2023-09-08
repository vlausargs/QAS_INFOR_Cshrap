//PROJECT NAME: Reporting
//CLASS NAME: IRpt_MultiFSBGeneralLedgerbyAccount2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_MultiFSBGeneralLedgerbyAccount2
	{
		int? Rpt_MultiFSBGeneralLedgerbyAccount2Sp(
			int? PTabType,
			string PSite,
			int? PNumHier,
			string PEntList,
			string PSort,
			string PChartAcct,
			string SAcctUnit1,
			string EAcctUnit1,
			string SAcctUnit2,
			string EAcctUnit2,
			string SAcctUnit3,
			string EAcctUnit3,
			string SAcctUnit4,
			string EAcctUnit4,
			string FSBName = null);
	}
}

