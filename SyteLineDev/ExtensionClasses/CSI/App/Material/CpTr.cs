//PROJECT NAME: CSIMaterial
//CLASS NAME: CpTr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface ICpTr
    {
        int CpTrSp(TrnNumType FTrn,
                   TrnLineType FSLine,
                   TrnLineType FELine,
                   ListYesNoType TCpCharge,
                   ref DateType TSchShipDate,
                   ref DateType TSchRcvDate,
                   ref TrnNumType TTrn,
                   ref InfobarType Infobar);
    }

    public class CpTr : ICpTr
    {
        readonly IApplicationDB appDB;

        public CpTr(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CpTrSp(TrnNumType FTrn,
                          TrnLineType FSLine,
                          TrnLineType FELine,
                          ListYesNoType TCpCharge,
                          ref DateType TSchShipDate,
                          ref DateType TSchRcvDate,
                          ref TrnNumType TTrn,
                          ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CpTrSp";

                appDB.AddCommandParameter(cmd, "FTrn", FTrn, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FSLine", FSLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FELine", FELine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TCpCharge", TCpCharge, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TSchShipDate", TSchShipDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TSchRcvDate", TSchRcvDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TTrn", TTrn, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
