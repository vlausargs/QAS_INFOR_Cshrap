//PROJECT NAME: CSIMaterial
//CLASS NAME: TrrcvTrnNumValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface ITrrcvTrnNumValid
    {
        int TrrcvTrnNumValidSp(ref string TrnNum,
                               ref string FromSite,
                               ref string ToSite,
                               ref string FobSite,
                               ref string FromWhse,
                               ref string ToWhse,
                               ref string Stat,
                               ref string Site,
                               ref string Whse,
                               ref string Infobar);
    }

    public class TrrcvTrnNumValid : ITrrcvTrnNumValid
    {
        readonly IApplicationDB appDB;

        public TrrcvTrnNumValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int TrrcvTrnNumValidSp(ref string TrnNum,
                                      ref string FromSite,
                                      ref string ToSite,
                                      ref string FobSite,
                                      ref string FromWhse,
                                      ref string ToWhse,
                                      ref string Stat,
                                      ref string Site,
                                      ref string Whse,
                                      ref string Infobar)
        {
            TrnNumType _TrnNum = TrnNum;
            SiteType _FromSite = FromSite;
            SiteType _ToSite = ToSite;
            SiteType _FobSite = FobSite;
            WhseType _FromWhse = FromWhse;
            WhseType _ToWhse = ToWhse;
            TransferStatusType _Stat = Stat;
            SiteType _Site = Site;
            WhseType _Whse = Whse;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TrrcvTrnNumValidSp";

                appDB.AddCommandParameter(cmd, "TrnNum", _TrnNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "FromSite", _FromSite, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ToSite", _ToSite, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "FobSite", _FobSite, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "FromWhse", _FromWhse, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ToWhse", _ToWhse, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Stat", _Stat, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                TrnNum = _TrnNum;
                FromSite = _FromSite;
                ToSite = _ToSite;
                FobSite = _FobSite;
                FromWhse = _FromWhse;
                ToWhse = _ToWhse;
                Stat = _Stat;
                Site = _Site;
                Whse = _Whse;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
