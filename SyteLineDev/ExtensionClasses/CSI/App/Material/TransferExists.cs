//PROJECT NAME: CSIMaterial
//CLASS NAME: TransferExists.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface ITransferExists
    {
        int TransferExistsSp(ItemType TrnNum,
                             ItemType Item,
                             ref SiteType FromSite,
                             ref WhseType FromWhse,
                             ref SiteType ToSite,
                             ref WhseType ToWhse,
                             ref FlagNyType TransferExists,
                             ref InfobarType Infobar);
    }

    public class TransferExists : ITransferExists
    {
        readonly IApplicationDB appDB;

        public TransferExists(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int TransferExistsSp(ItemType TrnNum,
                                    ItemType Item,
                                    ref SiteType FromSite,
                                    ref WhseType FromWhse,
                                    ref SiteType ToSite,
                                    ref WhseType ToWhse,
                                    ref FlagNyType TransferExists,
                                    ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TransferExistsSp";

                appDB.AddCommandParameter(cmd, "TrnNum", TrnNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Item", Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FromSite", FromSite, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "FromWhse", FromWhse, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ToSite", ToSite, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ToWhse", ToWhse, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TransferExists", TransferExists, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
