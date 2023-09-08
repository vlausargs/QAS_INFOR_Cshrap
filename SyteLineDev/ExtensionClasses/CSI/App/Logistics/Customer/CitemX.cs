//PROJECT NAME: CSICustomer
//CLASS NAME: CitemX.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface ICitemX
    {
        int CitemXSp(CoNumType CoNum,
                     CoLineType CoLine,
                     CoReleaseType CoRelease,
                     RefTypeIJKPRTType RefType,
                     JobPoProjReqTrnNumType RefNum,
                     SuffixPoLineProjTaskReqTrnLineType RefLineSuf,
                     OperNumPoReleaseType RefRelease,
                     ItemType Item,
                     UMType UM,
                     QtyUnitType QtyOrdered,
                     DateType DueDate,
                     WhseType Whse,
                     ref SuffixPoReqLineType CurSuffix,
                     ref InfobarType TXrefDestination,
                     ref FlagNyType CreateFlag,
                     ref FlagNyType CreateFlag2,
                     ref InfobarType PromptMsg,
                     ref InfobarType PromptButtons,
                     ref InfobarType Infobar);
    }

    public class CitemX : ICitemX
    {
        readonly IApplicationDB appDB;

        public CitemX(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CitemXSp(CoNumType CoNum,
                            CoLineType CoLine,
                            CoReleaseType CoRelease,
                            RefTypeIJKPRTType RefType,
                            JobPoProjReqTrnNumType RefNum,
                            SuffixPoLineProjTaskReqTrnLineType RefLineSuf,
                            OperNumPoReleaseType RefRelease,
                            ItemType Item,
                            UMType UM,
                            QtyUnitType QtyOrdered,
                            DateType DueDate,
                            WhseType Whse,
                            ref SuffixPoReqLineType CurSuffix,
                            ref InfobarType TXrefDestination,
                            ref FlagNyType CreateFlag,
                            ref FlagNyType CreateFlag2,
                            ref InfobarType PromptMsg,
                            ref InfobarType PromptButtons,
                            ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CitemXSp";

                appDB.AddCommandParameter(cmd, "CoNum", CoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoLine", CoLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoRelease", CoRelease, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RefType", RefType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RefNum", RefNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RefLineSuf", RefLineSuf, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RefRelease", RefRelease, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Item", Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UM", UM, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "QtyOrdered", QtyOrdered, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DueDate", DueDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Whse", Whse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CurSuffix", CurSuffix, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TXrefDestination", TXrefDestination, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CreateFlag", CreateFlag, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CreateFlag2", CreateFlag2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptMsg", PromptMsg, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptButtons", PromptButtons, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
