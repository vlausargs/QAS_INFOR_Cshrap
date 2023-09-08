//PROJECT NAME: CSIMaterial
//CLASS NAME: TransferLossDateChk.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface ITransferLossDateChk
    {
        int TransferLossDateChkSp(DateType TDate,
                                  SiteType Site,
                                  SiteType FromSite,
                                  SiteType ToSite,
                                  InfobarType FieldLabel,
                                  ref InfobarType PromptMsg1,
                                  ref InfobarType PromptButtons1,
                                  ref InfobarType PromptMsg2,
                                  ref InfobarType PromptButtons2,
                                  ref InfobarType Infobar);
    }

    public class TransferLossDateChk : ITransferLossDateChk
    {
        readonly IApplicationDB appDB;

        public TransferLossDateChk(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int TransferLossDateChkSp(DateType TDate,
                                         SiteType Site,
                                         SiteType FromSite,
                                         SiteType ToSite,
                                         InfobarType FieldLabel,
                                         ref InfobarType PromptMsg1,
                                         ref InfobarType PromptButtons1,
                                         ref InfobarType PromptMsg2,
                                         ref InfobarType PromptButtons2,
                                         ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TransferLossDateChkSp";

                appDB.AddCommandParameter(cmd, "TDate", TDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Site", Site, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FromSite", FromSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ToSite", ToSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FieldLabel", FieldLabel, ParameterDirection.Input);
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
