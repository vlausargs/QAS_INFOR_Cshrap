//PROJECT NAME: CSIMaterial
//CLASS NAME: RsvdInvCheckLocValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IRsvdInvCheckLocValid
    {
        int RsvdInvCheckLocValidSp(ItemType Item,
                                   WhseType Whse,
                                   LocType Loc,
                                   LotType Lot,
                                   QtyUnitType QtyRsvd,
                                   ref DescriptionType Description,
                                   ref Infobar Infobar,
                                   ImportDocIdType ImportDocId);
    }

    public class RsvdInvCheckLocValid : IRsvdInvCheckLocValid
    {
        readonly IApplicationDB appDB;

        public RsvdInvCheckLocValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int RsvdInvCheckLocValidSp(ItemType Item,
                                          WhseType Whse,
                                          LocType Loc,
                                          LotType Lot,
                                          QtyUnitType QtyRsvd,
                                          ref DescriptionType Description,
                                          ref Infobar Infobar,
                                          ImportDocIdType ImportDocId)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "RsvdInvCheckLocValidSp";

                appDB.AddCommandParameter(cmd, "Item", Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Whse", Whse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Loc", Loc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Lot", Lot, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "QtyRsvd", QtyRsvd, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Description", Description, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ImportDocId", ImportDocId, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
