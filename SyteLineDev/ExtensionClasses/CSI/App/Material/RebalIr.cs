//PROJECT NAME: CSIMaterial
//CLASS NAME: RebalIr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IRebalIr
    {
        int RebalIrSp(ref InfobarType Infobar);
    }

    public class RebalIr : IRebalIr
    {
        readonly IApplicationDB appDB;

        public RebalIr(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int RebalIrSp(ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "RebalIrSp";

                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
