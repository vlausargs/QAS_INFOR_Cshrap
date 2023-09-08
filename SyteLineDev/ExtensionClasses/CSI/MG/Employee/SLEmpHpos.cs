//PROJECT NAME: EmployeeExt
//CLASS NAME: SLEmpHpos.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Employee;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.Employee
{
    [IDOExtensionClass("SLEmpHpos")]
    public class SLEmpHpos : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int EmpHposDeleteEmpSalarySp(string PEmpNum,
                                            DateTime? PJobDate,
                                            ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iEmpHposDeleteEmpSalaryExt = new EmpHposDeleteEmpSalaryFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iEmpHposDeleteEmpSalaryExt.EmpHposDeleteEmpSalarySp(PEmpNum,
                                                                                   PJobDate,
                                                                                   ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int JobSalSp(string PEmpNum,
                            DateTime? PJobdate,
                            string PJobId,
                            ref DateTime? RSalDate,
                            ref string RPayFreq,
                            ref string RSalPeriod,
                            ref decimal? RSalary,
                            ref decimal? RAnnual,
                            ref decimal? RHrlyRate,
                            ref decimal? RPctIncr,
                            ref decimal? RMaxSalary,
                            ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iJobSalExt = new JobSalFactory().Create(appDb);

                DateType oRSalDate = RSalDate;
                PrPayFreqType oRPayFreq = RPayFreq;
                SalPeriodType oRSalPeriod = RSalPeriod;
                PrAmountType oRSalary = RSalary;
                AnnualSalaryType oRAnnual = RAnnual;
                HourlyRateType oRHrlyRate = RHrlyRate;
                SalaryChangePercentType oRPctIncr = RPctIncr;
                AnnualSalaryType oRMaxSalary = RMaxSalary;
                InfobarType oInfobar = Infobar;

                int Severity = iJobSalExt.JobSalSp(PEmpNum,
                                                   PJobdate,
                                                   PJobId,
                                                   ref oRSalDate,
                                                   ref oRPayFreq,
                                                   ref oRSalPeriod,
                                                   ref oRSalary,
                                                   ref oRAnnual,
                                                   ref oRHrlyRate,
                                                   ref oRPctIncr,
                                                   ref oRMaxSalary,
                                                   ref oInfobar);

                RSalDate = oRSalDate;
                RPayFreq = oRPayFreq;
                RSalPeriod = oRSalPeriod;
                RSalary = oRSalary;
                RAnnual = oRAnnual;
                RHrlyRate = oRHrlyRate;
                RPctIncr = oRPctIncr;
                RMaxSalary = oRMaxSalary;
                Infobar = oInfobar;


                return Severity;
            }
        }
    }
}
