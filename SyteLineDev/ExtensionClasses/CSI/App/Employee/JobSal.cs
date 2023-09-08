//PROJECT NAME: CSIEmployee
//CLASS NAME: JobSal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
    public interface IJobSal
    {
        int JobSalSp(EmpNumType PEmpNum,
                     DateType PJobdate,
                     JobIdType PJobId,
                     ref DateType RSalDate,
                     ref PrPayFreqType RPayFreq,
                     ref SalPeriodType RSalPeriod,
                     ref PrAmountType RSalary,
                     ref AnnualSalaryType RAnnual,
                     ref HourlyRateType RHrlyRate,
                     ref SalaryChangePercentType RPctIncr,
                     ref AnnualSalaryType RMaxSalary,
                     ref InfobarType Infobar);
    }

    public class JobSal : IJobSal
    {
        readonly IApplicationDB appDB;

        public JobSal(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int JobSalSp(EmpNumType PEmpNum,
                            DateType PJobdate,
                            JobIdType PJobId,
                            ref DateType RSalDate,
                            ref PrPayFreqType RPayFreq,
                            ref SalPeriodType RSalPeriod,
                            ref PrAmountType RSalary,
                            ref AnnualSalaryType RAnnual,
                            ref HourlyRateType RHrlyRate,
                            ref SalaryChangePercentType RPctIncr,
                            ref AnnualSalaryType RMaxSalary,
                            ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "JobSalSp";

                appDB.AddCommandParameter(cmd, "PEmpNum", PEmpNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PJobdate", PJobdate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PJobId", PJobId, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RSalDate", RSalDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RPayFreq", RPayFreq, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RSalPeriod", RSalPeriod, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RSalary", RSalary, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RAnnual", RAnnual, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RHrlyRate", RHrlyRate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RPctIncr", RPctIncr, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RMaxSalary", RMaxSalary, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
