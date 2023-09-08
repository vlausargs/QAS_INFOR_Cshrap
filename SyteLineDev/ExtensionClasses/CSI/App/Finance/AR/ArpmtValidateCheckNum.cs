//PROJECT NAME: CSICustomer
//CLASS NAME: ArpmtValidateCheckNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.AR
{
    public interface IArpmtValidateCheckNum
    {
        int ArpmtValidateCheckNumSp(ArCheckNumType PCheckNum,
                                    CustNumType PCustNum,
                                    BankCodeType PBankCode,
                                    ref InfobarType Infobar);
    }

    public class ArpmtValidateCheckNum : IArpmtValidateCheckNum
    {
        readonly IApplicationDB appDB;

        public ArpmtValidateCheckNum(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ArpmtValidateCheckNumSp(ArCheckNumType PCheckNum,
                                           CustNumType PCustNum,
                                           BankCodeType PBankCode,
                                           ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ArpmtValidateCheckNumSp";

                appDB.AddCommandParameter(cmd, "PCheckNum", PCheckNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PCustNum", PCustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PBankCode", PBankCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
