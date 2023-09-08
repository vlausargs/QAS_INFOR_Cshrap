//PROJECT NAME: CSIEmployee
//CLASS NAME: CheckNewSalary.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
    public interface ICheckNewSalary
    {
        int CheckNewSalarySp(EmpNumType EmpSalaryEmpNum,
                             PrAmountType EmpSalaryNewSalary,
                             SalPeriodType EmpSalaryOldSalPeriod);
    }

    public class CheckNewSalary : ICheckNewSalary
    {
        readonly IApplicationDB appDB;

        public CheckNewSalary(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CheckNewSalarySp(EmpNumType EmpSalaryEmpNum,
                                    PrAmountType EmpSalaryNewSalary,
                                    SalPeriodType EmpSalaryOldSalPeriod)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CheckNewSalarySp";

                appDB.AddCommandParameter(cmd, "EmpSalaryEmpNum", EmpSalaryEmpNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EmpSalaryNewSalary", EmpSalaryNewSalary, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EmpSalaryOldSalPeriod", EmpSalaryOldSalPeriod, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
