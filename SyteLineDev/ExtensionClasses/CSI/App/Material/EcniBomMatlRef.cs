//PROJECT NAME: CSIMaterial
//CLASS NAME: EcniBomMatlRef.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IEcniBomMatlRef
    {
        int EcniBomMatlRefSp(LongListType InJob,
                             LongListType InSuffix,
                             LongListType InOperNum,
                             LongListType InSequence,
                             LongListType InRefSeq,
                             ref FlagNyType OutRefExists);
    }

    public class EcniBomMatlRef : IEcniBomMatlRef
    {
        readonly IApplicationDB appDB;

        public EcniBomMatlRef(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int EcniBomMatlRefSp(LongListType InJob,
                                    LongListType InSuffix,
                                    LongListType InOperNum,
                                    LongListType InSequence,
                                    LongListType InRefSeq,
                                    ref FlagNyType OutRefExists)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EcniBomMatlRefSp";

                appDB.AddCommandParameter(cmd, "InJob", InJob, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InSuffix", InSuffix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InOperNum", InOperNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InSequence", InSequence, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InRefSeq", InRefSeq, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OutRefExists", OutRefExists, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
