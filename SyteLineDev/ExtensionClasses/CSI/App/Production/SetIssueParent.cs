//PROJECT NAME: CSIProduct
//CLASS NAME: SetIssueParent.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface ISetIssueParent
    {
        int SetIssueParentSp(string PJob,
                             short? PSuffix,
                             ref byte? PIssueParent,
                             ref string PProjNum,
                             ref int? PTaskNum,
                             ref int? PSeq,
                             ref string Infobar);
    }

    public class SetIssueParent : ISetIssueParent
    {
        readonly IApplicationDB appDB;

        public SetIssueParent(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SetIssueParentSp(string PJob,
                                    short? PSuffix,
                                    ref byte? PIssueParent,
                                    ref string PProjNum,
                                    ref int? PTaskNum,
                                    ref int? PSeq,
                                    ref string Infobar)
        {
            JobType _PJob = PJob;
            SuffixType _PSuffix = PSuffix;
            ListYesNoType _PIssueParent = PIssueParent;
            ProjNumType _PProjNum = PProjNum;
            TaskNumType _PTaskNum = PTaskNum;
            ProjmatlSeqType _PSeq = PSeq;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SetIssueParentSp";

                appDB.AddCommandParameter(cmd, "PJob", _PJob, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PSuffix", _PSuffix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PIssueParent", _PIssueParent, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PProjNum", _PProjNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PTaskNum", _PTaskNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PSeq", _PSeq, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                PIssueParent = _PIssueParent;
                PProjNum = _PProjNum;
                PTaskNum = _PTaskNum;
                PSeq = _PSeq;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
