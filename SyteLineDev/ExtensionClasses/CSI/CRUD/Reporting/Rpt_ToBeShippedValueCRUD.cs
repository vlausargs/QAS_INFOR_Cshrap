//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ToBeShippedValueCRUD.cs

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
    public class Rpt_ToBeShippedValueCRUD : IRpt_ToBeShippedValueCRUD
    {
        readonly IApplicationDB appDB;
        readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionNonTriggerInsertRequestFactory collectionNonTriggerInsertRequestFactory;
        readonly ICollectionNonTriggerDeleteRequestFactory collectionNonTriggerDeleteRequestFactory;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly ITransactionFactory transactionFactory;
        readonly IGetIsolationLevel iGetIsolationLevel;
        readonly IExistsChecker existsChecker;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly IQueryLanguage queryLanguage;
        readonly ICache mgSessionVariableBasedCache;
        readonly IRecordStreamFactory recordStreamFactory;
        readonly ISortOrderFactory sortOrderFactory;
        readonly IBookmarkFactory bookmarkFactory;
        ISortOrder coSortOrder;

        public Rpt_ToBeShippedValueCRUD(IApplicationDB appDB,
            ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionNonTriggerInsertRequestFactory collectionNonTriggerInsertRequestFactory,
            ICollectionNonTriggerDeleteRequestFactory collectionNonTriggerDeleteRequestFactory,
            ISQLExpressionExecutor sQLExpressionExecutor,
            ITransactionFactory transactionFactory,
            IGetIsolationLevel iGetIsolationLevel,
            IExistsChecker existsChecker,
            ISQLValueComparerUtil sQLUtil,
            IRecordStreamFactory recordStreamFactory,
            ISortOrderFactory sortOrderFactory,
            IBookmarkFactory bookmarkFactory,
            IQueryLanguage queryLanguage,
            ICache mgSessionVariableBasedCache)
        {
            this.appDB = appDB;
            this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.collectionNonTriggerInsertRequestFactory = collectionNonTriggerInsertRequestFactory;
            this.collectionNonTriggerDeleteRequestFactory = collectionNonTriggerDeleteRequestFactory;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.transactionFactory = transactionFactory;
            this.iGetIsolationLevel = iGetIsolationLevel;
            this.existsChecker = existsChecker;
            this.sQLUtil = sQLUtil;
            this.queryLanguage = queryLanguage;
            this.mgSessionVariableBasedCache = mgSessionVariableBasedCache;
            this.recordStreamFactory = recordStreamFactory;
            this.sortOrderFactory = sortOrderFactory;
            this.bookmarkFactory = bookmarkFactory;
        }

        public bool Optional_ModuleForExists()
        {
            return existsChecker.Exists(tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_ToBeShippedValueSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"));
        }

        public void DeclareALTGEN()
        {
            this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					        [SpName] SYSNAME);
					    SELECT * into #tv_ALTGEN from @ALTGEN");
        }
        public void InsertOptional_Module()
        {
            var optional_module1NonTriggerInsertRequest = collectionNonTriggerInsertRequestFactory.SQLInsert(
                targetTableName: "#tv_ALTGEN",
                targetColumns: new List<string>()
                {
                    { "SpName" },
                },
                valuesByExpressionToAssign: new Dictionary<string, IParameterizedCommand>()
                {
                    { "SpName" , collectionNonTriggerInsertRequestFactory.Clause("QUOTENAME(OBJECT_NAME(@@PROCID) + CHAR(95) + om.ModuleName)")},
                },
                fromClause: collectionNonTriggerInsertRequestFactory.Clause("optional_module om"),
                whereClause: collectionNonTriggerInsertRequestFactory.Clause("ISNULL(om.is_enabled, 0) = 1 AND OBJECT_ID(QUOTENAME(OBJECT_NAME(@@PROCID) + CHAR(95) + om.ModuleName)) IS NOT NULL"),
                orderByClause: collectionNonTriggerInsertRequestFactory.Clause("")
                );

            this.appDB.InsertWithoutTrigger(optional_module1NonTriggerInsertRequest);
        }

        public bool Tv_ALTGENForExists()
        {
            return existsChecker.Exists(tableName: "#tv_ALTGEN",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""));
        }

        public (string ALTGEN_SpName, int? rowCount) LoadTv_ALTGEN(string ALTGEN_SpName)
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


        public void DeleteTv_ALTGEN(string ALTGEN_SpName)
        {
            var tv_ALTGEN2NonTriggerDeleteRequest = collectionNonTriggerDeleteRequestFactory.SQLDelete(
                tableName: "#tv_ALTGEN",
                fromClause: collectionNonTriggerDeleteRequestFactory.Clause(""),
                whereClause: collectionNonTriggerDeleteRequestFactory.Clause("SpName = {0}", ALTGEN_SpName)
            );

            this.appDB.DeleteWithoutTrigger(tv_ALTGEN2NonTriggerDeleteRequest);
        }

        public void SetIsolationLevel()
        {
            this.sQLExpressionExecutor.Execute("SET XACT_ABORT ON");
            if (sQLUtil.SQLEqual(this.iGetIsolationLevel.GetIsolationLevelFn("ToBeShippedValueReport"), "COMMITTED") == true)
            {
                this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ COMMITTED");

            }
            else
            {
                this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");

            }
        }

        public (int? UnitQtyPlaces, string UnitQtyFormat, int? rowCount) LoadUnitQtyFromInvparms(int? UnitQtyPlaces, string UnitQtyFormat)
        {
            DecimalPlacesType _UnitQtyPlaces = DBNull.Value;
            InputMaskType _UnitQtyFormat = DBNull.Value;

            var invparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_UnitQtyPlaces,"places_qty_unit"},
                    {_UnitQtyFormat,"qty_unit_format"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "invparms",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var invparmsLoadResponse = this.appDB.Load(invparmsLoadRequest);
            if (invparmsLoadResponse.Items.Count > 0)
            {
                UnitQtyPlaces = _UnitQtyPlaces;
                UnitQtyFormat = _UnitQtyFormat;
            }

            int rowCount = invparmsLoadResponse.Items.Count;
            return (UnitQtyPlaces, UnitQtyFormat, rowCount);
        }

        public (int? CostItemAtWhse, string DefaultWhse, int? rowCount) LoadWhseFromInvparms(int? CostItemAtWhse, string DefaultWhse)
        {
            ListYesNoType _CostItemAtWhse = DBNull.Value;
            WhseType _DefaultWhse = DBNull.Value;

            var dbo_invparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_CostItemAtWhse,"isnull(invparms.cost_item_at_whse, 0)"},
                    {_DefaultWhse,"def_whse"},
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
                DefaultWhse = _DefaultWhse;
            }

            int rowCount = dbo_invparmsLoadResponse.Items.Count;
            return (CostItemAtWhse, DefaultWhse, rowCount);
        }

        public (string ParmsSite, int? rowCount) LoadParms(string ParmsSite)
        {
            SiteType _ParmsSite = DBNull.Value;

            var parmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_ParmsSite,"parms.site"},
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
                ParmsSite = _ParmsSite;
            }

            int rowCount = parmsLoadResponse.Items.Count;
            return (ParmsSite, rowCount);
        }

        public (string CurrparmsCurrCode, string CurrparmsCurrDescription, int? rowCount) LoadCurrparms(string CurrparmsCurrCode, string CurrparmsCurrDescription)
        {
            CurrCodeType _CurrparmsCurrCode = DBNull.Value;
            DescriptionType _CurrparmsCurrDescription = DBNull.Value;

            var currparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_CurrparmsCurrCode,"currparms.curr_code"},
                    {_CurrparmsCurrDescription,"currency.description"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "currparms",
                fromClause: collectionLoadRequestFactory.Clause(" INNER JOIN currency ON currparms.curr_code = currency.curr_code"),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var currparmsLoadResponse = this.appDB.Load(currparmsLoadRequest);
            if (currparmsLoadResponse.Items.Count > 0)
            {
                CurrparmsCurrCode = _CurrparmsCurrCode;
                CurrparmsCurrDescription = _CurrparmsCurrDescription;
            }

            int rowCount = currparmsLoadResponse.Items.Count;
            return (CurrparmsCurrCode, CurrparmsCurrDescription, rowCount);
        }

        public (int? CoParmsUseAltPriceCalc, int? rowCount) LoadCoparms(int? CoParmsUseAltPriceCalc)
        {
            ListYesNoType _CoParmsUseAltPriceCalc = DBNull.Value;

            var coparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_CoParmsUseAltPriceCalc,"coparms.use_alt_price_calc"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "coparms",
                fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var coparmsLoadResponse = this.appDB.Load(coparmsLoadRequest);
            if (coparmsLoadResponse.Items.Count > 0)
            {
                CoParmsUseAltPriceCalc = _CoParmsUseAltPriceCalc;
            }

            int rowCount = coparmsLoadResponse.Items.Count;
            return (CoParmsUseAltPriceCalc, rowCount);
        }

        public IRecordStream SelectCo(int pageSize, LoadType loadType, int? pSortByCurrency, int? pTransDomCurr, string pCoType, string pCoStat, string pCoitemStat, string pStartCoNum, string pEndCoNum, string pStartCustNum, string pEndCustNum, DateTime? pStartOrderDate, DateTime? pEndOrderDate, string pStartCustPo, string pEndCustPo, string pStartItem, string pEndItem, string pStartCustItem, string pEndCustItem, DateTime? pStartDueDate, DateTime? pEndDueDate, DateTime? pStartShipDate, DateTime? pEndShipDate, string pStartCurrCode, string pEndCurrCode, string ParmsSite, int? IncludeNull, int? CostItemAtWhse)
        {
            if (coSortOrder == null)
            {
                Dictionary<string, SortOrderDirection> dicSortOrder = new Dictionary<string, SortOrderDirection>();
                if (pSortByCurrency == 1)
                {
                    if (pTransDomCurr != 1)
                    {
                        dicSortOrder.Add("co.curr_code", SortOrderDirection.Ascending);
                    }
                    dicSortOrder.Add("coitem.co_num", SortOrderDirection.Ascending);
                    dicSortOrder.Add("coitem.co_line", SortOrderDirection.Ascending);
                    dicSortOrder.Add("coitem.co_release", SortOrderDirection.Ascending);
                }
                else
                {
                    dicSortOrder.Add("coitem.co_num", SortOrderDirection.Ascending);
                    dicSortOrder.Add("coitem.co_line", SortOrderDirection.Ascending);
                    dicSortOrder.Add("coitem.co_release", SortOrderDirection.Ascending);
                    if (pTransDomCurr != 1)
                    {
                        dicSortOrder.Add("co.curr_code", SortOrderDirection.Ascending);
                    }
                }
                dicSortOrder.Add("co.cust_num", SortOrderDirection.Ascending);
                dicSortOrder.Add("co.cust_seq", SortOrderDirection.Ascending);
                dicSortOrder.Add("co.lcr_num", SortOrderDirection.Ascending);
                dicSortOrder.Add("coitem.item", SortOrderDirection.Ascending);
                dicSortOrder.Add("coitem.whse", SortOrderDirection.Ascending);
                coSortOrder = sortOrderFactory.Create(dicSortOrder);
            }

            var selectList = new Dictionary<string, string>()
                {
                    {"currency.RowPointer","currency.RowPointer"},
                    {"currency.curr_code","currency.curr_code"},
                    {"currency.description","currency.description"},
                    {"currency.places","currency.places"},
                    {"custaddr.RowPointer","custaddr.RowPointer"},
                    {"co.curr_code","co.curr_code"},
                    {"custaddr.cust_num","custaddr.cust_num"},
                    {"custaddr.cust_seq","custaddr.cust_seq"},
                    {"co.co_num","co.co_num"},
                    {"co.cust_num","co.cust_num"},
                    {"co.cust_seq","co.cust_seq"},
                    {"co.exch_rate","co.exch_rate"},
                    {"co.disc","co.disc"},
                    {"co.lcr_num","co.lcr_num"},
                    {"co.order_date","co.order_date"},
                    {"co.RowPointer","co.RowPointer"},
                    {"co.credit_hold","co.credit_hold"},
                    {"coitem.u_m","coitem.u_m"},
                    {"coitem.item","coitem.item"},
                    {"coitem.whse","coitem.whse"},
                    {"coitem.price_conv","coitem.price_conv"},
                    {"coitem.cost","coitem.cost"},
                    {"coitem.qty_ordered","coitem.qty_ordered"},
                    {"coitem.qty_shipped","coitem.qty_shipped"},
                    {"coitem.disc","coitem.disc"},
                    {"coitem.qty_invoiced","coitem.qty_invoiced"},
                    {"coitem.co_num","coitem.co_num"},
                    {"coitem.co_line","coitem.co_line"},
                    {"coitem.co_release","coitem.co_release"},
                    {"coitem.qty_ordered_conv","coitem.qty_ordered_conv"},
                    {"coitem.due_date","coitem.due_date"},
                    {"coitem.stat","coitem.stat"},
                    {"coitem.RowPointer","coitem.RowPointer"},
                    {"coitem.description","coitem.description"},
                    {"coitem.qty_rsvd","coitem.qty_rsvd"},
                    {"coitem.ref_type","coitem.ref_type"},
                    {"coitem.ref_num","coitem.ref_num"},
                    {"cust_lcr.RowPointer","cust_lcr.RowPointer"},
                    {"cust_lcr.exp_date","cust_lcr.exp_date"},
                    {"cust_lcr.stat","cust_lcr.stat"},
                    {"cust_lcr.curr_code","cust_lcr.curr_code"},
                    {"cust_lcr.revolv","cust_lcr.revolv"},
                    {"cust_lcr.ship_value","cust_lcr.ship_value"},
                    {"cust_lcr.lcr_amt","cust_lcr.lcr_amt"},
                    {"cust_lcr.cust_num","cust_lcr.cust_num"},
                    {"cust_lcr.lcr_num","cust_lcr.lcr_num"},
                    {"customer.RowPointer","customer.RowPointer"},
                    {"customer.cust_num","customer.cust_num"},
                    {"customer.lcr_reqd","customer.lcr_reqd"},
                    {"coitem.qty_ready","coitem.qty_ready"},
                    {"item.RowPointer","item.RowPointer"},
                    {"ItemMatlCost",$"case when {CostItemAtWhse} = 1 then itemwhse.matl_cost else item.matl_cost end"},
                    {"ItemLbrCost",$"case when {CostItemAtWhse} = 1 then itemwhse.lbr_cost else item.lbr_cost end"},
                    {"ItemFovhdCost",$"case when {CostItemAtWhse} = 1 then itemwhse.fovhd_cost else item.fovhd_cost end"},
                    {"ItemVovhdCost",$"case when {CostItemAtWhse} = 1 then itemwhse.vovhd_cost else item.vovhd_cost end"},
                    {"ItemOutCost",$"case when {CostItemAtWhse} = 1 then itemwhse.out_cost else item.out_cost end"},
                    {"b_currency.RowPointer","b_currency.RowPointer"},
                };
            var coFromClause = collectionLoadRequestFactory.Clause(@" INNER JOIN coitem ON coitem.co_num = co.co_num INNER JOIN custaddr ON custaddr.cust_num = co.cust_num
					AND custaddr.cust_seq = co.cust_seq LEFT OUTER JOIN currency ON custaddr.curr_code = currency.curr_code LEFT OUTER JOIN customer ON customer.cust_num = custaddr.cust_num
					AND customer.cust_seq = 0 LEFT OUTER JOIN cust_lcr ON cust_lcr.cust_num = co.cust_num
					AND cust_lcr.lcr_num = co.lcr_num LEFT OUTER JOIN item ON item.item = coitem.item LEFT OUTER JOIN itemwhse ON item.item = itemwhse.item
					AND itemwhse.whse = coitem.whse LEFT OUTER JOIN currency AS b_currency ON b_currency.curr_code = co.curr_code");
            var coWhereClause = collectionLoadRequestFactory.Clause("CHARINDEX(co.type, {21}) > 0 AND CHARINDEX(co.stat, {22}) > 0 AND co.co_num BETWEEN {11} AND {18} AND co.cust_num BETWEEN {4} AND {12} AND co.order_date BETWEEN {0} AND {5} AND ISNULL(co.cust_po, '') BETWEEN {7} AND {16} AND CHARINDEX(coitem.stat, {13}) <> 0 AND coitem.qty_ordered > coitem.qty_shipped AND coitem.item BETWEEN {17} AND {20} AND ISNULL(coitem.cust_item, '') BETWEEN {1} AND {8} AND coitem.due_date BETWEEN {6} AND {14} AND ((coitem.ship_date BETWEEN {2} AND {9}) OR ({15} = 1 AND coitem.ship_date IS NULL)) AND coitem.qty_ordered > coitem.qty_shipped AND coitem.ship_site = {19} AND co.curr_code BETWEEN {3} AND {10}", pStartOrderDate, pStartCustItem, pStartShipDate, pStartCurrCode, pStartCustNum, pEndOrderDate, pStartDueDate, pStartCustPo, pEndCustItem, pEndShipDate, pEndCurrCode, pStartCoNum, pEndCustNum, pCoitemStat, pEndDueDate, IncludeNull, pEndCustPo, pStartItem, pEndCoNum, ParmsSite, pEndItem, pCoType, pCoStat);
            var coOrderByClause = collectionLoadRequestFactory.Clause(" coitem.co_num, coitem.co_line, coitem.co_release, " + (pTransDomCurr == 1 ? "" : " co.curr_code, ") + " co.cust_num, co.cust_seq, co.lcr_num, coitem.item, coitem.whse");

            var currencyFromClause = collectionLoadRequestFactory.Clause(@" INNER JOIN custaddr ON custaddr.curr_code = currency.curr_code INNER JOIN co ON co.cust_num = custaddr.cust_num
					AND co.cust_seq = custaddr.cust_seq INNER JOIN customer ON customer.cust_num = custaddr.cust_num
					AND customer.cust_seq = 0 LEFT OUTER JOIN shipco ON shipco.co_num = co.co_num INNER JOIN coitem ON coitem.co_num = co.co_num LEFT OUTER JOIN cust_lcr ON cust_lcr.cust_num = co.cust_num
					AND cust_lcr.lcr_num = co.lcr_num LEFT OUTER JOIN item ON item.item = coitem.item LEFT OUTER JOIN itemwhse ON item.item = itemwhse.item
					AND itemwhse.whse = coitem.whse LEFT OUTER JOIN currency AS b_currency ON b_currency.curr_code = co.curr_code");
            var currencyWhereClause = collectionLoadRequestFactory.Clause("currency.curr_code BETWEEN {1} AND {7} AND CHARINDEX(co.type, {21}) > 0 AND CHARINDEX(co.stat, {22}) > 0 AND co.co_num BETWEEN {11} AND {18} AND co.cust_num BETWEEN {4} AND {12} AND co.order_date BETWEEN {0} AND {5} AND ISNULL(co.cust_po, '') BETWEEN {8} AND {16} AND CHARINDEX(coitem.stat, {13}) <> 0 AND coitem.qty_ordered > coitem.qty_shipped AND coitem.item BETWEEN {17} AND {20} AND ISNULL(coitem.cust_item, '') BETWEEN {2} AND {9} AND coitem.due_date BETWEEN {6} AND {14} AND ((coitem.ship_date BETWEEN {3} AND {10}) OR ({15} = 1 AND coitem.ship_date IS NULL)) AND coitem.ship_site = {19}", pStartOrderDate, pStartCurrCode, pStartCustItem, pStartShipDate, pStartCustNum, pEndOrderDate, pStartDueDate, pEndCurrCode, pStartCustPo, pEndCustItem, pEndShipDate, pStartCoNum, pEndCustNum, pCoitemStat, pEndDueDate, IncludeNull, pEndCustPo, pStartItem, pEndCoNum, ParmsSite, pEndItem, pCoType, pCoStat);
            var currencyOrderByClause = collectionLoadRequestFactory.Clause((pTransDomCurr == 1 ? "" : " co.curr_code, ") + " coitem.co_num, coitem.co_line, coitem.co_release, co.cust_num, co.cust_seq, co.lcr_num, coitem.item, coitem.whse");

            var ToBeShipped_crsLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(
                columnExpressionByColumnName: selectList,
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: pSortByCurrency == 0 ? "co" : "currency",
                fromClause: pSortByCurrency == 0 ? coFromClause : currencyFromClause,
                whereClause: pSortByCurrency == 0 ? coWhereClause : currencyWhereClause,
                orderByClause: pSortByCurrency == 0 ? coOrderByClause : currencyOrderByClause);

            return recordStreamFactory.Create(appDB, queryLanguage, mgSessionVariableBasedCache, collectionLoadRequestFactory, ToBeShipped_crsLoadRequestForCursor, coSortOrder, SQLPagedRecordStreamBookmarkID.MyReport_Rpt, pageSize, loadType);
        }

        public bool ItemForExists(int? Severity, decimal? CoitemCost, decimal? ConvFactor, decimal? TcCprItemCost, string Infobar, string CoitemItem)
        {
            return existsChecker.Exists(tableName: "item",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("item.item = {0}", CoitemItem));
        }

        public (Guid? TemplcrRowPointer, decimal? TemplcrShipValue, int? rowCount) LoadTv_Templcr(string CoCustNum, string CoLcrNum, Guid? TemplcrRowPointer, decimal? TemplcrShipValue)
        {
            RowPointerType _TemplcrRowPointer = DBNull.Value;
            AmountType _TemplcrShipValue = DBNull.Value;

            var tv_TempLcrLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_TemplcrRowPointer,"templcr.RowPointer"},
                    {_TemplcrShipValue,"templcr.ship_value"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "#tv_TempLcr",
                fromClause: collectionLoadRequestFactory.Clause(" AS TempLcr"),
                whereClause: collectionLoadRequestFactory.Clause("TempLcr.cust_num = {0} AND TempLcr.lcr_num = {1}", CoCustNum, CoLcrNum),
                orderByClause: collectionLoadRequestFactory.Clause(" TempLcr.cust_num, TempLcr.lcr_num"));

            var tv_TempLcrLoadResponse = this.appDB.Load(tv_TempLcrLoadRequest);
            if (tv_TempLcrLoadResponse.Items.Count > 0)
            {
                TemplcrRowPointer = _TemplcrRowPointer;
                TemplcrShipValue = _TemplcrShipValue;
            }

            int rowCount = tv_TempLcrLoadResponse.Items.Count;
            return (TemplcrRowPointer, TemplcrShipValue, rowCount);
        }

        public void InsertLcrNontable(string CustLcrCustNum, string CustLcrLcrNum, decimal? TToBeShipped)
        {
            var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
            {
                    { "cust_num", CustLcrCustNum},
                    { "lcr_num", CustLcrLcrNum},
                    { "ship_value", TToBeShipped},
            });

            var nonTableLoadResponse = this.appDB.Load(nonTableLoadRequest);
            var nonTableInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_TempLcr",
                items: nonTableLoadResponse.Items);

            this.appDB.Insert(nonTableInsertRequest);
        }

        public ICollectionLoadResponse SelectReportSetNontable(int? pSortByCurrency, int? seq, int level, int? rptSeq, string CoitemCoNum, DateTime? CoOrderDate, int? CoitemCoLine, int? CoitemCoRelease, string CoitemItem, decimal? CoDisc, decimal? CoitemQtyOrderedConv, decimal? TcQtuQtyInv, decimal? TcCprItemPrice, decimal? CoitemDisc, decimal? TcAmtNetPrice, DateTime? CoitemDueDate, string CoitemStat, string TDesc, decimal? TcQtuQtyShp, decimal? TcQtuQtyRmn, decimal? TcCprItemCost, string CoitemUM, decimal? TcAmtNetCost, string CurrencyCurrCode, string CurrencyDescription, string TErrMsg, int? UnitQtyPlaces, string UnitQtyFormat, string GroupBy)
        {
            var nonTable1LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
            {
                    { "seq", seq},
                    { "Level", level},
                    { "rpt_seq", rptSeq},
                    { "co_num", CoitemCoNum},
                    { "order_date", CoOrderDate},
                    { "co_line", CoitemCoLine},
                    { "co_release", CoitemCoRelease},
                    { "item", CoitemItem},
                    { "disc", CoDisc},
                    { "qty_ordered_conv", CoitemQtyOrderedConv},
                    { "qty_invoiced", TcQtuQtyInv},
                    { "price_conv", TcCprItemPrice},
                    { "coitem_disc", CoitemDisc},
                    { "Amt_Net_Price", TcAmtNetPrice},
                    { "due_date", CoitemDueDate},
                    { "item_stat", CoitemStat},
                    { "item_Desc", TDesc},
                    { "qty_shipped", TcQtuQtyShp},
                    { "qty_remaining", TcQtuQtyRmn},
                    { "item_cost", TcCprItemCost},
                    { "item_u_m", CoitemUM},
                    { "net_item_cost", TcAmtNetCost},
                    { "curr_code", CurrencyCurrCode},
                    { "curr_desc", CurrencyDescription},
                    { "err_msg", TErrMsg},
                    { "UnitQtyPlaces", UnitQtyPlaces},
                    { "UnitQtyFormat", UnitQtyFormat},
                    { "GroupBy", GroupBy},
                    {"OrderTotalToBeShippedPrice", 0.0M},
                    {"OrderTotalCost", 0.0M},
                    {"TotalToBeShippedPriceByCurrency", 0.0M},
                    {"TotalOrderCostByCurrency", 0.0M},
                    {"TotalToBeShippedPrice", 0.0M},
                    {"TotalCost", 0.0M},
            });

            return this.appDB.Load(nonTable1LoadRequest);
        }

        public void DeclareTempLcr()
        {
            this.sQLExpressionExecutor.Execute(@"DECLARE @templcr TABLE (
				        RowPointer RowPointerType,
				        cust_num   CustNumType   ,
				        lcr_num    LcrNumType    ,
				        ship_value AmountType    );
				    SELECT * into #tv_templcr from @templcr");
        }

        public void InsertBookmark(IRecordReadOnly coItem)
        {
            if (coItem != null)
                mgSessionVariableBasedCache.Insert(Enum.GetName(typeof(SQLPagedRecordStreamBookmarkID), SQLPagedRecordStreamBookmarkID.MyReport_Rpt), (ICachable)bookmarkFactory.Create(coItem, coSortOrder));
        }


        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        AltExtGen_Rpt_ToBeShippedValueSp(
            string AltExtGenSp,
            string pCoType = null,
            string pCoStat = null,
            string pCoitemStat = null,
            int? pTransDomCurr = null,
            int? pSortByCurrency = null,
            string pCreditHold = null,
            int? pDispSubTots = null,
            string pStartCoNum = null,
            string pEndCoNum = null,
            string pStartCustNum = null,
            string pEndCustNum = null,
            DateTime? pStartOrderDate = null,
            DateTime? pEndOrderDate = null,
            string pStartCustPo = null,
            string pEndCustPo = null,
            string pStartItem = null,
            string pEndItem = null,
            string pStartCustItem = null,
            string pEndCustItem = null,
            DateTime? pStartDueDate = null,
            DateTime? pEndDueDate = null,
            DateTime? pStartShipDate = null,
            DateTime? pEndShipDate = null,
            string pStartCurrCode = null,
            string pEndCurrCode = null,
            int? PrintCost = 0,
            int? PrintPrice = 0,
            int? DisplayHeader = null,
            string BGSessionId = null,
            int? TaskId = null,
            string pSite = null,
            string BGUser = null)
        {
            InfobarType _pCoType = pCoType;
            InfobarType _pCoStat = pCoStat;
            InfobarType _pCoitemStat = pCoitemStat;
            ListYesNoType _pTransDomCurr = pTransDomCurr;
            ListYesNoType _pSortByCurrency = pSortByCurrency;
            StringType _pCreditHold = pCreditHold;
            ListYesNoType _pDispSubTots = pDispSubTots;
            CoNumType _pStartCoNum = pStartCoNum;
            CoNumType _pEndCoNum = pEndCoNum;
            CustNumType _pStartCustNum = pStartCustNum;
            CustNumType _pEndCustNum = pEndCustNum;
            DateType _pStartOrderDate = pStartOrderDate;
            DateType _pEndOrderDate = pEndOrderDate;
            CustPoType _pStartCustPo = pStartCustPo;
            CustPoType _pEndCustPo = pEndCustPo;
            ItemType _pStartItem = pStartItem;
            ItemType _pEndItem = pEndItem;
            CustItemType _pStartCustItem = pStartCustItem;
            CustItemType _pEndCustItem = pEndCustItem;
            DateType _pStartDueDate = pStartDueDate;
            DateType _pEndDueDate = pEndDueDate;
            DateType _pStartShipDate = pStartShipDate;
            DateType _pEndShipDate = pEndShipDate;
            CustItemType _pStartCurrCode = pStartCurrCode;
            CustItemType _pEndCurrCode = pEndCurrCode;
            ListYesNoType _PrintCost = PrintCost;
            ListYesNoType _PrintPrice = PrintPrice;
            ListYesNoType _DisplayHeader = DisplayHeader;
            StringType _BGSessionId = BGSessionId;
            TaskNumType _TaskId = TaskId;
            SiteType _pSite = pSite;
            UsernameType _BGUser = BGUser;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();
                IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "pCoType", _pCoType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pCoStat", _pCoStat, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pCoitemStat", _pCoitemStat, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pTransDomCurr", _pTransDomCurr, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pSortByCurrency", _pSortByCurrency, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pCreditHold", _pCreditHold, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pDispSubTots", _pDispSubTots, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pStartCoNum", _pStartCoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pEndCoNum", _pEndCoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pStartCustNum", _pStartCustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pEndCustNum", _pEndCustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pStartOrderDate", _pStartOrderDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pEndOrderDate", _pEndOrderDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pStartCustPo", _pStartCustPo, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pEndCustPo", _pEndCustPo, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pStartItem", _pStartItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pEndItem", _pEndItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pStartCustItem", _pStartCustItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pEndCustItem", _pEndCustItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pStartDueDate", _pStartDueDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pEndDueDate", _pEndDueDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pStartShipDate", _pStartShipDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pEndShipDate", _pEndShipDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pStartCurrCode", _pStartCurrCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pEndCurrCode", _pEndCurrCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PrintCost", _PrintCost, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PrintPrice", _PrintPrice, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TaskId", _TaskId, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BGUser", _BGUser, ParameterDirection.Input);

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
