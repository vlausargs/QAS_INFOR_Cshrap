//PROJECT NAME: CSIMaterial
//CLASS NAME: ForecastDateCalc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IForecastDateCalc
    {
        int ForecastDateCalcSp(ItemType Item,
                               DateType Fcstdate,
                               ref InfobarType Infobar);
    }

    public class ForecastDateCalc : IForecastDateCalc
    {
        readonly IApplicationDB appDB;

        public ForecastDateCalc(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ForecastDateCalcSp(ItemType Item,
                                      DateType Fcstdate,
                                      ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ForecastDateCalcSp";

                appDB.AddCommandParameter(cmd, "Item", Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Fcstdate", Fcstdate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
