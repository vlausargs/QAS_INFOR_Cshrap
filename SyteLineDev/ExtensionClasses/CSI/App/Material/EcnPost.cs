//PROJECT NAME: CSIMaterial
//CLASS NAME: EcnPost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IEcnPost
    {
        int EcnPostSp(EcnNumType SelEcnNum,
                      ref IntType EcnLineCount,
                      ref InfobarType Infobar);
    }

    public class EcnPost : IEcnPost
    {
        readonly IApplicationDB appDB;

        public EcnPost(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int EcnPostSp(EcnNumType SelEcnNum,
                             ref IntType EcnLineCount,
                             ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EcnPostSp";

                appDB.AddCommandParameter(cmd, "SelEcnNum", SelEcnNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EcnLineCount", EcnLineCount, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
