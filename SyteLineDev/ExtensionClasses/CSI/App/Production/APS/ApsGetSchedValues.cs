//PROJECT NAME: CSIAPS
//CLASS NAME: ApsGetSchedValues.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.APS
{
    public interface IApsGetSchedValues
    {
        int ApsGetSchedValuesSp(ApsAltNoType AltNum,
                                DecimalType Threshold,
                                ref ApsIntType RGUtil,
                                ref ApsIntType OrdLate,
                                ref ApsIntType OrdOnTime,
                                ref ApsIntType RGQueue);
    }

    public class ApsGetSchedValues : IApsGetSchedValues
    {
        readonly IApplicationDB appDB;

        public ApsGetSchedValues(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ApsGetSchedValuesSp(ApsAltNoType AltNum,
                                       DecimalType Threshold,
                                       ref ApsIntType RGUtil,
                                       ref ApsIntType OrdLate,
                                       ref ApsIntType OrdOnTime,
                                       ref ApsIntType RGQueue)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ApsGetSchedValuesSp";

                appDB.AddCommandParameter(cmd, "AltNum", AltNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Threshold", Threshold, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RGUtil", RGUtil, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OrdLate", OrdLate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OrdOnTime", OrdOnTime, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RGQueue", RGQueue, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
