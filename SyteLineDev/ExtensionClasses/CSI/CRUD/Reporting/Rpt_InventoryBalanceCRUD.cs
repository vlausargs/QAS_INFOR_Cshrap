//PROJECT NAME: Reporting
//CLASS NAME: Rpt_InventoryBalanceCRUD.cs

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

namespace CSI.Reporting
{
    public class Rpt_InventoryBalanceCRUD : IRpt_InventoryBalanceCRUD
    {
        readonly IApplicationDB appDB;
        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionNonTriggerInsertRequestFactory nonTriggerInsertRequestFactory;
        readonly ICollectionNonTriggerUpdateRequestFactory nonTriggerUpdateRequestFactory;
        readonly ICollectionNonTriggerDeleteRequestFactory nonTriggerDeleteRequestFactory;
        readonly IExistsChecker existsChecker;
        readonly IVariableUtil variableUtil;
        readonly IStringUtil stringUtil;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly IAndSqlWhere iAndSqlWhere;
        readonly IAndSqlWhereWithISNULL iAndSqlWhereWithISNULL;
        readonly ITransactionFactory transactionFactory;
        readonly IGetIsolationLevel iGetIsolationLevel;
        readonly IScalarFunction scalarFunction;
        readonly IQueryLanguage queryLanguage;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IBookmarkFactory bookmarkFactory;
        readonly ISortOrderFactory sortOrderFactory;
        readonly IDefineProcessVariable defineProcessVariable;
        readonly IGetVariable getVariable;
        readonly ICache mgSessionVariableBasedCache;

        public Rpt_InventoryBalanceCRUD(IApplicationDB appDB,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionNonTriggerInsertRequestFactory collectionNonTriggerInsertRequestFactory,
            ICollectionNonTriggerUpdateRequestFactory collectionNonTriggerUpdateRequestFactory,
            ICollectionNonTriggerDeleteRequestFactory collectionNonTriggerDeleteRequestFactory,
            IExistsChecker existsChecker,
            IVariableUtil variableUtil,
            IStringUtil stringUtil,
            ISQLValueComparerUtil sQLUtil,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            IAndSqlWhere iAndSqlWhere,
            IAndSqlWhereWithISNULL iAndSqlWhereWithISNULL,
            ITransactionFactory transactionFactory,
            IGetIsolationLevel iGetIsolationLevel,
            IScalarFunction scalarFunction,
            IQueryLanguage queryLanguage,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IBookmarkFactory bookmarkFactory,
            ISortOrderFactory sortOrderFactory,
            IDefineProcessVariable defineProcessVariable,
            IGetVariable getVariable,
            ICache mgSessionVariableBasedCache)
        {
            this.appDB = appDB;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.nonTriggerInsertRequestFactory = collectionNonTriggerInsertRequestFactory;
            this.nonTriggerUpdateRequestFactory = collectionNonTriggerUpdateRequestFactory;
            this.nonTriggerDeleteRequestFactory = collectionNonTriggerDeleteRequestFactory;
            this.existsChecker = existsChecker;
            this.variableUtil = variableUtil;
            this.stringUtil = stringUtil;
            this.sQLUtil = sQLUtil;
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.iAndSqlWhere = iAndSqlWhere;
            this.iAndSqlWhereWithISNULL = iAndSqlWhereWithISNULL;
            this.transactionFactory = transactionFactory;
            this.iGetIsolationLevel = iGetIsolationLevel;
            this.scalarFunction = scalarFunction;
            this.queryLanguage = queryLanguage;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.bookmarkFactory = bookmarkFactory;
            this.sortOrderFactory = sortOrderFactory;
            this.defineProcessVariable = defineProcessVariable;
            this.getVariable = getVariable;
            this.mgSessionVariableBasedCache = mgSessionVariableBasedCache;
        }

        public void DeclareAltgenTable()
        {
            //this temp table is a table variable in old stored procedure version.
            this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					        [SpName] SYSNAME);
					    SELECT * into #tv_ALTGEN from @ALTGEN");
        }

        public bool Optional_ModuleForExists()
        {
            return existsChecker.Exists(tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_InventoryBalanceSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"));
        }

        public void InsertOptional_Module1()
        {
            var optional_module1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"SpName","CAST (NULL AS NVARCHAR)"},
                    {"u0","[om].[ModuleName]"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_InventoryBalanceSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
            foreach (var optional_module1Item in optional_module1LoadResponse.Items)
            {
                optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("Rpt_InventoryBalanceSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
            };

            var optional_module1RequiredColumns = new List<string>() { "SpName" };

            optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

            var optional_module1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ALTGEN", items: optional_module1LoadResponse.Items);

            this.appDB.Insert(optional_module1InsertRequest);
        }

        public bool Tv_ALTGENForExists()
        {
            return existsChecker.Exists(tableName: "#tv_ALTGEN",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""));
        }

        public (string ALTGEN_SpName, int? rowCount) LoadTv_ALTGEN1(string ALTGEN_SpName)
        {
            StringType _ALTGEN_SpName = DBNull.Value;

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

            int rowCount = tv_ALTGEN1LoadResponse.Items.Count;
            return (ALTGEN_SpName, rowCount);
        }

        public void DeleteTv_ALTGEN2(string ALTGEN_SpName)
        {
            this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
            var tv_ALTGEN2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"[SpName]","[SpName]"},
                },
                tableName: "#tv_ALTGEN",
                loadForChange: true,
                lockingType: LockingType.None,
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("[SpName] = {0}", ALTGEN_SpName),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var tv_ALTGEN2LoadResponse = this.appDB.Load(tv_ALTGEN2LoadRequest);
            var tv_ALTGEN2DeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "#tv_ALTGEN",
                items: tv_ALTGEN2LoadResponse.Items);
            this.appDB.Delete(tv_ALTGEN2DeleteRequest);
            this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
        }

        public void SetXact_Abort()
        {
            this.sQLExpressionExecutor.Execute("SET XACT_ABORT ON");
        }

        public void SetIsolationLevel()
        {            
            if (sQLUtil.SQLEqual(this.iGetIsolationLevel.GetIsolationLevelFn("InventoryBalanceSumReport"), "COMMITTED") == true)
            {
                this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ COMMITTED");
            }
            else
            {
                this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
            }
        }

        public void DeclareTmpInvrptSummSetTable()
        {
            this.sQLExpressionExecutor.Execute(@"DECLARE @invrpt_summ_set TABLE (
				        Item             NVARCHAR (40)   PRIMARY KEY,
				        ItemDesc         NVARCHAR (40)  ,
				        ItemUOM          NVARCHAR (10)  ,
				        UnitPrice        AmtTotType     ,
				        Qty              DECIMAL (20, 8),
				        RecvQty          DECIMAL (20, 8),
				        RecvAmount       AmtTotType     ,
				        IssueQty         DECIMAL (20, 8),
				        IssueAmount      AmtTotType     ,
				        ItemStartBalCost AmtTotType     );
				    SELECT * into #tv_invrpt_summ_set from @invrpt_summ_set
				    ALTER TABLE #tv_invrpt_summ_set ADD PRIMARY KEY (Item)");
        }

        public void DeclareTmpItemTable()
        {
            this.sQLExpressionExecutor.Execute(@"CREATE TABLE #item (
				        Item              NVARCHAR (40)    COLLATE DATABASE_DEFAULT PRIMARY KEY,
				        ItemDesc          NVARCHAR (40)    COLLATE DATABASE_DEFAULT,
				        UM                NVARCHAR (10)    COLLATE DATABASE_DEFAULT,
				        LotTracked        BIT             ,
				        CostType          NVARCHAR (1)     COLLATE DATABASE_DEFAULT,
				        CostMethod        NVARCHAR (1)     COLLATE DATABASE_DEFAULT,
				        UnitCost          DECIMAL (25, 10),
				        TotQty            DECIMAL (25, 10),
				        StartingBalAmount DECIMAL (25, 10),
				        StartingBalQty    DECIMAL (25, 10),
				        MatltranRecCount  INT             ,
				        ItemQty           DECIMAL (25, 10),
				        ItemAmount        DECIMAL (25, 10),
				        TotAmount         DECIMAL (25, 10),
				        ItemStartBalCost  DECIMAL (25, 10)
				    )");
        }

        public void DeclareTmpSumTable()
        {
            this.sQLExpressionExecutor.Execute(@"DECLARE @SUM TABLE (
				        item             NVARCHAR (40)    PRIMARY KEY,
				        TotQty           DECIMAL (25, 10),
				        UnitPrice        DECIMAL (25, 10),
				        matltranRecCount INT             ,
				        TotAmount        DECIMAL (25, 10));
				    SELECT * into #tv_SUM from @SUM
				    ALTER TABLE #tv_SUM ADD PRIMARY KEY (item)");
        }

        public void DeclareTmpLotLocTable()
        {
            this.sQLExpressionExecutor.Execute(@"DECLARE @LotLoc TABLE (
				        item        NVARCHAR (30)   ,
				        whse        NVARCHAR (10)   ,
				        loc         NVARCHAR (15)   ,
				        lot         NVARCHAR (30)   ,
				        qty_on_hand DECIMAL (25, 10),
				        unit_cost   DECIMAL (25, 10) PRIMARY KEY (item, whse, loc, lot));
				    SELECT * into #tv_LotLoc from @LotLoc
				    ALTER TABLE #tv_LotLoc ADD PRIMARY KEY (item, whse, loc, lot)");
        }

        public void DeclareTmpItemLocTable()
        {
            this.sQLExpressionExecutor.Execute(@"DECLARE @ItemLoc TABLE (
				        item        NVARCHAR (30)   ,
				        whse        NVARCHAR (10)   ,
				        loc         NVARCHAR (15)   ,
				        qty_on_hand DECIMAL (25, 10),
				        unit_cost   DECIMAL (25, 10) PRIMARY KEY (item, whse, loc));
				    SELECT * into #tv_ItemLoc from @ItemLoc
				    ALTER TABLE #tv_ItemLoc ADD PRIMARY KEY (item, whse, loc)");
        }

        public void DeclareTmpItemLifoTable()
        {
            this.sQLExpressionExecutor.Execute(@"DECLARE @ItemLifo TABLE (
				        item      NVARCHAR (30)   ,
				        whse      NVARCHAR (10)   ,
				        qty       DECIMAL (25, 10),
				        unit_cost DECIMAL (25, 10),
				        seq       INT              IDENTITY (1, 1) PRIMARY KEY (item, whse, seq));
				    SELECT * into #tv_ItemLifo from @ItemLifo
				    ALTER TABLE #tv_ItemLifo ADD PRIMARY KEY (item, whse, seq)");
        }

        public void DeclareTmpMatltranTable()
        {
            this.sQLExpressionExecutor.Execute(@"CREATE TABLE #matltran (
				        item         NVARCHAR (30)    COLLATE DATABASE_DEFAULT,
				        trans_num    DECIMAL (10, 0) ,
				        trans_type   NVARCHAR (1)     COLLATE DATABASE_DEFAULT,
				        qty          DECIMAL (25, 10),
				        cost         DECIMAL (25, 10),
				        trans_date   DATETIME        ,
				        whse         NVARCHAR (4)     COLLATE DATABASE_DEFAULT,
				        loc          NVARCHAR (15)    COLLATE DATABASE_DEFAULT,
				        ref_type     NVARCHAR (1)     COLLATE DATABASE_DEFAULT,
				        document_num NVARCHAR (12)    COLLATE DATABASE_DEFAULT
				    )");
            this.sQLExpressionExecutor.Execute(@"CREATE UNIQUE INDEX #matltran_trans_num
				        ON #matltran(trans_num)");
            this.sQLExpressionExecutor.Execute(@"CREATE UNIQUE INDEX #matltran_item
				        ON #matltran(item, trans_num)");
            this.sQLExpressionExecutor.Execute(@"CREATE UNIQUE INDEX #matltran_trans_date
				        ON #matltran(item, trans_date, trans_num)");
        }

            public (string Site, int? rowCount) LoadParms(string Site)
        {
            SiteType _Site = DBNull.Value;

            var parmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_Site,"parms.site"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "parms",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var parmsLoadResponse = this.appDB.Load(parmsLoadRequest);
            if (parmsLoadResponse.Items.Count > 0)
            {
                Site = _Site;
            }

            int rowCount = parmsLoadResponse.Items.Count;
            return (Site, rowCount);
        }

        public (string XDomCurrency,
            int? DomCurrencyPlaces,
            string DomCurrencyFormat,
            string DomTotCurrencyFormat,
            int? CostPricePlaces,
            string CostPriceFormat, int? rowCount)
        LoadCurrparms(string XDomCurrency,
            string DomCurrencyFormat,
            int? DomCurrencyPlaces,
            string DomTotCurrencyFormat,
            string CostPriceFormat,
            int? CostPricePlaces)
        {
            CurrCodeType _XDomCurrency = DBNull.Value;
            DecimalPlacesType _DomCurrencyPlaces = DBNull.Value;
            InputMaskType _DomCurrencyFormat = DBNull.Value;
            InputMaskType _DomTotCurrencyFormat = DBNull.Value;
            DecimalPlacesType _CostPricePlaces = DBNull.Value;
            InputMaskType _CostPriceFormat = DBNull.Value;

            var currparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_XDomCurrency,"currparms.curr_code"},
                    {_DomCurrencyPlaces,"currency.places"},
                    {_DomCurrencyFormat,"currency.amt_format"},
                    {_DomTotCurrencyFormat,"currency.amt_tot_format"},
                    {_CostPricePlaces,"currency.places_cp"},
                    {_CostPriceFormat,"currency.cst_prc_format"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "currparms",
                fromClause: collectionLoadRequestFactory.Clause(" INNER JOIN currency ON currency.curr_code = currparms.curr_code"),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var currparmsLoadResponse = this.appDB.Load(currparmsLoadRequest);
            if (currparmsLoadResponse.Items.Count > 0)
            {
                XDomCurrency = _XDomCurrency;
                DomCurrencyPlaces = _DomCurrencyPlaces;
                DomCurrencyFormat = _DomCurrencyFormat;
                DomTotCurrencyFormat = _DomTotCurrencyFormat;
                CostPricePlaces = _CostPricePlaces;
                CostPriceFormat = _CostPriceFormat;
            }

            int rowCount = currparmsLoadResponse.Items.Count;
            return (XDomCurrency, DomCurrencyPlaces, DomCurrencyFormat, DomTotCurrencyFormat, CostPricePlaces, CostPriceFormat, rowCount);
        }

        public (string UnitQtyFormat, int? UnitQtyPlaces, int? rowCount) LoadINVPARMS(string UnitQtyFormat, int? UnitQtyPlaces)
        {
            InputMaskType _UnitQtyFormat = DBNull.Value;
            DecimalPlacesType _UnitQtyPlaces = DBNull.Value;

            var INVPARMSLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_UnitQtyFormat,"qty_unit_format"},
                    {_UnitQtyPlaces,"places_qty_unit"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                maximumRows: 1,
                tableName: "INVPARMS",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var INVPARMSLoadResponse = this.appDB.Load(INVPARMSLoadRequest);
            if (INVPARMSLoadResponse.Items.Count > 0)
            {
                UnitQtyFormat = _UnitQtyFormat;
                UnitQtyPlaces = _UnitQtyPlaces;
            }

            int rowCount = INVPARMSLoadResponse.Items.Count;
            return (UnitQtyFormat, UnitQtyPlaces, rowCount);
        }

        public (int? CostItemAtWhse, int? rowCount) LoadDbo_Invparms(int? CostItemAtWhse)
        {
            ListYesNoType _CostItemAtWhse = DBNull.Value;

            var dbo_invparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_CostItemAtWhse,"invparms.cost_item_at_whse"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "dbo.invparms",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var dbo_invparmsLoadResponse = this.appDB.Load(dbo_invparmsLoadRequest);
            if (dbo_invparmsLoadResponse.Items.Count > 0)
            {
                CostItemAtWhse = _CostItemAtWhse;
            }

            int rowCount = dbo_invparmsLoadResponse.Items.Count;
            return (CostItemAtWhse, rowCount);
        }

        public void InsertTmpItem(
            int? CostItemAtWhse, 
            int? AllItem, 
            int? AllDocumentNum, 
            int? IncludeNonNetStk,
            string WhseStarting, 
            string WhseEnding, 
            string ProductCodeStarting, 
            string ProductCodeEnding,
            string ItemStarting, 
            string ItemEnding,
            string LocStarting, 
            string LocEnding,
            string DocumentNumStarting,
            string DocumentNumEnding)
        {
            var unitCost = stringUtil.Concat(@"CASE WHEN (SELECT SUM(itemwhse.qty_on_hand + itemwhse.qty_mrb)
					              FROM itemwhse
					              WHERE itemwhse.item = item.item
					                ", this.iAndSqlWhere.AndSqlWhereFn("itemwhse", "whse", 1, WhseStarting, WhseEnding), @") = 0
					       THEN CASE WHEN item.cost_method = 'A' AND item.cost_type = 'A'
					           THEN (SELECT AVG(itemwhse.avg_u_cost)
					              FROM itemwhse
					              WHERE itemwhse.item = item.item
					                ", this.iAndSqlWhere.AndSqlWhereFn("itemwhse", "whse", 1, WhseStarting, WhseEnding), @")
					           ELSE (SELECT AVG(itemwhse.unit_cost)
					              FROM itemwhse
					              WHERE itemwhse.item = item.item
					                ", this.iAndSqlWhere.AndSqlWhereFn("itemwhse", "whse", 1, WhseStarting, WhseEnding), @")
					          END
					       ELSE CASE WHEN item.cost_method = 'A' AND item.cost_type = 'A'
					           THEN(SELECT SUM((itemwhse.qty_on_hand + itemwhse.qty_mrb) * itemwhse.avg_u_cost) / SUM(itemwhse.qty_on_hand + itemwhse.qty_mrb)
					              FROM itemwhse
					              WHERE itemwhse.item = item.item
					                ", this.iAndSqlWhere.AndSqlWhereFn("itemwhse", "whse", 1, WhseStarting, WhseEnding), @")
					           ELSE (SELECT SUM((itemwhse.qty_on_hand + itemwhse.qty_mrb) * itemwhse.unit_cost) / SUM(itemwhse.qty_on_hand + itemwhse.qty_mrb)
					              FROM itemwhse
					              WHERE itemwhse.item = item.item
					                ", this.iAndSqlWhere.AndSqlWhereFn("itemwhse", "whse", 1, WhseStarting, WhseEnding), @")
					        END
					   END");

            var whereClauseStr = stringUtil.Concat("1=1 ",
                   this.iAndSqlWhere.AndSqlWhereFn("item", "product_code", 1, ProductCodeStarting, ProductCodeEnding),
                   (sQLUtil.SQLEqual(AllItem, 0) == true ? this.iAndSqlWhere.AndSqlWhereFn("item", "item", 1, ItemStarting, ItemEnding) : ""));

            if (AllDocumentNum == 1)
            {
                whereClauseStr = stringUtil.Concat(whereClauseStr, " AND (", @" exists (select 1 from itemloc where
						         itemloc.item = item.item",
                             this.iAndSqlWhere.AndSqlWhereFn("itemloc", "whse", 1, WhseStarting, WhseEnding),
                             this.iAndSqlWhere.AndSqlWhereFn("itemloc", "loc", 1, LocStarting, LocEnding),
                             (sQLUtil.SQLEqual(IncludeNonNetStk, 0) == true ? "   AND (ISNULL(itemloc.mrb_flag,0) = 0))" : ")"),
                             " OR exists (select 1 from matltran where matltran.item = item.item",
                             this.iAndSqlWhere.AndSqlWhereFn("matltran", "whse", 1, WhseStarting, WhseEnding),
                             this.iAndSqlWhere.AndSqlWhereFn("matltran", "loc", 1, LocStarting, LocEnding), "))");

            }
            else
            {
                whereClauseStr = stringUtil.Concat(whereClauseStr, " AND (",
                    " exists (select 1 from matltran where matltran.item = item.item",
                    this.iAndSqlWhere.AndSqlWhereFn("matltran", "whse", 1, WhseStarting, WhseEnding),
                    this.iAndSqlWhere.AndSqlWhereFn("matltran", "loc", 1, LocStarting, LocEnding),
                    this.iAndSqlWhere.AndSqlWhereFn("matltran", "document_num", 1, DocumentNumStarting, DocumentNumEnding), "))");

            }

            var insertRequest = nonTriggerInsertRequestFactory.SQLInsert(
                targetTableName: "#item",
                targetColumns: new List<string> {
                    "Item",
                    "ItemDesc",
                    "UM",
                    "LotTracked",
                    "CostType",
                    "CostMethod",
                    "UnitCost"},
                valuesByExpressionToAssign:new Dictionary<string, IParameterizedCommand>
                {
                    {"Item",nonTriggerInsertRequestFactory.Clause("item.item")},
                    {"ItemDesc",nonTriggerInsertRequestFactory.Clause("item.description")},
                    {"UM",nonTriggerInsertRequestFactory.Clause("item.u_m")},
                    {"LotTracked",nonTriggerInsertRequestFactory.Clause("item.lot_tracked")},
                    {"CostType",nonTriggerInsertRequestFactory.Clause("item.cost_type")},
                    {"CostMethod",nonTriggerInsertRequestFactory.Clause("item.cost_method")},
                    {"UnitCost",nonTriggerInsertRequestFactory.Clause(CostItemAtWhse == 1 ? unitCost : "CASE WHEN item.cost_method = 'A' AND item.cost_type = 'A' THEN item.avg_u_cost ELSE item.unit_cost END")},
                },
                fromClause: nonTriggerInsertRequestFactory.Clause("Item"),
                whereClause: nonTriggerInsertRequestFactory.Clause(whereClauseStr)
                );
            this.appDB.InsertWithoutTrigger(insertRequest);
        }

        public void InsertLotloc(string WhseStarting, string WhseEnding, string LocStarting, string LocEnding)
        {
            var fromClause = nonTriggerInsertRequestFactory.Clause(@"#Item as item inner join lot_loc on lot_loc.item = item.item
					and lot_loc.whse between {0} and {2}
					and lot_loc.loc between {1} and {3}
					and lot_loc.qty_on_hand != 0", WhseStarting, LocStarting, WhseEnding, LocEnding);
            var whereClause = nonTriggerInsertRequestFactory.Clause("item.LotTracked = 1");

            var insertRequest = nonTriggerInsertRequestFactory.SQLInsert(
                targetTableName: "#tv_LotLoc",
                targetColumns: new List<string> {
                    "item",
                    "whse",
                    "loc",
                    "lot",
                    "qty_on_hand",
                    "unit_cost"},
                valuesByExpressionToAssign: new Dictionary<string, IParameterizedCommand>
                {
                    {"item",nonTriggerInsertRequestFactory.Clause("lot_loc.item")},
                    {"whse",nonTriggerInsertRequestFactory.Clause("lot_loc.whse")},
                    {"loc",nonTriggerInsertRequestFactory.Clause("lot_loc.loc")},
                    {"lot",nonTriggerInsertRequestFactory.Clause("lot_loc.lot")},
                    {"qty_on_hand",nonTriggerInsertRequestFactory.Clause("lot_loc.qty_on_hand")},
                    {"unit_cost",nonTriggerInsertRequestFactory.Clause("lot_loc.unit_cost")}
                },
                fromClause: fromClause,
                whereClause: whereClause);
            this.appDB.InsertWithoutTrigger(insertRequest);
        }

        public void InsertItemloc(string WhseStarting, string WhseEnding, string LocStarting, string LocEnding, int? IncludeNonNetStk)
        {
            var fromClause = nonTriggerInsertRequestFactory.Clause(@"#Item as item inner join itemloc on itemloc.item = item.item
					and itemloc.whse between {1} and {3}
					and itemloc.loc between {2} and {4}
					and itemloc.mrb_flag not in (case {0} when 0 then 1 else 2 end)
					and itemloc.qty_on_hand != 0", IncludeNonNetStk, WhseStarting, LocStarting, WhseEnding, LocEnding);
            var whereClause = nonTriggerInsertRequestFactory.Clause("item.LotTracked = 0 AND ((CostMethod = 'S' AND CostType = 'A') OR (CostMethod = 'A' AND CostType = 'A') OR (CostType = 'S'))");

            var insertRequest = nonTriggerInsertRequestFactory.SQLInsert(
                targetTableName: "#tv_ItemLoc",
                targetColumns: new List<string> {
                    "item",
                    "whse",
                    "loc",
                    "qty_on_hand",
                    "unit_cost"},
                valuesByExpressionToAssign: new Dictionary<string, IParameterizedCommand>
                {
                    {"item",nonTriggerInsertRequestFactory.Clause("itemloc.item")},
                    {"whse",nonTriggerInsertRequestFactory.Clause("itemloc.whse")},
                    {"loc",nonTriggerInsertRequestFactory.Clause("itemloc.loc")},
                    {"qty_on_hand",nonTriggerInsertRequestFactory.Clause("itemloc.qty_on_hand")},
                    {"unit_cost",nonTriggerInsertRequestFactory.Clause("itemloc.unit_cost")}
                },
                fromClause: fromClause,
                whereClause: whereClause);
            this.appDB.InsertWithoutTrigger(insertRequest);
        }

        public void InsertItemLifo(int? CostItemAtWhse, string WhseStarting, string WhseEnding)
        {
            var fromClause = CostItemAtWhse == 1 ? nonTriggerInsertRequestFactory.Clause(@"#Item as item inner join itemlifo on itemlifo.item = item.item
					and itemlifo.whse between {0} and {1}", WhseStarting, WhseEnding) : nonTriggerInsertRequestFactory.Clause("#Item AS item INNER JOIN itemlifo ON itemlifo.item = item.item");

            var whereClause = nonTriggerInsertRequestFactory.Clause("((item.CostMethod = 'F' OR item.CostMethod = 'L') AND CostType = 'A')");

            var insertRequest = nonTriggerInsertRequestFactory.SQLInsert(
                targetTableName: "#tv_ItemLifo",
                targetColumns: new List<string> {
                    "item",
                    "whse",
                    "qty",
                    "unit_cost"},
                valuesByExpressionToAssign: new Dictionary<string, IParameterizedCommand>
                {
                    {"item",nonTriggerInsertRequestFactory.Clause("itemlifo.item")},
                    {"whse",nonTriggerInsertRequestFactory.Clause("ISNULL(itemlifo.whse, '')")},
                    {"qty",nonTriggerInsertRequestFactory.Clause("itemlifo.qty")},
                    {"unit_cost",nonTriggerInsertRequestFactory.Clause("itemlifo.unit_cost")}
                },
                fromClause: fromClause,
                whereClause: whereClause);
            this.appDB.InsertWithoutTrigger(insertRequest);
        }

        public void InsertToSum(int? IncludeNonNetStk)
        {
            var SQL = @"INSERT INTO #tv_SUM
                    SELECT item.item
                    , SUM(lot_loc.qty_on_hand)
                    , CASE
                         WHEN(CostMethod = 'S' AND CostType = 'A')
                              THEN SUM(lot_loc.qty_on_hand* lot_loc.unit_cost)
                                / CASE SUM(lot_loc.qty_on_hand) WHEN 0 THEN 1 ELSE SUM(lot_loc.qty_on_hand) END
                         WHEN(CostMethod = 'A' AND CostType = 'A')
                              THEN item.UnitCost
                         WHEN(CostType = 'S')
                              THEN item.UnitCost
                         ELSE NULL
                      END
                    ,0
                    ,SUM(lot_loc.qty_on_hand *
                       CASE WHEN(CostMethod = 'S' AND CostType = 'A') THEN lot_loc.unit_cost
                            WHEN(CostMethod = 'A' AND CostType = 'A') THEN item.unitcost
                            WHEN(CostType = 'S') THEN item.UnitCost
                            ELSE NULL
                        END
                        )
                    FROM #item AS item
                       INNER JOIN #tv_LotLoc AS lot_loc ON
                          lot_loc.item = item.item
                       INNER JOIN itemloc ON
                          itemloc.item = lot_loc.item
                          AND itemloc.whse = lot_loc.whse
                          AND itemloc.loc = lot_loc.loc
                          AND itemloc.mrb_flag NOT IN(CASE {0} WHEN 0 THEN 1 ELSE 2 END)
                    WHERE item.LotTracked = 1
                    AND((CostMethod = 'S' AND CostType = 'A') OR(CostMethod = 'A' AND CostType = 'A') OR(CostType = 'S'))
                    GROUP BY item.item, item.CostMethod, item.CostType, item.UnitCost";
            this.sQLExpressionExecutor.Execute(SQL, IncludeNonNetStk);
        }

        public void InsertToSum1()
        {
            var SQL = @"INSERT INTO #tv_SUM
                    SELECT item.item
                    , SUM(itemloc.qty_on_hand)
                    , CASE
                         WHEN (CostMethod = 'S' AND CostType = 'A')
                              THEN SUM(itemloc.qty_on_hand * itemloc.unit_cost)
                                / CASE SUM(itemloc.qty_on_hand) WHEN 0 THEN 1 ELSE SUM(itemloc.qty_on_hand) END
                         WHEN (CostMethod = 'A' AND CostType = 'A')
                              THEN item.UnitCost
                         WHEN (CostType = 'S')
                              THEN item.UnitCost
                         ELSE NULL
                      END
                    ,0
                    ,SUM(itemloc.qty_on_hand *
                       CASE WHEN (CostMethod = 'S' AND CostType = 'A') THEN itemloc.unit_cost
                            WHEN (CostMethod = 'A' AND CostType = 'A') THEN item.unitcost
                            WHEN (CostType = 'S') THEN item.UnitCost
                            ELSE NULL
                        END
                        )
                    FROM #item AS item
                       INNER JOIN #tv_ItemLoc AS itemloc ON
                          itemloc.item = item.item
                    WHERE item.LotTracked = 0
                    AND ((CostMethod = 'S' AND CostType = 'A') OR (CostMethod = 'A' AND CostType = 'A') OR (CostType = 'S'))
                    GROUP BY item.item, item.CostMethod, item.CostType, item.UnitCost";
            this.sQLExpressionExecutor.Execute(SQL);
        }

        public void InsertToSum2(string WhseStarting, string WhseEnding, string LocStarting, string LocEnding, int? IncludeNonNetStk)
        {
            var SQL = @"INSERT INTO #tv_SUM
                    SELECT item.item
                    , SUM(itemlifo.qty)
                    , SUM(itemlifo.qty * itemlifo.unit_cost)
                      / ( CASE SUM(itemlifo.qty) WHEN 0 THEN 1 ELSE SUM(itemlifo.qty) END )
                    ,0
                    ,SUM(itemlifo.qty * itemlifo.unit_cost)
                    FROM #item AS item
                       INNER JOIN #tv_ItemLifo AS itemlifo ON itemlifo.item = item.item
                    WHERE ( (item.CostMethod = 'F' OR item.CostMethod = 'L') AND CostType = 'A' )
                    AND EXISTS ( SELECT 1 FROM itemloc WHERE
                          itemloc.item = item.item
                          AND itemloc.whse BETWEEN {0} AND {1}
                          AND itemloc.loc BETWEEN {2} AND {3}
                          AND itemloc.mrb_flag NOT IN (CASE {4} WHEN 0 THEN 1 ELSE 2 END)
                          AND itemloc.qty_on_hand != 0
                    )
                    GROUP BY item.item, item.CostMethod, item.CostType, item.UnitCost";
            this.sQLExpressionExecutor.Execute(SQL, WhseStarting, WhseEnding, LocStarting, LocEnding, IncludeNonNetStk);
        }

        public void UpdateItem()
        {
            var updateRequest = this.nonTriggerUpdateRequestFactory.SQLUpdate(
                tableName: "#item",
                expressionByColumnToAssign: new Dictionary<string, IParameterizedCommand> {
                        {"UnitCost", this.nonTriggerUpdateRequestFactory.Clause("ItemSum.UnitPrice")},
                        {"TotQty", this.nonTriggerUpdateRequestFactory.Clause("ItemSum.TotQty")},
                        {"TotAmount", this.nonTriggerUpdateRequestFactory.Clause("ItemSum.TotAmount")},
                },
                fromClause: this.nonTriggerUpdateRequestFactory.Clause("#item AS item INNER JOIN #tv_SUM AS ItemSum ON ItemSum.item = item.item"),
                whereClause: this.nonTriggerUpdateRequestFactory.Clause(""));
            this.appDB.UpdateWithoutTrigger(updateRequest);
        }

        public void InsertMatltran(
            int? IncludeNonNetStk,
            int? AllWhse,
            string LowChar,
            int? AllLoc,
            int? AllReasonCode,
            int? AllDocumentNum,
            DateTime? TransDateStarting,
            DateTime? Today,
            string WhseStarting,
            string WhseEnding,
            string LocStarting,
            string LocEnding,
            string ReasonCodeStarting,
            string ReasonCodeEnding,
            string DocumentNumStarting,
            string DocumentNumEnding)
        {
            var fromClauseStr = stringUtil.Concat(@"matltran as MT
				INNER JOIN #item as item on item.item = mt.item
				", (IncludeNonNetStk == 0 ? @" LEFT OUTER JOIN itemloc on
				      itemloc.item = mt.item
				      AND itemloc.whse = mt.whse
				      AND itemloc.loc = mt.loc" : ""));

            var whereClauseStr = stringUtil.Concat(@" MT.trans_date >= {0} and MT.RecordDate <= {1} ", 
                (sQLUtil.SQLEqual(AllWhse, 0) == true ? this.iAndSqlWhereWithISNULL.AndSqlWhereWithISNULLFn("MT", "whse", LowChar, 1, WhseStarting, WhseEnding) : ""), 
                (sQLUtil.SQLEqual(AllLoc, 0) == true ? this.iAndSqlWhereWithISNULL.AndSqlWhereWithISNULLFn("MT", "loc", LowChar, 1, LocStarting, LocEnding) : ""), 
                (sQLUtil.SQLEqual(AllReasonCode, 0) == true ? this.iAndSqlWhereWithISNULL.AndSqlWhereWithISNULLFn("MT", "reason_code", LowChar, 1, ReasonCodeStarting, ReasonCodeEnding) : ""), 
                (sQLUtil.SQLEqual(AllDocumentNum, 0) == true ? this.iAndSqlWhereWithISNULL.AndSqlWhereWithISNULLFn("MT", "document_num", LowChar, 1, DocumentNumStarting, DocumentNumEnding) : ""),
                (sQLUtil.SQLEqual(IncludeNonNetStk, 0) == true ? "   AND (ISNULL(itemloc.mrb_flag,0) = 0)" : ""), 
                @" AND (
				      (MT.trans_type = 'A' AND MT.qty != 0) OR
				      (MT.trans_type = 'A' AND MT.qty = 0) OR
				      (MT.trans_type = 'B') OR
				      (MT.trans_type = 'D' AND MT.qty < 0) OR
				      (MT.trans_type = 'D' AND MT.qty > 0) OR
				      (MT.trans_type = 'F' AND MT.ref_type = 'K') OR
				      (MT.trans_type = 'F' AND MT.ref_type = 'S') OR
				      (MT.trans_type = 'F' AND MT.ref_type not in('K','S')) OR
				      (MT.trans_type = 'G') OR
				      (MT.trans_type = 'H') OR
				      (MT.trans_type = 'I' AND MT.ref_type = 'C') OR
				      (MT.trans_type = 'I' AND MT.ref_type = 'K' AND MT.qty <> 0) OR
				      (MT.trans_type = 'I' AND MT.ref_type = 'S' AND MT.qty <> 0) OR
				      (MT.trans_type = 'I' AND MT.ref_type = 'W') OR
				      (MT.trans_type = 'I' AND MT.ref_type not in('K','S','W') AND MT.qty <> 0) OR
				      (MT.trans_type = 'L') OR
				      (MT.trans_type = 'M' AND MT.qty > 0) OR
				      (MT.trans_type = 'M' AND MT.qty <= 0) OR
				      (MT.trans_type = 'P') OR
				      (MT.trans_type = 'R' AND MT.ref_type = 'K') OR
				      (MT.trans_type = 'R' AND MT.ref_type = 'S') OR
				      (MT.trans_type = 'R' AND MT.ref_type = 'P' AND MT.loc IS NOT NULL) OR
				      (MT.trans_type = 'R' AND MT.ref_type not in('K','S', 'P') AND MT.qty < 0) OR
				      (MT.trans_type = 'R' AND MT.ref_type not in('K','S', 'P') AND MT.qty >= 0) OR
				      (MT.trans_type = 'S' AND MT.qty > 0 AND MT.loc IS NOT NULL) OR
				      (MT.trans_type = 'S' AND MT.qty <= 0 AND MT.loc IS NOT NULL) OR
				      (MT.trans_type = 'T' AND MT.qty > 0) OR
				      (MT.trans_type = 'T' AND MT.qty <=0) OR
				      (MT.trans_type = 'W' AND MT.ref_type = 'C') OR
				      (MT.trans_type = 'W' AND MT.ref_type = 'J') OR
				      (MT.trans_type = 'W' AND MT.ref_type = 'K') OR
				      (MT.trans_type = 'W' AND MT.ref_type = 'O' AND MT.qty > 0) OR
				      (MT.trans_type = 'W' AND MT.ref_type = 'O' AND MT.qty <= 0) OR
				      (MT.trans_type = 'W' AND MT.ref_type = 'P' AND MT.qty < 0 AND MT.loc IS NOT NULL) OR
				      (MT.trans_type = 'W' AND MT.ref_type = 'P' AND MT.qty >= 0 AND MT.loc IS NOT NULL) OR
				      (MT.trans_type = 'W' AND MT.ref_type = 'S') OR
				      (MT.trans_type = 'W' AND MT.ref_type = 'R') OR
				      (MT.trans_type = 'W' AND MT.ref_type = 'W')
				   )");

            var insertRequest = nonTriggerInsertRequestFactory.SQLInsert(
                targetTableName: "#matltran",
                targetColumns: new List<string> {
                    "item",
                    "trans_num",
                    "trans_type",
                    "qty",
                    "cost",
                    "trans_date",
                    "whse",
                    "loc",
                    "ref_type",
                    "document_num"},
                valuesByExpressionToAssign: new Dictionary<string, IParameterizedCommand>
                {
                    {"item",nonTriggerInsertRequestFactory.Clause("MT.item")},
                    {"trans_num",nonTriggerInsertRequestFactory.Clause("MT.trans_num")},
                    {"trans_type",nonTriggerInsertRequestFactory.Clause("MT.trans_type")},
                    {"qty",nonTriggerInsertRequestFactory.Clause("MT.qty")},
                    {"cost",nonTriggerInsertRequestFactory.Clause("MT.cost")},
                    {"trans_date",nonTriggerInsertRequestFactory.Clause("MT.trans_date")},
                    {"whse",nonTriggerInsertRequestFactory.Clause("MT.whse")},
                    {"loc",nonTriggerInsertRequestFactory.Clause("MT.loc")},
                    {"ref_type",nonTriggerInsertRequestFactory.Clause("MT.ref_type")},
                    {"document_num",nonTriggerInsertRequestFactory.Clause("MT.document_num")}                   
                },
                fromClause: nonTriggerInsertRequestFactory.Clause(fromClauseStr),
                whereClause: nonTriggerInsertRequestFactory.Clause(whereClauseStr, TransDateStarting, Today));
            this.appDB.InsertWithoutTrigger(insertRequest);
        }

        public void DeclareTmpTranSumTable()
        {
            if (this.scalarFunction.Execute<int?>(
                       "OBJECT_ID",
                       "tempdb..#tranSUM") == null)
            {

                this.sQLExpressionExecutor.Execute(@"Declare
					    @t_item ItemType
					    ,@t_trans_num QtyTotlType
					    ,@amt AmtTotType
					    SELECT @t_item AS item,
					           @t_trans_num AS trans_num,
					           @amt AS amt
					    INTO   #tranSUM
					    WHERE  1 = 2");

            }
            this.sQLExpressionExecutor.Execute(@"CREATE UNIQUE INDEX #tranSUM_item ON #tranSUM(item, trans_num)");
        }
         
        public void InsertTranSum1(int? DomCurrencyPlaces)
        {
            var SQL = @"INSERT INTO #tranSUM
                    SELECT mtran.item, mtran.trans_num,
                       SUM( CASE WHEN (mtran.trans_type = 'A' AND mtran.qty = 0 AND ma.acct IS NULL) THEN ISNULL(ma.amt,0)
                                 WHEN include_in_inventory_bal_calc = 1 THEN
                                    CASE WHEN mtran.qty = 0 OR mtran.cost = 0
                                      OR ROUND(mtran.qty * mtran.cost, {0}) != ma.amt
                                      THEN ISNULL(ma.amt, 0)
                                       ELSE ROUND(mtran.qty * mtran.cost, {0})
                                       END
                                 ELSE 0
                            END
                          ) amt
                    FROM #matltran mtran
                    LEFT OUTER JOIN matltran_amt ma ON mtran.trans_num = ma.trans_num
                    GROUP BY mtran.item, mtran.trans_num";
            this.sQLExpressionExecutor.Execute(SQL, DomCurrencyPlaces);
        }


        public void UpdateTransum2(int? DomCurrencyPlaces)
        {
            var updateRequest = this.nonTriggerUpdateRequestFactory.SQLUpdate(
                tableName: "#tranSUM",
                expressionByColumnToAssign: new Dictionary<string, IParameterizedCommand> {
                        {"amt", this.nonTriggerUpdateRequestFactory.Clause("round(mtran.qty * mtran.cost, {0})", DomCurrencyPlaces)},
                },
                fromClause: this.nonTriggerUpdateRequestFactory.Clause("#tranSUM AS tranSUM INNER JOIN #matltran AS mtran ON tranSUM.trans_num = mtran.trans_num"),
                whereClause: this.nonTriggerUpdateRequestFactory.Clause(@"tranSUM.amt = 0 AND CHARINDEX(mtran.trans_type, 'MT') > 0  
                            AND NOT EXISTS (SELECT 1 FROM matltran_amt ma WHERE ma.trans_num = mtran.trans_num)"));
            this.appDB.UpdateWithoutTrigger(updateRequest);
        }

        public void DeleteTv_SUM3()
        {
            var deleteRequest = this.nonTriggerDeleteRequestFactory.SQLDelete(
                  tableName: "#tv_SUM",
                  fromClause: this.nonTriggerDeleteRequestFactory.Clause(""),
                  whereClause: this.nonTriggerDeleteRequestFactory.Clause(""));
            this.appDB.DeleteWithoutTrigger(deleteRequest);
        }

        public void InsertSum4(DateTime? TransDateStarting)
        {
            var SQL = @"INSERT INTO #tv_SUM
                    SELECT mt.item
                    , SUM(mt.qty)
                    , SUM(tranSum.amt)
                    , COUNT(*)
                    , 0
                    FROM #matltran mt
                    INNER JOIN #tranSum tranSum
                    ON tranSum.item = mt.item AND tranSum.trans_num = mt.trans_num
                    WHERE mt.trans_date >= {0}
                    GROUP BY mt.item";
            this.sQLExpressionExecutor.Execute(SQL, TransDateStarting);
        }

        public void UpdateItem1()
        {
            var updateRequest = this.nonTriggerUpdateRequestFactory.SQLUpdate(
                tableName: "#item",
                expressionByColumnToAssign: new Dictionary<string, IParameterizedCommand> {
                        {"StartingBalAmount", this.nonTriggerUpdateRequestFactory.Clause("ItemSum.UnitPrice")},
                        {"StartingBalQty", this.nonTriggerUpdateRequestFactory.Clause("ItemSum.TotQty")},
                        {"matltranRecCount", this.nonTriggerUpdateRequestFactory.Clause("ItemSum.matltranRecCount")},
                },
                fromClause: this.nonTriggerUpdateRequestFactory.Clause("#item AS item INNER JOIN #tv_SUM AS ItemSum ON ItemSum.item = item.item"),
                whereClause: this.nonTriggerUpdateRequestFactory.Clause(""));
            this.appDB.UpdateWithoutTrigger(updateRequest);
        }


        public void UpdateItem2()
        {
            var updateRequest = this.nonTriggerUpdateRequestFactory.SQLUpdate(
                tableName: "#item",
                expressionByColumnToAssign: new Dictionary<string, IParameterizedCommand> {
                        {"TotQty", this.nonTriggerUpdateRequestFactory.Clause("ISNULL(TotQty, 0)")},
                        {"StartingBalQty", this.nonTriggerUpdateRequestFactory.Clause("ISNULL(StartingBalQty, 0)")},
                        {"matltranRecCount", this.nonTriggerUpdateRequestFactory.Clause("ISNULL(matltranRecCount, 0)")},
                        {"TotAmount", this.nonTriggerUpdateRequestFactory.Clause("ISNULL(TotAmount, 0)")},
                },
                fromClause: this.nonTriggerUpdateRequestFactory.Clause(""),
                whereClause: this.nonTriggerUpdateRequestFactory.Clause("TotQty IS NULL OR StartingBalQty IS NULL"));
            this.appDB.UpdateWithoutTrigger(updateRequest);
        }

        public void UpdateItem3()
        {
            var updateRequest = this.nonTriggerUpdateRequestFactory.SQLUpdate(
                tableName: "#item",
                expressionByColumnToAssign: new Dictionary<string, IParameterizedCommand> {
                        {"ItemAmount", this.nonTriggerUpdateRequestFactory.Clause(@"ISNULL(CASE WHEN TotQty = StartingBalQty OR matltranRecCount = 0
                            THEN UnitCost
                            ELSE (((TotQty * UnitCost) - StartingBalAmount) /  (TotQty - StartingBalQty))
                            END, 0)")},
                        {"ItemQty", this.nonTriggerUpdateRequestFactory.Clause("TotQty - StartingBalQty")},
                        {"ItemStartBalCost", this.nonTriggerUpdateRequestFactory.Clause("TotAmount - ISNULL(StartingBalAmount,0)")},
                },
                fromClause: this.nonTriggerUpdateRequestFactory.Clause(""),
                whereClause: this.nonTriggerUpdateRequestFactory.Clause(""));
            this.appDB.UpdateWithoutTrigger(updateRequest);
        }

        public void Tnsert_Invrpt_Summ_Set(DateTime? TransDateStarting, DateTime? TransDateEnding, int? IncludeMoveTrn)
        {
            var SQL = @"INSERT INTO #tv_invrpt_summ_set (
                        Item,
                        ItemDesc,
                        ItemUOM,
                        UnitPrice,
                        Qty,
                        RecvQty,
                        RecvAmount,
                        IssueQty,
                        IssueAmount,
                        ItemStartBalCost
                       )
                       SELECT
                         item.item
                       , item.ItemDesc
                       , item.UM
                       , ItemAmount
                       , ItemQty
                       , ISNULL(SUM(CASE WHEN qty >  0 THEN qty ELSE 0 END), 0)
                       , ISNULL(SUM(CASE WHEN qty >= 0 THEN tranSum.amt ELSE 0 END),0)
                       , ISNULL(SUM(CASE WHEN qty <= 0 THEN qty ELSE 0 END), 0)
                       , ISNULL(SUM(CASE WHEN qty <  0 THEN tranSum.amt ELSE 0 END), 0)
                       , ItemStartBalCost
                       FROM #item AS item
                          INNER JOIN #matltran AS MT ON MT.item = item.item
                          INNER JOIN #tranSum tranSum
                          ON tranSum.item = item.item AND tranSum.trans_num = MT.trans_num
                       WHERE MT.trans_date BETWEEN {0} AND {1}
                       AND NOT (MT.trans_type = 'M' AND {2} = 0)
                       GROUP BY item.item, ItemDesc, UM, item.ItemAmount, item.ItemQty, item.ItemStartBalCost";

            this.sQLExpressionExecutor.Execute(SQL, TransDateStarting, TransDateEnding, IncludeMoveTrn);
        }

        public void Insert_Invrpt_Summ_Set_others()
        {
            var SQL = @"INSERT INTO #tv_invrpt_summ_set (
                        Item,
                        ItemDesc,
                        ItemUOM,
                        UnitPrice,
                        Qty,
                        RecvQty,
                        RecvAmount,
                        IssueQty,
                        IssueAmount,
                        ItemStartBalCost
                       )
                       SELECT item
                       , ItemDesc
                       , UM
                       , ItemAmount
                       , ItemQty
                       , 0
                       , 0
                       , 0
                       , 0
                       , ItemStartBalCost
                       FROM #item AS item
                       WHERE NOT EXISTS(SELECT 1 FROM #tv_invrpt_summ_set AS rpt WHERE rpt.item = item.item)";
            this.sQLExpressionExecutor.Execute(SQL);
        }

        public void DeclareTmpMatltranInfoTable()
        {
            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "tempdb..#MatltranInfo") == null)
            {

                this.sQLExpressionExecutor.Execute(@"Declare
						    @site_ref SiteType
						    ,@trans_num MatlTransNumType
						    ,@trans_type MatlTransTypeType
						    ,@trans_date DateType
						    ,@item ItemType
						    ,@qty QtyPerType
						    ,@whse WhseType
						    ,@loc LocType
						    ,@ref_type RefTypeIJKOPRSTWType
						    ,@ref_num EmpJobCoPoRmaProjPsTrnNumType
						    ,@ref_line_suf CoLineSuffixPoLineProjTaskRmaTrnLineType
						    ,@cost CostPrcType
						    ,@user_code UserCodeType
						    ,@lot LotType
						    ,@ref_release CoReleaseOperNumPoReleaseType
						    ,@reason_code ReasonCodeType
						    ,@wc WcType
						    ,@from_loc NVARCHAR (80)
						    ,@to_loc NVARCHAR (80)
						    ,@TotPost AmtTotType
						    ,@MtCode NVARCHAR (8)
						    ,@DisplayTransType nvarchar (80)
						    ,@DisplayRef NVARCHAR (80)
						    ,@DisplayRefDesc NVARCHAR (80)
						    ,@DisplayLocCode NVARCHAR (80)
						    ,@DisplayReason NVARCHAR (80)
						    ,@DisplayReasonDesc NVARCHAR (80)
						    ,@ItemDesc DescriptionType
						    ,@ItemUOM UMType
						    ,@UnitCost CostPrcType
						    ,@ItemQty DECIMAL (25,10)
						    ,@QtyBalance DECIMAL (25,10)
						    ,@tranCost DECIMAL (25,10)
						    ,@ItemStartBalCost DECIMAL (25,10)
						    ,@TranCostTotal DECIMAL (25,10)
						    ,@document_num DocumentNumType
						    SELECT @site_ref AS site_ref,
						           @trans_num AS trans_num,
						           @trans_type AS trans_type,
						           @trans_date AS trans_date,
						           @item AS Item,
						           @qty AS qty,
						           @whse AS whse,
						           @loc AS loc,
						           @ref_type AS ref_type,
						           @ref_num AS ref_num,
						           @ref_line_suf AS ref_line_suf,
						           @cost AS cost,
						           @user_code AS user_code,
						           @lot AS lot,
						           @ref_release AS ref_release,
						           @reason_code AS reason_code,
						           @wc AS wc,
						           @from_loc AS from_loc,
						           @to_loc AS to_loc,
						           @TotPost AS TotPost,
						           @MtCode AS MtCode,
						           @DisplayTransType AS DisplayTransType,
						           @DisplayRef AS DisplayRef,
						           @DisplayRefDesc AS DisplayRefDesc,
						           @DisplayLocCode AS DisplayLocCode,
						           @DisplayReason AS DisplayReason,
						           @DisplayReasonDesc AS DisplayReasonDesc,
						           @ItemDesc AS ItemDesc,
						           @ItemUOM AS ItemUOM,
						           @UnitCost AS UnitCost,
						           @ItemQty AS ItemQty,
						           @QtyBalance AS QtyBalance,
						           @tranCost AS tranCost,
						           @ItemStartBalCost AS ItemStartBalCost,
						           @TranCostTotal AS TranCostTotal,
						           @document_num AS document_num
						    INTO   #MatltranInfo
						    WHERE  1 = 2");

            }
            this.sQLExpressionExecutor.Execute(@"ALTER TABLE #MatltranInfo ADD sequence INT IDENTITY");
            this.sQLExpressionExecutor.Execute(@"CREATE CLUSTERED INDEX IX_MatltranInfo_MtCode ON #MatltranInfo(MtCode)");
            this.sQLExpressionExecutor.Execute(@"CREATE UNIQUE INDEX IX_MatltranInfo_Item ON #MatltranInfo(item, sequence)");
        }


        public void InsertMatltraninfo1(string Site, DateTime? TransDateStarting, DateTime? TransDateEnding)
        {
            var fromClause = nonTriggerInsertRequestFactory.Clause(@"#matltran AS MT INNER JOIN #tranSum AS tranSum ON tranSum.item = MT.item
					AND tranSum.trans_num = MT.trans_num INNER JOIN #item AS item ON MT.item = item.item");
            var whereClause = nonTriggerInsertRequestFactory.Clause("MT.trans_date BETWEEN {0} AND {1}", TransDateStarting, TransDateEnding);

            var insertRequest = nonTriggerInsertRequestFactory.SQLInsert(
               targetTableName: "#MatltranInfo",
               targetColumns: new List<string> {
                    "site_ref",
                    "Item",
                    "ItemDesc",
                    "ItemUOM",
                    "trans_date",
                    "trans_num",
                    "UnitCost",
                    "ItemQty",
                    "qty",
                    "tranCost",
                    "trans_type",
                    "QtyBalance",
                    "whse",
                    "loc",
                    "ref_type",
                    "ItemStartBalCost",
                    "TranCostTotal",
                    "document_num"},
               valuesByExpressionToAssign: new Dictionary<string, IParameterizedCommand>
               {
                    {"site_ref",nonTriggerInsertRequestFactory.Clause("{0}", Site)},
                    {"Item",nonTriggerInsertRequestFactory.Clause("item.item")},
                    {"ItemDesc",nonTriggerInsertRequestFactory.Clause("item.ItemDesc")},
                    {"ItemUOM",nonTriggerInsertRequestFactory.Clause("item.UM")},
                    {"trans_date",nonTriggerInsertRequestFactory.Clause("MT.trans_date")},
                    {"trans_num",nonTriggerInsertRequestFactory.Clause("MT.trans_num")},
                    {"UnitCost",nonTriggerInsertRequestFactory.Clause("item.ItemAmount")},
                    {"ItemQty",nonTriggerInsertRequestFactory.Clause("item.ItemQty")},
                    {"qty",nonTriggerInsertRequestFactory.Clause("MT.qty")},
                    {"tranCost",nonTriggerInsertRequestFactory.Clause("ISNULL(tranSum.amt, 0) / (CASE WHEN MT.qty = 0 THEN 1 ELSE MT.qty END)")},
                    {"trans_type",nonTriggerInsertRequestFactory.Clause("MT.trans_type")},
                    {"QtyBalance",nonTriggerInsertRequestFactory.Clause("(SELECT SUM(mt2.qty) FROM   #matltran AS mt2 WHERE  mt2.item = MT.item        AND mt2.trans_date < MT.trans_date        AND mt2.trans_num < MT.trans_num)")},
                    {"whse",nonTriggerInsertRequestFactory.Clause("MT.whse")},
                    {"loc",nonTriggerInsertRequestFactory.Clause("MT.loc")},
                    {"ref_type",nonTriggerInsertRequestFactory.Clause("MT.ref_type")},
                    {"ItemStartBalCost",nonTriggerInsertRequestFactory.Clause("item.ItemStartBalCost")},
                    {"TranCostTotal",nonTriggerInsertRequestFactory.Clause("ISNULL(tranSum.amt, 0)")},
                    {"document_num",nonTriggerInsertRequestFactory.Clause("MT.document_num")},
               },
               fromClause: fromClause,
               whereClause: whereClause,
               orderByClause: nonTriggerInsertRequestFactory.Clause("MT.trans_num"));
            this.appDB.InsertWithoutTrigger(insertRequest);    
        }

        public void InsertMatltranInfoTemp()
        {
            this.sQLExpressionExecutor.Execute(@"SELECT item.Item,
					           item.ItemDesc,
					           item.UM,
					           item.ItemAmount,
					           IDENTITY (INT, -1, -1) AS NextTransNum,
					           item.ItemQty,
					           item.ItemStartBalCost
					    INTO   #MatltranInfo_Temp
					    FROM   #item AS item
					    WHERE  NOT EXISTS (SELECT 1
					                       FROM   #MatltranInfo AS mat
					                       WHERE  mat.item = item.item)");
        }


        public void InsertMatltraninfo2(string Site)
        {
            var insertRequest = nonTriggerInsertRequestFactory.SQLInsert(
                targetTableName: "#MatltranInfo",
                targetColumns: new List<string> {
                    "site_ref",
                    "Item",
                    "ItemDesc",
                    "ItemUOM",
                    "trans_date",
                    "DisplayTransType",
                    "UnitCost",
                    "ItemQty",
                    "qty",
                    "tranCost",
                    "trans_num",
                    "trans_type",
                    "QtyBalance",
                    "ItemStartBalCost",
                    "TranCostTotal",
                    "document_num"},
                valuesByExpressionToAssign: new Dictionary<string, IParameterizedCommand>
                {
                    {"site_ref",nonTriggerInsertRequestFactory.Clause("{0}",Site)},
                    {"Item",nonTriggerInsertRequestFactory.Clause("Item")},
                    {"ItemDesc",nonTriggerInsertRequestFactory.Clause("ItemDesc")},
                    {"ItemUOM",nonTriggerInsertRequestFactory.Clause("UM")},
                    {"trans_date",nonTriggerInsertRequestFactory.Clause("NULL")},
                    {"DisplayTransType",nonTriggerInsertRequestFactory.Clause("NULL")},
                    {"UnitCost",nonTriggerInsertRequestFactory.Clause("ItemAmount")},
                    {"ItemQty",nonTriggerInsertRequestFactory.Clause("ItemQty")},
                    {"qty",nonTriggerInsertRequestFactory.Clause("0")},
                    {"tranCost",nonTriggerInsertRequestFactory.Clause("0")},
                    {"trans_num",nonTriggerInsertRequestFactory.Clause("NextTransNum")},
                    {"trans_type",nonTriggerInsertRequestFactory.Clause("NULL")},
                    {"QtyBalance",nonTriggerInsertRequestFactory.Clause("0")},
                    {"ItemStartBalCost",nonTriggerInsertRequestFactory.Clause("ItemStartBalCost")},
                    {"TranCostTotal",nonTriggerInsertRequestFactory.Clause("0")},
                    {"document_num",nonTriggerInsertRequestFactory.Clause("NULL")},
                },
                fromClause: nonTriggerInsertRequestFactory.Clause("#MatltranInfo_Temp"),
                whereClause: nonTriggerInsertRequestFactory.Clause(""));
            this.appDB.InsertWithoutTrigger(insertRequest);
        }


        public void Insert_Invrpt_Det_Summ_Merged(Guid? ProcessId)
        {
            var SQL = @"INSERT INTO tmp_rpt_inventory_balance (
                         process_id
                       , seq
                       , Item
                       , ItemDesc
                       , ItemUOM
                       , UnitPrice
                       , ItemQty
                       , RecQty
                       , RecAmount
                       , IssQty
                       , IssAmount
                       , trans_date
                       , UnitCost
                       , DisplayTransType
                       , tranQty
                       , tranCost
                       , trans_type
                       , ItemStartBalCost
                       , TranCostTotal
                       , document_num
                       )
                       SELECT
                          process_id = {0},
                          row_number() over(order by item),
                          Item = Item,
                          ItemDesc = ItemDesc,
                          ItemUOM = ItemUOM,
                          UnitPrice = ISNULL(SUM(UnitPrice * Qty) / CASE SUM(Qty) WHEN 0 THEN 1 ELSE SUM(Qty) END, 0),
                          ItemQty = ISNULL(SUM(Qty),0),
                          RecQty = ISNULL(SUM(RecvQty),0),
                          RecAmount = ISNULL(SUM(RecvAmount),0),
                          IssQty = ISNULL(SUM(IssueQty),0),
                          IssAmount = ISNULL(SUM(IssueAmount),0),
                          trans_date = NULL,
                          UnitCost = NULL,
                          DisplayTransType = NULL,
                          tranQty = NULL,
                          tranCost = NULL,
                          '',
                          ItemStartBalCost = ISNULL(SUM(ItemStartBalCost),0),
                          0,
                          ''
                       FROM #tv_invrpt_summ_set
                       GROUP by Item, ItemDesc, ItemUOM
                       ORDER by Item";
            this.sQLExpressionExecutor.Execute(SQL, ProcessId);
        }

        public void InsertMatltranInfo3(Guid? ProcessId)
        {
            var insertRequest = nonTriggerInsertRequestFactory.SQLInsert(
                targetTableName: "tmp_rpt_inventory_balance",
                targetColumns: new List<string> {
                    "process_id",
                    "seq",
                    "Item",
                    "ItemDesc",
                    "ItemUOM",
                    "whse",
                    "loc",
                    "UnitPrice",
                    "ItemQty",
                    "RecQty",
                    "RecAmount",
                    "IssQty",
                    "IssAmount",
                    "trans_date",
                    "UnitCost",
                    "DisplayTransType",
                    "tranQty",
                    "tranCost",
                    "trans_type",
                    "QtyBal",
                    "ItemStartBalCost",
                    "TranCostTotal",
                    "document_num" },
                valuesByExpressionToAssign: new Dictionary<string, IParameterizedCommand>
                {
                    {"process_id", nonTriggerInsertRequestFactory.Clause("{0}", ProcessId)},
                    {"seq", nonTriggerInsertRequestFactory.Clause("ROW_NUMBER() OVER (ORDER By Item, whse, loc, trans_date, CAST(trans_num AS nvarchar(10)), CAST(sequence AS nvarchar(10)))")},
                    {"Item",nonTriggerInsertRequestFactory.Clause("#MatltranInfo.Item")},
                    {"ItemDesc",nonTriggerInsertRequestFactory.Clause("#MatltranInfo.ItemDesc")},
                    {"ItemUOM",nonTriggerInsertRequestFactory.Clause("#MatltranInfo.ItemUOM")},
                    {"whse",nonTriggerInsertRequestFactory.Clause("#MatltranInfo.whse")},
                    {"loc",nonTriggerInsertRequestFactory.Clause("#MatltranInfo.loc")},
                    {"UnitPrice",nonTriggerInsertRequestFactory.Clause("CAST (NULL AS DECIMAL)")},
                    {"ItemQty",nonTriggerInsertRequestFactory.Clause("ISNULL(ItemQty,0)")},
                    {"RecQty",nonTriggerInsertRequestFactory.Clause("CAST (NULL AS DECIMAL)")},
                    {"RecAmount",nonTriggerInsertRequestFactory.Clause("CAST (NULL AS DECIMAL)")},
                    {"IssQty",nonTriggerInsertRequestFactory.Clause("CAST (NULL AS DECIMAL)")},
                    {"IssAmount",nonTriggerInsertRequestFactory.Clause("CAST (NULL AS DECIMAL)")},
                    {"trans_date",nonTriggerInsertRequestFactory.Clause("#MatltranInfo.trans_date")},
                    {"UnitCost",nonTriggerInsertRequestFactory.Clause("ISNULL(UnitCost,0)")},
                    {"DisplayTransType",nonTriggerInsertRequestFactory.Clause("#MatltranInfo.DisplayTransType")},
                    {"tranQty",nonTriggerInsertRequestFactory.Clause("ISNULL(qty,0)")},
                    {"tranCost",nonTriggerInsertRequestFactory.Clause("ISNULL(tranCost,0)")},
                    {"trans_type",nonTriggerInsertRequestFactory.Clause("ISNULL(trans_type,'')")},
                    {"QtyBal",nonTriggerInsertRequestFactory.Clause("#MatltranInfo.QtyBalance")},
                    {"ItemStartBalCost",nonTriggerInsertRequestFactory.Clause("#MatltranInfo.ItemStartBalCost")},
                    {"TranCostTotal",nonTriggerInsertRequestFactory.Clause("ISNULL(TranCostTotal,0)")},
                    {"document_num",nonTriggerInsertRequestFactory.Clause("#MatltranInfo.document_num")}
                },
                fromClause: nonTriggerInsertRequestFactory.Clause("#MatltranInfo"),
                whereClause: nonTriggerInsertRequestFactory.Clause(""),
                orderByClause: nonTriggerInsertRequestFactory.Clause(" Item, whse, loc, trans_date, CAST(trans_num AS nvarchar(10)), CAST(sequence AS nvarchar(10))"));
            this.appDB.InsertWithoutTrigger(insertRequest);
        }

        public void DeleteTv_Invrpt_Det_Summ_Merged1(int? IncludeMoveTrn, Guid? ProcessId)
        {
            var deleteRequest = this.nonTriggerDeleteRequestFactory.SQLDelete(
                tableName: "tmp_rpt_inventory_balance",
                fromClause: this.nonTriggerDeleteRequestFactory.Clause(""),
                whereClause: this.nonTriggerDeleteRequestFactory.Clause("trans_type= 'M' AND {0} = 0 AND process_id = {1}", IncludeMoveTrn, ProcessId));
            this.appDB.DeleteWithoutTrigger(deleteRequest);
        }

        public void InsertInvrpt_Det_Summ_Merged(Guid? ProcessId)
        {
            var seqSelectList = new Dictionary<string, string>()
                {
                    {"maxSeq", "Max(Seq)"},
                };
            var SeqLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: seqSelectList,
                    loadForChange: false,
                    lockingType: LockingType.None,
                    tableName: "tmp_rpt_inventory_balance",
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause("process_id={0}", ProcessId));
            var seqLoadResponse = this.appDB.Load(SeqLoadRequest);
            int seq = seqLoadResponse.Items.Count > 0 ? seqLoadResponse.Items[0].GetValue<int>("maxSeq") : 1;

            var whereClause = collectionLoadRequestFactory.Clause("NOT EXISTS (SELECT 1 FROM tmp_rpt_inventory_balance AS rpt WHERE rpt.item = item.item AND rpt.process_id={0})", ProcessId);

            var insertRequest = nonTriggerInsertRequestFactory.SQLInsert(
                targetTableName: "tmp_rpt_inventory_balance",
                targetColumns: new List<string> {
                    "process_id",
                    "seq",
                    "Item",
                    "ItemDesc",
                    "ItemUOM",
                    "UnitPrice",
                    "ItemQty",
                    "RecQty",
                    "RecAmount",
                    "IssQty",
                    "IssAmount",
                    "ItemStartBalCost",
                    "trans_type",
                    "TranCostTotal",
                    "document_num"},
                valuesByExpressionToAssign: new Dictionary<string, IParameterizedCommand>
                {
                    {"process_id", nonTriggerInsertRequestFactory.Clause("{0}", ProcessId)},
                    {"seq",nonTriggerInsertRequestFactory.Clause("(ROW_NUMBER() OVER (ORDER By Item)) + {0}", seq)},
                    {"Item",nonTriggerInsertRequestFactory.Clause("item")},
                    {"ItemDesc",nonTriggerInsertRequestFactory.Clause("ItemDesc")},
                    {"ItemUOM",nonTriggerInsertRequestFactory.Clause("UM")},
                    {"UnitPrice",nonTriggerInsertRequestFactory.Clause("ItemAmount")},
                    {"ItemQty",nonTriggerInsertRequestFactory.Clause("ItemQty")},
                    {"RecQty",nonTriggerInsertRequestFactory.Clause("0")},
                    {"RecAmount",nonTriggerInsertRequestFactory.Clause("0")},
                    {"IssQty",nonTriggerInsertRequestFactory.Clause("0")},
                    {"IssAmount",nonTriggerInsertRequestFactory.Clause("0")},
                    {"ItemStartBalCost",nonTriggerInsertRequestFactory.Clause("ItemStartBalCost")},
                    {"trans_type",nonTriggerInsertRequestFactory.Clause("''")},
                    {"TranCostTotal",nonTriggerInsertRequestFactory.Clause("0")},
                    {"document_num",nonTriggerInsertRequestFactory.Clause("''")},
                },
                fromClause: nonTriggerInsertRequestFactory.Clause("#item AS item"),
                whereClause: whereClause,
                orderByClause: nonTriggerInsertRequestFactory.Clause(" Item"));
            this.appDB.InsertWithoutTrigger(insertRequest);
        }

        public void UpdateTv_Invrpt_Det_Summ_Merged2(Guid? ProcessId)
        {
            var updateRequest = this.nonTriggerUpdateRequestFactory.SQLUpdate(
                tableName: "tmp_rpt_inventory_balance",
                expressionByColumnToAssign: new Dictionary<string, IParameterizedCommand> {
                {"ItemStartBalCost", this.nonTriggerUpdateRequestFactory.Clause("0")},
                {"ItemQty", this.nonTriggerUpdateRequestFactory.Clause("0")},
                },
                fromClause: this.nonTriggerUpdateRequestFactory.Clause(""),
                whereClause: this.nonTriggerUpdateRequestFactory.Clause("process_id = {0} AND Seq NOT IN (SELECT MIN(Seq) FROM tmp_rpt_inventory_balance where process_id = {0} GROUP By Item)",ProcessId));
            this.appDB.UpdateWithoutTrigger(updateRequest);
        }

        public ICollectionLoadResponse SelectTv_Invrpt_Det_Summ_Merged3(DateTime? TransDateStarting, 
            DateTime? TransDateEndingOutput, 
            string DomCurrencyFormat,
            int? DomCurrencyPlaces,
            string DomTotCurrencyFormat,
            int? DomTotCurrencyPlaces,
            string CostPriceFormat,
            int? CostPricePlaces,
            string UnitQtyFormat,
            int? UnitQtyPlaces,
            int? FeatureRS8938Active,
            Guid? ProcessId,
            LoadType loadType,
            int recordCap)
        {
            IBookmark resultBookmark = (loadType == LoadType.Next) ? mgSessionVariableBasedCache.Get<Bookmark>("Bookmark") : null;
            Dictionary<string, SortOrderDirection> resultDicSortOrder = new Dictionary<string, SortOrderDirection>();
            resultDicSortOrder.Add("seq", SortOrderDirection.Ascending);
            ISortOrder resultSortOrder = sortOrderFactory.Create(resultDicSortOrder);
            var whereClause = collectionLoadRequestFactory.Clause(" process_id={0}", ProcessId);
            var selectList = new Dictionary<string, string>()
                {
                    {"DateStarting","CAST (NULL AS DATETIME)"},
                    {"DateEnding","CAST (NULL AS DATETIME)"},
                    {"Item","tmp_rpt_inventory_balance.Item"},
                    {"ItemDesc","tmp_rpt_inventory_balance.ItemDesc"},
                    {"ItemUOM","tmp_rpt_inventory_balance.ItemUOM"},
                    {"UnitPrice","tmp_rpt_inventory_balance.UnitPrice"},
                    {"ItemQty","tmp_rpt_inventory_balance.ItemQty"},
                    {"RecQty","tmp_rpt_inventory_balance.RecQty"},
                    {"RecAmount","tmp_rpt_inventory_balance.RecAmount"},
                    {"IssQty","tmp_rpt_inventory_balance.IssQty"},
                    {"IssAmount","tmp_rpt_inventory_balance.IssAmount"},
                    {"trans_date","tmp_rpt_inventory_balance.trans_date"},
                    {"UnitCost","tmp_rpt_inventory_balance.UnitCost"},
                    {"DisplayTransType","tmp_rpt_inventory_balance.DisplayTransType"},
                    {"tranQty","tmp_rpt_inventory_balance.tranQty"},
                    {"tranCost","tmp_rpt_inventory_balance.tranCost"},
                    {"DomCurrencyFormat","CAST (NULL AS NVARCHAR)"},
                    {"DomCurrencyPlaces","CAST (NULL AS INT)"},
                    {"DomTotCurrencyFormat","CAST (NULL AS NVARCHAR)"},
                    {"DomTotCurrencyPlaces","CAST (NULL AS INT)"},
                    {"CostPriceFormat","CAST (NULL AS NVARCHAR)"},
                    {"CostPricePlaces","CAST (NULL AS INT)"},
                    {"UnitQtyFormat","CAST (NULL AS NVARCHAR)"},
                    {"UnitQtyPlaces","CAST (NULL AS INT)"},
                    {"trans_type","tmp_rpt_inventory_balance.trans_type"},
                    {"QtyBal","tmp_rpt_inventory_balance.QtyBal"},
                    {"ItemStartBalCost","CASE WHEN (ItemQty=0 AND ISNULL(UnitPrice,0)=0) THEN 0 ELSE ItemStartBalCost END"},
                    {"TranCostTotal","tmp_rpt_inventory_balance.TranCostTotal"},
                    {"document_num","tmp_rpt_inventory_balance.document_num"},
                    {"UnboundQtyPlus","ItemQty+RecQty+IssQty"},
                    {"UnboundAmtPlus","ItemStartBalCost+RecAmount+IssAmount"},
                    {"UnboundRecResult","ISNULL(RecAmount,0)/IIF(RecQty IS NULL OR RecQty=0, 1, RecQty)"},
                    {"UnboundIssResult","ISNULL(IssAmount,0)/IIF(IssQty IS NULL OR IssQty=0, 1, IssQty)"},
                    {"UnboundPlusResult","IIF(ItemQty+RecQty+IssQty=0, 0, (ItemStartBalCost+RecAmount+IssAmount)/(ItemQty+RecQty+IssQty))"},
                    {"Whse","tmp_rpt_inventory_balance.whse"},
                    {"Loc","tmp_rpt_inventory_balance.loc"},
                    {"Group1",$"CASE WHEN {FeatureRS8938Active} = 1 THEN whse ELSE Item END"},
                    {"Group2",$"CASE WHEN {FeatureRS8938Active} = 1 THEN loc ELSE Item END"},
                    {"seq","seq"},
                };
            var tv_invrpt_det_summ_merged3LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName:selectList,
                    loadForChange: false,
                    lockingType: LockingType.None,
                    maximumRows: recordCap == 0 ? recordCap : recordCap + 1,
                    tableName: "tmp_rpt_inventory_balance",
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: resultBookmark == null ? whereClause : queryLanguage.AppendBookmark(whereClause, resultBookmark),
                    orderByClause: collectionLoadRequestFactory.Clause(" seq"));

            var tv_invrpt_det_summ_merged3LoadResponse = this.appDB.Load(tv_invrpt_det_summ_merged3LoadRequest);
            foreach (var tv_invrpt_det_summ_merged3Item in tv_invrpt_det_summ_merged3LoadResponse.Items)
            {
                tv_invrpt_det_summ_merged3Item.SetValue<DateTime?>("DateStarting", TransDateStarting);
                tv_invrpt_det_summ_merged3Item.SetValue<DateTime?>("DateEnding", TransDateEndingOutput);
                tv_invrpt_det_summ_merged3Item.SetValue<string>("DomCurrencyFormat", DomCurrencyFormat);
                tv_invrpt_det_summ_merged3Item.SetValue<int?>("DomCurrencyPlaces", DomCurrencyPlaces);
                tv_invrpt_det_summ_merged3Item.SetValue<string>("DomTotCurrencyFormat", DomTotCurrencyFormat);
                tv_invrpt_det_summ_merged3Item.SetValue<int?>("DomTotCurrencyPlaces", DomTotCurrencyPlaces);
                tv_invrpt_det_summ_merged3Item.SetValue<string>("CostPriceFormat", CostPriceFormat);
                tv_invrpt_det_summ_merged3Item.SetValue<int?>("CostPricePlaces", CostPricePlaces);
                tv_invrpt_det_summ_merged3Item.SetValue<string>("UnitQtyFormat", UnitQtyFormat);
                tv_invrpt_det_summ_merged3Item.SetValue<int?>("UnitQtyPlaces", UnitQtyPlaces);
            };
            if (tv_invrpt_det_summ_merged3LoadResponse.Items.Count > 1)
            {
                mgSessionVariableBasedCache.Insert("Bookmark", (ICachable)bookmarkFactory.Create(tv_invrpt_det_summ_merged3LoadResponse.Items[tv_invrpt_det_summ_merged3LoadResponse.Items.Count - 2], resultSortOrder));
            }
            (int? returnCode, string variableValue, string infobar) = getVariable.GetVariableSp("Bookmark", "", 0, "", "");
            if (!string.IsNullOrEmpty(variableValue))
            {
                defineProcessVariable.DefineProcessVariableSp("Bookmark", variableValue, infobar);
            }

            return tv_invrpt_det_summ_merged3LoadResponse;
        }

        public void CleanupInventoryBalanceResult(Guid? ProcessId)
        {
            var deleteRequest = this.nonTriggerDeleteRequestFactory.SQLDelete(
                tableName: "tmp_rpt_inventory_balance",
                fromClause: this.nonTriggerDeleteRequestFactory.Clause(""),
                whereClause: this.nonTriggerDeleteRequestFactory.Clause("process_id = {0}", ProcessId));
            this.appDB.DeleteWithoutTrigger(deleteRequest);
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        AltExtGen_Rpt_InventoryBalanceSp(
            string AltExtGenSp,
            string ProductCodeStarting = null,
            string ProductCodeEnding = null,
            string ItemStarting = null,
            string ItemEnding = null,
            string WhseStarting = null,
            string WhseEnding = null,
            string LocStarting = null,
            string LocEnding = null,
            DateTime? TransDateStarting = null,
            DateTime? TransDateEnding = null,
            string ReasonCodeStarting = null,
            string ReasonCodeEnding = null,
            int? SummaryDtl = 0,
            int? OneItmPerPg = null,
            int? IncludeMoveTrn = null,
            int? IncludeNonNetStk = null,
            int? DisplayHeader = null,
            int? TransDateStartingOffset = null,
            int? TransDateEndingOffset = null,
            string pSite = null,
            string MessageLanguage = null,
            string DocumentNumStarting = null,
            string DocumentNumEnding = null)
        {
            ProductCodeType _ProductCodeStarting = ProductCodeStarting;
            ProductCodeType _ProductCodeEnding = ProductCodeEnding;
            ItemType _ItemStarting = ItemStarting;
            ItemType _ItemEnding = ItemEnding;
            WhseType _WhseStarting = WhseStarting;
            WhseType _WhseEnding = WhseEnding;
            LocType _LocStarting = LocStarting;
            LocType _LocEnding = LocEnding;
            DateTimeType _TransDateStarting = TransDateStarting;
            DateTimeType _TransDateEnding = TransDateEnding;
            ReasonCodeType _ReasonCodeStarting = ReasonCodeStarting;
            ReasonCodeType _ReasonCodeEnding = ReasonCodeEnding;
            ListYesNoType _SummaryDtl = SummaryDtl;
            ListYesNoType _OneItmPerPg = OneItmPerPg;
            ListYesNoType _IncludeMoveTrn = IncludeMoveTrn;
            ListYesNoType _IncludeNonNetStk = IncludeNonNetStk;
            ListYesNoType _DisplayHeader = DisplayHeader;
            DateOffsetType _TransDateStartingOffset = TransDateStartingOffset;
            DateOffsetType _TransDateEndingOffset = TransDateEndingOffset;
            SiteType _pSite = pSite;
            MessageLanguageType _MessageLanguage = MessageLanguage;
            DocumentNumType _DocumentNumStarting = DocumentNumStarting;
            DocumentNumType _DocumentNumEnding = DocumentNumEnding;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();
                IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "ProductCodeStarting", _ProductCodeStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ProductCodeEnding", _ProductCodeEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "WhseStarting", _WhseStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "WhseEnding", _WhseEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "LocStarting", _LocStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "LocEnding", _LocEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TransDateStarting", _TransDateStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TransDateEnding", _TransDateEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ReasonCodeStarting", _ReasonCodeStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ReasonCodeEnding", _ReasonCodeEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SummaryDtl", _SummaryDtl, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OneItmPerPg", _OneItmPerPg, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "IncludeMoveTrn", _IncludeMoveTrn, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "IncludeNonNetStk", _IncludeNonNetStk, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TransDateStartingOffset", _TransDateStartingOffset, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TransDateEndingOffset", _TransDateEndingOffset, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "MessageLanguage", _MessageLanguage, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DocumentNumStarting", _DocumentNumStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DocumentNumEnding", _DocumentNumEnding, ParameterDirection.Input);

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
