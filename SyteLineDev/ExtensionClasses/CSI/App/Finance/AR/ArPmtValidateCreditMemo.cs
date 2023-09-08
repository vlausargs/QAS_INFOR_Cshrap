//PROJECT NAME: CSICustomer
//CLASS NAME: ArPmtValidateCreditMemo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.AR
{
    public interface IArPmtValidateCreditMemo
    {
        int ArPmtValidateCreditMemoSp(CustNumType CustNum,
                                      InvNumType CreditMemoNum,
                                      CurrCodeType CurrentCurrCode,
                                      ref InvSeqType InvSeq,
                                      ref AmountType Amount,
                                      ref DateType InvDate,
                                      ref CurrCodeType CurrCode,
                                      ref InfobarType Infobar);
    }

    public class ArPmtValidateCreditMemo : IArPmtValidateCreditMemo
    {
        readonly IApplicationDB appDB;

        public ArPmtValidateCreditMemo(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ArPmtValidateCreditMemoSp(CustNumType CustNum,
                                             InvNumType CreditMemoNum,
                                             CurrCodeType CurrentCurrCode,
                                             ref InvSeqType InvSeq,
                                             ref AmountType Amount,
                                             ref DateType InvDate,
                                             ref CurrCodeType CurrCode,
                                             ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ArPmtValidateCreditMemoSp";

                appDB.AddCommandParameter(cmd, "CustNum", CustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CreditMemoNum", CreditMemoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CurrentCurrCode", CurrentCurrCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InvSeq", InvSeq, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Amount", Amount, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "InvDate", InvDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CurrCode", CurrCode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
