//PROJECT NAME: CSIMaterial
//CLASS NAME: ValidateCoReservation.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IValidateCoReservation
    {
        int ValidateCoReservationSp(RsvdNumType RsvdNum,
                                    CoNumType CoNum,
                                    CoLineType CoLine,
                                    CoReleaseType CoRelease,
                                    ItemType CoItem,
                                    WhseType CoWhse,
                                    LocType CoLoc,
                                    ListYesNoType CoLotTracked,
                                    LotType CoLot,
                                    QtyUnitType CoQty,
                                    UMType CoUM,
                                    CustNumType CoCustNum,
                                    ref Infobar Infobar,
                                    ImportDocIdType ImportDocId,
                                    ListYesNoType TaxFreeMatl);
    }

    public class ValidateCoReservation : IValidateCoReservation
    {
        readonly IApplicationDB appDB;

        public ValidateCoReservation(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ValidateCoReservationSp(RsvdNumType RsvdNum,
                                           CoNumType CoNum,
                                           CoLineType CoLine,
                                           CoReleaseType CoRelease,
                                           ItemType CoItem,
                                           WhseType CoWhse,
                                           LocType CoLoc,
                                           ListYesNoType CoLotTracked,
                                           LotType CoLot,
                                           QtyUnitType CoQty,
                                           UMType CoUM,
                                           CustNumType CoCustNum,
                                           ref Infobar Infobar,
                                           ImportDocIdType ImportDocId,
                                           ListYesNoType TaxFreeMatl)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ValidateCoReservationSp";

                appDB.AddCommandParameter(cmd, "RsvdNum", RsvdNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoNum", CoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoLine", CoLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoRelease", CoRelease, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoItem", CoItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoWhse", CoWhse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoLoc", CoLoc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoLotTracked", CoLotTracked, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoLot", CoLot, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoQty", CoQty, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoUM", CoUM, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoCustNum", CoCustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ImportDocId", ImportDocId, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TaxFreeMatl", TaxFreeMatl, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
