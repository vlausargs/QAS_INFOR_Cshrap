//PROJECT NAME: CSIMaterial
//CLASS NAME: GuidSystemParCanAny.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IGuidSystemParCanAny
    {
        int GuidSystemParCanAnySp(StringType Type1,
                                  AuthorizationObjectNameType FormName1,
                                  StringType Type2,
                                  AuthorizationObjectNameType FormName2,
                                  ref PrivilegeType Privilege1,
                                  ref PrivilegeType Privilege2,
                                  ref GuidType GUID,
                                  ref ApsModeType ApsParmApsmode,
                                  ref InfobarType Infobar);
    }

    public class GuidSystemParCanAny : IGuidSystemParCanAny
    {
        readonly IApplicationDB appDB;

        public GuidSystemParCanAny(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int GuidSystemParCanAnySp(StringType Type1,
                                         AuthorizationObjectNameType FormName1,
                                         StringType Type2,
                                         AuthorizationObjectNameType FormName2,
                                         ref PrivilegeType Privilege1,
                                         ref PrivilegeType Privilege2,
                                         ref GuidType GUID,
                                         ref ApsModeType ApsParmApsmode,
                                         ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GuidSystemParCanAnySp";

                appDB.AddCommandParameter(cmd, "Type1", Type1, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FormName1", FormName1, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Type2", Type2, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FormName2", FormName2, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Privilege1", Privilege1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Privilege2", Privilege2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "GUID", GUID, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ApsParmApsmode", ApsParmApsmode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
