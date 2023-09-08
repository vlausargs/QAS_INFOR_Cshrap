//PROJECT NAME: CSIMaterial
//CLASS NAME: UpdateFeatRank.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IUpdateFeatRank
    {
        int UpdateFeatRankSp(ItemType Item,
                             OperNumType OperNum,
                             ref InfobarType Infobar);
    }

    public class UpdateFeatRank : IUpdateFeatRank
    {
        readonly IApplicationDB appDB;

        public UpdateFeatRank(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int UpdateFeatRankSp(ItemType Item,
                                    OperNumType OperNum,
                                    ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateFeatRankSp";

                appDB.AddCommandParameter(cmd, "Item", Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OperNum", OperNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
