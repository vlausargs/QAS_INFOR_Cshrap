//PROJECT NAME: CSIMaterial
//CLASS NAME: DeleteLot.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IDeleteLot
    {
        int DeleteLotSp(ItemType BegItem,
                        ItemType EndItem,
                        LotType BegLot,
                        LotType EndLot,
                        ref InfobarType Infobar);
    }

    public class DeleteLot : IDeleteLot
    {
        readonly IApplicationDB appDB;

        public DeleteLot(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int DeleteLotSp(ItemType BegItem,
                               ItemType EndItem,
                               LotType BegLot,
                               LotType EndLot,
                               ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteLotSp";

                appDB.AddCommandParameter(cmd, "BegItem", BegItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndItem", EndItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BegLot", BegLot, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndLot", EndLot, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
