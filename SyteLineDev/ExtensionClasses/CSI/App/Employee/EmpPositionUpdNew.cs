//PROJECT NAME: CSIEmployee
//CLASS NAME: EmpPositionUpdNew.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
    public interface IEmpPositionUpdNew
    {
        int EmpPositionUpdNewSp(EmpNumType TEmpNum,
                                JobIdType TJobId,
                                DateType TJobdate,
                                ref InfobarType Infobar);
    }

    public class EmpPositionUpdNew : IEmpPositionUpdNew
    {
        readonly IApplicationDB appDB;

        public EmpPositionUpdNew(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int EmpPositionUpdNewSp(EmpNumType TEmpNum,
                                       JobIdType TJobId,
                                       DateType TJobdate,
                                       ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EmpPositionUpdNewSp";

                appDB.AddCommandParameter(cmd, "TEmpNum", TEmpNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TJobId", TJobId, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TJobdate", TJobdate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
