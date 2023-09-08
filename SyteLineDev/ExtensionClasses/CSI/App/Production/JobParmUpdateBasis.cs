//PROJECT NAME: CSIProduct
//CLASS NAME: JobParmUpdateBasis.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface IJobParmUpdateBasis
    {
        int JobParmUpdateBasisSp(RunBasisType RunBasis);
    }

    public class JobParmUpdateBasis : IJobParmUpdateBasis
    {
        readonly IApplicationDB appDB;

        public JobParmUpdateBasis(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int JobParmUpdateBasisSp(RunBasisType RunBasis)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "JobParmUpdateBasisSp";

                appDB.AddCommandParameter(cmd, "RunBasis", RunBasis, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
