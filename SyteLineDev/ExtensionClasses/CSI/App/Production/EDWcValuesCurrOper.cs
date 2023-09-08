//PROJECT NAME: CSIProduct
//CLASS NAME: EDWcValuesCurrOper.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface IEDWcValuesCurrOper
    {
        int EDWcValuesCurrOperSp(ItemType Item,
                                 JobType Job,
                                 SuffixType Suffix,
                                 JobTypeType JobType,
                                 WcType Wc,
                                 ref ListYesNoType EcnTrack,
                                 ref Infobar Infobar);
    }

    public class EDWcValuesCurrOper : IEDWcValuesCurrOper
    {
        readonly IApplicationDB appDB;

        public EDWcValuesCurrOper(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int EDWcValuesCurrOperSp(ItemType Item,
                                        JobType Job,
                                        SuffixType Suffix,
                                        JobTypeType JobType,
                                        WcType Wc,
                                        ref ListYesNoType EcnTrack,
                                        ref Infobar Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EDWcValuesCurrOperSp";

                appDB.AddCommandParameter(cmd, "Item", Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Job", Job, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Suffix", Suffix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "JobType", JobType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Wc", Wc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EcnTrack", EcnTrack, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
