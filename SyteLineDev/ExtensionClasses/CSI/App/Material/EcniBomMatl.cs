//PROJECT NAME: CSIMaterial
//CLASS NAME: EcniBomMatl.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IEcniBomMatl
    {
        int EcniBomMatlSp(LongListType InJob,
                          LongListType InSuffix,
                          LongListType InOperNum,
                          LongListType InSequence,
                          ref FlagNyType OutOperExists,
                          ref FlagNyType OutSeqExists);
    }

    public class EcniBomMatl : IEcniBomMatl
    {
        readonly IApplicationDB appDB;

        public EcniBomMatl(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int EcniBomMatlSp(LongListType InJob,
                                 LongListType InSuffix,
                                 LongListType InOperNum,
                                 LongListType InSequence,
                                 ref FlagNyType OutOperExists,
                                 ref FlagNyType OutSeqExists)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EcniBomMatlSp";

                appDB.AddCommandParameter(cmd, "InJob", InJob, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InSuffix", InSuffix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InOperNum", InOperNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InSequence", InSequence, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OutOperExists", OutOperExists, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutSeqExists", OutSeqExists, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
