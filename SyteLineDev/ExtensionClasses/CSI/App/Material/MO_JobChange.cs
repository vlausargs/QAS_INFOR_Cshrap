//PROJECT NAME: CSIMaterial
//CLASS NAME: MO_JobChange.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IMO_JobChange
    {
        int MO_JobChangeSp(JobType Job,
                           SuffixType Suffix,
                           ItemType Item,
                           WhseType Whse,
                           ref LocType Loc,
                           ref LotType Lot,
                           ref TransRestrictionCodeType TrxRestrictCode);
    }

    public class MO_JobChange : IMO_JobChange
    {
        readonly IApplicationDB appDB;

        public MO_JobChange(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int MO_JobChangeSp(JobType Job,
                                  SuffixType Suffix,
                                  ItemType Item,
                                  WhseType Whse,
                                  ref LocType Loc,
                                  ref LotType Lot,
                                  ref TransRestrictionCodeType TrxRestrictCode)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "MO_JobChangeSp";

                appDB.AddCommandParameter(cmd, "Job", Job, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Suffix", Suffix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Item", Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Whse", Whse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Loc", Loc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Lot", Lot, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TrxRestrictCode", TrxRestrictCode, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
