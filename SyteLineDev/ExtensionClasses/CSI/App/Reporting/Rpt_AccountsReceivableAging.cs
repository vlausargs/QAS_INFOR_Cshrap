//PROJECT NAME: Reporting
//CLASS NAME: Rpt_AccountsReceivableAging.cs

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
using CSI.Material;
using CSI.Data.Cache;
using System.IO;

namespace CSI.Reporting
{
    public class Rpt_AccountsReceivableAging : IRpt_AccountsReceivableAging
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionUpdateRequestFactory collectionUpdateRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly ISQLCollectionLoad sQLCollectionLoad;
        readonly IApplyDateOffset iApplyDateOffset;
        readonly IExpandKyByType iExpandKyByType;
        readonly IScalarFunction scalarFunction;
        readonly IExistsChecker existsChecker;
        readonly IConvertToUtil convertToUtil;
        readonly IDateTimeUtil dateTimeUtil;
        readonly IVariableUtil variableUtil;
        readonly IAndSqlWhere iAndSqlWhere;
        readonly IMidnightOf iMidnightOf;
        readonly IStringUtil stringUtil;
        readonly IIsInteger iIsInteger;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly IAging iAging;
        readonly IQueryLanguage queryLanguage;
        readonly int recordCap;
        readonly IDefineProcessVariable defineProcessVariable;
        readonly IGetVariable getVariable;
        readonly ICache mgSessionVariableBasedCache;
        readonly IBookmarkFactory bookmarkFactory;
        readonly LoadType loadType;
        readonly IRecordCollectionToDataTable recordCollectionToDataTable;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
        readonly ILowCharacter lowCharacter;
        readonly IHighCharacter highCharacter;
        readonly ICollectionNonTriggerUpdateRequestFactory collectionNonTriggerUpdateRequestFactory;
        readonly ICollectionNonTriggerInsertRequestFactory collectionNonTriggerInsertRequestFactory;
        readonly ILogger logger;
        public Rpt_AccountsReceivableAging(IApplicationDB appDB,
            IBunchedLoadCollection bunchedLoadCollection,
            ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            ISQLCollectionLoad sQLCollectionLoad,
            IApplyDateOffset iApplyDateOffset,
            IExpandKyByType iExpandKyByType,
            IScalarFunction scalarFunction,
            IExistsChecker existsChecker,
            IConvertToUtil convertToUtil,
            IDateTimeUtil dateTimeUtil,
            IVariableUtil variableUtil,
            IAndSqlWhere iAndSqlWhere,
            IMidnightOf iMidnightOf,
            IStringUtil stringUtil,
            IIsInteger iIsInteger,
            ISQLValueComparerUtil sQLUtil,
            IAging iAging,
            IDefineProcessVariable defineProcessVariable,
            IGetVariable getVariable,
            ICache mgSessionVariableBasedCache,
            IQueryLanguage queryLanguage,
            IBookmarkFactory bookmarkFactory,
            //ISortOrder resultSortOrder,
            //ISortOrder arTranSortOrder,
            //ISortOrder tmpArAgingSortOrder,
            IRecordCollectionToDataTable recordCollectionToDataTable,
            IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse,
            ILowCharacter lowCharacter,
            IHighCharacter highCharacter,
            ICollectionNonTriggerUpdateRequestFactory collectionNonTriggerUpdateRequestFactory,
            ICollectionNonTriggerInsertRequestFactory collectionNonTriggerInsertRequestFactory,
            ILogger logger)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
            this.collectionLoadStatementRequestFactory = collectionLoadStatementRequestFactory;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            this.collectionUpdateRequestFactory = collectionUpdateRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.sQLCollectionLoad = sQLCollectionLoad;
            this.iApplyDateOffset = iApplyDateOffset;
            this.iExpandKyByType = iExpandKyByType;
            this.scalarFunction = scalarFunction;
            this.existsChecker = existsChecker;
            this.convertToUtil = convertToUtil;
            this.dateTimeUtil = dateTimeUtil;
            this.variableUtil = variableUtil;
            this.iAndSqlWhere = iAndSqlWhere;
            this.iMidnightOf = iMidnightOf;
            this.stringUtil = stringUtil;
            this.iIsInteger = iIsInteger;
            this.sQLUtil = sQLUtil;
            this.iAging = iAging;
            this.defineProcessVariable = defineProcessVariable;
            this.getVariable = getVariable;
            this.mgSessionVariableBasedCache = mgSessionVariableBasedCache;
            this.queryLanguage = queryLanguage;
            this.bookmarkFactory = bookmarkFactory;
            //this.resultSortOrder = resultSortOrder;
            //this.arTranSortOrder = arTranSortOrder;
            //this.tmpArAgingSortOrder = tmpArAgingSortOrder;
            this.loadType = bunchedLoadCollection.LoadType;
            this.recordCap = bunchedLoadCollection.RecordCap;
            this.bookmarkFactory = bookmarkFactory;
            this.recordCollectionToDataTable = recordCollectionToDataTable;
            this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
            if (bunchedLoadCollection.RecordCap == -1)
            {
                this.recordCap = 200;
            }
            if (bunchedLoadCollection.RecordCap == 0)
            {
                this.recordCap = int.MaxValue - 1;
            }
            this.lowCharacter = lowCharacter;
            this.highCharacter = highCharacter;
            this.collectionNonTriggerUpdateRequestFactory = collectionNonTriggerUpdateRequestFactory;
            this.collectionNonTriggerInsertRequestFactory = collectionNonTriggerInsertRequestFactory;
            this.logger = logger;
        }

        public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_AccountsReceivableAgingSp(
            DateTime? AgingDate = null,
            DateTime? CutoffDate = null,
            int? AgingDateOffset = null,
            int? CutoffDateOffset = null,
            string StateCycle = null,
            int? ShowActive = null,
            string BegSlsman = null,
            string EndSlsman = null,
            string CustomerStarting = null,
            string CustomerEnding = null,
            string NameStarting = null,
            string NameEnding = null,
            string CurCodeStarting = null,
            string CurCodeEnding = null,
            int? PrZeroBal = null,
            string CreditHold = null,
            int? PrCreditBal = null,
            int? SumToCorp = null,
            int? TransDomCurr = null,
            int? UseHistRate = null,
            string PrOpenItem = null,
            int? PrOpenPay = null,
            int? HidePaid = null,
            int? SortByCurr = null,
            string ArSortBy = null,
            string AgeBuckets = null,
            string InvDue = null,
            int? AgeDays1 = null,
            string AgeDesc1 = null,
            int? AgeDays2 = null,
            string AgeDesc2 = null,
            int? AgeDays3 = null,
            string AgeDesc3 = null,
            int? AgeDays4 = null,
            string AgeDesc4 = null,
            int? AgeDays5 = null,
            string AgeDesc5 = null,
            string SiteGroup = null,
            int? DisplayHeader = null,
            int? ConsolidateCustomers = null,
            int? IncludeEstCurrGainLossAmtsInTotals = null,
            string pSite = null,
            Guid? pProcessId = null)
        {
            DateType _AgingDate = AgingDate;
            DateType _CutoffDate = CutoffDate;
            DateOffsetType _AgingDateOffset = AgingDateOffset;
            DateOffsetType _CutoffDateOffset = CutoffDateOffset;
            InfobarType _StateCycle = StateCycle;
            ListYesNoType _ShowActive = ShowActive;
            SlsmanType _BegSlsman = BegSlsman;
            SlsmanType _EndSlsman = EndSlsman;
            CustNumType _CustomerStarting = CustomerStarting;
            CustNumType _CustomerEnding = CustomerEnding;
            NameType _NameStarting = NameStarting;
            NameType _NameEnding = NameEnding;
            CurrCodeType _CurCodeStarting = CurCodeStarting;
            CurrCodeType _CurCodeEnding = CurCodeEnding;
            ListYesNoType _PrZeroBal = PrZeroBal;
            StringType _CreditHold = CreditHold;
            ListYesNoType _PrCreditBal = PrCreditBal;
            ListYesNoType _SumToCorp = SumToCorp;
            ListYesNoType _TransDomCurr = TransDomCurr;
            ListYesNoType _UseHistRate = UseHistRate;
            SortDirectionPlusType _PrOpenItem = PrOpenItem;
            ListYesNoType _PrOpenPay = PrOpenPay;
            IntType _HidePaid = HidePaid;
            ListYesNoType _SortByCurr = SortByCurr;
            StringType _ArSortBy = ArSortBy;
            AcctType _AgeBuckets = AgeBuckets;
            ArAgeByType _InvDue = InvDue;
            AgeDaysType _AgeDays1 = AgeDays1;
            AgeDescType _AgeDesc1 = AgeDesc1;
            AgeDaysType _AgeDays2 = AgeDays2;
            AgeDescType _AgeDesc2 = AgeDesc2;
            AgeDaysType _AgeDays3 = AgeDays3;
            AgeDescType _AgeDesc3 = AgeDesc3;
            AgeDaysType _AgeDays4 = AgeDays4;
            AgeDescType _AgeDesc4 = AgeDesc4;
            AgeDaysType _AgeDays5 = AgeDays5;
            AgeDescType _AgeDesc5 = AgeDesc5;
            SiteGroupType _SiteGroup = SiteGroup;
            ListYesNoType _DisplayHeader = DisplayHeader;
            ListYesNoType _ConsolidateCustomers = ConsolidateCustomers;
            ListYesNoType _IncludeEstCurrGainLossAmtsInTotals = IncludeEstCurrGainLossAmtsInTotals;
            SiteType _pSite = pSite;
            RowPointerType _pProcessId = pProcessId;

            //ISortOrder resultSortOrder;
            //ISortOrder arTranSortOrder;
            //ISortOrder tmpArAgingSortOrder;

            Dictionary<string, SortOrderDirection> dicResultSortOrder = new Dictionary<string, SortOrderDirection>();
            dicResultSortOrder.Add("TcSortCurrCode", SortOrderDirection.Ascending);
            dicResultSortOrder.Add("Group1", SortOrderDirection.Ascending);
            dicResultSortOrder.Add("Group2", SortOrderDirection.Ascending);
            dicResultSortOrder.Add("Group3", SortOrderDirection.Ascending);
            dicResultSortOrder.Add("OrderByDate", SortOrderDirection.Ascending);
            dicResultSortOrder.Add("ApplyToInv", SortOrderDirection.Ascending);
            dicResultSortOrder.Add("TcArTranTypeGroup", SortOrderDirection.Ascending);
            dicResultSortOrder.Add("InvNum", SortOrderDirection.Ascending);
            dicResultSortOrder.Add("TcArtranInvSeq", SortOrderDirection.Ascending);
            dicResultSortOrder.Add("TcArTranChkSeq", SortOrderDirection.Ascending);
            dicResultSortOrder.Add("Seq", SortOrderDirection.Ascending);
            ISortOrder resultSortOrder = new SortOrder(dicResultSortOrder);

            Dictionary<string, SortOrderDirection> dicArTranSortOrder = new Dictionary<string, SortOrderDirection>();
            dicArTranSortOrder.Add("site_ref", SortOrderDirection.Ascending);
            dicArTranSortOrder.Add("cust_num", SortOrderDirection.Ascending);
            dicArTranSortOrder.Add("inv_num", SortOrderDirection.Ascending);
            dicArTranSortOrder.Add("inv_seq", SortOrderDirection.Ascending);
            dicArTranSortOrder.Add("check_seq", SortOrderDirection.Ascending);
            ISortOrder arTranSortOrder = new SortOrder(dicArTranSortOrder);

            Dictionary<string, SortOrderDirection> dicTmpArAgingSortOrder = new Dictionary<string, SortOrderDirection>();
            //dicTmpArAgingSortOrder.Add("TcSortCurrCode", SortOrderDirection.Ascending);
            //dicTmpArAgingSortOrder.Add("OrderByDate", SortOrderDirection.Ascending);
            //dicTmpArAgingSortOrder.Add("ApplyToInv", SortOrderDirection.Ascending);
            //dicTmpArAgingSortOrder.Add("TcArTranTypeGroup", SortOrderDirection.Ascending);
            //dicTmpArAgingSortOrder.Add("InvNum", SortOrderDirection.Ascending);
            //dicTmpArAgingSortOrder.Add("TcArtranInvSeq", SortOrderDirection.Ascending);
            //dicTmpArAgingSortOrder.Add("TcArTranChkSeq", SortOrderDirection.Ascending);
            dicTmpArAgingSortOrder.Add("Seq", SortOrderDirection.Ascending);
            ISortOrder tmpArAgingSortOrder = new SortOrder(dicTmpArAgingSortOrder);

            if (bunchedLoadCollection != null)
                bunchedLoadCollection.StartBunching();

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Rpt_AccountsReceivableAgingSp";

                appDB.AddCommandParameter(cmd, "AgingDate", _AgingDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CutoffDate", _CutoffDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AgingDateOffset", _AgingDateOffset, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CutoffDateOffset", _CutoffDateOffset, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StateCycle", _StateCycle, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ShowActive", _ShowActive, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BegSlsman", _BegSlsman, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndSlsman", _EndSlsman, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CustomerStarting", _CustomerStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CustomerEnding", _CustomerEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "NameStarting", _NameStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "NameEnding", _NameEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CurCodeStarting", _CurCodeStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CurCodeEnding", _CurCodeEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PrZeroBal", _PrZeroBal, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CreditHold", _CreditHold, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PrCreditBal", _PrCreditBal, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SumToCorp", _SumToCorp, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TransDomCurr", _TransDomCurr, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UseHistRate", _UseHistRate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PrOpenItem", _PrOpenItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PrOpenPay", _PrOpenPay, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "HidePaid", _HidePaid, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SortByCurr", _SortByCurr, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ArSortBy", _ArSortBy, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AgeBuckets", _AgeBuckets, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InvDue", _InvDue, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AgeDays1", _AgeDays1, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AgeDesc1", _AgeDesc1, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AgeDays2", _AgeDays2, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AgeDesc2", _AgeDesc2, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AgeDays3", _AgeDays3, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AgeDesc3", _AgeDesc3, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AgeDays4", _AgeDays4, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AgeDesc4", _AgeDesc4, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AgeDays5", _AgeDays5, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AgeDesc5", _AgeDesc5, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SiteGroup", _SiteGroup, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ConsolidateCustomers", _ConsolidateCustomers, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "IncludeEstCurrGainLossAmtsInTotals", _IncludeEstCurrGainLossAmtsInTotals, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pProcessId", _pProcessId, ParameterDirection.Input);

                IntType returnVal = 0;
                IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
                dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                if (bunchedLoadCollection != null)
                    bunchedLoadCollection.EndBunching();

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
            }
        }

        void LogTiming(string message)
        {
            //var timing = DateTime.Now - startTime;
            //logger.Performance(this.GetType().Name, $"{message} - {timing.ToString("c")}");
            //startTime = DateTime.Now;
        }

        #region C# Version
      //  public (
      //      ICollectionLoadResponse Data,
      //      int? ReturnCode)
      //  Rpt_AccountsReceivableAgingSp(
      //      DateTime? AgingDate = null,
      //      DateTime? CutoffDate = null,
      //      int? AgingDateOffset = null,
      //      int? CutoffDateOffset = null,
      //      string StateCycle = null,
      //      int? ShowActive = null,
      //      string BegSlsman = null,
      //      string EndSlsman = null,
      //      string CustomerStarting = null,
      //      string CustomerEnding = null,
      //      string NameStarting = null,
      //      string NameEnding = null,
      //      string CurCodeStarting = null,
      //      string CurCodeEnding = null,
      //      int? PrZeroBal = null,
      //      string CreditHold = null,
      //      int? PrCreditBal = null,
      //      int? SumToCorp = null,
      //      int? TransDomCurr = null,
      //      int? UseHistRate = null,
      //      string PrOpenItem = null,
      //      int? PrOpenPay = null,
      //      int? HidePaid = null,
      //      int? SortByCurr = null,
      //      string ArSortBy = null,
      //      string AgeBuckets = null,
      //      string InvDue = null,
      //      int? AgeDays1 = null,
      //      string AgeDesc1 = null,
      //      int? AgeDays2 = null,
      //      string AgeDesc2 = null,
      //      int? AgeDays3 = null,
      //      string AgeDesc3 = null,
      //      int? AgeDays4 = null,
      //      string AgeDesc4 = null,
      //      int? AgeDays5 = null,
      //      string AgeDesc5 = null,
      //      string SiteGroup = null,
      //      int? DisplayHeader = null,
      //      int? ConsolidateCustomers = null,
      //      int? IncludeEstCurrGainLossAmtsInTotals = null,
      //      string pSite = null,
      //      Guid? sessionId = null)
      //  {
      //      ArAgeByType _InvDue = InvDue;
      //      SiteGroupType _SiteGroup = SiteGroup;
      //      SiteType _pSite = pSite;
      //      IBookmark resultBookmark = null;

      //      //File.AppendAllText(@"C:\logs\araging\ArAgingLog.txt", "Starting: " + DateTime.Now.ToLongTimeString() + "\r\n");

      //      if (bunchedLoadCollection != null)
      //          bunchedLoadCollection.StartBunching();

      //      try
      //      {
      //          ICollectionLoadResponse Data = null;
      //          StringType _ALTGEN_SpName = DBNull.Value;
      //          string ALTGEN_SpName = null;
      //          int? ALTGEN_Severity = null;
      //          string LowChar = null;
      //          string HighChar = null;
      //          SiteType _ParmsSite = DBNull.Value;
      //          string ParmsSite = null;
      //          Guid? ProcessID = null;
      //          int? Severity = null;
      //          int? TGrand = null;
      //          decimal? TcTotBal = null;
      //          decimal? TcTotMajorBal = null;
      //          int? FirstOfCustomer = null;
      //          int? AnyTrans = null;
      //          int? AnyCurrTrans = null;
      //          int? SomeTrans = null;
      //          SiteType _SiteGroupSite = DBNull.Value;
      //          string SiteGroupSite = null;
      //          CurrCodeType _ParmsCurrCode = DBNull.Value;
      //          string ParmsCurrCode = null;
      //          string CurrencyCurrCode = null;
      //          int? TranslateForAging = null;
      //          int? TUseHistRate = null;
      //          string site_ref = null;
      //          string cust_num = null;
      //          string type = null;
      //          string inv_num = null;
      //          string apply_to_inv_num = null;
      //          int? inv_seq = null;
      //          int? check_seq = null;
      //          DateTime? inv_date = null;
      //          DateTime? due_date = null;
      //          DateType _order_by_date = DBNull.Value;
      //          DateTime? order_by_date = null;
      //          int? seq = null;
      //          string apply_to = null;
      //          string Inv_Num_Ori = null;
      //          string CustaddrCustNum = null;
      //          string CustaddrCurrCode = null;
      //          ICollectionLoadRequest curSiteGroupLoadRequestForCursor = null;
      //          ICollectionLoadResponse curSiteGroupLoadResponseForCursor = null;
      //          int curSiteGroup_CursorFetch_Status = -1;
      //          int curSiteGroup_CursorCounter = -1;
      //          ICollectionLoadRequest curCustAddrLoadRequestForCursor = null;
      //          ICollectionLoadResponse curCustAddrLoadResponseForCursor = null;
      //          int curCustAddr_CursorFetch_Status = -1;
      //          int curCustAddr_CursorCounter = -1;
      //          ICollectionLoadRequest curCurrencyLoadRequestForCursor = null;
      //          ICollectionLoadResponse curCurrencyLoadResponseForCursor = null;
      //          int curCurrency_CursorFetch_Status = -1;
      //          int curCurrency_CursorCounter = -1;
      //          ICollectionLoadRequest ResultSetCursorLoadRequestForCursor = null;
      //          ICollectionLoadResponse ResultSetCursorLoadResponseForCursor = null;
      //          int ResultSetCursor_CursorFetch_Status = -1;
      //          int ResultSetCursor_CursorCounter = -1;

      //          #region ETP Block
      //          if (existsChecker.Exists(tableName: "optional_module",
      //              fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
      //              whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_AccountsReceivableAgingSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"))
      //          )
      //          {
      //              //BEGIN
      //              //this temp table is a table variable in old stored procedure version.
      //              this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
						//    [SpName] SYSNAME);
						//SELECT * into #tv_ALTGEN from @ALTGEN");

      //              #region CRUD LoadToRecord
      //              var optional_module1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
      //                  {
      //                      {"SpName","CAST (NULL AS NVARCHAR)"},
      //                      {"u0","[om].[ModuleName]"},
      //                  },
      //                  loadForChange: false,
      //                  lockingType: LockingType.None,

      //                  tableName: "optional_module",
      //                  fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
      //                  whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_AccountsReceivableAgingSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
      //                  orderByClause: collectionLoadRequestFactory.Clause(""));
      //              var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
      //              #endregion  LoadToRecord

      //              #region CRUD InsertByRecords
      //              foreach (var optional_module1Item in optional_module1LoadResponse.Items)
      //              {
      //                  optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("Rpt_AccountsReceivableAgingSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
      //              };

      //              var optional_module1RequiredColumns = new List<string>() { "SpName" };

      //              optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

      //              var optional_module1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ALTGEN",
      //                  items: optional_module1LoadResponse.Items);

      //              this.appDB.Insert(optional_module1InsertRequest);
      //              #endregion InsertByRecords

      //              while (existsChecker.Exists(tableName: "#tv_ALTGEN",
      //                  fromClause: collectionLoadRequestFactory.Clause(""),
      //                  whereClause: collectionLoadRequestFactory.Clause(""))
      //              )
      //              {
      //                  //BEGIN
      //                  #region CRUD LoadToVariable
      //                  var tv_ALTGEN1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
      //                      {
      //                          {_ALTGEN_SpName,"[SpName]"},
      //                      },
      //                      loadForChange: false,
      //                  lockingType: LockingType.None,
      //                      maximumRows: 1,
      //                      tableName: "#tv_ALTGEN",
      //                      fromClause: collectionLoadRequestFactory.Clause(""),
      //                      whereClause: collectionLoadRequestFactory.Clause(""),
      //                      orderByClause: collectionLoadRequestFactory.Clause(""));
      //                  var tv_ALTGEN1LoadResponse = this.appDB.Load(tv_ALTGEN1LoadRequest);
      //                  if (tv_ALTGEN1LoadResponse.Items.Count > 0)
      //                  {
      //                      ALTGEN_SpName = _ALTGEN_SpName;
      //                  }
      //                  #endregion  LoadToVariable

      //                  var ALTGEN = AltExtGen_Rpt_AccountsReceivableAgingSp(ALTGEN_SpName,
      //                      AgingDate,
      //                      CutoffDate,
      //                      AgingDateOffset,
      //                      CutoffDateOffset,
      //                      StateCycle,
      //                      ShowActive,
      //                      BegSlsman,
      //                      EndSlsman,
      //                      CustomerStarting,
      //                      CustomerEnding,
      //                      NameStarting,
      //                      NameEnding,
      //                      CurCodeStarting,
      //                      CurCodeEnding,
      //                      PrZeroBal,
      //                      CreditHold,
      //                      PrCreditBal,
      //                      SumToCorp,
      //                      TransDomCurr,
      //                      UseHistRate,
      //                      PrOpenItem,
      //                      PrOpenPay,
      //                      HidePaid,
      //                      SortByCurr,
      //                      ArSortBy,
      //                      AgeBuckets,
      //                      InvDue,
      //                      AgeDays1,
      //                      AgeDesc1,
      //                      AgeDays2,
      //                      AgeDesc2,
      //                      AgeDays3,
      //                      AgeDesc3,
      //                      AgeDays4,
      //                      AgeDesc4,
      //                      AgeDays5,
      //                      AgeDesc5,
      //                      SiteGroup,
      //                      DisplayHeader,
      //                      ConsolidateCustomers,
      //                      IncludeEstCurrGainLossAmtsInTotals,
      //                      pSite);
      //                  ALTGEN_Severity = ALTGEN.ReturnCode;

      //                  if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
      //                  {
      //                      return (ALTGEN.Data, ALTGEN_Severity);
      //                  }
      //                  this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
      //                  /*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
      //                  #region CRUD LoadToRecord
      //                  var tv_ALTGEN2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
      //                      {
      //                          {"[SpName]","[SpName]"},
      //                      },
      //                      loadForChange: false,
      //                      lockingType: LockingType.None,
      //                      tableName: "#tv_ALTGEN",
      //                      fromClause: collectionLoadRequestFactory.Clause(""),
      //                      whereClause: collectionLoadRequestFactory.Clause("[SpName] = {0}", ALTGEN_SpName),
      //                      orderByClause: collectionLoadRequestFactory.Clause(""));
      //                  var tv_ALTGEN2LoadResponse = this.appDB.Load(tv_ALTGEN2LoadRequest);
      //                  #endregion  LoadToRecord

      //                  #region CRUD DeleteByRecord
      //                  var tv_ALTGEN2DeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "#tv_ALTGEN",
      //                      items: tv_ALTGEN2LoadResponse.Items);
      //                  this.appDB.Delete(tv_ALTGEN2DeleteRequest);
      //                  #endregion DeleteByRecord

      //                  this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
      //                  //END
      //              }
      //              //END
      //              LogTiming("ALTGEN");
      //          }
      //          if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Rpt_AccountsReceivableAgingSp") != null)
      //          {
      //              var EXTGEN = AltExtGen_Rpt_AccountsReceivableAgingSp("dbo.EXTGEN_Rpt_AccountsReceivableAgingSp",
      //                  AgingDate,
      //                  CutoffDate,
      //                  AgingDateOffset,
      //                  CutoffDateOffset,
      //                  StateCycle,
      //                  ShowActive,
      //                  BegSlsman,
      //                  EndSlsman,
      //                  CustomerStarting,
      //                  CustomerEnding,
      //                  NameStarting,
      //                  NameEnding,
      //                  CurCodeStarting,
      //                  CurCodeEnding,
      //                  PrZeroBal,
      //                  CreditHold,
      //                  PrCreditBal,
      //                  SumToCorp,
      //                  TransDomCurr,
      //                  UseHistRate,
      //                  PrOpenItem,
      //                  PrOpenPay,
      //                  HidePaid,
      //                  SortByCurr,
      //                  ArSortBy,
      //                  AgeBuckets,
      //                  InvDue,
      //                  AgeDays1,
      //                  AgeDesc1,
      //                  AgeDays2,
      //                  AgeDesc2,
      //                  AgeDays3,
      //                  AgeDesc3,
      //                  AgeDays4,
      //                  AgeDesc4,
      //                  AgeDays5,
      //                  AgeDesc5,
      //                  SiteGroup,
      //                  DisplayHeader,
      //                  ConsolidateCustomers,
      //                  IncludeEstCurrGainLossAmtsInTotals,
      //                  pSite);
      //              int? EXTGEN_Severity = EXTGEN.ReturnCode;

      //              if (EXTGEN_Severity != 1)
      //              {
      //                  //File.AppendAllText(@"C:\logs\araging\ArAgingLog.txt", "ExtGen Ending: " + DateTime.Now.ToLongTimeString() + " - " + EXTGEN.Data.Items.Count.ToString() + " - " + "\r\n");
      //                  return (EXTGEN.Data, EXTGEN_Severity);
      //              }
      //              LogTiming("EXTGEN");
      //          }
      //          #endregion                


      //          this.sQLExpressionExecutor.Execute("SET XACT_ABORT ON");
      //          try
      //          {
      //              if (sessionId != null && loadType == LoadType.Next)
      //              {
      //                  resultBookmark = mgSessionVariableBasedCache.Get<Bookmark>("Bookmark");
      //              }
      //              else
      //              {
      //                  LowChar = convertToUtil.ToString(this.lowCharacter.LowCharacterFn());
      //                  HighChar = convertToUtil.ToString(this.highCharacter.HighCharacterFn());
      //                  if (AgingDate != null)
      //                  {
      //                      #region CRUD ExecuteMethodCall
      //                      //Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
      //                      var ApplyDateOffset = this.iApplyDateOffset.ApplyDateOffsetSp(
      //                          Date: AgingDate,
      //                          Offset: AgingDateOffset,
      //                          IsEndDate: null);
      //                      AgingDate = ApplyDateOffset.Date;
      //                      #endregion ExecuteMethodCall
      //                      LogTiming("ApplyDateOffset");
      //                  }
      //                  if (CutoffDate != null)
      //                  {
      //                      #region CRUD ExecuteMethodCall
      //                      //Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
      //                      var ApplyDateOffset1 = this.iApplyDateOffset.ApplyDateOffsetSp(
      //                          Date: CutoffDate,
      //                          Offset: CutoffDateOffset,
      //                          IsEndDate: null);
      //                      CutoffDate = ApplyDateOffset1.Date;
      //                      #endregion ExecuteMethodCall
      //                      LogTiming("ApplyDateOffset1");
      //                  }
      //                  AgingDate = convertToUtil.ToDateTime(dateTimeUtil.DateAdd("Millisecond", -10, dateTimeUtil.DateAdd("Day", 1, this.iMidnightOf.MidnightOfFn(AgingDate))));
      //                  CutoffDate = convertToUtil.ToDateTime(dateTimeUtil.DateAdd("Millisecond", -10, dateTimeUtil.DateAdd("Day", 1, this.iMidnightOf.MidnightOfFn(CutoffDate))));
      //                  ShowActive = (int?)(stringUtil.IsNull(
      //                      ShowActive,
      //                      1));
      //                  BegSlsman = stringUtil.IsNull(
      //                      BegSlsman,
      //                      LowChar);
      //                  EndSlsman = stringUtil.IsNull(
      //                      EndSlsman,
      //                      HighChar);
      //                  CustomerStarting = stringUtil.IsNull(
      //                      this.iExpandKyByType.ExpandKyByTypeFn(
      //                          "CustNumType",
      //                          CustomerStarting),
      //                      LowChar);
      //                  CustomerEnding = stringUtil.IsNull(
      //                      this.iExpandKyByType.ExpandKyByTypeFn(
      //                          "CustNumType",
      //                          CustomerEnding),
      //                      HighChar);
      //                  NameStarting = stringUtil.IsNull(
      //                      NameStarting,
      //                      LowChar);
      //                  NameEnding = stringUtil.IsNull(
      //                      NameEnding,
      //                      HighChar);
      //                  CurCodeStarting = stringUtil.IsNull(
      //                      CurCodeStarting,
      //                      LowChar);
      //                  CurCodeEnding = stringUtil.IsNull(
      //                      CurCodeEnding,
      //                      HighChar);
      //                  PrZeroBal = (int?)(stringUtil.IsNull(
      //                      PrZeroBal,
      //                      0));
      //                  CreditHold = stringUtil.IsNull(
      //                      CreditHold,
      //                      "");
      //                  PrCreditBal = (int?)(stringUtil.IsNull(
      //                      PrCreditBal,
      //                      0));
      //                  SumToCorp = (int?)(stringUtil.IsNull(
      //                      SumToCorp,
      //                      0));
      //                  TransDomCurr = (int?)(stringUtil.IsNull(
      //                      TransDomCurr,
      //                      1));
      //                  UseHistRate = (int?)(stringUtil.IsNull(
      //                      UseHistRate,
      //                      1));
      //                  PrOpenItem = stringUtil.IsNull(
      //                      PrOpenItem,
      //                      "D");
      //                  PrOpenPay = (int?)(stringUtil.IsNull(
      //                      PrOpenPay,
      //                      1));
      //                  HidePaid = (int?)(stringUtil.IsNull(
      //                      HidePaid,
      //                      60));
      //                  SortByCurr = (int?)(stringUtil.IsNull(
      //                      SortByCurr,
      //                      0));
      //                  ArSortBy = stringUtil.IsNull(
      //                      ArSortBy,
      //                      "B");
      //                  ConsolidateCustomers = (int?)(stringUtil.IsNull(
      //                      ConsolidateCustomers,
      //                      0));
      //                  AgeBuckets = stringUtil.IsNull(
      //                      AgeBuckets,
      //                      "12345");
      //                  AgeDays1 = (int?)(stringUtil.IsNull(
      //                      AgeDays1,
      //                      0));
      //                  AgeDays2 = (int?)(stringUtil.IsNull(
      //                      AgeDays2,
      //                      0));
      //                  AgeDays3 = (int?)(stringUtil.IsNull(
      //                      AgeDays3,
      //                      0));
      //                  AgeDays4 = (int?)(stringUtil.IsNull(
      //                      AgeDays4,
      //                      0));
      //                  AgeDays5 = (int?)(stringUtil.IsNull(
      //                      AgeDays5,
      //                      0));
      //                  StateCycle = (sQLUtil.SQLEqual(StateCycle, "A") == true ? null : StateCycle);
      //                  IncludeEstCurrGainLossAmtsInTotals = (int?)(stringUtil.IsNull(
      //                      IncludeEstCurrGainLossAmtsInTotals,
      //                      0));
      //                  ProcessID = Guid.NewGuid();

      //                  string SQL = string.Empty;
      //                  SQL = stringUtil.Concat(@"
						//INSERT INTO tmp_artran_all (
						//  ProcessID
						//, RowPointer
						//, active
						//, exch_rate
						//, fixed_rate
						//, amount
						//, misc_charges
						//, sales_tax
						//, sales_tax_2
						//, freight
						//, inv_num
						//, apply_to_inv_num
						//, description
						//, due_date
						//, inv_date
						//, type
						//, inv_seq
						//, check_seq
						//, cust_num
						//, site_ref
						//, multi_due_date
						//, approval_status
						//, OrigAmount
						//, curr_code
						//, TH_payment_number
						//) SELECT
						//'", Convert.ToString(ProcessID), @"'
						//, artran.RowPointer
						//, active
						//, exch_rate
						//, fixed_rate
						//, amount
						//, misc_charges
						//, sales_tax
						//, sales_tax_2
						//, freight
						//, inv_num
						//, apply_to_inv_num
						//, description
						//, due_date
						//, inv_date
						//, type
						//, inv_seq
						//, check_seq
						//, cust_num
						//, site_ref
						//, 0
						//, approval_status
						//, amount
						//, curr_code
						//, TH_payment_number
						//FROM artran_all artran
						//");
      //                  if (SiteGroup != null)
      //                  {
      //                      SQL = stringUtil.Concat(SQL, @"
						//	INNER JOIN site_group ON
						//	site_group.site = artran.site_ref
						//	");
      //                  }
      //                  SQL = stringUtil.Concat(SQL, @"WHERE 1=1
						//");
      //                  if (SiteGroup != null)
      //                  {
      //                      SQL = stringUtil.Concat(SQL, "And site_group.site_group = '", SiteGroup, @"'
						//	");
      //                  }
      //                  if (CutoffDate != null)
      //                  {
      //                      SQL = stringUtil.Concat(SQL, "AND artran.inv_date <= '", Convert.ToString(CutoffDate), @"'
						//	");
      //                  }
      //                  if (sQLUtil.SQLNotEqual(stringUtil.IsNull(
      //                          PrOpenPay,
      //                          1), 1) == true)
      //                  {
      //                      SQL = stringUtil.Concat(SQL, @"AND (artran.type <> 'P' OR artran.apply_to_inv_num <> '0')
						//	");
      //                  }
      //                  if (sQLUtil.SQLEqual(stringUtil.IsNull(
      //                          ShowActive,
      //                          1), 1) == true)
      //                  {
      //                      SQL = stringUtil.Concat(SQL, @"AND artran.active = 1
						//	");
      //                  }
      //                  SQL = stringUtil.Concat(SQL, this.iAndSqlWhere.AndSqlWhereFn(
      //                      "artran",
      //                      "cust_num",
      //                      1,
      //                      CustomerStarting,
      //                      CustomerEnding));
      //                  SQL = stringUtil.Concat(SQL, @"
						//AND NOT (EXISTS (SELECT 1 FROM  ar_terms_due_all
						//   WHERE ar_terms_due_all.site_ref =artran.site_ref  and artran.cust_num = ar_terms_due_all.cust_num and
						//  ar_terms_due_all.inv_num =artran.inv_num and ar_terms_due_all.inv_seq = artran.inv_seq) and CHARINDEX( artran.type, 'ID') <> 0)
						//");

      //                  var execResult = sQLCollectionLoad.ExecuteDynamicQuery(SQL, "");

      //                  LogTiming("INSERT into tmp_artran_all");

      //                  this.sQLExpressionExecutor.Execute("UPDATE STATISTICS tmp_artran_all");

      //                  #region CRUD LoadToVariable
      //                  var arparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
      //                  {
      //                      {_InvDue,$"ISNULL({variableUtil.GetQuotedValue<string>(InvDue)}, inv_due)"},
      //                  },
      //                      loadForChange: false,
      //                  lockingType: LockingType.None,
      //                      tableName: "arparms",
      //                      fromClause: collectionLoadRequestFactory.Clause(""),
      //                      whereClause: collectionLoadRequestFactory.Clause(""),
      //                      orderByClause: collectionLoadRequestFactory.Clause(""));
      //                  var arparmsLoadResponse = this.appDB.Load(arparmsLoadRequest);
      //                  if (arparmsLoadResponse.Items.Count > 0)
      //                  {
      //                      InvDue = _InvDue;
      //                  }
      //                  #endregion  LoadToVariable
      //                  LogTiming("LOAD TO VAR arparms");

      //                  #region CRUD LoadToVariable
      //                  var parmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
      //                  {
      //                      {_SiteGroup,$"ISNULL({variableUtil.GetQuotedValue<string>(SiteGroup)}, site_group)"},
      //                      {_ParmsSite,"site"},
      //                  },
      //                      loadForChange: false,
      //                      lockingType: LockingType.None,
      //                      tableName: "parms",
      //                      fromClause: collectionLoadRequestFactory.Clause(""),
      //                      whereClause: collectionLoadRequestFactory.Clause(""),
      //                      orderByClause: collectionLoadRequestFactory.Clause(""));
      //                  var parmsLoadResponse = this.appDB.Load(parmsLoadRequest);
      //                  if (parmsLoadResponse.Items.Count > 0)
      //                  {
      //                      SiteGroup = _SiteGroup;
      //                      ParmsSite = _ParmsSite;
      //                  }
      //                  #endregion  LoadToVariable
      //                  LogTiming("LOAD TO VAR parms");

      //                  Severity = 0;
      //                  TGrand = 0;
      //                  FirstOfCustomer = 0;
      //                  AnyTrans = 0;
      //                  SomeTrans = 0;
      //                  TUseHistRate = 0;
      //                  if (this.scalarFunction.Execute<int?>(
      //                      "OBJECT_ID",
      //                      "tempdb..#artranc") == null)
      //                  {
      //                      //BEGIN
      //                      this.sQLExpressionExecutor.Execute(@"CREATE TABLE #artranc (
						//	    CustNum  NVARCHAR (7)    COLLATE DATABASE_DEFAULT,
						//	    InvNum   NVARCHAR (12)   COLLATE DATABASE_DEFAULT,
						//	    InvSeq   INT            ,
						//	    CheckSeq INT            ,
						//	    ExchRate DECIMAL (12, 7),
						//	    GainLoss DECIMAL (21, 8)
						//	)");
      //                      this.sQLExpressionExecutor.Execute(@"CREATE INDEX #artranc_2
						//	    ON #artranc(CustNum, InvNum, InvSeq, CheckSeq)");
      //                      //END
      //                  }
      //                  TGrand = 1;
      //                  TUseHistRate = UseHistRate;
      //                  if (this.scalarFunction.Execute<int?>(
      //                      "OBJECT_ID",
      //                      "tempdb..#AccountsReceivableAging") == null)
      //                  {
      //                      //BEGIN
      //                      this.sQLExpressionExecutor.Execute(@"Declare
						//	@TcSortCurrCode CurrCodeType
						//	,@CurrencyFormat InputMaskType
						//	,@CurrencyPlaces DecimalPlacesType
						//	,@TotCurrencyFormat InputMaskType
						//	,@TotCurrencyPlaces DecimalPlacesType
						//	,@TcSortBy NameType
						//	,@TcCustNum CustNumType
						//	,@TcCustName NameType
						//	,@TcCity CityType
						//	,@TcState StateType
						//	,@TcSite SiteType
						//	,@TcSiteName NameType
						//	,@TcContact ContactType
						//	,@TcPhone PhoneType
						//	,@TcTempTermsCode DescriptionType
						//	,@TcCustType CustTypeType
						//	,@TcCreditLimit AmountType
						//	,@TcCredhold InfoBarType
						//	,@TcCurrCode CurrCodeType
						//	,@TcArtranType ArtranTypeType
						//	,@StdCh NVARCHAR (50)
						//	,@TcArtranInvSeq INT
						//	,@TcArtranDate CurrentDateType
						//	,@TcArtranDueDate DateType
						//	,@TcAmtTran AmountType
						//	,@TcArtranExchRate ExchRateType
						//	,@TcArtranCurrCode CurrCodeType
						//	,@TcAmtTemp AmountType
						//	,@PAgeDesc AgeDescType
						//	,@PAgeDescNum GenericNoType
						//	,@TcApprovalStatus ListPendingApprovedRejectedType
						//	,@StdCh1 NVARCHAR (50)
						//	,@TcCustCurrCode CurrCodeType
						//	,@OrderByDate DateType
						//	,@ApplyToInv InvNumType
						//	,@TcArTranIvDate DateType
						//	,@TcArTranChkSeq ArCheckNumType
						//	,@InvNum InvNumType
						//	,@TotalDays INT
						//	,@THPaymentNumber PaymentNumberType
						//	SELECT @TcSortCurrCode AS TcSortCurrCode,
						//	       @CurrencyFormat AS CurrencyFormat,
						//	       @CurrencyPlaces AS CurrencyPlaces,
						//	       @TotCurrencyFormat AS TotCurrencyFormat,
						//	       @TotCurrencyPlaces AS TotCurrencyPlaces,
						//	       @TcSortBy AS TcSortBy,
						//	       @TcCustNum AS TcCustNum,
						//	       @TcCustName AS TcCustName,
						//	       @TcCity AS TcCity,
						//	       @TcState AS TcState,
						//	       @TcSite AS TcSite,
						//	       @TcSiteName AS TcSiteName,
						//	       @TcContact AS TcContact,
						//	       @TcPhone AS TcPhone,
						//	       @TcTempTermsCode AS TcTempTermsCode,
						//	       @TcCustType AS TcCustType,
						//	       @TcCreditLimit AS TcCreditLimit,
						//	       @TcCredhold AS TcCredhold,
						//	       @TcCurrCode AS TcCurrCode,
						//	       @TcArtranType AS TcArtranType,
						//	       @StdCh AS StdCh,
						//	       @TcArtranInvSeq AS TcArtranInvSeq,
						//	       @TcArtranDate AS TcArtranDate,
						//	       @TcArtranDueDate AS TcArtranDueDate,
						//	       @TcAmtTran AS TcAmtTran,
						//	       @TcArtranExchRate AS TcArtranExchRate,
						//	       @TcArtranCurrCode AS TcArtranCurrCode,
						//	       @TcAmtTran AS CustAmtTran,
						//	       @TcAmtTemp AS TcAmtTemp,
						//	       @PAgeDesc AS PAgeDesc,
						//	       @PAgeDescNum AS PAgeDescNum,
						//	       @TcApprovalStatus AS TcApprovalStatus,
						//	       @StdCh1 AS StdCh1,
						//	       @TcCustCurrCode AS TcCustCurrCode,
						//	       @OrderByDate AS OrderByDate,
						//	       @ApplyToInv AS ApplyToInv,
						//	       @TcArTranIvDate AS TcArTranIvDate,
						//	       @TcArTranChkSeq AS TcArTranChkSeq,
						//	       @InvNum AS InvNum,
						//	       @TotalDays AS TotalDays,
						//	       @THPaymentNumber AS THPaymentNumber
						//	INTO   #AccountsReceivableAging
						//	WHERE  1 = 2");
      //                      this.sQLExpressionExecutor.Execute(@"ALTER TABLE #AccountsReceivableAging
						//	    ADD seq INT IDENTITY");
      //                      this.sQLExpressionExecutor.Execute(@"CREATE INDEX ix1_seq
						//	    ON #AccountsReceivableAging(seq)");
      //                      this.sQLExpressionExecutor.Execute(@"ALTER TABLE #AccountsReceivableAging
						//	    ADD PRIMARY KEY (seq)");
      //                      this.sQLExpressionExecutor.Execute(@"CREATE INDEX ix1_TcCurrCode
						//	    ON #AccountsReceivableAging(TcCurrCode)");
      //                      this.sQLExpressionExecutor.Execute(@"CREATE INDEX ix1_ApplyToInv
						//	    ON #AccountsReceivableAging(ApplyToInv)");
      //                      this.sQLExpressionExecutor.Execute(@"CREATE INDEX ix1_InvNum_TotalDays
						//	    ON #AccountsReceivableAging(InvNum, TotalDays)");
      //                      //END
      //                  }

      //                  this.sQLExpressionExecutor.Execute("DELETE #AccountsReceivableAging");

      //                  TcTotBal = 0;
      //                  ParmsCurrCode = null;

      //                  #region CRUD LoadToVariable
      //                  var currparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
      //                  {
      //                      {_ParmsCurrCode,"curr_code"},
      //                  },
      //                      loadForChange: false,
      //                  lockingType: LockingType.None,
      //                      tableName: "currparms",
      //                      fromClause: collectionLoadRequestFactory.Clause(""),
      //                      whereClause: collectionLoadRequestFactory.Clause(""),
      //                      orderByClause: collectionLoadRequestFactory.Clause(""));
      //                  var currparmsLoadResponse = this.appDB.Load(currparmsLoadRequest);
      //                  if (currparmsLoadResponse.Items.Count > 0)
      //                  {
      //                      ParmsCurrCode = _ParmsCurrCode;
      //                  }
      //                  #endregion  LoadToVariable
      //                  LogTiming("LOAD TO VAR currparms");

      //                  if (sQLUtil.SQLEqual(ConsolidateCustomers, 0) == true)
      //                  {
      //                      //BEGIN
      //                      SiteGroupSite = null;

      //                      #region CRUD LoadToVariable
      //                      var site_groupLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
      //                      {
      //                          {_SiteGroupSite,"site_group.site"},
      //                      },
      //                          loadForChange: false,
      //                  lockingType: LockingType.None,
      //                          tableName: "site_group",
      //                          fromClause: collectionLoadRequestFactory.Clause(""),
      //                          whereClause: collectionLoadRequestFactory.Clause("site_group.site_group = {0}", SiteGroup),
      //                          orderByClause: collectionLoadRequestFactory.Clause(""));
      //                      var site_groupLoadResponse = this.appDB.Load(site_groupLoadRequest);
      //                      if (site_groupLoadResponse.Items.Count > 0)
      //                      {
      //                          SiteGroupSite = _SiteGroupSite;
      //                      }
      //                      #endregion  LoadToVariable
      //                      LogTiming("LOAD TO VAR site_group");
      //                      //END
      //                  }
      //                  if (sQLUtil.SQLEqual(SortByCurr, 0) == true)
      //                  {
      //                      //BEGIN
      //                      if (sQLUtil.SQLEqual(ConsolidateCustomers, 1) == true)
      //                      {
      //                          //BEGIN
      //                          #region CRUD LoadToRecord
      //                          curCustAddrLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
      //                          {
      //                              {"custaddr.cust_num","custaddr.cust_num"},
      //                              {"custaddr.curr_code","custaddr.curr_code"},
      //                          },
      //                              loadForChange: false,
      //                  lockingType: LockingType.None,
      //                              tableName: "custaddr",
      //                              fromClause: collectionLoadRequestFactory.Clause(""),
      //                              whereClause: collectionLoadRequestFactory.Clause("custaddr.cust_num BETWEEN {0} AND {2} AND (ISNULL(custaddr.name, {6}) BETWEEN {4} AND {5}) AND custaddr.cust_seq = 0 AND (custaddr.curr_code BETWEEN {1} AND {3})", CustomerStarting, CurCodeStarting, CustomerEnding, CurCodeEnding, NameStarting, NameEnding, LowChar),
      //                              orderByClause: collectionLoadRequestFactory.Clause(" CASE WHEN {0} = 'A' THEN custaddr.name ELSE custaddr.cust_num END", ArSortBy));
      //                          #endregion  LoadToRecord
                               
      //                          curCustAddrLoadResponseForCursor = this.appDB.Load(curCustAddrLoadRequestForCursor);
      //                          curCustAddr_CursorFetch_Status = curCustAddrLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
      //                          curCustAddr_CursorCounter = -1;

      //                          LogTiming($"LOAD TO RECORD for cursor - custaddr ({curCustAddrLoadResponseForCursor.Items.Count})");

      //                          while (sQLUtil.SQLEqual(Severity, 0) == true)
      //                          {
      //                              //BEGIN
      //                              curCustAddr_CursorCounter++;
      //                              if (curCustAddrLoadResponseForCursor.Items.Count > curCustAddr_CursorCounter)
      //                              {
      //                                  CustaddrCustNum = curCustAddrLoadResponseForCursor.Items[curCustAddr_CursorCounter].GetValue<string>(0);
      //                                  CustaddrCurrCode = curCustAddrLoadResponseForCursor.Items[curCustAddr_CursorCounter].GetValue<string>(1);
      //                              }
      //                              curCustAddr_CursorFetch_Status = (curCustAddr_CursorCounter == curCustAddrLoadResponseForCursor.Items.Count ? -1 : 0);

      //                              if (sQLUtil.SQLEqual(curCustAddr_CursorFetch_Status, -1) == true)
      //                              {
      //                                  break;
      //                              }
      //                              FirstOfCustomer = 1;
      //                              TcTotMajorBal = 0;
      //                              AnyTrans = 0;

      //                              #region CRUD LoadToRecord
      //                              curSiteGroupLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
      //                              {
      //                                  {"site_group.site","site_group.site"},
      //                              },
      //                                  loadForChange: false,
      //                  lockingType: LockingType.None,
      //                                  tableName: "site_group",
      //                                  fromClause: collectionLoadRequestFactory.Clause(""),
      //                                  whereClause: collectionLoadRequestFactory.Clause("site_group.site_group = {0}", SiteGroup),
      //                                  orderByClause: collectionLoadRequestFactory.Clause(""));
      //                              #endregion  LoadToRecord

      //                              curSiteGroupLoadResponseForCursor = this.appDB.Load(curSiteGroupLoadRequestForCursor);
      //                              curSiteGroup_CursorFetch_Status = curSiteGroupLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
      //                              curSiteGroup_CursorCounter = -1;

      //                              LogTiming($"LOAD TO RECORD for cursor - site_group  ({curSiteGroupLoadResponseForCursor.Items.Count})");

      //                              while (sQLUtil.SQLEqual(Severity, 0) == true)
      //                              {
      //                                  //BEGIN
      //                                  curSiteGroup_CursorCounter++;
      //                                  if (curSiteGroupLoadResponseForCursor.Items.Count > curSiteGroup_CursorCounter)
      //                                  {
      //                                      SiteGroupSite = curSiteGroupLoadResponseForCursor.Items[curSiteGroup_CursorCounter].GetValue<string>(0);
      //                                  }
      //                                  curSiteGroup_CursorFetch_Status = (curSiteGroup_CursorCounter == curSiteGroupLoadResponseForCursor.Items.Count ? -1 : 0);

      //                                  if (sQLUtil.SQLEqual(curSiteGroup_CursorFetch_Status, -1) == true)
      //                                  {
      //                                      break;
      //                                  }
      //                                  TranslateForAging = TransDomCurr;

      //                                  #region CRUD ExecuteMethodCall

      //                                  //Please Generate the bounce for this stored procedure: AgingSp
      //                                  var Aging = this.iAging.AgingSp(
      //                                      ConsolidateCustomers: ConsolidateCustomers,
      //                                      PSite: SiteGroupSite,
      //                                      PPrOpenItem: PrOpenItem,
      //                                      PAgingDate: AgingDate,
      //                                      PSumToCorp: SumToCorp,
      //                                      PSSlsman: BegSlsman,
      //                                      PESlsman: EndSlsman,
      //                                      PStateCycle: StateCycle,
      //                                      PCreditHold: CreditHold,
      //                                      PShowActive: ShowActive,
      //                                      PPrZeroBal: PrZeroBal,
      //                                      PPrCreditBal: PrCreditBal,
      //                                      PSortByCurr: SortByCurr,
      //                                      PPrOpenPay: PrOpenPay,
      //                                      PCutoffDate: CutoffDate,
      //                                      PInvDue: InvDue,
      //                                      PAgeDays1: AgeDays1,
      //                                      PAgeDays2: AgeDays2,
      //                                      PAgeDays3: AgeDays3,
      //                                      PAgeDays4: AgeDays4,
      //                                      PAgeDays5: AgeDays5,
      //                                      PHidePaid: HidePaid,
      //                                      PAgeBucket: AgeBuckets,
      //                                      TGrand: TGrand,
      //                                      FirstOfCustomer: FirstOfCustomer,
      //                                      UseHistRate: TUseHistRate,
      //                                      TranslateForAging: TranslateForAging,
      //                                      SiteLabel: null,
      //                                      TTransDom: null,
      //                                      CurCustNum: CustaddrCustNum,
      //                                      AnyTrans: SomeTrans,
      //                                      PAgeDesc1: AgeDesc1,
      //                                      PAgeDesc2: AgeDesc2,
      //                                      PAgeDesc3: AgeDesc3,
      //                                      PAgeDesc4: AgeDesc4,
      //                                      PAgeDesc5: AgeDesc5,
      //                                      PArSortBy: ArSortBy,
      //                                      ProcessID: ProcessID,
      //                                      IncludeEstCurrGainLossAmtsInTotals: IncludeEstCurrGainLossAmtsInTotals);
      //                                  TGrand = Aging.TGrand;
      //                                  FirstOfCustomer = Aging.FirstOfCustomer;
      //                                  TUseHistRate = Aging.UseHistRate;
      //                                  TranslateForAging = Aging.TranslateForAging;
      //                                  SomeTrans = Aging.AnyTrans;

      //                                  #endregion ExecuteMethodCall

      //                                  LogTiming($"AGING SP METHOD CALL");

      //                                  AnyTrans = (int?)((int)(AnyTrans) | (int)(SomeTrans));
      //                                  //END
      //                              }
      //                              curSiteGroupLoadResponseForCursor = null;
      //                              //Deallocate Cursor @curSiteGroup
      //                              TcTotBal = (decimal?)(TcTotBal + TcTotMajorBal);
      //                              //END

      //                          }
      //                          curCustAddrLoadResponseForCursor = null;
      //                          //Deallocate Cursor @curCustAddr
      //                          //END
      //                      }
      //                      else
      //                      {
      //                          //BEGIN
      //                          #region CRUD LoadToRecord
      //                          curSiteGroupLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
      //                          {
      //                              {"site_group.site","site_group.site"},
      //                          },
      //                              loadForChange: false,
      //                  lockingType: LockingType.None,
      //                              tableName: "site_group",
      //                              fromClause: collectionLoadRequestFactory.Clause(""),
      //                              whereClause: collectionLoadRequestFactory.Clause("site_group.site_group = {0}", SiteGroup),
      //                              orderByClause: collectionLoadRequestFactory.Clause(""));
      //                          #endregion  LoadToRecord
                               
      //                          curSiteGroupLoadResponseForCursor = this.appDB.Load(curSiteGroupLoadRequestForCursor);
      //                          curSiteGroup_CursorFetch_Status = curSiteGroupLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
      //                          curSiteGroup_CursorCounter = -1;

      //                          LogTiming($"LOAD TO RECORD for cursor - site_group ({curSiteGroupLoadResponseForCursor.Items.Count})");

      //                          while (sQLUtil.SQLEqual(Severity, 0) == true)
      //                          {
      //                              //BEGIN
      //                              curSiteGroup_CursorCounter++;
      //                              if (curSiteGroupLoadResponseForCursor.Items.Count > curSiteGroup_CursorCounter)
      //                              {
      //                                  SiteGroupSite = curSiteGroupLoadResponseForCursor.Items[curSiteGroup_CursorCounter].GetValue<string>(0);
      //                              }
      //                              curSiteGroup_CursorFetch_Status = (curSiteGroup_CursorCounter == curSiteGroupLoadResponseForCursor.Items.Count ? -1 : 0);

      //                              if (sQLUtil.SQLEqual(curSiteGroup_CursorFetch_Status, -1) == true)
      //                              {
      //                                  break;
      //                              }
      //                              TcTotMajorBal = 0;
      //                              if (sQLUtil.SQLEqual(ArSortBy, "A") == true || sQLUtil.SQLEqual(ArSortBy, "B") == true)
      //                              {

      //                                  #region CRUD LoadToRecord
      //                                  curCustAddrLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
      //                                  {
      //                                      {"custaddr.cust_num","custaddr.cust_num"},
      //                                      {"custaddr.curr_code","custaddr.curr_code"},
      //                                  },
      //                                      loadForChange: false,
      //                  lockingType: LockingType.None,
      //                                      tableName: "custaddr",
      //                                      fromClause: collectionLoadRequestFactory.Clause(@" LEFT OUTER JOIN customer_all AS customer ON custaddr.cust_num = customer.cust_num
						//					AND custaddr.cust_seq = customer.cust_seq"),
      //                                      whereClause: collectionLoadRequestFactory.Clause("custaddr.cust_num BETWEEN {0} AND {2} AND ISNULL(custaddr.name, {10}) BETWEEN {5} AND {6} AND custaddr.cust_seq = 0 AND custaddr.curr_code BETWEEN {1} AND {3} AND ISNULL(customer.slsman, {10}) BETWEEN {8} AND {9} AND (CHARINDEX(customer.state_cycle, {7}) <> 0 OR {7} = '' OR {7} IS NULL) AND customer.site_ref = {4}", CustomerStarting, CurCodeStarting, CustomerEnding, CurCodeEnding, SiteGroupSite, NameStarting, NameEnding, StateCycle, BegSlsman, EndSlsman, LowChar, LowChar),
      //                                      orderByClause: collectionLoadRequestFactory.Clause(" CASE WHEN {0} = 'A' THEN custaddr.name WHEN {0} = 'B' THEN custaddr.cust_num END", ArSortBy));
      //                                  #endregion  LoadToRecord
                                     
      //                                  curCustAddrLoadResponseForCursor = this.appDB.Load(curCustAddrLoadRequestForCursor);
      //                                  curCustAddr_CursorFetch_Status = curCustAddrLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
      //                                  curCustAddr_CursorCounter = -1;

      //                                  LogTiming($"LOAD TO RECORD for cursor - custaddr ({curCustAddrLoadResponseForCursor.Items.Count})");
      //                              }
      //                              else
      //                              {
      //                                  #region CRUD LoadToRecord
      //                                  curCustAddrLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
      //                                  {
      //                                      {"custaddr.cust_num","custaddr.cust_num"},
      //                                      {"custaddr.curr_code","custaddr.curr_code"},
      //                                  },
      //                                      loadForChange: false,
      //                  lockingType: LockingType.None,
      //                                      tableName: "custaddr",
      //                                      fromClause: collectionLoadRequestFactory.Clause(@" LEFT OUTER JOIN customer_all AS customer ON custaddr.cust_num = customer.cust_num
						//					AND custaddr.cust_seq = customer.cust_seq"),
      //                                      whereClause: collectionLoadRequestFactory.Clause("custaddr.cust_num BETWEEN {0} AND {2} AND (ISNULL(custaddr.name, {10}) BETWEEN {5} AND {6}) AND custaddr.cust_seq = 0 AND custaddr.curr_code BETWEEN {1} AND {3} AND (ISNULL(customer.slsman, {10}) BETWEEN {8} AND {9}) AND (CHARINDEX(customer.state_cycle, {7}) <> 0 OR {7} = '' OR {7} IS NULL) AND customer.site_ref = {4}", CustomerStarting, CurCodeStarting, CustomerEnding, CurCodeEnding, SiteGroupSite, NameStarting, NameEnding, StateCycle, BegSlsman, EndSlsman, LowChar, LowChar),
      //                                      orderByClause: collectionLoadRequestFactory.Clause(" customer.cust_num, customer.slsman"));
      //                                  #endregion  LoadToRecord

      //                                  curCustAddrLoadResponseForCursor = this.appDB.Load(curCustAddrLoadRequestForCursor);
      //                                  curCustAddr_CursorFetch_Status = curCustAddrLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
      //                                  curCustAddr_CursorCounter = -1;

      //                                  LogTiming($"LOAD TO RECORD for cursor - custaddr ({curCustAddrLoadResponseForCursor.Items.Count})");
      //                              }
      //                              while (sQLUtil.SQLEqual(Severity, 0) == true)
      //                              {
      //                                  //BEGIN
      //                                  curCustAddr_CursorCounter++;
      //                                  if (curCustAddrLoadResponseForCursor.Items.Count > curCustAddr_CursorCounter)
      //                                  {
      //                                      CustaddrCustNum = curCustAddrLoadResponseForCursor.Items[curCustAddr_CursorCounter].GetValue<string>(0);
      //                                      CustaddrCurrCode = curCustAddrLoadResponseForCursor.Items[curCustAddr_CursorCounter].GetValue<string>(1);
      //                                  }
      //                                  curCustAddr_CursorFetch_Status = (curCustAddr_CursorCounter == curCustAddrLoadResponseForCursor.Items.Count ? -1 : 0);

      //                                  if (sQLUtil.SQLEqual(curCustAddr_CursorFetch_Status, -1) == true)
      //                                  {
      //                                      break;
      //                                  }
      //                                  FirstOfCustomer = 1;
      //                                  TranslateForAging = TransDomCurr;

      //                                  #region CRUD ExecuteMethodCall

      //                                  //Please Generate the bounce for this stored procedure: AgingSp
      //                                  var Aging1 = this.iAging.AgingSp(
      //                                      ConsolidateCustomers: ConsolidateCustomers,
      //                                      PSite: SiteGroupSite,
      //                                      PPrOpenItem: PrOpenItem,
      //                                      PAgingDate: AgingDate,
      //                                      PSumToCorp: SumToCorp,
      //                                      PSSlsman: BegSlsman,
      //                                      PESlsman: EndSlsman,
      //                                      PStateCycle: StateCycle,
      //                                      PCreditHold: CreditHold,
      //                                      PShowActive: ShowActive,
      //                                      PPrZeroBal: PrZeroBal,
      //                                      PPrCreditBal: PrCreditBal,
      //                                      PSortByCurr: SortByCurr,
      //                                      PPrOpenPay: PrOpenPay,
      //                                      PCutoffDate: CutoffDate,
      //                                      PInvDue: InvDue,
      //                                      PAgeDays1: AgeDays1,
      //                                      PAgeDays2: AgeDays2,
      //                                      PAgeDays3: AgeDays3,
      //                                      PAgeDays4: AgeDays4,
      //                                      PAgeDays5: AgeDays5,
      //                                      PHidePaid: HidePaid,
      //                                      PAgeBucket: AgeBuckets,
      //                                      TGrand: TGrand,
      //                                      FirstOfCustomer: FirstOfCustomer,
      //                                      UseHistRate: TUseHistRate,
      //                                      TranslateForAging: TranslateForAging,
      //                                      SiteLabel: null,
      //                                      TTransDom: null,
      //                                      CurCustNum: CustaddrCustNum,
      //                                      AnyTrans: AnyTrans,
      //                                      PAgeDesc1: AgeDesc1,
      //                                      PAgeDesc2: AgeDesc2,
      //                                      PAgeDesc3: AgeDesc3,
      //                                      PAgeDesc4: AgeDesc4,
      //                                      PAgeDesc5: AgeDesc5,
      //                                      PArSortBy: ArSortBy,
      //                                      ProcessID: ProcessID,
      //                                      IncludeEstCurrGainLossAmtsInTotals: IncludeEstCurrGainLossAmtsInTotals);
      //                                  TGrand = Aging1.TGrand;
      //                                  FirstOfCustomer = Aging1.FirstOfCustomer;
      //                                  TUseHistRate = Aging1.UseHistRate;
      //                                  TranslateForAging = Aging1.TranslateForAging;
      //                                  AnyTrans = Aging1.AnyTrans;

      //                                  #endregion ExecuteMethodCall
      //                                  LogTiming($"AGING SP METHOD CALL");

      //                                  AnyCurrTrans = (int?)((sQLUtil.SQLEqual(AnyCurrTrans, 0) == true ? AnyTrans : AnyCurrTrans));
      //                                  //END
      //                              }
      //                              curCustAddrLoadResponseForCursor = null;
      //                              //Deallocate Cursor @curCustAddr
      //                              if (sQLUtil.SQLEqual(SortByCurr, 0) == true)
      //                              {
      //                                  //BEGIN
      //                                  TcTotBal = (decimal?)(TcTotBal + TcTotMajorBal);
      //                                  TcTotMajorBal = 0;
      //                                  //END
      //                              }
      //                              //END
      //                          }
      //                          curSiteGroupLoadResponseForCursor = null;
      //                          //Deallocate Cursor @curSiteGroup
      //                          //END
      //                      }
      //                      //END
      //                  }
      //                  else
      //                  {
      //                      //BEGIN
      //                      if (sQLUtil.SQLEqual(ConsolidateCustomers, 1) == true)
      //                      {
      //                          //BEGIN
      //                          #region CRUD LoadToRecord
      //                          curCurrencyLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
      //                          {
      //                              {"currency.curr_code","currency.curr_code"},
      //                              {"custaddr.cust_num","custaddr.cust_num"},
      //                              {"custaddr.curr_code","custaddr.curr_code"},
      //                          },
      //                              loadForChange: false,
      //                  lockingType: LockingType.None,
      //                              tableName: "currency",
      //                              fromClause: collectionLoadRequestFactory.Clause(@" inner join custaddr on custaddr.curr_code = currency.curr_code
						//			and custaddr.cust_seq = 0
						//			and custaddr.cust_num between {0} and {1}
						//			and (isnull(custaddr.name, {4}) between {2} and {3})", CustomerStarting, CustomerEnding, NameStarting, NameEnding, LowChar),
      //                              whereClause: collectionLoadRequestFactory.Clause("currency.curr_code BETWEEN {0} AND {1}", CurCodeStarting, CurCodeEnding),
      //                              orderByClause: collectionLoadRequestFactory.Clause(" CASE WHEN {0} = 'A' THEN custaddr.name ELSE custaddr.cust_num END", ArSortBy));
      //                          #endregion  LoadToRecord
                               
      //                          curCurrencyLoadResponseForCursor = this.appDB.Load(curCurrencyLoadRequestForCursor);
      //                          curCurrency_CursorFetch_Status = curCurrencyLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
      //                          curCurrency_CursorCounter = -1;

      //                          LogTiming($"LOAD TO RECORD for cursor - currency ({curCurrencyLoadResponseForCursor.Items.Count})");

      //                          while (sQLUtil.SQLEqual(Severity, 0) == true)
      //                          {
      //                              //BEGIN
      //                              curCurrency_CursorCounter++;
      //                              if (curCurrencyLoadResponseForCursor.Items.Count > curCurrency_CursorCounter)
      //                              {
      //                                  CurrencyCurrCode = curCurrencyLoadResponseForCursor.Items[curCurrency_CursorCounter].GetValue<string>(0);
      //                                  CustaddrCustNum = curCurrencyLoadResponseForCursor.Items[curCurrency_CursorCounter].GetValue<string>(1);
      //                                  CustaddrCurrCode = curCurrencyLoadResponseForCursor.Items[curCurrency_CursorCounter].GetValue<string>(2);
      //                              }
      //                              curCurrency_CursorFetch_Status = (curCurrency_CursorCounter == curCurrencyLoadResponseForCursor.Items.Count ? -1 : 0);

      //                              if (sQLUtil.SQLEqual(curCurrency_CursorFetch_Status, -1) == true)
      //                              {
      //                                  break;
      //                              }
      //                              FirstOfCustomer = 1;
      //                              TcTotMajorBal = 0;
      //                              AnyTrans = 0;

      //                              #region CRUD LoadToRecord
      //                              curSiteGroupLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
      //                              {
      //                                  {"site_group.site","site_group.site"},
      //                              },
      //                                  loadForChange: false,
      //                  lockingType: LockingType.None,
      //                                  tableName: "site_group",
      //                                  fromClause: collectionLoadRequestFactory.Clause(""),
      //                                  whereClause: collectionLoadRequestFactory.Clause("site_group.site_group = {0}", SiteGroup),
      //                                  orderByClause: collectionLoadRequestFactory.Clause(""));
      //                              #endregion  LoadToRecord

      //                              curSiteGroupLoadResponseForCursor = this.appDB.Load(curSiteGroupLoadRequestForCursor);
      //                              curSiteGroup_CursorFetch_Status = curSiteGroupLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
      //                              curSiteGroup_CursorCounter = -1;

      //                              LogTiming($"LOAD TO RECORD for cursor - site_group ({ curSiteGroupLoadResponseForCursor.Items.Count})");

      //                              while (sQLUtil.SQLEqual(Severity, 0) == true)
      //                              {
      //                                  //BEGIN
      //                                  curSiteGroup_CursorCounter++;
      //                                  if (curSiteGroupLoadResponseForCursor.Items.Count > curSiteGroup_CursorCounter)
      //                                  {
      //                                      SiteGroupSite = curSiteGroupLoadResponseForCursor.Items[curSiteGroup_CursorCounter].GetValue<string>(0);
      //                                  }
      //                                  curSiteGroup_CursorFetch_Status = (curSiteGroup_CursorCounter == curSiteGroupLoadResponseForCursor.Items.Count ? -1 : 0);

      //                                  if (sQLUtil.SQLEqual(curSiteGroup_CursorFetch_Status, -1) == true)
      //                                  {
      //                                      break;
      //                                  }
      //                                  TranslateForAging = TransDomCurr;

      //                                  #region CRUD ExecuteMethodCall

      //                                  //Please Generate the bounce for this stored procedure: AgingSp
      //                                  var Aging2 = this.iAging.AgingSp(
      //                                      ConsolidateCustomers: ConsolidateCustomers,
      //                                      PSite: SiteGroupSite,
      //                                      PPrOpenItem: PrOpenItem,
      //                                      PAgingDate: AgingDate,
      //                                      PSumToCorp: SumToCorp,
      //                                      PSSlsman: BegSlsman,
      //                                      PESlsman: EndSlsman,
      //                                      PStateCycle: StateCycle,
      //                                      PCreditHold: CreditHold,
      //                                      PShowActive: ShowActive,
      //                                      PPrZeroBal: PrZeroBal,
      //                                      PPrCreditBal: PrCreditBal,
      //                                      PSortByCurr: SortByCurr,
      //                                      PPrOpenPay: PrOpenPay,
      //                                      PCutoffDate: CutoffDate,
      //                                      PInvDue: InvDue,
      //                                      PAgeDays1: AgeDays1,
      //                                      PAgeDays2: AgeDays2,
      //                                      PAgeDays3: AgeDays3,
      //                                      PAgeDays4: AgeDays4,
      //                                      PAgeDays5: AgeDays5,
      //                                      PHidePaid: HidePaid,
      //                                      PAgeBucket: AgeBuckets,
      //                                      TGrand: TGrand,
      //                                      FirstOfCustomer: FirstOfCustomer,
      //                                      UseHistRate: TUseHistRate,
      //                                      TranslateForAging: TranslateForAging,
      //                                      SiteLabel: null,
      //                                      TTransDom: null,
      //                                      CurCustNum: CustaddrCustNum,
      //                                      AnyTrans: SomeTrans,
      //                                      PAgeDesc1: AgeDesc1,
      //                                      PAgeDesc2: AgeDesc2,
      //                                      PAgeDesc3: AgeDesc3,
      //                                      PAgeDesc4: AgeDesc4,
      //                                      PAgeDesc5: AgeDesc5,
      //                                      PArSortBy: ArSortBy,
      //                                      ProcessID: ProcessID,
      //                                      IncludeEstCurrGainLossAmtsInTotals: IncludeEstCurrGainLossAmtsInTotals);
      //                                  TGrand = Aging2.TGrand;
      //                                  FirstOfCustomer = Aging2.FirstOfCustomer;
      //                                  TUseHistRate = Aging2.UseHistRate;
      //                                  TranslateForAging = Aging2.TranslateForAging;
      //                                  SomeTrans = Aging2.AnyTrans;

      //                                  #endregion ExecuteMethodCall

      //                                  LogTiming($"AGING SP METHOD CALL");
      //                                  AnyTrans = (int?)((int)(AnyTrans) | (int)(SomeTrans));
      //                                  //END
      //                              }
      //                              curSiteGroupLoadResponseForCursor = null;
      //                              //Deallocate Cursor @curSiteGroup
      //                              TcTotBal = (decimal?)(TcTotBal + TcTotMajorBal);
      //                              //END
      //                          }
      //                          curCurrencyLoadResponseForCursor = null;
      //                          //Deallocate Cursor @curCurrency
      //                          //END
      //                      }
      //                      else
      //                      {
      //                          //BEGIN
      //                          #region CRUD LoadToRecord
      //                          curSiteGroupLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
      //                          {
      //                              {"site_group.site","site_group.site"},
      //                          },
      //                              loadForChange: false,
      //                  lockingType: LockingType.None,
      //                              tableName: "site_group",
      //                              fromClause: collectionLoadRequestFactory.Clause(""),
      //                              whereClause: collectionLoadRequestFactory.Clause("site_group.site_group = {0}", SiteGroup),
      //                              orderByClause: collectionLoadRequestFactory.Clause(""));
      //                          #endregion  LoadToRecord
                                
      //                          curSiteGroupLoadResponseForCursor = this.appDB.Load(curSiteGroupLoadRequestForCursor);
      //                          curSiteGroup_CursorFetch_Status = curSiteGroupLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
      //                          curSiteGroup_CursorCounter = -1;

      //                          LogTiming($"LOAD TO RECORD for cursor - site_group ({ curSiteGroupLoadResponseForCursor.Items.Count})");

      //                          while (sQLUtil.SQLEqual(Severity, 0) == true)
      //                          {
      //                              //BEGIN
      //                              curSiteGroup_CursorCounter++;
      //                              if (curSiteGroupLoadResponseForCursor.Items.Count > curSiteGroup_CursorCounter)
      //                              {
      //                                  SiteGroupSite = curSiteGroupLoadResponseForCursor.Items[curSiteGroup_CursorCounter].GetValue<string>(0);
      //                              }
      //                              curSiteGroup_CursorFetch_Status = (curSiteGroup_CursorCounter == curSiteGroupLoadResponseForCursor.Items.Count ? -1 : 0);

      //                              if (sQLUtil.SQLEqual(curSiteGroup_CursorFetch_Status, -1) == true)
      //                              {
      //                                  break;
      //                              }
      //                              TcTotMajorBal = 0;
      //                              if (sQLUtil.SQLEqual(ArSortBy, "A") == true || sQLUtil.SQLEqual(ArSortBy, "B") == true)
      //                              {
      //                                  #region CRUD LoadToRecord
      //                                  curCustAddrLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
      //                                  {
      //                                      {"currency.curr_code","currency.curr_code"},
      //                                      {"custaddr.cust_num","custaddr.cust_num"},
      //                                      {"custaddr.curr_code","custaddr.curr_code"},
      //                                  },
      //                                      loadForChange: false,
      //                  lockingType: LockingType.None,
      //                                      tableName: "currency",
      //                                      fromClause: collectionLoadRequestFactory.Clause(@" inner join custaddr on custaddr.curr_code = currency.curr_code
						//					and custaddr.cust_seq = 0
						//					and custaddr.cust_num between {0} and {1}
						//					and (isnull(custaddr.name, {7}) between {2} and {3}) left outer join customer_all as customer on custaddr.cust_num = customer.cust_num
						//					and custaddr.cust_seq = customer.cust_seq
						//					and isnull(customer.slsman, {7}) between {5} and {6}
						//					and (charindex(customer.state_cycle, {4}) <> 0
						//						or {4} = ''
						//						or {4} is null)", CustomerStarting, CustomerEnding, NameStarting, NameEnding, StateCycle, BegSlsman, EndSlsman, LowChar),
      //                                      whereClause: collectionLoadRequestFactory.Clause("customer.site_ref = {1} AND currency.curr_code BETWEEN {0} AND {2}", CurCodeStarting, SiteGroupSite, CurCodeEnding),
      //                                      orderByClause: collectionLoadRequestFactory.Clause(" CASE WHEN {0} = 'A' THEN custaddr.name WHEN {0} = 'B' THEN custaddr.cust_num END", ArSortBy));
      //                                  #endregion  LoadToRecord

      //                                  curCustAddrLoadResponseForCursor = this.appDB.Load(curCustAddrLoadRequestForCursor);
      //                                  curCustAddr_CursorFetch_Status = curCustAddrLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
      //                                  curCustAddr_CursorCounter = -1;

      //                                  LogTiming($"LOAD TO RECORD for cursor - currency ({ curCustAddrLoadResponseForCursor.Items.Count})");
      //                              }
      //                              else
      //                              {
      //                                  #region CRUD LoadToRecord
      //                                  curCustAddrLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
      //                                  {
      //                                      {"currency.curr_code","currency.curr_code"},
      //                                      {"custaddr.cust_num","custaddr.cust_num"},
      //                                      {"custaddr.curr_code","custaddr.curr_code"},
      //                                  },
      //                                      loadForChange: false,
      //                  lockingType: LockingType.None,
      //                                      tableName: "currency",
      //                                      fromClause: collectionLoadRequestFactory.Clause(@" inner join custaddr on custaddr.curr_code = currency.curr_code
						//					and custaddr.cust_seq = 0
						//					and custaddr.cust_num between {0} and {1}
						//					and isnull(custaddr.name, {7}) between {2} and {3} left outer join customer_all as customer on custaddr.cust_num = customer.cust_num
						//					and custaddr.cust_seq = customer.cust_seq
						//					and isnull(customer.slsman, {7}) between {5} and {6}
						//					and (charindex(customer.state_cycle, {4}) <> 0
						//						or {4} = ''
						//						or {4} is null)", CustomerStarting, CustomerEnding, NameStarting, NameEnding, StateCycle, BegSlsman, EndSlsman, LowChar),
      //                                      whereClause: collectionLoadRequestFactory.Clause("customer.site_ref = {1} AND currency.curr_code BETWEEN {0} AND {2}", CurCodeStarting, SiteGroupSite, CurCodeEnding),
      //                                      orderByClause: collectionLoadRequestFactory.Clause(" customer.cust_num, customer.slsman"));
      //                                  #endregion  LoadToRecord
                                       
      //                                  curCustAddrLoadResponseForCursor = this.appDB.Load(curCustAddrLoadRequestForCursor);
      //                                  curCustAddr_CursorFetch_Status = curCustAddrLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
      //                                  curCustAddr_CursorCounter = -1;

      //                                  LogTiming($"LOAD TO RECORD for cursor - currency ({ curCustAddrLoadResponseForCursor.Items.Count})");
      //                              }
      //                              while (sQLUtil.SQLEqual(Severity, 0) == true)
      //                              {
      //                                  //BEGIN
      //                                  curCustAddr_CursorCounter++;
      //                                  if (curCustAddrLoadResponseForCursor.Items.Count > curCustAddr_CursorCounter)
      //                                  {
      //                                      CurrencyCurrCode = curCustAddrLoadResponseForCursor.Items[curCustAddr_CursorCounter].GetValue<string>(0);
      //                                      CustaddrCustNum = curCustAddrLoadResponseForCursor.Items[curCustAddr_CursorCounter].GetValue<string>(1);
      //                                      CustaddrCurrCode = curCustAddrLoadResponseForCursor.Items[curCustAddr_CursorCounter].GetValue<string>(2);
      //                                  }
      //                                  curCustAddr_CursorFetch_Status = (curCustAddr_CursorCounter == curCustAddrLoadResponseForCursor.Items.Count ? -1 : 0);

      //                                  if (sQLUtil.SQLEqual(curCustAddr_CursorFetch_Status, -1) == true)
      //                                  {
      //                                      break;
      //                                  }
      //                                  FirstOfCustomer = 1;
      //                                  TranslateForAging = TransDomCurr;

      //                                  #region CRUD ExecuteMethodCall

      //                                  //Please Generate the bounce for this stored procedure: AgingSp
      //                                  var Aging3 = this.iAging.AgingSp(
      //                                      ConsolidateCustomers: ConsolidateCustomers,
      //                                      PSite: SiteGroupSite,
      //                                      PPrOpenItem: PrOpenItem,
      //                                      PAgingDate: AgingDate,
      //                                      PSumToCorp: SumToCorp,
      //                                      PSSlsman: BegSlsman,
      //                                      PESlsman: EndSlsman,
      //                                      PStateCycle: StateCycle,
      //                                      PCreditHold: CreditHold,
      //                                      PShowActive: ShowActive,
      //                                      PPrZeroBal: PrZeroBal,
      //                                      PPrCreditBal: PrCreditBal,
      //                                      PSortByCurr: SortByCurr,
      //                                      PPrOpenPay: PrOpenPay,
      //                                      PCutoffDate: CutoffDate,
      //                                      PInvDue: InvDue,
      //                                      PAgeDays1: AgeDays1,
      //                                      PAgeDays2: AgeDays2,
      //                                      PAgeDays3: AgeDays3,
      //                                      PAgeDays4: AgeDays4,
      //                                      PAgeDays5: AgeDays5,
      //                                      PHidePaid: HidePaid,
      //                                      PAgeBucket: AgeBuckets,
      //                                      TGrand: TGrand,
      //                                      FirstOfCustomer: FirstOfCustomer,
      //                                      UseHistRate: TUseHistRate,
      //                                      TranslateForAging: TranslateForAging,
      //                                      SiteLabel: null,
      //                                      TTransDom: null,
      //                                      CurCustNum: CustaddrCustNum,
      //                                      AnyTrans: AnyTrans,
      //                                      PAgeDesc1: AgeDesc1,
      //                                      PAgeDesc2: AgeDesc2,
      //                                      PAgeDesc3: AgeDesc3,
      //                                      PAgeDesc4: AgeDesc4,
      //                                      PAgeDesc5: AgeDesc5,
      //                                      PArSortBy: ArSortBy,
      //                                      ProcessID: ProcessID,
      //                                      IncludeEstCurrGainLossAmtsInTotals: IncludeEstCurrGainLossAmtsInTotals);
      //                                  TGrand = Aging3.TGrand;
      //                                  FirstOfCustomer = Aging3.FirstOfCustomer;
      //                                  TUseHistRate = Aging3.UseHistRate;
      //                                  TranslateForAging = Aging3.TranslateForAging;
      //                                  AnyTrans = Aging3.AnyTrans;

      //                                  #endregion ExecuteMethodCall
      //                                  LogTiming($"AGING SP METHOD CALL");
      //                                  AnyCurrTrans = (int?)((sQLUtil.SQLEqual(AnyCurrTrans, 0) == true ? AnyTrans : AnyCurrTrans));
      //                                  //END
      //                              }
      //                              curCustAddrLoadResponseForCursor = null;
      //                              //Deallocate Cursor @curCustAddr
      //                              if (sQLUtil.SQLEqual(SortByCurr, 0) == true)
      //                              {
      //                                  //BEGIN
      //                                  TcTotBal = (decimal?)(TcTotBal + TcTotMajorBal);
      //                                  TcTotMajorBal = 0;
      //                                  //END
      //                              }
      //                              if (sQLUtil.SQLEqual(TransDomCurr, 1) == true)
      //                              {
      //                                  //BEGIN
      //                                  TcTotBal = (decimal?)(TcTotBal + TcTotMajorBal);
      //                                  //END
      //                              }
      //                              //END
      //                          }
      //                          curSiteGroupLoadResponseForCursor = null;
      //                          //Deallocate Cursor @curSiteGroup
      //                          //END
      //                      }
      //                      //END
      //                  }
      //                  #region Cursor Statement

      //                  #region CRUD LoadToRecord
      //                  ResultSetCursorLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
      //                  {
      //                      {"TcSite","TcSite"},
      //                      {"TcCustNum","TcCustNum"},
      //                      {"TcArtranType","TcArtranType"},
      //                      {"StdCh","StdCh"},
      //                      {"StdCh1","StdCh1"},
      //                      {"TcArtranInvSeq","TcArtranInvSeq"},
      //                      {"TcArTranIvDate","TcArTranIvDate"},
      //                      {"TcArtranDueDate","TcArtranDueDate"},
      //                      {"seq","seq"},
      //                      {"ApplyToInv","ApplyToInv"},
      //                      {"TcArTranChkSeq","TcArTranChkSeq"},
      //                      {"InvNum","InvNum"},
      //                  },
      //                      loadForChange: false,
      //                  lockingType: LockingType.None,
      //                      tableName: "#AccountsReceivableAging",
      //                      fromClause: collectionLoadRequestFactory.Clause(""),
      //                      whereClause: collectionLoadRequestFactory.Clause(""),
      //                      orderByClause: collectionLoadRequestFactory.Clause(" TcCustNum, InvNum, ApplyToInv, TcArtranInvSeq, TcArTranChkSeq"));
      //                  #endregion  LoadToRecord
                      
      //                  #endregion Cursor Statement
      //                  ResultSetCursorLoadResponseForCursor = this.appDB.Load(ResultSetCursorLoadRequestForCursor);
      //                  ResultSetCursor_CursorFetch_Status = ResultSetCursorLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
      //                  ResultSetCursor_CursorCounter = -1;

      //                  LogTiming($"LOAD TO RECORD for cursor - AccountsReceivableAging ({ ResultSetCursorLoadResponseForCursor.Items.Count})");

      //                  while (sQLUtil.SQLEqual(1, 1) == true)
      //                  {
      //                      //BEGIN
      //                      ResultSetCursor_CursorCounter++;
      //                      if (ResultSetCursorLoadResponseForCursor.Items.Count > ResultSetCursor_CursorCounter)
      //                      {
      //                          site_ref = ResultSetCursorLoadResponseForCursor.Items[ResultSetCursor_CursorCounter].GetValue<string>(0);
      //                          cust_num = ResultSetCursorLoadResponseForCursor.Items[ResultSetCursor_CursorCounter].GetValue<string>(1);
      //                          type = ResultSetCursorLoadResponseForCursor.Items[ResultSetCursor_CursorCounter].GetValue<string>(2);
      //                          inv_num = ResultSetCursorLoadResponseForCursor.Items[ResultSetCursor_CursorCounter].GetValue<string>(3);
      //                          apply_to_inv_num = ResultSetCursorLoadResponseForCursor.Items[ResultSetCursor_CursorCounter].GetValue<string>(4);
      //                          inv_seq = ResultSetCursorLoadResponseForCursor.Items[ResultSetCursor_CursorCounter].GetValue<int?>(5);
      //                          inv_date = ResultSetCursorLoadResponseForCursor.Items[ResultSetCursor_CursorCounter].GetValue<DateTime?>(6);
      //                          due_date = ResultSetCursorLoadResponseForCursor.Items[ResultSetCursor_CursorCounter].GetValue<DateTime?>(7);
      //                          seq = ResultSetCursorLoadResponseForCursor.Items[ResultSetCursor_CursorCounter].GetValue<int?>(8);
      //                          apply_to = ResultSetCursorLoadResponseForCursor.Items[ResultSetCursor_CursorCounter].GetValue<string>(9);
      //                          check_seq = ResultSetCursorLoadResponseForCursor.Items[ResultSetCursor_CursorCounter].GetValue<int?>(10);
      //                          Inv_Num_Ori = ResultSetCursorLoadResponseForCursor.Items[ResultSetCursor_CursorCounter].GetValue<string>(11);
      //                      }
      //                      ResultSetCursor_CursorFetch_Status = (ResultSetCursor_CursorCounter == ResultSetCursorLoadResponseForCursor.Items.Count ? -1 : 0);

      //                      if (sQLUtil.SQLNotEqual(ResultSetCursor_CursorFetch_Status, 0) == true)
      //                      {
      //                          break;
      //                      }
      //                      if ((sQLUtil.SQLEqual(this.iIsInteger.IsIntegerFn(apply_to), 1) == true && sQLUtil.SQLLessThan(convertToUtil.ToInt64(apply_to), 0) == true) || (sQLUtil.SQLEqual(this.iIsInteger.IsIntegerFn(apply_to), 1) == true && sQLUtil.SQLEqual(convertToUtil.ToInt64(apply_to), 0) == true) || sQLUtil.SQLEqual(type, "I") == true)
      //                      {
      //                          //BEGIN
      //                          if (sQLUtil.SQLEqual(PrOpenItem, "D") == true)
      //                          {
      //                              sQLExpressionExecutor.Execute(@"UPDATE #AccountsReceivableAging SET OrderByDate = {0} WHERE seq = {1}", due_date, seq);
      //                          }
      //                          else
      //                          {
      //                              //BEGIN

      //                              //#region CRUD LoadToRecord
      //                              //var AccountsReceivableAging4LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
      //                              //{
      //                              //    {"OrderByDate","#AccountsReceivableAging.OrderByDate"},
      //                              //},
      //                              //    tableName: "#AccountsReceivableAging",
      //                              //    tableHints: TableHints.UPDLock,
      //                              //    fromClause: collectionLoadRequestFactory.Clause(""),
      //                              //    whereClause: collectionLoadRequestFactory.Clause("seq = {0}", seq),
      //                              //    orderByClause: collectionLoadRequestFactory.Clause(""));
      //                              //var AccountsReceivableAging4LoadResponse = this.appDB.Load(AccountsReceivableAging4LoadRequest);
      //                              //#endregion  LoadToRecord

      //                              //#region CRUD UpdateByRecord
      //                              //foreach (var AccountsReceivableAging4Item in AccountsReceivableAging4LoadResponse.Items)
      //                              //{
      //                              //    AccountsReceivableAging4Item.SetValue<DateTime?>("OrderByDate", inv_date);
      //                              //};

      //                              //var AccountsReceivableAging4RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#AccountsReceivableAging",
      //                              //    items: AccountsReceivableAging4LoadResponse.Items);

      //                              //this.appDB.Update(AccountsReceivableAging4RequestUpdate);
      //                              //#endregion UpdateByRecord

      //                              #region Update Without Trigger

      //                              var AccountsReceivableAging = collectionNonTriggerUpdateRequestFactory.SQLUpdate(
      //                                  tableName: "#AccountsReceivableAging",
      //                                  //TableHints: TableHints.UPDLock,
      //                                  expressionByColumnToAssign: new Dictionary<string, IParameterizedCommand>()
      //                                  {
      //                                  {"OrderByDate",collectionNonTriggerUpdateRequestFactory.Clause("{0}", inv_date)}
      //                                  },
      //                                  fromClause: collectionNonTriggerUpdateRequestFactory.Clause(""),
      //                                  whereClause: collectionNonTriggerUpdateRequestFactory.Clause("seq = {0}", seq)
      //                                  );

      //                              this.appDB.UpdateWithoutTrigger(AccountsReceivableAging);

      //                              #endregion Update Without Trigger
      //                              LogTiming("Update Without Trigger - AccountsReceivableAging");



      //                              //END
      //                          }
      //                          continue;
      //                          //END
      //                      }
      //                      else
      //                      {
      //                          //BEGIN
      //                          if (sQLUtil.SQLEqual(PrOpenItem, "D") == true)
      //                          {
      //                              //BEGIN
      //                              #region CRUD LoadToVariable
      //                              var AccountsReceivableAging5LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
      //                              {
      //                                  {_order_by_date,"TcArtranDueDate"},
      //                              },
      //                                  loadForChange: false,
      //                  lockingType: LockingType.None,
      //                                  tableName: "#AccountsReceivableAging",
      //                                  fromClause: collectionLoadRequestFactory.Clause(""),
      //                                  whereClause: collectionLoadRequestFactory.Clause("TcSite = {1} AND TcCustNum = {2} AND StdCh = {0} AND TcArtranType = 'I'", apply_to_inv_num, site_ref, cust_num),
      //                                  orderByClause: collectionLoadRequestFactory.Clause(""));
      //                              var AccountsReceivableAging5LoadResponse = this.appDB.Load(AccountsReceivableAging5LoadRequest);
      //                              if (AccountsReceivableAging5LoadResponse.Items.Count > 0)
      //                              {
      //                                  order_by_date = _order_by_date;
      //                              }
      //                              #endregion  LoadToVariable
      //                              LogTiming("LOAD TO VAR - AccountsReceivableAging");
      //                              //END
      //                          }
      //                          else
      //                          {
      //                              //BEGIN
      //                              #region CRUD LoadToVariable
      //                              var AccountsReceivableAging6LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
      //                              {
      //                                  {_order_by_date,"TcArTranIvDate"},
      //                              },
      //                                  loadForChange: false,
      //                  lockingType: LockingType.None,
      //                                  tableName: "#AccountsReceivableAging",
      //                                  fromClause: collectionLoadRequestFactory.Clause(""),
      //                                  whereClause: collectionLoadRequestFactory.Clause("TcSite = {1} AND TcCustNum = {2} AND StdCh = {0} AND TcArtranType = 'I'", apply_to_inv_num, site_ref, cust_num),
      //                                  orderByClause: collectionLoadRequestFactory.Clause(""));
      //                              var AccountsReceivableAging6LoadResponse = this.appDB.Load(AccountsReceivableAging6LoadRequest);
      //                              if (AccountsReceivableAging6LoadResponse.Items.Count > 0)
      //                              {
      //                                  order_by_date = _order_by_date;
      //                              }
      //                              #endregion  LoadToVariable
      //                              LogTiming("LOAD TO VAR - AccountsReceivableAging");
      //                              //END
      //                          }

      //                          //sQLExpressionExecutor.Execute(@"UPDATE #AccountsReceivableAging SET OrderByDate = {0} WHERE TcSite = {1} AND TcCustNum = {2} AND StdCh = {3} AND TcArtranInvSeq = {4} AND TcArTranChkSeq = {5}",
      //                          //                                 order_by_date, site_ref, cust_num, inv_num, inv_seq, check_seq);

      //                          #region Update Without Trigger

      //                          var AccountsReceivableAging2 = collectionNonTriggerUpdateRequestFactory.SQLUpdate(
      //                              tableName: "#AccountsReceivableAging",
      //                              //TableHints: TableHints.UPDLock,
      //                              expressionByColumnToAssign: new Dictionary<string, IParameterizedCommand>()
      //                              {
      //                                  {"OrderByDate",collectionNonTriggerUpdateRequestFactory.Clause("{0}", order_by_date)}
      //                              },
      //                              fromClause: collectionNonTriggerUpdateRequestFactory.Clause(""),
      //                              whereClause: collectionNonTriggerUpdateRequestFactory.Clause(" TcSite = {0} AND TcCustNum = {1} AND StdCh = {2} AND TcArtranInvSeq = {3} AND TcArTranChkSeq = {4}", site_ref, cust_num, inv_num, inv_seq, check_seq)
      //                              );

      //                          this.appDB.UpdateWithoutTrigger(AccountsReceivableAging2);

      //                          #endregion Update Without Trigger
      //                          LogTiming("Update Without Trigger - AccountsReceivableAging");

      //                          //END
      //                      }
      //                      //END
      //                  }
      //                  //Deallocate Cursor ResultSetCursor

      //                  IntType currCodeCount = 0;
      //                  var currCodeCountLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
      //                  {
      //                  {currCodeCount, "COUNT(DISTINCT TcCurrCode)"}
      //                  },
      //                  loadForChange: false,
      //                  lockingType: LockingType.None,
      //                  tableName: "#AccountsReceivableAging",
      //                  fromClause: collectionLoadRequestFactory.Clause(""),
      //                  whereClause: collectionLoadRequestFactory.Clause(""),
      //                  orderByClause: collectionLoadRequestFactory.Clause(""));
      //                  var currCodeCountLoadResponse = this.appDB.Load(currCodeCountLoadRequest);

      //                  string isCurrCodeDistinct = currCodeCount > 1 ? "1" : "0";

      //                  CleanupARAgingResult(sessionId);

      //                  #region Insert Without Trigger

      //                  var tv_tempOutputNonTriggerInsertRequest = collectionNonTriggerInsertRequestFactory.SQLInsert(
      //                  targetTableName: "tmp_rpt_accounts_receivable_aging",
      //                  targetColumns: new List<string>()
      //                      {
      //                      "process_id",
      //                      "TcSortCurrCode",
      //                      "CurrencyFormat",
      //                      "CurrencyPlaces",
      //                      "TotCurrencyFormat",
      //                      "TotCurrencyPlaces",
      //                      "TcSortBy",
      //                      "TcCustNum",
      //                      "TcCustName",
      //                      "TcCity",
      //                      "TcState",
      //                      "TcSite",
      //                      "TcSiteName",
      //                      "TcContact",
      //                      "TcPhone",
      //                      "TcTempTermsCode",
      //                      "TcCustType",
      //                      "TcCreditLimit",
      //                      "TcCredhold",
      //                      "TcCurrCode",
      //                      "TcArtranType",
      //                      "StdCh",
      //                      "TcArtranInvSeq",
      //                      "TcArtranDate",
      //                      "TcArtranDueDate",
      //                      "TcAmtTran",
      //                      "TcArtranExchRate",
      //                      "TcArtranCurrCode",
      //                      "CustAmtTran",
      //                      "TcAmtTemp",
      //                      "PAgeDesc",
      //                      "PAgeDescNum",
      //                      "TcApprovalStatus",
      //                      "StdCh1",
      //                      "TcCustCurrCode",
      //                      "OrderByDate",
      //                      "ApplyToInv",
      //                      "TcArTranIvDate",
      //                      "TcArTranChkSeq",
      //                      "InvNum",
      //                      "TotalDays",
      //                      "THPaymentNumber",
      //                      "seq",
      //                      "Group1",
      //                      "Group2",
      //                      "Group3",
      //                      "IsCurrCodeDistinct",
      //                      "TcArTranTypeGroup",
      //                     },
      //                  valuesByExpressionToAssign: new Dictionary<string, IParameterizedCommand>()
      //                  {
      //                      {"process_id", collectionNonTriggerInsertRequestFactory.Clause("{0}", sessionId) },
      //                      {"TcSortCurrCode", collectionNonTriggerInsertRequestFactory.Clause("arg.TcSortCurrCode")},
      //                      {"CurrencyFormat", collectionNonTriggerInsertRequestFactory.Clause("arg.CurrencyFormat")},
      //                      {"CurrencyPlaces", collectionNonTriggerInsertRequestFactory.Clause("arg.CurrencyPlaces")},
      //                      {"TotCurrencyFormat", collectionNonTriggerInsertRequestFactory.Clause("arg.TotCurrencyFormat")},
      //                      {"TotCurrencyPlaces", collectionNonTriggerInsertRequestFactory.Clause("arg.TotCurrencyPlaces")},
      //                      {"TcSortBy", collectionNonTriggerInsertRequestFactory.Clause("arg.TcSortBy")},
      //                      {"TcCustNum", collectionNonTriggerInsertRequestFactory.Clause("arg.TcCustNum")},
      //                      {"TcCustName", collectionNonTriggerInsertRequestFactory.Clause("arg.TcCustName")},
      //                      {"TcCity", collectionNonTriggerInsertRequestFactory.Clause("arg.TcCity")},
      //                      {"TcState", collectionNonTriggerInsertRequestFactory.Clause("arg.TcState")},
      //                      {"TcSite", collectionNonTriggerInsertRequestFactory.Clause("arg.TcSite")},
      //                      {"TcSiteName", collectionNonTriggerInsertRequestFactory.Clause("arg.TcSiteName")},
      //                      {"TcContact", collectionNonTriggerInsertRequestFactory.Clause("arg.TcContact")},
      //                      {"TcPhone", collectionNonTriggerInsertRequestFactory.Clause("arg.TcPhone")},
      //                      {"TcTempTermsCode", collectionNonTriggerInsertRequestFactory.Clause("arg.TcTempTermsCode")},
      //                      {"TcCustType", collectionNonTriggerInsertRequestFactory.Clause("arg.TcCustType")},
      //                      {"TcCreditLimit", collectionNonTriggerInsertRequestFactory.Clause("arg.TcCreditLimit")},
      //                      {"TcCredhold", collectionNonTriggerInsertRequestFactory.Clause("arg.TcCredhold")},
      //                      {"TcCurrCode", collectionNonTriggerInsertRequestFactory.Clause("arg.TcCurrCode")},
      //                      {"TcArtranType", collectionNonTriggerInsertRequestFactory.Clause("arg.TcArtranType")},
      //                      {"StdCh", collectionNonTriggerInsertRequestFactory.Clause("arg.StdCh")},
      //                      {"TcArtranInvSeq", collectionNonTriggerInsertRequestFactory.Clause("arg.TcArtranInvSeq")},
      //                      {"TcArtranDate", collectionNonTriggerInsertRequestFactory.Clause("arg.TcArtranDate")},
      //                      {"TcArtranDueDate", collectionNonTriggerInsertRequestFactory.Clause("arg.TcArtranDueDate")},
      //                      {"TcAmtTran", collectionNonTriggerInsertRequestFactory.Clause("arg.TcAmtTran")},
      //                      {"TcArtranExchRate", collectionNonTriggerInsertRequestFactory.Clause("arg.TcArtranExchRate")},
      //                      {"TcArtranCurrCode", collectionNonTriggerInsertRequestFactory.Clause("arg.TcArtranCurrCode")},
      //                      {"CustAmtTran", collectionNonTriggerInsertRequestFactory.Clause("arg.CustAmtTran")},
      //                      {"TcAmtTemp", collectionNonTriggerInsertRequestFactory.Clause("arg.TcAmtTemp")},
      //                      {"PAgeDesc", collectionNonTriggerInsertRequestFactory.Clause("arg.PAgeDesc")},
      //                      {"PAgeDescNum", collectionNonTriggerInsertRequestFactory.Clause("arg.PAgeDescNum")},
      //                      {"TcApprovalStatus", collectionNonTriggerInsertRequestFactory.Clause("arg.TcApprovalStatus")},
      //                      {"StdCh1", collectionNonTriggerInsertRequestFactory.Clause("arg.StdCh1")},
      //                      {"TcCustCurrCode", collectionNonTriggerInsertRequestFactory.Clause("arg.TcCustCurrCode")},
      //                      {"OrderByDate", collectionNonTriggerInsertRequestFactory.Clause("arg.OrderByDate")},
      //                      {"ApplyToInv", collectionNonTriggerInsertRequestFactory.Clause("arg.ApplyToInv")},
      //                      {"TcArTranIvDate", collectionNonTriggerInsertRequestFactory.Clause("arg.TcArTranIvDate")},
      //                      {"TcArTranChkSeq", collectionNonTriggerInsertRequestFactory.Clause("arg.TcArTranChkSeq")},
      //                      {"InvNum", collectionNonTriggerInsertRequestFactory.Clause("arg.InvNum")},
      //                      {"TotalDays", collectionNonTriggerInsertRequestFactory.Clause("arg.TotalDays")},
      //                      {"THPaymentNumber", collectionNonTriggerInsertRequestFactory.Clause("arg.THPaymentNumber")},
      //                      {"seq", collectionNonTriggerInsertRequestFactory.Clause("arg.seq")},
      //                      {"Group1", collectionNonTriggerInsertRequestFactory.Clause("CASE WHEN {0} = 'C' THEN TcSortBy ELSE '' END",ArSortBy)},
      //                      {"Group2", collectionNonTriggerInsertRequestFactory.Clause("CASE WHEN {0} = 0 THEN TcSite ELSE (CASE WHEN {1} = 'A' THEN TcCustName + TcCustNum ELSE TcCustNum END) END",ConsolidateCustomers,ArSortBy)},
      //                      {"Group3", collectionNonTriggerInsertRequestFactory.Clause("CASE WHEN {0} = 0 THEN (CASE WHEN {1} = 'A' THEN TcCustName + TcCustNum ELSE TcCustNum END) ELSE TcSite END",ConsolidateCustomers,ArSortBy)},
      //                      {"IsCurrCodeDistinct", collectionNonTriggerInsertRequestFactory.Clause("{0}",isCurrCodeDistinct)},
      //                      {"TcArTranTypeGroup", collectionNonTriggerInsertRequestFactory.Clause("CASE WHEN TcArTranType = 'I' THEN 0 ELSE 1 END ")},

      //                  },
      //                  fromClause: collectionNonTriggerInsertRequestFactory.Clause("#AccountsReceivableAging AS arg"),
      //                  orderByClause: collectionNonTriggerInsertRequestFactory.Clause("Seq")
      //                  );

      //                  this.appDB.InsertWithoutTrigger(tv_tempOutputNonTriggerInsertRequest);

      //                  #endregion Insert Without Trigger
      //                  LogTiming("Insert Without Trigger - tmp_rpt_accounts_receivable_aging");

      //                  CleanupARTranAll(ProcessID);
      //              }

      //              #region CRUD LoadArbitrary
      //              var tmp_araging_result1LoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
      //              {
      //              {"TcSortCurrCode","TcSortCurrCode"},
      //              {"Group1","Group1"},
      //              {"Group2","Group2"},
      //              {"Group3","Group3"},
      //              {"gp3_SiteTotal_Original",$"SUM(CASE WHEN {variableUtil.GetQuotedValue<int?>(TransDomCurr)} = 1 THEN TcAmtTemp ELSE TcAmtTemp / TcArtranExchRate END)"},
      //              {"gp3_SiteTotal_AgeDesc1",$"SUM(CASE WHEN PAgeDescNum = 1 THEN (CASE WHEN {variableUtil.GetQuotedValue<int?>(TransDomCurr)} = 1 THEN TcAmtTemp ELSE TcAmtTemp / TcArtranExchRate END) ELSE 0 END)"},
      //              {"gp3_SiteTotal_AgeDesc2",$"SUM(CASE WHEN PAgeDescNum = 2 THEN (CASE WHEN {variableUtil.GetQuotedValue<int?>(TransDomCurr)} = 1 THEN TcAmtTemp ELSE TcAmtTemp / TcArtranExchRate END) ELSE 0 END)"},
      //              {"gp3_SiteTotal_AgeDesc3",$"SUM(CASE WHEN PAgeDescNum = 3 THEN (CASE WHEN {variableUtil.GetQuotedValue<int?>(TransDomCurr)} = 1 THEN TcAmtTemp ELSE TcAmtTemp / TcArtranExchRate END) ELSE 0 END)"},
      //              {"gp3_SiteTotal_AgeDesc4",$"SUM(CASE WHEN PAgeDescNum = 4 THEN (CASE WHEN {variableUtil.GetQuotedValue<int?>(TransDomCurr)} = 1 THEN TcAmtTemp ELSE TcAmtTemp / TcArtranExchRate END) ELSE 0 END)"},
      //              {"gp3_SiteTotal_AgeDesc5",$"SUM(CASE WHEN PAgeDescNum = 5 THEN (CASE WHEN {variableUtil.GetQuotedValue<int?>(TransDomCurr)} = 1 THEN TcAmtTemp ELSE TcAmtTemp / TcArtranExchRate END) ELSE 0 END)"},
      //              {"gp3_CustomerTotal_Original",$"SUM(CASE WHEN {variableUtil.GetQuotedValue<int?>(TransDomCurr)} = 1 THEN TcAmtTemp ELSE TcAmtTemp / TcArtranExchRate END)"},
      //              {"gp3_CustomerTotal_AgeDesc1",$"SUM(CASE WHEN PAgeDescNum = 1 THEN (CASE WHEN {variableUtil.GetQuotedValue<int?>(TransDomCurr)} = 1 THEN TcAmtTemp ELSE TcAmtTemp / TcArtranExchRate END) ELSE 0 END)"},
      //              {"gp3_CustomerTotal_AgeDesc2",$"SUM(CASE WHEN PAgeDescNum = 2 THEN (CASE WHEN {variableUtil.GetQuotedValue<int?>(TransDomCurr)} = 1 THEN TcAmtTemp ELSE TcAmtTemp / TcArtranExchRate END) ELSE 0 END)"},
      //              {"gp3_CustomerTotal_AgeDesc3",$"SUM(CASE WHEN PAgeDescNum = 3 THEN (CASE WHEN {variableUtil.GetQuotedValue<int?>(TransDomCurr)} = 1 THEN TcAmtTemp ELSE TcAmtTemp / TcArtranExchRate END) ELSE 0 END)"},
      //              {"gp3_CustomerTotal_AgeDesc4",$"SUM(CASE WHEN PAgeDescNum = 4 THEN (CASE WHEN {variableUtil.GetQuotedValue<int?>(TransDomCurr)} = 1 THEN TcAmtTemp ELSE TcAmtTemp / TcArtranExchRate END) ELSE 0 END)"},
      //              {"gp3_CustomerTotal_AgeDesc5",$"SUM(CASE WHEN PAgeDescNum = 5 THEN (CASE WHEN {variableUtil.GetQuotedValue<int?>(TransDomCurr)} = 1 THEN TcAmtTemp ELSE TcAmtTemp / TcArtranExchRate END) ELSE 0 END)"},
      //              },
      //              selectStatement: collectionLoadRequestFactory.Clause("SELECT @selectList FROM tmp_rpt_accounts_receivable_aging where process_id = {0} GROUP BY TcSortCurrCode, Group1, Group2, Group3", sessionId)
      //              );

      //              var tmp_araging_result1LoadResponse = this.appDB.Load(tmp_araging_result1LoadRequest);
      //              Data = tmp_araging_result1LoadResponse;
      //              #endregion  LoadArbitrary

      //              #region CRUD LoadArbitrary
      //              var tmp_araging_result2LoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
      //              {
      //              {"TcSortCurrCode","TcSortCurrCode"},
      //              {"Group1","Group1"},
      //              {"Group2","Group2"},
      //              {"gp2_CustomerTotal_Original",$"SUM(CASE WHEN {variableUtil.GetQuotedValue<int?>(TransDomCurr)} = 1 THEN TcAmtTemp ELSE TcAmtTemp / TcArtranExchRate END)"},
      //              {"gp2_CustomerTotal_AgeDesc1",$"SUM(CASE WHEN PAgeDescNum = 1 THEN (CASE WHEN {variableUtil.GetQuotedValue<int?>(TransDomCurr)} = 1 THEN TcAmtTemp ELSE TcAmtTemp / TcArtranExchRate END) ELSE 0 END)"},
      //              {"gp2_CustomerTotal_AgeDesc2",$"SUM(CASE WHEN PAgeDescNum = 2 THEN (CASE WHEN {variableUtil.GetQuotedValue<int?>(TransDomCurr)} = 1 THEN TcAmtTemp ELSE TcAmtTemp / TcArtranExchRate END) ELSE 0 END)"},
      //              {"gp2_CustomerTotal_AgeDesc3",$"SUM(CASE WHEN PAgeDescNum = 3 THEN (CASE WHEN {variableUtil.GetQuotedValue<int?>(TransDomCurr)} = 1 THEN TcAmtTemp ELSE TcAmtTemp / TcArtranExchRate END) ELSE 0 END)"},
      //              {"gp2_CustomerTotal_AgeDesc4",$"SUM(CASE WHEN PAgeDescNum = 4 THEN (CASE WHEN {variableUtil.GetQuotedValue<int?>(TransDomCurr)} = 1 THEN TcAmtTemp ELSE TcAmtTemp / TcArtranExchRate END) ELSE 0 END)"},
      //              {"gp2_CustomerTotal_AgeDesc5",$"SUM(CASE WHEN PAgeDescNum = 5 THEN (CASE WHEN {variableUtil.GetQuotedValue<int?>(TransDomCurr)} = 1 THEN TcAmtTemp ELSE TcAmtTemp / TcArtranExchRate END) ELSE 0 END)"},
      //              {"gp2_SiteTotal_Original",$"SUM(CASE WHEN {variableUtil.GetQuotedValue<int?>(TransDomCurr)} = 1 THEN TcAmtTemp ELSE TcAmtTemp / TcArtranExchRate END)"},
      //              {"gp2_SiteTotal_AgeDesc1",$"SUM(CASE WHEN PAgeDescNum = 1 THEN (CASE WHEN {variableUtil.GetQuotedValue<int?>(TransDomCurr)} = 1 THEN TcAmtTemp ELSE TcAmtTemp / TcArtranExchRate END) ELSE 0 END)"},
      //              {"gp2_SiteTotal_AgeDesc2",$"SUM(CASE WHEN PAgeDescNum = 2 THEN (CASE WHEN {variableUtil.GetQuotedValue<int?>(TransDomCurr)} = 1 THEN TcAmtTemp ELSE TcAmtTemp / TcArtranExchRate END) ELSE 0 END)"},
      //              {"gp2_SiteTotal_AgeDesc3",$"SUM(CASE WHEN PAgeDescNum = 3 THEN (CASE WHEN {variableUtil.GetQuotedValue<int?>(TransDomCurr)} = 1 THEN TcAmtTemp ELSE TcAmtTemp / TcArtranExchRate END) ELSE 0 END)"},
      //              {"gp2_SiteTotal_AgeDesc4",$"SUM(CASE WHEN PAgeDescNum = 4 THEN (CASE WHEN {variableUtil.GetQuotedValue<int?>(TransDomCurr)} = 1 THEN TcAmtTemp ELSE TcAmtTemp / TcArtranExchRate END) ELSE 0 END)"},
      //              {"gp2_SiteTotal_AgeDesc5",$"SUM(CASE WHEN PAgeDescNum = 5 THEN (CASE WHEN {variableUtil.GetQuotedValue<int?>(TransDomCurr)} = 1 THEN TcAmtTemp ELSE TcAmtTemp / TcArtranExchRate END) ELSE 0 END)"},
      //              },
      //              selectStatement: collectionLoadRequestFactory.Clause("SELECT @selectList FROM tmp_rpt_accounts_receivable_aging where process_id = {0} GROUP BY TcSortCurrCode, Group1, Group2", sessionId)
      //              );

      //              var tmp_araging_result2LoadResponse = this.appDB.Load(tmp_araging_result2LoadRequest);
      //              Data = tmp_araging_result2LoadResponse;
      //              #endregion  LoadArbitrary

      //              #region CRUD LoadArbitrary
      //              var tmp_araging_result3LoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
      //             {
      //              {"TcSortCurrCode","TcSortCurrCode"},
      //              {"Total_Original",$"SUM(CASE WHEN {variableUtil.GetQuotedValue<int?>(TransDomCurr)} = 1 THEN TcAmtTemp ELSE TcAmtTemp / TcArtranExchRate END)"},
      //              {"Total_AgeDesc1",$"SUM(CASE WHEN PAgeDescNum = 1 THEN (CASE WHEN {variableUtil.GetQuotedValue<int?>(TransDomCurr)} = 1 THEN TcAmtTemp ELSE TcAmtTemp / TcArtranExchRate END) ELSE 0 END)"},
      //              {"Total_AgeDesc2",$"SUM(CASE WHEN PAgeDescNum = 2 THEN (CASE WHEN {variableUtil.GetQuotedValue<int?>(TransDomCurr)} = 1 THEN TcAmtTemp ELSE TcAmtTemp / TcArtranExchRate END) ELSE 0 END)"},
      //              {"Total_AgeDesc3",$"SUM(CASE WHEN PAgeDescNum = 3 THEN (CASE WHEN {variableUtil.GetQuotedValue<int?>(TransDomCurr)} = 1 THEN TcAmtTemp ELSE TcAmtTemp / TcArtranExchRate END) ELSE 0 END)"},
      //              {"Total_AgeDesc4",$"SUM(CASE WHEN PAgeDescNum = 4 THEN (CASE WHEN {variableUtil.GetQuotedValue<int?>(TransDomCurr)} = 1 THEN TcAmtTemp ELSE TcAmtTemp / TcArtranExchRate END) ELSE 0 END)"},
      //              {"Total_AgeDesc5",$"SUM(CASE WHEN PAgeDescNum = 5 THEN (CASE WHEN {variableUtil.GetQuotedValue<int?>(TransDomCurr)} = 1 THEN TcAmtTemp ELSE TcAmtTemp / TcArtranExchRate END) ELSE 0 END)"},
      //              },
      //              selectStatement: collectionLoadRequestFactory.Clause("SELECT @selectList FROM tmp_rpt_accounts_receivable_aging where process_id = {0} GROUP BY TcSortCurrCode", sessionId)
      //              );

      //              var tmp_araging_result3LoadResponse = this.appDB.Load(tmp_araging_result3LoadRequest);
      //              Data = tmp_araging_result3LoadResponse;
      //              #endregion  LoadArbitrary

      //              #region CRUD LoadToRecord
      //              var tmp_araging_result4LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
      //              {
      //              {"GrandTotal_Original",$"SUM(CASE WHEN {variableUtil.GetQuotedValue<int?>(TransDomCurr)} = 1 THEN TcAmtTemp ELSE TcAmtTemp / TcArtranExchRate END)"},
      //              {"GrandTotal_AgeDesc1",$"SUM(CASE WHEN PAgeDescNum = 1 THEN (CASE WHEN {variableUtil.GetQuotedValue<int?>(TransDomCurr)} = 1 THEN TcAmtTemp ELSE TcAmtTemp / TcArtranExchRate END) ELSE 0 END)"},
      //              {"GrandTotal_AgeDesc2",$"SUM(CASE WHEN PAgeDescNum = 2 THEN (CASE WHEN {variableUtil.GetQuotedValue<int?>(TransDomCurr)} = 1 THEN TcAmtTemp ELSE TcAmtTemp / TcArtranExchRate END) ELSE 0 END)"},
      //              {"GrandTotal_AgeDesc3",$"SUM(CASE WHEN PAgeDescNum = 3 THEN (CASE WHEN {variableUtil.GetQuotedValue<int?>(TransDomCurr)} = 1 THEN TcAmtTemp ELSE TcAmtTemp / TcArtranExchRate END) ELSE 0 END)"},
      //              {"GrandTotal_AgeDesc4",$"SUM(CASE WHEN PAgeDescNum = 4 THEN (CASE WHEN {variableUtil.GetQuotedValue<int?>(TransDomCurr)} = 1 THEN TcAmtTemp ELSE TcAmtTemp / TcArtranExchRate END) ELSE 0 END)"},
      //              {"GrandTotal_AgeDesc5",$"SUM(CASE WHEN PAgeDescNum = 5 THEN (CASE WHEN {variableUtil.GetQuotedValue<int?>(TransDomCurr)} = 1 THEN TcAmtTemp ELSE TcAmtTemp / TcArtranExchRate END) ELSE 0 END)"},
      //              },
      //              loadForChange: false,
      //                  lockingType: LockingType.None,
      //              tableName: "tmp_rpt_accounts_receivable_aging",
      //              fromClause: collectionLoadRequestFactory.Clause(""),
      //              whereClause: collectionLoadRequestFactory.Clause("process_id = {0}", sessionId),
      //              orderByClause: collectionLoadRequestFactory.Clause(""));
      //              var tmp_araging_result4LoadResponse = this.appDB.Load(tmp_araging_result4LoadRequest);
      //              #endregion  LoadToRecord

      //              var requestWhereClause = collectionLoadRequestFactory.Clause("process_id = {0}", sessionId);
      //              if (resultBookmark != null)
      //              {
      //                  requestWhereClause = queryLanguage.AppendBookmark(requestWhereClause, resultBookmark);
      //              }
      //              var loadResultRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
      //                  {
      //                  {"TcSortCurrCode","TcSortCurrCode"},
      //                  {"CurrencyFormat","CurrencyFormat"},
      //                  {"CurrencyPlaces","CurrencyPlaces"},
      //                  {"TotCurrencyFormat","TotCurrencyFormat"},
      //                  {"TotCurrencyPlaces","TotCurrencyPlaces"},
      //                  {"TcSortBy","TcSortBy"},
      //                  {"TcCustNum","TcCustNum"},
      //                  {"TcCustName","TcCustName"},
      //                  {"TcCity","TcCity"},
      //                  {"TcState","TcState"},
      //                  {"TcSite","TcSite"},
      //                  {"TcSiteName","TcSiteName"},
      //                  {"TcContact","TcContact"},
      //                  {"TcPhone","TcPhone"},
      //                  {"TcTempTermsCode","TcTempTermsCode"},
      //                  {"TcCustType","TcCustType"},
      //                  {"TcCreditLimit","TcCreditLimit"},
      //                  {"TcCredhold","TcCredhold"},
      //                  {"TcCurrCode","TcCurrCode"},
      //                  {"TcArtranType","TcArtranType"},
      //                  {"StdCh","StdCh"},
      //                  {"TcArtranInvSeq","TcArtranInvSeq"},
      //                  {"TcArtranDate","TcArtranDate"},
      //                  {"TcArtranDueDate","TcArtranDueDate"},
      //                  {"TcAmtTran","TcAmtTran"},
      //                  {"TcArtranExchRate","TcArtranExchRate"},
      //                  {"TcArtranCurrCode","TcArtranCurrCode"},
      //                  {"CustAmtTran","CustAmtTran"},
      //                  {"TcAmtTemp","TcAmtTemp"},
      //                  {"PAgeDesc","PAgeDesc"},
      //                  {"PAgeDescNum","PAgeDescNum"},
      //                  {"TcApprovalStatus","TcApprovalStatus"},
      //                  {"StdCh1","StdCh1"},
      //                  {"TcCustCurrCode","TcCustCurrCode"},
      //                  {"OrderByDate","OrderByDate"},
      //                  {"ApplyToInv","ApplyToInv"},
      //                  {"TcArTranIvDate","TcArTranIvDate"},
      //                  {"TcArTranChkSeq","TcArTranChkSeq"},
      //                  {"InvNum","InvNum"},
      //                  {"TotalDays","TotalDays"},
      //                  {"THPaymentNumber","THPaymentNumber"},
      //                  {"Seq","Seq"},
      //                  {"Group1","Group1"},
      //                  {"Group2","Group2"},
      //                  {"Group3","Group3"},
      //                  {"gp3_SiteTotal_Original","gp3_SiteTotal_Original"},
      //                  {"gp3_SiteTotal_AgeDesc1","gp3_SiteTotal_AgeDesc1"},
      //                  {"gp3_SiteTotal_AgeDesc2","gp3_SiteTotal_AgeDesc2"},
      //                  {"gp3_SiteTotal_AgeDesc3","gp3_SiteTotal_AgeDesc3"},
      //                  {"gp3_SiteTotal_AgeDesc4","gp3_SiteTotal_AgeDesc4"},
      //                  {"gp3_SiteTotal_AgeDesc5","gp3_SiteTotal_AgeDesc5"},
      //                  {"gp3_CustomerTotal_Original","gp3_CustomerTotal_Original"},
      //                  {"gp3_CustomerTotal_AgeDesc1","gp3_CustomerTotal_AgeDesc1"},
      //                  {"gp3_CustomerTotal_AgeDesc2","gp3_CustomerTotal_AgeDesc2"},
      //                  {"gp3_CustomerTotal_AgeDesc3","gp3_CustomerTotal_AgeDesc3"},
      //                  {"gp3_CustomerTotal_AgeDesc4","gp3_CustomerTotal_AgeDesc4"},
      //                  {"gp3_CustomerTotal_AgeDesc5","gp3_CustomerTotal_AgeDesc5"},
      //                  {"gp2_CustomerTotal_Original","gp2_CustomerTotal_Original"},
      //                  {"gp2_CustomerTotal_AgeDesc1","gp2_CustomerTotal_AgeDesc1"},
      //                  {"gp2_CustomerTotal_AgeDesc2","gp2_CustomerTotal_AgeDesc2"},
      //                  {"gp2_CustomerTotal_AgeDesc3","gp2_CustomerTotal_AgeDesc3"},
      //                  {"gp2_CustomerTotal_AgeDesc4","gp2_CustomerTotal_AgeDesc4"},
      //                  {"gp2_CustomerTotal_AgeDesc5","gp2_CustomerTotal_AgeDesc5"},
      //                  {"gp2_SiteTotal_Original","gp2_SiteTotal_Original"},
      //                  {"gp2_SiteTotal_AgeDesc1","gp2_SiteTotal_AgeDesc1"},
      //                  {"gp2_SiteTotal_AgeDesc2","gp2_SiteTotal_AgeDesc2"},
      //                  {"gp2_SiteTotal_AgeDesc3","gp2_SiteTotal_AgeDesc3"},
      //                  {"gp2_SiteTotal_AgeDesc4","gp2_SiteTotal_AgeDesc4"},
      //                  {"gp2_SiteTotal_AgeDesc5","gp2_SiteTotal_AgeDesc5"},
      //                  {"Total_Original","Total_Original"},
      //                  {"Total_AgeDesc1","Total_AgeDesc1"},
      //                  {"Total_AgeDesc2","Total_AgeDesc2"},
      //                  {"Total_AgeDesc3","Total_AgeDesc3"},
      //                  {"Total_AgeDesc4","Total_AgeDesc4"},
      //                  {"Total_AgeDesc5","Total_AgeDesc5"},
      //                  {"GrandTotal_Original","GrandTotal_Original"},
      //                  {"GrandTotal_AgeDesc1","GrandTotal_AgeDesc1"},
      //                  {"GrandTotal_AgeDesc2","GrandTotal_AgeDesc2"},
      //                  {"GrandTotal_AgeDesc3","GrandTotal_AgeDesc3"},
      //                  {"GrandTotal_AgeDesc4","GrandTotal_AgeDesc4"},
      //                  {"GrandTotal_AgeDesc5","GrandTotal_AgeDesc5"},
      //                  {"IsCurrCodeDistinct","IsCurrCodeDistinct"},
      //                  {"process_id","process_id"},
      //                  {"TcArTranTypeGroup","TcArTranTypeGroup"},
      //                  },
      //              loadForChange: false,
      //              lockingType: LockingType.None,
      //              tableName: "tmp_rpt_accounts_receivable_aging",
      //              maximumRows: recordCap + 1,
      //              fromClause: collectionLoadRequestFactory.Clause(""),
      //              whereClause: requestWhereClause,
      //              orderByClause: collectionLoadRequestFactory.Clause(" TcSortCurrCode, Group1, Group2, Group3, OrderByDate, ApplyToInv, TcArTranTypeGroup, InvNum, TcArtranInvSeq, TcArTranChkSeq, Seq"));
      //              var loadResultResponse = this.appDB.Load(loadResultRequest);

      //              LogTiming("Final Result - tmp_rpt_accounts_receivable_aging");

      //              if (loadResultResponse.Items.Count > 1 && loadResultResponse.Items.Count > recordCap)
      //              {
      //                  IRecordReadOnly bookmarkRow = loadResultResponse.Items[loadResultResponse.Items.Count - 2];
      //                  IBookmark bookmark = bookmarkFactory.Create(bookmarkRow, resultSortOrder);
      //                  mgSessionVariableBasedCache.Insert("Bookmark", (ICachable)bookmark);

      //                  (int? returnCode, string variableValue, string infobar) = getVariable.GetVariableSp("Bookmark", "", 0, "", "");
      //                  if (!string.IsNullOrEmpty(variableValue))
      //                  {
      //                      defineProcessVariable.DefineProcessVariableSp("Bookmark", variableValue, infobar);
      //                  }
      //              }
      //              else
      //              {
      //                  CleanupARAgingResult(sessionId);
      //              }

      //              DataTable dtResult = recordCollectionToDataTable.ToDataTable(loadResultResponse.Items);
      //              DataTable dtGroup1 = recordCollectionToDataTable.ToDataTable(tmp_araging_result1LoadResponse.Items);
      //              DataTable dtGroup2 = recordCollectionToDataTable.ToDataTable(tmp_araging_result2LoadResponse.Items);
      //              DataTable dtGroup3 = recordCollectionToDataTable.ToDataTable(tmp_araging_result3LoadResponse.Items);
      //              DataTable dtTotal = recordCollectionToDataTable.ToDataTable(tmp_araging_result4LoadResponse.Items);

      //              UpdateTableSummary(dtResult, dtGroup1, dtGroup2, dtGroup3, dtTotal);
      //              ICollectionLoadResponse resultCollection = dataTableToCollectionLoadResponse.Process(dtResult);

      //              Data = resultCollection;
      //          }
      //          catch (Exception ex)
      //          {
      //              CleanupARTranAll(ProcessID);
      //              CleanupARAgingResult(sessionId);
      //              DbException dbException = (DbException)appDB.GetDbException(ex);
      //              throw dbException;
      //          }

      //          LogTiming("Returned Final Result - tmp_rpt_accounts_receivable_aging");
      //          //File.AppendAllText(@"C:\logs\araging\ArAgingLog.txt", "Ending: " + DateTime.Now.ToLongTimeString() + " - "+ Data.Items.Count.ToString() + " - " +"\r\n");
      //          return (Data, Severity);
      //      }
      //      finally
      //      {
      //          if (bunchedLoadCollection != null)
      //              bunchedLoadCollection.EndBunching();
      //      }
      //  }

      //  private void UpdateTableSummary(DataTable dtResult, DataTable dtGroup1, DataTable dtGroup2, DataTable dtGroup3, DataTable dtTotal)
      //  {
      //      foreach (DataRow dr in dtGroup1.Rows)
      //      {
      //          string TcSortCurrCode = Convert.ToString(dr["TcSortCurrCode"]).Replace("'", "''");
      //          string Group1 = Convert.ToString(dr["Group1"]).Replace("'", "''");
      //          string Group2 = Convert.ToString(dr["Group2"]).Replace("'", "''");
      //          string Group3 = Convert.ToString(dr["Group3"]).Replace("'", "''");

      //          DataRow[] rowsToUpdate = dtResult.Select($"ISNULL(TcSortCurrCode,'') = ISNULL({variableUtil.GetQuotedValue(TcSortCurrCode)}, '') AND Group1 = '{Group1}' AND Group2 = '{Group2}' AND Group3 = '{Group3}'");
      //          foreach (DataRow drToUpdate in rowsToUpdate)
      //          {
      //              drToUpdate["gp3_SiteTotal_Original"] = dr["gp3_SiteTotal_Original"];
      //              drToUpdate["gp3_SiteTotal_AgeDesc1"] = dr["gp3_SiteTotal_AgeDesc1"];
      //              drToUpdate["gp3_SiteTotal_AgeDesc2"] = dr["gp3_SiteTotal_AgeDesc2"];
      //              drToUpdate["gp3_SiteTotal_AgeDesc3"] = dr["gp3_SiteTotal_AgeDesc3"];
      //              drToUpdate["gp3_SiteTotal_AgeDesc4"] = dr["gp3_SiteTotal_AgeDesc4"];
      //              drToUpdate["gp3_SiteTotal_AgeDesc5"] = dr["gp3_SiteTotal_AgeDesc5"];

      //              drToUpdate["gp3_CustomerTotal_Original"] = dr["gp3_CustomerTotal_Original"];
      //              drToUpdate["gp3_CustomerTotal_AgeDesc1"] = dr["gp3_CustomerTotal_AgeDesc1"];
      //              drToUpdate["gp3_CustomerTotal_AgeDesc2"] = dr["gp3_CustomerTotal_AgeDesc2"];
      //              drToUpdate["gp3_CustomerTotal_AgeDesc3"] = dr["gp3_CustomerTotal_AgeDesc3"];
      //              drToUpdate["gp3_CustomerTotal_AgeDesc4"] = dr["gp3_CustomerTotal_AgeDesc4"];
      //              drToUpdate["gp3_CustomerTotal_AgeDesc5"] = dr["gp3_CustomerTotal_AgeDesc5"];
      //          }
      //      }

      //      foreach (DataRow dr in dtGroup2.Rows)
      //      {
      //          string TcSortCurrCode = Convert.ToString(dr["TcSortCurrCode"]).Replace("'", "''");
      //          string Group1 = Convert.ToString(dr["Group1"]).Replace("'", "''");
      //          string Group2 = Convert.ToString(dr["Group2"]).Replace("'", "''");

      //          DataRow[] rowsToUpdate = dtResult.Select($"ISNULL(TcSortCurrCode, '') = ISNULL({variableUtil.GetQuotedValue(TcSortCurrCode)}, '') AND Group1 = '{Group1}' AND Group2 = '{Group2}'");
      //          foreach (DataRow drToUpdate in rowsToUpdate)
      //          {
      //              drToUpdate["gp2_CustomerTotal_Original"] = dr["gp2_CustomerTotal_Original"];
      //              drToUpdate["gp2_CustomerTotal_AgeDesc1"] = dr["gp2_CustomerTotal_AgeDesc1"];
      //              drToUpdate["gp2_CustomerTotal_AgeDesc2"] = dr["gp2_CustomerTotal_AgeDesc2"];
      //              drToUpdate["gp2_CustomerTotal_AgeDesc3"] = dr["gp2_CustomerTotal_AgeDesc3"];
      //              drToUpdate["gp2_CustomerTotal_AgeDesc4"] = dr["gp2_CustomerTotal_AgeDesc4"];
      //              drToUpdate["gp2_CustomerTotal_AgeDesc5"] = dr["gp2_CustomerTotal_AgeDesc5"];

      //              drToUpdate["gp2_SiteTotal_Original"] = dr["gp2_SiteTotal_Original"];
      //              drToUpdate["gp2_SiteTotal_AgeDesc1"] = dr["gp2_SiteTotal_AgeDesc1"];
      //              drToUpdate["gp2_SiteTotal_AgeDesc2"] = dr["gp2_SiteTotal_AgeDesc2"];
      //              drToUpdate["gp2_SiteTotal_AgeDesc3"] = dr["gp2_SiteTotal_AgeDesc3"];
      //              drToUpdate["gp2_SiteTotal_AgeDesc4"] = dr["gp2_SiteTotal_AgeDesc4"];
      //              drToUpdate["gp2_SiteTotal_AgeDesc5"] = dr["gp2_SiteTotal_AgeDesc5"];
      //          }
      //      }

      //      foreach (DataRow dr in dtGroup3.Rows)
      //      {
      //          string TcSortCurrCode = Convert.ToString(dr["TcSortCurrCode"]).Replace("'", "''");
      //          DataRow[] rowsToUpdate = dtResult.Select($"ISNULL(TcSortCurrCode, '') = ISNULL({variableUtil.GetQuotedValue(TcSortCurrCode)}, '')");
      //          foreach (DataRow drToUpdate in rowsToUpdate)
      //          {
      //              drToUpdate["Total_Original"] = dr["Total_Original"];
      //              drToUpdate["Total_AgeDesc1"] = dr["Total_AgeDesc1"];
      //              drToUpdate["Total_AgeDesc2"] = dr["Total_AgeDesc2"];
      //              drToUpdate["Total_AgeDesc3"] = dr["Total_AgeDesc3"];
      //              drToUpdate["Total_AgeDesc4"] = dr["Total_AgeDesc4"];
      //              drToUpdate["Total_AgeDesc5"] = dr["Total_AgeDesc5"];
      //          }
      //      }

      //      foreach (DataRow drToUpdate in dtResult.Rows)
      //      {
      //          drToUpdate["GrandTotal_Original"] = dtTotal.Rows[0]["GrandTotal_Original"];
      //          drToUpdate["GrandTotal_AgeDesc1"] = dtTotal.Rows[0]["GrandTotal_AgeDesc1"];
      //          drToUpdate["GrandTotal_AgeDesc2"] = dtTotal.Rows[0]["GrandTotal_AgeDesc2"];
      //          drToUpdate["GrandTotal_AgeDesc3"] = dtTotal.Rows[0]["GrandTotal_AgeDesc3"];
      //          drToUpdate["GrandTotal_AgeDesc4"] = dtTotal.Rows[0]["GrandTotal_AgeDesc4"];
      //          drToUpdate["GrandTotal_AgeDesc5"] = dtTotal.Rows[0]["GrandTotal_AgeDesc5"];
      //      }
      //  }

      //  private void CleanupARTranAll(Guid? processId)
      //  {
      //      try
      //      {
      //          string delARTranSql = string.Format("DELETE tmp_artran_all WHERE ProcessID = {0}", variableUtil.GetQuotedValue(processId));
      //          sQLExpressionExecutor.Execute(delARTranSql);
      //      }
      //      catch
      //      {
      //      }
      //  }

      //  private void CleanupARAgingResult(Guid? sessionId)
      //  {
      //      try
      //      {
      //          string delResultSql = string.Format("DELETE tmp_rpt_accounts_receivable_aging WHERE process_id = {0}", variableUtil.GetQuotedValue(sessionId));
      //          sQLExpressionExecutor.Execute(delResultSql);
      //      }
      //      catch
      //      {
      //      }
      //  }
        #endregion

        #region AltExtGen_Rpt_AccountsReceivableAgingSp
        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        AltExtGen_Rpt_AccountsReceivableAgingSp(
            string AltExtGenSp,
            DateTime? AgingDate = null,
            DateTime? CutoffDate = null,
            int? AgingDateOffset = null,
            int? CutoffDateOffset = null,
            string StateCycle = null,
            int? ShowActive = null,
            string BegSlsman = null,
            string EndSlsman = null,
            string CustomerStarting = null,
            string CustomerEnding = null,
            string NameStarting = null,
            string NameEnding = null,
            string CurCodeStarting = null,
            string CurCodeEnding = null,
            int? PrZeroBal = null,
            string CreditHold = null,
            int? PrCreditBal = null,
            int? SumToCorp = null,
            int? TransDomCurr = null,
            int? UseHistRate = null,
            string PrOpenItem = null,
            int? PrOpenPay = null,
            int? HidePaid = null,
            int? SortByCurr = null,
            string ArSortBy = null,
            string AgeBuckets = null,
            string InvDue = null,
            int? AgeDays1 = null,
            string AgeDesc1 = null,
            int? AgeDays2 = null,
            string AgeDesc2 = null,
            int? AgeDays3 = null,
            string AgeDesc3 = null,
            int? AgeDays4 = null,
            string AgeDesc4 = null,
            int? AgeDays5 = null,
            string AgeDesc5 = null,
            string SiteGroup = null,
            int? DisplayHeader = null,
            int? ConsolidateCustomers = null,
            int? IncludeEstCurrGainLossAmtsInTotals = null,
            string pSite = null)
        {
            DateType _AgingDate = AgingDate;
            DateType _CutoffDate = CutoffDate;
            DateOffsetType _AgingDateOffset = AgingDateOffset;
            DateOffsetType _CutoffDateOffset = CutoffDateOffset;
            InfobarType _StateCycle = StateCycle;
            ListYesNoType _ShowActive = ShowActive;
            SlsmanType _BegSlsman = BegSlsman;
            SlsmanType _EndSlsman = EndSlsman;
            CustNumType _CustomerStarting = CustomerStarting;
            CustNumType _CustomerEnding = CustomerEnding;
            NameType _NameStarting = NameStarting;
            NameType _NameEnding = NameEnding;
            CurrCodeType _CurCodeStarting = CurCodeStarting;
            CurrCodeType _CurCodeEnding = CurCodeEnding;
            ListYesNoType _PrZeroBal = PrZeroBal;
            StringType _CreditHold = CreditHold;
            ListYesNoType _PrCreditBal = PrCreditBal;
            ListYesNoType _SumToCorp = SumToCorp;
            ListYesNoType _TransDomCurr = TransDomCurr;
            ListYesNoType _UseHistRate = UseHistRate;
            SortDirectionPlusType _PrOpenItem = PrOpenItem;
            ListYesNoType _PrOpenPay = PrOpenPay;
            IntType _HidePaid = HidePaid;
            ListYesNoType _SortByCurr = SortByCurr;
            StringType _ArSortBy = ArSortBy;
            AcctType _AgeBuckets = AgeBuckets;
            ArAgeByType _InvDue = InvDue;
            AgeDaysType _AgeDays1 = AgeDays1;
            AgeDescType _AgeDesc1 = AgeDesc1;
            AgeDaysType _AgeDays2 = AgeDays2;
            AgeDescType _AgeDesc2 = AgeDesc2;
            AgeDaysType _AgeDays3 = AgeDays3;
            AgeDescType _AgeDesc3 = AgeDesc3;
            AgeDaysType _AgeDays4 = AgeDays4;
            AgeDescType _AgeDesc4 = AgeDesc4;
            AgeDaysType _AgeDays5 = AgeDays5;
            AgeDescType _AgeDesc5 = AgeDesc5;
            SiteGroupType _SiteGroup = SiteGroup;
            ListYesNoType _DisplayHeader = DisplayHeader;
            ListYesNoType _ConsolidateCustomers = ConsolidateCustomers;
            ListYesNoType _IncludeEstCurrGainLossAmtsInTotals = IncludeEstCurrGainLossAmtsInTotals;
            SiteType _pSite = pSite;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();
                IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "AgingDate", _AgingDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CutoffDate", _CutoffDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AgingDateOffset", _AgingDateOffset, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CutoffDateOffset", _CutoffDateOffset, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StateCycle", _StateCycle, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ShowActive", _ShowActive, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BegSlsman", _BegSlsman, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndSlsman", _EndSlsman, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CustomerStarting", _CustomerStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CustomerEnding", _CustomerEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "NameStarting", _NameStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "NameEnding", _NameEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CurCodeStarting", _CurCodeStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CurCodeEnding", _CurCodeEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PrZeroBal", _PrZeroBal, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CreditHold", _CreditHold, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PrCreditBal", _PrCreditBal, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SumToCorp", _SumToCorp, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TransDomCurr", _TransDomCurr, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UseHistRate", _UseHistRate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PrOpenItem", _PrOpenItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PrOpenPay", _PrOpenPay, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "HidePaid", _HidePaid, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SortByCurr", _SortByCurr, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ArSortBy", _ArSortBy, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AgeBuckets", _AgeBuckets, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InvDue", _InvDue, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AgeDays1", _AgeDays1, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AgeDesc1", _AgeDesc1, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AgeDays2", _AgeDays2, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AgeDesc2", _AgeDesc2, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AgeDays3", _AgeDays3, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AgeDesc3", _AgeDesc3, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AgeDays4", _AgeDays4, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AgeDesc4", _AgeDesc4, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AgeDays5", _AgeDays5, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AgeDesc5", _AgeDesc5, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SiteGroup", _SiteGroup, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ConsolidateCustomers", _ConsolidateCustomers, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "IncludeEstCurrGainLossAmtsInTotals", _IncludeEstCurrGainLossAmtsInTotals, ParameterDirection.Input);
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
        #endregion
    }
}
