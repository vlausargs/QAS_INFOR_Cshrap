//PROJECT NAME: CSIMaterial
//CLASS NAME: RsvdInvPostDelete.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IRsvdInvPostDelete
    {
        int RsvdInvPostDeleteSp(RsvdNumType RsvdNum,
                                ItemType Item,
                                WhseType Whse,
                                LocType Loc,
                                LotType Lot,
                                QtyUnitType QtyRsvd,
                                CoNumType RefNum,
                                CoLineType RefLine,
                                CoReleaseType RefRelease,
                                ListYesNoType ItLotTracked,
                                ListYesNoType ItSerialTracked,
                                ImportDocIdType ImportDocId);
    }

    public class RsvdInvPostDelete : IRsvdInvPostDelete
    {
        readonly IApplicationDB appDB;

        public RsvdInvPostDelete(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int RsvdInvPostDeleteSp(RsvdNumType RsvdNum,
                                       ItemType Item,
                                       WhseType Whse,
                                       LocType Loc,
                                       LotType Lot,
                                       QtyUnitType QtyRsvd,
                                       CoNumType RefNum,
                                       CoLineType RefLine,
                                       CoReleaseType RefRelease,
                                       ListYesNoType ItLotTracked,
                                       ListYesNoType ItSerialTracked,
                                       ImportDocIdType ImportDocId)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "RsvdInvPostDeleteSp";

                appDB.AddCommandParameter(cmd, "RsvdNum", RsvdNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Item", Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Whse", Whse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Loc", Loc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Lot", Lot, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "QtyRsvd", QtyRsvd, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RefNum", RefNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RefLine", RefLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RefRelease", RefRelease, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ItLotTracked", ItLotTracked, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ItSerialTracked", ItSerialTracked, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ImportDocId", ImportDocId, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
