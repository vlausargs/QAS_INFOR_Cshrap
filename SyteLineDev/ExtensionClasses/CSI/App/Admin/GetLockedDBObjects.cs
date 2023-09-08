//PROJECT NAME: CSIAdmin
//CLASS NAME: GetLockedDBObjects.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Admin
{
    public interface IGetLockedDBObjects
    {
        int GetLockedDBObjectsSp(ref IntType LockedUsers,
                                 ref IntType LockedFunctions,
                                 ref IntType LockedJournals);
    }

    public class GetLockedDBObjects : IGetLockedDBObjects
    {
        IApplicationDB appDB;

        public GetLockedDBObjects(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int GetLockedDBObjectsSp(ref IntType LockedUsers,
                                        ref IntType LockedFunctions,
                                        ref IntType LockedJournals)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetLockedDBObjectsSp";

                appDB.AddCommandParameter(cmd, "LockedUsers", LockedUsers, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "LockedFunctions", LockedFunctions, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "LockedJournals", LockedJournals, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}

