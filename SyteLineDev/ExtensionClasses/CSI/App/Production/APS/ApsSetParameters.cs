//PROJECT NAME: CSIAPS
//CLASS NAME: ApsSetParameters.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.APS
{
    public interface IApsSetParameters
    {
        int ApsSetParametersSp(ApsAltNoType AltNo,
                               ListYesNoType UseSupplyUsageTol,
                               ListYesNoType UsePlanForSched,
                               ListYesNoType PlanMatlAtOperStart,
                               ListYesNoType CalcJobEndDatesForFirm,
                               ListYesNoType CalcJobEndDatesForReleased,
                               ListYesNoType UseExpeditedLeadTime,
                               ListYesNoType UseLatestPullForAltItems,
                               ListYesNoType ApplyMaxThroughBOM,
                               ListYesNoType JobPSSupplySwitching,
                               ListYesNoType PlannedMfgSupplySwitching,
                               PlannerTraceLevelType PlannerTraceLevel,
                               ApsShiftType MFBSHIFTID,
                               ListYesNoType PlanPlanStopJob,
                               ListYesNoType PlanPlanStopedCO,
                               ListYesNoType PlanPlanPlannedCO,
                               ListYesNoType PlanPlanCreditHoldCO,
                               ListYesNoType DaysSupplyPlanning,
                               ListYesNoType PlanSafetyStockBeforeForecasts,
                               ListYesNoType PlanWhses,
                               ListYesNoType AllowForecastBOMSupplyItems,
                               ListYesNoType UseSchedTimesInPlanning,
                               ListYesNoType PreserveProdDates);
    }

    public class ApsSetParameters : IApsSetParameters
    {
        readonly IApplicationDB appDB;

        public ApsSetParameters(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ApsSetParametersSp(ApsAltNoType AltNo,
                                      ListYesNoType UseSupplyUsageTol,
                                      ListYesNoType UsePlanForSched,
                                      ListYesNoType PlanMatlAtOperStart,
                                      ListYesNoType CalcJobEndDatesForFirm,
                                      ListYesNoType CalcJobEndDatesForReleased,
                                      ListYesNoType UseExpeditedLeadTime,
                                      ListYesNoType UseLatestPullForAltItems,
                                      ListYesNoType ApplyMaxThroughBOM,
                                      ListYesNoType JobPSSupplySwitching,
                                      ListYesNoType PlannedMfgSupplySwitching,
                                      PlannerTraceLevelType PlannerTraceLevel,
                                      ApsShiftType MFBSHIFTID,
                                      ListYesNoType PlanPlanStopJob,
                                      ListYesNoType PlanPlanStopedCO,
                                      ListYesNoType PlanPlanPlannedCO,
                                      ListYesNoType PlanPlanCreditHoldCO,
                                      ListYesNoType DaysSupplyPlanning,
                                      ListYesNoType PlanSafetyStockBeforeForecasts,
                                      ListYesNoType PlanWhses,
                                      ListYesNoType AllowForecastBOMSupplyItems,
                                      ListYesNoType UseSchedTimesInPlanning,
                                      ListYesNoType PreserveProdDates)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ApsSetParametersSp";

                appDB.AddCommandParameter(cmd, "AltNo", AltNo, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UseSupplyUsageTol", UseSupplyUsageTol, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UsePlanForSched", UsePlanForSched, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PlanMatlAtOperStart", PlanMatlAtOperStart, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CalcJobEndDatesForFirm", CalcJobEndDatesForFirm, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CalcJobEndDatesForReleased", CalcJobEndDatesForReleased, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UseExpeditedLeadTime", UseExpeditedLeadTime, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UseLatestPullForAltItems", UseLatestPullForAltItems, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ApplyMaxThroughBOM", ApplyMaxThroughBOM, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "JobPSSupplySwitching", JobPSSupplySwitching, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PlannedMfgSupplySwitching", PlannedMfgSupplySwitching, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PlannerTraceLevel", PlannerTraceLevel, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "MFBSHIFTID", MFBSHIFTID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PlanPlanStopJob", PlanPlanStopJob, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PlanPlanStopedCO", PlanPlanStopedCO, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PlanPlanPlannedCO", PlanPlanPlannedCO, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PlanPlanCreditHoldCO", PlanPlanCreditHoldCO, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DaysSupplyPlanning", DaysSupplyPlanning, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PlanSafetyStockBeforeForecasts", PlanSafetyStockBeforeForecasts, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PlanWhses", PlanWhses, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AllowForecastBOMSupplyItems", AllowForecastBOMSupplyItems, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UseSchedTimesInPlanning", UseSchedTimesInPlanning, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PreserveProdDates", PreserveProdDates, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
