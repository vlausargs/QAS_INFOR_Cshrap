//PROJECT NAME: CSIVendor
//CLASS NAME: ARAPOffsetCreateAPPayment.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
    public interface IARAPOffsetCreateAPPayment
    {
        int ARAPOffsetCreateAPPaymentSp(VendNumType VendNum,
                                        ExchRateType ExchRate,
                                        ListYesNoType FixedRate,
                                        VoucherType Voucher,
                                        AmountType OffsetAmt,
                                        PoNumType PoNum,
                                        SiteType Site,
                                        AcctType OffsetAcct,
                                        UnitCode1Type OffsetAcctUnit1,
                                        UnitCode2Type OffsetAcctUnit2,
                                        UnitCode3Type OffsetAcctUnit3,
                                        UnitCode4Type OffsetAcctUnit4,
                                        ListYesNoType CreateAppmt,
                                        THPrefixType THPaymentNumberPrefix,
                                        ref InfobarType Infobar);
    }

    public class ARAPOffsetCreateAPPayment : IARAPOffsetCreateAPPayment
    {
        readonly IApplicationDB appDB;

        public ARAPOffsetCreateAPPayment(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ARAPOffsetCreateAPPaymentSp(VendNumType VendNum,
                                               ExchRateType ExchRate,
                                               ListYesNoType FixedRate,
                                               VoucherType Voucher,
                                               AmountType OffsetAmt,
                                               PoNumType PoNum,
                                               SiteType Site,
                                               AcctType OffsetAcct,
                                               UnitCode1Type OffsetAcctUnit1,
                                               UnitCode2Type OffsetAcctUnit2,
                                               UnitCode3Type OffsetAcctUnit3,
                                               UnitCode4Type OffsetAcctUnit4,
                                               ListYesNoType CreateAppmt,
                                               THPrefixType THPaymentNumberPrefix,
                                               ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ARAPOffsetCreateAPPaymentSp";

                appDB.AddCommandParameter(cmd, "VendNum", VendNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExchRate", ExchRate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FixedRate", FixedRate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Voucher", Voucher, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OffsetAmt", OffsetAmt, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PoNum", PoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Site", Site, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OffsetAcct", OffsetAcct, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OffsetAcctUnit1", OffsetAcctUnit1, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OffsetAcctUnit2", OffsetAcctUnit2, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OffsetAcctUnit3", OffsetAcctUnit3, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OffsetAcctUnit4", OffsetAcctUnit4, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CreateAppmt", CreateAppmt, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "THPaymentNumberPrefix", THPaymentNumberPrefix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
