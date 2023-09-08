//PROJECT NAME: CSIEmployee
//CLASS NAME: PMMyTaskAttachSync.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
    public interface IPMMyTaskAttachSync
    {
        int PMMyTaskAttachSyncSp(RowPointerType RowPointer);
    }

    public class PMMyTaskAttachSync : IPMMyTaskAttachSync
    {
        readonly IApplicationDB appDB;

        public PMMyTaskAttachSync(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int PMMyTaskAttachSyncSp(RowPointerType RowPointer)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PMMyTaskAttachSyncSp";

                appDB.AddCommandParameter(cmd, "RowPointer", RowPointer, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
