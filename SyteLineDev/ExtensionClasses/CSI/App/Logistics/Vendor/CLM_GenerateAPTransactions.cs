//PROJECT NAME: Logistics
//CLASS NAME: CLM_GenerateAPTransactions.cs

using CSI.Data;
using CSI.Data.Cache;
using CSI.Data.CRUD;
using CSI.Data.Functions;
using CSI.Data.RecordSets;
using CSI.Data.SQL;
using CSI.Data.SQL.UDDT;
using CSI.Data.Utilities;
using CSI.DataCollection;
using CSI.Logistics.Customer;
using CSI.Material;
using CSI.MG;
using CSI.MG.MGCore;
using System;
using System.Collections.Generic;
using System.Data;

namespace CSI.Logistics.Vendor
{
    public class CLM_GenerateAPTransactions : ICLM_GenerateAPTransactions
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly ICollectionNonTriggerInsertRequestFactory collectionNonTriggerInsertRequestFactory;
        readonly ICollectionNonTriggerUpdateRequestFactory collectionNonTriggerUpdateRequestFactory;
        readonly ICollectionNonTriggerDeleteRequestFactory collectionNonTriggerDeleteRequestFactory;
        readonly ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
        readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionUpdateRequestFactory collectionUpdateRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IExpandKyByType iExpandKyByType;
        readonly IScalarFunction scalarFunction;
        readonly IExistsChecker existsChecker;
        readonly IConvertToUtil convertToUtil;
        readonly IVariableUtil variableUtil;
        readonly IUomConvQty iUomConvQty;
        readonly IUomConvAmt iUomConvAmt;
        readonly IStringUtil stringUtil;
        readonly ISessionID iSessionID;
        readonly IRaiseError raiseError;
        readonly IGetumcf iGetumcf;
        readonly IMathUtil mathUtil;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly IMinQty iMinQty;
        readonly IMsgApp iMsgApp;
        readonly ILogger logger;

        // Streaming  
        readonly IDefineProcessVariable defineProcessVariable;
        readonly IGetVariable getVariable;
        readonly ICache mgSessionVariableBasedCache;
        readonly IQueryLanguage queryLanguage;
        readonly ISortOrderFactory sortOrderFactory;
        readonly LoadType loadType;
        readonly IRecordStreamFactory recordStreamFactory;
        readonly IUnionUtil unionUtil;
        readonly IHighString highString;
        readonly IHighInt highInt;
        int processedRowCount = 0;
        readonly int pageSize;
        readonly int recordCap;
        // Filter String
        readonly ISqlFilter sqlFilter;

        DateTime startTime;

        public CLM_GenerateAPTransactions(IApplicationDB appDB,
            IBunchedLoadCollection bunchedLoadCollection,
            ICollectionNonTriggerInsertRequestFactory collectionNonTriggerInsertRequestFactory,
            ICollectionNonTriggerUpdateRequestFactory collectionNonTriggerUpdateRequestFactory,
            ICollectionNonTriggerDeleteRequestFactory collectionNonTriggerDeleteRequestFactory,
            ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
            ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IExpandKyByType iExpandKyByType,
            IScalarFunction scalarFunction,
            IExistsChecker existsChecker,
            IConvertToUtil convertToUtil,
            IVariableUtil variableUtil,
            IUomConvQty iUomConvQty,
            IUomConvAmt iUomConvAmt,
            IStringUtil stringUtil,
            ISessionID iSessionID,
            IRaiseError raiseError,
            IGetumcf iGetumcf,
            IMathUtil mathUtil,
            ISQLValueComparerUtil sQLUtil,
            IMinQty iMinQty,
            IMsgApp iMsgApp,
            ILogger logger,
            // Streaming
            IDefineProcessVariable defineProcessVariable,
            IGetVariable getVariable,
            ISortOrderFactory sortOrderFactory,
            IQueryLanguage queryLanguage,
            ICache mgSessionVariableBasedCache,
            int recordCap,
            LoadType loadType,
            //CachePageSize pageSize,
            IRecordStreamFactory recordStreamFactory,
            IUnionUtil unionUtil,
            IHighString highString,
            IHighInt highInt,
            // Filter String
            ISqlFilter sqlFilter)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
            this.collectionNonTriggerInsertRequestFactory = collectionNonTriggerInsertRequestFactory;
            this.collectionNonTriggerUpdateRequestFactory = collectionNonTriggerUpdateRequestFactory;
            this.collectionNonTriggerDeleteRequestFactory = collectionNonTriggerDeleteRequestFactory;
            this.collectionLoadStatementRequestFactory = collectionLoadStatementRequestFactory;
            this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            this.collectionUpdateRequestFactory = collectionUpdateRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.iExpandKyByType = iExpandKyByType;
            this.scalarFunction = scalarFunction;
            this.existsChecker = existsChecker;
            this.convertToUtil = convertToUtil;
            this.variableUtil = variableUtil;
            this.iUomConvQty = iUomConvQty;
            this.iUomConvAmt = iUomConvAmt;
            this.stringUtil = stringUtil;
            this.iSessionID = iSessionID;
            this.raiseError = raiseError;
            this.iGetumcf = iGetumcf;
            this.mathUtil = mathUtil;
            this.sQLUtil = sQLUtil;
            this.iMinQty = iMinQty;
            this.iMsgApp = iMsgApp;
            this.logger = logger;
            // Streaming
            this.defineProcessVariable = defineProcessVariable;
            this.getVariable = getVariable;
            this.mgSessionVariableBasedCache = mgSessionVariableBasedCache;
            this.queryLanguage = queryLanguage;
            this.sortOrderFactory = sortOrderFactory;
            this.recordCap = recordCap;
            this.loadType = loadType;
            this.pageSize = Convert.ToInt32(pageSize);
            this.recordStreamFactory = recordStreamFactory;
            this.unionUtil = unionUtil;
            this.highString = highString;
            this.highInt = highInt;
            // Filter String
            this.sqlFilter = sqlFilter;
        }

        void LogTiming(string message)
        {
            var timing = DateTime.Now - startTime;
            logger.Performance(this.GetType().Name, $"{message} - {timing:c}");
            startTime = DateTime.Now;
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        CLM_GenerateAPTransactionsSp(
            string PVendNum,
            string PGenerateVoucher = "V",
            int? PCanEdi = 1,
            int? PShowEdi = 0,
            string CurrCode = null,
            string FilterString = null)
        {
            if (bunchedLoadCollection != null)
                bunchedLoadCollection.StartBunching();

            Guid? SessionId = this.iSessionID.SessionIDSp();

            try
            {
                ICollectionLoadResponse Data = null;
                startTime = DateTime.Now;

                // LOG TIMING
                LogTiming($"filter: {FilterString}");
                LogTiming($"start time: {startTime}");
                LogTiming($"record cap: {recordCap}");
                LogTiming($"page size: {pageSize}");

                #region Variable Declarations
                StringType _ALTGEN_SpName = DBNull.Value;
                string ALTGEN_SpName = null;
                int? Severity = 0;
                string Infobar = null;
                IntType _PGood = DBNull.Value;
                int? PGood = 0;
                int? PBad = 0;
                string EdiVinvGrnNum = null;
                decimal? EdiVinvItemOrigVchrQtyConv = null;
                string PoitemPoNum = null;
                int? PoitemPoLine = null;
                int? PoitemPoRelease = null;
                int? GrnLineGrnLine = null;
                RowPointerType _PochangeRowPointer = DBNull.Value;
                Guid? PochangeRowPointer = null;
                PoChangeStatusType _PochangeStat = DBNull.Value;
                string PochangeStat = null;
                DecimalPlacesType _InvparmsPlacesQtyUnit = DBNull.Value;
                int? InvparmsPlacesQtyUnit = null;
                DecimalPlacesType _CostPrcPlacesQtyUnit = DBNull.Value;
                int? CostPrcPlacesQtyUnit = null;
                int? MaxPoRelease = null;
                decimal? PoitemQtyToVoucher = null;
                ICollectionLoadResponse grn_lineCrsLoadResponseForCursor = null;
                int grn_lineCrs_CursorCounter = -1;
                #endregion

                // LOG TIMING
                LogTiming("Declaration of Variables");

                try
                {
                    if (existsChecker.Exists(tableName: "optional_module",
                        fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                        whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_GenerateAPTransactionsSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
                    {
                        // LOG TIMING
                        LogTiming("Exist Checker optional_module");

                        //this temp table is a table variable in old stored procedure version.
                        this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
                            [SpName] SYSNAME);
                        SELECT * into #tv_ALTGEN from @ALTGEN ");

                        #region CRUD LoadToRecord
                        var optional_module1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                                {
                                    {"SpName","CAST (NULL AS NVARCHAR)"},
                                    {"u0","[om].[ModuleName]"},
                                },
                            loadForChange: false,
                            lockingType: LockingType.None,
                            tableName: "optional_module",
                            fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                            whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_GenerateAPTransactionsSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                            orderByClause: collectionLoadRequestFactory.Clause(""));
                        var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
                        #endregion  LoadToRecord

                        #region CRUD InsertByRecords
                        foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                        {
                            optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("CLM_GenerateAPTransactionsSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
                        };

                        var optional_module1RequiredColumns = new List<string>() { "SpName" };

                        // LOG TIMING
                        LogTiming("InsertByRecords loop optional_module1LoadResponse");

                        optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

                        // LOG TIMING
                        LogTiming("ExtractRequiredColumns optional_module1LoadResponse");

                        var optional_module1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ALTGEN",
                            items: optional_module1LoadResponse.Items);

                        this.appDB.Insert(optional_module1InsertRequest);

                        // LOG TIMING
                        LogTiming("InsertByRecords appDb");
                        #endregion InsertByRecords

                        while (existsChecker.Exists(tableName: "#tv_ALTGEN",
                            fromClause: collectionLoadRequestFactory.Clause(""),
                            whereClause: collectionLoadRequestFactory.Clause("")))
                        {
                            #region CRUD LoadToVariable
                            var tv_ALTGEN1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                                    {
                                        {_ALTGEN_SpName,"[SpName]"},
                                    },
                                loadForChange: false,
                                lockingType: LockingType.None,
                                maximumRows: 1,
                                tableName: "#tv_ALTGEN",
                                fromClause: collectionLoadRequestFactory.Clause(""),
                                whereClause: collectionLoadRequestFactory.Clause(""),
                                orderByClause: collectionLoadRequestFactory.Clause(""));
                            var tv_ALTGEN1LoadResponse = this.appDB.Load(tv_ALTGEN1LoadRequest);
                            if (tv_ALTGEN1LoadResponse.Items.Count > 0)
                            {
                                ALTGEN_SpName = _ALTGEN_SpName;
                            }
                            #endregion  LoadToVariable

                            var ALTGEN = AltExtGen_CLM_GenerateAPTransactionsSp(ALTGEN_SpName,
                                PVendNum,
                                PGenerateVoucher,
                                PCanEdi,
                                PShowEdi,
                                CurrCode,
                                FilterString);
                            int? ALTGEN_Severity = ALTGEN.ReturnCode;

                            if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
                            {
                                return (ALTGEN.Data, ALTGEN_Severity);
                            }
                            this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
                            /*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
                            #region CRUD LoadToRecord
                            var tv_ALTGEN2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                                    {
                                        {"[SpName]","[SpName]"},
                                    },
                                loadForChange: true,
                                lockingType: LockingType.None,
                                tableName: "#tv_ALTGEN",
                                fromClause: collectionLoadRequestFactory.Clause(""),
                                whereClause: collectionLoadRequestFactory.Clause("[SpName] = {0}", ALTGEN_SpName),
                                orderByClause: collectionLoadRequestFactory.Clause(""));
                            var tv_ALTGEN2LoadResponse = this.appDB.Load(tv_ALTGEN2LoadRequest);
                            #endregion  LoadToRecord

                            #region CRUD DeleteByRecord
                            var tv_ALTGEN2DeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "#tv_ALTGEN",
                                items: tv_ALTGEN2LoadResponse.Items);
                            this.appDB.Delete(tv_ALTGEN2DeleteRequest);
                            #endregion DeleteByRecord

                            this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
                        }
                    }

                    if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_GenerateAPTransactionsSp") != null)
                    {
                        var EXTGEN = AltExtGen_CLM_GenerateAPTransactionsSp("dbo.EXTGEN_CLM_GenerateAPTransactionsSp",
                            PVendNum,
                            PGenerateVoucher,
                            PCanEdi,
                            PShowEdi,
                            CurrCode,
                            FilterString);
                        int? EXTGEN_Severity = EXTGEN.ReturnCode;

                        if (EXTGEN_Severity != 1)
                        {
                            return (EXTGEN.Data, EXTGEN_Severity);
                        }
                    }

                    // LOG TIMING
                    LogTiming("End of ALTGEN/EXTGEN");

                    //this temp table is a table variable in old stored procedure version.
                    this.sQLExpressionExecutor.Execute(@"DECLARE @TtGrnLine TABLE (
                        GrnNum          GrnNumType      ,
                        GrnLine         GrnLineType     ,
                        TcQtuQtyVoucher QtyUnitNoNegType);
                    SELECT * into #tv_TtGrnLine from @TtGrnLine ");

                    // LOG TIMING
                    LogTiming("sQLExpressionExecutor Declare #tv_TtGrnLine");

                    if (PVendNum != null)
                    {
                        PVendNum = this.iExpandKyByType.ExpandKyByTypeFn(
                            "VendNumType",
                            PVendNum);

                        // LOG TIMING
                        LogTiming("iExpandKyByType PVendNum");

                    }

                    //this temp table is a table variable in old stored procedure version.
                    this.sQLExpressionExecutor.Execute(@"DECLARE @poitems TABLE (
                        po_num                   PoNumType      ,
                        po_line                  PoLineType     ,
                        po_release               PoReleaseType  ,
                        item                     ItemType       ,
                        description              DescriptionType,
                        trans_nat                TransNatType   ,
                        trans_nat_2              TransNat2Type  ,
                        QtyReceived              QtyUnitType    ,
                        QtyToVoucher             QtyUnitType    ,
                        u_m                      UMType         ,
                        unit_mat_cost            CostPrcType    ,
                        plan_cost                CostPrcType    ,
                        vend_item                VendItemType   ,
                        terms_code               TermsCodeType  ,
                        fixed_rate               ListYesNoType  ,
                        exch_rate                ExchRateType   ,
                        grn_num                  GrnNumType     ,
                        grn_line                 GrnLineType    ,
                        po_RecordDate            DateType       ,
                        builder_po_orig_site     SiteType       ,
                        builder_po_num           PoNumType      ,
                        include_tax_in_cost      ListYesNoType  ,
                        non_inv_acct             AcctType       ,
                        non_inv_acct_description DescriptionType,
                        non_inv_acct_unit1       UnitCode1Type  ,
                        non_inv_acct_unit2       UnitCode2Type  ,
                        non_inv_acct_unit3       UnitCode3Type  ,
                        non_inv_acct_unit4       UnitCode4Type  ,
                        item_u_m                 UMType         );
                    SELECT * into #tv_poitems from @poitems ");

                    // LOG TIMING
                    LogTiming("sQLExpressionExecutor Declare #tv_poitems");

                    //this temp table is a table variable in old stored procedure version.
                    this.sQLExpressionExecutor.Execute(@"DECLARE @ums TABLE (
                        poitem_u_m      UMType          ,
                        item            ItemType        ,
                        uom_conv_factor UMConvFactorType);
                    SELECT * into #tv_ums from @ums ");

                    // LOG TIMING
                    LogTiming("sQLExpressionExecutor Declare #tv_ums");

                    //this temp table is a table variable in old stored procedure version.
                    this.sQLExpressionExecutor.Execute(@"DECLARE @VIN TABLE (
                        vend_inv_num VendInvNumType,
                        po_num       PoNumType     ,
                        seq_num      EdiSeqType    ,
                        grn_num      GrnNumType    );
                    SELECT * into #tv_VIN from @VIN ");

                    // LOG TIMING
                    LogTiming("sQLExpressionExecutor Declare #tv_VIN");

                    #region CRUD LoadToVariable
                    var invparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                        {
                            {_InvparmsPlacesQtyUnit,"places_qty_unit"},
                        },
                        loadForChange: false,
                        lockingType: LockingType.None,
                        tableName: "invparms",
                        fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                        whereClause: collectionLoadRequestFactory.Clause(""),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    var invparmsLoadResponse = this.appDB.Load(invparmsLoadRequest);
                    if (invparmsLoadResponse.Items.Count > 0)
                    {
                        InvparmsPlacesQtyUnit = _InvparmsPlacesQtyUnit;
                    }
                    #endregion  LoadToVariable

                    // LOG TIMING
                    LogTiming("LoadToVariable TABLE invparms VAR InvparmsPlacesQtyUnit");

                    #region CRUD LoadToVariable

                    var currencyLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                        {
                            {_CostPrcPlacesQtyUnit,"places_cp"},
                        },
                        loadForChange: false,
                        lockingType: LockingType.None,
                        tableName: "currency",
                        fromClause: collectionLoadRequestFactory.Clause(""),
                        whereClause: collectionLoadRequestFactory.Clause(" curr_code = {0}", CurrCode),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    var currencyLoadResponse = this.appDB.Load(currencyLoadRequest);
                    if (currencyLoadResponse.Items.Count > 0)
                    {
                        CostPrcPlacesQtyUnit = _CostPrcPlacesQtyUnit;
                    }
                    #endregion  LoadToVariable

                    // LOG TIMING
                    LogTiming("LoadToVariable TABLE currency VAR CostPrcPlacesQtyUnit");

                    if (sQLUtil.SQLEqual(PShowEdi, 0) == true)
                    {
                        // LOG TIMING
                        LogTiming($"IF PShowEdi=0");

                        #region Refactored - Use multiple nontrigger instead of UnionUtil

                        #region NonTriggerInsert

                        var tv_poitemsNonTriggerInsertRequest = collectionNonTriggerInsertRequestFactory.SQLInsert(
                            targetTableName: "#tv_poitems",
                            targetColumns: new List<string>()
                                {
                                   "po_num",
                                    "po_line",
                                    "po_release",
                                    "item",
                                    "description",
                                    "trans_nat",
                                    "trans_nat_2",
                                    "QtyReceived",
                                    "QtyToVoucher",
                                    "u_m",
                                    "unit_mat_cost",
                                    "plan_cost",
                                    "vend_item",
                                    "terms_code",
                                    "fixed_rate",
                                    "exch_rate",
                                    "grn_num",
                                    "grn_line",
                                    "po_RecordDate",
                                    "builder_po_orig_site",
                                    "builder_po_num",
                                    "include_tax_in_cost",
                                    "non_inv_acct",
                                    "non_inv_acct_description",
                                    "non_inv_acct_unit1",
                                    "non_inv_acct_unit2",
                                    "non_inv_acct_unit3",
                                    "non_inv_acct_unit4",
                                    "item_u_m",
                                },
                            valuesByExpressionToAssign: new Dictionary<string, IParameterizedCommand>()
                                {
                                   { "po_num", collectionNonTriggerInsertRequestFactory.Clause("poi.po_num") },
                                   { "po_line", collectionNonTriggerInsertRequestFactory.Clause("poi.po_line") },
                                   { "po_release", collectionNonTriggerInsertRequestFactory.Clause("poi.po_release") },
                                   { "item", collectionNonTriggerInsertRequestFactory.Clause("poi.item") },
                                   { "description", collectionNonTriggerInsertRequestFactory.Clause("poi.description") },
                                   { "trans_nat", collectionNonTriggerInsertRequestFactory.Clause("poi.trans_nat") },
                                   { "trans_nat_2", collectionNonTriggerInsertRequestFactory.Clause("poi.trans_nat_2") },
                                   { "QtyReceived", collectionNonTriggerInsertRequestFactory.Clause($"CASE WHEN {variableUtil.GetQuotedValue<string>(PGenerateVoucher)} = 'V' THEN poi.qty_received + poi.qty_returned ELSE poi.qty_returned END") },
                                   { "QtyToVoucher", collectionNonTriggerInsertRequestFactory.Clause($"(SELECT isnull(SUM(CASE WHEN {variableUtil.GetQuotedValue<string>(PGenerateVoucher)} = 'V' THEN po_rcpt.qty_received + po_rcpt.qty_returned - po_rcpt.qty_vouchered ELSE po_rcpt.qty_returned END), 0) FROM   po_rcpt WITH (READUNCOMMITTED) WHERE  po_rcpt.po_num = poi.po_num        AND po_rcpt.po_line = poi.po_line        AND po_rcpt.po_release = poi.po_release        AND po_rcpt.grn_num IS NULL        AND ISNULL(po_rcpt.grn_line, 0) = ISNULL({variableUtil.GetQuotedValue<int?>(GrnLineGrnLine)}, 0))") },
                                   { "u_m", collectionNonTriggerInsertRequestFactory.Clause("poi.u_m") },
                                   { "unit_mat_cost", collectionNonTriggerInsertRequestFactory.Clause("poi.unit_mat_cost") },
                                   { "plan_cost", collectionNonTriggerInsertRequestFactory.Clause("poi.plan_cost") },
                                   { "vend_item", collectionNonTriggerInsertRequestFactory.Clause("CASE WHEN poi.vend_item IS NOT NULL THEN poi.vend_item ELSE itemvend.vend_item END") },
                                   { "terms_code", collectionNonTriggerInsertRequestFactory.Clause("po.terms_code") },
                                   { "fixed_rate", collectionNonTriggerInsertRequestFactory.Clause("po.fixed_rate") },
                                   { "exch_rate", collectionNonTriggerInsertRequestFactory.Clause("po.exch_rate") },
                                   { "grn_num", collectionNonTriggerInsertRequestFactory.Clause("NULL") },
                                   { "grn_line", collectionNonTriggerInsertRequestFactory.Clause("NULL") },
                                   { "po_RecordDate", collectionNonTriggerInsertRequestFactory.Clause("po.RecordDate") },
                                   { "builder_po_orig_site", collectionNonTriggerInsertRequestFactory.Clause("po.builder_po_orig_site") },
                                   { "builder_po_num", collectionNonTriggerInsertRequestFactory.Clause("po.builder_po_num") },
                                   { "include_tax_in_cost", collectionNonTriggerInsertRequestFactory.Clause("po.include_tax_in_cost") },
                                   { "non_inv_acct", collectionNonTriggerInsertRequestFactory.Clause("poi.non_inv_acct") },
                                   { "non_inv_acct_description", collectionNonTriggerInsertRequestFactory.Clause("chart.description") },
                                   { "non_inv_acct_unit1", collectionNonTriggerInsertRequestFactory.Clause("poi.non_inv_acct_unit1") },
                                   { "non_inv_acct_unit2", collectionNonTriggerInsertRequestFactory.Clause("poi.non_inv_acct_unit2") },
                                   { "non_inv_acct_unit3", collectionNonTriggerInsertRequestFactory.Clause("poi.non_inv_acct_unit3") },
                                   { "non_inv_acct_unit4", collectionNonTriggerInsertRequestFactory.Clause("poi.non_inv_acct_unit4") },
                                   { "item_u_m", collectionNonTriggerInsertRequestFactory.Clause("item.u_m") },
                                },
                            fromClause: collectionNonTriggerInsertRequestFactory.Clause(@" poitem as poi with (readuncommitted) inner join po with (readuncommitted) on po.vend_num = {0}
                                and po.stat = 'o' left outer join chart with (readuncommitted) on poi.non_inv_acct = chart.acct left outer join item with (readuncommitted) on item.item = poi.item left outer join itemvend with (readuncommitted) on itemvend.vend_num = po.vend_num
                                and itemvend.item = poi.item", PVendNum),
                            whereClause: collectionNonTriggerInsertRequestFactory.Clause(" poi.po_num = po.po_num AND 1 = CASE WHEN {0} = 'V' AND poi.qty_received + poi.qty_returned - poi.qty_voucher > 0 THEN 1 WHEN {0} = 'A' AND poi.qty_returned > 0 THEN 1 ELSE 0 END AND po.curr_code = {1}", PGenerateVoucher, CurrCode),
                            orderByClause: collectionNonTriggerInsertRequestFactory.Clause("")
                            );

                        this.appDB.InsertWithoutTrigger(tv_poitemsNonTriggerInsertRequest);

                        // LOG TIMING
                        LogTiming($"UnionUtil to NonTrigger 1");

                        #endregion

                        #region NonTriggerInsert

                        var tv_poitems1NonTriggerInsertRequest = collectionNonTriggerInsertRequestFactory.SQLInsert(
                            targetTableName: "#tv_poitems",
                            targetColumns: new List<string>()
                                {
                                   "po_num",
                                    "po_line",
                                    "po_release",
                                    "item",
                                    "description",
                                    "trans_nat",
                                    "trans_nat_2",
                                    "QtyReceived",
                                    "QtyToVoucher",
                                    "u_m",
                                    "unit_mat_cost",
                                    "plan_cost",
                                    "vend_item",
                                    "terms_code",
                                    "fixed_rate",
                                    "exch_rate",
                                    "grn_num",
                                    "grn_line",
                                    "po_RecordDate",
                                    "builder_po_orig_site",
                                    "builder_po_num",
                                    "include_tax_in_cost",
                                    "non_inv_acct",
                                    "non_inv_acct_description",
                                    "non_inv_acct_unit1",
                                    "non_inv_acct_unit2",
                                    "non_inv_acct_unit3",
                                    "non_inv_acct_unit4",
                                    "item_u_m",
                                },
                            valuesByExpressionToAssign: new Dictionary<string, IParameterizedCommand>()
                                {
                                   { "po_num", collectionNonTriggerInsertRequestFactory.Clause("poi.po_num") },
                                   { "po_line", collectionNonTriggerInsertRequestFactory.Clause("poi.po_line") },
                                   { "po_release", collectionNonTriggerInsertRequestFactory.Clause("poi.po_release") },
                                   { "item", collectionNonTriggerInsertRequestFactory.Clause("poi.item") },
                                   { "description", collectionNonTriggerInsertRequestFactory.Clause("poi.description") },
                                   { "trans_nat", collectionNonTriggerInsertRequestFactory.Clause("poi.trans_nat") },
                                   { "trans_nat_2", collectionNonTriggerInsertRequestFactory.Clause("poi.trans_nat_2") },
                                   { "QtyReceived", collectionNonTriggerInsertRequestFactory.Clause($"(CASE WHEN {variableUtil.GetQuotedValue<string>(PGenerateVoucher)} = 'V' THEN grnl.qty_rec + poi.qty_returned ELSE poi.qty_returned END)") },
                                   { "QtyToVoucher", collectionNonTriggerInsertRequestFactory.Clause($"(SELECT isnull(SUM(CASE WHEN {variableUtil.GetQuotedValue<string>(PGenerateVoucher)} = 'V' THEN po_rcpt.qty_received + po_rcpt.qty_returned - po_rcpt.qty_vouchered ELSE po_rcpt.qty_returned END), 0) FROM   po_rcpt WITH (READUNCOMMITTED) WHERE  po_rcpt.po_num = poi.po_num        AND po_rcpt.po_line = poi.po_line        AND po_rcpt.po_release = poi.po_release        AND po_rcpt.grn_num = grnl.grn_num        AND po_rcpt.grn_line = grnl.grn_line)") },
                                   { "u_m", collectionNonTriggerInsertRequestFactory.Clause("poi.u_m") },
                                   { "unit_mat_cost", collectionNonTriggerInsertRequestFactory.Clause("poi.unit_mat_cost") },
                                   { "plan_cost", collectionNonTriggerInsertRequestFactory.Clause("poi.plan_cost") },
                                   { "vend_item", collectionNonTriggerInsertRequestFactory.Clause("(CASE WHEN poi.vend_item IS NOT NULL THEN poi.vend_item ELSE itemvend.vend_item END)") },
                                   { "terms_code", collectionNonTriggerInsertRequestFactory.Clause("po.terms_code") },
                                   { "fixed_rate", collectionNonTriggerInsertRequestFactory.Clause("po.fixed_rate") },
                                   { "exch_rate", collectionNonTriggerInsertRequestFactory.Clause("po.exch_rate") },
                                   { "grn_num", collectionNonTriggerInsertRequestFactory.Clause("grnl.grn_num") },
                                   { "grn_line", collectionNonTriggerInsertRequestFactory.Clause("grnl.grn_line") },
                                   { "po_RecordDate", collectionNonTriggerInsertRequestFactory.Clause("po.RecordDate") },
                                   { "builder_po_orig_site", collectionNonTriggerInsertRequestFactory.Clause("po.builder_po_orig_site") },
                                   { "builder_po_num", collectionNonTriggerInsertRequestFactory.Clause("po.builder_po_num") },
                                   { "include_tax_in_cost", collectionNonTriggerInsertRequestFactory.Clause("po.include_tax_in_cost") },
                                   { "non_inv_acct", collectionNonTriggerInsertRequestFactory.Clause("poi.non_inv_acct") },
                                   { "non_inv_acct_description", collectionNonTriggerInsertRequestFactory.Clause("chart.description") },
                                   { "non_inv_acct_unit1", collectionNonTriggerInsertRequestFactory.Clause("poi.non_inv_acct_unit1") },
                                   { "non_inv_acct_unit2", collectionNonTriggerInsertRequestFactory.Clause("poi.non_inv_acct_unit2") },
                                   { "non_inv_acct_unit3", collectionNonTriggerInsertRequestFactory.Clause("poi.non_inv_acct_unit3") },
                                   { "non_inv_acct_unit4", collectionNonTriggerInsertRequestFactory.Clause("poi.non_inv_acct_unit4") },
                                   { "item_u_m", collectionNonTriggerInsertRequestFactory.Clause("item.u_m") },
                                },
                            fromClause: collectionNonTriggerInsertRequestFactory.Clause(@" grn_hdr as grnh with (readuncommitted) inner join grn_line as grnl with (readuncommitted) on grnl.grn_num = grnh.grn_num inner join poitem as poi with (readuncommitted) on poi.po_num = grnl.po_num
                                and poi.po_line = grnl.po_line
                                and poi.po_release = grnl.po_release
                                and 1 = case when {0} = 'v'
                                and poi.qty_received + poi.qty_returned - poi.qty_voucher > 0 then 1 when {0} = 'a'
                                and poi.qty_returned > 0 then 1 else 0 end inner join po with (readuncommitted) on po.vend_num = grnh.vend_num
                                and po.stat = 'o'
                                and po.po_num = poi.po_num left outer join chart with (readuncommitted) on poi.non_inv_acct = chart.acct left outer join item with (readuncommitted) on item.item = poi.item left outer join itemvend with (readuncommitted) on itemvend.vend_num = po.vend_num
                                and itemvend.item = poi.item", PGenerateVoucher),
                            whereClause: collectionNonTriggerInsertRequestFactory.Clause(" grnh.vend_num = {0} AND grnh.stat = 'A' AND NOT EXISTS (SELECT 1 FROM #tv_poitems AS l WHERE poi.po_num = l.po_num AND poi.po_line = l.po_line AND poi.po_release = l.po_release AND poi.item = l.item AND poi.description = l.description AND poi.trans_nat = l.trans_nat AND poi.trans_nat_2 = l.trans_nat_2 AND QtyReceived = l.QtyReceived AND QtyToVoucher = l.QtyToVoucher AND poi.u_m = l.u_m AND poi.unit_mat_cost = l.unit_mat_cost AND poi.plan_cost = l.plan_cost AND vend_item = l.vend_item AND po.terms_code = l.terms_code AND po.fixed_rate = l.fixed_rate AND po.exch_rate = l.exch_rate AND grnl.grn_num = l.grn_num AND grnl.grn_line = l.grn_line AND po.RecordDate = l.po_RecordDate AND po.builder_po_orig_site = l.builder_po_orig_site AND po.builder_po_num = l.builder_po_num AND po.include_tax_in_cost = l.include_tax_in_cost AND poi.non_inv_acct = l.non_inv_acct AND non_inv_acct_description = l.non_inv_acct_description AND poi.non_inv_acct_unit1 = l.non_inv_acct_unit1 AND poi.non_inv_acct_unit2 = l.non_inv_acct_unit2 AND poi.non_inv_acct_unit3 = l.non_inv_acct_unit3 AND poi.non_inv_acct_unit4 = l.non_inv_acct_unit4 AND item_u_m = l.item_u_m)", PVendNum),
                            orderByClause: collectionNonTriggerInsertRequestFactory.Clause("")
                            );

                        this.appDB.InsertWithoutTrigger(tv_poitems1NonTriggerInsertRequest);

                        // LOG TIMING
                        LogTiming($"UnionUtil to NonTrigger 2");

                        #endregion

                        #endregion

                        #region NonTriggerInsert

                        var tv_umsNonTriggerInsertRequest = collectionNonTriggerInsertRequestFactory.SQLInsert(
                            targetTableName: "#tv_ums",
                            targetColumns: new List<string>()
                                {
                                    "poitem_u_m",
                                    "item"
                                },
                            valuesByExpressionToAssign: new Dictionary<string, IParameterizedCommand>()
                                {
                                    { "poitem_u_m", collectionNonTriggerInsertRequestFactory.Clause("u_m") },
                                    { "item", collectionNonTriggerInsertRequestFactory.Clause("item") },
                                },
                            fromClause: collectionNonTriggerInsertRequestFactory.Clause(" #tv_poitems"),
                            whereClause: collectionNonTriggerInsertRequestFactory.Clause(" u_m != item_u_m"),
                            orderByClause: collectionNonTriggerInsertRequestFactory.Clause(""),
                            distinct: true
                            );

                        this.appDB.InsertWithoutTrigger(tv_umsNonTriggerInsertRequest);

                        #endregion

                        // LOG TIMING
                        LogTiming("NonTriggerInsert TABLE #tv_ums tv_umsNonTriggerInsertRequest");

                        this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ums ADD tempTableId INT IDENTITY");

                        #region CRUD LoadToRecord
                        var tv_ums1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                                {
                                    {"uom_conv_factor","#tv_ums.uom_conv_factor"},
                                    {"u0","#tv_ums.poitem_u_m"},
                                    {"u1","#tv_ums.item"},
                                },
                            loadForChange: true,
                            lockingType: LockingType.UPDLock,
                            tableName: "#tv_ums",
                            fromClause: collectionLoadRequestFactory.Clause(""),
                            whereClause: collectionLoadRequestFactory.Clause(""),
                            orderByClause: collectionLoadRequestFactory.Clause(""));
                        var tv_ums1LoadResponse = this.appDB.Load(tv_ums1LoadRequest);
                        #endregion  LoadToRecord

                        // LOG TIMING
                        LogTiming($"LoadToRecord TABLE #tv_ums tv_ums1LoadResponse - data count: {tv_ums1LoadResponse.Items.Count}");

                        #region CRUD UpdateByRecord
                        foreach (var tv_ums1Item in tv_ums1LoadResponse.Items)
                        {
                            tv_ums1Item.SetValue<decimal?>("uom_conv_factor", this.iGetumcf.GetumcfFn(
                                    tv_ums1Item.GetDeletedValue<string>("u0"),
                                    tv_ums1Item.GetDeletedValue<string>("u1"),
                                    PVendNum,
                                    "P")
                                );
                        };

                        var tv_ums1RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#tv_ums",
                            items: tv_ums1LoadResponse.Items);

                        this.appDB.Update(tv_ums1RequestUpdate);
                        #endregion UpdateByRecord

                        // LOG TIMING
                        LogTiming($"UpdateByRecord TABLE #tv_ums tv_ums1RequestUpdate");

                        this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ums DROP COLUMN tempTableId");
                    }
                    else
                    {
                        // LOG TIMING
                        LogTiming($"IF PShowEdi=1");

                        if (sQLUtil.SQLEqual(PCanEdi, 1) == true && sQLUtil.SQLEqual(Severity, 0) == true)
                        {
                            // LOG TIMING
                            LogTiming($"IF PCanEdi=1");

                            #region NonTriggerInsert

                            var tv_VINNonTriggerInsertRequest = collectionNonTriggerInsertRequestFactory.SQLInsert(
                                targetTableName: "#tv_VIN",
                                targetColumns: new List<string>()
                                    {
                                        "vend_inv_num"
                                    },
                                valuesByExpressionToAssign: new Dictionary<string, IParameterizedCommand>()
                                    {
                                        { "vend_inv_num", collectionNonTriggerInsertRequestFactory.Clause("vend_inv_num") },
                                    },
                                fromClause: collectionNonTriggerInsertRequestFactory.Clause(" edi_vinv WITH (READUNCOMMITTED)"),
                                whereClause: collectionNonTriggerInsertRequestFactory.Clause(" edi_vinv.vend_num = {0}", PVendNum),
                                orderByClause: collectionNonTriggerInsertRequestFactory.Clause(""),
                                distinct: true
                                );

                            this.appDB.InsertWithoutTrigger(tv_VINNonTriggerInsertRequest);

                            #endregion

                            // LOG TIMING
                            LogTiming($"NonTriggerInsert TABLE #tv_VIN tv_VINInsertRequest");                            

                            this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_VIN ADD tempTableId INT IDENTITY");

                            #region NonTriggerUpdate
                            var tv_VIN1NonTriggerUpdateRequest = collectionNonTriggerUpdateRequestFactory.SQLUpdate(
                                tableName: "#tv_VIN",
                                expressionByColumnToAssign: new Dictionary<string, IParameterizedCommand>()
                                {
                                        { "po_num", collectionNonTriggerUpdateRequestFactory.Clause("buf1.po_num") },
                                        { "seq_num", collectionNonTriggerUpdateRequestFactory.Clause("buf1.seq_num") },
                                        { "grn_num", collectionNonTriggerUpdateRequestFactory.Clause("buf1.grn_num") },
                                },
                                fromClause: collectionNonTriggerUpdateRequestFactory.Clause(@" #tv_VIN as vin inner join (select vend_inv_num, 
                                        po_num, 
                                        seq_num, 
                                        grn_num 
                                     from   edi_vinv with (readuncommitted) 
                                     where  edi_vinv.vend_num = {0}) as buf1 on buf1.vend_inv_num = vin.vend_inv_num", PVendNum),
                                whereClause: collectionNonTriggerUpdateRequestFactory.Clause("")
                                );

                            this.appDB.UpdateWithoutTrigger(tv_VIN1NonTriggerUpdateRequest);
                            #endregion UpdateNonTrigger

                            // LOG TIMING
                            LogTiming($"UpdateNonTrigger TABLE #tv_VIN tv_VIN1NonTriggerUpdateRequest");

                            this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_VIN DROP COLUMN tempTableId");

                            #region NonTriggerInsert

                            var tv_ums2NonTriggerInsertRequest = collectionNonTriggerInsertRequestFactory.SQLInsert(
                                targetTableName: "#tv_ums",
                                targetColumns: new List<string>()
                                    {
                                        "poitem_u_m",
                                        "item"
                                    },
                                valuesByExpressionToAssign: new Dictionary<string, IParameterizedCommand>()
                                    {
                                        { "poitem_u_m", collectionNonTriggerInsertRequestFactory.Clause("poitem.u_m") },
                                        { "item", collectionNonTriggerInsertRequestFactory.Clause("poitem.item") },
                                    },
                                fromClause: collectionNonTriggerInsertRequestFactory.Clause(@" #tv_VIN AS vin 
                                         INNER JOIN 
                                         edi_vinv_item WITH (READUNCOMMITTED) 
                                         ON edi_vinv_item.po_num = vin.po_num 
                                            AND edi_vinv_item.seq_num = vin.seq_num 
                                         INNER JOIN 
                                         poitem WITH (READUNCOMMITTED) 
                                         ON poitem.po_num = edi_vinv_item.po_num 
                                            AND poitem.po_line = edi_vinv_item.po_line 
                                            AND poitem.po_release = edi_vinv_item.po_release 
                                         INNER JOIN 
                                         item WITH (READUNCOMMITTED) 
                                         ON item.item = poitem.item"),
                                whereClause: collectionNonTriggerInsertRequestFactory.Clause(" poitem.u_m != item.u_m"),
                                orderByClause: collectionNonTriggerInsertRequestFactory.Clause(""),
                                distinct: true
                                );

                            this.appDB.InsertWithoutTrigger(tv_ums2NonTriggerInsertRequest);

                            // LOG TIMING
                            LogTiming($"NonTriggerInsert TABLE #tv_ums tv_ums2NonTriggerInsertRequest");

                            #endregion

                            this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ums ADD tempTableId INT IDENTITY");

                            #region CRUD LoadToRecord
                            var tv_ums3LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                                        {
                                            {"uom_conv_factor","#tv_ums.uom_conv_factor"},
                                            {"u0","#tv_ums.poitem_u_m"},
                                            {"u1","#tv_ums.item"},
                                        },
                                loadForChange: true,
                                lockingType: LockingType.UPDLock,
                                tableName: "#tv_ums",
                                fromClause: collectionLoadRequestFactory.Clause(""),
                                whereClause: collectionLoadRequestFactory.Clause(""),
                                orderByClause: collectionLoadRequestFactory.Clause(""));
                            var tv_ums3LoadResponse = this.appDB.Load(tv_ums3LoadRequest);
                            #endregion  LoadToRecord

                            // LOG TIMING
                            LogTiming($"LoadToRecord TABLE #tv_ums tv_ums3LoadRequest - data count: {tv_ums3LoadResponse.Items.Count}");

                            #region CRUD UpdateByRecord
                            foreach (var tv_ums3Item in tv_ums3LoadResponse.Items)
                            {
                                tv_ums3Item.SetValue<decimal?>("uom_conv_factor", this.iGetumcf.GetumcfFn(
                                    tv_ums3Item.GetDeletedValue<string>("u0"),
                                    tv_ums3Item.GetDeletedValue<string>("u1"),
                                    PVendNum,
                                    "P"));
                            };

                            var tv_ums3RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#tv_ums",
                                items: tv_ums3LoadResponse.Items);

                            this.appDB.Update(tv_ums3RequestUpdate);
                            #endregion UpdateByRecord

                            // LOG TIMING
                            LogTiming($"UpdateByRecord TABLE #tv_ums tv_ums3RequestUpdate - data count: {tv_ums3RequestUpdate.Items.Count}");

                            this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ums DROP COLUMN tempTableId");

                            #region NonTriggerInsert

                            var tv_TtGrnLineNonTriggerInsertRequest = collectionNonTriggerInsertRequestFactory.SQLInsert(
                                targetTableName: "#tv_TtGrnLine",
                                targetColumns: new List<string>()
                                    {
                                        "GrnNum",
                                        "GrnLine",
                                        "TcQtuQtyVoucher"
                                    },
                                valuesByExpressionToAssign: new Dictionary<string, IParameterizedCommand>()
                                    {
                                        { "GrnNum", collectionNonTriggerInsertRequestFactory.Clause("{0}", "") },
                                        { "GrnLine", collectionNonTriggerInsertRequestFactory.Clause("{0}", 0) },
                                        { "TcQtuQtyVoucher", collectionNonTriggerInsertRequestFactory.Clause("edi_vinv_item.orig_vchr_qty_conv") }
                                    },
                                fromClause: collectionNonTriggerInsertRequestFactory.Clause(" #tv_VIN AS vin INNER JOIN edi_vinv_item ON edi_vinv_item.po_num = vin.po_num AND edi_vinv_item.seq_num = vin.seq_num"),
                                whereClause: collectionNonTriggerInsertRequestFactory.Clause(" isnull(vin.grn_num, '') = ''"),
                                orderByClause: collectionNonTriggerInsertRequestFactory.Clause("")
                                );

                            this.appDB.InsertWithoutTrigger(tv_TtGrnLineNonTriggerInsertRequest);

                            #endregion

                            // LOG TIMING
                            LogTiming("NonTriggerInsert TABLE #tv_TtGrnLine tv_TtGrnLineNonTriggerInsertRequest");

                            #region NonTriggerInsert

                            var tv_TtGrnLine1NonTriggerInsertRequest = collectionNonTriggerInsertRequestFactory.SQLInsert(
                               targetTableName: "#tv_TtGrnLine",
                               targetColumns: new List<string>()
                                   {
                                        "GrnNum",
                                        "GrnLine",
                                        "TcQtuQtyVoucher"
                                   },
                               valuesByExpressionToAssign: new Dictionary<string, IParameterizedCommand>()
                                   {
                                        { "GrnNum", collectionNonTriggerInsertRequestFactory.Clause("vin.grn_num") },
                                        { "GrnLine", collectionNonTriggerInsertRequestFactory.Clause("grn_line.grn_line") },
                                        { "TcQtuQtyVoucher", collectionNonTriggerInsertRequestFactory.Clause("edi_vinv_item.orig_vchr_qty_conv") }
                                   },
                               fromClause: collectionNonTriggerInsertRequestFactory.Clause(@" #tv_VIN AS vin inner join edi_vinv_item on edi_vinv_item.po_num = vin.po_num
                                        and edi_vinv_item.seq_num = vin.seq_num 
                                        and edi_vinv_item.po_release = 0 inner join grn_line on grn_line.grn_num = vin.grn_num 
                                        and grn_line.vend_num = {0}", PVendNum),
                               whereClause: collectionNonTriggerInsertRequestFactory.Clause("isnull(vin.grn_num, '') != ''"),
                               orderByClause: collectionNonTriggerInsertRequestFactory.Clause("")
                               );

                            this.appDB.InsertWithoutTrigger(tv_TtGrnLine1NonTriggerInsertRequest);


                            #endregion

                            // LOG TIMING
                            LogTiming("NonTriggerInsert TABLE #tv_TtGrnLine tv_TtGrnLine1NonTriggerInsertRequest");

                            #region Cursor Statement

                            #region CRUD LoadArbitrary
                            ICollectionLoadStatementRequest grn_numCrsLoadStatementRequestForCursor = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                                    {
                                        {"vin.grn_num","vin.grn_num"},
                                        {"grn_line.grn_line","grn_line.grn_line"},
                                        {"edi_vinv_item.po_num","edi_vinv_item.po_num"},
                                        {"edi_vinv_item.po_line","edi_vinv_item.po_line"},
                                        {"col4","dbo.UomConvQty(edi_vinv_item.orig_vchr_qty_conv, um.uom_conv_factor, 'To Base')"},
                                        {"col5","(SELECT max(po_release) FROM   poitem WITH (READUNCOMMITTED) WHERE  poitem.po_num = edi_vinv_item.po_num        AND edi_vinv_item.po_line = edi_vinv_item.po_line)"},
                                    },
                                selectStatement: collectionLoadRequestFactory.Clause(@"SELECT Distinct @selectList  
                                FROM #tv_VIN AS vin 
                                     INNER JOIN 
                                     edi_vinv_item WITH (READUNCOMMITTED) 
                                     ON edi_vinv_item.po_num = vin.po_num 
                                        AND edi_vinv_item.seq_num = vin.seq_num 
                                        AND edi_vinv_item.po_release > 0 
                                     INNER JOIN 
                                     grn_line WITH (READUNCOMMITTED) 
                                     ON grn_line.grn_num = vin.grn_num 
                                        AND grn_line.vend_num = {0} 
                                     INNER JOIN 
                                     poitem WITH (READUNCOMMITTED) 
                                     ON poitem.po_num = edi_vinv_item.po_num 
                                        AND poitem.po_line = edi_vinv_item.po_line 
                                        AND poitem.po_release = edi_vinv_item.po_release 
                                     LEFT OUTER JOIN 
                                     #tv_ums AS um 
                                     ON um.poitem_u_m = poitem.u_m 
                                        AND um.item = poitem.item 
                                WHERE isnull(vin.grn_num, '') != ''", PVendNum));

                            #endregion  LoadArbitrary

                            // LOG TIMING
                            LogTiming("LoadArbitrary CURSOR STATEMENT");

                            #endregion Cursor Statement

                            ICollectionLoadResponse grn_numCrsLoadResponseForCursor = this.appDB.Load(grn_numCrsLoadStatementRequestForCursor);
                            int grn_numCrs_CursorFetch_Status = grn_numCrsLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
                            int grn_numCrs_CursorCounter = -1;

                            // LOG TIMING
                            LogTiming($"CURSOR grn_numCrsLoadStatementRequestForCursor - data count: {grn_numCrsLoadResponseForCursor.Items.Count}");

                            // LOG TIMING
                            LogTiming("CURSOR - 1st WHILE");

                            while (sQLUtil.SQLEqual(1, 1) == true)
                            {
                                grn_numCrs_CursorCounter++;
                                if (grn_numCrsLoadResponseForCursor.Items.Count > grn_numCrs_CursorCounter)
                                {
                                    EdiVinvGrnNum = grn_numCrsLoadResponseForCursor.Items[grn_numCrs_CursorCounter].GetValue<string>(0);
                                    GrnLineGrnLine = grn_numCrsLoadResponseForCursor.Items[grn_numCrs_CursorCounter].GetValue<int?>(1);
                                    PoitemPoNum = grn_numCrsLoadResponseForCursor.Items[grn_numCrs_CursorCounter].GetValue<string>(2);
                                    PoitemPoLine = grn_numCrsLoadResponseForCursor.Items[grn_numCrs_CursorCounter].GetValue<int?>(3);
                                    EdiVinvItemOrigVchrQtyConv = grn_numCrsLoadResponseForCursor.Items[grn_numCrs_CursorCounter].GetValue<decimal?>(4);
                                    MaxPoRelease = grn_numCrsLoadResponseForCursor.Items[grn_numCrs_CursorCounter].GetValue<int?>(5);
                                }
                                grn_numCrs_CursorFetch_Status = (grn_numCrs_CursorCounter == grn_numCrsLoadResponseForCursor.Items.Count ? -1 : 0);

                                // LOG TIMING
                                LogTiming("CURSOR - 1st WHILE CURSOR COUNTER");

                                if (sQLUtil.SQLNotEqual(grn_numCrs_CursorFetch_Status, 0) == true)
                                {
                                    break;
                                }

                                #region Cursor Statement

                                #region CRUD LoadToRecord
                                ICollectionLoadRequest grn_lineCrsLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                                    {
                                        {"po_release","poitem.po_release"},
                                        {"col0","CAST (NULL AS DECIMAL)"},
                                        {"u0","poitem.qty_received"},
                                        {"u1","poitem.qty_returned"},
                                        {"u2","poitem.qty_voucher"},
                                    },
                                    loadForChange: false,
                                    lockingType: LockingType.None,
                                    tableName: "poitem",
                                    fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                                    whereClause: collectionLoadRequestFactory.Clause("poitem.po_num = {1} AND poitem.po_line = {0}", PoitemPoLine, PoitemPoNum),
                                    orderByClause: collectionLoadRequestFactory.Clause(" poitem.po_release"));
                                #endregion  LoadToRecord

                                // LOG TIMING
                                LogTiming($"CURSOR LoadToRecord TABLE poitem");

                                #endregion Cursor Statement

                                // LOG TIMING
                                LogTiming("CURSOR - 2nd WHILE");

                                while (sQLUtil.SQLEqual(1, 1) == true)
                                {
                                    grn_lineCrs_CursorCounter++;
                                    if (grn_lineCrsLoadResponseForCursor.Items.Count > grn_lineCrs_CursorCounter)
                                    {
                                        PoitemPoRelease = grn_lineCrsLoadResponseForCursor.Items[grn_lineCrs_CursorCounter].GetValue<int?>(0);
                                        PoitemQtyToVoucher = grn_lineCrsLoadResponseForCursor.Items[grn_lineCrs_CursorCounter].GetValue<decimal?>(1);
                                    }
                                    int grn_lineCrs_CursorFetch_Status = (grn_lineCrs_CursorCounter == grn_lineCrsLoadResponseForCursor.Items.Count ? -1 : 0);

                                    if (sQLUtil.SQLNotEqual(grn_lineCrs_CursorFetch_Status, 0) == true)
                                    {
                                        break;
                                    }

                                    decimal? TtGrnLineTcQtuQtyVoucher;
                                    if (sQLUtil.SQLEqual(PoitemPoRelease, MaxPoRelease) == true)
                                    {
                                        TtGrnLineTcQtuQtyVoucher = EdiVinvItemOrigVchrQtyConv;
                                    }
                                    else
                                    {
                                        TtGrnLineTcQtuQtyVoucher = this.iMinQty.MinQtyFn(
                                           EdiVinvItemOrigVchrQtyConv,
                                           PoitemQtyToVoucher);

                                        // LOG TIMING
                                        LogTiming("CURSOR iMinQty TtGrnLineTcQtuQtyVoucher");
                                    }

                                    // LOG TIMING
                                    LogTiming("CURSOR - 2nd WHILE CURSOR COUNTER");


                                    #region NonTriggerInsert

                                    var tv_TtGrnLine2NonTriggerInsertRequest = collectionNonTriggerInsertRequestFactory.SQLInsert(
                                        targetTableName: "#tv_TtGrnLine",
                                        targetColumns: new List<string>()
                                            {
                                                "GrnNum",
                                                "GrnLine",
                                                "TcQtuQtyVoucher"
                                            },
                                        valuesByExpressionToAssign: new Dictionary<string, IParameterizedCommand>()
                                            {
                                                { "GrnNum", collectionNonTriggerInsertRequestFactory.Clause("{0}", EdiVinvGrnNum) },
                                                { "GrnLine", collectionNonTriggerInsertRequestFactory.Clause("{0}", GrnLineGrnLine) },
                                                { "TcQtuQtyVoucher", collectionNonTriggerInsertRequestFactory.Clause("{0}", TtGrnLineTcQtuQtyVoucher) }
                                            },
                                            fromClause: collectionNonTriggerInsertRequestFactory.Clause(""),
                                            orderByClause: collectionNonTriggerInsertRequestFactory.Clause("")
                                        );

                                    this.appDB.InsertWithoutTrigger(tv_TtGrnLine2NonTriggerInsertRequest);

                                    #endregion

                                    // LOG TIMING
                                    LogTiming("NonTriggerInsert TABLE #tv_TtGrnLine tv_TtGrnLine2NonTriggerInsertRequest");

                                    EdiVinvItemOrigVchrQtyConv = (decimal?)(EdiVinvItemOrigVchrQtyConv - TtGrnLineTcQtuQtyVoucher);
                                    if (sQLUtil.SQLLessThanOrEqual(EdiVinvItemOrigVchrQtyConv, 0) == true)
                                    {
                                        break;
                                    }
                                }
                                //Deallocate Cursor grn_lineCrs

                                // LOG TIMING
                                LogTiming("CURSOR - END 2nd WHILE");

                                if (sQLUtil.SQLGreaterThan(EdiVinvItemOrigVchrQtyConv, 0) == true)
                                {
                                    #region NonTriggerInsert

                                    var tv_TtGrnLine3NonTriggerInsertRequest = collectionNonTriggerInsertRequestFactory.SQLInsert(
                                        targetTableName: "#tv_TtGrnLine",
                                        targetColumns: new List<string>()
                                            {
                                                "GrnNum",
                                                "GrnLine",
                                                "TcQtuQtyVoucher"
                                            },
                                        valuesByExpressionToAssign: new Dictionary<string, IParameterizedCommand>()
                                            {
                                                { "GrnNum", collectionNonTriggerInsertRequestFactory.Clause("{0}", EdiVinvGrnNum) },
                                                { "GrnLine", collectionNonTriggerInsertRequestFactory.Clause("{0}", GrnLineGrnLine) },
                                                { "TcQtuQtyVoucher", collectionNonTriggerInsertRequestFactory.Clause("{0}", EdiVinvItemOrigVchrQtyConv) }
                                            },
                                        fromClause: collectionNonTriggerInsertRequestFactory.Clause(""),
                                        whereClause: collectionNonTriggerInsertRequestFactory.Clause(""),
                                        orderByClause: collectionNonTriggerInsertRequestFactory.Clause("")
                                        );

                                    this.appDB.InsertWithoutTrigger(tv_TtGrnLine3NonTriggerInsertRequest);

                                    #endregion

                                    // LOG TIMING
                                    LogTiming("NonTriggerInsert table tv_TtGrnLine tv_TtGrnLine3NonTriggerInsertRequest");
                                }
                            }
                            //Deallocate Cursor grn_numCrs

                            // LOG TIMING
                            LogTiming("CURSOR - END 1st WHILE");

                            #region NonTriggerInsert

                            var tv_poitems2NonTriggerInsertRequest = collectionNonTriggerInsertRequestFactory.SQLInsert(
                                targetTableName: "#tv_poitems",
                                targetColumns: new List<string>()
                                    {
                                    "po_num",
                                    "po_line",
                                    "po_release",
                                    "item",
                                    "description",
                                    "trans_nat",
                                    "trans_nat_2",
                                    "QtyReceived",
                                    "QtyToVoucher",
                                    "u_m",
                                    "unit_mat_cost",
                                    "plan_cost",
                                    "vend_item",
                                    "terms_code",
                                    "fixed_rate",
                                    "exch_rate",
                                    "grn_num",
                                    "grn_line",
                                    "po_RecordDate",
                                    "builder_po_orig_site",
                                    "builder_po_num",
                                    "include_tax_in_cost",
                                    "non_inv_acct",
                                    "non_inv_acct_description",
                                    "non_inv_acct_unit1",
                                    "non_inv_acct_unit2",
                                    "non_inv_acct_unit3",
                                    "non_inv_acct_unit4",
                                    "item_u_m",
                                    },
                                valuesByExpressionToAssign: new Dictionary<string, IParameterizedCommand>()
                                    {
                                    { "po_num", collectionNonTriggerInsertRequestFactory.Clause("poitem.po_num") },
                                    { "po_line", collectionNonTriggerInsertRequestFactory.Clause("poitem.po_line") },
                                    { "po_release", collectionNonTriggerInsertRequestFactory.Clause("poitem.po_release") },
                                    { "item", collectionNonTriggerInsertRequestFactory.Clause("poitem.item") },
                                    { "description", collectionNonTriggerInsertRequestFactory.Clause("poitem.description") },
                                    { "trans_nat", collectionNonTriggerInsertRequestFactory.Clause("poitem.trans_nat") },
                                    { "trans_nat_2", collectionNonTriggerInsertRequestFactory.Clause("poitem.trans_nat_2") },
                                    { "QtyReceived", collectionNonTriggerInsertRequestFactory.Clause("(SELECT isnull(SUM(po_rcpt.qty_received + po_rcpt.qty_returned - po_rcpt.qty_vouchered), 0) FROM   po_rcpt WITH (READUNCOMMITTED) WHERE  po_rcpt.po_num = poitem.po_num        AND po_rcpt.po_line = poitem.po_line        AND po_rcpt.po_release = poitem.po_release        AND ISNULL(po_rcpt.grn_num, '') = ISNULL(vin.grn_num, '')        AND ISNULL(po_rcpt.grn_line, 0) = ISNULL(ttgl.GrnLine, 0))") },
                                    { "QtyToVoucher", collectionNonTriggerInsertRequestFactory.Clause($"round(ttgl.TcQtuQtyVoucher, {InvparmsPlacesQtyUnit})") },
                                    { "u_m", collectionNonTriggerInsertRequestFactory.Clause("poitem.u_m") },
                                    { "unit_mat_cost", collectionNonTriggerInsertRequestFactory.Clause("edi_vinv_item.orig_unit_cost_conv") },
                                    { "plan_cost", collectionNonTriggerInsertRequestFactory.Clause("poitem.plan_cost") },
                                    { "vend_item", collectionNonTriggerInsertRequestFactory.Clause("CASE WHEN poitem.vend_item IS NOT NULL THEN poitem.vend_item ELSE itemvend.vend_item END") },
                                    { "terms_code", collectionNonTriggerInsertRequestFactory.Clause("po.terms_code") },
                                    { "fixed_rate", collectionNonTriggerInsertRequestFactory.Clause("po.fixed_rate") },
                                    { "exch_rate", collectionNonTriggerInsertRequestFactory.Clause("po.exch_rate") },
                                    { "grn_num", collectionNonTriggerInsertRequestFactory.Clause("vin.grn_num") },
                                    { "grn_line", collectionNonTriggerInsertRequestFactory.Clause("ttgl.GrnLine") },
                                    { "po_RecordDate", collectionNonTriggerInsertRequestFactory.Clause("po.RecordDate") },
                                    { "builder_po_orig_site", collectionNonTriggerInsertRequestFactory.Clause("po.builder_po_orig_site") },
                                    { "builder_po_num", collectionNonTriggerInsertRequestFactory.Clause("po.builder_po_num") },
                                    { "include_tax_in_cost", collectionNonTriggerInsertRequestFactory.Clause("po.include_tax_in_cost") },
                                    { "non_inv_acct", collectionNonTriggerInsertRequestFactory.Clause("poitem.non_inv_acct") },
                                    { "non_inv_acct_description", collectionNonTriggerInsertRequestFactory.Clause("chart.description") },
                                    { "non_inv_acct_unit1", collectionNonTriggerInsertRequestFactory.Clause("poitem.non_inv_acct_unit1") },
                                    { "non_inv_acct_unit2", collectionNonTriggerInsertRequestFactory.Clause("poitem.non_inv_acct_unit2") },
                                    { "non_inv_acct_unit3", collectionNonTriggerInsertRequestFactory.Clause("poitem.non_inv_acct_unit3") },
                                    { "non_inv_acct_unit4", collectionNonTriggerInsertRequestFactory.Clause("poitem.non_inv_acct_unit4") },
                                    { "item_u_m", collectionNonTriggerInsertRequestFactory.Clause("item.u_m") },
                                    },
                                fromClause: collectionNonTriggerInsertRequestFactory.Clause(@"#tv_VIN AS vin 
                                    INNER JOIN 
                                    edi_vinv_item WITH (READUNCOMMITTED) 
                                    ON edi_vinv_item.po_num = vin.po_num 
                                       AND edi_vinv_item.seq_num = vin.seq_num 
                                    INNER JOIN 
                                    po WITH (READUNCOMMITTED) 
                                    ON po.po_num = vin.po_num 
                                       AND po.stat = 'O' 
                                    INNER JOIN 
                                    poitem WITH (READUNCOMMITTED) 
                                    ON poitem.po_num = edi_vinv_item.po_num 
                                       AND poitem.po_line = edi_vinv_item.po_line 
                                       AND poitem.po_release = edi_vinv_item.po_release 
                                    LEFT OUTER JOIN 
                                    chart WITH (READUNCOMMITTED) 
                                    ON poitem.non_inv_acct = chart.acct 
                                    LEFT OUTER JOIN 
                                    item WITH (READUNCOMMITTED) 
                                    ON item.item = poitem.item 
                                    LEFT OUTER JOIN 
                                    itemvend WITH (READUNCOMMITTED) 
                                    ON itemvend.vend_num = po.vend_num 
                                       AND itemvend.item = poitem.item INNER JOIN #tv_TtGrnLine AS ttgl ON isnull(ttgl.GrnNum, '') = isnull(vin.grn_num, '')"),
                                whereClause: collectionNonTriggerInsertRequestFactory.Clause(""),
                                orderByClause: collectionNonTriggerInsertRequestFactory.Clause(""),
                                distinct: true
                                );

                            this.appDB.InsertWithoutTrigger(tv_poitems2NonTriggerInsertRequest);

                            #endregion

                            // LOG TIMING
                            LogTiming("NonTriggerInsert tv_poitems2NonTriggerInsertRequest");
                        }
                    }

                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_poitems ADD tempTableId INT IDENTITY");
                    /*Needs to load at least one column from the table: #tv_poitems for delete, Loads the record based on its where and from clause, then deletes it by record.*/

                    #region NonTriggerDelete
                    var tv_poitemsNonTriggerDeleteRequest = collectionNonTriggerDeleteRequestFactory.SQLDelete(
                            tableName: "#tv_poitems",
                            fromClause: collectionNonTriggerUpdateRequestFactory.Clause(""),
                            whereClause: collectionNonTriggerUpdateRequestFactory.Clause("round(QtyToVoucher, {0}) <= 0", InvparmsPlacesQtyUnit)
                        );

                    this.appDB.DeleteWithoutTrigger(tv_poitemsNonTriggerDeleteRequest);
                    #endregion

                    // LOG TIMING
                    LogTiming("NonTriggerDelete #tv_poitems tv_poitemsNonTriggerDeleteRequest");

                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_poitems DROP COLUMN tempTableId");

                    #region CRUD LoadToVariable
                    var pochangeLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                        {
                            {_PochangeRowPointer,"pochange.RowPointer"},
                            {_PochangeStat,"pochange.stat"},
                        },
                        loadForChange: false,
                        lockingType: LockingType.None,
                        maximumRows: 1,
                        tableName: "pochange",
                        fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                        whereClause: collectionLoadRequestFactory.Clause($"pochange.po_num IN (SELECT DISTINCT po_num FROM #tv_poitems)"),
                        orderByClause: collectionLoadRequestFactory.Clause(" chg_num DESC"));

                    var pochangeLoadResponse = this.appDB.Load(pochangeLoadRequest);
                    if (pochangeLoadResponse.Items.Count > 0)
                    {
                        PochangeRowPointer = _PochangeRowPointer;
                        PochangeStat = _PochangeStat;
                    }
                    #endregion  LoadToVariable

                    // LOG TIMING
                    LogTiming($"LoadToVariable TABLE pochange VAR PochangeRowPointer, PochangeStat - data count: {pochangeLoadResponse.Items.Count}");

                    if (PochangeRowPointer != null && sQLUtil.SQLNotEqual(PochangeStat, "P") == true)
                    {
                        if (Infobar == null)
                        {
                            #region CRUD ExecuteMethodCall

                            var MsgApp = this.iMsgApp.MsgAppSp(
                                Infobar: Infobar,
                                BaseMsg: "I=ExistFor<>",
                                Parm1: "@pochange",
                                Parm2: "@pochange.stat",
                                Parm3: "@:PoChangeStatus:P");
                            Infobar = MsgApp.Infobar;

                            #endregion ExecuteMethodCall

                            // LOG TIMING
                            LogTiming($"ExecuteMethodCall MsgApp");
                        }
                    }

                    #region CRUD LoadToVariable
                    var tv_poitems5LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                        {
                            {_PGood,"count(DISTINCT po_num)"},
                        },
                        loadForChange: false,
                        lockingType: LockingType.None,
                        tableName: "#tv_poitems",
                        fromClause: collectionLoadRequestFactory.Clause(""),
                        whereClause: collectionLoadRequestFactory.Clause(""),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    var tv_poitems5LoadResponse = this.appDB.Load(tv_poitems5LoadRequest);
                    if (tv_poitems5LoadResponse.Items.Count > 0)
                    {
                        PGood = _PGood;
                    }
                    #endregion  LoadToVariable

                    // LOG TIMING
                    LogTiming($"LoadToVariable TABLE #tv_poitems VAR PGood");

                    #region Filter String 

                    string propertyList = "BuilderPoNum;BuilderPoOrigSite;DerExchRate;DerFixedRate;DerIncludeTaxInPrice;GrnLine;GrnNum;Item;ItemDescription;NonInvAcct;NonInvAcctDesc;NonInvAcctUnit1;NonInvAcctUnit2;NonInvAcctUnit3;NonInvAcctUnit4;PoLine;PoNum;PoRelease;TermsCode;TransNat;TransNat2;UM";
                    string columnList = "poi.builder_po_num;poi.builder_po_orig_site;poi.exch_rate;poi.fixed_rate;poi.include_tax_in_cost;poi.grn_line;poi.grn_num;poi.item;poi.description;poi.non_inv_acct;poi.non_inv_acct_description;poi.non_inv_acct_unit1;poi.non_inv_acct_unit2;poi.non_inv_acct_unit3;poi.non_inv_acct_unit4;poi.po_line;poi.po_num;poi.po_release;poi.terms_code;poi.trans_nat;poi.trans_nat_2;poi.u_m";

                    FilterString = stringUtil.IsNull(
                        sqlFilter.SqlFilterFn(
                            FilterString,
                            propertyList,
                            columnList,
                            ";"),
                        "");

                    LogTiming($"SqlFilterFn: {FilterString}");

                    #endregion

                    #region Streaming

                    #region CRUD LoadToRecord
                    var tv_poitems6LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                        {
                            {"ConnectionId","CAST (NULL AS NVARCHAR)"},
                            {"Type","CAST (NULL AS NVARCHAR)"},
                            {"poi.grn_num","poi.grn_num"},  // filter
                            {"poi.grn_line","poi.grn_line"},  // filter
                            {"poi.po_num","poi.po_num"},  // filter
                            {"poi.po_line","poi.po_line"},  // filter
                            {"poi.po_release","poi.po_release"},  // filter
                            {"poi.item","poi.item"},  // filter
                            {"poi.description","poi.description"},  // filter
                            {"poi.trans_nat","poi.trans_nat"},  // filter
                            {"poi.trans_nat_2","poi.trans_nat_2"},  // filter
                            {"poi.u_m","poi.u_m"},  // filter
                            {"poi.terms_code","poi.terms_code"},  // filter
                            {"QtuQtyReceived","CAST (NULL AS DECIMAL)"}, // filter - NOT INCLUDED
                            {"QtuQtyVoucher","CAST (NULL AS DECIMAL)"},
                            {"OrigQtuQtyVoucher","CAST (NULL AS DECIMAL)"},  // filter - NOT INCLUDED
                            {"poi.unit_mat_cost","poi.unit_mat_cost"},
                            {"CprItemCostConv","CAST (NULL AS DECIMAL)"},  // filter - NOT INCLUDED 
                            {"CprPlanCostConv","CAST (NULL AS DECIMAL)"},  // filter - NOT INCLUDED
                            {"DerEdiVoucher","CAST (NULL AS INT)"},
                            {"vin.vend_inv_num","vin.vend_inv_num"},
                            {"DerReadOnlyRow","CAST (NULL AS INT)"},
                            {"poi.po_RecordDate","poi.po_RecordDate"},
                            {"RowPointer","CAST(NULL AS NVARCHAR)"},
                            {"poi.fixed_rate","poi.fixed_rate"},  // filter
                            {"poi.exch_rate","poi.exch_rate"},  // filter
                            {"SelectDeniedReadOnlyFlag","CAST (NULL AS INT)"},
                            {"poi.vend_item","poi.vend_item"},
                            {"poi.builder_po_orig_site","poi.builder_po_orig_site"},  // filter
                            {"poi.builder_po_num","poi.builder_po_num"},  // filter
                            {"poi.include_tax_in_cost","poi.include_tax_in_cost"}, // filter
                            {"poi.non_inv_acct","poi.non_inv_acct"},  // filter
                            {"poi.non_inv_acct_description","poi.non_inv_acct_description"},  // filter
                            {"poi.non_inv_acct_unit1","poi.non_inv_acct_unit1"},  // filter
                            {"poi.non_inv_acct_unit2","poi.non_inv_acct_unit2"},  // filter 
                            {"poi.non_inv_acct_unit3","poi.non_inv_acct_unit3"}, // filter
                            {"poi.non_inv_acct_unit4","poi.non_inv_acct_unit4"}, // filter
                            {"DerItemExists","CAST (NULL AS INT)"},
                            {"poi.QtyReceived","poi.QtyReceived"},
                            {"um.uom_conv_factor","um.uom_conv_factor"},
                            {"poi.QtyToVoucher","poi.QtyToVoucher"},
                            {"poi.plan_cost","poi.plan_cost"},
                            {"poi.item_u_m","poi.item_u_m"},
                        },
                        loadForChange: false,
                        lockingType: LockingType.None,
                        tableName: "#tv_poitems",
                        fromClause: collectionLoadRequestFactory.Clause(@" AS poi LEFT OUTER JOIN #tv_ums AS um ON um.poitem_u_m = poi.u_m 
                                AND um.item = poi.item LEFT OUTER JOIN #tv_VIN AS vin on vin.po_num = poi.po_num"),

                        whereClause: collectionLoadRequestFactory.Clause(FilterString),
                        orderByClause: collectionLoadRequestFactory.Clause(" poi.po_num, poi.po_line, poi.po_release, poi.grn_num, poi.grn_line"));
                    #endregion  LoadToRecord

                    // LOG TIMING
                    LogTiming($"LoadToRecord TABLE #tv_poitems for Streaming");

                    // Bunching
                    // Build sort order, it will be used in bookmark.
                    // Sort order columns should include all key columns and order by columns.
                    Dictionary<string, SortOrderDirection> dictvPoItemsSortOrder = new Dictionary<string, SortOrderDirection>
                    {
                        { "poi.po_num", SortOrderDirection.Ascending },
                        { "poi.po_line", SortOrderDirection.Ascending },
                        { "poi.po_release", SortOrderDirection.Ascending },
                        { "poi.grn_num", SortOrderDirection.Ascending },
                        { "poi.grn_line", SortOrderDirection.Ascending }
                    };
                    ISortOrder tvPoItemsSortOrder = sortOrderFactory.Create(dictvPoItemsSortOrder);

                    ProcessStreaming(PCanEdi, PShowEdi, SessionId, InvparmsPlacesQtyUnit, CostPrcPlacesQtyUnit, tv_poitems6LoadRequest, tvPoItemsSortOrder);

                    Data = unionUtil.Process();

                    LogTiming($"unionUtil Process");

                    #endregion

                    if (sQLUtil.SQLNotEqual(Severity, 0) == true)
                    {
                        raiseError.RaiseErrorSp(
                            Infobar,
                            16);

                        var resultTableLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                                {
                                    {"ConnectionId","CAST (NULL AS NVARCHAR)"},
                                    {"Type","CAST (NULL AS NVARCHAR)"},
                                    {"GrnNum","poi.grn_num"},
                                    {"GrnLine","poi.grn_line"},
                                    {"PoNum","poi.po_num"},
                                    {"PoLine","poi.po_line"},
                                    {"PoRelease","poi.po_release"},
                                    {"Item","poi.item"},
                                    {"ItemDescription","poi.description"},
                                    {"TransNat","poi.trans_nat"},
                                    {"TransNat2","poi.trans_nat_2"},
                                    {"UM","poi.u_m"},
                                    {"TermsCode","poi.terms_code"},
                                    {"QtuQtyReceived","CAST (NULL AS DECIMAL)"},
                                    {"QtuQtyVoucher","CAST (NULL AS DECIMAL)"},
                                    {"OrigQtuQtyVoucher","CAST (NULL AS DECIMAL)"},
                                    {"TcCprItemCost","poi.unit_mat_cost"},
                                    {"CprItemCostConv","CAST (NULL AS DECIMAL)"},
                                    {"CprPlanCostConv","CAST (NULL AS DECIMAL)"},
                                    {"DerEdiVoucher","CAST (NULL AS INT)"},
                                    {"DerVendorEDIInvoice","CAST (NULL AS NVARCHAR)"},
                                    {"DerReadOnlyRow","CAST (NULL AS INT)"},
                                    {"PoRecordDate","poi.po_RecordDate"},
                                    {"RowPointer","CAST(NULL AS NVARCHAR)"},
                                    {"DerFixedRate","poi.fixed_rate"},
                                    {"DerExchRate","poi.exch_rate"},
                                    {"SelectDeniedReadOnlyFlag","CAST (NULL AS INT)"},
                                    {"VendItem","poi.vend_item"},
                                    {"BuilderPoOrigSite","poi.builder_po_orig_site"},
                                    {"BuilderPoNum","poi.builder_po_num"},
                                    {"DerIncludeTaxInPrice","poi.include_tax_in_cost"},
                                    {"NonInvAcct","poi.non_inv_acct"},
                                    {"NonInvAcctDesc","poi.non_inv_acct_description"},
                                    {"NonInvAcctUnit1","poi.non_inv_acct_unit1"},
                                    {"NonInvAcctUnit2","poi.non_inv_acct_unit2"},
                                    {"NonInvAcctUnit3","poi.non_inv_acct_unit3"},
                                    {"NonInvAcctUnit4","poi.non_inv_acct_unit4"},
                                    {"DerItemExists","CAST (NULL AS INT)"},
                                },
                        loadForChange: false,
                        lockingType: LockingType.None,
                        tableName: "#tv_poitems",
                        fromClause: collectionLoadRequestFactory.Clause(" as poi"),
                        whereClause: collectionLoadRequestFactory.Clause("1 = 2"),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                        var resultTableLoadResponse = this.appDB.Load(resultTableLoadRequest);

                        Data = resultTableLoadResponse;

                        // LOG TIMING
                        LogTiming("RaiseErrorSp");
                    }

                    Infobar = null;

                    #region CRUD ExecuteMethodCall

                    var MsgApp1 = this.iMsgApp.MsgAppSp(
                        Infobar: Infobar,
                        BaseMsg: "I=#Processed",
                        Parm1: convertToUtil.ToString(PGood),
                        Parm2: "@po");
                    Severity = MsgApp1.ReturnCode;
                    Infobar = MsgApp1.Infobar;

                    #endregion ExecuteMethodCall

                    // LOG TIMING
                    LogTiming($"MsgApp1");

                    if (sQLUtil.SQLGreaterThan(PBad, 0) == true)
                    {
                        Infobar = null;

                        #region CRUD ExecuteMethodCall

                        var MsgApp2 = this.iMsgApp.MsgAppSp(
                            Infobar: Infobar,
                            BaseMsg: "I=#Partial",
                            Parm1: convertToUtil.ToString(PBad),
                            Parm2: "@po");
                        Severity = MsgApp2.ReturnCode;
                        Infobar = MsgApp2.Infobar;

                        #endregion ExecuteMethodCall

                        // LOG TIMING
                        LogTiming($"MsgApp2");
                    }

                    #region Bookmark
                    if (recordCap > 0 && Data.Items.Count > recordCap)
                    {
                        defineProcessVariable.DefineProcessVariableSp("RecordCap", (Data.Items.Count - 1).ToString(), null);
                        // LOG TIMING
                        LogTiming($"defineProcessVariable {Data.Items.Count - 1}");

                        (int? returnCode, string variableValue, string infobar) = getVariable.GetVariableSp("MyReport_Rpt", "", 0, "", "");
                        // LOG TIMING
                        LogTiming($"variableValue {variableValue}");

                        defineProcessVariable.DefineProcessVariableSp("Bookmark", variableValue, infobar);
                    }
                    bunchedLoadCollection.EndBunching();
                    #endregion

                    // LOG TIMING
                    LogTiming($"END {Data.Items.Count}");
                }
                catch (Exception ex)
                {
                    LogTiming($"error {ex.Message}");
                    Severity = 16;
                }

                return (Data, Severity);
            }
            finally
            {

            }
        }

        private void ProcessStreaming(
            int? PCanEdi,
            int? PShowEdi,
            Guid? SessionId,
            int? InvparmsPlacesQtyUnit,
            int? CostPrcPlacesQtyUnit,
            ICollectionLoadRequest tv_poitems6LoadRequest,
            ISortOrder tvPoItemsSortOrder)
        {
            // LOG TIMING
            //LogTiming($"Start Streaming");
            LogTiming($"Start Streaming PCanEdi={PCanEdi}, PShowEdi={PShowEdi}");

            #region Streaming Variables
            decimal? voucher_QtuQtyReceived;
            decimal? voucher_QtuQtyVoucher;
            decimal? voucher_OrigQtuQtyVoucher;
            decimal? voucher_CprItemCostConv;
            decimal? voucher_CprPlanCostConv;
            decimal? voucher_UomConvFactor;
            int? voucher_DerItemExists;
            #endregion

            using (IRecordStream sQLPagedRecordStream = recordStreamFactory.Create(appDB, queryLanguage, mgSessionVariableBasedCache,
                collectionLoadRequestFactory, tv_poitems6LoadRequest, tvPoItemsSortOrder, SQLPagedRecordStreamBookmarkID.MyReport_Rpt, pageSize, loadType))
            {
                // LOG TIMING
                LogTiming($"START Streaming While Loop");

                while (sQLPagedRecordStream.Read())
                {
                    var voucherItem = sQLPagedRecordStream.Current;
                    LogTiming($"Streaming While Loop-item: {voucherItem.GetValue<string>("poi.item")}");                    

                    #region Assign Values
                    voucher_UomConvFactor = voucherItem.GetValue<decimal?>("um.uom_conv_factor");
                    voucher_QtuQtyReceived = mathUtil.Round<decimal?>(this.iUomConvQty.UomConvQtyFn(
                        voucherItem.GetValue<decimal?>("poi.QtyReceived"),
                        stringUtil.IsNull(
                            voucher_UomConvFactor,
                            1M),
                        "FROM Base"), InvparmsPlacesQtyUnit);
                    voucher_QtuQtyVoucher = mathUtil.Round<decimal?>(this.iUomConvQty.UomConvQtyFn(
                        voucherItem.GetValue<decimal?>("poi.QtyToVoucher"),
                        stringUtil.IsNull(
                            voucher_UomConvFactor,
                            1M),
                        "FROM Base"), InvparmsPlacesQtyUnit);
                    voucher_OrigQtuQtyVoucher = mathUtil.Round<decimal?>(this.iUomConvQty.UomConvQtyFn(
                        voucherItem.GetValue<decimal?>("poi.QtyToVoucher"),
                        stringUtil.IsNull(
                            voucher_UomConvFactor,
                            1M),
                        "FROM Base"), InvparmsPlacesQtyUnit);
                    voucher_CprItemCostConv = mathUtil.Round<decimal?>(this.iUomConvAmt.UomConvAmtFn(
                        voucherItem.GetValue<decimal?>("poi.unit_mat_cost"),
                        stringUtil.IsNull(
                            voucher_UomConvFactor,
                            1M),
                        "FROM Base"), CostPrcPlacesQtyUnit);
                    voucher_CprPlanCostConv = mathUtil.Round<decimal?>(this.iUomConvAmt.UomConvAmtFn(
                        voucherItem.GetValue<decimal?>("poi.plan_cost"),
                        stringUtil.IsNull(
                            voucher_UomConvFactor,
                            1M),
                        "FROM Base"), CostPrcPlacesQtyUnit);
                    voucher_DerItemExists = voucherItem.GetValue<string>("poi.item_u_m") == null ? 0 : 1;
                    #endregion

                    #region CRUD LoadResponseWithoutTable
                    var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
                    {
                        {"ConnectionId",SessionId},
                        {"Type","M"},
                        {"GrnNum",voucherItem.GetValue<string>("poi.grn_num")},
                        {"GrnLine",voucherItem.GetValue<int?>("poi.grn_line")},
                        {"PoNum",voucherItem.GetValue<string>("poi.po_num")},
                        {"PoLine",voucherItem.GetValue<int?>("poi.po_line")},
                        {"PoRelease",voucherItem.GetValue<int?>("poi.po_release")},
                        {"Item",voucherItem.GetValue<string>("poi.item")},
                        {"ItemDescription",voucherItem.GetValue<string>("poi.description")},
                        {"TransNat",voucherItem.GetValue<string>("poi.trans_nat")},
                        {"TransNat2",voucherItem.GetValue<string>("poi.trans_nat_2")},
                        {"UM",voucherItem.GetValue<string>("poi.u_m")},
                        {"TermsCode",voucherItem.GetValue<string>("poi.terms_code")},
                        {"QtuQtyReceived",voucher_QtuQtyReceived},
                        {"QtuQtyVoucher",voucher_QtuQtyVoucher},
                        {"OrigQtuQtyVoucher",voucher_OrigQtuQtyVoucher},
                        {"TcCprItemCost",voucherItem.GetValue<decimal?>("poi.unit_mat_cost")},
                        {"CprItemCostConv",voucher_CprItemCostConv},
                        {"CprPlanCostConv",voucher_CprPlanCostConv},
                        {"DerEdiVoucher", PCanEdi},
                        {"DerVendorEDIInvoice", voucherItem.GetValue<string>("vin.vend_inv_num")},
                        {"DerReadOnlyRow", PShowEdi},
                        {"PoRecordDate",voucherItem.GetValue<DateTime?>("poi.po_RecordDate")},
                        {"RowPointer",Guid.NewGuid()},
                        {"DerFixedRate",voucherItem.GetValue<int?>("poi.fixed_rate")},
                        {"DerExchRate",voucherItem.GetValue<decimal?>("poi.exch_rate")},
                        {"SelectDeniedReadOnlyFlag",0},
                        {"VendItem",voucherItem.GetValue<string>("poi.vend_item")},
                        {"BuilderPoOrigSite",voucherItem.GetValue<string>("poi.builder_po_orig_site")},
                        {"BuilderPoNum",voucherItem.GetValue<string>("poi.builder_po_num")},
                        {"DerIncludeTaxInPrice",voucherItem.GetValue<int?>("poi.include_tax_in_cost")},
                        {"NonInvAcct",voucherItem.GetValue<string>("poi.non_inv_acct")},
                        {"NonInvAcctDesc",voucherItem.GetValue<string>("poi.non_inv_acct_description")},
                        {"NonInvAcctUnit1",voucherItem.GetValue<string>("poi.non_inv_acct_unit1")},
                        {"NonInvAcctUnit2",voucherItem.GetValue<string>("poi.non_inv_acct_unit2")},
                        {"NonInvAcctUnit3",voucherItem.GetValue<string>("poi.non_inv_acct_unit3")},
                        {"NonInvAcctUnit4",voucherItem.GetValue<string>("poi.non_inv_acct_unit4")},
                        {"DerItemExists",voucher_DerItemExists},
                    });

                    var nonTableLoadResponse = this.appDB.Load(nonTableLoadRequest);
                    #endregion CRUD LoadResponseWithoutTable

                    #region CRUD InsertByRecords
                    unionUtil.Add(nonTableLoadResponse);
                    processedRowCount += nonTableLoadResponse.Items.Count;
                    #endregion InsertByRecords

                    if (processedRowCount >= recordCap)
                    {
                        // LOG TIMING
                        LogTiming($"Streaming Max RecordCap");

                        // Insert one more row so that get more row is enabled.
                        var nonTableLoadRequest2 = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
                        {
                            {"ConnectionId", null},
                            {"Type",""},
                            {"GrnNum",""},
                            {"GrnLine",""},
                            {"PoNum",this.highString.HighStringFn("PoNumType")},
                            {"PoLine",this.highInt.HighIntFn()},
                            {"PoRelease",0},
                            {"Item",""},
                            {"ItemDescription",""},
                            {"TransNat",""},
                            {"TransNat2",""},
                            {"UM",""},
                            {"TermsCode",""},
                            {"QtuQtyReceived",0M},
                            {"QtuQtyVoucher",0M},
                            {"OrigQtuQtyVoucher",0M},
                            {"TcCprItemCost",0M},
                            {"CprItemCostConv",0M},
                            {"CprPlanCostConv",0M},
                            {"DerEdiVoucher",0},
                            {"DerVendorEDIInvoice",""},
                            {"DerReadOnlyRow",0},
                            {"PoRecordDate",null},
                            {"RowPointer",null},
                            {"DerFixedRate",0},
                            {"DerExchRate",0M},
                            {"SelectDeniedReadOnlyFlag",0},
                            {"VendItem",""},
                            {"BuilderPoOrigSite",""},
                            {"BuilderPoNum",""},
                            {"DerIncludeTaxInPrice",0},
                            {"NonInvAcct",""},
                            {"NonInvAcctDesc",""},
                            {"NonInvAcctUnit1",""},
                            {"NonInvAcctUnit2",""},
                            {"NonInvAcctUnit3",""},
                            {"NonInvAcctUnit4",""},
                            {"DerItemExists",null},
                        });

                        var nonTableLoadResponse2 = this.appDB.Load(nonTableLoadRequest2);

                        unionUtil.Add(nonTableLoadResponse2);

                        // LOG TIMING
                        LogTiming($"Streaming add dummy row");
                        break;
                    }
                }
            }

            LogTiming($"END Streaming While Loop ProcessedRowCount {processedRowCount}");
        }

        public (
        ICollectionLoadResponse Data,
        int? ReturnCode)
        AltExtGen_CLM_GenerateAPTransactionsSp(
        string AltExtGenSp,
        string PVendNum,
        string PGenerateVoucher = "V",
        int? PCanEdi = 1,
        int? PShowEdi = 0,
        string CurrCode = null,
        string FilterString = null)
        {
            VendNumType _PVendNum = PVendNum;
            GenericCodeType _PGenerateVoucher = PGenerateVoucher;
            FlagNyType _PCanEdi = PCanEdi;
            FlagNyType _PShowEdi = PShowEdi;
            CurrCodeType _CurrCode = CurrCode;
            LongListType _FilterString = FilterString;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();
                IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PGenerateVoucher", _PGenerateVoucher, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PCanEdi", _PCanEdi, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PShowEdi", _PShowEdi, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);

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
