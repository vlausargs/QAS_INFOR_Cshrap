//PROJECT NAME: ProjectsExt
//CLASS NAME: SLRevMs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.Projects;
using CSI.Data.RecordSets;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Logistics.Vendor;
using CSI.Logistics.Customer;

namespace CSI.MG.Projects
{
	[IDOExtensionClass("SLRevMs")]
	public class SLRevMs : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_RevMsNomSp(DateTime? PActDate,
		                                DateTime? PPlanDate,
		                                string Filter)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_RevMsNomExt = new CLM_RevMsNomFactory().Create(appDb, bunchedLoadCollection);
				
				DataTable dt = iCLM_RevMsNomExt.CLM_RevMsNomSp(PActDate,
				                                               PPlanDate,
				                                               Filter);
				
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int AutonomAllRevMsSp(string ProjNum,
		                             ref int? Count,
		                             ref byte? Refresh,
		                             ref string PromptMsg,
		                             ref string PromptButtons,
		                             ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iAutonomAllRevMsExt = new AutonomAllRevMsFactory().Create(appDb);
				
				int Severity = iAutonomAllRevMsExt.AutonomAllRevMsSp(ProjNum,
				                                                     ref Count,
				                                                     ref Refresh,
				                                                     ref PromptMsg,
				                                                     ref PromptButtons,
				                                                     ref Infobar);
				
				return Severity;
			}
		}















		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RevMsInitSp(string ProjNum,
		ref string RevCalcMethod,
		ref decimal? RevCalcPct,
		ref decimal? RevCalcAmt,
		ref string CostCalcMethod,
		ref decimal? CostCalcPct,
		ref decimal? CostCalcAmt)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRevMsInitExt = new RevMsInitFactory().Create(appDb);
				
				var result = iRevMsInitExt.RevMsInitSp(ProjNum,
				RevCalcMethod,
				RevCalcPct,
				RevCalcAmt,
				CostCalcMethod,
				CostCalcPct,
				CostCalcAmt);
				
				int Severity = result.ReturnCode.Value;
				RevCalcMethod = result.RevCalcMethod;
				RevCalcPct = result.RevCalcPct;
				RevCalcAmt = result.RevCalcAmt;
				CostCalcMethod = result.CostCalcMethod;
				CostCalcPct = result.CostCalcPct;
				CostCalcAmt = result.CostCalcAmt;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RevMsSeqCheckReqSp(string PProjNum,
		string PMsNum,
		int? PTaskNum,
		ref string MsgPrompt,
		ref string MsgButtons,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRevMsSeqCheckReqExt = new RevMsSeqCheckReqFactory().Create(appDb);
				
				var result = iRevMsSeqCheckReqExt.RevMsSeqCheckReqSp(PProjNum,
				PMsNum,
				PTaskNum,
				MsgPrompt,
				MsgButtons,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				MsgPrompt = result.MsgPrompt;
				MsgButtons = result.MsgButtons;
				Infobar = result.Infobar;
				return Severity;
			}
		}









































		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RevCalcPlanSp(string IProjNum,
		string IMsNum,
		int? CalcAct,
		ref decimal? OActRev,
		ref decimal? OActMatlCost,
		ref decimal? OActLaborCost,
		ref decimal? OActOvhCost,
		ref decimal? OActGaCost,
		ref decimal? OActOtherCost,
		[Optional] ref DateTime? OPlanDate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRevCalcExt = new RevCalcFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRevCalcExt.RevCalcSp(IProjNum,
				IMsNum,
				CalcAct,
				OActRev,
				OActMatlCost,
				OActLaborCost,
				OActOvhCost,
				OActGaCost,
				OActOtherCost,
				OPlanDate);
				
				int Severity = result.ReturnCode.Value;
				OActRev = result.OActRev;
				OActMatlCost = result.OActMatlCost;
				OActLaborCost = result.OActLaborCost;
				OActOvhCost = result.OActOvhCost;
				OActGaCost = result.OActGaCost;
				OActOtherCost = result.OActOtherCost;
				OPlanDate = result.OPlanDate;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RevCalcSp(string IProjNum,
		string IMsNum,
		int? CalcAct,
		ref decimal? OActRev,
		ref decimal? OActMatlCost,
		ref decimal? OActLaborCost,
		ref decimal? OActOvhCost,
		ref decimal? OActGaCost,
		ref decimal? OActOtherCost,
		[Optional] ref DateTime? OPlanDate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRevCalcExt = new RevCalcFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRevCalcExt.RevCalcSp(IProjNum,
				IMsNum,
				CalcAct,
				OActRev,
				OActMatlCost,
				OActLaborCost,
				OActOvhCost,
				OActGaCost,
				OActOtherCost,
				OPlanDate);
				
				int Severity = result.ReturnCode.Value;
				OActRev = result.OActRev;
				OActMatlCost = result.OActMatlCost;
				OActLaborCost = result.OActLaborCost;
				OActOvhCost = result.OActOvhCost;
				OActGaCost = result.OActGaCost;
				OActOtherCost = result.OActOtherCost;
				OPlanDate = result.OPlanDate;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable RevMsPostSp(string Process,
		string FromProjNum,
		string ToProjNum,
		string FromRevMsNum,
		string ToRevMsNum,
		int? MsPeriod,
		int? MsYear,
		DateTime? PostDate,
		string PrintLevel,
		string PostLevel)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRevMsPostExt = new RevMsPostFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRevMsPostExt.RevMsPostSp(Process,
				FromProjNum,
				ToProjNum,
				FromRevMsNum,
				ToRevMsNum,
				MsPeriod,
				MsYear,
				PostDate,
				PrintLevel,
				PostLevel);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int UPD_RevMsNomSp(string pProjNum,
		string pRevMsNum,
		int? pNominated,
		DateTime? pPlanDate,
		decimal? pPlanMatlCost,
		decimal? pPlanLaborCost,
		decimal? pPlanOtherCost,
		decimal? pPlanOvhCost,
		decimal? pPlanGACost,
		decimal? pPlanRev,
		DateTime? pActDate,
		decimal? pActMatlCost,
		decimal? pActLaborCost,
		decimal? pActOtherCost,
		decimal? pActOvhCost,
		decimal? pActGACost,
		decimal? pActRev)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iUPD_RevMsNomExt = new UPD_RevMsNomFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iUPD_RevMsNomExt.UPD_RevMsNomSp(pProjNum,
				pRevMsNum,
				pNominated,
				pPlanDate,
				pPlanMatlCost,
				pPlanLaborCost,
				pPlanOtherCost,
				pPlanOvhCost,
				pPlanGACost,
				pPlanRev,
				pActDate,
				pActMatlCost,
				pActLaborCost,
				pActOtherCost,
				pActOvhCost,
				pActGACost,
				pActRev);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int AutonomRevMsSp(string InProjNum,
		string InMsNum,
		ref int? CanBeNom,
		ref DateTime? NomDate,
		ref int? TReq,
		ref int? PNotProcess,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iAutonomRevMsExt = new AutonomRevMsFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iAutonomRevMsExt.AutonomRevMsSp(InProjNum,
				InMsNum,
				CanBeNom,
				NomDate,
				TReq,
				PNotProcess,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				CanBeNom = result.CanBeNom;
				NomDate = result.NomDate;
				TReq = result.TReq;
				PNotProcess = result.PNotProcess;
				Infobar = result.Infobar;
				return Severity;
			}
		}










		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ProjGetMsPeriodSp(DateTime? MsPlanDate,
		DateTime? MsActDate,
		ref int? CurrentPeriod,
		ref DateTime? CurrentPeriodStart,
		ref DateTime? CurrentPeriodEnd,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var iProjGetMsPeriodExt = new ProjGetMsPeriodFactory().Create(this, true);
				
				var result = iProjGetMsPeriodExt.ProjGetMsPeriodSp(MsPlanDate,
				MsActDate,
				CurrentPeriod,
				CurrentPeriodStart,
				CurrentPeriodEnd,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				CurrentPeriod = result.CurrentPeriod;
				CurrentPeriodStart = result.CurrentPeriodStart;
				CurrentPeriodEnd = result.CurrentPeriodEnd;
				Infobar = result.Infobar;
				return Severity;
			}
		}





















		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_DomesticCurrencySp(string CurrCode,
		[Optional, DefaultParameterValue(0)] int? UseBuyRate,
		[Optional] decimal? TRate,
		[Optional] DateTime? PossibleDate,
		[Optional] decimal? Amount1,
		[Optional] decimal? Amount2,
		[Optional] decimal? Amount3,
		[Optional] decimal? Amount4,
		[Optional] decimal? Amount5,
		[Optional] decimal? Amount6,
		[Optional] decimal? Amount7,
		[Optional] decimal? Amount8,
		[Optional] decimal? Amount9,
		[Optional] decimal? Amount10,
		[Optional] decimal? Amount11,
		[Optional] decimal? Amount12,
		[Optional] decimal? Amount13,
		[Optional] decimal? Amount14,
		[Optional] decimal? Amount15,
		[Optional] decimal? Amount16,
		[Optional] decimal? Amount17,
		[Optional] decimal? Amount18,
		[Optional] decimal? Amount19,
		[Optional] decimal? Amount20,
		[Optional] decimal? Amount21,
		[Optional] decimal? Amount22,
		[Optional] decimal? Amount23,
		[Optional] decimal? Amount24,
		[Optional] decimal? Amount25,
		[Optional] decimal? Amount26,
		[Optional] decimal? Amount27,
		[Optional] decimal? Amount28,
		[Optional] decimal? Amount29,
		[Optional] decimal? Amount30,
		[Optional] decimal? Amount31,
		[Optional] decimal? Amount32,
		[Optional] decimal? Amount33,
		[Optional] decimal? Amount34,
		[Optional] decimal? Amount35,
		[Optional] decimal? Amount36,
		[Optional] decimal? Amount37,
		[Optional] decimal? Amount38,
		[Optional] decimal? Amount39,
		[Optional] decimal? Amount40)
		{
			var iCLM_DomesticCurrencyExt = new CLM_DomesticCurrencyFactory().Create(this, true);
				
			var result = iCLM_DomesticCurrencyExt.CLM_DomesticCurrencySp(CurrCode,
			UseBuyRate,
			TRate,
			PossibleDate,
			Amount1,
			Amount2,
			Amount3,
			Amount4,
			Amount5,
			Amount6,
			Amount7,
			Amount8,
			Amount9,
			Amount10,
			Amount11,
			Amount12,
			Amount13,
			Amount14,
			Amount15,
			Amount16,
			Amount17,
			Amount18,
			Amount19,
			Amount20,
			Amount21,
			Amount22,
			Amount23,
			Amount24,
			Amount25,
			Amount26,
			Amount27,
			Amount28,
			Amount29,
			Amount30,
			Amount31,
			Amount32,
			Amount33,
			Amount34,
			Amount35,
			Amount36,
			Amount37,
			Amount38,
			Amount39,
			Amount40);
				
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
		}
	}
}
