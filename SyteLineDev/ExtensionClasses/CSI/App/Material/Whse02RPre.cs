//PROJECT NAME: CSIMaterial
//CLASS NAME: Whse02RPre.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IWhse02RPre
    {
        int Whse02RPreSp(TrnNumType BegTrnNum,
                         TrnNumType EndTrnNum,
                         DateType PostDate,
                         ListYesNoType PostMatlIssues,
                         ref InfobarType PromptMsg,
                         ref InfobarType PromptButtons,
                         ref InfobarType Infobar);
    }

    public class Whse02RPre : IWhse02RPre
    {
        readonly IApplicationDB appDB;

        public Whse02RPre(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int Whse02RPreSp(TrnNumType BegTrnNum,
                                TrnNumType EndTrnNum,
                                DateType PostDate,
                                ListYesNoType PostMatlIssues,
                                ref InfobarType PromptMsg,
                                ref InfobarType PromptButtons,
                                ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Whse02RPreSp";

                appDB.AddCommandParameter(cmd, "BegTrnNum", BegTrnNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndTrnNum", EndTrnNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PostDate", PostDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PostMatlIssues", PostMatlIssues, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PromptMsg", PromptMsg, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptButtons", PromptButtons, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
