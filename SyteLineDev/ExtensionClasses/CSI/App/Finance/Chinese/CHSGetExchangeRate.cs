//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSGetExchangeRate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.Chinese
{
    public interface ICHSGetExchangeRate
    {
        int CHSGetExchangeRateSp(DateType TransDate,
                                 GenericIntType BankOrCurr,
                                 DeTypeType FrgnYN,
                                 CurrCodeType SysCurrCode,
                                 ref BankCodeType bank_code,
                                 ref CurrCodeType curr_code,
                                 ref ExchRateType exch_rate,
                                 ref ListYesNoType rate_is_divisor,
                                 ref InfobarType InfoBar);
    }

    public class CHSGetExchangeRate : ICHSGetExchangeRate
    {
        readonly IApplicationDB appDB;

        public CHSGetExchangeRate(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CHSGetExchangeRateSp(DateType TransDate,
                                        GenericIntType BankOrCurr,
                                        DeTypeType FrgnYN,
                                        CurrCodeType SysCurrCode,
                                        ref BankCodeType bank_code,
                                        ref CurrCodeType curr_code,
                                        ref ExchRateType exch_rate,
                                        ref ListYesNoType rate_is_divisor,
                                        ref InfobarType InfoBar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CHSGetExchangeRateSp";

                appDB.AddCommandParameter(cmd, "TransDate", TransDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BankOrCurr", BankOrCurr, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FrgnYN", FrgnYN, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SysCurrCode", SysCurrCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "bank_code", bank_code, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "curr_code", curr_code, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "exch_rate", exch_rate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "rate_is_divisor", rate_is_divisor, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "InfoBar", InfoBar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}

