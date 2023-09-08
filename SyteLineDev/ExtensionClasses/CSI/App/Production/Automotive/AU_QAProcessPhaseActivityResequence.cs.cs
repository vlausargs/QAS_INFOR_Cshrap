//PROJECT NAME: CSIAUIndPack
//CLASS NAME: AU_QAProcessPhaseActivityResequence.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.Automotive
{
    public interface IAU_QAProcessPhaseActivityResequence
    {
        int AU_QAProcessPhaseActivityResequenceSp(AU_QAProcessIDType QAProcess,
                                                  SequenceType Sequence);
    }

    public class AU_QAProcessPhaseActivityResequence : IAU_QAProcessPhaseActivityResequence
    {
        readonly IApplicationDB appDB;

        public AU_QAProcessPhaseActivityResequence(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int AU_QAProcessPhaseActivityResequenceSp(AU_QAProcessIDType QAProcess,
                                                         SequenceType Sequence)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AU_QAProcessPhaseActivityResequenceSp";

                appDB.AddCommandParameter(cmd, "QAProcess", QAProcess, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Sequence", Sequence, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
