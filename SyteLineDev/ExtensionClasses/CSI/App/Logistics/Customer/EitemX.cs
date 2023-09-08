//PROJECT NAME: CSICustomer
//CLASS NAME: EitemX.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IEitemX
    {
        int EitemXSp(CoNumType EstNum,
                     CoLineType EstLine,
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

    public class EitemX : IEitemX
    {
        readonly IApplicationDB appDB;

        public EitemX(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int EitemXSp(CoNumType EstNum,
                            CoLineType EstLine,
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
                cmd.CommandText = "EitemXSp";

                appDB.AddCommandParameter(cmd, "EstNum", EstNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EstLine", EstLine, ParameterDirection.Input);
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
