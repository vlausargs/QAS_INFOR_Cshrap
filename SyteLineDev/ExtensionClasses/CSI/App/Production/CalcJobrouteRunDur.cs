//PROJECT NAME: CSIProduct
//CLASS NAME: CalcJobrouteRunDur.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface ICalcJobrouteRunDur
    {
        int CalcJobrouteRunDurSp(JobType pItemJob,
                                 SuffixType pItemSuffix,
                                 OperNumType pJobrouteOperNum,
                                 EfficiencyType pJobrouteEfficiency,
                                 ref QtyUnitType rJobrouteRunDur,
                                 ref InfobarType Infobar);
    }

    public class CalcJobrouteRunDur : ICalcJobrouteRunDur
    {
        readonly IApplicationDB appDB;

        public CalcJobrouteRunDur(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CalcJobrouteRunDurSp(JobType pItemJob,
                                        SuffixType pItemSuffix,
                                        OperNumType pJobrouteOperNum,
                                        EfficiencyType pJobrouteEfficiency,
                                        ref QtyUnitType rJobrouteRunDur,
                                        ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CalcJobrouteRunDurSp";

                appDB.AddCommandParameter(cmd, "pItemJob", pItemJob, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pItemSuffix", pItemSuffix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pJobrouteOperNum", pJobrouteOperNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pJobrouteEfficiency", pJobrouteEfficiency, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "rJobrouteRunDur", rJobrouteRunDur, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
