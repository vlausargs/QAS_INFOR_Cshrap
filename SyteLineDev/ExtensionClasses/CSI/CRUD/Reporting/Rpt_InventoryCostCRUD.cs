//PROJECT NAME: Reporting
//CLASS NAME: Rpt_InventoryCostCRUD.cs

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
	public class Rpt_InventoryCostCRUD : IRpt_InventoryCostCRUD
	{
		readonly IApplicationDB appDB;
		readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly ICollectionNonTriggerInsertRequestFactory collectionNonTriggerInsertRequestFactory;
		readonly ICollectionNonTriggerUpdateRequestFactory collectionNonTriggerUpdateRequestFactory;
		readonly ICollectionNonTriggerDeleteRequestFactory collectionNonTriggerDeleteRequestFactory;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IExistsChecker existsChecker;
		readonly IStringUtil stringUtil;

		// IUnionUtil
		readonly IUnionUtil unionUtil_MatlType;
		readonly IUnionUtil unionUtil_CostType;
		readonly IUnionUtil unionUtil_CostMethod;

		// Bunch required interfaces
		readonly IRecordBunchFactory recordBunchFactory;
		readonly IQueryLanguage queryLanguage;
		readonly IGetVariable getVariable;
		readonly IDefineProcessVariable defineProcessVariable;
		readonly ISessionBasedCache mgSessionVariableBasedCache;
		readonly IBookmarkFactory bookmarkFactory;
		readonly ISortOrderFactory sortOrderFactory;

		public Rpt_InventoryCostCRUD(IApplicationDB appDB,
			ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			ICollectionNonTriggerInsertRequestFactory collectionNonTriggerInsertRequestFactory,
			ICollectionNonTriggerUpdateRequestFactory collectionNonTriggerUpdateRequestFactory,
			ICollectionNonTriggerDeleteRequestFactory collectionNonTriggerDeleteRequestFactory,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IExistsChecker existsChecker,
			IStringUtil stringUtil,
			IUnionUtil unionUtil_MatlType,
		    IUnionUtil unionUtil_CostType,
		    IUnionUtil unionUtil_CostMethod,
		    // Bunch required interfaces
		    IRecordBunchFactory recordBunchFactory,
			IQueryLanguage queryLanguage,
			IGetVariable getVariable,
			IDefineProcessVariable defineProcessVariable,
			ISessionBasedCache mgSessionVariableBasedCache,
			IBookmarkFactory bookmarkFactory,
			ISortOrderFactory sortOrderFactory)
		{
			this.appDB = appDB;
			this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.collectionNonTriggerInsertRequestFactory = collectionNonTriggerInsertRequestFactory;
			this.collectionNonTriggerUpdateRequestFactory = collectionNonTriggerUpdateRequestFactory;
			this.collectionNonTriggerDeleteRequestFactory = collectionNonTriggerDeleteRequestFactory;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.existsChecker = existsChecker;
			this.stringUtil = stringUtil;
			this.unionUtil_MatlType = unionUtil_MatlType;
			this.unionUtil_CostType = unionUtil_CostType;
			this.unionUtil_CostMethod = unionUtil_CostMethod;
			// Bunch required interfaces
			this.recordBunchFactory = recordBunchFactory;
			this.queryLanguage = queryLanguage;
			this.getVariable = getVariable;
			this.defineProcessVariable = defineProcessVariable;
			this.mgSessionVariableBasedCache = mgSessionVariableBasedCache;
			this.bookmarkFactory = bookmarkFactory;
			this.sortOrderFactory = sortOrderFactory;
		}
		
		public bool Optional_ModuleForExists()
		{
			return existsChecker.Exists(tableName:"optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_InventoryCostSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"));
		}
		
		public ICollectionLoadResponse Optional_Module1Select()
		{
			var optional_module1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"SpName","CAST (NULL AS NVARCHAR)"},
					{"u0","[om].[ModuleName]"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_InventoryCostSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			
			var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
			
			foreach(var optional_module1Item in optional_module1LoadResponse.Items){
				optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("Rpt_InventoryCostSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
			};
			
			return optional_module1LoadResponse;
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
				loadForChange: true,
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
		
		public (string ParmsCurrCode, int? rowCount) CurrparmsLoad(string ParmsCurrCode)
		{
			CurrCodeType _ParmsCurrCode = DBNull.Value;
			
			var currparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_ParmsCurrCode,"curr_code"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"currparms",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var currparmsLoadResponse = this.appDB.Load(currparmsLoadRequest);
			if(currparmsLoadResponse.Items.Count > 0)
			{
				ParmsCurrCode = _ParmsCurrCode;
			}
			
			int rowCount = currparmsLoadResponse.Items.Count;
			return (ParmsCurrCode, rowCount);
		}
		
		public (int? CostPricePlaces, string CostPriceFormat, int? rowCount) CurrencyLoad(string ParmsCurrCode, string CostPriceFormat, int? CostPricePlaces)
		{
			DecimalPlacesType _CostPricePlaces = DBNull.Value;
			InputMaskType _CostPriceFormat = DBNull.Value;
			
			var currencyLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_CostPricePlaces,"places_cp"},
					{_CostPriceFormat,"cst_prc_format"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				maximumRows: 1,
				tableName:"currency",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("currency.curr_code = {0}",ParmsCurrCode),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var currencyLoadResponse = this.appDB.Load(currencyLoadRequest);
			if(currencyLoadResponse.Items.Count > 0)
			{
				CostPricePlaces = _CostPricePlaces;
				CostPriceFormat = _CostPriceFormat;
			}
			
			int rowCount = currencyLoadResponse.Items.Count;
			return (CostPricePlaces, CostPriceFormat, rowCount);
		}
		
		public (int? CostItemAtWhse, int? rowCount) Dbo_InvparmsLoad(int? CostItemAtWhse)
		{
			ListYesNoType _CostItemAtWhse = DBNull.Value;
			
			var dbo_invparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_CostItemAtWhse,"invparms.cost_item_at_whse"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"dbo.invparms",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var dbo_invparmsLoadResponse = this.appDB.Load(dbo_invparmsLoadRequest);
			if(dbo_invparmsLoadResponse.Items.Count > 0)
			{
				CostItemAtWhse = _CostItemAtWhse;
			}
			
			int rowCount = dbo_invparmsLoadResponse.Items.Count;
			return (CostItemAtWhse, rowCount);
		}
		
		public void SelectInsert_Tv_ItemGeneral(Guid? processId, string ExbegWhse, string ExendWhse, string ExbegLoc, string ExendLoc, string ExbegProductcode,
			string ExendProductcode, string ExbegItem, string ExendItem, string ExOptgoItemStat, string ExOptgoMatlType, string ExOptprPMTCode,
			string ExOptacAbcCode, int? TStock, string ParmsCurrCode, DateTime? GetSiteDate, int? ExOptprPrZeroQty, string CostPriceFormat, int? CostPricePlaces)
		{
			var selectInsertRequest = collectionNonTriggerInsertRequestFactory.SQLInsert(targetTableName: "tmp_rpt_inventory_cost",
				targetColumns: new List<string>
				{ "process_id",
			      "whse",
                  "item",
                  "loc",
                  "lot",
                  "status",
                  "item_desc",
                  "item_stocked",
                  "matl_type",
                  "cost_method",
                  "u_m",
                  "pmt_code",
                  "product_code",
                  "cost_type",
                  "itemloc_inv_acct",
                  "itemloc_lbr_acct",
                  "itemloc_fovhd_acct",
                  "itemloc_vovhd_acct",
                  "itemloc_out_acct",
                  "lot_tracked",
                  "itemprice_unit_price1",
                  "qty_on_hand",
                  "cpr_cost",
                  "matl_cost",
                  "lbr_cost",
                  "fovhd_cost",
                  "vovhd_cost",
                  "out_cost",
				  "CostPriceFormat",
				  "CostPricePlaces",
				  "matl_type_description",
				  "cost_method_description",
				  "cost_type_description",
				},
				valuesByExpressionToAssign: new Dictionary<string, IParameterizedCommand>()
				{
					{"process_id", collectionNonTriggerInsertRequestFactory.Clause("{0}", processId)},
					{"whse",collectionNonTriggerInsertRequestFactory.Clause("itemloc.whse")},
					{"item",collectionNonTriggerInsertRequestFactory.Clause("itemloc.item")},
					{"loc",collectionNonTriggerInsertRequestFactory.Clause("itemloc.loc")},
					{"lot",collectionNonTriggerInsertRequestFactory.Clause("lot_loc.lot")},
					{"status",collectionNonTriggerInsertRequestFactory.Clause("item.stat")},
					{"item_desc",collectionNonTriggerInsertRequestFactory.Clause("item.description")},
					{"item_stocked",collectionNonTriggerInsertRequestFactory.Clause("item.stocked")},
					{"matl_type",collectionNonTriggerInsertRequestFactory.Clause("item.matl_type")},
					{"cost_method",collectionNonTriggerInsertRequestFactory.Clause("item.cost_method")},
					{"u_m",collectionNonTriggerInsertRequestFactory.Clause("item.u_m")},
					{"pmt_code",collectionNonTriggerInsertRequestFactory.Clause("item.p_m_t_code")},
					{"product_code",collectionNonTriggerInsertRequestFactory.Clause("item.product_code")},
					{"cost_type",collectionNonTriggerInsertRequestFactory.Clause("item.cost_type")},
					{"itemloc_inv_acct",collectionNonTriggerInsertRequestFactory.Clause("itemloc.inv_acct")},
					{"itemloc_lbr_acct",collectionNonTriggerInsertRequestFactory.Clause("itemloc.lbr_acct")},
					{"itemloc_fovhd_acct",collectionNonTriggerInsertRequestFactory.Clause("itemloc.fovhd_acct")},
					{"itemloc_vovhd_acct",collectionNonTriggerInsertRequestFactory.Clause("itemloc.vovhd_acct")},
					{"itemloc_out_acct",collectionNonTriggerInsertRequestFactory.Clause("itemloc.out_acct")},
					{"lot_tracked",collectionNonTriggerInsertRequestFactory.Clause("item.lot_tracked")},
					{"itemprice_unit_price1",collectionNonTriggerInsertRequestFactory.Clause("isnull((SELECT TOP 1 unit_price1 FROM itemprice WHERE itemprice.item = item.item AND itemprice.effect_date <= {1} AND itemprice.curr_code = {0} ORDER BY itemprice.effect_date DESC), 0)", ParmsCurrCode,GetSiteDate)},
					{"qty_on_hand",collectionNonTriggerInsertRequestFactory.Clause("lot_loc.qty_on_hand")},
					{"cpr_cost",collectionNonTriggerInsertRequestFactory.Clause("CASE WHEN item.cost_type = 'S' OR item.cost_method IN ('A', 'C', 'L', 'F') THEN item.unit_cost ELSE lot_loc.unit_cost END")},
					{"matl_cost",collectionNonTriggerInsertRequestFactory.Clause("CASE WHEN item.cost_type = 'S' OR item.cost_method IN ('A', 'C', 'L', 'F') THEN item.matl_cost ELSE lot_loc.matl_cost END")},
					{"lbr_cost",collectionNonTriggerInsertRequestFactory.Clause("CASE WHEN item.cost_type = 'S' OR item.cost_method IN ('A', 'C', 'L', 'F') THEN item.lbr_cost ELSE lot_loc.lbr_cost END")},
					{"fovhd_cost",collectionNonTriggerInsertRequestFactory.Clause("CASE WHEN item.cost_type = 'S' OR item.cost_method IN ('A', 'C', 'L', 'F') THEN item.fovhd_cost ELSE lot_loc.fovhd_cost END")},
					{"vovhd_cost",collectionNonTriggerInsertRequestFactory.Clause("CASE WHEN item.cost_type = 'S' OR item.cost_method IN ('A', 'C', 'L', 'F') THEN item.vovhd_cost ELSE lot_loc.vovhd_cost END")},
					{"out_cost",collectionNonTriggerInsertRequestFactory.Clause("CASE WHEN item.cost_type = 'S' OR item.cost_method IN ('A', 'C', 'L', 'F') THEN item.out_cost ELSE lot_loc.out_cost END")},
					{"CostPriceFormat", collectionNonTriggerInsertRequestFactory.Clause("{0}", CostPriceFormat)},
					{"CostPricePlaces", collectionNonTriggerInsertRequestFactory.Clause("{0}", CostPricePlaces)},
					{"matl_type_description", collectionNonTriggerInsertRequestFactory.Clause("mt.matl_type_description")},
                    {"cost_method_description", collectionNonTriggerInsertRequestFactory.Clause("cm.cost_method_description")},
                    {"cost_type_description", collectionNonTriggerInsertRequestFactory.Clause("ct.cost_type_description")},
				},
				fromClause: collectionNonTriggerInsertRequestFactory.Clause(@"item inner join itemloc on item.item = itemloc.item inner join whse on itemloc.whse = whse.whse inner join location on itemloc.loc = location.loc inner join lot_loc on lot_loc.item = itemloc.item
					and lot_loc.whse = itemloc.whse and lot_loc.loc = itemloc.loc and({0} = 1 or lot_loc.qty_on_hand != 0)
                    INNER JOIN #tv_MatlType AS mt ON mt.matl_type = item.matl_type
                    INNER JOIN #tv_CostType AS ct ON ct.cost_type = item.cost_type
                    INNER JOIN #tv_CostMethod AS cm ON cm.cost_method = item.cost_method", ExOptprPrZeroQty),
				whereClause: collectionNonTriggerInsertRequestFactory.Clause("item.lot_tracked = 1 AND whse.whse BETWEEN {6} AND {7} AND location.loc BETWEEN {10} AND {11} AND itemloc.item BETWEEN {8} AND {9} AND (item.product_code BETWEEN {0} AND {1}) AND (CHARINDEX(item.matl_type, {2}) <> 0 OR ISNULL({2}, '') = '') AND (CHARINDEX(item.p_m_t_code, {4}) > 0) AND (item.stocked = {12} OR ISNULL({12}, 2) = 2) AND (CHARINDEX(item.abc_code, {5}) <> 0 OR ISNULL({5}, '') = '') AND (CHARINDEX(item.stat, {3}) <> 0 OR ISNULL({3}, '') = '')", ExbegProductcode, ExendProductcode, ExOptgoMatlType, ExOptgoItemStat, ExOptprPMTCode, ExOptacAbcCode, ExbegWhse, ExendWhse, ExbegItem, ExendItem, ExbegLoc, ExendLoc, TStock),
				orderByClause: collectionNonTriggerInsertRequestFactory.Clause(""));
			this.appDB.InsertWithoutTrigger(selectInsertRequest);
		}

		public void SelectInsert1_Tv_ItemGeneral(Guid? processId, string ExbegWhse, string ExendWhse, string ExbegLoc, string ExendLoc, string ExbegProductcode, 
			string ExendProductcode, string ExbegItem, string ExendItem, string ExOptgoItemStat, string ExOptgoMatlType, string ExOptprPMTCode, 
			string ExOptacAbcCode, int? TStock, string ParmsCurrCode, DateTime? GetSiteDate, int? ExOptprPrZeroQty, string CostPriceFormat, int? CostPricePlaces)
        {
			var selectInsertRequest = collectionNonTriggerInsertRequestFactory.SQLInsert(targetTableName: "tmp_rpt_inventory_cost",
				targetColumns: new List<string>
				{ "process_id",
			      "whse",
				  "item",
				  "loc",
				  "lot",
				  "status",
				  "item_desc",
				  "item_stocked",
				  "matl_type",
				  "cost_method",
				  "u_m",
				  "pmt_code",
				  "product_code",
				  "cost_type",
				  "itemloc_inv_acct",
				  "itemloc_lbr_acct",
				  "itemloc_fovhd_acct",
				  "itemloc_vovhd_acct",
				  "itemloc_out_acct",
				  "lot_tracked",
				  "itemprice_unit_price1",
				  "qty_on_hand",
				  "cpr_cost",
				  "matl_cost",
				  "lbr_cost",
				  "fovhd_cost",
				  "vovhd_cost",
				  "out_cost",
				  "CostPriceFormat",
				  "CostPricePlaces",
				  "matl_type_description",
				  "cost_method_description",
				  "cost_type_description",
				},
				valuesByExpressionToAssign: new Dictionary<string, IParameterizedCommand>()
				{
					{"process_id",collectionNonTriggerInsertRequestFactory.Clause("{0}", processId)},
					{"whse",collectionNonTriggerInsertRequestFactory.Clause("itemloc.whse")},
					{"item",collectionNonTriggerInsertRequestFactory.Clause("itemloc.item")},
					{"loc",collectionNonTriggerInsertRequestFactory.Clause("itemloc.loc")},
					{"lot",collectionNonTriggerInsertRequestFactory.Clause("''")},
					{"status",collectionNonTriggerInsertRequestFactory.Clause("item.stat")},
					{"item_desc",collectionNonTriggerInsertRequestFactory.Clause("item.description")},
					{"item_stocked",collectionNonTriggerInsertRequestFactory.Clause("item.stocked")},
					{"matl_type",collectionNonTriggerInsertRequestFactory.Clause("item.matl_type")},
					{"cost_method",collectionNonTriggerInsertRequestFactory.Clause("item.cost_method")},
					{"u_m",collectionNonTriggerInsertRequestFactory.Clause("item.u_m")},
					{"pmt_code",collectionNonTriggerInsertRequestFactory.Clause("item.p_m_t_code")},
					{"product_code",collectionNonTriggerInsertRequestFactory.Clause("item.product_code")},
					{"cost_type",collectionNonTriggerInsertRequestFactory.Clause("item.cost_type")},
					{"itemloc_inv_acct",collectionNonTriggerInsertRequestFactory.Clause("itemloc.inv_acct")},
					{"itemloc_lbr_acct",collectionNonTriggerInsertRequestFactory.Clause("itemloc.lbr_acct")},
					{"itemloc_fovhd_acct",collectionNonTriggerInsertRequestFactory.Clause("itemloc.fovhd_acct")},
					{"itemloc_vovhd_acct",collectionNonTriggerInsertRequestFactory.Clause("itemloc.vovhd_acct")},
					{"itemloc_out_acct",collectionNonTriggerInsertRequestFactory.Clause("itemloc.out_acct")},
					{"lot_tracked",collectionNonTriggerInsertRequestFactory.Clause("item.lot_tracked")},
					{"itemprice_unit_price1",collectionNonTriggerInsertRequestFactory.Clause("isnull((SELECT TOP 1 unit_price1 FROM itemprice WHERE itemprice.item = item.item AND itemprice.effect_date <= {1} AND itemprice.curr_code = {0} ORDER BY itemprice.effect_date DESC), 0)", ParmsCurrCode,GetSiteDate)},
					{"qty_on_hand",collectionNonTriggerInsertRequestFactory.Clause("itemloc.qty_on_hand")},
					{"cpr_cost",collectionNonTriggerInsertRequestFactory.Clause("CASE WHEN item.cost_type = 'S' OR item.cost_method IN ('A', 'C', 'L', 'F') THEN item.unit_cost ELSE itemloc.unit_cost END")},
					{"matl_cost",collectionNonTriggerInsertRequestFactory.Clause("CASE WHEN item.cost_type = 'S' OR item.cost_method IN ('A', 'C', 'L', 'F') THEN item.matl_cost ELSE itemloc.matl_cost END")},
					{"lbr_cost",collectionNonTriggerInsertRequestFactory.Clause("CASE WHEN item.cost_type = 'S' OR item.cost_method IN ('A', 'C', 'L', 'F') THEN item.lbr_cost ELSE itemloc.lbr_cost END")},
					{"fovhd_cost",collectionNonTriggerInsertRequestFactory.Clause("CASE WHEN item.cost_type = 'S' OR item.cost_method IN ('A', 'C', 'L', 'F') THEN item.fovhd_cost ELSE itemloc.fovhd_cost END")},
					{"vovhd_cost",collectionNonTriggerInsertRequestFactory.Clause("CASE WHEN item.cost_type = 'S' OR item.cost_method IN ('A', 'C', 'L', 'F') THEN item.vovhd_cost ELSE itemloc.vovhd_cost END")},
					{"out_cost",collectionNonTriggerInsertRequestFactory.Clause("CASE WHEN item.cost_type = 'S' OR item.cost_method IN ('A', 'C', 'L', 'F') THEN item.out_cost ELSE itemloc.out_cost END")},
					{"CostPriceFormat", collectionNonTriggerInsertRequestFactory.Clause("{0}", CostPriceFormat)},
					{"CostPricePlaces", collectionNonTriggerInsertRequestFactory.Clause("{0}", CostPricePlaces)},
					{"matl_type_description", collectionNonTriggerInsertRequestFactory.Clause("mt.matl_type_description")},
					{"cost_method_description", collectionNonTriggerInsertRequestFactory.Clause("cm.cost_method_description")},
					{"cost_type_description", collectionNonTriggerInsertRequestFactory.Clause("ct.cost_type_description")},
				},
				fromClause: collectionNonTriggerInsertRequestFactory.Clause(@"item inner join itemloc on item.item = itemloc.item
					and ({0} = 1 or itemloc.qty_on_hand != 0) inner join whse on itemloc.whse = whse.whse inner join location on itemloc.loc = location.loc
                    INNER JOIN #tv_MatlType AS mt ON mt.matl_type = item.matl_type
                    INNER JOIN #tv_CostType AS ct ON ct.cost_type = item.cost_type
                    INNER JOIN #tv_CostMethod AS cm ON cm.cost_method = item.cost_method", ExOptprPrZeroQty),
				whereClause: collectionNonTriggerInsertRequestFactory.Clause("item.lot_tracked = 0 AND whse.whse BETWEEN {6} AND {7} AND location.loc BETWEEN {10} AND {11} AND itemloc.item BETWEEN {8} AND {9} AND (item.product_code BETWEEN {0} AND {1}) AND (CHARINDEX(item.matl_type, {2}) <> 0 OR ISNULL({2}, '') = '') AND (CHARINDEX(item.p_m_t_code, {4}) > 0) AND (item.stocked = {12} OR ISNULL({12}, 2) = 2) AND (CHARINDEX(item.abc_code, {5}) <> 0 OR ISNULL({5}, '') = '') AND (CHARINDEX(item.stat, {3}) <> 0 OR ISNULL({3}, '') = '')", ExbegProductcode, ExendProductcode, ExOptgoMatlType, ExOptgoItemStat, ExOptprPMTCode, ExOptacAbcCode, ExbegWhse, ExendWhse, ExbegItem, ExendItem, ExbegLoc, ExendLoc, TStock),
				orderByClause: collectionNonTriggerInsertRequestFactory.Clause(""));
			this.appDB.InsertWithoutTrigger(selectInsertRequest);
		}

		public void UpdateTmpItemGeneral0(Guid? processId)
        {
			string populateCTECmd = string.Format($@"IF OBJECT_ID('tempdb..#tv_ItemGeneral_Update') IS NOT NULL
                                         DROP TABLE #tv_ItemGeneral_Update
                                      select sum(itemlifo.qty) as sum_qty
                                      , sum(itemlifo.qty * itemlifo.unit_cost) as sum_unit_cost
                                      , sum(itemlifo.qty * itemlifo.matl_cost) as sum_matl_cost
                                      , sum(itemlifo.qty * itemlifo.lbr_cost) as sum_lbr_cost
                                      , sum(itemlifo.qty * itemlifo.fovhd_cost) as sum_fovhd_cost
                                      , sum(itemlifo.qty * itemlifo.vovhd_cost) as sum_vovhd_cost
                                      , sum(itemlifo.qty * itemlifo.out_cost) as sum_out_cost
                                      , itemlifo.item
                                       INTO #tv_ItemGeneral_Update
                                      from tmp_rpt_inventory_cost as ig
                                          inner join itemlifo on
                                             itemlifo.item = ig.item
                                             and itemlifo.inv_acct = ig.itemloc_inv_acct
                                             and itemlifo.lbr_acct = ig.itemloc_lbr_acct
                                             and itemlifo.fovhd_acct = ig.itemloc_fovhd_acct
                                             and itemlifo.vovhd_acct = ig.itemloc_vovhd_acct
                                             and itemlifo.out_acct = ig.itemloc_out_acct
                                       where process_id = '{processId}' group by itemlifo.item");
			this.sQLExpressionExecutor.Execute(populateCTECmd);

			var TmpItemGeneralUpdateRequest = collectionNonTriggerUpdateRequestFactory.SQLUpdate(tableName: "tmp_rpt_inventory_cost",
				expressionByColumnToAssign: new Dictionary<string, IParameterizedCommand>()
				{
					{"itemlifo_qty", collectionNonTriggerUpdateRequestFactory.Clause("sum_qty")},
					{"itemlifo_unit_cost", collectionNonTriggerUpdateRequestFactory.Clause("sum_unit_cost")},
					{"itemlifo_matl_cost", collectionNonTriggerUpdateRequestFactory.Clause("sum_matl_cost")},
					{"itemlifo_lbr_cost", collectionNonTriggerUpdateRequestFactory.Clause("sum_lbr_cost")},
					{"itemlifo_fovhd_cost", collectionNonTriggerUpdateRequestFactory.Clause("sum_fovhd_cost")},
					{"itemlifo_vovhd_cost", collectionNonTriggerUpdateRequestFactory.Clause("sum_vovhd_cost")},
					{"itemlifo_out_cost", collectionNonTriggerUpdateRequestFactory.Clause("sum_out_cost")},
				},
				fromClause: collectionNonTriggerUpdateRequestFactory.Clause(@"tmp_rpt_inventory_cost as ig
                                                                              inner join #tv_ItemGeneral_Update il on
                                                                                 il.item = ig.item"),
				whereClause: collectionNonTriggerUpdateRequestFactory.Clause("process_id = {0} and ig.cost_type != 'S' and ig.cost_method in ('L', 'F')", processId));
			this.appDB.UpdateWithoutTrigger(TmpItemGeneralUpdateRequest);
		}

		public void UpdateTmpItemGeneral1(Guid? processId)
        {
			var TmpItemGeneralUpdateRequest = collectionNonTriggerUpdateRequestFactory.SQLUpdate(tableName: "tmp_rpt_inventory_cost",
				expressionByColumnToAssign: new Dictionary<string, IParameterizedCommand>()
				{
					{"cpr_cost", collectionNonTriggerUpdateRequestFactory.Clause("case when ig.cost_type = 'S' or ig.cost_method in ('A', 'C', 'L', 'F') then itemwhse.unit_cost else ig.cpr_cost end")},
					{"matl_cost", collectionNonTriggerUpdateRequestFactory.Clause("case when ig.cost_type = 'S' or ig.cost_method in ('A', 'C', 'L', 'F') then itemwhse.matl_cost else ig.matl_cost end")},
					{"lbr_cost", collectionNonTriggerUpdateRequestFactory.Clause("case when ig.cost_type = 'S' or ig.cost_method in ('A', 'C', 'L', 'F') then itemwhse.lbr_cost else ig.lbr_cost end")},
					{"fovhd_cost", collectionNonTriggerUpdateRequestFactory.Clause("case when ig.cost_type = 'S' or ig.cost_method in ('A', 'C', 'L', 'F') then itemwhse.fovhd_cost else ig.fovhd_cost end")},
					{"vovhd_cost", collectionNonTriggerUpdateRequestFactory.Clause("case when ig.cost_type = 'S' or ig.cost_method in ('A', 'C', 'L', 'F') then itemwhse.vovhd_cost else ig.vovhd_cost end")},
					{"out_cost", collectionNonTriggerUpdateRequestFactory.Clause("case when ig.cost_type = 'S' or ig.cost_method in ('A', 'C', 'L', 'F') then itemwhse.out_cost else ig.out_cost end")},
				},
				fromClause: collectionNonTriggerUpdateRequestFactory.Clause("tmp_rpt_inventory_cost ig inner join itemwhse on itemwhse.item = ig.item and itemwhse.whse = ig.whse"),
				whereClause: collectionNonTriggerUpdateRequestFactory.Clause("process_id = {0}", processId));
			this.appDB.UpdateWithoutTrigger(TmpItemGeneralUpdateRequest);
		}

		public void UpdateTmpItemGeneral2(Guid? processId)
        {
			string populateCTECmd = string.Format($@"IF OBJECT_ID('tempdb..#tv_ItemGeneral_Update') IS NOT NULL
                                         DROP TABLE #tv_ItemGeneral_Update
                                      select sum(itemlifo.qty) as sum_qty
   	                                  , sum(itemlifo.qty * itemlifo.unit_cost) as sum_unit_cost
   	                                  , sum(itemlifo.qty * itemlifo.matl_cost) as sum_matl_cost
   	                                  , sum(itemlifo.qty * itemlifo.lbr_cost) as sum_lbr_cost
   	                                  , sum(itemlifo.qty * itemlifo.fovhd_cost) as sum_fovhd_cost
   	                                  , sum(itemlifo.qty * itemlifo.vovhd_cost) as sum_vovhd_cost
   	                                  , sum(itemlifo.qty * itemlifo.out_cost) as sum_out_cost
   	                                  , itemlifo.item
                                      , itemlifo.whse
                                      INTO #tv_ItemGeneral_Update
   	                                  from tmp_rpt_inventory_cost as ig
                                           inner join itemlifo on
                                              itemlifo.item = ig.item
                                              and itemlifo.whse = ig.whse
                                              and itemlifo.inv_acct = ig.itemloc_inv_acct
                                              and itemlifo.lbr_acct = ig.itemloc_lbr_acct
                                              and itemlifo.fovhd_acct = ig.itemloc_fovhd_acct
                                              and itemlifo.vovhd_acct = ig.itemloc_vovhd_acct
                                              and itemlifo.out_acct = ig.itemloc_out_acct
                                      where process_id = '{processId}'
   		                               group by itemlifo.item, itemlifo.whse");
			sQLExpressionExecutor.Execute(populateCTECmd);

			var TmpItemGeneralUpdateRequest = collectionNonTriggerUpdateRequestFactory.SQLUpdate(tableName: "tmp_rpt_inventory_cost",
				expressionByColumnToAssign: new Dictionary<string, IParameterizedCommand>()
				{
					{"itemlifo_qty", collectionNonTriggerUpdateRequestFactory.Clause("sum_qty")},
					{"itemlifo_unit_cost", collectionNonTriggerUpdateRequestFactory.Clause("sum_unit_cost")},
					{"itemlifo_matl_cost", collectionNonTriggerUpdateRequestFactory.Clause("sum_matl_cost")},
					{"itemlifo_lbr_cost", collectionNonTriggerUpdateRequestFactory.Clause("sum_lbr_cost")},
					{"itemlifo_fovhd_cost", collectionNonTriggerUpdateRequestFactory.Clause("sum_fovhd_cost")},
					{"itemlifo_vovhd_cost", collectionNonTriggerUpdateRequestFactory.Clause("sum_vovhd_cost")},
					{"itemlifo_out_cost", collectionNonTriggerUpdateRequestFactory.Clause("sum_out_cost")},
				},
				fromClause: collectionNonTriggerUpdateRequestFactory.Clause(@"tmp_rpt_inventory_cost as ig
                                                                              inner join #tv_ItemGeneral_Update il on
                                                                                 il.item = ig.item
                                                                                 and il.whse = ig.whse"),
				whereClause: collectionNonTriggerUpdateRequestFactory.Clause("process_id = {0} and ig.cost_type != 'S' and ig.cost_method in ('L', 'F')", processId));
			this.appDB.UpdateWithoutTrigger(TmpItemGeneralUpdateRequest);
		}

		public void UpdateTmpItemGeneral3(Guid? processId)
		{
			var TmpItemGeneralUpdateRequest = collectionNonTriggerUpdateRequestFactory.SQLUpdate(tableName: "tmp_rpt_inventory_cost",
				expressionByColumnToAssign: new Dictionary<string, IParameterizedCommand>()
				{
					{"cpr_cost", collectionNonTriggerUpdateRequestFactory.Clause("itemlifo_unit_cost / itemlifo_qty")},
					{"matl_cost", collectionNonTriggerUpdateRequestFactory.Clause("itemlifo_matl_cost / itemlifo_qty")},
					{"lbr_cost", collectionNonTriggerUpdateRequestFactory.Clause("itemlifo_lbr_cost / itemlifo_qty")},
					{"fovhd_cost", collectionNonTriggerUpdateRequestFactory.Clause("itemlifo_fovhd_cost / itemlifo_qty")},
					{"vovhd_cost", collectionNonTriggerUpdateRequestFactory.Clause("itemlifo_vovhd_cost / itemlifo_qty")},
					{"out_cost", collectionNonTriggerUpdateRequestFactory.Clause("itemlifo_out_cost / itemlifo_qty")},
				},
				fromClause: collectionNonTriggerUpdateRequestFactory.Clause("tmp_rpt_inventory_cost ig"),
				whereClause: collectionNonTriggerUpdateRequestFactory.Clause("process_id = {0} and ig.cost_type != 'S' and ig.cost_method in ('L', 'F') and ig.itemlifo_qty != 0", processId));
			this.appDB.UpdateWithoutTrigger(TmpItemGeneralUpdateRequest);
		}

		public ICollectionLoadResponse NontableSelect(string Description)
		{
			var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "matl_type", "M" },
					{ "matl_type_description", Description },
			});
			
			return this.appDB.Load(nonTableLoadRequest);
		}
		public void NontableInsert(ICollectionLoadResponse nonTableLoadResponse)
		{
			unionUtil_MatlType.Add(nonTableLoadResponse);
		}
		
		public ICollectionLoadResponse Nontable1Select(string Description)
		{
			var nonTable1LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "matl_type", "F" },
					{ "matl_type_description", Description },
			});
			
			return this.appDB.Load(nonTable1LoadRequest);
		}
		public void Nontable1Insert(ICollectionLoadResponse nonTable1LoadResponse)
		{
			unionUtil_MatlType.Add(nonTable1LoadResponse);
		}
		
		public ICollectionLoadResponse Nontable2Select(string Description)
		{
			var nonTable2LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "matl_type", "T" },
					{ "matl_type_description", Description },
			});
			
			return this.appDB.Load(nonTable2LoadRequest);
		}
		public void Nontable2Insert(ICollectionLoadResponse nonTable2LoadResponse)
		{
			unionUtil_MatlType.Add(nonTable2LoadResponse);
		}
		
		public ICollectionLoadResponse Nontable3Select(string Description)
		{
			var nonTable3LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "matl_type", "O" },
					{ "matl_type_description", Description },
			});
			
			return this.appDB.Load(nonTable3LoadRequest);
		}

		public void Nontable3Insert(ICollectionLoadResponse nonTable3LoadResponse)
		{
			unionUtil_MatlType.Add(nonTable3LoadResponse);

			var nonTable3InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_MatlType",
				items: unionUtil_MatlType.Process(UnionType.UnionAll, null).Items);

            this.appDB.Insert(nonTable3InsertRequest);
        }
		
		public ICollectionLoadResponse Nontable4Select(string Description)
		{
			var nonTable4LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "cost_type", "A" },
					{ "cost_type_description", Description },
			});
			
			return this.appDB.Load(nonTable4LoadRequest);
		}
		public void Nontable4Insert(ICollectionLoadResponse nonTable4LoadResponse)
		{
			unionUtil_CostType.Add(nonTable4LoadResponse);
		}
		
		public ICollectionLoadResponse Nontable5Select(string Description)
		{
			var nonTable5LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "cost_type", "S" },
					{ "cost_type_description", Description },
			});
			
			return this.appDB.Load(nonTable5LoadRequest);
		}
		public void Nontable5Insert(ICollectionLoadResponse nonTable5LoadResponse)
		{
			unionUtil_CostType.Add(nonTable5LoadResponse);

			var nonTable5InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_CostType",
				items: unionUtil_CostType.Process(UnionType.UnionAll, null).Items);
			
			this.appDB.Insert(nonTable5InsertRequest);
		}
		
		public ICollectionLoadResponse Nontable6Select(string Description)
		{
			var nonTable6LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "cost_method", "C" },
					{ "cost_method_description", Description },
			});
			
			return this.appDB.Load(nonTable6LoadRequest);
		}
		public void Nontable6Insert(ICollectionLoadResponse nonTable6LoadResponse)
		{
			unionUtil_CostMethod.Add(nonTable6LoadResponse);
		}
		
		public ICollectionLoadResponse Nontable7Select(string Description)
		{
			var nonTable7LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "cost_method", "A" },
					{ "cost_method_description", Description },
			});
			
			return this.appDB.Load(nonTable7LoadRequest);
		}
		public void Nontable7Insert(ICollectionLoadResponse nonTable7LoadResponse)
		{
			unionUtil_CostMethod.Add(nonTable7LoadResponse);
		}
		
		public ICollectionLoadResponse Nontable8Select(string Description)
		{
			var nonTable8LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "cost_method", "L" },
					{ "cost_method_description", Description },
			});
			
			return this.appDB.Load(nonTable8LoadRequest);
		}
		public void Nontable8Insert(ICollectionLoadResponse nonTable8LoadResponse)
		{
			unionUtil_CostMethod.Add(nonTable8LoadResponse);
		}
		
		public ICollectionLoadResponse Nontable9Select(string Description)
		{
			var nonTable9LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "cost_method", "F" },
					{ "cost_method_description", Description },
			});
			
			return this.appDB.Load(nonTable9LoadRequest);
		}
		public void Nontable9Insert(ICollectionLoadResponse nonTable9LoadResponse)
		{
			unionUtil_CostMethod.Add(nonTable9LoadResponse);
		}
		
		public ICollectionLoadResponse Nontable10Select(string Description)
		{
			var nonTable10LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "cost_method", "S" },
					{ "cost_method_description", Description },
			});
			
			return this.appDB.Load(nonTable10LoadRequest);
		}

		public void Nontable10Insert(ICollectionLoadResponse nonTable10LoadResponse)
		{
			unionUtil_CostMethod.Add(nonTable10LoadResponse);

			var nonTable10InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_CostMethod",
				items: unionUtil_CostMethod.Process(UnionType.UnionAll, null).Items);
			
			this.appDB.Insert(nonTable10InsertRequest);
		}

		public ICollectionLoadResponse SelectBunchPageFromStaging(Guid? processId, int recordCap, LoadType loadType, int? printCost)
        {
			ICollectionLoadResponse resultPage = null;
			var resultLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
			{
				{"whse", "whse"},
                {"loc", "loc"},
                {"lot", "nullif(lot, '')"},
                {"status", "status"},
                {"item", "item"},
                {"qty_on_hand", "qty_on_hand"},
                {"cpr_cost", $"case when {printCost} = 0 then 0 else ig.cpr_cost end"},
                {"cpr_price", $"case when {printCost} = 0 then 0 else ig.itemprice_unit_price1 end"},
                {"amt_cost", $"case when {printCost} = 0 then 0 else ig.cpr_cost * ig.qty_on_hand end"},
                {"amt_price", $"case when {printCost} = 0 then 0 else ig.qty_on_hand * ig.itemprice_unit_price1 end"},
                {"item_desc", "item_desc"},
                {"item_stocked", "item_stocked"},
                {"matl_type_description", "matl_type_description"},
                {"cost_method_description", "cost_method_description"},
                {"u_m", "ig.u_m"},
                {"description", "u_m.description"},
                {"pmt_code", "ig.pmt_code"},
                {"product_code", "ig.product_code"},
                {"cost_type_description", "cost_type_description"},
                {"matl_cost", $"case when {printCost} = 0 then 0 else ig.matl_cost * ig.qty_on_hand end"},
                {"lbr_cost", $"case when {printCost} = 0 then 0 else ig.lbr_cost * ig.qty_on_hand end"},
                {"fovhd_cost", $"case when {printCost} = 0 then 0 else ig.fovhd_cost * ig.qty_on_hand end"},
                {"vovhd_cost", $"case when {printCost} = 0 then 0 else ig.vovhd_cost * ig.qty_on_hand end"},
                {"out_cost", $"case when {printCost} = 0 then 0 else ig.out_cost * ig.qty_on_hand end"},
                {"CostPriceFormat", "CostPriceFormat"},
                {"CostPricePlaces", "CostPricePlaces"},
                {"process_id", "process_id"},
			},
			tableName: "tmp_rpt_inventory_cost",
			loadForChange: false,
			lockingType: LockingType.None,
			fromClause: collectionLoadRequestFactory.Clause("AS ig LEFT OUTER JOIN u_m ON u_m.u_m = ig.u_m"),
			whereClause: collectionLoadRequestFactory.Clause("process_id = {0}", processId),
			orderByClause: collectionLoadRequestFactory.Clause("whse, loc, item, lot"));

			Dictionary<string, SortOrderDirection> dicResultSortOrder = new Dictionary<string, SortOrderDirection>();
			dicResultSortOrder.Add("whse", SortOrderDirection.Ascending);
			dicResultSortOrder.Add("loc", SortOrderDirection.Ascending);
			dicResultSortOrder.Add("item", SortOrderDirection.Ascending);
			dicResultSortOrder.Add("lot", SortOrderDirection.Ascending);
			ISortOrder resultSortOrder = sortOrderFactory.Create(dicResultSortOrder);
			
			using (IRecordBunch recordBunch = recordBunchFactory.Create(appDB, queryLanguage, getVariable, defineProcessVariable,
				mgSessionVariableBasedCache, collectionLoadRequestFactory, resultLoadRequest, resultSortOrder, bookmarkFactory,
				SQLPagedRecordBunchBookmarkID.BunchingBookmark, BunchType.Load, loadType, recordCap, true))
            {
				if (recordBunch.ReadPage())
					resultPage = recordBunch.CurrentPage;
            }

	        return resultPage;
        }

		public void CleanupStagingTable(Guid? processId)
        {
			var deleteStagingRequest = collectionNonTriggerDeleteRequestFactory.SQLDelete(tableName: "tmp_rpt_inventory_cost",
				fromClause: collectionNonTriggerDeleteRequestFactory.Clause(""),
				whereClause: collectionNonTriggerDeleteRequestFactory.Clause("process_id = {0}", processId));
			this.appDB.DeleteWithoutTrigger(deleteStagingRequest);
        }
		
		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		AltExtGen_Rpt_InventoryCostSp(
			string AltExtGenSp,
			string ExbegWhse = null,
			string ExendWhse = null,
			string ExbegLoc = null,
			string ExendLoc = null,
			string ExbegProductcode = null,
			string ExendProductcode = null,
			string ExbegItem = null,
			string ExendItem = null,
			string ExOptgoItemStat = "AOS",
			string ExOptgoMatlType = "MTFO",
			string ExOptprPMTCode = "PMT",
			string ExOptszStocked = "B",
			string ExOptacAbcCode = "ABC",
			int? ExOptprPrZeroQty = 0,
			int? ShowDetail = 0,
			int? PrintCost = 0,
			int? DisplayHeader = null,
			string PMessageLanguage = null,
			string pSite = null,
			Guid? ProcessID = null)
		{
			WhseType _ExbegWhse = ExbegWhse;
			WhseType _ExendWhse = ExendWhse;
			LocType _ExbegLoc = ExbegLoc;
			LocType _ExendLoc = ExendLoc;
			ProductCodeType _ExbegProductcode = ExbegProductcode;
			ProductCodeType _ExendProductcode = ExendProductcode;
			ItemType _ExbegItem = ExbegItem;
			ItemType _ExendItem = ExendItem;
			StringType _ExOptgoItemStat = ExOptgoItemStat;
			StringType _ExOptgoMatlType = ExOptgoMatlType;
			StringType _ExOptprPMTCode = ExOptprPMTCode;
			StringType _ExOptszStocked = ExOptszStocked;
			StringType _ExOptacAbcCode = ExOptacAbcCode;
			ListYesNoType _ExOptprPrZeroQty = ExOptprPrZeroQty;
			ListYesNoType _ShowDetail = ShowDetail;
			ListYesNoType _PrintCost = PrintCost;
			ListYesNoType _DisplayHeader = DisplayHeader;
			MessageLanguageType _PMessageLanguage = PMessageLanguage;
			SiteType _pSite = pSite;
			RowPointerType _ProcessID = ProcessID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;
				
				appDB.AddCommandParameter(cmd, "ExbegWhse", _ExbegWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExendWhse", _ExendWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExbegLoc", _ExbegLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExendLoc", _ExendLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExbegProductcode", _ExbegProductcode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExendProductcode", _ExendProductcode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExbegItem", _ExbegItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExendItem", _ExendItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptgoItemStat", _ExOptgoItemStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptgoMatlType", _ExOptgoMatlType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptprPMTCode", _ExOptprPMTCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptszStocked", _ExOptszStocked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptacAbcCode", _ExOptacAbcCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptprPrZeroQty", _ExOptprPrZeroQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowDetail", _ShowDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintCost", _PrintCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMessageLanguage", _PMessageLanguage, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessID, ParameterDirection.Input);

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
