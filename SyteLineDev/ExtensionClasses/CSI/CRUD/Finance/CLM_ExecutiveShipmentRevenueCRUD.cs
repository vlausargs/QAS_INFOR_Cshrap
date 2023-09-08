//PROJECT NAME: Finance
//CLASS NAME: CLM_ExecutiveShipmentRevenueCRUD.cs

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
using CSI.Logistics.Customer;
using System.Linq;
using CSI.Data.Cache;

namespace CSI.Finance
{
	public class CLM_ExecutiveShipmentRevenueCRUD : ICLM_ExecutiveShipmentRevenueCRUD
	{
		readonly IApplicationDB appDB;
		readonly ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionUpdateRequestFactory collectionUpdateRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly ICollectionNonTriggerInsertRequestFactory collectionNonTriggerInsertRequestFactory;
		readonly ICollectionNonTriggerDeleteRequestFactory collectionNonTriggerDeleteRequestFactory;
		readonly ICollectionNonTriggerUpdateRequestFactory collectionNonTriggerUpdateRequestFactory;
		readonly ITransactionFactory transactionFactory;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IExistsChecker existsChecker;
		readonly IUomConvQty iUomConvQty;
		readonly IUomConvAmt iUomConvAmt;
		readonly IMathUtil mathUtil;
		readonly IRecordStreamFactory recordStreamFactory;
		readonly ISessionBasedCache mgSessionVariableBasedCache;
		readonly IQueryLanguage queryLanguage;
		readonly ISortOrderFactory sortOrderFactory;
		readonly IBookmarkFactory bookmarkFactory;
		readonly IDefineProcessVariable defineProcessVariable;
		readonly IGetVariable getVariable;
		readonly IRecordBunchFactory recordBunchFactory;

		public CLM_ExecutiveShipmentRevenueCRUD(IApplicationDB appDB,
			ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			ICollectionNonTriggerInsertRequestFactory collectionNonTriggerInsertRequestFactory,
			ICollectionNonTriggerDeleteRequestFactory collectionNonTriggerDeleteRequestFactory,
			ICollectionNonTriggerUpdateRequestFactory collectionNonTriggerUpdateRequestFactory,
			ITransactionFactory transactionFactory,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IExistsChecker existsChecker,
			IUomConvQty iUomConvQty,
			IUomConvAmt iUomConvAmt,
			IMathUtil mathUtil,
			IRecordStreamFactory recordStreamFactory,
			ISortOrderFactory sortOrderFactory,
			IBookmarkFactory bookmarkFactory,
			IQueryLanguage queryLanguage,
			ISessionBasedCache mgSessionVariableBasedCache,
			IDefineProcessVariable defineProcessVariable,
			IGetVariable getVariable,
			IRecordBunchFactory recordBunchFactory)
		{
			this.appDB = appDB;
			this.collectionLoadStatementRequestFactory = collectionLoadStatementRequestFactory;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionUpdateRequestFactory = collectionUpdateRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.collectionNonTriggerInsertRequestFactory = collectionNonTriggerInsertRequestFactory;
			this.collectionNonTriggerDeleteRequestFactory = collectionNonTriggerDeleteRequestFactory;
			this.collectionNonTriggerUpdateRequestFactory = collectionNonTriggerUpdateRequestFactory;
			this.transactionFactory = transactionFactory;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.existsChecker = existsChecker;
			this.iUomConvQty = iUomConvQty;
			this.iUomConvAmt = iUomConvAmt;
			this.mathUtil = mathUtil;
			this.recordStreamFactory = recordStreamFactory;
			this.mgSessionVariableBasedCache = mgSessionVariableBasedCache;
			this.queryLanguage = queryLanguage;
			this.sortOrderFactory = sortOrderFactory;
			this.bookmarkFactory = bookmarkFactory;
			this.defineProcessVariable = defineProcessVariable;
			this.getVariable = getVariable;
			this.recordBunchFactory = recordBunchFactory;
		}

		public void DeclareAltgenTable()
		{
			this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
						    [SpName] SYSNAME);
						SELECT * into #tv_ALTGEN from @ALTGEN");
		}

		public bool Optional_ModuleForExists()
		{
			return existsChecker.Exists(tableName: "optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_ExecutiveShipmentRevenueSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"));
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
			this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
		}

		public ICollectionLoadResponse SelectSite_Group(string SiteGroup)
		{
			var site_group_crsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"site_group.site","site_group.site"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName: "site_group",
				fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
				whereClause: collectionLoadRequestFactory.Clause("site_group.site_group = {0}", SiteGroup),
				orderByClause: collectionLoadRequestFactory.Clause(""));

			var site_group_crsLoadResponse = this.appDB.Load(site_group_crsLoadRequest);
			return site_group_crsLoadResponse;
		}

		public IList<string> InsertSite_Group(ICollectionLoadResponse loadResponse)
		{
			IList<string> siteList = new List<string>();
			foreach (var item in loadResponse.Items)
			{
				siteList.Add(item.GetValue<string>("site_group.site"));
			}
			return siteList;
		}

		public (string DomCurrCode, int? rowCount) LoadCurrparms_All(string Site, string DomCurrCode)
		{
			CurrCodeType _DomCurrCode = DBNull.Value;

			var currparms_allLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_DomCurrCode,"currparms_all.curr_code"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName: "currparms_all",
				fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
				whereClause: collectionLoadRequestFactory.Clause("currparms_all.site_ref = {0}", Site),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var currparms_allLoadResponse = this.appDB.Load(currparms_allLoadRequest);
			if (currparms_allLoadResponse.Items.Count > 0)
			{
				DomCurrCode = _DomCurrCode;
			}

			int rowCount = currparms_allLoadResponse.Items.Count;
			return (DomCurrCode, rowCount);
		}

		public (int? DomCurrencyPlaces, int? DomCurrencyPlacesCp, int? rowCount) LoadCurrency(string DomCurrCode, int? DomCurrencyPlaces, int? DomCurrencyPlacesCp)
		{
			DecimalPlacesType _DomCurrencyPlaces = DBNull.Value;
			DecimalPlacesType _DomCurrencyPlacesCp = DBNull.Value;

			var currencyLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_DomCurrencyPlaces,"places"},
					{_DomCurrencyPlacesCp,"places_cp"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName: "currency",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("curr_code = {0}", DomCurrCode),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var currencyLoadResponse = this.appDB.Load(currencyLoadRequest);
			if (currencyLoadResponse.Items.Count > 0)
			{
				DomCurrencyPlaces = _DomCurrencyPlaces;
				DomCurrencyPlacesCp = _DomCurrencyPlacesCp;
			}

			int rowCount = currencyLoadResponse.Items.Count;
			return (DomCurrencyPlaces, DomCurrencyPlacesCp, rowCount);
		}

		public (int? InvparmsPlacesQtyUnit, int? rowCount) LoadInvparms(int? InvparmsPlacesQtyUnit)
		{
			DecimalPlacesType _InvparmsPlacesQtyUnit = DBNull.Value;

			var invparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_InvparmsPlacesQtyUnit,"places_qty_unit"},
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
				InvparmsPlacesQtyUnit = _InvparmsPlacesQtyUnit;
			}

			int rowCount = invparmsLoadResponse.Items.Count;
			return (InvparmsPlacesQtyUnit, rowCount);
		}

		public void CreateTempCoitem()
		{
			this.sQLExpressionExecutor.Execute(@"CREATE TABLE #Coitem (
					    CoOrigSite     NVARCHAR (8)     COLLATE DATABASE_DEFAULT,
					    CoNum          NVARCHAR (20)    COLLATE DATABASE_DEFAULT,
					    CoLine         INT             ,
					    CoRelease      INT             ,
					    Item           NVARCHAR (40)    COLLATE DATABASE_DEFAULT,
					    ItDescription  NVARCHAR (40)    COLLATE DATABASE_DEFAULT,
					    DerProductCode NVARCHAR (10)    COLLATE DATABASE_DEFAULT,
					    CoCustNum      NVARCHAR (20)    COLLATE DATABASE_DEFAULT,
					    Adr0Name       NVARCHAR (60)    COLLATE DATABASE_DEFAULT,
					    CoCurrCode     NVARCHAR (3)     COLLATE DATABASE_DEFAULT,
					    ShipDate       DATETIME        ,
					    UM             NVARCHAR (10)    COLLATE DATABASE_DEFAULT,
					    QtyOrderedConv DECIMAL (25, 10),
					    PriceConv      DECIMAL (25, 10),
					    DiscountPrice  DECIMAL (25, 10),
					    Disc           DECIMAL (25, 10),
					    CoDisc         DECIMAL (25, 10),
					    QtyShippedConv DECIMAL (25, 10),
					    CostConv       DECIMAL (25, 10),
					    ShipSite       NVARCHAR (8)     COLLATE DATABASE_DEFAULT,
					    DerTotCost     DECIMAL (25, 10),
					    DerNetPrice    DECIMAL (25, 10),
					    DerMargin      DECIMAL (25, 10),
					    DomCurrCode    NVARCHAR (3)     COLLATE DATABASE_DEFAULT,
					    seq            INT              IDENTITY PRIMARY KEY
					)");
		}

		public void CreateTempCoitemSum()
		{
			this.sQLExpressionExecutor.Execute(@"CREATE TABLE #CoitemSum (
					    Item           NVARCHAR (40)    COLLATE DATABASE_DEFAULT,
					    ItDescription  NVARCHAR (40)    COLLATE DATABASE_DEFAULT,
					    DerProductCode NVARCHAR (10)    COLLATE DATABASE_DEFAULT,
					    DerTotCost     DECIMAL (25, 10),
					    DerNetPrice    DECIMAL (25, 10),
					    DerMargin      DECIMAL (25, 10),
					    ShipSite       NVARCHAR (8)     COLLATE DATABASE_DEFAULT,
					    DomCurrCode    NVARCHAR (3)     COLLATE DATABASE_DEFAULT
					)");
			this.sQLExpressionExecutor.Execute(@"CREATE INDEX #CoitemSum_ShipSite
					    ON #CoitemSum(ShipSite)");
			this.sQLExpressionExecutor.Execute(@"CREATE INDEX #CoitemSum_DerProductCode
					    ON #CoitemSum(DerProductCode)");
			this.sQLExpressionExecutor.Execute(@"CREATE INDEX #CoitemSum_Item
					    ON #CoitemSum(Item)");
		}

		public void CreateTempTableTv_um()
		{
			this.sQLExpressionExecutor.Execute(@"DECLARE @um TABLE (
					    coitem_u_m  UMType          ,
					    item        ItemType        ,
					    cust_num    CustNumType     ,
					    conv_factor UMConvFactorType DEFAULT 1,
					    ship_site   SiteType         PRIMARY KEY (coitem_u_m, item, cust_num, ship_site)) 
                        SELECT * into #tv_um from @um");
			this.sQLExpressionExecutor.Execute($"ALTER TABLE #tv_um ADD CONSTRAINT df_conv_factor_{Guid.NewGuid().ToString().Substring(0, 8)} DEFAULT 1 FOR conv_factor");
			this.sQLExpressionExecutor.Execute(@"ALTER TABLE #tv_um ADD PRIMARY KEY (coitem_u_m, item, cust_num, ship_site)");
		}

		public void InsertTempCoitem(IList<string> SiteList, DateTime? DateStarting, DateTime? DateEnding, string DomCurrCode)
		{
			string whereInCondition = SiteList?.Count > 0 ? $"coitem.site_ref in ({ String.Join(",", SiteList.Select(s => "'" + s + "'"))})" : "1=2";
			var tempCoitemNonTriggerInsertRequest = collectionNonTriggerInsertRequestFactory.SQLInsert(
					targetTableName: "#Coitem",
					targetColumns: new List<string>()
					{
						{"CoOrigSite"},
						{"CoNum"},
						{"CoLine"},
						{"CoRelease"},
						{"Item"},
						{"ItDescription"},
						{"DerProductCode"},
						{"CoCustNum"},
						{"Adr0Name"},
						{"CoCurrCode"},
						{"ShipDate"},
						{"UM"},
						{"QtyOrderedConv"},
						{"PriceConv"},
						{"DiscountPrice"},
						{"Disc"},
						{"CoDisc"},
						{"QtyShippedConv"},
						{"CostConv"},
						{"ShipSite"},
						{"DerTotCost"},
						{"DerNetPrice"},
						{"DerMargin"},
						{"DomCurrCode"}
					},
					valuesByExpressionToAssign: new Dictionary<string, IParameterizedCommand>()
					{
						{"CoOrigSite", collectionNonTriggerInsertRequestFactory.Clause("co.orig_site")},
						{"CoNum", collectionNonTriggerInsertRequestFactory.Clause("co.co_num")},
						{"CoLine", collectionNonTriggerInsertRequestFactory.Clause("coitem.co_line")},
						{"CoRelease", collectionNonTriggerInsertRequestFactory.Clause("coitem.co_release")},
						{"Item", collectionNonTriggerInsertRequestFactory.Clause("coitem.item")},
						{"ItDescription", collectionNonTriggerInsertRequestFactory.Clause("coitem.description")},
						{"DerProductCode", collectionNonTriggerInsertRequestFactory.Clause("isnull(item.product_code, non_inventory_item.product_code)")},
						{"CoCustNum", collectionNonTriggerInsertRequestFactory.Clause("co.cust_num")},
						{"Adr0Name", collectionNonTriggerInsertRequestFactory.Clause("custaddr.name")},
						{"CoCurrCode", collectionNonTriggerInsertRequestFactory.Clause("co.curr_code")},
						{"ShipDate", collectionNonTriggerInsertRequestFactory.Clause("co_ship_all.ship_date")},
						{"UM", collectionNonTriggerInsertRequestFactory.Clause("coitem.u_m")},
						{"QtyOrderedConv", collectionNonTriggerInsertRequestFactory.Clause("coitem.qty_ordered_conv")},
						{"PriceConv", collectionNonTriggerInsertRequestFactory.Clause("coitem.price_conv")},
						{"DiscountPrice", collectionNonTriggerInsertRequestFactory.Clause("coitem.price_conv")},
						{"Disc", collectionNonTriggerInsertRequestFactory.Clause("coitem.disc")},
						{"CoDisc", collectionNonTriggerInsertRequestFactory.Clause(@"CASE WHEN co.discount_type = 'P' THEN co.disc 
                            ELSE (co.disc_amount * 100.0) / (CASE WHEN (co.price + co.disc_amount 
                            - co.sales_tax - co.sales_tax_2 - co.misc_charges - co.freight
                            - co.sales_tax_t - co.sales_tax_t2 - co.m_charges_t - co.freight_t) = 0 THEN 1
                            ELSE (co.price + co.disc_amount
                            - co.sales_tax - co.sales_tax_2 - co.misc_charges - co.freight
                            - co.sales_tax_t - co.sales_tax_t2 - co.m_charges_t - co.freight_t)
                           END)
                        END")},
						{"QtyShippedConv", collectionNonTriggerInsertRequestFactory.Clause("co_ship_all.qty_shipped")},
						{"CostConv", collectionNonTriggerInsertRequestFactory.Clause("case when item.RowPointer is not null then (coitem.cgs_total / coitem.qty_shipped) else coitem.cost_conv end")},
						{"ShipSite", collectionNonTriggerInsertRequestFactory.Clause("coitem.ship_site")},
						{"DerTotCost", collectionNonTriggerInsertRequestFactory.Clause("0")},
						{"DerNetPrice", collectionNonTriggerInsertRequestFactory.Clause("0")},
						{"DerMargin", collectionNonTriggerInsertRequestFactory.Clause("0")},
						{"DomCurrCode", collectionNonTriggerInsertRequestFactory.Clause("{0}", DomCurrCode)}
					},
					fromClause: collectionNonTriggerInsertRequestFactory.Clause(@"coitem_all as coitem with (readuncommitted) inner join co_all as co with (readuncommitted) on co.co_num = coitem.co_num
						and co.site_ref = coitem.site_ref
						and charindex(co.type, 'rb') > 0 inner join custaddr with (readuncommitted) on co.cust_num = custaddr.cust_num
						and co.cust_seq = custaddr.cust_seq left outer join item_all as item with (readuncommitted) on item.item = coitem.item
						and item.site_ref = coitem.site_ref inner join co_ship_all on co_ship_all.site_ref = coitem.site_ref
						and co_ship_all.co_num = coitem.co_num
						and co_ship_all.co_line = coitem.co_line
						and co_ship_all.co_release = coitem.co_release
						and co_ship_all.ship_date between {0} and {1} left outer join non_inventory_item on non_inventory_item.item = coitem.item", DateStarting, DateEnding),
					whereClause: collectionNonTriggerInsertRequestFactory.Clause($"coitem.ship_site = coitem.site_ref AND {whereInCondition} AND coitem.qty_shipped <> 0"),
					orderByClause: collectionNonTriggerInsertRequestFactory.Clause(" co.orig_site, coitem.co_num, coitem.co_line, coitem.co_release")
				);

			this.appDB.InsertWithoutTrigger(tempCoitemNonTriggerInsertRequest);
		}

		public IRecordStream SelectTempCoitem(string DomCurrCode, LoadType loadType = LoadType.First, CachePageSize pageSize = CachePageSize.XLarge)
		{
			// Build the sort order columns first. Then build the default values.
			Dictionary<string, SortOrderDirection> dicSortOrder = new Dictionary<string, SortOrderDirection>();
			dicSortOrder.Add("CoCurrCode", SortOrderDirection.Ascending);
			dicSortOrder.Add("ShipDate", SortOrderDirection.Ascending);
			dicSortOrder.Add("seq", SortOrderDirection.Ascending);

			// The following code is building default values for RowPointer (guid type) and price (decimal type) columns.
			Dictionary<string, object> dicDefaultValue = new Dictionary<string, object>();
			dicDefaultValue.Add("CoCurrCode", "");
			dicDefaultValue.Add("ShipDate", "1900-01-01 00:00:00.000");

			// Invoke create method provide both sort columns and their defalut values.
			var sortOrder = sortOrderFactory.Create(dicSortOrder, dicDefaultValue);

			var currCrsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"CoCurrCode","CoCurrCode"},
					{"PriceConv","PriceConv"},
					{"seq","seq"},
					{"ShipSite","ShipSite"},
					{"ShipDate","ShipDate"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName: "#Coitem",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("CoCurrCode != {0}", DomCurrCode),
				orderByClause: collectionLoadRequestFactory.Clause(" CoCurrCode, ShipDate, seq"));

			IRecordStream recordStream = recordStreamFactory.Create(appDB, queryLanguage, mgSessionVariableBasedCache, collectionLoadRequestFactory,
				currCrsLoadRequest, sortOrder, SQLPagedRecordStreamBookmarkID.CLM_ExecutiveShipmentRevenue_Coitem, Convert.ToInt32(pageSize), loadType, false);
			return recordStream;
		}

		public void UpdateTempCoitemByCoitemPriceConv(int? seq, decimal? coitem_price_conv)
		{
			var tempCoitemUpdateRequest = collectionNonTriggerUpdateRequestFactory.SQLUpdate(
				tableName: "#Coitem",
				expressionByColumnToAssign: new Dictionary<string, IParameterizedCommand>()
				{
					{"PriceConv",collectionNonTriggerUpdateRequestFactory.Clause("{0}", coitem_price_conv)},
					{"DiscountPrice",collectionNonTriggerUpdateRequestFactory.Clause("{0}", coitem_price_conv)}
				},
				fromClause: collectionNonTriggerUpdateRequestFactory.Clause(""),
				whereClause: collectionNonTriggerUpdateRequestFactory.Clause("seq = {0}", seq));

			this.appDB.UpdateWithoutTrigger(tempCoitemUpdateRequest);
		}

		public void UpdateDiscountPriceForTempCoitem(int? DomCurrencyPlacesCp)
		{
			if (DomCurrencyPlacesCp == null) return;
			var tempCoitemUpdateRequest = collectionNonTriggerUpdateRequestFactory.SQLUpdate(
				tableName: "#Coitem",
				expressionByColumnToAssign: new Dictionary<string, IParameterizedCommand>()
				{
					{"DiscountPrice",collectionNonTriggerUpdateRequestFactory.Clause("round(PriceConv * (1.0 - (Disc / 100.0)) * (1.0 - (CoDisc / 100.0)), {0})", DomCurrencyPlacesCp)}
				},
				fromClause: collectionNonTriggerUpdateRequestFactory.Clause(""),
				whereClause: collectionNonTriggerUpdateRequestFactory.Clause("Disc != 0 OR CoDisc != 0"));

			this.appDB.UpdateWithoutTrigger(tempCoitemUpdateRequest);
		}

		public void InsertTempTvUm()
		{
			var tempTvUmNonTriggerInsertRequest = collectionNonTriggerInsertRequestFactory.SQLInsert(
					targetTableName: "#tv_um",
					targetColumns: new List<string>()
					{
						{"coitem_u_m"},
						{"item"},
						{"cust_num"},
						{"ship_site"},
					},
					valuesByExpressionToAssign: new Dictionary<string, IParameterizedCommand>()
					{
						{"coitem_u_m", collectionNonTriggerInsertRequestFactory.Clause("coitem.UM")},
						{"item", collectionNonTriggerInsertRequestFactory.Clause("coitem.Item")},
						{"cust_num", collectionNonTriggerInsertRequestFactory.Clause("coitem.CoCustNum")},
						{"ship_site", collectionNonTriggerInsertRequestFactory.Clause("coitem.ShipSite")},

					},
					fromClause: collectionNonTriggerInsertRequestFactory.Clause(" #Coitem AS coitem"),
					whereClause: collectionNonTriggerInsertRequestFactory.Clause(""),
					orderByClause: collectionNonTriggerInsertRequestFactory.Clause(""),
					distinct: true
				);

			this.appDB.InsertWithoutTrigger(tempTvUmNonTriggerInsertRequest);
		}

		public IRecordStream SelectTempTvUm(LoadType loadType = LoadType.First, CachePageSize pageSize = CachePageSize.XLarge)
		{
			// Build the sort order columns first. Then build the default values.
			Dictionary<string, SortOrderDirection> dicSortOrder = new Dictionary<string, SortOrderDirection>();
			dicSortOrder.Add("um.item", SortOrderDirection.Ascending);
			dicSortOrder.Add("um.coitem_u_m", SortOrderDirection.Ascending);
			dicSortOrder.Add("um.cust_num", SortOrderDirection.Ascending);
			dicSortOrder.Add("um.ship_site", SortOrderDirection.Ascending);

			// The following code is building default values for RowPointer (guid type) and price (decimal type) columns.
			Dictionary<string, object> dicDefaultValue = new Dictionary<string, object>();
			dicDefaultValue.Add("um.item", "");
			dicDefaultValue.Add("um.coitem_u_m", "");
			dicDefaultValue.Add("um.cust_num", "");
			dicDefaultValue.Add("um.ship_site", "");

			// Invoke create method provide both sort columns and their defalut values.
			var sortOrder = sortOrderFactory.Create(dicSortOrder, dicDefaultValue);

			var umCrsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"um.coitem_u_m","um.coitem_u_m"},
					{"um.item","um.item"},
					{"um.cust_num","um.cust_num"},
					{"um.ship_site","um.ship_site"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName: "#tv_um",
				fromClause: collectionLoadRequestFactory.Clause(@" AS um INNER JOIN item_all WITH (READUNCOMMITTED) ON item_all.item = um.item
					AND item_all.site_ref = um.ship_site"),
				whereClause: collectionLoadRequestFactory.Clause(" coitem_u_m != item_all.u_m"),
				orderByClause: collectionLoadRequestFactory.Clause(" um.item, um.coitem_u_m, um.cust_num, um.ship_site"));

			IRecordStream recordStream = recordStreamFactory.Create(appDB, queryLanguage, mgSessionVariableBasedCache, collectionLoadRequestFactory,
				umCrsLoadRequest, sortOrder, SQLPagedRecordStreamBookmarkID.CLM_ExecutiveShipmentRevenue_Um, Convert.ToInt32(pageSize), loadType, false);
			return recordStream;
		}
		public void UpdateTempTvUm(decimal? UomConvFactor, string coitem_ship_site, string coitem_item, string coitem_u_m, string co_cust_num)
		{
			var tempTvUmUpdateRequest = collectionNonTriggerUpdateRequestFactory.SQLUpdate(
				tableName: "#tv_um",
				expressionByColumnToAssign: new Dictionary<string, IParameterizedCommand>()
				{
					{"conv_factor",collectionNonTriggerUpdateRequestFactory.Clause("{0}", UomConvFactor)}
				},
				fromClause: collectionNonTriggerUpdateRequestFactory.Clause(""),
				whereClause: collectionNonTriggerUpdateRequestFactory.Clause("coitem_u_m = {3} AND item = {1} AND cust_num = {2} AND ship_site = {0}", coitem_ship_site, coitem_item, co_cust_num, coitem_u_m));

			this.appDB.UpdateWithoutTrigger(tempTvUmUpdateRequest);
		}

		public ICollectionLoadResponse SelectTempCoitemForUpdate()
		{
			var Coitem3LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"QtyShippedConv","coitem.QtyShippedConv"},
					{"CostConv","coitem.CostConv"},
					{"u0","um.conv_factor"},
				},
				loadForChange: true,
				lockingType: LockingType.UPDLock,
				tableName: "#Coitem",
				fromClause: collectionLoadRequestFactory.Clause(@" AS coitem INNER JOIN #tv_um AS um ON um.coitem_u_m = coitem.UM
					AND um.item = coitem.Item
					AND um.cust_num = coitem.CoCustNum
					AND um.ship_site = coitem.ShipSite
					AND um.conv_factor != 1"),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(Coitem3LoadRequest);
		}

		public void UpdateTempCoitem(int? DomCurrencyPlacesCp, int? InvparmsPlacesQtyUnit, ICollectionLoadResponse Coitem3LoadResponse)
		{
			if (DomCurrencyPlacesCp == null || InvparmsPlacesQtyUnit == null) return;
			foreach (var Coitem3Item in Coitem3LoadResponse.Items)
			{
				Coitem3Item.SetValue<decimal?>("QtyShippedConv", mathUtil.Round<decimal?>(this.iUomConvQty.UomConvQtyFn(
						Coitem3Item.GetDeletedValue<decimal?>("QtyShippedConv"),
						Coitem3Item.GetDeletedValue<decimal?>("u0"),
						"FROM Base"), InvparmsPlacesQtyUnit));
				Coitem3Item.SetValue<decimal?>("CostConv", mathUtil.Round<decimal?>(this.iUomConvAmt.UomConvAmtFn(
						Coitem3Item.GetDeletedValue<decimal?>("CostConv"),
						Coitem3Item.GetDeletedValue<decimal?>("u0"),
						"FROM Base"), DomCurrencyPlacesCp));
			};

			var Coitem3RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#Coitem",
				items: Coitem3LoadResponse.Items);

			this.appDB.Update(Coitem3RequestUpdate);
		}

		public void UpdateTempCoitemByDomCurrencyPlaces(int? DomCurrencyPlaces)
		{
			if (DomCurrencyPlaces == null) return;
			var tempCoitemUpdateRequest = collectionNonTriggerUpdateRequestFactory.SQLUpdate(
				tableName: "#Coitem",
				expressionByColumnToAssign: new Dictionary<string, IParameterizedCommand>()
				{
					{"DerNetPrice",collectionNonTriggerUpdateRequestFactory.Clause("round(DiscountPrice * QtyShippedConv, {0})", DomCurrencyPlaces)},
					{"DerTotCost",collectionNonTriggerUpdateRequestFactory.Clause("round(CostConv * QtyShippedConv, {0})", DomCurrencyPlaces)}
				},
				fromClause: collectionNonTriggerUpdateRequestFactory.Clause(""),
				whereClause: collectionNonTriggerUpdateRequestFactory.Clause(""));

			this.appDB.UpdateWithoutTrigger(tempCoitemUpdateRequest);
		}

		public void UpdateTempCoitem()
		{
			var tempCoitemUpdateRequest = collectionNonTriggerUpdateRequestFactory.SQLUpdate(
				tableName: "#Coitem",
				expressionByColumnToAssign: new Dictionary<string, IParameterizedCommand>()
				{
					{"DerMargin",collectionNonTriggerUpdateRequestFactory.Clause("DerNetPrice - DerTotCost")},
				},
				fromClause: collectionNonTriggerUpdateRequestFactory.Clause(""),
				whereClause: collectionNonTriggerUpdateRequestFactory.Clause(""));

			this.appDB.UpdateWithoutTrigger(tempCoitemUpdateRequest);
		}

		public void InsertTempCoitemsumForViewS()
		{
			this.sQLExpressionExecutor.Execute(@"INSERT INTO #CoitemSum (
                ShipSite,
                DerTotCost,
                DerNetPrice,
                DerMargin)
                SELECT
                ShipSite,
                SUM(DerTotCost),
                SUM(DerNetPrice),
                SUM(DerMargin)
                FROM #Coitem
                GROUP BY ShipSite");
		}

		public void InsertTempCoitemsumForViewP()
		{
			this.sQLExpressionExecutor.Execute(@"INSERT INTO #CoitemSum (
                DerProductCode,
                DerTotCost,
                DerNetPrice,
                DerMargin
                )
                SELECT
                DerProductCode,
                SUM(DerTotCost),
                SUM(DerNetPrice),
                SUM(DerMargin)
                FROM #Coitem
                GROUP BY DerProductCode");
		}

		public void InsertTempCoitemsumForViewI()
		{
			this.sQLExpressionExecutor.Execute(@"INSERT INTO #CoitemSum (
                Item,
                ItDescription,
                DerTotCost,
                DerNetPrice,
                DerMargin,
                DerProductCode
                )
                SELECT
                Item,
                ItDescription,
                SUM(DerTotCost),
                SUM(DerNetPrice),
                SUM(DerMargin),
                DerProductCode
                FROM #Coitem
                GROUP BY Item,ItDescription,DerProductCode");
		}

		public void UpdateTempCoitemsumByDomCurrCode(string DomCurrCode)
		{
			if (DomCurrCode == null) return;
			var tempCoitemsumUpdateRequest = collectionNonTriggerUpdateRequestFactory.SQLUpdate(
				tableName: "#CoitemSum",
				expressionByColumnToAssign: new Dictionary<string, IParameterizedCommand>()
				{
					{"DomCurrCode",collectionNonTriggerUpdateRequestFactory.Clause("{0}", DomCurrCode)},
				},
				fromClause: collectionNonTriggerUpdateRequestFactory.Clause(""),
				whereClause: collectionNonTriggerUpdateRequestFactory.Clause(""));

			this.appDB.UpdateWithoutTrigger(tempCoitemsumUpdateRequest);
		}

		public void CreateTempCoitem2()
		{
			this.sQLExpressionExecutor.Execute(@"SELECT   CoOrigSite,
						         CoNum,
						         CoLine,
						         CoRelease,
						         Item,
						         ItDescription,
						         DerProductCode,
						         ShipSite,
						         SUM(DerTotCost) AS DerTotCost,
						         SUM(DerNetPrice) AS DerNetPrice,
						         SUM(DerMargin) AS DerMargin,
						         CoCustNum,
						         Adr0Name,
						         DomCurrCode,
						         MAX(seq) AS seq
						INTO     #Coitem2
						FROM     #Coitem
						GROUP BY CoOrigSite, CoNum, CoLine, CoRelease, Item, ItDescription, DerProductCode, ShipSite, CoCustNum, Adr0Name, DomCurrCode");
		}

		public ICollectionLoadResponse GetResultFromTempCoitemSum(LoadType loadType = LoadType.First, int recordCap = 5000)
		{

			ICollectionLoadResponse Data = null;
			var CoitemSumLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"CoOrigSite","NULL"},
					{"CoNum","NULL"},
					{"CoLine","NULL"},
					{"CoRelease","NULL"},
					{"Item","Item"},
					{"ItDescription","ItDescription"},
					{"DerProductCode","DerProductCode"},
					{"ShipSite","ShipSite"},
					{"DerTotCost","DerTotCost"},
					{"DerNetPrice","DerNetPrice"},
					{"DerMargin","DerMargin"},
					{"CoCustNum","NULL"},
					{"Adr0Name","NULL"},
					{"UbGrandTotCost","(SELECT TOP 1 isnull(SUM(DerTotCost), 'NULL') FROM   #Coitem)"},
					{"UbGrandTotPrice","(SELECT TOP 1 isnull(SUM(DerNetPrice), 'NULL') FROM   #Coitem)"},
					{"UbGrandTotMargin","(SELECT TOP 1 isnull(SUM(DerMargin), 'NULL') FROM   #Coitem)"},
					{"DomCurrCode","DomCurrCode"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName: "#CoitemSum",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(" ShipSite, DerProductCode, Item"));

			// Build the sort order columns first. Then build the default values.
			Dictionary<string, SortOrderDirection> dicSortOrder = new Dictionary<string, SortOrderDirection>();
			dicSortOrder.Add("ShipSite", SortOrderDirection.Ascending);
			dicSortOrder.Add("DerProductCode", SortOrderDirection.Ascending);
			dicSortOrder.Add("Item", SortOrderDirection.Ascending);

			// The following code is building default values for RowPointer (guid type) and price (decimal type) columns.
			Dictionary<string, object> dicDefaultValue = new Dictionary<string, object>();
			dicDefaultValue.Add("ShipSite", "");
			dicDefaultValue.Add("DerProductCode", "");
			dicDefaultValue.Add("Item", "");

			// Invoke create method provide both sort columns and their defalut values.
			var sortOrder = sortOrderFactory.Create(dicSortOrder, dicDefaultValue);

			using (IRecordBunch recordBunch = recordBunchFactory.Create(appDB, queryLanguage, getVariable, defineProcessVariable,
				mgSessionVariableBasedCache, collectionLoadRequestFactory, CoitemSumLoadRequest, sortOrder, bookmarkFactory,
				SQLPagedRecordBunchBookmarkID.BunchingBookmark, BunchType.Load, loadType, recordCap, true))
			{
				if (recordBunch.ReadPage())
					Data = recordBunch.CurrentPage;
			}

			return Data;
		}

		public ICollectionLoadResponse GetResultFromTempCoitem2(LoadType loadType = LoadType.First, int recordCap = 5000)
		{
			ICollectionLoadResponse Data = null;
			var Coitem2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"CoOrigSite","CoOrigSite"},
					{"CoNum","CoNum"},
					{"CoLine","CoLine"},
					{"CoRelease","CoRelease"},
					{"Item","Item"},
					{"ItDescription","ItDescription"},
					{"DerProductCode","DerProductCode"},
					{"ShipSite","ShipSite"},
					{"DerTotCost","DerTotCost"},
					{"DerNetPrice","DerNetPrice"},
					{"DerMargin","DerMargin"},
					{"CoCustNum","CoCustNum"},
					{"Adr0Name","Adr0Name"},
					{"UbGrandTotCost","(SELECT TOP 1 isnull(SUM(DerTotCost), 'NULL') FROM   #Coitem)"},
					{"UbGrandTotPrice","(SELECT TOP 1 isnull(SUM(DerNetPrice), 'NULL') FROM   #Coitem)"},
					{"UbGrandTotMargin","(SELECT TOP 1 isnull(SUM(DerMargin), 'NULL') FROM   #Coitem)"},
					{"DomCurrCode","DomCurrCode"},
					{"seq","seq"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName: "#Coitem2",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(" seq"));

			Dictionary<string, SortOrderDirection> dicSortOrder = new Dictionary<string, SortOrderDirection>();
			dicSortOrder.Add("seq", SortOrderDirection.Ascending);

			var sortOrder = sortOrderFactory.Create(dicSortOrder);

			using (IRecordBunch recordBunch = recordBunchFactory.Create(appDB, queryLanguage, getVariable, defineProcessVariable,
				mgSessionVariableBasedCache, collectionLoadRequestFactory, Coitem2LoadRequest, sortOrder, bookmarkFactory,
				SQLPagedRecordBunchBookmarkID.BunchingBookmark, BunchType.Load, loadType, recordCap, true))
			{
				if (recordBunch.ReadPage())
					Data = recordBunch.CurrentPage;
			}

			return Data;
		}

		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		AltExtGen_CLM_ExecutiveShipmentRevenueSp(
			string AltExtGenSp,
			string View,
			string SiteGroup,
			DateTime? DateStarting,
			DateTime? DateEnding,
			string FilterString = null)
		{
			StringType _View = View;
			SiteGroupType _SiteGroup = SiteGroup;
			DateType _DateStarting = DateStarting;
			DateType _DateEnding = DateEnding;
			LongListType _FilterString = FilterString;

			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;

				appDB.AddCommandParameter(cmd, "View", _View, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteGroup", _SiteGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateStarting", _DateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateEnding", _DateEnding, ParameterDirection.Input);
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
