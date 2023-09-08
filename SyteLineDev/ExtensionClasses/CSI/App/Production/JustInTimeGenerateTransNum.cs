//PROJECT NAME: CSIProduct
//CLASS NAME: JustInTimeGenerateTransNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface IJustInTimeGenerateTransNum
    {
        int JustInTimeGenerateTransNumSp(RowPointerType SessionID,
                                         ref HugeTransNumType TJobtranTransNum,
                                         ref InfobarType Infobar);
    }

    public class JustInTimeGenerateTransNum : IJustInTimeGenerateTransNum
    {
        readonly IApplicationDB appDB;

        public JustInTimeGenerateTransNum(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int JustInTimeGenerateTransNumSp(RowPointerType SessionID,
                                                ref HugeTransNumType TJobtranTransNum,
                                                ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "JustInTimeGenerateTransNumSp";

                appDB.AddCommandParameter(cmd, "SessionID", SessionID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TJobtranTransNum", TJobtranTransNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
