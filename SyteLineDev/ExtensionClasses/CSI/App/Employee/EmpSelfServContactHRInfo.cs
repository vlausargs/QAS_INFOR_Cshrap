//PROJECT NAME: CSIEmployee
//CLASS NAME: EmpSelfServContactHRInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
    public interface IEmpSelfServContactHRInfo
    {
        int EmpSelfServContactHRInfoSp(ref EmailType EmpEmail,
                                       ref UsernameType EmpUserName,
                                       ref EmailType HREmail,
                                       ref UsernameType HRUserName,
                                       ref InfobarType Infobar);
    }

    public class EmpSelfServContactHRInfo : IEmpSelfServContactHRInfo
    {
        readonly IApplicationDB appDB;

        public EmpSelfServContactHRInfo(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int EmpSelfServContactHRInfoSp(ref EmailType EmpEmail,
                                              ref UsernameType EmpUserName,
                                              ref EmailType HREmail,
                                              ref UsernameType HRUserName,
                                              ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EmpSelfServContactHRInfoSp";

                appDB.AddCommandParameter(cmd, "EmpEmail", EmpEmail, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "EmpUserName", EmpUserName, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "HREmail", HREmail, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "HRUserName", HRUserName, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
