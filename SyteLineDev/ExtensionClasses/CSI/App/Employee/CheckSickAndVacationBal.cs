//PROJECT NAME: CSIEmployee
//CLASS NAME: CheckSickAndVacationBal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
    public interface ICheckSickAndVacationBal
    {
        int CheckSickAndVacationBalSp(MatlTransNumType TransNum,
                                      EmpNumType EmpNum,
                                      PrhrsHrTypeType HrType,
                                      TotalHoursType Hrs,
                                      ref InfobarType Infobar);
    }

    public class CheckSickAndVacationBal : ICheckSickAndVacationBal
    {
        readonly IApplicationDB appDB;

        public CheckSickAndVacationBal(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CheckSickAndVacationBalSp(MatlTransNumType TransNum,
                                             EmpNumType EmpNum,
                                             PrhrsHrTypeType HrType,
                                             TotalHoursType Hrs,
                                             ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CheckSickAndVacationBalSp";

                appDB.AddCommandParameter(cmd, "TransNum", TransNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EmpNum", EmpNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "HrType", HrType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Hrs", Hrs, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
