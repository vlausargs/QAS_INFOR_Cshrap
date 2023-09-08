//PROJECT NAME: CSIDataCollection
//CLASS NAME: DcsfcOperNumValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.DataCollection
{
    public interface IDcsfcOperNumValid
    {
        int DcsfcOperNumValidSp(JobType InJob,
                                SuffixType InSuffix,
                                OperNumType InOperNum,
                                ref InfobarType Infobar);
    }

    public class DcsfcOperNumValid : IDcsfcOperNumValid
    {
        readonly IApplicationDB appDB;

        public DcsfcOperNumValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int DcsfcOperNumValidSp(JobType InJob,
                                       SuffixType InSuffix,
                                       OperNumType InOperNum,
                                       ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DcsfcOperNumValidSp";

                appDB.AddCommandParameter(cmd, "InJob", InJob, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InSuffix", InSuffix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InOperNum", InOperNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}