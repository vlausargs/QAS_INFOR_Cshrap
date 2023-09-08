//PROJECT NAME: MG.MGCore
//CLASS NAME: CanAny.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.SQL
{
    public class CanAny : ICanAny
    {
        IApplicationDB appDB;


        public CanAny(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public (int? ReturnCode, int? Privilege) CanAnySp(string Type,
        string FormName,
        int? Privilege)
        {
            StringType _Type = Type;
            AuthorizationObjectNameType _FormName = FormName;
            PrivilegeType _Privilege = Privilege;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CanAnySp";

                appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FormName", _FormName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Privilege", _Privilege, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Privilege = _Privilege;

                return (Severity, Privilege);
            }
        }

        public int? CanAnyFn(string Type,
        string FormName)
        {
            LongList _Type = Type;
            AuthorizationObjectNameType _FormName = FormName;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  dbo.[CanAny](@Type, @FormName)";

                appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FormName", _FormName, ParameterDirection.Input);

                var Output = appDB.ExecuteScalar<int?>(cmd);

                return Output;
            }
        }
    }
}
