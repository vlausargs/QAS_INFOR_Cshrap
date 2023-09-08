//PROJECT NAME: CSIMaterial
//CLASS NAME: ValidateLocationForExternalWarehouse.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IValidateLocationForExternalWarehouse
    {
        int ValidateLocationForExternalWarehouseSp(WhseType PWhse,
                                                   LocType PLoc,
                                                   ref InfobarType Infobar);
        int? ValidateLocationForExternalWarehouseFn(
            string PWhse,
            string PLoc);

    }

    public class ValidateLocationForExternalWarehouse : IValidateLocationForExternalWarehouse
    {
        readonly IApplicationDB appDB;

        public ValidateLocationForExternalWarehouse(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ValidateLocationForExternalWarehouseSp(WhseType PWhse,
                                                          LocType PLoc,
                                                          ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ValidateLocationForExternalWarehouseSp";

                appDB.AddCommandParameter(cmd, "PWhse", PWhse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PLoc", PLoc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }

        public int? ValidateLocationForExternalWarehouseFn(
            string PWhse,
            string PLoc)
        {
            WhseType _PWhse = PWhse;
            LocType _PLoc = PLoc;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  dbo.[ValidateLocationForExternalWarehouse](@PWhse, @PLoc)";

                appDB.AddCommandParameter(cmd, "PWhse", _PWhse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PLoc", _PLoc, ParameterDirection.Input);

                var Output = appDB.ExecuteScalar<int?>(cmd);

                return Output;
            }
        }
    }
}
