//PROJECT NAME: CSIProduct
//CLASS NAME: JobtranLocValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface IJobtranLocValid
    {
        int JobtranLocValidSp(ItemType Item,
                              JobType Job,
                              SuffixType Suffix,
                              LocType InLoc,
                              WhseType Whse,
                              ref DescriptionType LocDesc,
                              ref ListYesNoType QuestionAsked,
                              ref InfobarType PromptMsg,
                              ref InfobarType PromptButtons,
                              ref InfobarType Infobar);
    }

    public class JobtranLocValid : IJobtranLocValid
    {
        readonly IApplicationDB appDB;

        public JobtranLocValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int JobtranLocValidSp(ItemType Item,
                                     JobType Job,
                                     SuffixType Suffix,
                                     LocType InLoc,
                                     WhseType Whse,
                                     ref DescriptionType LocDesc,
                                     ref ListYesNoType QuestionAsked,
                                     ref InfobarType PromptMsg,
                                     ref InfobarType PromptButtons,
                                     ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "JobtranLocValidSp";

                appDB.AddCommandParameter(cmd, "Item", Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Job", Job, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Suffix", Suffix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InLoc", InLoc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Whse", Whse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "LocDesc", LocDesc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "QuestionAsked", QuestionAsked, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptMsg", PromptMsg, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptButtons", PromptButtons, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
