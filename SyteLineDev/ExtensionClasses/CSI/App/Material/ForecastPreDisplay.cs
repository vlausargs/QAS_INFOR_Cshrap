//PROJECT NAME: CSIMaterial
//CLASS NAME: ForecastPreDisplay.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IForecastPreDisplay
    {
        int ForecastPreDisplaySp(ref PrivilegeType CanDueLTProjected,
                                 ref PrivilegeType CanDueNEProjected,
                                 ref DateType McalFirstDate,
                                 ref DateType McalLastDate,
                                 ref ApsModeType ApsParmApsmode,
                                 ref MrpReqSrcType MrpParmReqSrc,
                                 ref InfobarType Infobar);
    }

    public class ForecastPreDisplay : IForecastPreDisplay
    {
        readonly IApplicationDB appDB;

        public ForecastPreDisplay(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ForecastPreDisplaySp(ref PrivilegeType CanDueLTProjected,
                                        ref PrivilegeType CanDueNEProjected,
                                        ref DateType McalFirstDate,
                                        ref DateType McalLastDate,
                                        ref ApsModeType ApsParmApsmode,
                                        ref MrpReqSrcType MrpParmReqSrc,
                                        ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ForecastPreDisplaySp";

                appDB.AddCommandParameter(cmd, "CanDueLTProjected", CanDueLTProjected, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CanDueNEProjected", CanDueNEProjected, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "McalFirstDate", McalFirstDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "McalLastDate", McalLastDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ApsParmApsmode", ApsParmApsmode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "MrpParmReqSrc", MrpParmReqSrc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
