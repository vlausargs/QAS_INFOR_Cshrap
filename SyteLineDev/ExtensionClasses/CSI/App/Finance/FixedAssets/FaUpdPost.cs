//PROJECT NAME: CSIFinance
//CLASS NAME: FaUpdPost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.FixedAssets
{
    public interface IFaUpdPost
    {
        int FaUpdPostSp(TokenType PUserID,
                        ref InfobarType Infobar);
    }

    public class FaUpdPost : IFaUpdPost
    {
        readonly IApplicationDB appDB;

        public FaUpdPost(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int FaUpdPostSp(TokenType PUserID,
                               ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "FaUpdPostSp";

                appDB.AddCommandParameter(cmd, "PUserID", PUserID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
