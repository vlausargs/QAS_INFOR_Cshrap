//PROJECT NAME: CSIMaterial
//CLASS NAME: VerifyUniqueLot.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IVerifyUniqueLot
    {
        int VerifyUniqueLotSp(ref InfobarType Infobar);
    }

    public class VerifyUniqueLot : IVerifyUniqueLot
    {
        readonly IApplicationDB appDB;

        public VerifyUniqueLot(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int VerifyUniqueLotSp(ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "VerifyUniqueLotSp";

                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
