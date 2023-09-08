//PROJECT NAME: CSIProduct
//CLASS NAME: SaveTmpJobRef.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface ISaveTmpJobRef
    {
        int SaveTmpJobRefSp(ListYesNoType IsDelete,
                            JobType PJobmatlJob,
                            SuffixType PJobmatlSuffix,
                            OperNumType PJobmatlOperNum,
                            JobmatlSequenceType PJobmatlSequence,
                            ListYesNoType IsClear);
    }

    public class SaveTmpJobRef : ISaveTmpJobRef
    {
        readonly IApplicationDB appDB;

        public SaveTmpJobRef(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SaveTmpJobRefSp(ListYesNoType IsDelete,
                                   JobType PJobmatlJob,
                                   SuffixType PJobmatlSuffix,
                                   OperNumType PJobmatlOperNum,
                                   JobmatlSequenceType PJobmatlSequence,
                                   ListYesNoType IsClear)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SaveTmpJobRefSp";

                appDB.AddCommandParameter(cmd, "IsDelete", IsDelete, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PJobmatlJob", PJobmatlJob, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PJobmatlSuffix", PJobmatlSuffix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PJobmatlOperNum", PJobmatlOperNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PJobmatlSequence", PJobmatlSequence, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "IsClear", IsClear, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
