//PROJECT NAME: MG.MGCore
//CLASS NAME: GetIsolationLevel.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.Functions
{
    public class GetIsolationLevel : IGetIsolationLevel
    {
        IApplicationDB appDB;

        public GetIsolationLevel(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public string GetIsolationLevelFn(string Taskname)
        {
            BGTaskNameType _Taskname = Taskname;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  dbo.[GetIsolationLevel](@Taskname)";

                appDB.AddCommandParameter(cmd, "Taskname", _Taskname, ParameterDirection.Input);

                var Output = appDB.ExecuteScalar<string>(cmd);

                return Output;
            }
        }
    }
}
