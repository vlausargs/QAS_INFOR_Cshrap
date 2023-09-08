//PROJECT NAME: CSIFinance
//CLASS NAME: FaUpdPre.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.FixedAssets
{
    public interface IFaUpdPre
    {
        int FaUpdPreSp(TokenType PUserID,
                       IntType ErrorCnt,
                       ref InfobarType PromptMsg,
                       ref Infobar PromptButtons,
                       ref InfobarType Infobar);
    }

    public class FaUpdPre : IFaUpdPre
    {
        readonly IApplicationDB appDB;

        public FaUpdPre(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int FaUpdPreSp(TokenType PUserID,
                              IntType ErrorCnt,
                              ref InfobarType PromptMsg,
                              ref Infobar PromptButtons,
                              ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "FaUpdPreSp";

                appDB.AddCommandParameter(cmd, "PUserID", PUserID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ErrorCnt", ErrorCnt, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PromptMsg", PromptMsg, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptButtons", PromptButtons, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
