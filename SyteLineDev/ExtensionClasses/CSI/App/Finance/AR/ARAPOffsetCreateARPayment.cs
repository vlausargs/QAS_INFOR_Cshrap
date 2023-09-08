//PROJECT NAME: CSICustomer
//CLASS NAME: ARAPOffsetCreateARPayment.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.AR
{
    public interface IARAPOffsetCreateARPayment
    {
        int ARAPOffsetCreateARPaymentSp(CustNumType CustNum,
                                        ExchRateType ExchRate,
                                        ListYesNoType FixedRate,
                                        InvNumType InvNum,
                                        SiteType Site,
                                        AmountType OffsetAmt,
                                        CoNumType CoNum,
                                        DoNumType DoNum,
                                        ShipmentIDType ShipmentId,
                                        AcctType OffsetAcct,
                                        UnitCode1Type OffsetAcctUnit1,
                                        UnitCode2Type OffsetAcctUnit2,
                                        UnitCode3Type OffsetAcctUnit3,
                                        UnitCode4Type OffsetAcctUnit4,
                                        ListYesNoType CreateArpmt,
                                        ref InfobarType Infobar,
                                        CustNumType ApplyCustNum,
                                        THPrefixType THPaymentNumberPrefix);
    }

    public class ARAPOffsetCreateARPayment : IARAPOffsetCreateARPayment
    {
        readonly IApplicationDB appDB;

        public ARAPOffsetCreateARPayment(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ARAPOffsetCreateARPaymentSp(CustNumType CustNum,
                                               ExchRateType ExchRate,
                                               ListYesNoType FixedRate,
                                               InvNumType InvNum,
                                               SiteType Site,
                                               AmountType OffsetAmt,
                                               CoNumType CoNum,
                                               DoNumType DoNum,
                                               ShipmentIDType ShipmentId,
                                               AcctType OffsetAcct,
                                               UnitCode1Type OffsetAcctUnit1,
                                               UnitCode2Type OffsetAcctUnit2,
                                               UnitCode3Type OffsetAcctUnit3,
                                               UnitCode4Type OffsetAcctUnit4,
                                               ListYesNoType CreateArpmt,
                                               ref InfobarType Infobar,
                                               CustNumType ApplyCustNum,
                                               THPrefixType THPaymentNumberPrefix)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ARAPOffsetCreateARPaymentSp";

                appDB.AddCommandParameter(cmd, "CustNum", CustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExchRate", ExchRate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FixedRate", FixedRate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InvNum", InvNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Site", Site, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OffsetAmt", OffsetAmt, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoNum", CoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DoNum", DoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ShipmentId", ShipmentId, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OffsetAcct", OffsetAcct, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OffsetAcctUnit1", OffsetAcctUnit1, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OffsetAcctUnit2", OffsetAcctUnit2, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OffsetAcctUnit3", OffsetAcctUnit3, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OffsetAcctUnit4", OffsetAcctUnit4, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CreateArpmt", CreateArpmt, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ApplyCustNum", ApplyCustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "THPaymentNumberPrefix", THPaymentNumberPrefix, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
