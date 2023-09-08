//PROJECT NAME: CSIProduct
//CLASS NAME: SetWcValuesForCurrOper.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface ISetWcValuesForCurrOper
    {
        int SetWcValuesForCurrOperSp(WcType Wc,
                                     ref ListYesNoType CntrlPoint,
                                     ref BflushTypeType BflushType,
                                     ref RunRateType SetupRate,
                                     ref EfficiencyType Efficiency,
                                     ref OverheadRateType FovhdRateMch,
                                     ref OverheadRateType VovhdRateMch,
                                     ref RunRateType RunRateLbr,
                                     ref SchedHoursType JshQueueHrs,
                                     ref SchedHoursType JshMoveHrs,
                                     ref OverheadRateType VarovhdRate,
                                     ref OverheadRateType FixovhdRate,
                                     ref SchedHoursType FinishHrs,
                                     ref SchedDriverType SchedDrv,
                                     ref Infobar Infobar);
    }

    public class SetWcValuesForCurrOper : ISetWcValuesForCurrOper
    {
        readonly IApplicationDB appDB;

        public SetWcValuesForCurrOper(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SetWcValuesForCurrOperSp(WcType Wc,
                                            ref ListYesNoType CntrlPoint,
                                            ref BflushTypeType BflushType,
                                            ref RunRateType SetupRate,
                                            ref EfficiencyType Efficiency,
                                            ref OverheadRateType FovhdRateMch,
                                            ref OverheadRateType VovhdRateMch,
                                            ref RunRateType RunRateLbr,
                                            ref SchedHoursType JshQueueHrs,
                                            ref SchedHoursType JshMoveHrs,
                                            ref OverheadRateType VarovhdRate,
                                            ref OverheadRateType FixovhdRate,
                                            ref SchedHoursType FinishHrs,
                                            ref SchedDriverType SchedDrv,
                                            ref Infobar Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SetWcValuesForCurrOperSp";

                appDB.AddCommandParameter(cmd, "Wc", Wc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CntrlPoint", CntrlPoint, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "BflushType", BflushType, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "SetupRate", SetupRate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Efficiency", Efficiency, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "FovhdRateMch", FovhdRateMch, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "VovhdRateMch", VovhdRateMch, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RunRateLbr", RunRateLbr, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "JshQueueHrs", JshQueueHrs, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "JshMoveHrs", JshMoveHrs, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "VarovhdRate", VarovhdRate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "FixovhdRate", FixovhdRate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "FinishHrs", FinishHrs, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "SchedDrv", SchedDrv, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
