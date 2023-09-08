//PROJECT NAME: CSIMaterial
//CLASS NAME: ValidateSiteMove.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IValidateSiteMove
    {
        int ValidateSiteMoveSp(SiteType FromSite,
                               SiteType ToSite,
                               ref InfobarType Infobar);
    }

    public class ValidateSiteMove : IValidateSiteMove
    {
        readonly IApplicationDB appDB;

        public ValidateSiteMove(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ValidateSiteMoveSp(SiteType FromSite,
                                      SiteType ToSite,
                                      ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ValidateSiteMoveSp";

                appDB.AddCommandParameter(cmd, "FromSite", FromSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ToSite", ToSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
