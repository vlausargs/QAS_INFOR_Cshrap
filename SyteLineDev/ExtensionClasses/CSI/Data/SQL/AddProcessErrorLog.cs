//PROJECT NAME: MG.MGCore
//CLASS NAME: AddProcessErrorLog.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.SQL
{
    public class AddProcessErrorLog : IAddProcessErrorLog
    {
        IApplicationDB appDB;


        public AddProcessErrorLog(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int? AddProcessErrorLogSp(int? ProcessID,
        string InfobarText,
        int? MessageSeverity = null)
        {
            GenericNoType _ProcessID = ProcessID;
            InfobarType _InfobarText = InfobarText;
            GenericNoType _MessageSeverity = MessageSeverity;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddProcessErrorLogSp";

                appDB.AddCommandParameter(cmd, "ProcessID", _ProcessID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InfobarText", _InfobarText, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "MessageSeverity", _MessageSeverity, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return (Severity);
            }
        }
    }
}
