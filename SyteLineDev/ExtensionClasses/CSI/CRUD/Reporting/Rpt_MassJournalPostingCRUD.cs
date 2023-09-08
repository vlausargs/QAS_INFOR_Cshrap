//PROJECT NAME: Reporting
//CLASS NAME: Rpt_MassJournalPostingCRUD.cs

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
using CSI.Data.Cache;
using CSI.Data.Utilities;

namespace CSI.Reporting
{
	public class Rpt_MassJournalPostingCRUD : IRpt_MassJournalPostingCRUD
	{
		readonly IApplicationDB appDB;

		readonly ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
		readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionUpdateRequestFactory collectionUpdateRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionNonTriggerInsertRequestFactory collectionNonTriggerInsertRequestFactory;
        readonly ICollectionNonTriggerDeleteRequestFactory collectionNonTriggerDeleteRequestFactory;
        readonly IExistsChecker existsChecker;
		readonly IConvertToUtil convertToUtil;
		readonly IVariableUtil variableUtil;
		readonly IStringUtil stringUtil;
		readonly ISQLValueComparerUtil sQLUtil;
        readonly IUnionUtil unionUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;

        // Bunching required interfaces.
        readonly IRecordStreamFactory recordStreamFactory;
        readonly ICache mgSessionVariableBasedCache;
        readonly IQueryLanguage queryLanguage;
        readonly ISortOrderFactory sortOrderFactory;
        readonly IBookmarkFactory bookmarkFactory;
        readonly IDefineProcessVariable defineProcessVariable;
        readonly IGetVariable getVariable;
        readonly int recordCap;
        readonly int pageSize;
        readonly LoadType loadType;

        public Rpt_MassJournalPostingCRUD(IApplicationDB appDB,
            ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
            ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionNonTriggerInsertRequestFactory collectionNonTriggerInsertRequestFactory,
            ICollectionNonTriggerDeleteRequestFactory collectionNonTriggerDeleteRequestFactory,
            IExistsChecker existsChecker,
			IConvertToUtil convertToUtil,
			IVariableUtil variableUtil,
			IStringUtil stringUtil,
			ISQLValueComparerUtil sQLUtil,
            IUnionUtil unionUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IBunchedLoadCollection bunchedLoadCollection,
            IRecordStreamFactory recordStreamFactory,
            ISortOrderFactory sortOrderFactory,
            IBookmarkFactory bookmarkFactory,
            IQueryLanguage queryLanguage,
            ICache mgSessionVariableBasedCache,
            IDefineProcessVariable defineProcessVariable,
            IGetVariable getVariable,
            CachePageSize cachePageSize)
		{
			this.appDB = appDB;
			this.collectionLoadStatementRequestFactory = collectionLoadStatementRequestFactory;
			this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionUpdateRequestFactory = collectionUpdateRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.collectionNonTriggerInsertRequestFactory = collectionNonTriggerInsertRequestFactory;
            this.collectionNonTriggerDeleteRequestFactory = collectionNonTriggerDeleteRequestFactory;
            this.existsChecker = existsChecker;
			this.convertToUtil = convertToUtil;
			this.variableUtil = variableUtil;
			this.stringUtil = stringUtil;
			this.sQLUtil = sQLUtil;
            this.unionUtil = unionUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;

            this.recordStreamFactory = recordStreamFactory;
            this.mgSessionVariableBasedCache = mgSessionVariableBasedCache;
            this.queryLanguage = queryLanguage;
            this.sortOrderFactory = sortOrderFactory;
            this.bookmarkFactory = bookmarkFactory;
            this.defineProcessVariable = defineProcessVariable;
            this.getVariable = getVariable;
            this.recordCap = bunchedLoadCollection.RecordCap;
            // Record cap value should specially handled.
            // -1 as default 200 rows.
            // 0 as all rows. Use int.MaxValue - 1 because we will add 1 later.
            if (recordCap == -1)
            {
                recordCap = 200;
            }
            else if (recordCap == 0)
            {
                recordCap = int.MaxValue - 1;
            }
            this.loadType = bunchedLoadCollection.LoadType;
            this.sortOrderFactory = sortOrderFactory;
            // We'd better pass in enum type for page size.
            // Then convert it to int for use.
            this.pageSize = Convert.ToInt32(cachePageSize);
        }
		
		public bool Optional_ModuleForExists()
		{
			return existsChecker.Exists(tableName:"optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_MassJournalPostingSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"));
		}
		
		public ICollectionLoadResponse Optional_Module1Select()
		{
			var optional_module1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"SpName","CAST (NULL AS NVARCHAR)"},
					{"u0","[om].[ModuleName]"},
				},
				loadForChange: false,
                lockingType:LockingType.None,
				tableName:"optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_MassJournalPostingSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(optional_module1LoadRequest);
		}
		
		public void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse)
		{
			var optional_module1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ALTGEN",
				items: optional_module1LoadResponse.Items);
			
			this.appDB.Insert(optional_module1InsertRequest);
		}
		
		public bool Tv_ALTGENForExists()
		{
			return existsChecker.Exists(tableName:"#tv_ALTGEN",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""));
		}
		
		public (string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName)
		{
			StringType _ALTGEN_SpName = DBNull.Value;
			
			var tv_ALTGEN1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_ALTGEN_SpName,"[SpName]"},
				},
				loadForChange: false,
                lockingType: LockingType.None,
                maximumRows: 1,
				tableName:"#tv_ALTGEN",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var tv_ALTGEN1LoadResponse = this.appDB.Load(tv_ALTGEN1LoadRequest);
			if(tv_ALTGEN1LoadResponse.Items.Count > 0)
			{
				ALTGEN_SpName = _ALTGEN_SpName;
			}
			
			int rowCount = tv_ALTGEN1LoadResponse.Items.Count;
			return (ALTGEN_SpName, rowCount);
		}
		
		public ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName)
		{
			var tv_ALTGEN2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"[SpName]","[SpName]"},
				},
                loadForChange: false,
                lockingType: LockingType.None,
                tableName:"#tv_ALTGEN",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("[SpName] = {0}",ALTGEN_SpName),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(tv_ALTGEN2LoadRequest);
		}
		
		public void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse)
		{
			var tv_ALTGEN2DeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "#tv_ALTGEN",
				items: tv_ALTGEN2LoadResponse.Items);
			this.appDB.Delete(tv_ALTGEN2DeleteRequest);
		}
		
		public (int? AnalyticalLedger, string Site, int? rowCount) ParmsLoad(int? AnalyticalLedger, string Site)
		{
			ListYesNoType _AnalyticalLedger = DBNull.Value;
			SiteType _Site = DBNull.Value;
			
			var parmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_AnalyticalLedger,"parms.analytical_ledger"},
					{_Site,"parms.site"},
				},
				loadForChange: false,
                lockingType: LockingType.None,
                maximumRows: 1,
				tableName:"parms",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var parmsLoadResponse = this.appDB.Load(parmsLoadRequest);
			if(parmsLoadResponse.Items.Count > 0)
			{
				AnalyticalLedger = _AnalyticalLedger;
				Site = _Site;
			}
			
			int rowCount = parmsLoadResponse.Items.Count;
			return (AnalyticalLedger, Site, rowCount);
		}
		
		public (string XDomCurrency, int? rowCount) CurrparmsLoad(string XDomCurrency)
		{
			CurrCodeType _XDomCurrency = DBNull.Value;
			
			var currparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_XDomCurrency,"currparms.curr_code"},
				},
				loadForChange: false,
                lockingType: LockingType.None,
                maximumRows: 1,
				tableName:"currparms",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var currparmsLoadResponse = this.appDB.Load(currparmsLoadRequest);
			if(currparmsLoadResponse.Items.Count > 0)
			{
				XDomCurrency = _XDomCurrency;
			}
			
			int rowCount = currparmsLoadResponse.Items.Count;
			return (XDomCurrency, rowCount);
		}
		
		public (int? XDomCurrencyPlaces, int? rowCount) CurrencyLoad(string XDomCurrency, int? XDomCurrencyPlaces)
		{
			DecimalPlacesType _XDomCurrencyPlaces = DBNull.Value;
			
			var currencyLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_XDomCurrencyPlaces,"currency.places"},
				},
				loadForChange: false,
                lockingType: LockingType.None,
                maximumRows: 1,
				tableName:"currency",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("currency.curr_code = {0}",XDomCurrency),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var currencyLoadResponse = this.appDB.Load(currencyLoadRequest);
			if(currencyLoadResponse.Items.Count > 0)
			{
				XDomCurrencyPlaces = _XDomCurrencyPlaces;
			}
			
			int rowCount = currencyLoadResponse.Items.Count;
			return (XDomCurrencyPlaces, rowCount);
		}
		
		public (string DomCurrencyFormat, int? DomCurrencyPlaces, string DomTotCurrencyFormat, int? DomTotCurrencyPlaces, int? rowCount) Currency1Load(string DomCurrencyFormat, int? DomCurrencyPlaces, string DomTotCurrencyFormat, int? DomTotCurrencyPlaces)
		{
			InputMaskType _DomCurrencyFormat = DBNull.Value;
			DecimalPlacesType _DomCurrencyPlaces = DBNull.Value;
			InputMaskType _DomTotCurrencyFormat = DBNull.Value;
			DecimalPlacesType _DomTotCurrencyPlaces = DBNull.Value;
			
			var currency1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_DomCurrencyFormat,"amt_format"},
					{_DomCurrencyPlaces,"places"},
					{_DomTotCurrencyFormat,"amt_tot_format"},
					{_DomTotCurrencyPlaces,"places"},
				},
				loadForChange: false,
                lockingType: LockingType.None,
                maximumRows: 1,
				tableName:"currency",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("currency.curr_code = (SELECT curr_code FROM currparms)"),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var currency1LoadResponse = this.appDB.Load(currency1LoadRequest);
			if(currency1LoadResponse.Items.Count > 0)
			{
				DomCurrencyFormat = _DomCurrencyFormat;
				DomCurrencyPlaces = _DomCurrencyPlaces;
				DomTotCurrencyFormat = _DomTotCurrencyFormat;
				DomTotCurrencyPlaces = _DomTotCurrencyPlaces;
			}
			
			int rowCount = currency1LoadResponse.Items.Count;
			return (DomCurrencyFormat, DomCurrencyPlaces, DomTotCurrencyFormat, DomTotCurrencyPlaces, rowCount);
		}
		
		public IRecordStream Tt_JournalSelect(DateTime? pTransDateStart, DateTime? pTransDateEnd, Guid? pSessionID)
		{
			var TTJournalIdCrsLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"tt_journal.id","tt_journal.id"},
					{"tmp_journal.id","tmp_journal.id"},
					{"tmp_journal.seq","tmp_journal.seq"},
					{"tmp_journal.trans_date","tmp_journal.trans_date"},
					{"tmp_journal.acct","tmp_journal.acct"},
					{"tmp_journal.dom_amount","tmp_journal.dom_amount"},
					{"tmp_journal.ref","tmp_journal.ref"},
					{"tmp_journal.reverse","tmp_journal.reverse"},
					{"tmp_journal.bank_code","tmp_journal.bank_code"},
					{"tmp_journal.acct_unit1","tmp_journal.acct_unit1"},
					{"tmp_journal.acct_unit2","tmp_journal.acct_unit2"},
					{"tmp_journal.acct_unit3","tmp_journal.acct_unit3"},
					{"tmp_journal.acct_unit4","tmp_journal.acct_unit4"},
					{"tmp_journal.curr_code","tmp_journal.curr_code"},
					{"tmp_journal.exch_rate","tmp_journal.exch_rate"},
					{"tmp_journal.for_amount","tmp_journal.for_amount"},
					{"tmp_journal.NoteExistsFlag","tmp_journal.NoteExistsFlag"},
					{"tmp_journal.RowPointer","tmp_journal.RowPointer"},
					{"chart.RowPointer","chart.RowPointer"},
					{"chart.description","chart.description"},
					{"chart.type","chart.type"},
				},
				loadForChange: false,
                lockingType: LockingType.None,
                tableName:"tt_journal",
				fromClause: collectionLoadRequestFactory.Clause(@" INNER JOIN tmp_journal ON tt_journal.id = tmp_journal.id
					AND tt_journal.SessionID = tmp_journal.ProcessId INNER JOIN chart ON chart.acct = tmp_journal.acct"),
				whereClause: collectionLoadRequestFactory.Clause("tt_journal.SessionID = {2} AND tt_journal.printed = 0 AND tt_journal.post = 1 AND (tmp_journal.trans_date >= {0} AND tmp_journal.trans_date <= {1})",pTransDateStart,pTransDateEnd,pSessionID),
				orderByClause: collectionLoadRequestFactory.Clause(" tmp_journal.id, tmp_journal.seq"));

            var dicTTJournalSort = new Dictionary<string, SortOrderDirection>();
            dicTTJournalSort.Add("tmp_journal.id", SortOrderDirection.Ascending);
            dicTTJournalSort.Add("tmp_journal.seq", SortOrderDirection.Ascending);
            var ttJournalSort = sortOrderFactory.Create(dicTTJournalSort);

            var ttJournalStream = recordStreamFactory.Create(appDB, queryLanguage, mgSessionVariableBasedCache, collectionLoadRequestFactory, TTJournalIdCrsLoadRequestForCursor,
                ttJournalSort, SQLPagedRecordStreamBookmarkID.MyReport_Rpt, pageSize, LoadType.First, false);

            return ttJournalStream;
        }

		public (int? treadonly, string JournalLedgerType, int? rowCount) Jour_HdrLoad(string JournalId, string JournalLedgerType, int? treadonly)
		{
			ListYesNoType _treadonly = DBNull.Value;
			LedgerTypeType _JournalLedgerType = DBNull.Value;
			
			var jour_hdrLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_treadonly,"jour_hdr.read_only"},
					{_JournalLedgerType,"jour_hdr.ledger_type"},
				},
				loadForChange: false,
                lockingType: LockingType.None,
                tableName:"jour_hdr",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("jour_hdr.id = {0}",JournalId),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var jour_hdrLoadResponse = this.appDB.Load(jour_hdrLoadRequest);
			if(jour_hdrLoadResponse.Items.Count > 0)
			{
				treadonly = _treadonly;
				JournalLedgerType = _JournalLedgerType;
			}
			
			int rowCount = jour_hdrLoadResponse.Items.Count;
			return (treadonly, JournalLedgerType, rowCount);
		}
		
		public (int? PeriodsCurPeriod, int? PeriodsClosed, int? rowCount) Periods_AllasperiodsLoad(Guid? PeriodsRowPointer, int? PeriodsCurPeriod, int? PeriodsClosed)
		{
			FinPeriodType _PeriodsCurPeriod = DBNull.Value;
			ListYesNoType _PeriodsClosed = DBNull.Value;
			
			var periods_allASperiodsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_PeriodsCurPeriod,"periods.cur_per"},
					{_PeriodsClosed,"periods.closed"},
				},
				loadForChange: false,
                lockingType: LockingType.None,
                tableName:"periods_all AS periods",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("periods.RowPointer = {0}",PeriodsRowPointer),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var periods_allASperiodsLoadResponse = this.appDB.Load(periods_allASperiodsLoadRequest);
			if(periods_allASperiodsLoadResponse.Items.Count > 0)
			{
				PeriodsCurPeriod = _PeriodsCurPeriod;
				PeriodsClosed = _PeriodsClosed;
			}
			
			int rowCount = periods_allASperiodsLoadResponse.Items.Count;
			return (PeriodsCurPeriod, PeriodsClosed, rowCount);
		}
		
		public (int? ForCurrencyPlaces, string ForCurrencyFormat, int? rowCount) Currency2Load(string JournalCurrCode, string ForCurrencyFormat, int? ForCurrencyPlaces)
		{
			DecimalPlacesType _ForCurrencyPlaces = DBNull.Value;
			InputMaskType _ForCurrencyFormat = DBNull.Value;
			
			var currency2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_ForCurrencyPlaces,"places"},
					{_ForCurrencyFormat,"amt_format"},
				},
				loadForChange: false,
                lockingType: LockingType.None,
                maximumRows: 1,
				tableName:"currency",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("curr_code = {0}",JournalCurrCode),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var currency2LoadResponse = this.appDB.Load(currency2LoadRequest);
			if(currency2LoadResponse.Items.Count > 0)
			{
				ForCurrencyPlaces = _ForCurrencyPlaces;
				ForCurrencyFormat = _ForCurrencyFormat;
			}
			
			int rowCount = currency2LoadResponse.Items.Count;
			return (ForCurrencyPlaces, ForCurrencyFormat, rowCount);
		}
		
		public ICollectionLoadResponse NontableSelect(Guid? processId, int? NewJournalInd, string JournalId, int? JournalSeq, int? JournalDetailSeq, 
            string DomCurrencyFormat, int? DomCurrencyPlaces, string ForCurrencyFormat, int? ForCurrencyPlaces, 
            string DomTotCurrencyFormat, int? DomTotCurrencyPlaces)
		{
			var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
                    {"process_id", processId},
					{ "NewJournalInd", NewJournalInd},
					{ "JournalId", JournalId},
					{ "JournalSeq", JournalSeq},
					{ "JournalDetailSeq", JournalDetailSeq},
					{ "DetailType", 0},
					{ "ReadOnlyInd", 0},
					{ "CurPeriodInd", null},
					{ "TransDate", null},
					{ "Account", null},
					{ "AcctUnit1", null},
					{ "AcctUnit2", null},
					{ "AcctUnit3", null},
					{ "AcctUnit4", null},
					{ "DomTcAmtDr", 0},
					{ "DomTcAmtCr", 0},
					{ "JournalRef", null},
					{ "JournalReverse", null},
					{ "BankCode", null},
					{ "AcctDescription", null},
					{ "TcAmtDr", 0},
					{ "TcAmtCr", 0},
					{ "CurrCode", null},
					{ "ExchRate", null},
					{ "NoteExistsFlag", 0},
					{ "JournalIsAna", 0},
					{ "ChartType", null},
					{ "Account2", null},
					{ "ChartDescription2", null},
					{ "DomTcAmtDr2", 0},
					{ "DomTcAmtCr2", 0},
					{ "HdrText", 0},
					{ "SubStrText", null},
					{ "DisAccount", null},
					{ "DisAcctUnit1", null},
					{ "DisAcctUnit2", null},
					{ "DisAcctUnit3", null},
					{ "DisAcctUnit4", null},
					{ "DomTcAmtDr3", 0},
					{ "DomTcAmtCr3", 0},
					{ "ChartDescription3", null},
					{ "RecurMsg", 0},
					{ "PctMsg", 0},
					{ "FtrText", 0},
					{ "WarnText1", 0},
					{ "WarnText2", 0},
					{ "JournalRowPointer", null},
					{ "DomCurrencyFormat", DomCurrencyFormat},
					{ "DomCurrencyPlaces", DomCurrencyPlaces},
					{ "ForCurrencyFormat", ForCurrencyFormat},
					{ "ForCurrencyPlaces", ForCurrencyPlaces},
					{ "DomTotCurrencyFormat", DomTotCurrencyFormat},
					{ "DomTotCurrencyPlaces", DomTotCurrencyPlaces},
			});
			
			return this.appDB.Load(nonTableLoadRequest);
		}
		public void NontableInsert(ICollectionLoadResponse nonTableLoadResponse)
		{
            unionUtil.Add(nonTableLoadResponse);
		}
		
		public ICollectionLoadResponse Nontable1Select(Guid? processId, int? NewJournalInd, string JournalId, int? JournalSeq, int? JournalDetailSeq, 
            int? treadonly, int? tPer, DateTime? PDate, string JournalAcct, string JournalAcctUnit1, string JournalAcctUnit2, 
            string JournalAcctUnit3, string JournalAcctUnit4, decimal? JournalDomAmount, decimal? DomTcAmtDr, decimal? DomTcAmtCr,
            string JournalRef, int? JournalReverse, string JournalBankCode, string tAcct, decimal? JournalForAmount, decimal? TcAmtDr, 
            decimal? TcAmtCr, string JournalCurrCode, decimal? JournalExchRate, int? NoteExistsFlag, int? tJournalIsAna, string ChartType, 
            int? WarnText1, int? WarnText2, Guid? JournalRowPointer, string DomCurrencyFormat, int? DomCurrencyPlaces, string ForCurrencyFormat, 
            int? ForCurrencyPlaces, string DomTotCurrencyFormat, int? DomTotCurrencyPlaces)
		{
			var nonTable1LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
                    {"process_id", processId},
                    { "NewJournalInd", NewJournalInd},
					{ "JournalId", JournalId},
					{ "JournalSeq", JournalSeq},
					{ "JournalDetailSeq", JournalDetailSeq},
					{ "DetailType", 1},
					{ "ReadOnlyInd", treadonly},
					{ "CurPeriodInd", (sQLUtil.SQLEqual(tPer, 1) == true ? "*" : convertToUtil.ToString<string>(null))},
					{ "TransDate", PDate},
					{ "Account", JournalAcct},
					{ "AcctUnit1", JournalAcctUnit1},
					{ "AcctUnit2", JournalAcctUnit2},
					{ "AcctUnit3", JournalAcctUnit3},
					{ "AcctUnit4", JournalAcctUnit4},
					{ "DomTcAmtDr", (sQLUtil.SQLGreaterThan(JournalDomAmount, 0) == true ? DomTcAmtDr : 0)},
					{ "DomTcAmtCr", (sQLUtil.SQLLessThan(JournalDomAmount, 0) == true ? DomTcAmtCr : 0)},
					{ "JournalRef", JournalRef},
					{ "JournalReverse", (sQLUtil.SQLEqual(treadonly, 0) == true ? JournalReverse : null)},
					{ "BankCode", JournalBankCode},
					{ "AcctDescription", tAcct},
					{ "TcAmtDr", (sQLUtil.SQLGreaterThan(JournalForAmount, 0) == true ? TcAmtDr : 0)},
					{ "TcAmtCr", (sQLUtil.SQLLessThan(JournalForAmount, 0) == true ? TcAmtCr : 0)},
					{ "CurrCode", JournalCurrCode},
					{ "ExchRate", JournalExchRate},
					{ "NoteExistsFlag", NoteExistsFlag},
					{ "JournalIsAna", tJournalIsAna},
					{ "ChartType", ChartType},
					{ "Account2", null},
					{ "ChartDescription2", null},
					{ "DomTcAmtDr2", 0},
					{ "DomTcAmtCr2", 0},
					{ "HdrText", 0},
					{ "SubStrText", null},
					{ "DisAccount", null},
					{ "DisAcctUnit1", null},
					{ "DisAcctUnit2", null},
					{ "DisAcctUnit3", null},
					{ "DisAcctUnit4", null},
					{ "DomTcAmtDr3", 0},
					{ "DomTcAmtCr3", 0},
					{ "ChartDescription3", null},
					{ "RecurMsg", 0},
					{ "PctMsg", 0},
					{ "FtrText", 0},
					{ "WarnText1", WarnText1},
					{ "WarnText2", WarnText2},
					{ "JournalRowPointer", JournalRowPointer},
					{ "DomCurrencyFormat", DomCurrencyFormat},
					{ "DomCurrencyPlaces", DomCurrencyPlaces},
					{ "ForCurrencyFormat", ForCurrencyFormat},
					{ "ForCurrencyPlaces", ForCurrencyPlaces},
					{ "DomTotCurrencyFormat", DomTotCurrencyFormat},
					{ "DomTotCurrencyPlaces", DomTotCurrencyPlaces},
			});
			
			return this.appDB.Load(nonTable1LoadRequest);
		}
		public void Nontable1Insert(ICollectionLoadResponse nonTable1LoadResponse)
		{
            unionUtil.Add(nonTable1LoadResponse);
		}
		
		public void Tmpprtacctdis1Delete()
		{
            var tmpPrtAcctDisDeleteRequest = collectionNonTriggerDeleteRequestFactory.SQLDelete(tableName: "#tmpPrtAcctDis",
                fromClause: collectionNonTriggerDeleteRequestFactory.Clause(""),
                whereClause: collectionNonTriggerDeleteRequestFactory.Clause(""));
            this.appDB.DeleteWithoutTrigger(tmpPrtAcctDisDeleteRequest);
		}
		
		public IRecordStream Tmpprtacctdis2Select(int? Severity, string JournalAcct, decimal? JournalDomAmount, string PList, string JournalCurrCode, string CrDbTxt, string ChartDescription, int? XDomCurrencyPlaces, int? DetailSeq, DateTime? PDate, decimal? JournalForAmount)
		{
			var DisCrsLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"tpad.Account","tpad.Account"},
					{"tpad.ChartDescription","tpad.ChartDescription"},
					{"tpad.DomTcAmtDr","tpad.DomTcAmtDr"},
					{"tpad.DomTcAmtCr","tpad.DomTcAmtCr"},
					{"tpad.HdrText","tpad.HdrText"},
					{"tpad.DisAccount","tpad.DisAccount"},
					{"tpad.DisAccountUnit1","tpad.DisAccountUnit1"},
					{"tpad.DisAccountUnit2","tpad.DisAccountUnit2"},
					{"tpad.DisAccountUnit3","tpad.DisAccountUnit3"},
					{"tpad.DisAccountUnit4","tpad.DisAccountUnit4"},
					{"tpad.DomTcAmtDr2","tpad.DomTcAmtDr2"},
					{"tpad.DomTcAmtCr2","tpad.DomTcAmtCr2"},
					{"tpad.DisAcctDescription","tpad.DisAcctDescription"},
					{"tpad.RecurMsg","tpad.RecurMsg"},
					{"tpad.PctMsg","tpad.PctMsg"},
					{"tpad.FtrText","tpad.FtrText"},
					{"tpad.SubStrText","tpad.SubStrText"},
                    {"tpad.DetailSeq","tpad.DetailSeq"},
                },
				loadForChange: false,
                lockingType: LockingType.None,
                tableName:"#tmpPrtAcctDis",
				fromClause: collectionLoadRequestFactory.Clause(" AS tpad"),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(" tpad.DetailSeq ASC"));
            
            Dictionary<string, SortOrderDirection> dicDisCrsSortOrder = new Dictionary<string, SortOrderDirection>();
            dicDisCrsSortOrder.Add("tpad.DetailSeq", SortOrderDirection.Ascending);
            ISortOrder disCrsSortOrder = sortOrderFactory.Create(dicDisCrsSortOrder);

            var recordStream = recordStreamFactory.Create(appDB, queryLanguage, mgSessionVariableBasedCache, collectionLoadRequestFactory,
                DisCrsLoadRequestForCursor, disCrsSortOrder, SQLPagedRecordStreamBookmarkID.MyReport_Rpt, pageSize, LoadType.First, false);

            return recordStream;
        }
		public ICollectionLoadResponse Nontable2Select(Guid? processId, int? NewJournalInd, string JournalId, int? JournalSeq, int? JournalDetailSeq, int? treadonly, int? tPer, DateTime? PDate, string JournalAcct, string JournalAcctUnit1, string JournalAcctUnit2, string JournalAcctUnit3, string JournalAcctUnit4, string JournalRef, int? JournalReverse, string JournalBankCode, string tAcct, string JournalCurrCode, decimal? JournalExchRate, int? NoteExistsFlag, int? tJournalIsAna, string ChartType, string tpadAccount, string tpadChartDescription, decimal? tpadDomTcAmtDr, decimal? tpadDomTcAmtCr, int? tpadHdrText, string tpadSubStrText, string tpadDisAccount, string tpadDisAccountUnit1, string tpadDisAccountUnit2, string tpadDisAccountUnit3, string tpadDisAccountUnit4, decimal? tpadDomTcAmtDr2, decimal? tpadDomTcAmtCr2, string tpadDisAcctDescription, int? tpadRecurMsg, int? tpadPctMsg, int? tpadFtrText, int? WarnText1, int? WarnText2, Guid? JournalRowPointer, string DomCurrencyFormat, int? DomCurrencyPlaces, string ForCurrencyFormat, int? ForCurrencyPlaces, string DomTotCurrencyFormat, int? DomTotCurrencyPlaces)
		{
			var nonTable2LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
                    {"process_id", processId},
					{ "NewJournalInd", NewJournalInd},
					{ "JournalId", JournalId},
					{ "JournalSeq", JournalSeq},
					{ "JournalDetailSeq", JournalDetailSeq},
					{ "DetailType", 2},
					{ "ReadOnlyInd", treadonly},
					{ "CurPeriodInd", (sQLUtil.SQLEqual(tPer, 1) == true ? "*" : convertToUtil.ToString<string>(null))},
					{ "TransDate", PDate},
					{ "Account", JournalAcct},
					{ "AcctUnit1", JournalAcctUnit1},
					{ "AcctUnit2", JournalAcctUnit2},
					{ "AcctUnit3", JournalAcctUnit3},
					{ "AcctUnit4", JournalAcctUnit4},
					{ "DomTcAmtDr", 0},
					{ "DomTcAmtCr", 0},
					{ "JournalRef", JournalRef},
					{ "JournalReverse", (sQLUtil.SQLEqual(treadonly, 0) == true ? JournalReverse : null)},
					{ "BankCode", JournalBankCode},
					{ "AcctDescription", tAcct},
					{ "TcAmtDr", 0},
					{ "TcAmtCr", 0},
					{ "CurrCode", JournalCurrCode},
					{ "ExchRate", JournalExchRate},
					{ "NoteExistsFlag", NoteExistsFlag},
					{ "JournalIsAna", tJournalIsAna},
					{ "ChartType", ChartType},
					{ "Account2", tpadAccount},
					{ "ChartDescription2", tpadChartDescription},
					{ "DomTcAmtDr2", tpadDomTcAmtDr},
					{ "DomTcAmtCr2", tpadDomTcAmtCr},
					{ "HdrText", tpadHdrText},
					{ "SubStrText", tpadSubStrText},
					{ "DisAccount", tpadDisAccount},
					{ "DisAcctUnit1", tpadDisAccountUnit1},
					{ "DisAcctUnit2", tpadDisAccountUnit2},
					{ "DisAcctUnit3", tpadDisAccountUnit3},
					{ "DisAcctUnit4", tpadDisAccountUnit4},
					{ "DomTcAmtDr3", tpadDomTcAmtDr2},
					{ "DomTcAmtCr3", tpadDomTcAmtCr2},
					{ "ChartDescription3", tpadDisAcctDescription},
					{ "RecurMsg", tpadRecurMsg},
					{ "PctMsg", tpadPctMsg},
					{ "FtrText", tpadFtrText},
					{ "WarnText1", WarnText1},
					{ "WarnText2", WarnText2},
					{ "JournalRowPointer", JournalRowPointer},
					{ "DomCurrencyFormat", DomCurrencyFormat},
					{ "DomCurrencyPlaces", DomCurrencyPlaces},
					{ "ForCurrencyFormat", ForCurrencyFormat},
					{ "ForCurrencyPlaces", ForCurrencyPlaces},
					{ "DomTotCurrencyFormat", DomTotCurrencyFormat},
					{ "DomTotCurrencyPlaces", DomTotCurrencyPlaces},
			});
			
			return this.appDB.Load(nonTable2LoadRequest);
		}
		public void Nontable2Insert(ICollectionLoadResponse nonTable2LoadResponse)
		{
            unionUtil.Add(nonTable2LoadResponse);
        }
		
		public void Tmp_JournalDelete(Guid? pSessionID)
		{
            string delSql = string.Format("DELETE tmp_journal WHERE ProcessId = {0}", variableUtil.GetQuotedValue(pSessionID));
            sQLExpressionExecutor.Execute(delSql);
		}
		
		public void Tt_Journal1Update(Guid? pSessionID)
		{
            string updSql = string.Format("UPDATE tt_journal SET printed = 1 WHERE SessionID = {0} AND id IN (SELECT id FROM tt_journal WHERE SessionID = {0} AND printed = 0 AND post = 1)", variableUtil.GetQuotedValue(pSessionID));
            sQLExpressionExecutor.Execute(updSql);
        }
		
		public void Tt_Journal2Delete(Guid? pSessionID)
		{
            string delSql = string.Format("DELETE tt_journal WHERE SessionID = {0} AND printed = 1 AND posted = 1", variableUtil.GetQuotedValue(pSessionID));
            sQLExpressionExecutor.Execute(delSql);
		}
		
		public ICollectionLoadResponse Nontable3Select(Guid? processId)
		{
			var nonTable3LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
                    {"process_id", processId},
					{ "NewJournalInd", null},
					{ "JournalId", null},
					{ "JournalSeq", null},
					{ "JournalDetailSeq", null},
					{ "DetailType", null},
					{ "ReadOnlyInd", null},
					{ "CurPeriodInd", null},
					{ "TransDate", null},
					{ "Account", null},
					{ "AcctUnit1", null},
					{ "AcctUnit2", null},
					{ "AcctUnit3", null},
					{ "AcctUnit4", null},
					{ "DomTcAmtDr", null},
					{ "DomTcAmtCr", null},
					{ "JournalRef", null},
					{ "JournalReverse", null},
					{ "BankCode", null},
					{ "AcctDescription", null},
					{ "TcAmtDr", null},
					{ "TcAmtCr", null},
					{ "CurrCode", null},
					{ "ExchRate", null},
					{ "NoteExistsFlag", null},
					{ "JournalIsAna", null},
					{ "ChartType", null},
					{ "Account2", null},
					{ "ChartDescription2", null},
					{ "DomTcAmtDr2", null},
					{ "DomTcAmtCr2", null},
					{ "HdrText", null},
					{ "SubStrText", null},
					{ "DisAccount", null},
					{ "DisAcctUnit1", null},
					{ "DisAcctUnit2", null},
					{ "DisAcctUnit3", null},
					{ "DisAcctUnit4", null},
					{ "DomTcAmtDr3", null},
					{ "DomTcAmtCr3", null},
					{ "ChartDescription3", null},
					{ "RecurMsg", null},
					{ "PctMsg", null},
					{ "FtrText", null},
					{ "WarnText1", null},
					{ "WarnText2", null},
					{ "JournalRowPointer", null},
					{ "DomCurrencyFormat", null},
					{ "DomCurrencyPlaces", null},
					{ "ForCurrencyFormat", null},
					{ "ForCurrencyPlaces", null},
					{ "DomTotCurrencyFormat", null},
					{ "DomTotCurrencyPlaces", null},
			});
			
			return this.appDB.Load(nonTable3LoadRequest);
		}
		public void Nontable3Insert(ICollectionLoadResponse nonTable3LoadResponse)
		{
            unionUtil.Add(nonTable3LoadResponse);
		}
		
		public ICollectionLoadResponse _Select(Guid? processId)
		{
            // Insert rows in the unionUtil to tmp_rpt_mass_journal_posting table for later join query.
            var unionUtilCollectionLoadResponse = unionUtil.Process();
            var insertRequest = collectionInsertRequestFactory.SQLInsert("tmp_rpt_mass_journal_posting", unionUtilCollectionLoadResponse.Items);
            this.appDB.Insert(insertRequest);
            unionUtil.Clear();

            var _LoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"NewJournalInd","NewJournalInd"},
					{"JournalId","JournalId"},
					{"JournalSeq","JournalSeq"},
					{"Seq","Seq"},
					{"DetailType","DetailType"},
					{"col5","1"},
					{"SubStrText","SubStrText"},
					{"A.JournalRowPointer","A.JournalRowPointer"},
				},
				selectStatement: collectionLoadRequestFactory.Clause(@"SELECT @selectList
					FROM (SELECT DISTINCT NewJournalInd,
						JournalId,
						JournalSeq,
						DetailType,
						JournalRowPointer
						FROM   tmp_rpt_mass_journal_posting
						WHERE process_id = {0} AND JournalId IS NOT NULL
						AND NewJournalInd = 0
						AND DetailType <> 1
						AND HdrText = 1) AS A
					INNER JOIN
					(SELECT   max(JournalDetailSeq) AS Seq,
						max(SubStrText) AS SubStrText,
						JournalRowPointer
						FROM     tmp_rpt_mass_journal_posting
						WHERE process_id = {0} AND JournalId IS NOT NULL
						AND NewJournalInd = 0
						AND DetailType <> 1
						GROUP BY JournalRowPointer) AS B
					ON (A.JournalRowPointer = B.JournalRowPointer)", processId));
			
			return this.appDB.Load(_LoadRequest);
		}
		
		public void _Insert(ICollectionLoadResponse _LoadResponse)
		{
			var _InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_DetailA",
				items: _LoadResponse.Items);
			
			this.appDB.Insert(_InsertRequest);
		}
		
		public void DetailInsert(Guid? processId)
		{
            object nullValue = null;
            var nonTriggerDetailSelectInsertRequest = collectionNonTriggerInsertRequestFactory.SQLInsert(
                targetTableName: "tmp_rpt_mass_journal_posting",
                targetColumns: new List<string>()
                {   "process_id",
                    "NewJournalInd",
                    "JournalId",
                    "JournalSeq",
                    "JournalDetailSeq",
                    "DetailType",
                    "ReadOnlyInd",
                    "CurPeriodInd",
                    "TransDate",
                    "Account",
                    "AcctUnit1",
                    "AcctUnit2",
                    "AcctUnit3",
                    "AcctUnit4",
                    "DomTcAmtDr",
                    "DomTcAmtCr",
                    "JournalRef",
                    "JournalReverse",
                    "BankCode",
                    "AcctDescription",
                    "TcAmtDr",
                    "TcAmtCr",
                    "CurrCode",
                    "ExchRate",
                    "NoteExistsFlag",
                    "JournalIsAna",
                    "ChartType",
                    "Account2",
                    "ChartDescription2",
                    "DomTcAmtDr2",
                    "DomTcAmtCr2",
                    "HdrText",
                    "SubStrText",
                    "DisAccount",
                    "DisAcctUnit1",
                    "DisAcctUnit2",
                    "DisAcctUnit3",
                    "DisAcctUnit4",
                    "DomTcAmtDr3",
                    "DomTcAmtCr3",
                    "ChartDescription3",
                    "RecurMsg",
                    "PctMsg",
                    "FtrText",
                    "WarnText1",
                    "WarnText2",
                    "JournalRowPointer",
                    "DomCurrencyFormat",
                    "DomCurrencyPlaces",
                    "ForCurrencyFormat",
                    "ForCurrencyPlaces",
                    "DomTotCurrencyFormat",
                    "DomTotCurrencyPlaces"
                },
                valuesByExpressionToAssign: new Dictionary<string, IParameterizedCommand>()
                {
                    {"process_id", collectionNonTriggerInsertRequestFactory.Clause("{0}", processId)},
                    {"NewJournalInd", collectionNonTriggerInsertRequestFactory.Clause("NewJournalInd")},
                    {"JournalId", collectionNonTriggerInsertRequestFactory.Clause("JournalId")},
                    {"JournalSeq", collectionNonTriggerInsertRequestFactory.Clause("JournalSeq")},
                    {"JournalDetailSeq", collectionNonTriggerInsertRequestFactory.Clause("JournalDetailSeq")},
                    {"DetailType", collectionNonTriggerInsertRequestFactory.Clause("DetailType")},
                    {"ReadOnlyInd", collectionNonTriggerInsertRequestFactory.Clause("{0}", nullValue)},
                    {"CurPeriodInd", collectionNonTriggerInsertRequestFactory.Clause("{0}", nullValue)},
                    {"TransDate", collectionNonTriggerInsertRequestFactory.Clause("{0}", nullValue)},
                    {"Account", collectionNonTriggerInsertRequestFactory.Clause("{0}", nullValue)},
                    {"AcctUnit1", collectionNonTriggerInsertRequestFactory.Clause("{0}", nullValue)},
                    {"AcctUnit2", collectionNonTriggerInsertRequestFactory.Clause("{0}", nullValue)},
                    {"AcctUnit3", collectionNonTriggerInsertRequestFactory.Clause("{0}", nullValue)},
                    {"AcctUnit4", collectionNonTriggerInsertRequestFactory.Clause("{0}", nullValue)},
                    {"DomTcAmtDr", collectionNonTriggerInsertRequestFactory.Clause("{0}", nullValue)},
                    {"DomTcAmtCr", collectionNonTriggerInsertRequestFactory.Clause("{0}", nullValue)},
                    {"JournalRef", collectionNonTriggerInsertRequestFactory.Clause("{0}", nullValue)},
                    {"JournalReverse", collectionNonTriggerInsertRequestFactory.Clause("{0}", nullValue)},
                    {"BankCode", collectionNonTriggerInsertRequestFactory.Clause("{0}", nullValue)},
                    {"AcctDescription", collectionNonTriggerInsertRequestFactory.Clause("{0}", nullValue)},
                    {"TcAmtDr", collectionNonTriggerInsertRequestFactory.Clause("{0}", nullValue)},
                    {"TcAmtCr", collectionNonTriggerInsertRequestFactory.Clause("{0}", nullValue)},
                    {"CurrCode", collectionNonTriggerInsertRequestFactory.Clause("{0}", nullValue)},
                    {"ExchRate", collectionNonTriggerInsertRequestFactory.Clause("{0}", nullValue)},
                    {"NoteExistsFlag", collectionNonTriggerInsertRequestFactory.Clause("{0}", nullValue)},
                    {"JournalIsAna", collectionNonTriggerInsertRequestFactory.Clause("{0}", nullValue)},
                    {"ChartType", collectionNonTriggerInsertRequestFactory.Clause("{0}", nullValue)},
                    {"Account2", collectionNonTriggerInsertRequestFactory.Clause("{0}", nullValue)},
                    {"ChartDescription2", collectionNonTriggerInsertRequestFactory.Clause("{0}", nullValue)},
                    {"DomTcAmtDr2", collectionNonTriggerInsertRequestFactory.Clause("{0}", nullValue)},
                    {"DomTcAmtCr2", collectionNonTriggerInsertRequestFactory.Clause("{0}", nullValue)},
                    {"HdrText", collectionNonTriggerInsertRequestFactory.Clause("HdrText")},
                    {"SubStrText", collectionNonTriggerInsertRequestFactory.Clause("SubStrText")},
                    {"DisAccount", collectionNonTriggerInsertRequestFactory.Clause("{0}", nullValue)},
                    {"DisAcctUnit1", collectionNonTriggerInsertRequestFactory.Clause("{0}", nullValue)},
                    {"DisAcctUnit2", collectionNonTriggerInsertRequestFactory.Clause("{0}", nullValue)},
                    {"DisAcctUnit3", collectionNonTriggerInsertRequestFactory.Clause("{0}", nullValue)},
                    {"DisAcctUnit4", collectionNonTriggerInsertRequestFactory.Clause("{0}", nullValue)},
                    {"DomTcAmtDr3", collectionNonTriggerInsertRequestFactory.Clause("{0}", nullValue)},
                    {"DomTcAmtCr3", collectionNonTriggerInsertRequestFactory.Clause("{0}", nullValue)},
                    {"ChartDescription3", collectionNonTriggerInsertRequestFactory.Clause("{0}", nullValue)},
                    {"RecurMsg", collectionNonTriggerInsertRequestFactory.Clause("{0}", nullValue)},
                    {"PctMsg", collectionNonTriggerInsertRequestFactory.Clause("{0}", nullValue)},
                    {"FtrText", collectionNonTriggerInsertRequestFactory.Clause("{0}", nullValue)},
                    {"WarnText1", collectionNonTriggerInsertRequestFactory.Clause("{0}", nullValue)},
                    {"WarnText2", collectionNonTriggerInsertRequestFactory.Clause("{0}", nullValue)},
                    {"JournalRowPointer", collectionNonTriggerInsertRequestFactory.Clause("JournalRowPointer")},
                    {"DomCurrencyFormat", collectionNonTriggerInsertRequestFactory.Clause("{0}", nullValue)},
                    {"DomCurrencyPlaces", collectionNonTriggerInsertRequestFactory.Clause("{0}", nullValue)},
                    {"ForCurrencyFormat", collectionNonTriggerInsertRequestFactory.Clause("{0}", nullValue)},
                    {"ForCurrencyPlaces", collectionNonTriggerInsertRequestFactory.Clause("{0}", nullValue)},
                    {"DomTotCurrencyFormat", collectionNonTriggerInsertRequestFactory.Clause("{0}", nullValue)},
                    {"DomTotCurrencyPlaces", collectionNonTriggerInsertRequestFactory.Clause("{0}", nullValue)},
                },
                fromClause: collectionNonTriggerInsertRequestFactory.Clause("#tv_DetailA"),
                whereClause: collectionNonTriggerInsertRequestFactory.Clause(""),
                orderByClause: collectionNonTriggerInsertRequestFactory.Clause(""));

            this.appDB.InsertWithoutTrigger(nonTriggerDetailSelectInsertRequest);
		}
		
		public ICollectionLoadResponse Tv_DetailSelect(Guid? processId)
		{
            IBookmark bookmark = mgSessionVariableBasedCache.Get<Bookmark>("BunchingBookmark");
            var whereClause = collectionLoadRequestFactory.Clause(" process_id = {0}", processId);
            if (bookmark != null && loadType == LoadType.Next)
            {
                // Append additional condition from bookmark if it is not null.
                whereClause = queryLanguage.AppendBookmark(whereClause, bookmark);
            }

            var tv_DetailLoadRequest = collectionLoadRequestFactory.SQLLoad(columns: new List<string>()
                {
                    "NewJournalInd",
                    "JournalId",
                    "JournalSeq",
                    "JournalDetailSeq",
                    "DetailType",
                    "ReadOnlyInd",
                    "CurPeriodInd",
                    "TransDate",
                    "Account",
                    "AcctUnit1",
                    "AcctUnit2",
                    "AcctUnit3",
                    "AcctUnit4",
                    "DomTcAmtDr",
                    "DomTcAmtCr",
                    "JournalRef",
                    "JournalReverse",
                    "BankCode",
                    "AcctDescription",
                    "TcAmtDr",
                    "TcAmtCr",
                    "CurrCode",
                    "ExchRate",
                    "NoteExistsFlag",
                    "JournalIsAna",
                    "ChartType",
                    "Account2",
                    "ChartDescription2",
                    "DomTcAmtDr2",
                    "DomTcAmtCr2",
                    "HdrText",
                    "SubStrText",
                    "DisAccount",
                    "DisAcctUnit1",
                    "DisAcctUnit2",
                    "DisAcctUnit3",
                    "DisAcctUnit4",
                    "DomTcAmtDr3",
                    "DomTcAmtCr3",
                    "ChartDescription3",
                    "RecurMsg",
                    "PctMsg",
                    "FtrText",
                    "WarnText1",
                    "WarnText2",
                    "JournalRowPointer",
                    "DomCurrencyFormat",
                    "DomCurrencyPlaces",
                    "ForCurrencyFormat",
                    "ForCurrencyPlaces",
                    "DomTotCurrencyFormat",
                    "DomTotCurrencyPlaces",
                },
                loadForChange: false,
                lockingType: LockingType.None,
                maximumRows: recordCap + 1,
                tableName: "tmp_rpt_mass_journal_posting",
                fromClause: collectionLoadRequestFactory.Clause(" Detail"),
                whereClause: whereClause,
                orderByClause: collectionLoadRequestFactory.Clause(" Detail.JournalId ASC, Detail.JournalSeq ASC, Detail.DetailType ASC, Detail.JournalDetailSeq ASC")); ;
			
            var tv_DetailLoadResponse = this.appDB.Load(tv_DetailLoadRequest);
            if(tv_DetailLoadResponse.Items.Count > recordCap)
            {
                Dictionary<string, SortOrderDirection> dicDetailSortOrder = new Dictionary<string, SortOrderDirection>();
                dicDetailSortOrder.Add("JournalId", SortOrderDirection.Ascending);
                dicDetailSortOrder.Add("JournalSeq", SortOrderDirection.Ascending);
                dicDetailSortOrder.Add("DetailType", SortOrderDirection.Ascending);
                dicDetailSortOrder.Add("JournalDetailSeq", SortOrderDirection.Ascending);

                ISortOrder detailSortOrder = sortOrderFactory.Create(dicDetailSortOrder);

                // Use the last second row for bookmark.
                int lastSecondRowIndex = tv_DetailLoadResponse.Items.Count - 2;
                IRecordReadOnly bookmarkRow = tv_DetailLoadResponse.Items[lastSecondRowIndex];
                bookmark = bookmarkFactory.Create(bookmarkRow, detailSortOrder);
                // Save bookmark with mgSessionVariableBasedCache.
                mgSessionVariableBasedCache.Insert("BunchingBookmark", (ICachable)bookmark);

                // After mgSessionVariableBasedCache save the BunchingBookmark, get the serialized xml. 
                (int? returnCode, string variableValue, string infobar) = getVariable.GetVariableSp("BunchingBookmark", "", 0, "", "");
                if (!string.IsNullOrEmpty(variableValue))
                {
                    // Save this xml as bookmark for mongoose. The variable name should be "Bookmark".
                    defineProcessVariable.DefineProcessVariableSp("Bookmark", variableValue, infobar);
                }
            }
            else
            {
                CleanupResultTable(processId);
            }

            return tv_DetailLoadResponse;
        }

        public void CleanupResultTable(Guid? processId)
        {
            var resultTableDeleteRequest = collectionNonTriggerDeleteRequestFactory.SQLDelete(
                tableName: "tmp_rpt_mass_journal_posting",
                fromClause: collectionNonTriggerDeleteRequestFactory.Clause(""),
                whereClause: collectionNonTriggerDeleteRequestFactory.Clause("process_id = {0}", processId));
            this.appDB.DeleteWithoutTrigger(resultTableDeleteRequest);
        }
		
		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		AltExtGen_Rpt_MassJournalPostingSp(
			string AltExtGenSp,
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
			StringType _pSessionIDChar = pSessionIDChar;
			ListYesNoType _pSingleDate = pSingleDate;
			DateType _pDateForTrans = pDateForTrans;
			DateType _pTransDateStart = pTransDateStart;
			DateType _pTransDateEnd = pTransDateEnd;
			ListYesNoType _pPostInBackgroundQueue = pPostInBackgroundQueue;
			ListYesNoType _pCompJour = pCompJour;
			StringType _pCompressionLevel = pCompressionLevel;
			ListYesNoType _pDeleteTransactionsAfterPost = pDeleteTransactionsAfterPost;
			DateType _pReversingTransactionDate = pReversingTransactionDate;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;
				
				appDB.AddCommandParameter(cmd, "pSessionIDChar", _pSessionIDChar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSingleDate", _pSingleDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pDateForTrans", _pDateForTrans, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTransDateStart", _pTransDateStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTransDateEnd", _pTransDateEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPostInBackgroundQueue", _pPostInBackgroundQueue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCompJour", _pCompJour, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCompressionLevel", _pCompressionLevel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pDeleteTransactionsAfterPost", _pDeleteTransactionsAfterPost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pReversingTransactionDate", _pReversingTransactionDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				var resultSet = dataTableToCollectionLoadResponse.Process(dtReturn);
				var returnCode = (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value;
				
				return (resultSet, returnCode);
			}
		}
	}
}
