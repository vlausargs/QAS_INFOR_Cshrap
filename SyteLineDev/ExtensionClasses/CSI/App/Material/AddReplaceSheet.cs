//PROJECT NAME: CSIMaterial
//CLASS NAME: AddReplaceSheet.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IAddReplaceSheet
    {
        int AddReplaceSheetSp(ref SheetTagNumType SheetNum,
                              ref ItemType Item,
                              ref LocType Loc,
                              ref LotType Lot,
                              ref SerNumType SerNum,
                              ref SheetTagNumType TagNum,
                              ref SheetTagNumType TagXref,
                              ref QtyUnitNoNegType CountQty,
                              ref PhyinvPostStatusType PostStat,
                              ref PhyinvPostStatusType DerPostStat,
                              ref ListYesNoType Approved,
                              ref PhyinvCntStatusType CntStat,
                              ref PhyinvTypeType PhyType,
                              ref PhyinvStatusType Stat,
                              ref ListYesNoType LotTracked,
                              ref ListYesNoType SerialTracked,
                              ref ListYesNoType NewSheet,
                              ref InfobarType Infobar,
                              ref ImportDocIdType ImportDocId,
                              ref ListYesNoType TaxFreeMatl);
    }

    public class AddReplaceSheet : IAddReplaceSheet
    {
        readonly IApplicationDB appDB;

        public AddReplaceSheet(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int AddReplaceSheetSp(ref SheetTagNumType SheetNum,
                                     ref ItemType Item,
                                     ref LocType Loc,
                                     ref LotType Lot,
                                     ref SerNumType SerNum,
                                     ref SheetTagNumType TagNum,
                                     ref SheetTagNumType TagXref,
                                     ref QtyUnitNoNegType CountQty,
                                     ref PhyinvPostStatusType PostStat,
                                     ref PhyinvPostStatusType DerPostStat,
                                     ref ListYesNoType Approved,
                                     ref PhyinvCntStatusType CntStat,
                                     ref PhyinvTypeType PhyType,
                                     ref PhyinvStatusType Stat,
                                     ref ListYesNoType LotTracked,
                                     ref ListYesNoType SerialTracked,
                                     ref ListYesNoType NewSheet,
                                     ref InfobarType Infobar,
                                     ref ImportDocIdType ImportDocId,
                                     ref ListYesNoType TaxFreeMatl)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddReplaceSheetSp";

                appDB.AddCommandParameter(cmd, "SheetNum", SheetNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Item", Item, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Loc", Loc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Lot", Lot, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "SerNum", SerNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TagNum", TagNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TagXref", TagXref, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CountQty", CountQty, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PostStat", PostStat, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "DerPostStat", DerPostStat, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Approved", Approved, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CntStat", CntStat, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PhyType", PhyType, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Stat", Stat, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "LotTracked", LotTracked, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "SerialTracked", SerialTracked, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "NewSheet", NewSheet, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ImportDocId", ImportDocId, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TaxFreeMatl", TaxFreeMatl, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
