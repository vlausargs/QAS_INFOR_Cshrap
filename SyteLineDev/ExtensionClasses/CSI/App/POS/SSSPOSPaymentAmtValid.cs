//PROJECT NAME: CSIPOS
//CLASS NAME: SSSPOSPaymentAmtValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.POS
{
    public interface ISSSPOSPaymentAmtValid
    {
        int SSSPOSPaymentAmtValidSp(string POSNum,
                                    decimal? PNRef,
                                    decimal? Amount,
                                    ref string Infobar);
    }

    public class SSSPOSPaymentAmtValid : ISSSPOSPaymentAmtValid
    {
        readonly IApplicationDB appDB;

        public SSSPOSPaymentAmtValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSPOSPaymentAmtValidSp(string POSNum,
                                           decimal? PNRef,
                                           decimal? Amount,
                                           ref string Infobar)
        {
            POSMNumType _POSNum = POSNum;
            CCIGatewayTransNumType _PNRef = PNRef;
            AmountType _Amount = Amount;
            Infobar _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSPOSPaymentAmtValidSp";

                appDB.AddCommandParameter(cmd, "POSNum", _POSNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PNRef", _PNRef, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Amount", _Amount, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
