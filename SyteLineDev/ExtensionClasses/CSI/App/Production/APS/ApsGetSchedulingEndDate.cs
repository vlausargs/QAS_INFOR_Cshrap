//PROJECT NAME: CSIAPS
//CLASS NAME: ApsGetSchedulingEndDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.APS
{
    public interface IApsGetSchedulingEndDate
    {
        int ApsGetSchedulingEndDateSp(ref DateType PEndDate);
    }

    public class ApsGetSchedulingEndDate : IApsGetSchedulingEndDate
    {
        readonly IApplicationDB appDB;

        public ApsGetSchedulingEndDate(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ApsGetSchedulingEndDateSp(ref DateType PEndDate)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ApsGetSchedulingEndDateSp";

                appDB.AddCommandParameter(cmd, "PEndDate", PEndDate, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
