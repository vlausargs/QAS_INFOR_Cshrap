//PROJECT NAME: CSIMaterial
//CLASS NAME: MiscIssueGetLotConvQtyOnHand.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IMiscIssueGetLotConvQtyOnHand
    {
        int MiscIssueGetLotConvQtyOnHandSp(WhseType Whse,
                                           ItemType Item,
                                           LocType Loc,
                                           LotType Lot,
                                           QtyUnitType QtyIssued,
                                           UMType UM,
                                           SiteType Site,
                                           ref QtyUnitType LotQtyOnHand,
                                           ref Infobar PromptMsg,
                                           ref Infobar PromptButtons,
                                           ref InfobarType Infobar,
                                           ImportDocIdType ImportDocId);
    }

    public class MiscIssueGetLotConvQtyOnHand : IMiscIssueGetLotConvQtyOnHand
    {
        readonly IApplicationDB appDB;

        public MiscIssueGetLotConvQtyOnHand(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int MiscIssueGetLotConvQtyOnHandSp(WhseType Whse,
                                                  ItemType Item,
                                                  LocType Loc,
                                                  LotType Lot,
                                                  QtyUnitType QtyIssued,
                                                  UMType UM,
                                                  SiteType Site,
                                                  ref QtyUnitType LotQtyOnHand,
                                                  ref Infobar PromptMsg,
                                                  ref Infobar PromptButtons,
                                                  ref InfobarType Infobar,
                                                  ImportDocIdType ImportDocId)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "MiscIssueGetLotConvQtyOnHandSp";

                appDB.AddCommandParameter(cmd, "Whse", Whse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Item", Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Loc", Loc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Lot", Lot, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "QtyIssued", QtyIssued, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UM", UM, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Site", Site, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "LotQtyOnHand", LotQtyOnHand, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptMsg", PromptMsg, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptButtons", PromptButtons, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ImportDocId", ImportDocId, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
