//PROJECT NAME: CSIEmployee
//CLASS NAME: EmpHposDeleteEmpSalary.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
    public interface IEmpHposDeleteEmpSalary
    {
        int EmpHposDeleteEmpSalarySp(EmpNumType PEmpNum,
                                     DateType PJobDate,
                                     ref InfobarType Infobar);
    }

    public class EmpHposDeleteEmpSalary : IEmpHposDeleteEmpSalary
    {
        readonly IApplicationDB appDB;

        public EmpHposDeleteEmpSalary(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int EmpHposDeleteEmpSalarySp(EmpNumType PEmpNum,
                                            DateType PJobDate,
                                            ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EmpHposDeleteEmpSalarySp";

                appDB.AddCommandParameter(cmd, "PEmpNum", PEmpNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PJobDate", PJobDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
