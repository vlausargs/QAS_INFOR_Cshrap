//PROJECT NAME: CSIPOS
//CLASS NAME: SSSPOSCalcQtyShipped.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.POS
{
    public interface ISSSPOSCalcQtyShipped
    {
        int SSSPOSCalcQtyShippedSp(string Item,
                                   string Whse,
                                   string Loc,
                                   string Lot,
                                   byte? LotTracked,
                                   decimal? QtyOrderedConv,
                                   ref decimal? QtyShippedConv,
                                   ref string Infobar);
    }

    public class SSSPOSCalcQtyShipped : ISSSPOSCalcQtyShipped
    {
        readonly IApplicationDB appDB;

        public SSSPOSCalcQtyShipped(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSPOSCalcQtyShippedSp(string Item,
                                          string Whse,
                                          string Loc,
                                          string Lot,
                                          byte? LotTracked,
                                          decimal? QtyOrderedConv,
                                          ref decimal? QtyShippedConv,
                                          ref string Infobar)
        {
            ItemType _Item = Item;
            WhseType _Whse = Whse;
            LocType _Loc = Loc;
            LotType _Lot = Lot;
            ListYesNoType _LotTracked = LotTracked;
            QtyUnitType _QtyOrderedConv = QtyOrderedConv;
            QtyUnitType _QtyShippedConv = QtyShippedConv;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSPOSCalcQtyShippedSp";

                appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "LotTracked", _LotTracked, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "QtyOrderedConv", _QtyOrderedConv, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "QtyShippedConv", _QtyShippedConv, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                QtyShippedConv = _QtyShippedConv;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
