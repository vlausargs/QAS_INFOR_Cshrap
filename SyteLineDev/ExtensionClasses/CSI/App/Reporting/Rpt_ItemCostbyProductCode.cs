//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ItemCostbyProductCode.cs

using System;
using System.Data;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System.Collections.Generic;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.Data.SQL;
using CSI.MG.MGCore;

namespace CSI.Reporting
{
    public class Rpt_ItemCostbyProductCode : IRpt_ItemCostbyProductCode
    {
        IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
        ICollectionInsertRequestFactory collectionInsertRequestFactory;
        ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        ICollectionUpdateRequestFactory collectionUpdateRequestFactory;
        ICollectionLoadRequestFactory collectionLoadRequestFactory;
        ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly ICloseSessionContext iCloseSessionContext;
        readonly IInitSessionContext iInitSessionContext;
        readonly ITransactionFactory transactionFactory;
        readonly IGetIsolationLevel iGetIsolationLevel;
        readonly IGetWinRegDecGroup iGetWinRegDecGroup;
        readonly IFixMaskForCrystal iFixMaskForCrystal;
        IScalarFunction scalarFunction;
        IExistsChecker existsChecker;
        IConvertToUtil convertToUtil;
        readonly IGetSiteDate iGetSiteDate;
        IVariableUtil variableUtil;
        IStringUtil stringUtil;
        ISQLValueComparerUtil sQLUtil;
        readonly ILowCharacter lowCharacter;
        readonly IHighCharacter highCharacter;
        public Rpt_ItemCostbyProductCode(IApplicationDB appDB,
            IBunchedLoadCollection bunchedLoadCollection,
            ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            ICloseSessionContext iCloseSessionContext,
            IInitSessionContext iInitSessionContext,
            ITransactionFactory transactionFactory,
            IGetIsolationLevel iGetIsolationLevel,
            IGetWinRegDecGroup iGetWinRegDecGroup,
            IFixMaskForCrystal iFixMaskForCrystal,
            IScalarFunction scalarFunction,
            IExistsChecker existsChecker,
            IConvertToUtil convertToUtil,
            IGetSiteDate iGetSiteDate,
            IVariableUtil variableUtil,
            IStringUtil stringUtil,
            ISQLValueComparerUtil sQLUtil,
            ILowCharacter lowCharacter,
            IHighCharacter highCharacter)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
            this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            this.collectionUpdateRequestFactory = collectionUpdateRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.iCloseSessionContext = iCloseSessionContext;
            this.iInitSessionContext = iInitSessionContext;
            this.transactionFactory = transactionFactory;
            this.iGetIsolationLevel = iGetIsolationLevel;
            this.iGetWinRegDecGroup = iGetWinRegDecGroup;
            this.iFixMaskForCrystal = iFixMaskForCrystal;
            this.scalarFunction = scalarFunction;
            this.existsChecker = existsChecker;
            this.convertToUtil = convertToUtil;
            this.iGetSiteDate = iGetSiteDate;
            this.variableUtil = variableUtil;
            this.stringUtil = stringUtil;
            this.sQLUtil = sQLUtil;
            this.highCharacter = highCharacter;
            this.lowCharacter = lowCharacter;
        }

        public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ItemCostbyProductCodeSp(string StartProdCode = null,
            string EndProdCode = null,
            string StartItem = null,
            string EndItem = null,
            string FromWarehouse = null,
            string ToWarehouse = null,
            string MatlStat = null,
            string MatlType = null,
            string Source = null,
            string Stocked = null,
            string ABCCode = null,
            int? PrintZeroQty = null,
            int? PrintCostDet = null,
            int? DisplayHeader = null,
            int? CostItemAtWhse = null,
            string pSite = null)
        {
            ICollectionLoadResponse Data = null;

            int? Severity = 0;

            StringType _ALTGEN_SpName = DBNull.Value;
            string ALTGEN_SpName = null;
            int? ALTGEN_Severity = null;
            Guid? RptSessionID = null;
            string product_code = null;
            int? t_stocked = null;
            string t_item_stat = null;
            string item_stat = null;
            string item_item = null;
            string item_matl_type = null;
            string item_pmt_code = null;
            int? item_stocked = null;
            string item_cost_type = null;
            string item_cost_method = null;
            string item_um = null;
            decimal? tc_qtt = null;
            CostPrcType _tc_cpr_price = DBNull.Value;
            decimal? tc_cpr_price = null;
            decimal? item_unit_cost = null;
            decimal? tc_tot_tmp_price = null;
            QtyTotlType _tc_tot_item_cost = DBNull.Value;
            decimal? tc_tot_item_cost = null;
            decimal? item_comp_setup = null;
            decimal? item_comp_run = null;
            decimal? item_comp_matl = null;
            decimal? item_comp_tool = null;
            decimal? item_comp_fixture = null;
            decimal? item_comp_other = null;
            decimal? item_comp_fixed = null;
            decimal? item_comp_var = null;
            decimal? item_comp_outside = null;
            int? item_lot_tracked = null;
            decimal? tc_tot_cost = null;
            decimal? tc_tot_price = null;
            QtyTotlType _tc_qtt_on_hand = DBNull.Value;
            decimal? tc_qtt_on_hand = null;
            QtyTotlType _tc_qtt_mrb = DBNull.Value;
            decimal? tc_qtt_mrb = null;
            CurrCodeType _XDomCurrency = DBNull.Value;
            string XDomCurrency = null;
            int? DecimalPlaces = null;
            int? IntPosition = null;
            InputMaskType _DomCurrencyFormat = DBNull.Value;
            string DomCurrencyFormat = null;
            DecimalPlacesType _DomCurrencyPlaces = DBNull.Value;
            int? DomCurrencyPlaces = null;
            InputMaskType _DomTotCurrencyFormat = DBNull.Value;
            string DomTotCurrencyFormat = null;
            int? DomTotCurrencyPlaces = null;
            InputMaskType _CostPriceFormat = DBNull.Value;
            string CostPriceFormat = null;
            DecimalPlacesType _CostPricePlaces = DBNull.Value;
            int? CostPricePlaces = null;
            InputMaskType _UnitQtyFormat = DBNull.Value;
            string UnitQtyFormat = null;
            DecimalPlacesType _UnitQtyPlaces = DBNull.Value;
            int? UnitQtyPlaces = null;
            string LowCharacter = null;
            string HighCharacter = null;
            string Prev_product_code = null;
            string Prev_Whse = null;
            string WinRegDecGroupValue = null;
            string Whse = null;
            DateTime? Today = null;
            WhseType _DefaultWhse = DBNull.Value;
            string DefaultWhse = null;
            ICollectionLoadRequest item_crsLoadRequestForCursor = null;
            ICollectionLoadResponse item_crsLoadResponseForCursor = null;
            int item_crs_CursorFetch_Status = -1;
            int item_crs_CursorCounter = -1;

            if (existsChecker.Exists(
                tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_ItemCostbyProductCodeSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
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
                    whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_ItemCostbyProductCodeSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
                #endregion  LoadToRecord

                #region CRUD InsertByRecords
                foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                {
                    optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName("Rpt_ItemCostbyProductCodeSp" + stringUtil.Char(95) + optional_module1Item.GetValue<string>("u0")));
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
                    //BEGIN

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
                    this.appDB.Load(tv_ALTGEN1LoadRequest);
                    ALTGEN_SpName = _ALTGEN_SpName;
                    #endregion  LoadToVariable

                    var ALTGEN = AltExtGen_Rpt_ItemCostbyProductCodeSp(_ALTGEN_SpName,
                        StartProdCode,
                        EndProdCode,
                        StartItem,
                        EndItem,
                        FromWarehouse,
                        ToWarehouse,
                        MatlStat,
                        MatlType,
                        Source,
                        Stocked,
                        ABCCode,
                        PrintZeroQty,
                        PrintCostDet,
                        DisplayHeader,
                        CostItemAtWhse,
                        pSite);
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
                    //END
                }
                //END
            }

            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Rpt_ItemCostbyProductCodeSp") != null)
            {
                var EXTGEN = AltExtGen_Rpt_ItemCostbyProductCodeSp("dbo.EXTGEN_Rpt_ItemCostbyProductCodeSp",
                    StartProdCode,
                    EndProdCode,
                    StartItem,
                    EndItem,
                    FromWarehouse,
                    ToWarehouse,
                    MatlStat,
                    MatlType,
                    Source,
                    Stocked,
                    ABCCode,
                    PrintZeroQty,
                    PrintCostDet,
                    DisplayHeader,
                    CostItemAtWhse,
                    pSite);
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN.Data, EXTGEN_Severity);
                }
            }

            this.transactionFactory.BeginTransaction("");
            this.sQLExpressionExecutor.Execute("SET XACT_ABORT ON ");
            if (sQLUtil.SQLEqual(this.iGetIsolationLevel.GetIsolationLevelFn("ItemCostbyProductCodeReport"), "COMMITTED") == true)
            {
                this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ COMMITTED");
            }
            else
            {
                this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
            }
            LowCharacter = this.lowCharacter.LowCharacterFn();
            HighCharacter = this.highCharacter.HighCharacterFn();
            Today = convertToUtil.ToDateTime(this.iGetSiteDate.GetSiteDateFn(scalarFunction.Execute<DateTime>("GETDATE")));
            WinRegDecGroupValue = this.iGetWinRegDecGroup.GetWinRegDecGroupFn();

            #region CRUD ExecuteMethodCall

            //Please Generate the bounce for this stored procedure: InitSessionContextSp
            var InitSessionContext = this.iInitSessionContext.InitSessionContextSp(ContextName: "Rpt_ItemCostbyProductCodeSp"
                , SessionID: RptSessionID
                , Site: pSite);
            RptSessionID = InitSessionContext.SessionID;

            #endregion ExecuteMethodCall

            StartProdCode = stringUtil.IsNull(StartProdCode, LowCharacter);
            EndProdCode = stringUtil.IsNull(EndProdCode, HighCharacter);
            StartItem = stringUtil.IsNull(StartItem, LowCharacter);
            EndItem = stringUtil.IsNull(EndItem, HighCharacter);
            FromWarehouse = stringUtil.IsNull(FromWarehouse, LowCharacter);
            ToWarehouse = stringUtil.IsNull(ToWarehouse, HighCharacter);
            MatlStat = stringUtil.IsNull(MatlStat, "");
            MatlType = stringUtil.IsNull(MatlType, "");
            Source = stringUtil.IsNull(Source, "");
            Stocked = stringUtil.IsNull(Stocked, "");
            ABCCode = stringUtil.IsNull(ABCCode, "");
            PrintZeroQty = (int?)(stringUtil.IsNull(PrintZeroQty, 0));
            PrintCostDet = (int?)(stringUtil.IsNull(PrintCostDet, 0));
            t_stocked = convertToUtil.ToInt32(sQLUtil.SQLEqual(Stocked, "Y") == true ? 1 : 0);
            //this temp table is a table variable in old stored procedure version.
            this.sQLExpressionExecutor.Execute(@"DECLARE @tt_rpt_set TABLE (
                    prodcode             ProductCodeType  ,
                    item_stat            ItemStatusType   ,
                    item                 DescriptionType  ,
                    type                 MatlTypeType     ,
                    source               PMTCodeType      ,
                    stocked              ListYesNoType    ,
                    cost_type            CostTypeType     ,
                    cost_method          CostMethodType   ,
                    um                   UMType           ,
                    tot_on_hand          QtyTotlType      ,
                    unit_price           CostPrcType      ,
                    unit_cost            CostPrcType      ,
                    tot_price            DECIMAL (38, 8)  ,
                    tot_cost             DECIMAL (38, 8)  ,
                    setup_cost_unit      CostPrcType      ,
                    run_cost_unit        CostPrcType      ,
                    matl_cost_unit       CostPrcType      ,
                    tool_cost_unit       CostPrcType      ,
                    fixture_cost_unit    CostPrcType      ,
                    other_cost_unit      CostPrcType      ,
                    fixed_ovhd_unit      CostPrcType      ,
                    var_ovhd_unit        CostPrcType      ,
                    outside_unit         CostPrcType      ,
                    setup_cost_onhand    AmtTotType       ,
                    run_cost_onhand      AmtTotType       ,
                    matl_cost_onhand     AmtTotType       ,
                    tool_cost_onhand     AmtTotType       ,
                    fixture_cost_onhand  AmtTotType       ,
                    other_cost_onhand    AmtTotType       ,
                    fixed_ovhd_onhand    AmtTotType       ,
                    var_ovhd_onhand      AmtTotType       ,
                    outside_onhand       AmtTotType       ,
                    sub_tot_price        DECIMAL (22, 8)  ,
                    sub_tot_cost         DECIMAL (22, 8)  ,
                    DomCurrencyFormat    InputMaskType    ,
                    DomCurrencyPlaces    DecimalPlacesType,
                    DomTotCurrencyFormat InputMaskType    ,
                    DomTotCurrencyPlaces DecimalPlacesType,
                    CostPriceFormat      InputMaskType    ,
                    CostPricePlaces      DecimalPlacesType,
                    UnitQtyFormat        InputMaskType    ,
                    UnitQtyPlaces        DecimalPlacesType,
                    Whse                 WhseType         ,
                    TotLaborOnhandCost   AmtTotType       ,
                    TotTypeOnhandCost    AmtTotType       ,
                    TotOvhdOnhandCost    AmtTotType       ,
                    TotUnitCost          AmtTotType       ,
                    TotOnhandCost        AmtTotType       );
                SELECT * into #tv_tt_rpt_set from @tt_rpt_set ");

            #region CRUD LoadToVariable
            var currparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_XDomCurrency,"currparms.curr_code"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                maximumRows: 1,
                tableName: "currparms",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            this.appDB.Load(currparmsLoadRequest);
            XDomCurrency = _XDomCurrency;
            #endregion  LoadToVariable

            #region CRUD LoadToVariable
            var currencyLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_DomCurrencyPlaces,"places"},
                    {_DomCurrencyFormat,"amt_format"},
                    {_DomTotCurrencyFormat,"amt_tot_format"},
                    {_CostPricePlaces,"places_cp"},
                    {_CostPriceFormat,"cst_prc_format"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                maximumRows: 1,
                tableName: "currency",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("currency.curr_code = {0}", XDomCurrency),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            this.appDB.Load(currencyLoadRequest);
            DomCurrencyPlaces = _DomCurrencyPlaces;
            DomCurrencyFormat = _DomCurrencyFormat;
            DomTotCurrencyFormat = _DomTotCurrencyFormat;
            CostPricePlaces = _CostPricePlaces;
            CostPriceFormat = _CostPriceFormat;
            #endregion  LoadToVariable

            #region CRUD LoadToVariable
            var invparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_UnitQtyFormat,"qty_unit_format"},
                    {_UnitQtyPlaces,"places_qty_unit"},
                    {_DefaultWhse,"invparms.def_whse"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                maximumRows: 1,
                tableName: "invparms",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            this.appDB.Load(invparmsLoadRequest);
            UnitQtyFormat = _UnitQtyFormat;
            UnitQtyPlaces = _UnitQtyPlaces;
            DefaultWhse = _DefaultWhse;
            #endregion  LoadToVariable

            DomCurrencyFormat = this.iFixMaskForCrystal.FixMaskForCrystalFn(DomCurrencyFormat, WinRegDecGroupValue);
            DomTotCurrencyFormat = this.iFixMaskForCrystal.FixMaskForCrystalFn(DomTotCurrencyFormat, WinRegDecGroupValue);
            CostPriceFormat = this.iFixMaskForCrystal.FixMaskForCrystalFn(CostPriceFormat, WinRegDecGroupValue);
            UnitQtyFormat = this.iFixMaskForCrystal.FixMaskForCrystalFn(UnitQtyFormat, WinRegDecGroupValue);
            DecimalPlaces = 0;
            IntPosition = convertToUtil.ToInt32(stringUtil.CharIndex(".", DomTotCurrencyFormat));
            if (sQLUtil.SQLGreaterThan(IntPosition, 0) == true)
            {
                DecimalPlaces = convertToUtil.ToInt32(stringUtil.Len(stringUtil.Substring(DomTotCurrencyFormat, IntPosition + 1, stringUtil.Len(DomTotCurrencyFormat))));
            }
            DomTotCurrencyPlaces = DecimalPlaces;
            Prev_product_code = "";
            Prev_Whse = "";
            if (sQLUtil.SQLEqual(CostItemAtWhse, 1) == true)
            {
                //BEGIN
                #region Cursor Statement

                #region CRUD LoadToRecord
                item_crsLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"item.stat","item.stat"},
                        {"item.item","item.item"},
                        {"item.matl_type","item.matl_type"},
                        {"item.p_m_t_code","item.p_m_t_code"},
                        {"item.stocked","item.stocked"},
                        {"item.cost_type","item.cost_type"},
                        {"item.cost_method","item.cost_method"},
                        {"item.u_m","item.u_m"},
                        {"itemwhse.unit_cost","itemwhse.unit_cost"},
                        {"itemwhse.comp_setup","itemwhse.comp_setup"},
                        {"itemwhse.comp_run","itemwhse.comp_run"},
                        {"itemwhse.comp_matl","itemwhse.comp_matl"},
                        {"itemwhse.comp_tool","itemwhse.comp_tool"},
                        {"itemwhse.comp_fixture","itemwhse.comp_fixture"},
                        {"itemwhse.comp_other","itemwhse.comp_other"},
                        {"itemwhse.comp_fixed","itemwhse.comp_fixed"},
                        {"itemwhse.comp_var","itemwhse.comp_var"},
                        {"itemwhse.comp_outside","itemwhse.comp_outside"},
                        {"item.lot_tracked","item.lot_tracked"},
                        {"prodcode.product_code","prodcode.product_code"},
                        {"itemwhse.whse","itemwhse.whse"},
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "itemwhse",
                    fromClause: collectionLoadRequestFactory.Clause(" INNER JOIN item ON itemwhse.item = item.item LEFT OUTER JOIN prodcode ON item.product_code = prodcode.product_code"),
                    whereClause: collectionLoadRequestFactory.Clause("itemwhse.whse BETWEEN {0} AND {2} AND item.item BETWEEN {4} AND {8} AND prodcode.product_code BETWEEN {1} AND {3} AND item.item <> '' AND CHARINDEX(item.matl_type, {6}) <> 0 AND CHARINDEX(item.p_m_t_code, {11}) > 0 AND (CASE WHEN {9} = 'B' THEN 1 ELSE CASE WHEN item.stocked = {5} THEN 1 ELSE 0 END END) <> 0 AND CHARINDEX(item.abc_code, {10}) <> 0 AND CHARINDEX(item.stat, {7}) <> 0", FromWarehouse, StartProdCode, ToWarehouse, EndProdCode, StartItem, t_stocked, MatlType, MatlStat, EndItem, Stocked, ABCCode, Source),
                    orderByClause: collectionLoadRequestFactory.Clause(" itemwhse.whse, prodcode.product_code, item.item"));
                #endregion  LoadToRecord

                #endregion Cursor Statement
                //END
            }
            else
            {
                //BEGIN
                #region Cursor Statement

                #region CRUD LoadToRecord
                item_crsLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"item.stat","item.stat"},
                        {"item.item","item.item"},
                        {"item.matl_type","item.matl_type"},
                        {"item.p_m_t_code","item.p_m_t_code"},
                        {"item.stocked","item.stocked"},
                        {"item.cost_type","item.cost_type"},
                        {"item.cost_method","item.cost_method"},
                        {"item.u_m","item.u_m"},
                        {"item.unit_cost","item.unit_cost"},
                        {"item.comp_setup","item.comp_setup"},
                        {"item.comp_run","item.comp_run"},
                        {"item.comp_matl","item.comp_matl"},
                        {"item.comp_tool","item.comp_tool"},
                        {"item.comp_fixture","item.comp_fixture"},
                        {"item.comp_other","item.comp_other"},
                        {"item.comp_fixed","item.comp_fixed"},
                        {"item.comp_var","item.comp_var"},
                        {"item.comp_outside","item.comp_outside"},
                        {"item.lot_tracked","item.lot_tracked"},
                        {"prodcode.product_code","prodcode.product_code"},
                        {"Whse",$"{variableUtil.GetValue<string>(DefaultWhse)}"},
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "prodcode",
                    fromClause: collectionLoadRequestFactory.Clause(" LEFT OUTER JOIN item ON prodcode.product_code = item.product_code"),
                    whereClause: collectionLoadRequestFactory.Clause("item.item BETWEEN {2} AND {6} AND item.item <> '' AND CHARINDEX(item.matl_type, {4}) <> 0 AND CHARINDEX(item.p_m_t_code, {9}) > 0 AND (CASE WHEN {7} = 'B' THEN 1 ELSE CASE WHEN item.stocked = {3} THEN 1 ELSE 0 END END) <> 0 AND CHARINDEX(item.abc_code, {8}) <> 0 AND CHARINDEX(item.stat, {5}) <> 0 AND prodcode.product_code BETWEEN {0} AND {1}", StartProdCode, EndProdCode, StartItem, t_stocked, MatlType, MatlStat, EndItem, Stocked, ABCCode, Source),
                    orderByClause: collectionLoadRequestFactory.Clause(" prodcode.product_code, item.item"));
                #endregion  LoadToRecord

                #endregion Cursor Statement
                //END
            }
            item_crsLoadResponseForCursor = this.appDB.Load(item_crsLoadRequestForCursor);
            item_crs_CursorFetch_Status = item_crsLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
            item_crs_CursorCounter = -1;

            while (sQLUtil.SQLEqual(1, 1) == true)
            {
                //BEGIN
                item_crs_CursorCounter++;
                if (item_crsLoadResponseForCursor.Items.Count > item_crs_CursorCounter)
                {
                    item_stat = item_crsLoadResponseForCursor.Items[item_crs_CursorCounter].GetValue<string>(0);
                    item_item = item_crsLoadResponseForCursor.Items[item_crs_CursorCounter].GetValue<string>(1);
                    item_matl_type = item_crsLoadResponseForCursor.Items[item_crs_CursorCounter].GetValue<string>(2);
                    item_pmt_code = item_crsLoadResponseForCursor.Items[item_crs_CursorCounter].GetValue<string>(3);
                    item_stocked = item_crsLoadResponseForCursor.Items[item_crs_CursorCounter].GetValue<int?>(4);
                    item_cost_type = item_crsLoadResponseForCursor.Items[item_crs_CursorCounter].GetValue<string>(5);
                    item_cost_method = item_crsLoadResponseForCursor.Items[item_crs_CursorCounter].GetValue<string>(6);
                    item_um = item_crsLoadResponseForCursor.Items[item_crs_CursorCounter].GetValue<string>(7);
                    item_unit_cost = item_crsLoadResponseForCursor.Items[item_crs_CursorCounter].GetValue<decimal?>(8);
                    item_comp_setup = item_crsLoadResponseForCursor.Items[item_crs_CursorCounter].GetValue<decimal?>(9);
                    item_comp_run = item_crsLoadResponseForCursor.Items[item_crs_CursorCounter].GetValue<decimal?>(10);
                    item_comp_matl = item_crsLoadResponseForCursor.Items[item_crs_CursorCounter].GetValue<decimal?>(11);
                    item_comp_tool = item_crsLoadResponseForCursor.Items[item_crs_CursorCounter].GetValue<decimal?>(12);
                    item_comp_fixture = item_crsLoadResponseForCursor.Items[item_crs_CursorCounter].GetValue<decimal?>(13);
                    item_comp_other = item_crsLoadResponseForCursor.Items[item_crs_CursorCounter].GetValue<decimal?>(14);
                    item_comp_fixed = item_crsLoadResponseForCursor.Items[item_crs_CursorCounter].GetValue<decimal?>(15);
                    item_comp_var = item_crsLoadResponseForCursor.Items[item_crs_CursorCounter].GetValue<decimal?>(16);
                    item_comp_outside = item_crsLoadResponseForCursor.Items[item_crs_CursorCounter].GetValue<decimal?>(17);
                    item_lot_tracked = item_crsLoadResponseForCursor.Items[item_crs_CursorCounter].GetValue<int?>(18);
                    product_code = item_crsLoadResponseForCursor.Items[item_crs_CursorCounter].GetValue<string>(19);
                    Whse = item_crsLoadResponseForCursor.Items[item_crs_CursorCounter].GetValue<string>(20);
                }
                item_crs_CursorFetch_Status = (item_crs_CursorCounter == item_crsLoadResponseForCursor.Items.Count ? -1 : 0);

                if (sQLUtil.SQLNotEqual(item_crs_CursorFetch_Status, 0) == true)
                {
                    //BEGIN
                    if (sQLUtil.SQLEqual(CostItemAtWhse, 1) == true)
                    {
                        //BEGIN
                        if ((sQLUtil.SQLNotEqual(Prev_Whse, "") == true || sQLUtil.SQLNotEqual(Prev_product_code, "") == true))
                        {
                            //BEGIN
                            this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_tt_rpt_set ADD tempTableId INT IDENTITY");

                            #region CRUD LoadToRecord
                            var tv_tt_rpt_setLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                                {
                                    {"sub_tot_price","#tv_tt_rpt_set.sub_tot_price"},
                                    {"sub_tot_cost","#tv_tt_rpt_set.sub_tot_cost"},
                                }, 
                                loadForChange: true, 
                                lockingType: LockingType.UPDLock,
                                tableName: "#tv_tt_rpt_set",
                                fromClause: collectionLoadRequestFactory.Clause(""),
                                whereClause: collectionLoadRequestFactory.Clause("prodcode = {0} AND Whse = {1}", Prev_product_code, Prev_Whse),
                                orderByClause: collectionLoadRequestFactory.Clause(""));
                            var tv_tt_rpt_setLoadResponse = this.appDB.Load(tv_tt_rpt_setLoadRequest);
                            #endregion  LoadToRecord

                            #region CRUD UpdateByRecord
                            foreach (var tv_tt_rpt_setItem in tv_tt_rpt_setLoadResponse.Items)
                            {
                                tv_tt_rpt_setItem.SetValue<decimal?>("sub_tot_price", tc_tot_price);
                                tv_tt_rpt_setItem.SetValue<decimal?>("sub_tot_cost", tc_tot_cost);
                            };

                            var tv_tt_rpt_setRequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#tv_tt_rpt_set",
                                items: tv_tt_rpt_setLoadResponse.Items);

                            this.appDB.Update(tv_tt_rpt_setRequestUpdate);
                            #endregion UpdateByRecord

                            this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_tt_rpt_set DROP COLUMN tempTableId");
                            //END
                        }

                        break;
                        //END
                    }
                    else
                    {
                        //BEGIN
                        if ((sQLUtil.SQLNotEqual(Prev_product_code, "") == true))
                        {
                            //BEGIN
                            this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_tt_rpt_set ADD tempTableId INT IDENTITY");

                            #region CRUD LoadToRecord
                            var tv_tt_rpt_set1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                                {
                                    {"sub_tot_price","#tv_tt_rpt_set.sub_tot_price"},
                                    {"sub_tot_cost","#tv_tt_rpt_set.sub_tot_cost"},
                                },
                                loadForChange: true, 
                                lockingType: LockingType.UPDLock,
                                tableName: "#tv_tt_rpt_set",
                                fromClause: collectionLoadRequestFactory.Clause(""),
                                whereClause: collectionLoadRequestFactory.Clause("prodcode = {0}", Prev_product_code),
                                orderByClause: collectionLoadRequestFactory.Clause(""));
                            var tv_tt_rpt_set1LoadResponse = this.appDB.Load(tv_tt_rpt_set1LoadRequest);
                            #endregion  LoadToRecord

                            #region CRUD UpdateByRecord
                            foreach (var tv_tt_rpt_set1Item in tv_tt_rpt_set1LoadResponse.Items)
                            {
                                tv_tt_rpt_set1Item.SetValue<decimal?>("sub_tot_price", tc_tot_price);
                                tv_tt_rpt_set1Item.SetValue<decimal?>("sub_tot_cost", tc_tot_cost);
                            };

                            var tv_tt_rpt_set1RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#tv_tt_rpt_set",
                                items: tv_tt_rpt_set1LoadResponse.Items);

                            this.appDB.Update(tv_tt_rpt_set1RequestUpdate);
                            #endregion UpdateByRecord

                            this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_tt_rpt_set DROP COLUMN tempTableId");
                            //END
                        }

                        break;
                        //END
                    }
                    //END
                }

                tc_qtt_on_hand = 0;
                tc_qtt_mrb = 0;
                if (sQLUtil.SQLEqual(CostItemAtWhse, 1) == true)
                {
                    //BEGIN
                    if ((sQLUtil.SQLEqual(Prev_Whse, "") == true || sQLUtil.SQLEqual(Prev_product_code, "") == true))
                    {
                        //BEGIN
                        tc_tot_cost = 0;
                        tc_tot_price = 0;
                        Prev_product_code = product_code;
                        Prev_Whse = Whse;
                        //END
                    }
                    else
                    {
                        if ((sQLUtil.SQLNotEqual(Prev_Whse, Whse) == true || sQLUtil.SQLNotEqual(Prev_product_code, product_code) == true))
                        {
                            //BEGIN
                            this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_tt_rpt_set ADD tempTableId INT IDENTITY");

                            #region CRUD LoadToRecord
                            var tv_tt_rpt_set2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                                {
                                    {"sub_tot_price","#tv_tt_rpt_set.sub_tot_price"},
                                    {"sub_tot_cost","#tv_tt_rpt_set.sub_tot_cost"},
                                },
                                loadForChange: true, 
                                lockingType: LockingType.UPDLock,
                                tableName: "#tv_tt_rpt_set",
                                fromClause: collectionLoadRequestFactory.Clause(""),
                                whereClause: collectionLoadRequestFactory.Clause("prodcode = {0} AND Whse = {1}", Prev_product_code, Prev_Whse),
                                orderByClause: collectionLoadRequestFactory.Clause(""));
                            var tv_tt_rpt_set2LoadResponse = this.appDB.Load(tv_tt_rpt_set2LoadRequest);
                            #endregion  LoadToRecord

                            #region CRUD UpdateByRecord
                            foreach (var tv_tt_rpt_set2Item in tv_tt_rpt_set2LoadResponse.Items)
                            {
                                tv_tt_rpt_set2Item.SetValue<decimal?>("sub_tot_price", tc_tot_price);
                                tv_tt_rpt_set2Item.SetValue<decimal?>("sub_tot_cost", tc_tot_cost);
                            };

                            var tv_tt_rpt_set2RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#tv_tt_rpt_set",
                                items: tv_tt_rpt_set2LoadResponse.Items);

                            this.appDB.Update(tv_tt_rpt_set2RequestUpdate);
                            #endregion UpdateByRecord

                            this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_tt_rpt_set DROP COLUMN tempTableId");
                            tc_tot_cost = 0;
                            tc_tot_price = 0;
                            Prev_product_code = product_code;
                            Prev_Whse = Whse;
                            //END
                        }
                    }

                    #region CRUD LoadToVariable
                    var itemwhse1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                        {
                            {_tc_qtt_on_hand,"ISNULL(itemwhse.qty_on_hand, 0)"},
                            {_tc_qtt_mrb,"ISNULL(itemwhse.qty_mrb, 0)"},
                        },
                        loadForChange: false, 
                        lockingType: LockingType.None,
                        tableName: "itemwhse",
                        fromClause: collectionLoadRequestFactory.Clause(""),
                        whereClause: collectionLoadRequestFactory.Clause("itemwhse.item = {0} AND itemwhse.whse = {1}", item_item, Whse),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    this.appDB.Load(itemwhse1LoadRequest);
                    tc_qtt_on_hand = _tc_qtt_on_hand;
                    tc_qtt_mrb = _tc_qtt_mrb;
                    #endregion  LoadToVariable

                    //END
                }
                else
                {
                    //BEGIN
                    if ((sQLUtil.SQLEqual(Prev_product_code, "") == true))
                    {
                        //BEGIN
                        tc_tot_cost = 0;
                        tc_tot_price = 0;
                        Prev_product_code = product_code;
                        //END

                    }
                    else
                    {
                        if ((sQLUtil.SQLNotEqual(Prev_product_code, product_code) == true))
                        {
                            //BEGIN
                            this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_tt_rpt_set ADD tempTableId INT IDENTITY");

                            #region CRUD LoadToRecord
                            var tv_tt_rpt_set3LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                                {
                                    {"sub_tot_price","#tv_tt_rpt_set.sub_tot_price"},
                                    {"sub_tot_cost","#tv_tt_rpt_set.sub_tot_cost"},
                                },
                                loadForChange: true, 
                                lockingType: LockingType.UPDLock,
                                tableName: "#tv_tt_rpt_set",
                                fromClause: collectionLoadRequestFactory.Clause(""),
                                whereClause: collectionLoadRequestFactory.Clause("prodcode = {0}", Prev_product_code),
                                orderByClause: collectionLoadRequestFactory.Clause(""));
                            var tv_tt_rpt_set3LoadResponse = this.appDB.Load(tv_tt_rpt_set3LoadRequest);
                            #endregion  LoadToRecord

                            #region CRUD UpdateByRecord
                            foreach (var tv_tt_rpt_set3Item in tv_tt_rpt_set3LoadResponse.Items)
                            {
                                tv_tt_rpt_set3Item.SetValue<decimal?>("sub_tot_price", tc_tot_price);
                                tv_tt_rpt_set3Item.SetValue<decimal?>("sub_tot_cost", tc_tot_cost);
                            };

                            var tv_tt_rpt_set3RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#tv_tt_rpt_set",
                                items: tv_tt_rpt_set3LoadResponse.Items);

                            this.appDB.Update(tv_tt_rpt_set3RequestUpdate);
                            #endregion UpdateByRecord

                            this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_tt_rpt_set DROP COLUMN tempTableId");
                            tc_tot_cost = 0;
                            tc_tot_price = 0;
                            Prev_product_code = product_code;
                            //END
                        }
                    }

                    #region CRUD LoadToVariable
                    var itemwhse2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                        {
                            {_tc_qtt_on_hand,"ISNULL(SUM(itemwhse.qty_on_hand), 0)"},
                            {_tc_qtt_mrb,"ISNULL(SUM(itemwhse.qty_mrb), 0)"},
                        },
                        loadForChange: false, 
                        lockingType: LockingType.None,
                        tableName: "itemwhse",
                        fromClause: collectionLoadRequestFactory.Clause(""),
                        whereClause: collectionLoadRequestFactory.Clause("itemwhse.item = {0}", item_item),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    this.appDB.Load(itemwhse2LoadRequest);
                    tc_qtt_on_hand = _tc_qtt_on_hand;
                    tc_qtt_mrb = _tc_qtt_mrb;
                    #endregion  LoadToVariable

                    //END
                }
                tc_qtt = (decimal?)(tc_qtt_on_hand + tc_qtt_mrb);
                tc_tot_item_cost = 0;
                if (sQLUtil.SQLEqual(tc_qtt, 0) == true && sQLUtil.SQLEqual(PrintZeroQty, 0) == true)
                {
                    continue;
                }
                if (sQLUtil.SQLNotEqual(stringUtil.CharIndex(item_cost_method, "AC"), 0) == true || sQLUtil.SQLEqual(item_cost_type, "S") == true)
                {
                    tc_tot_item_cost = (decimal?)(tc_qtt * item_unit_cost);
                }
                else
                {
                    if (sQLUtil.SQLNotEqual(stringUtil.CharIndex(item_cost_method, "LF"), 0) == true)
                    {
                        if (sQLUtil.SQLEqual(CostItemAtWhse, 1) == true)
                        {
                            #region CRUD LoadToVariable
                            var itemlifoLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                                {
                                    {_tc_tot_item_cost,"ISNULL(SUM(itemlifo.qty * itemlifo.unit_cost), 0)"},
                                },
                                loadForChange: false, 
                                lockingType: LockingType.None,
                                tableName: "itemlifo",
                                fromClause: collectionLoadRequestFactory.Clause(""),
                                whereClause: collectionLoadRequestFactory.Clause("itemlifo.item = {0} AND itemlifo.whse = {1}", item_item, Whse),
                                orderByClause: collectionLoadRequestFactory.Clause(""));
                            this.appDB.Load(itemlifoLoadRequest);
                            tc_tot_item_cost = _tc_tot_item_cost;
                            #endregion  LoadToVariable
                        }
                        else
                        {
                            #region CRUD LoadToVariable
                            var itemlifo1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                                {
                                    {_tc_tot_item_cost,"ISNULL(SUM(itemlifo.qty * itemlifo.unit_cost), 0)"},
                                },
                                loadForChange: false, 
                                lockingType: LockingType.None,
                                tableName: "itemlifo",
                                fromClause: collectionLoadRequestFactory.Clause(""),
                                whereClause: collectionLoadRequestFactory.Clause("itemlifo.item = {0}", item_item),
                                orderByClause: collectionLoadRequestFactory.Clause(""));
                            this.appDB.Load(itemlifo1LoadRequest);
                            tc_tot_item_cost = _tc_tot_item_cost;
                            #endregion  LoadToVariable
                        }
                    }
                    else
                    {
                        if (sQLUtil.SQLEqual(item_cost_method, "S") == true)
                        {
                            //BEGIN
                            if (sQLUtil.SQLEqual(item_lot_tracked, 1) == true)
                            {
                                if (sQLUtil.SQLEqual(CostItemAtWhse, 1) == true)
                                {
                                    #region CRUD LoadToVariable
                                    var itemlocLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                                        {
                                            {_tc_tot_item_cost,"ISNULL(SUM(lot_loc.qty_on_hand * lot_loc.unit_cost), 0)"},
                                        },
                                        loadForChange: false, 
                                        lockingType: LockingType.None,
                                        tableName: "itemloc",
                                        fromClause: collectionLoadRequestFactory.Clause(@" INNER JOIN lot_loc ON lot_loc.whse = itemloc.whse 
                                            AND lot_loc.item = itemloc.item 
                                            AND lot_loc.loc = itemloc.loc"),
                                        whereClause: collectionLoadRequestFactory.Clause("itemloc.item = {0} AND itemloc.whse = {1}", item_item, Whse),
                                        orderByClause: collectionLoadRequestFactory.Clause(""));
                                    this.appDB.Load(itemlocLoadRequest);
                                    tc_tot_item_cost = _tc_tot_item_cost;
                                    #endregion  LoadToVariable
                                }
                                else
                                {
                                    #region CRUD LoadToVariable
                                    var itemloc1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                                        {
                                            {_tc_tot_item_cost,"ISNULL(SUM(lot_loc.qty_on_hand * lot_loc.unit_cost), 0)"},
                                        },
                                        loadForChange: false, 
                                        lockingType: LockingType.None,
                                        tableName: "itemloc",
                                        fromClause: collectionLoadRequestFactory.Clause(@" INNER JOIN lot_loc ON lot_loc.whse = itemloc.whse 
                                            AND lot_loc.item = itemloc.item 
                                            AND lot_loc.loc = itemloc.loc"),
                                        whereClause: collectionLoadRequestFactory.Clause("itemloc.item = {0}", item_item),
                                        orderByClause: collectionLoadRequestFactory.Clause(""));
                                    this.appDB.Load(itemloc1LoadRequest);
                                    tc_tot_item_cost = _tc_tot_item_cost;
                                    #endregion  LoadToVariable
                                }
                            }
                            else
                            {
                                if (sQLUtil.SQLEqual(CostItemAtWhse, 1) == true)
                                {
                                    #region CRUD LoadToVariable
                                    var itemloc2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                                        {
                                            {_tc_tot_item_cost,"ISNULL(SUM(itemloc.qty_on_hand * itemloc.unit_cost), 0)"},
                                        },
                                        loadForChange: false,
                                        lockingType: LockingType.None,
                                        tableName: "itemloc",
                                        fromClause: collectionLoadRequestFactory.Clause(""),
                                        whereClause: collectionLoadRequestFactory.Clause("itemloc.item = {0} AND itemloc.whse = {1}", item_item, Whse),
                                        orderByClause: collectionLoadRequestFactory.Clause(""));
                                    this.appDB.Load(itemloc2LoadRequest);
                                    tc_tot_item_cost = _tc_tot_item_cost;
                                    #endregion  LoadToVariable
                                }
                                else
                                {
                                    #region CRUD LoadToVariable
                                    var itemloc3LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                                        {
                                            {_tc_tot_item_cost,"ISNULL(SUM(itemloc.qty_on_hand * itemloc.unit_cost), 0)"},
                                        },
                                        loadForChange: false, 
                                        lockingType: LockingType.None,
                                        tableName: "itemloc",
                                        fromClause: collectionLoadRequestFactory.Clause(""),
                                        whereClause: collectionLoadRequestFactory.Clause("itemloc.item = {0}", item_item),
                                        orderByClause: collectionLoadRequestFactory.Clause(""));
                                    this.appDB.Load(itemloc3LoadRequest);
                                    tc_tot_item_cost = _tc_tot_item_cost;
                                    #endregion  LoadToVariable
                                }
                            }
                            //END
                        }
                    }
                }
                _tc_cpr_price = 0;
                #region CRUD LoadToVariable
                var itempriceLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                    {
                        {_tc_cpr_price,"ISNULL(itemprice.unit_price1, 0)"},
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "itemprice",
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause("itemprice.item = {1} AND itemprice.effect_date <= {2} AND itemprice.curr_code = {0}", XDomCurrency, item_item, Today),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                this.appDB.Load(itempriceLoadRequest);
                tc_cpr_price = _tc_cpr_price;
                #endregion  LoadToVariable

                tc_tot_tmp_price = (decimal?)(tc_qtt * tc_cpr_price);
                t_item_stat = " ";
                if (sQLUtil.SQLEqual(item_stat, "O") == true)
                {
                    t_item_stat = "#";
                }
                else
                {
                    if (sQLUtil.SQLEqual(item_stat, "S") == true)
                    {
                        t_item_stat = "/";
                    }
                }
                if (item_unit_cost != null)
                {
                    tc_tot_cost = (decimal?)(tc_tot_cost + tc_tot_item_cost);
                }
                if (tc_cpr_price != null)
                {
                    tc_tot_price = (decimal?)(tc_tot_price + tc_tot_tmp_price);
                }

                #region CRUD LoadResponseWithoutTable
                var nonTable4LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
                    {
                        { "prodcode", variableUtil.GetValue<string>(product_code,true)},
                        { "item_stat", variableUtil.GetValue<string>(t_item_stat,true)},
                        { "item", variableUtil.GetValue<string>(stringUtil.Concat(t_item_stat, item_item),true)},
                        { "type", variableUtil.GetValue<string>(item_matl_type,true)},
                        { "source", variableUtil.GetValue<string>(item_pmt_code,true)},
                        { "stocked", variableUtil.GetValue<int?>(item_stocked,true)},
                        { "cost_type", variableUtil.GetValue<string>(item_cost_type,true)},
                        { "cost_method", variableUtil.GetValue<string>(item_cost_method,true)},
                        { "um", variableUtil.GetValue<string>(item_um,true)},
                        { "tot_on_hand", variableUtil.GetValue<decimal?>(tc_qtt,true)},
                        { "unit_price", variableUtil.GetValue<decimal?>(tc_cpr_price,true)},
                        { "unit_cost", variableUtil.GetValue<decimal?>(item_unit_cost,true)},
                        { "tot_price", variableUtil.GetValue<decimal?>(tc_tot_tmp_price,true)},
                        { "tot_cost", variableUtil.GetValue<decimal?>(tc_tot_item_cost,true)},
                        { "setup_cost_unit", variableUtil.GetValue<decimal?>(item_comp_setup,true)},
                        { "run_cost_unit", variableUtil.GetValue<decimal?>(item_comp_run,true)},
                        { "matl_cost_unit", variableUtil.GetValue<decimal?>(item_comp_matl,true)},
                        { "tool_cost_unit", variableUtil.GetValue<decimal?>(item_comp_tool,true)},
                        { "fixture_cost_unit", variableUtil.GetValue<decimal?>(item_comp_fixture,true)},
                        { "other_cost_unit", variableUtil.GetValue<decimal?>(item_comp_other,true)},
                        { "fixed_ovhd_unit", variableUtil.GetValue<decimal?>(item_comp_fixed,true)},
                        { "var_ovhd_unit", variableUtil.GetValue<decimal?>(item_comp_var,true)},
                        { "outside_unit", variableUtil.GetValue<decimal?>(item_comp_outside,true)},
                        { "setup_cost_onhand", variableUtil.GetValue<decimal?>(item_comp_setup * tc_qtt,true)},
                        { "run_cost_onhand", variableUtil.GetValue<decimal?>(item_comp_run * tc_qtt,true)},
                        { "matl_cost_onhand", variableUtil.GetValue<decimal?>(item_comp_matl * tc_qtt,true)},
                        { "tool_cost_onhand", variableUtil.GetValue<decimal?>(item_comp_tool * tc_qtt,true)},
                        { "fixture_cost_onhand", variableUtil.GetValue<decimal?>(item_comp_fixture * tc_qtt,true)},
                        { "other_cost_onhand", variableUtil.GetValue<decimal?>(item_comp_other * tc_qtt,true)},
                        { "fixed_ovhd_onhand", variableUtil.GetValue<decimal?>(item_comp_fixed * tc_qtt,true)},
                        { "var_ovhd_onhand", variableUtil.GetValue<decimal?>(item_comp_var * tc_qtt,true)},
                        { "outside_onhand", variableUtil.GetValue<decimal?>(item_comp_outside * tc_qtt,true)},
                        { "sub_tot_price", variableUtil.GetValue<decimal?>(null,true)},
                        { "sub_tot_cost", variableUtil.GetValue<decimal?>(null,true)},
                        { "DomCurrencyFormat", variableUtil.GetValue<string>(DomCurrencyFormat,true)},
                        { "DomCurrencyPlaces", variableUtil.GetValue<int?>(DomCurrencyPlaces,true)},
                        { "DomTotCurrencyFormat", variableUtil.GetValue<string>(DomTotCurrencyFormat,true)},
                        { "DomTotCurrencyPlaces", variableUtil.GetValue<int?>(DomTotCurrencyPlaces,true)},
                        { "CostPriceFormat", variableUtil.GetValue<string>(CostPriceFormat,true)},
                        { "CostPricePlaces", variableUtil.GetValue<int?>(CostPricePlaces,true)},
                        { "UnitQtyFormat", variableUtil.GetValue<string>(UnitQtyFormat,true)},
                        { "UnitQtyPlaces", variableUtil.GetValue<int?>(UnitQtyPlaces,true)},
                        { "Whse", variableUtil.GetValue<string>(Whse,true)},
                        { "TotLaborOnhandCost", variableUtil.GetValue<decimal?>(item_comp_setup * tc_qtt + item_comp_run * tc_qtt,true)},
                        { "TotTypeOnhandCost", variableUtil.GetValue<decimal?>(item_comp_matl * tc_qtt + item_comp_tool * tc_qtt + item_comp_fixture * tc_qtt + item_comp_other * tc_qtt,true)},
                        { "TotOvhdOnhandCost", variableUtil.GetValue<decimal?>(item_comp_fixed * tc_qtt + item_comp_var * tc_qtt + item_comp_outside * tc_qtt,true)},
                        { "TotUnitCost", variableUtil.GetValue<decimal?>(item_comp_setup + item_comp_run + item_comp_matl + item_comp_tool + item_comp_fixture + item_comp_other + item_comp_fixed + item_comp_var + item_comp_outside,true)},
                        { "TotOnhandCost", variableUtil.GetValue<decimal?>(item_comp_setup * tc_qtt + item_comp_run * tc_qtt + item_comp_matl * tc_qtt + item_comp_tool * tc_qtt + item_comp_fixture * tc_qtt + item_comp_other * tc_qtt + item_comp_fixed * tc_qtt + item_comp_var * tc_qtt + item_comp_outside * tc_qtt,true)},
                    });

                var nonTable4LoadResponse = this.appDB.Load(nonTable4LoadRequest);
                Data = nonTable4LoadResponse;
                #endregion CRUD LoadResponseWithoutTable

                #region CRUD InsertByRecords
                var nonTable4InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_tt_rpt_set",
                    items: nonTable4LoadResponse.Items);

                this.appDB.Insert(nonTable4InsertRequest);
                #endregion InsertByRecords

                //END
            }
            //Deallocate Cursor item_crs
            if (sQLUtil.SQLEqual(CostItemAtWhse, 1) == true)
            {
                #region CRUD LoadColumn
                var tv_tt_rpt_set4LoadRequest = collectionLoadRequestFactory.SQLLoad(columns: new List<string>()
                    {
                        "prodcode",
                        "item_stat",
                        "item",
                        "type",
                        "source",
                        "stocked",
                        "cost_type",
                        "cost_method",
                        "um",
                        "tot_on_hand",
                        "unit_price",
                        "unit_cost",
                        "tot_price",
                        "tot_cost",
                        "setup_cost_unit",
                        "run_cost_unit",
                        "matl_cost_unit",
                        "tool_cost_unit",
                        "fixture_cost_unit",
                        "other_cost_unit",
                        "fixed_ovhd_unit",
                        "var_ovhd_unit",
                        "outside_unit",
                        "setup_cost_onhand",
                        "run_cost_onhand",
                        "matl_cost_onhand",
                        "tool_cost_onhand",
                        "fixture_cost_onhand",
                        "other_cost_onhand",
                        "fixed_ovhd_onhand",
                        "var_ovhd_onhand",
                        "outside_onhand",
                        "sub_tot_price",
                        "sub_tot_cost",
                        "DomCurrencyFormat",
                        "DomCurrencyPlaces",
                        "DomTotCurrencyFormat",
                        "DomTotCurrencyPlaces",
                        "CostPriceFormat",
                        "CostPricePlaces",
                        "UnitQtyFormat",
                        "UnitQtyPlaces",
                        "Whse",
                        "TotLaborOnhandCost",
                        "TotTypeOnhandCost",
                        "TotOvhdOnhandCost",
                        "TotUnitCost",
                        "TotOnhandCost",
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "#tv_tt_rpt_set",
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause(""),
                    orderByClause: collectionLoadRequestFactory.Clause(" Whse, prodcode, item"));

                var tv_tt_rpt_set4LoadResponse = this.appDB.Load(tv_tt_rpt_set4LoadRequest);
                Data = tv_tt_rpt_set4LoadResponse;
                #endregion  LoadColumn
            }
            else
            {
                #region CRUD LoadColumn
                var tv_tt_rpt_set5LoadRequest = collectionLoadRequestFactory.SQLLoad(columns: new List<string>()
                    {
                        "prodcode",
                        "item_stat",
                        "item",
                        "type",
                        "source",
                        "stocked",
                        "cost_type",
                        "cost_method",
                        "um",
                        "tot_on_hand",
                        "unit_price",
                        "unit_cost",
                        "tot_price",
                        "tot_cost",
                        "setup_cost_unit",
                        "run_cost_unit",
                        "matl_cost_unit",
                        "tool_cost_unit",
                        "fixture_cost_unit",
                        "other_cost_unit",
                        "fixed_ovhd_unit",
                        "var_ovhd_unit",
                        "outside_unit",
                        "setup_cost_onhand",
                        "run_cost_onhand",
                        "matl_cost_onhand",
                        "tool_cost_onhand",
                        "fixture_cost_onhand",
                        "other_cost_onhand",
                        "fixed_ovhd_onhand",
                        "var_ovhd_onhand",
                        "outside_onhand",
                        "sub_tot_price",
                        "sub_tot_cost",
                        "DomCurrencyFormat",
                        "DomCurrencyPlaces",
                        "DomTotCurrencyFormat",
                        "DomTotCurrencyPlaces",
                        "CostPriceFormat",
                        "CostPricePlaces",
                        "UnitQtyFormat",
                        "UnitQtyPlaces",
                        "Whse",
                        "TotLaborOnhandCost",
                        "TotTypeOnhandCost",
                        "TotOvhdOnhandCost",
                        "TotUnitCost",
                        "TotOnhandCost",
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "#tv_tt_rpt_set",
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause(""),
                    orderByClause: collectionLoadRequestFactory.Clause(" prodcode, item"));

                var tv_tt_rpt_set5LoadResponse = this.appDB.Load(tv_tt_rpt_set5LoadRequest);
                Data = tv_tt_rpt_set5LoadResponse;
                #endregion  LoadColumn
            }
            this.transactionFactory.CommitTransaction("");

            #region CRUD ExecuteMethodCall

            //Please Generate the bounce for this stored procedure: CloseSessionContextSp
            var CloseSessionContext = this.iCloseSessionContext.CloseSessionContextSp(SessionID: RptSessionID);

            #endregion ExecuteMethodCall

            return (Data, Severity);
        }
        public (ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_Rpt_ItemCostbyProductCodeSp(string AltExtGenSp,
            string StartProdCode = null,
            string EndProdCode = null,
            string StartItem = null,
            string EndItem = null,
            string FromWarehouse = null,
            string ToWarehouse = null,
            string MatlStat = null,
            string MatlType = null,
            string Source = null,
            string Stocked = null,
            string ABCCode = null,
            int? PrintZeroQty = null,
            int? PrintCostDet = null,
            int? DisplayHeader = null,
            int? CostItemAtWhse = null,
            string pSite = null)
        {
            ProductCodeType _StartProdCode = StartProdCode;
            ProductCodeType _EndProdCode = EndProdCode;
            ItemType _StartItem = StartItem;
            ItemType _EndItem = EndItem;
            WhseType _FromWarehouse = FromWarehouse;
            WhseType _ToWarehouse = ToWarehouse;
            InfobarType _MatlStat = MatlStat;
            InfobarType _MatlType = MatlType;
            InfobarType _Source = Source;
            InfobarType _Stocked = Stocked;
            InfobarType _ABCCode = ABCCode;
            ListYesNoType _PrintZeroQty = PrintZeroQty;
            ListYesNoType _PrintCostDet = PrintCostDet;
            ListYesNoType _DisplayHeader = DisplayHeader;
            ListYesNoType _CostItemAtWhse = CostItemAtWhse;
            SiteType _pSite = pSite;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();
                IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "StartProdCode", _StartProdCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndProdCode", _EndProdCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartItem", _StartItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndItem", _EndItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FromWarehouse", _FromWarehouse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ToWarehouse", _ToWarehouse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "MatlStat", _MatlStat, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "MatlType", _MatlType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Source", _Source, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Stocked", _Stocked, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ABCCode", _ABCCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PrintZeroQty", _PrintZeroQty, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PrintCostDet", _PrintCostDet, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CostItemAtWhse", _CostItemAtWhse, ParameterDirection.Input);
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
