//PROJECT NAME: CSIMaterial
//CLASS NAME: RsvdInvPostSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IRsvdInvPostSave
    {
        int RsvdInvPostSaveSp(ItemType Item,
                              WhseType Whse,
                              LocType Loc,
                              LotType Lot,
                              QtyUnitType QtyRsvd,
                              QtyUnitType OldQtyRsvd,
                              CoNumType RefNum,
                              CoLineType RefLine,
                              CoReleaseType RefRelease,
                              ListYesNoType ItLotTracked,
                              ref Infobar Infobar,
                              ImportDocIdType ImportDocId);
    }

    public class RsvdInvPostSave : IRsvdInvPostSave
    {
        readonly IApplicationDB appDB;

        public RsvdInvPostSave(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int RsvdInvPostSaveSp(ItemType Item,
                                     WhseType Whse,
                                     LocType Loc,
                                     LotType Lot,
                                     QtyUnitType QtyRsvd,
                                     QtyUnitType OldQtyRsvd,
                                     CoNumType RefNum,
                                     CoLineType RefLine,
                                     CoReleaseType RefRelease,
                                     ListYesNoType ItLotTracked,
                                     ref Infobar Infobar,
                                     ImportDocIdType ImportDocId)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "RsvdInvPostSaveSp";

                appDB.AddCommandParameter(cmd, "Item", Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Whse", Whse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Loc", Loc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Lot", Lot, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "QtyRsvd", QtyRsvd, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OldQtyRsvd", OldQtyRsvd, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RefNum", RefNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RefLine", RefLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RefRelease", RefRelease, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ItLotTracked", ItLotTracked, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ImportDocId", ImportDocId, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
