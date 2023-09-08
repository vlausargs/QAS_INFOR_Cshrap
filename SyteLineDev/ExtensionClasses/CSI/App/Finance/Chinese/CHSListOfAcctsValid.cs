//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSListOfAcctsValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.Chinese
{
    public interface ICHSListOfAcctsValid
    {
        int CHSListOfAcctsValidSp(TransNatType TypeCode,
                                  AmountType DebitAmount,
                                  AmountType CreditAmount,
                                  AcctType Acct,
                                  ref InfobarType Infobar);
    }

    public class CHSListOfAcctsValid : ICHSListOfAcctsValid
    {
        readonly IApplicationDB appDB;

        public CHSListOfAcctsValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CHSListOfAcctsValidSp(TransNatType TypeCode,
                                         AmountType DebitAmount,
                                         AmountType CreditAmount,
                                         AcctType Acct,
                                         ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CHSListOfAcctsValidSp";

                appDB.AddCommandParameter(cmd, "TypeCode", TypeCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DebitAmount", DebitAmount, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CreditAmount", CreditAmount, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Acct", Acct, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}

