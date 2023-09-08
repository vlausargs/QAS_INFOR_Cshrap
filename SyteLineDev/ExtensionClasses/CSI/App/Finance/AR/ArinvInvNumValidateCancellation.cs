//PROJECT NAME: CSICustomer
//CLASS NAME: ArinvInvNumValidateCancellation.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.AR
{
    public interface IArinvInvNumValidateCancellation
    {
        int ArinvInvNumValidateCancellationSp(CustNumType CustNum,
                                              InvNumType InvNum,
                                              ref ArInvSeqType InvSeq,
                                              ref InvNumType ApplyToInvNum,
                                              ref AmountType Amount,
                                              ref AmountType Freight,
                                              ref AmountType MiscCharges,
                                              ref AmountType SalesTax,
                                              ref AmountType SalesTax2,
                                              ref ListYesNoType FixedRate,
                                              ref ExchRateType ExchRate,
                                              ref InfobarType Infobar);
    }

    public class ArinvInvNumValidateCancellation : IArinvInvNumValidateCancellation
    {
        readonly IApplicationDB appDB;

        public ArinvInvNumValidateCancellation(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ArinvInvNumValidateCancellationSp(CustNumType CustNum,
                                                     InvNumType InvNum,
                                                     ref ArInvSeqType InvSeq,
                                                     ref InvNumType ApplyToInvNum,
                                                     ref AmountType Amount,
                                                     ref AmountType Freight,
                                                     ref AmountType MiscCharges,
                                                     ref AmountType SalesTax,
                                                     ref AmountType SalesTax2,
                                                     ref ListYesNoType FixedRate,
                                                     ref ExchRateType ExchRate,
                                                     ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ArinvInvNumValidateCancellationSp";

                appDB.AddCommandParameter(cmd, "CustNum", CustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InvNum", InvNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InvSeq", InvSeq, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ApplyToInvNum", ApplyToInvNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Amount", Amount, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Freight", Freight, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "MiscCharges", MiscCharges, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "SalesTax", SalesTax, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "SalesTax2", SalesTax2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "FixedRate", FixedRate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ExchRate", ExchRate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
