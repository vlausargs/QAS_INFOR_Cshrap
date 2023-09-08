//PROJECT NAME: CSIMaterial
//CLASS NAME: CoInitBol.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface ICoInitBol
    {
        int CoInitBolSp(TrnNumType PTrnNum,
                        BolNumType PBolNum,
                        PackNumType PPackNum,
                        FlagNyType PCopyFromPackSlip,
                        ref InfobarType Infobar);
    }

    public class CoInitBol : ICoInitBol
    {
        readonly IApplicationDB appDB;

        public CoInitBol(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CoInitBolSp(TrnNumType PTrnNum,
                               BolNumType PBolNum,
                               PackNumType PPackNum,
                               FlagNyType PCopyFromPackSlip,
                               ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CoInitBolSp";

                appDB.AddCommandParameter(cmd, "PTrnNum", PTrnNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PBolNum", PBolNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PPackNum", PPackNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PCopyFromPackSlip", PCopyFromPackSlip, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
