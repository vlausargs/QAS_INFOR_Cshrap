//PROJECT NAME: Material
//CLASS NAME: CopyCostingAnalysisAlternativeCRUD.cs

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

namespace CSI.Material
{
	public class CopyCostingAnalysisAlternativeCRUD : ICopyCostingAnalysisAlternativeCRUD
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

		public CopyCostingAnalysisAlternativeCRUD(IApplicationDB appDB,
			ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
			ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			IExistsChecker existsChecker,
			IVariableUtil variableUtil,
			IStringUtil stringUtil)
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
		}

		public bool Optional_ModuleForExists()
		{
			return existsChecker.Exists(tableName: "optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CopyCostingAnalysisAlternativeSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"));
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
                tableName: "optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CopyCostingAnalysisAlternativeSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(optional_module1LoadRequest);
		}

		public void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse)
		{
			var optional_module1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ALTGEN",
				items: optional_module1LoadResponse.Items);

			this.appDB.Insert(optional_module1InsertRequest);
		}

		public bool Tv_ALTGENForExists()
		{
			return existsChecker.Exists(tableName: "#tv_ALTGEN",
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

		public ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName)
		{
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
			return this.appDB.Load(tv_ALTGEN2LoadRequest);
		}

		public void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse)
		{
			var tv_ALTGEN2DeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "#tv_ALTGEN",
				items: tv_ALTGEN2LoadResponse.Items);
			this.appDB.Delete(tv_ALTGEN2DeleteRequest);
		}

		public ICollectionLoadResponse RouteSelect(string Item, string FromJob, string ToJob, int? FromSuffix, int? NewJobFlag)
		{
			var routeLoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"alt_item",$"{variableUtil.GetQuotedValue<string>(Item)}"},
					{"from_job",$"{variableUtil.GetQuotedValue<string>(FromJob)}"},
					{"to_job",$"{variableUtil.GetQuotedValue<string>(ToJob)}"},
					{"suffix",$"{variableUtil.GetQuotedValue<int?>(FromSuffix)}"},
					{"NewJobFlag",$"{variableUtil.GetQuotedValue<int?>(NewJobFlag)}"},
				},
				selectStatement: collectionLoadRequestFactory.Clause("SELECT @selectList"));

			return this.appDB.Load(routeLoadRequest);
		}

		public void RouteInsert(ICollectionLoadResponse routeLoadResponse)
		{
			var routeInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#route",
				items: routeLoadResponse.Items);

			this.appDB.Insert(routeInsertRequest);
		}

		int? Cost_Item_At_Whse;
		public (int? CostItemAtWhse, string DefaultWhse, int? rowCount) InvparmsLoad(int? CostItemAtWhse, string DefaultWhse)
		{
			ListYesNoType _CostItemAtWhse = DBNull.Value;
			WhseType _DefaultWhse = DBNull.Value;

			var invparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_CostItemAtWhse,"cost_item_at_whse"},
					{_DefaultWhse,"def_whse"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "invparms",
				fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
				whereClause: collectionLoadRequestFactory.Clause("parm_key = 0"),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var invparmsLoadResponse = this.appDB.Load(invparmsLoadRequest);
			if (invparmsLoadResponse.Items.Count > 0)
			{
				CostItemAtWhse = _CostItemAtWhse;
				DefaultWhse = _DefaultWhse;
			}

			Cost_Item_At_Whse = CostItemAtWhse;
			int rowCount = invparmsLoadResponse.Items.Count;
			return (CostItemAtWhse, DefaultWhse, rowCount);
		}

		public (string JobPrefix, int? rowCount) Invparms1Load(string JobPrefix)
		{
			AlphaPrefixType _JobPrefix = DBNull.Value;

			var invparms1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_JobPrefix,"invparms.cwo_prefix"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "invparms",
				fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var invparms1LoadResponse = this.appDB.Load(invparms1LoadRequest);
			if (invparms1LoadResponse.Items.Count > 0)
			{
				JobPrefix = _JobPrefix;
			}

			int rowCount = invparms1LoadResponse.Items.Count;
			return (JobPrefix, rowCount);
		}

		public bool Costing_AltForExists(string CostingAlt)
		{
			return existsChecker.Exists(tableName: "costing_alt",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("costing_alt = {0}", CostingAlt));
		}

		public (string CostType, int? CopyRoutingFlag, int? rowCount) Costing_Alt1Load(string CostingAltFrom, int? CopyRoutingFlag, string CostType)
		{
			CostTypeType _CostType = DBNull.Value;
			ListYesNoType _CopyRoutingFlag = DBNull.Value;

			var costing_alt1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_CostType,"cost_type"},
					{_CopyRoutingFlag,"copy_routing_flag"},
				},
				loadForChange: false,
                lockingType: LockingType.None,
                tableName: "costing_alt",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("costing_alt = {0}", CostingAltFrom),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var costing_alt1LoadResponse = this.appDB.Load(costing_alt1LoadRequest);
			if (costing_alt1LoadResponse.Items.Count > 0)
			{
				CostType = _CostType;
				CopyRoutingFlag = _CopyRoutingFlag;
			}

			int rowCount = costing_alt1LoadResponse.Items.Count;
			return (CostType, CopyRoutingFlag, rowCount);
		}

		public ICollectionLoadResponse NontableSelect(string CostingAlt, string CostingAltDescription, string BOMType, string CostType, string Whse, string DefaultWhse, int? CopyRouting)
		{
			var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "costing_alt", CostingAlt},
					{ "description", CostingAltDescription},
					{ "cost_type", stringUtil.IsNull(
						BOMType,
						CostType)},
					{ "whse", stringUtil.IsNull(
						Whse,
						DefaultWhse)},
					{ "copy_routing_flag", CopyRouting},
					{ "cost_roll_up_flag", 0},
			});

			return this.appDB.Load(nonTableLoadRequest);
		}
		public void NontableInsert(ICollectionLoadResponse nonTableLoadResponse)
		{
			var nonTableInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "costing_alt",
				items: nonTableLoadResponse.Items);

			this.appDB.Insert(nonTableInsertRequest);
		}

		public ICollectionLoadResponse ItemSelect(string PMTCode, string ABCCode, string CostMethod, string MatlType, string ProductCodeStarting, string ProductCodeEnding, string ItemStarting, string ItemEnding, string Whse, int? Suffix)
		{
			var itemLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"item","item.item"},
					{"cost_type","item.cost_type"},
					{"u_m","item.u_m"},
					{"drawing_nbr","item.drawing_nbr"},
					{"revision","item.revision"},
					{"product_code","item.product_code"},
					{"matl_cost","CAST (NULL AS DECIMAL)"},
					{"lbr_cost","CAST (NULL AS DECIMAL)"},
					{"fovhd_cost","CAST (NULL AS DECIMAL)"},
					{"vovhd_cost","CAST (NULL AS DECIMAL)"},
					{"out_cost","CAST (NULL AS DECIMAL)"},
					{"asm_setup","itemwhse.asm_setup"},
					{"asm_run","itemwhse.asm_run"},
					{"asm_matl","itemwhse.asm_matl"},
					{"asm_tool","itemwhse.asm_tool"},
					{"asm_fixture","itemwhse.asm_fixture"},
					{"asm_other","itemwhse.asm_other"},
					{"asm_fixed","itemwhse.asm_fixed"},
					{"asm_var","itemwhse.asm_var"},
					{"asm_outside","itemwhse.asm_outside"},
					{"comp_setup","itemwhse.comp_setup"},
					{"comp_run","itemwhse.comp_run"},
					{"comp_matl","itemwhse.comp_matl"},
					{"comp_tool","itemwhse.comp_tool"},
					{"comp_fixture","itemwhse.comp_fixture"},
					{"comp_other","itemwhse.comp_other"},
					{"comp_fixed","itemwhse.comp_fixed"},
					{"comp_var","itemwhse.comp_var"},
					{"comp_outside","itemwhse.comp_outside"},
					{"family_code","item.family_code"},
					{"u0","itemwhse.matl_cost"},
					{"u1","itemwhse.cur_matl_cost"},
					{"u2","itemwhse.lbr_cost"},
					{"u3","itemwhse.cur_lbr_cost"},
					{"u4","itemwhse.fovhd_cost"},
					{"u5","itemwhse.cur_fovhd_cost"},
					{"u6","itemwhse.vovhd_cost"},
					{"u7","itemwhse.cur_vovhd_cost"},
					{"u8","itemwhse.out_cost"},
					{"u9","itemwhse.cur_out_cost"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "item",
				fromClause: collectionLoadRequestFactory.Clause(@" inner join itemwhse on itemwhse.item = item.item
					and itemwhse.whse = {1} inner join job as j on item.job = j.job
					and j.suffix = {0}", Suffix, Whse),
				whereClause: collectionLoadRequestFactory.Clause("item.product_code BETWEEN {0} AND {1} AND item.item BETWEEN {2} AND {3} AND CHARINDEX(p_m_t_code, {6}) > 0 AND CHARINDEX(abc_code, {7}) > 0 AND CHARINDEX(cost_method, {4}) > 0 AND CHARINDEX(matl_type, {5}) > 0", ProductCodeStarting, ProductCodeEnding, ItemStarting, ItemEnding, CostMethod, MatlType, PMTCode, ABCCode),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(itemLoadRequest);
		}

		public void ItemInsert(ICollectionLoadResponse itemLoadResponse)
		{
			var itemInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#cai",
				items: itemLoadResponse.Items);

			this.appDB.Insert(itemInsertRequest);
		}

		public ICollectionLoadResponse Item1Select(string PMTCode, string ABCCode, string CostMethod, string MatlType, string ProductCodeStarting, string ProductCodeEnding, string ItemStarting, string ItemEnding, int? Suffix)
		{
			var item1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"item","item.item"},
					{"cost_type","item.cost_type"},
					{"u_m","item.u_m"},
					{"drawing_nbr","item.drawing_nbr"},
					{"revision","item.revision"},
					{"product_code","item.product_code"},
					{"matl_cost","CAST (NULL AS DECIMAL)"},
					{"lbr_cost","CAST (NULL AS DECIMAL)"},
					{"fovhd_cost","CAST (NULL AS DECIMAL)"},
					{"vovhd_cost","CAST (NULL AS DECIMAL)"},
					{"out_cost","CAST (NULL AS DECIMAL)"},
					{"asm_setup","item.asm_setup"},
					{"asm_run","item.asm_run"},
					{"asm_matl","item.asm_matl"},
					{"asm_tool","item.asm_tool"},
					{"asm_fixture","item.asm_fixture"},
					{"asm_other","item.asm_other"},
					{"asm_fixed","item.asm_fixed"},
					{"asm_var","item.asm_var"},
					{"asm_outside","item.asm_outside"},
					{"comp_setup","item.comp_setup"},
					{"comp_run","item.comp_run"},
					{"comp_matl","item.comp_matl"},
					{"comp_tool","item.comp_tool"},
					{"comp_fixture","item.comp_fixture"},
					{"comp_other","item.comp_other"},
					{"comp_fixed","item.comp_fixed"},
					{"comp_var","item.comp_var"},
					{"comp_outside","item.comp_outside"},
					{"family_code","item.family_code"},
					{"u0","item.matl_cost"},
					{"u1","item.cur_matl_cost"},
					{"u2","item.lbr_cost"},
					{"u3","item.cur_lbr_cost"},
					{"u4","item.fovhd_cost"},
					{"u5","item.cur_fovhd_cost"},
					{"u6","item.vovhd_cost"},
					{"u7","item.cur_vovhd_cost"},
					{"u8","item.out_cost"},
					{"u9","item.cur_out_cost"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "item",
				fromClause: collectionLoadRequestFactory.Clause(@" inner join job as j on item.job = j.job
					and j.suffix = {0}", Suffix),
				whereClause: collectionLoadRequestFactory.Clause("item.product_code BETWEEN {0} AND {1} AND item.item BETWEEN {2} AND {3} AND CHARINDEX(item.p_m_t_code, {6}) > 0 AND CHARINDEX(item.abc_code, {7}) > 0 AND CHARINDEX(item.cost_method, {4}) > 0 AND CHARINDEX(item.matl_type, {5}) > 0", ProductCodeStarting, ProductCodeEnding, ItemStarting, ItemEnding, CostMethod, MatlType, PMTCode, ABCCode),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(item1LoadRequest);
		}

		public void Item1Insert(ICollectionLoadResponse item1LoadResponse)
		{
			var item1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#cai",
				items: item1LoadResponse.Items);

			this.appDB.Insert(item1InsertRequest);
		}

		public ICollectionLoadResponse Cai1Select(string CostingAltFrom, string PMTCode, string ABCCode, string CostMethod, string MatlType, string ProductCodeStarting, string ProductCodeEnding, string ItemStarting, string ItemEnding)
		{
			var cai1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"item","costing_alt_item.item"},
					{"cost_type","costing_alt_item.cost_type"},
					{"u_m","costing_alt_item.u_m"},
					{"drawing_nbr","costing_alt_item.drawing_nbr"},
					{"revision","costing_alt_item.revision"},
					{"product_code","costing_alt_item.product_code"},
					{"matl_cost","costing_alt_item.matl_cost"},
					{"lbr_cost","costing_alt_item.lbr_cost"},
					{"fovhd_cost","costing_alt_item.fovhd_cost"},
					{"vovhd_cost","costing_alt_item.vovhd_cost"},
					{"out_cost","costing_alt_item.out_cost"},
					{"asm_setup","costing_alt_item.asm_setup"},
					{"asm_run","costing_alt_item.asm_run"},
					{"asm_matl","costing_alt_item.asm_matl"},
					{"asm_tool","costing_alt_item.asm_tool"},
					{"asm_fixture","costing_alt_item.asm_fixture"},
					{"asm_other","costing_alt_item.asm_other"},
					{"asm_fixed","costing_alt_item.asm_fixed"},
					{"asm_var","costing_alt_item.asm_var"},
					{"asm_outside","costing_alt_item.asm_outside"},
					{"comp_setup","costing_alt_item.comp_setup"},
					{"comp_run","costing_alt_item.comp_run"},
					{"comp_matl","costing_alt_item.comp_matl"},
					{"comp_tool","costing_alt_item.comp_tool"},
					{"comp_fixture","costing_alt_item.comp_fixture"},
					{"comp_other","costing_alt_item.comp_other"},
					{"comp_fixed","costing_alt_item.comp_fixed"},
					{"comp_var","costing_alt_item.comp_var"},
					{"comp_outside","costing_alt_item.comp_outside"},
					{"family_code","costing_alt_item.family_code"},
				},
				loadForChange: false,
                lockingType: LockingType.None,
                tableName: "costing_alt_item",
				fromClause: collectionLoadRequestFactory.Clause(@" INNER JOIN item ON item.item = costing_alt_item.item INNER JOIN job AS j ON j.job = costing_alt_item.job
					AND j.suffix = costing_alt_item.suffix"),
				whereClause: collectionLoadRequestFactory.Clause("costing_alt_item.costing_alt = {2} AND costing_alt_item.product_code BETWEEN {0} AND {1} AND costing_alt_item.item BETWEEN {3} AND {4} AND CHARINDEX(item.p_m_t_code, {7}) > 0 AND CHARINDEX(item.abc_code, {8}) > 0 AND CHARINDEX(item.cost_method, {5}) > 0 AND CHARINDEX(item.matl_type, {6}) > 0", ProductCodeStarting, ProductCodeEnding, CostingAltFrom, ItemStarting, ItemEnding, CostMethod, MatlType, PMTCode, ABCCode),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(cai1LoadRequest);
		}

		public void Cai1Insert(ICollectionLoadResponse cai1LoadResponse)
		{
			var cai1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#cai",
				items: cai1LoadResponse.Items);

			this.appDB.Insert(cai1InsertRequest);
		}

		public ICollectionLoadResponse Costing_Alt_ItemSelect(string CostingAlt)
		{
			var costing_alt_itemLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"costing_alt",$"{variableUtil.GetQuotedValue<string>(CostingAlt)}"},
					{"item","#cai.item"},
					{"cost_type","#cai.cost_type"},
					{"u_m","#cai.u_m"},
					{"drawing_nbr","#cai.drawing_nbr"},
					{"revision","#cai.revision"},
					{"product_code","#cai.product_code"},
					{"matl_cost","#cai.matl_cost"},
					{"lbr_cost","#cai.lbr_cost"},
					{"fovhd_cost","#cai.fovhd_cost"},
					{"vovhd_cost","#cai.vovhd_cost"},
					{"out_cost","#cai.out_cost"},
					{"asm_setup","#cai.asm_setup"},
					{"asm_run","#cai.asm_run"},
					{"asm_matl","#cai.asm_matl"},
					{"asm_tool","#cai.asm_tool"},
					{"asm_fixture","#cai.asm_fixture"},
					{"asm_other","#cai.asm_other"},
					{"asm_fixed","#cai.asm_fixed"},
					{"asm_var","#cai.asm_var"},
					{"asm_outside","#cai.asm_outside"},
					{"comp_setup","#cai.comp_setup"},
					{"comp_run","#cai.comp_run"},
					{"comp_matl","#cai.comp_matl"},
					{"comp_tool","#cai.comp_tool"},
					{"comp_fixture","#cai.comp_fixture"},
					{"comp_other","#cai.comp_other"},
					{"comp_fixed","#cai.comp_fixed"},
					{"comp_var","#cai.comp_var"},
					{"comp_outside","#cai.comp_outside"},
					{"family_code","#cai.family_code"},
					{"cost_roll_up_flag","0"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "#cai",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("NOT EXISTS (SELECT 1 FROM costing_alt_item WHERE costing_alt_item.costing_alt = {0} AND costing_alt_item.item = #cai.item)", CostingAlt),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(costing_alt_itemLoadRequest);
		}

		public void Costing_Alt_ItemInsert(ICollectionLoadResponse costing_alt_itemLoadResponse)
		{
			var costing_alt_itemInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "costing_alt_item",
				items: costing_alt_itemLoadResponse.Items);

			this.appDB.Insert(costing_alt_itemInsertRequest);
		}

		public (string CostType, int? CopyRoutingFlag, int? rowCount) Costing_Alt2Load(string CostingAlt, int? CopyRoutingFlag, string CostType)
		{
			CostTypeType _CostType = DBNull.Value;
			ListYesNoType _CopyRoutingFlag = DBNull.Value;

			var costing_alt2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_CostType,"cost_type"},
					{_CopyRoutingFlag,"copy_routing_flag"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "costing_alt",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("costing_alt = {0}", CostingAlt),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var costing_alt2LoadResponse = this.appDB.Load(costing_alt2LoadRequest);
			if (costing_alt2LoadResponse.Items.Count > 0)
			{
				CostType = _CostType;
				CopyRoutingFlag = _CopyRoutingFlag;
			}

			int rowCount = costing_alt2LoadResponse.Items.Count;
			return (CostType, CopyRoutingFlag, rowCount);
		}

		public bool Costing_Alt_Item1ForExists(string CostingAltFrom)
		{
			return existsChecker.Exists(tableName: "costing_alt_item",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("costing_alt = {0}", CostingAltFrom));
		}

		public ICollectionLoadResponse Cai2Select(string CostingAlt, string CostingAltFrom, int? Suffix)
		{
			var itemCrsLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"#cai.item","#cai.item"},
					{"FromRoute.job","FromRoute.job"},
					{"ToRoute.job","ToRoute.job"},
					{"job.suffix","job.suffix"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "#cai",
				fromClause: collectionLoadRequestFactory.Clause(@" inner join costing_alt_item as fromroute on fromroute.costing_alt = {0}
					and fromroute.item = #cai.item inner join costing_alt_item as toroute on toroute.costing_alt = {1}
					and toroute.item = #cai.item left outer join job on job.job = fromroute.job
					and job.suffix = {2}", CostingAltFrom, CostingAlt, Suffix),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));

			return this.appDB.Load(itemCrsLoadRequestForCursor);
		}


		public ICollectionLoadResponse Cai3Select(int? Suffix, string CostingAlt)
		{
			var itemCrsLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"#cai.item","#cai.item"},
						{"item.job","item.job"},
						{"ToRoute.job","ToRoute.job"},
						{"col3",$"{variableUtil.GetQuotedValue<int?>(Suffix)}"},
					},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "#cai",
				fromClause: collectionLoadRequestFactory.Clause(@" inner join item on #cai.item = item.item inner join costing_alt_item as toroute on toroute.costing_alt = {0}
						and toroute.item = #cai.item", CostingAlt),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));

			return this.appDB.Load(itemCrsLoadRequestForCursor);
		}
		public ICollectionLoadResponse Nontable1Select(string Item, string FromJob, string ToJob, int? NewJobFlag, int? FromSuffix)
		{
			var nonTable1LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
				{
						{ "alt_item", Item},
						{ "from_job", FromJob},
						{ "to_job", ToJob},
						{ "suffix", stringUtil.IsNull(
							FromSuffix,
							0)},
						{ "NewJobFlag", NewJobFlag},
				});

			return this.appDB.Load(nonTable1LoadRequest);
		}
		public void Nontable1Insert(ICollectionLoadResponse nonTable1LoadResponse)
		{
			var nonTable1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#route",
				items: nonTable1LoadResponse.Items);

			this.appDB.Insert(nonTable1InsertRequest);
		}

		public ICollectionLoadResponse JrtresourcegroupSelect(int? CopyRoutingFlag)
		{
			var jrtresourcegroupLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"job","job"},
					},
				tableName: "jrtresourcegroup", 
                loadForChange: true, 
                lockingType: LockingType.None,
                fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("job IN (SELECT to_job FROM #route WHERE NewJobFlag = 1 OR {0} = 0)", CopyRoutingFlag),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(jrtresourcegroupLoadRequest);
		}

		public void JrtresourcegroupDelete(ICollectionLoadResponse jrtresourcegroupLoadResponse)
		{
			var jrtresourcegroupDeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "jrtresourcegroup",
				items: jrtresourcegroupLoadResponse.Items);
			this.appDB.Delete(jrtresourcegroupDeleteRequest);
		}

		public ICollectionLoadResponse JobmatlSelect(int? CopyRoutingFlag)
		{
			var jobmatlLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"job","job"},
					},
				tableName: "jobmatl", 
                loadForChange: true, 
                lockingType: LockingType.None,
                fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("job IN (SELECT to_job FROM #route WHERE NewJobFlag = 1 OR {0} = 0)", CopyRoutingFlag),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(jobmatlLoadRequest);
		}

		public void JobmatlDelete(ICollectionLoadResponse jobmatlLoadResponse)
		{
			var jobmatlDeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "jobmatl",
				items: jobmatlLoadResponse.Items);
			this.appDB.Delete(jobmatlDeleteRequest);
		}

		public ICollectionLoadResponse Jrt_SchSelect(int? CopyRoutingFlag)
		{
			var jrt_schLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"job","job"},
					},
				tableName: "jrt_sch", 
                loadForChange: true, 
                lockingType: LockingType.None,
                fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("job IN (SELECT to_job FROM #route WHERE NewJobFlag = 1 OR {0} = 0)", CopyRoutingFlag),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(jrt_schLoadRequest);
		}

		public void Jrt_SchDelete(ICollectionLoadResponse jrt_schLoadResponse)
		{
			var jrt_schDeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "jrt_sch",
				items: jrt_schLoadResponse.Items);
			this.appDB.Delete(jrt_schDeleteRequest);
		}

		public ICollectionLoadResponse JobrouteSelect(int? CopyRoutingFlag)
		{
			var jobrouteLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"job","job"},
					},
				tableName: "jobroute",
                loadForChange: true, 
                lockingType: LockingType.None,
                fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("job IN (SELECT to_job FROM #route WHERE NewJobFlag = 1 OR {0} = 0)", CopyRoutingFlag),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(jobrouteLoadRequest);
		}

		public void JobrouteDelete(ICollectionLoadResponse jobrouteLoadResponse)
		{
			var jobrouteDeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "jobroute",
				items: jobrouteLoadResponse.Items);
			this.appDB.Delete(jobrouteDeleteRequest);
		}

		public ICollectionLoadResponse Job_SchSelect(int? CopyRoutingFlag)
		{
			var job_schLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"job","job"},
					},
				tableName: "job_sch", 
                loadForChange: true, 
                lockingType: LockingType.None,
                fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("job IN (SELECT to_job FROM #route WHERE NewJobFlag = 1 OR {0} = 0)", CopyRoutingFlag),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(job_schLoadRequest);
		}

		public void Job_SchDelete(ICollectionLoadResponse job_schLoadResponse)
		{
			var job_schDeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "job_sch",
				items: job_schLoadResponse.Items);
			this.appDB.Delete(job_schDeleteRequest);
		}

		public ICollectionLoadResponse JobSelect(int? CopyRoutingFlag)
		{
			var jobLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"job","job"},
					},
				tableName: "job", 
                loadForChange: true, 
                lockingType: LockingType.None,
                fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("job IN (SELECT to_job FROM #route WHERE NewJobFlag = 1 OR {0} = 0)", CopyRoutingFlag),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(jobLoadRequest);
		}

		public void JobDelete(ICollectionLoadResponse jobLoadResponse)
		{
			var jobDeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "job",
				items: jobLoadResponse.Items);
			this.appDB.Delete(jobDeleteRequest);
		}

		public ICollectionLoadResponse Costing_Alt_Item2Select(string CostingAlt)
		{
			var costing_alt_item2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"job","costing_alt_item.job"},
						{"suffix","costing_alt_item.suffix"},
						{"u0","#route.to_job"},
						{"u1","#route.suffix"},
					},
				tableName: "costing_alt_item", 
                loadForChange: true, 
                lockingType: LockingType.UPDLock,
                fromClause: collectionLoadRequestFactory.Clause(@" inner join #route on costing_alt_item.costing_alt = {0}
						and costing_alt_item.item = #route.alt_item
						and (isnull(costing_alt_item.job, '') != #route.to_job
							or costing_alt_item.suffix != #route.suffix)", CostingAlt),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(costing_alt_item2LoadRequest);
		}

		public void Costing_Alt_Item2Update(ICollectionLoadResponse costing_alt_item2LoadResponse)
		{
			foreach (var costing_alt_item2Item in costing_alt_item2LoadResponse.Items)
			{
				costing_alt_item2Item.SetValue<string>("job", costing_alt_item2Item.GetDeletedValue<string>("u0"));
				costing_alt_item2Item.SetValue<int?>("suffix", costing_alt_item2Item.GetDeletedValue<int?>("u1"));
			};

			var costing_alt_item2RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "costing_alt_item",
				items: costing_alt_item2LoadResponse.Items);

			this.appDB.Update(costing_alt_item2RequestUpdate);
		}

		public ICollectionLoadResponse Job1Select(int? CopyRoutingFlag)
		{
			var job1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"type","'A'"},
						{"job","#route.to_job"},
						{"suffix","#route.suffix"},
						{"job_date","job_date"},
						{"cust_num","cust_num"},
						{"ord_type","ord_type"},
						{"ord_num","ord_num"},
						{"ord_line","ord_line"},
						{"ord_release","ord_release"},
						{"est_job","est_job"},
						{"est_suf","est_suf"},
						{"item","item"},
						{"qty_released","qty_released"},
						{"qty_complete","qty_complete"},
						{"qty_scrapped","qty_scrapped"},
						{"stat","stat"},
						{"lst_trx_date","lst_trx_date"},
						{"root_job","root_job"},
						{"root_suf","root_suf"},
						{"ref_job","ref_job"},
						{"ref_suf","ref_suf"},
						{"ref_oper","ref_oper"},
						{"ref_seq","ref_seq"},
						{"low_level","low_level"},
						{"effect_date","effect_date"},
						{"wip_acct","wip_acct"},
						{"wip_total","wip_total"},
						{"wip_complete","wip_complete"},
						{"wip_special","wip_special"},
						{"revision","revision"},
						{"picked","picked"},
						{"whse","whse"},
						{"jcb_acct","jcb_acct"},
						{"ps_num","ps_num"},
						{"wip_lbr_acct","wip_lbr_acct"},
						{"wip_fovhd_acct","wip_fovhd_acct"},
						{"wip_vovhd_acct","wip_vovhd_acct"},
						{"wip_out_acct","wip_out_acct"},
						{"wip_matl_total","wip_matl_total"},
						{"wip_lbr_total","wip_lbr_total"},
						{"wip_fovhd_total","wip_fovhd_total"},
						{"wip_vovhd_total","wip_vovhd_total"},
						{"wip_out_total","wip_out_total"},
						{"wip_matl_comp","wip_matl_comp"},
						{"wip_lbr_comp","wip_lbr_comp"},
						{"wip_fovhd_comp","wip_fovhd_comp"},
						{"wip_vovhd_comp","wip_vovhd_comp"},
						{"wip_out_comp","wip_out_comp"},
						{"rollup_date","rollup_date"},
						{"wip_acct_unit1","wip_acct_unit1"},
						{"wip_acct_unit2","wip_acct_unit2"},
						{"wip_acct_unit3","wip_acct_unit3"},
						{"wip_acct_unit4","wip_acct_unit4"},
						{"jcb_acct_unit1","jcb_acct_unit1"},
						{"jcb_acct_unit2","jcb_acct_unit2"},
						{"jcb_acct_unit3","jcb_acct_unit3"},
						{"jcb_acct_unit4","jcb_acct_unit4"},
						{"wip_lbr_acct_unit1","wip_lbr_acct_unit1"},
						{"wip_lbr_acct_unit2","wip_lbr_acct_unit2"},
						{"wip_lbr_acct_unit3","wip_lbr_acct_unit3"},
						{"wip_lbr_acct_unit4","wip_lbr_acct_unit4"},
						{"wip_fovhd_acct_unit1","wip_fovhd_acct_unit1"},
						{"wip_fovhd_acct_unit2","wip_fovhd_acct_unit2"},
						{"wip_fovhd_acct_unit3","wip_fovhd_acct_unit3"},
						{"wip_fovhd_acct_unit4","wip_fovhd_acct_unit4"},
						{"wip_vovhd_acct_unit1","wip_vovhd_acct_unit1"},
						{"wip_vovhd_acct_unit2","wip_vovhd_acct_unit2"},
						{"wip_vovhd_acct_unit3","wip_vovhd_acct_unit3"},
						{"wip_vovhd_acct_unit4","wip_vovhd_acct_unit4"},
						{"wip_out_acct_unit1","wip_out_acct_unit1"},
						{"wip_out_acct_unit2","wip_out_acct_unit2"},
						{"wip_out_acct_unit3","wip_out_acct_unit3"},
						{"wip_out_acct_unit4","wip_out_acct_unit4"},
						{"prod_mix","prod_mix"},
						{"description","description"},
						{"config_id","config_id"},
						{"co_product_mix","co_product_mix"},
						{"scheduled","scheduled"},
						{"export_type","export_type"},
						{"contains_tax_free_matl","contains_tax_free_matl"},
						{"midnight_of_job_sch_end_date","midnight_of_job_sch_end_date"},
						{"midnight_of_job_sch_compdate","midnight_of_job_sch_compdate"},
						{"rework","rework"},
						{"unlinked_xref","unlinked_xref"},
						{"prospect_id","prospect_id"},
						{"is_external","is_external"},
						{"preassign_lots","preassign_lots"},
						{"preassign_serials","preassign_serials"},
					},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "#route",
				fromClause: collectionLoadRequestFactory.Clause(@" INNER JOIN job ON job.job = #route.from_job
						AND job.suffix = #route.suffix"),
				whereClause: collectionLoadRequestFactory.Clause(" NewJobFlag = 1 OR {0} = 0", CopyRoutingFlag),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(job1LoadRequest);
		}

		public void Job1Insert(ICollectionLoadResponse job1LoadResponse)
		{
			var job1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "job",
				items: job1LoadResponse.Items);

			this.appDB.Insert(job1InsertRequest);
		}

		public ICollectionLoadResponse Job_Sch1Select(int? CopyRoutingFlag)
		{
			var job_sch1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"job","to_job"},
						{"suffix","suffix"},
					},
				loadForChange: false,
                lockingType: LockingType.None,
                tableName: "#route",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("to_job IS NOT NULL AND (NewJobFlag = 1 OR {0} = 0)", CopyRoutingFlag),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(job_sch1LoadRequest);
		}

		public void Job_Sch1Insert(ICollectionLoadResponse job_sch1LoadResponse)
		{
			var job_sch1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "job_sch",
				items: job_sch1LoadResponse.Items);

			this.appDB.Insert(job_sch1InsertRequest);
		}

		public ICollectionLoadResponse Jobroute1Select(int? CopyRoutingFlag)
		{
			var jobroute1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"job","#route.to_job"},
						{"suffix","#route.suffix"},
						{"oper_num","jobroute.oper_num"},
						{"wc","jobroute.wc"},
						{"setup_hrs_t","jobroute.setup_hrs_t"},
						{"setup_cost_t","jobroute.setup_cost_t"},
						{"complete","jobroute.complete"},
						{"setup_hrs_v","jobroute.setup_hrs_v"},
						{"wip_amt","jobroute.wip_amt"},
						{"qty_scrapped","jobroute.qty_scrapped"},
						{"qty_received","jobroute.qty_received"},
						{"qty_moved","jobroute.qty_moved"},
						{"qty_complete","jobroute.qty_complete"},
						{"effect_date","jobroute.effect_date"},
						{"obs_date","jobroute.obs_date"},
						{"bflush_type","jobroute.bflush_type"},
						{"run_basis_lbr","jobroute.run_basis_lbr"},
						{"run_basis_mch","jobroute.run_basis_mch"},
						{"fixovhd_t_lbr","jobroute.fixovhd_t_lbr"},
						{"fixovhd_t_mch","jobroute.fixovhd_t_mch"},
						{"varovhd_t_lbr","jobroute.varovhd_t_lbr"},
						{"varovhd_t_mch","jobroute.varovhd_t_mch"},
						{"run_hrs_t_lbr","jobroute.run_hrs_t_lbr"},
						{"run_hrs_t_mch","jobroute.run_hrs_t_mch"},
						{"run_hrs_v_lbr","jobroute.run_hrs_v_lbr"},
						{"run_hrs_v_mch","jobroute.run_hrs_v_mch"},
						{"run_cost_t_lbr","jobroute.run_cost_t_lbr"},
						{"cntrl_point","jobroute.cntrl_point"},
						{"setup_rate","jobroute.setup_rate"},
						{"efficiency","jobroute.efficiency"},
						{"fovhd_rate_mch","jobroute.fovhd_rate_mch"},
						{"vovhd_rate_mch","jobroute.vovhd_rate_mch"},
						{"run_rate_lbr","jobroute.run_rate_lbr"},
						{"varovhd_rate","jobroute.varovhd_rate"},
						{"fixovhd_rate","jobroute.fixovhd_rate"},
						{"wip_matl_amt","jobroute.wip_matl_amt"},
						{"wip_lbr_amt","jobroute.wip_lbr_amt"},
						{"wip_fovhd_amt","jobroute.wip_fovhd_amt"},
						{"wip_vovhd_amt","jobroute.wip_vovhd_amt"},
						{"wip_out_amt","jobroute.wip_out_amt"},
					},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "#route",
				fromClause: collectionLoadRequestFactory.Clause(@" INNER JOIN jobroute ON jobroute.job = #route.from_job
						AND jobroute.suffix = #route.suffix"),
				whereClause: collectionLoadRequestFactory.Clause(" NewJobFlag = 1 OR {0} = 0", CopyRoutingFlag),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(jobroute1LoadRequest);
		}

		public void Jobroute1Insert(ICollectionLoadResponse jobroute1LoadResponse)
		{
			var jobroute1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "jobroute",
				items: jobroute1LoadResponse.Items);

			this.appDB.Insert(jobroute1InsertRequest);
		}

		public ICollectionLoadResponse Jrt_Sch1Select(int? CopyRoutingFlag)
		{
			var jrt_sch1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"job","#route.to_job"},
						{"suffix","#route.suffix"},
						{"oper_num","jrt_sch.oper_num"},
						{"setup_ticks","jrt_sch.setup_ticks"},
						{"setup_hrs","jrt_sch.setup_hrs"},
						{"run_ticks_lbr","jrt_sch.run_ticks_lbr"},
						{"run_lbr_hrs","jrt_sch.run_lbr_hrs"},
						{"run_ticks_mch","jrt_sch.run_ticks_mch"},
						{"run_mch_hrs","jrt_sch.run_mch_hrs"},
						{"pcs_per_lbr_hr","jrt_sch.pcs_per_lbr_hr"},
						{"pcs_per_mch_hr","jrt_sch.pcs_per_mch_hr"},
						{"sched_ticks","jrt_sch.sched_ticks"},
						{"sched_hrs","jrt_sch.sched_hrs"},
						{"sched_off","jrt_sch.sched_off"},
						{"offset_hrs","jrt_sch.offset_hrs"},
						{"move_ticks","jrt_sch.move_ticks"},
						{"move_hrs","jrt_sch.move_hrs"},
						{"queue_ticks","jrt_sch.queue_ticks"},
						{"queue_hrs","jrt_sch.queue_hrs"},
						{"start_date","jrt_sch.start_date"},
						{"end_date","jrt_sch.end_date"},
						{"start_tick","jrt_sch.start_tick"},
						{"end_tick","jrt_sch.end_tick"},
						{"finish_hrs","jrt_sch.finish_hrs"},
						{"matrixtype","jrt_sch.matrixtype"},
						{"tabid","jrt_sch.tabid"},
						{"whenrule","jrt_sch.whenrule"},
						{"sched_drv","jrt_sch.sched_drv"},
						{"plannerstep","jrt_sch.plannerstep"},
						{"setuprgid","jrt_sch.setuprgid"},
						{"setuprule","jrt_sch.setuprule"},
						{"schedsteprule","jrt_sch.schedsteprule"},
						{"crsbrkrule","jrt_sch.crsbrkrule"},
						{"allow_reallocation","jrt_sch.allow_reallocation"},
						{"splitsize","jrt_sch.splitsize"},
						{"batch_definition_id","jrt_sch.batch_definition_id"},
						{"splitrule","jrt_sch.splitrule"},
						{"splitgroup","jrt_sch.splitgroup"},
						{"freeze_sch","jrt_sch.freeze_sch"},
						{"prod_batch_id","jrt_sch.prod_batch_id"},
					},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "#route",
				fromClause: collectionLoadRequestFactory.Clause(@" INNER JOIN jrt_sch ON jrt_sch.job = #route.from_job
						AND jrt_sch.suffix = #route.suffix"),
				whereClause: collectionLoadRequestFactory.Clause(" NewJobFlag = 1 OR {0} = 0", CopyRoutingFlag),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(jrt_sch1LoadRequest);
		}

		public void Jrt_Sch1Insert(ICollectionLoadResponse jrt_sch1LoadResponse)
		{
			var jrt_sch1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "jrt_sch",
				items: jrt_sch1LoadResponse.Items);

			this.appDB.Insert(jrt_sch1InsertRequest);
		}

		public ICollectionLoadResponse Jobmatl1Select(int? CopyRoutingFlag)
		{
			var jobmatl1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"job","#route.to_job"},
						{"suffix","#route.suffix"},
						{"oper_num","jobmatl.oper_num"},
						{"sequence","jobmatl.sequence"},
						{"matl_type","jobmatl.matl_type"},
						{"item","jobmatl.item"},
						{"matl_qty","jobmatl.matl_qty"},
						{"units","jobmatl.units"},
						{"cost","jobmatl.cost"},
						{"qty_issued","jobmatl.qty_issued"},
						{"a_cost","jobmatl.a_cost"},
						{"ref_type","jobmatl.ref_type"},
						{"ref_num","jobmatl.ref_num"},
						{"ref_line_suf","jobmatl.ref_line_suf"},
						{"ref_release","jobmatl.ref_release"},
						{"po_unit_cost","jobmatl.po_unit_cost"},
						{"effect_date","jobmatl.effect_date"},
						{"obs_date","jobmatl.obs_date"},
						{"scrap_fact","jobmatl.scrap_fact"},
						{"qty_var","jobmatl.qty_var"},
						{"fixovhd_t","jobmatl.fixovhd_t"},
						{"varovhd_t","jobmatl.varovhd_t"},
						{"feature","jobmatl.feature"},
						{"probable","jobmatl.probable"},
						{"opt_code","jobmatl.opt_code"},
						{"inc_price","jobmatl.inc_price"},
						{"description","jobmatl.description"},
						{"pick_date","jobmatl.pick_date"},
						{"bom_seq","jobmatl.bom_seq"},
						{"matl_qty_conv","jobmatl.matl_qty_conv"},
						{"u_m","jobmatl.u_m"},
						{"inc_price_conv","jobmatl.inc_price_conv"},
						{"cost_conv","jobmatl.cost_conv"},
						{"backflush","jobmatl.backflush"},
						{"bflush_loc","jobmatl.bflush_loc"},
						{"fmatlovhd","jobmatl.fmatlovhd"},
						{"vmatlovhd","jobmatl.vmatlovhd"},
						{"matl_cost","jobmatl.matl_cost"},
						{"lbr_cost","jobmatl.lbr_cost"},
						{"fovhd_cost","jobmatl.fovhd_cost"},
						{"vovhd_cost","jobmatl.vovhd_cost"},
						{"out_cost","jobmatl.out_cost"},
						{"a_matl_cost","jobmatl.a_matl_cost"},
						{"a_lbr_cost","jobmatl.a_lbr_cost"},
						{"a_fovhd_cost","jobmatl.a_fovhd_cost"},
						{"a_vovhd_cost","jobmatl.a_vovhd_cost"},
						{"a_out_cost","jobmatl.a_out_cost"},
						{"matl_cost_conv","jobmatl.matl_cost_conv"},
						{"lbr_cost_conv","jobmatl.lbr_cost_conv"},
						{"fovhd_cost_conv","jobmatl.fovhd_cost_conv"},
						{"vovhd_cost_conv","jobmatl.vovhd_cost_conv"},
						{"out_cost_conv","jobmatl.out_cost_conv"},
						{"alt_group","jobmatl.alt_group"},
						{"alt_group_rank","jobmatl.alt_group_rank"},
						{"planned_alternate","jobmatl.planned_alternate"},
						{"new_sequence","jobmatl.new_sequence"},
						{"manufacturer_id","jobmatl.manufacturer_id"},
						{"manufacturer_item","jobmatl.manufacturer_item"},
					},
				loadForChange: false,
                lockingType: LockingType.None,
                tableName: "#route",
				fromClause: collectionLoadRequestFactory.Clause(@" INNER JOIN jobmatl ON jobmatl.job = #route.from_job
						AND jobmatl.suffix = #route.suffix"),
				whereClause: collectionLoadRequestFactory.Clause(" NewJobFlag = 1 OR {0} = 0", CopyRoutingFlag),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(jobmatl1LoadRequest);
		}

		public void Jobmatl1Insert(ICollectionLoadResponse jobmatl1LoadResponse)
		{
			var jobmatl1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "jobmatl",
				items: jobmatl1LoadResponse.Items);

			this.appDB.Insert(jobmatl1InsertRequest);
		}

		public ICollectionLoadResponse Jrtresourcegroup1Select(int? CopyRoutingFlag)
		{
			var jrtresourcegroup1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"job","#route.to_job"},
						{"suffix","#route.suffix"},
						{"oper_num","res.oper_num"},
						{"rgid","res.rgid"},
						{"qty_resources","res.qty_resources"},
						{"NoteExistsFlag","res.NoteExistsFlag"},
						{"resactn","res.resactn"},
						{"sequence","sequence"},
					},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "#route",
				fromClause: collectionLoadRequestFactory.Clause(@" INNER JOIN jrtresourcegroup AS res ON res.job = #route.from_job
						AND res.suffix = #route.suffix"),
				whereClause: collectionLoadRequestFactory.Clause(" NewJobFlag = 1 OR {0} = 0", CopyRoutingFlag),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(jrtresourcegroup1LoadRequest);
		}

		public void Jrtresourcegroup1Insert(ICollectionLoadResponse jrtresourcegroup1LoadResponse)
		{
			var jrtresourcegroup1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "jrtresourcegroup",
				items: jrtresourcegroup1LoadResponse.Items);

			this.appDB.Insert(jrtresourcegroup1InsertRequest);
		}

		public ICollectionLoadResponse Costing_Alt_WcSelect(string CostingAlt)
		{
			var costing_alt_wcLoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{ "costing_alt", $"{variableUtil.GetQuotedValue<string>(CostingAlt)}" },
						{ "wc", "wc.wc" },
						{ "setup_rate", "wc.setup_rate" },
						{ "efficiency", "wc.efficiency" },
						{ "fovhd_rate_mch", "wc.fovhd_rate_mch" },
						{ "vovhd_rate_mch", "wc.vovhd_rate_mch" },
						{ "run_rate_lbr", "wc.run_rate_lbr" },
						{ "overhead", "wc.overhead" },
						{ "cost_roll_up_flag", "0" },
					},
				selectStatement: collectionLoadRequestFactory.Clause(@"SELECT Distinct @selectList
						FROM costing_alt_item
						INNER JOIN
						job
						ON costing_alt_item.item = job.item
						AND costing_alt_item.suffix = job.suffix
						AND job.type = 'A'
						INNER JOIN
						jobroute
						ON job.job = jobroute.job
						AND job.suffix = jobroute.suffix
						INNER JOIN
						wc WITH (READUNCOMMITTED)
						ON jobroute.wc = wc.wc
						WHERE costing_alt_item.costing_alt = {0}
						AND NOT EXISTS (SELECT 1
							FROM   costing_alt_wc AS cawc
							WHERE  cawc.costing_alt = {0}
							AND cawc.wc = wc.wc)", CostingAlt));

			return this.appDB.Load(costing_alt_wcLoadRequest);
		}

		public void Costing_Alt_WcInsert(ICollectionLoadResponse costing_alt_wcLoadResponse)
		{
			var costing_alt_wcInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "costing_alt_wc",
				items: costing_alt_wcLoadResponse.Items);

			this.appDB.Insert(costing_alt_wcInsertRequest);
		}

		public ICollectionLoadResponse Costing_Alt_DeptSelect(string CostingAlt)
		{
			var costing_alt_deptLoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{ "costing_alt", $"{variableUtil.GetQuotedValue<string>(CostingAlt)}" },
						{ "dept", "dept.dept" },
						{ "varovhd_rate", "dept.varovhd_rate" },
						{ "fixovhd_rate", "dept.fixovhd_rate" },
						{ "cost_roll_up_flag", "0" },
					},
				selectStatement: collectionLoadRequestFactory.Clause(@"SELECT Distinct @selectList
						FROM costing_alt_item
						INNER JOIN
						job
						ON costing_alt_item.item = job.item
						AND costing_alt_item.suffix = job.suffix
						AND job.type = 'A'
						INNER JOIN
						jobroute
						ON job.job = jobroute.job
						AND job.suffix = jobroute.suffix
						INNER JOIN
						wc WITH (READUNCOMMITTED)
						ON jobroute.wc = wc.wc
						INNER JOIN
						dept WITH (READUNCOMMITTED)
						ON wc.dept = dept.dept
						WHERE costing_alt_item.costing_alt = {0}
						AND NOT EXISTS (SELECT 1
							FROM   costing_alt_dept AS cadt
							WHERE  cadt.costing_alt = {0}
							AND cadt.dept = dept.dept)", CostingAlt));

			return this.appDB.Load(costing_alt_deptLoadRequest);
		}

		public void Costing_Alt_DeptInsert(ICollectionLoadResponse costing_alt_deptLoadResponse)
		{
			var costing_alt_deptInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "costing_alt_dept",
				items: costing_alt_deptLoadResponse.Items);

			this.appDB.Insert(costing_alt_deptInsertRequest);
		}

		public ICollectionLoadResponse Costing_Alt_MaterialSelect(string CostingAlt, string Whse)
		{
           
            var costing_alt_materialLoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{ "costing_alt", $"{variableUtil.GetQuotedValue<string>(CostingAlt)}" },
						{ "item", "item.item" },
						{ "cost_type", "item.cost_type" },
						{ "u_m", "item.u_m" },
						{ "product_code", "item.product_code" },
						{ "unit_matl_cost", $"CASE WHEN {variableUtil.GetQuotedValue<int?>(Cost_Item_At_Whse)} = 1 THEN itemwhse.cur_mat_cost ELSE item.cur_mat_cost END" },
						{ "unit_duty_cost", $"CASE WHEN {variableUtil.GetQuotedValue<int?>(Cost_Item_At_Whse)} = 1 THEN itemwhse.cur_duty_cost ELSE item.cur_duty_cost END" },
						{ "unit_freight_cost", $"CASE WHEN {variableUtil.GetQuotedValue<int?>(Cost_Item_At_Whse)} = 1 THEN itemwhse.cur_freight_cost ELSE item.cur_freight_cost END" },
						{ "unit_brokerage_cost", $"CASE WHEN {variableUtil.GetQuotedValue<int?>(Cost_Item_At_Whse)} = 1 THEN itemwhse.cur_brokerage_cost ELSE item.cur_brokerage_cost END" },
						{ "unit_insurance", $"CASE WHEN {variableUtil.GetQuotedValue<int?>(Cost_Item_At_Whse)} = 1 THEN itemwhse.cur_insurance_cost ELSE item.cur_insurance_cost END" },
						{ "unit_loc_frt", $"CASE WHEN {variableUtil.GetQuotedValue<int?>(Cost_Item_At_Whse)} = 1 THEN itemwhse.cur_loc_frt_cost ELSE item.cur_loc_frt_cost END" },
						{ "cost_roll_up_flag", "1" },
					},
				selectStatement: collectionLoadRequestFactory.Clause(@"SELECT Distinct @selectList
						FROM costing_alt_item
						INNER JOIN
						job
						ON costing_alt_item.item = job.item
						AND costing_alt_item.suffix = job.suffix
						AND job.type = 'A'
						INNER JOIN
						jobmatl
						ON job.job = jobmatl.job
						AND job.suffix = jobmatl.suffix
						INNER JOIN
						item
						ON jobmatl.item = item.item
						AND item.p_m_t_code <> 'M'
						LEFT OUTER JOIN
						itemwhse
						ON itemwhse.item = item.item
						AND itemwhse.whse = {1}
						WHERE costing_alt_item.costing_alt = {0}
						AND NOT EXISTS (SELECT 1
							FROM   costing_alt_material AS camt
							WHERE  camt.costing_alt = {0}
							AND camt.item = item.item)", CostingAlt, Whse));

			return this.appDB.Load(costing_alt_materialLoadRequest);
		}

		public void Costing_Alt_MaterialInsert(ICollectionLoadResponse costing_alt_materialLoadResponse)
		{
			var costing_alt_materialInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "costing_alt_material",
				items: costing_alt_materialLoadResponse.Items);

			this.appDB.Insert(costing_alt_materialInsertRequest);
		}

		public ICollectionLoadResponse Costing_Alt_Product_CodeSelect(string CostingAlt)
		{
			var costing_alt_product_codeLoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{ "costing_alt", $"{variableUtil.GetQuotedValue<string>(CostingAlt)}" },
						{ "product_code", "prodcode.product_code" },
						{ "markup", "prodcode.markup" },
						{ "fmatlovhd", "prodcode.fmatlovhd" },
						{ "vmatlovhd", "prodcode.vmatlovhd" },
						{ "purchovhd", "prodcode.purchovhd" },
						{ "cost_roll_up_flag", "0" },
					},
				selectStatement: collectionLoadRequestFactory.Clause(@"SELECT Distinct @selectList
						FROM costing_alt_material
						INNER JOIN
						prodcode
						ON costing_alt_material.product_code = prodcode.product_code
						WHERE costing_alt_material.costing_alt = {0}
						AND NOT EXISTS (SELECT 1
							FROM   costing_alt_product_code AS capc
							WHERE  capc.costing_alt = {0}
							AND capc.product_code = costing_alt_material.product_code)", CostingAlt));

			return this.appDB.Load(costing_alt_product_codeLoadRequest);
		}

		public void Costing_Alt_Product_CodeInsert(ICollectionLoadResponse costing_alt_product_codeLoadResponse)
		{
			var costing_alt_product_codeInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "costing_alt_product_code",
				items: costing_alt_product_codeLoadResponse.Items);

			this.appDB.Insert(costing_alt_product_codeInsertRequest);
		}

		public ICollectionLoadResponse Costing_Alt_Product_Code1Select(string CostingAlt, string CostingAltFrom)
		{
			var costing_alt_product_code1LoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{ "costing_alt", $"{variableUtil.GetQuotedValue<string>(CostingAlt)}" },
						{ "product_code", "product_code" },
						{ "markup", "markup" },
						{ "fmatlovhd", "fmatlovhd" },
						{ "vmatlovhd", "vmatlovhd" },
						{ "purchovhd", "purchovhd" },
						{ "cost_roll_up_flag", "cost_roll_up_flag" },
					},
				selectStatement: collectionLoadRequestFactory.Clause(@"SELECT Distinct @selectList
						FROM costing_alt_product_code AS pc
						WHERE costing_alt = {0}
						AND NOT EXISTS (SELECT 1
							FROM   costing_alt_product_code AS capc
							WHERE  capc.costing_alt = {1}
							AND capc.product_code = pc.product_code)", CostingAltFrom, CostingAlt));

			return this.appDB.Load(costing_alt_product_code1LoadRequest);
		}

		public void Costing_Alt_Product_Code1Insert(ICollectionLoadResponse costing_alt_product_code1LoadResponse)
		{
			var costing_alt_product_code1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "costing_alt_product_code",
				items: costing_alt_product_code1LoadResponse.Items);

			this.appDB.Insert(costing_alt_product_code1InsertRequest);
		}

		public ICollectionLoadResponse Costing_Alt_Wc1Select(string CostingAlt, string CostingAltFrom)
		{
			var costing_alt_wc1LoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{ "costing_alt", $"{variableUtil.GetQuotedValue<string>(CostingAlt)}" },
						{ "wc", "wc" },
						{ "setup_rate", "setup_rate" },
						{ "efficiency", "efficiency" },
						{ "fovhd_rate_mch", "fovhd_rate_mch" },
						{ "vovhd_rate_mch", "vovhd_rate_mch" },
						{ "run_rate_lbr", "run_rate_lbr" },
						{ "overhead", "overhead" },
						{ "cost_roll_up_flag", "cost_roll_up_flag" },
					},
				selectStatement: collectionLoadRequestFactory.Clause(@"SELECT Distinct @selectList
						FROM costing_alt_wc AS wc
						WHERE costing_alt = {0}
						AND NOT EXISTS (SELECT 1
							FROM   costing_alt_wc AS cawc
							WHERE  cawc.costing_alt = {1}
							AND cawc.wc = wc.wc)", CostingAltFrom, CostingAlt));

			return this.appDB.Load(costing_alt_wc1LoadRequest);
		}

		public void Costing_Alt_Wc1Insert(ICollectionLoadResponse costing_alt_wc1LoadResponse)
		{
			var costing_alt_wc1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "costing_alt_wc",
				items: costing_alt_wc1LoadResponse.Items);

			this.appDB.Insert(costing_alt_wc1InsertRequest);
		}

		public ICollectionLoadResponse Costing_Alt_Dept1Select(string CostingAlt, string CostingAltFrom)
		{
			var costing_alt_dept1LoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{ "costing_alt", $"{variableUtil.GetQuotedValue<string>(CostingAlt)}" },
						{ "dept", "dept" },
						{ "varovhd_rate", "varovhd_rate" },
						{ "fixovhd_rate", "fixovhd_rate" },
						{ "cost_roll_up_flag", "cost_roll_up_flag" },
					},
				selectStatement: collectionLoadRequestFactory.Clause(@"SELECT Distinct @selectList
						FROM costing_alt_dept AS dt
						WHERE costing_alt = {0}
						AND NOT EXISTS (SELECT 1
							FROM   costing_alt_dept AS cadt
							WHERE  cadt.costing_alt = {1}
							AND cadt.dept = dt.dept)", CostingAltFrom, CostingAlt));

			return this.appDB.Load(costing_alt_dept1LoadRequest);
		}

		public void Costing_Alt_Dept1Insert(ICollectionLoadResponse costing_alt_dept1LoadResponse)
		{
			var costing_alt_dept1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "costing_alt_dept",
				items: costing_alt_dept1LoadResponse.Items);

			this.appDB.Insert(costing_alt_dept1InsertRequest);
		}

		public ICollectionLoadResponse Costing_Alt_Material1Select(string CostingAlt, string CostingAltFrom)
		{
			var costing_alt_material1LoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{ "costing_alt", $"{variableUtil.GetQuotedValue<string>(CostingAlt)}" },
						{ "item", "item" },
						{ "cost_type", "cost_type" },
						{ "u_m", "u_m" },
						{ "product_code", "product_code" },
						{ "unit_matl_cost", "unit_matl_cost" },
						{ "unit_duty_cost", "unit_duty_cost" },
						{ "unit_freight_cost", "unit_freight_cost" },
						{ "unit_brokerage_cost", "unit_brokerage_cost" },
						{ "cost_roll_up_flag", "cost_roll_up_flag" },
					},
				selectStatement: collectionLoadRequestFactory.Clause(@"SELECT Distinct @selectList
						FROM costing_alt_material AS mt
						WHERE costing_alt = {0}
						AND NOT EXISTS (SELECT 1
							FROM   costing_alt_material AS camt
							WHERE  camt.costing_alt = {1}
							AND camt.item = mt.item)", CostingAltFrom, CostingAlt));

			return this.appDB.Load(costing_alt_material1LoadRequest);
		}

		public void Costing_Alt_Material1Insert(ICollectionLoadResponse costing_alt_material1LoadResponse)
		{
			var costing_alt_material1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "costing_alt_material",
				items: costing_alt_material1LoadResponse.Items);

			this.appDB.Insert(costing_alt_material1InsertRequest);
		}

		public (int? ReturnCode,
			string Infobar)
		AltExtGen_CopyCostingAnalysisAlternativeSp(
			string AltExtGenSp,
			string CostingAlt,
			string CostingAltDescription,
			string BOMType,
			string Whse,
			string CostingAltFrom,
			int? CopyRouting,
			string PMTCode,
			string ABCCode,
			string CostMethod,
			string MatlType,
			string ProductCodeStarting,
			string ProductCodeEnding,
			string ItemStarting,
			string ItemEnding,
			string Infobar)
		{
			CostingAlternativeType _CostingAlt = CostingAlt;
			DescriptionType _CostingAltDescription = CostingAltDescription;
			CostTypeType _BOMType = BOMType;
			WhseType _Whse = Whse;
			CostingAlternativeType _CostingAltFrom = CostingAltFrom;
			ListYesNoType _CopyRouting = CopyRouting;
			StringType _PMTCode = PMTCode;
			StringType _ABCCode = ABCCode;
			StringType _CostMethod = CostMethod;
			StringType _MatlType = MatlType;
			ProductCodeType _ProductCodeStarting = ProductCodeStarting;
			ProductCodeType _ProductCodeEnding = ProductCodeEnding;
			ItemType _ItemStarting = ItemStarting;
			ItemType _ItemEnding = ItemEnding;
			InfobarType _Infobar = Infobar;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;

				appDB.AddCommandParameter(cmd, "CostingAlt", _CostingAlt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CostingAltDescription", _CostingAltDescription, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BOMType", _BOMType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CostingAltFrom", _CostingAltFrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CopyRouting", _CopyRouting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMTCode", _PMTCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ABCCode", _ABCCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CostMethod", _CostMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlType", _MatlType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCodeStarting", _ProductCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCodeEnding", _ProductCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

				var Severity = appDB.ExecuteNonQuery(cmd);

				Infobar = _Infobar;

				return (Severity, Infobar);
			}
		}
	}

}

