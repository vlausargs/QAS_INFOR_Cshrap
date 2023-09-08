//PROJECT NAME: CSIEmployee
//CLASS NAME: ValidateEmployeeUsername.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
    public interface IValidateEmployeeUsername
    {
        int ValidateEmployeeUsernameSp(EmpNumType EmpNum,
                                       UsernameType Username,
                                       ref InfobarType Infobar);
    }

    public class ValidateEmployeeUsername : IValidateEmployeeUsername
    {
        readonly IApplicationDB appDB;

        public ValidateEmployeeUsername(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ValidateEmployeeUsernameSp(EmpNumType EmpNum,
                                              UsernameType Username,
                                              ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ValidateEmployeeUsernameSp";

                appDB.AddCommandParameter(cmd, "EmpNum", EmpNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Username", Username, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
