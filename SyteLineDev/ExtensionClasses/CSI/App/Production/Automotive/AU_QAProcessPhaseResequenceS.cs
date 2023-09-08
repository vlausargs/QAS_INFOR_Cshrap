//PROJECT NAME: CSIAUIndPack
//CLASS NAME: AU_QAProcessPhaseResequenceS.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.Automotive
{
    public interface IAU_QAProcessPhaseResequenceS
    {
        int AU_QAProcessPhaseResequenceSp(string QAProcess);
    }

    public class AU_QAProcessPhaseResequenceS : IAU_QAProcessPhaseResequenceS
    {
        readonly IApplicationDB appDB;

        public AU_QAProcessPhaseResequenceS(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int AU_QAProcessPhaseResequenceSp(string QAProcess)
        {
            AU_QAProcessIDType _QAProcess = QAProcess;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AU_QAProcessPhaseResequenceSp ";

                appDB.AddCommandParameter(cmd, "QAProcess", _QAProcess, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
