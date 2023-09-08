//PROJECT NAME: CSIEmployee
//CLASS NAME: PayrollParamUpdatePrtrx.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
    public interface IPayrollParamUpdatePrtrx
    {
        int PayrollParamUpdatePrtrxSp(DateType CurStart,
                                      DateType CurEnd,
                                      PrAmountType HrsDay,
                                      PrAmountType HrsWeek,
                                      PrAmountType HrsBiWeek,
                                      PrAmountType HrsSemiMo,
                                      PrAmountType HrsMo,
                                      PrAmountType HrsQuart,
                                      ref InfobarType Infobar);
    }

    public class PayrollParamUpdatePrtrx : IPayrollParamUpdatePrtrx
    {
        readonly IApplicationDB appDB;

        public PayrollParamUpdatePrtrx(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int PayrollParamUpdatePrtrxSp(DateType CurStart,
                                             DateType CurEnd,
                                             PrAmountType HrsDay,
                                             PrAmountType HrsWeek,
                                             PrAmountType HrsBiWeek,
                                             PrAmountType HrsSemiMo,
                                             PrAmountType HrsMo,
                                             PrAmountType HrsQuart,
                                             ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PayrollParamUpdatePrtrxSp";

                appDB.AddCommandParameter(cmd, "CurStart", CurStart, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CurEnd", CurEnd, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "HrsDay", HrsDay, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "HrsWeek", HrsWeek, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "HrsBiWeek", HrsBiWeek, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "HrsSemiMo", HrsSemiMo, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "HrsMo", HrsMo, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "HrsQuart", HrsQuart, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
