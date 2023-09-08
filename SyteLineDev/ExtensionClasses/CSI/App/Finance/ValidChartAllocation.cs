//PROJECT NAME: CSIFinance
//CLASS NAME: ValidChartAllocation.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance
{
    public interface IValidChartAllocation
    {
        int ValidChartAllocationSp(CustNumType PAcctNum,
                                   ref InfobarType Infobar);
    }

    public class ValidChartAllocation : IValidChartAllocation
    {
        readonly IApplicationDB appDB;

        public ValidChartAllocation(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ValidChartAllocationSp(CustNumType PAcctNum,
                                          ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ValidChartAllocationSp";

                appDB.AddCommandParameter(cmd, "PAcctNum", PAcctNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}