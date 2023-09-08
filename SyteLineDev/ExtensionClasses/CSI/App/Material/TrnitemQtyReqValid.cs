//PROJECT NAME: CSIMaterial
//CLASS NAME: TrnitemQtyReqValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface ITrnitemQtyReqValid
    {
        int TrnitemQtyReqValidSp(TrnNumType TrnNum,
                                 SiteType FromSite,
                                 SiteType ToSite,
                                 ItemType Item,
                                 QtyUnitType Qty,
                                 ref InfobarType Infobar);
    }

    public class TrnitemQtyReqValid : ITrnitemQtyReqValid
    {
        readonly IApplicationDB appDB;

        public TrnitemQtyReqValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int TrnitemQtyReqValidSp(TrnNumType TrnNum,
                                        SiteType FromSite,
                                        SiteType ToSite,
                                        ItemType Item,
                                        QtyUnitType Qty,
                                        ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TrnitemQtyReqValidSp";

                appDB.AddCommandParameter(cmd, "TrnNum", TrnNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FromSite", FromSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ToSite", ToSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Item", Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Qty", Qty, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
