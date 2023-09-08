//PROJECT NAME: CSIMaterial
//CLASS NAME: RebalItemQtyTrn.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IRebalItemQtyTrn
    {
        int RebalItemQtyTrnSp(ref InfobarType Infobar);
    }

    public class RebalItemQtyTrn : IRebalItemQtyTrn
    {
        readonly IApplicationDB appDB;

        public RebalItemQtyTrn(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int RebalItemQtyTrnSp(ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "RebalItemQtyTrnSp";

                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
