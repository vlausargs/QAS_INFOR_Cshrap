//PROJECT NAME: Reporting
//CLASS NAME: IRpt_MultiFSBGeneralLedgerTransaction.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
    public interface IRpt_MultiFSBGeneralLedgerTransaction
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Rpt_MultiFSBGeneralLedgerTransactionSp(decimal? ExOptStartingTrans = null,
        decimal? ExOptEndingTrans = null,
        string ExOptStartingRef = null,
        string ExOptEndingRef = null,
        int? TAnalyticalLedger = null,
        DateTime? ExOptStartingTransDate = null,
        DateTime? ExOptEndingTransDate = null,
        string ExOptStartingAcc = null,
        string ExOptEndingAcc = null,
        string ExOptacChartType = null,
        string ExOptBegAcctUnit1 = null,
        string ExOptEndAcctUnit1 = null,
        string ExOptBegAcctUnit2 = null,
        string ExOptEndAcctUnit2 = null,
        string ExOptBegAcctUnit3 = null,
        string ExOptEndAcctUnit3 = null,
        string ExOptBegAcctUnit4 = null,
        string ExOptEndAcctUnit4 = null,
        string ExOptSortBy = null,
        int? StartingTransDateOffset = null,
        int? EndingTransDateOffset = null,
        int? DisplayHeader = null,
        int? ShowInternal = null,
        int? ShowExternal = null,
        string FSBName = null,
        string pSite = null);
    }
}