//PROJECT NAME: CSICustomer
//CLASS NAME: ReadyQtyCalc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IReadyQtyCalc
    {
        int ReadyQtyCalcsp(string RefType,
                           string Item,
                           string OldWhse,
                           string ShipSite,
                           ref decimal? QtyReady);
    }

    public class ReadyQtyCalc : IReadyQtyCalc
    {
        readonly IApplicationDB appDB;

        public ReadyQtyCalc(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ReadyQtyCalcsp(string RefType,
                                  string Item,
                                  string OldWhse,
                                  string ShipSite,
                                  ref decimal? QtyReady)
        {
            RefTypeIJKPRTType _RefType = RefType;
            ItemType _Item = Item;
            WhseType _OldWhse = OldWhse;
            SiteType _ShipSite = ShipSite;
            QtyUnitType _QtyReady = QtyReady;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ReadyQtyCalcsp";

                appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OldWhse", _OldWhse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ShipSite", _ShipSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "QtyReady", _QtyReady, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                QtyReady = _QtyReady;

                return Severity;
            }
        }
    }
}
