//PROJECT NAME: CSIMaterial
//CLASS NAME: CoBolPack.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface ICoBolPack
    {
        int CoBolPackSp(TrnNumType PTrnNum,
                        PackNumType PPackSlip,
                        ref BolNumType PBolNum,
                        ref InfobarType Infobar);
    }

    public class CoBolPack : ICoBolPack
    {
        readonly IApplicationDB appDB;

        public CoBolPack(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CoBolPackSp(TrnNumType PTrnNum,
                               PackNumType PPackSlip,
                               ref BolNumType PBolNum,
                               ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CoBolPackSp";

                appDB.AddCommandParameter(cmd, "PTrnNum", PTrnNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PPackSlip", PPackSlip, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PBolNum", PBolNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
