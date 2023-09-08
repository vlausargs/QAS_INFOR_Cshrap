//PROJECT NAME: CSIMaterial
//CLASS NAME: ChangeTransferExchRate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IChangeTransferExchRate
    {
        int ChangeTransferExchRateSp(SiteType FromSite,
                                     SiteType ToSite,
                                     ExchRateType ExchRate,
                                     ref InfobarType Infobar);
    }

    public class ChangeTransferExchRate : IChangeTransferExchRate
    {
        readonly IApplicationDB appDB;

        public ChangeTransferExchRate(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ChangeTransferExchRateSp(SiteType FromSite,
                                            SiteType ToSite,
                                            ExchRateType ExchRate,
                                            ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ChangeTransferExchRateSp";

                appDB.AddCommandParameter(cmd, "FromSite", FromSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ToSite", ToSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExchRate", ExchRate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
