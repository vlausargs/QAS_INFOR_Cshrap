//PROJECT NAME: CSIFinance
//CLASS NAME: ValidateUnitCodeForDistribution.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance
{
    public interface IValidateUnitCodeForDistribution
    {
        int ValidateUnitCodeForDistributionSp(AcctType TargetAccount,
                                              AcctType DistributionAccount,
                                              ref Infobar Infobar);
    }

    public class ValidateUnitCodeForDistribution : IValidateUnitCodeForDistribution
    {
        readonly IApplicationDB appDB;

        public ValidateUnitCodeForDistribution(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ValidateUnitCodeForDistributionSp(AcctType TargetAccount,
                                                     AcctType DistributionAccount,
                                                     ref Infobar Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ValidateUnitCodeForDistributionSp";

                appDB.AddCommandParameter(cmd, "TargetAccount", TargetAccount, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DistributionAccount", DistributionAccount, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}