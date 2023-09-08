//PROJECT NAME: CSICustomer
//CLASS NAME: CoReleaseValidQtyOrdered.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface ICoReleaseValidQtyOrdered
    {
        int CoReleaseValidQtyOrderedSp(CoNumType CoNum,
                                       CoLineType CoLine,
                                       CoLineType CoRelease,
                                       ItemType Item,
                                       UMType UM,
                                       CustNumType CoCustNum,
                                       CurrCodeType CurrCode,
                                       PriceCodeType ItemPriceCode,
                                       QtyUnitType QtyOrderedConv,
                                       ItemType CustItem,
                                       SiteType ShipSite,
                                       GenericDateType CoOrderDate,
                                       WhseType Whse,
                                       RefTypeIJKPRTType RefType,
                                       ref AmountType Price,
                                       ref QtyUnitNoNegType QtyReady,
                                       ref QtyUnitNoNegType QtyReadyConv,
                                       ref InfobarType Infobar);
    }

    public class CoReleaseValidQtyOrdered : ICoReleaseValidQtyOrdered
    {
        readonly IApplicationDB appDB;

        public CoReleaseValidQtyOrdered(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CoReleaseValidQtyOrderedSp(CoNumType CoNum,
                                              CoLineType CoLine,
                                              CoLineType CoRelease,
                                              ItemType Item,
                                              UMType UM,
                                              CustNumType CoCustNum,
                                              CurrCodeType CurrCode,
                                              PriceCodeType ItemPriceCode,
                                              QtyUnitType QtyOrderedConv,
                                              ItemType CustItem,
                                              SiteType ShipSite,
                                              GenericDateType CoOrderDate,
                                              WhseType Whse,
                                              RefTypeIJKPRTType RefType,
                                              ref AmountType Price,
                                              ref QtyUnitNoNegType QtyReady,
                                              ref QtyUnitNoNegType QtyReadyConv,
                                              ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CoReleaseValidQtyOrderedSp";

                appDB.AddCommandParameter(cmd, "CoNum", CoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoLine", CoLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoRelease", CoRelease, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Item", Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UM", UM, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoCustNum", CoCustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CurrCode", CurrCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ItemPriceCode", ItemPriceCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "QtyOrderedConv", QtyOrderedConv, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CustItem", CustItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ShipSite", ShipSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoOrderDate", CoOrderDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Whse", Whse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RefType", RefType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Price", Price, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "QtyReady", QtyReady, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "QtyReadyConv", QtyReadyConv, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
