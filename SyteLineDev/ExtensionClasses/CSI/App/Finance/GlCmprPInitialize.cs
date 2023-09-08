//PROJECT NAME: CSIFinance
//CLASS NAME: GlCmprPInitialize.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance
{
    public interface IGlCmprPInitialize
    {
        int GlCmprPInitializeSp(ref DateType RPeriodsPerStart,
                                ref InfobarType Infobar);
    }

    public class GlCmprPInitialize : IGlCmprPInitialize
    {
        readonly IApplicationDB appDB;

        public GlCmprPInitialize(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int GlCmprPInitializeSp(ref DateType RPeriodsPerStart,
                                       ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GlCmprPInitializeSp";

                appDB.AddCommandParameter(cmd, "RPeriodsPerStart", RPeriodsPerStart, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}