//PROJECT NAME: CSIMaterial
//CLASS NAME: Alloctr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IAlloctr
    {
        int AlloctrSp(TrnNumType CurTrnNum,
                      ref IntType ProcessLevel,
                      ref InfobarType PromptMsg,
                      ref InfobarType PromptButtons,
                      ref InfobarType Infobar);
    }

    public class Alloctr : IAlloctr
    {
        readonly IApplicationDB appDB;

        public Alloctr(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int AlloctrSp(TrnNumType CurTrnNum,
                             ref IntType ProcessLevel,
                             ref InfobarType PromptMsg,
                             ref InfobarType PromptButtons,
                             ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AlloctrSp";

                appDB.AddCommandParameter(cmd, "CurTrnNum", CurTrnNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ProcessLevel", ProcessLevel, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptMsg", PromptMsg, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptButtons", PromptButtons, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
