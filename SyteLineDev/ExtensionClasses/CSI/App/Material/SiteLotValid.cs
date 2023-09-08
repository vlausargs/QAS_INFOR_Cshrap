//PROJECT NAME: CSIMaterial
//CLASS NAME: SiteLotValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface ISiteLotValid
    {
        int SiteLotValidSp(ItemType pItem,
                           LotType pLot,
                           LocType pTrnLoc,
                           WhseType pWhse,
                           SiteType pSite,
                           ref InfobarType Infobar);
    }

    public class SiteLotValid : ISiteLotValid
    {
        readonly IApplicationDB appDB;

        public SiteLotValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SiteLotValidSp(ItemType pItem,
                                  LotType pLot,
                                  LocType pTrnLoc,
                                  WhseType pWhse,
                                  SiteType pSite,
                                  ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SiteLotValidSp";

                appDB.AddCommandParameter(cmd, "pItem", pItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pLot", pLot, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pTrnLoc", pTrnLoc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pWhse", pWhse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pSite", pSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
