//PROJECT NAME: CSIProduct
//CLASS NAME: CoProductPostDelete.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface ICoProductPostDelete
    {
        int CoProductPostDeleteSp(JobType Job,
                                  SuffixType Suffix,
                                  ItemType Item,
                                  ref InfobarType Infobar);
    }

    public class CoProductPostDelete : ICoProductPostDelete
    {
        readonly IApplicationDB appDB;

        public CoProductPostDelete(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CoProductPostDeleteSp(JobType Job,
                                         SuffixType Suffix,
                                         ItemType Item,
                                         ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CoProductPostDeleteSp";

                appDB.AddCommandParameter(cmd, "Job", Job, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Suffix", Suffix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Item", Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
