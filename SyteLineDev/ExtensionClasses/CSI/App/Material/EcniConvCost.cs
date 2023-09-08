//PROJECT NAME: CSIMaterial
//CLASS NAME: EcniConvCost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IEcniConvCost
    {
        int EcniConvCostSp(UMType PNewUM,
                           UMType POldUM,
                           ItemType PItem,
                           CustNumType PVendNum,
                           LongListType PArea,
                           ref CostPrcType PMatlCostConv,
                           ref CostPrcType PLbrCostConv,
                           ref CostPrcType PFovhdCostConv,
                           ref CostPrcType PVovhdCostConv,
                           ref CostPrcType POutCostConv,
                           ref CostPrcType PIncPriceConv,
                           ref InfobarType Infobar);
    }

    public class EcniConvCost : IEcniConvCost
    {
        readonly IApplicationDB appDB;

        public EcniConvCost(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int EcniConvCostSp(UMType PNewUM,
                                  UMType POldUM,
                                  ItemType PItem,
                                  CustNumType PVendNum,
                                  LongListType PArea,
                                  ref CostPrcType PMatlCostConv,
                                  ref CostPrcType PLbrCostConv,
                                  ref CostPrcType PFovhdCostConv,
                                  ref CostPrcType PVovhdCostConv,
                                  ref CostPrcType POutCostConv,
                                  ref CostPrcType PIncPriceConv,
                                  ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EcniConvCostSp";

                appDB.AddCommandParameter(cmd, "PNewUM", PNewUM, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "POldUM", POldUM, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PItem", PItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PVendNum", PVendNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PArea", PArea, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PMatlCostConv", PMatlCostConv, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PLbrCostConv", PLbrCostConv, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PFovhdCostConv", PFovhdCostConv, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PVovhdCostConv", PVovhdCostConv, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "POutCostConv", POutCostConv, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PIncPriceConv", PIncPriceConv, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
