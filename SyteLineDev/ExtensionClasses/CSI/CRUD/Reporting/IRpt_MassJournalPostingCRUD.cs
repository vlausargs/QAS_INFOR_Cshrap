//PROJECT NAME: Reporting
//CLASS NAME: IRpt_MassJournalPostingCRUD.cs

using System;
using System.Data;
using CSI.Data.Cache;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_MassJournalPostingCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse Optional_Module1Select();
		void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
		ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
		void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		(int? AnalyticalLedger, string Site, int? rowCount) ParmsLoad(int? AnalyticalLedger, string Site);
		(string XDomCurrency, int? rowCount) CurrparmsLoad(string XDomCurrency);
		(int? XDomCurrencyPlaces, int? rowCount) CurrencyLoad(string XDomCurrency, int? XDomCurrencyPlaces);
		(string DomCurrencyFormat, int? DomCurrencyPlaces, string DomTotCurrencyFormat, int? DomTotCurrencyPlaces, int? rowCount) Currency1Load(string DomCurrencyFormat, int? DomCurrencyPlaces, string DomTotCurrencyFormat, int? DomTotCurrencyPlaces);
		IRecordStream Tt_JournalSelect(DateTime? pTransDateStart, DateTime? pTransDateEnd, Guid? pSessionID);
		(int? treadonly, string JournalLedgerType, int? rowCount) Jour_HdrLoad(string JournalId, string JournalLedgerType, int? treadonly);
		(int? PeriodsCurPeriod, int? PeriodsClosed, int? rowCount) Periods_AllasperiodsLoad(Guid? PeriodsRowPointer, int? PeriodsCurPeriod, int? PeriodsClosed);
		(int? ForCurrencyPlaces, string ForCurrencyFormat, int? rowCount) Currency2Load(string JournalCurrCode, string ForCurrencyFormat, int? ForCurrencyPlaces);
		ICollectionLoadResponse NontableSelect(Guid? processId, int? NewJournalInd, string JournalId, int? JournalSeq, int? JournalDetailSeq, string DomCurrencyFormat, int? DomCurrencyPlaces, string ForCurrencyFormat, int? ForCurrencyPlaces, string DomTotCurrencyFormat, int? DomTotCurrencyPlaces);
		void NontableInsert(ICollectionLoadResponse nonTableLoadResponse);
		ICollectionLoadResponse Nontable1Select(Guid? processId, int? NewJournalInd, string JournalId, int? JournalSeq, int? JournalDetailSeq, int? treadonly, int? tPer, DateTime? PDate, string JournalAcct, string JournalAcctUnit1, string JournalAcctUnit2, string JournalAcctUnit3, string JournalAcctUnit4, decimal? JournalDomAmount, decimal? DomTcAmtDr, decimal? DomTcAmtCr, string JournalRef, int? JournalReverse, string JournalBankCode, string tAcct, decimal? JournalForAmount, decimal? TcAmtDr, decimal? TcAmtCr, string JournalCurrCode, decimal? JournalExchRate, int? NoteExistsFlag, int? tJournalIsAna, string ChartType, int? WarnText1, int? WarnText2, Guid? JournalRowPointer, string DomCurrencyFormat, int? DomCurrencyPlaces, string ForCurrencyFormat, int? ForCurrencyPlaces, string DomTotCurrencyFormat, int? DomTotCurrencyPlaces);
		void Nontable1Insert(ICollectionLoadResponse nonTable1LoadResponse);
		void Tmpprtacctdis1Delete();
		IRecordStream Tmpprtacctdis2Select(int? Severity, string JournalAcct, decimal? JournalDomAmount, string PList, string JournalCurrCode, string CrDbTxt, string ChartDescription, int? XDomCurrencyPlaces, int? DetailSeq, DateTime? PDate, decimal? JournalForAmount);
		ICollectionLoadResponse Nontable2Select(Guid? processId, int? NewJournalInd, string JournalId, int? JournalSeq, int? JournalDetailSeq, int? treadonly, int? tPer, DateTime? PDate, string JournalAcct, string JournalAcctUnit1, string JournalAcctUnit2, string JournalAcctUnit3, string JournalAcctUnit4, string JournalRef, int? JournalReverse, string JournalBankCode, string tAcct, string JournalCurrCode, decimal? JournalExchRate, int? NoteExistsFlag, int? tJournalIsAna, string ChartType, string tpadAccount, string tpadChartDescription, decimal? tpadDomTcAmtDr, decimal? tpadDomTcAmtCr, int? tpadHdrText, string tpadSubStrText, string tpadDisAccount, string tpadDisAccountUnit1, string tpadDisAccountUnit2, string tpadDisAccountUnit3, string tpadDisAccountUnit4, decimal? tpadDomTcAmtDr2, decimal? tpadDomTcAmtCr2, string tpadDisAcctDescription, int? tpadRecurMsg, int? tpadPctMsg, int? tpadFtrText, int? WarnText1, int? WarnText2, Guid? JournalRowPointer, string DomCurrencyFormat, int? DomCurrencyPlaces, string ForCurrencyFormat, int? ForCurrencyPlaces, string DomTotCurrencyFormat, int? DomTotCurrencyPlaces);
		void Nontable2Insert(ICollectionLoadResponse nonTable2LoadResponse);
		void Tmp_JournalDelete(Guid? pSessionID);
		void Tt_Journal1Update(Guid? pSessionID);
		void Tt_Journal2Delete(Guid? pSessionID);
		ICollectionLoadResponse Nontable3Select(Guid? processId);
		void Nontable3Insert(ICollectionLoadResponse nonTable3LoadResponse);
		ICollectionLoadResponse _Select(Guid? processId);
		void _Insert(ICollectionLoadResponse _LoadResponse);
		void DetailInsert(Guid? processId);
		ICollectionLoadResponse Tv_DetailSelect(Guid? processId);
        void CleanupResultTable(Guid? processId);
        (ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_Rpt_MassJournalPostingSp(string AltExtGenSp, string pSessionIDChar, int? pSingleDate, DateTime? pDateForTrans, DateTime? pTransDateStart, DateTime? pTransDateEnd, int? pPostInBackgroundQueue, int? pCompJour, string pCompressionLevel, int? pDeleteTransactionsAfterPost, DateTime? pReversingTransactionDate, string pSite);
    }
}

