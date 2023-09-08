//PROJECT NAME: CSIMaterial
//CLASS NAME: ASNRecalc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IASNRecalc
    {
        int ASNRecalcSp(CoTrnNumType TrnNum,
                        BolNumType BolNum,
                        ref AmountType NewFreightCharges,
                        ref AmountType NewCodAmount,
                        ref AmountType NewTotalCharges,
                        ref InfobarType PromptMsg,
                        ref InfobarType PromptButtons);
    }

    public class ASNRecalc : IASNRecalc
    {
        readonly IApplicationDB appDB;

        public ASNRecalc(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ASNRecalcSp(CoTrnNumType TrnNum,
                               BolNumType BolNum,
                               ref AmountType NewFreightCharges,
                               ref AmountType NewCodAmount,
                               ref AmountType NewTotalCharges,
                               ref InfobarType PromptMsg,
                               ref InfobarType PromptButtons)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ASNRecalcSp";

                appDB.AddCommandParameter(cmd, "TrnNum", TrnNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BolNum", BolNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "NewFreightCharges", NewFreightCharges, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "NewCodAmount", NewCodAmount, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "NewTotalCharges", NewTotalCharges, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptMsg", PromptMsg, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptButtons", PromptButtons, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
