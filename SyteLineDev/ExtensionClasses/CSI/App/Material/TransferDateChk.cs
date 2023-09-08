//PROJECT NAME: CSIMaterial
//CLASS NAME: TransferDateChk.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface ITransferDateChk
    {
        int TransferDateChkSp(SiteType TSite,
                              DateType TDate,
                              ref InfobarType PromptMsg1,
                              ref InfobarType PromptButtons1,
                              ref InfobarType PromptMsg2,
                              ref InfobarType PromptButtons2,
                              ref InfobarType Infobar);
    }

    public class TransferDateChk : ITransferDateChk
    {
        readonly IApplicationDB appDB;

        public TransferDateChk(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int TransferDateChkSp(SiteType TSite,
                                     DateType TDate,
                                     ref InfobarType PromptMsg1,
                                     ref InfobarType PromptButtons1,
                                     ref InfobarType PromptMsg2,
                                     ref InfobarType PromptButtons2,
                                     ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TransferDateChkSp";

                appDB.AddCommandParameter(cmd, "TSite", TSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TDate", TDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PromptMsg1", PromptMsg1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptButtons1", PromptButtons1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptMsg2", PromptMsg2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptButtons2", PromptButtons2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
