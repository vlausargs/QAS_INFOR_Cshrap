//PROJECT NAME: Reporting
//CLASS NAME: IRpt_GeneralLedgerCheckInformation.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_GeneralLedgerCheckInformation
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) Rpt_GeneralLedgerCheckInformationSp(
			string AccountStarting = null,
			string AccountEnding = null,
			string PrintTrxText = null,
			int? AnalyticalLedger = null,
			string AcctUnit1Starting = null,
			string AcctUnit1Ending = null,
			string AcctUnit2Starting = null,
			string AcctUnit2Ending = null,
			string AcctUnit3Starting = null,
			string AcctUnit3Ending = null,
			string AcctUnit4Starting = null,
			string AcctUnit4Ending = null,
			DateTime? TransDateStarting = null,
			DateTime? TransDateEnding = null,
			string RefStarting = null,
			string RefEnding = null,
			string VendNumStarting = null,
			string VendNumEnding = null,
			string VoucherStarting = null,
			string VoucherEnding = null,
			DateTime? CheckDateStarting = null,
			DateTime? CheckDateEnding = null,
			int? CheckNumStarting = null,
			int? CheckNumEnding = null,
			decimal? TransNumStarting = null,
			decimal? TransNumEnding = null,
			int? TransDateStartingOffset = null,
			int? TransDateEndingOffset = null,
			int? CheckDateStartingOffset = null,
			int? CheckDateEndingOffset = null,
			int? ShowInternal = null,
			int? ShowExternal = null,
			int? DisplayHeader = null,
			string pSite = null);
	}
}

