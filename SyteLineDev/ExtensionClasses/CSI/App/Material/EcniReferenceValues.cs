//PROJECT NAME: CSIMaterial
//CLASS NAME: EcniReferenceValues.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IEcniReferenceValues
    {
        int EcniReferenceValuesSp(JobType InJob,
                                  SuffixType InSuffix,
                                  OperNumType InOperNum,
                                  JobmatlSequenceType InSequence,
                                  JobRefSeqType InRefSeq,
                                  ref ItemType OutItem,
                                  ref DescriptionType OutDescription,
                                  ref WcType OutWc,
                                  ref DescriptionType OutWcDesc,
                                  ref BubbleType OutBubble,
                                  ref RefDesignatorType OutRefDes,
                                  ref AssemblySeqType OutAssySeq,
                                  ref FlagNyType OutValidOper,
                                  ref FlagNyType OutValidSeq);
    }

    public class EcniReferenceValues : IEcniReferenceValues
    {
        readonly IApplicationDB appDB;

        public EcniReferenceValues(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int EcniReferenceValuesSp(JobType InJob,
                                         SuffixType InSuffix,
                                         OperNumType InOperNum,
                                         JobmatlSequenceType InSequence,
                                         JobRefSeqType InRefSeq,
                                         ref ItemType OutItem,
                                         ref DescriptionType OutDescription,
                                         ref WcType OutWc,
                                         ref DescriptionType OutWcDesc,
                                         ref BubbleType OutBubble,
                                         ref RefDesignatorType OutRefDes,
                                         ref AssemblySeqType OutAssySeq,
                                         ref FlagNyType OutValidOper,
                                         ref FlagNyType OutValidSeq)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EcniReferenceValuesSp";

                appDB.AddCommandParameter(cmd, "InJob", InJob, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InSuffix", InSuffix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InOperNum", InOperNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InSequence", InSequence, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InRefSeq", InRefSeq, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OutItem", OutItem, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutDescription", OutDescription, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutWc", OutWc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutWcDesc", OutWcDesc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutBubble", OutBubble, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutRefDes", OutRefDes, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutAssySeq", OutAssySeq, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutValidOper", OutValidOper, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutValidSeq", OutValidSeq, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
