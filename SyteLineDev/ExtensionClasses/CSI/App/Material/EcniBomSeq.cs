//PROJECT NAME: CSIMaterial
//CLASS NAME: EcniBomSeq.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IEcniBomSeq
    {
        int EcniBomSeqSp(LongListType InJob,
                         LongListType InSuffix,
                         LongListType InOperNum,
                         LongListType InSequence,
                         LongListType InBomSeq,
                         ref FlagNyType OutExists);
    }

    public class EcniBomSeq : IEcniBomSeq
    {
        readonly IApplicationDB appDB;

        public EcniBomSeq(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int EcniBomSeqSp(LongListType InJob,
                                LongListType InSuffix,
                                LongListType InOperNum,
                                LongListType InSequence,
                                LongListType InBomSeq,
                                ref FlagNyType OutExists)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EcniBomSeqSp";

                appDB.AddCommandParameter(cmd, "InJob", InJob, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InSuffix", InSuffix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InOperNum", InOperNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InSequence", InSequence, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InBomSeq", InBomSeq, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OutExists", OutExists, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
