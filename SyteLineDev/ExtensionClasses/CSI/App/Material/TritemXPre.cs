//PROJECT NAME: CSIMaterial
//CLASS NAME: TritemXPre.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface ITritemXPre
    {
        int TritemXPreSp(InfobarType SourceFile,
                         RefTypeIJPRType SourceRefType,
                         JobPoReqNumType SourceRefNum,
                         SuffixPoReqLineType SourceRefLineSuf,
                         PoReleaseType SourceRefRelease,
                         ItemType SourceItem,
                         DateType PDueDate,
                         ref FlagNyType PoChangeOrd,
                         ref InfobarType PromptMsg1,
                         ref InfobarType PromptButtons1,
                         ref InfobarType PromptMsg2,
                         ref InfobarType PromptButtons2,
                         ref InfobarType PromptMsg3,
                         ref InfobarType PromptButtons3,
                         ref InfobarType PromptMsg4,
                         ref InfobarType PromptButtons4,
                         ref InfobarType PromptMsg5,
                         ref InfobarType PromptButtons5,
                         ref InfobarType Infobar);
    }

    public class TritemXPre : ITritemXPre
    {
        readonly IApplicationDB appDB;

        public TritemXPre(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int TritemXPreSp(InfobarType SourceFile,
                                RefTypeIJPRType SourceRefType,
                                JobPoReqNumType SourceRefNum,
                                SuffixPoReqLineType SourceRefLineSuf,
                                PoReleaseType SourceRefRelease,
                                ItemType SourceItem,
                                DateType PDueDate,
                                ref FlagNyType PoChangeOrd,
                                ref InfobarType PromptMsg1,
                                ref InfobarType PromptButtons1,
                                ref InfobarType PromptMsg2,
                                ref InfobarType PromptButtons2,
                                ref InfobarType PromptMsg3,
                                ref InfobarType PromptButtons3,
                                ref InfobarType PromptMsg4,
                                ref InfobarType PromptButtons4,
                                ref InfobarType PromptMsg5,
                                ref InfobarType PromptButtons5,
                                ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TritemXPreSp";

                appDB.AddCommandParameter(cmd, "SourceFile", SourceFile, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SourceRefType", SourceRefType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SourceRefNum", SourceRefNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SourceRefLineSuf", SourceRefLineSuf, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SourceRefRelease", SourceRefRelease, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SourceItem", SourceItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PDueDate", PDueDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PoChangeOrd", PoChangeOrd, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptMsg1", PromptMsg1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptButtons1", PromptButtons1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptMsg2", PromptMsg2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptButtons2", PromptButtons2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptMsg3", PromptMsg3, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptButtons3", PromptButtons3, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptMsg4", PromptMsg4, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptButtons4", PromptButtons4, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptMsg5", PromptMsg5, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptButtons5", PromptButtons5, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
