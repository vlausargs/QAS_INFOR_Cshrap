//PROJECT NAME: Data
//CLASS NAME: IGlPostD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGlPostD
	{
		(int? ReturnCode,
			decimal? PEndTrans,
			string Infobar) GlPostDSp(
			int? PAnalyticalLedger,
			decimal? ParTrans,
			decimal? ParTransRev,
			DateTime? PDate,
			DateTime? PNextPer,
			string PAcct,
			decimal? PDomAmount,
			decimal? PForAmount,
			string PList,
			int? PDomCurrencyPlaces,
			int? ForCurrencyPlaces = 2,
			decimal? PEndTrans = null,
			Guid? JournalRowPointer = null,
			string JournalVendNum = null,
			string JournalVoucher = null,
			int? JournalCheckNum = null,
			DateTime? JournalCheckDate = null,
			string JournalFromSite = null,
			string JournalId = null,
			int? JournalVouchSeq = null,
			string JournalRefType = null,
			decimal? JournalMatlTransNum = null,
			string JournalBankCode = null,
			string JournalCurrCode = null,
			decimal? JournalExchRate = null,
			string JournalAcctUnit1 = null,
			string JournalAcctUnit2 = null,
			string JournalAcctUnit3 = null,
			string JournalAcctUnit4 = null,
			DateTime? JournalTransDate = null,
			int? JournalReverse = null,
			string JournalRef = null,
			int? JournalNoteExists = 1,
			string JournalControlPrefix = null,
			string JournalControlSite = null,
			int? JournalControlYear = null,
			int? JournalControlPeriod = null,
			decimal? JournalControlNumber = null,
			string JournalRefControlPrefix = null,
			string JournalRefControlSite = null,
			int? JournalRefControlYear = null,
			int? JournalRefControlPeriod = null,
			decimal? JournalRefControlNumber = null,
			int? RevJournalControlYear = null,
			int? RevJournalControlPeriod = null,
			decimal? RevJournalControlNumber = null,
			string Infobar = null,
			decimal? JournalProjTransNum = null,
			decimal? PJournalBatchId = null);
	}
}

