//PROJECT NAME: CSIMaterial
//CLASS NAME: Sloclot.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface ISloclot
    {
        int SloclotSp(SiteType Site,
                      ItemType Item,
                      WhseType Whse,
                      LocType Loc,
                      ListYesNoType LotTracked,
                      EmpJobCoPoRmaProjPsTrnNumType RefNum,
                      CoLineSuffixPoLineProjTaskRmaTrnLineType RefLine,
                      CoReleaseOperNumPoReleaseType RefRelease,
                      RefTypeIJKOPRSTWType RefType,
                      ref LotType Lot,
                      ref InfobarType Infobar);
    }

    public class Sloclot : ISloclot
    {
        readonly IApplicationDB appDB;

        public Sloclot(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SloclotSp(SiteType Site,
                             ItemType Item,
                             WhseType Whse,
                             LocType Loc,
                             ListYesNoType LotTracked,
                             EmpJobCoPoRmaProjPsTrnNumType RefNum,
                             CoLineSuffixPoLineProjTaskRmaTrnLineType RefLine,
                             CoReleaseOperNumPoReleaseType RefRelease,
                             RefTypeIJKOPRSTWType RefType,
                             ref LotType Lot,
                             ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SloclotSp";

                appDB.AddCommandParameter(cmd, "Site", Site, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Item", Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Whse", Whse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Loc", Loc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "LotTracked", LotTracked, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RefNum", RefNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RefLine", RefLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RefRelease", RefRelease, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RefType", RefType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Lot", Lot, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
