//PROJECT NAME: CSIAUIndPack
//CLASS NAME: AU_QAProcessDefnPhaseActivityResequence.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.Automotive
{
    public interface IAU_QAProcessDefnPhaseActivityResequence
    {
        int AU_QAProcessDefnPhaseActivityResequenceSp(AU_QAProcessType QAProcess,
                                                      SequenceType Sequence);
    }

    public class AU_QAProcessDefnPhaseActivityResequence : IAU_QAProcessDefnPhaseActivityResequence
    {
        readonly IApplicationDB appDB;

        public AU_QAProcessDefnPhaseActivityResequence(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int AU_QAProcessDefnPhaseActivityResequenceSp(AU_QAProcessType QAProcess,
                                                             SequenceType Sequence)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AU_QAProcessDefnPhaseActivityResequenceSp";

                appDB.AddCommandParameter(cmd, "QAProcess", QAProcess, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Sequence", Sequence, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
