//PROJECT NAME: CSIAUIndPack
//CLASS NAME: AU_QAProcessDefnPhaseResequence.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.Automotive
{
    public interface IAU_QAProcessDefnPhaseResequence
    {
        int AU_QAProcessDefnPhaseResequenceSp(AU_QAProcessType QAProcess);
    }

    public class AU_QAProcessDefnPhaseResequence : IAU_QAProcessDefnPhaseResequence
    {
        readonly IApplicationDB appDB;

        public AU_QAProcessDefnPhaseResequence(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int AU_QAProcessDefnPhaseResequenceSp(AU_QAProcessType QAProcess)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AU_QAProcessDefnPhaseResequenceSp";

                appDB.AddCommandParameter(cmd, "QAProcess", QAProcess, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
