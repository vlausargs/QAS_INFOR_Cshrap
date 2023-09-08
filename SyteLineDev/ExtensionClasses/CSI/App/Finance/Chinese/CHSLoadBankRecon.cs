//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSLoadBankRecon.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.Chinese
{
    public interface ICHSLoadBankRecon
    {
        int CHSLoadBankReconSp(BankCodeType PBankCode,
                               DateType PDate,
                               StringType PDebitCredit,
                               AmountType PAmount,
                               StringType PSource,
                               RowPointerType PSessionID,
                               ref InfobarType Infobar);
    }

    public class CHSLoadBankRecon : ICHSLoadBankRecon
    {
        readonly IApplicationDB appDB;

        public CHSLoadBankRecon(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CHSLoadBankReconSp(BankCodeType PBankCode,
                                      DateType PDate,
                                      StringType PDebitCredit,
                                      AmountType PAmount,
                                      StringType PSource,
                                      RowPointerType PSessionID,
                                      ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CHSLoadBankReconSp";

                appDB.AddCommandParameter(cmd, "PBankCode", PBankCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PDate", PDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PDebitCredit", PDebitCredit, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PAmount", PAmount, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PSource", PSource, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PSessionID", PSessionID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
