//PROJECT NAME: CSIProduct
//CLASS NAME: PsStatValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface IPsStatValid
    {
        int PsStatValidSp(PsStatusType PFromStat,
                          PsStatusType PToStat,
                          ref InfobarType Infobar);
    }

    public class PsStatValid : IPsStatValid
    {
        readonly IApplicationDB appDB;

        public PsStatValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int PsStatValidSp(PsStatusType PFromStat,
                                 PsStatusType PToStat,
                                 ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PsStatValidSp";

                appDB.AddCommandParameter(cmd, "PFromStat", PFromStat, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PToStat", PToStat, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
