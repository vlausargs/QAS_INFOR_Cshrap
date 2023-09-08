//PROJECT NAME: Logistics
//CLASS NAME: CLM_POBuilderPLNData.cs

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

namespace CSI.Logistics.Vendor
{
	public class CLM_POBuilderPLNData : ICLM_POBuilderPLNData
	{
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly ICSIRemoteMethodCall cSIRemoteMethodCall;
		readonly IExecuteDynamicSQL iExecuteDynamicSQL;
		readonly IScalarFunction scalarFunction;
		readonly IStringUtil stringUtil;
		readonly IRaiseError raiseError;
		readonly ICurrCnvt iCurrCnvt;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly ICLM_POBuilderPLNDataCRUD iCLM_POBuilderPLNDataCRUD;
		readonly ILogger logger;
		DateTime startTime;

		public CLM_POBuilderPLNData(IBunchedLoadCollection bunchedLoadCollection,
			ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			ICSIRemoteMethodCall cSIRemoteMethodCall,
			IExecuteDynamicSQL iExecuteDynamicSQL,
			IScalarFunction scalarFunction,
			IStringUtil stringUtil,
			IRaiseError raiseError,
			ICurrCnvt iCurrCnvt,
			ISQLValueComparerUtil sQLUtil,
			ICLM_POBuilderPLNDataCRUD iCLM_POBuilderPLNDataCRUD,
			ILogger logger)
			
		{
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.cSIRemoteMethodCall = cSIRemoteMethodCall;
			this.iExecuteDynamicSQL = iExecuteDynamicSQL;
			this.scalarFunction = scalarFunction;
			this.stringUtil = stringUtil;
			this.raiseError = raiseError;
			this.iCurrCnvt = iCurrCnvt;
			this.sQLUtil = sQLUtil;
			this.iCLM_POBuilderPLNDataCRUD = iCLM_POBuilderPLNDataCRUD;
			this.logger = logger;
			
		}

		void LogTiming(string message)
		{
			var timing = DateTime.Now - startTime;
			logger.Performance(this.GetType().Name, $"{message} - {timing:c}");
			startTime = DateTime.Now;
		}

		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		CLM_POBuilderPLNDataSp (
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
		
			SiteType _Site = Site;
			if(bunchedLoadCollection != null)
			bunchedLoadCollection.StartBunching();
			
			try
			{
				
				ICollectionLoadResponse Data = null;
				startTime = DateTime.Now;

				// LOG TIMING
				LogTiming($"start time: {startTime}");
				LogTiming($"record cap: {RecordCap}");

				string ALTGEN_SpName = null;
				int? ALTGEN_Severity = null;
				int? rowCount = null;
				string All_Sites = null;
				string Select = null;
				string Where = null;
				string AppDataBase = null;
				string SQL = null;
				string Filter = null;
				int? Severity = null;
				int? RetrievedRecords = null;
				int? Flag = null;
				string Infobar = null;
				ICollectionLoadResponse site_group_cursorLoadResponseForCursor = null;
				int site_group_cursor_CursorFetch_Status = -1;
				int site_group_cursor_CursorCounter = -1;
				int? Count = null;
				int? Index = null;
				string Reference = null;
				string SiteRef = null;
				string Item = null;
				string Description = null;
				Guid? ApsPlanRowpointer = null;
				decimal? QtyOrdered = null;
				string UM = null;
				decimal? PlanCost = null;
				decimal? UnitMatCost = null;
				decimal? UnitDutyCost = null;
				decimal? UnitFreightCost = null;
				decimal? UnitBrokerageCost = null;
				decimal? UnitLocalFreight = null;
				decimal? UnitInsuranceCost = null;
				DateTime? ReleaseDate = null;
				DateTime? DueDate = null;
				int? LeadTime = null;
				decimal? UnitCost = null;
				decimal? ExtendedCost = null;
				string SelectionClause = null;
				string FromClause = null;
				string WhereClause = null;
				string AdditionalClause = null;
				string KeyColumns = null;
				string FilterString = null;


				// LOG TIMING
				LogTiming("Declaration of Variables");

				if (this.iCLM_POBuilderPLNDataCRUD.Optional_ModuleForExists())
				{
					// LOG TIMING
					LogTiming("Exist Checker optional_module");

					//this temp table is a table variable in old stored procedure version.
					this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
						    [SpName] SYSNAME);
						SELECT * into #tv_ALTGEN from @ALTGEN");
					var optional_module1LoadResponse = this.iCLM_POBuilderPLNDataCRUD.Optional_Module1Select();
					var optional_module1RequiredColumns = new List<string>() {"SpName"};

					// LOG TIMING
					LogTiming("InsertByRecords loop optional_module1LoadResponse");

					optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

					// LOG TIMING
					LogTiming("ExtractRequiredColumns optional_module1LoadResponse");

					this.iCLM_POBuilderPLNDataCRUD.Optional_Module1Insert(optional_module1LoadResponse);

					// LOG TIMING
					LogTiming("InsertByRecords appDb");

					while (this.iCLM_POBuilderPLNDataCRUD.Tv_ALTGENForExists())
					{
						(ALTGEN_SpName, rowCount) = this.iCLM_POBuilderPLNDataCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
						var ALTGEN = this.iCLM_POBuilderPLNDataCRUD.AltExtGen_CLM_POBuilderPLNDataSp (ALTGEN_SpName,
							RecordCap,
							Site,
							SiteGroup,
							ItemStarting,
							ItemEnding,
							StartingDueDate,
							EndingDueDate,
							Planner,
							VendorCurrCode);
						ALTGEN_Severity = ALTGEN.ReturnCode;
						
						if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
						{
							return (ALTGEN.Data, ALTGEN_Severity);
							
						}
						this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
						/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
						var tv_ALTGEN2LoadResponse = this.iCLM_POBuilderPLNDataCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
						this.iCLM_POBuilderPLNDataCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
						this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
						
					}
					
				}
				if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_POBuilderPLNDataSp") != null)
				{
					var EXTGEN = this.iCLM_POBuilderPLNDataCRUD.AltExtGen_CLM_POBuilderPLNDataSp("dbo.EXTGEN_CLM_POBuilderPLNDataSp",
						RecordCap,
						Site,
						SiteGroup,
						ItemStarting,
						ItemEnding,
						StartingDueDate,
						EndingDueDate,
						Planner,
						VendorCurrCode);
					int? EXTGEN_Severity = EXTGEN.ReturnCode;
					
					if (EXTGEN_Severity != 1)
					{
						return (EXTGEN.Data, EXTGEN_Severity);
					}
				}


				// LOG TIMING
				LogTiming("End of ALTGEN/EXTGEN");

				Filter = "";
				Severity = 0;
				RetrievedRecords = 0;
				Flag = 0;
				if (sQLUtil.SQLBool(sQLUtil.SQLNot((sQLUtil.SQLAnd(ItemStarting== null, ItemEnding== null)))))
				{
					if (ItemStarting== null)
					{
						Filter = stringUtil.Concat("item <= '", stringUtil.Replace(
							ItemEnding,
							"'",
							"''"), "'");
						
					}
					if (ItemEnding== null)
					{
						Filter = stringUtil.Concat("item >= '", stringUtil.Replace(
							ItemStarting,
							"'",
							"''"), "'");
						
					}
					if (ItemStarting!= null && ItemEnding!= null)
					{
						Filter = stringUtil.Concat("item BETWEEN '", stringUtil.Replace(
							ItemStarting,
							"'",
							"''"), "' AND '", stringUtil.Replace(
							ItemEnding,
							"'",
							"''"), "'");
						
					}
					
				}

				// LOG TIMING
				LogTiming("Filter StaringItem - EndingItem");

				if (sQLUtil.SQLBool(sQLUtil.SQLNot((sQLUtil.SQLAnd(StartingDueDate== null, EndingDueDate== null)))))
				{
					if (sQLUtil.SQLBool(sQLUtil.SQLNot((sQLUtil.SQLAnd(ItemStarting== null, ItemEnding== null)))))
					{
						Filter = stringUtil.Concat(Filter, " AND ");
						
					}
					if (StartingDueDate== null)
					{
						Filter = stringUtil.Concat(Filter, "due_date <= '", stringUtil.Replace(
							Convert.ToString(EndingDueDate),
							"'",
							"''"), "'");
						
					}
					if (EndingDueDate== null)
					{
						Filter = stringUtil.Concat(Filter, "due_date >= '", stringUtil.Replace(
							Convert.ToString(StartingDueDate),
							"'",
							"''"), "'");
						
					}
					if (StartingDueDate!= null && EndingDueDate!= null)
					{
						Filter = stringUtil.Concat(Filter, "due_date BETWEEN '", stringUtil.Replace(
							Convert.ToString(StartingDueDate),
							"'",
							"''"), "' AND '", stringUtil.Replace(
							Convert.ToString(EndingDueDate),
							"'",
							"''"), "'");
						
					}
					
				}

				// LOG TIMING
				LogTiming("Filter StaringDueDate - EndingDueDate");

				if (sQLUtil.SQLBool(Planner!= null))
				{
					if (sQLUtil.SQLBool(sQLUtil.SQLNot((sQLUtil.SQLAnd(sQLUtil.SQLAnd(sQLUtil.SQLAnd(ItemStarting== null, ItemEnding== null), StartingDueDate== null), EndingDueDate== null)))))
					{
						Filter = stringUtil.Concat(Filter, " AND ");
						
					}
					Filter = stringUtil.Concat(Filter, "plan_code = '", stringUtil.Replace(
						Planner,
						"'",
						"''"), "'");
					
				}

				// LOG TIMING
				LogTiming("Filter Planner");

				if (SiteGroup!= null)
				{
					Flag = 1;
					#region Cursor Statement
					site_group_cursorLoadResponseForCursor = this.iCLM_POBuilderPLNDataCRUD.SiteSelect(SiteGroup);

					// LOG TIMING
					LogTiming("CursorLoadRequest - SiteSelect()");

					site_group_cursor_CursorFetch_Status = site_group_cursorLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
					site_group_cursor_CursorCounter = -1;

					// LOG TIMING
					LogTiming($"CURSOR site_group_cursorLoadResponseForCursor - data count: {site_group_cursorLoadResponseForCursor.Items.Count}");


					#endregion Cursor Statement

				}



				if (SiteGroup== null && Site!= null)
				{
					Flag = 1;
					#region Cursor Statement
					site_group_cursorLoadResponseForCursor = this.iCLM_POBuilderPLNDataCRUD.Site1Select(Site);
					#endregion Cursor Statement

					// LOG TIMING
					LogTiming($"CURSOR site_group_cursorLoadResponseForCursor - data count: {site_group_cursorLoadResponseForCursor.Items.Count}");

				}



				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @tt_tmp_po_builder TABLE (
					    DoSelect                 TINYINT          DEFAULT 0,
					    to_site                  SiteType        ,
					    item                     ItemType        ,
					    description              DescriptionType ,
					    apsplan_RowPointer       RowPointerType  ,
					    qty_ordered              QtyUnitNoNegType,
					    qty_ordered_conv         QtyUnitNoNegType,
					    u_m                      UMType          ,
					    due_date                 DateType        ,
					    release_date             DateType        ,
					    plan_cost                CostPrcType     ,
					    plan_cost_conv           CostPrcType     ,
					    item_cost                CostPrcType     ,
					    item_cost_conv           CostPrcType     ,
					    unit_mat_cost            CostPrcType     ,
					    unit_mat_cost_conv       CostPrcType     ,
					    unit_duty_cost           CostPrcType     ,
					    unit_duty_cost_conv      CostPrcType     ,
					    unit_freight_cost        CostPrcType     ,
					    unit_freight_cost_conv   CostPrcType     ,
					    unit_brokerage_cost      CostPrcType     ,
					    unit_brokerage_cost_conv CostPrcType     ,
					    unit_insurance_cost      CostPrcType     ,
					    unit_insurance_cost_conv CostPrcType     ,
					    unit_local_frieght       CostPrcType     ,
					    unit_local_freight_conv  CostPrcType     ,
					    lead_time                LeadTimeType    ,
					    ref_num                  MrpOrderType    ,
					    extended_cost            AmtTotType      ,
					    extended_cost_conv       AmtTotType      );
					SELECT * into #tv_tt_tmp_po_builder from @tt_tmp_po_builder;");

				// LOG TIMING
				LogTiming("sQLExpressionExecutor Declare tt_tmp_po_builder");

				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @tt_tmp_po_builder1 TABLE (
					    ID                  INT              IDENTITY,
					    to_site             SiteType        ,
					    item                ItemType        ,
					    description         DescriptionType ,
					    apsplan_RowPointer  RowPointerType  ,
					    qty_ordered         QtyUnitNoNegType,
					    u_m                 UMType          ,
					    due_date            DateType        ,
					    release_date        DateType        ,
					    unit_mat_cost       CostPrcType     ,
					    unit_duty_cost      CostPrcType     ,
					    unit_freight_cost   CostPrcType     ,
					    unit_brokerage_cost CostPrcType     ,
					    unit_insurance_cost CostPrcType     ,
					    unit_local_frieght  CostPrcType     ,
					    lead_time           LeadTimeType    ,
					    ref_num             MrpOrderType    );
					SELECT * into #tv_tt_tmp_po_builder1 from @tt_tmp_po_builder1
					ALTER TABLE #tv_tt_tmp_po_builder1 ADD PRIMARY KEY (ID)");

				// LOG TIMING
				LogTiming("sQLExpressionExecutor Declare tt_tmp_po_builder1");

				Index = 1;
				if (sQLUtil.SQLBool(sQLUtil.SQLEqual(Flag, 1)))
				{
					while (sQLUtil.SQLBool(sQLUtil.SQLEqual(1, 1)))
					{
						site_group_cursor_CursorCounter++;
						if(site_group_cursorLoadResponseForCursor.Items.Count > site_group_cursor_CursorCounter)
						{
							All_Sites = site_group_cursorLoadResponseForCursor.Items[site_group_cursor_CursorCounter].GetValue<string>(0);
						}
						site_group_cursor_CursorFetch_Status = (site_group_cursor_CursorCounter == site_group_cursorLoadResponseForCursor.Items.Count ? -1 : 0);

						if (sQLUtil.SQLNotEqual(site_group_cursor_CursorFetch_Status, 0) == true)
						{
							
							break;
							
						}
						(AppDataBase, rowCount) = this.iCLM_POBuilderPLNDataCRUD.Site2Load(All_Sites, AppDataBase);


						if (sQLUtil.SQLBool(sQLUtil.SQLNot((sQLUtil.SQLAnd(sQLUtil.SQLAnd(sQLUtil.SQLAnd(sQLUtil.SQLAnd(ItemStarting== null, ItemEnding== null), StartingDueDate== null), EndingDueDate== null), Planner== null)))))
						{
							Where = stringUtil.Concat("(site_ref = '", stringUtil.Replace(
								All_Sites,
								"'",
								"''"), "'", ") AND (", Filter, ")");
							
						}
						else
						{
							Where = stringUtil.Concat("(site_ref = '", stringUtil.Replace(
								All_Sites,
								"'",
								"''"), "')");
							
						}
						Select = stringUtil.Concat("SELECT TOP ", Convert.ToString(RecordCap), @"site_ref
							                                      , item
							                                      , description
							                                      , rowpointer
							                                      , qty, u_m
							                                      , due_date
							                                      , start_date
							                                      , unit_mat_cost
							                                      , unit_duty_cost
							                                      , unit_freight_cost
							                                      , unit_brokerage_cost
							                                      , unit_insurance_cost
							                                      , unit_loc_frt_cost
							                                      , lead_time,ref_num");
						SQL = stringUtil.Concat(Select, " FROM ", stringUtil.QuoteName(AppDataBase), ".dbo.", stringUtil.QuoteName(stringUtil.Concat("vapsplan_", AppDataBase)), " WHERE ", Where);
						
						var tv_tt_tmp_po_builder1ExecResult = cSIRemoteMethodCall.RemoteMethodCallSp(
						Site: All_Sites
						, IdoName: null
						, MethodName: "ExecuteSQLSp"
						, StoredProcName: null
						, Infobar: Infobar
						, RefRowPointer: null
						, SQL
						, Infobar);
						Severity = tv_tt_tmp_po_builder1ExecResult.ReturnCode;

						// LOG TIMING
						LogTiming("tv_tt_tmp_po_builder1ExecResult RemoteMethodCallSp");

						this.iCLM_POBuilderPLNDataCRUD.Tv_Tt_Tmp_Po_Builder1Insert(Severity, All_Sites, Infobar, SQL, AppDataBase, tv_tt_tmp_po_builder1ExecResult.Data, Where);

						// LOG TIMING
						LogTiming("InserRequest - Tv_Tt_Tmp_Po_Builder1Insert()");

						Infobar = tv_tt_tmp_po_builder1ExecResult.Infobar;
						if (sQLUtil.SQLNotEqual(Severity, 0) == true)
						{
							raiseError.RaiseErrorSp(
								Infobar,
								Severity,
								1);
							return (Data, Severity);
						}
						(Count, rowCount) = this.iCLM_POBuilderPLNDataCRUD.Tv_Tt_Tmp_Po_Builder11Load(Count);

						// LOG TIMING
						LogTiming("LoadRequest - Tv_Tt_Tmp_Po_Builder11Load()");

						while (sQLUtil.SQLLessThanOrEqual(Index, Count) == true)
						{
							(SiteRef,
								 Item,
								 Description,
								 ApsPlanRowpointer,
								 QtyOrdered,
								 UM,
								 DueDate,
								 ReleaseDate,
								 UnitMatCost,
								 UnitDutyCost,
								 UnitFreightCost,
								 UnitBrokerageCost,
								 UnitInsuranceCost,
								 UnitLocalFreight,
								 LeadTime,
								 Reference, rowCount) = this.iCLM_POBuilderPLNDataCRUD.Tv_Tt_Tmp_Po_Builder12Load(Index,
								 Count,
								 Reference,
								 SiteRef,
								 Item,
								 Description,
								 ApsPlanRowpointer,
								 QtyOrdered,
								 UM,
								 UnitMatCost,
								 UnitDutyCost,
								 UnitFreightCost,
								 UnitBrokerageCost,
								 UnitLocalFreight,
								 UnitInsuranceCost,
								 ReleaseDate,
								 DueDate,
								 LeadTime);

							#region CRUD ExecuteMethodCall

							//Please Generate the bounce for this stored procedure: CurrCnvtSp
							var CurrCnvt = this.iCurrCnvt.CurrCnvtSp(
								CurrCode: VendorCurrCode,
								FromDomestic: 1,
								UseBuyRate: 1,
								RoundResult: 0,
								Infobar: Infobar,
								Amount1: UnitMatCost,
								Result1: UnitMatCost,
								Amount2: UnitFreightCost,
								Result2: UnitFreightCost,
								Amount3: UnitDutyCost,
								Result3: UnitDutyCost,
								Amount4: UnitBrokerageCost,
								Result4: UnitBrokerageCost,
								Amount5: UnitInsuranceCost,
								Result5: UnitInsuranceCost,
								Amount6: UnitLocalFreight,
								Result6: UnitLocalFreight,
								Site: Site);
							Severity = CurrCnvt.ReturnCode;
							Infobar = CurrCnvt.Infobar;
							UnitMatCost = CurrCnvt.Result1;
							UnitFreightCost = CurrCnvt.Result2;
							UnitDutyCost = CurrCnvt.Result3;
							UnitBrokerageCost = CurrCnvt.Result4;
							UnitInsuranceCost = CurrCnvt.Result5;
							UnitLocalFreight = CurrCnvt.Result6;

							#endregion ExecuteMethodCall

							if (sQLUtil.SQLNotEqual(Severity, 0) == true)
							{
								raiseError.RaiseErrorSp(
									Infobar,
									Severity);
								return (Data, Severity);
							}
							PlanCost = (decimal?)(UnitMatCost + UnitDutyCost + UnitFreightCost + UnitBrokerageCost + UnitInsuranceCost + UnitLocalFreight);
							UnitCost = PlanCost;
							ExtendedCost = (decimal?)(PlanCost * QtyOrdered);
							Reference = stringUtil.Concat("PLN   ", Reference);
							var nonTableLoadResponse = this.iCLM_POBuilderPLNDataCRUD.NontableSelect(SiteRef, Item, Description, ApsPlanRowpointer, QtyOrdered, UM, DueDate, ReleaseDate, PlanCost, UnitMatCost, UnitDutyCost, UnitFreightCost, UnitBrokerageCost, UnitInsuranceCost, UnitLocalFreight, LeadTime, Reference, ExtendedCost);
							Data = nonTableLoadResponse;
							this.iCLM_POBuilderPLNDataCRUD.NontableInsert(nonTableLoadResponse);
							Index = (int?)(Index + 1);
							RetrievedRecords = (int?)(RetrievedRecords + 1);
							if (sQLUtil.SQLEqual(RetrievedRecords, RecordCap) == true)
							{

								break;

							}
							
							

						}

						// LOG TIMING
						LogTiming("CURSOR - END 2nd WHILE");

						if (sQLUtil.SQLEqual(RetrievedRecords, RecordCap) == true)
						{
							
							break;
							
						}
						
					}
					//Deallocate Cursor site_group_cursor
					
				}

				this.sQLExpressionExecutor.Execute(@"SELECT to_site,
					       item,
					       description,
					       apsplan_RowPointer,
					       qty_ordered,
					       qty_ordered_conv,
					       u_m,
					       due_date,
					       release_date,
					       plan_cost,
					       plan_cost_conv,
					       item_cost,
					       item_cost_conv,
					       unit_mat_cost,
					       unit_mat_cost_conv,
					       unit_duty_cost,
					       unit_duty_cost_conv,
					       unit_freight_cost,
					       unit_freight_cost_conv,
					       unit_brokerage_cost,
					       unit_brokerage_cost_conv,
					       unit_insurance_cost,
					       unit_insurance_cost_conv,
					       unit_local_frieght,
					       unit_local_freight_conv,
					       lead_time,
					       ref_num,
					       extended_cost,
					       extended_cost_conv
					INTO   #tempOutput
					FROM   #tv_tt_tmp_po_builder");
				
				SelectionClause = "SELECT *";
				FromClause = "FROM #tempOutput";
				WhereClause = null;
				AdditionalClause = "ORDER BY to_site, item, due_date, ref_num";
				KeyColumns = "to_site, item, due_date, ref_num";
				FilterString = null;
				if (this.scalarFunction.Execute<int?>(
					"OBJECT_ID",
					"tempdb..#DynamicParameters") != null)
				{
					this.sQLExpressionExecutor.Execute("DROP TABLE #DynamicParameters");

					
				}

				this.sQLExpressionExecutor.Execute(@"Declare
					@SelectionClause VeryLongListType
					,@FromClause VeryLongListType
					,@WhereClause VeryLongListType
					,@AdditionalClause VeryLongListType
					,@KeyColumns VeryLongListType
					,@FilterString VeryLongListType
					SELECT @SelectionClause AS SelectionClause,
					       @FromClause AS FromClause,
					       @WhereClause AS WhereClause,
					       @AdditionalClause AS AdditionalClause,
					       @KeyColumns AS KeyColumns,
					       @FilterString AS FilterString
					INTO   #DynamicParameters
					WHERE 1 = 2");
				var DynamicParametersLoadResponse = this.iCLM_POBuilderPLNDataCRUD.DynamicparametersSelect(SelectionClause, FromClause, WhereClause, AdditionalClause, KeyColumns, FilterString);

				this.iCLM_POBuilderPLNDataCRUD.DynamicparametersInsert(DynamicParametersLoadResponse);

				#region CRUD ExecuteMethodCall

				//Please Generate the bounce for this stored procedure: ExecuteDynamicSQLSp
				var ExecuteDynamicSQL = this.iExecuteDynamicSQL.ExecuteDynamicSQLSp(
					NeedGetMoreRows: 1,
					Infobar: Infobar);
				Severity = ExecuteDynamicSQL.ReturnCode;
				Data = ExecuteDynamicSQL.Data;
				Infobar = ExecuteDynamicSQL.Infobar;

				#endregion ExecuteMethodCall

				return (Data, Severity = 0);


			}
			finally
			{
				if(bunchedLoadCollection != null)
				bunchedLoadCollection.EndBunching();
			}

		}

    }
}