//PROJECT NAME: CSICustomer
//CLASS NAME: Homepage_GetItemVendPriceBrkInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IHomepage_GetItemVendPriceBrkInfo
    {
        int Homepage_GetItemVendPriceBrkInfoSp(string VendNum,
                                               string Item,
                                               string VendItem,
                                               ref decimal? BrkQty1,
                                               ref decimal? BrkQty2,
                                               ref decimal? BrkQty3,
                                               ref decimal? BrkQty4,
                                               ref decimal? BrkQty5,
                                               ref decimal? BrkCost1,
                                               ref decimal? BrkCost2,
                                               ref decimal? BrkCost3,
                                               ref decimal? BrkCost4,
                                               ref decimal? BrkCost5,
                                               ref string Infobar);
    }

    public class Homepage_GetItemVendPriceBrkInfo : IHomepage_GetItemVendPriceBrkInfo
    {
        readonly IApplicationDB appDB;

        public Homepage_GetItemVendPriceBrkInfo(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int Homepage_GetItemVendPriceBrkInfoSp(string VendNum,
                                                      string Item,
                                                      string VendItem,
                                                      ref decimal? BrkQty1,
                                                      ref decimal? BrkQty2,
                                                      ref decimal? BrkQty3,
                                                      ref decimal? BrkQty4,
                                                      ref decimal? BrkQty5,
                                                      ref decimal? BrkCost1,
                                                      ref decimal? BrkCost2,
                                                      ref decimal? BrkCost3,
                                                      ref decimal? BrkCost4,
                                                      ref decimal? BrkCost5,
                                                      ref string Infobar)
        {
            VendNumType _VendNum = VendNum;
            ItemType _Item = Item;
            VendItemType _VendItem = VendItem;
            QtyUnitType _BrkQty1 = BrkQty1;
            QtyUnitType _BrkQty2 = BrkQty2;
            QtyUnitType _BrkQty3 = BrkQty3;
            QtyUnitType _BrkQty4 = BrkQty4;
            QtyUnitType _BrkQty5 = BrkQty5;
            CostPrcType _BrkCost1 = BrkCost1;
            CostPrcType _BrkCost2 = BrkCost2;
            CostPrcType _BrkCost3 = BrkCost3;
            CostPrcType _BrkCost4 = BrkCost4;
            CostPrcType _BrkCost5 = BrkCost5;
            Infobar _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Homepage_GetItemVendPriceBrkInfoSp";

                appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "VendItem", _VendItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BrkQty1", _BrkQty1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "BrkQty2", _BrkQty2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "BrkQty3", _BrkQty3, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "BrkQty4", _BrkQty4, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "BrkQty5", _BrkQty5, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "BrkCost1", _BrkCost1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "BrkCost2", _BrkCost2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "BrkCost3", _BrkCost3, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "BrkCost4", _BrkCost4, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "BrkCost5", _BrkCost5, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                BrkQty1 = _BrkQty1;
                BrkQty2 = _BrkQty2;
                BrkQty3 = _BrkQty3;
                BrkQty4 = _BrkQty4;
                BrkQty5 = _BrkQty5;
                BrkCost1 = _BrkCost1;
                BrkCost2 = _BrkCost2;
                BrkCost3 = _BrkCost3;
                BrkCost4 = _BrkCost4;
                BrkCost5 = _BrkCost5;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
