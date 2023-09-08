//PROJECT NAME: CSIMaterial
//CLASS NAME: CoBol.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface ICoBol
    {
        int CoBolSp(TrnNumType PTrnNum,
                    ref BolNumType BolNum,
                    ref InfobarType Infobar);
    }

    public class CoBol : ICoBol
    {
        readonly IApplicationDB appDB;

        public CoBol(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CoBolSp(TrnNumType PTrnNum,
                           ref BolNumType BolNum,
                           ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CoBolSp";

                appDB.AddCommandParameter(cmd, "PTrnNum", PTrnNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BolNum", BolNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
