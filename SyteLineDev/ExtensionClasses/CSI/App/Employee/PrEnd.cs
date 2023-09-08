//PROJECT NAME: CSIEmployee
//CLASS NAME: PrEnd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
    public interface IPrEnd
    {
        int PrEndSp(EmpNumType EmpNumStart,
                    EmpNumType EmpNumEnd,
                    ref InfobarType Infobar);
    }

    public class PrEnd : IPrEnd
    {
        readonly IApplicationDB appDB;

        public PrEnd(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int PrEndSp(EmpNumType EmpNumStart,
                           EmpNumType EmpNumEnd,
                           ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PrEndSp";

                appDB.AddCommandParameter(cmd, "EmpNumStart", EmpNumStart, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EmpNumEnd", EmpNumEnd, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
