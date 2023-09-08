//PROJECT NAME: CSIEmployee
//CLASS NAME: MarkProMgrMyTaskState.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
    public interface IMarkProMgrMyTaskState
    {
        int MarkProMgrMyTaskStateSp(RowPointerType RowPointer,
                                    UsernameType UserName);
    }

    public class MarkProMgrMyTaskState : IMarkProMgrMyTaskState
    {
        readonly IApplicationDB appDB;

        public MarkProMgrMyTaskState(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int MarkProMgrMyTaskStateSp(RowPointerType RowPointer,
                                           UsernameType UserName)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "MarkProMgrMyTaskStateSp";

                appDB.AddCommandParameter(cmd, "RowPointer", RowPointer, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UserName", UserName, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
