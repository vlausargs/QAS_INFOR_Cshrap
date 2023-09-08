//PROJECT NAME: CSIEmployee
//CLASS NAME: PRtrxvpValPeriod.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
    public interface IPRtrxvpValPeriod
    {
        int PRtrxvpValPeriodSp(DateType pCheckDate,
                               ref InfobarType Infobar);
    }

    public class PRtrxvpValPeriod : IPRtrxvpValPeriod
    {
        readonly IApplicationDB appDB;

        public PRtrxvpValPeriod(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int PRtrxvpValPeriodSp(DateType pCheckDate,
                                      ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PRtrxvpValPeriodSp";

                appDB.AddCommandParameter(cmd, "pCheckDate", pCheckDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
