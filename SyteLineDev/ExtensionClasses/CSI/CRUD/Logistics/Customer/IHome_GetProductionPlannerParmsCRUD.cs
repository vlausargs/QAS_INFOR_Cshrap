//PROJECT NAME: Logistics
//CLASS NAME: IHome_GetProductionPlannerParmsCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHome_GetProductionPlannerParmsCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse Optional_Module1Select();
		void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
		ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
		void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		(int? ReturnCode, int? pFiscalYear,string InvSiteGrp,string ApsParmApsmode,int? CanAdd,int? CanUpdate,int? CanDelete,string PlanMode,string Parm_DefWhse,int? UnpostedDCSFC,int? UnpostedDCJM,int? UnpostedDCJMRcpt,int? UnpostedJobLaborTrans,int? UnpostedDCJIT,int? UnpostedDCPS,int? UnpostedDCPSScrap,int? UnpostedJobMatlTrans,int? UnpostedDCSFCWCLabor,int? UnpostedDCSFCWCMachine,int? UnpostedDCWC,int? pCurPeriod,DateTime? rPer1Start,DateTime? rPer2Start,DateTime? rPer3Start,DateTime? rPer4Start,DateTime? rPer5Start,DateTime? rPer6Start,DateTime? rPer7Start,DateTime? rPer8Start,DateTime? rPer9Start,DateTime? rPer10Start,DateTime? rPer11Start,DateTime? rPer12Start,DateTime? rPer13Start,DateTime? rPer1End,DateTime? rPer2End,DateTime? rPer3End,DateTime? rPer4End,DateTime? rPer5End,DateTime? rPer6End,DateTime? rPer7End,DateTime? rPer8End,DateTime? rPer9End,DateTime? rPer10End,DateTime? rPer11End,DateTime? rPer12End,DateTime? rPer13End,int? CompleteQty,int? PastDueQty,string Infobar) AltExtGen_Home_GetProductionPlannerParmsSp(string AltExtGenSp, decimal? Userid, int? pFiscalYear, string InvSiteGrp, string ApsParmApsmode, int? CanAdd, int? CanUpdate, int? CanDelete, string PlanMode, string Parm_DefWhse, int? UnpostedDCSFC, int? UnpostedDCJM, int? UnpostedDCJMRcpt, int? UnpostedJobLaborTrans, int? UnpostedDCJIT, int? UnpostedDCPS, int? UnpostedDCPSScrap, int? UnpostedJobMatlTrans, int? UnpostedDCSFCWCLabor, int? UnpostedDCSFCWCMachine, int? UnpostedDCWC, int? pCurPeriod, DateTime? rPer1Start, DateTime? rPer2Start, DateTime? rPer3Start, DateTime? rPer4Start, DateTime? rPer5Start, DateTime? rPer6Start, DateTime? rPer7Start, DateTime? rPer8Start, DateTime? rPer9Start, DateTime? rPer10Start, DateTime? rPer11Start, DateTime? rPer12Start, DateTime? rPer13Start, DateTime? rPer1End, DateTime? rPer2End, DateTime? rPer3End, DateTime? rPer4End, DateTime? rPer5End, DateTime? rPer6End, DateTime? rPer7End, DateTime? rPer8End, DateTime? rPer9End, DateTime? rPer10End, DateTime? rPer11End, DateTime? rPer12End, DateTime? rPer13End, int? CompleteQty, int? PastDueQty, string Infobar);
	}
}

