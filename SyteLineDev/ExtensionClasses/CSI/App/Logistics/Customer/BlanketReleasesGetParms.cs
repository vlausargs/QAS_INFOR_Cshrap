//PROJECT NAME: CSICustomer
//CLASS NAME: BlanketReleasesGetParms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IBlanketReleasesGetParms
    {
        int BlanketReleasesGetParmsSp(StringType Type,
                                      StringType Type1,
                                      ref ListYesNoType CanDueNEProjected,
                                      ref ListYesNoType CanDueLTProjected,
                                      ref DuePeriodType ParmDuePeriod,
                                      ref ApsModeType ApsParmApsmode,
                                      ref ListYesNoType ParmEcReporting);
    }

    public class BlanketReleasesGetParms : IBlanketReleasesGetParms
    {
        readonly IApplicationDB appDB;

        public BlanketReleasesGetParms(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int BlanketReleasesGetParmsSp(StringType Type,
                                             StringType Type1,
                                             ref ListYesNoType CanDueNEProjected,
                                             ref ListYesNoType CanDueLTProjected,
                                             ref DuePeriodType ParmDuePeriod,
                                             ref ApsModeType ApsParmApsmode,
                                             ref ListYesNoType ParmEcReporting)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "BlanketReleasesGetParmsSp";

                appDB.AddCommandParameter(cmd, "Type", Type, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Type1", Type1, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CanDueNEProjected", CanDueNEProjected, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CanDueLTProjected", CanDueLTProjected, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ParmDuePeriod", ParmDuePeriod, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ApsParmApsmode", ApsParmApsmode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ParmEcReporting", ParmEcReporting, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
