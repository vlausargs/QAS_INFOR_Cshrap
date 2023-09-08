//PROJECT NAME: CSIEmployee
//CLASS NAME: VoidPrtrxChecksToPrintPost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
    public interface IVoidPrtrxChecksToPrintPost
    {
        int VoidPrtrxChecksToPrintPostSp(RowPointerType PSessionID,
                                         TokenType PUserID,
                                         BankCodeType PBankCode,
                                         ref Infobar Infobar);
    }

    public class VoidPrtrxChecksToPrintPost : IVoidPrtrxChecksToPrintPost
    {
        readonly IApplicationDB appDB;

        public VoidPrtrxChecksToPrintPost(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int VoidPrtrxChecksToPrintPostSp(RowPointerType PSessionID,
                                                TokenType PUserID,
                                                BankCodeType PBankCode,
                                                ref Infobar Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "VoidPrtrxChecksToPrintPostSp";

                appDB.AddCommandParameter(cmd, "PSessionID", PSessionID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PUserID", PUserID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PBankCode", PBankCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
