//PROJECT NAME: CSIMaterial
//CLASS NAME: RsvdInvCheckLotValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IRsvdInvCheckLotValid
    {
        int RsvdInvCheckLotValidSp(ItemType Item,
                                   WhseType Whse,
                                   LocType Loc,
                                   LotType Lot,
                                   QtyUnitType QtyRsvd,
                                   ref Infobar Infobar,
                                   ImportDocIdType ImportDocId);
    }

    public class RsvdInvCheckLotValid : IRsvdInvCheckLotValid
    {
        readonly IApplicationDB appDB;

        public RsvdInvCheckLotValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int RsvdInvCheckLotValidSp(ItemType Item,
                                          WhseType Whse,
                                          LocType Loc,
                                          LotType Lot,
                                          QtyUnitType QtyRsvd,
                                          ref Infobar Infobar,
                                          ImportDocIdType ImportDocId)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "RsvdInvCheckLotValidSp";

                appDB.AddCommandParameter(cmd, "Item", Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Whse", Whse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Loc", Loc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Lot", Lot, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "QtyRsvd", QtyRsvd, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ImportDocId", ImportDocId, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
