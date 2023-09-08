//PROJECT NAME: CSIEmployee
//CLASS NAME: GenerateEmploymentPeriods.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
    public interface IGenerateEmploymentPeriods
    {
        int GenerateEmploymentPeriodsSp(EmpNumType EmpNum,
                                        DateType HireDate,
                                        ListYesNoType UseinAdjustedHireDateCalc,
                                        ref InfobarType Infobar);
    }

    public class GenerateEmploymentPeriods : IGenerateEmploymentPeriods
    {
        readonly IApplicationDB appDB;

        public GenerateEmploymentPeriods(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int GenerateEmploymentPeriodsSp(EmpNumType EmpNum,
                                               DateType HireDate,
                                               ListYesNoType UseinAdjustedHireDateCalc,
                                               ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GenerateEmploymentPeriodsSp";

                appDB.AddCommandParameter(cmd, "EmpNum", EmpNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "HireDate", HireDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UseinAdjustedHireDateCalc", UseinAdjustedHireDateCalc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
