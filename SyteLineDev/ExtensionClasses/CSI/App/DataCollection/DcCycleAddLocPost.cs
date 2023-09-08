//PROJECT NAME: CSIDataCollection
//CLASS NAME: DcCycleAddLocPost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.DataCollection
{
    public interface IDcCycleAddLocPost
    {
        int DcCycleAddLocPostSP(ItemType DCItemItem,
                                WhseType DCItemWhse,
                                LocType DCItemLoc,
                                ref LotType DCItemLot,
                                ref InfobarType Infobar);
    }

    public class DcCycleAddLocPost : IDcCycleAddLocPost
    {
        readonly IApplicationDB appDB;

        public DcCycleAddLocPost(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int DcCycleAddLocPostSP(ItemType DCItemItem,
                                       WhseType DCItemWhse,
                                       LocType DCItemLoc,
                                       ref LotType DCItemLot,
                                       ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DcCycleAddLocPostSP";

                appDB.AddCommandParameter(cmd, "DCItemItem", DCItemItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DCItemWhse", DCItemWhse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DCItemLoc", DCItemLoc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DCItemLot", DCItemLot, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
