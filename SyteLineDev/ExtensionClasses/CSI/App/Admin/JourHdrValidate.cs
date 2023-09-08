//PROJECT NAME: CSIAdmin
//CLASS NAME: JourHdrValidate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Admin
{
    public interface IJourHdrValidate
    {
        int JourHdrValidateSp(JourControlPrefixType NewPrefix,
                              JournalIdType JournalId,
                              ref InfobarType Infobar);
    }

    public class JourHdrValidate : IJourHdrValidate
    {
        IApplicationDB appDB;

        public JourHdrValidate(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int JourHdrValidateSp(JourControlPrefixType NewPrefix,
                                     JournalIdType JournalId,
                                     ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "JourHdrValidateSp";

                appDB.AddCommandParameter(cmd, "NewPrefix", NewPrefix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "JournalId", JournalId, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}

