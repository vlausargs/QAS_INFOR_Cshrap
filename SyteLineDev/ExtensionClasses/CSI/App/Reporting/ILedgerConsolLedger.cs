//PROJECT NAME: Reporting
//CLASS NAME: ILedgerConsolLedger.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ILedgerConsolLedger
	{
		(int? ReturnCode,
			string Infobar) LedgerConsolLedgerSp(
			decimal? pTransNum,
			string pAcct,
			DateTime? pTransDate,
			decimal? pDomAmount,
			string pRef,
			string pVendNum,
			string pVoucher,
			int? pCheckNum,
			DateTime? pCheckDate,
			string pFromSite,
			string pFromId,
			int? pVouchSeq,
			string pRefType,
			decimal? pMatlTransNum,
			decimal? pDTransNum,
			string pBankCode,
			string pAcctUnit1,
			string pAcctUnit2,
			string pAcctUnit3,
			string pAcctUnit4,
			string pCurrCode,
			decimal? pExchRate,
			string pSite,
			string ParmsSite,
			string pHierarchy,
			string pConsolidated,
			string LedgerControlPrefix,
			string LedgerControlSite,
			int? LedgerControlYear,
			int? LedgerControlPeriod,
			decimal? LedgerControlNumber,
			string LedgerRefControlPrefix,
			string LedgerRefControlSite,
			int? LedgerRefControlYear,
			int? LedgerRefControlPeriod,
			decimal? LedgerRefControlNumber,
			string Infobar,
			decimal? pJournalBatchId,
			decimal? pForAmount,
			decimal? pLedgerProjTransNum,
			int? pLedgerCancellation,
			Guid? SessionID);
	}
}

