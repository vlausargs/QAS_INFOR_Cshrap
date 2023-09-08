//PROJECT NAME: CSICustomer
//CLASS NAME: COShippingQtyConvWrapper.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface ICOShippingQtyConvWrapper
    {
        int COShippingQtyConvWrapperSp(decimal? UbQtyToShpConv,
                                       string Item,
                                       string UM,
                                       string CoCustNum,
                                       ref decimal? UbQtyToShp,
                                       ref string Infobar);
    }

    public class COShippingQtyConvWrapper : ICOShippingQtyConvWrapper
    {
        readonly IApplicationDB appDB;

        public COShippingQtyConvWrapper(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int COShippingQtyConvWrapperSp(decimal? UbQtyToShpConv,
                                              string Item,
                                              string UM,
                                              string CoCustNum,
                                              ref decimal? UbQtyToShp,
                                              ref string Infobar)
        {
            QtyUnitType _UbQtyToShpConv = UbQtyToShpConv;
            ItemType _Item = Item;
            UMType _UM = UM;
            CustNumType _CoCustNum = CoCustNum;
            QtyUnitType _UbQtyToShp = UbQtyToShp;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "COShippingQtyConvWrapperSp";

                appDB.AddCommandParameter(cmd, "UbQtyToShpConv", _UbQtyToShpConv, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoCustNum", _CoCustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UbQtyToShp", _UbQtyToShp, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                UbQtyToShp = _UbQtyToShp;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
