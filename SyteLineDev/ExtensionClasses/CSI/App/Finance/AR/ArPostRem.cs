//PROJECT NAME: CSIFinance
//CLASS NAME: ArPostRem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.AR
{
    public interface IArPostRem
    {
        int ArPostRemSp(BankCodeType pBankCode,
                        CustNumType pCustNum,
                        DraftNumType pDraftNum,
                        ref InfobarType rInfobar);
    }

    public class ArPostRem : IArPostRem
    {
        readonly IApplicationDB appDB;

        public ArPostRem(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ArPostRemSp(BankCodeType pBankCode,
                               CustNumType pCustNum,
                               DraftNumType pDraftNum,
                               ref InfobarType rInfobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ArPostRemSp";

                appDB.AddCommandParameter(cmd, "pBankCode", pBankCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pCustNum", pCustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pDraftNum", pDraftNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "rInfobar", rInfobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}

