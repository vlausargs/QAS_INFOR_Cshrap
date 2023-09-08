//PROJECT NAME: CSITaxInterface
//CLASS NAME: SSSVTXAvaTaxExemptProcessWrapper.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.TaxInterface
{
    public interface ISSSVTXAvaTaxExemptProcessWrapper
    {
        int SSSVTXAvaTaxExemptProcessWrapperSp(InvNumType pInvNum,
                                               ref Infobar Infobar);
    }

    public class SSSVTXAvaTaxExemptProcessWrapper : ISSSVTXAvaTaxExemptProcessWrapper
    {
        readonly IApplicationDB appDB;

        public SSSVTXAvaTaxExemptProcessWrapper(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSVTXAvaTaxExemptProcessWrapperSp(InvNumType pInvNum,
                                                      ref Infobar Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSVTXAvaTaxExemptProcessWrapperSp";

                appDB.AddCommandParameter(cmd, "pInvNum", pInvNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
