//PROJECT NAME: Reporting
//CLASS NAME: Rpt_MassJournalPosting.cs

using System;
using System.Data;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System.Collections.Generic;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Data.SQL;
using CSI.Finance;
using CSI.Data.Cache;

namespace CSI.Reporting
{
    public class Rpt_MassJournalPosting : IRpt_MassJournalPosting
    {
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IGetWinRegDecGroup iGetWinRegDecGroup;
        readonly IFixMaskForCrystal iFixMaskForCrystal;
        readonly IApplyDateOffset iApplyDateOffset;
        readonly IScalarFunction scalarFunction;
        readonly IConvertToUtil convertToUtil;
        readonly IPrtAcctDis iPrtAcctDis;
        readonly IStringUtil stringUtil;
        readonly ILowDate iLowDate;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly IPerGet iPerGet;
        readonly IRpt_MassJournalPostingCRUD iRpt_MassJournalPostingCRUD;
        readonly LoadType loadType;

        public Rpt_MassJournalPosting(IBunchedLoadCollection bunchedLoadCollection,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IGetWinRegDecGroup iGetWinRegDecGroup,
            IFixMaskForCrystal iFixMaskForCrystal,
            IApplyDateOffset iApplyDateOffset,
            IScalarFunction scalarFunction,
            IConvertToUtil convertToUtil,
            IPrtAcctDis iPrtAcctDis,
            IStringUtil stringUtil,
            ILowDate iLowDate,
            ISQLValueComparerUtil sQLUtil,
            IPerGet iPerGet,
            IRpt_MassJournalPostingCRUD iRpt_MassJournalPostingCRUD)
        {
            this.bunchedLoadCollection = bunchedLoadCollection;
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.iGetWinRegDecGroup = iGetWinRegDecGroup;
            this.iFixMaskForCrystal = iFixMaskForCrystal;
            this.iApplyDateOffset = iApplyDateOffset;
            this.scalarFunction = scalarFunction;
            this.convertToUtil = convertToUtil;
            this.iPrtAcctDis = iPrtAcctDis;
            this.stringUtil = stringUtil;
            this.iLowDate = iLowDate;
            this.sQLUtil = sQLUtil;
            this.iPerGet = iPerGet;
            this.iRpt_MassJournalPostingCRUD = iRpt_MassJournalPostingCRUD;
            this.loadType = this.bunchedLoadCollection.LoadType;
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        Rpt_MassJournalPostingSp(
            string pSessionIDChar = null,
            int? pSingleDate = null,
            DateTime? pDateForTrans = null,
            DateTime? pTransDateStart = null,
            DateTime? pTransDateEnd = null,
            int? pPostInBackgroundQueue = null,
            int? pCompJour = null,
            string pCompressionLevel = null,
            int? pDeleteTransactionsAfterPost = null,
            DateTime? pReversingTransactionDate = null,
            string pSite = null)
        {
            Guid? pSessionID = string.IsNullOrEmpty(pSessionIDChar) ? default(Guid?) : new Guid(pSessionIDChar);

            if (bunchedLoadCollection != null)
                bunchedLoadCollection.StartBunching();
            
            try
            {
                ICollectionLoadResponse Data = null;

                string ALTGEN_SpName = null;
                int? ALTGEN_Severity = null;
                int? rowCount = null;
                int? Severity = null;
                string PrevJournalId = null;
                int? AnalyticalLedger = null;
                string Site = null;
                Guid? JournalRowPointer = null;
                string JournalId = null;
                string TTJournalId = null;
                string XDomCurrency = null;
                int? XDomCurrencyPlaces = null;
                int? JournalSeq = null;
                DateTime? JournalTransDate = null;
                string JournalAcct = null;
                decimal? JournalDomAmount = null;
                string JournalRef = null;
                int? JournalReverse = null;
                string JournalBankCode = null;
                string JournalAcctUnit1 = null;
                string JournalAcctUnit2 = null;
                string JournalAcctUnit3 = null;
                string JournalAcctUnit4 = null;
                string JournalCurrCode = null;
                decimal? JournalExchRate = null;
                decimal? JournalForAmount = null;
                string JournalLedgerType = null;
                int? NoteExistsFlag = null;
                int? treadonly = null;
                int? tJournalIsAna = null;
                Guid? ChartRowPointer = null;
                string ChartDescription = null;
                string ChartType = null;
                string tAcct = null;
                decimal? DomTcAmtCr = null;
                decimal? TcAmtCr = null;
                decimal? DomTcAmtDr = null;
                decimal? TcAmtDr = null;
                string CrDbTxt = null;
                DateTime? PDate = null;
                int? CurrentPeriod = null;
                Guid? PeriodsRowPointer = null;
                int? tPer = null;
                int? PeriodsCurPeriod = null;
                int? PeriodsClosed = null;
                int? WarnText1 = null;
                int? WarnText2 = null;
                int? JournalDetailSeq = null;
                int? DetailSeq = null;
                string PList = null;
                string tpadAccount = null;
                string tpadChartDescription = null;
                decimal? tpadDomTcAmtDr = null;
                decimal? tpadDomTcAmtCr = null;
                int? tpadHdrText = null;
                string tpadDisAccount = null;
                string tpadDisAccountUnit1 = null;
                string tpadDisAccountUnit2 = null;
                string tpadDisAccountUnit3 = null;
                string tpadDisAccountUnit4 = null;
                decimal? tpadDomTcAmtDr2 = null;
                decimal? tpadDomTcAmtCr2 = null;
                string tpadDisAcctDescription = null;
                int? tpadRecurMsg = null;
                int? tpadPctMsg = null;
                int? tpadFtrText = null;
                int? NewJournalInd = null;
                string Infobar = null;
                string tpadSubStrText = null;
                DateTime? LastDate = null;
                DateTime? LowDate = null;
                int? Temptablecreated = null;
                string DomCurrencyFormat = null;
                int? DomCurrencyPlaces = null;
                string ForCurrencyFormat = null;
                int? ForCurrencyPlaces = null;
                string DomTotCurrencyFormat = null;
                int? DomTotCurrencyPlaces = null;
                string SubStrText1 = null;
                string SubStrText2 = null;
                string SubStrText3 = null;

                if (this.iRpt_MassJournalPostingCRUD.Optional_ModuleForExists())
                {
                    //this temp table is a table variable in old stored procedure version.
                    this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
						    [SpName] SYSNAME);
						SELECT * into #tv_ALTGEN from @ALTGEN");
                    var optional_module1LoadResponse = this.iRpt_MassJournalPostingCRUD.Optional_Module1Select();
                    foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                    {
                        optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("Rpt_MassJournalPostingSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
                    };

                    var optional_module1RequiredColumns = new List<string>() { "SpName" };

                    optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

                    this.iRpt_MassJournalPostingCRUD.Optional_Module1Insert(optional_module1LoadResponse);
                    while (this.iRpt_MassJournalPostingCRUD.Tv_ALTGENForExists())
                    {
                        (ALTGEN_SpName, rowCount) = this.iRpt_MassJournalPostingCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
                        var ALTGEN = this.iRpt_MassJournalPostingCRUD.AltExtGen_Rpt_MassJournalPostingSp(ALTGEN_SpName,
                            pSessionIDChar,
                            pSingleDate,
                            pDateForTrans,
                            pTransDateStart,
                            pTransDateEnd,
                            pPostInBackgroundQueue,
                            pCompJour,
                            pCompressionLevel,
                            pDeleteTransactionsAfterPost,
                            pReversingTransactionDate,
                            pSite);
                        ALTGEN_Severity = ALTGEN.ReturnCode;

                        if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
                        {
                            return (ALTGEN.Data, ALTGEN_Severity);
                        }
                        this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
                        /*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
                        var tv_ALTGEN2LoadResponse = this.iRpt_MassJournalPostingCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
                        this.iRpt_MassJournalPostingCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
                        this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
                    }
                }

                if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Rpt_MassJournalPostingSp") != null)
                {
                    var EXTGEN = this.iRpt_MassJournalPostingCRUD.AltExtGen_Rpt_MassJournalPostingSp("dbo.EXTGEN_Rpt_MassJournalPostingSp",
                        pSessionIDChar,
                        pSingleDate,
                        pDateForTrans,
                        pTransDateStart,
                        pTransDateEnd,
                        pPostInBackgroundQueue,
                        pCompJour,
                        pCompressionLevel,
                        pDeleteTransactionsAfterPost,
                        pReversingTransactionDate,
                        pSite);
                    int? EXTGEN_Severity = EXTGEN.ReturnCode;

                    if (EXTGEN_Severity != 1)
                    {
                        return (EXTGEN.Data, EXTGEN_Severity);
                    }
                }

                // The first request, do the process. Otherwise read the bunching result.
                if (loadType == LoadType.First || pSessionID == null)
                {
                    this.sQLExpressionExecutor.Execute(@"DECLARE @DetailA TABLE (
					    NewJournalInd     INT           ,
					    JournalId         JournalIdType ,
					    JournalSeq        JournalSeqType,
					    JournalDetailSeq  INT           ,
					    DetailType        INT           ,
					    HdrText           TINYINT       ,
					    SubStrText        NVARCHAR (40) ,
					    JournalRowPointer RowPointerType);
					SELECT * into #tv_DetailA from @DetailA");
                    PrevJournalId = "";
                    Temptablecreated = 0;
                    (AnalyticalLedger, Site, rowCount) = this.iRpt_MassJournalPostingCRUD.ParmsLoad(AnalyticalLedger, Site);
                    (XDomCurrency, rowCount) = this.iRpt_MassJournalPostingCRUD.CurrparmsLoad(XDomCurrency);
                    (XDomCurrencyPlaces, rowCount) = this.iRpt_MassJournalPostingCRUD.CurrencyLoad(XDomCurrency, XDomCurrencyPlaces);
                    (DomCurrencyFormat, DomCurrencyPlaces, DomTotCurrencyFormat, DomTotCurrencyPlaces, rowCount) = this.iRpt_MassJournalPostingCRUD.Currency1Load(DomCurrencyFormat, DomCurrencyPlaces, DomTotCurrencyFormat, DomTotCurrencyPlaces);
                    DomCurrencyFormat = this.iFixMaskForCrystal.FixMaskForCrystalFn(
                        DomCurrencyFormat,
                        this.iGetWinRegDecGroup.GetWinRegDecGroupFn());
                    DomTotCurrencyFormat = this.iFixMaskForCrystal.FixMaskForCrystalFn(
                        DomTotCurrencyFormat,
                        this.iGetWinRegDecGroup.GetWinRegDecGroupFn());
                    JournalRowPointer = null;
                    JournalId = null;
                    Severity = 0;
                    LowDate = convertToUtil.ToDateTime(this.iLowDate.LowDateFn());

                    #region CRUD ExecuteMethodCall

                    //Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
                    var ApplyDateOffset = this.iApplyDateOffset.ApplyDateOffsetSp(
                        Date: pTransDateStart,
                        IsEndDate: 0);
                    pTransDateStart = ApplyDateOffset.Date;

                    #endregion ExecuteMethodCall

                    #region CRUD ExecuteMethodCall

                    //Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
                    var ApplyDateOffset1 = this.iApplyDateOffset.ApplyDateOffsetSp(
                        Date: pTransDateEnd,
                        IsEndDate: 1);
                    pTransDateEnd = ApplyDateOffset1.Date;

                    #endregion ExecuteMethodCall

                    using (IRecordStream ttJournalStream = this.iRpt_MassJournalPostingCRUD.Tt_JournalSelect(pTransDateStart, pTransDateEnd, pSessionID))
                    {
                        while (ttJournalStream.Read())
                        {
                            IRecordReadOnly ttJournalRow = ttJournalStream.Current;

                            TTJournalId = ttJournalRow.GetValue<string>(0);
                            JournalId = ttJournalRow.GetValue<string>(1);
                            JournalSeq = ttJournalRow.GetValue<int?>(2);
                            JournalTransDate = ttJournalRow.GetValue<DateTime?>(3);
                            JournalAcct = ttJournalRow.GetValue<string>(4);
                            JournalDomAmount = ttJournalRow.GetValue<decimal?>(5);
                            JournalRef = ttJournalRow.GetValue<string>(6);
                            JournalReverse = ttJournalRow.GetValue<int?>(7);
                            JournalBankCode = ttJournalRow.GetValue<string>(8);
                            JournalAcctUnit1 = ttJournalRow.GetValue<string>(9);
                            JournalAcctUnit2 = ttJournalRow.GetValue<string>(10);
                            JournalAcctUnit3 = ttJournalRow.GetValue<string>(11);
                            JournalAcctUnit4 = ttJournalRow.GetValue<string>(12);
                            JournalCurrCode = ttJournalRow.GetValue<string>(13);
                            JournalExchRate = ttJournalRow.GetValue<decimal?>(14);
                            JournalForAmount = ttJournalRow.GetValue<decimal?>(15);
                            NoteExistsFlag = ttJournalRow.GetValue<int?>(16);
                            JournalRowPointer = ttJournalRow.GetValue<Guid?>(17);
                            ChartRowPointer = ttJournalRow.GetValue<Guid?>(18);
                            ChartDescription = ttJournalRow.GetValue<string>(19);
                            ChartType = ttJournalRow.GetValue<string>(20);

                            if (sQLUtil.SQLNotEqual(PrevJournalId, JournalId) == true)
                            {
                                Severity = 0;
                                LastDate = convertToUtil.ToDateTime(LowDate);
                                NewJournalInd = 1;
                                (treadonly, JournalLedgerType, rowCount) = this.iRpt_MassJournalPostingCRUD.Jour_HdrLoad(JournalId, JournalLedgerType, treadonly);
                                if (sQLUtil.SQLEqual(AnalyticalLedger, 1) == true)
                                {
                                    if (sQLUtil.SQLEqual(JournalLedgerType, "A") == true)
                                    {
                                        tJournalIsAna = 1;
                                    }
                                    else
                                    {
                                        tJournalIsAna = 0;
                                    }
                                }
                                PrevJournalId = JournalId;
                            }
                            tAcct = ChartDescription;
                            if (sQLUtil.SQLLessThan(JournalDomAmount, 0) == true)
                            {
                                DomTcAmtCr = (decimal?)(JournalDomAmount * -1M);
                                TcAmtCr = (decimal?)(JournalForAmount * -1M);
                                CrDbTxt = "Credit";
                            }
                            else
                            {
                                DomTcAmtDr = JournalDomAmount;
                                TcAmtDr = JournalForAmount;
                                CrDbTxt = " Debit";
                            }
                            if (sQLUtil.SQLEqual(pSingleDate, 1) == true)
                            {
                                PDate = convertToUtil.ToDateTime(pDateForTrans);
                            }
                            else
                            {
                                PDate = convertToUtil.ToDateTime(JournalTransDate);
                            }
                            if (sQLUtil.SQLNotEqual(LastDate, PDate) == true)
                            {
                                #region CRUD ExecuteMethodCall

                                //Please Generate the bounce for this stored procedure: PerGetSp
                                var PerGet = this.iPerGet.PerGetSp(
                                    Date: PDate,
                                    CurrentPeriod: CurrentPeriod,
                                    PeriodsRowPointer: PeriodsRowPointer,
                                    Infobar: Infobar,
                                    Site: Site);
                                Severity = PerGet.ReturnCode;
                                CurrentPeriod = PerGet.CurrentPeriod;
                                PeriodsRowPointer = PerGet.PeriodsRowPointer;
                                Infobar = PerGet.Infobar;

                                #endregion ExecuteMethodCall

                                tPer = 0;
                                if (sQLUtil.SQLNotEqual(Severity, 0) == true)
                                {
                                    tPer = 1;
                                }
                                else
                                {
                                    (PeriodsCurPeriod, PeriodsClosed, rowCount) = this.iRpt_MassJournalPostingCRUD.Periods_AllasperiodsLoad(PeriodsRowPointer, PeriodsCurPeriod, PeriodsClosed);
                                    if (sQLUtil.SQLEqual(PeriodsClosed, 1) == true)
                                    {
                                        tPer = 1;
                                    }
                                    else
                                    {
                                        if (sQLUtil.SQLNotEqual(CurrentPeriod, PeriodsCurPeriod) == true)
                                        {
                                            tPer = 1;
                                        }
                                    }
                                }
                            }
                            LastDate = convertToUtil.ToDateTime(PDate);
                            WarnText1 = 0;
                            WarnText2 = 0;
                            if (sQLUtil.SQLEqual(tJournalIsAna, 0) == true && sQLUtil.SQLEqual(ChartType, "Y") == true)
                            {
                                WarnText1 = 1;
                            }
                            if (sQLUtil.SQLEqual(tJournalIsAna, 1) == true && sQLUtil.SQLNotEqual(ChartType, "Y") == true)
                            {
                                WarnText2 = 1;
                            }
                            JournalDetailSeq = 0;
                            (ForCurrencyPlaces, ForCurrencyFormat, rowCount) = this.iRpt_MassJournalPostingCRUD.Currency2Load(JournalCurrCode, ForCurrencyFormat, ForCurrencyPlaces);
                            ForCurrencyFormat = this.iFixMaskForCrystal.FixMaskForCrystalFn(
                                ForCurrencyFormat,
                                this.iGetWinRegDecGroup.GetWinRegDecGroupFn());
                            if (sQLUtil.SQLEqual(NewJournalInd, 1) == true)
                            {
                                var nonTableLoadResponse = this.iRpt_MassJournalPostingCRUD.NontableSelect(pSessionID, NewJournalInd, JournalId, JournalSeq, JournalDetailSeq, DomCurrencyFormat, DomCurrencyPlaces, ForCurrencyFormat, ForCurrencyPlaces, DomTotCurrencyFormat, DomTotCurrencyPlaces);
                                Data = nonTableLoadResponse;
                                this.iRpt_MassJournalPostingCRUD.NontableInsert(nonTableLoadResponse);
                            }
                            NewJournalInd = 0;
                            JournalDetailSeq = 1;
                            var nonTable1LoadResponse = this.iRpt_MassJournalPostingCRUD.Nontable1Select(pSessionID, NewJournalInd, JournalId, JournalSeq, JournalDetailSeq, treadonly, tPer, PDate, JournalAcct, JournalAcctUnit1, JournalAcctUnit2, JournalAcctUnit3, JournalAcctUnit4, JournalDomAmount, DomTcAmtDr, DomTcAmtCr, JournalRef, JournalReverse, JournalBankCode, tAcct, JournalForAmount, TcAmtDr, TcAmtCr, JournalCurrCode, JournalExchRate, NoteExistsFlag, tJournalIsAna, ChartType, WarnText1, WarnText2, JournalRowPointer, DomCurrencyFormat, DomCurrencyPlaces, ForCurrencyFormat, ForCurrencyPlaces, DomTotCurrencyFormat, DomTotCurrencyPlaces);
                            Data = nonTable1LoadResponse;
                            this.iRpt_MassJournalPostingCRUD.Nontable1Insert(nonTable1LoadResponse);
                            if (sQLUtil.SQLEqual(ChartType, "D") == true)
                            {
                                if (sQLUtil.SQLEqual(Temptablecreated, 0) == true)
                                {
                                    if (this.scalarFunction.Execute<int?>(
                                        "OBJECT_ID",
                                        "tempdb..#tmpPrtAcctDis") != null)
                                    {
                                        this.sQLExpressionExecutor.Execute("DROP TABLE #tmpPrtAcctDis");
                                    }

                                    this.sQLExpressionExecutor.Execute(@"SELECT tpad.vouch_seq AS DetailSeq,
								       tpad.ap_acct AS Account,
								       tpad.txt AS ChartDescription,
								       tpad.purch_amt AS DomTcAmtDr,
								       tpad.purch_amt AS DomTcAmtCr,
								       tpad.active AS HdrText,
								       tpad.ap_acct AS DisAccount,
								       tpad.ap_acct_unit1 AS DisAccountUnit1,
								       tpad.ap_acct_unit2 AS DisAccountUnit2,
								       tpad.ap_acct_unit3 AS DisAccountUnit3,
								       tpad.ap_acct_unit4 AS DisAccountUnit4,
								       tpad.purch_amt AS DomTcAmtDr2,
								       tpad.purch_amt AS DomTcAmtCr2,
								       tpad.txt AS DisAcctDescription,
								       tpad.active AS RecurMsg,
								       tpad.active AS PctMsg,
								       tpad.active AS FtrText,
								       tpad.txt AS SubStrText
								INTO   #tmpPrtAcctDis
								FROM   aptrxp AS tpad
								WHERE  1 = 2");
                                    Temptablecreated = 1;
                                }
                                else
                                {
                                    /*Needs to load at least one column from the table: #tmpPrtAcctDis for delete, Loads the record based on its where and from clause, then deletes it by record.*/
                                    //var tmpPrtAcctDis1LoadResponse = this.iRpt_MassJournalPostingCRUD.Tmpprtacctdis1Select();
                                    this.iRpt_MassJournalPostingCRUD.Tmpprtacctdis1Delete();
                                }
                                DetailSeq = 0;
                                Severity = 0;
                                PList = "";

                                #region CRUD ExecuteMethodCall

                                //Please Generate the bounce for this stored procedure: PrtAcctDisSp
                                var PrtAcctDis = this.iPrtAcctDis.PrtAcctDisSp(
                                    pAcct: JournalAcct,
                                    pAmount: JournalDomAmount,
                                    pList: PList,
                                    pCurrCode: JournalCurrCode,
                                    pCrDbTxt: CrDbTxt,
                                    pChartDescription: ChartDescription,
                                    pDomCurrPlaces: XDomCurrencyPlaces,
                                    pDetailSeq: DetailSeq,
                                    pDate: PDate,
                                    pForAmount: JournalForAmount);
                                Severity = PrtAcctDis;

                                #endregion ExecuteMethodCall

                                #region Cursor Statement
                                using (IRecordStream disCrsRecordStream = this.iRpt_MassJournalPostingCRUD.Tmpprtacctdis2Select(Severity, JournalAcct, JournalDomAmount, PList, JournalCurrCode, CrDbTxt, ChartDescription, XDomCurrencyPlaces, DetailSeq, PDate, JournalForAmount))
                                {
                                    while (disCrsRecordStream.Read())
                                    {
                                        IRecordReadOnly disCrsRow = disCrsRecordStream.Current;

                                        tpadAccount = disCrsRow.GetValue<string>(0);
                                        tpadChartDescription = disCrsRow.GetValue<string>(1);
                                        tpadDomTcAmtDr = disCrsRow.GetValue<decimal?>(2);
                                        tpadDomTcAmtCr = disCrsRow.GetValue<decimal?>(3);
                                        tpadHdrText = disCrsRow.GetValue<int?>(4);
                                        tpadDisAccount = disCrsRow.GetValue<string>(5);
                                        tpadDisAccountUnit1 = disCrsRow.GetValue<string>(6);
                                        tpadDisAccountUnit2 = disCrsRow.GetValue<string>(7);
                                        tpadDisAccountUnit3 = disCrsRow.GetValue<string>(8);
                                        tpadDisAccountUnit4 = disCrsRow.GetValue<string>(9);
                                        tpadDomTcAmtDr2 = disCrsRow.GetValue<decimal?>(10);
                                        tpadDomTcAmtCr2 = disCrsRow.GetValue<decimal?>(11);
                                        tpadDisAcctDescription = disCrsRow.GetValue<string>(12);
                                        tpadRecurMsg = disCrsRow.GetValue<int?>(13);
                                        tpadPctMsg = disCrsRow.GetValue<int?>(14);
                                        tpadFtrText = disCrsRow.GetValue<int?>(15);
                                        tpadSubStrText = disCrsRow.GetValue<string>(16);

                                        JournalDetailSeq = (int?)(JournalDetailSeq + 1);
                                        SubStrText1 = stringUtil.Substring(
                                            tpadSubStrText,
                                            1,
                                            stringUtil.CharIndex(
                                                " ",
                                                tpadSubStrText));
                                        tpadSubStrText = stringUtil.Substring(
                                            tpadSubStrText,
                                            convertToUtil.ToInt32(stringUtil.CharIndex(
                                                    " ",
                                                    tpadSubStrText)) + 1,
                                            stringUtil.Len(tpadSubStrText));
                                        SubStrText2 = stringUtil.Substring(
                                            tpadSubStrText,
                                            1,
                                            stringUtil.CharIndex(
                                                " ",
                                                tpadSubStrText));
                                        tpadSubStrText = stringUtil.Substring(
                                            tpadSubStrText,
                                            convertToUtil.ToInt32(stringUtil.CharIndex(
                                                    " ",
                                                    tpadSubStrText)) + 1,
                                            stringUtil.Len(tpadSubStrText));
                                        SubStrText3 = stringUtil.Substring(
                                            tpadSubStrText,
                                            1,
                                            stringUtil.CharIndex(
                                                " ",
                                                tpadSubStrText));
                                        tpadSubStrText = SubStrText2;
                                        var nonTable2LoadResponse = this.iRpt_MassJournalPostingCRUD.Nontable2Select(pSessionID, NewJournalInd, JournalId, JournalSeq, JournalDetailSeq, treadonly, tPer, PDate, JournalAcct, JournalAcctUnit1, JournalAcctUnit2, JournalAcctUnit3, JournalAcctUnit4, JournalRef, JournalReverse, JournalBankCode, tAcct, JournalCurrCode, JournalExchRate, NoteExistsFlag, tJournalIsAna, ChartType, tpadAccount, tpadChartDescription, tpadDomTcAmtDr, tpadDomTcAmtCr, tpadHdrText, tpadSubStrText, tpadDisAccount, tpadDisAccountUnit1, tpadDisAccountUnit2, tpadDisAccountUnit3, tpadDisAccountUnit4, tpadDomTcAmtDr2, tpadDomTcAmtCr2, tpadDisAcctDescription, tpadRecurMsg, tpadPctMsg, tpadFtrText, WarnText1, WarnText2, JournalRowPointer, DomCurrencyFormat, DomCurrencyPlaces, ForCurrencyFormat, ForCurrencyPlaces, DomTotCurrencyFormat, DomTotCurrencyPlaces);
                                        Data = nonTable2LoadResponse;
                                        this.iRpt_MassJournalPostingCRUD.Nontable2Insert(nonTable2LoadResponse);
                                    }
                                }

                                #endregion Cursor Statement
                                //Deallocate Cursor DisCrs
                            }
                        }
                    }
                    //Deallocate Cursor TTJournalIdCrs
                    this.iRpt_MassJournalPostingCRUD.Tmp_JournalDelete(pSessionID);
                    this.iRpt_MassJournalPostingCRUD.Tt_Journal1Update(pSessionID);
                    this.iRpt_MassJournalPostingCRUD.Tt_Journal2Delete(pSessionID);

                    if (this.scalarFunction.Execute<int?>(
                        "OBJECT_ID",
                        "tempdb..#tmpPrtAcctDis") != null)
                    {
                        this.sQLExpressionExecutor.Execute("DROP TABLE #tmpPrtAcctDis");
                    }
                    var nonTable3LoadResponse = this.iRpt_MassJournalPostingCRUD.Nontable3Select(pSessionID);
                    this.iRpt_MassJournalPostingCRUD.Nontable3Insert(nonTable3LoadResponse);
                    var _LoadResponse = this.iRpt_MassJournalPostingCRUD._Select(pSessionID);
                    this.iRpt_MassJournalPostingCRUD._Insert(_LoadResponse);
                    this.iRpt_MassJournalPostingCRUD.DetailInsert(pSessionID);
                }
                
                var tv_DetailLoadResponse = this.iRpt_MassJournalPostingCRUD.Tv_DetailSelect(pSessionID);
                Data = tv_DetailLoadResponse;

                return (Data, Severity);
            }
            catch(Exception ex)
            {
                iRpt_MassJournalPostingCRUD.CleanupResultTable(pSessionID);
                throw ex;
            }
            finally
            {
                if (bunchedLoadCollection != null)
                    bunchedLoadCollection.EndBunching();
            }
        }
    }
}
