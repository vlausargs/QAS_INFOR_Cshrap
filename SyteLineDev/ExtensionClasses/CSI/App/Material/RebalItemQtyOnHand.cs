//PROJECT NAME: CSIMaterial
//CLASS NAME: RebalItemQtyOnHand.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IRebalItemQtyOnHand
    {
        int RebalItemQtyOnHandSp(ref InfobarType Infobar);
    }

    public class RebalItemQtyOnHand : IRebalItemQtyOnHand
    {
        readonly IApplicationDB appDB;

        public RebalItemQtyOnHand(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int RebalItemQtyOnHandSp(ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "RebalItemQtyOnHandSp";

                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
