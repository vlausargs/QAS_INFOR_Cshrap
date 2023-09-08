//PROJECT NAME: CSIDataCollection
//CLASS NAME: DcsfcLotValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.DataCollection
{
    public interface IDcsfcLotValid
    {
        int DcsfcLotValidSp(LotType InLot,
                            ItemType InItem,
                            EmpJobCoPoRmaProjPsTrnNumType RefNum,
                            CoLineSuffixPoLineProjTaskRmaTrnLineType RefLine,
                            CoReleaseOperNumPoReleaseType RefRelease,
                            RefTypeIJKOPRSTWType RefType,
                            ref LotType OutLot,
                            ref FlagNyType AddQuestionAsked,
                            ref FlagNyType ContQuestionAsked,
                            ref InfobarType PromptMsg,
                            ref InfobarType PromptButtons,
                            ref InfobarType Infobar);
    }

    public class DcsfcLotValid : IDcsfcLotValid
    {
        readonly IApplicationDB appDB;

        public DcsfcLotValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int DcsfcLotValidSp(LotType InLot,
                                   ItemType InItem,
                                   EmpJobCoPoRmaProjPsTrnNumType RefNum,
                                   CoLineSuffixPoLineProjTaskRmaTrnLineType RefLine,
                                   CoReleaseOperNumPoReleaseType RefRelease,
                                   RefTypeIJKOPRSTWType RefType,
                                   ref LotType OutLot,
                                   ref FlagNyType AddQuestionAsked,
                                   ref FlagNyType ContQuestionAsked,
                                   ref InfobarType PromptMsg,
                                   ref InfobarType PromptButtons,
                                   ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DcsfcLotValidSp";

                appDB.AddCommandParameter(cmd, "InLot", InLot, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InItem", InItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RefNum", RefNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RefLine", RefLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RefRelease", RefRelease, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RefType", RefType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OutLot", OutLot, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "AddQuestionAsked", AddQuestionAsked, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ContQuestionAsked", ContQuestionAsked, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptMsg", PromptMsg, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptButtons", PromptButtons, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}

