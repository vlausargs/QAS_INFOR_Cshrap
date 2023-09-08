//PROJECT NAME: CSIEmployee
//CLASS NAME: EmpPositionMoveToHistPre.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
    public interface IEmpPositionMoveToHistPre
    {
        int EmpPositionMoveToHistPreSp(EmpNumType PEmpNum,
                                       ref InfobarType PromptMsg,
                                       ref Infobar PromptButtons,
                                       ref Infobar Infobar);
    }

    public class EmpPositionMoveToHistPre : IEmpPositionMoveToHistPre
    {
        readonly IApplicationDB appDB;

        public EmpPositionMoveToHistPre(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int EmpPositionMoveToHistPreSp(EmpNumType PEmpNum,
                                              ref InfobarType PromptMsg,
                                              ref Infobar PromptButtons,
                                              ref Infobar Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EmpPositionMoveToHistPreSp";

                appDB.AddCommandParameter(cmd, "PEmpNum", PEmpNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PromptMsg", PromptMsg, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptButtons", PromptButtons, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
