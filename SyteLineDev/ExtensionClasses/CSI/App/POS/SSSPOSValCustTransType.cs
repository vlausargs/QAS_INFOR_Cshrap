//PROJECT NAME: CSIPOS
//CLASS NAME: SSSPOSValCustTransType.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.POS
{
    public interface ISSSPOSValCustTransType
    {
        int SSSPOSValCustTransTypeSp(string CustNum,
                                     ref byte? CanOnAcct,
                                     ref byte? CanCash,
                                     ref byte? CanCreditCard,
                                     ref byte? CanCheck,
                                     ref string Infobar);
    }

    public class SSSPOSValCustTransType : ISSSPOSValCustTransType
    {
        readonly IApplicationDB appDB;

        public SSSPOSValCustTransType(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSPOSValCustTransTypeSp(string CustNum,
                                            ref byte? CanOnAcct,
                                            ref byte? CanCash,
                                            ref byte? CanCreditCard,
                                            ref byte? CanCheck,
                                            ref string Infobar)
        {
            CustNumType _CustNum = CustNum;
            ListYesNoType _CanOnAcct = CanOnAcct;
            ListYesNoType _CanCash = CanCash;
            ListYesNoType _CanCreditCard = CanCreditCard;
            ListYesNoType _CanCheck = CanCheck;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSPOSValCustTransTypeSp";

                appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CanOnAcct", _CanOnAcct, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CanCash", _CanCash, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CanCreditCard", _CanCreditCard, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CanCheck", _CanCheck, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                CanOnAcct = _CanOnAcct;
                CanCash = _CanCash;
                CanCreditCard = _CanCreditCard;
                CanCheck = _CanCheck;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
