//PROJECT NAME: CSICustomer
//CLASS NAME: CoPackingSlipQtyConv.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface ICoPackingSlipQtyConv
    {
        int CoPackingSlipQtyConvSp(QtyUnitType QuantityToPackConv,
                                   ItemType Item,
                                   UMType UM,
                                   CustNumType CustNum,
                                   ref QtyUnitType QuantityToPack,
                                   ref InfobarType Infobar);
    }

    public class CoPackingSlipQtyConv : ICoPackingSlipQtyConv
    {
        readonly IApplicationDB appDB;

        public CoPackingSlipQtyConv(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CoPackingSlipQtyConvSp(QtyUnitType QuantityToPackConv,
                                          ItemType Item,
                                          UMType UM,
                                          CustNumType CustNum,
                                          ref QtyUnitType QuantityToPack,
                                          ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CoPackingSlipQtyConvSp";

                appDB.AddCommandParameter(cmd, "QuantityToPackConv", QuantityToPackConv, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Item", Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UM", UM, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CustNum", CustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "QuantityToPack", QuantityToPack, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
