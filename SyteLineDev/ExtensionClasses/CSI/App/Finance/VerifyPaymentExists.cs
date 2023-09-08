//PROJECT NAME: CSIFinance
//CLASS NAME: VerifyPaymentExists.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance
{
    public interface IVerifyPaymentExists
    {
        int VerifyPaymentExistsSp(DateType CheckDate,
                                  ArCheckNumType CheckNumber,
                                  AmountType CheckAmt,
                                  CustNumType RefNum,
                                  ref CurrCodeType CustCurrCode,
                                  ref ListYesNoType Exists,
                                  ref InfobarType Infobar);
    }

    public class VerifyPaymentExists : IVerifyPaymentExists
    {
        readonly IApplicationDB appDB;

        public VerifyPaymentExists(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int VerifyPaymentExistsSp(DateType CheckDate,
                                         ArCheckNumType CheckNumber,
                                         AmountType CheckAmt,
                                         CustNumType RefNum,
                                         ref CurrCodeType CustCurrCode,
                                         ref ListYesNoType Exists,
                                         ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "VerifyPaymentExistsSp";

                appDB.AddCommandParameter(cmd, "CheckDate", CheckDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CheckNumber", CheckNumber, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CheckAmt", CheckAmt, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RefNum", RefNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CustCurrCode", CustCurrCode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Exists", Exists, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
