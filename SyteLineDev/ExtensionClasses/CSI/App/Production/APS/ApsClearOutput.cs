//PROJECT NAME: CSIAPS
//CLASS NAME: ApsClearOutput.cs

using CSI.Data.SQL.UDDT;
using CSI.MG;
using System;
using System.Data;

namespace CSI.Production.APS
{
    public interface IApsClearOutput
    {
        int ApsClearOutputSp();
    }

    public class ApsClearOutput : IApsClearOutput
    {
        readonly IApplicationDB appDB;

        public ApsClearOutput(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ApsClearOutputSp()
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ApsClearOutputSp";

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
