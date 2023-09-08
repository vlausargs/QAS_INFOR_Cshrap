//PROJECT NAME: ProjectsExt
//CLASS NAME: SLInvMs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.Projects;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using CSI.Logistics.Vendor;
using CSI.Logistics.Customer;

namespace CSI.MG.Projects
{
	[IDOExtensionClass("SLInvMs")]
	public class SLInvMs : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int AutonomAllInvMsSp(string ProjNum,
		                             ref byte? Refresh,
		                             ref string PromptMsg,
		                             ref string PromptButtons,
		                             ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iAutonomAllInvMsExt = new AutonomAllInvMsFactory().Create(appDb);
				
				int Severity = iAutonomAllInvMsExt.AutonomAllInvMsSp(ProjNum,
				                                                     ref Refresh,
				                                                     ref PromptMsg,
				                                                     ref PromptButtons,
				                                                     ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_InvMsNomSp(DateTime? PActDate,
		                                DateTime? PPlanDate,
		                                string Filter)
		{
			var iCLM_InvMsNomExt = new CLM_InvMsNomFactory().Create(this, true);

			var result = iCLM_InvMsNomExt.CLM_InvMsNomSp(PActDate,
				PPlanDate,
				Filter);

			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int Home_GetTodaysKeyProjectValuesSp(ref decimal? InvoiceAmountTot,
			ref decimal? RevenueAmountTot)
		{
			var iHome_GetTodaysKeyProjectValuesExt = new Home_GetTodaysKeyProjectValuesFactory().Create(this, true);
			
			var result = iHome_GetTodaysKeyProjectValuesExt.Home_GetTodaysKeyProjectValuesSp(InvoiceAmountTot,
				RevenueAmountTot);
			
			InvoiceAmountTot = result.InvoiceAmountTot;
			RevenueAmountTot = result.RevenueAmountTot;
			
			return result.ReturnCode??0;
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int InvMsSeqCheckReqSp(string PProjNum,
		                              string PMsNum,
		                              int? PTaskNum,
		                              ref string MsgPrompt,
		                              ref string MsgButtons,
		                              ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iInvMsSeqCheckReqExt = new InvMsSeqCheckReqFactory().Create(appDb);
				
				int Severity = iInvMsSeqCheckReqExt.InvMsSeqCheckReqSp(PProjNum,
				                                                       PMsNum,
				                                                       PTaskNum,
				                                                       ref MsgPrompt,
				                                                       ref MsgButtons,
				                                                       ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int AutonomInvMsSp(string InProjNum,
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
				
				var iAutonomInvMsExt = new AutonomInvMsFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iAutonomInvMsExt.AutonomInvMsSp(InProjNum,
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

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Home_MetricProjectMilestonesSp(string MilestoneIndicator)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iHome_MetricProjectMilestonesExt = new Home_MetricProjectMilestonesFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iHome_MetricProjectMilestonesExt.Home_MetricProjectMilestonesSp(MilestoneIndicator);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ProjInvMsLoadTotSp(DateTime? PCurrentPeriodStart,
		DateTime? PCurrentPeriodEnd,
		ref decimal? PTotPerPlanInvAmt,
		ref decimal? PTotPerActInvAmt,
		ref decimal? PTotPerNomPlanInvAmt,
		ref decimal? PTotPerNomActInvAmt,
		ref decimal? PTotYrPlanInvAmt,
		ref decimal? PTotYrActInvAmt,
		ref decimal? PTotYrNomPlanInvAmt,
		ref decimal? PTotYrNomActInvAmt)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iProjInvMsLoadTotExt = new ProjInvMsLoadTotFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iProjInvMsLoadTotExt.ProjInvMsLoadTotSp(PCurrentPeriodStart,
				PCurrentPeriodEnd,
				PTotPerPlanInvAmt,
				PTotPerActInvAmt,
				PTotPerNomPlanInvAmt,
				PTotPerNomActInvAmt,
				PTotYrPlanInvAmt,
				PTotYrActInvAmt,
				PTotYrNomPlanInvAmt,
				PTotYrNomActInvAmt);
				
				int Severity = result.ReturnCode.Value;
				PTotPerPlanInvAmt = result.PTotPerPlanInvAmt;
				PTotPerActInvAmt = result.PTotPerActInvAmt;
				PTotPerNomPlanInvAmt = result.PTotPerNomPlanInvAmt;
				PTotPerNomActInvAmt = result.PTotPerNomActInvAmt;
				PTotYrPlanInvAmt = result.PTotYrPlanInvAmt;
				PTotYrActInvAmt = result.PTotYrActInvAmt;
				PTotYrNomPlanInvAmt = result.PTotYrNomPlanInvAmt;
				PTotYrNomActInvAmt = result.PTotYrNomActInvAmt;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_NominatedInvoiceMilestonesSp(string PProjectStarting,
		string PProjectEnding,
		string PInvoiceMilestoneStarting,
		string PInvoiceMilestoneEnding,
		int? PPeriod,
		int? PNonPostedMSOnly,
		int? PYear,
		int? PPrintCost,
		[Optional] string PSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_NominatedInvoiceMilestonesExt = new Rpt_NominatedInvoiceMilestonesFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_NominatedInvoiceMilestonesExt.Rpt_NominatedInvoiceMilestonesSp(PProjectStarting,
				PProjectEnding,
				PInvoiceMilestoneStarting,
				PInvoiceMilestoneEnding,
				PPeriod,
				PNonPostedMSOnly,
				PYear,
				PPrintCost,
				PSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int UPD_InvMsNomSp(string pProjNum,
		string pInvMsNum,
		int? pNominated,
		decimal? pActInvAmt,
		DateTime? pActDate,
		decimal? pTaxableAmt,
		decimal? pActFreight,
		decimal? pMiscCharges,
		decimal? pPlanInvAmt,
		decimal? pPlanFreight,
		decimal? pPlanMiscCharges)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iUPD_InvMsNomExt = new UPD_InvMsNomFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iUPD_InvMsNomExt.UPD_InvMsNomSp(pProjNum,
				pInvMsNum,
				pNominated,
				pActInvAmt,
				pActDate,
				pTaxableAmt,
				pActFreight,
				pMiscCharges,
				pPlanInvAmt,
				pPlanFreight,
				pPlanMiscCharges);
				
				int Severity = result.Value;
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
