//PROJECT NAME: FinanceExt
//CLASS NAME: SLFsbPeriods.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Finance;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Finance
{
    [IDOExtensionClass("SLFsbPeriods")]
    public class SLFsbPeriods : ExtensionClassBase
    {



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CheckFiscalYearSp(string PeriodName,
		                             short? NewFiscalYear,
		                             ref short? MaxFiscalYear,
		                             ref short? MinFiscalYear,
		                             ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iMultiFSBCheckFiscalYearExt = new MultiFSBCheckFiscalYearFactory().Create(appDb);
				
				var result = iMultiFSBCheckFiscalYearExt.MultiFSBCheckFiscalYearSp(PeriodName,
				                                                                   NewFiscalYear,
				                                                                   MaxFiscalYear,
				                                                                   MinFiscalYear,
				                                                                   Infobar);
				
				int Severity = result.ReturnCode.Value;
				MaxFiscalYear = result.MaxFiscalYear;
				MinFiscalYear = result.MinFiscalYear;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PeriodsGetCurrentSp(string PeriodName,
		                               [Optional] string Site,
		                               [Optional, DefaultParameterValue((byte)0)] ref byte? PeriodsCurPer,
		                               ref short? PeriodsFiscalYear,
		                               ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iMultiFSBPeriodsGetCurrentExt = new MultiFSBPeriodsGetCurrentFactory().Create(appDb);
				
				var result = iMultiFSBPeriodsGetCurrentExt.MultiFSBPeriodsGetCurrentSp(PeriodName,
				                                                                       Site,
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
        public int DateChkSp([Optional] string PeriodName,
        [Optional] DateTime? PDate,
        [Optional] string FieldLabel,
        [Optional] string FunctionLabel,
        [Optional] ref string Infobar,
        [Optional] ref string PromptMsg,
        [Optional] ref string PromptButtons)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iMultiFSBDateChkExt = new MultiFSBDateChkFactory().Create(appDb);

                var result = iMultiFSBDateChkExt.MultiFSBDateChkSp(PeriodName,
                PDate,
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
		public int FSBGetDescriptionByPeriodSp(string PeriodName,
		ref string PeriodDescription)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iFSBGetDescriptionByPeriodExt = new FSBGetDescriptionByPeriodFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iFSBGetDescriptionByPeriodExt.FSBGetDescriptionByPeriodSp(PeriodName,
				PeriodDescription);
				
				int Severity = result.ReturnCode.Value;
				PeriodDescription = result.PeriodDescription;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FSBGetNextFiscalYearStartDateSp(string PeriodName,
		ref int? NextFiscalYear,
		ref DateTime? NextStartDate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iFSBGetNextFiscalYearStartDateExt = new FSBGetNextFiscalYearStartDateFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iFSBGetNextFiscalYearStartDateExt.FSBGetNextFiscalYearStartDateSp(PeriodName,
				NextFiscalYear,
				NextStartDate);
				
				int Severity = result.ReturnCode.Value;
				NextFiscalYear = result.NextFiscalYear;
				NextStartDate = result.NextStartDate;
				return Severity;
			}
		}


        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetCurPeriodBeginEndDateSp(string FSBName,
        ref DateTime? RStartDate,
        ref DateTime? REndDate,
        ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var mgInvoker = new MGInvoker(this.Context);

                var iMultiFSBGetCurPeriodBeginEndDateExt = new MultiFSBGetCurPeriodBeginEndDateFactory().Create(appDb);

                var result = iMultiFSBGetCurPeriodBeginEndDateExt.MultiFSBGetCurPeriodBeginEndDateSp(FSBName,
                RStartDate,
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
        public int InitPeriodsTableSp(string PeriodName,
        string PeriodDesc)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var mgInvoker = new MGInvoker(this.Context);

                var iMultiFSBInitPeriodsTableExt = new MultiFSBInitPeriodsTableFactory().Create(appDb);

                int? Severity = iMultiFSBInitPeriodsTableExt.MultiFSBInitPeriodsTableSp(PeriodName,
                PeriodDesc);

                return Severity == null ? 0 : (int)Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ValidatePeriodClosedSp(int? FiscalYearClosed,
            int? Closed,
            ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var mgInvoker = new MGInvoker(this.Context);

                var iMultiFSBValidatePeriodClosedExt = new MultiFSBValidatePeriodClosedFactory().Create(appDb);

                var result = iMultiFSBValidatePeriodClosedExt.MultiFSBValidatePeriodClosedSp(FiscalYearClosed,
                    Closed,
                    Infobar);

                int Severity = result.ReturnCode.Value;
                Infobar = result.Infobar;
                return Severity;
            }
        }



        [IDOMethod(MethodFlags.None, "Infobar")]
        public int VerifyStartDateSp(string PeriodName,
        DateTime? PStartDate,
        short? PFiscalYear,
        ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iMultiFSBVerifyStartDateExt = new MultiFSBVerifyStartDateFactory().Create(appDb);

                var result = iMultiFSBVerifyStartDateExt.MultiFSBVerifyStartDateSp(PeriodName,
                PStartDate,
                PFiscalYear,
                Infobar);

                int Severity = result.ReturnCode.Value;
                Infobar = result.Infobar;
                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int PerGetSp(string PeriodName,
                            DateTime? Date,
                            [Optional] ref int? CurrentPeriod,
                            [Optional] ref Guid? PeriodsRowPointer,
                            ref string Infobar,
                            [Optional] string Site,
                            [Optional] ref short? PeriodsFiscalYear,
                            [Optional] ref DateTime? PeriodStartDate,
                            [Optional] ref DateTime? PeriodEndDate)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iMultiFSBPerGetExt = new MultiFSBPerGetFactory().Create(appDb);

                var result = iMultiFSBPerGetExt.MultiFSBPerGetSp(PeriodName,
                                                                 Date,
                                                                 CurrentPeriod,
                                                                 PeriodsRowPointer,
                                                                 Infobar,
                                                                 Site,
                                                                 PeriodsFiscalYear,
                                                                 PeriodStartDate,
                                                                 PeriodEndDate);

                int Severity = result.ReturnCode.Value;
                CurrentPeriod = result.CurrentPeriod;
                PeriodsRowPointer = result.PeriodsRowPointer;
                Infobar = result.Infobar;
                PeriodsFiscalYear = result.PeriodsFiscalYear;
                PeriodStartDate = result.PeriodStartDate;
                PeriodEndDate = result.PeriodEndDate;
                return Severity;
            }
        }
    }
}
