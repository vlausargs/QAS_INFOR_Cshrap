//PROJECT NAME: CSIMaterial
//CLASS NAME: ResforOrderUpdate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IResforOrderUpdate
    {
        int ResforOrderUpdateSp(LongListType PCmd,
                                ref RsvdNumType RsvdNum,
                                ItemType Item,
                                WhseType Whse,
                                CoNumType RefNum,
                                CoLineType RefLine,
                                CoLineType RefRelease,
                                CustNumType CustNum,
                                LocType Loc,
                                LotType Lot,
                                QtyUnitType Qty,
                                UMType UM,
                                RowPointerType SessionID,
                                ref Infobar Infobar,
                                ImportDocIdType ImportDocId);
    }

    public class ResforOrderUpdate : IResforOrderUpdate
    {
        readonly IApplicationDB appDB;

        public ResforOrderUpdate(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ResforOrderUpdateSp(LongListType PCmd,
                                       ref RsvdNumType RsvdNum,
                                       ItemType Item,
                                       WhseType Whse,
                                       CoNumType RefNum,
                                       CoLineType RefLine,
                                       CoLineType RefRelease,
                                       CustNumType CustNum,
                                       LocType Loc,
                                       LotType Lot,
                                       QtyUnitType Qty,
                                       UMType UM,
                                       RowPointerType SessionID,
                                       ref Infobar Infobar,
                                       ImportDocIdType ImportDocId)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ResforOrderUpdateSp";

                appDB.AddCommandParameter(cmd, "PCmd", PCmd, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RsvdNum", RsvdNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Item", Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Whse", Whse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RefNum", RefNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RefLine", RefLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RefRelease", RefRelease, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CustNum", CustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Loc", Loc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Lot", Lot, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Qty", Qty, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UM", UM, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SessionID", SessionID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ImportDocId", ImportDocId, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
