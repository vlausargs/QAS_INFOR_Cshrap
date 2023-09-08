//PROJECT NAME: CSIDataCollection
//CLASS NAME: DcsfcNextOperValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.DataCollection
{
    public interface IDcsfcNextOperValid
    {
        int DcsfcNextOperValidSp(JobType InJob,
                                 SuffixType InSuffix,
                                 OperNumType InNextOper,
                                 ref InfobarType Infobar);
    }

    public class DcsfcNextOperValid : IDcsfcNextOperValid
    {
        readonly IApplicationDB appDB;

        public DcsfcNextOperValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int DcsfcNextOperValidSp(JobType InJob,
                                        SuffixType InSuffix,
                                        OperNumType InNextOper,
                                        ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DcsfcNextOperValidSp";

                appDB.AddCommandParameter(cmd, "InJob", InJob, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InSuffix", InSuffix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InNextOper", InNextOper, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}