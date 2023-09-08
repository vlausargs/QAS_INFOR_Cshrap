//PROJECT NAME: CSIAPS
//CLASS NAME: ApsGetSchedulingStartDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.APS
{
    public interface IApsGetSchedulingStartDate
    {
        int ApsGetSchedulingStartDateSp(ref DateType PStartDate);
        DateTime? ApsGetSchedulingStartDateFn(
            int? AltNum);
    }

    public class ApsGetSchedulingStartDate : IApsGetSchedulingStartDate
    {
        readonly IApplicationDB appDB;

        public ApsGetSchedulingStartDate(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ApsGetSchedulingStartDateSp(ref DateType PStartDate)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ApsGetSchedulingStartDateSp";

                appDB.AddCommandParameter(cmd, "PStartDate", PStartDate, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
        public DateTime? ApsGetSchedulingStartDateFn(
            int? AltNum)
        {
            ApsAltNoType _AltNum = AltNum;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  dbo.[ApsGetSchedulingStartDate](@AltNum)";

                appDB.AddCommandParameter(cmd, "AltNum", _AltNum, ParameterDirection.Input);

                var Output = appDB.ExecuteScalar<DateTime?>(cmd);

                return Output;
            }
        }

    }
}
