//PROJECT NAME: CSIFinance
//CLASS NAME: IsSiteAndHasSameBaseCurr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance
{
    public interface IIsSiteAndHasSameBaseCurr
    {
        int IsSiteAndHasSameBaseCurrSp(ref SiteType PSite,
                                       ref InfobarType Infobar);
    }

    public class IsSiteAndHasSameBaseCurr : IIsSiteAndHasSameBaseCurr
    {
        readonly IApplicationDB appDB;

        public IsSiteAndHasSameBaseCurr(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int IsSiteAndHasSameBaseCurrSp(ref SiteType PSite,
                                              ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "IsSiteAndHasSameBaseCurrSp";

                appDB.AddCommandParameter(cmd, "PSite", PSite, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}