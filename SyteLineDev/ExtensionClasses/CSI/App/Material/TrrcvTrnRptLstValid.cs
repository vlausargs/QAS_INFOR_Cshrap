//PROJECT NAME: CSIMaterial
//CLASS NAME: TrrcvTrnRptLstValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface ITrrcvTrnRptLstValid
    {
        int TrrcvTrnRptLstValidSp(TrnNumType TrnNum,
                                  ref InfobarType Infobar);
    }

    public class TrrcvTrnRptLstValid : ITrrcvTrnRptLstValid
    {
        readonly IApplicationDB appDB;

        public TrrcvTrnRptLstValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int TrrcvTrnRptLstValidSp(TrnNumType TrnNum,
                                         ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TrrcvTrnRptLstValidSp";

                appDB.AddCommandParameter(cmd, "TrnNum", TrnNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
