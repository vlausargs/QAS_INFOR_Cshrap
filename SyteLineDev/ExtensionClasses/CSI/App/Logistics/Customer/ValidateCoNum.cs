//PROJECT NAME: CSICustomer
//CLASS NAME: ValidateCoNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IValidateCoNum
    {
        int ValidateCoNumSp(CoNumType CoNum,
                            ref InfobarType PromptMsg,
                            ref InfobarType PromptButtons);
    }

    public class ValidateCoNum : IValidateCoNum
    {
        readonly IApplicationDB appDB;

        public ValidateCoNum(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ValidateCoNumSp(CoNumType CoNum,
                                   ref InfobarType PromptMsg,
                                   ref InfobarType PromptButtons)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ValidateCoNumSp";

                appDB.AddCommandParameter(cmd, "CoNum", CoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PromptMsg", PromptMsg, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptButtons", PromptButtons, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
