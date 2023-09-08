//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemRsvdValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IItemRsvdValid
    {
        int ItemRsvdValidSp(WhseType Whse,
                            ItemType Item,
                            ref CostMethodType CostMethod,
                            ref DescriptionType Description,
                            ref ListLocLotType IssueBy,
                            ref ListYesNoType LotTracked,
                            ref ListYesNoType Reservable,
                            ref ListYesNoType SerialTracked,
                            ref UMType UM,
                            ref QtyTotlType QtyMrb,
                            ref QtyTotlType QtyOnHand,
                            ref QtyTotlType QtyRsvdCo,
                            ref InfobarType Infobar,
                            ref ListYesNoType TaxFreeMatl);
    }

    public class ItemRsvdValid : IItemRsvdValid
    {
        readonly IApplicationDB appDB;

        public ItemRsvdValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ItemRsvdValidSp(WhseType Whse,
                                   ItemType Item,
                                   ref CostMethodType CostMethod,
                                   ref DescriptionType Description,
                                   ref ListLocLotType IssueBy,
                                   ref ListYesNoType LotTracked,
                                   ref ListYesNoType Reservable,
                                   ref ListYesNoType SerialTracked,
                                   ref UMType UM,
                                   ref QtyTotlType QtyMrb,
                                   ref QtyTotlType QtyOnHand,
                                   ref QtyTotlType QtyRsvdCo,
                                   ref InfobarType Infobar,
                                   ref ListYesNoType TaxFreeMatl)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ItemRsvdValidSp";

                appDB.AddCommandParameter(cmd, "Whse", Whse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Item", Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CostMethod", CostMethod, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Description", Description, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "IssueBy", IssueBy, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "LotTracked", LotTracked, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Reservable", Reservable, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "SerialTracked", SerialTracked, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "UM", UM, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "QtyMrb", QtyMrb, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "QtyOnHand", QtyOnHand, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "QtyRsvdCo", QtyRsvdCo, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TaxFreeMatl", TaxFreeMatl, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
