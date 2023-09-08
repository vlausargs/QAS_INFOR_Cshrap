//PROJECT NAME: CSIAPS
//CLASS NAME: ApsGetRuleValue.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.APS
{
    public interface IApsGetRuleValue
    {
        int ApsGetRuleValueSp(ApsSmallIntType PRuleType,
                              ApsMsgParmType PRuleValueDisplay,
                              ref ApsRulevalType PRuleValue);
    }

    public class ApsGetRuleValue : IApsGetRuleValue
    {
        readonly IApplicationDB appDB;

        public ApsGetRuleValue(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ApsGetRuleValueSp(ApsSmallIntType PRuleType,
                                     ApsMsgParmType PRuleValueDisplay,
                                     ref ApsRulevalType PRuleValue)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ApsGetRuleValueSp";

                appDB.AddCommandParameter(cmd, "PRuleType", PRuleType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PRuleValueDisplay", PRuleValueDisplay, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PRuleValue", PRuleValue, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
