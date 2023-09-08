//PROJECT NAME: CSIPOS
//CLASS NAME: SSSPOSQtyOnHandCheck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.POS
{
    public interface ISSSPOSQtyOnHandCheck
    {
        int SSSPOSQtyOnHandCheckSp(string Item,
                                   string Whse,
                                   string Loc,
                                   string Lot,
                                   byte? LotTracked,
                                   decimal? QtyShippedConv,
                                   ref byte? Valid,
                                   ref string Infobar);
    }

    public class SSSPOSQtyOnHandCheck : ISSSPOSQtyOnHandCheck
    {
        readonly IApplicationDB appDB;

        public SSSPOSQtyOnHandCheck(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSPOSQtyOnHandCheckSp(string Item,
                                          string Whse,
                                          string Loc,
                                          string Lot,
                                          byte? LotTracked,
                                          decimal? QtyShippedConv,
                                          ref byte? Valid,
                                          ref string Infobar)
        {
            ItemType _Item = Item;
            WhseType _Whse = Whse;
            LocType _Loc = Loc;
            LotType _Lot = Lot;
            ListYesNoType _LotTracked = LotTracked;
            QtyUnitType _QtyShippedConv = QtyShippedConv;
            ListYesNoType _Valid = Valid;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSPOSQtyOnHandCheckSp";

                appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "LotTracked", _LotTracked, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "QtyShippedConv", _QtyShippedConv, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Valid", _Valid, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Valid = _Valid;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
