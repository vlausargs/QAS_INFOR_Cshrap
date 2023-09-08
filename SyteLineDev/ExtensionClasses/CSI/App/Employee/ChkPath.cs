//PROJECT NAME: CSIEmployee
//CLASS NAME: ChkPath.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
    public interface IChkPath
    {
        int ChkPathSp(LongListType Path,
                      ref LongListType TChar);
    }

    public class ChkPath : IChkPath
    {
        readonly IApplicationDB appDB;

        public ChkPath(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ChkPathSp(LongListType Path,
                             ref LongListType TChar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ChkPathSp";

                appDB.AddCommandParameter(cmd, "Path", Path, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TChar", TChar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
