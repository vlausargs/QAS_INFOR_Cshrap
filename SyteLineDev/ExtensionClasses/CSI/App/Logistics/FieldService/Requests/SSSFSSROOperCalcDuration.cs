//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSSROOperCalcDuration.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
    public interface ISSSFSSROOperCalcDuration
    {
        int SSSFSSROOperCalcDurationSp(FSSRONumType SRONum,
                                       FSSROLineType SROLine,
                                       FSSROOperType SROOper,
                                       ref FixedHoursType Duration,
                                       ref FSDurationTypeType DurationUnits,
                                       ref Infobar Infobar);
    }

    public class SSSFSSROOperCalcDuration : ISSSFSSROOperCalcDuration
    {
        readonly IApplicationDB appDB;

        public SSSFSSROOperCalcDuration(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSFSSROOperCalcDurationSp(FSSRONumType SRONum,
                                              FSSROLineType SROLine,
                                              FSSROOperType SROOper,
                                              ref FixedHoursType Duration,
                                              ref FSDurationTypeType DurationUnits,
                                              ref Infobar Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSFSSROOperCalcDurationSp";

                appDB.AddCommandParameter(cmd, "SRONum", SRONum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SROLine", SROLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SROOper", SROOper, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Duration", Duration, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "DurationUnits", DurationUnits, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
