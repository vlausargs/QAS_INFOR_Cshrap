//PROJECT NAME: Logistics
//CLASS NAME: Home_GetProductionPlannerParms.cs

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
using CSI.Production;
using CSI.Production.Projects;
using CSI.Finance;
using CSI.Material;
using CSI.Codes;

namespace CSI.Logistics.Customer
{
	public class Home_GetProductionPlannerParms : IHome_GetProductionPlannerParms
	{
		
		readonly IHome_GetTodaysKeyProductionValues iHome_GetTodaysKeyProductionValues;
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly IGetSysParPermPlanMode iGetSysParPermPlanMode;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IGetUnPostedProdTrans iGetUnPostedProdTrans;
		readonly ITransactionFactory transactionFactory;
		readonly IGetFiscalPeriods iGetFiscalPeriods;
		readonly IScalarFunction scalarFunction;
		readonly IGetFiscalYear iGetFiscalYear;
		readonly IGetInvSiteGrp iGetInvSiteGrp;
		readonly IGetCurPeriod iGetCurPeriod;
		readonly IStringUtil stringUtil;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IHome_GetProductionPlannerParmsCRUD iHome_GetProductionPlannerParmsCRUD;
		
		public Home_GetProductionPlannerParms(IHome_GetTodaysKeyProductionValues iHome_GetTodaysKeyProductionValues,
			ICollectionLoadResponseUtil collectionLoadResponseUtil,
			IGetSysParPermPlanMode iGetSysParPermPlanMode,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IGetUnPostedProdTrans iGetUnPostedProdTrans,
			ITransactionFactory transactionFactory,
			IGetFiscalPeriods iGetFiscalPeriods,
			IScalarFunction scalarFunction,
			IGetFiscalYear iGetFiscalYear,
			IGetInvSiteGrp iGetInvSiteGrp,
			IGetCurPeriod iGetCurPeriod,
			IStringUtil stringUtil,
			ISQLValueComparerUtil sQLUtil,
			IHome_GetProductionPlannerParmsCRUD iHome_GetProductionPlannerParmsCRUD)
		{
			this.iHome_GetTodaysKeyProductionValues = iHome_GetTodaysKeyProductionValues;
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.iGetSysParPermPlanMode = iGetSysParPermPlanMode;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.iGetUnPostedProdTrans = iGetUnPostedProdTrans;
			this.transactionFactory = transactionFactory;
			this.iGetFiscalPeriods = iGetFiscalPeriods;
			this.scalarFunction = scalarFunction;
			this.iGetFiscalYear = iGetFiscalYear;
			this.iGetInvSiteGrp = iGetInvSiteGrp;
			this.iGetCurPeriod = iGetCurPeriod;
			this.stringUtil = stringUtil;
			this.sQLUtil = sQLUtil;
			this.iHome_GetProductionPlannerParmsCRUD = iHome_GetProductionPlannerParmsCRUD;
		}
		
		public (
			int? ReturnCode,
			int? pFiscalYear,
			string InvSiteGrp,
			string ApsParmApsmode,
			int? CanAdd,
			int? CanUpdate,
			int? CanDelete,
			string PlanMode,
			string Parm_DefWhse,
			int? UnpostedDCSFC,
			int? UnpostedDCJM,
			int? UnpostedDCJMRcpt,
			int? UnpostedJobLaborTrans,
			int? UnpostedDCJIT,
			int? UnpostedDCPS,
			int? UnpostedDCPSScrap,
			int? UnpostedJobMatlTrans,
			int? UnpostedDCSFCWCLabor,
			int? UnpostedDCSFCWCMachine,
			int? UnpostedDCWC,
			int? pCurPeriod,
			DateTime? rPer1Start,
			DateTime? rPer2Start,
			DateTime? rPer3Start,
			DateTime? rPer4Start,
			DateTime? rPer5Start,
			DateTime? rPer6Start,
			DateTime? rPer7Start,
			DateTime? rPer8Start,
			DateTime? rPer9Start,
			DateTime? rPer10Start,
			DateTime? rPer11Start,
			DateTime? rPer12Start,
			DateTime? rPer13Start,
			DateTime? rPer1End,
			DateTime? rPer2End,
			DateTime? rPer3End,
			DateTime? rPer4End,
			DateTime? rPer5End,
			DateTime? rPer6End,
			DateTime? rPer7End,
			DateTime? rPer8End,
			DateTime? rPer9End,
			DateTime? rPer10End,
			DateTime? rPer11End,
			DateTime? rPer12End,
			DateTime? rPer13End,
			int? CompleteQty,
			int? PastDueQty,
			string Infobar)
		Home_GetProductionPlannerParmsSp (
			decimal? Userid,
			int? pFiscalYear,
			string InvSiteGrp,
			string ApsParmApsmode,
			int? CanAdd,
			int? CanUpdate,
			int? CanDelete,
			string PlanMode,
			string Parm_DefWhse,
			int? UnpostedDCSFC,
			int? UnpostedDCJM,
			int? UnpostedDCJMRcpt,
			int? UnpostedJobLaborTrans,
			int? UnpostedDCJIT,
			int? UnpostedDCPS,
			int? UnpostedDCPSScrap,
			int? UnpostedJobMatlTrans,
			int? UnpostedDCSFCWCLabor,
			int? UnpostedDCSFCWCMachine,
			int? UnpostedDCWC,
			int? pCurPeriod,
			DateTime? rPer1Start,
			DateTime? rPer2Start,
			DateTime? rPer3Start,
			DateTime? rPer4Start,
			DateTime? rPer5Start,
			DateTime? rPer6Start,
			DateTime? rPer7Start,
			DateTime? rPer8Start,
			DateTime? rPer9Start,
			DateTime? rPer10Start,
			DateTime? rPer11Start,
			DateTime? rPer12Start,
			DateTime? rPer13Start,
			DateTime? rPer1End,
			DateTime? rPer2End,
			DateTime? rPer3End,
			DateTime? rPer4End,
			DateTime? rPer5End,
			DateTime? rPer6End,
			DateTime? rPer7End,
			DateTime? rPer8End,
			DateTime? rPer9End,
			DateTime? rPer10End,
			DateTime? rPer11End,
			DateTime? rPer12End,
			DateTime? rPer13End,
			int? CompleteQty,
			int? PastDueQty,
			string Infobar)
		{
			
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			int? Severity = null;
			if (this.iHome_GetProductionPlannerParmsCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iHome_GetProductionPlannerParmsCRUD.Optional_Module1Select();
				
				this.iHome_GetProductionPlannerParmsCRUD.Optional_Module1Insert(optional_module1LoadResponse);
				while (this.iHome_GetProductionPlannerParmsCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iHome_GetProductionPlannerParmsCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iHome_GetProductionPlannerParmsCRUD.AltExtGen_Home_GetProductionPlannerParmsSp (ALTGEN_SpName,
						Userid,
						pFiscalYear,
						InvSiteGrp,
						ApsParmApsmode,
						CanAdd,
						CanUpdate,
						CanDelete,
						PlanMode,
						Parm_DefWhse,
						UnpostedDCSFC,
						UnpostedDCJM,
						UnpostedDCJMRcpt,
						UnpostedJobLaborTrans,
						UnpostedDCJIT,
						UnpostedDCPS,
						UnpostedDCPSScrap,
						UnpostedJobMatlTrans,
						UnpostedDCSFCWCLabor,
						UnpostedDCSFCWCMachine,
						UnpostedDCWC,
						pCurPeriod,
						rPer1Start,
						rPer2Start,
						rPer3Start,
						rPer4Start,
						rPer5Start,
						rPer6Start,
						rPer7Start,
						rPer8Start,
						rPer9Start,
						rPer10Start,
						rPer11Start,
						rPer12Start,
						rPer13Start,
						rPer1End,
						rPer2End,
						rPer3End,
						rPer4End,
						rPer5End,
						rPer6End,
						rPer7End,
						rPer8End,
						rPer9End,
						rPer10End,
						rPer11End,
						rPer12End,
						rPer13End,
						CompleteQty,
						PastDueQty,
						Infobar);
					ALTGEN_Severity = ALTGEN.ReturnCode;
					
					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN_Severity, pFiscalYear, InvSiteGrp, ApsParmApsmode, CanAdd, CanUpdate, CanDelete, PlanMode, Parm_DefWhse, UnpostedDCSFC, UnpostedDCJM, UnpostedDCJMRcpt, UnpostedJobLaborTrans, UnpostedDCJIT, UnpostedDCPS, UnpostedDCPSScrap, UnpostedJobMatlTrans, UnpostedDCSFCWCLabor, UnpostedDCSFCWCMachine, UnpostedDCWC, pCurPeriod, rPer1Start, rPer2Start, rPer3Start, rPer4Start, rPer5Start, rPer6Start, rPer7Start, rPer8Start, rPer9Start, rPer10Start, rPer11Start, rPer12Start, rPer13Start, rPer1End, rPer2End, rPer3End, rPer4End, rPer5End, rPer6End, rPer7End, rPer8End, rPer9End, rPer10End, rPer11End, rPer12End, rPer13End, CompleteQty, PastDueQty, Infobar);
						
					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iHome_GetProductionPlannerParmsCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iHome_GetProductionPlannerParmsCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
					
				}
				
			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Home_GetProductionPlannerParmsSp") != null)
			{
				var EXTGEN = this.iHome_GetProductionPlannerParmsCRUD.AltExtGen_Home_GetProductionPlannerParmsSp("dbo.EXTGEN_Home_GetProductionPlannerParmsSp",
					Userid,
					pFiscalYear,
					InvSiteGrp,
					ApsParmApsmode,
					CanAdd,
					CanUpdate,
					CanDelete,
					PlanMode,
					Parm_DefWhse,
					UnpostedDCSFC,
					UnpostedDCJM,
					UnpostedDCJMRcpt,
					UnpostedJobLaborTrans,
					UnpostedDCJIT,
					UnpostedDCPS,
					UnpostedDCPSScrap,
					UnpostedJobMatlTrans,
					UnpostedDCSFCWCLabor,
					UnpostedDCSFCWCMachine,
					UnpostedDCWC,
					pCurPeriod,
					rPer1Start,
					rPer2Start,
					rPer3Start,
					rPer4Start,
					rPer5Start,
					rPer6Start,
					rPer7Start,
					rPer8Start,
					rPer9Start,
					rPer10Start,
					rPer11Start,
					rPer12Start,
					rPer13Start,
					rPer1End,
					rPer2End,
					rPer3End,
					rPer4End,
					rPer5End,
					rPer6End,
					rPer7End,
					rPer8End,
					rPer9End,
					rPer10End,
					rPer11End,
					rPer12End,
					rPer13End,
					CompleteQty,
					PastDueQty,
					Infobar);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;
				
				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.pFiscalYear, EXTGEN.InvSiteGrp, EXTGEN.ApsParmApsmode, EXTGEN.CanAdd, EXTGEN.CanUpdate, EXTGEN.CanDelete, EXTGEN.PlanMode, EXTGEN.Parm_DefWhse, EXTGEN.UnpostedDCSFC, EXTGEN.UnpostedDCJM, EXTGEN.UnpostedDCJMRcpt, EXTGEN.UnpostedJobLaborTrans, EXTGEN.UnpostedDCJIT, EXTGEN.UnpostedDCPS, EXTGEN.UnpostedDCPSScrap, EXTGEN.UnpostedJobMatlTrans, EXTGEN.UnpostedDCSFCWCLabor, EXTGEN.UnpostedDCSFCWCMachine, EXTGEN.UnpostedDCWC, EXTGEN.pCurPeriod, EXTGEN.rPer1Start, EXTGEN.rPer2Start, EXTGEN.rPer3Start, EXTGEN.rPer4Start, EXTGEN.rPer5Start, EXTGEN.rPer6Start, EXTGEN.rPer7Start, EXTGEN.rPer8Start, EXTGEN.rPer9Start, EXTGEN.rPer10Start, EXTGEN.rPer11Start, EXTGEN.rPer12Start, EXTGEN.rPer13Start, EXTGEN.rPer1End, EXTGEN.rPer2End, EXTGEN.rPer3End, EXTGEN.rPer4End, EXTGEN.rPer5End, EXTGEN.rPer6End, EXTGEN.rPer7End, EXTGEN.rPer8End, EXTGEN.rPer9End, EXTGEN.rPer10End, EXTGEN.rPer11End, EXTGEN.rPer12End, EXTGEN.rPer13End, EXTGEN.CompleteQty, EXTGEN.PastDueQty, EXTGEN.Infobar);
				}
			}
			
			this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
			
			#region CRUD ExecuteMethodCall
			
			//Please Generate the bounce for this stored procedure: GetFiscalYearSp
			var GetFiscalYear = this.iGetFiscalYear.GetFiscalYearSp(pFiscalYear: pFiscalYear);
			Severity = GetFiscalYear.ReturnCode;
			pFiscalYear = GetFiscalYear.pFiscalYear;
			
			#endregion ExecuteMethodCall
			
			#region CRUD ExecuteMethodCall
			
			//Please Generate the bounce for this stored procedure: GetInvSiteGrpSp
			var GetInvSiteGrp = this.iGetInvSiteGrp.GetInvSiteGrpSp(
				Userid: Userid,
				InvSiteGrp: InvSiteGrp);
			Severity = GetInvSiteGrp.ReturnCode;
			InvSiteGrp = GetInvSiteGrp.InvSiteGrp;
			
			#endregion ExecuteMethodCall
			
			#region CRUD ExecuteMethodCall
			
			//Please Generate the bounce for this stored procedure: GetSysParPermPlanModeSp
			var GetSysParPermPlanMode = this.iGetSysParPermPlanMode.GetSysParPermPlanModeSp(
				ApsParmApsmode: ApsParmApsmode,
				CanAdd: CanAdd,
				CanUpdate: CanUpdate,
				CanDelete: CanDelete,
				PlanMode: PlanMode,
				Parm_DefWhse: Parm_DefWhse,
				Infobar: Infobar);
			Severity = GetSysParPermPlanMode.ReturnCode;
			ApsParmApsmode = GetSysParPermPlanMode.ApsParmApsmode;
			CanAdd = GetSysParPermPlanMode.CanAdd;
			CanUpdate = GetSysParPermPlanMode.CanUpdate;
			CanDelete = GetSysParPermPlanMode.CanDelete;
			PlanMode = GetSysParPermPlanMode.PlanMode;
			Parm_DefWhse = GetSysParPermPlanMode.Parm_DefWhse;
			Infobar = GetSysParPermPlanMode.Infobar;
			
			#endregion ExecuteMethodCall
			
			#region CRUD ExecuteMethodCall
			
			//Please Generate the bounce for this stored procedure: GetUnPostedProdTransSp
			var GetUnPostedProdTrans = this.iGetUnPostedProdTrans.GetUnPostedProdTransSp(
				UnpostedDCSFC: UnpostedDCSFC,
				UnpostedDCJM: UnpostedDCJM,
				UnpostedDCJMRcpt: UnpostedDCJMRcpt,
				UnpostedJobLaborTrans: UnpostedJobLaborTrans,
				UnpostedDCJIT: UnpostedDCJIT,
				UnpostedDCPS: UnpostedDCPS,
				UnpostedDCPSScrap: UnpostedDCPSScrap,
				UnpostedJobMatlTrans: UnpostedJobMatlTrans,
				UnpostedDCSFCWCLabor: UnpostedDCSFCWCLabor,
				UnpostedDCSFCWCMachine: UnpostedDCSFCWCMachine,
				UnpostedDCWC: UnpostedDCWC);
			Severity = GetUnPostedProdTrans.ReturnCode;
			UnpostedDCSFC = GetUnPostedProdTrans.UnpostedDCSFC;
			UnpostedDCJM = GetUnPostedProdTrans.UnpostedDCJM;
			UnpostedDCJMRcpt = GetUnPostedProdTrans.UnpostedDCJMRcpt;
			UnpostedJobLaborTrans = GetUnPostedProdTrans.UnpostedJobLaborTrans;
			UnpostedDCJIT = GetUnPostedProdTrans.UnpostedDCJIT;
			UnpostedDCPS = GetUnPostedProdTrans.UnpostedDCPS;
			UnpostedDCPSScrap = GetUnPostedProdTrans.UnpostedDCPSScrap;
			UnpostedJobMatlTrans = GetUnPostedProdTrans.UnpostedJobMatlTrans;
			UnpostedDCSFCWCLabor = GetUnPostedProdTrans.UnpostedDCSFCWCLabor;
			UnpostedDCSFCWCMachine = GetUnPostedProdTrans.UnpostedDCSFCWCMachine;
			UnpostedDCWC = GetUnPostedProdTrans.UnpostedDCWC;
			
			#endregion ExecuteMethodCall
			
			#region CRUD ExecuteMethodCall
			
			//Please Generate the bounce for this stored procedure: GetCurPeriodSp
			var GetCurPeriod = this.iGetCurPeriod.GetCurPeriodSp(pCurPeriod: pCurPeriod);
			Severity = GetCurPeriod.ReturnCode;
			pCurPeriod = GetCurPeriod.pCurPeriod;
			
			#endregion ExecuteMethodCall
			
			#region CRUD ExecuteMethodCall
			
			//Please Generate the bounce for this stored procedure: GetFiscalPeriodsSp
			var GetFiscalPeriods = this.iGetFiscalPeriods.GetFiscalPeriodsSp(
				pFiscalYear: pFiscalYear,
				rPer1Start: rPer1Start,
				rPer2Start: rPer2Start,
				rPer3Start: rPer3Start,
				rPer4Start: rPer4Start,
				rPer5Start: rPer5Start,
				rPer6Start: rPer6Start,
				rPer7Start: rPer7Start,
				rPer8Start: rPer8Start,
				rPer9Start: rPer9Start,
				rPer10Start: rPer10Start,
				rPer11Start: rPer11Start,
				rPer12Start: rPer12Start,
				rPer13Start: rPer13Start,
				rPer1End: rPer1End,
				rPer2End: rPer2End,
				rPer3End: rPer3End,
				rPer4End: rPer4End,
				rPer5End: rPer5End,
				rPer6End: rPer6End,
				rPer7End: rPer7End,
				rPer8End: rPer8End,
				rPer9End: rPer9End,
				rPer10End: rPer10End,
				rPer11End: rPer11End,
				rPer12End: rPer12End,
				rPer13End: rPer13End,
				Infobar: Infobar);
			Severity = GetFiscalPeriods.ReturnCode;
			rPer1Start = GetFiscalPeriods.rPer1Start;
			rPer2Start = GetFiscalPeriods.rPer2Start;
			rPer3Start = GetFiscalPeriods.rPer3Start;
			rPer4Start = GetFiscalPeriods.rPer4Start;
			rPer5Start = GetFiscalPeriods.rPer5Start;
			rPer6Start = GetFiscalPeriods.rPer6Start;
			rPer7Start = GetFiscalPeriods.rPer7Start;
			rPer8Start = GetFiscalPeriods.rPer8Start;
			rPer9Start = GetFiscalPeriods.rPer9Start;
			rPer10Start = GetFiscalPeriods.rPer10Start;
			rPer11Start = GetFiscalPeriods.rPer11Start;
			rPer12Start = GetFiscalPeriods.rPer12Start;
			rPer13Start = GetFiscalPeriods.rPer13Start;
			rPer1End = GetFiscalPeriods.rPer1End;
			rPer2End = GetFiscalPeriods.rPer2End;
			rPer3End = GetFiscalPeriods.rPer3End;
			rPer4End = GetFiscalPeriods.rPer4End;
			rPer5End = GetFiscalPeriods.rPer5End;
			rPer6End = GetFiscalPeriods.rPer6End;
			rPer7End = GetFiscalPeriods.rPer7End;
			rPer8End = GetFiscalPeriods.rPer8End;
			rPer9End = GetFiscalPeriods.rPer9End;
			rPer10End = GetFiscalPeriods.rPer10End;
			rPer11End = GetFiscalPeriods.rPer11End;
			rPer12End = GetFiscalPeriods.rPer12End;
			rPer13End = GetFiscalPeriods.rPer13End;
			Infobar = GetFiscalPeriods.Infobar;
			
			#endregion ExecuteMethodCall
			
			#region CRUD ExecuteMethodCall
			
			//Please Generate the bounce for this stored procedure: Home_GetTodaysKeyProductionValuesSp
			var Home_GetTodaysKeyProductionValues = this.iHome_GetTodaysKeyProductionValues.Home_GetTodaysKeyProductionValuesSp(
				CompleteQty: CompleteQty,
				PastDueQty: PastDueQty);
			Severity = Home_GetTodaysKeyProductionValues.ReturnCode;
			CompleteQty = Home_GetTodaysKeyProductionValues.CompleteQty;
			PastDueQty = Home_GetTodaysKeyProductionValues.PastDueQty;
			
			#endregion ExecuteMethodCall
			
			return (Severity, pFiscalYear, InvSiteGrp, ApsParmApsmode, CanAdd, CanUpdate, CanDelete, PlanMode, Parm_DefWhse, UnpostedDCSFC, UnpostedDCJM, UnpostedDCJMRcpt, UnpostedJobLaborTrans, UnpostedDCJIT, UnpostedDCPS, UnpostedDCPSScrap, UnpostedJobMatlTrans, UnpostedDCSFCWCLabor, UnpostedDCSFCWCMachine, UnpostedDCWC, pCurPeriod, rPer1Start, rPer2Start, rPer3Start, rPer4Start, rPer5Start, rPer6Start, rPer7Start, rPer8Start, rPer9Start, rPer10Start, rPer11Start, rPer12Start, rPer13Start, rPer1End, rPer2End, rPer3End, rPer4End, rPer5End, rPer6End, rPer7End, rPer8End, rPer9End, rPer10End, rPer11End, rPer12End, rPer13End, CompleteQty, PastDueQty, Infobar);
			
		}
		
	}
}
