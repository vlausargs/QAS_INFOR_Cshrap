//PROJECT NAME: APSExt
//CLASS NAME: SLAltplans.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.APS;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.APS
{
    [IDOExtensionClass("SLAltplans")]
    public class SLAltplans : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ApsGetParametersSp(short? AltNo,
                                      ref byte? UseSupplyUsageTol,
                                      ref byte? UsePlanForSched,
                                      ref byte? PlanMatlAtOperStart,
                                      ref byte? CalcJobEndDatesForFirm,
                                      ref byte? CalcJobEndDatesForReleased,
                                      ref byte? UseExpeditedLeadTime,
                                      ref byte? UseLatestPullForAltItems,
                                      ref byte? ApplyMaxThroughBOM,
                                      ref byte? JobPSSupplySwitching,
                                      ref byte? PlannedMfgSupplySwitching,
                                      ref string PlannerTraceLevel,
                                      ref byte? PlanPlanStopJob,
                                      ref byte? PlanPlanStopedCO,
                                      ref byte? PlanPlanPlannedCO,
                                      ref byte? PlanPlanCreditHoldCO,
                                      ref byte? PlanSafetyStockBeforeForecasts,
                                      ref byte? PlanWhses,
                                      ref byte? AllowForecastBOMSupplyItems,
                                      ref byte? UseSchedTimesInPlanning,
                                      ref byte? PreserveProdDates)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iApsGetParametersExt = new ApsGetParametersFactory().Create(appDb);

                ListYesNoType oUseSupplyUsageTol = UseSupplyUsageTol;
                ListYesNoType oUsePlanForSched = UsePlanForSched;
                ListYesNoType oPlanMatlAtOperStart = PlanMatlAtOperStart;
                ListYesNoType oCalcJobEndDatesForFirm = CalcJobEndDatesForFirm;
                ListYesNoType oCalcJobEndDatesForReleased = CalcJobEndDatesForReleased;
                ListYesNoType oUseExpeditedLeadTime = UseExpeditedLeadTime;
                ListYesNoType oUseLatestPullForAltItems = UseLatestPullForAltItems;
                ListYesNoType oApplyMaxThroughBOM = ApplyMaxThroughBOM;
                ListYesNoType oJobPSSupplySwitching = JobPSSupplySwitching;
                ListYesNoType oPlannedMfgSupplySwitching = PlannedMfgSupplySwitching;
                PlannerTraceLevelType oPlannerTraceLevel = PlannerTraceLevel;
                ListYesNoType oPlanPlanStopJob = PlanPlanStopJob;
                ListYesNoType oPlanPlanStopedCO = PlanPlanStopedCO;
                ListYesNoType oPlanPlanPlannedCO = PlanPlanPlannedCO;
                ListYesNoType oPlanPlanCreditHoldCO = PlanPlanCreditHoldCO;
                ListYesNoType oPlanSafetyStockBeforeForecasts = PlanSafetyStockBeforeForecasts;
                ListYesNoType oPlanWhses = PlanWhses;
                ListYesNoType oAllowForecastBOMSupplyItems = AllowForecastBOMSupplyItems;
                ListYesNoType oUseSchedTimesInPlanning = UseSchedTimesInPlanning;
                ListYesNoType oPreserveProdDates = PreserveProdDates;

                int Severity = iApsGetParametersExt.ApsGetParametersSp(AltNo,
                                                                       ref oUseSupplyUsageTol,
                                                                       ref oUsePlanForSched,
                                                                       ref oPlanMatlAtOperStart,
                                                                       ref oCalcJobEndDatesForFirm,
                                                                       ref oCalcJobEndDatesForReleased,
                                                                       ref oUseExpeditedLeadTime,
                                                                       ref oUseLatestPullForAltItems,
                                                                       ref oApplyMaxThroughBOM,
                                                                       ref oJobPSSupplySwitching,
                                                                       ref oPlannedMfgSupplySwitching,
                                                                       ref oPlannerTraceLevel,
                                                                       ref oPlanPlanStopJob,
                                                                       ref oPlanPlanStopedCO,
                                                                       ref oPlanPlanPlannedCO,
                                                                       ref oPlanPlanCreditHoldCO,
                                                                       ref oPlanSafetyStockBeforeForecasts,
                                                                       ref oPlanWhses,
                                                                       ref oAllowForecastBOMSupplyItems,
                                                                       ref oUseSchedTimesInPlanning,
                                                                       ref oPreserveProdDates);

                UseSupplyUsageTol = oUseSupplyUsageTol;
                UsePlanForSched = oUsePlanForSched;
                PlanMatlAtOperStart = oPlanMatlAtOperStart;
                CalcJobEndDatesForFirm = oCalcJobEndDatesForFirm;
                CalcJobEndDatesForReleased = oCalcJobEndDatesForReleased;
                UseExpeditedLeadTime = oUseExpeditedLeadTime;
                UseLatestPullForAltItems = oUseLatestPullForAltItems;
                ApplyMaxThroughBOM = oApplyMaxThroughBOM;
                JobPSSupplySwitching = oJobPSSupplySwitching;
                PlannedMfgSupplySwitching = oPlannedMfgSupplySwitching;
                PlannerTraceLevel = oPlannerTraceLevel;
                PlanPlanStopJob = oPlanPlanStopJob;
                PlanPlanStopedCO = oPlanPlanStopedCO;
                PlanPlanPlannedCO = oPlanPlanPlannedCO;
                PlanPlanCreditHoldCO = oPlanPlanCreditHoldCO;
                PlanSafetyStockBeforeForecasts = oPlanSafetyStockBeforeForecasts;
                PlanWhses = oPlanWhses;
                AllowForecastBOMSupplyItems = oAllowForecastBOMSupplyItems;
                UseSchedTimesInPlanning = oUseSchedTimesInPlanning;
                PreserveProdDates = oPreserveProdDates;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ApsGetPlannerValuesSp(short? ALTNO,
                                         ref int? OrdLate,
                                         ref int? MfgItemShort,
                                         ref int? PurItemShort,
                                         ref int? RGBottle,
                                         ref int? ItemBottle)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iApsGetPlannerValuesExt = new ApsGetPlannerValuesFactory().Create(appDb);

                ApsIntType oOrdLate = OrdLate;
                ApsIntType oMfgItemShort = MfgItemShort;
                ApsIntType oPurItemShort = PurItemShort;
                ApsIntType oRGBottle = RGBottle;
                ApsIntType oItemBottle = ItemBottle;

                int Severity = iApsGetPlannerValuesExt.ApsGetPlannerValuesSp(ALTNO,
                                                                             ref oOrdLate,
                                                                             ref oMfgItemShort,
                                                                             ref oPurItemShort,
                                                                             ref oRGBottle,
                                                                             ref oItemBottle);

                OrdLate = oOrdLate;
                MfgItemShort = oMfgItemShort;
                PurItemShort = oPurItemShort;
                RGBottle = oRGBottle;
                ItemBottle = oItemBottle;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ApsSetParametersSp(short? AltNo,
                                      byte? UseSupplyUsageTol,
                                      byte? UsePlanForSched,
                                      byte? PlanMatlAtOperStart,
                                      byte? CalcJobEndDatesForFirm,
                                      byte? CalcJobEndDatesForReleased,
                                      byte? UseExpeditedLeadTime,
                                      byte? UseLatestPullForAltItems,
                                      byte? ApplyMaxThroughBOM,
                                      byte? JobPSSupplySwitching,
                                      byte? PlannedMfgSupplySwitching,
                                      string PlannerTraceLevel,
                                      string MFBSHIFTID,
                                      byte? PlanPlanStopJob,
                                      byte? PlanPlanStopedCO,
                                      byte? PlanPlanPlannedCO,
                                      byte? PlanPlanCreditHoldCO,
                                      byte? DaysSupplyPlanning,
                                      byte? PlanSafetyStockBeforeForecasts,
                                      byte? PlanWhses,
                                      byte? AllowForecastBOMSupplyItems,
                                      byte? UseSchedTimesInPlanning,
                                      byte? PreserveProdDates)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iApsSetParametersExt = new ApsSetParametersFactory().Create(appDb);

                int Severity = iApsSetParametersExt.ApsSetParametersSp(AltNo,
                                                                       UseSupplyUsageTol,
                                                                       UsePlanForSched,
                                                                       PlanMatlAtOperStart,
                                                                       CalcJobEndDatesForFirm,
                                                                       CalcJobEndDatesForReleased,
                                                                       UseExpeditedLeadTime,
                                                                       UseLatestPullForAltItems,
                                                                       ApplyMaxThroughBOM,
                                                                       JobPSSupplySwitching,
                                                                       PlannedMfgSupplySwitching,
                                                                       PlannerTraceLevel,
                                                                       MFBSHIFTID,
                                                                       PlanPlanStopJob,
                                                                       PlanPlanStopedCO,
                                                                       PlanPlanPlannedCO,
                                                                       PlanPlanCreditHoldCO,
                                                                       DaysSupplyPlanning,
                                                                       PlanSafetyStockBeforeForecasts,
                                                                       PlanWhses,
                                                                       AllowForecastBOMSupplyItems,
                                                                       UseSchedTimesInPlanning,
                                                                       PreserveProdDates);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_ApsGetAltPlanGraphSp(short? AltNo)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iCLM_ApsGetAltPlanGraphExt = new CLM_ApsGetAltPlanGraphFactory().Create(appDb, bunchedLoadCollection);

                DataTable dt = iCLM_ApsGetAltPlanGraphExt.CLM_ApsGetAltPlanGraphSp(AltNo);

                return dt;
            }
        }
    }
}
