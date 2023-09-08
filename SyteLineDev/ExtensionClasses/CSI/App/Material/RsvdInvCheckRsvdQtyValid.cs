//PROJECT NAME: CSIMaterial
//CLASS NAME: RsvdInvCheckRsvdQtyValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IRsvdInvCheckRsvdQtyValid
    {
        int RsvdInvCheckRsvdQtyValidSp(ItemType Item,
                                       WhseType Whse,
                                       LocType Loc,
                                       LotType Lot,
                                       QtyUnitType QtyRsvd,
                                       QtyUnitType QtyRsvdOld,
                                       ref Infobar Infobar,
                                       ImportDocIdType ImportDocId);
    }

    public class RsvdInvCheckRsvdQtyValid : IRsvdInvCheckRsvdQtyValid
    {
        readonly IApplicationDB appDB;

        public RsvdInvCheckRsvdQtyValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int RsvdInvCheckRsvdQtyValidSp(ItemType Item,
                                              WhseType Whse,
                                              LocType Loc,
                                              LotType Lot,
                                              QtyUnitType QtyRsvd,
                                              QtyUnitType QtyRsvdOld,
                                              ref Infobar Infobar,
                                              ImportDocIdType ImportDocId)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "RsvdInvCheckRsvdQtyValidSp";

                appDB.AddCommandParameter(cmd, "Item", Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Whse", Whse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Loc", Loc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Lot", Lot, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "QtyRsvd", QtyRsvd, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "QtyRsvdOld", QtyRsvdOld, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ImportDocId", ImportDocId, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
