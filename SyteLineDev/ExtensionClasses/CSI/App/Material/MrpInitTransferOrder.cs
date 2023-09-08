//PROJECT NAME: CSIMaterial
//CLASS NAME: MrpInitTransferOrder.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IMrpInitTransferOrder
    {
        int MrpInitTransferOrderSp(ItemType Item,
                                   ref SiteType FromSite,
                                   ref WhseType FromWhse,
                                   ref SiteType ToSite,
                                   ref WhseType ToWhse);
    }

    public class MrpInitTransferOrder : IMrpInitTransferOrder
    {
        readonly IApplicationDB appDB;

        public MrpInitTransferOrder(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int MrpInitTransferOrderSp(ItemType Item,
                                          ref SiteType FromSite,
                                          ref WhseType FromWhse,
                                          ref SiteType ToSite,
                                          ref WhseType ToWhse)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "MrpInitTransferOrderSp";

                appDB.AddCommandParameter(cmd, "Item", Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FromSite", FromSite, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "FromWhse", FromWhse, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ToSite", ToSite, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ToWhse", ToWhse, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
