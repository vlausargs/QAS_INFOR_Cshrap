using CSI.Data.SQL.UDDT;
using CSI.MG;
using System;
using System.Data;
using System.Linq;

namespace CSI.Data.Functions
{
    public class IsAddonAvailable : IIsAddonAvailable
    {
        readonly IApplicationDB appDB;


        public IsAddonAvailable(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int? IsAddonAvailableFn(string ModuleName)
        {
            LicenseModuleNameType _ModuleName = ModuleName;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  dbo.[IsAddonAvailable](@ModuleName)";

                appDB.AddCommandParameter(cmd, "ModuleName", _ModuleName, ParameterDirection.Input);

                var Output = appDB.ExecuteScalar<int?>(cmd);

                return Output;
            }
        }
    }

    static class SqlStyleExtensions
    {
        public static bool In(this LicenseModuleNameType me, params LicenseModuleNameType[] set)
        {
            return set.Contains(me);
        }
    }
}
