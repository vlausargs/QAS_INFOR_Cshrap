//PROJECT NAME: CSIMaterial
//CLASS NAME: TrnShipLocChange.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface ITrnShipLocChange
    {
        int TrnShipLocChangeSp(TrnNumType TrnNum,
                               TrnLineType TrnLine,
                               ItemType Item,
                               WhseType Whse,
                               LocType Loc,
                               UMConvFactorType UmConvFactor,
                               ref LotType Lot,
                               ref QtyUnitType QtyToShip,
                               ref QtyUnitType QtyOnHandConv,
                               ref QtyUnitType QtyOnHand,
                               ref InfobarType Infobar,
                               ImportDocIdType ImportDocId);
    }

    public class TrnShipLocChange : ITrnShipLocChange
    {
        readonly IApplicationDB appDB;

        public TrnShipLocChange(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int TrnShipLocChangeSp(TrnNumType TrnNum,
                                      TrnLineType TrnLine,
                                      ItemType Item,
                                      WhseType Whse,
                                      LocType Loc,
                                      UMConvFactorType UmConvFactor,
                                      ref LotType Lot,
                                      ref QtyUnitType QtyToShip,
                                      ref QtyUnitType QtyOnHandConv,
                                      ref QtyUnitType QtyOnHand,
                                      ref InfobarType Infobar,
                                      ImportDocIdType ImportDocId)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TrnShipLocChangeSp";

                appDB.AddCommandParameter(cmd, "TrnNum", TrnNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TrnLine", TrnLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Item", Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Whse", Whse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Loc", Loc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UmConvFactor", UmConvFactor, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Lot", Lot, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "QtyToShip", QtyToShip, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "QtyOnHandConv", QtyOnHandConv, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "QtyOnHand", QtyOnHand, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ImportDocId", ImportDocId, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
