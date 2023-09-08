//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ItemDetail.cs

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
using System.Linq;
using CSI.MG.MGCore;
using CSI.Adapters;
using CSI.Data.Utilities;

namespace CSI.Reporting
{
	public class Rpt_ItemDetail : IRpt_ItemDetail
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
		ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
		ICollectionInsertRequestFactory collectionInsertRequestFactory;
		ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
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
        readonly IGetCode iGetCode;
		ISQLValueComparerUtil sQLUtil;
		IUnionUtil iUnionUtil;
        readonly ILowCharacter lowCharacter;
        readonly IHighCharacter highCharacter;

        public Rpt_ItemDetail(IApplicationDB appDB,
			IBunchedLoadCollection bunchedLoadCollection,
			ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
			ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
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
			IGetCode iGetCode,
			ISQLValueComparerUtil sQLUtil,
			IUnionUtil iUnionUtil,
            ILowCharacter lowCharacter,
            IHighCharacter highCharacter)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.collectionLoadStatementRequestFactory = collectionLoadStatementRequestFactory;
			this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
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
			this.iGetCode = iGetCode;
			this.sQLUtil = sQLUtil;
			this.iUnionUtil = iUnionUtil;
            this.lowCharacter = lowCharacter;
            this.highCharacter = highCharacter;
		}

		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ItemDetailSp(string MaterialStatus = "AOS",
			string Source = "PMT",
			string MaterialType = "MTFO",
			string ABCCode = "ABC",
			int? Stocked = 0,
			int? NotStocked = 0,
			int? DisplayStockroomLocations = 0,
			int? DisplayVendorsfortheItems = 0,
			int? DisplayCustomersforItems = 0,
			int? PrintZeroQtyOnHandItems = 0,
			int? PrintCost = 0,
			int? PrintPrice = 0,
			int? DisplayHeader = 0,
			string WarehouseStarting = null,
			string WarehouseEnding = null,
			string ItemStarting = null,
			string ItemEnding = null,
			string ProductCodeStarting = null,
			string ProductCodeEnding = null,
			string ComplianceProgramId = null,
			string ComplianceStatus = null,
			string pSite = null)
		{
			ICollectionLoadResponse Data = null;

			StringType _ALTGEN_SpName = DBNull.Value;
			int? ALTGEN_Severity = null;
			Guid? RptSessionID = null;
			int? Severity = null;
			int? TStock = null;
			decimal? TMarkup = null;
			string TMethod = null;
			string TPmtCode = null;
			string TStat = null;
			string TypeDesc = null;
			QtyTotlType _TcQttWip = DBNull.Value;
			QtyTotlType _TcQttOnHand = DBNull.Value;
			QtyTotlType _TcQttOrdered = DBNull.Value;
			QtyUnitType _TcQttReorder = DBNull.Value;
			QtyTotlType _TcQttAllocCo = DBNull.Value;
			QtyTotlType _TcQttRsvdCo = DBNull.Value;
			QtyCumuType _TcQtcSoldYtd = DBNull.Value;
			QtyCumuType _TcQtcPurYtd = DBNull.Value;
			QtyTotlType _TcQttMrb = DBNull.Value;
			CostPrcType _TcCprPrice = DBNull.Value;
			ListYesNoType _TReprice = DBNull.Value;
			string SysCode_SymCode = null;
			CurrCodeType _ParmCurrCode = DBNull.Value;
			DateTime? Today = null;
			int? DSLUpdate = null;
			int? DVIUpdate = null;
			int? DCIUpdate = null;
			string CastLeadTime = null;
			string WhseWhse = null;
			string ItemMatlType = null;
			string ItemCostMethod = null;
			string ItemPMTCode = null;
			string ItemStat = null;
			string ItemItem = null;
			string ItemDescription = null;
			decimal? ItemQtyAllocjob = null;
			string ItemAbcCode = null;
			decimal? ItemUnitCost = null;
			string ItemProductCode = null;
			decimal? ItemQtyMfgYtd = null;
			decimal? ItemQtyUsedYtd = null;
			string ItemJob = null;
			decimal? ItemCurUCost = null;
			int? ItemPhantomFlag = null;
			string ItemUM = null;
			int? ItemLowLevel = null;
			int? ItemLeadTime = null;
			decimal? ItemLotSize = null;
			string ItemRevision = null;
			int? ItemStocked = null;
			decimal? ItemAvgUCost = null;
			int? ItemPlanFlag = null;
			decimal? ItemOrderMin = null;
			decimal? ItemOrderMult = null;
			int? ItemDaysSupply = null;
			int? ItemMpsFlag = null;
			string ItemPlanCode = null;
			int? ItemSerialTracked = null;
			decimal? ItemLstUCost = null;
			int? ItemBackflush = null;
			string ItemBflushLoc = null;
			string ItemDrawingNbr = null;
			int? ItemPaperTime = null;
			int? ItemDockTime = null;
			int? ItemAcceptReq = null;
			int? ItemLotTracked = null;
			DateTime? ItemChgDate = null;
			string ItemStatusChgUserCode = null;
			RowPointerType _ItemwhseRowPointer = DBNull.Value;
			Guid? ProdcodeRowPointer = null;
			decimal? ProdcodeMarkup = null;
			int? ItemlocRank = null;
			string LotLocLoc = null;
			string LotLocLot = null;
			decimal? LotLocQtyOnHand = null;
			decimal? LotLocQtyRsvd = null;
			string VendorItem = null;
			string VendNumber = null;
			string VendAddrName = null;
			string CustomerItem = null;
			string CustNumber = null;
			string CustAddrName = null;
			CurrCodeType _XDomCurrency = DBNull.Value;
			InputMaskType _CostPriceFormat = DBNull.Value;
			string CostPriceFormat = null;
			DecimalPlacesType _CostPricePlaces = DBNull.Value;
			string LowChar = null;
			string HighChar = null;
			int? Compliant = null;
			ListYesNoType _CostItemAtWhse = DBNull.Value;
			ICollectionLoadRequest whs_crsLoadRequestForCursor = null;
			ICollectionLoadResponse whs_crsLoadResponseForCursor = null;
			int whs_crs_CursorFetch_Status = -1;
			int whs_crs_CursorCounter = -1;

			if (existsChecker.Exists(
				tableName: "optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_ItemDetailSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
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
					whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_ItemDetailSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
				#endregion  LoadToRecord

				#region CRUD InsertByRecords
				foreach (var optional_module1Item in optional_module1LoadResponse.Items)
				{
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName("Rpt_ItemDetailSp" + stringUtil.Char(95) + optional_module1Item.GetValue<string>("u0")));
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
					this.appDB.Load(tv_ALTGEN1LoadRequest);
					#endregion  LoadToVariable

					var ALTGEN = AltExtGen_Rpt_ItemDetailSp(_ALTGEN_SpName,
						MaterialStatus,
						Source,
						MaterialType,
						ABCCode,
						Stocked,
						NotStocked,
						DisplayStockroomLocations,
						DisplayVendorsfortheItems,
						DisplayCustomersforItems,
						PrintZeroQtyOnHandItems,
						PrintCost,
						PrintPrice,
						DisplayHeader,
						WarehouseStarting,
						WarehouseEnding,
						ItemStarting,
						ItemEnding,
						ProductCodeStarting,
						ProductCodeEnding,
						ComplianceProgramId,
						ComplianceStatus,
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
						whereClause: collectionLoadRequestFactory.Clause("[SpName] = {0}", _ALTGEN_SpName),
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

			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Rpt_ItemDetailSp") != null)
			{
				var EXTGEN = AltExtGen_Rpt_ItemDetailSp("dbo.EXTGEN_Rpt_ItemDetailSp",
					MaterialStatus,
					Source,
					MaterialType,
					ABCCode,
					Stocked,
					NotStocked,
					DisplayStockroomLocations,
					DisplayVendorsfortheItems,
					DisplayCustomersforItems,
					PrintZeroQtyOnHandItems,
					PrintCost,
					PrintPrice,
					DisplayHeader,
					WarehouseStarting,
					WarehouseEnding,
					ItemStarting,
					ItemEnding,
					ProductCodeStarting,
					ProductCodeEnding,
					ComplianceProgramId,
					ComplianceStatus,
					pSite);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}

			this.transactionFactory.BeginTransaction("");
			this.sQLExpressionExecutor.Execute("SET XACT_ABORT ON ");
			if (sQLUtil.SQLEqual(this.iGetIsolationLevel.GetIsolationLevelFn("ItemDetailReport"), "COMMITTED") == true)
			{
				this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ COMMITTED");
			}
			else
			{
				this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
			}

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: InitSessionContextSp
			var InitSessionContext = this.iInitSessionContext.InitSessionContextSp(ContextName: "Rpt_ItemDetailSp"
				, SessionID: RptSessionID
				, Site: pSite);
			RptSessionID = InitSessionContext.SessionID;

			#endregion ExecuteMethodCall

			//this temp table is a table variable in old stored procedure version.
			this.sQLExpressionExecutor.Execute(@"DECLARE @ReportSET TABLE (
				    w_warehouse                 whsetype         ,
				    i_item                      itemtype         ,
				    i_description               DescriptionType  ,
				    i_qty_allocjob              QtyTotlType      ,
				    i_abc_code                  AbcCodeType      ,
				    i_unit_cost                 CostPrcType      ,
				    i_product_code              ProductCodeType  ,
				    i_qty_mfg_ytd               QtyCumuType      ,
				    i_qty_used_ytd              QtyCumuType      ,
				    i_job                       JobType          ,
				    i_cur_u_cost                CostPrcType      ,
				    i_phantom_flag              ListYesNoType    ,
				    i_u_m                       UMType           ,
				    i_low_level                 LowLevelType     ,
				    i_lead_time                 NVARCHAR (20)    ,
				    i_lot_size                  QtyPerType       ,
				    i_revision                  RevisionType     ,
				    i_stocked                   ListYesNoType    ,
				    i_ave_u_cost                CostPrcType      ,
				    i_plan_flag                 ListYesNoType    ,
				    i_order_min                 QtyUnitType      ,
				    i_order_mult                QtyUnitType      ,
				    i_days_supply               DaysSupplyType   ,
				    i_mps_flag                  ListYesNoType    ,
				    i_plan_code                 UserCodeType     ,
				    i_serial_tracked            ListYesNoType    ,
				    i_lst_u_cost                CostPrcType      ,
				    i_backflush                 ListYesNoType    ,
				    i_bflush_loc                LocType          ,
				    i_drawing_nbr               DrawingNbrType   ,
				    i_paper_time                LeadTimeType     ,
				    i_dock_time                 LeadTimeType     ,
				    i_accept_reg                ListYesNoType    ,
				    i_lot_tracked               ListYesNoType    ,
				    i_change_date               DateType         ,
				    i_status_chg_user_code      UserCodeType     ,
				    t_wip                       QtyTotlType      ,
				    t_ordered                   QtyTotlType      ,
				    t_reorder                   QtyUnitType      ,
				    t_on_hand                   QtyTotlType      ,
				    t_alloc_ord                 QtyTotlType      ,
				    t_rsvd_co                   QtyTotlType      ,
				    t_sold_ytd                  QtyCumuType      ,
				    t_pur_ytd                   QtyCumuType      ,
				    t_mrb                       QtyTotlType      ,
				    t_type_desc                 NVARCHAR (20)    ,
				    t_method                    NVARCHAR (20)    ,
				    t_pmt_code                  NVARCHAR (20)    ,
				    t_stat                      NVARCHAR (20)    ,
				    t_reprice                   ListYesNoType    ,
				    t_unit_price                CostPrcType      ,
				    p_markup                    MarkupType       ,
				    d_displaystockroomlocations FlagNyType       ,
				    il_Rank                     ItemlocRankType  ,
				    il_Loc                      LocType          ,
				    il_Lot                      LotType          ,
				    il_QtyOnHand                QtyUnitType      ,
				    il_QtyRsvd                  QtyUnitType      ,
				    d_displayvendorsfortheitems FlagNyType       ,
				    vi_Item                     ItemType         ,
				    vi_VendNum                  VendNumType      ,
				    vi_VendName                 NameType         ,
				    d_displaycustomersforitems  FlagNyType       ,
				    ci_Item                     ItemType         ,
				    ci_CustNumb                 VendNumType      ,
				    ci_CustName                 NameType         ,
				    CostPriceFormat             InputMaskType    ,
				    CostPricePlaces             DecimalPlacesType,
				    compliant                   CHAR (1)         );
				SELECT * into #tv_ReportSET from @ReportSET ");

			Today = convertToUtil.ToDateTime(this.iGetSiteDate.GetSiteDateFn(scalarFunction.Execute<DateTime>("GETDATE")));
			LowChar = convertToUtil.ToString(this.lowCharacter.LowCharacterFn());
			HighChar = convertToUtil.ToString(this.highCharacter.HighCharacterFn());
			WarehouseStarting = stringUtil.IsNull(WarehouseStarting, LowChar);
			WarehouseEnding = stringUtil.IsNull(WarehouseEnding, HighChar);
			ItemStarting = stringUtil.IsNull(ItemStarting, LowChar);
			ItemEnding = stringUtil.IsNull(ItemEnding, HighChar);
			ProductCodeStarting = stringUtil.IsNull(ProductCodeStarting, LowChar);
			ProductCodeEnding = stringUtil.IsNull(ProductCodeEnding, HighChar);
			TStock = 0;
			TMarkup = 0;
			_TcQttWip = 0;
			_TcQttOnHand = 0;
			_TcQttOrdered = 0;
			_TcQttReorder = 0;
			_TcQttAllocCo = 0;
			_TcQttRsvdCo = 0;
			_TcQtcSoldYtd = 0;
			_TcQtcPurYtd = 0;
			_TcQttMrb = 0;
			_TcCprPrice = 0;
			_TReprice = 0;
			Severity = 0;
			if (sQLUtil.SQLEqual(Stocked, 1) == true && sQLUtil.SQLEqual(NotStocked, 1) == true)
			{
				TStock = null;
			}
			if (sQLUtil.SQLEqual(Stocked, 0) == true && sQLUtil.SQLEqual(NotStocked, 1) == true)
			{
				TStock = 0;
			}
			if (sQLUtil.SQLEqual(Stocked, 1) == true && sQLUtil.SQLEqual(NotStocked, 0) == true)
			{
				TStock = 1;
			}

			#region CRUD LoadToVariable
			var currparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_XDomCurrency,"currparms.curr_code"},
					{_CostPricePlaces,"places_cp"},
					{_CostPriceFormat,"cst_prc_format"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "currparms",
				fromClause: collectionLoadRequestFactory.Clause(" LEFT OUTER JOIN currency ON currency.curr_code = currparms.curr_code"),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			this.appDB.Load(currparmsLoadRequest);
			#endregion  LoadToVariable

			#region CRUD LoadToVariable
			var currencyLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_CostPricePlaces,"places_cp"},
					{_CostPriceFormat,"cst_prc_format"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "currency",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("currency.curr_code = {0}", _XDomCurrency),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			this.appDB.Load(currencyLoadRequest);
			#endregion  LoadToVariable

			_CostPriceFormat = this.iFixMaskForCrystal.FixMaskForCrystalFn(CostPriceFormat, this.iGetWinRegDecGroup.GetWinRegDecGroupFn());

			#region CRUD LoadToVariable
			var currparms1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_ParmCurrCode,"currparms.curr_code"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "currparms",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("currparms.parm_key = 0"),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			this.appDB.Load(currparms1LoadRequest);
			#endregion  LoadToVariable

			#region CRUD LoadToVariable
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
			this.appDB.Load(dbo_invparmsLoadRequest);
			#endregion  LoadToVariable

			if (sQLUtil.SQLEqual(_CostItemAtWhse, 1) == true)
			{
				#region Cursor Statement

				#region CRUD LoadToRecord
				whs_crsLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"whse","whse.whse"},
						{"item","item.item"},
						{"matl_type","item.matl_type"},
						{"cost_method","item.cost_method"},
						{"p_m_t_code","item.p_m_t_code"},
						{"stat","item.stat"},
						{"description","item.description"},
						{"qty_allocjob","item.qty_allocjob"},
						{"abc_code","item.abc_code"},
						{"unit_cost","itemwhse.unit_cost"},
						{"product_code","item.product_code"},
						{"qty_mfg_ytd","item.qty_mfg_ytd"},
						{"qty_used_ytd","item.qty_used_ytd"},
						{"job","item.job"},
						{"cur_u_cost","itemwhse.cur_u_cost"},
						{"phantom_flag","item.phantom_flag"},
						{"u_m","item.u_m"},
						{"low_level","item.low_level"},
						{"lead_time","item.lead_time"},
						{"lot_size","item.lot_size"},
						{"revision","item.revision"},
						{"stocked","item.stocked"},
						{"avg_u_cost","itemwhse.avg_u_cost"},
						{"plan_flag","item.plan_flag"},
						{"order_min","item.order_min"},
						{"order_mult","item.order_mult"},
						{"days_supply","item.days_supply"},
						{"mps_flag","item.mps_flag"},
						{"plan_code","item.plan_code"},
						{"serial_tracked","item.serial_tracked"},
						{"lst_u_cost","itemwhse.lst_u_cost"},
						{"backflush","item.backflush"},
						{"bflush_loc","item.bflush_loc"},
						{"drawing_nbr","item.drawing_nbr"},
						{"paper_time","item.paper_time"},
						{"dock_time","item.dock_time"},
						{"accept_req","item.accept_req"},
						{"lot_tracked","item.lot_tracked"},
						{"chg_date","item.chg_date"},
						{"status_chg_user_code","item.status_chg_user_code"},
						{"RowPointer","prodcode.RowPointer"},
						{"markup","prodcode.markup"},
						{"Compliant",$"CAST (NULL AS INT)"},
						{"u0",$"ISNULL((SELECT compliant        FROM   item_compliance        WHERE  item_compliance.item = item.item               AND item_compliance.compliance_program_id = {variableUtil.GetValue<string>(ComplianceProgramId)}), 0)"},
					},
					loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "whse",
					fromClause: collectionLoadRequestFactory.Clause(@" inner join itemwhse on itemwhse.whse = whse.whse inner join item on item.item = itemwhse.item 
						and item.item between {3} and {5} 
						and item.product_code between {0} and {1} 
						and (({4} is not null) 
						     and (charindex(item.matl_type, {4}) <> 0)) 
						and (({7} is not null) 
						     and (charindex(item.p_m_t_code, {7}) > 0)) 
						and (({6} is not null) 
						     and (charindex(item.abc_code, {6}) <> 0)) 
						and (({2} is not null) 
						     and (charindex(item.stat, {2}) <> 0)) 
						and (({8} is null) 
						     or (item.stocked = {8})) left outer join prodcode on prodcode.product_code = item.product_code", ProductCodeStarting, ProductCodeEnding, MaterialStatus, ItemStarting, MaterialType, ItemEnding, ABCCode, Source, TStock),
					whereClause: collectionLoadRequestFactory.Clause("whse.whse BETWEEN ISNULL({0}, whse.whse) AND ISNULL({1}, whse.whse)", WarehouseStarting, WarehouseEnding),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				#endregion  LoadToRecord

				#endregion Cursor Statement
			}
			else
			{
				#region Cursor Statement

				#region CRUD LoadToRecord
				whs_crsLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"whse","whse.whse"},
						{"item","item.item"},
						{"matl_type","item.matl_type"},
						{"cost_method","item.cost_method"},
						{"p_m_t_code","item.p_m_t_code"},
						{"stat","item.stat"},
						{"description","item.description"},
						{"qty_allocjob","item.qty_allocjob"},
						{"abc_code","item.abc_code"},
						{"unit_cost","item.unit_cost"},
						{"product_code","item.product_code"},
						{"qty_mfg_ytd","item.qty_mfg_ytd"},
						{"qty_used_ytd","item.qty_used_ytd"},
						{"job","item.job"},
						{"cur_u_cost","item.cur_u_cost"},
						{"phantom_flag","item.phantom_flag"},
						{"u_m","item.u_m"},
						{"low_level","item.low_level"},
						{"lead_time","item.lead_time"},
						{"lot_size","item.lot_size"},
						{"revision","item.revision"},
						{"stocked","item.stocked"},
						{"avg_u_cost","item.avg_u_cost"},
						{"plan_flag","item.plan_flag"},
						{"order_min","item.order_min"},
						{"order_mult","item.order_mult"},
						{"days_supply","item.days_supply"},
						{"mps_flag","item.mps_flag"},
						{"plan_code","item.plan_code"},
						{"serial_tracked","item.serial_tracked"},
						{"lst_u_cost","item.lst_u_cost"},
						{"backflush","item.backflush"},
						{"bflush_loc","item.bflush_loc"},
						{"drawing_nbr","item.drawing_nbr"},
						{"paper_time","item.paper_time"},
						{"dock_time","item.dock_time"},
						{"accept_req","item.accept_req"},
						{"lot_tracked","item.lot_tracked"},
						{"chg_date","item.chg_date"},
						{"status_chg_user_code","item.status_chg_user_code"},
						{"RowPointer","prodcode.RowPointer"},
						{"markup","prodcode.markup"},
						{"Compliant",$"CAST (NULL AS INT)"},
						{"u0",$"ISNULL((SELECT compliant        FROM   item_compliance        WHERE  item_compliance.item = item.item               AND item_compliance.compliance_program_id = {variableUtil.GetValue<string>(ComplianceProgramId)}), 0)"},
					},
					loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "whse",
					fromClause: collectionLoadRequestFactory.Clause(@" inner join itemwhse on itemwhse.whse = whse.whse inner join item on item.item = itemwhse.item 
						and item.item between {3} and {5} 
						and item.product_code between {0} and {1} 
						and (({4} is not null) 
						     and (charindex(item.matl_type, {4}) <> 0)) 
						and (({7} is not null) 
						     and (charindex(item.p_m_t_code, {7}) > 0)) 
						and (({6} is not null) 
						     and (charindex(item.abc_code, {6}) <> 0)) 
						and (({2} is not null) 
						     and (charindex(item.stat, {2}) <> 0)) 
						and (({8} is null) 
						     or (item.stocked = {8})) left outer join prodcode on prodcode.product_code = item.product_code", ProductCodeStarting, ProductCodeEnding, MaterialStatus, ItemStarting, MaterialType, ItemEnding, ABCCode, Source, TStock),
					whereClause: collectionLoadRequestFactory.Clause("whse.whse BETWEEN ISNULL({0}, whse.whse) AND ISNULL({1}, whse.whse)", WarehouseStarting, WarehouseEnding),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				#endregion  LoadToRecord

				#endregion Cursor Statement
			}
			whs_crsLoadResponseForCursor = this.appDB.Load(whs_crsLoadRequestForCursor);

			foreach (var whse1Item in whs_crsLoadResponseForCursor.Items)
			{
				whse1Item.SetValue<int?>("Compliant", whse1Item.GetValue<int?>("u0"));
			};

			whs_crs_CursorFetch_Status = whs_crsLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
			whs_crs_CursorCounter = -1;

			while (sQLUtil.SQLBool(sQLUtil.SQLEqual(Severity, 0)))
			{
				whs_crs_CursorCounter++;
				if (whs_crsLoadResponseForCursor.Items.Count > whs_crs_CursorCounter)
				{
					WhseWhse = whs_crsLoadResponseForCursor.Items[whs_crs_CursorCounter].GetValue<string>(0);
					ItemItem = whs_crsLoadResponseForCursor.Items[whs_crs_CursorCounter].GetValue<string>(1);
					ItemMatlType = whs_crsLoadResponseForCursor.Items[whs_crs_CursorCounter].GetValue<string>(2);
					ItemCostMethod = whs_crsLoadResponseForCursor.Items[whs_crs_CursorCounter].GetValue<string>(3);
					ItemPMTCode = whs_crsLoadResponseForCursor.Items[whs_crs_CursorCounter].GetValue<string>(4);
					ItemStat = whs_crsLoadResponseForCursor.Items[whs_crs_CursorCounter].GetValue<string>(5);
					ItemDescription = whs_crsLoadResponseForCursor.Items[whs_crs_CursorCounter].GetValue<string>(6);
					ItemQtyAllocjob = whs_crsLoadResponseForCursor.Items[whs_crs_CursorCounter].GetValue<decimal?>(7);
					ItemAbcCode = whs_crsLoadResponseForCursor.Items[whs_crs_CursorCounter].GetValue<string>(8);
					ItemUnitCost = whs_crsLoadResponseForCursor.Items[whs_crs_CursorCounter].GetValue<decimal?>(9);
					ItemProductCode = whs_crsLoadResponseForCursor.Items[whs_crs_CursorCounter].GetValue<string>(10);
					ItemQtyMfgYtd = whs_crsLoadResponseForCursor.Items[whs_crs_CursorCounter].GetValue<decimal?>(11);
					ItemQtyUsedYtd = whs_crsLoadResponseForCursor.Items[whs_crs_CursorCounter].GetValue<decimal?>(12);
					ItemJob = whs_crsLoadResponseForCursor.Items[whs_crs_CursorCounter].GetValue<string>(13);
					ItemCurUCost = whs_crsLoadResponseForCursor.Items[whs_crs_CursorCounter].GetValue<decimal?>(14);
					ItemPhantomFlag = whs_crsLoadResponseForCursor.Items[whs_crs_CursorCounter].GetValue<int?>(15);
					ItemUM = whs_crsLoadResponseForCursor.Items[whs_crs_CursorCounter].GetValue<string>(16);
					ItemLowLevel = whs_crsLoadResponseForCursor.Items[whs_crs_CursorCounter].GetValue<int?>(17);
					ItemLeadTime = whs_crsLoadResponseForCursor.Items[whs_crs_CursorCounter].GetValue<int?>(18);
					ItemLotSize = whs_crsLoadResponseForCursor.Items[whs_crs_CursorCounter].GetValue<decimal?>(19);
					ItemRevision = whs_crsLoadResponseForCursor.Items[whs_crs_CursorCounter].GetValue<string>(20);
					ItemStocked = whs_crsLoadResponseForCursor.Items[whs_crs_CursorCounter].GetValue<int?>(21);
					ItemAvgUCost = whs_crsLoadResponseForCursor.Items[whs_crs_CursorCounter].GetValue<decimal?>(22);
					ItemPlanFlag = whs_crsLoadResponseForCursor.Items[whs_crs_CursorCounter].GetValue<int?>(23);
					ItemOrderMin = whs_crsLoadResponseForCursor.Items[whs_crs_CursorCounter].GetValue<decimal?>(24);
					ItemOrderMult = whs_crsLoadResponseForCursor.Items[whs_crs_CursorCounter].GetValue<decimal?>(25);
					ItemDaysSupply = whs_crsLoadResponseForCursor.Items[whs_crs_CursorCounter].GetValue<int?>(26);
					ItemMpsFlag = whs_crsLoadResponseForCursor.Items[whs_crs_CursorCounter].GetValue<int?>(27);
					ItemPlanCode = whs_crsLoadResponseForCursor.Items[whs_crs_CursorCounter].GetValue<string>(28);
					ItemSerialTracked = whs_crsLoadResponseForCursor.Items[whs_crs_CursorCounter].GetValue<int?>(29);
					ItemLstUCost = whs_crsLoadResponseForCursor.Items[whs_crs_CursorCounter].GetValue<decimal?>(30);
					ItemBackflush = whs_crsLoadResponseForCursor.Items[whs_crs_CursorCounter].GetValue<int?>(31);
					ItemBflushLoc = whs_crsLoadResponseForCursor.Items[whs_crs_CursorCounter].GetValue<string>(32);
					ItemDrawingNbr = whs_crsLoadResponseForCursor.Items[whs_crs_CursorCounter].GetValue<string>(33);
					ItemPaperTime = whs_crsLoadResponseForCursor.Items[whs_crs_CursorCounter].GetValue<int?>(34);
					ItemDockTime = whs_crsLoadResponseForCursor.Items[whs_crs_CursorCounter].GetValue<int?>(35);
					ItemAcceptReq = whs_crsLoadResponseForCursor.Items[whs_crs_CursorCounter].GetValue<int?>(36);
					ItemLotTracked = whs_crsLoadResponseForCursor.Items[whs_crs_CursorCounter].GetValue<int?>(37);
					ItemChgDate = whs_crsLoadResponseForCursor.Items[whs_crs_CursorCounter].GetValue<DateTime?>(38);
					ItemStatusChgUserCode = whs_crsLoadResponseForCursor.Items[whs_crs_CursorCounter].GetValue<string>(39);
					ProdcodeRowPointer = whs_crsLoadResponseForCursor.Items[whs_crs_CursorCounter].GetValue<Guid?>(40);
					ProdcodeMarkup = whs_crsLoadResponseForCursor.Items[whs_crs_CursorCounter].GetValue<decimal?>(41);
					Compliant = whs_crsLoadResponseForCursor.Items[whs_crs_CursorCounter].GetValue<int?>(42);
				}
				whs_crs_CursorFetch_Status = (whs_crs_CursorCounter == whs_crsLoadResponseForCursor.Items.Count ? -1 : 0);

				if (sQLUtil.SQLEqual(whs_crs_CursorFetch_Status, -1) == true)
				{
					break;
				}
				if (ComplianceProgramId != null)
				{
					if (sQLUtil.SQLEqual(ComplianceStatus, "C") == true && sQLUtil.SQLEqual(Compliant, 0) == true)
					{
						continue;
					}
					if (sQLUtil.SQLEqual(ComplianceStatus, "N") == true && sQLUtil.SQLEqual(Compliant, 1) == true)
					{
						continue;
					}
					
				}
				_TcQttWip = 0;
				_TcQttOrdered = 0;
				_TcQttReorder = 0;
				_TcQttOnHand = 0;
				_TcQttAllocCo = 0;
				_TcQttRsvdCo = 0;
				_TcQtcSoldYtd = 0;
				_TcQtcPurYtd = 0;
				_TcQttMrb = 0;

				#region CRUD LoadToVariable
				var itemwhseLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
					{
						{_TcQttWip,"ISNULL(SUM(itemwhse.qty_wip), 0)"},
						{_TcQttOrdered,"ISNULL(SUM(itemwhse.qty_ordered), 0)"},
						{_TcQttReorder,"ISNULL(SUM(itemwhse.qty_reorder), 0)"},
						{_TcQttOnHand,"ISNULL(SUM(itemwhse.qty_on_hand), 0)"},
						{_TcQttAllocCo,"ISNULL(SUM(itemwhse.qty_alloc_co), 0)"},
						{_TcQttRsvdCo,"ISNULL(SUM(itemwhse.qty_rsvd_co), 0)"},
						{_TcQtcSoldYtd,"ISNULL(SUM(itemwhse.qty_sold_ytd), 0)"},
						{_TcQtcPurYtd,"ISNULL(SUM(itemwhse.qty_pur_ytd), 0)"},
						{_TcQttMrb,"ISNULL(SUM(itemwhse.qty_mrb), 0)"},
					},
					loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "itemwhse",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause("itemwhse.whse = {0} AND itemwhse.item = {1}", WhseWhse, ItemItem),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				this.appDB.Load(itemwhseLoadRequest);
				#endregion  LoadToVariable

				#region CRUD LoadToVariable
				var itemwhse1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
					{
						{_ItemwhseRowPointer,"itemwhse.RowPointer"},
					},
					loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "itemwhse",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause("itemwhse.whse = {0} AND itemwhse.item = {1}", WhseWhse, ItemItem),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				this.appDB.Load(itemwhse1LoadRequest);
				#endregion  LoadToVariable

				if (sQLUtil.SQLBool(!_ItemwhseRowPointer.IsNull))
				{
					if (sQLUtil.SQLBool(sQLUtil.SQLNot((sQLUtil.SQLAnd(sQLUtil.SQLEqual(_TcQttOnHand, 0), sQLUtil.SQLEqual(PrintZeroQtyOnHandItems, 0))))))
					{
						if (ProdcodeRowPointer != null)
						{
							TMarkup = ProdcodeMarkup;
						}
						TypeDesc = ItemMatlType;
						SysCode_SymCode = ItemMatlType;

						#region CRUD ExecuteMethodCall

						//Please Generate the bounce for this stored procedure: GetCodeSp
						var GetCode = this.iGetCode.GetCodeSp(PClass: "item.matl_type"
							, PCode: SysCode_SymCode
							, PDesc: TypeDesc);
						TypeDesc = GetCode.PDesc;

						#endregion ExecuteMethodCall

						TMethod = ItemCostMethod;
						SysCode_SymCode = ItemCostMethod;

						#region CRUD ExecuteMethodCall

						//Please Generate the bounce for this stored procedure: GetCodeSp
						var GetCode1 = this.iGetCode.GetCodeSp(PClass: "item.cost_method"
							, PCode: SysCode_SymCode
							, PDesc: TMethod);
						TMethod = GetCode1.PDesc;

						#endregion ExecuteMethodCall

						TPmtCode = ItemPMTCode;
						SysCode_SymCode = ItemPMTCode;

						#region CRUD ExecuteMethodCall

						//Please Generate the bounce for this stored procedure: GetCodeSp
						var GetCode2 = this.iGetCode.GetCodeSp(PClass: "item.p_m_t_code"
							, PCode: SysCode_SymCode
							, PDesc: TPmtCode);
						TPmtCode = GetCode2.PDesc;

						#endregion ExecuteMethodCall

						TStat = ItemStat;
						SysCode_SymCode = ItemStat;

						#region CRUD ExecuteMethodCall

						//Please Generate the bounce for this stored procedure: GetCodeSp
						var GetCode3 = this.iGetCode.GetCodeSp(PClass: "item.stat"
							, PCode: SysCode_SymCode
							, PDesc: TStat);
						TStat = GetCode3.PDesc;

						#endregion ExecuteMethodCall

						_TReprice = 0;
						_TcCprPrice = 0;

						#region CRUD LoadToVariable
						var itempriceLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
							{
								{_TReprice,"itemprice.reprice"},
								{_TcCprPrice,"itemprice.unit_price1"},
							},
							loadForChange: false, 
                            lockingType: LockingType.None,
                            maximumRows: 1,
							tableName: "itemprice",
							fromClause: collectionLoadRequestFactory.Clause(""),
						whereClause: collectionLoadRequestFactory.Clause("itemprice.item = {1} AND itemprice.curr_code = {0} AND DATEDIFF(DAY, itemprice.effect_date, {2}) >= 0", _ParmCurrCode, ItemItem, Today),
							orderByClause: collectionLoadRequestFactory.Clause(" itemprice.effect_date DESC"));
						
						this.appDB.Load(itempriceLoadRequest);
						#endregion  LoadToVariable

						
						CastLeadTime = Convert.ToString(ItemLeadTime) + " Days";
						VendorItem = null;
						VendNumber = null;
						VendAddrName = null;
						CustomerItem = null;
						CustNumber = null;
						CustAddrName = null;
						ItemlocRank = null;
						LotLocLoc = null;
						LotLocLot = null;
						LotLocQtyOnHand = null;
						LotLocQtyRsvd = null;
						if (sQLUtil.SQLEqual(PrintCost, 0) == true)
						{
							ItemLstUCost = 0;
							ItemAvgUCost = 0;
							ItemCurUCost = 0;
							ItemUnitCost = 0;
							TMarkup = 0;
						}
						if (sQLUtil.SQLEqual(PrintPrice, 0) == true)
						{
							_TcCprPrice = 0;
						}

						#region CRUD LoadResponseWithoutTable
						var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
							{
								{ "w_warehouse", variableUtil.GetValue<string>(WhseWhse,true)},
								{ "i_item", variableUtil.GetValue<string>(ItemItem,true)},
								{ "i_description", variableUtil.GetValue<string>(ItemDescription,true)},
								{ "i_qty_allocjob", variableUtil.GetValue<decimal?>(ItemQtyAllocjob,true)},
								{ "i_abc_code", variableUtil.GetValue<string>(ItemAbcCode,true)},
								{ "i_unit_cost", variableUtil.GetValue<decimal?>(ItemUnitCost,true)},
								{ "i_product_code", variableUtil.GetValue<string>(ItemProductCode,true)},
								{ "i_qty_mfg_ytd", variableUtil.GetValue<decimal?>(ItemQtyMfgYtd,true)},
								{ "i_qty_used_ytd", variableUtil.GetValue<decimal?>(ItemQtyUsedYtd,true)},
								{ "i_job", variableUtil.GetValue<string>(ItemJob,true)},
								{ "i_cur_u_cost", variableUtil.GetValue<decimal?>(ItemCurUCost,true)},
								{ "i_phantom_flag", variableUtil.GetValue<int?>(ItemPhantomFlag,true)},
								{ "i_u_m", variableUtil.GetValue<string>(ItemUM,true)},
								{ "i_low_level", variableUtil.GetValue<int?>(ItemLowLevel,true)},
								{ "i_lead_time", variableUtil.GetValue<string>(CastLeadTime,true)},
								{ "i_lot_size", variableUtil.GetValue<decimal?>(ItemLotSize,true)},
								{ "i_revision", variableUtil.GetValue<string>(ItemRevision,true)},
								{ "i_stocked", variableUtil.GetValue<int?>(ItemStocked,true)},
								{ "i_ave_u_cost", variableUtil.GetValue<decimal?>(ItemAvgUCost,true)},
								{ "i_plan_flag", variableUtil.GetValue<int?>(ItemPlanFlag,true)},
								{ "i_order_min", variableUtil.GetValue<decimal?>(ItemOrderMin,true)},
								{ "i_order_mult", variableUtil.GetValue<decimal?>(ItemOrderMult,true)},
								{ "i_days_supply", variableUtil.GetValue<int?>(ItemDaysSupply,true)},
								{ "i_mps_flag", variableUtil.GetValue<int?>(ItemMpsFlag,true)},
								{ "i_plan_code", variableUtil.GetValue<string>(ItemPlanCode,true)},
								{ "i_serial_tracked", variableUtil.GetValue<int?>(ItemSerialTracked,true)},
								{ "i_lst_u_cost", variableUtil.GetValue<decimal?>(ItemLstUCost,true)},
								{ "i_backflush", variableUtil.GetValue<int?>(ItemBackflush,true)},
								{ "i_bflush_loc", variableUtil.GetValue<string>(ItemBflushLoc,true)},
								{ "i_drawing_nbr", variableUtil.GetValue<string>(ItemDrawingNbr,true)},
								{ "i_paper_time", variableUtil.GetValue<int?>(ItemPaperTime,true)},
								{ "i_dock_time", variableUtil.GetValue<int?>(ItemDockTime,true)},
								{ "i_accept_reg", variableUtil.GetValue<int?>(ItemAcceptReq,true)},
								{ "i_lot_tracked", variableUtil.GetValue<int?>(ItemLotTracked,true)},
								{ "i_change_date", variableUtil.GetValue<DateTime?>(ItemChgDate,true)},
								{ "i_status_chg_user_code", variableUtil.GetValue<string>(ItemStatusChgUserCode,true)},
								{ "t_wip", variableUtil.GetValue<QtyTotlType>(_TcQttWip,true)},
								{ "t_ordered", variableUtil.GetValue<QtyTotlType>(_TcQttOrdered,true)},
								{ "t_reorder", variableUtil.GetValue<QtyUnitType>(_TcQttReorder,true)},
								{ "t_on_hand", variableUtil.GetValue<QtyTotlType>(_TcQttOnHand,true)},
								{ "t_alloc_ord", variableUtil.GetValue<QtyTotlType>(_TcQttAllocCo,true)},
								{ "t_rsvd_co", variableUtil.GetValue<QtyTotlType>(_TcQttRsvdCo,true)},
								{ "t_sold_ytd", variableUtil.GetValue<QtyCumuType>(_TcQtcSoldYtd,true)},
								{ "t_pur_ytd", variableUtil.GetValue<QtyCumuType>(_TcQtcPurYtd,true)},
								{ "t_mrb", variableUtil.GetValue<QtyTotlType>(_TcQttMrb,true)},
								{ "t_type_desc", variableUtil.GetValue<string>(TypeDesc,true)},
								{ "t_method", variableUtil.GetValue<string>(TMethod,true)},
								{ "t_pmt_code", variableUtil.GetValue<string>(TPmtCode,true)},
								{ "t_stat", variableUtil.GetValue<string>(TStat,true)},
								{ "t_reprice", variableUtil.GetValue<ListYesNoType>(_TReprice,true)},
								{ "t_unit_price", variableUtil.GetValue<CostPrcType>(_TcCprPrice,true)},
								{ "p_markup", variableUtil.GetValue<decimal?>(TMarkup,true)},
								{ "d_displaystockroomlocations", variableUtil.GetValue<int?>(DSLUpdate,true)},
								{ "il_Rank", variableUtil.GetValue<int?>(ItemlocRank,true)},
								{ "il_Loc", variableUtil.GetValue<string>(LotLocLoc,true)},
								{ "il_Lot", variableUtil.GetValue<string>(LotLocLot,true)},
								{ "il_QtyOnHand", variableUtil.GetValue<decimal?>(LotLocQtyOnHand,true)},
								{ "il_QtyRsvd", variableUtil.GetValue<decimal?>(LotLocQtyRsvd,true)},
								{ "d_displayvendorsfortheitems", variableUtil.GetValue<int?>(DVIUpdate,true)},
								{ "vi_Item", variableUtil.GetValue<string>(VendorItem,true)},
								{ "vi_VendNum", variableUtil.GetValue<string>(VendNumber,true)},
								{ "vi_VendName", variableUtil.GetValue<string>(VendAddrName,true)},
								{ "d_displaycustomersforitems", variableUtil.GetValue<int?>(DCIUpdate,true)},
								{ "ci_Item", variableUtil.GetValue<string>(CustomerItem,true)},
								{ "ci_CustNumb", variableUtil.GetValue<string>(CustNumber,true)},
								{ "ci_CustName", variableUtil.GetValue<string>(CustAddrName,true)},
								{ "CostPriceFormat", variableUtil.GetValue<InputMaskType>(_CostPriceFormat,true)},
								{ "CostPricePlaces", variableUtil.GetValue<DecimalPlacesType>(_CostPricePlaces,true)},
								{ "compliant", variableUtil.GetValue<int?>(Compliant,true)},
							});

						var nonTableLoadResponse = this.appDB.Load(nonTableLoadRequest);
						Data = nonTableLoadResponse;
						#endregion CRUD LoadResponseWithoutTable

						iUnionUtil.Add(nonTableLoadResponse);
					}
				}
			}

			#region CRUD InsertByRecords

			var insertTableLoadResponse = iUnionUtil.Process();
			var nonTableInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ReportSET",
				items: insertTableLoadResponse.Items);

			this.appDB.Insert(nonTableInsertRequest);
			#endregion InsertByRecords

			//Deallocate Cursor whs_crs

			#region CRUD LoadToRecord
			var tv_ReportSETLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"w_warehouse","#tv_ReportSET.w_warehouse"},
					{"i_item","#tv_ReportSET.i_item"},
					{"i_description","#tv_ReportSET.i_description"},
					{"i_qty_allocjob","#tv_ReportSET.i_qty_allocjob"},
					{"i_abc_code","#tv_ReportSET.i_abc_code"},
					{"i_unit_cost","#tv_ReportSET.i_unit_cost"},
					{"i_product_code","#tv_ReportSET.i_product_code"},
					{"i_qty_mfg_ytd","#tv_ReportSET.i_qty_mfg_ytd"},
					{"i_qty_used_ytd","#tv_ReportSET.i_qty_used_ytd"},
					{"i_job","#tv_ReportSET.i_job"},
					{"i_cur_u_cost","#tv_ReportSET.i_cur_u_cost"},
					{"i_phantom_flag","#tv_ReportSET.i_phantom_flag"},
					{"i_u_m","#tv_ReportSET.i_u_m"},
					{"i_low_level","#tv_ReportSET.i_low_level"},
					{"i_lead_time","#tv_ReportSET.i_lead_time"},
					{"i_lot_size","#tv_ReportSET.i_lot_size"},
					{"i_revision","#tv_ReportSET.i_revision"},
					{"i_stocked","#tv_ReportSET.i_stocked"},
					{"i_ave_u_cost","#tv_ReportSET.i_ave_u_cost"},
					{"i_plan_flag","#tv_ReportSET.i_plan_flag"},
					{"i_order_min","#tv_ReportSET.i_order_min"},
					{"i_order_mult","#tv_ReportSET.i_order_mult"},
					{"i_days_supply","#tv_ReportSET.i_days_supply"},
					{"i_mps_flag","#tv_ReportSET.i_mps_flag"},
					{"i_plan_code","#tv_ReportSET.i_plan_code"},
					{"i_serial_tracked","#tv_ReportSET.i_serial_tracked"},
					{"i_lst_u_cost","#tv_ReportSET.i_lst_u_cost"},
					{"i_backflush","#tv_ReportSET.i_backflush"},
					{"i_bflush_loc","#tv_ReportSET.i_bflush_loc"},
					{"i_drawing_nbr","#tv_ReportSET.i_drawing_nbr"},
					{"i_paper_time","#tv_ReportSET.i_paper_time"},
					{"i_dock_time","#tv_ReportSET.i_dock_time"},
					{"i_accept_reg","#tv_ReportSET.i_accept_reg"},
					{"i_lot_tracked","#tv_ReportSET.i_lot_tracked"},
					{"i_change_date","#tv_ReportSET.i_change_date"},
					{"i_status_chg_user_code","#tv_ReportSET.i_status_chg_user_code"},
					{"t_wip","#tv_ReportSET.t_wip"},
					{"t_ordered","#tv_ReportSET.t_ordered"},
					{"t_reorder","#tv_ReportSET.t_reorder"},
					{"t_on_hand","#tv_ReportSET.t_on_hand"},
					{"t_alloc_ord","#tv_ReportSET.t_alloc_ord"},
					{"t_rsvd_co","#tv_ReportSET.t_rsvd_co"},
					{"t_sold_ytd","#tv_ReportSET.t_sold_ytd"},
					{"t_pur_ytd","#tv_ReportSET.t_pur_ytd"},
					{"t_mrb","#tv_ReportSET.t_mrb"},
					{"t_type_desc","#tv_ReportSET.t_type_desc"},
					{"t_method","#tv_ReportSET.t_method"},
					{"t_pmt_code","#tv_ReportSET.t_pmt_code"},
					{"t_stat","#tv_ReportSET.t_stat"},
					{"t_reprice","#tv_ReportSET.t_reprice"},
					{"t_unit_price","#tv_ReportSET.t_unit_price"},
					{"p_markup","#tv_ReportSET.p_markup"},
					{"d_displaystockroomlocations","#tv_ReportSET.d_displaystockroomlocations"},
					{"il_Rank","#tv_ReportSET.il_Rank"},
					{"il_Loc","#tv_ReportSET.il_Loc"},
					{"il_Lot","#tv_ReportSET.il_Lot"},
					{"il_QtyOnHand","#tv_ReportSET.il_QtyOnHand"},
					{"il_QtyRsvd","#tv_ReportSET.il_QtyRsvd"},
					{"d_displayvendorsfortheitems","#tv_ReportSET.d_displayvendorsfortheitems"},
					{"vi_Item","#tv_ReportSET.vi_Item"},
					{"vi_VendNum","#tv_ReportSET.vi_VendNum"},
					{"vi_VendName","#tv_ReportSET.vi_VendName"},
					{"d_displaycustomersforitems","#tv_ReportSET.d_displaycustomersforitems"},
					{"ci_Item","#tv_ReportSET.ci_Item"},
					{"ci_CustNumb","#tv_ReportSET.ci_CustNumb"},
					{"ci_CustName","#tv_ReportSET.ci_CustName"},
					{"CostPriceFormat","#tv_ReportSET.CostPriceFormat"},
					{"CostPricePlaces","#tv_ReportSET.CostPricePlaces"},
					{"compliant","#tv_ReportSET.compliant"},
					{"col0","CAST (NULL AS NVARCHAR)"},
					{"col1","CAST (NULL AS NVARCHAR)"},
					{"col2","CAST (NULL AS NVARCHAR)"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "#tv_ReportSET",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(" w_warehouse ASC, i_item ASC"));
			var tv_ReportSETLoadResponse = this.appDB.Load(tv_ReportSETLoadRequest);
			#endregion  LoadToRecord

			foreach (var tv_ReportSETItem in tv_ReportSETLoadResponse.Items)
			{
				tv_ReportSETItem.SetValue<string>("w_warehouse", tv_ReportSETItem.GetValue<string>("w_warehouse"));
				tv_ReportSETItem.SetValue<string>("i_item", tv_ReportSETItem.GetValue<string>("i_item"));
				tv_ReportSETItem.SetValue<string>("i_description", tv_ReportSETItem.GetValue<string>("i_description"));
				tv_ReportSETItem.SetValue<decimal?>("i_qty_allocjob", tv_ReportSETItem.GetValue<decimal?>("i_qty_allocjob"));
				tv_ReportSETItem.SetValue<string>("i_abc_code", tv_ReportSETItem.GetValue<string>("i_abc_code"));
				tv_ReportSETItem.SetValue<decimal?>("i_unit_cost", tv_ReportSETItem.GetValue<decimal?>("i_unit_cost"));
				tv_ReportSETItem.SetValue<string>("i_product_code", tv_ReportSETItem.GetValue<string>("i_product_code"));
				tv_ReportSETItem.SetValue<decimal?>("i_qty_mfg_ytd", tv_ReportSETItem.GetValue<decimal?>("i_qty_mfg_ytd"));
				tv_ReportSETItem.SetValue<decimal?>("i_qty_used_ytd", tv_ReportSETItem.GetValue<decimal?>("i_qty_used_ytd"));
				tv_ReportSETItem.SetValue<string>("i_job", tv_ReportSETItem.GetValue<string>("i_job"));
				tv_ReportSETItem.SetValue<decimal?>("i_cur_u_cost", tv_ReportSETItem.GetValue<decimal?>("i_cur_u_cost"));
				tv_ReportSETItem.SetValue<int?>("i_phantom_flag", tv_ReportSETItem.GetValue<int?>("i_phantom_flag"));
				tv_ReportSETItem.SetValue<string>("i_u_m", tv_ReportSETItem.GetValue<string>("i_u_m"));
				tv_ReportSETItem.SetValue<int?>("i_low_level", tv_ReportSETItem.GetValue<int?>("i_low_level"));
				tv_ReportSETItem.SetValue<string>("i_lead_time", tv_ReportSETItem.GetValue<string>("i_lead_time"));
				tv_ReportSETItem.SetValue<decimal?>("i_lot_size", tv_ReportSETItem.GetValue<decimal?>("i_lot_size"));
				tv_ReportSETItem.SetValue<string>("i_revision", tv_ReportSETItem.GetValue<string>("i_revision"));
				tv_ReportSETItem.SetValue<int?>("i_stocked", tv_ReportSETItem.GetValue<int?>("i_stocked"));
				tv_ReportSETItem.SetValue<decimal?>("i_ave_u_cost", tv_ReportSETItem.GetValue<decimal?>("i_ave_u_cost"));
				tv_ReportSETItem.SetValue<int?>("i_plan_flag", tv_ReportSETItem.GetValue<int?>("i_plan_flag"));
				tv_ReportSETItem.SetValue<decimal?>("i_order_min", tv_ReportSETItem.GetValue<decimal?>("i_order_min"));
				tv_ReportSETItem.SetValue<decimal?>("i_order_mult", tv_ReportSETItem.GetValue<decimal?>("i_order_mult"));
				tv_ReportSETItem.SetValue<int?>("i_days_supply", tv_ReportSETItem.GetValue<int?>("i_days_supply"));
				tv_ReportSETItem.SetValue<int?>("i_mps_flag", tv_ReportSETItem.GetValue<int?>("i_mps_flag"));
				tv_ReportSETItem.SetValue<string>("i_plan_code", tv_ReportSETItem.GetValue<string>("i_plan_code"));
				tv_ReportSETItem.SetValue<int?>("i_serial_tracked", tv_ReportSETItem.GetValue<int?>("i_serial_tracked"));
				tv_ReportSETItem.SetValue<decimal?>("i_lst_u_cost", tv_ReportSETItem.GetValue<decimal?>("i_lst_u_cost"));
				tv_ReportSETItem.SetValue<int?>("i_backflush", tv_ReportSETItem.GetValue<int?>("i_backflush"));
				tv_ReportSETItem.SetValue<string>("i_bflush_loc", tv_ReportSETItem.GetValue<string>("i_bflush_loc"));
				tv_ReportSETItem.SetValue<string>("i_drawing_nbr", tv_ReportSETItem.GetValue<string>("i_drawing_nbr"));
				tv_ReportSETItem.SetValue<int?>("i_paper_time", tv_ReportSETItem.GetValue<int?>("i_paper_time"));
				tv_ReportSETItem.SetValue<int?>("i_dock_time", tv_ReportSETItem.GetValue<int?>("i_dock_time"));
				tv_ReportSETItem.SetValue<int?>("i_accept_reg", tv_ReportSETItem.GetValue<int?>("i_accept_reg"));
				tv_ReportSETItem.SetValue<int?>("i_lot_tracked", tv_ReportSETItem.GetValue<int?>("i_lot_tracked"));
				tv_ReportSETItem.SetValue<DateTime?>("i_change_date", tv_ReportSETItem.GetValue<DateTime?>("i_change_date"));
				tv_ReportSETItem.SetValue<string>("i_status_chg_user_code", tv_ReportSETItem.GetValue<string>("i_status_chg_user_code"));
				tv_ReportSETItem.SetValue<decimal?>("t_wip", tv_ReportSETItem.GetValue<decimal?>("t_wip"));
				tv_ReportSETItem.SetValue<decimal?>("t_ordered", tv_ReportSETItem.GetValue<decimal?>("t_ordered"));
				tv_ReportSETItem.SetValue<decimal?>("t_reorder", tv_ReportSETItem.GetValue<decimal?>("t_reorder"));
				tv_ReportSETItem.SetValue<decimal?>("t_on_hand", tv_ReportSETItem.GetValue<decimal?>("t_on_hand"));
				tv_ReportSETItem.SetValue<decimal?>("t_alloc_ord", tv_ReportSETItem.GetValue<decimal?>("t_alloc_ord"));
				tv_ReportSETItem.SetValue<decimal?>("t_rsvd_co", tv_ReportSETItem.GetValue<decimal?>("t_rsvd_co"));
				tv_ReportSETItem.SetValue<decimal?>("t_sold_ytd", tv_ReportSETItem.GetValue<decimal?>("t_sold_ytd"));
				tv_ReportSETItem.SetValue<decimal?>("t_pur_ytd", tv_ReportSETItem.GetValue<decimal?>("t_pur_ytd"));
				tv_ReportSETItem.SetValue<decimal?>("t_mrb", tv_ReportSETItem.GetValue<decimal?>("t_mrb"));
				tv_ReportSETItem.SetValue<string>("t_type_desc", tv_ReportSETItem.GetValue<string>("t_type_desc"));
				tv_ReportSETItem.SetValue<string>("t_method", tv_ReportSETItem.GetValue<string>("t_method"));
				tv_ReportSETItem.SetValue<string>("t_pmt_code", tv_ReportSETItem.GetValue<string>("t_pmt_code"));
				tv_ReportSETItem.SetValue<string>("t_stat", tv_ReportSETItem.GetValue<string>("t_stat"));
				tv_ReportSETItem.SetValue<int?>("t_reprice", tv_ReportSETItem.GetValue<int?>("t_reprice"));
				tv_ReportSETItem.SetValue<decimal?>("t_unit_price", tv_ReportSETItem.GetValue<decimal?>("t_unit_price"));
				tv_ReportSETItem.SetValue<decimal?>("p_markup", tv_ReportSETItem.GetValue<decimal?>("p_markup"));
				tv_ReportSETItem.SetValue<int?>("d_displaystockroomlocations", tv_ReportSETItem.GetValue<int?>("d_displaystockroomlocations"));
				tv_ReportSETItem.SetValue<int?>("il_Rank", tv_ReportSETItem.GetValue<int?>("il_Rank"));
				tv_ReportSETItem.SetValue<string>("il_Loc", tv_ReportSETItem.GetValue<string>("il_Loc"));
				tv_ReportSETItem.SetValue<string>("il_Lot", tv_ReportSETItem.GetValue<string>("il_Lot"));
				tv_ReportSETItem.SetValue<decimal?>("il_QtyOnHand", tv_ReportSETItem.GetValue<decimal?>("il_QtyOnHand"));
				tv_ReportSETItem.SetValue<decimal?>("il_QtyRsvd", tv_ReportSETItem.GetValue<decimal?>("il_QtyRsvd"));
				tv_ReportSETItem.SetValue<int?>("d_displayvendorsfortheitems", tv_ReportSETItem.GetValue<int?>("d_displayvendorsfortheitems"));
				tv_ReportSETItem.SetValue<string>("vi_Item", tv_ReportSETItem.GetValue<string>("vi_Item"));
				tv_ReportSETItem.SetValue<string>("vi_VendNum", tv_ReportSETItem.GetValue<string>("vi_VendNum"));
				tv_ReportSETItem.SetValue<string>("vi_VendName", tv_ReportSETItem.GetValue<string>("vi_VendName"));
				tv_ReportSETItem.SetValue<int?>("d_displaycustomersforitems", tv_ReportSETItem.GetValue<int?>("d_displaycustomersforitems"));
				tv_ReportSETItem.SetValue<string>("ci_Item", tv_ReportSETItem.GetValue<string>("ci_Item"));
				tv_ReportSETItem.SetValue<string>("ci_CustNumb", tv_ReportSETItem.GetValue<string>("ci_CustNumb"));
				tv_ReportSETItem.SetValue<string>("ci_CustName", tv_ReportSETItem.GetValue<string>("ci_CustName"));
				tv_ReportSETItem.SetValue<string>("CostPriceFormat", tv_ReportSETItem.GetValue<string>("CostPriceFormat"));
				tv_ReportSETItem.SetValue<int?>("CostPricePlaces", tv_ReportSETItem.GetValue<int?>("CostPricePlaces"));
				tv_ReportSETItem.SetValue<string>("compliant", tv_ReportSETItem.GetValue<string>("compliant"));
				tv_ReportSETItem.SetValue<string>("col0", sQLUtil.CaseWhen<string>(sQLUtil.SQLEqual(DisplayStockroomLocations, 0) == true, null, tv_ReportSETItem.GetValue<string>("i_item")));
				tv_ReportSETItem.SetValue<string>("col1", sQLUtil.CaseWhen<string>(sQLUtil.SQLEqual(DisplayVendorsfortheItems, 0) == true, null, tv_ReportSETItem.GetValue<string>("i_item")));
				tv_ReportSETItem.SetValue<string>("col2", sQLUtil.CaseWhen<string>(sQLUtil.SQLEqual(DisplayCustomersforItems, 0) == true, null, tv_ReportSETItem.GetValue<string>("i_item")));
			};

			Data = tv_ReportSETLoadResponse;

			this.transactionFactory.CommitTransaction("");

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: CloseSessionContextSp
			var CloseSessionContext = this.iCloseSessionContext.CloseSessionContextSp(SessionID: RptSessionID);

			#endregion ExecuteMethodCall

			return (Data, Severity);
		}
		public (ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_Rpt_ItemDetailSp(string AltExtGenSp,
			string MaterialStatus = "AOS",
			string Source = "PMT",
			string MaterialType = "MTFO",
			string ABCCode = "ABC",
			int? Stocked = 0,
			int? NotStocked = 0,
			int? DisplayStockroomLocations = 0,
			int? DisplayVendorsfortheItems = 0,
			int? DisplayCustomersforItems = 0,
			int? PrintZeroQtyOnHandItems = 0,
			int? PrintCost = 0,
			int? PrintPrice = 0,
			int? DisplayHeader = 0,
			string WarehouseStarting = null,
			string WarehouseEnding = null,
			string ItemStarting = null,
			string ItemEnding = null,
			string ProductCodeStarting = null,
			string ProductCodeEnding = null,
			string ComplianceProgramId = null,
			string ComplianceStatus = null,
			string pSite = null)
		{
			InfobarType _MaterialStatus = MaterialStatus;
			InfobarType _Source = Source;
			InfobarType _MaterialType = MaterialType;
			InfobarType _ABCCode = ABCCode;
			ListYesNoType _Stocked = Stocked;
			ListYesNoType _NotStocked = NotStocked;
			ListYesNoType _DisplayStockroomLocations = DisplayStockroomLocations;
			ListYesNoType _DisplayVendorsfortheItems = DisplayVendorsfortheItems;
			ListYesNoType _DisplayCustomersforItems = DisplayCustomersforItems;
			ListYesNoType _PrintZeroQtyOnHandItems = PrintZeroQtyOnHandItems;
			ListYesNoType _PrintCost = PrintCost;
			ListYesNoType _PrintPrice = PrintPrice;
			ListYesNoType _DisplayHeader = DisplayHeader;
			WhseType _WarehouseStarting = WarehouseStarting;
			WhseType _WarehouseEnding = WarehouseEnding;
			ItemType _ItemStarting = ItemStarting;
			ItemType _ItemEnding = ItemEnding;
			ProductCodeType _ProductCodeStarting = ProductCodeStarting;
			ProductCodeType _ProductCodeEnding = ProductCodeEnding;
			ComplianceProgramIdType _ComplianceProgramId = ComplianceProgramId;
			StringType _ComplianceStatus = ComplianceStatus;
			SiteType _pSite = pSite;

			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;

				appDB.AddCommandParameter(cmd, "MaterialStatus", _MaterialStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Source", _Source, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MaterialType", _MaterialType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ABCCode", _ABCCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Stocked", _Stocked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NotStocked", _NotStocked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayStockroomLocations", _DisplayStockroomLocations, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayVendorsfortheItems", _DisplayVendorsfortheItems, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayCustomersforItems", _DisplayCustomersforItems, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintZeroQtyOnHandItems", _PrintZeroQtyOnHandItems, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintCost", _PrintCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintPrice", _PrintPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WarehouseStarting", _WarehouseStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WarehouseEnding", _WarehouseEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCodeStarting", _ProductCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCodeEnding", _ProductCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ComplianceProgramId", _ComplianceProgramId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ComplianceStatus", _ComplianceStatus, ParameterDirection.Input);
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
