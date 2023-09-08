//PROJECT NAME: CSIMaterial
//CLASS NAME: MiscIssueGetLotAndLoc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IMiscIssueGetLotAndLoc
    {
        int MiscIssueGetLotAndLocSp(WhseType Whse,
                                  ItemType Item,
                                  ref LocType Loc,
                                  ref LotType Lot,
                                  ref ImportDocIdType ImportDocId,
                                  ref TransRestrictionCodeType TrxRestrictCode);
    }

    public class MiscIssueGetLotAndLoc : IMiscIssueGetLotAndLoc
    {
        readonly IApplicationDB appDB;

        public MiscIssueGetLotAndLoc(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int MiscIssueGetLotAndLocSp(WhseType Whse,
                                         ItemType Item,
                                         ref LocType Loc,
                                         ref LotType Lot,
                                         ref ImportDocIdType ImportDocId,
                                         ref TransRestrictionCodeType TrxRestrictCode)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "MiscIssueGetLotAndLoc";

                appDB.AddCommandParameter(cmd, "Whse", Whse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Item", Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Loc", Loc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Lot", Lot, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ImportDocId", ImportDocId, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TrxRestrictCode", TrxRestrictCode, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
