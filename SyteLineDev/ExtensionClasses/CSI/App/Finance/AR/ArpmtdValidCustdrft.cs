//PROJECT NAME: CSICustomer
//CLASS NAME: ArpmtdValidCustdrft.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.AR
{
    public interface IArpmtdValidCustdrft
    {
        int ArpmtdValidCustdrftSp(ArCheckNumType CheckNum,
                                  CustNumType CustNum,
                                  InvNumType InvNum,
                                  DateType DueDate,
                                  StringType ArpmtdType,
                                  ArpmtTypeType ArpmtType,
                                  ref Infobar PromptMsg,
                                  ref Infobar Infobar);
    }

    public class ArpmtdValidCustdrft : IArpmtdValidCustdrft
    {
        readonly IApplicationDB appDB;

        public ArpmtdValidCustdrft(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ArpmtdValidCustdrftSp(ArCheckNumType CheckNum,
                                         CustNumType CustNum,
                                         InvNumType InvNum,
                                         DateType DueDate,
                                         StringType ArpmtdType,
                                         ArpmtTypeType ArpmtType,
                                         ref Infobar PromptMsg,
                                         ref Infobar Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ArpmtdValidCustdrftSp";

                appDB.AddCommandParameter(cmd, "CheckNum", CheckNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CustNum", CustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InvNum", InvNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DueDate", DueDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ArpmtdType", ArpmtdType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ArpmtType", ArpmtType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PromptMsg", PromptMsg, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
