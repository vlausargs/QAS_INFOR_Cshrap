//PROJECT NAME: CSIFinance
//CLASS NAME: ValidateSpecifiedUnitCodeForDistribution.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance
{
    public interface IValidateSpecifiedUnitCodeForDistribution
    {
        int ValidateSpecifiedUnitCodeForDistributionSp(AcctType CompareAccount,
                                                       UnitCode1Type unit1,
                                                       UnitCode2Type unit2,
                                                       UnitCode3Type unit3,
                                                       UnitCode4Type unit4,
                                                       ref Infobar Infobar);
    }

    public class ValidateSpecifiedUnitCodeForDistribution : IValidateSpecifiedUnitCodeForDistribution
    {
        readonly IApplicationDB appDB;

        public ValidateSpecifiedUnitCodeForDistribution(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ValidateSpecifiedUnitCodeForDistributionSp(AcctType CompareAccount,
                                                              UnitCode1Type unit1,
                                                              UnitCode2Type unit2,
                                                              UnitCode3Type unit3,
                                                              UnitCode4Type unit4,
                                                              ref Infobar Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ValidateSpecifiedUnitCodeForDistributionSp";

                appDB.AddCommandParameter(cmd, "CompareAccount", CompareAccount, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "unit1", unit1, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "unit2", unit2, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "unit3", unit3, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "unit4", unit4, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
