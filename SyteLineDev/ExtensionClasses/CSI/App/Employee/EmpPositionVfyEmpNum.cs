//PROJECT NAME: CSIEmployee
//CLASS NAME: EmpPositionVfyEmpNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
    public interface IEmpPositionVfyEmpNum
    {
        int EmpPositionVfyEmpNumSp(EmpNumType PEmpNum,
                                   ref InfobarType Infobar);
    }

    public class EmpPositionVfyEmpNum : IEmpPositionVfyEmpNum
    {
        readonly IApplicationDB appDB;

        public EmpPositionVfyEmpNum(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int EmpPositionVfyEmpNumSp(EmpNumType PEmpNum,
                                          ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EmpPositionVfyEmpNumSp";

                appDB.AddCommandParameter(cmd, "PEmpNum", PEmpNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
