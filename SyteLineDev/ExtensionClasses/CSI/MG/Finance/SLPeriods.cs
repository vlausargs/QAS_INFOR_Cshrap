//PROJECT NAME: FinanceExt
//CLASS NAME: SLPeriods.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Finance;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.ExternalContracts.FactoryTrack;
using CSI.Admin;
using CSI.Data.RecordSets;

namespace CSI.MG.Finance
{
    [IDOExtensionClass("SLPeriods")]
    public class SLPeriods : CSIExtensionClassBase, IExtFTSLPeriods
    {

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CheckFiscalYearSp(int? NewFiscalYear,
		                             ref int? MaxFiscalYear,
		                             ref int? MinFiscalYear,
		                             ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCheckFiscalYearExt = new CheckFiscalYearFactory().Create(appDb);
				
				int Severity = iCheckFiscalYearExt.CheckFiscalYearSp(NewFiscalYear,
				                                                     ref MaxFiscalYear,
				                                                     ref MinFiscalYear,
				                                                     ref Infobar);
				
				return Severity;
			}
		}






		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PeriodsCompareSp([Optional] string Site,
		                            [Optional] string CutOffDateLabel,
		                            DateTime? CutOffDate,
		                            [Optional] string CtaDateLabel,
		                            DateTime? CtaDate,
		                            string Function,
		                            ref string PromptMsg,
		                            ref string PromptButtons,
		                            ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPeriodsCompareExt = new PeriodsCompareFactory().Create(appDb);
				
				var result = iPeriodsCompareExt.PeriodsCompareSp(Site,
				                                                 CutOffDateLabel,
				                                                 CutOffDate,
				                                                 CtaDateLabel,
				                                                 CtaDate,
				                                                 Function,
				                                                 PromptMsg,
				                                                 PromptButtons,
				                                                 Infobar);
				
				int Severity = result.ReturnCode.Value;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PeriodsGetCurrentSp([Optional] string Site,
		                               [Optional, DefaultParameterValue((byte)0)] ref byte? PeriodsCurPer,
		ref short? PeriodsFiscalYear,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPeriodsGetCurrentExt = new PeriodsGetCurrentFactory().Create(appDb);
				
				var result = iPeriodsGetCurrentExt.PeriodsGetCurrentSp(Site,
				                                                       PeriodsCurPer,
				                                                       PeriodsFiscalYear,
				                                                       Infobar);
				
				int Severity = result.ReturnCode.Value;
				PeriodsCurPer = result.PeriodsCurPer;
				PeriodsFiscalYear = result.PeriodsFiscalYear;
				Infobar = result.Infobar;
				return Severity;
			}
		}













		[IDOMethod(MethodFlags.None, "Infobar")]
		public int VerifyEndDateSp(int? PFiscalYear,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iVerifyEndDateExt = new VerifyEndDateFactory().Create(appDb);
				
				var result = iVerifyEndDateExt.VerifyEndDateSp(PFiscalYear,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CheckEndDateSp(DateTime? EndDate,
		DateTime? NextPeriodStartDate,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCheckEndDateExt = new CheckEndDateFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCheckEndDateExt.CheckEndDateSp(EndDate,
				NextPeriodStartDate,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CheckStartDateSp(DateTime? StartDate,
		DateTime? LastPeriodEndDate,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCheckStartDateExt = new CheckStartDateFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCheckStartDateExt.CheckStartDateSp(StartDate,
				LastPeriodEndDate,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DateChkSp([Optional] DateTime? PDate,
		[Optional] string FieldLabel,
		[Optional] string FunctionLabel,
		[Optional] ref string Infobar,
		[Optional] ref string PromptMsg,
		[Optional] ref string PromptButtons)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iDateChkExt = new CSI.Material.DateChkFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iDateChkExt.DateChkSp(PDate,
				FieldLabel,
				FunctionLabel,
				Infobar,
				PromptMsg,
				PromptButtons);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DeleteBudgetSp(int? FiscalYear,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iDeleteBudgetExt = new DeleteBudgetFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iDeleteBudgetExt.DeleteBudgetSp(FiscalYear,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetCurPeriodBeginEndDateSp(ref DateTime? RStartDate,
		ref DateTime? REndDate,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetCurPeriodBeginEndDateExt = new GetCurPeriodBeginEndDateFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetCurPeriodBeginEndDateExt.GetCurPeriodBeginEndDateSp(RStartDate,
				REndDate,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				RStartDate = result.RStartDate;
				REndDate = result.REndDate;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetCurPeriodSp(ref int? pCurPeriod)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetCurPeriodExt = new GetCurPeriodFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetCurPeriodExt.GetCurPeriodSp(pCurPeriod);
				
				int Severity = result.ReturnCode.Value;
				pCurPeriod = result.pCurPeriod;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetFirstFiscalYearSp(ref int? FirstFiscalYear)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetFirstFiscalYearExt = new GetFirstFiscalYearFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetFirstFiscalYearExt.GetFirstFiscalYearSp(FirstFiscalYear);
				
				int Severity = result.ReturnCode.Value;
				FirstFiscalYear = result.FirstFiscalYear;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetFiscalYearStartAndEndDateSp(ref DateTime? FiscalYearStartDate,
		ref DateTime? FiscalYearEndDate,
		ref int? FiscalYear,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetFiscalYearStartAndEndDateExt = new GetFiscalYearStartAndEndDateFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetFiscalYearStartAndEndDateExt.GetFiscalYearStartAndEndDateSp(FiscalYearStartDate,
				FiscalYearEndDate,
				FiscalYear,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				FiscalYearStartDate = result.FiscalYearStartDate;
				FiscalYearEndDate = result.FiscalYearEndDate;
				FiscalYear = result.FiscalYear;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetNextFiscalYearSp(ref int? NextFiscalYear)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetNextFiscalYearExt = new GetNextFiscalYearFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetNextFiscalYearExt.GetNextFiscalYearSp(NextFiscalYear);
				
				int Severity = result.ReturnCode.Value;
				NextFiscalYear = result.NextFiscalYear;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetNextStartDateSp(ref DateTime? NextStartDate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetNextStartDateExt = new GetNextStartDateFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetNextStartDateExt.GetNextStartDateSp(NextStartDate);
				
				int Severity = result.ReturnCode.Value;
				NextStartDate = result.NextStartDate;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int InitPeriodsTableSp(ref int? pAllowInsertForSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iInitPeriodsTableExt = new InitPeriodsTableFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iInitPeriodsTableExt.InitPeriodsTableSp(pAllowInsertForSite);
				
				int Severity = result.ReturnCode.Value;
				pAllowInsertForSite = result.pAllowInsertForSite;
				return Severity;
			}
		}



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PerGetSp(DateTime? Date,
		[Optional] ref int? CurrentPeriod,
		[Optional] ref Guid? PeriodsRowPointer,
		ref string Infobar,
		[Optional] string Site,
		[Optional] ref int? PeriodsFiscalYear,
		[Optional] ref string CurPeriodStatus)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPerGetExt = new PerGetFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPerGetExt.PerGetSp(Date,
				CurrentPeriod,
				PeriodsRowPointer,
				Infobar,
				Site,
				PeriodsFiscalYear,
				CurPeriodStatus);
				
				int Severity = result.ReturnCode.Value;
				CurrentPeriod = result.CurrentPeriod;
				PeriodsRowPointer = result.PeriodsRowPointer;
				Infobar = result.Infobar;
				PeriodsFiscalYear = result.PeriodsFiscalYear;
				CurPeriodStatus = result.CurPeriodStatus;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PeriodsYTDSp(ref DateTime? YearStart,
		ref DateTime? YearEnd,
		ref DateTime? PeriodStart,
		ref DateTime? PeriodEnd,
		ref DateTime? LastYearStart,
		ref DateTime? LastYearEnd,
		ref DateTime? FiscalYearStart,
		ref DateTime? FiscalYearEnd,
		ref DateTime? FiscalPeriodStart,
		ref DateTime? FiscalPeriodEnd,
		ref DateTime? FiscalLastYearStart,
		ref DateTime? FiscalLastYearEnd)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPeriodsYTDExt = new PeriodsYTDFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPeriodsYTDExt.PeriodsYTDSp(YearStart,
				YearEnd,
				PeriodStart,
				PeriodEnd,
				LastYearStart,
				LastYearEnd,
				FiscalYearStart,
				FiscalYearEnd,
				FiscalPeriodStart,
				FiscalPeriodEnd,
				FiscalLastYearStart,
				FiscalLastYearEnd);
				
				int Severity = result.ReturnCode.Value;
				YearStart = result.YearStart;
				YearEnd = result.YearEnd;
				PeriodStart = result.PeriodStart;
				PeriodEnd = result.PeriodEnd;
				LastYearStart = result.LastYearStart;
				LastYearEnd = result.LastYearEnd;
				FiscalYearStart = result.FiscalYearStart;
				FiscalYearEnd = result.FiscalYearEnd;
				FiscalPeriodStart = result.FiscalPeriodStart;
				FiscalPeriodEnd = result.FiscalPeriodEnd;
				FiscalLastYearStart = result.FiscalLastYearStart;
				FiscalLastYearEnd = result.FiscalLastYearEnd;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PreDeleteCheckSp(int? FiscalYear,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPreDeleteCheckExt = new PreDeleteCheckFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPreDeleteCheckExt.PreDeleteCheckSp(FiscalYear,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}


        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ValidatePeriodClosedSp(int? FiscalYearClosed,
			int? Closed,
			ref string Infobar)
        {
            var iValidatePeriodClosedExt = new ValidatePeriodClosedFactory().Create(this, true);

            var result = iValidatePeriodClosedExt.ValidatePeriodClosedSp(FiscalYearClosed,
				Closed,
				Infobar);

            Infobar = result.Infobar;

            return result.ReturnCode ?? 0;
        }


        [IDOMethod(MethodFlags.None, "Infobar")]
		public int VerifyStartDateSp(DateTime? PStartDate,
		int? PFiscalYear,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iVerifyStartDateExt = new VerifyStartDateFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iVerifyStartDateExt.VerifyStartDateSp(PStartDate,
				PFiscalYear,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
