//PROJECT NAME: Logistics
//CLASS NAME: CLM_CashImpactGrid.cs

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
using CSI.Data.Utilities;

namespace CSI.Logistics.Customer
{
    public class CLM_CashImpactGrid : ICLM_CashImpactGrid
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
        readonly ITransactionFactory transactionFactory;
        readonly IRpt_CashImpactSub iRpt_CashImpactSub;
        readonly IExecuteDynamicSQL iExecuteDynamicSQL;
        readonly IScalarFunction scalarFunction;
        readonly IExistsChecker existsChecker;
        readonly IVariableUtil variableUtil;
        readonly IStringUtil stringUtil;
        readonly ISqlFilter iSqlFilter;
        readonly ISQLValueComparerUtil sQLUtil;

        public CLM_CashImpactGrid(IApplicationDB appDB,
            IBunchedLoadCollection bunchedLoadCollection,
            ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            ITransactionFactory transactionFactory,
            IRpt_CashImpactSub iRpt_CashImpactSub,
            IExecuteDynamicSQL iExecuteDynamicSQL,
            IScalarFunction scalarFunction,
            IExistsChecker existsChecker,
            IVariableUtil variableUtil,
            IStringUtil stringUtil,
            ISqlFilter iSqlFilter,
            ISQLValueComparerUtil sQLUtil)
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
            this.transactionFactory = transactionFactory;
            this.iRpt_CashImpactSub = iRpt_CashImpactSub;
            this.iExecuteDynamicSQL = iExecuteDynamicSQL;
            this.scalarFunction = scalarFunction;
            this.existsChecker = existsChecker;
            this.variableUtil = variableUtil;
            this.stringUtil = stringUtil;
            this.iSqlFilter = iSqlFilter;
            this.sQLUtil = sQLUtil;
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        CLM_CashImpactGridSp(
            string TransactionType = null,
            string FilterString = null)
        {
            if (bunchedLoadCollection != null)
                bunchedLoadCollection.StartBunching();

            try
            {
                ICollectionLoadResponse Data = null;

                StringType _ALTGEN_SpName = DBNull.Value;
                string ALTGEN_SpName = null;
                int? ALTGEN_Severity = null;
                int? Severity = null;
                CurrCodeType _ParmsCurrCode = DBNull.Value;
                string ParmsCurrCode = null;
                string Infobar = null;
                string WhereClause = null;
                string PropertyList = null;
                string ColumnList = null;
                string SelectionClause = null;
                string FromClause = null;
                string AdditionalClause = null;
                string KeyColumns = null;

                if (existsChecker.Exists(
                    tableName: "optional_module",
                    fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                    whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_CashImpactGridSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
                {
                    //BEGIN
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
                        whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_CashImpactGridSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
                    #endregion  LoadToRecord

                    #region CRUD InsertByRecords
                    foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                    {
                        optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("CLM_CashImpactGridSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
                    };

                    var optional_module1RequiredColumns = new List<string>() { "SpName" };

                    optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

                    var optional_module1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ALTGEN",
                        items: optional_module1LoadResponse.Items);

                    this.appDB.Insert(optional_module1InsertRequest);
                    #endregion InsertByRecords

                    while (existsChecker.Exists(
                        tableName: "#tv_ALTGEN",
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

                        var ALTGEN = AltExtGen_CLM_CashImpactGridSp(_ALTGEN_SpName,
                            TransactionType,
                            FilterString);
                        ALTGEN_Severity = ALTGEN.ReturnCode;

                        if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
                        {
                            return (ALTGEN.Data, ALTGEN_Severity);

                        }

                        this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
                        /*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
                        #region CRUD LoadToRecord
                        var tv_ALTGEN2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                            {
                                {"col0","1"},
                            },
                            tableName: "#tv_ALTGEN", 
                            loadForChange: true, 
                            lockingType: LockingType.None,
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

                if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_CashImpactGridSp") != null)
                {
                    var EXTGEN = AltExtGen_CLM_CashImpactGridSp("dbo.EXTGEN_CLM_CashImpactGridSp",
                        TransactionType,
                        FilterString);
                    int? EXTGEN_Severity = EXTGEN.ReturnCode;

                    if (EXTGEN_Severity != 1)
                    {
                        return (EXTGEN.Data, EXTGEN_Severity);
                    }
                }

                this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
                //this temp table is a table variable in old stored procedure version.
                this.sQLExpressionExecutor.Execute(@"DECLARE @RptMainSet TABLE (
                        StartDate            DateType         ,
                        Date3                DateType         ,
                        Date4                DateType         ,
                        Date5                DateType         ,
                        Date6                DateType         ,
                        EndDate              DateType         ,
                        CurrencyCurrCode     CurrCodeType     ,
                        Type                 NVARCHAR (30)    ,
                        SubType              NVARCHAR (30)    ,
                        DataOfStartDate      AmountType       ,
                        DataOfBaseDate       AmountType       ,
                        DataOfDate3          AmountType       ,
                        DataOfDate4          AmountType       ,
                        DataOfDate5          AmountType       ,
                        DataOfDate6          AmountType       ,
                        Flag                 INT              ,
                        GroupIndex           INT              ,
                        SubGroupIndex        INT              ,
                        DomCurrencyFormat    InputMaskType    ,
                        DomCurrencyPlaces    DecimalPlacesType,
                        DomTotCurrencyFormat InputMaskType    ,
                        DomTotCurrencyPlaces DecimalPlacesType);
                    SELECT * into #tv_RptMainSet from @RptMainSet ");

                //this temp table is a table variable in old stored procedure version.
                this.sQLExpressionExecutor.Execute(@"DECLARE @Impact TABLE (
                        Date1          DateType     ,
                        Date2          DateType     ,
                        Date3          DateType     ,
                        Date4          DateType     ,
                        Date5          DateType     ,
                        Date6          DateType     ,
                        CustCurrCode   NVARCHAR (3) ,
                        CashImpactType NVARCHAR (30),
                        CashBucket1    AmtTotType   ,
                        CashBucket2    AmtTotType   ,
                        CashBucket3    AmtTotType   ,
                        CashBucket4    AmtTotType   ,
                        CashBucket5    AmtTotType   ,
                        CashBucket6    AmtTotType   ,
                        display_order  INT          );
                    SELECT * into #tv_Impact from @Impact ");

                //this temp table is a table variable in old stored procedure version.
                this.sQLExpressionExecutor.Execute(@"DECLARE @TotalCash TABLE (
                        CashImpactType NVARCHAR (30),
                        AsOfDate       DateType     ,
                        CashBucket     AmtTotType   );
                    SELECT * into #tv_TotalCash from @TotalCash ");
                Severity = 0;

                #region CRUD InsertByMethodCall
                //Please Generate the bounce for this stored procedure:Rpt_CashImpactSubSp
                var tv_RptMainSetExecResult = this.iRpt_CashImpactSub.Rpt_CashImpactSubSp(SummaryOrDetail: "S"
                    , InclARTrxAPTrxOrBoth: "B"
                    , InclCOPOOrBoth: "B"
                    , InclPORequisitions: 1
                    , InclCOBlanketReleases: 1
                    , InclPOBlanketReleases: 1
                    , InclCOProgresiveBilling: 1
                    , CreditHold: "B"
                    , InclEstimateOrders: 1
                    , EstimateOrderOffsetDay: 0
                    , InclAREarlyPayDiscounts: 2
                    , InclAPEarlyPayDiscounts: 2
                    , CustomerPaymentsBasis: "A"
                    , NumberOfDaysLookback: 30
                    , TranslateToDomesticCurrency: 1
                    , StartingCurrencyCode: null
                    , EndingCurrencyCode: null
                    , PaymentHold: "B"
                    , EstimateStatus: "WQP"
                    , NumberOfDaysPerColumn: 30
                    , UseHistoricalCurrencyRate: 1);
                var tv_RptMainSetLoadResponse = collectionLoadResponseUtil.CloneCollectionRenameColumns(tv_RptMainSetExecResult.Data,
                    new List<string>() { "StartDate",
                        "Date3",
                        "Date4",
                        "Date5",
                        "Date6",
                        "EndDate",
                        "CurrencyCurrCode",
                        "Type",
                        "SubType",
                        "DataOfStartDate",
                        "DataOfBaseDate",
                        "DataOfDate3",
                        "DataOfDate4",
                        "DataOfDate5",
                        "DataOfDate6",
                        "Flag",
                        "GroupIndex",
                        "SubGroupIndex",
                        "DomCurrencyFormat",
                        "DomCurrencyPlaces",
                        "DomTotCurrencyFormat",
                        "DomTotCurrencyPlaces" });
                var tv_RptMainSetInsertRequest = this.collectionInsertRequestFactory.SQLInsert(tableName: "#tv_RptMainSet",
                items: tv_RptMainSetLoadResponse.Items);

                this.appDB.Insert(tv_RptMainSetInsertRequest);

                #endregion InsertByMethodCall

                #region CRUD LoadToVariable
                var currparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                    {
                        {_ParmsCurrCode,"curr_code"},
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "currparms",
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause(""),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var currparmsLoadResponse = this.appDB.Load(currparmsLoadRequest);
                if (currparmsLoadResponse.Items.Count > 0)
                {
                    ParmsCurrCode = _ParmsCurrCode;
                }
                #endregion  LoadToVariable

                #region CRUD LoadArbitrary
                var tv_ImpactLoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        { "Date1", "StartDate" },
                        { "Date2", "Date3" },
                        { "Date3", "Date4" },
                        { "Date4", "Date5" },
                        { "Date5", "Date6" },
                        { "Date6", "EndDate" },
                        { "CustCurrCode", $"{variableUtil.GetValue<string>(ParmsCurrCode)}" },
                        { "CashImpactType", "Type" },
                        { "CashBucket1", "sum(DataOfStartDate)" },
                        { "CashBucket2", "sum(DataOfBaseDate)" },
                        { "CashBucket3", "sum(DataOfDate3)" },
                        { "CashBucket4", "sum(DataOfDate4)" },
                        { "CashBucket5", "sum(DataOfDate5)" },
                        { "CashBucket6", "sum(DataOfDate6)" },
                        { "display_order", "0" },
                    },
                    selectStatement: collectionLoadRequestFactory.Clause(@"SELECT @selectList  
                        FROM #tv_RptMainSet 
                        GROUP BY StartDate, Date3, Date4, Date5, Date6, EndDate, Type"));

                var tv_ImpactLoadResponse = this.appDB.Load(tv_ImpactLoadRequest);
                Data = tv_ImpactLoadResponse;
                #endregion  LoadArbitrary

                #region CRUD InsertByRecords
                var tv_ImpactInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_Impact",
                    items: tv_ImpactLoadResponse.Items);

                this.appDB.Insert(tv_ImpactInsertRequest);
                #endregion InsertByRecords

                this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_Impact ADD tempTableId INT IDENTITY");

                #region CRUD LoadToRecord
                var tv_Impact1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"display_order","#tv_Impact.display_order"},
                    },
                    tableName: "#tv_Impact", 
                    loadForChange: true, 
                    lockingType: LockingType.UPDLock,
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause("CashImpactType = 'ARTransaction'"),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var tv_Impact1LoadResponse = this.appDB.Load(tv_Impact1LoadRequest);
                #endregion  LoadToRecord

                #region CRUD UpdateByRecord
                foreach (var tv_Impact1Item in tv_Impact1LoadResponse.Items)
                {
                    tv_Impact1Item.SetValue<int?>("display_order", 1);
                };

                var tv_Impact1RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#tv_Impact",
                    items: tv_Impact1LoadResponse.Items);

                this.appDB.Update(tv_Impact1RequestUpdate);
                #endregion UpdateByRecord

                this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_Impact DROP COLUMN tempTableId");
                this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_Impact ADD tempTableId INT IDENTITY");

                #region CRUD LoadToRecord
                var tv_Impact2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"display_order","#tv_Impact.display_order"},
                    },
                    tableName: "#tv_Impact", 
                    loadForChange: true,
                    lockingType: LockingType.UPDLock,
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause("CashImpactType = 'CustomerOrder'"),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var tv_Impact2LoadResponse = this.appDB.Load(tv_Impact2LoadRequest);
                #endregion  LoadToRecord

                #region CRUD UpdateByRecord
                foreach (var tv_Impact2Item in tv_Impact2LoadResponse.Items)
                {
                    tv_Impact2Item.SetValue<int?>("display_order", 2);
                };

                var tv_Impact2RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#tv_Impact",
                    items: tv_Impact2LoadResponse.Items);

                this.appDB.Update(tv_Impact2RequestUpdate);
                #endregion UpdateByRecord

                this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_Impact DROP COLUMN tempTableId");
                this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_Impact ADD tempTableId INT IDENTITY");

                #region CRUD LoadToRecord
                var tv_Impact3LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"display_order","#tv_Impact.display_order"},
                    },
                    tableName: "#tv_Impact", 
                    loadForChange: true,
                    lockingType: LockingType.UPDLock,
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause("CashImpactType = 'ProgressiveBill'"),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var tv_Impact3LoadResponse = this.appDB.Load(tv_Impact3LoadRequest);
                #endregion  LoadToRecord

                #region CRUD UpdateByRecord
                foreach (var tv_Impact3Item in tv_Impact3LoadResponse.Items)
                {
                    tv_Impact3Item.SetValue<int?>("display_order", 3);
                };

                var tv_Impact3RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#tv_Impact",
                    items: tv_Impact3LoadResponse.Items);

                this.appDB.Update(tv_Impact3RequestUpdate);
                #endregion UpdateByRecord

                this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_Impact DROP COLUMN tempTableId");
                this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_Impact ADD tempTableId INT IDENTITY");

                #region CRUD LoadToRecord
                var tv_Impact4LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"display_order","#tv_Impact.display_order"},
                    },
                    tableName: "#tv_Impact", 
                    loadForChange: true,
                    lockingType: LockingType.UPDLock,
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause("CashImpactType = 'COBlanketLine'"),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var tv_Impact4LoadResponse = this.appDB.Load(tv_Impact4LoadRequest);
                #endregion  LoadToRecord

                #region CRUD UpdateByRecord
                foreach (var tv_Impact4Item in tv_Impact4LoadResponse.Items)
                {
                    tv_Impact4Item.SetValue<int?>("display_order", 4);
                };

                var tv_Impact4RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#tv_Impact",
                    items: tv_Impact4LoadResponse.Items);

                this.appDB.Update(tv_Impact4RequestUpdate);
                #endregion UpdateByRecord

                this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_Impact DROP COLUMN tempTableId");
                this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_Impact ADD tempTableId INT IDENTITY");

                #region CRUD LoadToRecord
                var tv_Impact5LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"display_order","#tv_Impact.display_order"},
                    },
                    tableName: "#tv_Impact", 
                    loadForChange: true, 
                    lockingType: LockingType.UPDLock,
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause("CashImpactType = 'EstimateOrder'"),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var tv_Impact5LoadResponse = this.appDB.Load(tv_Impact5LoadRequest);
                #endregion  LoadToRecord

                #region CRUD UpdateByRecord
                foreach (var tv_Impact5Item in tv_Impact5LoadResponse.Items)
                {
                    tv_Impact5Item.SetValue<int?>("display_order", 5);
                };

                var tv_Impact5RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#tv_Impact",
                    items: tv_Impact5LoadResponse.Items);

                this.appDB.Update(tv_Impact5RequestUpdate);
                #endregion UpdateByRecord

                this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_Impact DROP COLUMN tempTableId");
                this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_Impact ADD tempTableId INT IDENTITY");

                #region CRUD LoadToRecord
                var tv_Impact6LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"display_order","#tv_Impact.display_order"},
                    },
                    tableName: "#tv_Impact", 
                    loadForChange: true, 
                    lockingType: LockingType.UPDLock,
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause("CashImpactType = 'TotalCashIn'"),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var tv_Impact6LoadResponse = this.appDB.Load(tv_Impact6LoadRequest);
                #endregion  LoadToRecord

                #region CRUD UpdateByRecord
                foreach (var tv_Impact6Item in tv_Impact6LoadResponse.Items)
                {
                    tv_Impact6Item.SetValue<int?>("display_order", 6);
                };

                var tv_Impact6RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#tv_Impact",
                    items: tv_Impact6LoadResponse.Items);

                this.appDB.Update(tv_Impact6RequestUpdate);
                #endregion UpdateByRecord

                this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_Impact DROP COLUMN tempTableId");
                this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_Impact ADD tempTableId INT IDENTITY");

                #region CRUD LoadToRecord
                var tv_Impact7LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"display_order","#tv_Impact.display_order"},
                    },
                    tableName: "#tv_Impact", 
                    loadForChange: true, 
                    lockingType: LockingType.UPDLock,
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause("CashImpactType = 'APTransaction'"),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var tv_Impact7LoadResponse = this.appDB.Load(tv_Impact7LoadRequest);
                #endregion  LoadToRecord

                #region CRUD UpdateByRecord
                foreach (var tv_Impact7Item in tv_Impact7LoadResponse.Items)
                {
                    tv_Impact7Item.SetValue<int?>("display_order", 7);
                };

                var tv_Impact7RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#tv_Impact",
                    items: tv_Impact7LoadResponse.Items);

                this.appDB.Update(tv_Impact7RequestUpdate);
                #endregion UpdateByRecord

                this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_Impact DROP COLUMN tempTableId");
                this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_Impact ADD tempTableId INT IDENTITY");

                #region CRUD LoadToRecord
                var tv_Impact8LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"display_order","#tv_Impact.display_order"},
                    },
                    tableName: "#tv_Impact", 
                    loadForChange: true,
                    lockingType: LockingType.UPDLock,
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause("CashImpactType = 'PurchaseOrder'"),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var tv_Impact8LoadResponse = this.appDB.Load(tv_Impact8LoadRequest);
                #endregion  LoadToRecord

                #region CRUD UpdateByRecord
                foreach (var tv_Impact8Item in tv_Impact8LoadResponse.Items)
                {
                    tv_Impact8Item.SetValue<int?>("display_order", 8);
                };

                var tv_Impact8RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#tv_Impact",
                    items: tv_Impact8LoadResponse.Items);

                this.appDB.Update(tv_Impact8RequestUpdate);
                #endregion UpdateByRecord

                this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_Impact DROP COLUMN tempTableId");
                this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_Impact ADD tempTableId INT IDENTITY");

                #region CRUD LoadToRecord
                var tv_Impact9LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"display_order","#tv_Impact.display_order"},
                    },
                    tableName: "#tv_Impact", 
                    loadForChange: true,
                    lockingType: LockingType.UPDLock,
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause("CashImpactType = 'POBlanketLine'"),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var tv_Impact9LoadResponse = this.appDB.Load(tv_Impact9LoadRequest);
                #endregion  LoadToRecord

                #region CRUD UpdateByRecord
                foreach (var tv_Impact9Item in tv_Impact9LoadResponse.Items)
                {
                    tv_Impact9Item.SetValue<int?>("display_order", 9);
                };

                var tv_Impact9RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#tv_Impact",
                    items: tv_Impact9LoadResponse.Items);

                this.appDB.Update(tv_Impact9RequestUpdate);
                #endregion UpdateByRecord

                this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_Impact DROP COLUMN tempTableId");
                this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_Impact ADD tempTableId INT IDENTITY");

                #region CRUD LoadToRecord
                var tv_Impact10LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"display_order","#tv_Impact.display_order"},
                    },
                    tableName: "#tv_Impact", 
                    loadForChange: true, 
                    lockingType: LockingType.UPDLock,
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause("CashImpactType = 'PORequisitions'"),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var tv_Impact10LoadResponse = this.appDB.Load(tv_Impact10LoadRequest);
                #endregion  LoadToRecord

                #region CRUD UpdateByRecord
                foreach (var tv_Impact10Item in tv_Impact10LoadResponse.Items)
                {
                    tv_Impact10Item.SetValue<int?>("display_order", 10);
                };

                var tv_Impact10RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#tv_Impact",
                    items: tv_Impact10LoadResponse.Items);

                this.appDB.Update(tv_Impact10RequestUpdate);
                #endregion UpdateByRecord

                this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_Impact DROP COLUMN tempTableId");
                this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_Impact ADD tempTableId INT IDENTITY");

                #region CRUD LoadToRecord
                var tv_Impact11LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"display_order","#tv_Impact.display_order"},
                    },
                    tableName: "#tv_Impact", 
                    loadForChange: true, 
                    lockingType: LockingType.UPDLock,
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause("CashImpactType = 'TotalCashOut'"),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var tv_Impact11LoadResponse = this.appDB.Load(tv_Impact11LoadRequest);
                #endregion  LoadToRecord

                #region CRUD UpdateByRecord
                foreach (var tv_Impact11Item in tv_Impact11LoadResponse.Items)
                {
                    tv_Impact11Item.SetValue<int?>("display_order", 11);
                };

                var tv_Impact11RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#tv_Impact",
                    items: tv_Impact11LoadResponse.Items);

                this.appDB.Update(tv_Impact11RequestUpdate);
                #endregion UpdateByRecord

                this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_Impact DROP COLUMN tempTableId");
                this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_Impact ADD tempTableId INT IDENTITY");

                #region CRUD LoadToRecord
                var tv_Impact12LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"display_order","#tv_Impact.display_order"},
                    },
                    tableName: "#tv_Impact",
                    loadForChange: true, 
                    lockingType: LockingType.UPDLock,
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause("CashImpactType = 'NetChange'"),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var tv_Impact12LoadResponse = this.appDB.Load(tv_Impact12LoadRequest);
                #endregion  LoadToRecord

                #region CRUD UpdateByRecord
                foreach (var tv_Impact12Item in tv_Impact12LoadResponse.Items)
                {
                    tv_Impact12Item.SetValue<int?>("display_order", 12);
                };

                var tv_Impact12RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#tv_Impact",
                    items: tv_Impact12LoadResponse.Items);

                this.appDB.Update(tv_Impact12RequestUpdate);
                #endregion UpdateByRecord

                this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_Impact DROP COLUMN tempTableId");
                this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_Impact ADD tempTableId INT IDENTITY");

                #region CRUD LoadToRecord
                var tv_Impact13LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"display_order","#tv_Impact.display_order"},
                    },
                    tableName: "#tv_Impact", 
                    loadForChange: true,
                    lockingType: LockingType.UPDLock,
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause("CashImpactType = 'RunningNetChange'"),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var tv_Impact13LoadResponse = this.appDB.Load(tv_Impact13LoadRequest);
                #endregion  LoadToRecord

                #region CRUD UpdateByRecord
                foreach (var tv_Impact13Item in tv_Impact13LoadResponse.Items)
                {
                    tv_Impact13Item.SetValue<int?>("display_order", 13);
                };

                var tv_Impact13RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#tv_Impact",
                    items: tv_Impact13LoadResponse.Items);

                this.appDB.Update(tv_Impact13RequestUpdate);
                #endregion UpdateByRecord

                this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_Impact DROP COLUMN tempTableId");

                #region CRUD LoadToRecord
                var TotalCashLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"CashImpactType","CashImpactType"},
                        {"AsOfDate","Date1"},
                        {"CashBucket","CashBucket1"},
                    },
                    loadForChange: false,                     
                    lockingType: LockingType.None,
                    tableName: "#tv_Impact",
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause(""),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var TotalCashLoadResponse = this.appDB.Load(TotalCashLoadRequest);
                #endregion  LoadToRecord

                #region CRUD InsertByRecords
                var TotalCashInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_TotalCash",
                    items: TotalCashLoadResponse.Items);

                this.appDB.Insert(TotalCashInsertRequest);
                #endregion InsertByRecords

                #region CRUD LoadToRecord
                var TotalCash1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"CashImpactType","CashImpactType"},
                        {"AsOfDate","Date2"},
                        {"CashBucket","CashBucket2"},
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "#tv_Impact",
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause(""),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var TotalCash1LoadResponse = this.appDB.Load(TotalCash1LoadRequest);
                #endregion  LoadToRecord

                #region CRUD InsertByRecords
                var TotalCash1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_TotalCash",
                    items: TotalCash1LoadResponse.Items);

                this.appDB.Insert(TotalCash1InsertRequest);
                #endregion InsertByRecords

                #region CRUD LoadToRecord
                var TotalCash2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"CashImpactType","CashImpactType"},
                        {"AsOfDate","Date3"},
                        {"CashBucket","CashBucket3"},
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "#tv_Impact",
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause(""),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var TotalCash2LoadResponse = this.appDB.Load(TotalCash2LoadRequest);
                #endregion  LoadToRecord

                #region CRUD InsertByRecords
                var TotalCash2InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_TotalCash",
                    items: TotalCash2LoadResponse.Items);

                this.appDB.Insert(TotalCash2InsertRequest);
                #endregion InsertByRecords

                #region CRUD LoadToRecord
                var TotalCash3LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"CashImpactType","CashImpactType"},
                        {"AsOfDate","Date4"},
                        {"CashBucket","CashBucket4"},
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "#tv_Impact",
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause(""),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var TotalCash3LoadResponse = this.appDB.Load(TotalCash3LoadRequest);
                #endregion  LoadToRecord

                #region CRUD InsertByRecords
                var TotalCash3InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_TotalCash",
                    items: TotalCash3LoadResponse.Items);

                this.appDB.Insert(TotalCash3InsertRequest);
                #endregion InsertByRecords

                #region CRUD LoadToRecord
                var TotalCash4LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"CashImpactType","CashImpactType"},
                        {"AsOfDate","Date5"},
                        {"CashBucket","CashBucket5"},
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "#tv_Impact",
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause(""),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var TotalCash4LoadResponse = this.appDB.Load(TotalCash4LoadRequest);
                #endregion  LoadToRecord

                #region CRUD InsertByRecords
                var TotalCash4InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_TotalCash",
                    items: TotalCash4LoadResponse.Items);

                this.appDB.Insert(TotalCash4InsertRequest);
                #endregion InsertByRecords

                #region CRUD LoadToRecord
                var TotalCash5LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"CashImpactType","CashImpactType"},
                        {"AsOfDate","Date6"},
                        {"CashBucket","CashBucket6"},
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "#tv_Impact",
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause(""),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var TotalCash5LoadResponse = this.appDB.Load(TotalCash5LoadRequest);
                #endregion  LoadToRecord

                #region CRUD InsertByRecords
                var TotalCash5InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_TotalCash",
                    items: TotalCash5LoadResponse.Items);

                this.appDB.Insert(TotalCash5InsertRequest);
                #endregion InsertByRecords

                if (this.scalarFunction.Execute<int?>("OBJECT_ID", "tempdb..#TotalCash") != null)
                {
                    this.sQLExpressionExecutor.Execute("DROP TABLE #TotalCash ");
                }

                this.sQLExpressionExecutor.Execute(@"SELECT   *
				INTO     #TotalCash
				FROM     #tv_TotalCash
				WHERE 1 = 0");

                this.sQLExpressionExecutor.Execute(@"INSERT
				INTO     #TotalCash
				SELECT * FROM      #tv_TotalCash
				WHERE    CashImpactType IN ('TotalCashIn', 'TotalCashOut', 'NetChange', 'RunningNetChange')
				         AND CashImpactType = CAST({0} AS nvarchar (30))
				ORDER BY CashImpactType",
                    TransactionType);

                PropertyList = "CashType;AsOfDate;CashBucket";
                ColumnList = "CashImpactType;AsOfDate;CashBucket";
                FilterString = stringUtil.IsNull(this.iSqlFilter.SqlFilterFn(FilterString, PropertyList, ColumnList, ";"), "");
                SelectionClause = "";
                FromClause = "";
                AdditionalClause = "";
                KeyColumns = "";
                SelectionClause = "SELECT *";
                FromClause = "FROM #TotalCash";
                WhereClause = null;
                AdditionalClause = "ORDER BY CashImpactType, AsOfDate";
                KeyColumns = "CashImpactType, AsOfDate";
                if (this.scalarFunction.Execute<int?>("OBJECT_ID", "tempdb..#DynamicParameters") != null)
                {
                    this.sQLExpressionExecutor.Execute("DROP TABLE #DynamicParameters ");

                }

                this.sQLExpressionExecutor.Execute(@"Declare
                     @SelectionClause VeryLongListType
                     ,@FromClause VeryLongListType
                     ,@WhereClause LongListType
                     ,@AdditionalClause VeryLongListType
                     ,@KeyColumns VeryLongListType
                     ,@FilterString LongListType
                     SELECT @SelectionClause AS SelectionClause,
                            @FromClause AS FromClause,
                            @WhereClause AS WhereClause,
                            @AdditionalClause AS AdditionalClause,
                            @KeyColumns AS KeyColumns,
                            @FilterString AS FilterString
                     INTO   #DynamicParameters
                     WHERE 1 = 2");

                #region CRUD LoadArbitrary
                var DynamicParametersLoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"SelectionClause",$"{variableUtil.GetValue<string>(SelectionClause)}"},
                        {"FromClause",$"{variableUtil.GetValue<string>(FromClause)}"},
                        {"WhereClause",$"{variableUtil.GetValue<string>(WhereClause)}"},
                        {"AdditionalClause",$"{variableUtil.GetValue<string>(AdditionalClause)}"},
                        {"KeyColumns",$"{variableUtil.GetValue<string>(KeyColumns)}"},
                        {"FilterString",$"{variableUtil.GetValue<string>(FilterString)}"},
                    },
                    selectStatement: collectionLoadRequestFactory.Clause("SELECT @selectList"));

                var DynamicParametersLoadResponse = this.appDB.Load(DynamicParametersLoadRequest);
                Data = DynamicParametersLoadResponse;
                #endregion  LoadArbitrary

                #region CRUD InsertByRecords
                var DynamicParametersInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#DynamicParameters",
                    items: DynamicParametersLoadResponse.Items);

                this.appDB.Insert(DynamicParametersInsertRequest);
                #endregion InsertByRecords

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: ExecuteDynamicSQLSp
                var ExecuteDynamicSQL = this.iExecuteDynamicSQL.ExecuteDynamicSQLSp(NeedGetMoreRows: 1
                    , Infobar: Infobar);
                Severity = ExecuteDynamicSQL.ReturnCode;
                Data = ExecuteDynamicSQL.Data;
                Infobar = ExecuteDynamicSQL.Infobar;

                #endregion ExecuteMethodCall

                if (this.scalarFunction.Execute<int?>("OBJECT_ID", "tempdb..#TotalCash") != null)
                {
                    this.sQLExpressionExecutor.Execute("DROP TABLE #TotalCash ");

                }
                return (Data, Severity);
            }
            finally
            {
                if (bunchedLoadCollection != null)
                    bunchedLoadCollection.EndBunching();
            }
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        AltExtGen_CLM_CashImpactGridSp(
            string AltExtGenSp,
            string TransactionType = null,
            string FilterString = null)
        {
            StringType _TransactionType = TransactionType;
            LongListType _FilterString = FilterString;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();
                IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "TransactionType", _TransactionType, ParameterDirection.Input);
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
