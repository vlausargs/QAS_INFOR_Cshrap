//PROJECT NAME: Logistics
//CLASS NAME: CLM_POBuilderPLNDataCRUD.cs

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

namespace CSI.Logistics.Vendor
{
	public class CLM_POBuilderPLNDataCRUD : ICLM_POBuilderPLNDataCRUD
	{
		readonly IApplicationDB appDB;
		readonly ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
		readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly IExistsChecker existsChecker;
		readonly IVariableUtil variableUtil;
		readonly IStringUtil stringUtil;
		readonly ILogger logger;
		readonly ICollectionNonTriggerInsertRequestFactory collectionNonTriggerInsertRequestFactory;
		DateTime startTime;

		public CLM_POBuilderPLNDataCRUD(IApplicationDB appDB,
			ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
			ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			ICollectionLoadResponseUtil collectionLoadResponseUtil,
			IExistsChecker existsChecker,
			IVariableUtil variableUtil,
			IStringUtil stringUtil,
			ILogger logger,
			ICollectionNonTriggerInsertRequestFactory collectionNonTriggerInsertRequestFactory
			)
		{
			this.appDB = appDB;
			this.collectionLoadStatementRequestFactory = collectionLoadStatementRequestFactory;
			this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.existsChecker = existsChecker;
			this.variableUtil = variableUtil;
			this.stringUtil = stringUtil;
			this.logger = logger;
			this.collectionNonTriggerInsertRequestFactory = collectionNonTriggerInsertRequestFactory;
			
		}

		void LogTiming(string message)
		{
			var timing = DateTime.Now - startTime;
			logger.Performance(this.GetType().Name, $"{message} - {timing:c}");
			startTime = DateTime.Now;
		}



		public bool Optional_ModuleForExists()
		{
			return existsChecker.Exists(tableName:"optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_POBuilderPLNDataSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"));
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
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_POBuilderPLNDataSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			
			var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
			
			foreach(var optional_module1Item in optional_module1LoadResponse.Items){
				optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("CLM_POBuilderPLNDataSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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
		
		public ICollectionLoadResponse SiteSelect(string SiteGroup)
		{
			var site_group_cursorLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"site_group.site","site_group.site"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"site",
				fromClause: collectionLoadRequestFactory.Clause(", site_group"),
				whereClause: collectionLoadRequestFactory.Clause("site.intranet_name = (SELECT intranet_name FROM site INNER JOIN parms ON parms.site = site.site) AND site_group = {0} AND site.site = site_group.site",SiteGroup),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			
			var site_group_cursorLoadResponseForCursor = this.appDB.Load(site_group_cursorLoadRequestForCursor);
			return site_group_cursorLoadResponseForCursor;
		}
		public ICollectionLoadResponse Site1Select(string Site)
		{
			var site_group_cursorLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"site","site"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName: "site",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("site = {0}", Site),
				orderByClause: collectionLoadRequestFactory.Clause(""));

			var site_group_cursorLoadResponseForCursor = this.appDB.Load(site_group_cursorLoadRequestForCursor);
			return site_group_cursorLoadResponseForCursor;
		}
			public (string AppDataBase, int? rowCount) Site2Load(string All_Sites, string AppDataBase)
			{
				OSLocationType _AppDataBase = DBNull.Value;
				
				var site2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
					{
						{_AppDataBase,"site.app_db_name"},
					},
					loadForChange: false,
					lockingType: LockingType.None,
					tableName:"site",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause("site = {0}",All_Sites),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var site2LoadResponse = this.appDB.Load(site2LoadRequest);
				if(site2LoadResponse.Items.Count > 0)
				{
					AppDataBase = _AppDataBase;
				}
				
				int rowCount = site2LoadResponse.Items.Count;
				return (AppDataBase, rowCount);
			}
			
			public void Tv_Tt_Tmp_Po_Builder1Insert(int? Severity, string All_Sites, string Infobar, string SQL, string AppDataBase, ICollectionLoadResponse tv_tt_tmp_po_builder1ExecResultLoadResponse, string Where)
			{

			var tv_tt_tmp_po_builder1LoadRequest = collectionNonTriggerInsertRequestFactory.SQLInsert(
            targetTableName: "#tv_tt_tmp_po_builder1",
            targetColumns: new List<string>() { "to_site",
                                    "item",
                                    "description",
                                    "apsplan_RowPointer",
                                    "qty_ordered",
                                    "u_m",
                                    "due_date",
                                    "release_date",
                                    "unit_mat_cost",
                                    "unit_duty_cost",
                                    "unit_freight_cost",
                                    "unit_brokerage_cost",
                                    "unit_insurance_cost",
                                    "unit_local_frieght",
                                    "lead_time",
                                    "ref_num" },
            valuesByExpressionToAssign: new Dictionary<string,
            IParameterizedCommand>()
            {
                {"to_site", collectionNonTriggerInsertRequestFactory.Clause("site_ref")},
                {"item", collectionNonTriggerInsertRequestFactory.Clause("item")},
                {"description", collectionNonTriggerInsertRequestFactory.Clause("description")},
                {"apsplan_RowPointer", collectionNonTriggerInsertRequestFactory.Clause("rowpointer")},
                {"qty_ordered", collectionNonTriggerInsertRequestFactory.Clause("qty")},
                {"u_m", collectionNonTriggerInsertRequestFactory.Clause("u_m")},
                {"due_date", collectionNonTriggerInsertRequestFactory.Clause("due_date")},
                {"release_date", collectionNonTriggerInsertRequestFactory.Clause("start_date")},
                {"unit_mat_cost", collectionNonTriggerInsertRequestFactory.Clause("unit_mat_cost")},
                {"unit_duty_cost", collectionNonTriggerInsertRequestFactory.Clause("unit_duty_cost")},
                {"unit_freight_cost", collectionNonTriggerInsertRequestFactory.Clause("unit_freight_cost")},
                {"unit_brokerage_cost", collectionNonTriggerInsertRequestFactory.Clause("unit_brokerage_cost")},
                {"unit_insurance_cost", collectionNonTriggerInsertRequestFactory.Clause("unit_insurance_cost")},
                {"unit_local_frieght", collectionNonTriggerInsertRequestFactory.Clause("unit_loc_frt_cost")},
                {"lead_time", collectionNonTriggerInsertRequestFactory.Clause("lead_time")},
                {"ref_num", collectionNonTriggerInsertRequestFactory.Clause("ref_num")},
            },
            fromClause: collectionNonTriggerInsertRequestFactory.Clause("[" + AppDataBase + "]" + ".dbo.[vapsplan_" + AppDataBase + "]"),
            whereClause: collectionNonTriggerInsertRequestFactory.Clause(Where),
            orderByClause: collectionNonTriggerInsertRequestFactory.Clause("")
			
            );

            this.appDB.InsertWithoutTrigger(tv_tt_tmp_po_builder1LoadRequest);

        }

		public (int? Count, int? rowCount) Tv_Tt_Tmp_Po_Builder11Load(int? Count)
			{
				IntType _Count = DBNull.Value;
				
				var tv_tt_tmp_po_builder11LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
					{
						{_Count,"COUNT(*)"},
					},
					loadForChange: false,
					lockingType: LockingType.None,
					tableName:"#tv_tt_tmp_po_builder1",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause(""),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var tv_tt_tmp_po_builder11LoadResponse = this.appDB.Load(tv_tt_tmp_po_builder11LoadRequest);
				if(tv_tt_tmp_po_builder11LoadResponse.Items.Count > 0)
				{
					Count = _Count;
				}
				
				int rowCount = tv_tt_tmp_po_builder11LoadResponse.Items.Count;
				return (Count, rowCount);
			}

		public (string SiteRef,
			string Item,
			string Description,
			Guid? ApsPlanRowpointer,
			decimal? QtyOrdered,
			string UM,
			DateTime? DueDate,
			DateTime? ReleaseDate,
			decimal? UnitMatCost,
			decimal? UnitDutyCost,
			decimal? UnitFreightCost,
			decimal? UnitBrokerageCost,
			decimal? UnitInsuranceCost,
			decimal? UnitLocalFreight,
			int? LeadTime,
			string Reference, int? rowCount)
		Tv_Tt_Tmp_Po_Builder12Load(int? Index,
			int? Count,
			string Reference,
			string SiteRef,
			string Item,
			string Description,
			Guid? ApsPlanRowpointer,
			decimal? QtyOrdered,
			string UM,
			decimal? UnitMatCost,
			decimal? UnitDutyCost,
			decimal? UnitFreightCost,
			decimal? UnitBrokerageCost,
			decimal? UnitLocalFreight,
			decimal? UnitInsuranceCost,
			DateTime? ReleaseDate,
			DateTime? DueDate,
			int? LeadTime)
		{
			SiteType _SiteRef = DBNull.Value;
			ItemType _Item = DBNull.Value;
			DescriptionType _Description = DBNull.Value;
			RowPointerType _ApsPlanRowpointer = DBNull.Value;
			QtyUnitNoNegType _QtyOrdered = DBNull.Value;
			UMType _UM = DBNull.Value;
			DateType _DueDate = DBNull.Value;
			DateType _ReleaseDate = DBNull.Value;
			CostPrcType _UnitMatCost = DBNull.Value;
			CostPrcType _UnitDutyCost = DBNull.Value;
			CostPrcType _UnitFreightCost = DBNull.Value;
			CostPrcType _UnitBrokerageCost = DBNull.Value;
			CostPrcType _UnitInsuranceCost = DBNull.Value;
			CostPrcType _UnitLocalFreight = DBNull.Value;
			LeadTimeType _LeadTime = DBNull.Value;
			StringType _Reference = DBNull.Value;

			var tv_tt_tmp_po_builder12LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
					{
						{_SiteRef,"to_site"},
						{_Item,"item"},
						{_Description,"description"},
						{_ApsPlanRowpointer,"apsplan_RowPointer"},
						{_QtyOrdered,"qty_ordered"},
						{_UM,"u_m"},
						{_DueDate,"due_date"},
						{_ReleaseDate,"release_date"},
						{_UnitMatCost,"unit_mat_cost"},
						{_UnitDutyCost,"unit_duty_cost"},
						{_UnitFreightCost,"unit_freight_cost"},
						{_UnitBrokerageCost,"unit_brokerage_cost"},
						{_UnitInsuranceCost,"unit_insurance_cost"},
						{_UnitLocalFreight,"unit_local_frieght"},
						{_LeadTime,"lead_time"},
						{_Reference,"ref_num"},
					},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName: "#tv_tt_tmp_po_builder1",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("ID = {0}", Index),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var tv_tt_tmp_po_builder12LoadResponse = this.appDB.Load(tv_tt_tmp_po_builder12LoadRequest);
			if (tv_tt_tmp_po_builder12LoadResponse.Items.Count > 0)
			{
				SiteRef = _SiteRef;
				Item = _Item;
				Description = _Description;
				ApsPlanRowpointer = _ApsPlanRowpointer;
				QtyOrdered = _QtyOrdered;
				UM = _UM;
				DueDate = _DueDate;
				ReleaseDate = _ReleaseDate;
				UnitMatCost = _UnitMatCost;
				UnitDutyCost = _UnitDutyCost;
				UnitFreightCost = _UnitFreightCost;
				UnitBrokerageCost = _UnitBrokerageCost;
				UnitInsuranceCost = _UnitInsuranceCost;
				UnitLocalFreight = _UnitLocalFreight;
				LeadTime = _LeadTime;
				Reference = _Reference;
			}

			int rowCount = tv_tt_tmp_po_builder12LoadResponse.Items.Count;
			return (SiteRef, Item, Description, ApsPlanRowpointer, QtyOrdered, UM, DueDate, ReleaseDate, UnitMatCost, UnitDutyCost, UnitFreightCost, UnitBrokerageCost, UnitInsuranceCost, UnitLocalFreight, LeadTime, Reference, rowCount);
		}

		public ICollectionLoadResponse NontableSelect(string SiteRef, string Item, string Description, Guid? ApsPlanRowpointer, decimal? QtyOrdered, string UM, DateTime? DueDate, DateTime? ReleaseDate, decimal? PlanCost, decimal? UnitMatCost, decimal? UnitDutyCost, decimal? UnitFreightCost, decimal? UnitBrokerageCost, decimal? UnitInsuranceCost, decimal? UnitLocalFreight, int? LeadTime, string Reference, decimal? ExtendedCost)
			{
				var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
				{
						{ "to_site", SiteRef},
						{ "item", Item},
						{ "description", Description},
						{ "apsplan_RowPointer", ApsPlanRowpointer},
						{ "qty_ordered", QtyOrdered},
						{ "qty_ordered_conv", QtyOrdered},
						{ "u_m", UM},
						{ "due_date", DueDate},
						{ "release_date", ReleaseDate},
						{ "plan_cost", PlanCost},
						{ "plan_cost_conv", PlanCost},
						{ "item_cost", PlanCost},
						{ "item_cost_conv", PlanCost},
						{ "unit_mat_cost", UnitMatCost},
						{ "unit_mat_cost_conv", UnitMatCost},
						{ "unit_duty_cost", UnitDutyCost},
						{ "unit_duty_cost_conv", UnitDutyCost},
						{ "unit_freight_cost", UnitFreightCost},
						{ "unit_freight_cost_conv", UnitFreightCost},
						{ "unit_brokerage_cost", UnitBrokerageCost},
						{ "unit_brokerage_cost_conv", UnitBrokerageCost},
						{ "unit_insurance_cost", UnitInsuranceCost},
						{ "unit_insurance_cost_conv", UnitInsuranceCost},
						{ "unit_local_frieght", UnitLocalFreight},
						{ "unit_local_freight_conv", UnitLocalFreight},
						{ "lead_time", LeadTime},
						{ "ref_num", Reference},
						{ "extended_cost", ExtendedCost},
						{ "extended_cost_conv", ExtendedCost},
				});
				
				return this.appDB.Load(nonTableLoadRequest);
			}

		public void NontableInsert(ICollectionLoadResponse nonTableLoadResponse)
		{
			var nonTableInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_tt_tmp_po_builder",
				items: nonTableLoadResponse.Items);

			this.appDB.Insert(nonTableInsertRequest);
		}

		public ICollectionLoadResponse DynamicparametersSelect(string SelectionClause, string FromClause, string WhereClause, string AdditionalClause, string KeyColumns, string FilterString)
		{
			var DynamicParametersLoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"SelectionClause",$"{variableUtil.GetQuotedValue<string>(SelectionClause)}"},
						{"FromClause",$"{variableUtil.GetQuotedValue<string>(FromClause)}"},
						{"WhereClause",$"{variableUtil.GetQuotedValue<string>(WhereClause)}"},
						{"AdditionalClause",$"{variableUtil.GetQuotedValue<string>(AdditionalClause)}"},
						{"KeyColumns",$"{variableUtil.GetQuotedValue<string>(KeyColumns)}"},
						{"FilterString",$"{variableUtil.GetQuotedValue<string>(FilterString)}"},
					},
				selectStatement: collectionLoadRequestFactory.Clause("SELECT @selectList"));

			return this.appDB.Load(DynamicParametersLoadRequest);
		}

		public void DynamicparametersInsert(ICollectionLoadResponse DynamicParametersLoadResponse)
		{
			var DynamicParametersInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#DynamicParameters",
				items: DynamicParametersLoadResponse.Items);

			this.appDB.Insert(DynamicParametersInsertRequest);
		}

		public ICollectionLoadResponse NontableSelect2()
		{
			var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
				{
						{ "to_site", "DALS"},
						{ "item", "zTest"},
						{ "description", ""},
						{ "apsplan_RowPointer", null},
						{ "qty_ordered", 0M},
						{ "qty_ordered_conv", 0M},
						{ "u_m", ""},
						{ "due_date", "2029-09-15 00:00:00.000"},
						{ "release_date", null},
						{ "plan_cost", 0M},
						{ "plan_cost_conv", 0M},
						{ "item_cost", 0M},
						{ "item_cost_conv", 0M},
						{ "unit_mat_cost", 0M},
						{ "unit_mat_cost_conv", 0M},
						{ "unit_duty_cost", 0M},
						{ "unit_duty_cost_conv", 0M},
						{ "unit_freight_cost", 0M},
						{ "unit_freight_cost_conv", 0M},
						{ "unit_brokerage_cost", 0M},
						{ "unit_brokerage_cost_conv", 0M},
						{ "unit_insurance_cost", 0M},
						{ "unit_insurance_cost_conv", 0M},
						{ "unit_local_frieght", 0M},
						{ "unit_local_freight_conv", 0M},
						{ "lead_time", 0M},
						{ "ref_num", "zrefnum"},
						{ "extended_cost", 0M},
						{ "extended_cost_conv", 0M},
				});

			return this.appDB.Load(nonTableLoadRequest);
		}
		
			public (
				ICollectionLoadResponse Data,
				int? ReturnCode)
			AltExtGen_CLM_POBuilderPLNDataSp(
				string AltExtGenSp,
				int? RecordCap,
				string Site,
				string SiteGroup,
				string ItemStarting,
				string ItemEnding,
				DateTime? StartingDueDate,
				DateTime? EndingDueDate,
				string Planner,
				string VendorCurrCode)
			{
				IntType _RecordCap = RecordCap;
				SiteType _Site = Site;
				SiteGroupType _SiteGroup = SiteGroup;
				ItemType _ItemStarting = ItemStarting;
				ItemType _ItemEnding = ItemEnding;
				DateType _StartingDueDate = StartingDueDate;
				DateType _EndingDueDate = EndingDueDate;
				UserCodeType _Planner = Planner;
				CurrCodeType _VendorCurrCode = VendorCurrCode;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = AltExtGenSp;
					
					appDB.AddCommandParameter(cmd, "RecordCap", _RecordCap, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "SiteGroup", _SiteGroup, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "StartingDueDate", _StartingDueDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndingDueDate", _EndingDueDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Planner", _Planner, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "VendorCurrCode", _VendorCurrCode, ParameterDirection.Input);
					
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
