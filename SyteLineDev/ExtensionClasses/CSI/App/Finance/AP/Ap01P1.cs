//PROJECT NAME: CSIFinance
//CLASS NAME: Ap01P1.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.AP
{
    public interface IAp01P1
    {
        int Ap01P1Sp(BankCodeType BankHdrBankCode,
                     AppmtPayTypeType PayTypeCodeCt,
                     GlCheckNumType ExOptCheckNum,
                     ref GlCheckNumType TCurCheckN,
                     ref Infobar Infobar);
    }

    public class Ap01P1 : IAp01P1
    {
        readonly IApplicationDB appDB;

        public Ap01P1(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int Ap01P1Sp(BankCodeType BankHdrBankCode,
                            AppmtPayTypeType PayTypeCodeCt,
                            GlCheckNumType ExOptCheckNum,
                            ref GlCheckNumType TCurCheckN,
                            ref Infobar Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Ap01P1Sp";

                appDB.AddCommandParameter(cmd, "BankHdrBankCode", BankHdrBankCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PayTypeCodeCt", PayTypeCodeCt, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExOptCheckNum", ExOptCheckNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TCurCheckN", TCurCheckN, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
