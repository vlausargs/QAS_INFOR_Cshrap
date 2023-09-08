//PROJECT NAME: CSIProduct
//CLASS NAME: SaveJobtranitem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface ISaveJobtranitem
    {
        int SaveJobtranitemSp(decimal? TransNum,
                              string Item,
                              decimal? QtyComplete,
                              decimal? QtyMoved,
                              decimal? QtyScrapped,
                              string Reason,
                              int? NextOper,
                              string Loc,
                              string Lot);
    }

    public class SaveJobtranitem : ISaveJobtranitem
    {
        readonly IApplicationDB appDB;

        public SaveJobtranitem(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SaveJobtranitemSp(decimal? TransNum,
                                     string Item,
                                     decimal? QtyComplete,
                                     decimal? QtyMoved,
                                     decimal? QtyScrapped,
                                     string Reason,
                                     int? NextOper,
                                     string Loc,
                                     string Lot)
        {
            HugeTransNumType _TransNum = TransNum;
            ItemType _Item = Item;
            QtyUnitType _QtyComplete = QtyComplete;
            QtyUnitType _QtyMoved = QtyMoved;
            QtyUnitType _QtyScrapped = QtyScrapped;
            ReasonCodeType _Reason = Reason;
            OperNumType _NextOper = NextOper;
            LocType _Loc = Loc;
            LotType _Lot = Lot;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SaveJobtranitemSp";

                appDB.AddCommandParameter(cmd, "TransNum", _TransNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "QtyComplete", _QtyComplete, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "QtyMoved", _QtyMoved, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "QtyScrapped", _QtyScrapped, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Reason", _Reason, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "NextOper", _NextOper, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
