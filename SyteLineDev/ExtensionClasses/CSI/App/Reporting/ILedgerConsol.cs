//PROJECT NAME: Reporting
//CLASS NAME: ILedgerConsol.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ILedgerConsol
	{
		(ICollectionLoadResponse Data, int? ReturnCode) LedgerConsolSp(string pConsolidated = null,
		DateTime? pCutoffDate = null,
		DateTime? pCTADate = null,
		int? pPostTrx = null,
		string pMode = null,
		int? pSummaryOrDetail = null,
		int? pYearEnd = null,
		int? pUseCTADate = null,
		int? FASB52Override = null,
		decimal? UserID = null,
		string BGSessionId = null,
		string pSite = null);
	}
}

