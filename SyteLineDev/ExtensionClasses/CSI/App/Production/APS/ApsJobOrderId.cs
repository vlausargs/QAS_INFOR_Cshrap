//PROJECT NAME: CSIAPS
//CLASS NAME: ApsJobOrderId.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.APS
{
    public interface IApsJobOrderId
    {
        int ApsJobOrderIdSp(JobType PJob,
                            SuffixType PSuffix,
                            ref ApsOrderType PApsOrderId);
        string ApsJobOrderIdFn(
            string PJob,
            int? PSuffix);
    }

    public class ApsJobOrderId : IApsJobOrderId
    {
        readonly IApplicationDB appDB;

        public ApsJobOrderId(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ApsJobOrderIdSp(JobType PJob,
                                   SuffixType PSuffix,
                                   ref ApsOrderType PApsOrderId)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ApsJobOrderIdSp";

                appDB.AddCommandParameter(cmd, "PJob", PJob, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PSuffix", PSuffix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PApsOrderId", PApsOrderId, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }

        public string ApsJobOrderIdFn(
            string PJob,
            int? PSuffix)
        {
            JobType _PJob = PJob;
            SuffixType _PSuffix = PSuffix;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  dbo.[ApsJobOrderId](@PJob, @PSuffix)";

                appDB.AddCommandParameter(cmd, "PJob", _PJob, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PSuffix", _PSuffix, ParameterDirection.Input);

                var Output = appDB.ExecuteScalar<string>(cmd);

                return Output;
            }
        }
    }
}