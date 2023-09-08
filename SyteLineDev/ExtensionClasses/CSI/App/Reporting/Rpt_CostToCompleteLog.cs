//PROJECT NAME: Reporting
//CLASS NAME: Rpt_CostToCompleteLog.cs

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
using CSI.Material;

namespace CSI.Reporting
{
	public class Rpt_CostToCompleteLog : IRpt_CostToCompleteLog
	{
		
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly ICloseSessionContext iCloseSessionContext;
		readonly IInitSessionContext iInitSessionContext;
		readonly ITransactionFactory transactionFactory;
		readonly IGetIsolationLevel iGetIsolationLevel;
		readonly IApplyDateOffset iApplyDateOffset;
		readonly IExpandKyByType iExpandKyByType;
		readonly IScalarFunction scalarFunction;
		readonly IConvertToUtil convertToUtil;
		readonly IHighCharacter highCharacter;
		readonly ILowCharacter lowCharacter;
		readonly IStringUtil stringUtil;
		readonly IHighInt iHighInt;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly ILowInt iLowInt;
		readonly IRpt_CostToCompleteLogCRUD iRpt_CostToCompleteLogCRUD;
		
		public Rpt_CostToCompleteLog(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			ICloseSessionContext iCloseSessionContext,
			IInitSessionContext iInitSessionContext,
			ITransactionFactory transactionFactory,
			IGetIsolationLevel iGetIsolationLevel,
			IApplyDateOffset iApplyDateOffset,
			IExpandKyByType iExpandKyByType,
			IScalarFunction scalarFunction,
			IConvertToUtil convertToUtil,
			IHighCharacter highCharacter,
			ILowCharacter lowCharacter,
			IStringUtil stringUtil,
			IHighInt iHighInt,
			ISQLValueComparerUtil sQLUtil,
			ILowInt iLowInt,
			IRpt_CostToCompleteLogCRUD iRpt_CostToCompleteLogCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.iCloseSessionContext = iCloseSessionContext;
			this.iInitSessionContext = iInitSessionContext;
			this.transactionFactory = transactionFactory;
			this.iGetIsolationLevel = iGetIsolationLevel;
			this.iApplyDateOffset = iApplyDateOffset;
			this.iExpandKyByType = iExpandKyByType;
			this.scalarFunction = scalarFunction;
			this.convertToUtil = convertToUtil;
			this.highCharacter = highCharacter;
			this.lowCharacter = lowCharacter;
			this.stringUtil = stringUtil;
			this.iHighInt = iHighInt;
			this.sQLUtil = sQLUtil;
			this.iLowInt = iLowInt;
			this.iRpt_CostToCompleteLogCRUD = iRpt_CostToCompleteLogCRUD;
		}
		
		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		Rpt_CostToCompleteLogSp (
			string ProjectStarting = null,
			string ProjectEnding = null,
			int? TaskStarting = null,
			int? TaskEnding = null,
			string CostCodeStarting = null,
			string CostCodeEnding = null,
			string ProjectStatus = null,
			DateTime? Date = null,
			int? DateOffset = null,
			int? Printcost = 0,
			int? DisplayHeader = 1,
			string pSite = null)
		{
			
			DateType _Date = Date;
			
			ICollectionLoadResponse Data = null;
			
			int? Severity = 0;
			
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			Guid? RptSessionID = null;
			string LowCharacter = null;
			string HighCharacter = null;
			ICollectionLoadResponse log_curLoadResponseForCursor = null;
			int log_cur_CursorFetch_Status = -1;
			int log_cur_CursorCounter = -1;
			string proj_num = null;
			string proj_desc = null;
			string stat = null;
			string cust_num = null;
			int? cust_seq = null;
			string name = null;
			string contract = null;
			int? task_num = null;
			string task_desc = null;
			string cost_class = null;
			string cost_code = null;
			string cost_desc = null;
			DateTime? snap_date = null;
			decimal? a_units = null;
			decimal? a_cost = null;
			ProjUnitsType _units = DBNull.Value;
			decimal? units = null;
			decimal? plan_units = null;
			decimal? fcst_cost = null;
			decimal? plan_cost = null;
			decimal? cost_to_complete = null;
			decimal? cost_to_complete_units = null;
			if (this.iRpt_CostToCompleteLogCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iRpt_CostToCompleteLogCRUD.Optional_Module1Select();
				var optional_module1RequiredColumns = new List<string>() {"SpName"};
				
				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);
				
				this.iRpt_CostToCompleteLogCRUD.Optional_Module1Insert(optional_module1LoadResponse);
				while (this.iRpt_CostToCompleteLogCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iRpt_CostToCompleteLogCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iRpt_CostToCompleteLogCRUD.AltExtGen_Rpt_CostToCompleteLogSp (ALTGEN_SpName,
						ProjectStarting,
						ProjectEnding,
						TaskStarting,
						TaskEnding,
						CostCodeStarting,
						CostCodeEnding,
						ProjectStatus,
						Date,
						DateOffset,
						Printcost,
						DisplayHeader,
						pSite);
					ALTGEN_Severity = ALTGEN.ReturnCode;
					
					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN.Data, ALTGEN_Severity);
						
					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iRpt_CostToCompleteLogCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iRpt_CostToCompleteLogCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
					
				}
				
			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Rpt_CostToCompleteLogSp") != null)
			{
				var EXTGEN = this.iRpt_CostToCompleteLogCRUD.AltExtGen_Rpt_CostToCompleteLogSp("dbo.EXTGEN_Rpt_CostToCompleteLogSp",
					ProjectStarting,
					ProjectEnding,
					TaskStarting,
					TaskEnding,
					CostCodeStarting,
					CostCodeEnding,
					ProjectStatus,
					Date,
					DateOffset,
					Printcost,
					DisplayHeader,
					pSite);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;
				
				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}
			
			this.transactionFactory.BeginTransaction("");
			this.sQLExpressionExecutor.Execute("SET XACT_ABORT ON");
			if (sQLUtil.SQLEqual(this.iGetIsolationLevel.GetIsolationLevelFn("CostToCompleteLogReport"), "COMMITTED") == true)
			{
				this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ COMMITTED");
				
			}
			else
			{
				this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
				
			}
			
			#region CRUD ExecuteMethodCall
			
			//Please Generate the bounce for this stored procedure: InitSessionContextSp
			var InitSessionContext = this.iInitSessionContext.InitSessionContextSp(
				ContextName: "Rpt_CostToCompleteLogSp",
				SessionID: RptSessionID,
				Site: pSite);
			RptSessionID = InitSessionContext.SessionID;
			
			#endregion ExecuteMethodCall
			
			LowCharacter = convertToUtil.ToString(lowCharacter.LowCharacterFn());
			HighCharacter = convertToUtil.ToString(highCharacter.HighCharacterFn());
			ProjectStarting = stringUtil.IsNull(
				this.iExpandKyByType.ExpandKyByTypeFn(
					"ProjNumType",
					ProjectStarting),
				LowCharacter);
			ProjectEnding = stringUtil.IsNull(
				this.iExpandKyByType.ExpandKyByTypeFn(
					"ProjNumType",
					ProjectEnding),
				HighCharacter);
			TaskStarting = (int?)(stringUtil.IsNull(
				TaskStarting,
				this.iLowInt.LowIntFn()));
			TaskEnding = (int?)(stringUtil.IsNull(
				TaskEnding,
				this.iHighInt.HighIntFn()));
			CostCodeStarting = stringUtil.IsNull(
				CostCodeStarting,
				LowCharacter);
			CostCodeEnding = stringUtil.IsNull(
				CostCodeEnding,
				HighCharacter);
			ProjectStatus = stringUtil.IsNull(
				ProjectStatus,
				"AICHE");
			
			#region CRUD ExecuteMethodCall
			
			//Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
			var ApplyDateOffset = this.iApplyDateOffset.ApplyDateOffsetSp(
				Date: Date,
				Offset: DateOffset,
				IsEndDate: null);
			Date = ApplyDateOffset.Date;
			
			#endregion ExecuteMethodCall
			
			//this temp table is a table variable in old stored procedure version.
			this.sQLExpressionExecutor.Execute(@"DECLARE @rpt_set TABLE (
				    proj_num               ProjNumType      ,
				    proj_desc              DescriptionType  ,
				    stat                   ProjStatusType   ,
				    cust_num               CustNumType      ,
				    cust_seq               CustSeqType      ,
				    name                   NameType         ,
				    contract               ContractType     ,
				    snap_date              DateType         ,
				    task_num               TaskNumType      ,
				    task_desc              DescriptionType  ,
				    cost_class             CostCodeClassType,
				    cost_code              CostCodeType     ,
				    cost_desc              DescriptionType  ,
				    a_units                ProjUnitsType    ,
				    a_cost                 AmtTotType       ,
				    units                  ProjUnitsType    ,
				    plan_units             ProjUnitsType    ,
				    fcst_cost              AmtTotType       ,
				    plan_cost              AmtTotType       ,
				    cost_to_complete       AmtTotType       ,
				    cost_to_complete_units ProjUnitsType    );
				SELECT * into #tv_rpt_set from @rpt_set");
			this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_rpt_set ADD tempTableId INT IDENTITY");
			/*Needs to load at least one column from the table: #tv_rpt_set for delete, Loads the record based on its where and from clause, then deletes it by record.*/
			var tv_rpt_setLoadResponse = this.iRpt_CostToCompleteLogCRUD.Tv_Rpt_SetSelect();
			this.iRpt_CostToCompleteLogCRUD.Tv_Rpt_SetDelete(tv_rpt_setLoadResponse);
			this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_rpt_set DROP COLUMN tempTableId");
			log_curLoadResponseForCursor = this.iRpt_CostToCompleteLogCRUD.ProjSelect(ProjectStarting, ProjectEnding, TaskStarting, TaskEnding, CostCodeStarting, CostCodeEnding, ProjectStatus, Date);
			log_cur_CursorFetch_Status = log_curLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
			log_cur_CursorCounter = -1;
			
			while (sQLUtil.SQLEqual(1, 1) == true)
			{
				log_cur_CursorCounter++;
				if(log_curLoadResponseForCursor.Items.Count > log_cur_CursorCounter)
				{
					proj_num = log_curLoadResponseForCursor.Items[log_cur_CursorCounter].GetValue<string>(0);
					proj_desc = log_curLoadResponseForCursor.Items[log_cur_CursorCounter].GetValue<string>(1);
					stat = log_curLoadResponseForCursor.Items[log_cur_CursorCounter].GetValue<string>(2);
					cust_num = log_curLoadResponseForCursor.Items[log_cur_CursorCounter].GetValue<string>(3);
					cust_seq = log_curLoadResponseForCursor.Items[log_cur_CursorCounter].GetValue<int?>(4);
					name = log_curLoadResponseForCursor.Items[log_cur_CursorCounter].GetValue<string>(5);
					contract = log_curLoadResponseForCursor.Items[log_cur_CursorCounter].GetValue<string>(6);
					task_num = log_curLoadResponseForCursor.Items[log_cur_CursorCounter].GetValue<int?>(7);
					task_desc = log_curLoadResponseForCursor.Items[log_cur_CursorCounter].GetValue<string>(8);
					cost_class = log_curLoadResponseForCursor.Items[log_cur_CursorCounter].GetValue<string>(9);
					cost_code = log_curLoadResponseForCursor.Items[log_cur_CursorCounter].GetValue<string>(10);
					cost_desc = log_curLoadResponseForCursor.Items[log_cur_CursorCounter].GetValue<string>(11);
				}
				log_cur_CursorFetch_Status = (log_cur_CursorCounter == log_curLoadResponseForCursor.Items.Count ? -1 : 0);
				
				if (sQLUtil.SQLNotEqual(log_cur_CursorFetch_Status, 0) == true)
				{
					
					break;
					
				}
				a_units = 0;
				a_cost = 0;
				units = 0;
				fcst_cost = 0;
				plan_units = 0;
				plan_cost = 0;
				(a_units, a_cost, units, fcst_cost, plan_units, plan_cost, snap_date, rowCount) = this.iRpt_CostToCompleteLogCRUD.Ctc_LogLoad(Date, proj_num, task_num, cost_code, snap_date, a_units, a_cost, units, plan_units, fcst_cost, plan_cost);
				cost_to_complete = (decimal?)((sQLUtil.SQLEqual(plan_cost, 0) == true ? fcst_cost - a_cost : plan_cost - a_cost));
				cost_to_complete_units = (decimal?)((sQLUtil.SQLEqual(plan_cost, 0) == true ? units - a_units : plan_units - a_units));
				if (sQLUtil.SQLEqual(Printcost, 0) == true)
				{
					a_cost = 0;
					fcst_cost = 0;
					plan_cost = 0;
					cost_to_complete = 0;
					
				}
				var nonTableLoadResponse = this.iRpt_CostToCompleteLogCRUD.NontableSelect(proj_num, proj_desc, stat, cust_num, cust_seq, name, contract, snap_date, task_num, task_desc, cost_class, cost_code, cost_desc, a_units, a_cost, units, plan_units, fcst_cost, plan_cost, cost_to_complete, cost_to_complete_units);
				Data = nonTableLoadResponse;
				this.iRpt_CostToCompleteLogCRUD.NontableInsert(nonTableLoadResponse);
				
			}
			log_curLoadResponseForCursor = null;
			//Deallocate Cursor @log_cur
			var tv_rpt_set1LoadResponse = this.iRpt_CostToCompleteLogCRUD.Tv_Rpt_Set1Select();
			Data = tv_rpt_set1LoadResponse;
			this.transactionFactory.CommitTransaction("");
			
			#region CRUD ExecuteMethodCall
			
			//Please Generate the bounce for this stored procedure: CloseSessionContextSp
			var CloseSessionContext = this.iCloseSessionContext.CloseSessionContextSp(SessionID: RptSessionID);
			
			#endregion ExecuteMethodCall
			
			return (Data, Severity);
		}
		
	}
}
