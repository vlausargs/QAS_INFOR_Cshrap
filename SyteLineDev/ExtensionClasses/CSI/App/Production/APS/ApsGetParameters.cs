//PROJECT NAME: CSIAPS
//CLASS NAME: ApsGetParameters.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.APS
{
    public interface IApsGetParameters
    {
        int ApsGetParametersSp(ApsAltNoType AltNo,
                               ref ListYesNoType UseSupplyUsageTol,
                               ref ListYesNoType UsePlanForSched,
                               ref ListYesNoType PlanMatlAtOperStart,
                               ref ListYesNoType CalcJobEndDatesForFirm,
                               ref ListYesNoType CalcJobEndDatesForReleased,
                               ref ListYesNoType UseExpeditedLeadTime,
                               ref ListYesNoType UseLatestPullForAltItems,
                               ref ListYesNoType ApplyMaxThroughBOM,
                               ref ListYesNoType JobPSSupplySwitching,
                               ref ListYesNoType PlannedMfgSupplySwitching,
                               ref PlannerTraceLevelType PlannerTraceLevel,
                               ref ListYesNoType PlanPlanStopJob,
                               ref ListYesNoType PlanPlanStopedCO,
                               ref ListYesNoType PlanPlanPlannedCO,
                               ref ListYesNoType PlanPlanCreditHoldCO,
                               ref ListYesNoType PlanSafetyStockBeforeForecasts,
                               ref ListYesNoType PlanWhses,
                               ref ListYesNoType AllowForecastBOMSupplyItems,
                               ref ListYesNoType UseSchedTimesInPlanning,
                               ref ListYesNoType PreserveProdDates);
    }

    public class ApsGetParameters : IApsGetParameters
    {
        readonly IApplicationDB appDB;

        public ApsGetParameters(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ApsGetParametersSp(ApsAltNoType AltNo,
                                      ref ListYesNoType UseSupplyUsageTol,
                                      ref ListYesNoType UsePlanForSched,
                                      ref ListYesNoType PlanMatlAtOperStart,
                                      ref ListYesNoType CalcJobEndDatesForFirm,
                                      ref ListYesNoType CalcJobEndDatesForReleased,
                                      ref ListYesNoType UseExpeditedLeadTime,
                                      ref ListYesNoType UseLatestPullForAltItems,
                                      ref ListYesNoType ApplyMaxThroughBOM,
                                      ref ListYesNoType JobPSSupplySwitching,
                                      ref ListYesNoType PlannedMfgSupplySwitching,
                                      ref PlannerTraceLevelType PlannerTraceLevel,
                                      ref ListYesNoType PlanPlanStopJob,
                                      ref ListYesNoType PlanPlanStopedCO,
                                      ref ListYesNoType PlanPlanPlannedCO,
                                      ref ListYesNoType PlanPlanCreditHoldCO,
                                      ref ListYesNoType PlanSafetyStockBeforeForecasts,
                                      ref ListYesNoType PlanWhses,
                                      ref ListYesNoType AllowForecastBOMSupplyItems,
                                      ref ListYesNoType UseSchedTimesInPlanning,
                                      ref ListYesNoType PreserveProdDates)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ApsGetParametersSp";

                appDB.AddCommandParameter(cmd, "AltNo", AltNo, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UseSupplyUsageTol", UseSupplyUsageTol, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "UsePlanForSched", UsePlanForSched, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PlanMatlAtOperStart", PlanMatlAtOperStart, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CalcJobEndDatesForFirm", CalcJobEndDatesForFirm, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CalcJobEndDatesForReleased", CalcJobEndDatesForReleased, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "UseExpeditedLeadTime", UseExpeditedLeadTime, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "UseLatestPullForAltItems", UseLatestPullForAltItems, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ApplyMaxThroughBOM", ApplyMaxThroughBOM, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "JobPSSupplySwitching", JobPSSupplySwitching, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PlannedMfgSupplySwitching", PlannedMfgSupplySwitching, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PlannerTraceLevel", PlannerTraceLevel, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PlanPlanStopJob", PlanPlanStopJob, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PlanPlanStopedCO", PlanPlanStopedCO, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PlanPlanPlannedCO", PlanPlanPlannedCO, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PlanPlanCreditHoldCO", PlanPlanCreditHoldCO, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PlanSafetyStockBeforeForecasts", PlanSafetyStockBeforeForecasts, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PlanWhses", PlanWhses, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "AllowForecastBOMSupplyItems", AllowForecastBOMSupplyItems, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "UseSchedTimesInPlanning", UseSchedTimesInPlanning, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PreserveProdDates", PreserveProdDates, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
