//PROJECT NAME: CSIMaterial
//CLASS NAME: TrnLocValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface ITrnLocValid
    {
        int TrnLocValidSp(ItemType PItem,
                          TrnNumType PTrnNum,
                          LocType TTrnLoc,
                          ref FlagNyType ItemLocQuestionAsked,
                          ref WhseType PWhse,
                          ref SiteType TSite,
                          ref InfobarType PromptMsg,
                          ref InfobarType PromptButtons,
                          ref InfobarType Infobar);
    }

    public class TrnLocValid : ITrnLocValid
    {
        readonly IApplicationDB appDB;

        public TrnLocValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int TrnLocValidSp(ItemType PItem,
                                 TrnNumType PTrnNum,
                                 LocType TTrnLoc,
                                 ref FlagNyType ItemLocQuestionAsked,
                                 ref WhseType PWhse,
                                 ref SiteType TSite,
                                 ref InfobarType PromptMsg,
                                 ref InfobarType PromptButtons,
                                 ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TrnLocValidSp";

                appDB.AddCommandParameter(cmd, "PItem", PItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PTrnNum", PTrnNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TTrnLoc", TTrnLoc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ItemLocQuestionAsked", ItemLocQuestionAsked, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PWhse", PWhse, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TSite", TSite, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptMsg", PromptMsg, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptButtons", PromptButtons, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
