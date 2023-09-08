//PROJECT NAME: CSITaxInterface
//CLASS NAME: SSSVTXAvaTaxExemptCheckWrapper.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.TaxInterface
{
    public interface ISSSVTXAvaTaxExemptCheckWrapper
    {
        int SSSVTXAvaTaxExemptCheckWrapperSp(InvNumType pInvNum,
                                             ref ListYesNoType oCanReverse,
                                             ref AmountType oAvalaraTax,
                                             ref AmountType oAvalaraTax2,
                                             ref InfobarType Infobar);
    }

    public class SSSVTXAvaTaxExemptCheckWrapper : ISSSVTXAvaTaxExemptCheckWrapper
    {
        readonly IApplicationDB appDB;

        public SSSVTXAvaTaxExemptCheckWrapper(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSVTXAvaTaxExemptCheckWrapperSp(InvNumType pInvNum,
                                                    ref ListYesNoType oCanReverse,
                                                    ref AmountType oAvalaraTax,
                                                    ref AmountType oAvalaraTax2,
                                                    ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSVTXAvaTaxExemptCheckWrapperSp";

                appDB.AddCommandParameter(cmd, "pInvNum", pInvNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "oCanReverse", oCanReverse, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "oAvalaraTax", oAvalaraTax, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "oAvalaraTax2", oAvalaraTax2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
