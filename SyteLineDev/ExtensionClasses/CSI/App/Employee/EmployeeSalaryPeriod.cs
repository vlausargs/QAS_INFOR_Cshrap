//PROJECT NAME: CSIEmployee
//CLASS NAME: EmployeeSalaryPeriod.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
    public interface IEmployeeSalaryPeriod
    {
        int EmployeeSalaryPeriodSp(JobIdType JobId,
                                   ref SalPeriodType SalaryPeriod,
                                   ref PrPayFreqType PayFreq);
    }

    public class EmployeeSalaryPeriod : IEmployeeSalaryPeriod
    {
        readonly IApplicationDB appDB;

        public EmployeeSalaryPeriod(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int EmployeeSalaryPeriodSp(JobIdType JobId,
                                          ref SalPeriodType SalaryPeriod,
                                          ref PrPayFreqType PayFreq)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EmployeeSalaryPeriodSp";

                appDB.AddCommandParameter(cmd, "JobId", JobId, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SalaryPeriod", SalaryPeriod, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PayFreq", PayFreq, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
