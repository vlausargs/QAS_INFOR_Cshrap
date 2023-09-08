//PROJECT NAME: CSIAPS
//CLASS NAME: ApsGetGanttDates.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.APS
{
    public interface IApsGetGanttDates
    {
        int ApsGetGanttDatesSp(ApsAltNoType AltNo,
                               IntType DataType,
                               ref GenericDateType StartDate,
                               ref GenericDateType EndDate);
    }

    public class ApsGetGanttDates : IApsGetGanttDates
    {
        readonly IApplicationDB appDB;

        public ApsGetGanttDates(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ApsGetGanttDatesSp(ApsAltNoType AltNo,
                                      IntType DataType,
                                      ref GenericDateType StartDate,
                                      ref GenericDateType EndDate)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ApsGetGanttDatesSp";

                appDB.AddCommandParameter(cmd, "AltNo", AltNo, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DataType", DataType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartDate", StartDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "EndDate", EndDate, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
