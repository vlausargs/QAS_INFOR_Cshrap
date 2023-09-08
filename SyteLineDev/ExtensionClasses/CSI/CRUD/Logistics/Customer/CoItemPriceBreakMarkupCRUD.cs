//PROJECT NAME: Logistics
//CLASS NAME: CoItemPriceBreakMarkupCRUD.cs

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

namespace CSI.Logistics.Customer
{
	public class CoItemPriceBreakMarkupCRUD : ICoItemPriceBreakMarkupCRUD
	{
		readonly IApplicationDB appDB;
		readonly ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
		readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionUpdateRequestFactory collectionUpdateRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly IExistsChecker existsChecker;
		readonly IVariableUtil variableUtil;
		readonly IStringUtil stringUtil;
		readonly ISQLValueComparerUtil sQLUtil;
		
		public CoItemPriceBreakMarkupCRUD(IApplicationDB appDB,
			ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
			ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			IExistsChecker existsChecker,
			IVariableUtil variableUtil,
			IStringUtil stringUtil,
			ISQLValueComparerUtil sQLUtil)
		{
			this.appDB = appDB;
			this.collectionLoadStatementRequestFactory = collectionLoadStatementRequestFactory;
			this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionUpdateRequestFactory = collectionUpdateRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.existsChecker = existsChecker;
			this.variableUtil = variableUtil;
			this.stringUtil = stringUtil;
			this.sQLUtil = sQLUtil;
		}
		
		public bool Optional_ModuleForExists()
		{
			return existsChecker.Exists(tableName:"optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME(N'CoItemPriceBreakMarkupSp_' + [om].[ModuleName])) IS NOT NULL"));
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
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME(N'CoItemPriceBreakMarkupSp_' + [om].[ModuleName])) IS NOT NULL"),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			
			var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
			
			foreach(var optional_module1Item in optional_module1LoadResponse.Items){
				optional_module1Item.SetValue<string>("SpName", stringUtil.Concat("CoItemPriceBreakMarkupSp_", optional_module1Item.GetValue<string>("u0")));
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
		
		public (string Site, int? rowCount) ParmsLoad(string Site)
		{
			SiteType _Site = DBNull.Value;
			
			var parmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_Site,"parms.site"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				maximumRows: 1,
				tableName:"parms",
				fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var parmsLoadResponse = this.appDB.Load(parmsLoadRequest);
			if(parmsLoadResponse.Items.Count > 0)
			{
				Site = _Site;
			}
			
			int rowCount = parmsLoadResponse.Items.Count;
			return (Site, rowCount);
		}
		
		public (string CurrparmsCurrCode, int? rowCount) CurrparmsLoad(string CurrparmsCurrCode)
		{
			CurrCodeType _CurrparmsCurrCode = DBNull.Value;
			
			var currparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_CurrparmsCurrCode,"currparms.curr_code"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				maximumRows: 1,
				tableName:"currparms",
				fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var currparmsLoadResponse = this.appDB.Load(currparmsLoadRequest);
			if(currparmsLoadResponse.Items.Count > 0)
			{
				CurrparmsCurrCode = _CurrparmsCurrCode;
			}
			
			int rowCount = currparmsLoadResponse.Items.Count;
			return (CurrparmsCurrCode, rowCount);
		}
		
		public (string CoCurrCode, DateTime? CoOrderDate, int? CoFixedRate, decimal? CoExchRate, int? rowCount) CoLoad(string CoNum, string CoCurrCode, DateTime? CoOrderDate, int? CoFixedRate, decimal? CoExchRate)
		{
			CurrCodeType _CoCurrCode = DBNull.Value;
			DateType _CoOrderDate = DBNull.Value;
			ListYesNoType _CoFixedRate = DBNull.Value;
			ExchRateType _CoExchRate = DBNull.Value;
			
			var coLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_CoCurrCode,"co.curr_code"},
					{_CoOrderDate,"co.order_date"},
					{_CoFixedRate,"co.fixed_rate"},
					{_CoExchRate,"co.exch_rate"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"co",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("co.co_num = {0}",CoNum),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var coLoadResponse = this.appDB.Load(coLoadRequest);
			if(coLoadResponse.Items.Count > 0)
			{
				CoCurrCode = _CoCurrCode;
				CoOrderDate = _CoOrderDate;
				CoFixedRate = _CoFixedRate;
				CoExchRate = _CoExchRate;
			}
			
			int rowCount = coLoadResponse.Items.Count;
			return (CoCurrCode, CoOrderDate, CoFixedRate, CoExchRate, rowCount);
		}
		
		public (string Item, decimal? QtyPerCycle, decimal? ItemQty, int? rowCount) Prod_MixLoad(string CoProductMix, decimal? ProdCycles, decimal? ItemQty, decimal? QtyPerCycle, string Item)
		{
			ItemType _Item = DBNull.Value;
			QtyUnitType _QtyPerCycle = DBNull.Value;
			QtyUnitType _ItemQty = DBNull.Value;
			
			var prod_mixLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_Item,"item"},
					{_QtyPerCycle,"1"},
					{_ItemQty,$"{ProdCycles}"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				maximumRows: 1,
				tableName:"prod_mix",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("prod_mix.item = {0}",CoProductMix),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var prod_mixLoadResponse = this.appDB.Load(prod_mixLoadRequest);
			if(prod_mixLoadResponse.Items.Count > 0)
			{
				Item = _Item;
				QtyPerCycle = _QtyPerCycle;
				ItemQty = _ItemQty;
			}
			
			int rowCount = prod_mixLoadResponse.Items.Count;
			return (Item, QtyPerCycle, ItemQty, rowCount);
		}
		
		public bool CoitemForExists(string CoNum, string Item)
		{
			return existsChecker.Exists(tableName:"coitem",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("coitem.item = {1} AND coitem.co_num = {0}",CoNum,Item));
		}
		
		public ICollectionLoadResponse Coitem1Select(string CoNum)
		{
			var coitem1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"co_num","co_num"},
				},
				loadForChange: true,
				lockingType: LockingType.None,
				tableName:"coitem",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("co_num = {0}",CoNum),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(coitem1LoadRequest);
		}
		
		public void Coitem1Delete(ICollectionLoadResponse coitem1LoadResponse)
		{
			var coitem1DeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "coitem",
				items: coitem1LoadResponse.Items);
			this.appDB.Delete(coitem1DeleteRequest);
		}
		
		public bool JobForExists(string BOMType, string CoNum, int? CoLine, string Item)
		{
			return existsChecker.Exists(tableName:"job",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("job.ord_num = {1} AND job.ord_line = {0} AND job.item <> {2} AND job.suffix = 0",CoLine,CoNum,Item));
		}
		
		public bool Job1ForExists(string BOMType, string CoNum, string CoProductMix)
		{
			return existsChecker.Exists(tableName:"job",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("job.ord_num = {1} AND job.prod_mix <> {0}",CoProductMix,CoNum));
		}
		
		public bool Coitem2ForExists(string CoNum)
		{
			return existsChecker.Exists(tableName:"coitem",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("co_num = {0}",CoNum));
		}
		
		public ICollectionLoadResponse Job_Price_BreakSelect(string CoNum, int? CoLine)
		{
			var job_price_breakLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"job_price_break.job","job_price_break.job"},
					{"job_price_break.suffix","job_price_break.suffix"},
				},
				loadForChange: true,
				lockingType: LockingType.None,
				tableName:"job_price_break",
				fromClause: collectionLoadRequestFactory.Clause(@" INNER JOIN job_price_break ON job_price_break.job = job.job
					AND job_price_break.suffix = job.suffix"),
				whereClause: collectionLoadRequestFactory.Clause("job.ord_num = {1} AND job.ord_line = {0}",CoLine,CoNum),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(job_price_breakLoadRequest);
		}
		
		public void Job_Price_BreakDelete(ICollectionLoadResponse job_price_breakLoadResponse)
		{
			var job_price_breakDeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "job_price_break",
				items: job_price_breakLoadResponse.Items);
			this.appDB.Delete(job_price_breakDeleteRequest);
		}
		
		public ICollectionLoadResponse JobitemSelect(string CoNum, int? CoLine)
		{
			var jobitemLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"jobitem.job","jobitem.job"},
				},
				loadForChange: true,
				lockingType: LockingType.None,
				tableName:"jobitem",
				fromClause: collectionLoadRequestFactory.Clause(" INNER JOIN jobitem ON jobitem.job = job.job"),
				whereClause: collectionLoadRequestFactory.Clause("job.ord_num = {1} AND job.ord_line = {0}",CoLine,CoNum),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(jobitemLoadRequest);
		}
		
		public void JobitemDelete(ICollectionLoadResponse jobitemLoadResponse)
		{
			var jobitemDeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "jobitem",
				items: jobitemLoadResponse.Items);
			this.appDB.Delete(jobitemDeleteRequest);
		}
		
		public ICollectionLoadResponse Job2Select(string CoNum, int? CoLine)
		{
			var job2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"ord_num","ord_num"},
					{"ord_line","ord_line"},
				},
				loadForChange: true,
				lockingType: LockingType.None,
				tableName:"job",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("job.ord_num = {1} AND job.ord_line = {0}",CoLine,CoNum),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(job2LoadRequest);
		}
		
		public void Job2Delete(ICollectionLoadResponse job2LoadResponse)
		{
			var job2DeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "job",
				items: job2LoadResponse.Items);
			this.appDB.Delete(job2DeleteRequest);
		}
		
		public bool Job3ForExists(string CoNum, int? CoLine)
		{
			return existsChecker.Exists(tableName:"job",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("job.ord_num = {1} AND job.ord_line = {0}",CoLine,CoNum));
		}
		
		public ICollectionLoadResponse Job4Select(string CoNum, int? CoLine)
		{
			var job4LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"prod_mix","job.prod_mix"},
					{"MO_product_cycle","job.MO_product_cycle"},
					{"MO_qty_per_cycle","job.MO_qty_per_cycle"},
				},
				loadForChange: true,
				lockingType: LockingType.UPDLock,
				tableName:"job",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("ord_num = {1} AND ord_line = {0}",CoLine,CoNum),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(job4LoadRequest);
		}
		
		public void Job4Update(decimal? ProdCycles, decimal? QtyPerCycle, string CoProductMix, ICollectionLoadResponse job4LoadResponse)
		{
			foreach(var job4Item in job4LoadResponse.Items){
				job4Item.SetValue<string>("prod_mix", CoProductMix);
				job4Item.SetValue<decimal?>("MO_product_cycle", ProdCycles);
				job4Item.SetValue<decimal?>("MO_qty_per_cycle", QtyPerCycle);
			};
			
			var job4RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "job",
				items: job4LoadResponse.Items);
			
			this.appDB.Update(job4RequestUpdate);
		}
		
		public (string job, int? suffix, decimal? PriceBasisValue, decimal? ProdcodeMarkup, decimal? CoDisc, int? rowCount) Job5Load(string CoNum,
			int? CoLine,
			string Item,
			decimal? PriceBasisValue,
			decimal? CoDisc,
			string job,
			int? suffix,
			decimal? ProdcodeMarkup)
		{
			JobType _job = DBNull.Value;
			SuffixType _suffix = DBNull.Value;
			AmountType _PriceBasisValue = DBNull.Value;
			MarkupType _ProdcodeMarkup = DBNull.Value;
			LineDiscType _CoDisc = DBNull.Value;
			
			var job5LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_job,"job.job"},
					{_suffix,"job.suffix"},
					{_PriceBasisValue,$"ISNULL({PriceBasisValue}, 0)"},
					{_ProdcodeMarkup,"ISNULL(prodcode.markup, 0)"},
					{_CoDisc,$"CASE WHEN {CoDisc} IS NULL THEN 0 ELSE {CoDisc} END"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"job",
				fromClause: collectionLoadRequestFactory.Clause(@" LEFT OUTER JOIN coitem ON coitem.co_num = {1}
					AND coitem.co_line = {0}
					AND coitem.ref_num = job.job
					AND coitem.ref_line_suf = job.suffix
					AND coitem.ref_type = 'J'
					AND coitem.item = job.item LEFT OUTER JOIN ItemsNonInventoryItems ON ItemsNonInventoryItems.item = coitem.item LEFT OUTER JOIN prodcode ON prodcode.product_code = ItemsNonInventoryItems.product_code",CoLine,CoNum),
				whereClause: collectionLoadRequestFactory.Clause("job.ord_num = {1} AND job.ord_line = {0} AND job.item = {2}",CoLine,CoNum,Item),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var job5LoadResponse = this.appDB.Load(job5LoadRequest);
			if(job5LoadResponse.Items.Count > 0)
			{
				job = _job;
				suffix = _suffix;
				PriceBasisValue = _PriceBasisValue;
				ProdcodeMarkup = _ProdcodeMarkup;
				CoDisc = _CoDisc;
			}
			
			int rowCount = job5LoadResponse.Items.Count;
			return (job, suffix, PriceBasisValue, ProdcodeMarkup, CoDisc, rowCount);
		}
		
		public (decimal? MatlCost, decimal? Fixture, decimal? material, decimal? Tool, decimal? Other, decimal? RunCost, decimal? FixOvhdCost, decimal? VarOvhdCost, decimal? OutSideCost) CostSelect(string CoNum, int? CoLine, decimal? ItemQty, string Item,decimal? RunCost, decimal? FixOvhdCost, decimal? VarOvhdCost, decimal? OutSideCost)
		{                                                                                                                                                                                                                                                                                                   
			decimal? MatlCost = null;                                                                                                                                                                                                                                                                       
			AmountType _MatlCost = DBNull.Value;
			decimal? Fixture = null;
			AmountType _Fixture = DBNull.Value;
			decimal? material = null;
			AmountType _material = DBNull.Value;
			decimal? Tool = null;
			AmountType _Tool = DBNull.Value;
			decimal? Other = null;
			AmountType _Other = DBNull.Value;
			decimal? RunCostVar = RunCost;
			AmountType _RunCost = DBNull.Value;
			decimal? FixOvhdCostVar = FixOvhdCost;
			AmountType _FixOvhdCost = DBNull.Value;
			decimal? VarOvhdCostVar = VarOvhdCost;
			AmountType _VarOvhdCost = DBNull.Value;
			decimal? OutSideCostVar = OutSideCost;
			AmountType _OutSideCost = DBNull.Value;
			
			var costLoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_MatlCost,"isnull(SUM(MatlCost), 0)"},
					{_Fixture,"isnull(SUM(Fixture), 0)"},
					{_material,"isnull(SUM(Material), 0)"},
					{_Tool,"isnull(SUM(tool), 0)"},
					{_Other,"isnull(SUM(Other), 0)"},
					{_RunCost,$"{RunCostVar} + isnull(SUM(Labor), 0)"},
					{_FixOvhdCost,$"{FixOvhdCostVar} + isnull(SUM(FixOvhdCost), 0)"},
					{_VarOvhdCost,$"{VarOvhdCostVar} + isnull(SUM(VarOvhdCost), 0)"},
					{_OutSideCost,$"{OutSideCostVar} + isnull(SUM(OutSideCost), 0)"}
				},
				selectStatement: collectionLoadRequestFactory.Clause(@"SELECT @selectList
					FROM (SELECT   (qty * SUM(CASE WHEN jm.outside != 1 THEN jm.matl_Cost ELSE 0 END)) AS MatlCost,
						(qty * SUM(CASE WHEN jm.matl_type = 'F'
								AND jm.outside != 1 THEN jm.matl_Cost ELSE 0 END)) AS Fixture,
						(qty * SUM(CASE WHEN jm.matl_type = 'M'
								AND jm.outside != 1 THEN jm.matl_Cost ELSE 0 END)) AS Material,
						(qty * SUM(CASE WHEN jm.matl_type = 'T'
								AND jm.outside != 1 THEN jm.matl_Cost ELSE 0 END)) AS Tool,
						(qty * SUM(CASE WHEN jm.matl_type = 'O'
								AND jm.outside != 1 THEN jm.matl_Cost ELSE 0 END)) AS Other,
						(qty * SUM(CASE WHEN jm.outside != 1 THEN jm.lbr_cost ELSE 0 END)) AS Labor,
						(qty * SUM(jm.Fovhd_cost + CASE WHEN charindex('M', jm.overhead) > 0 THEN jm.fmatlovhd * jm.matl_cost ELSE 0 END)) AS FixOvhdCost,
						(qty * SUM(jm.vovhd_cost + CASE WHEN charindex('M', jm.overhead) > 0 THEN jm.vmatlovhd * jm.matl_cost ELSE 0 END)) AS VarOvhdCost,
						(qty * ISNULL(SUM(CASE WHEN jm.outside = 1 THEN jm.cost ELSE jm.out_cost END), 0)) AS OutSideCost
						FROM     (SELECT (jm.matl_qty / CASE WHEN scrap_fact <> 1 THEN (1.0 - scrap_fact) ELSE 1 END) * CASE WHEN jm.units = 'U' THEN {0}  ELSE 1 END AS qty,
							jm.matl_type AS matl_type,
							jm.cost,
							jm.matl_cost,
							jm.lbr_cost,
							jm.fovhd_cost,
							jm.vovhd_cost,
							jm.out_cost,
							jm.vmatlovhd,
							jm.fmatlovhd,
							wc.outside,
							wc.overhead
							FROM   job
							INNER JOIN
							jobmatl AS jm
							ON job.job = jm.job
							AND job.suffix = jm.suffix
							INNER JOIN
							jobroute AS jr
							ON jr.job = jm.job
							AND jr.suffix = jm.suffix
							AND jr.oper_num = jm.oper_num
							INNER JOIN
							wc
							ON wc.wc = jr.wc
							WHERE  job.ord_num = {2}
							AND job.ord_line = {1}
							AND job.item = {3} ) AS jm
						GROUP BY qty) AS cost", ItemQty, CoLine, CoNum, Item));
			
			var costLoadResponse = this.appDB.Load(costLoadRequest);            
            if (costLoadResponse.Items.Count > 0)
			{
				MatlCost = _MatlCost;
				Fixture = _Fixture;
				material = _material;
				Tool = _Tool;
				Other = _Other;
                RunCostVar = _RunCost;
				FixOvhdCostVar = _FixOvhdCost;
				VarOvhdCostVar = _VarOvhdCost;
                OutSideCostVar = _OutSideCost;
			}
			
			return (MatlCost, Fixture, material, Tool, Other, RunCostVar, FixOvhdCostVar, VarOvhdCostVar, OutSideCostVar);
		}
		
		public bool Job_Price_Break1ForExists(string PriceBasis, decimal? ItemQty, string job, int? suffix)
		{
			return existsChecker.Exists(tableName:"job_price_break",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("job = {2} AND suffix = {1} AND {0} >= break_qty",ItemQty,suffix,job));
		}
		
		public decimal? JbpSelect(string CoNum, int? CoLine, decimal? ItemQty, string Item, decimal? Fixture, decimal? material, decimal? Other, decimal? Tool, decimal? SetupCost, decimal? RunCost, decimal? FixOvhdCost, decimal? VarOvhdCost, decimal? OutSideCost)
		{
			decimal? Markedup = null;
			AmountType _Markedup = DBNull.Value;
			
			var jbpLoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_Markedup,"setup_value + run_value + outside_value + matl_value + Fixture_value + Tool_value + other_value + over_head_value + non_recurring_value"},
				},
				selectStatement: collectionLoadRequestFactory.Clause(@"SELECT @selectList
					FROM (SELECT   TOP 1 {9}  AS CoNum,
						{8}  AS CoLine,
						ISNULL({3}  * (1 + ISNULL(jpb.setup_markup, 0) / 100), 0) AS setup_value,
						ISNULL({5}  * (1 + ISNULL(jpb.run_markup, 0) / 100), 0) AS run_value,
						ISNULL({0}  * (1 + ISNULL(jpb.outside_markup, 0) / 100), 0) AS outside_value,
						ISNULL({4}  * (1 + ISNULL(jpb.matl_markup, 0) / 100), 0) AS matl_value,
						ISNULL({6}  * (1 + ISNULL(jpb.fixture_markup, 0) / 100), 0) AS Fixture_value,
						ISNULL({11}  * (1 + ISNULL(jpb.tool_markup, 0) / 100), 0) AS Tool_value,
						ISNULL({10}  * (1 + ISNULL(jpb.other_markup, 0) / 100), 0) AS other_value,
						ISNULL(({1}  + {2} ) * (1 + ISNULL(jpb.overhead_markup, 0) / 100), 0) AS over_head_value,
						ISNULL(jpb.non_recurring_cost * (1 + ISNULL(jpb.non_recurring_markup, 0) / 100), 0) AS non_recurring_value
						FROM     job
						LEFT OUTER JOIN
						job_price_break AS jpb
						ON jpb.job = job.job
						AND jpb.suffix = job.suffix
						WHERE    job.ord_num = {9}
						AND job.ord_line = {8}
						AND jpb.break_qty <= {7}
						AND job.item = {12}
						ORDER BY jpb.break_qty DESC) AS jbp", OutSideCost, FixOvhdCost, VarOvhdCost, SetupCost, material, RunCost, Fixture, ItemQty, CoLine, CoNum, Other, Tool, Item));
			
			var jbpLoadResponse = this.appDB.Load(jbpLoadRequest);
			if(jbpLoadResponse.Items.Count > 0)
			{
				Markedup = _Markedup;
			}
			
			return Markedup;
		}
		
		public decimal? ValSelect(decimal? PriceBasisValue, decimal? ProdcodeMarkup, decimal? OutSideCost, decimal? FixOvhdCost, decimal? VarOvhdCost, string PriceBasis, decimal? SetupCost, decimal? material, decimal? RunCost, decimal? Fixture, decimal? ItemQty, decimal? CoDisc, decimal? Other, decimal? Tool, string CoNum, int? CoLine, string Item)
		{
			decimal? Markedup = null;
			AmountType _Markedup = DBNull.Value;
			
			var ValLoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_Markedup,$"CASE {variableUtil.GetQuotedValue<string>(PriceBasis)} WHEN N'%' THEN (setup_value + run_value + outside_value + matl_value + Fixture_value + Tool_value + other_value + over_head_value + non_recurring_value) * (1 + {PriceBasisValue} / 100) WHEN N'$' THEN ({SetupCost} + {RunCost} + {OutSideCost} + {material} + {Fixture} + {Tool} + {Other} + {FixOvhdCost} + {VarOvhdCost}) + {PriceBasisValue} * {ItemQty} WHEN N'P' THEN {PriceBasisValue} * {ItemQty} WHEN N'D' THEN ({SetupCost} + {RunCost} + {OutSideCost} + {material} + {Fixture} + {Tool} + {Other} + {FixOvhdCost} + {VarOvhdCost}) * {ProdcodeMarkup} * (1 - ISNULL({CoDisc}, 0) / 100) ELSE ({SetupCost} + {RunCost} + {OutSideCost} + {material} + {Fixture} + {Tool} + {Other} + {FixOvhdCost} + {VarOvhdCost}) * {ProdcodeMarkup} END"},
				},
				selectStatement: collectionLoadRequestFactory.Clause(@"SELECT @selectList
					FROM (SELECT   TOP 1 {9}  AS CoNum,
						{8}  AS CoLine,
						{5}  AS qty_ordered_conv,
						ISNULL({3}  * (1 + ISNULL(jpb.setup_markup, 0) / 100), 0) AS setup_value,
						ISNULL({6}  * (1 + ISNULL(jpb.run_markup, 0) / 100), 0) AS run_value,
						ISNULL({0}  * (1 + ISNULL(jpb.outside_markup, 0) / 100), 0) AS outside_value,
						ISNULL({4}  * (1 + ISNULL(jpb.matl_markup, 0) / 100), 0) AS matl_value,
						ISNULL({7}  * (1 + ISNULL(jpb.fixture_markup, 0) / 100), 0) AS Fixture_value,
						ISNULL({11}  * (1 + ISNULL(jpb.tool_markup, 0) / 100), 0) AS Tool_value,
						ISNULL({10}  * (1 + ISNULL(jpb.other_markup, 0) / 100), 0) AS other_value,
						ISNULL({1}  + {2} , 0) * (1 + ISNULL(jpb.overhead_markup, 0) / 100) AS over_head_value,
						ISNULL(jpb.non_recurring_cost * (1 + ISNULL(jpb.non_recurring_markup, 0) / 100), 0) AS non_recurring_value
						FROM     job
						LEFT OUTER JOIN
						job_price_break AS jpb
						ON jpb.job = job.job
						AND jpb.suffix = job.suffix
						AND jpb.break_qty <= {5}
						WHERE    job.ord_num = {9}
						AND job.ord_line = {8}
						AND job.item = {12}
						ORDER BY jpb.break_qty DESC) AS Val", OutSideCost, FixOvhdCost, VarOvhdCost, SetupCost, material, ItemQty, RunCost, Fixture, CoLine, CoNum, Other, Tool, Item));
			
			var ValLoadResponse = this.appDB.Load(ValLoadRequest);
			if(ValLoadResponse.Items.Count > 0)
			{
				Markedup = _Markedup;
			}
			
			return Markedup;
		}
		
		public ICollectionLoadResponse Coitem3Select(string CoNum)
		{
			var coitem3LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"ref_num","coitem.ref_num"},
					{"ref_line_suf","coitem.ref_line_suf"},
					{"ref_type","coitem.ref_type"},
					{"wks_basis","coitem.wks_basis"},
					{"wks_value","coitem.wks_value"},
					{"disc","coitem.disc"},
					{"qty_ordered","coitem.qty_ordered"},
					{"qty_ordered_conv","coitem.qty_ordered_conv"},
					{"price_conv","coitem.price_conv"},
					{"cost_conv","coitem.cost_conv"},
					{"matl_cost_conv","coitem.matl_cost_conv"},
					{"lbr_cost_conv","coitem.lbr_cost_conv"},
					{"fovhd_cost_conv","coitem.fovhd_cost_conv"},
					{"vovhd_cost_conv","coitem.vovhd_cost_conv"},
					{"out_cost_conv","coitem.out_cost_conv"},
					{"u0","jobitem.ratio1"},
					{"u1","jobitem.ratio2"},
				},
				loadForChange: true,
				lockingType: LockingType.UPDLock,
				tableName:"coitem",
				fromClause: collectionLoadRequestFactory.Clause(@" INNER JOIN jobitem ON jobitem.ord_num = coitem.co_num
					AND jobitem.item = coitem.item"),
				whereClause: collectionLoadRequestFactory.Clause("jobitem.ord_num = {0} AND coitem.co_num = {0}",CoNum),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(coitem3LoadRequest);
		}
		
		public void Coitem3Update(decimal? ItemQty, string PriceBasis, decimal? PriceBasisValue, decimal? CoDisc, decimal? UnitFixture, decimal? Unitmaterial, decimal? UnitOther, decimal? UnitTool, decimal? unitSetupCost, decimal? UnitRunCost, decimal? UnitFixOvhdCost, decimal? UnitVarOvhdCost, decimal? UnitOutSideCost, decimal? UnitMarkedup, decimal? Yield, string job, int? suffix, ICollectionLoadResponse coitem3LoadResponse)
		{
			foreach(var coitem3Item in coitem3LoadResponse.Items){
				coitem3Item.SetValue<string>("ref_num", job);
				coitem3Item.SetValue<int?>("ref_line_suf", suffix);
				coitem3Item.SetValue<string>("ref_type", "J");
				coitem3Item.SetValue<string>("wks_basis", PriceBasis);
				coitem3Item.SetValue<decimal?>("wks_value", stringUtil.IsNull<decimal?>(
					PriceBasisValue,
					0));
				coitem3Item.SetValue<decimal?>("disc", stringUtil.IsNull<decimal?>(
					CoDisc,
					0));
				coitem3Item.SetValue<decimal?>("qty_ordered", ItemQty * (decimal?)(coitem3Item.GetDeletedValue<int?>("u0")));
				coitem3Item.SetValue<decimal?>("qty_ordered_conv", ItemQty * (decimal?)(coitem3Item.GetDeletedValue<int?>("u0")));
				coitem3Item.SetValue<decimal?>("price_conv", stringUtil.IsNull<decimal?>(
					UnitMarkedup * 1M + (1M - Yield),
					0) / (decimal?)((((sQLUtil.SQLEqual(coitem3Item.GetDeletedValue<int?>("u1"), 0) == true ? 1 : coitem3Item.GetDeletedValue<int?>("u1"))))) * (decimal?)(coitem3Item.GetDeletedValue<int?>("u0")));
				coitem3Item.SetValue<decimal?>("cost_conv", (stringUtil.IsNull<decimal?>(
					UnitFixture + Unitmaterial + UnitTool + UnitOther,
					0) / (decimal?)(((sQLUtil.SQLEqual(coitem3Item.GetDeletedValue<int?>("u1"), 0) == true ? 1 : coitem3Item.GetDeletedValue<int?>("u1")))) * (decimal?)(coitem3Item.GetDeletedValue<int?>("u0")) + (stringUtil.IsNull<decimal?>(
					unitSetupCost,
					0) + stringUtil.IsNull<decimal?>(
					UnitRunCost,
					0) + stringUtil.IsNull<decimal?>(
					UnitFixOvhdCost,
					0) + stringUtil.IsNull<decimal?>(
					UnitVarOvhdCost,
					0) + stringUtil.IsNull<decimal?>(
					UnitOutSideCost,
					0)) * (decimal?)(coitem3Item.GetDeletedValue<int?>("u0")) / (decimal?)((((sQLUtil.SQLEqual(coitem3Item.GetDeletedValue<int?>("u1"), 0) == true ? 1 : coitem3Item.GetDeletedValue<int?>("u1"))))) * (decimal?)(coitem3Item.GetDeletedValue<int?>("u0"))));
				coitem3Item.SetValue<decimal?>("matl_cost_conv", stringUtil.IsNull<decimal?>(
					UnitFixture + Unitmaterial + UnitTool + UnitOther,
					0) / (decimal?)(((sQLUtil.SQLEqual(coitem3Item.GetDeletedValue<int?>("u1"), 0) == true ? 1 : coitem3Item.GetDeletedValue<int?>("u1")))) * (decimal?)(coitem3Item.GetDeletedValue<int?>("u0")));
				coitem3Item.SetValue<decimal?>("lbr_cost_conv", stringUtil.IsNull<decimal?>(
					unitSetupCost,
					0) / (decimal?)((((sQLUtil.SQLEqual(coitem3Item.GetDeletedValue<int?>("u1"), 0) == true ? 1 : coitem3Item.GetDeletedValue<int?>("u1"))))) * (decimal?)(coitem3Item.GetDeletedValue<int?>("u0")) + stringUtil.IsNull<decimal?>(
					UnitRunCost,
					0) / (decimal?)((((sQLUtil.SQLEqual(coitem3Item.GetDeletedValue<int?>("u1"), 0) == true ? 1 : coitem3Item.GetDeletedValue<int?>("u1"))))) * (decimal?)(coitem3Item.GetDeletedValue<int?>("u0")));
				coitem3Item.SetValue<decimal?>("fovhd_cost_conv", stringUtil.IsNull<decimal?>(
					UnitFixOvhdCost,
					0) / (decimal?)((((sQLUtil.SQLEqual(coitem3Item.GetDeletedValue<int?>("u1"), 0) == true ? 1 : coitem3Item.GetDeletedValue<int?>("u1"))))) * (decimal?)(coitem3Item.GetDeletedValue<int?>("u0")));
				coitem3Item.SetValue<decimal?>("vovhd_cost_conv", stringUtil.IsNull<decimal?>(
					UnitVarOvhdCost,
					0) / (decimal?)((((sQLUtil.SQLEqual(coitem3Item.GetDeletedValue<int?>("u1"), 0) == true ? 1 : coitem3Item.GetDeletedValue<int?>("u1"))))) * (decimal?)(coitem3Item.GetDeletedValue<int?>("u0")));
				coitem3Item.SetValue<decimal?>("out_cost_conv", stringUtil.IsNull<decimal?>(
					UnitOutSideCost,
					0) / (decimal?)((((sQLUtil.SQLEqual(coitem3Item.GetDeletedValue<int?>("u1"), 0) == true ? 1 : coitem3Item.GetDeletedValue<int?>("u1"))))) * (decimal?)(coitem3Item.GetDeletedValue<int?>("u0")));
			};
			
			var coitem3RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "coitem",
				items: coitem3LoadResponse.Items);
			
			this.appDB.Update(coitem3RequestUpdate);
		}
		
		public ICollectionLoadResponse Coitem4Select(string CoNum, int? CoLine)
		{
			var coitem4LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"ref_num","coitem.ref_num"},
					{"ref_line_suf","coitem.ref_line_suf"},
					{"ref_type","coitem.ref_type"},
					{"wks_basis","coitem.wks_basis"},
					{"wks_value","coitem.wks_value"},
					{"disc","coitem.disc"},
					{"qty_ordered","coitem.qty_ordered"},
					{"qty_ordered_conv","coitem.qty_ordered_conv"},
					{"price_conv","coitem.price_conv"},
					{"cost_conv","coitem.cost_conv"},
					{"matl_cost_conv","coitem.matl_cost_conv"},
					{"lbr_cost_conv","coitem.lbr_cost_conv"},
					{"fovhd_cost_conv","coitem.fovhd_cost_conv"},
					{"vovhd_cost_conv","coitem.vovhd_cost_conv"},
					{"out_cost_conv","coitem.out_cost_conv"},
				},
				loadForChange: true,
				lockingType: LockingType.UPDLock,
				tableName:"coitem",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("coitem.co_num = {1} AND coitem.co_line = {0}",CoLine,CoNum),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(coitem4LoadRequest);
		}
		
		public void Coitem4Update(decimal? ItemQty, string PriceBasis, decimal? PriceBasisValue, decimal? CoDisc, decimal? UnitFixture, decimal? Unitmaterial, decimal? UnitOther, decimal? UnitTool, decimal? unitSetupCost, decimal? UnitRunCost, decimal? UnitFixOvhdCost, decimal? UnitVarOvhdCost, decimal? UnitOutSideCost, decimal? UnitMarkedup, string job, int? suffix, ICollectionLoadResponse coitem4LoadResponse)
		{
			foreach(var coitem4Item in coitem4LoadResponse.Items){
				coitem4Item.SetValue<string>("ref_num", job);
				coitem4Item.SetValue<int?>("ref_line_suf", suffix);
				coitem4Item.SetValue<string>("ref_type", "J");
				coitem4Item.SetValue<string>("wks_basis", PriceBasis);
				coitem4Item.SetValue<decimal?>("wks_value", stringUtil.IsNull<decimal?>(
					PriceBasisValue,
					0));
				coitem4Item.SetValue<decimal?>("disc", stringUtil.IsNull<decimal?>(
					CoDisc,
					0));
				coitem4Item.SetValue<decimal?>("qty_ordered", ItemQty);
				coitem4Item.SetValue<decimal?>("qty_ordered_conv", ItemQty);
				coitem4Item.SetValue<decimal?>("price_conv", UnitMarkedup);
				coitem4Item.SetValue<decimal?>("cost_conv", (stringUtil.IsNull<decimal?>(
					UnitFixture + Unitmaterial + UnitTool + UnitOther,
					0) + stringUtil.IsNull<decimal?>(
					unitSetupCost,
					0) + stringUtil.IsNull<decimal?>(
					UnitRunCost,
					0) + stringUtil.IsNull<decimal?>(
					UnitFixOvhdCost,
					0) + stringUtil.IsNull<decimal?>(
					UnitVarOvhdCost,
					0) + stringUtil.IsNull<decimal?>(
					UnitOutSideCost,
					0)));
				coitem4Item.SetValue<decimal?>("matl_cost_conv", stringUtil.IsNull<decimal?>(
					UnitFixture + Unitmaterial + UnitTool + UnitOther,
					0));
				coitem4Item.SetValue<decimal?>("lbr_cost_conv", stringUtil.IsNull<decimal?>(
					unitSetupCost,
					0) + stringUtil.IsNull<decimal?>(
					UnitRunCost,
					0));
				coitem4Item.SetValue<decimal?>("fovhd_cost_conv", stringUtil.IsNull<decimal?>(
					UnitFixOvhdCost,
					0));
				coitem4Item.SetValue<decimal?>("vovhd_cost_conv", stringUtil.IsNull<decimal?>(
					UnitVarOvhdCost,
					0));
				coitem4Item.SetValue<decimal?>("out_cost_conv", stringUtil.IsNull<decimal?>(
					UnitOutSideCost,
					0));
			};
			
			var coitem4RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "coitem",
				items: coitem4LoadResponse.Items);
			
			this.appDB.Update(coitem4RequestUpdate);
		}
		
		public (int? ReturnCode,
			string InfoBar)
		AltExtGen_CoItemPriceBreakMarkupSp(
			string AltExtGenSp,
			string CoNum,
			int? CoLine,
			int? VendorPriceBreaks,
			decimal? ItemQty,
			decimal? ProdCycles,
			decimal? QtyPerCycle,
			string Item,
			DateTime? DueDate,
			string Whse,
			string BOMType,
			string Resource,
			string CoProductMix,
			string AlternateID,
			string PriceBasis,
			decimal? PriceBasisValue,
			decimal? CoDisc,
			string InfoBar)
		{
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			ListYesNoType _VendorPriceBreaks = VendorPriceBreaks;
			QtyUnitType _ItemQty = ItemQty;
			QtyUnitType _ProdCycles = ProdCycles;
			QtyUnitType _QtyPerCycle = QtyPerCycle;
			ItemType _Item = Item;
			DateType _DueDate = DueDate;
			WhseType _Whse = Whse;
			MO_JobConfigTypeType _BOMType = BOMType;
			ApsResourceType _Resource = Resource;
			ProdMixType _CoProductMix = CoProductMix;
			MO_BOMAlternateType _AlternateID = AlternateID;
			WksBasisType _PriceBasis = PriceBasis;
			AmountType _PriceBasisValue = PriceBasisValue;
			LineDiscType _CoDisc = CoDisc;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendorPriceBreaks", _VendorPriceBreaks, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemQty", _ItemQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProdCycles", _ProdCycles, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyPerCycle", _QtyPerCycle, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BOMType", _BOMType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Resource", _Resource, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoProductMix", _CoProductMix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlternateID", _AlternateID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PriceBasis", _PriceBasis, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PriceBasisValue", _PriceBasisValue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoDisc", _CoDisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
		
	}
}
