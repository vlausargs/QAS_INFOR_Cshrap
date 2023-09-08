//PROJECT NAME: CSIEmployee
//CLASS NAME: EmpPositionMoveToHist.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
    public interface IEmpPositionMoveToHist
    {
        int EmpPositionMoveToHistSp(EmpNumType PEmpNum,
                                    ref Infobar Infobar);
    }

    public class EmpPositionMoveToHist : IEmpPositionMoveToHist
    {
        readonly IApplicationDB appDB;

        public EmpPositionMoveToHist(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int EmpPositionMoveToHistSp(EmpNumType PEmpNum,
                                           ref Infobar Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EmpPositionMoveToHistSp";

                appDB.AddCommandParameter(cmd, "PEmpNum", PEmpNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
